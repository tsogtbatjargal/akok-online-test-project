using System.ComponentModel.DataAnnotations;

namespace AKOK_BlazorServer.Models
{
    public class ResultText
    {
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string HeaderText { get; set; }
        public string LongText { get; set; }
    }
}
