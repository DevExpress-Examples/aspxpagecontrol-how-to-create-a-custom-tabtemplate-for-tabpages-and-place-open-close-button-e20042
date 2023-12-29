<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128555111/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E20042)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [TabTemplate.cs](./CS/WebSite/App_Code/TabTemplate.cs) (VB: [TabTemplate.vb](./VB/WebSite/App_Code/TabTemplate.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# ASPxPageControl: How to Create a Custom TabTemplate for TabPages and Place Open/Close Buttons inside the Template (TabPages are Recreated in Page_Load  only)


<p>This example shows how to create custom TabTemplates for ASPxPageControl TabPages. In this example, each TabControl has a “Close” button which closes the corresponding TabPage once clicked. The last tab page has an “Open New Tab” button instead of the “Close” button. Once this button is clicked, a new TabPage is added to the ASPxPageControl TabPages collection.</p><p>Since ASPxPageControl does not support Callback, it is placed inside an ASPxCallback panel. Every time a button is clicked the ASPxCallbackPanel callback event is raised to add/remove TabPages. </p><p>A sorted dictionary is used to keep track of existing TabPages. After each callback, TabPages are recreated in Page_Load event to ensure consistency. To make sure there is only one “Open New Tab” button, once a TabPage is added to the end of the collection, the TabTemplate of the previous TabPage with “Open New Tab” button is changed. </p><br />


<br/>


