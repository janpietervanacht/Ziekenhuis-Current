#pragma checksum "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da7b3302961d86c8fc494be9c16b29f7fe9280c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_GedeeldeViewsClient__ClientFieldsPartial), @"mvc.1.0.view", @"/Views/Client/GedeeldeViewsClient/_ClientFieldsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da7b3302961d86c8fc494be9c16b29f7fe9280c3", @"/Views/Client/GedeeldeViewsClient/_ClientFieldsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_GedeeldeViewsClient__ClientFieldsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Neem DoctorFullName op in een TextBoxFor, want anders wordt de doctor naam niet meer -->\r\n<!-- getoond bij een redisplay van de view bij foutmeldingen -->\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 5 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.DoctorFullName, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 8 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.DoctorFullName, new { @readonly = "readonly", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 13 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.NrofPrescriptions, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 16 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.NrofPrescriptions, new
                {
                    htmlAttributes =
                        new { @readonly = "readonly", @class = "form-control" }
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 25 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 27 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.Client.FirstName, new { placeholder = "Vul voornaam in", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 28 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 34 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Man"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 35 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.RadioButtonFor(c => c.Client.Gender, "M"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n    ");
#nullable restore
#line 37 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Vrouw"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 38 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.RadioButtonFor(c => c.Client.Gender, "V"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n    ");
#nullable restore
#line 40 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Onzijdig"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 41 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.RadioButtonFor(c => c.Client.Gender, "O"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 46 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Is verzekerd: "));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 47 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.CheckBoxFor(c => c.Client.IsInsured));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 51 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.LastName, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 54 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.Client.LastName,
                new { placeholder = "Vul achternaam in", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 56 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 63 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.Street, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 66 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.Client.Street, new { placeholder = "Vul straat in", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 67 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.Street, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 73 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.HouseNumber, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <!-- Als je EditorFor gebruikt bij een integer veld, verschijnt een arrow-enumerator rechts op -->\r\n    <!-- het veld, dat wil ik niet. Gebruik daarom TextBoxFor -->\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 78 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.Client.HouseNumber, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 79 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.HouseNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 84 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.PostalCode, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 87 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.Client.PostalCode, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 88 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.PostalCode, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n</div>\r\n<div class=\"form-group\">\r\n    <!-- TextBoxFor plaatst het veld rechts van het label -->\r\n    ");
#nullable restore
#line 95 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.City, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 98 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextBoxFor(c => c.Client.City, new { placeholder = "Vul plaats in", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 99 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.City, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<!-- In de ClientViewModel wordt naast de client ook een lijst van alle landen meegegeven-->\r\n<!-- zodat je een dropdownlist van landen kan laten zien -->\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 107 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Land:"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""col-md-10"">
        <!-- c.Client.CountryId wordt gekoppeld aan de 2e parameter van de SelectList -->
        <!-- c.Client.CountryId NIET als HiddenFor opnemen in de cshtml! -->
        <!-- daardoor wordt bij Update View de juiste Country getoond midden in de combobox -->
        <!-- en wordt in de POST method de nieuwe waarde van c.Client.CountryId teruggegeven-->
        <!-- De 2e en 3e parameter van de SelectList zijn properties van class Country -->
        ");
#nullable restore
#line 114 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.DropDownListFor(c => c.Client.CountryId,
                new SelectList(Model.Countries, "Id", "CountryDescription"),
                new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 117 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.CountryId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<!-- In de ClientViewModel wordt naast de client ook een lijst van alle sterrenbeelden meegegeven-->\r\n<!-- zodat je een dropdownlist van sterrenbeelden kan laten zien -->\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 126 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Sterrenbeeld:"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""col-md-10"">
        <!-- c.ZodiacId wordt gekoppeld aan de 2e parameter van de SelectList -->
        <!-- c.ZodiacId NIET als HiddenFor opnemen in de cshtml! -->
        <!-- daardoor wordt bij Update View de juiste ZodiacVM getoond midden in de combobox -->
        <!-- en wordt in de POST method de nieuwe waarde van c.ZodiacId teruggegeven -->
        <!-- De 2e en 3e parameter van de SelectList zijn properties van class ZodiacVM -->
        <!-- op het scherm wordt de 3e parameter getoond -->
        ");
#nullable restore
#line 134 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.DropDownListFor(c => c.ZodiacId,
                new SelectList(Model.AstrologyZodiacSignList, "Id", "AstrologyZodiacSign"),
                new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 137 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.ZodiacId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 143 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.Label("Soort sporter:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 145 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.DropDownListFor(c => c.SportTypeId,
                new SelectList(Model.SportTypeList, "Id", "TypeOfSporter"),
                new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 148 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.SportTypeId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 154 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.BirthDate, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 157 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.Client.BirthDate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 158 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.BirthDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 164 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.BudgetAvaiable, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 167 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.Client.BudgetAvaiable, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 168 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.BudgetAvaiable, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 174 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.BudgetSpent, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 177 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.Client.BudgetSpent, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 178 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.BudgetSpent, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 184 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.CommentForDoctor, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 187 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.TextAreaFor(c => c.Client.CommentForDoctor, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 188 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.CommentForDoctor, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<br />\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 195 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
Write(Html.LabelFor(c => c.Client.PolicyNumber, htmlAttributes:
                     new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 198 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.EditorFor(c => c.Client.PolicyNumber, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 199 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\GedeeldeViewsClient\_ClientFieldsPartial.cshtml"
   Write(Html.ValidationMessageFor(c => c.Client.PolicyNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n");
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
