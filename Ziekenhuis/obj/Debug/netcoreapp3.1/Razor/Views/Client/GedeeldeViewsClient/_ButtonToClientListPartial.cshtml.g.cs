#pragma checksum "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ButtonToClientListPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e56526128d18d49aa7382d657114580b93decb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_GedeeldeViewsClient__ButtonToClientListPartial), @"mvc.1.0.view", @"/Views/Client/GedeeldeViewsClient/_ButtonToClientListPartial.cshtml")]
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
#line 1 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\_ViewImports.cshtml"
using Ziekenhuis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\_ViewImports.cshtml"
using Ziekenhuis.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e56526128d18d49aa7382d657114580b93decb8", @"/Views/Client/GedeeldeViewsClient/_ButtonToClientListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_GedeeldeViewsClient__ButtonToClientListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <br />\r\n<button class=\"clickButtonJP purpleJP\">\r\n    ");
#nullable restore
#line 4 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ButtonToClientListPartial.cshtml"
Write(Html.ActionLink($"Ga terug naar clienten-lijst voor dokter {Model.DoctorFullName}", "Index", 
   new
        {
            doctorId = Model.Client.DoctorId 
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</button>\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ziekenhuis.Ziekenhuis.ViewModels.ClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
