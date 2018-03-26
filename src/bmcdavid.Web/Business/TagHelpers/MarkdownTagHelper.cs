using CommonMark;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace bmcdavid.Web
{
    [HtmlTargetElement("markdown", TagStructure = TagStructure.NormalOrSelfClosing)]
    [HtmlTargetElement(Attributes = "markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        public ModelExpression Content { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName == "markdown")
            {
                output.TagName = null;
            }
            output.Attributes.RemoveAll("markdown");

            var content = await GetContent(output);
            //var options = new HeyRed.MarkdownSharp.MarkdownOptions
            //{
            //    AutoHyperlink = true,
            //    AutoNewLines = true,
            //    LinkEmails = true,
            //    QuoteSingleLine = true,
            //    StrictBoldItalic = true
            //};
            //var mark = new HeyRed.MarkdownSharp.Markdown(options);
            //var html = mark.Transform(content);
            var html = CommonMarkConverter.Convert(content);
            output.Content.SetHtmlContent(html ?? "");
        }

        private async Task<string> GetContent(TagHelperOutput output)
        {
            if (Content != null) return Content.Model?.ToString();

            return (await output.GetChildContentAsync()).GetContent();

        }
    }
}
