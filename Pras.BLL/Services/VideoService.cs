using System;
using System.Collections.Generic;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<VideoDTO> Find()
        {
            return Mapper.Map<List<VideoDTO>>(_unitOfWork.VideosRepository.Find());
        }

        public VideoDTO Find(Guid id)
        {
            return Mapper.Map<VideoDTO>(_unitOfWork.VideosRepository.FindById(id).Result);
        }

        public VideoDTO Save(VideoDTO model)
        {
            Video entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Video>(model);
                _unitOfWork.VideosRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.VideosRepository.FindById(model.Id).Result;
                Mapper.Map(model, entity);
                _unitOfWork.VideosRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<VideoDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.VideosRepository.FindById(id).Result;
            if (toDelete != null)
            {
                _unitOfWork.VideosRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }
    }
}
