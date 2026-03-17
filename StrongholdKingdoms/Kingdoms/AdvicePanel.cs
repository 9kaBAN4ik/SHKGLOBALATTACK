using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000BA RID: 186
	public class AdvicePanel : CustomSelfDrawPanel
	{
		// Token: 0x06000520 RID: 1312 RVA: 0x0000ABAE File Offset: 0x00008DAE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000ABCD File Offset: 0x00008DCD
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00062D24 File Offset: 0x00060F24
		public AdvicePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00062DA4 File Offset: 0x00060FA4
		public void init(Form parent, int screenID)
		{
			this.m_parent = parent;
			this.m_screenID = screenID;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Alpha = 0.8f;
			base.addControl(this.mainBackgroundImage);
			this.overlayImage.Position = new Point(0, 0);
			this.overlayImage.Size = this.mainBackgroundImage.Size;
			this.overlayImage.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.overlayImage.Alpha = 0.8f;
			this.closeButton.ImageNorm = GFXLibrary.button_132_normal;
			this.closeButton.ImageOver = GFXLibrary.button_132_over;
			this.closeButton.ImageClick = GFXLibrary.button_132_in;
			this.closeButton.setSizeToImage();
			this.closeButton.Position = new Point(this.overlayImage.Width / 2 - this.closeButton.Width / 2, this.overlayImage.Rectangle.Bottom - 40 - this.closeButton.Height / 2);
			this.closeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.closeButton.TextYOffset = -2;
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			this.closeButton.Enabled = true;
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.overlayImage.addControl(this.closeButton);
			this.enableCheckbox.CheckedImage = GFXLibrary.checkbox_checked;
			this.enableCheckbox.UncheckedImage = GFXLibrary.checkbox_unchecked;
			this.enableCheckbox.setSizeToImage();
			this.enableCheckbox.Position = new Point(15, this.overlayImage.Height - this.enableCheckbox.Height - 15);
			this.enableCheckbox.Checked = Program.mySettings.adviceEnabled;
			this.enableCheckbox.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.enableClick));
			this.overlayImage.addControl(this.enableCheckbox);
			this.disableLabel.Text = SK.Text("TIPS_disable", "Show tips in future");
			this.disableLabel.Position = new Point(this.enableCheckbox.Rectangle.Right, this.enableCheckbox.Y);
			this.disableLabel.Size = new Size(200, this.enableCheckbox.Height);
			this.disableLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.disableLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.disableLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.disableLabel);
			this.titleLabel.Position = new Point(0, 20);
			this.titleLabel.Size = new Size(this.overlayImage.Width, 40);
			this.titleLabel.Font = FontManager.GetFont("Arial", 25f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.titleLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.titleLabel);
			this.contentLabel.Position = new Point(40, this.titleLabel.Rectangle.Bottom);
			this.contentLabel.Size = new Size(this.overlayImage.Width - 80, 140);
			this.contentLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.contentLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.contentLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.contentLabel);
			this.wikiButton.ImageNorm = GFXLibrary.button_132_normal;
			this.wikiButton.ImageOver = GFXLibrary.button_132_over;
			this.wikiButton.ImageClick = GFXLibrary.button_132_in;
			this.wikiButton.setSizeToImage();
			this.wikiButton.Position = new Point(this.overlayImage.Width / 2 - this.wikiButton.Width / 2, this.closeButton.Y - this.wikiButton.Height - 15);
			this.wikiButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.wikiButton.TextYOffset = -2;
			this.wikiButton.Text.Color = global::ARGBColors.Black;
			this.wikiButton.Enabled = true;
			this.wikiButton.Text.Text = SK.Text("GENERIC_Open_Wiki", "Open Wiki");
			this.wikiButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.wikiClick));
			this.overlayImage.addControl(this.wikiButton);
			this.titleLabel.Text = AdvicePanel.getAdviceHeader(this.m_screenID);
			this.contentLabel.Text = AdvicePanel.getAdviceContent(this.m_screenID);
			base.Invalidate();
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000ABE1 File Offset: 0x00008DE1
		private void closeClick()
		{
			InterfaceMgr.Instance.closeAdvicePopup();
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0000ABED File Offset: 0x00008DED
		private void wikiClick()
		{
			CustomSelfDrawPanel.WikiLinkControl.openWikiPage(this.m_screenID);
			this.closeClick();
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000AC00 File Offset: 0x00008E00
		private void enableClick()
		{
			Program.mySettings.adviceEnabled = this.enableCheckbox.Checked;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000633C0 File Offset: 0x000615C0
		public static bool usesAdvicePanel(int screenID)
		{
			switch (screenID)
			{
			case 7:
			case 8:
			case 14:
			case 15:
			case 17:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
				return true;
			}
			return false;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00063424 File Offset: 0x00061624
		public static string getAdviceHeader(int screenID)
		{
			switch (screenID)
			{
			case 7:
				return SK.Text("ADVICE_Header_Banquet", "Banquets");
			case 8:
				return SK.Text("ADVICE_Header_Vassals", "Vassals");
			case 9:
				return SK.Text("ADVICE_Header_Capital", "Capital Village");
			case 14:
				return SK.Text("ADVICE_Header_Wall", "Parishes and Capitals");
			case 15:
				return SK.Text("ADVICE_Header_Vote", "Voting");
			case 17:
				return SK.Text("ADVICE_Header_Research", "Research");
			case 19:
				return SK.Text("ADVICE_Header_Quests", "Quests");
			case 20:
				return SK.Text("ADVICE_Header_Attacks", "Attacks");
			case 21:
				return SK.Text("ADVICE_Header_Reports", "Reports");
			case 22:
				return SK.Text("ADVICE_Header_Glory", "The Glory Race");
			case 23:
				return SK.Text("ADVICE_Header_Faction", "Factions");
			case 24:
				return SK.Text("ADVICE_Header_Houses", "Houses");
			}
			return string.Empty;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0006354C File Offset: 0x0006174C
		public static string getAdviceContent(int screenID)
		{
			switch (screenID)
			{
			case 7:
				return SK.Text("ADVICE_Content_Banquet", "Hold banquets to receive significant boosts to your honour. Research new resources to hold more opulent banquets and multiply the amount of honour received.");
			case 8:
				return SK.Text("ADVICE_Content_Vassals", "Become another player's vassal to make them your Liege Lord. Receive extra honour in exchange for allowing them to station troops in your castle. Alternatively become a Liege Lord yourself, allowing you to launch attacks from your vassals' villages and strengthen their defences.");
			case 9:
				return "...";
			case 14:
				return SK.Text("ADVICE_Content_Capitals", "Every village is part of a parish, with an elected parish steward. The parish wall allows the parish members to discuss local issues. Parishes are grouped into counties, provinces and countries.");
			case 15:
				return SK.Text("ADVICE_Content_Vote", "Any player of rank Peasant (4) or higher can vote in elections to decide the leader of their parish. This elected leader is then responsible for maintaining the capital's village and castle, and for setting taxes.");
			case 17:
				return SK.Text("ADVICE_Content_Research", "Use research points to research new technologies, in order to gain access to new resources, buildings, weapons, military units and strategies. Research points can be gained by increasing your rank, purchased with gold, or via strategy cards.");
			case 19:
				return SK.Text("ADVICE_Content_Quests", "Quests are a great way to earn a wide variety of rewards for completing simple tasks that also teach about the game. Select an available quest and on completion new quests will be unlocked.");
			case 20:
				return SK.Text("ADVICE_Content_Attacks", "Here you can view a summary of all your armies currently marching towards battle, as well as your enemies' incoming attacks against your castles. You can also view any scouts, traders, monks or reinforcements currently on the move.");
			case 21:
				return SK.Text("ADVICE_Content_Reports", "Reports are a record of all battles against your enemies as well as major events that affect you and your villages.");
			case 22:
				return SK.Text("ADVICE_Content_Glory", "Houses are an alliance of factions combining their military and political might in a battle to control the world. The Glory Race is a series of glory rounds where houses compete to acquire glory points. When the glory race is won, the members of the winning house are immortalised in the Hall of Heroes.");
			case 23:
				return SK.Text("ADVICE_Content_Factions", "A faction is a collection of players working together for a common cause. Any player with the rank of Bondsman (7) or higher can join a faction, either by applying directly to an open faction, or by being invited by a faction officer.");
			case 24:
				return SK.Text("ADVICE_Content_Houses", "To take part in the glory race, factions need to apply to join a house. Factions already within the house then vote to decide whether to accept or reject the new faction. Each house is presided over by an elected house marshall.");
			}
			return string.Empty;
		}

		// Token: 0x040005F1 RID: 1521
		private IContainer components;

		// Token: 0x040005F2 RID: 1522
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040005F3 RID: 1523
		private CustomSelfDrawPanel.CSDExtendingPanel overlayImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040005F4 RID: 1524
		private CustomSelfDrawPanel.CSDCheckBox enableCheckbox = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040005F5 RID: 1525
		private CustomSelfDrawPanel.CSDLabel disableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005F6 RID: 1526
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005F7 RID: 1527
		private CustomSelfDrawPanel.CSDLabel contentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005F8 RID: 1528
		private CustomSelfDrawPanel.CSDButton wikiButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005F9 RID: 1529
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005FA RID: 1530
		private Form m_parent;

		// Token: 0x040005FB RID: 1531
		private int m_screenID;
	}
}
