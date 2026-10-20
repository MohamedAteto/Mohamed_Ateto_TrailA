using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class ApplicationRepo : GenericRepo<Application>, IApplicationRepo
    {
        private readonly AppDbContext _context;

        public ApplicationRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Application>> GetApplicationsWithAuthenticatedCandidate(int Cadidateid)
        {
        
            var applications = await _context.Applications.Where(c => c.CanditaeProfileID == Cadidateid)
                .ToListAsync();

            return applications;
        }
    }
}
