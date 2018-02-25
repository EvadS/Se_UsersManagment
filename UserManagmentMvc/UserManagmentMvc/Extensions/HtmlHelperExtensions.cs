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
    }
}