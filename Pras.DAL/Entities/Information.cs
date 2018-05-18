using System;
using Pras.Shared.Enums;

namespace Pras.DAL.Entities
{
    public class Information : Entity
    {
        public InformationTypes Type { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
