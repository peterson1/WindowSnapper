namespace WindowSnapper.Core
{
    public class DisplayProperties
    {
        public int  AvailableWidth   { get; set; }
        public int  AvailableHeight  { get; set; }
        public int  RelativeLeft     { get; set; }
        public int  RelativeTop      { get; set; }
        public int  ColumnCount      { get; set; }
        public int  RowCount         { get; set; }
    }


    public static class Display
    {
        public static DisplayProperties Define(int availableWidth ,
                                               int availableHeight,
                                               int relativeLeft   ,
                                               int relativeTop    ,
                                               int columnCount    ,
                                               int rowCount) => new DisplayProperties
            {
                AvailableWidth  = availableWidth ,
                AvailableHeight = availableHeight,
                RelativeLeft    = relativeLeft   ,
                RelativeTop     = relativeTop    ,
                ColumnCount     = columnCount    ,
                RowCount        = rowCount
            };
    }
}
