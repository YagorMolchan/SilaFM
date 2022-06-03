using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pras.BLL.DTO;     

namespace Pras.BLL.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterDTO> Find();
        CharacterDTO Find(Guid id);
        CharacterDTO Save(CharacterDTO model);
        void Delete(Guid id);
    }
}
