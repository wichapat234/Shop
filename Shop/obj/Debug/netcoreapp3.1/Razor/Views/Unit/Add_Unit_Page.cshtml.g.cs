#pragma checksum "D:\Shop\Shop\Views\Unit\Add_Unit_Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2e3d98dc7a5041c1a5d3c7df2a9e71a6eda4a38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Unit_Add_Unit_Page), @"mvc.1.0.view", @"/Views/Unit/Add_Unit_Page.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2e3d98dc7a5041c1a5d3c7df2a9e71a6eda4a38", @"/Views/Unit/Add_Unit_Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Unit_Add_Unit_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Shop\Shop\Views\Unit\Add_Unit_Page.cshtml"
  
    ViewData["Title"] = "เพิ่มหน่วยสินค้า";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 5 "D:\Shop\Shop\Views\Unit\Add_Unit_Page.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n<div class=\"text-center\">\r\n    <br><br>\r\n\r\n    <label>ชื่อหน่วย : </label>\r\n    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 218, "\"", 226, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""add_unit"">
    <input type='button' value='บันทึก' id='myButton' onclick=""Save()"" /><br>
    <span style=""color:red;"" id=""validate_add_unit""></span>

</div>
<script>
    function Save() {
        const name = document.getElementById('add_unit').value;
        namespace = name.trim();
        console.log(name)
        if (namespace.trim() == """") {
            $('#validate_add_unit').text('กรอกข้อความ')
            $('#add_unit').css(""border"", ""1px solid red"");
            console.log(""ไม่ผ่าน"")
        } else {         
            console.log(""ผ่าน"")
            const obj = { Name: name }
            axios({
                method: 'post',
                url: '/Unit/Insert_Unit',
                data: obj
            })
                .then(function (response) {
                    console.log(response);
                    if (response.data == ""seccess"") {
                        window.location = '/Unit/List_Unit';
                    }
                    else {
         ");
            WriteLiteral("               alert(\"หน่วยสินค้าซ้ำ\")\r\n                    }\r\n                })\r\n                .catch(function (error) {\r\n                    console.log(error);\r\n                });\r\n        }\r\n\r\n    }\r\n\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n");
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
