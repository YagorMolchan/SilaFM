using Pras.DAL.Context;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrasDbContext _context;
        private IRepository<Audio> _audiosRepository;
        private IRepository<Information> _informationRepository;
        private IRepository<Person> _peopleRepository;
        private IRepository<Speaker> _speakersRepository;
        private IRepository<Video> _videosRepository;

        public UnitOfWork(PrasDbContext context)
        {
            _context = context;
        }

        public IRepository<Audio> AudiosRepository
        {
            get
            {
                if (_audiosRepository == null)
                {
                    _audiosRepository = new Repository<Audio>(_context);
                }
                return _audiosRepository;
            }
        }

        public IRepository<Information> InformationRepository
        {
            get
            {
                if (_informationRepository == null)
                {
                    _informationRepository = new Repository<Information>(_context);
                }
                return _informationRepository;
            }
        }

        public IRepository<Person> PeopleRepository
        {
            get
            {
                if (_peopleRepository == null)
                {
                    _peopleRepository = new Repository<Person>(_context);
                }
                return _peopleRepository;
            }
        }

        public IRepository<Speaker> SpeakersRepository
        {
            get
            {
                if (_speakersRepository == null)
                {
                    _speakersRepository = new Repository<Speaker>(_context);
                }
                return _speakersRepository;
            }
        }

        public IRepository<Video> VideosRepository
        {
            get
            {
                if (_videosRepository == null)
                {
                    _videosRepository = new Repository<Video>(_context);
                }
                return _videosRepository;
            }
        }

        public PrasDbContext Context => _context;

        public bool Commit()
        {
            return _context.Commit() != 0;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
