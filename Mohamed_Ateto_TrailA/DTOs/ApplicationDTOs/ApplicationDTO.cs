using Mohamed_Ateto_TrailA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.DTOs.ApplicationDTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string? CoverLetter { get; set; }


        public int CanditaeProfileID { get; set; }

        public int JobID { get; set; }
    }
}
