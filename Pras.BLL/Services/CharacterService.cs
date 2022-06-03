using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Interfaces;
using Pras.DAL.Entities;
using Pras.BLL.DTO;
using AutoMapper;

namespace Pras.BLL.Services
{
    public class CharacterService:ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.ServicesRepository.FindById(id);
            if (toDelete != null)
            {
                _unitOfWork.ServicesRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }

        public List<CharacterDTO> Find()
        {
            return Mapper.Map<List<CharacterDTO>>(_unitOfWork.CharactersRepository.Find());
        }

        public CharacterDTO Find(Guid id)
        {
            return Mapper.Map<CharacterDTO>(_unitOfWork.CharactersRepository.FindById(id));
        }

        public CharacterDTO Save(CharacterDTO model)
        {
            Character entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Character>(model);
                _unitOfWork.CharactersRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.CharactersRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.CharactersRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<CharacterDTO>(entity);
        }

    }
}
