using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pras.DAL.Entities
{
    public class Review : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
    }
}
