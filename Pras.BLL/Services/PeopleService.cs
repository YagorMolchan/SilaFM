using System;
using System.Collections.Generic;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<PersonDTO> Find()
        {
            return Mapper.Map<List<PersonDTO>>(_unitOfWork.PeopleRepository.Find());
        }

        public PersonDTO Find(Guid id)
        {
            return Mapper.Map<PersonDTO>(_unitOfWork.PeopleRepository.FindById(id));
        }

        public PersonDTO Save(PersonDTO model)
        {
            Person entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Person>(model);
                _unitOfWork.PeopleRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.PeopleRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.PeopleRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<PersonDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.PeopleRepository.FindById(id);
            if (toDelete != null)
            {
                _unitOfWork.PeopleRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }
    }
}
