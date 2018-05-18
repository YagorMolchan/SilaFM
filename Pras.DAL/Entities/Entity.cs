using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pras.DAL.Entities
{
    public class Entity
    {

        public virtual bool IsNew => Id == Guid.Empty;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.Empty;
        }
    }
}
