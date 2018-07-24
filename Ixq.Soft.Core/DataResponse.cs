using System.Collections;
using Newtonsoft.Json;

namespace Ixq.Soft.Core
{
    /// <summary>
    ///     数据响应类。
    /// </summary>
    public class DataResponse
    {
        /// <summary>
        ///     实例化一个新的 <see cref="DataResponse" /> 实例。
        /// </summary>
        public DataResponse()
        {
        }

        /// <summary>
        ///     使用 <see cref="IPagedList" /> 实例化一个新的 <see cref="DataResponse" /> 实例。
        /// </summary>
        /// <param name="pagingList"></param>
        public DataResponse(IPagedList pagingList)
        {
            PageIndex = pagingList.PageIndex;
            PageTotal = pagingList.TotalPages;
            Records = pagingList.TotalRecords;
            Rows = pagingList;
        }

        /// <summary>
        ///     用户数据
        /// </summary>
        [JsonProperty("userdata")]
        public object UserData { get; set; }

        /// <summary>
        ///     包含实际数据的数组
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable Rows { get; set; }

        /// <summary>
        ///     查询出的记录数
        /// </summary>
        [JsonProperty("records")]
        public int Records { get; set; }

        /// <summary>
        ///     当前页
        /// </summary>
        [JsonProperty("page")]
        public int PageIndex { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        [JsonProperty("total")]
        public int PageTotal { get; set; }
    }
}