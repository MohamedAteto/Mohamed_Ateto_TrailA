using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohamed_Ateto_TrailA.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? CoverLetter { get; set; }


        public int CanditaeProfileID { get; set; }
        [ForeignKey(nameof(CanditaeProfileID))]
        public CanditateProfile CanditateProfile { get; set; }


        public int JobID { get; set; }
        [ForeignKey(nameof(JobID))]
        public Job Job { get; set; }
    }
}
