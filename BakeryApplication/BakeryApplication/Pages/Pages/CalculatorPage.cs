using System;
using Gtk;
using Npgsql;

namespace BakeryApplication
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class CalculatorPage : Gtk.Bin
    {
        //public bool activated = false;
        public static CalculatorPage calculatorpage_instance;

        public CalculatorPage()
        {
            this.Build();
            calculatorpage_instance = this;

            this.WidthRequest = StyleGUI.GetWidth();
            //this.DefaultWidth = StyleGUI.GetWidth();
            this.HeightRequest = StyleGUI.GetHeight();
            //this.DefaultHeight = StyleGUI.GetHeight();

            StyleGUI.ButtonSetup(buttonCalculate);
            buttonCalculate.ModifyFont(StyleGUI.xlarge_font);

            StyleGUI.ButtonSetup(buttonHome);
            buttonHome.ModifyFont(StyleGUI.medium_font);

            labelCalculator.ModifyFont(StyleGUI.title_font);
            labelEntry.ModifyFont(StyleGUI.xlarge_font);
            labelResult.ModifyFont(StyleGUI.xlarge_font);
            labelDough.ModifyFont(StyleGUI.medium_font_italic);
            labelFilling.ModifyFont(StyleGUI.medium_font_italic);
            labelPaste.ModifyFont(StyleGUI.medium_font);
            labelBatch.ModifyFont(StyleGUI.medium_font);

            labelDoughBatchResult.ModifyFont(StyleGUI.xlarge_font);
            labelChickenResult.ModifyFont(StyleGUI.xlarge_font);
            labelCreamCheeseResult.ModifyFont(StyleGUI.xlarge_font);
            labelShreddedCheeseResult.ModifyFont(StyleGUI.xlarge_font);

            entryCaseNumber.HeightRequest = 100;
            entryCaseNumber.WidthRequest = 200;
            entryCaseNumber.ModifyFont(StyleGUI.title_font);

            eventboxMain.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxEntry.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonCalculate.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxLabelCalculator.ModifyBg(StateType.Normal, StyleGUI.light_grey);
            eventboxRatios.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonRatios.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxLabelDough.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxLabelFilling.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxBottom.ModifyBg(StateType.Normal, StyleGUI.light_grey);
            eventboxButtonHome.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxNavigation.ModifyBg(StateType.Normal, StyleGUI.background_color);

            tableRatios.HideAll();
            buttonRatios.Label = "Show ratios";

            PopulateRatios();
        }

        /**
         * This function is called when MainWindow's SetPage()
         * sets this page as the current page to display to user.
         */
        public void ActivatePage()
        {
            tableRatios.HideAll();
            buttonRatios.Label = "Show ratios";
        }

        /**
         * Called when MainWindow's SetPage() sets any other page to be displayed.
         */
        public void DeactivatePage()
        {
            tableRatios.HideAll();
            buttonRatios.Label = "Show ratios";

        }


        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }


        protected void OnButtonCalculateClicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryCaseNumber.Text, out input_cases))
            {
                Console.WriteLine("PopulateResult called. ");
                PopulateResult(input_cases);
            }
        }

        static int input_cases;
        static int cases_per_dough_batch = 10;
        static int filling_per_case_lbs = 10;
        static int chicken_per_case_lbs = 5;
        static int cream_cheese_per_case_lbs = 3;
        static int normal_cheese_per_case_lbs = 2;

        public void PopulateRatios()
        {
            string ratio_dough = "One batch = " + cases_per_dough_batch.ToString() + "cases.";

            string ratio_filling;
            string part1 = filling_per_case_lbs.ToString() + "lbs per case";
            string part2 = "\n  = " + chicken_per_case_lbs.ToString() + "lbs chicken,";
            string part3 = "\n     " + cream_cheese_per_case_lbs.ToString() + "lbs cream cheese,";
            string part4 = "\n     " + normal_cheese_per_case_lbs.ToString() + "lbs normal cheese.";
            ratio_filling = part1 + part2 + part3 + part4;

            labelPaste.Text = ratio_filling;
            labelBatch.Text = ratio_dough;
        }

        public void PopulateResult(int case_count)
        {
            int dough_batches = GetBatchCount(case_count);
            int cases = dough_batches * 10;
            int chicken_result = chicken_per_case_lbs * cases;
            int cream_cheese_result = cream_cheese_per_case_lbs * cases;
            int shredded_cheese_result = normal_cheese_per_case_lbs * cases;


            labelDoughBatchResult.Text = dough_batches.ToString();
            labelChickenResult.Text = chicken_result.ToString();
            labelCreamCheeseResult.Text = cream_cheese_result.ToString();
            labelShreddedCheeseResult.Text = shredded_cheese_result.ToString();
        }

        public static int GetBatchCount(int cases)
        {
            int adjusted_count;

            if (cases % cases_per_dough_batch == 0)
            {
                adjusted_count = cases / cases_per_dough_batch;
            }
            else
            {
                adjusted_count = cases / cases_per_dough_batch + 1;
            }

            return adjusted_count;
        }

        protected void OnButtonHomeClicked(object sender, EventArgs e)
        {
            MainWindow.SetPage(typeof(HomePage));
        }

        protected void OnButtonRatiosClicked(object sender, EventArgs e)
        {
            if (tableRatios.Visible)
            {
                tableRatios.HideAll();
                buttonRatios.Label = "Show ratios";
            }
            else if (!tableRatios.Visible)
            {
                tableRatios.ShowAll();
                buttonRatios.Label = "Hide ratios";
            }
        }
    }
}
