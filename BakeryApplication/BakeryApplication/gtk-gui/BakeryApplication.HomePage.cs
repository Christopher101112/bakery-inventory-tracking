
// This file has been generated by the GUI designer. Do not modify.
namespace BakeryApplication
{
	public partial class HomePage
	{
		private global::Gtk.EventBox eventboxMain;

		private global::Gtk.VBox vboxMain;

		private global::Gtk.Label labelHomePageTitle;

		private global::Gtk.Table tableOptions;

		private global::Gtk.Button buttonCalculator;

		private global::Gtk.Button buttonInventory;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget BakeryApplication.HomePage
			global::Stetic.BinContainer.Attach(this);
			this.Name = "BakeryApplication.HomePage";
			// Container child BakeryApplication.HomePage.Gtk.Container+ContainerChild
			this.eventboxMain = new global::Gtk.EventBox();
			this.eventboxMain.Name = "eventboxMain";
			// Container child eventboxMain.Gtk.Container+ContainerChild
			this.vboxMain = new global::Gtk.VBox();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.labelHomePageTitle = new global::Gtk.Label();
			this.labelHomePageTitle.Name = "labelHomePageTitle";
			this.labelHomePageTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Rice & Beans, LLC");
			this.vboxMain.Add(this.labelHomePageTitle);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.labelHomePageTitle]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.tableOptions = new global::Gtk.Table(((uint)(3)), ((uint)(2)), true);
			this.tableOptions.Name = "tableOptions";
			this.tableOptions.RowSpacing = ((uint)(6));
			this.tableOptions.ColumnSpacing = ((uint)(6));
			// Container child tableOptions.Gtk.Table+TableChild
			this.buttonCalculator = new global::Gtk.Button();
			this.buttonCalculator.CanFocus = true;
			this.buttonCalculator.Name = "buttonCalculator";
			this.buttonCalculator.UseUnderline = true;
			this.buttonCalculator.BorderWidth = ((uint)(24));
			this.buttonCalculator.Label = global::Mono.Unix.Catalog.GetString("Calculator");
			this.tableOptions.Add(this.buttonCalculator);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.tableOptions[this.buttonCalculator]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableOptions.Gtk.Table+TableChild
			this.buttonInventory = new global::Gtk.Button();
			this.buttonInventory.CanFocus = true;
			this.buttonInventory.Name = "buttonInventory";
			this.buttonInventory.UseUnderline = true;
			this.buttonInventory.BorderWidth = ((uint)(24));
			this.buttonInventory.Label = global::Mono.Unix.Catalog.GetString("Inventory");
			this.tableOptions.Add(this.buttonInventory);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.tableOptions[this.buttonInventory]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vboxMain.Add(this.tableOptions);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.tableOptions]));
			w4.Position = 1;
			this.eventboxMain.Add(this.vboxMain);
			this.Add(this.eventboxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonInventory.Clicked += new global::System.EventHandler(this.OnButtonInventoryClicked);
			this.buttonCalculator.Clicked += new global::System.EventHandler(this.OnButtonCalculatorClicked);
		}
	}
}