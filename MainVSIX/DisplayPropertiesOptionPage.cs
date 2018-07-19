using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using WindowSnapper.Core;

namespace MainVSIX
{
    public class DisplayPropertiesOptionPage : DialogPage
    {
        [Category("Environment Properties")]
        [DisplayName("Window Left Margin")]
        public int   WindowLeftMargin     { get; set; }

        [Category("Environment Properties")]
        [DisplayName("Window Top Margin")]
        public int WindowTopMargin { get; set; }

        [Category("Environment Properties")]
        [DisplayName("Window Right Margin")]   
        public int   WindowRightMargin  { get; set; }

        [Category("Environment Properties")]
        [DisplayName("Window Bottom Margin")]
        public int WindowBottomMargin { get; set; }

        [Category("Environment Properties")]
        [DisplayName("Taskbar Height")]   
        [Description("This setting assumes that Windows Taskbar is visible only on the primary display.")]
        public int   TaskbarHeight       { get; set; }


        [Category("Primary Display")]
        [DisplayName("Available Width")]
        public int? Display1AvailableWidth  { get; set; }

        [Category("Primary Display")]
        [DisplayName("Available Height")]
        public int? Display1AvailableHeight { get; set; }

        [Category("Primary Display")]
        [DisplayName("Absolute Left Position")]
        public int? Display1RelativeLeft    { get; set; }

        [Category("Primary Display")]
        [DisplayName("Absolute Top Position")]
        public int? Display1RelativeTop     { get; set; }

        [Category("Primary Display")]
        [DisplayName("Number of Columns")]
        public int? Display1ColumnCount     { get; set; }

        [Category("Primary Display")]
        [DisplayName("Number of Rows")]
        public int? Display1RowCount        { get; set; }



        [Category("Secondary Display")]
        [DisplayName("Available Width")]
        public int? Display2AvailableWidth  { get; set; }

        [Category("Secondary Display")]
        [DisplayName("Available Height")]
        public int? Display2AvailableHeight { get; set; }

        [Category("Secondary Display")]
        [DisplayName("Relative Left Position")]
        public int? Display2RelativeLeft    { get; set; }

        [Category("Secondary Display")]
        [DisplayName("Relative Top Position")]
        public int? Display2RelativeTop     { get; set; }

        [Category("Secondary Display")]
        [DisplayName("Number of Columns")]
        public int? Display2ColumnCount     { get; set; }

        [Category("Secondary Display")]
        [DisplayName("Number of Rows")]
        public int? Display2RowCount        { get; set; }


        public DisplayProperties GetDisplay1Propeties() => new DisplayProperties
        {
            AvailableWidth  = Display1AvailableWidth  ?? 0,
            AvailableHeight = Display1AvailableHeight ?? 0,
            RelativeLeft    = Display1RelativeLeft    ?? 0,
            RelativeTop     = Display1RelativeTop     ?? 0,
            ColumnCount     = Display1ColumnCount     ?? 0,
            RowCount        = Display1RowCount        ?? 0,
        };


        public DisplayProperties GetDisplay2Propeties() => new DisplayProperties
        {
            AvailableWidth  = Display2AvailableWidth  ?? 0,
            AvailableHeight = Display2AvailableHeight ?? 0,
            RelativeLeft    = Display2RelativeLeft    ?? 0,
            RelativeTop     = Display2RelativeTop     ?? 0,
            ColumnCount     = Display2ColumnCount     ?? 0,
            RowCount        = Display2RowCount        ?? 0,
        };
    }
}
