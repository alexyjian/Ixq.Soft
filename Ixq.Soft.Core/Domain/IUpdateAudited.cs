using System;

namespace Ixq.Soft.Core.Domain
{
    /// <summary>
    ///     更新审计接口。
    /// </summary>
    public interface IUpdateAudited
    {
        /// <summary>
        ///     获取或设置一个值，表示此实体的更新者Id.
        /// </summary>
        long UpdateUserId { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示此实体的更新时间。
        /// </summary>
        DateTime? UpdateTime { get; set; }
    }
}