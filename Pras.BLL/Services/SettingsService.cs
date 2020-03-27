using System;
using System.Linq;
using AutoMapper;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.BLL.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public SettingsDTO Find()
        {
            return Mapper.Map<SettingsDTO>(_unitOfWork.SettingsRepository.Find().SingleOrDefault() ?? new Settings(){Created = DateTime.Now});
        }

        public SettingsDTO Save(SettingsDTO model)
        {
            Settings entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Settings>(model);
                _unitOfWork.SettingsRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.SettingsRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.SettingsRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<SettingsDTO>(entity);
        }
    }
}
