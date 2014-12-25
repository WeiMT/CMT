using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Vendor.Web.Extension.MvcHtmlHelper
{
    public static partial class HtmlHelperExtend
    {
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
			return DatePickerFor(htmlHelper, expression, null, "yyyy-MM-dd");
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttribute)
        {
			return DatePickerFor(htmlHelper, expression, htmlAttribute, "yyyy-MM-dd");
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttribute, string formart)
        {
            MemberExpression nameExpr = (MemberExpression)expression.Body;
            string propertyName = nameExpr.Member.Name;

            PropertyInfo property = typeof(TModel).GetProperty(propertyName);
            DataTypeAttribute attribute = (DataTypeAttribute)property.GetCustomAttributes(typeof(DataTypeAttribute), false)[0];

            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttribute);
            htmlAttributes.Add("data-type", "datepicker");
            if (!htmlAttributes.Keys.Contains("class"))
            {
                htmlAttributes.Add("class", "field-input");
            }

            if (attribute != null)
            {
                if (attribute.DataType == DataType.Date)
                {
                    object o = htmlHelper.ViewData.Eval(propertyName);
                    DateTime? date = o as DateTime?;
                    if (!date.HasValue || date == DateTime.MaxValue || date == DateTime.MinValue)
                    {
                        return htmlHelper.TextBox(propertyName, "", htmlAttributes);//new { data_type = "datepicker", @class = "field-input" }
                    }
                    else
                    {
                        DateTime d = (DateTime)date;
                        return htmlHelper.TextBox(propertyName, d.ToString(formart), htmlAttributes);//new { data_type = "datepicker", @class = "field-input" }
                    }
                }
            }
            return htmlHelper.TextBoxFor(expression,
                                    "{0:" + formart + "}"
                                    , htmlAttributes);
        }
    }
}