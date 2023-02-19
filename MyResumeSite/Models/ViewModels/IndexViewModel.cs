namespace MyResumeSite.Models.ViewModels
{
    public class IndexViewModel
    {
        public AdminInfo AdminInfo { get; set; }
        public List<SectionTitleDetail> TitleDetails { get; set; }
        public List<AdminResume> AdminResumes { get; set; }
        public List<AdminResumeSectionTitle> SectionTitle { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}
