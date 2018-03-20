namespace Ixq.Soft.Core.Caching
{
    /// <summary>
    ///     序列化服务。
    /// </summary>
    public interface ISerializableService
    {
        /// <summary>
        ///     反序列化。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        T Deserialize<T>(byte[] data);

        /// <summary>
        ///     序列化。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] Serialize(object obj);
    }
}