using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Enums
{

    [Flags]
   public enum Coordinates
    {
        None=0,
        Left=1,
        Top=2,
        Right=4,
        Bottom=8,
        Middle=16,

        LeftTop= Left & Top,
        RightTop = Right & Top,
        MiddleTop = Middle & Top,

        LeftBottom = Left & Bottom,
        RightBottom = Right & Bottom,
        MiddleBottom = Middle & Bottom

    }
}
