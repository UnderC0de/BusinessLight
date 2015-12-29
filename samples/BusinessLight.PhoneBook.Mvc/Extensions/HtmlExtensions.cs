using System.Web.Mvc;
using System.Web.Mvc.Html;
using BusinessLight.Dto;
using BusinessLight.PhoneBook.Mvc.ViewModels;

namespace BusinessLight.PhoneBook.Mvc.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Pager<TFilter, TResult>(this HtmlHelper helper, PagedViewModel<TFilter, TResult> model)
            where TFilter : IPagedFilter
            where TResult : UniqueEntityDto
        {
            var ulBuilder = new TagBuilder("ul");
            ulBuilder.AddCssClass("pagination");
            
            var pagingInfo = model.PagedResult.PagingInfo;
            for (var i = 0; i < pagingInfo.PageCount; i++)
            {
                var liBuilder = new TagBuilder("li");

                if (i == model.PagedFilter.PageNumber)
                {
                    liBuilder.AddCssClass("active");
                }
                var aBuilder = new TagBuilder("a");
                aBuilder.SetInnerText((i + 1).ToString());
                aBuilder.Attributes.Add("href", "#");

                liBuilder.InnerHtml += aBuilder;
                ulBuilder.InnerHtml += liBuilder;
            }
            var htmlHelper = new HtmlHelper<PagedViewModel<TFilter, TResult>>(helper.ViewContext, helper.ViewDataContainer, helper.RouteCollection);
            ulBuilder.InnerHtml += htmlHelper.HiddenFor(m => m.PagedFilter.PageNumber);
            var hiddenPageNumber = htmlHelper.IdFor(m => m.PagedFilter.PageNumber).ToString();
            var scriptBuilder = new TagBuilder("script")
            {
                InnerHtml = string.Format("$('.pagination > li').click(function(){{ $('#{0}').val($(this).text() - 1); $(this).parents('form:first').submit(); return false; }});", hiddenPageNumber)
            };
            
            ulBuilder.InnerHtml += scriptBuilder;
            return new MvcHtmlString(ulBuilder.ToString());
        }
    }
}