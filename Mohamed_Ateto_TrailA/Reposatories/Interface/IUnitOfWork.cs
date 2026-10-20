using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface IUnitOfWork
    {
        IAuthRepo AuthRepo { get; }
        IJobRepo JobRepo { get; }
        IApplicationRepo ApplicationRepo { get; }
        ICompanyRepo CompanyRepo { get; }
        IGenericRepo<CanditateProfile> CandidateProfile {  get; }

        Task CompleteAsync();
    }
}
