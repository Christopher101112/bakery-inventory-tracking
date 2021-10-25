using System;
using System.Threading;
using BakeryApplication;
using Gtk;
using System.Collections.Generic;


public partial class MainWindow : Gtk.Window
{
    static MainWindow mainwindow_instance;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        mainwindow_instance = this;

        Build();

        //Display updated date and time throughout application.
        labelDatetime.ModifyFont(StyleGUI.medium_font);
        Timer timer = new Timer(TimerCallback, null, 0, 10000);

        eventboxMain.ModifyBg(StateType.Normal, StyleGUI.dark_grey);
        eventboxLabels.ModifyBg(StateType.Normal, StyleGUI.dark_grey);
        
        this.WidthRequest = StyleGUI.GetWidth();
        this.DefaultWidth = StyleGUI.GetWidth();
        this.HeightRequest = StyleGUI.GetHeight();
        this.DefaultHeight = StyleGUI.GetHeight();
    }

    private void TimerCallback(object o)
    {
        labelDatetime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    /**
     * Set the notebook page to be displayed to user.
     */
    public static void SetPage(Type page)
    {
        //Look through all notebook pages.
        for(int i=0; i< mainwindow_instance.notebookPages.NPages; i++)
        {
            Widget nth_page = mainwindow_instance.notebookPages.GetNthPage(i);

            //If requested page found, display it as the current page.
            if(nth_page.GetType() == page)
            {
                /**
                 * Regarding the code below: 
                 * Better method, esp if number of pages grow, would be to have interface type "Page".
                 * That way, we could have a collection of type "Page", and iterate through it.
                 * However, the pages were auto-generated as widgets by Gtk#, which causes problems with inheritance.
                 * @TODO Implement inheritance as described.
                 */
                if(page == typeof(InventoryPage))
                {
                    InventoryPage.inventorypage_instance.ActivatePage();
                    HomePage.homepage_instance.DeactivatePage();
                    CalculatorPage.calculatorpage_instance.DeactivatePage();
                }
                else if(page == typeof(HomePage))
                {
                    HomePage.homepage_instance.ActivatePage();
                    CalculatorPage.calculatorpage_instance.DeactivatePage();
                    InventoryPage.inventorypage_instance.DeactivatePage();
                }
                else if(page == typeof(CalculatorPage))
                {
                    CalculatorPage.calculatorpage_instance.ActivatePage();
                    HomePage.homepage_instance.DeactivatePage();
                    InventoryPage.inventorypage_instance.DeactivatePage();
                }

                mainwindow_instance.notebookPages.CurrentPage = i;
                break;
            }
        } 
    }

}
