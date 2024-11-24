using UnityEngine;

namespace Shadow_Racing.Scripts
{
    // Набор констант.
    public static class ColorConstants
    {
        public static readonly Color RED_COLOR_LINE = new(0.82f, 0.19f, 0.20f, 0.24f); 
        public static readonly Color GREEN_COLOR_LINE = new(0.31f, 0.93f, 0.33f, 0.24f);
        public static readonly Color WHITE_COLOR_LINE = new Color(1f, 1f, 1f, 0.24f); 
        
        public static readonly Color RED_COLOR_TEXT = new(0.82f, 0.19f, 0.20f, 1f); 
        public static readonly Color GREEN_COLOR_TEXT = new(0.31f, 0.93f, 0.33f, 1f); 
        public static readonly Color WHITE_COLOR_TEXT = new Color(1f, 1f, 1f, 1f);
    }
}