using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohamed_Ateto_TrailA.DTOs.ApplicationDTOs;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork un;
        private readonly IMapper map;

        public ApplicationController(IUnitOfWork un, IMapper map)
        {
            this.un = un;
            this.map = map;
        }



        [HttpPatch]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> UpdateStaus(int id , string Status)
        {
            var item = await un.ApplicationRepo.GetById(id);

            if (item is null)
                return BadRequest("NOt Found");

            if (Status != "Pending" && Status != "UnderReview" && Status != "Accepted" && Status != "Rejected")
                return BadRequest("Invalid Status");

            item .Status = Status;
            await un.ApplicationRepo.Update(id , item);
            await un.CompleteAsync();

            return Ok("Update succfully");


        }

        [HttpGet]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> GetWithCandidate(int id)
        {
            var candidate = await un.AuthRepo.GetById(id);

            if (candidate is null || candidate.Role != "Candidate")
                return NotFound("NOt Exist Or not a Candidate");


            var items = await un.ApplicationRepo.GetApplicationsWithAuthenticatedCandidate(id);

            if (items is null || items.Count == 0)
                return BadRequest("Has NO Applications");

            var DTO = map.Map<List<ApplicationDTO>>(items);

            return Ok(DTO);
            
        }
    }
}
