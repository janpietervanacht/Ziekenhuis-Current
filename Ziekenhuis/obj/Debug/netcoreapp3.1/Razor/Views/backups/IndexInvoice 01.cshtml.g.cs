#pragma checksum "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87262f621adf5ae87ddce6318f5c2b0422faefc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_backups_IndexInvoice_01), @"mvc.1.0.view", @"/Views/backups/IndexInvoice 01.cshtml")]
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
#nullable restore
#line 2 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
using Ziekenhuis.Ziekenhuis.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87262f621adf5ae87ddce6318f5c2b0422faefc9", @"/Views/backups/IndexInvoice 01.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_backups_IndexInvoice_01 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.InvoiceListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
 if (@Model.ClientId != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Lijst met facturen voor één client: ");
#nullable restore
#line 6 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
                                       Write(Model.ClientFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 7 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
 if (@Model.DoctorId != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Lijst met facturen voor één dokter: ");
#nullable restore
#line 11 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
                                       Write(Model.DoctorFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 12 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
 if (@Model.ClientId == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Lijst met alle facturen voor alle clienten</h4>\r\n");
#nullable restore
#line 17 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
 if (@Model.DoctorId == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Lijst met alle facturen voor alle dokters</h4>\r\n");
#nullable restore
#line 22 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Zowel arts als client moeten bekend zijn om een factuur te kunnen maken -->\r\n<!-- Beide value parameters zijn niet nullable -->\r\n<p>\r\n");
#nullable restore
#line 27 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
     if (@Model.DoctorId != null && Model.ClientId != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button style=\"font-style: italic; color: purple\">\r\n            ");
#nullable restore
#line 30 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.ActionLink($"Maak factuur", "Create",
           new { clientId = Model.ClientId, doctorId = Model.DoctorId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </button>\r\n");
#nullable restore
#line 33 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<p>\r\n\r\n    <!-- Html.ActionLink maakt de hele knop aan, inclusief onderwater href = \" \" -->\r\n    <button type=\"submit\" style=\"color: blue; font-size: 14px\">\r\n        ");
#nullable restore
#line 40 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
   Write(Html.ActionLink("Naar Hoofdmenu", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </button>\r\n    <br />\r\n    <br />\r\n\r\n    <button type=\"submit\" style=\"color: blue; font-size: 14px\">\r\n        ");
#nullable restore
#line 46 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
   Write(Html.ActionLink("Naar clienten-lijst", "Index", "Client", new { doctorId = Model.DoctorId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </button>\r\n</p>\r\n\r\n\r\n\r\n<table class=\"table table-condensed table-hover\">\r\n    <tr>\r\n\r\n        <!-- Als geen client meegegeven als parameter, dan worden de recepten-->\r\n        <!-- van alle clienten getoond. -->\r\n");
#nullable restore
#line 57 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
         if (@Model.ClientId == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th class=\"redJP tableHeaderJP\">\r\n                ");
#nullable restore
#line 60 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayNameFor(m => m.ClientFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
#nullable restore
#line 62 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <!-- Als geen doctor meegegeven als parameter, dan worden de recepten-->\r\n        <!-- van alle doctoren getoond. -->\r\n\r\n");
#nullable restore
#line 66 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
         if (@Model.DoctorId == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th class=\"redJP tableHeaderJP\">\r\n                ");
#nullable restore
#line 69 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayNameFor(m => m.DoctorFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
#nullable restore
#line 71 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <th class=\"yellowJP tableHeaderJP\">\r\n            ");
#nullable restore
#line 74 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.DisplayName("Factuurnummer"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th class=\"brownJP tableHeaderJP\">\r\n            ");
#nullable restore
#line 78 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.DisplayName("Action code"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n\r\n        <th class=\"brownJP tableHeaderJP\">\r\n            ");
#nullable restore
#line 83 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.DisplayName("Status"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th class=\"blueJP tableHeaderJP\">\r\n            ");
#nullable restore
#line 87 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.DisplayName("Bedrag factuur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th class=\"blueJP tableHeaderJP\">\r\n            ");
#nullable restore
#line 91 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
       Write(Html.DisplayName("Vervaldatum"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th></th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 98 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
     foreach (var invVM in @Model.InvoiceList)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n");
#nullable restore
#line 102 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
             if (@Model.ClientId == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 105 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
               Write(Html.DisplayFor(i => invVM.ClientFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 107 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 109 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
             if (@Model.DoctorId == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 112 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
               Write(Html.DisplayFor(i => invVM.DoctorFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 114 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <!-- NTD: factuurnummer opmaken met leading zeroes -->\r\n            <td>\r\n                ");
#nullable restore
#line 118 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayFor(i => invVM.Invoice.InvoiceNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 121 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayFor(i => invVM.Invoice.ActionCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <!-- NTD: status weergeven met een Enum, ipv DataBaseWaarden VRAAG PETER -->\r\n            <td>\r\n                ");
#nullable restore
#line 125 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayFor(i => invVM.Invoice.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td class=\"invAmount\">\r\n                ");
#nullable restore
#line 129 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayFor(i => invVM.Invoice.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 133 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
           Write(Html.DisplayFor(i => invVM.Invoice.DueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n\r\n            <td>\r\n                <button class=\"clickButtonJP\">\r\n                    ");
#nullable restore
#line 139 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
               Write(Html.ActionLink("Details factuur " + invVM.Invoice.InvoiceDescription,
            "Details", "Invoice", new { invoiceId = invVM.Invoice.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                </button>
            </td>
            <!-- ------------------------------------------------------------------------------------ -->

            <td>
                <button class=""clickButtonJP"">
                    <!-- controller naam mag weg als je in dezelfde controller blijft -->
                    ");
#nullable restore
#line 148 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
               Write(Html.ActionLink($"Verwijder factuur ", "Delete", new { invoiceId = invVM.Invoice.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </td>\r\n\r\n            <td>\r\n                <button class=\"clickButtonJP\">\r\n                    <!-- controller naam mag weg als je in dezelfde controller blijft -->\r\n                    ");
#nullable restore
#line 155 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"
               Write(Html.ActionLink($"Wijzig factuur ", "Update", "Invoice", new { invoiceId = invVM.Invoice.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </button>\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 160 "D:\Users\janpi\repos-d\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\backups\IndexInvoice 01.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <tr>
        <td></td>
    </tr>
</table>

<br>
<button onclick=""berekenTotaalBedrag()"">Bereken totalen</button>
<br />
<input type=""text"" id=""show1"" disabled />
<br />
<input type=""text"" id=""show2"" disabled />
<br />
<input type=""text"" id=""show3"" disabled>
<br />
<input type=""text"" id=""show3"" disabled>
<br />
<input type=""text"" id=""show4"" disabled>
<br />

<script>

    var x = 0;

    function berekenTotaalBedrag() {

        var invList = document.getElementsByClassName(""invAmount"");

        document.getElementById(""show1"").value = x;
        document.getElementById(""show2"").value = invList[x].innerText;
        document.getElementById(""show3"").value = parseFloat(invList[x].innerText);

        x++;
        if (x == invList.length) {
            x = 0;
        }
    };
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ziekenhuis.Ziekenhuis.ViewModels.InvoiceListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
