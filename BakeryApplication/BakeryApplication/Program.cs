using System;
using Gtk;

namespace BakeryApplication
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int width = 1024;
            int height = 768;
            StyleGUI.Setup(width, height);

            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
