#pragma checksum "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad242bca818126a6ed5479d312d484375e71a0b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inventory_ChangeStock), @"mvc.1.0.view", @"/Views/Inventory/ChangeStock.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad242bca818126a6ed5479d312d484375e71a0b3", @"/Views/Inventory/ChangeStock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2671581be0bb2cfe9521ab7bcf5661bb3a795a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Inventory_ChangeStock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ReportOfChanges>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/changeStock.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<button class=""btn btn-primary"" id=""accept"">Zmień stan magazynowy(uwaga, utracisz możliwośćkontynuacji inwentaryzacji)</button>
<table id=""items"" class=""table table-striped"">
    <thead class=""thead-dark"">
        <tr>
            <th>Id produktu</th>
            <th>SKU</th>
            <th>Różnica</th>
            <th>Stan faktyczny</th>
            <th>Tytuł oferty</th>
        </tr>
    </thead>
    <tbody class=""table-striped"">
");
#nullable restore
#line 14 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
         foreach (ReportOfChanges reportOfChanges in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 566, "\"", 604, 1);
#nullable restore
#line 16 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
WriteAttributeValue("", 574, reportOfChanges.sku.Trim(' '), 574, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td class=\"id\"> ");
#nullable restore
#line 17 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                           Write(reportOfChanges.product_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"sku\">");
#nullable restore
#line 18 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                           Write(reportOfChanges.sku.Trim(' '));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 19 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                 if (reportOfChanges.difference_of_stock > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"difference_of_stock\">");
#nullable restore
#line 21 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                                               Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 22 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                }
                else if (@reportOfChanges.difference_of_stock == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"difference_of_stock\">");
#nullable restore
#line 25 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                                               Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"difference_of_stock\">");
#nullable restore
#line 29 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                                               Write(reportOfChanges.difference_of_stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 30 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"realStock\">");
#nullable restore
#line 31 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                                 Write(reportOfChanges.realStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"name\">");
#nullable restore
#line 32 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"
                            Write(reportOfChanges.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Dariusz Kubacki\source\repos\ShoperInwentaryzacja\ShoperInwentaryzacja\Views\Inventory\ChangeStock.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad242bca818126a6ed5479d312d484375e71a0b310598", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            DefineSection("Items", async() => {
                WriteLiteral("\r\n    <li class=\"nav-item\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad242bca818126a6ed5479d312d484375e71a0b311943", async() => {
                    WriteLiteral("Wyloguj");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </li>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ReportOfChanges>> Html { get; private set; }
    }
}
#pragma warning restore 1591