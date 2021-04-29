#pragma checksum "D:\Shop\Shop\Views\Home\List_Bill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09a0a2e5456f13de86ced9344602a0f4f76df195"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_List_Bill), @"mvc.1.0.view", @"/Views/Home/List_Bill.cshtml")]
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
#line 1 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
using Shop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09a0a2e5456f13de86ced9344602a0f4f76df195", @"/Views/Home/List_Bill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_List_Bill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<billViewmodel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
  
    ViewData["Title"] = "รายการบิล";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1>รายการบิล</h1>
</div>

<div class=""text-center"">
    <label>วันที่ :</label>&nbsp;<input type=""date"">&nbsp;
    <label>หมายเลขบิล :</label>&nbsp;<input type=""text"">&nbsp;
    <input type='button' value='ค้นหา' id='myButton' onClick='Add_Bill()' />&nbsp;
    <input type='button' value='เพิ่มบิล' id='myButton' onClick='Add_Bill()' />
    <br>
    <br>
    <table border=""1"">
        <thead>
            <tr>
                <th> วันที่ </th>
                <th> หมายเลขบิล </th>
                <th> ราคาทั้งหมดก่อนลดราคา </th>
                <th> ลดราคาทั้งหมด </th>
                <th> ราคาทั้งหมดหลังลดราคา </th>
                <th> รายละเอียด </th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 32 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
               foreach (var data in Model.bill)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 35 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                       Write(data.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                       Write(data.IdBill);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                       Write(data.PriceAfter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                       Write(data.TotalDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 39 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                       Write(data.PriceBefore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> <input type=\"button\" name=\"detail\"");
            BeginWriteAttribute("onClick", " onClick=\'", 1291, "\'", 1326, 3);
            WriteAttributeValue("", 1301, "Detail_Bill(", 1301, 12, true);
#nullable restore
#line 40 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
WriteAttributeValue("", 1313, data.IdBill, 1313, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1325, ")", 1325, 1, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"รายละเอียด\"></td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "D:\Shop\Shop\Views\Home\List_Bill.cshtml"
                }

            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<style>\r\n    table {\r\n        width: 100%;\r\n        margin-left: auto;\r\n        margin-right: auto;\r\n        height: 50px;\r\n    }\r\n\r\n        table th {\r\n            height: 50px;\r\n        }\r\n</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<billViewmodel> Html { get; private set; }
    }
}
#pragma warning restore 1591
