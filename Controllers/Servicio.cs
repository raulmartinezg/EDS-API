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
    public class Servicio : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public Servicio(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicio([FromQuery] string fecha, int clave)
        {
            var data = _storedRepository.DWH_SPORY_NivelServicio(fecha, clave);
            return Ok(data);
        }
    }
}
