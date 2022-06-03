using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.BLL.DTO
{
    public class CharacterDTO:EntityDTO
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public SpeakerDTO Speaker { get; set; }
             
    }
}
