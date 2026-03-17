using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004F8 RID: 1272
	public class WheelSelectPanel : CustomSelfDrawPanel
	{
		// Token: 0x06003051 RID: 12369 RVA: 0x00023271 File Offset: 0x00021471
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06003052 RID: 12370 RVA: 0x00023290 File Offset: 0x00021490
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06003053 RID: 12371 RVA: 0x0027C884 File Offset: 0x0027AA84
		public WheelSelectPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06003054 RID: 12372 RVA: 0x0027C964 File Offset: 0x0027AB64
		public void init(bool initialCall)
		{
			WheelSelectPanel.Instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.MainPanel.Size = base.Size;
			this.MainPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.MainPanel);
			this.MainPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.cardpanel_panel_gradient_top_left;
			csdimage.Size = GFXLibrary.cardpanel_panel_gradient_top_left.Size;
			csdimage.Position = new Point(0, 0);
			this.MainPanel.addControl(csdimage);
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = GFXLibrary.cardpanel_panel_gradient_bottom_right;
			csdimage2.Size = GFXLibrary.cardpanel_panel_gradient_bottom_right.Size;
			csdimage2.Position = new Point(this.MainPanel.Width - csdimage2.Width - 6, this.MainPanel.Height - csdimage2.Height - 6);
			this.MainPanel.addControl(csdimage2);
			this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			this.closeImage.Size = this.closeImage.Image.Size;
			this.closeImage.setMouseOverDelegate(delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Cards_Close");
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.closeImage.CustomTooltipID = 10100;
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 32, new Point(base.Width - 40 - 40, 2));
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			int num = 10;
			int num2 = 45;
			int num3 = 160;
			int num4 = 110;
			this.questWheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.questWheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.questWheelButton.Data = -1;
			this.questWheelButton.MoveOnClick = false;
			this.questWheelButton.Position = new Point(num, num4);
			this.questWheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.questWheelButton.Data).ToString();
			this.questWheelButton.TextYOffset = 32;
			this.questWheelButton.Text.Color = global::ARGBColors.Black;
			this.questWheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.questWheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.questWheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.questWheelButton);
			this.questWheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.questWheelButton.Data) > 0);
			this.treasure1WheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.treasure1WheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.treasure1WheelButton.Data = 0;
			this.treasure1WheelButton.MoveOnClick = false;
			this.treasure1WheelButton.Position = new Point(num + num2 + num3, num4);
			this.treasure1WheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.treasure1WheelButton.Data).ToString();
			this.treasure1WheelButton.TextYOffset = 32;
			this.treasure1WheelButton.Text.Color = global::ARGBColors.Black;
			this.treasure1WheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.treasure1WheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasure1WheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.treasure1WheelButton);
			this.treasure1WheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.treasure1WheelButton.Data) > 0);
			this.treasure2WheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.treasure2WheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.treasure2WheelButton.Data = 1;
			this.treasure2WheelButton.MoveOnClick = false;
			this.treasure2WheelButton.Position = new Point(num + num2 + num3 * 2, num4);
			this.treasure2WheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.treasure2WheelButton.Data).ToString();
			this.treasure2WheelButton.TextYOffset = 32;
			this.treasure2WheelButton.Text.Color = global::ARGBColors.Black;
			this.treasure2WheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.treasure2WheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasure2WheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.treasure2WheelButton);
			this.treasure2WheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.treasure2WheelButton.Data) > 0);
			this.treasure3WheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.treasure3WheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.treasure3WheelButton.Data = 2;
			this.treasure3WheelButton.MoveOnClick = false;
			this.treasure3WheelButton.Position = new Point(num + num2 + num3 * 3, num4);
			this.treasure3WheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.treasure3WheelButton.Data).ToString();
			this.treasure3WheelButton.TextYOffset = 32;
			this.treasure3WheelButton.Text.Color = global::ARGBColors.Black;
			this.treasure3WheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.treasure3WheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasure3WheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.treasure3WheelButton);
			this.treasure3WheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.treasure3WheelButton.Data) > 0);
			this.treasure4WheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.treasure4WheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.treasure4WheelButton.Data = 3;
			this.treasure4WheelButton.MoveOnClick = false;
			this.treasure4WheelButton.Position = new Point(num + num2 + num3, num4 + 150);
			this.treasure4WheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.treasure4WheelButton.Data).ToString();
			this.treasure4WheelButton.TextYOffset = 32;
			this.treasure4WheelButton.Text.Color = global::ARGBColors.Black;
			this.treasure4WheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.treasure4WheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasure4WheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.treasure4WheelButton);
			this.treasure4WheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.treasure4WheelButton.Data) > 0);
			this.treasure5WheelButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.treasure5WheelButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.treasure5WheelButton.Data = 4;
			this.treasure5WheelButton.MoveOnClick = false;
			this.treasure5WheelButton.Position = new Point(num + num2 + num3 * 2, num4 + 150);
			this.treasure5WheelButton.Text.Text = GameEngine.Instance.World.getTickets(this.treasure5WheelButton.Data).ToString();
			this.treasure5WheelButton.TextYOffset = 32;
			this.treasure5WheelButton.Text.Color = global::ARGBColors.Black;
			this.treasure5WheelButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.treasure5WheelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasure5WheelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openWheel));
			this.mainBackgroundImage.addControl(this.treasure5WheelButton);
			this.treasure5WheelButton.Enabled = (GameEngine.Instance.World.getTickets(this.treasure5WheelButton.Data) > 0);
			this.labelTitle.Text = SK.Text("WheelSelectPanel_SelectType", "Select Wheel Type");
			this.labelTitle.Position = new Point(0, 5);
			this.labelTitle.Size = new Size(base.Width, 64);
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.labelTitle.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			this.questLabel.Text = SK.Text("WheelSelectPanel_Quest", "Quest");
			this.questLabel.Position = new Point(this.questWheelButton.X - 8, 50);
			this.questLabel.Size = new Size(150, 64);
			this.questLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.questLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.questLabel.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.questLabel);
			this.treasureLabel.Text = SK.Text("WheelSelectPanel_Treasure", "Treasure Castle");
			this.treasureLabel.Position = new Point(42, 50);
			this.treasureLabel.Size = new Size(800, 64);
			this.treasureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureLabel.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureLabel);
			this.treasureTier1Label.Text = SK.Text("WheelSelectPanel_Tier1", "Tier 1");
			this.treasureTier1Label.Position = new Point(this.treasure1WheelButton.X - 8, 80);
			this.treasureTier1Label.Size = new Size(150, 64);
			this.treasureTier1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureTier1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureTier1Label.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureTier1Label);
			this.treasureTier2Label.Text = SK.Text("WheelSelectPanel_Tier2", "Tier 2");
			this.treasureTier2Label.Position = new Point(this.treasure2WheelButton.X - 8, 80);
			this.treasureTier2Label.Size = new Size(150, 64);
			this.treasureTier2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureTier2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureTier2Label.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureTier2Label);
			this.treasureTier3Label.Text = SK.Text("WheelSelectPanel_Tier3", "Tier 3");
			this.treasureTier3Label.Position = new Point(this.treasure3WheelButton.X - 8, 80);
			this.treasureTier3Label.Size = new Size(150, 64);
			this.treasureTier3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureTier3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureTier3Label.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureTier3Label);
			this.treasureTier4Label.Text = SK.Text("WheelSelectPanel_Tier4", "Tier 4");
			this.treasureTier4Label.Position = new Point(this.treasure4WheelButton.X - 8, 230);
			this.treasureTier4Label.Size = new Size(150, 64);
			this.treasureTier4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureTier4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureTier4Label.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureTier4Label);
			this.treasureTier5Label.Text = SK.Text("WheelSelectPanel_Tier5", "Tier 5");
			this.treasureTier5Label.Position = new Point(this.treasure5WheelButton.X - 8, 230);
			this.treasureTier5Label.Size = new Size(150, 64);
			this.treasureTier5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureTier5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.treasureTier5Label.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.treasureTier5Label);
		}

		// Token: 0x06003055 RID: 12373 RVA: 0x0027D8A4 File Offset: 0x0027BAA4
		private void openWheel()
		{
			if (this.ClickedControl != null)
			{
				int data = this.ClickedControl.Data;
				InterfaceMgr.Instance.closeWheelSelectPopup();
				InterfaceMgr.Instance.openWheelPopup(data);
			}
		}

		// Token: 0x06003056 RID: 12374 RVA: 0x000232A4 File Offset: 0x000214A4
		private void closeClick()
		{
			InterfaceMgr.Instance.closeWheelSelectPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x04003CC2 RID: 15554
		private IContainer components;

		// Token: 0x04003CC3 RID: 15555
		private static WheelSelectPanel Instance;

		// Token: 0x04003CC4 RID: 15556
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CC5 RID: 15557
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CC6 RID: 15558
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CC7 RID: 15559
		private CustomSelfDrawPanel.CSDButton questWheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CC8 RID: 15560
		private CustomSelfDrawPanel.CSDButton treasure1WheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CC9 RID: 15561
		private CustomSelfDrawPanel.CSDButton treasure2WheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CCA RID: 15562
		private CustomSelfDrawPanel.CSDButton treasure3WheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CCB RID: 15563
		private CustomSelfDrawPanel.CSDButton treasure4WheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CCC RID: 15564
		private CustomSelfDrawPanel.CSDButton treasure5WheelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CCD RID: 15565
		private CustomSelfDrawPanel.CSDExtendingPanel MainPanel = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003CCE RID: 15566
		private CustomSelfDrawPanel.CSDLabel questLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CCF RID: 15567
		private CustomSelfDrawPanel.CSDLabel treasureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CD0 RID: 15568
		private CustomSelfDrawPanel.CSDLabel treasureTier1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CD1 RID: 15569
		private CustomSelfDrawPanel.CSDLabel treasureTier2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CD2 RID: 15570
		private CustomSelfDrawPanel.CSDLabel treasureTier3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CD3 RID: 15571
		private CustomSelfDrawPanel.CSDLabel treasureTier4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CD4 RID: 15572
		private CustomSelfDrawPanel.CSDLabel treasureTier5Label = new CustomSelfDrawPanel.CSDLabel();
	}
}
