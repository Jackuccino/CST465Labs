#pragma checksum "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6422d07bda99c039add6356d3d9f9fc9b058c6a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HHEditorFor_Index), @"mvc.1.0.view", @"/Views/HHEditorFor/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/HHEditorFor/Index.cshtml", typeof(AspNetCore.Views_HHEditorFor_Index))]
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
#line 1 "E:\CST465 Web Dev\Lab 4\Views\_ViewImports.cshtml"
using Lab_4.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6422d07bda99c039add6356d3d9f9fc9b058c6a8", @"/Views/HHEditorFor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"548afca5e9120173fcbf17dfa4c4f2290a6655c9", @"/Views/_ViewImports.cshtml")]
    public class Views_HHEditorFor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ComputerModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(65, 26, true);
            WriteLiteral("\r\n<h2>HHEditorFor</h2>\r\n\r\n");
            EndContext();
#line 9 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{
    

#line default
#line hidden
            BeginContext(141, 23, false);
#line 11 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(168, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(207, 60, false);
#line 14 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.Name, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(267, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(278, 118, false);
#line 15 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.Name, new { htmlAttributes = new { @class = "form-control", placeholder = "Enter your name" } }));

#line default
#line hidden
            EndContext();
            BeginContext(396, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(407, 38, false);
#line 16 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.Name));

#line default
#line hidden
            EndContext();
            BeginContext(445, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(498, 64, false);
#line 19 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.Password, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(562, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(573, 140, false);
#line 20 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.Password, new { htmlAttributes = new { @class = "form-control", type = "password", placeholder = "Enter password" } }));

#line default
#line hidden
            EndContext();
            BeginContext(713, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(724, 42, false);
#line 21 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.Password));

#line default
#line hidden
            EndContext();
            BeginContext(766, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(819, 79, false);
#line 24 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.IPAddress, "IP Address", new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(898, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(909, 124, false);
#line 25 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.IPAddress, new { htmlAttributes = new { @class = "form-control", placeholder = "Enter IP address" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1044, 43, false);
#line 26 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.IPAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1140, 64, false);
#line 29 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.Location, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1215, 121, false);
#line 30 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.Location, new { htmlAttributes = new { @class = "form-control", placeholder = "Enter location" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1347, 42, false);
#line 31 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.Location));

#line default
#line hidden
            EndContext();
            BeginContext(1389, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1442, 58, false);
#line 34 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.OS, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1511, 85, false);
#line 35 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.OS, new { htmlAttributes = new { @class = "form-control",  } }));

#line default
#line hidden
            EndContext();
            BeginContext(1596, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1607, 36, false);
#line 36 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.OS));

#line default
#line hidden
            EndContext();
            BeginContext(1643, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1696, 67, false);
#line 39 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.Description, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1763, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1774, 139, false);
#line 40 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.Description, new { htmlAttributes = new { @class = "form-control", rows = "5", placeholder = "Enter description" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1924, 45, false);
#line 41 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1969, 52, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(2022, 73, false);
#line 44 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.LabelFor(m => m.SupportedMonitors, new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(2095, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(2106, 147, false);
#line 45 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.EditorFor(m => m.SupportedMonitors, new { htmlAttributes = new { @class = "form-control", type = "number", placeholder = "Enter a number" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2253, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(2264, 51, false);
#line 46 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
   Write(Html.ValidationMessageFor(m => m.SupportedMonitors));

#line default
#line hidden
            EndContext();
            BeginContext(2315, 81, true);
            WriteLiteral("\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n");
            EndContext();
#line 49 "E:\CST465 Web Dev\Lab 4\Views\HHEditorFor\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ComputerModel> Html { get; private set; }
    }
}
#pragma warning restore 1591