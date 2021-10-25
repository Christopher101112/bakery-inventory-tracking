
// This file has been generated by the GUI designer. Do not modify.
namespace BakeryApplication
{
	public partial class InventoryPage
	{
		private global::Gtk.EventBox eventboxMain;

		private global::Gtk.VBox vboxMain;

		private global::Gtk.EventBox eventboxCurrentInventory;

		private global::Gtk.VBox vboxCurrentInventory;

		private global::Gtk.EventBox eventboxLabelCurrent;

		private global::Gtk.Label labelCurrentInventory;

		private global::Gtk.HBox hboxInventoryOptions;

		private global::Gtk.EventBox eventboxButtonUpdate;

		private global::Gtk.Button buttonUpdate;

		private global::Gtk.EventBox eventboxButtonRequestUpdate;

		private global::Gtk.Button buttonRequestUpdate;

		private global::Gtk.EventBox eventboxNotebookHistory;

		private global::Gtk.Notebook notebook1;

		private global::Gtk.EventBox eventboxActiveOrdersTab;

		private global::Gtk.VBox vboxActiveOrdersTab;

		private global::Gtk.EventBox eventboxLabelActiveOrders;

		private global::Gtk.Label labelActiveOrders;

		private global::Gtk.Alignment alignmentNodeviewActiveOrders;

		private global::Gtk.ScrolledWindow scrolledwindowNodeviewActiveOrders;

		private global::Gtk.NodeView nodeviewActiveOrders;

		private global::Gtk.HBox hboxActiveOrdersOptions;

		private global::Gtk.EventBox eventboxButtonRequestOrderCompletion;

		private global::Gtk.Button buttonRequestOrderCompletion;

		private global::Gtk.EventBox eventboxActiveOrderUI;

		private global::Gtk.VBox vboxActiveOrderUI;

		private global::Gtk.EventBox eventboxLabelActiveOrderID;

		private global::Gtk.Label labelActiveOrderID;

		private global::Gtk.EventBox eventboxEntryActiveOrderID;

		private global::Gtk.Entry entryActiveOrderID;

		private global::Gtk.EventBox eventboxButtonSubmit;

		private global::Gtk.Button buttonSubmit;

		private global::Gtk.Label labelPageUpcomingOrders;

		private global::Gtk.EventBox eventboxCompletedOrdersTab;

		private global::Gtk.VBox vboxCompletedOrdersTab;

		private global::Gtk.EventBox eventboxLabelCompletedOrders;

		private global::Gtk.Label labelCompletedOrders;

		private global::Gtk.Alignment alignmentCompletedOrdersNodeview;

		private global::Gtk.ScrolledWindow scrolledwindowCompletedOrdersNodeview;

		private global::Gtk.NodeView nodeviewCompletedOrders;

		private global::Gtk.Label labelPageCompletedOrders;

		private global::Gtk.EventBox eventboxShippingHistoryTab;

		private global::Gtk.VBox vboxShippingHistoryTab;

		private global::Gtk.EventBox eventboxLabelShippingHistory;

		private global::Gtk.Label labelShippingHistory;

		private global::Gtk.Alignment alignmentNodeviewShippingHistory;

		private global::Gtk.ScrolledWindow scrolledwindowNodeviewShippingHistory;

		private global::Gtk.NodeView nodeviewShippingHistory;

		private global::Gtk.Label labelPageShippingHistory;

		private global::Gtk.EventBox eventboxNavigation;

		private global::Gtk.HBox hboxNavigation;

		private global::Gtk.EventBox eventboxButtonHome;

