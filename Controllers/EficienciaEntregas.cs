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
    public class EficienciaEntregas : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public EficienciaEntregas(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEficienciaEntregas([FromQuery] DateTime fecha_inicial, DateTime fecha_final)
        {
            var data = _storedRepository.DWH_SPORY_EficienciaEntregas(fecha_inicial, fecha_final);
            return Ok(data);
        }
    }
}
