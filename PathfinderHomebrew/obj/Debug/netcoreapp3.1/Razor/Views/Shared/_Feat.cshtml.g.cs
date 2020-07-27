#pragma checksum "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38ad00a61bdb20cb9e974f1546be2205edcf4cca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Feat), @"mvc.1.0.view", @"/Views/Shared/_Feat.cshtml")]
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
#line 2 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
using PathfinderHomebrew.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
using PathfinderHomebrew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ad00a61bdb20cb9e974f1546be2205edcf4cca", @"/Views/Shared/_Feat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ce22b36fbd58cf06b4462a4d86b44f45b276ada", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Feat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PathfinderHomebrew.Models.Feat>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<article>\r\n    <h1>\r\n        <b>(");
#nullable restore
#line 9 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
       Write(Model.Type.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(") ");
#nullable restore
#line 9 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if ((await AuthorizationService.AuthorizeAsync(
       User, Model.OwnerID, Operations.Update)).Succeeded)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span> | <a class=\"feat-Link\"");
            BeginWriteAttribute("href", " href=\"", 458, "\"", 517, 1);
#nullable restore
#line 14 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
WriteAttributeValue("", 465, Url.Action("Edit", "Feat", new { key = Model.Key }), 465, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></span>\r\n");
#nullable restore
#line 15 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if ((await AuthorizationService.AuthorizeAsync(
       User, Model.OwnerID, Operations.Delete)).Succeeded)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span> | <a class=\"feat-Link\"");
            BeginWriteAttribute("href", " href=\"", 717, "\"", 778, 1);
#nullable restore
#line 19 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
WriteAttributeValue("", 724, Url.Action("Remove", "Feat", new { key = Model.Key }), 724, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></span>\r\n");
#nullable restore
#line 20 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <br />\r\n    </h1>\r\n    <div class=\"details\">\r\n    </div>\r\n    <div class=\"content feat-Content\">\r\n\r\n");
#nullable restore
#line 28 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if (Model.FlavorText != null && Model.FlavorText.Length > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><i>");
#nullable restore
#line 30 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
             Write(Model.FlavorText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></p>\r\n");
#nullable restore
#line 31 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if (Model.Prerequisites != null && Model.Prerequisites.Length > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><b class=\"black-ben\">Prerequisites: </b>");
#nullable restore
#line 35 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
                                                  Write(Model.Prerequisites);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 36 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p><b class=\"black-ben\">Benefit: </b>");
#nullable restore
#line 38 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
                                        Write(Model.Benefits);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 40 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if (Model.Special != null && Model.Special.Length > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><b class=\"black-ben\">Special: </b>");
#nullable restore
#line 42 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
                                            Write(Model.Special);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 43 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
         if (Model.Normal != null && Model.Normal.Length > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><b class=\"black-ben\">Normal: </b>");
#nullable restore
#line 47 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
                                           Write(Model.Normal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 48 "C:\Users\Johan\source\repos\PathfinderHomebrew\PathfinderHomebrew\Views\Shared\_Feat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</article>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PathfinderHomebrew.Models.Feat> Html { get; private set; }
    }
}
#pragma warning restore 1591