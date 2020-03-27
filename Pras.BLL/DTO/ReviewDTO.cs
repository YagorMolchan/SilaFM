using System;
using Pras.DAL.Entities;

namespace Pras.BLL.DTO
{
    public class ReviewDTO : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public DateTime? Created { get; set; }
    }
}
