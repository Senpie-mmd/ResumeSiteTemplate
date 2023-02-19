using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyResumeSite.Models
{
    public class AdminResumeSectionTitle
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "* Please enter SectionTitle")]
        public string SectionTitle { get; set; }
        public int AdminResumeID { get; set; }
        [ForeignKey("AdminResumeID")]
        public AdminResume AdminResume { get; set; }
    }
}
