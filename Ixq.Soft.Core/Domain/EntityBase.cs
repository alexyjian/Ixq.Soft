using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.Domain
{
    public class EntityBase : IEntityBase<int>
    {
        public int Id { get; set; }
    }
}