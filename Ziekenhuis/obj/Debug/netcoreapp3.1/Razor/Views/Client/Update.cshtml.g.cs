#pragma checksum "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f2a63d9dbdaf4ea309d87e43793dc73c91ac689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Update), @"mvc.1.0.view", @"/Views/Client/Update.cshtml")]
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
#nullable restore
#line 2 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
using Ziekenhuis.Model.ConstantsAndEnums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f2a63d9dbdaf4ea309d87e43793dc73c91ac689", @"/Views/Client/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aa387ae76655fcb036c5f168de19d98bb21ac6", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ziekenhuis.Ziekenhuis.ViewModels.ClientViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "GedeeldeViewsClient/_ClientFieldsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "GedeeldeViewsClient/_ButtonToClientListPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ComplimentPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!-- Onderstaande is niet goed, er is geen redisplay van ClientFullName -->\r\n<!-- Bij het tonen van foutboodschappen -->\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""form-horizontal"">

    <!-- We willen de errormessages verzamelen en tonen: -->
    <!-- De Summary box toont geen foutboodschappen op property level in de Summary box-->
    <!-- Maw de foutboodschappen vanuit Data Annotations komen bij de velden zelf -->
    <!-- Als ModelState.IsValid dan vervolgen we met de complexere custom made error messages -->
    <!-- Zoals bijvoorbeeld een check op een reguliere expressie, of een database integriteits-check -->
    <!-- excludePropertyErrors = true -->
    <!-- Alleen complexe, expliciet gecodeerde foutboodschappen tonen we in de ValidationSummary -->


    ");
#nullable restore
#line 24 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <!-- Zet alle velden, die niet op scherm muteerbaar zijn in HiddenFor : NIET VERGETEN !! -->
    <!-- Anders krijgt de controller deze velden niet meer terug in de POST aktie -->
    <!-- en komt  ook ModelState voor deze velden op false, zeker als het veld [required] is -->

    <!-- Let op, velden die je wel muteert, niet in HiddenFor zetten  -->
    <!-- In het bijzonder het sleutelveld van de Dropdownlists -->

    ");
#nullable restore
#line 33 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.HiddenFor(c => c.Client.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 34 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.HiddenFor(c => c.Client.DoctorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 36 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.HiddenFor(c => c.Client.AstrologyZodiacSign));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 37 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
Write(Html.HiddenFor(c => c.Client.TypeOfSporter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    <!-- Attentie, een veld dat op het scherm aan te passen is, mag niet -->\r\n    <!-- een tweede keer in de HiddenForLijst verschijnen -->\r\n    <!-- Onderstaande regel maakt BirthDate niet meer wijzigbaar-->\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n    <div class=\"row\" style=\"border: 1px solid #ff6a00; border-radius:5px;\">\r\n\r\n        <br />\r\n        <div class=\"col-sm-10\">\r\n\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 56 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
           Write(Html.LabelFor(c => c.Client.ClientNumber, htmlAttributes:
                        new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 59 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
               Write(Html.EditorFor(c => c.Client.ClientNumber,
                       new { htmlAttributes = new { @readonly = "readonly", @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 61 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
               Write(Html.ValidationMessageFor(c => c.Client.ClientNumber, "",
                            new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 69 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
           Write(Html.LabelFor(c => c.Client.ActionCode, htmlAttributes:
                        new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 71 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
           Write(Html.DropDownListFor(c => c.Client.ActionCode, new SelectList(Enum.GetValues(typeof(ActionCode))),
                    "Actief/Inactief"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f2a63d9dbdaf4ea309d87e43793dc73c91ac68910147", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 85 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            <!-- derived fields - readonly -->\r\n            <fieldset disabled>\r\n                <br /><br />\r\n                ");
#nullable restore
#line 90 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
           Write(Html.LabelFor(c => c.AgeInDays, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 92 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
               Write(Html.EditorFor(c => c.AgeInDays, new
                    {
                        htmlAttributes =
                   new { @class = "form-control" }
                    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <br />\r\n                ");
#nullable restore
#line 99 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
           Write(Html.LabelFor(c => c.NrofPrescriptions, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 101 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
               Write(Html.EditorFor(c => c.NrofPrescriptions, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <br /> <br />
            </fieldset>

            <br />
            <div>
                <input type=""submit"" value=""Wijzig client"" />
            </div>

        </div> <!-- end col-sm-10 -->

    </div> <!-- class = 'row' -->

    <br />
    <!-- Als de shared view niet direct onder een standaard View folder staat -->
    <!-- Bijvoorbeeld ""Client"" ""Prescription"" of ""Shared"" -->
    <!-- Gebruik dan onderstaande syntax met of zonder .cshtml extensie -->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f2a63d9dbdaf4ea309d87e43793dc73c91ac68914089", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 119 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <!-- Onderstaande partial wordt alleen gezocht in de standard view folders: -->\r\n    <!-- \"Client\", \"Prescription\", etc, en \"Shared\" -->\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f2a63d9dbdaf4ea309d87e43793dc73c91ac68915901", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div> <!-- class = form-horizontal -->\r\n");
#nullable restore
#line 126 "C:\Users\janpi\source\repos\@Ziekenhuis App\Ziekenhuis Current\Ziekenhuis\Views\Client\Update.cshtml"


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
