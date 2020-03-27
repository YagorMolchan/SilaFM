using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<NewsDTO> Find()
        {
            return Mapper.Map<List<NewsDTO>>(_unitOfWork.NewsRepository.Find());
        }

        public NewsDTO Find(Guid id)
        {
            return Mapper.Map<NewsDTO>(_unitOfWork.NewsRepository.FindById(id));
        }

        public NewsDTO Save(NewsDTO model)
        {
            News entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<News>(model);
                _unitOfWork.NewsRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.NewsRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.NewsRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<NewsDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.NewsRepository.FindById(id);
            if (toDelete != null)
            {
                _unitOfWork.NewsRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }

        public NewsDTO Find(string url)
        {
            return Mapper.Map<NewsDTO>(_unitOfWork.NewsRepository.Find().SingleOrDefault(p=>p.Url==url));
        }
    }
}
