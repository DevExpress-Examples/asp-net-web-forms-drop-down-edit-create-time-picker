using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public class TimePickerDropDownTemplate : ITemplate {
    int startTime;
    int endTime;
    int interval;
    int columnCount;
    int rowCount;
    int cellCount;
    bool renderInRows;
    Control container;

    public TimePickerDropDownTemplate(int startTime, int endTime, int interval, int columnCount, bool renderInRows) {
        this.startTime = startTime * 60;
        this.endTime = endTime * 60;
        this.interval = interval;
        this.columnCount = columnCount;
        this.renderInRows = renderInRows;
        cellCount = (endTime - startTime + 1) * 60 / interval;
        rowCount = (int)Math.Floor((double)cellCount / columnCount);
    }

    public int StartTime {
        get { return startTime; }
    }

    public int EndTime {
        get { return endTime; }
    }

    public int Interval {
        get { return interval; }
    }

    public int ColumnCount {
        get { return columnCount; }
    }

    public int RowCount {
        get { return rowCount; }
    }

    public int CellCount {
        get { return cellCount; }
    }

    public bool RenderInRows {
        get { return renderInRows; }
    }

    public TemplateContainerBase Container {
        get { return container as TemplateContainerBase; }
    }

    public void InstantiateIn(Control container) {
        this.container = container;

        Table mainTable = new Table();
        mainTable.ID = "mainTable";
        mainTable.Width = new Unit(100, UnitType.Percentage);

        for (int i = 0; i < RowCount; i++) {
            TableRow row = new TableRow();
            for (int j = 0; j < ColumnCount; j++) {
                TableCell cell = new TableCell();
                Control cellControl = CreateCellControl(i, j);
                if (cellControl != null) {
                    cell.Controls.Add(cellControl);
                }
                row.Cells.Add(cell);
            }
            mainTable.Rows.Add(row);
        }

        container.Controls.Add(mainTable);
    }

    private Control CreateCellControl(int row, int column) {
        int cellIndex = (RenderInRows) ? row * ColumnCount + column : column * RowCount + row;
        if (row * ColumnCount + column < CellCount) {
            ASPxDropDownEdit parent = Container.NamingContainer.NamingContainer as ASPxDropDownEdit;

            ASPxButton button = new ASPxButton();
            button.ID = String.Format("btTime_{0}_{1}", row, column);

            DateTime time = new DateTime(0);
            time = time.AddMinutes(StartTime + Interval * cellIndex);

            button.Text = time.ToString("HH:mm");
            button.Checked = (button.Text == parent.Text);
            button.Width = new Unit(100, UnitType.Percentage);
            button.AutoPostBack = false;
            button.GroupName = parent.UniqueID;
            button.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.SetText(s.GetText()); {0}.HideDropDown(); }}", parent.ClientInstanceName);

            return button;
        }
        return null;
    }
}