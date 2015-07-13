using System;
using System.Text;
using System.Web.Mvc;
using MvcSalesService.Models;

namespace MvcSalesService.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                if (i == 1 || i == pagingInfo.TotalPages ||( i -10 < pagingInfo.CurrentPage && i + 10 > pagingInfo.CurrentPage))
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    if (i == pagingInfo.CurrentPage)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    result.Append(tag);
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}