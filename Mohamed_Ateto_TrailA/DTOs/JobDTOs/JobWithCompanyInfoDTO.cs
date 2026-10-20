using Mohamed_Ateto_TrailA.DTOs.CompanyDTOs;

namespace Mohamed_Ateto_TrailA.DTOs.JobDTOs
{
    public class JobWithCompanyInfoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public string EmployeeType { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public CompanyDTO CompanyInfo { get; set; }
    }
}
