using EDS_API.Interface;
using EDS_API.Parameters;
using EDS_API.Repositories;
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
    public class RastreoEmbarque : ControllerBase
    {
        private readonly IStoredRepository _storedRepository;

        public RastreoEmbarque(IStoredRepository storedRepository)
        {
            _storedRepository = storedRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRastreoEmbarque([FromQuery] RastreoEmbarqueParameters param)
        {
            var data = _storedRepository.DWH_SPQRY_RastreabilidadViajes(param) ;
            return Ok(data);
        }
    }
}
