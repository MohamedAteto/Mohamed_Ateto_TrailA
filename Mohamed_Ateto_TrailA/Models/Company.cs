using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Mohamed_Ateto_TrailA.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; } 
        [Required,MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(100)]

        public string Description { get; set; }

        public string? WebSite { get; set; }
        [Required]
        public string Location { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


        public ICollection<Job> jobs { get; set; }
    }
}
