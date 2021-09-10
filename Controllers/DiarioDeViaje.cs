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
    public class DiarioDeViaje : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public DiarioDeViaje(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiarioDeViaje([FromQuery] DateTime fecha)
        {
            var data = _storedRepository.DWH_SPORY_DiarioDeViaje(fecha);
            return Ok(data);
        }
    }
}
