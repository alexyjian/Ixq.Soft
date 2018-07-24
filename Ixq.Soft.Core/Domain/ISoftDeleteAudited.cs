using System;

namespace Ixq.Soft.Core.Domain
{
    /// <summary>
    ///     软删除审计接口。
    /// </summary>
    public interface ISoftDeleteAudited
    {
        /// <summary>
        ///     获取或设置一个值，表示此实体的删除者Id.
        /// </summary>
        long DeleteUserId { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示此实体的删除时间。
        /// </summary>
        DateTime? DeleteTime { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示此实体是否被删除。
        /// </summary>
        bool IsDeleted { get; set; }
    }
}