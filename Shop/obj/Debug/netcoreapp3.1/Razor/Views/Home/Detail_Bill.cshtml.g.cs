#pragma checksum "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ce142c41b710faffa3e27cfa05110c05a18dce8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail_Bill), @"mvc.1.0.view", @"/Views/Home/Detail_Bill.cshtml")]
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
#nullable restore
#line 1 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
using Shop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce142c41b710faffa3e27cfa05110c05a18dce8", @"/Views/Home/Detail_Bill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Detail_Bill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetailbillViewmodel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
  
    ViewData["Title"] = "รายการบิล";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1>รายการบิล</h1>
</div>

<div class=""text-center"">
    <br>
    <br>
    <table border=""1"">
        <thead>
            <tr>

                <th rowspan=""2"" colspan=""3""> </th>
                <th>เลขบิล </th>
                <th>Bill-00");
#nullable restore
#line 21 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                       Write(Model.sumarybill.Bill_Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n            <tr>\r\n\r\n                <th>วันที่ </th>\r\n");
            WriteLiteral(@"            </tr>
            <tr>
                <th colspan=""5"">&nbsp;</th>
            </tr>

            <tr>
                <th> สินค้า </th>
                <th> จำนวน/หน่วย </th>
                <th> ราคา </th>
                <th> ส่วนลด </th>
                <th> ทั้งหมด </th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 42 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
              
                foreach (var data in Model.bill)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td> ");
#nullable restore
#line 46 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                        Write(data.NameProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 47 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                        Write(data.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 47 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                                      Write(data.NameUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 48 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                        Write(data.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 49 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                        Write(data.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 50 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                         Write(data.ProductPrice-@data.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 53 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th colspan=\"5\">&nbsp;</th>\r\n            </tr>\r\n            <tr>\r\n                <th rowspan=\"3\" colspan=\"3\"> </th>\r\n                <th>ราคารววมก่อนส่วนลด </th>\r\n                <th>");
#nullable restore
#line 61 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
               Write(Model.sumarybill.Price_Before);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n            <tr>\r\n\r\n                <th>ส่วนลดทั้งหมด </th>\r\n                <th>");
#nullable restore
#line 66 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
               Write(Model.sumarybill.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n            <tr>\r\n\r\n                <th>ราคารวมทั้งหมด </th>\r\n                <th>");
#nullable restore
#line 71 "D:\Shop\Shop\Views\Home\Detail_Bill.cshtml"
               Write(Model.sumarybill.Price_After);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
            </tr>

        </tbody>
    </table>
    <br>
    <center>
        <input type='button' value='กลับหน้ารายการ' id='myButton' onclick=""BlackToList()"" />
    </center>
    <br>
</div>
<style>
    table {
        width: 100%;
        height:50px;
    }
        table th {
            height: 50px;
        }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailbillViewmodel> Html { get; private set; }
    }
}
#pragma warning restore 1591
