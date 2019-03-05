  

    function GetCliente() {
            var id = $('#id').val().trim();

            var cliente = {
                nome: $('#nome').val().trim(),
                endereco: $('#endereco').val().trim(),
                email: $('#email').val().trim(),
                telefone: $('#telefone').val().trim()
            }
            debugger
            return cliente;
        }
        function Salvar() {
            try {

                var cli = this.GetCliente();

                $.ajax({
                    url: "http://localhost:5000/api/cliente/",
                    type: "post",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(cli)
                })
                debugger;

            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        }
        function  BuscarTodos() {
            try {
                $.ajax({
                    url: 'http://localhost:5000/api/cliente',
                })
                    .done(function (res) {
                        for (var cli of res) {

                            $('.tabela').append(`
                        <tr>
                        <td>${cli.id}</td>
                        <td>${cli.nome}</td>
                        <td>${cli.endereco}</td>
                        <td>${cli.email}</td>
                        <td>${cli.telefone}</td>   
                        </tr>                         
                        `);
                        }
                    })


            } catch (erro) {
                alert(`Erro ${erro}`)
            }
        }
        function Editar() {
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
        }
        function Excluir() {
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
    


$(document).ready(() => {
    this.BuscarTodos();
});
