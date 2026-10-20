using System.ComponentModel.DataAnnotations;

namespace Mohamed_Ateto_TrailA.DTOs.CompanyDTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string? WebSite { get; set; }
        public string Location { get; set; }


        public int UserId { get; set; }
    }
}
