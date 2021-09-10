using EDS_API.Interface;
using EDS_API.Parameters;
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
    public class Detalle : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public Detalle(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetalle([FromQuery] DetalleParameters param)
        {
            var data = _storedRepository.dbo_SPORY_TiemposViajeEvaluacion(param);
            return Ok(data);
        }
    }
}
