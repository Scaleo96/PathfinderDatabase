#pragma checksum "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b544e9b3aa4ec016eab4173116a7e0ab1a673ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_Item), @"mvc.1.0.view", @"/Views/Item/Item.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b544e9b3aa4ec016eab4173116a7e0ab1a673ed", @"/Views/Item/Item.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ce22b36fbd58cf06b4462a4d86b44f45b276ada", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_Item : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PathfinderHomebrew.Models.Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<article>\r\n    <h1>\r\n        <b>(");
#nullable restore
#line 5 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
       Write(Model.TypeName());

#line default
#line hidden
#nullable disable
            WriteLiteral(") ");
#nullable restore
#line 5 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
         if (User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span> | <a class=\"feat-Link\"");
            BeginWriteAttribute("href", " href=\"", 209, "\"", 270, 1);
#nullable restore
#line 9 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
WriteAttributeValue("", 216, Url.Action("Remove", "Item", new { key = Model.Key }), 216, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></span>\r\n");
#nullable restore
#line 10 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <br />\r\n    </h1>\r\n    <div class=\"details\">\r\n    </div>\r\n    <div class=\"content feat-Content\">\r\n\r\n        <p>\r\n            <b class=\"black-ben\">Aura</b> ");
#nullable restore
#line 19 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                                     Write(Model.AuraStrength);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
             for (int i = 0; i < Model.AuraTypes.Count; i++)
            {

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
        Write(Model.AuraTypes[i].AuraType.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                                                     if (Model.AuraTypes.Count - 1 > i)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>, </span>");
#nullable restore
#line 22 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>;</span>");
#nullable restore
#line 24 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                           }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <b class=\"black-ben\">CL</b>\r\n            ");
#nullable restore
#line 26 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
        Write(Model.CasterLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("th;\r\n            <b class=\"black-ben\">Weight </b>\r\n            ");
#nullable restore
#line 28 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
       Write(Model.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            lbs;\r\n            <b class=\"black-ben\">Price </b>\r\n            ");
#nullable restore
#line 31 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            gp\r\n        </p>\r\n\r\n        <p class=\"item-divider\">DESCRIPTION</p>\r\n        <p>");
#nullable restore
#line 36 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"item-divider\">CONSTRUCTION REQUIREMENTS</p>\r\n        <p>");
#nullable restore
#line 38 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
      Write(Model.ConstructionRequirements);

#line default
#line hidden
#nullable disable
            WriteLiteral("; <b>Cost </b> ");
#nullable restore
#line 38 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Item\Item.cshtml"
                                                     Write(Model.Price/2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" gp</p>\r\n\r\n    </div>\r\n</article>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PathfinderHomebrew.Models.Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
