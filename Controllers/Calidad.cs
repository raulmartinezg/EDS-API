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
    public class Calidad : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public Calidad(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalidad([FromQuery] string fecha_inicial,string fecha_final)
        {
            var data = _storedRepository.DWH_SPQRY_EncuestaSatisServ(fecha_inicial, fecha_final);
            return Ok(data);
        }
    }
}
