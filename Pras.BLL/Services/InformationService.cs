using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;
using Pras.Shared.Enums;

namespace Pras.BLL.Services
{
    public class InformationService : IInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public InformationDTO Find(InformationTypes type)
        {
            return Mapper.Map<InformationDTO>(_unitOfWork.InformationRepository.Find()
                                                  .SingleOrDefault(p => p.Type == type) ??
                                              new Information {Type = type, Created = DateTime.Now});
        }

        public InformationDTO Save(InformationDTO model)
        {
            Information entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Information>(model);
                _unitOfWork.InformationRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.InformationRepository.FindById(model.Id).Result;
                Mapper.Map(model, entity);
                _unitOfWork.InformationRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<InformationDTO>(entity);
        }
    }
}
