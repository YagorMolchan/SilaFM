using System;
using Pras.DAL.Context;
using Pras.DAL.Entities;

namespace Pras.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Audio> AudiosRepository { get; }
        IRepository<Information> InformationRepository { get; }
        IRepository<Person> PeopleRepository { get; }
        IRepository<Speaker> SpeakersRepository { get; }
        IRepository<Video> VideosRepository { get; }
        IRepository<News> NewsRepository { get; }
        IRepository<Review> ReviewsRepository { get; }
        IRepository<Settings> SettingsRepository { get; }
        PrasDbContext Context { get; }
        bool Commit();
    }
}
