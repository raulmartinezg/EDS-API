using EDS_API.Entities;
using EDS_API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IRepository _repository;

        public LinkController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Folios")]
        public async Task<IActionResult> SyncFolios()
        {
            var data = _repository.GetFolios();
            return Ok(data);
        }

        [HttpGet("Concesionario")]
        public async Task<IActionResult> ConcRuta([FromHeader] int clave)
        {
            var data = _repository.GetConcesionario(clave);
            return Ok(data);
        }

        [HttpPost("Json")]
        public async Task<IActionResult> SendJson(TbhisContenidoViajeSae obj)
        {
            var data = await _repository.InsertJson(obj);
            return Ok(data);
        }
    }
}
