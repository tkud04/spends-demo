#pragma checksum "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f51f2bedfd13dea0e4aa98b2d8486543139d86b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Spends_Delete), @"mvc.1.0.view", @"/Views/Spends/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Spends/Delete.cshtml", typeof(AspNetCore.Views_Spends_Delete))]
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
#line 1 "c:\dotnet\SpendsDemo\Views\_ViewImports.cshtml"
using SpendsDemo;

#line default
#line hidden
#line 2 "c:\dotnet\SpendsDemo\Views\_ViewImports.cshtml"
using SpendsDemo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f51f2bedfd13dea0e4aa98b2d8486543139d86b", @"/Views/Spends/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbba085de7275fb399a8cfe281cf3ec7a903a350", @"/Views/_ViewImports.cshtml")]
    public class Views_Spends_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SpendsDemo.Models.Spends>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(77, 176, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Spends</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(254, 40, false);
#line 15 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(294, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(358, 36, false);
#line 18 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(394, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(457, 41, false);
#line 21 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Month));

#line default
#line hidden
            EndContext();
            BeginContext(498, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(562, 37, false);
#line 24 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Month));

#line default
#line hidden
            EndContext();
            BeginContext(599, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(662, 41, false);
#line 27 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Media));

#line default
#line hidden
            EndContext();
            BeginContext(703, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(767, 37, false);
#line 30 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Media));

#line default
#line hidden
            EndContext();
            BeginContext(804, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(867, 42, false);
#line 33 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Region));

#line default
#line hidden
            EndContext();
            BeginContext(909, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(973, 38, false);
#line 36 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Region));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1074, 43, false);
#line 39 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Quarter));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1181, 39, false);
#line 42 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Quarter));

#line default
#line hidden
            EndContext();
            BeginContext(1220, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1283, 44, false);
#line 45 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(1327, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1391, 40, false);
#line 48 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(1431, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1494, 46, false);
#line 51 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Advertizer));

#line default
#line hidden
            EndContext();
            BeginContext(1540, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1604, 42, false);
#line 54 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Advertizer));

#line default
#line hidden
            EndContext();
            BeginContext(1646, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1709, 41, false);
#line 57 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(1750, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1814, 37, false);
#line 60 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(1851, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1914, 43, false);
#line 63 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Station));

#line default
#line hidden
            EndContext();
            BeginContext(1957, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2021, 39, false);
#line 66 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Station));

#line default
#line hidden
            EndContext();
            BeginContext(2060, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2123, 43, false);
#line 69 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TVRadio));

#line default
#line hidden
            EndContext();
            BeginContext(2166, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2230, 39, false);
#line 72 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TVRadio));

#line default
#line hidden
            EndContext();
            BeginContext(2269, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2332, 40, false);
#line 75 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Days));

#line default
#line hidden
            EndContext();
            BeginContext(2372, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2436, 36, false);
#line 78 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Days));

#line default
#line hidden
            EndContext();
            BeginContext(2472, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2535, 44, false);
#line 81 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TimeBand));

#line default
#line hidden
            EndContext();
            BeginContext(2579, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2643, 40, false);
#line 84 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TimeBand));

#line default
#line hidden
            EndContext();
            BeginContext(2683, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2746, 44, false);
#line 87 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TimeSlot));

#line default
#line hidden
            EndContext();
            BeginContext(2790, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2854, 40, false);
#line 90 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TimeSlot));

#line default
#line hidden
            EndContext();
            BeginContext(2894, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2957, 41, false);
#line 93 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Print));

#line default
#line hidden
            EndContext();
            BeginContext(2998, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3062, 37, false);
#line 96 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Print));

#line default
#line hidden
            EndContext();
            BeginContext(3099, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3162, 51, false);
#line 99 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AverageDuration));

#line default
#line hidden
            EndContext();
            BeginContext(3213, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3277, 47, false);
#line 102 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AverageDuration));

#line default
#line hidden
            EndContext();
            BeginContext(3324, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3387, 42, false);
#line 105 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AdSize));

#line default
#line hidden
            EndContext();
            BeginContext(3429, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3493, 38, false);
#line 108 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AdSize));

#line default
#line hidden
            EndContext();
            BeginContext(3531, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3594, 46, false);
#line 111 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalSpend));

#line default
#line hidden
            EndContext();
            BeginContext(3640, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3704, 42, false);
#line 114 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalSpend));

#line default
#line hidden
            EndContext();
            BeginContext(3746, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3809, 45, false);
#line 117 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.dateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(3854, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3918, 41, false);
#line 120 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
       Write(Html.DisplayFor(model => model.dateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(3959, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(3997, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f51f2bedfd13dea0e4aa98b2d8486543139d86b18911", async() => {
                BeginContext(4023, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4033, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f51f2bedfd13dea0e4aa98b2d8486543139d86b19304", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 125 "c:\dotnet\SpendsDemo\Views\Spends\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4069, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(4152, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f51f2bedfd13dea0e4aa98b2d8486543139d86b21179", async() => {
                    BeginContext(4174, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4190, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4203, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SpendsDemo.Models.Spends> Html { get; private set; }
    }
}
#pragma warning restore 1591