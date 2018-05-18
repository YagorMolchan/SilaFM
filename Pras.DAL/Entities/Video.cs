using System;
using Pras.Shared.Enums;

namespace Pras.DAL.Entities
{
    public class Video : Entity
    {
        public VideoTypes Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
        public DateTime Created { get; set; }
    }
}
