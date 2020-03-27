using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<ReviewDTO> Find()
        {
            return Mapper.Map<List<ReviewDTO>>(_unitOfWork.ReviewsRepository.Find());
        }

        public ReviewDTO Find(Guid id)
        {
            return Mapper.Map<ReviewDTO>(_unitOfWork.ReviewsRepository.FindById(id));
        }

        public ReviewDTO Save(ReviewDTO model)
        {
            Review entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Review>(model);
                _unitOfWork.ReviewsRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.ReviewsRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.ReviewsRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<ReviewDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.ReviewsRepository.FindById(id);
            if (toDelete != null)
            {
                _unitOfWork.ReviewsRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }

        public List<ReviewDTO> GetLastReviews(int count)
        {
            return Mapper.Map<List<ReviewDTO>>(_unitOfWork.ReviewsRepository.Find().OrderByDescending(p=>p.Created).Take(count));
        }
    }
}
