using System;

namespace Ixq.Soft.Core.Domain
{
    /// <summary>
    /// 新增审计接口。
    /// </summary>
    public interface ICreationAudited
    {
        /// <summary>
        /// 获取或设置一个值，表示此实体的创建者Id.
        /// </summary>
        long CreationUserId { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示此实体的创建时间。
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}