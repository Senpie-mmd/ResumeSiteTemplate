using System.ComponentModel.DataAnnotations;

namespace MyResumeSite.Models
{
    public class Message
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "* Please enter YourName!")]
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime AddedTime { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "* Please enter Message Title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "* Please enter Message!")]
        public string Body { get; set; }
        [EmailAddress(ErrorMessage = "* Please enter a valid EmailAddress!")]
        [Required(ErrorMessage = "* Please enter Email!")]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
