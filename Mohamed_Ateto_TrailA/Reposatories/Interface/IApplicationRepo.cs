using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface IApplicationRepo : IGenericRepo<Application>
    {
        Task<ICollection<Application>> GetApplicationsWithAuthenticatedCandidate(int Cadidateid);
    }

}
