using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface IPeopleService
    {
        List<PersonDTO> Find();
        PersonDTO Find(Guid id);
        PersonDTO Save(PersonDTO model);
        void Delete(Guid id);
    }
}
