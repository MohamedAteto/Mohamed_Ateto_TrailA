using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohamed_Ateto_TrailA.Models
{
    public class CanditateProfile
    {
        [Key]
        public int id {  get; set; }
        [Required,Phone]
        public string Phone { get; set; }

        public string? ResumeURL { get; set; }
        [Required,MaxLength(500)]
        public string Skill { get; set; }
        [Range(0,50)]
        public int YearOfExperience { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public ICollection<Application> Applications { get; set; } = new List<Application>();


    }
}
