<%@ Control Language="vb" AutoEventWireup="true" CodeFile="TimePicker.ascx.vb" Inherits="WebUserControl" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>
<script type="text/javascript">
	function ddeTimePicker_GotFocus(s, e) {
		if (s.cpShowPopupOnFocus == true)
			s.ShowDropDown();
	}

	function ddeTimePicker_TextChanged(s, e) {
		var date = new Date("0/1/1 " + s.GetText());
		var text = "";
		if (s.GetText() != "" && date != null && date != "Invalid Date") {
			text = date.toTimeString().substr(0, 5);
		}
		s.SetText(text);
	}
</script>
<dx:ASPxDropDownEdit ID="ddeTimePicker" runat="server" 
	oninit="ddeTimePicker_Init">
	<DropDownButton>
		<Image Url="Images/clock.png">
		</Image>
	</DropDownButton>
	<ClientSideEvents GotFocus="ddeTimePicker_GotFocus" TextChanged="ddeTimePicker_TextChanged" />
</dx:ASPxDropDownEdit>