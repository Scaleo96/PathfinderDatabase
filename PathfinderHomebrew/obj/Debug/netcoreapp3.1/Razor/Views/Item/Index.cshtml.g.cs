#pragma checksum "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e61e677dcdea82f57c8f99f1844cb8ac7c05122e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_Index), @"mvc.1.0.view", @"/Views/Item/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\_ViewImports.cshtml"
using PathfinderHomebrew;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\_ViewImports.cshtml"
using PathfinderHomebrew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e61e677dcdea82f57c8f99f1844cb8ac7c05122e", @"/Views/Item/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ce22b36fbd58cf06b4462a4d86b44f45b276ada", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PathfinderHomebrew.Models.Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
   
    var parms = new Dictionary<string, string>
    {
        { "type", ViewBag.Type }
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Items | <span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e61e677dcdea82f57c8f99f1844cb8ac7c05122e4371", async() => {
                WriteLiteral("<b>Add New Item</b>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 10 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = parms;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span></h1>\r\n\r\n<p>\r\n    Below is a list of homebrew and thrird-party items allowed.\r\n</p>\r\n\r\n<p class=\"pager\">\r\n");
#nullable restore
#line 17 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
     if (ViewBag.HasPreviousPage)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"prev\"");
            BeginWriteAttribute("href", " href=\"", 464, "\"", 558, 1);
#nullable restore
#line 19 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
WriteAttributeValue("", 471, Url.Action("Index", "Item" , new { type = ViewBag.Type, page = ViewBag.PreviousPage }), 471, 87, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            &lt; Previous\r\n        </a>\r\n");
#nullable restore
#line 22 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 24 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
     if (ViewBag.HasNextPage)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"next\"");
            BeginWriteAttribute("href", " href=\"", 673, "\"", 763, 1);
#nullable restore
#line 26 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
WriteAttributeValue("", 680, Url.Action("Index", "Item" , new { type = ViewBag.Type, page = ViewBag.NextPage }), 680, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            Next &gt;\r\n        </a>\r\n");
#nullable restore
#line 29 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

<div class=""feat-list"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th scope=""col"">Item Name</th>
                <th scope=""col"">Category/Type</th>
                <th scope=""col"">Price</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 42 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"feat-listing\"></tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 45 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
                           Write(Html.ActionLink(item.Name, "Item", "Item", new { key = item.Key }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 47 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
             if (item.Type != ItemType.Wondrous_Item)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 49 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
               Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 50 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 53 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
               Write(item.ItemSlot);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 54 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 56 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 57 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PathfinderHomebrew.Models.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
