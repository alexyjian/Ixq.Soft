namespace Ixq.Soft.Core.Domain
{
    /// <summary>
    ///     定义一个实体接口。
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型。</typeparam>
    public interface IEntityBase<TKey>
    {
        /// <summary>
        ///     获取或设置一个值，表示实体的标识。
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示排序码。
        /// </summary>
        string SoteCode { get; set; }
    }
}