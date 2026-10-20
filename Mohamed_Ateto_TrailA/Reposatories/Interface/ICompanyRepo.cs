using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface ICompanyRepo : IGenericRepo<Company>
    {
        Task<Company> GetMostApplaidJob();
    }
}
