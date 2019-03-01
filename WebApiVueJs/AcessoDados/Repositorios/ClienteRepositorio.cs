using ProjetoBase.AcessoDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVueJs.Model;

namespace WebApiVueJs.AcessoDados.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente, int>
    {
        public ClienteRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
