using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required,StringLength(100,MinimumLength = 3)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTime CreateAte { get; set; }

        public CanditateProfile CanditateProfile { get; set; }

        public ICollection<Company> Companys { get; set; }
    }
}
