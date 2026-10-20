using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IJobRepo JobRepo { get; }
        public IAuthRepo AuthRepo { get; }
        public IApplicationRepo ApplicationRepo { get; }
       public IGenericRepo<CanditateProfile> CandidateProfile { get; }

        public ICompanyRepo CompanyRepo { get; }

        public UnitOfWork(AppDbContext context, IAuthRepo authRepo , IJobRepo jobRepo,
            IApplicationRepo applicationRepo , IGenericRepo<CanditateProfile> candidateProfile , ICompanyRepo companyRepo)
        {
            _context = context;
            AuthRepo = authRepo;
            JobRepo = jobRepo;
            ApplicationRepo = applicationRepo;
            CandidateProfile = candidateProfile;
            CompanyRepo = companyRepo;
        }



        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
