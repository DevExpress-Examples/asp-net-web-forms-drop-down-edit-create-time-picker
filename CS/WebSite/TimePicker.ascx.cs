using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class WebUserControl : System.Web.UI.UserControl {
    int startTime = 0;
    int endTime = 23;
    int interval = 60;
    int columnCount = 3;
    bool renderInRows = true;

    protected void Page_Init(object sender, EventArgs e) {
    }

    protected void ddeTimePicker_Init(object sender, EventArgs e) {
        ASPxDropDownEdit dropDown = sender as ASPxDropDownEdit;

        if (dropDown.ClientInstanceName == String.Empty)
            dropDown.ClientInstanceName = dropDown.UniqueID;
        dropDown.DropDownWindowTemplate = new TimePickerDropDownTemplate(StartTime, EndTime, Interval, ColumnCount, RenderInRows);
    }

    public Unit Width {
        get { return ddeTimePicker.Width; }
        set { ddeTimePicker.Width = value; }
    }

    public bool ShowPopupButton {
        get { return ddeTimePicker.DropDownButton.Visible; }
        set { ddeTimePicker.DropDownButton.Visible = value; }
    }

    public bool ShowPopupOnFocus {
        get { return (ddeTimePicker.JSProperties.ContainsKey("cpShowPopupOnFocus")) ? (bool)ddeTimePicker.JSProperties["cpShowPopupOnFocus"] : false; }
        set { ddeTimePicker.JSProperties["cpShowPopupOnFocus"] = value; }
    }

    public int StartTime {
        get { return startTime; }
        set {
            if (value >= 0 && value < EndTime)
                startTime = value;
        }
    }

    public int EndTime {
        get { return endTime; }
        set {
            if (value > StartTime && value < 24)
                endTime = value;
        }
    }

    public int Interval {
        get { return interval; }
        set {
            if (value > 0 && value <= 1440)
                interval = value;
        }
    }

    public string ToolTip {
        get { return ddeTimePicker.DropDownButton.ToolTip; }
        set { ddeTimePicker.DropDownButton.ToolTip = value; }
    }

    int ColumnCount {
        get { return columnCount; }
        set {
            if (value > 0 )
            columnCount = value;
        }
    }

    public bool RenderInRows {
        get { return renderInRows; }
        set { renderInRows = value; }
    }

    public string Text {
        get { return ddeTimePicker.Text; }
    }

    public DateTime Time {
        get { return DateTime.Parse(ddeTimePicker.Text); }
        set { ddeTimePicker.Text = value.ToString("HH:mm"); }
    }

    public string ClientInstanceName {
        get { return ddeTimePicker.ClientInstanceName; }
        set { ddeTimePicker.ClientInstanceName = value; }
    }
}