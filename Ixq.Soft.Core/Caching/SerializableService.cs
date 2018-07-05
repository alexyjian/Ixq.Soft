using System.Text;
using Newtonsoft.Json;

namespace Ixq.Soft.Core.Caching
{
    /// <summary>
    ///     基于 Newtonsoft.Json 类库实现的序列化服务。
    /// </summary>
    public class SerializableService : ISerializableService
    {
        /// <inheritdoc />
        public T Deserialize<T>(byte[] data)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(data));
        }

        /// <inheritdoc />
        public byte[] Serialize(object obj)
        {
            return Encoding.Default.GetBytes(JsonConvert.SerializeObject(obj));
        }
    }
}