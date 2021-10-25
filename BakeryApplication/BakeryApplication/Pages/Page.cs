using System;
namespace BakeryApplication
{

    /**
     * Page interface not yot implemented:
     *      Because the 'Page' classes (CalculatorPage, etc.) are generated as Gdk Widgets,
     *      inheritance requires going into the auto-generated GUI-Stetic files.
     *      This is not justified at present because the number of pages is low.
     */
    [System.ComponentModel.ToolboxItem(true)]
    public partial class Page : Gtk.Bin
    {
        protected Page()
        {
            this.Build();
        }

        public virtual void ActivatePage()
        {

        }

        public virtual void DeactivatePage()
        {

        }
    }
}
