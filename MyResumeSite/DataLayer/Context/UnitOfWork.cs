using MyResumeSite.Data;
using MyResumeSite.DataLayer.Repositories;
using MyResumeSite.DataLayer.Services;
using MyResumeSite.Models;

namespace MyResumeSite.DataLayer.Context
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private ICrudRepository<Comment> _commentRepo;
        public ICrudRepository<Comment> CommentRepo
        {
            get
            {
                if (_commentRepo == null)
                {
                    _commentRepo = new CrudRepository<Comment>(_context);
                }
                return _commentRepo;
            }
        }

        private ICrudRepository<AdminInfo> _adminInfoRepo;
        public ICrudRepository<AdminInfo> AdminInfoRepo
        {
            get
            {
                if (_adminInfoRepo == null)
                {
                    _adminInfoRepo = new CrudRepository<AdminInfo>(_context);
                }
                return _adminInfoRepo;
            }
        }

        private ICrudRepository<AdminResume> _adminResumeRepo;
        public ICrudRepository<AdminResume> AdminResumeRepo
        {
            get
            {
                if (_adminResumeRepo == null)
                {
                    _adminResumeRepo = new CrudRepository<AdminResume>(_context);
                }
                return _adminResumeRepo;
            }
        }

        private ISectionTitleRepository<AdminResumeSectionTitle> _sectionTitleRepo;
        public ISectionTitleRepository<AdminResumeSectionTitle> SectionTitleRepo
        {
            get
            {
                if (_sectionTitleRepo == null)
                {
                    _sectionTitleRepo = new SectionTitleRepository<AdminResumeSectionTitle>(_context);
                }
                return _sectionTitleRepo;
            }
        }

        private ITitleDetailRepository<SectionTitleDetail> _titleDetailRepo;
        public ITitleDetailRepository<SectionTitleDetail> TitleDetailRepo
        {
            get
            {
                if (_titleDetailRepo == null)
                {
                    _titleDetailRepo = new TitleDetailRepositoy<SectionTitleDetail>(_context);
                }
                return _titleDetailRepo;
            }
        }

        private ICrudRepository<Message> _messageRepo;
        public ICrudRepository<Message> MessageRepo
        {
            get
            {
                if (_messageRepo == null)
                {
                    _messageRepo = new CrudRepository<Message>(_context);
                }
                return _messageRepo;
            }
        }

        private IValidationRepository _validationRepo;
        public IValidationRepository ValidationRepo
        {
            get
            {
                if (_validationRepo == null)
                {
                    _validationRepo = new ValidationRepository(_context);
                }
                return _validationRepo;
            }
        }

        private IAdminRepository _adminRepo;
        public IAdminRepository AdminRepo
        {
            get
            {
                if (_adminRepo == null)
                {
                    _adminRepo = new AdminRepository(_context);
                }
                return _adminRepo;
            }
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
