using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.DAL.Entities
{
    public class Character:Entity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public virtual Speaker Speaker { get; set; }
    }
}
