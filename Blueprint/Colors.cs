using System.Drawing;

namespace Blueprint
{
    public class Colors
    {
        public class ColorPair
        {
            public Color Active { get; private set; }
            public Color Inactive { get; private set; }
            public Color Selected { get; private set; }
            public ColorPair(Color active, Color inactive, Color selected)
            {
                Active = active;
                Inactive = inactive;
                Selected = selected;
            }
        }

        public static Color Background = Color.RoyalBlue;
        public static Color Grid = Color.LightGray;
        public static Color GridMidLines = Color.White;

        public static Color ScientificText { get { return Color.White; } }

        public static Color Line2DIntersection { get { return Color.Navy; } }

        public static ColorPair Line2D = new ColorPair(Color.Orange, Color.Silver, Color.Red);
        public static ColorPair Vector2D = new ColorPair(Color.Yellow, Color.LightGray, Color.Red);
        public static ColorPair Triangle2D = new ColorPair(Color.OrangeRed, Color.LightGray, Color.Red);
        public static ColorPair Triangle2DFilled = new ColorPair(Color.CornflowerBlue, Color.LightSlateGray, Color.Red);
        public static ColorPair Circle2D = new ColorPair(Color.LightSalmon, Color.Silver, Color.Red);
        public static ColorPair Shape2D = new ColorPair(Color.DarkRed, Color.Silver, Color.Red);
    }
}
