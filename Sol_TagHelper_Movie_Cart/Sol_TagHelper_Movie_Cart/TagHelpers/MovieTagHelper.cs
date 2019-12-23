using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sol_TagHelper_Movie_Cart.Models;

namespace Sol_TagHelper_Movie_Cart.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("movie-cart")]
    public class MovieTagHelper : TagHelper
    {
        #region Declaration
        private readonly IHtmlHelper htmlHelper = null;

        //private const string UrlAttributeName = "url";
        //private const string TitleAttributeName = "title";
        //private const string DetailsAttributeName = "details";
        private const string MovieListAttributeName = "item-source";

        #endregion

        #region Constructor
        public MovieTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        #endregion

        #region Property (Html Attribute)

        //[HtmlAttributeName(UrlAttributeName)]
        //public String Url { get; set; }

        //[HtmlAttributeName(TitleAttributeName)]
        //public String Title { get; set; }

        //[HtmlAttributeName(DetailsAttributeName)]
        //public String Details { get; set; }

        [HtmlAttributeName(MovieListAttributeName)]
        public ModelExpression MovieList { get; set; }


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion 


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            //var movieModel = new MovieModel()
            //{
            //    Url = Convert.ToString(Url),
            //    Title = Convert.ToString(Title),
            //    Details = Convert.ToString(Details)
            //};

            var movieCardTemplate = await htmlHelper.PartialAsync("~/Views/Shared/_MovieTagHelperPartialView.cshtml", MovieList.Model);

            output.Content.SetHtmlContent(movieCardTemplate);

            //return base.ProcessAsync(context, output);
        }
    }
}
