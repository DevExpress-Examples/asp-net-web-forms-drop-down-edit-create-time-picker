Imports System
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class WebUserControl
	Inherits System.Web.UI.UserControl

'INSTANT VB NOTE: The field startTime was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private startTime_Conflict As Integer = 0
'INSTANT VB NOTE: The field endTime was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private endTime_Conflict As Integer = 23
'INSTANT VB NOTE: The field interval was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private interval_Conflict As Integer = 60
'INSTANT VB NOTE: The field columnCount was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private columnCount_Conflict As Integer = 3
'INSTANT VB NOTE: The field renderInRows was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private renderInRows_Conflict As Boolean = True

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
			Return If(ddeTimePicker.JSProperties.ContainsKey("cpShowPopupOnFocus"), CBool(ddeTimePicker.JSProperties("cpShowPopupOnFocus")), False)
		End Get
		Set(ByVal value As Boolean)
			ddeTimePicker.JSProperties("cpShowPopupOnFocus") = value
		End Set
	End Property

	Public Property StartTime() As Integer
		Get
			Return startTime_Conflict
		End Get
		Set(ByVal value As Integer)
			If value >= 0 AndAlso value < EndTime Then
				startTime_Conflict = value
			End If
		End Set
	End Property

	Public Property EndTime() As Integer
		Get
			Return endTime_Conflict
		End Get
		Set(ByVal value As Integer)
			If value > StartTime AndAlso value < 24 Then
				endTime_Conflict = value
			End If
		End Set
	End Property

	Public Property Interval() As Integer
		Get
			Return interval_Conflict
		End Get
		Set(ByVal value As Integer)
			If value > 0 AndAlso value <= 1440 Then
				interval_Conflict = value
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
			Return columnCount_Conflict
		End Get
		Set(ByVal value As Integer)
			If value > 0 Then
			columnCount_Conflict = value
			End If
		End Set
	End Property

	Public Property RenderInRows() As Boolean
		Get
			Return renderInRows_Conflict
		End Get
		Set(ByVal value As Boolean)
			renderInRows_Conflict = value
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