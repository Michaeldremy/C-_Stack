#pragma checksum "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "385d10ca295df334695055c89203074f89899a83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewOneWedding), @"mvc.1.0.view", @"/Views/Home/ViewOneWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewOneWedding.cshtml", typeof(AspNetCore.Views_Home_ViewOneWedding))]
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
#line 1 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner;

#line default
#line hidden
#line 2 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"385d10ca295df334695055c89203074f89899a83", @"/Views/Home/ViewOneWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b0732bfebbac067a62d1314c0d18406fc96ec4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewOneWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeddingWrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(70, 100, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row pt-3\">\r\n        <div class=\"col-8\">\r\n            <h1>");
            EndContext();
            BeginContext(171, 24, false);
#line 10 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
           Write(Model.Wedding.Wedder_One);

#line default
#line hidden
            EndContext();
            BeginContext(195, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(199, 24, false);
#line 10 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                                       Write(Model.Wedding.Wedder_Two);

#line default
#line hidden
            EndContext();
            BeginContext(223, 473, true);
            WriteLiteral(@"'s Wedding</h1>
        </div>
        <div class=""col-2 pt-2 text-center"">
            <a href=""/dashboard""><button type=""submit"" class=""btn btn-primary"">Dashboard</button></a>
        </div>
        <div class=""col-2 pt-2 text-center"">
            <a href=""""><button type=""submit"" class=""btn btn-primary"">Logout</button></a>
        </div>
    </div>
    <div class=""row pt-5 pl-5"">
        <div class=""col-6"">
            <h4>Date: <span style=""color: blue;"">");
            EndContext();
            BeginContext(697, 37, false);
#line 21 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                                            Write(Model.Wedding.Date.ToLongDateString());

#line default
#line hidden
            EndContext();
            BeginContext(734, 167, true);
            WriteLiteral("</span></h4>\r\n        <div class=\"col-12 pt-4\">\r\n            <h4>Guests:</h4>\r\n            <div class=\"col-12 pl-5 pt-4\">\r\n                <h4>Enter Guests here</h4>\r\n");
            EndContext();
#line 26 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                 foreach (var person in @Model.Wedding.AllUsers)
                {

#line default
#line hidden
            BeginContext(986, 46, true);
            WriteLiteral("                <ul>\r\n                    <li>");
            EndContext();
            BeginContext(1033, 21, false);
#line 29 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                   Write(person.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1054, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1056, 20, false);
#line 29 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                                          Write(person.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1076, 30, true);
            WriteLiteral("</li>\r\n                </ul>\r\n");
            EndContext();
#line 31 "C:\Users\Micha\Desktop\C#_Stack\Entity_Framework\Wedding_Planner\Views\Home\ViewOneWedding.cshtml"
                }

#line default
#line hidden
            BeginContext(1125, 347, true);
            WriteLiteral(@"            </div>
        </div>
        </div>
        <div class=""col-6"">
            <iframe width=""600"" height=""450"" frameborder=""0"" style=""border:0"" src=""https://www.google.com/maps/embed/v1/view?zoom=17&center=47.8410%2C-122.1102&key=AIzaSyAaY398y15b65z9lhVqyvzSWCSZiFP0Qco"" allowfullscreen></iframe>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeddingWrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
