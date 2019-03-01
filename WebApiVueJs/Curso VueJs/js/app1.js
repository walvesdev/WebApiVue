Vue.component('meu-componente',{
    template: `<div> 
                    <h1>Bem-Vindo!</h1> {{texto01}} {{ nome }} </br> 
                </div>`,
    data: function(){
        return{
            texto01 : 'texto 01'
        }
    },
    props: ['nome']
})

var app = new Vue({
    el: '#app',
    data:{
        mensagem : 'Teste vue 123456',
        titulo:' titulo sapn',
        isVisible: false,
        lista:[
            {texto: "texto 1"},
            {texto: "texto 2"},
            {texto: "texto 3"}
        ],
        meuHTML : '<input type="text"/>',
        contador : 0,
        texto : 'Texto Maiusculo!'
    },
    filters:{
        Maiusculo: function(texto){ return texto.toUpperCase();}
    },
    methods: {
        AumentarContador: function(){
            this.contador ++;
        }
    },
    created() {
        console.log("Iniciando vue")
    },

})