using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.DTOs.CompanyDTOs;
using Mohamed_Ateto_TrailA.DTOs.JobDTOs;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {

        private readonly AppDbContext _context;

        public JobRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Job>> GetThirdMostExpensive()
        {
            var items = await _context.Jobs
                .OrderByDescending(s => s.Salary)
                .Skip(2)
                .Take(1)
                .ToListAsync();

            return items;
        }

        public async Task<JobWithCompanyInfoDTO> GitWithCopanyInfo(int jobid)
        {
            var item = await _context.Jobs.Include(m => m.Company)
                .Where(s => s.Id == jobid)
                .Select(s => new JobWithCompanyInfoDTO
                {
                 Id = jobid,
                 Title = s.Title,
                 Description = s.Description,
                 EmployeeType = s.EmployeeType,
                 Salary = s.Salary,
                 Location = s.Location,
                 Status = s.Status,
                 Deadline = s.Deadline,
                 CompanyInfo = new CompanyDTO
                 {
                     Id = s.CompanyID,
                     Name = s.Company.Name,
                     Description = s.Company.Description,
                     Location = s.Company.Location,
                     UserId = s.Company.UserId,
                     WebSite = s.Company.WebSite,
                 }

                }).FirstOrDefaultAsync();

            return item;
        }

        public async Task<ICollection<Job>> SearchWithTitleAndDescription(string Name)
        {
            var items = await _context.Jobs
                .Where(s => s.Title.Contains(Name) || s.Description.Contains(Name)).ToListAsync();


            return items;

        }
    }
}
