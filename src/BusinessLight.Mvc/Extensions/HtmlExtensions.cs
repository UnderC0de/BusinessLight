using System;
using System.Web.Mvc;

namespace BusinessLight.Mvc.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    public static class HtmlExtensions
    {
        public static T ReturnIf<T>(this HtmlHelper htmlHelper, bool condition, T trueCondition, T falseCondition = default(T))
        {
            return condition ? trueCondition : falseCondition;
        }

        public static string ImageData(this HtmlHelper htmlHelper, byte[] imageData)
        {
            var imageBase64 = Convert.ToBase64String(imageData);
            var imageSrc = string.Format("data:image/png;base64,{0}", imageBase64);
            return imageSrc;
        }

        public static string CurrentAction(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.GetActionName();
        }

        public static string CurrentController(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.GetControllerName();
        }

        public static MvcHtmlString JavascriptString(this HtmlHelper html, string value)
        {
            return MvcHtmlString.Create(HttpUtility.JavaScriptStringEncode(value));
        }

        public static MvcHtmlString GetDescriptionsForList(this HtmlHelper html, IEnumerable<string> selectedIds, IEnumerable<SelectListItem> items)
        {
            var selectionList = items.ToList();
            var stringBuilder = new StringBuilder();
            foreach (var id in selectedIds)
            {
                var description = selectionList.Single(x => x.Value == id).Text;
                stringBuilder.Append(description);
                stringBuilder.Append("; ");
            }
            return MvcHtmlString.Create(stringBuilder.ToString().Trim(' ', ';'));
        }

        #region Collection Editor
        public static IHtmlString CollectionEditorFor<TModel, TItem>(this HtmlHelper<TModel> html, Func<TModel, IEnumerable<TItem>> collection, string partialViewName, string controllerActionPath, string addButtonTitle, object addButtonHtmlAttributes = null)
        {
            var editorId = "CollectionEditor_" + Guid.NewGuid().ToString("N");
            var addButtonId = "CollectionEditorAdd_" + Guid.NewGuid().ToString("N");

            var output = new StringBuilder();

            RenderInitialCollection(output, html, collection, partialViewName, editorId);
            RenderAddButton(output, addButtonId, addButtonTitle, addButtonHtmlAttributes);
            RenderEditorScript(controllerActionPath, output, editorId, addButtonId);

            return new HtmlString(output.ToString());
        }

        private static void RenderInitialCollection<TModel, TItem>(StringBuilder output, HtmlHelper<TModel> html, Func<TModel, IEnumerable<TItem>> collection, string partialViewName, string editorId)
        {
            output.AppendLine(@"<ul id=""" + editorId + @""" style=""list-style-type: none; padding: 0"">");
            var items = collection(html.ViewData.Model);
            if (items != null)
            {
                foreach (var item in collection(html.ViewData.Model))
                    output.AppendLine(html.Partial(partialViewName, item).ToString());
            }
            output.AppendLine(@"</ul>");
        }

        private static void RenderAddButton(StringBuilder output, string addButtonId, string addButtonTitle, object addButtonHtmlAttributes)
        {
            var inputTag = new TagBuilder("input");
            inputTag.MergeAttributes(new Dictionary<string, string>
            {
                { "type", "button" },
                { "value", addButtonTitle },
                { "id", addButtonId },
            });
            inputTag.MergeAttributes(new RouteValueDictionary(addButtonHtmlAttributes));

            output.AppendLine(@"<p>");
            output.AppendLine(inputTag.ToString());
            output.AppendLine(@"</p>");
        }

        private static void RenderEditorScript(string controllerActionPath, StringBuilder output, string editorId, string addButtonId)
        {
            output.AppendLine(
                @"<script type=""text/javascript"">
                    $(function() {
                        $(""#" + editorId + @""").sortable();
                        $(""#" + addButtonId + @""").click(function() {
                            $.get('" + controllerActionPath + @"', { '_': $.now() }, function (template) {
                                var itemList = $(""#" + editorId + @""");
                                itemList.append(template);
                                var form = itemList.closest(""form"");
                                form.removeData(""validator"");
                                form.removeData(""unobtrusiveValidation"");
                                $.validator.unobtrusive.parse(form);
                                form.validate();
                            });
                        });
                    });
                </script>");
        }

        public static IDisposable BeginCollectionItem<TModel>(this HtmlHelper<TModel> html, string collectionPropertyName)
        {
            var itemIndex = GetCollectionItemIndex(collectionPropertyName);
            var collectionItemName = $"{collectionPropertyName}[{itemIndex}]";

            var hiddenInput = new TagBuilder("input");
            hiddenInput.MergeAttributes(new Dictionary<string, string>
            {
                { "name", $"{collectionPropertyName}.Index"},
                { "value", itemIndex },
                { "type", "hidden" },
                { "autocomplete", "off" }
            });

            html.ViewContext.Writer.WriteLine(hiddenInput.ToString(TagRenderMode.SelfClosing));
            return new CollectionItemNamePrefixScope(html.ViewData.TemplateInfo, collectionItemName);
        }

        private static string GetCollectionItemIndex(string collectionIndexFieldName)
        {
            var fieldKey = "CollectionEditorExtensions:" + collectionIndexFieldName;
            Queue<string> previousIndices = (Queue<string>)HttpContext.Current.Items[fieldKey];

            if (previousIndices == null)
            {
                previousIndices = new Queue<string>();
                HttpContext.Current.Items[fieldKey] = new Queue<string>();

                var previousIndicesValues = HttpContext.Current.Request[collectionIndexFieldName + ".Index"];
                if (!String.IsNullOrWhiteSpace(previousIndicesValues))
                {
                    foreach (var index in previousIndicesValues.Split(','))
                        previousIndices.Enqueue(index);
                }
            }

            return previousIndices.Count > 0 ? previousIndices.Dequeue() : Guid.NewGuid().ToString();
        }

        private class CollectionItemNamePrefixScope : IDisposable
        {
            private readonly TemplateInfo _templateInfo;
            private readonly string _previousPrefix;

            public CollectionItemNamePrefixScope(TemplateInfo templateInfo, string collectionItemName)
            {
                _templateInfo = templateInfo;
                _previousPrefix = templateInfo.HtmlFieldPrefix;

                templateInfo.HtmlFieldPrefix = collectionItemName;
            }

            public void Dispose()
            {
                _templateInfo.HtmlFieldPrefix = _previousPrefix;
            }
        }
        #endregion
    }
}
