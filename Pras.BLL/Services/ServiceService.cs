using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pras.BLL.Services.Interfaces;
using Pras.BLL.DTO;
using Pras.DAL.Interfaces;
using Pras.DAL.Entities;
using AutoMapper;

namespace Pras.BLL.Services
{
    public class ServiceService:IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IUnitOfWork unitOfWork)
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

        public List<ServiceDTO> Find()
        {
            return Mapper.Map<List<ServiceDTO>>(_unitOfWork.ServicesRepository.Find());
        }

        public ServiceDTO Find(Guid id)
        {
            return Mapper.Map<ServiceDTO>(_unitOfWork.ServicesRepository.FindById(id));
        }

        public ServiceDTO Save(ServiceDTO model)
        {
            Service entity;
            if (model.IsNew)
            {
                entity = Mapper.Map<Service>(model);
                _unitOfWork.ServicesRepository.InsertOrUpdate(entity);
            }
            else
            {
                entity = _unitOfWork.ServicesRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.ServicesRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<ServiceDTO>(entity);
        }



    }
}
