using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Negocio;

namespace WebAPISeguro.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApoliceController : Controller
    {
        private readonly IApoliceNegocio _apoliceNegocio;

        public ApoliceController(IApoliceNegocio apoliceNegocio)
        {
            _apoliceNegocio = apoliceNegocio;
        }
        // GET api/apolice
        [HttpGet]
        public IActionResult Get()
        {
            Retorno<object> oRet = new Retorno<object>();
            oRet = _apoliceNegocio.GetAll();
            
            return Ok(oRet);
        }

        // GET api/apolice/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Retorno<object> oRet = new Retorno<object>();
            oRet = _apoliceNegocio.Get(id);
            
            return Ok(oRet);

        }

        // POST api/apolice
        [HttpPost]
        public IActionResult Post([FromBody] Apolice model)
        {
            Retorno<object> oRet = new Retorno<object>();
            oRet = _apoliceNegocio.Add(model);
            
            return Ok(oRet);

        }

        // PUT api/apolice/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Apolice model)
        {
            Retorno oRet = new Retorno();
            oRet = _apoliceNegocio.Update(id, model);
           
            return Ok(oRet);

        }

        // DELETE api/apolice/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Retorno oRet = new Retorno();
            oRet = _apoliceNegocio.Delete(id);
            
            return Ok(oRet);
        }
    }
}
