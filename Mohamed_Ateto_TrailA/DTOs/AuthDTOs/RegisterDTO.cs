using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Candidate";
        public DateTime CreateAte  => DateTime.Now;

    }
}
