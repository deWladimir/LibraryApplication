#pragma checksum "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a3faa107a1ccaa88f2b5f66966f39a5eb5da46d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Import), @"mvc.1.0.view", @"/Views/Books/Import.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a3faa107a1ccaa88f2b5f66966f39a5eb5da46d", @"/Views/Books/Import.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26b1dd210bbfdcd5c1d9aa8f270204e21129424f", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Import : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GenreFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CountryFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
  
    ViewData["Title"] = "Import";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("FixedBar", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
     foreach (var g in DataForFixedBar.Genres)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a3faa107a1ccaa88f2b5f66966f39a5eb5da46d5147", async() => {
#nullable restore
#line 9 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
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
#line 9 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
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
#line 10 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <h2 style=\"margin: 0.15em 0 0.1em 0.1em; color: #343434; font-size: 20px; font-weight: normal; text-transform: uppercase; font-family: \'Orienta\', sans-serif; letter-spacing: 1px;\">Автори за країною</h2>\r\n");
#nullable restore
#line 12 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
     foreach (var c in DataForFixedBar.Countries)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a3faa107a1ccaa88f2b5f66966f39a5eb5da46d8783", async() => {
#nullable restore
#line 14 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
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
#line 14 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
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
#line 15 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
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
        background-color: #408fbd11;
        margin-top: 10px;
        padding: 20px;
    }

    li {
        list-style-type: none;
    }
</style>
<h1>Зміни були успішно внесені!</h1>
");
#nullable restore
#line 34 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
 if (ViewBag.MissingAuthors != null && ViewBag.MissingAuthors.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"layer1\">\r\n        <h2>Ви хотіли додати книжки автора, якого ще немає в базі даних. Спочатку додайте цих авторів.</h2>\r\n        <ul>\r\n");
#nullable restore
#line 39 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
             foreach (string author in ViewBag.MissingAuthors)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 41 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
               Write(author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 42 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 45 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
 if (ViewBag.UnvalidPath != null && ViewBag.UnvalidPath.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"layer2\">\r\n        <h2>Наступні книжки не були додані через некоректний шлях до файлу</h2>\r\n        <ul>\r\n");
#nullable restore
#line 51 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
             foreach (string book in ViewBag.UnvalidPath)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 53 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
               Write(book);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 54 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 57 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
 if (ViewBag.PagesChanged != null && ViewBag.PagesChanged.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"layer1\">\r\n        <h2>В наступних книжках була встановлена кількість сторінок за замовчуванням. Змініть її</h2>\r\n        <ul>\r\n");
#nullable restore
#line 63 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
             foreach (string book in ViewBag.PagesChanged)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 65 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
               Write(book);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 66 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 69 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
 if (ViewBag.Doubles != null && ViewBag.Doubles.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"layer2\">\r\n        <h2>Наступні книжки не були додані, бо вони, ймовірно, вже є</h2>\r\n        <h4>Одна з їх файлових адрес дублює вже існуючу або у вказаного автора вже є така книжка</h4>\r\n        <ul>\r\n");
#nullable restore
#line 76 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
             foreach (string book in ViewBag.Doubles)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 78 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
               Write(book);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 79 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 82 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
 if (ViewBag.NameProblem.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"layer2\">\r\n        <h2>");
#nullable restore
#line 86 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
       Write(ViewBag.NameProblem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        </div>\r\n");
#nullable restore
#line 88 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
#nullable restore
#line 89 "C:\Users\User\source\repos\LibraryApplication\LibraryApplication\Views\Books\Import.cshtml"
Write(Html.ActionLink("До списку книжок", "Index", "Books"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
