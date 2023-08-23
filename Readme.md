<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128531404/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3995)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Drop Down Edit for ASP.NET Web Forms - How to create a time picker control
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3995/)**
<!-- run online end -->

This example demonstrates how to create a TimePicker control based on the [ASPxDropDownEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDropDownEdit) control.

## Overview

Follow the steps below to create a time picker:

1. Put the [ASPxDropDownEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDropDownEdit) control to your web form or into a UserControl.
2. Handle the control's `Init` event to specify the [DropDownWindowTemplate](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDropDownEdit.DropDownWindowTemplate). This template should implement the [ITemplate](https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.itemplate?view=netframework-4.8.1&redirectedfrom=MSDN) interface. In this class, populate the control's popup window content with controls.
3. In your custom template class, call the [InstantiateIn](http://msdn.microsoft.com/en-us/library/system.web.ui.itemplate.instantiatein.aspx) method to create [buttons](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxButton) that are used for time picking. Set their [AutoPostBack](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxButton.AutoPostBack) properties to `false` to prevent them from sending postbacks while clicking. Handle a button's client-side `Click` event to set the `ASPxDropDownEdit` control text value on the client side on a button click. You can also use this event to close DropDownWindow.

## Files to Review

* [TimePickerDropDownTemplate.cs](./CS/WebSite/App_Code/TimePickerDropDownTemplate.cs) (VB: [TimePickerDropDownTemplate.vb](./VB/WebSite/App_Code/TimePickerDropDownTemplate.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [TimePicker.ascx](./CS/WebSite/TimePicker.ascx) (VB: [TimePicker.ascx](./VB/WebSite/TimePicker.ascx))
* [TimePicker.ascx.cs](./CS/WebSite/TimePicker.ascx.cs) (VB: [TimePicker.ascx.vb](./VB/WebSite/TimePicker.ascx.vb))
