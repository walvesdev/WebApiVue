using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVueJs.AcessoDados;
using WebApiVueJs.AcessoDados.Repositorios;
using WebApiVueJs.Model;

namespace WebApiVueJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepositorio clienteRepositorio;
        private readonly ApplicationContext context;

        public ClienteController(ClienteRepositorio clienteRepositorio, ApplicationContext context)
        {
            this.clienteRepositorio = clienteRepositorio;
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return clienteRepositorio.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            return clienteRepositorio.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            clienteRepositorio.Inserir(cliente);
            
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromBody] Cliente value)
        {
            DbSet<Cliente> dbset = context.Set<Cliente>();
            try
            {
                if (value != null && dbset.Where(c => c.Id == id).Any())
                {
                    clienteRepositorio.Atualizar(value);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            DbSet<Cliente> dbset = context.Set<Cliente>();
            try
            {
                if (dbset.Where(c => c.Id == id).Any())
                {
                    Cliente cliente = clienteRepositorio.SelecionarPorId(id);
                    clienteRepositorio.Excluir(cliente);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
    }
}
