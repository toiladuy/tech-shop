#pragma checksum "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b20ad3a89a79185394610c39d38d467ba4c7927a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderDetails_Index), @"mvc.1.0.view", @"/Views/OrderDetails/Index.cshtml")]
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
#line 1 "D:\C#\SHOP\SHOP\Shop\Views\_ViewImports.cshtml"
using Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\SHOP\SHOP\Shop\Views\_ViewImports.cshtml"
using Shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b20ad3a89a79185394610c39d38d467ba4c7927a", @"/Views/OrderDetails/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_OrderDetails_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shop.Models.OrderDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AddOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubQuantity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddQuantity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Voucher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" d-block d-md-flex"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Indexcheckout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sqr d-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <!-- breadcrumb area start -->
    <div class=""breadcrumb-area"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""breadcrumb-wrap"">
                        <nav aria-label=""breadcrumb"">
                            <ul class=""breadcrumb"">
                                <li class=""breadcrumb-item""><a href=""index.html""><i class=""fa fa-home""></i></a></li>
                                <li class=""breadcrumb-item""><a href=""shop.html"">shop</a></li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">cart</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- cart main wrapper start -->
    <div class=""cart-main-wrapper section-padding"">
        <div class=""container"">
            <div class=""section-bg-color"">
  ");
            WriteLiteral(@"              <div class=""row"">
                    <div class=""col-lg-12"">
                        <!-- Cart Table Area -->
                        <div class=""cart-table table-responsive"">
                            <table class=""table table-bordered"">
                                <thead>
                                    <tr>
                                        <th class=""pro-thumbnail"">Thumbnail</th>
                                        <th class=""pro-title"">Product</th>
                                        <th class=""pro-price"">Price</th>
                                        <th class=""pro-quantity"">Quantity</th>
                                        <th class=""pro-subtotal"">Total</th>
                                        <th class=""pro-remove"">Remove</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 47 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n");
#nullable restore
#line 50 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                              
                                                string[] arrListStr = item.Product.ProductImage.Split(' ');
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"pro-thumbnail\"><a href=\"#\"><img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 2506, "\"", 2557, 2);
            WriteAttributeValue("", 2512, "https://localhost:44347/images/", 2512, 31, true);
