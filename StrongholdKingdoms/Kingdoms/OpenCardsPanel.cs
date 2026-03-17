using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200025E RID: 606
	public class OpenCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x06001AA5 RID: 6821 RVA: 0x001A5230 File Offset: 0x001A3430
		public OpenCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x001A533C File Offset: 0x001A353C
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_001;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * OpenCardsPanel.BorderPadding;
			this.AvailablePanelWidth = this.ContentWidth - 150 - 40;
			this.InplayPanelWidth = this.ContentWidth - OpenCardsPanel.BorderPadding - this.AvailablePanelWidth;
			this.AvailablePanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, base.Height - 16 - OpenCardsPanel.BorderPadding);
			this.AvailablePanel.Position = new Point(16, 16);
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			int width = base.Width - OpenCardsPanel.BorderPadding * 3 - this.AvailablePanel.Width;
			int height = 100;
			if (OpenCardsPanel.buttonpic == null)
			{
				OpenCardsPanel.buttonpic = new Bitmap(width, height);
				using (Graphics graphics = Graphics.FromImage(OpenCardsPanel.buttonpic))
				{
					Brush green = Brushes.Green;
					graphics.FillRectangle(green, new Rectangle(new Point(0, 0), OpenCardsPanel.buttonpic.Size));
				}
			}
			this.closeButton.Size = new Size(width, 38);
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.closeButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.closeButton.TextYOffset = -1;
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.closeButton);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Cards_Close");
			this.closeButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.closeButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.closeButton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, OpenCardsPanel.BorderPadding);
			this.playbutton.Size = new Size(width, height);
			this.playbutton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, this.closeButton.Y + this.closeButton.Height + OpenCardsPanel.BorderPadding / 2);
			this.playbutton.Image = OpenCardsPanel.buttonpic;
			this.mainBackgroundImage.addControl(this.playbutton);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(width, height);
			csdlabel.Text = SK.Text("OpenCardsPanel_Open_Cards", "Open Cards");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.playbutton.addControl(csdlabel);
			this.buybutton.Size = new Size(width, 100);
			this.buybutton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, this.playbutton.Y + this.playbutton.Height + OpenCardsPanel.BorderPadding / 2);
			this.buybutton.Image = OpenCardsPanel.buttonpic;
			this.mainBackgroundImage.addControl(this.buybutton);
			csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(width, height);
			csdlabel.Text = SK.Text("OpenCardsPanel_Buy_Cards", "Buy Cards");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.buybutton.addControl(csdlabel);
			this.premiumbutton.Size = new Size(width, 100);
			this.premiumbutton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, this.buybutton.Y + this.buybutton.Height + OpenCardsPanel.BorderPadding / 2);
			this.premiumbutton.Image = OpenCardsPanel.buttonpic;
			this.mainBackgroundImage.addControl(this.premiumbutton);
			csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(width, height);
			csdlabel.Text = SK.Text("OpenCardsPanel_Premium", "Premium");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.premiumbutton.addControl(csdlabel);
			this.managebutton.Size = new Size(width, 100);
			this.managebutton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, this.premiumbutton.Y + this.premiumbutton.Height + OpenCardsPanel.BorderPadding / 2);
			this.managebutton.Image = OpenCardsPanel.buttonpic;
			this.mainBackgroundImage.addControl(this.managebutton);
			csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(width, height);
			csdlabel.Text = SK.Text("OpenCardsPanel_Manage_Cards", "Manage Cards");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.managebutton.addControl(csdlabel);
			this.crownsbutton.Size = new Size(width, 100);
			this.crownsbutton.Position = new Point(base.Width - this.closeButton.Width - OpenCardsPanel.BorderPadding, this.managebutton.Y + this.managebutton.Height + OpenCardsPanel.BorderPadding / 2);
			this.crownsbutton.Image = OpenCardsPanel.buttonpic;
			this.mainBackgroundImage.addControl(this.crownsbutton);
			csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(width, height);
			csdlabel.Text = SK.Text("OpenCardsPanel_Get_Crowns", "Get Crowns");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.crownsbutton.addControl(csdlabel);
			this.labelTitle.Position = new Point(OpenCardsPanel.BorderPadding, 2);
			this.labelTitle.Size = new Size(300, 64);
			this.labelTitle.Text = SK.Text("OpenCardsPanel_Latest_Offers", "Latest Offers");
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.White;
			this.labelTitle.DropShadowColor = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x0001AA0F File Offset: 0x00018C0F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x0001AA2E File Offset: 0x00018C2E
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04002B76 RID: 11126
		private DateTime lastUpdatedProgressBars = DateTime.Now.AddSeconds(30.0);

		// Token: 0x04002B77 RID: 11127
		private DateTime lastTickCall = DateTime.Now.AddSeconds(-60.0);

		// Token: 0x04002B78 RID: 11128
		private DateTime lastRefresh = DateTime.Now;

		// Token: 0x04002B79 RID: 11129
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B7A RID: 11130
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B7B RID: 11131
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B7C RID: 11132
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B7D RID: 11133
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B7E RID: 11134
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B7F RID: 11135
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B80 RID: 11136
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B81 RID: 11137
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B82 RID: 11138
		private int currentCardSection = -1;

		// Token: 0x04002B83 RID: 11139
		private static int BorderPadding = 16;

		// Token: 0x04002B84 RID: 11140
		private int ContentWidth;

		// Token: 0x04002B85 RID: 11141
		private int AvailablePanelWidth;

		// Token: 0x04002B86 RID: 11142
		private int InplayPanelWidth;

		// Token: 0x04002B87 RID: 11143
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x04002B88 RID: 11144
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B89 RID: 11145
		private CustomSelfDrawPanel.CSDImage InplayPanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B8A RID: 11146
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002B8B RID: 11147
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarInplay = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002B8C RID: 11148
		private Bitmap greenbar = new Bitmap(29, 3);

		// Token: 0x04002B8D RID: 11149
		private static Bitmap buttonpic;

		// Token: 0x04002B8E RID: 11150
		private IContainer components;
	}
}
