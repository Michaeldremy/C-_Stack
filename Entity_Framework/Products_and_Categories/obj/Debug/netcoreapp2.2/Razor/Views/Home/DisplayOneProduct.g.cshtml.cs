#pragma checksum "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d36d8a571365b5f4695b437e970632e39d8d89a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayOneProduct), @"mvc.1.0.view", @"/Views/Home/DisplayOneProduct.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/DisplayOneProduct.cshtml", typeof(AspNetCore.Views_Home_DisplayOneProduct))]
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
#line 1 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\_ViewImports.cshtml"
using Products_and_Categories;

#line default
#line hidden
#line 2 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\_ViewImports.cshtml"
using Products_and_Categories.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d36d8a571365b5f4695b437e970632e39d8d89a", @"/Views/Home/DisplayOneProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bd6de6e6a9ac2d243eee5113369f84e5ce262d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayOneProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProdCatWrapper>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("custom-select form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateProdAssociation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(70, 133, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 pt-5 text-center\">\r\n            <h2 style=\"color: red;\">");
            EndContext();
            BeginContext(204, 18, false);
#line 10 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                               Write(Model.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(222, 126, true);
            WriteLiteral("</h2>\r\n        </div>\r\n    </div>\r\n    <div class=\"row pt-5\">\r\n        <div class=\"col-9\">\r\n            <h3>Categories:</h3>\r\n");
            EndContext();
#line 17 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
             foreach (var p in @Model.Product.CategoryAssociation)
            {

#line default
#line hidden
            BeginContext(479, 38, true);
            WriteLiteral("            <ul>\r\n                <li>");
            EndContext();
            BeginContext(518, 15, false);
#line 20 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
               Write(p.Category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(533, 26, true);
            WriteLiteral("</li>\r\n            </ul>\r\n");
            EndContext();
#line 22 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
            }

#line default
#line hidden
            BeginContext(574, 105, true);
            WriteLiteral("        </div>\r\n        <div class=\"col-3 text-center\">\r\n            <h5>Add Category:</h5>\r\n            ");
            EndContext();
            BeginContext(679, 671, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d36d8a571365b5f4695b437e970632e39d8d89a7150", async() => {
                BeginContext(803, 62, true);
                WriteLiteral("\r\n                <div class=\"col pt-3\">\r\n                    ");
                EndContext();
                BeginContext(865, 296, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d36d8a571365b5f4695b437e970632e39d8d89a7597", async() => {
                    BeginContext(941, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 29 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                         foreach (var c in @Model.Categories)
                        {

#line default
#line hidden
                    BeginContext(1033, 24, true);
                    WriteLiteral("                        ");
                    EndContext();
                    BeginContext(1057, 46, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d36d8a571365b5f4695b437e970632e39d8d89a8392", async() => {
                        BeginContext(1088, 6, false);
#line 31 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                                                 Write(c.Name);

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 31 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                           WriteLiteral(c.CategoryId);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1103, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 32 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                        }

#line default
#line hidden
                    BeginContext(1132, 20, true);
                    WriteLiteral("                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 28 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Association.CategoryId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1161, 182, true);
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col pt-3\">\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Add</button>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 26 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Products_and_Categories\Views\Home\DisplayOneProduct.cshtml"
                                                                                                  WriteLiteral(Model.Product.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1350, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProdCatWrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
