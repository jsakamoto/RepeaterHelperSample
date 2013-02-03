using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepeaterHelperSample
{
    public class RepeaterItem<T1>
    {
        public int Index { get; protected set; }

        public bool Even { get { return (this.Index % 2) == 0; } }

        public bool Odd { get { return !this.Even; } }

        public T1 Item { get; protected set; }

        public RepeaterItem(T1 item, int index)
        {
            this.Item = item;
            this.Index = index;
        }
    }
}