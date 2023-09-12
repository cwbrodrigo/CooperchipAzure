using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net.NetworkInformation;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.TagHelpers
{
    public class NossoEmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var prefix = await output.GetChildContentAsync();
            var email = prefix.GetContent() + "@gmail.com";
            output.Attributes.SetAttribute("href, mailto", email);
            output.Content.SetContent(email);
        }
    }
}
