using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000525 RID: 1317
	public class WorldsEndPanel : CustomSelfDrawPanel
	{
		// Token: 0x060033CF RID: 13263 RVA: 0x002ABCD4 File Offset: 0x002A9ED4
		public WorldsEndPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060033D0 RID: 13264 RVA: 0x002ABF40 File Offset: 0x002AA140
		public void init(WorldsEndWindow parent)
		{
			int num = 25;
			int num2 = 22;
			int num3 = 30;
			int x = 200;
			int x2 = 350;
			int width = 150;
			this.m_parent = parent;
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			this.background.Position = new Point(0, 70);
			this.background.Size = new Size(base.Width, 446);
			base.addControl(this.background);
			this.background.Create(GFXLibrary._9sclice_fancy_top_left, GFXLibrary._9sclice_fancy_top_mid, GFXLibrary._9sclice_fancy_top_right, GFXLibrary._9sclice_fancy_mid_left, GFXLibrary._9sclice_fancy_mid_mid, GFXLibrary._9sclice_fancy_mid_right, GFXLibrary._9sclice_fancy_bottom_left, GFXLibrary._9sclice_fancy_bottom_mid, GFXLibrary._9sclice_fancy_bottom_right);
			this.background.ForceTiling();
			this.topImage.Image = GFXLibrary._9sclice_fancy_top_mid_over_01;
			this.topImage.Position = new Point((base.Width - this.topImage.Image.Width) / 2, 0);
			base.addControl(this.topImage);
			this.bottomImage.Image = GFXLibrary._9sclice_fancy_bottom_mid_over;
			this.bottomImage.Position = new Point((base.Width - this.bottomImage.Image.Width) / 2, base.Height - this.bottomImage.Image.Height - 5);
			base.addControl(this.bottomImage);
			this.backgroundArea.Position = new Point(171, 134);
			this.backgroundArea.Size = new Size(514, 340);
			base.addControl(this.backgroundArea);
			if (!GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.eowLogo.Image = GFXLibrary.age_seventh_age_x130;
				this.eowLogo.Position = new Point((this.backgroundArea.Width - this.eowLogo.Image.Width) / 2, -133);
				this.backgroundArea.addControl(this.eowLogo);
			}
			this.headerShield.Image = GameEngine.Instance.World.getWorldShield(RemoteServices.Instance.UserID, 25, 28);
			this.headerShield.Position = new Point(320, -10);
			this.backgroundArea.addControl(this.headerShield);
			this.headerGlobe.Image = GFXLibrary.eow_globe;
			this.headerGlobe.Position = new Point(470, -10);
			this.backgroundArea.addControl(this.headerGlobe);
			this.btnClose.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnClose.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnClose.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnClose.Position = new Point(260 - this.btnClose.ImageNorm.Width / 2, 327);
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.TextYOffset = -2;
			this.btnClose.Text.Color = global::ARGBColors.White;
			this.btnClose.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnClose.Text.Position = new Point(-3, 0);
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.logoutClick));
			this.btnClose.Enabled = true;
			this.backgroundArea.addControl(this.btnClose);
			this.endDateLabel.Text = SK.Text("EOW_WorldEnded", "World Ended on Day") + " : ";
			this.endDateLabel.Position = new Point(num3 - 10, -10);
			this.endDateLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
			this.endDateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.endDateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.endDateLabel.Color = global::ARGBColors.Red;
			this.endDateLabel.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.endDateLabel);
			this.endDateLabel2.Text = SK.Text("EOW_AtTime", "At Time") + " : ";
			this.endDateLabel2.Position = new Point(num3 - 10, 7);
			this.endDateLabel2.Size = new Size(this.backgroundArea.Width + 100, 150);
			this.endDateLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.endDateLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.endDateLabel2.Color = global::ARGBColors.Red;
			this.endDateLabel2.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.endDateLabel2);
			this.Entry1_name.Text = SK.Text("EOW_Stats_Captures", "Villages Captured");
			this.Entry1_name.Position = new Point(num3, num + num2 * 3);
			this.Entry1_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry1_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry1_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry1_name.Color = global::ARGBColors.Black;
			this.Entry1_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry1_name);
			this.Entry1_you.Text = "";
			this.Entry1_you.Position = new Point(x, num + num2 * 3);
			this.Entry1_you.Size = new Size(width, 20);
			this.Entry1_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry1_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry1_you.Color = global::ARGBColors.Black;
			this.Entry1_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry1_you);
			this.Entry1_all.Text = "";
			this.Entry1_all.Position = new Point(x2, num + num2 * 3);
			this.Entry1_all.Size = new Size(width, 20);
			this.Entry1_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry1_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry1_all.Color = global::ARGBColors.Black;
			this.Entry1_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry1_all);
			this.Entry2_name.Text = SK.Text("EOW_Stats_razes", "Villages Razed");
			this.Entry2_name.Position = new Point(num3, num + num2 * 4);
			this.Entry2_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry2_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry2_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry2_name.Color = global::ARGBColors.Black;
			this.Entry2_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry2_name);
			this.Entry2_you.Text = "";
			this.Entry2_you.Position = new Point(x, num + num2 * 4);
			this.Entry2_you.Size = new Size(width, 20);
			this.Entry2_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry2_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry2_you.Color = global::ARGBColors.Black;
			this.Entry2_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry2_you);
			this.Entry2_all.Text = "";
			this.Entry2_all.Position = new Point(x2, num + num2 * 4);
			this.Entry2_all.Size = new Size(width, 20);
			this.Entry2_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry2_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry2_all.Color = global::ARGBColors.Black;
			this.Entry2_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry2_all);
			this.Entry3_name.Text = SK.Text("EOW_Stats_trades", "Market Trades");
			this.Entry3_name.Position = new Point(num3, num + num2 * 11);
			this.Entry3_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry3_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry3_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry3_name.Color = global::ARGBColors.Black;
			this.Entry3_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry3_name);
			this.Entry3_you.Text = "";
			this.Entry3_you.Position = new Point(x, num + num2 * 11);
			this.Entry3_you.Size = new Size(width, 20);
			this.Entry3_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry3_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry3_you.Color = global::ARGBColors.Black;
			this.Entry3_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry3_you);
			this.Entry3_all.Text = "";
			this.Entry3_all.Position = new Point(x2, num + num2 * 11);
			this.Entry3_all.Size = new Size(width, 20);
			this.Entry3_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry3_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry3_all.Color = global::ARGBColors.Black;
			this.Entry3_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry3_all);
			this.Entry4_name.Text = SK.Text("EOW_Stats_transfers", "Supply Carts Sent");
			this.Entry4_name.Position = new Point(num3, num + num2 * 10);
			this.Entry4_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry4_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry4_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry4_name.Color = global::ARGBColors.Black;
			this.Entry4_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry4_name);
			this.Entry4_you.Text = "";
			this.Entry4_you.Position = new Point(x, num + num2 * 10);
			this.Entry4_you.Size = new Size(width, 20);
			this.Entry4_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry4_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry4_you.Color = global::ARGBColors.Black;
			this.Entry4_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry4_you);
			this.Entry4_all.Text = "";
			this.Entry4_all.Position = new Point(x2, num + num2 * 10);
			this.Entry4_all.Size = new Size(width, 20);
			this.Entry4_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry4_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry4_all.Color = global::ARGBColors.Black;
			this.Entry4_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry4_all);
			this.Entry5_name.Text = SK.Text("EOW_Stats_attacks", "Battles Fought");
			this.Entry5_name.Position = new Point(num3, num);
			this.Entry5_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry5_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry5_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry5_name.Color = global::ARGBColors.Black;
			this.Entry5_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry5_name);
			this.Entry5_you.Text = "";
			this.Entry5_you.Position = new Point(x, num);
			this.Entry5_you.Size = new Size(width, 20);
			this.Entry5_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry5_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry5_you.Color = global::ARGBColors.Black;
			this.Entry5_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry5_you);
			this.Entry5_all.Text = "";
			this.Entry5_all.Position = new Point(x2, num);
			this.Entry5_all.Size = new Size(width, 20);
			this.Entry5_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry5_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry5_all.Color = global::ARGBColors.Black;
			this.Entry5_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry5_all);
			this.Entry6_name.Text = SK.Text("EOW_Stats_scouts", "Scouts Sent");
			this.Entry6_name.Position = new Point(num3, num + num2);
			this.Entry6_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry6_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry6_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry6_name.Color = global::ARGBColors.Black;
			this.Entry6_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry6_name);
			this.Entry6_you.Text = "";
			this.Entry6_you.Position = new Point(x, num + num2);
			this.Entry6_you.Size = new Size(width, 20);
			this.Entry6_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry6_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry6_you.Color = global::ARGBColors.Black;
			this.Entry6_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry6_you);
			this.Entry6_all.Text = "";
			this.Entry6_all.Position = new Point(x2, num + num2);
			this.Entry6_all.Size = new Size(width, 20);
			this.Entry6_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry6_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry6_all.Color = global::ARGBColors.Black;
			this.Entry6_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry6_all);
			this.Entry7_name.Text = SK.Text("EOW_Stats_Pillaged", "Goods Pillaged");
			this.Entry7_name.Position = new Point(num3, num + num2 * 5);
			this.Entry7_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry7_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry7_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry7_name.Color = global::ARGBColors.Black;
			this.Entry7_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry7_name);
			this.Entry7_you.Text = "";
			this.Entry7_you.Position = new Point(x, num + num2 * 5);
			this.Entry7_you.Size = new Size(width, 20);
			this.Entry7_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry7_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry7_you.Color = global::ARGBColors.Black;
			this.Entry7_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry7_you);
			this.Entry7_all.Text = "";
			this.Entry7_all.Position = new Point(x2, num + num2 * 5);
			this.Entry7_all.Size = new Size(width, 20);
			this.Entry7_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry7_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry7_all.Color = global::ARGBColors.Black;
			this.Entry7_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry7_all);
			this.Entry8_name.Text = SK.Text("EOW_Stats_ransacked", "Buildings Ransacked");
			this.Entry8_name.Position = new Point(num3, num + num2 * 6);
			this.Entry8_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry8_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry8_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry8_name.Color = global::ARGBColors.Black;
			this.Entry8_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry8_name);
			this.Entry8_you.Text = "";
			this.Entry8_you.Position = new Point(x, num + num2 * 6);
			this.Entry8_you.Size = new Size(width, 20);
			this.Entry8_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry8_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry8_you.Color = global::ARGBColors.Black;
			this.Entry8_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry8_you);
			this.Entry8_all.Text = "";
			this.Entry8_all.Position = new Point(x2, num + num2 * 6);
			this.Entry8_all.Size = new Size(width, 20);
			this.Entry8_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry8_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry8_all.Color = global::ARGBColors.Black;
			this.Entry8_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry8_all);
			this.Entry9_name.Text = SK.Text("EOW_Stats_glory", "Glory Gained");
			this.Entry9_name.Position = new Point(num3, num + num2 * 2);
			this.Entry9_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry9_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry9_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry9_name.Color = global::ARGBColors.Black;
			this.Entry9_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry9_name);
			this.Entry9_you.Text = "";
			this.Entry9_you.Position = new Point(x, num + num2 * 2);
			this.Entry9_you.Size = new Size(width, 20);
			this.Entry9_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry9_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry9_you.Color = global::ARGBColors.Black;
			this.Entry9_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry9_you);
			this.Entry9_all.Text = "";
			this.Entry9_all.Position = new Point(x2, num + num2 * 2);
			this.Entry9_all.Size = new Size(width, 20);
			this.Entry9_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry9_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry9_all.Color = global::ARGBColors.Black;
			this.Entry9_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry9_all);
			this.Entry10_name.Text = SK.Text("EOW_Stats_wolves", "Wolves Killed");
			this.Entry10_name.Position = new Point(num3, num + num2 * 9);
			this.Entry10_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry10_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry10_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry10_name.Color = global::ARGBColors.Black;
			this.Entry10_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry10_name);
			this.Entry10_you.Text = "";
			this.Entry10_you.Position = new Point(x, num + num2 * 9);
			this.Entry10_you.Size = new Size(width, 20);
			this.Entry10_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry10_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry10_you.Color = global::ARGBColors.Black;
			this.Entry10_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry10_you);
			this.Entry10_all.Text = "";
			this.Entry10_all.Position = new Point(x2, num + num2 * 9);
			this.Entry10_all.Size = new Size(width, 20);
			this.Entry10_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry10_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry10_all.Color = global::ARGBColors.Black;
			this.Entry10_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry10_all);
			this.Entry11_name.Text = SK.Text("EOW_Stats_bandits", "Bandits Killed");
			this.Entry11_name.Position = new Point(num3, num + num2 * 8);
			this.Entry11_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry11_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry11_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry11_name.Color = global::ARGBColors.Black;
			this.Entry11_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry11_name);
			this.Entry11_you.Text = "";
			this.Entry11_you.Position = new Point(x, num + num2 * 8);
			this.Entry11_you.Size = new Size(width, 20);
			this.Entry11_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry11_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry11_you.Color = global::ARGBColors.Black;
			this.Entry11_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry11_you);
			this.Entry11_all.Text = "";
			this.Entry11_all.Position = new Point(x2, num + num2 * 8);
			this.Entry11_all.Size = new Size(width, 20);
			this.Entry11_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry11_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry11_all.Color = global::ARGBColors.Black;
			this.Entry11_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry11_all);
			this.Entry12_name.Text = SK.Text("EOW_Stats_AITroops", "AI Troops Killed");
			this.Entry12_name.Position = new Point(num3, num + num2 * 7);
			this.Entry12_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry12_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry12_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry12_name.Color = global::ARGBColors.Black;
			this.Entry12_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry12_name);
			this.Entry12_you.Text = "";
			this.Entry12_you.Position = new Point(x, num + num2 * 7);
			this.Entry12_you.Size = new Size(width, 20);
			this.Entry12_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry12_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry12_you.Color = global::ARGBColors.Black;
			this.Entry12_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry12_you);
			this.Entry12_all.Text = "";
			this.Entry12_all.Position = new Point(x2, num + num2 * 7);
			this.Entry12_all.Size = new Size(width, 20);
			this.Entry12_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry12_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry12_all.Color = global::ARGBColors.Black;
			this.Entry12_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry12_all);
			this.Entry13_name.Text = SK.Text("EOW_Stats_stashes", "Stashes Uncovered");
			this.Entry13_name.Position = new Point(num3, num + num2 * 12);
			this.Entry13_name.Size = new Size(this.backgroundArea.Width, 20);
			this.Entry13_name.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry13_name.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.Entry13_name.Color = global::ARGBColors.Black;
			this.Entry13_name.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry13_name);
			this.Entry13_you.Text = "";
			this.Entry13_you.Position = new Point(x, num + num2 * 12);
			this.Entry13_you.Size = new Size(width, 20);
			this.Entry13_you.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry13_you.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry13_you.Color = global::ARGBColors.Black;
			this.Entry13_you.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry13_you);
			this.Entry13_all.Text = "";
			this.Entry13_all.Position = new Point(x2, num + num2 * 12);
			this.Entry13_all.Size = new Size(width, 20);
			this.Entry13_all.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.Entry13_all.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.Entry13_all.Color = global::ARGBColors.Black;
			this.Entry13_all.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.Entry13_all);
			if (WorldsEndPanel.cachedData == null)
			{
				RemoteServices.Instance.set_EndOfTheWorldStats_UserCallBack(new RemoteServices.EndOfTheWorldStats_UserCallBack(this.endOfTheWorldCallback));
				RemoteServices.Instance.EndOfTheWorldStats();
				return;
			}
			this.showData();
		}

		// Token: 0x060033D1 RID: 13265 RVA: 0x000251B2 File Offset: 0x000233B2
		private void endOfTheWorldCallback(EndOfTheWorldStats_ReturnType returnData)
		{
			if (returnData.Success)
			{
				WorldsEndPanel.cachedData = returnData;
				this.showData();
			}
		}

		// Token: 0x060033D2 RID: 13266 RVA: 0x002ADC40 File Offset: 0x002ABE40
		private void showData()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			this.Entry1_you.Text = WorldsEndPanel.cachedData.yourData.numCaptures.ToString("N", nfi);
			this.Entry1_all.Text = WorldsEndPanel.cachedData.globalData.numCaptures.ToString("N", nfi);
			this.Entry2_you.Text = WorldsEndPanel.cachedData.yourData.numRazes.ToString("N", nfi);
			this.Entry2_all.Text = WorldsEndPanel.cachedData.globalData.numRazes.ToString("N", nfi);
			this.Entry3_you.Text = WorldsEndPanel.cachedData.yourData.numTradesSent.ToString("N", nfi);
			this.Entry3_all.Text = WorldsEndPanel.cachedData.globalData.numTradesSent.ToString("N", nfi);
			this.Entry4_you.Text = WorldsEndPanel.cachedData.yourData.numMarketTransfers.ToString("N", nfi);
			this.Entry4_all.Text = WorldsEndPanel.cachedData.globalData.numMarketTransfers.ToString("N", nfi);
			this.Entry5_you.Text = WorldsEndPanel.cachedData.yourData.numAttacks.ToString("N", nfi);
			this.Entry5_all.Text = WorldsEndPanel.cachedData.globalData.numAttacks.ToString("N", nfi);
			this.Entry6_you.Text = WorldsEndPanel.cachedData.yourData.numScouts.ToString("N", nfi);
			this.Entry6_all.Text = WorldsEndPanel.cachedData.globalData.numScouts.ToString("N", nfi);
			this.Entry7_you.Text = ((long)(WorldsEndPanel.cachedData.yourData.numGoodsPillaged * 500.0)).ToString("N", nfi);
			this.Entry7_all.Text = ((long)(WorldsEndPanel.cachedData.globalData.numGoodsPillaged * 500.0)).ToString("N", nfi);
			this.Entry8_you.Text = WorldsEndPanel.cachedData.yourData.numBuildingsRansacked.ToString("N", nfi);
			this.Entry8_all.Text = WorldsEndPanel.cachedData.globalData.numBuildingsRansacked.ToString("N", nfi);
			this.Entry9_you.Text = WorldsEndPanel.cachedData.yourData.gloryGained.ToString("N", nfi);
			this.Entry9_all.Text = WorldsEndPanel.cachedData.globalData.gloryGained.ToString("N", nfi);
			this.Entry10_you.Text = WorldsEndPanel.cachedData.yourData.numWolvesKilled.ToString("N", nfi);
			this.Entry10_all.Text = WorldsEndPanel.cachedData.globalData.numWolvesKilled.ToString("N", nfi);
			this.Entry11_you.Text = WorldsEndPanel.cachedData.yourData.numBanditsKilled.ToString("N", nfi);
			this.Entry11_all.Text = WorldsEndPanel.cachedData.globalData.numBanditsKilled.ToString("N", nfi);
			this.Entry12_you.Text = WorldsEndPanel.cachedData.yourData.numAITroopsKilled.ToString("N", nfi);
			this.Entry12_all.Text = WorldsEndPanel.cachedData.globalData.numAITroopsKilled.ToString("N", nfi);
			this.Entry13_you.Text = WorldsEndPanel.cachedData.yourData.numStashesUncovered.ToString("N", nfi);
			this.Entry13_all.Text = WorldsEndPanel.cachedData.globalData.numStashesUncovered.ToString("N", nfi);
			int num = (int)(WorldsEndPanel.cachedData.globalData.endTime - GameEngine.Instance.World.m_worldStartDate).TotalDays;
			this.endDateLabel.Text = SK.Text("EOW_WorldEnded", "World Ended on Day") + " : " + num.ToString();
			this.endDateLabel2.Text = SK.Text("EOW_AtTime", "At Time") + " : " + WorldsEndPanel.cachedData.globalData.endTime.ToShortTimeString();
		}

		// Token: 0x060033D3 RID: 13267 RVA: 0x000251C8 File Offset: 0x000233C8
		private void logoutClick()
		{
			GameEngine.Instance.playInterfaceSound("AutoSelectVillageAreaPopup_logout");
			this.m_parent.closing = true;
			GameEngine.Instance.closeNoVillagePopup(false);
		}

		// Token: 0x060033D4 RID: 13268 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closePopup()
		{
		}

		// Token: 0x060033D5 RID: 13269 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x000251F0 File Offset: 0x000233F0
		public static void logout()
		{
			WorldsEndPanel.cachedData = null;
		}

		// Token: 0x060033D7 RID: 13271 RVA: 0x000251F8 File Offset: 0x000233F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060033D8 RID: 13272 RVA: 0x002AE0C4 File Offset: 0x002AC2C4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "WorldsEndPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x040040C0 RID: 16576
		public static EndOfTheWorldStats_ReturnType cachedData;

		// Token: 0x040040C1 RID: 16577
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040040C2 RID: 16578
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040C3 RID: 16579
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040040C4 RID: 16580
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040040C5 RID: 16581
		private CustomSelfDrawPanel.CSDImage topImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040C6 RID: 16582
		private CustomSelfDrawPanel.CSDImage bottomImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040C7 RID: 16583
		private CustomSelfDrawPanel.CSDImage eowLogo = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040C8 RID: 16584
		private CustomSelfDrawPanel.CSDImage headerShield = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040C9 RID: 16585
		private CustomSelfDrawPanel.CSDImage headerGlobe = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040CA RID: 16586
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040040CB RID: 16587
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040CC RID: 16588
		private CustomSelfDrawPanel.CSDLabel lostMessageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040CD RID: 16589
		private CustomSelfDrawPanel.CSDLabel Entry1_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040CE RID: 16590
		private CustomSelfDrawPanel.CSDLabel Entry1_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040CF RID: 16591
		private CustomSelfDrawPanel.CSDLabel Entry1_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D0 RID: 16592
		private CustomSelfDrawPanel.CSDLabel Entry2_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D1 RID: 16593
		private CustomSelfDrawPanel.CSDLabel Entry2_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D2 RID: 16594
		private CustomSelfDrawPanel.CSDLabel Entry2_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D3 RID: 16595
		private CustomSelfDrawPanel.CSDLabel Entry3_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D4 RID: 16596
		private CustomSelfDrawPanel.CSDLabel Entry3_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D5 RID: 16597
		private CustomSelfDrawPanel.CSDLabel Entry3_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D6 RID: 16598
		private CustomSelfDrawPanel.CSDLabel Entry4_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D7 RID: 16599
		private CustomSelfDrawPanel.CSDLabel Entry4_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D8 RID: 16600
		private CustomSelfDrawPanel.CSDLabel Entry4_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040D9 RID: 16601
		private CustomSelfDrawPanel.CSDLabel Entry5_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DA RID: 16602
		private CustomSelfDrawPanel.CSDLabel Entry5_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DB RID: 16603
		private CustomSelfDrawPanel.CSDLabel Entry5_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DC RID: 16604
		private CustomSelfDrawPanel.CSDLabel Entry6_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DD RID: 16605
		private CustomSelfDrawPanel.CSDLabel Entry6_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DE RID: 16606
		private CustomSelfDrawPanel.CSDLabel Entry6_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040DF RID: 16607
		private CustomSelfDrawPanel.CSDLabel Entry7_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E0 RID: 16608
		private CustomSelfDrawPanel.CSDLabel Entry7_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E1 RID: 16609
		private CustomSelfDrawPanel.CSDLabel Entry7_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E2 RID: 16610
		private CustomSelfDrawPanel.CSDLabel Entry8_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E3 RID: 16611
		private CustomSelfDrawPanel.CSDLabel Entry8_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E4 RID: 16612
		private CustomSelfDrawPanel.CSDLabel Entry8_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E5 RID: 16613
		private CustomSelfDrawPanel.CSDLabel Entry9_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E6 RID: 16614
		private CustomSelfDrawPanel.CSDLabel Entry9_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E7 RID: 16615
		private CustomSelfDrawPanel.CSDLabel Entry9_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E8 RID: 16616
		private CustomSelfDrawPanel.CSDLabel Entry10_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040E9 RID: 16617
		private CustomSelfDrawPanel.CSDLabel Entry10_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040EA RID: 16618
		private CustomSelfDrawPanel.CSDLabel Entry10_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040EB RID: 16619
		private CustomSelfDrawPanel.CSDLabel Entry11_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040EC RID: 16620
		private CustomSelfDrawPanel.CSDLabel Entry11_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040ED RID: 16621
		private CustomSelfDrawPanel.CSDLabel Entry11_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040EE RID: 16622
		private CustomSelfDrawPanel.CSDLabel Entry12_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040EF RID: 16623
		private CustomSelfDrawPanel.CSDLabel Entry12_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F0 RID: 16624
		private CustomSelfDrawPanel.CSDLabel Entry12_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F1 RID: 16625
		private CustomSelfDrawPanel.CSDLabel Entry13_name = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F2 RID: 16626
		private CustomSelfDrawPanel.CSDLabel Entry13_you = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F3 RID: 16627
		private CustomSelfDrawPanel.CSDLabel Entry13_all = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F4 RID: 16628
		private CustomSelfDrawPanel.CSDLabel endDateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F5 RID: 16629
		private CustomSelfDrawPanel.CSDLabel endDateLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040F6 RID: 16630
		private WorldsEndWindow m_parent;

		// Token: 0x040040F7 RID: 16631
		private IContainer components;
	}
}
