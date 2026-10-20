using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohamed_Ateto_TrailA.DTOs.CandidateDTOs;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadidateProfileController : ControllerBase
    {
        private readonly IUnitOfWork un;
        private readonly IMapper map;

        public CadidateProfileController(IUnitOfWork un, IMapper map)
        {
            this.un = un;
            this.map = map;
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id , UpdateCandidateProfileDTO DTO)
        {
            if (DTO is null)
                return BadRequest("invalid data");

            var item = await un.CandidateProfile.GetById(id);
            if(item is null)
                return NotFound("Not Found");

            map.Map(DTO, item);
            await un.CandidateProfile.Update(id, item);
            await un.CompleteAsync();

            return NoContent();


        }


    }
}
