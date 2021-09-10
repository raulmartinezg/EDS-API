using EDS_API.Entities;
using EDS_API.Interface;
using EDS_API.Pagination;
using EDS_API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEncuestaPorConcesionario : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public TipoEncuestaPorConcesionario(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTipoEncuestaPorConcesionario([FromQuery]DateTime fecha)
        {
            var data = _storedRepository.DWH_SPORY_ReporteTipoEncuesta(fecha);
            return Ok(data);
        }
    }
}
