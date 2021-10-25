using System;
using Gtk;
using Gdk;
using Npgsql;
using System.Collections;
namespace BakeryApplication
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InventoryPage : Gtk.Bin
    {
        //The columns for current inventory table.
        private static ArrayList case_types = new ArrayList()
        {
            "Market 32",
            "Stewarts",
            "Other",
            "Total"
        };

        //Array to store case counts for each column.
        private static int[] case_counts = new int[case_types.Count];

        public bool activated = false;

        public InventoryPage()
        {
            this.Build();

            labelCurrentInventory.ModifyFont(StyleGUI.title_font);

            eventboxLabelCurrent.ModifyBg(StateType.Normal, StyleGUI.border_color);
            eventboxMain.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxCurrentInventory.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxNavigation.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonHome.ModifyBg(StateType.Normal, StyleGUI.background_color);

            StyleGUI.ButtonSetup(buttonHome);
            buttonHome.ModifyFont(StyleGUI.medium_font);


            //SETUP TABLES
            Table table_current = new Table(2, (uint)case_types.Count, true);
            table_current.RowSpacing = 0;
            vboxCurrentInventory.Add(table_current);

            //Populate case_counts from database.
            PopulateCaseCounts();

            //Populate tables.
            uint i = 0;
            uint j = 1;
            foreach (var column in case_types)
            {
                //Eventboxes for row 1 (headers).
                EventBox eventbox = new EventBox(); 
                eventbox.ModifyBg(StateType.Normal, StyleGUI.background_color);
                eventbox.BorderWidth = 10;
                Label label = new Label(column.ToString());
                label.ModifyFont(StyleGUI.large_font_italic);
                eventbox.Add(label);
                
                //Eventboxes for row 2 (case count)
                EventBox eventbox2 = new EventBox(); 
                eventbox2.ModifyBg(StateType.Normal, StyleGUI.border_color);
                eventbox2.BorderWidth = 0;
                Label label2 = new Label(case_counts[i].ToString());
                label2.ModifyFont(StyleGUI.large_font_italic);
                eventbox2.Add(label2);

                //Eventboxes for row 3 (entryboxes).
                EventBox eventbox3 = new EventBox();
                eventbox3.ModifyBg(StateType.Normal, StyleGUI.border_color);
                eventbox3.BorderWidth = 0;
                Entry entry = new Entry();
                entry.WidthRequest = 30;
                entry.ModifyBg(StateType.Normal, StyleGUI.border_color);
                entry.ModifyBase(StateType.Normal, StyleGUI.border_color);
                eventbox3.Add(entry);

                //Populate each row of table.
                table_current.Attach(eventbox, i, j, 0, 1); //First row
                table_current.Attach(eventbox2, i, j, 1, 2); //Second row
                table_current.Attach(eventbox3, i, j, 2, 3); //Third row

                i++;
                j++;
            }
        }


        /**
         * Call to the database for current inventory numbers. 
         */
        public static void PopulateCaseCounts()
        {
            for(int i=0; i<case_counts.Length; i++)
            {
                case_counts[i] = 0;
            }
        }

        
        protected void OnButtonHomeClicked(object sender, EventArgs e)
        {
            MainWindow.SetPage(0);
        }
    }
}
