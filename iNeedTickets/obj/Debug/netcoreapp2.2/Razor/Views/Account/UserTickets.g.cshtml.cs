#pragma checksum "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d490472dc7e8241170b9791811b7408ff983eceb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_UserTickets), @"mvc.1.0.view", @"/Views/Account/UserTickets.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/UserTickets.cshtml", typeof(AspNetCore.Views_Account_UserTickets))]
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
#line 1 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\_ViewImports.cshtml"
using iNeedTickets;

#line default
#line hidden
#line 2 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\_ViewImports.cshtml"
using iNeedTickets.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d490472dc7e8241170b9791811b7408ff983eceb", @"/Views/Account/UserTickets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f60ed2231cd9183c3fcd360565fba6d163d9627b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserTickets : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<iNeedTickets.Models.Ticket>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/usertickets.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
  
    ViewData["Title"] = "UserTickets";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(144, 16, true);
            WriteLiteral("\r\n<html>\r\n\r\n    ");
            EndContext();
            BeginContext(160, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d490472dc7e8241170b9791811b7408ff983eceb5001", async() => {
                BeginContext(166, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(176, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d490472dc7e8241170b9791811b7408ff983eceb5391", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(246, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(259, 8, true);
            WriteLiteral("\r\n\r\n    ");
            EndContext();
            BeginContext(267, 1537, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d490472dc7e8241170b9791811b7408ff983eceb7619", async() => {
                BeginContext(273, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
#line 16 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
          
            var eventsList = new List<Event>();
            

#line default
#line hidden
#line 18 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
             foreach (var ticket in Model)
            {
                if (!eventsList.Contains(ticket.TicketArea.Event))
                {
                    eventsList.Add(ticket.TicketArea.Event);
                }
            }

#line default
#line hidden
#line 24 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
             

            eventsList.OrderBy(e => e.Date);
        

#line default
#line hidden
                BeginContext(639, 45, true);
                WriteLiteral("\r\n        <div id=\"purchased-tickets-page\">\r\n");
                EndContext();
#line 30 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
             if (Model.ToList().Count > 0)
            {

#line default
#line hidden
                BeginContext(743, 144, true);
                WriteLiteral("                <h4 class=\"main-text\">Your purchased tickets:</h4>\r\n                <div id=\"ticket-list-container\">\r\n                    <ul>\r\n");
                EndContext();
#line 35 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                         foreach(var e in eventsList)
                        {

#line default
#line hidden
                BeginContext(969, 66, true);
                WriteLiteral("                            <li>\r\n                                ");
                EndContext();
                BeginContext(1036, 6, false);
#line 38 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                           Write(e.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1042, 3, true);
                WriteLiteral(" - ");
                EndContext();
                BeginContext(1046, 6, false);
#line 38 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                     Write(e.Date);

#line default
#line hidden
                EndContext();
                BeginContext(1052, 3, true);
                WriteLiteral(" - ");
                EndContext();
                BeginContext(1056, 15, false);
#line 38 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                               Write(e.Location.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1071, 40, true);
                WriteLiteral("\r\n                                <ul>\r\n");
                EndContext();
#line 40 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                     foreach (var t in Model)
                                    {
                                        if(t.TicketArea.Event.Id == e.Id)
                                        {

#line default
#line hidden
                BeginContext(1331, 48, true);
                WriteLiteral("                                            <li>");
                EndContext();
                BeginContext(1380, 21, false);
#line 44 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                           Write(t.TicketArea.AreaName);

#line default
#line hidden
                EndContext();
                BeginContext(1401, 3, true);
                WriteLiteral(" - ");
                EndContext();
                BeginContext(1405, 18, false);
#line 44 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                                                    Write(t.TicketArea.Price);

#line default
#line hidden
                EndContext();
                BeginContext(1423, 11, true);
                WriteLiteral(" lei</li>\r\n");
                EndContext();
#line 45 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                                        }
                                    }

#line default
#line hidden
                BeginContext(1516, 50, true);
                WriteLiteral("                                    </ul>\r\n</li>\r\n");
                EndContext();
#line 49 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
                        }

#line default
#line hidden
                BeginContext(1593, 51, true);
                WriteLiteral("                    </ul>\r\n                </div>\r\n");
                EndContext();
#line 52 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
            }
            else
            {

#line default
#line hidden
                BeginContext(1692, 70, true);
                WriteLiteral("                <div>You don\'t have any purchased tickets yet!</div>\r\n");
                EndContext();
#line 56 "C:\Users\Mihail\Documents\Git Repos\iNeedTickets\iNeedTickets\Views\Account\UserTickets.cshtml"
            }

#line default
#line hidden
                BeginContext(1777, 20, true);
                WriteLiteral("        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1804, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<iNeedTickets.Models.Ticket>> Html { get; private set; }
    }
}
#pragma warning restore 1591
