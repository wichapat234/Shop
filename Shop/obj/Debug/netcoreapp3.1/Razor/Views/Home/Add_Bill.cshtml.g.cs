#pragma checksum "D:\Shop\Shop\Views\Home\Add_Bill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3cd8dec5bac9fe1151ef33d4eaa46ec85ee3200"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Add_Bill), @"mvc.1.0.view", @"/Views/Home/Add_Bill.cshtml")]
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
#line 1 "D:\Shop\Shop\Views\_ViewImports.cshtml"
using Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3cd8dec5bac9fe1151ef33d4eaa46ec85ee3200", @"/Views/Home/Add_Bill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Add_Bill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Shop\Shop\Views\Home\Add_Bill.cshtml"
  
    ViewData["Title"] = "เพิ่มบิล";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 5 "D:\Shop\Shop\Views\Home\Add_Bill.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
</div>
<div class=""text-center"">
    <input type='button' value='เพิ่มรายการ' id='add_bill' />
    <table border=""1"" class=""center"">
        <thead>
            <tr>
                <th> ชื่อสินค้า </th>
                <th> หน่วย </th>
                <th> ราคา/หน่วย </th>
                <th> จำนวน </th>
                <th> ราคารวม </th>
                <th> ส่วนลด </th>
                <th> ราคารวมหลังส่วนลด </th>
            </tr>
        </thead>
        <tbody id=""table_add_bill"">
");
            WriteLiteral(@"
        </tbody>
    </table>


</div>
<style>
    table {
        width: 100%;
        height: 50px;
    }

        table th {
            height: 50px;
        }

        table td {
            height: 40px;
        }
</style>





");
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