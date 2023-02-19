namespace MyResumeSite.Models.ViewModels
{
    public class AdminIndexViewModel
    {
        public AdminInfo AdminInfo { get; set; }
        public List<AdminResume> AdminResumes { get; set; }
        public List<AdminResumeSectionTitle> SectionTitles { get; set; }
        public List<SectionTitleDetail> TitleDetails { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Message> Messages { get; set; }
    }
}
