using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.DTOs.CompanyDTOs;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class CompanyRepo : GenericRepo<Company>, ICompanyRepo
    {
        private readonly AppDbContext _conext;

        public CompanyRepo(AppDbContext context) : base(context)
        {
            _conext = context;
        }

        public async Task<Company> GetMostApplaidJob()
        {
            
            var items = await _conext.Companys
                .OrderByDescending(s => s.jobs.Count())
                .FirstOrDefaultAsync();

            return items;



        }
    }
}
