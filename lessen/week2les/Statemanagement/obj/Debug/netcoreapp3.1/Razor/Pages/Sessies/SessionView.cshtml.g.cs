#pragma checksum "D:\code\HBO\jaar2\servertechnology\week2les\Statemanagement\Pages\Sessies\SessionView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9557778add93e24d6b0505bd5924f007ac615080"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Statemanagement.Pages.Sessies.Pages_Sessies_SessionView), @"mvc.1.0.razor-page", @"/Pages/Sessies/SessionView.cshtml")]
namespace Statemanagement.Pages.Sessies
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
#line 1 "D:\code\HBO\jaar2\servertechnology\week2les\Statemanagement\Pages\_ViewImports.cshtml"
using Statemanagement;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9557778add93e24d6b0505bd5924f007ac615080", @"/Pages/Sessies/SessionView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a1f7a7b4e6d1ec6e914c8a0e4990e9246db4704", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Sessies_SessionView : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\code\HBO\jaar2\servertechnology\week2les\Statemanagement\Pages\Sessies\SessionView.cshtml"
  
    ViewData["Title"] = "SessionView";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>SessionView</h1>\r\n\r\n<h4>");
#nullable restore
#line 9 "D:\code\HBO\jaar2\servertechnology\week2les\Statemanagement\Pages\Sessies\SessionView.cshtml"
Write(ViewData["SessieTekst"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<h4>");
#nullable restore
#line 10 "D:\code\HBO\jaar2\servertechnology\week2les\Statemanagement\Pages\Sessies\SessionView.cshtml"
Write(ViewData["Boek"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Statemanagement.SessionViewModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Statemanagement.SessionViewModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Statemanagement.SessionViewModel>)PageContext?.ViewData;
        public Statemanagement.SessionViewModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
