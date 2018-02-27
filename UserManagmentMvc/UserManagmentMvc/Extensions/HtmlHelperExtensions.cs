using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace UserManagmentMvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString mDisplayNameFor<TModel, TProperty>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TModel>(), typeof(TModel), name);
            return new MvcHtmlString(metadata.DisplayName);
        }


        public static HtmlString DisplayForPhone(this HtmlHelper helper, string phone)
        {
            if (phone == null)
            {
                return new HtmlString(string.Empty);
            }
            string formatted = phone;
            if (phone.Length == 10)
            {
                formatted = $"({phone.Substring(0, 3)}) {phone.Substring(3, 3)}-{phone.Substring(6, 4)}";
            }
            else if (phone.Length == 7)
            {
                formatted = $"{phone.Substring(0, 3)}-{phone.Substring(3, 4)}";
            }
            string s = $"<a href='tel:{phone}'>{formatted}</a>";
            return new HtmlString(s);
        }
    }
}