<!-- default file list -->
*Files to look at*:

* [TimePickerDropDownTemplate.cs](./CS/WebSite/App_Code/TimePickerDropDownTemplate.cs) (VB: [TimePickerDropDownTemplate.vb](./VB/WebSite/App_Code/TimePickerDropDownTemplate.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [TimePicker.ascx](./CS/WebSite/TimePicker.ascx) (VB: [TimePicker.ascx](./VB/WebSite/TimePicker.ascx))
* [TimePicker.ascx.cs](./CS/WebSite/TimePicker.ascx.cs) (VB: [TimePicker.ascx.vb](./VB/WebSite/TimePicker.ascx.vb))
<!-- default file list end -->
# How to create a TimePicker control using the ASPxDropDownEdit control
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3995/)**
<!-- run online end -->


<p>This example demonstrates how to create a TimePicker control using the ASPxDropDownEdit control.</p><br />
<p>Execute the following steps to create the TimePicker control:</p><p>- Put the <a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxDropDownEdittopic"><u>ASPxDropDownEdit</u></a> control on your web form or into a UserControl.</p><p>- Handle its <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxClassesScriptsASPxClientControl_Inittopic"><u>Init</u></a> event to specify its <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsASPxDropDownEdit_DropDownWindowTemplatetopic"><u>DropDownWindowTemplate</u></a>. This DropDownWindowTemplate should implement the <a href="http://msdn.microsoft.com/en-us/library/system.web.ui.itemplate.aspx"><u>ITemplate</u></a> interface. In this class, fill the ASPxDropDownEdit's popup window content with required controls.</p><p>- In your custom template class, use the <a href="http://msdn.microsoft.com/en-us/library/system.web.ui.itemplate.instantiatein.aspx"><u>InstantiateIn</u></a> method to create <a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxButtontopic"><u>ASPxButton</u></a> controls that will be used for time picking. Set their <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsASPxButton_AutoPostBacktopic"><u>ASPxButton.AutoPostBack</u></a> property to a false value to prevent them from sending postbacks while clicking. Handle their client-side Click events (by using the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsButtonClientSideEvents_Clicktopic"><u>ButtonClientSideEvents.Click property</u></a>) to set the required ASPxDropDownEdit text value on the client side by clicking a button. You can also use this event to close DropDownWindow.</p>

<br/>


