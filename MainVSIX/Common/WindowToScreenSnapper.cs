using WindowSnapper.Core;

namespace MainVSIX.Common
{
    public static class WindowToScreenSnapper
    {
        public const int TOP_BAR_HEIGHT = 55;
        public const int BOTTOM_BAR_HEIGHT = 7;

        public static void SnapToPosition(this EnvDTE.Window win,
            int positionKey, int displayIndex = 0)
        {
            var disp1  = Display.Define(1920, 1080, 0, 0, 5, 0);
            var disp2  = Display.Define(1920, 1080, 0, -1080, 5, 0);
            var splitr = new VerticalScreenSplitter(disp1, disp2);
            var props  = splitr.PostionAt(positionKey, displayIndex);

            win.IsFloating = true;
            win.Left       = props.Left;
            win.Top        = props.Top;
            win.Width      = props.Width;
            win.Height     = props.Height
                           - TOP_BAR_HEIGHT
                           - BOTTOM_BAR_HEIGHT;
        }
    }
}
