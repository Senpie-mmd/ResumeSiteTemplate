using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyResumeSite.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public bool IsConfirmed { get; set; }
        [Required(ErrorMessage = "* Please enter your Name!")]
        [MaxLength(25)]
        [DisplayName("Name")]
        public string AutherName { get; set; }
        [Required(ErrorMessage = "* Please enter your Email!")]
        [EmailAddress(ErrorMessage = "* Please enter a valid EmailAddress!")]
        [DisplayName("Email")]
        public string AutherEmail { get; set; }
        [Required(ErrorMessage = "* Please enter your FeedBack!")]
        [DisplayName("FeedBack")]
        public string Text { get; set; }
        [Required(ErrorMessage = "* Please rate me from 0 to 10!")]
        [Range(0, 10)]
        [DisplayName("Rate me! (0 to 10)")]
        public double Rate { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
