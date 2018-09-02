using WindowSnapper.Core;

namespace MainVSIX.Common
{
    public static class WindowToScreenSnapper
    {
        //public const int TOP_BAR_HEIGHT = 55;
        //public const int BOTTOM_BAR_HEIGHT = 7;

        public static bool SnapToPosition(this EnvDTE.Window win,
            int positionKey, int displayIndex, DisplayPropertiesOptionPage opt)
        {
            var disp1  = opt.GetDisplay1Propeties();
            var disp2  = opt.GetDisplay2Propeties();
            var splitr = new VerticalScreenSplitter(disp1, disp2);
            var props  = splitr.PostionAt(positionKey, displayIndex);
            if (props == null) return false;

            try
            {
                win.IsFloating = true;
            }
            catch { }
            win.Left       = props.Left;
            win.Top        = props.Top;
            win.Width      = props.Width - opt.WindowLeftMargin 
                                         - opt.WindowRightMargin;

            win.Height     = props.Height - opt.WindowTopMargin 
                                          - opt.WindowBottomMargin
                                          - (displayIndex == 0 ? opt.TaskbarHeight : 0);
            return true;
        }
    }
}
