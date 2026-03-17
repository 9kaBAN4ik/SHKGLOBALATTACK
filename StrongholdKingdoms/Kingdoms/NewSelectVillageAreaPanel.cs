using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200025B RID: 603
	public class NewSelectVillageAreaPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001A8E RID: 6798 RVA: 0x001A378C File Offset: 0x001A198C
		public NewSelectVillageAreaPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x001A3894 File Offset: 0x001A1A94
		public void init(int tryingToJoinCounty, NewSelectVillageAreaWindow parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			this.background.Position = new Point(0, 0);
			this.background.Size = new Size(base.Width, base.Height);
			base.addControl(this.background);
			this.background.Create(GFXLibrary._9sclice_fancy_top_left, GFXLibrary._9sclice_fancy_top_mid, GFXLibrary._9sclice_fancy_top_right, GFXLibrary._9sclice_fancy_mid_left, GFXLibrary._9sclice_fancy_mid_mid, GFXLibrary._9sclice_fancy_mid_right, GFXLibrary._9sclice_fancy_bottom_left, GFXLibrary._9sclice_fancy_bottom_mid, GFXLibrary._9sclice_fancy_bottom_right);
			this.background.ForceTiling();
			this.backgroundArea.Position = new Point(206, 53);
			this.backgroundArea.Size = new Size(514, 340);
			base.addControl(this.backgroundArea);
			this.smallButtons = false;
			int y = 0;
			int x = 0;
			int num = 0;
			this.divider = 5f;
			switch (GameEngine.Instance.World.WorldMapType)
			{
			case 1:
				this.mapImage.Image = GFXLibrary.world_select_map_de;
				break;
			default:
				this.mapImage.Image = GFXLibrary.world_select_map_en;
				break;
			case 3:
				this.mapImage.Image = GFXLibrary.world_select_map_fr;
				break;
			case 4:
				this.mapImage.Image = GFXLibrary.world_select_map_ru;
				break;
			case 5:
				this.mapImage.Image = GFXLibrary.world_select_map_sa;
				this.divider = 6f;
				y = 10;
				break;
			case 6:
				this.mapImage.Image = GFXLibrary.world_select_map_es;
				this.divider = 5.5f;
				y = 104;
				break;
			case 7:
				this.mapImage.Image = GFXLibrary.world_select_map_pl;
				y = 50;
				break;
			case 8:
				this.mapImage.Image = GFXLibrary.world_select_map_eu;
				y = 66;
				this.divider = 5.5f;
				break;
			case 9:
				this.mapImage.Image = GFXLibrary.world_select_map_tr;
				this.divider = 5.5f;
				y = 190;
				break;
			case 10:
				this.mapImage.Image = GFXLibrary.world_select_map_us;
				this.divider = 5.5f;
				y = 130;
				break;
			case 11:
				this.mapImage.Image = GFXLibrary.world_select_map_it;
				y = 85;
				break;
			case 16:
				this.mapImage.Image = GFXLibrary.world_select_map_world;
				y = 45;
				x = -67;
				num = -52;
				this.smallButtons = true;
				break;
			case 17:
				this.mapImage.Image = GFXLibrary.world_select_map_ph;
				x = 50;
				this.divider = 6.7f;
				break;
			case 19:
				this.mapImage.Image = GFXLibrary.world_select_map_china;
				y = 15;
				x = -67;
				num = -52;
				this.smallButtons = true;
				break;
			case 23:
			case 24:
				this.mapImage.Image = GFXLibrary.world_select_map_kingmaker;
				y = 65;
				x = -32;
				this.divider = 5.5f;
				num = -52;
				this.smallButtons = true;
				break;
			}
			this.mapImage.Position = new Point(x, y);
			this.backgroundArea.addControl(this.mapImage);
			this.mapBorder.Position = new Point(x, y);
			this.mapBorder.Size = new Size(this.mapImage.Width, this.mapImage.Height);
			this.mapBorder.LineColor = global::ARGBColors.Black;
			this.backgroundArea.addControl(this.mapBorder);
			this.btnEnterGame.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnEnterGame.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnEnterGame.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnEnterGame.Position = new Point(565, 60);
			this.btnEnterGame.Text.Text = SK.Text("SelectVillageAreaPopup_Enter_Game", "Enter Game");
			this.btnEnterGame.TextYOffset = -2;
			this.btnEnterGame.Text.Color = global::ARGBColors.White;
			this.btnEnterGame.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnEnterGame.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnEnterGame.Text.Position = new Point(-3, 0);
			this.btnEnterGame.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnEnterGame_Click));
			this.btnEnterGame.Enabled = false;
			this.backgroundArea.addControl(this.btnEnterGame);
			this.btnBack.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnBack.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnBack.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnBack.Position = new Point(565 + num, 540);
			this.btnBack.Text.Text = SK.Text("FORUMS_Back", "Back");
			this.btnBack.TextYOffset = -2;
			this.btnBack.Text.Color = global::ARGBColors.White;
			this.btnBack.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnBack.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnBack.Text.Position = new Point(-3, 0);
			this.btnBack.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnBack_Click));
			this.btnBack.Enabled = true;
			this.backgroundArea.addControl(this.btnBack);
			this.btnLogout.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnLogout.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnLogout.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnLogout.Position = new Point(565 + num, 500);
			this.btnLogout.Text.Text = SK.Text("LogoutPanel_Swap_Worlds", "Swap Worlds");
			this.btnLogout.TextYOffset = -2;
			this.btnLogout.Text.Color = global::ARGBColors.White;
			this.btnLogout.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnLogout.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnLogout.Text.Position = new Point(-3, 0);
			this.btnLogout.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.logoutClick));
			this.btnLogout.Enabled = true;
			this.backgroundArea.addControl(this.btnLogout);
			this.headerLabel.Text = SK.Text("SelectVillageAreaPopup_Select_Village_Location", "Select Village Location");
			this.headerLabel.Position = new Point(0, 1);
			this.headerLabel.Size = new Size(this.background.Width, 150);
			this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.headerLabel.Color = global::ARGBColors.Black;
			this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.background.addControl(this.headerLabel);
			this.loadingLabel.Text = SK.Text("SelectVillageAreaPopup_Downloading", "Downloading") + " .....";
			this.loadingLabel.Position = new Point(this.btnEnterGame.Position.X + this.btnEnterGame.Width / 2 - 100, this.btnEnterGame.Position.Y + 50);
			this.loadingLabel.Size = new Size(200, 200);
			this.loadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.loadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.loadingLabel.Color = global::ARGBColors.Black;
			this.loadingLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.loadingLabel);
			this.populationLabel.Text = SK.Text("SelectVillagePopup_Population", "Population");
			this.populationLabel.Position = new Point(574, 245);
			this.populationLabel.Size = new Size(150, 30);
			this.populationLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.populationLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.populationLabel.Color = global::ARGBColors.Black;
			this.populationLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.populationLabel);
			this.lowImage.Image = GFXLibrary.selector_square_normal;
			this.lowImage.Position = new Point(574, 270);
			this.backgroundArea.addControl(this.lowImage);
			this.lowLabel.Text = SK.Text("SelectVillagePopup_Low", "Low");
			this.lowLabel.Position = new Point(594, 270);
			this.lowLabel.Size = new Size(150, 30);
			this.lowLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.lowLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lowLabel.Color = global::ARGBColors.Black;
			this.lowLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.lowLabel);
			this.medImage.Image = GFXLibrary.selector_square_orange_normal;
			this.medImage.Position = new Point(574, 295);
			this.backgroundArea.addControl(this.medImage);
			this.medLabel.Text = SK.Text("SelectVillagePopup_Medium", "Medium");
			this.medLabel.Position = new Point(594, 295);
			this.medLabel.Size = new Size(150, 30);
			this.medLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.medLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.medLabel.Color = global::ARGBColors.Black;
			this.medLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.medLabel);
			this.highImage.Image = GFXLibrary.selector_square_red_normal;
			this.highImage.Position = new Point(574, 320);
			this.backgroundArea.addControl(this.highImage);
			this.highLabel.Text = SK.Text("SelectVillagePopup_High", "High");
			this.highLabel.Position = new Point(594, 320);
			this.highLabel.Size = new Size(150, 30);
			this.highLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.highLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.highLabel.Color = global::ARGBColors.Black;
			this.highLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.highLabel);
			if (GameEngine.Instance.World.WorldMapType == 16 || GameEngine.Instance.World.WorldMapType == 19 || GameEngine.Instance.World.WorldMapType == 23 || GameEngine.Instance.World.WorldMapType == 24)
			{
				int num2 = 0;
				if (GameEngine.Instance.World.WorldMapType == 19)
				{
					num2 = 13;
					this.btnLogout.Position = new Point(565 + num, 500 + num2);
					this.btnBack.Position = new Point(565 + num, 540 + num2);
				}
				this.btnEnterGame.Position = new Point(65 + num, 500 + num2);
				this.loadingLabel.Position = new Point(this.btnEnterGame.Position.X + this.btnEnterGame.Width / 2 - 100, this.btnEnterGame.Position.Y + 50 + num2);
				this.populationLabel.Position = new Point(324 + num, 500 + num2);
				this.lowImage.Position = new Point(324 + num, 525 + num2);
				this.lowLabel.Position = new Point(344 + num, 525 + num2);
				this.medImage.Position = new Point(324 + num, 550 + num2);
				this.medLabel.Position = new Point(344 + num, 550 + num2);
				this.highImage.Position = new Point(324 + num, 575 + num2);
				this.highLabel.Position = new Point(344 + num, 575 + num2);
			}
			RemoteServices.Instance.set_GetVillageStartLocations_UserCallBack(new RemoteServices.GetVillageStartLocations_UserCallBack(this.GetVillageStartLocationsCallback));
			RemoteServices.Instance.GetVillageStartLocations();
			if (tryingToJoinCounty >= 0)
			{
				this.closePopup();
				this.m_popup = new JoiningWorldPopup();
				this.m_popup.init(tryingToJoinCounty, "");
				this.m_popup.Show(this);
				this.btnEnterGame.Enabled = false;
				this.delayedRetry = DateTime.Now.AddSeconds(-25.0);
				GameEngine.Instance.tryingToJoinCounty = -2;
			}
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x001A4784 File Offset: 0x001A2984
		private void logoutClick()
		{
			GameEngine.Instance.playInterfaceSound("SelectVillageAreaPopup_logout");
			this.m_parent.closing = true;
			GameEngine.Instance.closeNoVillagePopup(false);
			LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x001A47E8 File Offset: 0x001A29E8
		private void btnEnterGame_Click()
		{
			if (this.selectedCounty >= 0)
			{
				GameEngine.Instance.playInterfaceSound("SelectVillageAreaPopup_enter_game");
				this.closePopup();
				this.m_popup = new JoiningWorldPopup();
				this.m_popup.init(this.selectedCounty, "");
				this.m_popup.Show(this);
				this.btnEnterGame.Enabled = false;
				this.retries = 0;
				RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
				RemoteServices.Instance.SetStartingCounty(this.selectedCounty);
			}
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x0001A916 File Offset: 0x00018B16
		public void closePopup()
		{
			if (this.m_popup != null)
			{
				this.m_popup.Close();
				this.m_popup = null;
			}
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x001A487C File Offset: 0x001A2A7C
		public void update()
		{
			if (this.delayedRetry != DateTime.MinValue && (DateTime.Now - this.delayedRetry).TotalSeconds > 30.0)
			{
				this.delayedRetry = DateTime.MinValue;
				RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
				RemoteServices.Instance.SetStartingCounty(-1);
			}
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x0001A932 File Offset: 0x00018B32
		public void GetVillageStartLocationsCallback(GetVillageStartLocations_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingLabel.Visible = false;
				this.importCounties(returnData.availableCounties);
			}
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x001A48EC File Offset: 0x001A2AEC
		private void importCounties(List<int> counties)
		{
			this.selectedCounty = -1;
			if (counties == null)
			{
				return;
			}
			this.mapImage.clearControls();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < counties.Count; j += 4)
				{
					int num = counties[j];
					int num2 = counties[j + 1];
					int num3 = counties[j + 2];
					int num4 = counties[j + 3];
					Point countyMarkerLocation = GameEngine.Instance.World.getCountyMarkerLocation(num);
					if (num2 == -1000)
					{
						if (i == 0)
						{
							CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
							csdimage.Image = GFXLibrary.selector_square_red_normal;
							csdimage.Size = new Size(csdimage.Size.Width / 2, csdimage.Size.Height / 2);
							csdimage.CustomTooltipID = 1101;
							csdimage.Position = new Point((int)((float)countyMarkerLocation.X / this.divider) - 4, (int)((float)countyMarkerLocation.Y / this.divider) - 4);
							csdimage.Colorise = Color.FromArgb(255, 128, 128, 128);
							this.mapImage.addControl(csdimage);
						}
					}
					else if (i == 1)
					{
						CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
						csdbutton.Position = new Point((int)((float)countyMarkerLocation.X / this.divider) - 8, (int)((float)countyMarkerLocation.Y / this.divider) - 8);
						csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconOver_Click));
						csdbutton.Data = num;
						csdbutton.CustomTooltipID = 1100;
						this.mapImage.addControl(csdbutton);
						if (num2 > num3 / 2)
						{
							csdbutton.ImageNorm = GFXLibrary.selector_square_normal;
							csdbutton.ImageOver = GFXLibrary.selector_square_over;
							csdbutton.ImageClick = GFXLibrary.selector_square_pressed;
						}
						else if (num2 > num3 / 7)
						{
							csdbutton.ImageNorm = GFXLibrary.selector_square_orange_normal;
							csdbutton.ImageOver = GFXLibrary.selector_square_orange_over;
							csdbutton.ImageClick = GFXLibrary.selector_square_orange_pressed;
						}
						else
						{
							csdbutton.ImageNorm = GFXLibrary.selector_square_red_normal;
							csdbutton.ImageOver = GFXLibrary.selector_square_red_over;
							csdbutton.ImageClick = GFXLibrary.selector_square_red_pressed;
						}
						if (this.smallButtons)
						{
							csdbutton.Position = new Point((int)((float)countyMarkerLocation.X / this.divider) - 4, (int)((float)countyMarkerLocation.Y / this.divider) - 4);
							csdbutton.Size = new Size(csdbutton.Size.Width / 2, csdbutton.Size.Height / 2);
						}
					}
				}
			}
			this.mapImage.invalidate();
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x001A4BC8 File Offset: 0x001A2DC8
		private void iconOver_Click()
		{
			GameEngine.Instance.playInterfaceSound("SelectVillageAreaPopup_select_county");
			if (this.m_popup != null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			if (csdbutton != null)
			{
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.mapImage.Controls)
				{
					if (csdcontrol.GetType() == typeof(CustomSelfDrawPanel.CSDButton))
					{
						CustomSelfDrawPanel.CSDButton csdbutton2 = (CustomSelfDrawPanel.CSDButton)csdcontrol;
						if (object.ReferenceEquals(csdbutton2.ImageClick, GFXLibrary.selector_square_pressed))
						{
							csdbutton2.ImageNorm = GFXLibrary.selector_square_normal;
							csdbutton2.ImageOver = GFXLibrary.selector_square_over;
						}
						else if (object.ReferenceEquals(csdbutton2.ImageClick, GFXLibrary.selector_square_orange_pressed))
						{
							csdbutton2.ImageNorm = GFXLibrary.selector_square_orange_normal;
							csdbutton2.ImageOver = GFXLibrary.selector_square_orange_over;
						}
						else if (object.ReferenceEquals(csdbutton2.ImageClick, GFXLibrary.selector_square_red_pressed))
						{
							csdbutton2.ImageNorm = GFXLibrary.selector_square_red_normal;
							csdbutton2.ImageOver = GFXLibrary.selector_square_red_over;
						}
						if (this.smallButtons)
						{
							csdbutton2.Size = new Size(csdbutton2.Size.Width / 2, csdbutton2.Size.Height / 2);
						}
					}
				}
				if (object.ReferenceEquals(csdbutton.ImageClick, GFXLibrary.selector_square_pressed))
				{
					csdbutton.ImageNorm = GFXLibrary.selector_square_pressed;
					csdbutton.ImageOver = GFXLibrary.selector_square_pressed;
				}
				else if (object.ReferenceEquals(csdbutton.ImageClick, GFXLibrary.selector_square_orange_pressed))
				{
					csdbutton.ImageNorm = GFXLibrary.selector_square_orange_pressed;
					csdbutton.ImageOver = GFXLibrary.selector_square_orange_pressed;
				}
				else if (object.ReferenceEquals(csdbutton.ImageClick, GFXLibrary.selector_square_red_pressed))
				{
					csdbutton.ImageNorm = GFXLibrary.selector_square_red_pressed;
					csdbutton.ImageOver = GFXLibrary.selector_square_red_pressed;
				}
				if (this.smallButtons)
				{
					csdbutton.Size = new Size(csdbutton.Size.Width / 2, csdbutton.Size.Height / 2);
				}
				this.selectedCounty = csdbutton.Data;
				this.btnEnterGame.Enabled = true;
				this.loadingLabel.Text = GameEngine.Instance.World.getCountyName(this.selectedCounty);
				this.loadingLabel.Visible = true;
				this.mapImage.invalidate();
			}
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x001A4E60 File Offset: 0x001A3060
		private void SetStartingCountyCallback(SetStartingCounty_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.availableCounties != null)
			{
				bool flag = false;
				for (int i = 0; i < returnData.availableCounties.Count; i += 4)
				{
					if (returnData.availableCounties[i] == this.selectedCounty)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.retries++;
					if (this.retries < 2)
					{
						Thread.Sleep(2000);
						RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
						RemoteServices.Instance.SetStartingCounty(this.selectedCounty);
						return;
					}
				}
				this.importCounties(returnData.availableCounties);
				this.btnEnterGame.Enabled = true;
				this.closePopup();
				MyMessageBox.Show(SK.Text("SelectVillageAreaPopup_Village_Placement_Error_Message", "The server failed to find you a village, please try again."), SK.Text("SelectVillageAreaPopup_Village_Placement_Error", "Village Placement Error"));
				return;
			}
			if (returnData.villageID >= 0)
			{
				GameEngine.Instance.World.setVillageName(returnData.villageID, returnData.villageName);
				GameEngine.Instance.World.addUserVillage(returnData.villageID);
				GameEngine.Instance.World.updateWorldMapOwnership();
				this.m_parent.closing = true;
				GameEngine.Instance.closeNoVillagePopup(true);
				GameEngine.Instance.World.setResearchData(returnData.m_researchData);
				InterfaceMgr.Instance.selectUserVillage(returnData.villageID, false);
				return;
			}
			this.delayedRetry = DateTime.Now;
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x0001A954 File Offset: 0x00018B54
		private void btnBack_Click()
		{
			GameEngine.Instance.playInterfaceSound("SelectVillageAreaPopup_back");
			this.m_parent.closing = true;
			this.closePopup();
			GameEngine.Instance.closeNoVillagePopup(false);
			GameEngine.Instance.openSimpleSelectVillage();
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x0001A98C File Offset: 0x00018B8C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x001A4FD0 File Offset: 0x001A31D0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "NewSelectVillageAreaPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x04002B59 RID: 11097
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002B5A RID: 11098
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002B5B RID: 11099
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002B5C RID: 11100
		private CustomSelfDrawPanel.CSDImage mapImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B5D RID: 11101
		private CustomSelfDrawPanel.CSDRectangle mapBorder = new CustomSelfDrawPanel.CSDRectangle();

		// Token: 0x04002B5E RID: 11102
		private CustomSelfDrawPanel.CSDButton btnEnterGame = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B5F RID: 11103
		private CustomSelfDrawPanel.CSDButton btnBack = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B60 RID: 11104
		private CustomSelfDrawPanel.CSDButton btnLogout = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B61 RID: 11105
		private CustomSelfDrawPanel.CSDLabel loadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B62 RID: 11106
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B63 RID: 11107
		private CustomSelfDrawPanel.CSDLabel lostMessageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B64 RID: 11108
		private CustomSelfDrawPanel.CSDImage lowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B65 RID: 11109
		private CustomSelfDrawPanel.CSDImage medImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B66 RID: 11110
		private CustomSelfDrawPanel.CSDImage highImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B67 RID: 11111
		private CustomSelfDrawPanel.CSDLabel populationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B68 RID: 11112
		private CustomSelfDrawPanel.CSDLabel lowLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B69 RID: 11113
		private CustomSelfDrawPanel.CSDLabel medLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B6A RID: 11114
		private CustomSelfDrawPanel.CSDLabel highLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B6B RID: 11115
		private float divider = 5f;

		// Token: 0x04002B6C RID: 11116
		private NewSelectVillageAreaWindow m_parent;

		// Token: 0x04002B6D RID: 11117
		private bool smallButtons;

		// Token: 0x04002B6E RID: 11118
		private int selectedCounty = -1;

		// Token: 0x04002B6F RID: 11119
		private JoiningWorldPopup m_popup;

		// Token: 0x04002B70 RID: 11120
		private int retries;

		// Token: 0x04002B71 RID: 11121
		private DateTime delayedRetry = DateTime.MinValue;

		// Token: 0x04002B72 RID: 11122
		private IContainer components;
	}
}
