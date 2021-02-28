#pragma checksum "C:\Users\10PRO64\source\repos\CRM\CRM\Views\Admin\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1853e0da25bb295b53fe14edb0a37e1d432c1bf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManageUsers), @"mvc.1.0.view", @"/Views/Admin/ManageUsers.cshtml")]
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
#line 1 "C:\Users\10PRO64\source\repos\CRM\CRM\Views\_ViewImports.cshtml"
using CRM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\10PRO64\source\repos\CRM\CRM\Views\_ViewImports.cshtml"
using CRM.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\10PRO64\source\repos\CRM\CRM\Views\Admin\ManageUsers.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\10PRO64\source\repos\CRM\CRM\Views\Admin\ManageUsers.cshtml"
using CRM.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1853e0da25bb295b53fe14edb0a37e1d432c1bf8", @"/Views/Admin/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03934a8a7d47f2a43fed5950159610447dac5492", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ManageUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\10PRO64\source\repos\CRM\CRM\Views\Admin\ManageUsers.cshtml"
  
    ViewData["Title"]="Manage Users";
    Layout="_CRMLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""accordion"" role=""tablist"" aria-multiselectable=""true"">
    <div class=""card"">
        <h5 class=""card-header text-uppercase"" role=""tab"" id=""headingOne"">
            <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne"" aria-expanded=""false"" aria-controls=""collapseOne"" class=""d-block"">
                <i class=""fas fa-chevron-down float-right""></i> All Users
            </a>
        </h5>

        <div id=""collapseOne"" class=""collapse show"" role=""tabpanel"" aria-labelledby=""headingOne"">
            <table class=""table table-hover"">
                <tbody>
                <tr>
                    <td>John</td>
                    <td>Doe</td>
                    <td>john@example.com</td>
                </tr>
                <tr>
                    <td>Mary</td>
                    <td>Moe</td>
                    <td>mary@example.com</td>
                </tr>
                <tr>
                    <td>July</td>
                    <td>Dooley</td>
         ");
            WriteLiteral(@"           <td>july@example.com</td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class=""card"">
        <h5 class=""card-header text-uppercase"" role=""tab"" id=""headingTwo"">
            <a class=""collapsed d-block"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseTwo"" aria-expanded=""false"" aria-controls=""collapseTwo"">
                <i class=""fas fa-chevron-down float-right""></i> Administrators
            </a>
        </h5>
        <div id=""collapseTwo"" class=""collapse"" role=""tabpanel"" aria-labelledby=""headingTwo"">
            <table class=""table table-hover"">
                <tbody>
                <tr>
                    <td>John</td>
                    <td>Doe</td>
                    <td>john@example.com</td>
                </tr>
                <tr>
                    <td>Mary</td>
                    <td>Moe</td>
                    <td>mary@example.com</td>
                </tr>
                <tr>
   ");
            WriteLiteral(@"                 <td>July</td>
                    <td>Dooley</td>
                    <td>july@example.com</td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class=""card"">
        <h5 class=""card-header text-uppercase"" role=""tab"" id=""headingThree"">
            <a class=""collapsed d-block"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseThree"" aria-expanded=""false"" aria-controls=""collapseThree"">
                <i class=""fas fa-chevron-down float-right""></i> Members
            </a>
        </h5>
        <div id=""collapseThree"" class=""collapse"" role=""tabpanel"" aria-labelledby=""headingThree"">
            <table class=""table table-hover"">
                <tbody>
                <tr>
                    <td>John</td>
                    <td>Doe</td>
                    <td>john@example.com</td>
                </tr>
                <tr>
                    <td>Mary</td>
                    <td>Moe</td>
              ");
            WriteLiteral(@"      <td>mary@example.com</td>
                </tr>
                <tr>
                    <td>July</td>
                    <td>Dooley</td>
                    <td>july@example.com</td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>




");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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