#nullable restore
#line 53 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
WriteAttributeValue("", 2543, arrListStr[0], 2543, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Product\" /></a></td>\r\n                                            <td class=\"pro-title\"><a href=\"#\">");
#nullable restore
#line 54 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                                                         Write(item.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                            <td class=\"pro-price\"><span><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 2790, "\"", 2809, 1);
#nullable restore
#line 55 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
WriteAttributeValue("", 2798, item.Price, 2798, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly id=\"price\" /></span></td>\r\n                                            <td class=\"pro-quantity\">\r\n                                                <div");
            BeginWriteAttribute("class", " class=\"", 2970, "\"", 2978, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                  \r\n                                                  \r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b20ad3a89a79185394610c39d38d467ba4c7927a10626", async() => {
                WriteLiteral("<h3>-</h3>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        <input type=\"text\" style=\"text-align:center\"");
            BeginWriteAttribute("value", " value=\"", 3336, "\"", 3358, 1);
#nullable restore
#line 61 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
WriteAttributeValue("", 3344, item.Quantity, 3344, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"60\" height=\"80\">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b20ad3a89a79185394610c39d38d467ba4c7927a13564", async() => {
                WriteLiteral("<h4>+</h4>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                   \r\n                                                    </div>\r\n                                                  \r\n                                            </td>\r\n");
#nullable restore
#line 67 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                              
                                                var pricetotla = item.Quantity * item.Price;
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"pro-subtotal\"><span>");
#nullable restore
#line 70 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                                                      Write(pricetotla);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                                            <td class=""pro-remove""><a data-toggle=""modal"" data-target=""#logoutModal""><i class=""fa fa-trash-o""></i></a></td>
                                        </tr>
                                        <div class=""modal fade"" id=""logoutModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
                                             aria-hidden=""true"">
                                            <div class=""modal-dialog"" role=""document"">
                                                <div class=""modal-content"">
                                                    <div class=""modal-header"">
                                                        <h5 class=""modal-title"" id=""exampleModalLabel"">Do you want to delete this item?</h5>
                                                        <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                                                            <span aria-hi");
            WriteLiteral(@"dden=""true"">×</span>
                                                        </button>
                                                    </div>
                                                    <div class=""modal-footer"">
                                                        <button class=""btn btn-secondary"" type=""button"" data-dismiss=""modal"">Cancel</button>
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 5479, "\"", 5511, 2);
            WriteAttributeValue("", 5486, "/AddOrder/Delete/", 5486, 17, true);
#nullable restore
#line 85 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
WriteAttributeValue("", 5503, item.Id, 5503, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 90 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                        <!-- Cart Update Option -->
                        <div class=""cart-update-option d-block d-md-flex justify-content-between"">
                            <div class=""apply-coupon-wrapper"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b20ad3a89a79185394610c39d38d467ba4c7927a19661", async() => {
                WriteLiteral(@"
                                    <input name=""vouchercode"" type=""text"" placeholder=""Enter Your Coupon Code"" required />
                                    <button type=""submit"" class=""btn btn-sqr"">Apply Coupon</button>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-5 ml-auto"">
                        <!-- Cart Calculation Area -->
                        <div class=""cart-calculator-wrapper"">
                            <div class=""cart-calculate-items"">
");
#nullable restore
#line 111 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                  
                                    double total = 0;
                                    double sale = 0;
                                    String vouchercode = "";
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 117 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                 foreach (var item in Model)
                                {
                                    total += Convert.ToDouble(item.Quantity * item.Price);
                                    IEnumerable<Voucher> voucher = ViewData["Voucher"] as IEnumerable<Voucher>;
                                    if (item.Order.Voucher != null)
                                    {
                                        foreach (Voucher voucher1 in voucher)
                                        {
                                            if (item.Order.VoucherId.Equals(voucher1.Id))
                                            {
                                                sale = Convert.ToDouble(voucher1.VoucherDiscount);
                                                vouchercode = voucher1.VoucherCode.ToString();
                                            }
                                        }
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h6>Cart Totals : ");
#nullable restore
#line 133 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                             Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                <div class=\"table-responsive\">\r\n                                    <table class=\"table\">\r\n                                        <tr>\r\n");
#nullable restore
#line 137 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                               var subtotal = total * sale / 100; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>Sub Total</td>\r\n                                            <td>$");
#nullable restore
#line 139 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                            Write(subtotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <td>Voucher Code</td>\r\n                                            <td>");
#nullable restore
#line 143 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                           Write(vouchercode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr class=\"total\">\r\n                                            <td>Total</td>\r\n");
#nullable restore
#line 147 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                              
                                                double finaltotal = total - subtotal;
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class=\"total-amount\">$");
#nullable restore
#line 150 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
                                                             Write(finaltotal.ToString("0.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                    </table>\r\n                                </div>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b20ad3a89a79185394610c39d38d467ba4c7927a26437", async() => {
                WriteLiteral("Proceed Checkout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- cart main wrapper end -->
</main>

<!-- Scroll to top start -->
<div class=""scroll-top not-visible"">
    <i class=""fa fa-angle-up""></i>
</div>
<!-- Scroll to Top End -->
<!-- footer area start -->
<!-- footer area end -->
<!-- Quick view modal start -->
<div class=""modal"" id=""quick_view"">
    <div class=""modal-dialog modal-lg modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <!-- product details inner end -->
                <div class=""product-details-inner"">
                    <div class=""row"">
                        <div class=""col-lg-5"">
                            <div class=""product-large-slider"">
                                <d");
            WriteLiteral(@"iv class=""pro-large-img img-zoom"">
                                    <img src=""https://localhost:44347/images/product-details-img1.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-large-img img-zoom"">
                                    <img src=""https://localhost:44347/images/product-details-img2.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-large-img img-zoom"">
                                    <img src=""https://localhost:44347/images/product-details-img3.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-large-img img-zoom"">
                                    <img src=""https://localhost:44347/images/product-details-img4.jpg"" alt=""product-details"" />
                                </div>
                            </div>
                            <div class=""pro-nav slick-row-10 slick");
            WriteLiteral(@"-arrow-style"">
                                <div class=""pro-nav-thumb"">
                                    <img src=""https://localhost:44347/images/product-details-img1.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-nav-thumb"">
                                    <img src=""https://localhost:44347/images/product-details-img2.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-nav-thumb"">
                                    <img src=""https://localhost:44347/images/product-details-img3.jpg"" alt=""product-details"" />
                                </div>
                                <div class=""pro-nav-thumb"">
                                    <img src=""https://localhost:44347/images/product-details-img4.jpg"" alt=""product-details"" />
                                </div>
                            </div>
                        </div>
                    ");
            WriteLiteral(@"    <div class=""col-lg-7"">
                            <div class=""product-details-des"">
                                <h3 class=""product-name"">Handmade Leather Bags Full Package</h3>
                                <div class=""ratings d-flex"">
                                    <span><i class=""fa fa-star-o""></i></span>
                                    <span><i class=""fa fa-star-o""></i></span>
                                    <span><i class=""fa fa-star-o""></i></span>
                                    <span><i class=""fa fa-star-o""></i></span>
                                    <span><i class=""fa fa-star-o""></i></span>
                                    <div class=""pro-review"">
                                        <span>1 Reviews</span>
                                    </div>
                                </div>
                                <div class=""price-box"">
                                    <span class=""price-regular"">$70.00</span>
                                ");
            WriteLiteral(@"    <span class=""price-old""><del>$90.00</del></span>
                                </div>
                                <div class=""availability"">
                                    <i class=""fa fa-check-circle""></i>
                                    <span>200 in stock</span>
                                </div>
                                <p class=""pro-desc"">
                                    Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy
                                    eirmod tempor invidunt ut labore et dolore magna aliquyam erat.
                                </p>
                                <div class=""quantity-cart-box d-flex align-items-center"">
                                    <h6 class=""option-title"">qty:</h6>
                                    <div class=""quantity"">
                                        <div class=""pro-qty""><input type=""text"" value=""1""></div>
                                    </div>
                           ");
            WriteLiteral(@"         <div class=""action_link"">
                                        <a class=""btn btn-cart2"" href=""#"">Add to Cart</a>
                                    </div>
                                </div>
                                <div class=""useful-links"">
                                    <a href=""#"" data-toggle=""tooltip"" title=""Compare"">
                                        <i class=""pe-7s-refresh-2""></i>compare
                                    </a>
                                    <a href=""#"" data-toggle=""tooltip"" title=""Wishlist"">
                                        <i class=""pe-7s-like""></i>wishlist
                                    </a>
                                </div>
                                <div class=""like-icon"">
                                    <a class=""facebook"" href=""#""><i class=""fa fa-facebook""></i>like</a>
                                    <a class=""twitter"" href=""#""><i class=""fa fa-twitter""></i>tweet</a>
                              ");
            WriteLiteral(@"      <a class=""pinterest"" href=""#""><i class=""fa fa-pinterest""></i>save</a>
                                    <a class=""google"" href=""#""><i class=""fa fa-google-plus""></i>share</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> <!-- product details inner end -->
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 270 "D:\C#\SHOP\SHOP\Shop\Views\OrderDetails\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shop.Models.OrderDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
