#pragma checksum "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Prescription\SharedViewsPrescr\_ButtonToPrescrListPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e4bceabda51c121bf6652a7520c5ba275a696e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prescription_SharedViewsPrescr__ButtonToPrescrListPartial), @"mvc.1.0.view", @"/Views/Prescription/SharedViewsPrescr/_ButtonToPrescrListPartial.cshtml")]
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
#line 1 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\_ViewImports.cshtml"
using Ziekenhuis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\_ViewImports.cshtml"
using Ziekenhuis.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e4bceabda51c121bf6652a7520c5ba275a696e7", @"/Views/Prescription/SharedViewsPrescr/_ButtonToPrescrListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Prescription_SharedViewsPrescr__ButtonToPrescrListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.PrescrWith5LinesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<button class=\"clickButtonJP\">\r\n    ");
#nullable restore
#line 4 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Prescription\SharedViewsPrescr\_ButtonToPrescrListPartial.cshtml"
Write(Html.ActionLink("Naar recepten-lijst ", "Index",
   new
        {
            doctorId = Model.Prescription.DoctorId,
            clientId = Model.Prescription.ClientId
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ziekenhuis.Ziekenhuis.ViewModels.PrescrWith5LinesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
