var app = new Vue({
    el: '#app',
    data: {
        cliente: {
            nome: '',
            endereco: '',
            email: '',
            telefone: ''
        },
        clientes: []
    },
    computed: {
        clientesComputed: {
            get: function () {
                return this.clientes;
            },
            set: function (novoValor) {
                this.clientes = novoValor;
            }
        }
    },
    watch: {
        clientes: function (valor) {
            return this.clientes;
        }
    },
    filters: {

    },
    methods: {
        Salvar: function () {
            try {

                fetch('http://localhost:5000/api/cliente',
                    {
                        method: "POST",
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(this.cliente)
                    })
                    .then(res => {
                        this.BuscarTodos();
                        //this.app.forceUpdate();
                    })
                    .catch(erro => alert(`Erro ao processar a requisição ${erro}`));
                // app.$forceUpdate();
                //this.BuscarTodos();

            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        },
        BuscarTodos: function () {
            try {
                fetch('http://localhost:5000/api/cliente/')
                    .then(res => res.json())
                    .then(res => {
                        this.clientes = res;  
                    })
                    .catch(erro => alert(`Erro ao processar a requisição ${erro}`));
            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        },
        Editar: function () {
            try {

                fetch(`http://localhost:5000/api/cliente/`,
                    {
                        method: "PUT",
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(this.cliente)

                    })
                    .catch(erro => alert(`Erro ao processar a requisição ${erro}`));


            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        },
        Excluir: function () {
            try {

                fetch(`http://localhost:5000/api/cliente/${this.cliente.id}`,
                    {
                        method: "DELETE",
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        }

                    })
                    .catch(erro => alert(`Erro ao processar a requisição ${erro}`));


            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        }
    },
    created() {
        this.BuscarTodos()
    },
    beforeDestroy() {
        this.BuscarTodos()
    }

})
