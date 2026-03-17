using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002A1 RID: 673
	public class ProvinceFrontPagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001E53 RID: 7763 RVA: 0x0001CFFA File Offset: 0x0001B1FA
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x0001D00A File Offset: 0x0001B20A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0001D01A File Offset: 0x0001B21A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001E56 RID: 7766 RVA: 0x0001D02C File Offset: 0x0001B22C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001E57 RID: 7767 RVA: 0x0001D039 File Offset: 0x0001B239
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06001E58 RID: 7768 RVA: 0x0001D04D File Offset: 0x0001B24D
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x0001D05A File Offset: 0x0001B25A
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x0001D067 File Offset: 0x0001B267
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x001D4440 File Offset: 0x001D2640
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
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "ProvinceFrontPagePanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x001D452C File Offset: 0x001D272C
		public ProvinceFrontPagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001E5D RID: 7773 RVA: 0x001D4664 File Offset: 0x001D2864
		public void init()
		{
			int height = base.Height;
			ProvinceFrontPagePanel2.instance = this;
			base.clearControls();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int provinceFromVillageID = GameEngine.Instance.World.getProvinceFromVillageID(selectedMenuVillage);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 14, new Point(base.Width - 44, 3));
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.parishNameLabel.Text = string.Concat(new string[]
			{
				SK.Text("GENERIC_Province", "Province"),
				" : ",
				GameEngine.Instance.World.getProvinceName(provinceFromVillageID),
				" (",
				GameEngine.Instance.World.getVillageName(selectedMenuVillage),
				")"
			});
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.windowImage.Size = new Size(400, 150);
			this.windowImage.Position = new Point(493, 130);
			this.backgroundImage.addControl(this.windowImage);
			this.windowImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.sheriffLabel.Text = SK.Text("Provinces_Current_Governor", "Current Governor");
			this.sheriffLabel.Position = new Point(30, 26);
			this.sheriffLabel.Size = new Size(250, 40);
			this.sheriffLabel.Color = global::ARGBColors.Black;
			this.sheriffLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.sheriffLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.sheriffLabel);
			this.goldLabel.Text = SK.Text("GENERIC_Current_Gold", "Current Gold");
			this.goldLabel.Position = new Point(30, 66);
			this.goldLabel.Size = new Size(250, 40);
			this.goldLabel.Color = global::ARGBColors.Black;
			this.goldLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.goldLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.goldLabel);
			this.taxLabel.Text = SK.Text("GENERIC_Tax_Rate", "Tax Rate");
			this.taxLabel.Position = new Point(30, 106);
			this.taxLabel.Size = new Size(250, 40);
			this.taxLabel.Color = global::ARGBColors.Black;
			this.taxLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.taxLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.taxLabel);
			this.sheriffName.Text = "";
			this.sheriffName.Position = new Point(170, 26);
			this.sheriffName.Size = new Size(200, 40);
			this.sheriffName.Color = global::ARGBColors.Black;
			this.sheriffName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.sheriffName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.sheriffName);
			this.goldValue.Text = "";
			this.goldValue.Position = new Point(170, 66);
			this.goldValue.Size = new Size(200, 40);
			this.goldValue.Color = global::ARGBColors.Black;
			this.goldValue.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.goldValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.goldValue);
			this.taxValue.Text = "";
			this.taxValue.Position = new Point(170, 106);
			this.taxValue.Size = new Size(200, 40);
			this.taxValue.Color = global::ARGBColors.Black;
			this.taxValue.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.taxValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.taxValue);
			this.activityLabel.Text = SK.Text("WALL_recent_activity", "Recent Activity");
			this.activityLabel.Position = new Point(8, -16);
			this.activityLabel.Size = new Size(388, 40);
			this.activityLabel.Color = global::ARGBColors.Black;
			this.activityLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.activityLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.backgroundImage.addControl(this.activityLabel);
			this.wallInfoImage.Size = new Size(396, height - 80);
			this.wallInfoImage.Position = new Point(8, 29);
			this.backgroundImage.addControl(this.wallInfoImage);
			this.wallInfoImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.wallScrollArea.Position = new Point(15, 15);
			this.wallScrollArea.Size = new Size(337, height - 101);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(337, height - 101));
			this.wallInfoImage.addControl(this.wallScrollArea);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(358, 15);
			this.wallScrollBar.Size = new Size(24, height - 101);
			this.wallInfoImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			ProvinceFrontPagePanel2.StoredProvinceInfo storedProvinceInfo = (ProvinceFrontPagePanel2.StoredProvinceInfo)this.provinceList[provinceFromVillageID];
			bool flag = false;
			if (storedProvinceInfo == null || (DateTime.Now - storedProvinceInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedProvinceInfo.lastReturnData == null)
			{
				flag = true;
			}
			this.m_currentVillage = selectedMenuVillage;
			if (this.currentProvince != provinceFromVillageID)
			{
				this.currentLeaderID = -1;
				this.currentLeaderName = "";
				this.m_userIDOnCurrent = -1;
			}
			this.currentProvince = provinceFromVillageID;
			if (flag)
			{
				RemoteServices.Instance.set_GetProvinceFrontPageInfo_UserCallBack(new RemoteServices.GetProvinceFrontPageInfo_UserCallBack(this.getProvinceFrontPageInfoCallback));
				RemoteServices.Instance.GetProvinceFrontPageInfo(this.m_currentVillage);
			}
			this.updateLeaderInfo();
			if (!flag)
			{
				this.getProvinceFrontPageInfoCallback(storedProvinceInfo.lastReturnData);
			}
			this.btnChat.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.btnChat.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.btnChat.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.btnChat.Position = new Point(base.Width - 230, base.Height - 90);
			this.btnChat.Text.Text = SK.Text("GENERIC_Chat", "Chat");
			this.btnChat.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnChat.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnChat.TextYOffset = -3;
			this.btnChat.Text.Color = global::ARGBColors.Black;
			this.btnChat.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.chatClick), "ProvinceFrontPagePanel2_chat");
			this.backgroundImage.addControl(this.btnChat);
		}

		// Token: 0x06001E5E RID: 7774 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06001E5F RID: 7775 RVA: 0x0001D086 File Offset: 0x0001B286
		public void logout()
		{
			this.provinceList.Clear();
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x0001D093 File Offset: 0x0001B293
		private void chatClick()
		{
			if (this.currentProvince >= 0)
			{
				InterfaceMgr.Instance.initChatPanel(1, this.currentProvince);
			}
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x0001D0AF File Offset: 0x0001B2AF
		public void updateLeaderInfo()
		{
			this.sheriffName.Text = this.currentLeaderName;
			this.m_userIDOnCurrent = this.currentLeaderID;
			this.update();
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x001D5094 File Offset: 0x001D3294
		public void getProvinceFrontPageInfoCallback(GetProvinceFrontPageInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			ProvinceFrontPagePanel2.StoredProvinceInfo storedProvinceInfo = (ProvinceFrontPagePanel2.StoredProvinceInfo)this.provinceList[returnData.provinceID];
			if (storedProvinceInfo == null)
			{
				storedProvinceInfo = new ProvinceFrontPagePanel2.StoredProvinceInfo();
				this.provinceList[returnData.provinceID] = storedProvinceInfo;
			}
			storedProvinceInfo.m_lastUpdateTime = DateTime.Now;
			storedProvinceInfo.lastReturnData = returnData;
			if (this.currentProvince == returnData.provinceID)
			{
				this.m_userIDOnCurrent = -1;
				this.currentLeaderID = returnData.leaderID;
				this.currentLeaderName = returnData.leaderName;
				this.updateLeaderInfo();
				NumberFormatInfo nfi = GameEngine.NFI;
				switch (returnData.taxRate)
				{
				case 0:
					this.taxValue.Text = "0";
					break;
				case 1:
					this.taxValue.Text = "x1";
					break;
				case 2:
					this.taxValue.Text = "x2";
					break;
				case 3:
					this.taxValue.Text = "x3";
					break;
				case 4:
					this.taxValue.Text = "x4";
					break;
				case 5:
					this.taxValue.Text = "x5";
					break;
				case 6:
					this.taxValue.Text = "x6";
					break;
				case 7:
					this.taxValue.Text = "x7";
					break;
				case 8:
					this.taxValue.Text = "x8";
					break;
				case 9:
					this.taxValue.Text = "x9";
					break;
				}
				this.goldValue.Text = returnData.gold.ToString("N", nfi);
				this.createParishWall(returnData.provinceWallInfo);
			}
		}

		// Token: 0x06001E63 RID: 7779 RVA: 0x001D5244 File Offset: 0x001D3444
		private void createParishWall(WallInfo[] wallInfos)
		{
			this.origWallInfo = wallInfos;
			List<WallInfo> list = new List<WallInfo>();
			this.wallList.Clear();
			foreach (WallInfo wallInfo in wallInfos)
			{
				if (wallInfo.entryType == 1)
				{
					bool flag = false;
					foreach (WallInfo wallInfo2 in list)
					{
						if (wallInfo2.userID == wallInfo.userID)
						{
							flag = true;
							wallInfo2.fData1 += wallInfo.fData1;
							wallInfo2.data4 += wallInfo.data4;
						}
					}
					if (!flag)
					{
						WallInfo wallInfo3 = new WallInfo();
						wallInfo3.data1 = wallInfo.data1;
						wallInfo3.data2 = wallInfo.data2;
						wallInfo3.data3 = wallInfo.data3;
						wallInfo3.data4 = wallInfo.data4;
						wallInfo3.fData1 = wallInfo.fData1;
						wallInfo3.entryType = wallInfo.entryType;
						wallInfo3.userID = wallInfo.userID;
						wallInfo3.username = wallInfo.username;
						list.Add(wallInfo3);
						this.wallList.Add(wallInfo3);
					}
				}
				else
				{
					this.wallList.Add(wallInfo);
				}
			}
			this.updateWallArea();
		}

		// Token: 0x06001E64 RID: 7780 RVA: 0x001D53A8 File Offset: 0x001D35A8
		public void updateWallArea()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			foreach (WallInfo wallInfo in this.wallList)
			{
				CustomSelfDrawPanel.ParishWallEntry parishWallEntry = new CustomSelfDrawPanel.ParishWallEntry();
				if (num != 0)
				{
					num += 5;
				}
				parishWallEntry.Position = new Point(0, num);
				parishWallEntry.init(wallInfo, num2, this.m_currentVillage, this);
				this.wallScrollArea.addControl(parishWallEntry);
				num += parishWallEntry.Height;
				this.lineList.Add(parishWallEntry);
				num2++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num - this.wallScrollBar.Height;
			}
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001E65 RID: 7781 RVA: 0x001D54EC File Offset: 0x001D36EC
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 15 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x04002EFB RID: 12027
		private DockableControl dockableControl;

		// Token: 0x04002EFC RID: 12028
		private IContainer components;

		// Token: 0x04002EFD RID: 12029
		private Panel focusPanel;

		// Token: 0x04002EFE RID: 12030
		public static ProvinceFrontPagePanel2 instance;

		// Token: 0x04002EFF RID: 12031
		private SparseArray provinceList = new SparseArray();

		// Token: 0x04002F00 RID: 12032
		private int currentProvince = -1;

		// Token: 0x04002F01 RID: 12033
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x04002F02 RID: 12034
		private int currentLeaderID = -1;

		// Token: 0x04002F03 RID: 12035
		private string currentLeaderName = "";

		// Token: 0x04002F04 RID: 12036
		private int m_userIDOnCurrent = -1;

		// Token: 0x04002F05 RID: 12037
		private int m_currentVillage = -1;

		// Token: 0x04002F06 RID: 12038
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F07 RID: 12039
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002F08 RID: 12040
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002F09 RID: 12041
		private CustomSelfDrawPanel.CSDLabel activityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F0A RID: 12042
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002F0B RID: 12043
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F0C RID: 12044
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F0D RID: 12045
		private CustomSelfDrawPanel.CSDExtendingPanel windowImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F0E RID: 12046
		private CustomSelfDrawPanel.CSDLabel sheriffLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F0F RID: 12047
		private CustomSelfDrawPanel.CSDLabel sheriffName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F10 RID: 12048
		private CustomSelfDrawPanel.CSDLabel goldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F11 RID: 12049
		private CustomSelfDrawPanel.CSDLabel goldValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F12 RID: 12050
		private CustomSelfDrawPanel.CSDLabel taxLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F13 RID: 12051
		private CustomSelfDrawPanel.CSDLabel taxValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F14 RID: 12052
		private CustomSelfDrawPanel.CSDButton btnChat = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002F15 RID: 12053
		private List<CustomSelfDrawPanel.ParishWallEntry> lineList = new List<CustomSelfDrawPanel.ParishWallEntry>();

		// Token: 0x04002F16 RID: 12054
		private WallInfo[] origWallInfo;

		// Token: 0x04002F17 RID: 12055
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x020002A2 RID: 674
		public class StoredProvinceInfo
		{
			// Token: 0x04002F18 RID: 12056
			public GetProvinceFrontPageInfo_ReturnType lastReturnData;

			// Token: 0x04002F19 RID: 12057
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}
	}
}
