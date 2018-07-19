using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowSnapper.Core
{
    public class VerticalScreenSplitter
    {
        private List<DisplayProperties> _screens;


        public VerticalScreenSplitter(params DisplayProperties[] displayProperties)
        {
            _screens = displayProperties.ToList();
        }


        public WindowProperties PostionAt(int positionKey, int displayIndex = 0)
        {
            if (displayIndex >= _screens.Count) return null;
            var screen = _screens[displayIndex];
            if (positionKey > screen.ColumnCount) return null;
            var divBy     = screen.ColumnCount;
            positionKey   = Math.Min(positionKey, divBy);
            var newWidth  = screen.AvailableWidth / divBy;

            return new WindowProperties
            {
                Width  = newWidth,
                Height = screen.AvailableHeight,
                Top    = screen.RelativeTop,
                Left   = screen.RelativeLeft 
                       + (newWidth * (positionKey - 1))
            };
        }
    }
}
