#pragma checksum "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\Home\Numbers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93668b6089d1296cc439191e9ef75b51ba1f3a0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Numbers), @"mvc.1.0.view", @"/Views/Home/Numbers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Numbers.cshtml", typeof(AspNetCore.Views_Home_Numbers))]
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
#line 1 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\_ViewImports.cshtml"
using ViewModel_Fun;

#line default
#line hidden
#line 2 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\_ViewImports.cshtml"
using ViewModel_Fun.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93668b6089d1296cc439191e9ef75b51ba1f3a0e", @"/Views/Home/Numbers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d67dacb5d440fdfd5c9974c666c8e8de3a51591", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Numbers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\Home\Numbers.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(61, 64, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h4>Here are some numbers!</h4>\r\n");
            EndContext();
#line 9 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\Home\Numbers.cshtml"
     foreach (var num in Model)
    {

#line default
#line hidden
            BeginContext(165, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(177, 3, false);
#line 11 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\Home\Numbers.cshtml"
      Write(num);

#line default
#line hidden
            EndContext();
            BeginContext(180, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 12 "C:\Users\Micha\Desktop\C#_Stack\ASP_MVC2\ViewModel_Fun\Views\Home\Numbers.cshtml"
    }

#line default
#line hidden
            BeginContext(193, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
