using EDS_API.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EDS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensualDeViaje : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public MensualDeViaje(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMensualDeViajes([FromQuery] DateTime fecha_inicial, DateTime fecha_final)
        {
            var data = _storedRepository.DWH_SPORY_MensualDeViajes(fecha_inicial,fecha_final);
            return Ok(data);
        }
    }
}
