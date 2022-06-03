using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.DAL.Entities
{
    public  class Hero:Entity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public virtual Speaker Speaker { get; set; }
    }
}
