using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyResumeSite.Models
{
    public class SectionTitleDetail
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "* Please enter your Skill!")]
        [MaxLength(20)]
        public string SkillName { get; set; }
        [Range(1, 100, ErrorMessage = "* Please enter a number between 1 & 100!")]
        [Required(ErrorMessage = "* Please enter your knowledge at this Skill!")]
        public int SkillKnowledge { get; set; }
        public int SectionID { get; set; }
        [ForeignKey("SectionID")]
        public AdminResumeSectionTitle AdminResumeSectionTitle { get; set; }
    }
}
