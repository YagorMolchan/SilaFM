using System;
using System.Collections.Generic;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class SpeakersService : ISpeakersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<SpeakerDTO> Find()
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find());
        }

        public SpeakerDTO Find(Guid id)
        {
            return Mapper.Map<SpeakerDTO>(_unitOfWork.SpeakersRepository.FindById(id).Result);
        }

        public SpeakerDTO Save(SpeakerDTO model)
        {
            Speaker entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Speaker>(model);
                _unitOfWork.SpeakersRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.SpeakersRepository.FindById(model.Id).Result;
                Mapper.Map(model, entity);
                _unitOfWork.SpeakersRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<SpeakerDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.SpeakersRepository.FindById(id).Result;
            if (toDelete != null)
            {
                _unitOfWork.SpeakersRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }
    }
}
