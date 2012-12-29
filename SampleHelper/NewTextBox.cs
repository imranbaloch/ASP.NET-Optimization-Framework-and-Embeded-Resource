using System;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Web.Optimization;

namespace ImranB.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString NewTextBox(this HtmlHelper html, string name)
        {
            var js = Scripts.Render("~/ImranB/Embedded/Js").ToString();
            var css = Scripts.Render("~/ImranB/Embedded/Css").ToString();
            var textbox = html.TextBox(name).ToString();
            return MvcHtmlString.Create(textbox + js + css);
        }
    }
}
