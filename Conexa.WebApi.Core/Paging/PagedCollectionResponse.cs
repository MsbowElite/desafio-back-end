using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.WebApi.Core.Paging
{
    public class PagedCollectionResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
    }
}
