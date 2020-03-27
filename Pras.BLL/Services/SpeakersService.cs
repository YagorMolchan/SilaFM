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
            return Mapper.Map<SpeakerDTO>(_unitOfWork.SpeakersRepository.FindById(id));
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
                entity = _unitOfWork.SpeakersRepository.FindById(model.Id);
                Mapper.Map(model, entity);
                _unitOfWork.SpeakersRepository.InsertOrUpdate(entity);
            }

            _unitOfWork.Commit();
            return Mapper.Map<SpeakerDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var toDelete = _unitOfWork.SpeakersRepository.FindById(id);
            if (toDelete != null)
            {
                _unitOfWork.SpeakersRepository.Delete(toDelete);
                _unitOfWork.Commit();
            }
        }

        public List<string> GetLastSpeakersNames(int count)
        {
            return _unitOfWork.SpeakersRepository.Find().OrderByDescending(p => p.Created).Take(count)
                .Select(p => p.Name).ToList();
        }

        public List<SpeakerDTO> GetLastSpeakers(int count)
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find().OrderByDescending(p => p.Created).Take(count));
        }

        public List<SpeakerDTO> Find(SpeakerTypes type)
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find().Where(p => p.Type == type)
                .OrderByDescending(p => p.Created));
        }

        public List<SpeakerDTO> Find(SpeakerCountries country)
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find().Where(p => p.Country == country.ToString())
                .OrderByDescending(p => p.Created));
        }

        public List<SpeakerDTO> Find(SpeakerTypes type, SpeakerCountries country)
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find().Where(p => p.Type == type && p.Country == country.ToString())
                .OrderByDescending(p => p.Created));
        }

        public List<SpeakerDTO> Find(SpeakerCountries country, params SpeakerTypes[] types)
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find()
                .Where(p => types.Any(x => x == p.Type) && p.Country == country.ToString())
                .OrderByDescending(p => p.Created));
        }

        public List<SpeakerDTO> FindVip()
        {
            return Mapper.Map<List<SpeakerDTO>>(_unitOfWork.SpeakersRepository.Find().Where(p => p.IsVip)
                .OrderByDescending(p => p.Created));
        }

        public SpeakerDTO Find(string url)
        {
            return Mapper.Map<SpeakerDTO>(_unitOfWork.SpeakersRepository.Find().SingleOrDefault(p => p.Url == url));
        }
    }
}
