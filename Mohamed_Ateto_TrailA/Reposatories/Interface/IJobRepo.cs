using Mohamed_Ateto_TrailA.DTOs.JobDTOs;
using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<ICollection<Job>> GetThirdMostExpensive();
        Task<JobWithCompanyInfoDTO> GitWithCopanyInfo(int jobid);
        Task<ICollection<Job>> SearchWithTitleAndDescription(string Name);
    }
}
