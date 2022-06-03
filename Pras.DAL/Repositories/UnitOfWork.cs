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
        private IRepository<News> _newsRepository;
        private IRepository<Review> _reviewsRepository;
        private IRepository<Settings> _settingsRepository;
        private IRepository<Service> _servicesRepository;
        private IRepository<Character> _charactersRepository;

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

        public IRepository<News> NewsRepository {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new Repository<News>(_context);
                }
                return _newsRepository;
            }
        }

        public IRepository<Review> ReviewsRepository {
            get
            {
                if (_reviewsRepository == null)
                {
                    _reviewsRepository = new Repository<Review>(_context);
                }
                return _reviewsRepository;
            }
        }

        public IRepository<Settings> SettingsRepository {
            get
            {
                if (_settingsRepository == null)
                {
                    _settingsRepository = new Repository<Settings>(_context);
                }
                return _settingsRepository;
            }
        }

        public PrasDbContext Context => _context;

        public IRepository<Service> ServicesRepository
        {
            get
            {
                if(_servicesRepository == null)
                {
                    _servicesRepository = new Repository<Service>(_context);
                }
                return _servicesRepository;
            }
        }

        public IRepository<Character> CharactersRepository
        {
            get
            {
                if (_charactersRepository == null)
                {
                    _charactersRepository = new Repository<Character>(_context);
                }
                return _charactersRepository;
            }
        }

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
