using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Vendor.Web.Extension.Common.Models;

namespace Vendor.Web.Extension.MvcHtmlHelper
{
    public static partial class HtmlHelperExtend
    {
        public static MvcHtmlString BooleanToDropdown(this HtmlHelper htmlHelper, string name, bool? value, object[] displayTexts, object htmlAttributes)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            if (displayTexts.Length > 2)
            {
                selectList.Add(new SelectListItem() { Text = displayTexts[2].ToString(), Selected = (!value.HasValue) });
            }
            selectList.Add(new SelectListItem() { Text = displayTexts[0].ToString(), Value = "true", Selected = (value.HasValue ? value.Value : false) });
            selectList.Add(new SelectListItem() { Text = displayTexts[1].ToString(), Value = "false", Selected = (value.HasValue ? value.Value : false) });
            return htmlHelper.DropDownList(name, selectList, htmlAttributes);
        }


        public static MvcHtmlString BooleanFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            DisplayType displayType, DisplayDirection direction, object[] values, object htmlAttribute, object itemAttribute)
        {
            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttribute);

            MemberExpression nameExpr = (MemberExpression)expression.Body;
            string propertyName = nameExpr.Member.Name;
            bool? propertyValue = (bool?)htmlHelper.ViewData.Eval(propertyName);

            IDictionary<string, object> itemAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(itemAttribute);

            if (values.Length < 2)
            {
                throw new ArgumentException("aleast 2 values, for three condition:true, false, null");
            }

            switch (displayType)
            {
                case DisplayType.CheckList:
                    return null;
                case DisplayType.DropdownList:
                    List<SelectListItem> selectList = new List<SelectListItem>();
                    if (values.Length > 2)
                    {
                        selectList.Add(new SelectListItem() { Text = values[2].ToString(), Selected = (!propertyValue.HasValue) });
                    }
                    selectList.Add(new SelectListItem() { Text = values[0].ToString(), Value = "true", Selected = (propertyValue.HasValue ? propertyValue.Value : false) });
                    selectList.Add(new SelectListItem() { Text = values[1].ToString(), Value = "false", Selected = (propertyValue.HasValue ? propertyValue.Value : false) });
                    return htmlHelper.DropDownList(propertyName, selectList, htmlAttributes);
                case DisplayType.RadioList:
                    string itemStr = "";
                    int checkedIndex = 2;
                    if (propertyValue.HasValue)
                    {
                        if (propertyValue.Value)
                            checkedIndex = 0;
                        else
                            checkedIndex = 1;
                    }
                    for (int i = 0; i < values.Length; i++)
                    {
                        bool isCheck = false;
                        isCheck = (i == checkedIndex);

                        object value = "";
                        switch (i)
                        {
                            case 0:
                                value = true;
                                break;
                            case 1:
                                value = false;
                                break;
                            case 2:
                                value = "";
                                break;
                        }
                        itemStr += (htmlHelper.RadioButton(propertyName, value, isCheck, itemAttributes)).ToHtmlString();
                        itemStr += "&nbsp;" + values[i].ToString();// ResourceHelper.GetResourceObject(typeof(CommonResource), radio.ResourceKey);
                        if (direction == DisplayDirection.Vertical)
                        {
                            itemStr += "<br/>";
                        }
                        else
                        {
                            itemStr += "&nbsp;&nbsp;";
                        }
                    }
                    return new MvcHtmlString(itemStr);
            }

            return null;
        }

        public static MvcHtmlString BooleanFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            DisplayType displayType, DisplayDirection direction, object[] values, object htmlAttribute)
        {
            return htmlHelper.BooleanFor(expression, displayType, direction, values, htmlAttribute, null);
        }

        public static MvcHtmlString BooleanFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object[] displayValues)
        {
            MemberExpression nameExpr = (MemberExpression)expression.Body;
            string propertyName = nameExpr.Member.Name;
            bool? propertyValue = (bool?)htmlHelper.ViewData.Eval(propertyName);

            if (displayValues.Length < 3)
            {
                throw new ArgumentException("aleast 3 values, for three condition:true, false, null");
            }

            if (propertyValue.HasValue)
            {
                if (propertyValue.Value)
                    return new MvcHtmlString(displayValues[0].ToString());
                else
                    return new MvcHtmlString(displayValues[1].ToString());
            }
            else
            {
                return new MvcHtmlString(displayValues[2].ToString());
            }
        }

        public static MvcHtmlString Boolean(this HtmlHelper htmlHelper, bool? value, object[] displayValues)
        {
            if (displayValues.Length < 3)
            {
                throw new ArgumentException("aleast 3 values, for three condition:true, false, null");
            }

            if (value.HasValue)
            {
                if (value.Value)
                    return new MvcHtmlString(displayValues[0].ToString());
                else
                    return new MvcHtmlString(displayValues[1].ToString());
            }
            else
            {
                return new MvcHtmlString(displayValues[2].ToString());
            }
        }

        public static MvcHtmlString Boolean(this HtmlHelper htmlHelper, bool value, object[] displayValues)
        {
            if (displayValues.Length < 2)
            {
                throw new ArgumentException("aleast 2 values, for three condition:true, false, null");
            }

            if (value)
                return new MvcHtmlString(displayValues[0].ToString());
            else
                return new MvcHtmlString(displayValues[1].ToString());
        }

    }
}