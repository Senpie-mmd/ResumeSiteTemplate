using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyResumeSite.Models
{
    public class AdminResume
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "* Please enter Title!")]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "* Please pick an Image!")]
        public string Image { get; set; }
        [MaxLength(20)]
        public string TypeID { get; set; }

        public string Body { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public AdminInfo AdminInfo { get; set; }
        [MaxLength(50)]
        public string DateAndTime { get; set; }
        [MaxLength(50)]
        public string SectionInfo { get; set; }
    }
}
