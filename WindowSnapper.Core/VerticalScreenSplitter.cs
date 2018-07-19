using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowSnapper.Core
{
    public class VerticalScreenSplitter
    {
        private int _divBy;
        private List<(int Width, int Height)> _screens;


        public VerticalScreenSplitter(int splitCount, params (int Width, int Height)[] displayResolutions)
        {
            _divBy   = splitCount;
            _screens = displayResolutions.ToList();
        }


        public WindowProperties PostionAt(int positionKey, int displayIndex = 0)
        {
            positionKey   = Math.Min(positionKey, _divBy);
            var newWidth  = _screens[0].Width / _divBy;
            return new WindowProperties
            {
                Width  = newWidth,
                Height = _screens[0].Height,
                Top    = 0,
                Left   = newWidth * (positionKey - 1)
            };
        }
    }
}
