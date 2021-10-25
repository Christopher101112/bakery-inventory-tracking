using System;
using Gtk;

namespace BakeryApplication
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class HomePage : Gtk.Bin
    {
        public bool activated = false;
        public static HomePage homepage_instance;

        public HomePage()
        {
            this.Build();
            homepage_instance = this;

            eventboxMain.ModifyBg(StateType.Normal, StyleGUI.background_color);
            this.labelHomePageTitle.ModifyFont(StyleGUI.title_font);

            StyleGUI.HomeButtonSetup(buttonCalculator);
            buttonCalculator.Child.ModifyFont(StyleGUI.xlarge_font);

            StyleGUI.HomeButtonSetup(buttonInventory);
            buttonInventory.Child.ModifyFont(StyleGUI.xlarge_font);
        }

        /**
         * This function is called when MainWindow's SetPage()
         * sets this page as the current page to display to user.
         */
        public void ActivatePage()
        {

        }

        /**
         * Called when MainWindow's SetPage() sets any other page to be displayed.
         */
        public void DeactivatePage()
        {

        }

        protected void OnButtonCalculatorClicked(object sender, EventArgs e)
        {
            MainWindow.SetPage(typeof(CalculatorPage));
        }

        protected void OnButtonInventoryClicked(object sender, EventArgs e)
        {
            MainWindow.SetPage(typeof(InventoryPage));
        }
    }
}
