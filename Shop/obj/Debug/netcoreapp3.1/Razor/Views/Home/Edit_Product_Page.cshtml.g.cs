#pragma checksum "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e69c5306ce6cb61d70ce75ce893905db343a647"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Edit_Product_Page), @"mvc.1.0.view", @"/Views/Home/Edit_Product_Page.cshtml")]
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
#line 1 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
using Shop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e69c5306ce6cb61d70ce75ce893905db343a647", @"/Views/Home/Edit_Product_Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Edit_Product_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditProductViewmodel>
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
#nullable restore
#line 3 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
  
    ViewData["Title"] = "แก้ไขสินค้า";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 7 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n<div>\r\n<br><br>\r\n    <table class=\"center\">\r\n        <tr>\r\n            <td>ชื่อสินค้า :</td>\r\n            <td>\r\n                <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 314, "\"", 340, 1);
#nullable restore
#line 15 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
WriteAttributeValue("", 322, Model.NameProduct, 322, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""edit_product"">
                <span style=""color:red;"" id=""validate_edit_nameproduct""></span>
            </td>
        </tr>
        <tr>
            <td><label>หน่วย : </label></td>

            <td>
                <select name=""name_unit"" id=""edit_unit"">

");
#nullable restore
#line 25 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                     foreach (var data in Model.unit)
                    {
                        if (Model.IdUnit == data.IdUnit)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e69c5306ce6cb61d70ce75ce893905db343a6474706", async() => {
                WriteLiteral(" ");
#nullable restore
#line 29 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                                                              Write(data.NameUnit);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                               WriteLiteral(data.IdUnit);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 30 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"

                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e69c5306ce6cb61d70ce75ce893905db343a6477127", async() => {
                WriteLiteral(" ");
#nullable restore
#line 34 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                                                     Write(data.NameUnit);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
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
#line 35 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                        }

                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
                                                                            
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </select>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td><label>ราคา : </label></td>\r\n\r\n            <td>\r\n                <input type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 1351, "\"", 1378, 1);
#nullable restore
#line 47 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
WriteAttributeValue("", 1359, Model.ProductPrice, 1359, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"edit_price\">\r\n                <span style=\"color:red;\" id=\"validate_edit_price\"></span>\r\n            </td>\r\n\r\n        </tr>\r\n    </table>\r\n    <br>\r\n    <center>\r\n        <input type=\'button\' value=\'บันทึก\' id=\'myButton\'");
            BeginWriteAttribute("onclick", " onclick=\"", 1604, "\"", 1647, 3);
            WriteAttributeValue("", 1614, "Update_Product(", 1614, 15, true);
#nullable restore
#line 55 "D:\Shop\Shop\Views\Home\Edit_Product_Page.cshtml"
WriteAttributeValue("", 1629, Model.Product_Id, 1629, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1646, ")", 1646, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </center>\r\n    <br>\r\n\r\n</div>\r\n<style>\r\n    table {\r\n        margin-left: auto;\r\n        margin-right: auto;\r\n    }\r\n</style>\r\n\r\n\r\n\r\n\r\n\r\n");
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
