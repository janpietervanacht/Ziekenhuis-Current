#pragma checksum "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbc5c7ad1fb7b08edf13cef173482c76d17c8a31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_SharedViewsInvoice__InvoiceFieldsPartial), @"mvc.1.0.view", @"/Views/Invoice/SharedViewsInvoice/_InvoiceFieldsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbc5c7ad1fb7b08edf13cef173482c76d17c8a31", @"/Views/Invoice/SharedViewsInvoice/_InvoiceFieldsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_SharedViewsInvoice__InvoiceFieldsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.InvoiceViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- First show output only fields, do not use a <fieldset disabled> block, does not work -->\r\n<!-- Instead, use readonly attrib -->\r\n\r\n<p>Alle gegevens: </p>\r\n<br />\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 9 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.ClientFullName, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.ClientFullName, new { htmlAttributes = new { @class = "editor-for-JP", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 14 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.DoctorFullName, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 15 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.DoctorFullName, new { htmlAttributes = new { @class = "editor-for-JP", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 19 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.Label("", "Clientnummer:", htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 20 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.ClientNumber, new { htmlAttributes = new { @class = "editor-for-JP", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 24 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.Status, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 25 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.Invoice.Status, new { htmlAttributes = new { @class = "editor-for-JP", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 29 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.SendYN, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 30 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.Invoice.SendYN, new { htmlAttributes = new { @class = "editor-for-JP", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n<!---- end of readonly fields -->\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 38 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.InvoiceDescription, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 39 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Invoice.InvoiceDescription, new
   {
       @class = "form-control purpleJP",
       placeholder = "Vul hier de omschrijving in"
   }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 44 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Invoice.InvoiceDescription, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 48 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.Amount, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 49 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Invoice.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 50 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Invoice.Amount, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 54 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.DueDate, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 55 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.EditorFor(i => i.Invoice.DueDate, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 56 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Invoice.DueDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 60 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.LabelFor(i => i.Invoice.AmountPaid, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 61 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Invoice.AmountPaid, htmlAttributes: new { @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 62 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Invoice.DueDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<!-- Toon alle 3 invoice lines ----------------------------------------------------------->\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 67 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.Label("", "Factuur-regel 1:", htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    ");
#nullable restore
#line 69 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Line1, new { @class = "form-control box-JP box-width-200-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 70 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Line1, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 74 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.Label("", "Factuur-regel 2:", htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    ");
#nullable restore
#line 76 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Line2, new { @class = "form-control box-JP box-width-200-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 77 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Line2, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 81 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.Label("", "Factuur-regel 3:", htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    ");
#nullable restore
#line 83 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.TextBoxFor(i => i.Line3, new { @class = "form-control box-JP box-width-200-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 84 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Invoice\SharedViewsInvoice\_InvoiceFieldsPartial.cshtml"
Write(Html.ValidationMessageFor(i => i.Line3, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ziekenhuis.Ziekenhuis.ViewModels.InvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
