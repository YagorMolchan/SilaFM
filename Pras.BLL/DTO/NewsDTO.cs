using System;
using Pras.DAL.Entities;

namespace Pras.BLL.DTO
{
    public class NewsDTO : Entity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
