Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.Web
Imports System.Web.UI.WebControls

Public Class TimePickerDropDownTemplate
	Implements ITemplate
	Private startTime_Renamed As Integer
	Private endTime_Renamed As Integer
	Private interval_Renamed As Integer
	Private columnCount_Renamed As Integer
	Private rowCount_Renamed As Integer
	Private cellCount_Renamed As Integer
	Private renderInRows_Renamed As Boolean
	Private container_Renamed As Control

	Public Sub New(ByVal startTime As Integer, ByVal endTime As Integer, ByVal interval As Integer, ByVal columnCount As Integer, ByVal renderInRows As Boolean)
		Me.startTime_Renamed = startTime * 60
		Me.endTime_Renamed = endTime * 60
		Me.interval_Renamed = interval
		Me.columnCount_Renamed = columnCount
		Me.renderInRows_Renamed = renderInRows
		cellCount_Renamed = (endTime - startTime + 1) * 60 \ interval
		rowCount_Renamed = CInt(Fix(Math.Floor(CDbl(cellCount_Renamed) / columnCount)))
	End Sub

	Public ReadOnly Property StartTime() As Integer
		Get
			Return startTime_Renamed
		End Get
	End Property

	Public ReadOnly Property EndTime() As Integer
		Get
			Return endTime_Renamed
		End Get
	End Property

	Public ReadOnly Property Interval() As Integer
		Get
			Return interval_Renamed
		End Get
	End Property

	Public ReadOnly Property ColumnCount() As Integer
		Get
			Return columnCount_Renamed
		End Get
	End Property

	Public ReadOnly Property RowCount() As Integer
		Get
			Return rowCount_Renamed
		End Get
	End Property

	Public ReadOnly Property CellCount() As Integer
		Get
			Return cellCount_Renamed
		End Get
	End Property

	Public ReadOnly Property RenderInRows() As Boolean
		Get
			Return renderInRows_Renamed
		End Get
	End Property

	Public ReadOnly Property Container() As TemplateContainerBase
		Get
			Return TryCast(container_Renamed, TemplateContainerBase)
		End Get
	End Property

	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Me.container_Renamed = container

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
		Dim cellIndex As Integer
		If (RenderInRows) Then
			cellIndex = row * ColumnCount + column
		Else
			cellIndex = column * RowCount + row
		End If
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