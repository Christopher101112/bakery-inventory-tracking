using System;
using Gtk;
using Gdk;
using Pango;

namespace BakeryApplication
{
    public static class StyleGUI
    {
        static int window_width;
        static int window_height;

        public static Gdk.Color background_color = new Gdk.Color(82, 181, 234); //Blue.
        public static Gdk.Color light_grey = new Gdk.Color(210, 210, 210); //Light grey.
        public static Gdk.Color dark_grey = new Gdk.Color(82, 82, 82); //Dark grey.
        public static Gdk.Color warning_red = new Gdk.Color(242, 125, 125); //Red
        public static Gdk.Color default_white = new Gdk.Color(242, 241, 240); //White cream (Default GDK# widget color)
        public static Gdk.Color success_green = new Gdk.Color(41, 236, 123); //Green.

        public static FontDescription title_font = FontDescription.FromString("Arial Demi-bold 50");

        public static FontDescription xlarge_font = FontDescription.FromString("Arial 36");
        public static FontDescription xlarge_font_italic = FontDescription.FromString("Arial Italic 36");
        public static FontDescription xlarge_font_bold = FontDescription.FromString("Arial Demi-bold 36");


        public static FontDescription large_font = FontDescription.FromString("Avenir Next 27");
        public static FontDescription large_font_italic = FontDescription.FromString("Avenir Next Italic 27");

        public static FontDescription medium_font = FontDescription.FromString("Avenir Next 18");
        public static FontDescription medium_font_italic = FontDescription.FromString("Avenir Next Italic 18");


        public static void Setup(int width, int height)
        {
            window_height = height;
            window_width = width;
        }

        public static int GetWidth()
        {
            return window_width;
        }

        public static int GetHeight()
        {
            return window_height;
        }

        public static void ButtonSetup(Button button)
        {
            button.WidthRequest = 120;
            button.HeightRequest = 80;
        }

        //Width fills to screen size. Height should be set based on monitor.
        public static void HomeButtonSetup(Button button)
        {
            button.WidthRequest = 120;
            button.HeightRequest = 200;
        }
    }
}
