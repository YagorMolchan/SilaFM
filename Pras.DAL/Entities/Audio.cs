using System;
using Pras.Shared.Enums;

namespace Pras.DAL.Entities
{
    public class Audio : Entity
    {
        public AudioTypes Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
        public bool IsNovelty { get; set; }
        public DateTime Created { get; set; }
    }
}
