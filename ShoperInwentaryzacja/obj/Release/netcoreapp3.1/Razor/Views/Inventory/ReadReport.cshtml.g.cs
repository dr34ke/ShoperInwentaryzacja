#pragma checksum "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ff8b828bde3a6887dfcc63a9fd8ace808b04cbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inventory_ReadReport), @"mvc.1.0.view", @"/Views/Inventory/ReadReport.cshtml")]
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
#line 1 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\_ViewImports.cshtml"
using ShoperInwentaryzacja;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\_ViewImports.cshtml"
using ShoperInwentaryzacja.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ff8b828bde3a6887dfcc63a9fd8ace808b04cbc", @"/Views/Inventory/ReadReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2671581be0bb2cfe9521ab7bcf5661bb3a795a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Inventory_ReadReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<ReportOfChanges>, string, string>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeStock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ReadTable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
  
    var parms = new Dictionary<string, string>
    {
                { "shopId", Model.Item2 },
                { "inventoryId", Model.Item3 }
            };

#line default
#line hidden
#nullable disable
            WriteLiteral("<button id=\"accept\"></button>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ff8b828bde3a6887dfcc63a9fd8ace808b04cbc4980", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 12 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = parms;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" |
<button class=""accepted"" style=""display:none""></button>
<table id=""items"">
    <thead>
        <tr>
            <th>Akceptuj zmianę</th>
            <th>Id produktu</th>
            <th>SKU</th>
            <th>Różnica</th>
            <th>Stan faktyczny</th>
            <th>Tytuł oferty</th>
        </tr>
    </thead>
");
#nullable restore
#line 25 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
     foreach (ReportOfChanges reportOfChanges in Model.Item1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n");
#nullable restore
#line 29 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                 if (@reportOfChanges.difference_of_stock == 0)
                {
                    reportOfChanges.accepted = false;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4ff8b828bde3a6887dfcc63a9fd8ace808b04cbc7713", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 33 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => reportOfChanges.accepted);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n            <td class=\"id\"> ");
#nullable restore
#line 35 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                       Write(reportOfChanges.product_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"sku\">");
#nullable restore
#line 36 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                       Write(reportOfChanges.sku.Trim(' '));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 37 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
             if (reportOfChanges.difference_of_stock > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"difference_of_stock\">");
#nullable restore
#line 39 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                                           Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 40 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
            }
            else if (@reportOfChanges.difference_of_stock == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"difference_of_stock\">");
#nullable restore
#line 43 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                                           Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 44 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"difference_of_stock\">");
#nullable restore
#line 47 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                                           Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 48 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td class=\"realStock\">");
#nullable restore
#line 49 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                             Write(reportOfChanges.realStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"name\">");
#nullable restore
#line 50 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"
                        Write(reportOfChanges.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ReadReport.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ff8b828bde3a6887dfcc63a9fd8ace808b04cbc13134", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<ReportOfChanges>, string, string>> Html { get; private set; }
    }
}
#pragma warning restore 1591