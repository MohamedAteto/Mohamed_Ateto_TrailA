using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.DTOs.JobDTOs
{
    public class JobDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public string EmployeeType { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }

        public int CompanyID { get; set; }
    }
}
