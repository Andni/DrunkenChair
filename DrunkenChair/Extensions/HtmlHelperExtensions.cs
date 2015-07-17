using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System;

using System.Web.Mvc.Html;

using Event = Niklasson.EonIV.CharacterGeneration.Contracts.RuleBookEvent;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Extensions
{
    public static partial class HtmlHelperExtensions
    {
        public static IDictionary<string, object> MergeHtmlAttributes(this HtmlHelper helper, object htmlAttributesObject, object defaultHtmlAttributesObject)
        {
            var concatKeys = new string[] { "class" };

            var htmlAttributesDict = htmlAttributesObject as IDictionary<string, object>;
            var defaultHtmlAttributesDict = defaultHtmlAttributesObject as IDictionary<string, object>;

            RouteValueDictionary htmlAttributes = (htmlAttributesDict != null)
                ? new RouteValueDictionary(htmlAttributesDict)
                : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributesObject);
            RouteValueDictionary defaultHtmlAttributes = (defaultHtmlAttributesDict != null)
                ? new RouteValueDictionary(defaultHtmlAttributesDict)
                : HtmlHelper.AnonymousObjectToHtmlAttributes(defaultHtmlAttributesObject);

            foreach (var item in htmlAttributes)
            {
                if (concatKeys.Contains(item.Key))
                {
                    defaultHtmlAttributes[item.Key] = (defaultHtmlAttributes[item.Key] != null)
                        ? string.Format("{0} {1}", defaultHtmlAttributes[item.Key], item.Value)
                        : item.Value;
                }
                else
                {
                    defaultHtmlAttributes[item.Key] = item.Value;
                }
            }

            return defaultHtmlAttributes;
        }

        public static MvcHtmlString GenerateEventList(this HtmlHelper helper, IEnumerable<Event> events)
        {
            TagBuilder tb = new TagBuilder("dl");
            tb.GenerateId(helper.ViewData.ModelMetadata.DisplayName);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach(RuleBookEvent e in events)
            {
                sb.Append(String.Format("<dt>{0} {1}</dt><br/>", e.Number, e.Name));

                sb.Append(String.Format("<dd>{0}[", e.Description, e.ModificationOptions));

                foreach(CharacterModificationOptions mod in e.ModificationOptions)
                {
                    sb.Append(String.Format("<br/>", mod.Alternatives));
                }
                sb.Append("]</dd>");
            }
            tb.InnerHtml = sb.ToString();
            var tmp = tb.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(tmp);
        }
    }
}