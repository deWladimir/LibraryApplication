#pragma checksum "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "284493a10484764694cce44f5a5eadd03ad326c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
#line 1 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\_ViewImports.cshtml"
using LibraryApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\_ViewImports.cshtml"
using LibraryApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\_ViewImports.cshtml"
using LibraryApplication.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"284493a10484764694cce44f5a5eadd03ad326c6", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26b1dd210bbfdcd5c1d9aa8f270204e21129424f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GenreFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CountryFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Authors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
#nullable disable
            DefineSection("FixedBar", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
     foreach (var g in DataForFixedBar.Genres)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "284493a10484764694cce44f5a5eadd03ad326c65713", async() => {
#nullable restore
#line 8 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                                      Write(g.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                        WriteLiteral(g.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <h2 style=\"margin: 0.15em 0 0.1em 0.1em; color: #343434; font-size: 20px; font-weight: normal; text-transform: uppercase; font-family: \'Orienta\', sans-serif; letter-spacing: 1px;\">???????????? ???? ??????????????</h2>\r\n");
#nullable restore
#line 11 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
     foreach (var c in DataForFixedBar.Countries)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "284493a10484764694cce44f5a5eadd03ad326c69344", async() => {
#nullable restore
#line 13 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                                        Write(c.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                          WriteLiteral(c.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral(@"<style>
    .layer1 {
        background-color: #9ee8c0;
        padding: 10px;
    }

    .layer2 {
        background-color: #78471011;
        margin-top: 10px;
        padding: 20px;
    }
</style>
<div class=""layer1"">
    <h1>???????????????????? ???????????? ???? ??????????????</h1>
    <h3>""");
#nullable restore
#line 30 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
    Write(ViewBag.Query);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h3>\r\n</div>\r\n<div class=\"layer2\">\r\n");
#nullable restore
#line 33 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
     if (ViewBag.BNumber != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>????????????:</h2>\r\n");
#nullable restore
#line 36 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
         foreach (var b in ViewBag.Books)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
       Write(Html.ActionLink((string)@b.Name, "Details", "Books", new { id = (int)@b.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                                          
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
     if (ViewBag.ANumber != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>????????????:</h2>\r\n");
#nullable restore
#line 44 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
         foreach (var a in ViewBag.Authors)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "284493a10484764694cce44f5a5eadd03ad326c614862", async() => {
#nullable restore
#line 46 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                             Write(a.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                                                          Write(a.LastName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                               WriteLiteral(a.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
     if (ViewBag.ANumber == 0 && ViewBag.BNumber == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"font-size: 16px\">???? ?????????? ?????????????? ???????????? ???? ????????????????</p>\r\n");
#nullable restore
#line 53 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<script>document.getElementById(\'querySearch\').value = ");
#nullable restore
#line 55 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Home\Search.cshtml"
                                                  Write(ViewBag.Query);

#line default
#line hidden
#nullable disable
            WriteLiteral(";</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
