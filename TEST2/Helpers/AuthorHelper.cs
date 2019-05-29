using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Helpers
{
    public static class AuthorHelper
    {
        public static IHtmlContent CreatedBy(this IHtmlHelper htmlHelper)
             => new HtmlString("<strong>&copy Kamil Wszeborowski</strong>");
    }

}
