using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohamed_Ateto_TrailA.DTOs.JobDTOs;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork un;
        private readonly IMapper map;

        public JobController(IUnitOfWork un, IMapper map)
        {
            this.un = un;
            this.map = map;
        }

        [HttpGet("Third Most")]

        public async Task<IActionResult> GetThirdMost()
        {
            var item = await un.JobRepo.GetThirdMostExpensive();

            if (item is null)
                return NotFound("no Data Availble");

            var DTO = map.Map<List<JobDTO>>(item);

            return Ok(DTO);
        }



        [HttpGet("With Company Info")]

        public async Task<IActionResult> With_Company_Info(int jobid)
        {
            var item = await un.JobRepo.GitWithCopanyInfo(jobid);

            if (item is null)
                return NotFound("no Data Availble");
            return Ok(item);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var item = await un.JobRepo.GetById(id);
            if (item is null)
                return BadRequest("not Availble");

            await un.JobRepo.Delete(id);
            await un.CompleteAsync();

            return Ok("Deleted");

        }

        [HttpGet("Search")]

        public async Task<IActionResult> Search(string Name)
        {
            var item = await un.JobRepo.SearchWithTitleAndDescription(Name);

            if (item is null)
                return NotFound("no Data Availble");

            var DTO = map.Map<List<JobDTO>>(item);

            return Ok(DTO);
        }

    }
}
