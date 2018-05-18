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
    public class AudioService : IAudioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AudioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<AudioDTO> Find()
        {
            return Mapper.Map<List<AudioDTO>>(_unitOfWork.AudiosRepository.Find());
        }

        public AudioDTO Find(Guid id)
        {
            return Mapper.Map<AudioDTO>(_unitOfWork.AudiosRepository.FindById(id).Result);
        }

        public AudioDTO Save(AudioDTO model)
        {
            Audio entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Audio>(model);
                _unitOfWork.AudiosRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.AudiosRepository.FindById(model.Id).Result;
                Mapper.Map(model, entity);
                _unitOfWork.AudiosRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<AudioDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.AudiosRepository.FindById(id).Result;
            if (toDelete != null)
            {
                _unitOfWork.AudiosRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }
    }
}
