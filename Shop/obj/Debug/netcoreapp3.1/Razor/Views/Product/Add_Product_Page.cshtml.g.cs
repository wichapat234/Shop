#pragma checksum "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "945990999974bb41cb90b00813b0f66db020d46e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Add_Product_Page), @"mvc.1.0.view", @"/Views/Product/Add_Product_Page.cshtml")]
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
#line 1 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
using Shop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945990999974bb41cb90b00813b0f66db020d46e", @"/Views/Product/Add_Product_Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Add_Product_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditProductViewmodel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
  
    ViewData["Title"] = "เพิ่มสินค้า";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 8 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n<div>\r\n    <br><br>\r\n    <table class=\"center\">\r\n        <tr>\r\n            <td>ชื่อสินค้า :</td>\r\n            <td><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 302, "\"", 310, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"add_product\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td><label>หน่วย : </label></td>\r\n\r\n            <td>\r\n                <select name=\"name_unit\" id=\"add_unit\">\r\n\r\n");
#nullable restore
#line 23 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
                      
                        foreach (var data in Model.unit)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945990999974bb41cb90b00813b0f66db020d46e4407", async() => {
#nullable restore
#line 26 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
                                                    Write(data.NameUnit);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
                               WriteLiteral(data.IdUnit);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 27 "D:\Shop\Shop\Views\Product\Add_Product_Page.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td><label>ราคา : </label></td>\r\n            <td><input type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 887, "\"", 895, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""add_price""></td>
        </tr>
    </table>
    <br>
    <center>
        <input type='button' value='บันทึก' id='myButton' onclick=""Save_Product()"" />
    </center>
    <br>

</div>
<script>
    function Save_Product() {
        let ProductName = document.getElementById('add_product').value;
        let ProductPrice = document.getElementById('add_price').value;
        let idUnit = document.getElementById('add_unit').value;
        let idunit = parseInt(idUnit)
        let price = parseFloat(ProductPrice)
        if (name.trim() == """" && ProductPrice.trim() == """") {
            $('#validate_add_unit').text('กรอกข้อความ')
            $('#add_unit').css(""border"", ""1px solid red"");
        } else {
            const obj = { ProductPrice: price, ProductName: ProductName, IdUnit: idunit }
            console.log(obj)
            axios({
                method: 'post',
                url: '/Product/Insert_Product',
                data: obj
            })
                .then(fun");
            WriteLiteral(@"ction (response) {
                    console.log(response);
                    if (response.data == ""seccess"") {
                        window.location = '/Home/List_Product';
                    }
                    else {
                        alert(""หน่วยสินค้าซ้ำ"")
                    }
                })
                .catch(function (error) {
                    console.log(error);
                });
        }

    }
</script>
<style>
    table {
        margin-left: auto;
        margin-right: auto;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditProductViewmodel> Html { get; private set; }
    }
}
#pragma warning restore 1591