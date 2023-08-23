Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.Web
Imports System.Web.UI.WebControls

Public Class TimePickerDropDownTemplate
	Implements ITemplate

'INSTANT VB NOTE: The field startTime was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private startTime_Conflict As Integer
'INSTANT VB NOTE: The field endTime was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private endTime_Conflict As Integer
'INSTANT VB NOTE: The field interval was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private interval_Conflict As Integer
'INSTANT VB NOTE: The field columnCount was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private columnCount_Conflict As Integer
'INSTANT VB NOTE: The field rowCount was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private rowCount_Conflict As Integer
'INSTANT VB NOTE: The field cellCount was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private cellCount_Conflict As Integer
'INSTANT VB NOTE: The field renderInRows was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private renderInRows_Conflict As Boolean
'INSTANT VB NOTE: The field container was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private container_Conflict As Control

	Public Sub New(ByVal startTime As Integer, ByVal endTime As Integer, ByVal interval As Integer, ByVal columnCount As Integer, ByVal renderInRows As Boolean)
		Me.startTime_Conflict = startTime * 60
		Me.endTime_Conflict = endTime * 60
		Me.interval_Conflict = interval
		Me.columnCount_Conflict = columnCount
		Me.renderInRows_Conflict = renderInRows
		cellCount_Conflict = (endTime - startTime + 1) * 60 \ interval
		rowCount_Conflict = CInt(Math.Truncate(Math.Floor(CDbl(cellCount_Conflict) / columnCount)))
	End Sub

	Public ReadOnly Property StartTime() As Integer
		Get
			Return startTime_Conflict
		End Get
	End Property

	Public ReadOnly Property EndTime() As Integer
		Get
			Return endTime_Conflict
		End Get
	End Property

	Public ReadOnly Property Interval() As Integer
		Get
			Return interval_Conflict
		End Get
	End Property

	Public ReadOnly Property ColumnCount() As Integer
		Get
			Return columnCount_Conflict
		End Get
	End Property

	Public ReadOnly Property RowCount() As Integer
		Get
			Return rowCount_Conflict
		End Get
	End Property

	Public ReadOnly Property CellCount() As Integer
		Get
			Return cellCount_Conflict
		End Get
	End Property

	Public ReadOnly Property RenderInRows() As Boolean
		Get
			Return renderInRows_Conflict
		End Get
	End Property

	Public ReadOnly Property Container() As TemplateContainerBase
		Get
			Return TryCast(container_Conflict, TemplateContainerBase)
		End Get
	End Property

	Public Sub InstantiateIn(ByVal container As Control)
		Me.container_Conflict = container

		Dim mainTable As New Table()
		mainTable.ID = "mainTable"
		mainTable.Width = New Unit(100, UnitType.Percentage)

		For i As Integer = 0 To RowCount - 1
			Dim row As New TableRow()
			For j As Integer = 0 To ColumnCount - 1
				Dim cell As New TableCell()
				Dim cellControl As Control = CreateCellControl(i, j)
				If cellControl IsNot Nothing Then
					cell.Controls.Add(cellControl)
				End If
				row.Cells.Add(cell)
			Next j
			mainTable.Rows.Add(row)
		Next i

		container.Controls.Add(mainTable)
	End Sub

	Private Function CreateCellControl(ByVal row As Integer, ByVal column As Integer) As Control
		Dim cellIndex As Integer = If(RenderInRows, row * ColumnCount + column, column * RowCount + row)
		If row * ColumnCount + column < CellCount Then
			Dim parent As ASPxDropDownEdit = TryCast(Container.NamingContainer.NamingContainer, ASPxDropDownEdit)

			Dim button As New ASPxButton()
			button.ID = String.Format("btTime_{0}_{1}", row, column)

			Dim time As New DateTime(0)
			time = time.AddMinutes(StartTime + Interval * cellIndex)

			button.Text = time.ToString("HH:mm")
			button.Checked = (button.Text = parent.Text)
			button.Width = New Unit(100, UnitType.Percentage)
			button.AutoPostBack = False
			button.GroupName = parent.UniqueID
			button.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.SetText(s.GetText()); {0}.HideDropDown(); }}", parent.ClientInstanceName)

			Return button
		End If
		Return Nothing
	End Function
End Class