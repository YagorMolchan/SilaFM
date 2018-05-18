using System;
using Pras.Shared.Enums;

namespace Pras.DAL.Entities
{
    public class Speaker : Entity
    {
        public SpeakerTypes Type { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Price30 { get; set; }
        public string Price90 { get; set; }
        public SpeakerStatuses Status { get; set; }
        public string Track { get; set; }
        public string Terms { get; set; }
        public bool IsNovelty { get; set; }
        public string Language { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
    }
}
