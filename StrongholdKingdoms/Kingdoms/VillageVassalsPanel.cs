using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004F0 RID: 1264
	public class VillageVassalsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002FED RID: 12269 RVA: 0x00275F3C File Offset: 0x0027413C
		public VillageVassalsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06002FEE RID: 12270 RVA: 0x002760F8 File Offset: 0x002742F8
		public void reinit()
		{
			bool flag = this.validVassalTarget;
			int selectedVillage = this.m_selectedVillage;
			this.init(false);
			this.validVassalTarget = flag;
			this.m_selectedVillage = selectedVillage;
			if (this.validVassalTarget)
			{
				int num = GameEngine.Instance.World.numVassalsAllowed();
				int num2 = GameEngine.Instance.World.countVassals();
				if (num > num2)
				{
					this.btnRequestVassalage.Enabled = true;
				}
			}
			if (this.m_selectedVillage >= 0)
			{
				this.tbSelectVassalName.Text = GameEngine.Instance.World.getVillageName(this.m_selectedVillage);
			}
		}

		// Token: 0x06002FEF RID: 12271 RVA: 0x0027618C File Offset: 0x0027438C
		public void init(bool resized)
		{
			int height = base.Height;
			VillageVassalsPanel.instance = this;
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.body_background_002;
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Tile = true;
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundLeftEdge.Image = GFXLibrary.body_background_canvas_left_edge;
			this.backgroundLeftEdge.Position = new Point(0, 0);
			this.backgroundLeftEdge.Size = new Size(this.backgroundLeftEdge.Image.Width, height - 40);
			this.backgroundLeftEdge.Tile = true;
			this.backgroundImage.addControl(this.backgroundLeftEdge);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.CreateX(GFXLibrary.mail_top_drag_bar_left, GFXLibrary.mail_top_drag_bar_middle, GFXLibrary.mail_top_drag_bar_right, -2, 2);
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			this.parishNameLabel.Text = SK.Text("GENERIC_Vassals", "Vassals") + " : " + GameEngine.Instance.World.getVillageNameOrType(selectedMenuVillage);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.btnVassalsOverview.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnVassalsOverview.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnVassalsOverview.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnVassalsOverview.Position = new Point(base.Width - 230, 7);
			this.btnVassalsOverview.Text.Text = SK.Text("Vassals_Overview", "Vassals Overview");
			this.btnVassalsOverview.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnVassalsOverview.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnVassalsOverview.TextYOffset = -3;
			this.btnVassalsOverview.Text.Color = global::ARGBColors.Black;
			this.btnVassalsOverview.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.allVassals), "VillageVassalsPanel_all_vassals");
			this.headerImage.addControl(this.btnVassalsOverview);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 8, new Point(base.Width - 230 - 50, 3));
			this.liegeLordImageArea.Size = new Size(base.Width - 50, 85);
			this.liegeLordImageArea.Position = new Point(25, 20);
			this.backgroundImage.addControl(this.liegeLordImageArea);
			this.liegeLordImageArea.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.currentLiegeLordLabel.Text = SK.Text("VassalControlPanel_Current_Liege_Lord", "Current Liege Lord");
			this.currentLiegeLordLabel.Color = global::ARGBColors.Black;
			this.currentLiegeLordLabel.Position = new Point(5, 5);
			this.currentLiegeLordLabel.Size = new Size(500, 25);
			this.currentLiegeLordLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.currentLiegeLordLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.liegeLordImageArea.addControl(this.currentLiegeLordLabel);
			Graphics graphics = base.CreateGraphics();
			Size size = graphics.MeasureString(this.currentLiegeLordLabel.Text, this.currentLiegeLordLabel.Font, 500).ToSize();
			graphics.Dispose();
			this.currentLiegeLordInfoLabel.Text = "";
			this.currentLiegeLordInfoLabel.Color = global::ARGBColors.Black;
			this.currentLiegeLordInfoLabel.Position = new Point(10 + size.Width + 5, 7);
			this.currentLiegeLordInfoLabel.Size = new Size(500, 50);
			this.currentLiegeLordInfoLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentLiegeLordInfoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.currentLiegeLordInfoLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.liegeLordClicked));
			this.liegeLordImageArea.addControl(this.currentLiegeLordInfoLabel);
			this.lblHonourPerDay.Text = SK.Text("VassalControlPanel_Honour_Gained_Per_Day", "Honour Gained Per Day") + " : ";
			this.lblHonourPerDay.Color = global::ARGBColors.Black;
			this.lblHonourPerDay.Position = new Point(243, 56);
			this.lblHonourPerDay.Size = new Size(500, 25);
			this.lblHonourPerDay.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.lblHonourPerDay.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.liegeLordImageArea.addControl(this.lblHonourPerDay);
			this.smallPeasantImage2.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage2.Position = new Point(642, 5);
			this.smallPeasantImage2.ClipRect = new Rectangle(0, 0, this.smallPeasantImage2.Image.Width * 5 / 6, this.smallPeasantImage2.Image.Height);
			this.liegeLordImageArea.addControl(this.smallPeasantImage2);
			this.lblPeasants.Text = "0";
			this.lblPeasants.Color = global::ARGBColors.Black;
			this.lblPeasants.Position = new Point(624, 55);
			this.lblPeasants.Size = new Size(55, 25);
			this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.liegeLordImageArea.addControl(this.lblPeasants);
			this.lblArchers.Text = "0";
			this.lblArchers.Color = global::ARGBColors.Black;
			this.lblArchers.Position = new Point(684, 55);
			this.lblArchers.Size = new Size(55, 25);
			this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.liegeLordImageArea.addControl(this.lblArchers);
			this.lblPikemen.Text = "0";
			this.lblPikemen.Color = global::ARGBColors.Black;
			this.lblPikemen.Position = new Point(744, 55);
			this.lblPikemen.Size = new Size(55, 25);
			this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.liegeLordImageArea.addControl(this.lblPikemen);
			this.lblSwordsmen.Text = "0";
			this.lblSwordsmen.Color = global::ARGBColors.Black;
			this.lblSwordsmen.Position = new Point(804, 55);
			this.lblSwordsmen.Size = new Size(55, 25);
			this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.liegeLordImageArea.addControl(this.lblSwordsmen);
			this.lblCatapults.Text = "0";
			this.lblCatapults.Color = global::ARGBColors.Black;
			this.lblCatapults.Position = new Point(864, 55);
			this.lblCatapults.Size = new Size(55, 25);
			this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.liegeLordImageArea.addControl(this.lblCatapults);
			this.btnBreakVassalage.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnBreakVassalage.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnBreakVassalage.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnBreakVassalage.Position = new Point(37, 72);
			this.btnBreakVassalage.Text.Text = SK.Text("VassalControlPanel_Break_From_Liege_Lord", "Break From Liege Lord");
			this.btnBreakVassalage.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnBreakVassalage.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnBreakVassalage.TextYOffset = -3;
			this.btnBreakVassalage.Text.Color = global::ARGBColors.Black;
			this.btnBreakVassalage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.promptBreakFromYourLiegeLord), "VillageVassalsPanel_break_vassal");
			this.backgroundImage.addControl(this.btnBreakVassalage);
			this.blockYSize = height - 40 - 56 - 124;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 129);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider2Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(300, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.yourVassalsLabel.Text = SK.Text("VassalControlPanel_Your_Vassals", "Your Vassals") + " (" + GameEngine.Instance.World.countVassals().ToString() + ")";
			this.yourVassalsLabel.Color = global::ARGBColors.Black;
			this.yourVassalsLabel.Position = new Point(12, -3);
			this.yourVassalsLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.yourVassalsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.yourVassalsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.yourVassalsLabel);
			this.maxVassalsLabel.Text = SK.Text("VassalControlPanel_Max_Vassals", "Maximum Vassals Allowed") + " : " + GameEngine.Instance.World.numVassalsAllowed().ToString();
			this.maxVassalsLabel.Color = global::ARGBColors.Black;
			this.maxVassalsLabel.Position = new Point(this.headerLabelsImage.Width - 333, -3);
			this.maxVassalsLabel.Size = new Size(319, this.headerLabelsImage.Height);
			this.maxVassalsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.maxVassalsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.headerLabelsImage.addControl(this.maxVassalsLabel);
			this.vassalScrollArea.Position = new Point(25, 164);
			this.vassalScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.vassalScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.vassalScrollArea);
			this.vassalScrollArea.Visible = true;
			int value = this.vassalScrollBar.Value;
			this.vassalScrollBar.Position = new Point(943, 164);
			this.vassalScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.vassalScrollBar);
			this.vassalScrollBar.Value = 0;
			this.vassalScrollBar.Max = 100;
			this.vassalScrollBar.NumVisibleLines = 25;
			this.vassalScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.vassalScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage.Position = new Point(323, -10);
			this.smallPeasantImage.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Image.Width * 5 / 6, this.smallPeasantImage.Image.Height);
			this.headerLabelsImage.addControl(this.smallPeasantImage);
			if (resized)
			{
				this.vassalScrollBar.Value = value;
			}
			this.btnClose.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnClose.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnClose.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnClose.Position = new Point(base.Width - 230, height - 40 - 40 - 4);
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnClose.TextYOffset = -3;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "VillageVassalsPanel_close");
			this.backgroundImage.addControl(this.btnClose);
			this.btnSelectVassal.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnSelectVassal.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnSelectVassal.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnSelectVassal.Position = new Point(20, height - 40 - 40 - 4);
			this.btnSelectVassal.Text.Text = SK.Text("VassalControlPanel_Select_Vassal", "Select Vassal");
			this.btnSelectVassal.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnSelectVassal.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnSelectVassal.TextYOffset = -3;
			this.btnSelectVassal.Text.Color = global::ARGBColors.Black;
			this.btnSelectVassal.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSelectVassal_Click), "VillageVassalsPanel_select");
			this.backgroundImage.addControl(this.btnSelectVassal);
			this.tbSelectVassalName.Text = "Selected Vassal";
			this.tbSelectVassalName.Color = global::ARGBColors.White;
			this.tbSelectVassalName.DropShadowColor = global::ARGBColors.Black;
			this.tbSelectVassalName.Position = new Point(240, height - 40 - 40 - 4 + 6);
			this.tbSelectVassalName.Size = new Size(200, 25);
			this.tbSelectVassalName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.tbSelectVassalName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.backgroundImage.addControl(this.tbSelectVassalName);
			this.lblVassalError.Text = "";
			this.lblVassalError.Color = global::ARGBColors.Black;
			this.lblVassalError.Position = new Point(20, height - 40 - 40 - 4 + 6 - 24);
			this.lblVassalError.Size = new Size(634, 25);
			this.lblVassalError.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.lblVassalError.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.backgroundImage.addControl(this.lblVassalError);
			this.btnRequestVassalage.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnRequestVassalage.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnRequestVassalage.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnRequestVassalage.Position = new Point(450, height - 40 - 40 - 4);
			this.btnRequestVassalage.Text.Text = SK.Text("VassalControlPanel_RequestVassalage", "Request Vassalage");
			this.btnRequestVassalage.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnRequestVassalage.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnRequestVassalage.TextYOffset = -3;
			this.btnRequestVassalage.Text.Color = global::ARGBColors.Black;
			this.btnRequestVassalage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnRequestVassalage_Click), "VillageVassalsPanel_request");
			this.btnRequestVassalage.Enabled = false;
			this.backgroundImage.addControl(this.btnRequestVassalage);
			GameEngine.Instance.vassalsManager.Reset();
			this.lblVassalError.Visible = false;
			this.btnRequestVassalage.Enabled = false;
			this.btnSelectVassal.Visible = false;
			this.tbSelectVassalName.Visible = false;
			this.btnRequestVassalage.Visible = false;
			this.tbSelectVassalName.Text = "";
			this.noResearchWindow.Size = new Size(739, 150);
			this.noResearchWindow.Position = new Point(126, 230);
			this.backgroundImage.addControl(this.noResearchWindow);
			this.noResearchWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.noResearchWindow.Visible = false;
			this.noResearchText.Text = SK.Text("Vassal_Need_Rank", "You don't currently have the required Rank (8) to make another player your Vassal.");
			this.noResearchText.Color = Color.FromArgb(224, 203, 146);
			this.noResearchText.Position = new Point(20, 0);
			this.noResearchText.Size = new Size(this.noResearchWindow.Width - 40, this.noResearchWindow.Height);
			this.noResearchText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.noResearchText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.noResearchWindow.addControl(this.noResearchText);
			RemoteServices.Instance.set_VassalInfo_UserCallBack(new RemoteServices.VassalInfo_UserCallBack(this.vassalInfoCallBack));
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				RemoteServices.Instance.VassalInfo(village.VillageID);
			}
			this.reAddVassals();
		}

		// Token: 0x06002FF0 RID: 12272 RVA: 0x00277578 File Offset: 0x00275778
		public void vassalInfoCallBack(VassalInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			GameEngine.Instance.vassalsManager.importVassals(returnData.liegeLordInfo, returnData.vassals);
			GameEngine.Instance.vassalsManager.importVassalRequests(returnData.requestsYouveMade, returnData.requestsOfYou);
			this.reAddVassals();
			GameEngine.Instance.World.updateUserVassals();
			int num = GameEngine.Instance.World.numVassalsAllowed();
			int num2 = GameEngine.Instance.World.countVassals();
			if (num <= num2 || GameEngine.Instance.World.isHeretic())
			{
				this.btnSelectVassal.Visible = false;
				this.tbSelectVassalName.Visible = false;
				this.btnRequestVassalage.Visible = false;
				return;
			}
			this.btnSelectVassal.Visible = true;
			this.tbSelectVassalName.Visible = true;
			this.btnRequestVassalage.Visible = true;
			if (this.validVassalTarget)
			{
				this.btnRequestVassalage.Enabled = true;
				return;
			}
			this.btnRequestVassalage.Enabled = false;
		}

		// Token: 0x06002FF1 RID: 12273 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06002FF2 RID: 12274 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x00277678 File Offset: 0x00275878
		private void wallScrollBarMoved()
		{
			int value = this.vassalScrollBar.Value;
			this.vassalScrollArea.Position = new Point(this.vassalScrollArea.X, 164 - value);
			this.vassalScrollArea.ClipRect = new Rectangle(this.vassalScrollArea.ClipRect.X, value, this.vassalScrollArea.ClipRect.Width, this.vassalScrollArea.ClipRect.Height);
			this.vassalScrollArea.invalidate();
			this.vassalScrollBar.invalidate();
		}

		// Token: 0x06002FF4 RID: 12276 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06002FF5 RID: 12277 RVA: 0x00277714 File Offset: 0x00275914
		private void liegeLordClicked()
		{
			VassalInfo liegeLord = GameEngine.Instance.vassalsManager.GetLiegeLord();
			if (liegeLord != null && liegeLord.villageID >= 0)
			{
				int villageID = liegeLord.villageID;
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(villageID);
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(0);
				InterfaceMgr.Instance.closeParishPanel();
				GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
				InterfaceMgr.Instance.displaySelectedVillagePanel(villageID, false, true, true, false);
			}
		}

		// Token: 0x06002FF6 RID: 12278 RVA: 0x002777B0 File Offset: 0x002759B0
		private void reAddVassals()
		{
			CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
			VassalInfo liegeLord = GameEngine.Instance.vassalsManager.GetLiegeLord();
			VassalInfo[] vassals = GameEngine.Instance.vassalsManager.GetVassals();
			VassalRequestInfo[] requestsSentByYou = GameEngine.Instance.vassalsManager.GetRequestsSentByYou();
			VassalRequestInfo[] requestsSentToYou = GameEngine.Instance.vassalsManager.GetRequestsSentToYou();
			this.lineList.Clear();
			if (liegeLord == null || liegeLord.villageID < 0)
			{
				this.currentLiegeLordInfoLabel.Text = SK.Text("VassalControlPanel_You_Have_No_Liege_Lord", "You currently have no Liege Lord. Accept offers from other players to become their Vassal to receive a daily Honour boost.");
				this.btnBreakVassalage.Visible = false;
				this.lblHonourPerDay.Visible = false;
				this.smallPeasantImage2.Visible = false;
				this.lblPeasants.Visible = false;
				this.lblArchers.Visible = false;
				this.lblPikemen.Visible = false;
				this.lblSwordsmen.Visible = false;
				this.lblCatapults.Visible = false;
			}
			else
			{
				this.btnBreakVassalage.Visible = true;
				this.smallPeasantImage2.Visible = true;
				this.lblPeasants.Visible = true;
				this.lblArchers.Visible = true;
				this.lblPikemen.Visible = true;
				this.lblSwordsmen.Visible = true;
				this.lblCatapults.Visible = true;
				NumberFormatInfo nfi = GameEngine.NFI;
				this.lblPeasants.Text = liegeLord.stationed_Peasants.ToString("N", nfi);
				this.lblArchers.Text = liegeLord.stationed_Archers.ToString("N", nfi);
				this.lblPikemen.Text = liegeLord.stationed_Pikemen.ToString("N", nfi);
				this.lblSwordsmen.Text = liegeLord.stationed_Swordsmen.ToString("N", nfi);
				this.lblCatapults.Text = liegeLord.stationed_Catapults.ToString("N", nfi);
				this.currentLiegeLordInfoLabel.Text = string.Concat(new string[]
				{
					GameEngine.Instance.World.getVillageName(liegeLord.villageID),
					" (",
					liegeLord.liegelordname,
					" - ",
					Rankings.getRankingName(GameEngine.Instance.LocalWorldData, liegeLord.rank, liegeLord.subrank, liegeLord.male),
					")"
				});
				this.lblHonourPerDay.Visible = true;
				int num = (int)(liegeLord.honourPerSecond * 86400.0);
				this.lblHonourPerDay.Text = SK.Text("VassalControlPanel_Honour_Gained_Per_Day", "Honour Gained Per Day") + " : " + num.ToString("N", nfi);
			}
			if (GameEngine.Instance.World.getRank() < 7)
			{
				this.noResearchWindow.Visible = true;
			}
			this.vassalScrollArea.clearControls();
			int num2 = 0;
			int num3 = 0;
			if (requestsSentToYou != null)
			{
				VassalRequestInfo[] array = requestsSentToYou;
				foreach (VassalRequestInfo vassalRequestInfo in array)
				{
					if (num2 != 0)
					{
						num2 += 5;
					}
					VillageVassalsPanel.ArmyLine armyLine = new VillageVassalsPanel.ArmyLine();
					armyLine.Position = new Point(0, num2);
					armyLine.initAsked(num3, this, vassalRequestInfo.requesterVillageID, vassalRequestInfo.requesterUserName, vassalRequestInfo.requestMadeTime);
					this.vassalScrollArea.addControl(armyLine);
					num2 += armyLine.Height;
					this.lineList.Add(armyLine);
					num3++;
				}
			}
			if (requestsSentByYou != null)
			{
				VassalRequestInfo[] array3 = requestsSentByYou;
				foreach (VassalRequestInfo vassalRequestInfo2 in array3)
				{
					if (num2 != 0)
					{
						num2 += 5;
					}
					VillageVassalsPanel.ArmyLine armyLine2 = new VillageVassalsPanel.ArmyLine();
					armyLine2.Position = new Point(0, num2);
					armyLine2.initAsking(num3, this, vassalRequestInfo2.vassalVillageID, vassalRequestInfo2.vassalUserName, vassalRequestInfo2.requestMadeTime);
					this.vassalScrollArea.addControl(armyLine2);
					num2 += armyLine2.Height;
					this.lineList.Add(armyLine2);
					num3++;
				}
			}
			if (vassals != null)
			{
				VassalInfo[] array5 = vassals;
				foreach (VassalInfo vassalInfo in array5)
				{
					if (num2 != 0)
					{
						num2 += 5;
					}
					VillageVassalsPanel.ArmyLine armyLine3 = new VillageVassalsPanel.ArmyLine();
					armyLine3.Position = new Point(0, num2);
					armyLine3.init(num3, this, vassalInfo.villageID, vassalInfo.honourPerSecond, vassalInfo.stationed_Peasants, vassalInfo.stationed_Archers, vassalInfo.stationed_Pikemen, vassalInfo.stationed_Swordsmen, vassalInfo.stationed_Catapults, vassalInfo.vassalPlayerName);
					this.vassalScrollArea.addControl(armyLine3);
					num2 += armyLine3.Height;
					this.lineList.Add(armyLine3);
					num3++;
				}
			}
			this.vassalScrollArea.Size = new Size(this.vassalScrollArea.Width, num2);
			if (num2 < this.vassalScrollBar.Height)
			{
				this.vassalScrollBar.Visible = false;
			}
			else
			{
				this.vassalScrollBar.Visible = true;
				this.vassalScrollBar.NumVisibleLines = this.vassalScrollBar.Height;
				this.vassalScrollBar.Max = num2 - this.vassalScrollBar.Height;
			}
			this.vassalScrollArea.invalidate();
			this.vassalScrollBar.invalidate();
			this.backgroundImage.invalidate();
		}

		// Token: 0x06002FF7 RID: 12279 RVA: 0x00277CF8 File Offset: 0x00275EF8
		public void promptBreakFromYourVassal(int villageID)
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.theirVillageID = villageID;
				this.yourVillageID = village.VillageID;
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("VassalControlPanel_BreakVassalage_Warning", "Breaking from your vassal will mean any troops stationed there will be lost."), SK.Text("VassalControlPanel_BreakVassalage", "Break Vassalage?"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.confirmBreakFromYourVassal();
				}
			}
		}

		// Token: 0x06002FF8 RID: 12280 RVA: 0x00022E0D File Offset: 0x0002100D
		private void confirmBreakFromYourVassal()
		{
			GameEngine.Instance.vassalsManager.BreakFromYourVassal(this.yourVillageID, this.theirVillageID, new VassalsManager.VassalsUpdatedCallback(this.reAddVassals));
		}

		// Token: 0x06002FF9 RID: 12281 RVA: 0x00277D58 File Offset: 0x00275F58
		private void promptBreakFromYourLiegeLord()
		{
			VassalInfo liegeLord = GameEngine.Instance.vassalsManager.GetLiegeLord();
			this.theirVillageID = liegeLord.villageID;
			VillageMap village = GameEngine.Instance.Village;
			this.yourVillageID = village.VillageID;
			if (village != null)
			{
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("VassalControlPanel_BreakFromLiegeLord_Warning", "Breaking from your Liege Lord will remove any stationed troops from your village."), SK.Text("VassalControlPanel_BreakFromLiegeLord", "Break from Liege Lord?"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.confirmBreakFromYourLiegeLord();
				}
			}
		}

		// Token: 0x06002FFA RID: 12282 RVA: 0x00022E36 File Offset: 0x00021036
		private void confirmBreakFromYourLiegeLord()
		{
			GameEngine.Instance.vassalsManager.BreakFromYourLiegeLord(this.theirVillageID, this.yourVillageID, new VassalsManager.VassalsUpdatedCallback(this.reAddVassals));
		}

		// Token: 0x06002FFB RID: 12283 RVA: 0x00277DCC File Offset: 0x00275FCC
		public void btnRequestVassalage_Click()
		{
			if (this.m_selectedVillage >= 0 && !GameEngine.Instance.World.WorldEnded)
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.btnRequestVassalage.Enabled = false;
					GameEngine.Instance.vassalsManager.AskSomeoneToBeYourVassal(village.VillageID, this.m_selectedVillage, new VassalsManager.VassalsUpdatedCallback(this.reAddVassals));
				}
			}
		}

		// Token: 0x06002FFC RID: 12284 RVA: 0x00277E34 File Offset: 0x00276034
		private void btnSelectVassal_Click()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				GameEngine.Instance.World.zoomToVillage(village.VillageID);
			}
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(13);
		}

		// Token: 0x06002FFD RID: 12285 RVA: 0x00277E78 File Offset: 0x00276078
		public void setVassalVillage(int villageID)
		{
			this.validVassalTarget = false;
			this.m_selectedVillage = villageID;
			this.tbSelectVassalName.Text = GameEngine.Instance.World.getVillageName(this.m_selectedVillage);
			if (villageID >= 0 && !GameEngine.Instance.World.WorldEnded)
			{
				RemoteServices.Instance.set_GetPreVassalInfo_UserCallBack(new RemoteServices.GetPreVassalInfo_UserCallBack(this.getPreVassalInfoCallBack));
				RemoteServices.Instance.GetPreVassalInfo(InterfaceMgr.Instance.OwnSelectedVillage, villageID);
			}
			this.btnRequestVassalage.Enabled = false;
			this.lblVassalError.Visible = false;
		}

		// Token: 0x06002FFE RID: 12286 RVA: 0x00277F0C File Offset: 0x0027610C
		public void getPreVassalInfoCallBack(GetPreVassalInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.HERETIC)
				{
					this.validVassalTarget = false;
					this.btnRequestVassalage.Enabled = false;
					this.lblVassalError.Text = SK.Text("VassalControlPanel_Village_Heretic", "Heretics can't use Vassalage");
					this.lblVassalError.Visible = true;
				}
				return;
			}
			if (returnData.alreadyHasLiegeLord || returnData.rankTooHigh || returnData.invalidTarget)
			{
				this.validVassalTarget = false;
				this.btnRequestVassalage.Enabled = false;
				if (returnData.alreadyHasLiegeLord)
				{
					this.lblVassalError.Text = SK.Text("VassalControlPanel_Village_Has_Liege_Lord", "Village already has a liege lord");
				}
				else if (returnData.rankTooHigh)
				{
					this.lblVassalError.Text = SK.Text("VassalControlPanel_Rank_Too_High", "The Player's Rank is too high");
				}
				else if (returnData.invalidTarget)
				{
					this.lblVassalError.Text = SK.Text("VassalControlPanel_Invalid_Village", "Not a valid village for vassaling.");
				}
				this.lblVassalError.Visible = true;
				return;
			}
			this.validVassalTarget = true;
			int num = GameEngine.Instance.World.numVassalsAllowed();
			int num2 = GameEngine.Instance.World.countVassals();
			if (num > num2)
			{
				this.btnRequestVassalage.Enabled = true;
			}
			this.lblVassalError.Visible = false;
		}

		// Token: 0x06002FFF RID: 12287 RVA: 0x00278054 File Offset: 0x00276254
		public void PromptAcceptRequest(int villageID)
		{
			VassalInfo liegeLord = GameEngine.Instance.vassalsManager.GetLiegeLord();
			this.theirVillageID = villageID;
			if (liegeLord != null && liegeLord.villageID >= 0)
			{
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("VassalControlPanel_AcceptLiegeLordWarning", "Accepting a new Liege Lord will break you from your current Liege Lord and any troops stationed will be lost."), SK.Text("VassalControlPanel_AcceptLiegeLord", "Accept New Liege Lord?"), MessageBoxButtons.YesNo);
				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}
			this.onConfirmAcceptRequest();
		}

		// Token: 0x06003000 RID: 12288 RVA: 0x00022E5F File Offset: 0x0002105F
		private void onConfirmAcceptRequest()
		{
			GameEngine.Instance.vassalsManager.AcceptRequest(this.theirVillageID, GameEngine.Instance.Village.VillageID, new VassalsManager.VassalsUpdatedCallback(this.handleVassalRequestCallBack));
		}

		// Token: 0x06003001 RID: 12289 RVA: 0x00022E91 File Offset: 0x00021091
		public void declineRequest(int villageID)
		{
			GameEngine.Instance.vassalsManager.DeclineRequest(villageID, GameEngine.Instance.Village.VillageID, new VassalsManager.VassalsUpdatedCallback(this.handleVassalRequestCallBack));
		}

		// Token: 0x06003002 RID: 12290 RVA: 0x00022EBE File Offset: 0x000210BE
		public void cancelRequest(int villageID)
		{
			GameEngine.Instance.vassalsManager.CancelRequest(villageID, GameEngine.Instance.Village.VillageID, new VassalsManager.VassalsUpdatedCallback(this.handleVassalRequestCallBack));
		}

		// Token: 0x06003003 RID: 12291 RVA: 0x00022EEB File Offset: 0x000210EB
		public void handleVassalRequestCallBack()
		{
			this.reAddVassals();
			this.lblVassalError.Visible = false;
			this.btnRequestVassalage.Enabled = false;
			this.tbSelectVassalName.Text = "";
		}

		// Token: 0x06003004 RID: 12292 RVA: 0x00022F1B File Offset: 0x0002111B
		private void allVassals()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(24, false);
		}

		// Token: 0x06003005 RID: 12293 RVA: 0x0000B71E File Offset: 0x0000991E
		private void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06003006 RID: 12294 RVA: 0x00022F2A File Offset: 0x0002112A
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06003007 RID: 12295 RVA: 0x00022F3A File Offset: 0x0002113A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06003008 RID: 12296 RVA: 0x00022F4A File Offset: 0x0002114A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06003009 RID: 12297 RVA: 0x00022F5C File Offset: 0x0002115C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600300A RID: 12298 RVA: 0x00022F69 File Offset: 0x00021169
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x00022F83 File Offset: 0x00021183
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600300C RID: 12300 RVA: 0x00022F90 File Offset: 0x00021190
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600300D RID: 12301 RVA: 0x00022F9D File Offset: 0x0002119D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600300E RID: 12302 RVA: 0x002780B4 File Offset: 0x002762B4
		private void InitializeComponent()
		{
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			base.Name = "VillageVassalsPanel";
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04003C51 RID: 15441
		public static VillageVassalsPanel instance;

		// Token: 0x04003C52 RID: 15442
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003C53 RID: 15443
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C54 RID: 15444
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C55 RID: 15445
		private CustomSelfDrawPanel.CSDButton btnVassalsOverview = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C56 RID: 15446
		private CustomSelfDrawPanel.CSDExtendingPanel liegeLordImageArea = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003C57 RID: 15447
		private CustomSelfDrawPanel.CSDLabel currentLiegeLordLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C58 RID: 15448
		private CustomSelfDrawPanel.CSDLabel currentLiegeLordInfoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C59 RID: 15449
		private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5A RID: 15450
		private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5B RID: 15451
		private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5C RID: 15452
		private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5D RID: 15453
		private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5E RID: 15454
		private CustomSelfDrawPanel.CSDLabel lblHonourPerDay = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C5F RID: 15455
		private CustomSelfDrawPanel.CSDButton btnBreakVassalage = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C60 RID: 15456
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C61 RID: 15457
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003C62 RID: 15458
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C63 RID: 15459
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C64 RID: 15460
		private CustomSelfDrawPanel.CSDLabel yourVassalsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C65 RID: 15461
		private CustomSelfDrawPanel.CSDLabel outGoingFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C66 RID: 15462
		private CustomSelfDrawPanel.CSDLabel maxVassalsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C67 RID: 15463
		private CustomSelfDrawPanel.CSDVertScrollBar vassalScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003C68 RID: 15464
		private CustomSelfDrawPanel.CSDArea vassalScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003C69 RID: 15465
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C6A RID: 15466
		private CustomSelfDrawPanel.CSDImage smallPeasantImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C6B RID: 15467
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C6C RID: 15468
		private CustomSelfDrawPanel.CSDButton btnSelectVassal = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C6D RID: 15469
		private CustomSelfDrawPanel.CSDButton btnRequestVassalage = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C6E RID: 15470
		private CustomSelfDrawPanel.CSDLabel tbSelectVassalName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C6F RID: 15471
		private CustomSelfDrawPanel.CSDLabel lblVassalError = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C70 RID: 15472
		private int blockYSize;

		// Token: 0x04003C71 RID: 15473
		private CustomSelfDrawPanel.CSDExtendingPanel noResearchWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003C72 RID: 15474
		private CustomSelfDrawPanel.CSDLabel noResearchText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C73 RID: 15475
		private List<VillageVassalsPanel.ArmyLine> lineList = new List<VillageVassalsPanel.ArmyLine>();

		// Token: 0x04003C74 RID: 15476
		private int theirVillageID;

		// Token: 0x04003C75 RID: 15477
		private int yourVillageID;

		// Token: 0x04003C76 RID: 15478
		public bool validVassalTarget;

		// Token: 0x04003C77 RID: 15479
		public int m_selectedVillage = -1;

		// Token: 0x04003C78 RID: 15480
		private VillageVassalsPanel.ArmyComparer armyComparer = new VillageVassalsPanel.ArmyComparer();

		// Token: 0x04003C79 RID: 15481
		private DockableControl dockableControl;

		// Token: 0x04003C7A RID: 15482
		private IContainer components;

		// Token: 0x04003C7B RID: 15483
		private Panel focusPanel;

		// Token: 0x020004F1 RID: 1265
		public class ArmyComparer : IComparer<WorldMap.LocalArmyData>
		{
			// Token: 0x0600300F RID: 12303 RVA: 0x0001D3B7 File Offset: 0x0001B5B7
			public int Compare(WorldMap.LocalArmyData x, WorldMap.LocalArmyData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.armyID > y.armyID)
					{
						return 1;
					}
					if (x.armyID < y.armyID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020004F2 RID: 1266
		public class ArmyLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06003011 RID: 12305 RVA: 0x002781A0 File Offset: 0x002763A0
			public void initAsked(int position, VillageVassalsPanel parent, int villageID, string userName, DateTime requestTime)
			{
				this.m_villageID = villageID;
				this.m_parent = parent;
				this.m_position = position;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.lblVillage.Text = GameEngine.Instance.World.getVillageName(villageID) + " (" + userName + ")";
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(290, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "VillageVassalsPanel_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblPeasants.Text = string.Concat(new string[]
				{
					SK.Text("VassalControlRequestLine_Request_Made", "Request Made"),
					" :",
					requestTime.ToShortTimeString(),
					" : ",
					requestTime.ToShortDateString()
				});
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.Position = new Point(305, 0);
				this.lblPeasants.Size = new Size(430, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblPeasants);
				this.btnAccept.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
				this.btnAccept.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
				this.btnAccept.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
				this.btnAccept.Position = new Point(626, 3);
				this.btnAccept.Text.Text = SK.Text("GENERIC_Accept", "Accept");
				this.btnAccept.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnAccept.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnAccept.TextYOffset = -3;
				this.btnAccept.Text.Color = global::ARGBColors.Black;
				this.btnAccept.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.acceptVassalageRequest), "VillageVassalsPanel_accept");
				this.backgroundImage.addControl(this.btnAccept);
				this.btnReject.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
				this.btnReject.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
				this.btnReject.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
				this.btnReject.Position = new Point(776, 3);
				this.btnReject.Text.Text = SK.Text("GENERIC_Decline", "Decline");
				this.btnReject.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnReject.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnReject.TextYOffset = -3;
				this.btnReject.Text.Color = global::ARGBColors.Black;
				this.btnReject.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.declineVassalageRequest), "VillageVassalsPanel_reject");
				this.backgroundImage.addControl(this.btnReject);
			}

			// Token: 0x06003012 RID: 12306 RVA: 0x002785B0 File Offset: 0x002767B0
			public void initAsking(int position, VillageVassalsPanel parent, int villageID, string userName, DateTime requestTime)
			{
				this.m_villageID = villageID;
				this.m_parent = parent;
				this.m_position = position;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.lblVillage.Text = GameEngine.Instance.World.getVillageName(villageID) + " (" + userName + ")";
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(290, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "VillageVassalsPanel_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblPeasants.Text = string.Concat(new string[]
				{
					SK.Text("VassalControlRequestLine_Request_Made", "Request Made"),
					" :",
					requestTime.ToShortTimeString(),
					" : ",
					requestTime.ToShortDateString()
				});
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.Position = new Point(305, 0);
				this.lblPeasants.Size = new Size(430, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblPeasants);
				this.btnCancel.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
				this.btnCancel.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
				this.btnCancel.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
				this.btnCancel.Position = new Point(776, 3);
				this.btnCancel.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
				this.btnCancel.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnCancel.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnCancel.TextYOffset = -3;
				this.btnCancel.Text.Color = global::ARGBColors.Black;
				this.btnCancel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelVassalageRequest), "VillageVassalsPanel_cancel");
				this.backgroundImage.addControl(this.btnCancel);
			}

			// Token: 0x06003013 RID: 12307 RVA: 0x002788CC File Offset: 0x00276ACC
			public void init(int position, VillageVassalsPanel parent, int villageID, double honourPerSecond, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, string username)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_villageID = villageID;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				if (username.Length > 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblVillage;
					csdlabel.Text = csdlabel.Text + " (" + username + ")";
				}
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(290, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "VillageVassalsPanel_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblPeasants.Text = numPeasants.ToString();
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.RolloverColor = global::ARGBColors.White;
				this.lblPeasants.Position = new Point(305, 0);
				this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblPeasants.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick));
				this.lblPeasants.CustomTooltipID = 2800;
				this.backgroundImage.addControl(this.lblPeasants);
				this.lblArchers.Text = numArchers.ToString();
				this.lblArchers.Color = global::ARGBColors.Black;
				this.lblArchers.RolloverColor = global::ARGBColors.White;
				this.lblArchers.Position = new Point(365, 0);
				this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
				this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblArchers.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick));
				this.lblArchers.CustomTooltipID = 2800;
				this.backgroundImage.addControl(this.lblArchers);
				this.lblPikemen.Text = numPikemen.ToString();
				this.lblPikemen.Color = global::ARGBColors.Black;
				this.lblPikemen.RolloverColor = global::ARGBColors.White;
				this.lblPikemen.Position = new Point(425, 0);
				this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
				this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblPikemen.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick));
				this.lblPikemen.CustomTooltipID = 2800;
				this.backgroundImage.addControl(this.lblPikemen);
				this.lblSwordsmen.Text = numSwordsmen.ToString();
				this.lblSwordsmen.Color = global::ARGBColors.Black;
				this.lblSwordsmen.RolloverColor = global::ARGBColors.White;
				this.lblSwordsmen.Position = new Point(485, 0);
				this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
				this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblSwordsmen.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick));
				this.lblSwordsmen.CustomTooltipID = 2800;
				this.backgroundImage.addControl(this.lblSwordsmen);
				this.lblCatapults.Text = numCatapults.ToString();
				this.lblCatapults.Color = global::ARGBColors.Black;
				this.lblCatapults.RolloverColor = global::ARGBColors.White;
				this.lblCatapults.Position = new Point(545, 0);
				this.lblCatapults.Size = new Size(55, this.backgroundImage.Height);
				this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblCatapults.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick));
				this.lblCatapults.CustomTooltipID = 2800;
				this.backgroundImage.addControl(this.lblCatapults);
				this.btnBreakVassalage.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
				this.btnBreakVassalage.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
				this.btnBreakVassalage.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
				this.btnBreakVassalage.Position = new Point(706, 3);
				this.btnBreakVassalage.Text.Text = SK.Text("VassalControlSentLine_Break_Vassalage", "Break Vassalage");
				this.btnBreakVassalage.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnBreakVassalage.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnBreakVassalage.TextYOffset = -3;
				this.btnBreakVassalage.Text.Color = global::ARGBColors.Black;
				this.btnBreakVassalage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.breakVassalage), "VillageVassalsPanel_break_vassal_line");
				this.backgroundImage.addControl(this.btnBreakVassalage);
				base.invalidate();
			}

			// Token: 0x06003014 RID: 12308 RVA: 0x00009262 File Offset: 0x00007462
			public bool update()
			{
				return false;
			}

			// Token: 0x06003015 RID: 12309 RVA: 0x00022FBC File Offset: 0x000211BC
			private void breakVassalage()
			{
				if (this.m_parent != null)
				{
					this.m_parent.promptBreakFromYourVassal(this.m_villageID);
				}
			}

			// Token: 0x06003016 RID: 12310 RVA: 0x00022FD7 File Offset: 0x000211D7
			private void cancelVassalageRequest()
			{
				if (this.m_parent != null)
				{
					this.m_parent.cancelRequest(this.m_villageID);
				}
			}

			// Token: 0x06003017 RID: 12311 RVA: 0x00022FF2 File Offset: 0x000211F2
			private void acceptVassalageRequest()
			{
				if (this.m_parent != null)
				{
					this.m_parent.PromptAcceptRequest(this.m_villageID);
				}
			}

			// Token: 0x06003018 RID: 12312 RVA: 0x0002300D File Offset: 0x0002120D
			private void declineVassalageRequest()
			{
				if (this.m_parent != null)
				{
					this.m_parent.declineRequest(this.m_villageID);
				}
			}

			// Token: 0x06003019 RID: 12313 RVA: 0x00278F14 File Offset: 0x00277114
			private void lblVillage_Click()
			{
				if (this.m_villageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_villageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_villageID, false, true, true, false);
				}
			}

			// Token: 0x0600301A RID: 12314 RVA: 0x00023028 File Offset: 0x00021228
			private void troopClick()
			{
				if (this.m_villageID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("VillageVassalsPanel_troops");
					InterfaceMgr.Instance.setVassalArmiesVillage(this.m_villageID);
					InterfaceMgr.Instance.setVillageTabSubMode(15);
				}
			}

			// Token: 0x04003C7C RID: 15484
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003C7D RID: 15485
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C7E RID: 15486
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C7F RID: 15487
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C80 RID: 15488
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C81 RID: 15489
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C82 RID: 15490
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C83 RID: 15491
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C84 RID: 15492
			private CustomSelfDrawPanel.CSDButton btnBreakVassalage = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003C85 RID: 15493
			private CustomSelfDrawPanel.CSDButton btnAccept = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003C86 RID: 15494
			private CustomSelfDrawPanel.CSDButton btnReject = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003C87 RID: 15495
			private CustomSelfDrawPanel.CSDButton btnCancel = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003C88 RID: 15496
			private int m_position = -1000;

			// Token: 0x04003C89 RID: 15497
			private VillageVassalsPanel m_parent;

			// Token: 0x04003C8A RID: 15498
			private int m_villageID = -1;

			// Token: 0x04003C8B RID: 15499
			private DateTime m_arrivalTime = DateTime.Now;
		}
	}
}
