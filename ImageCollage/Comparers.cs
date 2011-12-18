using System.Collections;
using System.Drawing;

namespace ImageCollage
{
    public class HeightComparer : IComparer
    {
        // Return -1, 0, or 1 to indicate whether
        // x belongs before, the same as, or after y.
        // Sort by height, width descending.
        public int Compare(object x, object y)
        {
            ImgRectangle xrect = (ImgRectangle)x;
            ImgRectangle yrect = (ImgRectangle)y;
            if (xrect.Height < yrect.Height) return 1;
            if (xrect.Height > yrect.Height) return -1;
            if (xrect.Width < yrect.Width) return 1;
            if (xrect.Width > yrect.Width) return -1;
            return 0;
        }
    }

}