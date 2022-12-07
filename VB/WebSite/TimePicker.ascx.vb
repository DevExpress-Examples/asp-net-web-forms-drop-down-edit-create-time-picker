Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class WebUserControl
	Inherits System.Web.UI.UserControl
	Private startTime_Renamed As Integer = 0
	Private endTime_Renamed As Integer = 23
	Private interval_Renamed As Integer = 60
	Private columnCount_Renamed As Integer = 3
	Private renderInRows_Renamed As Boolean = True

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Protected Sub ddeTimePicker_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim dropDown As ASPxDropDownEdit = TryCast(sender, ASPxDropDownEdit)

		If dropDown.ClientInstanceName = String.Empty Then
			dropDown.ClientInstanceName = dropDown.UniqueID
		End If
		dropDown.DropDownWindowTemplate = New TimePickerDropDownTemplate(StartTime, EndTime, Interval, ColumnCount, RenderInRows)
	End Sub

	Public Property Width() As Unit
		Get
			Return ddeTimePicker.Width
		End Get
		Set(ByVal value As Unit)
			ddeTimePicker.Width = value
		End Set
	End Property

	Public Property ShowPopupButton() As Boolean
		Get
			Return ddeTimePicker.DropDownButton.Visible
		End Get
		Set(ByVal value As Boolean)
			ddeTimePicker.DropDownButton.Visible = value
		End Set
	End Property

	Public Property ShowPopupOnFocus() As Boolean
		Get
			If (ddeTimePicker.JSProperties.ContainsKey("cpShowPopupOnFocus")) Then
				Return CBool(ddeTimePicker.JSProperties("cpShowPopupOnFocus"))
			Else
				Return False
			End If
		End Get
		Set(ByVal value As Boolean)
			ddeTimePicker.JSProperties("cpShowPopupOnFocus") = value
		End Set
	End Property

	Public Property StartTime() As Integer
		Get
			Return startTime_Renamed
		End Get
		Set(ByVal value As Integer)
			If value >= 0 AndAlso value < EndTime Then
				startTime_Renamed = value
			End If
		End Set
	End Property

	Public Property EndTime() As Integer
		Get
			Return endTime_Renamed
		End Get
		Set(ByVal value As Integer)
			If value > StartTime AndAlso value < 24 Then
				endTime_Renamed = value
			End If
		End Set
	End Property

	Public Property Interval() As Integer
		Get
			Return interval_Renamed
		End Get
		Set(ByVal value As Integer)
			If value > 0 AndAlso value <= 1440 Then
				interval_Renamed = value
			End If
		End Set
	End Property

	Public Property ToolTip() As String
		Get
			Return ddeTimePicker.DropDownButton.ToolTip
		End Get
		Set(ByVal value As String)
			ddeTimePicker.DropDownButton.ToolTip = value
		End Set
	End Property

	Private Property ColumnCount() As Integer
		Get
			Return columnCount_Renamed
		End Get
		Set(ByVal value As Integer)
			If value > 0 Then
			columnCount_Renamed = value
			End If
		End Set
	End Property

	Public Property RenderInRows() As Boolean
		Get
			Return renderInRows_Renamed
		End Get
		Set(ByVal value As Boolean)
			renderInRows_Renamed = value
		End Set
	End Property

	Public ReadOnly Property Text() As String
		Get
			Return ddeTimePicker.Text
		End Get
	End Property

	Public Property Time() As DateTime
		Get
			Return DateTime.Parse(ddeTimePicker.Text)
		End Get
		Set(ByVal value As DateTime)
			ddeTimePicker.Text = value.ToString("HH:mm")
		End Set
	End Property

	Public Property ClientInstanceName() As String
		Get
			Return ddeTimePicker.ClientInstanceName
		End Get
		Set(ByVal value As String)
			ddeTimePicker.ClientInstanceName = value
		End Set
	End Property
End Class