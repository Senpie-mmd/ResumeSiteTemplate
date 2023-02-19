namespace MyResumeSite.Models.ViewModels
{
    public class ResumeRemoveViewModel
    {
        public AdminResume AdminResume { get; set; }
        public List<AdminResumeSectionTitle> SectionTitles { get; set; }
        public List<SectionTitleDetail> TitleDetails { get; set; }
    }
}
