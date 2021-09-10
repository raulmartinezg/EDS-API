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
    public class TiempoViajeEvaluacion : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public TiempoViajeEvaluacion(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet("{cf}")]
        public async Task<IActionResult> GetRastreoEmbarque(int cf)
        {
            var data = _storedRepository.DWH_SPORY_TiemposViajeEvaluacion(cf);
            return Ok(data);
        }

    }
}
