using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Core.Entity;

namespace Ixq.Soft.Entities
{
    public class EntityBase : EntityBase<Guid>
    {
    }

    public class EntityBase<TKey> : IEntity<TKey>, ICreateSpecification, IUpdataSpecification,
        ISoftDeleteSpecification
    {
        [Key]
        public virtual TKey Id { get; set; }

        [Required]
        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime? UpdataDate { get; set; }
        public virtual DateTime? DeleteDate { get; set; }
        public virtual bool IsDeleted { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }

        [StringLength(200)]
        public string SoteCode { get; set; }

        public virtual void OnCreateComplete()
        {
            CreateDate = DateTime.Now;
        }

        public virtual void OnUpdataComplete()
        {
        }

        public virtual void OnSoftDeleteComplete()
        {
        }
    }
}