using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.Domain
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}
