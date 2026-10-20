using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohamed_Ateto_TrailA.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]

        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required,Range(1,1000000)]
        public decimal Salary { get; set; }
        [Required]
        public string EmployeeType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime Deadline {  get; set; }
        [Required]
        public string Status { get; set; }


        public int CompanyID { get; set; }
        [ForeignKey(nameof(CompanyID))]
        public Company Company { get; set; }

        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
