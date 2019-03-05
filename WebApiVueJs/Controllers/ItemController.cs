using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVueJs.AcessoDados;
using WebApiVueJs.AcessoDados.Repositorios;
using WebApiVueJs.Model;
using RestSharp;
using RestSharp.Serialization.Json;

namespace WebApiVueJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {       

        [HttpGet]
        public List<ItemsList> Get()
        {

            RestClient restClient = new RestClient(string.Format("https://www.rjstecnologia.com.br/"));
            RestRequest restRequest = new RestRequest(string.Format("documentos/json-teste.json"), Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            List<ItemsList> items = new JsonDeserializer().Deserialize<List<ItemsList>>((restResponse));


            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromBody] Cliente value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            
        }
    }
}
