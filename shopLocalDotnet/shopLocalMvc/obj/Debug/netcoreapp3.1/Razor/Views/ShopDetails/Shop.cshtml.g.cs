#pragma checksum "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7429fe997d7905689e60ebba373ece0783a3f9cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShopDetails_Shop), @"mvc.1.0.view", @"/Views/ShopDetails/Shop.cshtml")]
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
#line 1 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\_ViewImports.cshtml"
using shopLocalMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\_ViewImports.cshtml"
using shopLocalMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7429fe997d7905689e60ebba373ece0783a3f9cf", @"/Views/ShopDetails/Shop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43bd5468e9f1d9608a608220dfe944ea32c23306", @"/Views/_ViewImports.cshtml")]
    public class Views_ShopDetails_Shop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<shopLocalCommonModels.ShopModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
  
    ViewData["Title"] = "Shop Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Store Details</h1>\r\n<div class=\"jumbotron\">\r\n    <h2 class=\"display-4\">");
#nullable restore
#line 8 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
                     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <p class=\"lead\">");
#nullable restore
#line 9 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
               Write(Model.StreetAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 10 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
  Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 11 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
  Write(Model.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 12 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
  Write(Model.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 13 "C:\Users\Samuel Obembe\PROJECTS\ShopLocal\shopLocalDotnet\shopLocalMvc\Views\ShopDetails\Shop.cshtml"
  Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <a class=\"btn btn-primary btn-lg\" href=\"#\" role=\"button\">Edit</a>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<shopLocalCommonModels.ShopModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
