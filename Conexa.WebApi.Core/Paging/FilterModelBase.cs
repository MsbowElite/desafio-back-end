using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.WebApi.Core.Paging
{
    public abstract class FilterModelBase : ICloneable
    {
        public int Limit { get; set; }
        public int Offset { get; set; }

        public FilterModelBase()
        {
            this.Limit = 10;
            this.Offset = 0;
        }

        public abstract object Clone();
    }
}
