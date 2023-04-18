using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox2.Examples.Generics.EntityExample
{
    public interface IEntity<TKey> where TKey : unmanaged
    {
        TKey Id { get; set; }
    }

    public abstract class EntityBase : IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string CreatedBy { get; set; } = default!;

        [Required]
        public DateTime CreatedOn { get; set; }    
    }

    public class Location : EntityBase
    {

    }

    public static class EntityExtensions
    {
        public static TEntity Create<TEntity>(this TEntity entity, string user, DateTime date)
            where TEntity : EntityBase
        {
            entity.CreatedOn = date;
            entity.CreatedBy = user;
            return entity;
        }
    }
}
