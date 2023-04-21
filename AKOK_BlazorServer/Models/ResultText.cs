using System.ComponentModel.DataAnnotations;

namespace AKOK_BlazorServer.Models
{
    public class ResultText
    {
        public int ID { get; set; }
       
        [Required(ErrorMessage = "Number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number should be greater than 0")]
        public int Number { get; set; }
      
        [Required(ErrorMessage = "Header is required")]
        public string HeaderText { get; set; }
        public string LongText { get; set; }
    }
}
