using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.DTOs.CandidateDTOs
{
    public class CandidateDTO
    {
        public int id { get; set; }
        public string Phone { get; set; }

        public string? ResumeURL { get; set; }
        public string Skill { get; set; }
        public int YearOfExperience { get; set; }

        public int UserID { get; set; }
    }
}
