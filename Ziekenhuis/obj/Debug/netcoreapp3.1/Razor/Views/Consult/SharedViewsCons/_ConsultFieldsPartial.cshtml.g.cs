#pragma checksum "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35845e4615f6adf5537d898e84c208a4e4dedf18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consult_SharedViewsCons__ConsultFieldsPartial), @"mvc.1.0.view", @"/Views/Consult/SharedViewsCons/_ConsultFieldsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35845e4615f6adf5537d898e84c208a4e4dedf18", @"/Views/Consult/SharedViewsCons/_ConsultFieldsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Consult_SharedViewsCons__ConsultFieldsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.ConsultViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 4 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.LabelFor(p => p.Consult.ConsultDescr, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    ");
#nullable restore
#line 6 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.TextBoxFor(p => p.Consult.ConsultDescr, new { placeholder = "Vul omschrijving in", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 7 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(p => p.Consult.ConsultDescr, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <br />\r\n    ");
#nullable restore
#line 10 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.LabelFor(p => p.Consult.ConsultDate, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 11 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.EditorFor(p => p.Consult.ConsultDate, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 12 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(p => p.Consult.ConsultDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br /><br />\r\n\r\n\r\n    ");
#nullable restore
#line 16 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.LabelFor(p => p.Consult.CommentForDoctor, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    ");
#nullable restore
#line 17 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.TextAreaFor(p => p.Consult.CommentForDoctor, new { @class = "text-area-JP", placeholder = "Vul comment toe voor dit consult" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 18 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(p => p.Consult.CommentForDoctor, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n\r\n    <br />\r\n    ");
#nullable restore
#line 22 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.LabelFor(p => p.Consult.Price, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 23 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.EditorFor(p => p.Consult.Price, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 24 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Consult\SharedViewsCons\_ConsultFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(p => p.Consult.Price, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n</div>\r\n\r\n<!-------------------------------------------------->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ziekenhuis.Ziekenhuis.ViewModels.ConsultViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
