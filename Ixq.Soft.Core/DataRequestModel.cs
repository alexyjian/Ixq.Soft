using System.ComponentModel;

namespace Ixq.Soft.Core
{
    public class DataRequestModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }

        public ListSortDirection ListSortDirection =>
            SortDirection.Equals("asc", System.StringComparison.OrdinalIgnoreCase)
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;
    }
}
