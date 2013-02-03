using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using System.Web.WebPages.Html;

namespace RepeaterHelperSample
{
    public static class RepeaterHelper
    {
        public static HelperResult Repeater<T1>(this HtmlHelper helper, IEnumerable<T1> items, 
            Func<T1, HelperResult> template, 
            Func<T1, HelperResult> separator = null,
            Func<T1, HelperResult> empty = null)
        {
            var result = new HelperResult(writer =>
            {
                foreach (var itemWithIndex in items.Select((item, index) => new { item, index }))
                {
                    if (itemWithIndex.index > 0 && separator != null)
                    {
                        separator(itemWithIndex.item).WriteTo(writer);
                    }
                    template(itemWithIndex.item).WriteTo(writer);
                }
                if (items.Any() == false && empty != null)
                {
                    empty(default(T1)).WriteTo(writer);
                }
            });
            return result;
        }

        /// <summary>
        /// Repeater Helper Type2
        /// </summary>
        public static HelperResult Repeater<T1>(this HtmlHelper helper, IEnumerable<T1> items,
            Func<T1, Func<RepeaterItem<T1>, HelperResult>> template,
            Func<RepeaterItem<T1>, HelperResult> separator = null,
            Func<RepeaterItem<T1>, HelperResult> empty = null)
        {
            var result = new HelperResult(writer =>
            {
                foreach (var itemWithIndex in items.Select((item, index) => new RepeaterItem<T1>(item, index)))
                {
                    if (itemWithIndex.Index > 0 && separator != null)
                    {
                        separator(itemWithIndex).WriteTo(writer);
                    }
                    template(itemWithIndex.Item)(itemWithIndex).WriteTo(writer);
                }
                if (items.Any() == false && empty != null)
                {
                    empty(default(RepeaterItem<T1>)).WriteTo(writer);
                }
            });
            return result;
        }
    }
}