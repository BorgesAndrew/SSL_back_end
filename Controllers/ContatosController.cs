using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContatosController : ControllerBase
    {
        // GET: api/Contatos
        [HttpGet]
        public IEnumerable Get()
        {
            return ContatosRepositorio.ObterContatos();
        }

        // GET: api/Contatos/5
        [HttpGet("{cdContato}")]
        public IEnumerable Get(int cdContato)
        {
            return ContatosRepositorio.ObterContato(cdContato);
        }

        // POST: api/Contatos
        [HttpPost]
        public Contatos Post([FromBody] Contatos contato)
        {
           return ContatosRepositorio.CadastrarContato(contato);
        }

        // PUT: api/Contatos/5
        [HttpPut("{cdContato}")]
        public Contatos Put(int cdContato, [FromBody] Contatos contato)
        {
            return ContatosRepositorio.AtualizarContato(cdContato, contato);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{cdContato}")]
        public void Delete(int cdContato)
        {
             ContatosRepositorio.DeletarContato(cdContato);
        }
    }
}
