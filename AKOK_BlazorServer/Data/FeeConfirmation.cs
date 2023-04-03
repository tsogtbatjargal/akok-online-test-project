using System.ComponentModel.DataAnnotations;

namespace AKOK_BlazorServer.Data
{
    public class FeeConfirmation
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }        
        public int ResultNameNumber { get; set; }
        public int? ResultNameNumberHybrid { get; set; }
        public int DynamicsOfLifeNumber { get; set; }
    }
}
