using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohamed_Ateto_TrailA.DTOs.CompanyDTOs;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IUnitOfWork un;
        private readonly IMapper map;

        public CompanyController(IUnitOfWork un, IMapper map)
        {
            this.un = un;
            this.map = map;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var items = await un.CompanyRepo.GetMostApplaidJob();

            if(items == null)
                return BadRequest("No data");

            var DTO = map.Map<CompanyDTO>(items);
            return Ok(DTO);
        }
    }
}