		private global::Gtk.Button buttonHome;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget BakeryApplication.InventoryPage
			global::Stetic.BinContainer.Attach(this);
			this.Name = "BakeryApplication.InventoryPage";
			// Container child BakeryApplication.InventoryPage.Gtk.Container+ContainerChild
			this.eventboxMain = new global::Gtk.EventBox();
			this.eventboxMain.Name = "eventboxMain";
			// Container child eventboxMain.Gtk.Container+ContainerChild
			this.vboxMain = new global::Gtk.VBox();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.eventboxCurrentInventory = new global::Gtk.EventBox();
			this.eventboxCurrentInventory.Name = "eventboxCurrentInventory";
			// Container child eventboxCurrentInventory.Gtk.Container+ContainerChild
			this.vboxCurrentInventory = new global::Gtk.VBox();
			this.vboxCurrentInventory.Name = "vboxCurrentInventory";
			this.vboxCurrentInventory.Spacing = 50;
			// Container child vboxCurrentInventory.Gtk.Box+BoxChild
			this.eventboxLabelCurrent = new global::Gtk.EventBox();
			this.eventboxLabelCurrent.Name = "eventboxLabelCurrent";
			// Container child eventboxLabelCurrent.Gtk.Container+ContainerChild
			this.labelCurrentInventory = new global::Gtk.Label();
			this.labelCurrentInventory.Name = "labelCurrentInventory";
			this.labelCurrentInventory.LabelProp = global::Mono.Unix.Catalog.GetString("Current Inventory");
			this.eventboxLabelCurrent.Add(this.labelCurrentInventory);
			this.vboxCurrentInventory.Add(this.eventboxLabelCurrent);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxCurrentInventory[this.eventboxLabelCurrent]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			this.eventboxCurrentInventory.Add(this.vboxCurrentInventory);
			this.vboxMain.Add(this.eventboxCurrentInventory);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.eventboxCurrentInventory]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxInventoryOptions = new global::Gtk.HBox();
			this.hboxInventoryOptions.Name = "hboxInventoryOptions";
			this.hboxInventoryOptions.Spacing = 6;
			// Container child hboxInventoryOptions.Gtk.Box+BoxChild
			this.eventboxButtonUpdate = new global::Gtk.EventBox();
			this.eventboxButtonUpdate.Name = "eventboxButtonUpdate";
			// Container child eventboxButtonUpdate.Gtk.Container+ContainerChild
			this.buttonUpdate = new global::Gtk.Button();
			this.buttonUpdate.CanFocus = true;
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.UseUnderline = true;
			this.buttonUpdate.Label = global::Mono.Unix.Catalog.GetString("Submit");
			this.eventboxButtonUpdate.Add(this.buttonUpdate);
			this.hboxInventoryOptions.Add(this.eventboxButtonUpdate);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxInventoryOptions[this.eventboxButtonUpdate]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxInventoryOptions.Gtk.Box+BoxChild
			this.eventboxButtonRequestUpdate = new global::Gtk.EventBox();
			this.eventboxButtonRequestUpdate.Name = "eventboxButtonRequestUpdate";
			// Container child eventboxButtonRequestUpdate.Gtk.Container+ContainerChild
			this.buttonRequestUpdate = new global::Gtk.Button();
			this.buttonRequestUpdate.CanFocus = true;
			this.buttonRequestUpdate.Name = "buttonRequestUpdate";
			this.buttonRequestUpdate.Relief = ((global::Gtk.ReliefStyle)(2));
			this.buttonRequestUpdate.Label = global::Mono.Unix.Catalog.GetString("+ make an inventory update");
			this.eventboxButtonRequestUpdate.Add(this.buttonRequestUpdate);
			this.hboxInventoryOptions.Add(this.eventboxButtonRequestUpdate);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxInventoryOptions[this.eventboxButtonRequestUpdate]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxMain.Add(this.hboxInventoryOptions);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxInventoryOptions]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.eventboxNotebookHistory = new global::Gtk.EventBox();
			this.eventboxNotebookHistory.Name = "eventboxNotebookHistory";
			// Container child eventboxNotebookHistory.Gtk.Container+ContainerChild
			this.notebook1 = new global::Gtk.Notebook();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.eventboxActiveOrdersTab = new global::Gtk.EventBox();
			this.eventboxActiveOrdersTab.Name = "eventboxActiveOrdersTab";
			// Container child eventboxActiveOrdersTab.Gtk.Container+ContainerChild
			this.vboxActiveOrdersTab = new global::Gtk.VBox();
			this.vboxActiveOrdersTab.Name = "vboxActiveOrdersTab";
			this.vboxActiveOrdersTab.Spacing = 6;
			// Container child vboxActiveOrdersTab.Gtk.Box+BoxChild
			this.eventboxLabelActiveOrders = new global::Gtk.EventBox();
			this.eventboxLabelActiveOrders.Name = "eventboxLabelActiveOrders";
			// Container child eventboxLabelActiveOrders.Gtk.Container+ContainerChild
			this.labelActiveOrders = new global::Gtk.Label();
			this.labelActiveOrders.Name = "labelActiveOrders";
			this.labelActiveOrders.LabelProp = global::Mono.Unix.Catalog.GetString("Active Orders");
			this.eventboxLabelActiveOrders.Add(this.labelActiveOrders);
			this.vboxActiveOrdersTab.Add(this.eventboxLabelActiveOrders);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vboxActiveOrdersTab[this.eventboxLabelActiveOrders]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vboxActiveOrdersTab.Gtk.Box+BoxChild
			this.alignmentNodeviewActiveOrders = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignmentNodeviewActiveOrders.Name = "alignmentNodeviewActiveOrders";
			// Container child alignmentNodeviewActiveOrders.Gtk.Container+ContainerChild
			this.scrolledwindowNodeviewActiveOrders = new global::Gtk.ScrolledWindow();
			this.scrolledwindowNodeviewActiveOrders.CanFocus = true;
			this.scrolledwindowNodeviewActiveOrders.Name = "scrolledwindowNodeviewActiveOrders";
			this.scrolledwindowNodeviewActiveOrders.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindowNodeviewActiveOrders.Gtk.Container+ContainerChild
			this.nodeviewActiveOrders = new global::Gtk.NodeView();
			this.nodeviewActiveOrders.CanFocus = true;
			this.nodeviewActiveOrders.Name = "nodeviewActiveOrders";
			this.scrolledwindowNodeviewActiveOrders.Add(this.nodeviewActiveOrders);
			this.alignmentNodeviewActiveOrders.Add(this.scrolledwindowNodeviewActiveOrders);
			this.vboxActiveOrdersTab.Add(this.alignmentNodeviewActiveOrders);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vboxActiveOrdersTab[this.alignmentNodeviewActiveOrders]));
			w14.Position = 1;
			// Container child vboxActiveOrdersTab.Gtk.Box+BoxChild
			this.hboxActiveOrdersOptions = new global::Gtk.HBox();
			this.hboxActiveOrdersOptions.Name = "hboxActiveOrdersOptions";
			this.hboxActiveOrdersOptions.Spacing = 6;
			// Container child hboxActiveOrdersOptions.Gtk.Box+BoxChild
			this.eventboxButtonRequestOrderCompletion = new global::Gtk.EventBox();
			this.eventboxButtonRequestOrderCompletion.Name = "eventboxButtonRequestOrderCompletion";
			// Container child eventboxButtonRequestOrderCompletion.Gtk.Container+ContainerChild
			this.buttonRequestOrderCompletion = new global::Gtk.Button();
			this.buttonRequestOrderCompletion.CanFocus = true;
			this.buttonRequestOrderCompletion.Name = "buttonRequestOrderCompletion";
			this.buttonRequestOrderCompletion.Relief = ((global::Gtk.ReliefStyle)(2));
			this.buttonRequestOrderCompletion.Label = global::Mono.Unix.Catalog.GetString("+ change active order to \'completed\'");
			this.eventboxButtonRequestOrderCompletion.Add(this.buttonRequestOrderCompletion);
			this.hboxActiveOrdersOptions.Add(this.eventboxButtonRequestOrderCompletion);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hboxActiveOrdersOptions[this.eventboxButtonRequestOrderCompletion]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hboxActiveOrdersOptions.Gtk.Box+BoxChild
			this.eventboxActiveOrderUI = new global::Gtk.EventBox();
			this.eventboxActiveOrderUI.Name = "eventboxActiveOrderUI";
			// Container child eventboxActiveOrderUI.Gtk.Container+ContainerChild
			this.vboxActiveOrderUI = new global::Gtk.VBox();
			this.vboxActiveOrderUI.Name = "vboxActiveOrderUI";
			this.vboxActiveOrderUI.Spacing = 6;
			// Container child vboxActiveOrderUI.Gtk.Box+BoxChild
			this.eventboxLabelActiveOrderID = new global::Gtk.EventBox();
			this.eventboxLabelActiveOrderID.Name = "eventboxLabelActiveOrderID";
			// Container child eventboxLabelActiveOrderID.Gtk.Container+ContainerChild
			this.labelActiveOrderID = new global::Gtk.Label();
			this.labelActiveOrderID.Name = "labelActiveOrderID";
			this.labelActiveOrderID.LabelProp = global::Mono.Unix.Catalog.GetString("Enter Order ID");
			this.eventboxLabelActiveOrderID.Add(this.labelActiveOrderID);
			this.vboxActiveOrderUI.Add(this.eventboxLabelActiveOrderID);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vboxActiveOrderUI[this.eventboxLabelActiveOrderID]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vboxActiveOrderUI.Gtk.Box+BoxChild
			this.eventboxEntryActiveOrderID = new global::Gtk.EventBox();
			this.eventboxEntryActiveOrderID.Name = "eventboxEntryActiveOrderID";
			// Container child eventboxEntryActiveOrderID.Gtk.Container+ContainerChild
			this.entryActiveOrderID = new global::Gtk.Entry();
			this.entryActiveOrderID.CanFocus = true;
			this.entryActiveOrderID.Name = "entryActiveOrderID";
			this.entryActiveOrderID.IsEditable = true;
			this.entryActiveOrderID.InvisibleChar = '●';
			this.eventboxEntryActiveOrderID.Add(this.entryActiveOrderID);
			this.vboxActiveOrderUI.Add(this.eventboxEntryActiveOrderID);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vboxActiveOrderUI[this.eventboxEntryActiveOrderID]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			this.eventboxActiveOrderUI.Add(this.vboxActiveOrderUI);
			this.hboxActiveOrdersOptions.Add(this.eventboxActiveOrderUI);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hboxActiveOrdersOptions[this.eventboxActiveOrderUI]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hboxActiveOrdersOptions.Gtk.Box+BoxChild
			this.eventboxButtonSubmit = new global::Gtk.EventBox();
			this.eventboxButtonSubmit.Name = "eventboxButtonSubmit";
			// Container child eventboxButtonSubmit.Gtk.Container+ContainerChild
			this.buttonSubmit = new global::Gtk.Button();
			this.buttonSubmit.CanFocus = true;
			this.buttonSubmit.Name = "buttonSubmit";
			this.buttonSubmit.UseUnderline = true;
			this.buttonSubmit.Label = global::Mono.Unix.Catalog.GetString("Submit");
			this.eventboxButtonSubmit.Add(this.buttonSubmit);
			this.hboxActiveOrdersOptions.Add(this.eventboxButtonSubmit);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hboxActiveOrdersOptions[this.eventboxButtonSubmit]));
			w24.Position = 2;
			w24.Expand = false;
			w24.Fill = false;
			this.vboxActiveOrdersTab.Add(this.hboxActiveOrdersOptions);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vboxActiveOrdersTab[this.hboxActiveOrdersOptions]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			this.eventboxActiveOrdersTab.Add(this.vboxActiveOrdersTab);
			this.notebook1.Add(this.eventboxActiveOrdersTab);
			// Notebook tab
			this.labelPageUpcomingOrders = new global::Gtk.Label();
			this.labelPageUpcomingOrders.Name = "labelPageUpcomingOrders";
			this.labelPageUpcomingOrders.LabelProp = global::Mono.Unix.Catalog.GetString("Active orders");
			this.notebook1.SetTabLabel(this.eventboxActiveOrdersTab, this.labelPageUpcomingOrders);
			this.labelPageUpcomingOrders.ShowAll();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.eventboxCompletedOrdersTab = new global::Gtk.EventBox();
			this.eventboxCompletedOrdersTab.Name = "eventboxCompletedOrdersTab";
			// Container child eventboxCompletedOrdersTab.Gtk.Container+ContainerChild
			this.vboxCompletedOrdersTab = new global::Gtk.VBox();
			this.vboxCompletedOrdersTab.Name = "vboxCompletedOrdersTab";
			this.vboxCompletedOrdersTab.Spacing = 6;
			// Container child vboxCompletedOrdersTab.Gtk.Box+BoxChild
			this.eventboxLabelCompletedOrders = new global::Gtk.EventBox();
			this.eventboxLabelCompletedOrders.Name = "eventboxLabelCompletedOrders";
			// Container child eventboxLabelCompletedOrders.Gtk.Container+ContainerChild
			this.labelCompletedOrders = new global::Gtk.Label();
			this.labelCompletedOrders.Name = "labelCompletedOrders";
			this.labelCompletedOrders.LabelProp = global::Mono.Unix.Catalog.GetString("Completed orders");
			this.eventboxLabelCompletedOrders.Add(this.labelCompletedOrders);
			this.vboxCompletedOrdersTab.Add(this.eventboxLabelCompletedOrders);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vboxCompletedOrdersTab[this.eventboxLabelCompletedOrders]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vboxCompletedOrdersTab.Gtk.Box+BoxChild
			this.alignmentCompletedOrdersNodeview = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignmentCompletedOrdersNodeview.Name = "alignmentCompletedOrdersNodeview";
			// Container child alignmentCompletedOrdersNodeview.Gtk.Container+ContainerChild
			this.scrolledwindowCompletedOrdersNodeview = new global::Gtk.ScrolledWindow();
			this.scrolledwindowCompletedOrdersNodeview.CanFocus = true;
			this.scrolledwindowCompletedOrdersNodeview.Name = "scrolledwindowCompletedOrdersNodeview";
			this.scrolledwindowCompletedOrdersNodeview.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindowCompletedOrdersNodeview.Gtk.Container+ContainerChild
			this.nodeviewCompletedOrders = new global::Gtk.NodeView();
			this.nodeviewCompletedOrders.CanFocus = true;
			this.nodeviewCompletedOrders.Name = "nodeviewCompletedOrders";
			this.scrolledwindowCompletedOrdersNodeview.Add(this.nodeviewCompletedOrders);
			this.alignmentCompletedOrdersNodeview.Add(this.scrolledwindowCompletedOrdersNodeview);
			this.vboxCompletedOrdersTab.Add(this.alignmentCompletedOrdersNodeview);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vboxCompletedOrdersTab[this.alignmentCompletedOrdersNodeview]));
			w32.Position = 1;
			this.eventboxCompletedOrdersTab.Add(this.vboxCompletedOrdersTab);
			this.notebook1.Add(this.eventboxCompletedOrdersTab);
			global::Gtk.Notebook.NotebookChild w34 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.eventboxCompletedOrdersTab]));
			w34.Position = 1;
			// Notebook tab
			this.labelPageCompletedOrders = new global::Gtk.Label();
			this.labelPageCompletedOrders.Name = "labelPageCompletedOrders";
			this.labelPageCompletedOrders.LabelProp = global::Mono.Unix.Catalog.GetString("Completed orders");
			this.notebook1.SetTabLabel(this.eventboxCompletedOrdersTab, this.labelPageCompletedOrders);
			this.labelPageCompletedOrders.ShowAll();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.eventboxShippingHistoryTab = new global::Gtk.EventBox();
			this.eventboxShippingHistoryTab.Name = "eventboxShippingHistoryTab";
			// Container child eventboxShippingHistoryTab.Gtk.Container+ContainerChild
			this.vboxShippingHistoryTab = new global::Gtk.VBox();
			this.vboxShippingHistoryTab.Name = "vboxShippingHistoryTab";
			this.vboxShippingHistoryTab.Spacing = 6;
			// Container child vboxShippingHistoryTab.Gtk.Box+BoxChild
			this.eventboxLabelShippingHistory = new global::Gtk.EventBox();
			this.eventboxLabelShippingHistory.Name = "eventboxLabelShippingHistory";
			// Container child eventboxLabelShippingHistory.Gtk.Container+ContainerChild
			this.labelShippingHistory = new global::Gtk.Label();
			this.labelShippingHistory.Name = "labelShippingHistory";
			this.labelShippingHistory.LabelProp = global::Mono.Unix.Catalog.GetString("Shipping History");
			this.eventboxLabelShippingHistory.Add(this.labelShippingHistory);
			this.vboxShippingHistoryTab.Add(this.eventboxLabelShippingHistory);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vboxShippingHistoryTab[this.eventboxLabelShippingHistory]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			// Container child vboxShippingHistoryTab.Gtk.Box+BoxChild
			this.alignmentNodeviewShippingHistory = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignmentNodeviewShippingHistory.Name = "alignmentNodeviewShippingHistory";
			// Container child alignmentNodeviewShippingHistory.Gtk.Container+ContainerChild
			this.scrolledwindowNodeviewShippingHistory = new global::Gtk.ScrolledWindow();
			this.scrolledwindowNodeviewShippingHistory.CanFocus = true;
			this.scrolledwindowNodeviewShippingHistory.Name = "scrolledwindowNodeviewShippingHistory";
			this.scrolledwindowNodeviewShippingHistory.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindowNodeviewShippingHistory.Gtk.Container+ContainerChild
			this.nodeviewShippingHistory = new global::Gtk.NodeView();
			this.nodeviewShippingHistory.CanFocus = true;
			this.nodeviewShippingHistory.Name = "nodeviewShippingHistory";
			this.scrolledwindowNodeviewShippingHistory.Add(this.nodeviewShippingHistory);
			this.alignmentNodeviewShippingHistory.Add(this.scrolledwindowNodeviewShippingHistory);
			this.vboxShippingHistoryTab.Add(this.alignmentNodeviewShippingHistory);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vboxShippingHistoryTab[this.alignmentNodeviewShippingHistory]));
			w39.Position = 1;
			this.eventboxShippingHistoryTab.Add(this.vboxShippingHistoryTab);
			this.notebook1.Add(this.eventboxShippingHistoryTab);
			global::Gtk.Notebook.NotebookChild w41 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.eventboxShippingHistoryTab]));
			w41.Position = 2;
			// Notebook tab
			this.labelPageShippingHistory = new global::Gtk.Label();
			this.labelPageShippingHistory.Name = "labelPageShippingHistory";
			this.labelPageShippingHistory.LabelProp = global::Mono.Unix.Catalog.GetString("Shipping history");
			this.notebook1.SetTabLabel(this.eventboxShippingHistoryTab, this.labelPageShippingHistory);
			this.labelPageShippingHistory.ShowAll();
			this.eventboxNotebookHistory.Add(this.notebook1);
			this.vboxMain.Add(this.eventboxNotebookHistory);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.eventboxNotebookHistory]));
			w43.Position = 2;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.eventboxNavigation = new global::Gtk.EventBox();
			this.eventboxNavigation.Name = "eventboxNavigation";
			// Container child eventboxNavigation.Gtk.Container+ContainerChild
			this.hboxNavigation = new global::Gtk.HBox();
			this.hboxNavigation.Name = "hboxNavigation";
			this.hboxNavigation.Spacing = 6;
			// Container child hboxNavigation.Gtk.Box+BoxChild
			this.eventboxButtonHome = new global::Gtk.EventBox();
			this.eventboxButtonHome.Name = "eventboxButtonHome";
			// Container child eventboxButtonHome.Gtk.Container+ContainerChild
			this.buttonHome = new global::Gtk.Button();
			this.buttonHome.CanFocus = true;
			this.buttonHome.Name = "buttonHome";
			this.buttonHome.UseUnderline = true;
			this.buttonHome.BorderWidth = ((uint)(9));
			this.buttonHome.Label = global::Mono.Unix.Catalog.GetString("Home");
			this.eventboxButtonHome.Add(this.buttonHome);
			this.hboxNavigation.Add(this.eventboxButtonHome);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.hboxNavigation[this.eventboxButtonHome]));
			w45.Position = 0;
			w45.Expand = false;
			w45.Fill = false;
			this.eventboxNavigation.Add(this.hboxNavigation);
			this.vboxMain.Add(this.eventboxNavigation);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.eventboxNavigation]));
			w47.Position = 3;
			w47.Expand = false;
			w47.Fill = false;
			this.eventboxMain.Add(this.vboxMain);
			this.Add(this.eventboxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonUpdate.Clicked += new global::System.EventHandler(this.OnButtonUpdateClicked);
			this.buttonRequestUpdate.Clicked += new global::System.EventHandler(this.OnButtonRequestUpdateClicked);
			this.buttonRequestOrderCompletion.Clicked += new global::System.EventHandler(this.OnButtonRequestOrderCompletionClicked);
			this.buttonSubmit.Clicked += new global::System.EventHandler(this.OnButtonSubmitClicked);
			this.buttonHome.Clicked += new global::System.EventHandler(this.OnButtonHomeClicked);
		}
	}
}
