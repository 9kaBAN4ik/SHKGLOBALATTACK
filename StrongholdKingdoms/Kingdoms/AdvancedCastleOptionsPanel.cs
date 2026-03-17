using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000B8 RID: 184
	public class AdvancedCastleOptionsPanel : CustomSelfDrawPanel
	{
		// Token: 0x06000507 RID: 1287 RVA: 0x0000AA61 File Offset: 0x00008C61
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00060BB0 File Offset: 0x0005EDB0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "AdvancedCastleOptionsPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00060C10 File Offset: 0x0005EE10
		public AdvancedCastleOptionsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00060D74 File Offset: 0x0005EF74
		public void init(AdvancedCastleOptionsPopup parent, bool castleSetup)
		{
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.popup_background_01;
			this.backgroundImage.Position = new Point(0, 0);
			base.addControl(this.backgroundImage);
			this.captureLabel.Text = SK.Text("Advanced_Castle_Options", "Advanced Options");
			this.captureLabel.Color = global::ARGBColors.White;
			this.captureLabel.Position = new Point(13, 7);
			this.captureLabel.Size = new Size(335, 20);
			this.captureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.captureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.backgroundImage.addControl(this.captureLabel);
			if (castleSetup)
			{
				this.memoriseLabel.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseLabel.Color = global::ARGBColors.White;
				this.memoriseLabel.Position = new Point(13, 50);
				this.memoriseLabel.Size = new Size(335, 20);
				this.memoriseLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.memoriseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.memoriseLabel);
				this.memoriseTroopsButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseTroopsButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseTroopsButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseTroopsButton.Position = new Point(25, 75);
				this.memoriseTroopsButton.Text.Text = SK.Text("Advanced_Castle_Troops", "Troops");
				this.memoriseTroopsButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseTroopsButton.Text.Color = global::ARGBColors.Black;
				this.memoriseTroopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseTroopsClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseTroopsButton);
				this.memoriseCastleButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseCastleButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseCastleButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseCastleButton.Position = new Point(195, 75);
				this.memoriseCastleButton.Text.Text = SK.Text("Advanced_Castle_Castle", "Infrastructure");
				this.memoriseCastleButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseCastleButton.Text.Color = global::ARGBColors.Black;
				this.memoriseCastleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseCastleClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.memoriseCastleButton);
				this.restoreLabel.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreLabel.Color = global::ARGBColors.White;
				this.restoreLabel.Position = new Point(13, 110);
				this.restoreLabel.Size = new Size(335, 20);
				this.restoreLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.restoreLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.restoreLabel);
				this.restoreTroopsButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreTroopsButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreTroopsButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreTroopsButton.Position = new Point(25, 135);
				this.restoreTroopsButton.Text.Text = SK.Text("Advanced_Castle_Troops", "Troops");
				this.restoreTroopsButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreTroopsButton.Text.Color = global::ARGBColors.Black;
				this.restoreTroopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreTroopsClicked), "AdvancedCastleOptionsPanel_restore_troops");
				this.backgroundImage.addControl(this.restoreTroopsButton);
				this.restoreCastleButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreCastleButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreCastleButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreCastleButton.Position = new Point(195, 135);
				this.restoreCastleButton.Text.Text = SK.Text("Advanced_Castle_Castle", "Infrastructure");
				this.restoreCastleButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreCastleButton.Text.Color = global::ARGBColors.Black;
				this.restoreCastleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreCastleClicked), "AdvancedCastleOptionsPanel_restore_Infrastructure");
				this.backgroundImage.addControl(this.restoreCastleButton);
				this.infoLabel.Text = "";
				this.infoLabel.Color = global::ARGBColors.White;
				this.infoLabel.Position = new Point(0, 165);
				this.infoLabel.Size = new Size(this.backgroundImage.Width, 20);
				this.infoLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.infoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.infoLabel);
				this.deleteCastleButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.deleteCastleButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.deleteCastleButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.deleteCastleButton.Position = new Point(70, 200);
				this.deleteCastleButton.Text.Text = SK.Text("Advanced_Castle_Delete_Castle", "Delete All Castle Infrastructure");
				if (Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
				{
					this.deleteCastleButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else
				{
					this.deleteCastleButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				}
				this.deleteCastleButton.Text.Color = global::ARGBColors.Black;
				this.deleteCastleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteCastleClicked), "CastleMapPanel_delete_constructing");
				this.backgroundImage.addControl(this.deleteCastleButton);
				this.deleteMoatButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.deleteMoatButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.deleteMoatButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.deleteMoatButton.Position = new Point(70, 230);
				this.deleteMoatButton.Text.Text = SK.Text("Advanced_Castle_Delete_Castle_moat", "Delete All Moat");
				if (Program.mySettings.LanguageIdent == "pt")
				{
					this.deleteMoatButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else
				{
					this.deleteMoatButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				}
				this.deleteMoatButton.Text.Color = global::ARGBColors.Black;
				this.deleteMoatButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteMoatClicked), "CastleMapPanel_delete_constructing");
				this.backgroundImage.addControl(this.deleteMoatButton);
				this.deletePitsButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.deletePitsButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.deletePitsButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.deletePitsButton.Position = new Point(70, 260);
				this.deletePitsButton.Text.Text = SK.Text("Advanced_Castle_Delete_Castle_pits", "Delete All Killing Pits");
				if (Program.mySettings.LanguageIdent == "pt")
				{
					this.deletePitsButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else
				{
					this.deletePitsButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				}
				this.deletePitsButton.Text.Color = global::ARGBColors.Black;
				this.deletePitsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deletePitsClicked), "CastleMapPanel_delete_constructing");
				this.backgroundImage.addControl(this.deletePitsButton);
				this.deleteOilPotsButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.deleteOilPotsButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.deleteOilPotsButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.deleteOilPotsButton.Position = new Point(70, 290);
				this.deleteOilPotsButton.Text.Text = SK.Text("Advanced_Castle_Delete_Castle_oil_pots", "Delete All Oil Pots");
				if (Program.mySettings.LanguageIdent == "pt")
				{
					this.deleteOilPotsButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else
				{
					this.deleteOilPotsButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				}
				this.deleteOilPotsButton.Text.Color = global::ARGBColors.Black;
				this.deleteOilPotsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteOilPotsClicked), "CastleMapPanel_delete_constructing");
				this.backgroundImage.addControl(this.deleteOilPotsButton);
				if (GameEngine.Instance.World.WorldEnded)
				{
					this.deleteCastleButton.Visible = false;
					this.deleteMoatButton.Visible = false;
					this.deletePitsButton.Visible = false;
					this.deleteOilPotsButton.Visible = false;
				}
				else
				{
					this.deleteCastleButton.Visible = true;
					this.deleteMoatButton.Visible = true;
					this.deletePitsButton.Visible = true;
					this.deleteOilPotsButton.Visible = true;
				}
				this.memoriseTroopsButton.Enabled = true;
				this.memoriseCastleButton.Enabled = true;
				this.restoreCastleButton.Enabled = true;
				this.restoreTroopsButton.Enabled = true;
				if (GameEngine.Instance.Castle != null)
				{
					if (GameEngine.Instance.Castle.countPlacedTroops() <= 0)
					{
						this.memoriseTroopsButton.Enabled = false;
					}
					if (GameEngine.Instance.Castle.countPlacedInfrastructure() <= 0)
					{
						this.deleteCastleButton.Enabled = false;
						this.memoriseCastleButton.Enabled = false;
					}
					if (GameEngine.Instance.Castle.countPlacedMoat() <= 0)
					{
						this.deleteMoatButton.Enabled = false;
					}
					if (GameEngine.Instance.Castle.countPlacedPits() <= 0)
					{
						this.deletePitsButton.Enabled = false;
					}
					if (GameEngine.Instance.Castle.countPlacedOilPots() <= 0)
					{
						this.deleteOilPotsButton.Enabled = false;
					}
					if (!GameEngine.Instance.Castle.gotInfrastructureSave())
					{
						this.restoreCastleButton.Enabled = false;
					}
					if (!GameEngine.Instance.Castle.gotTroopsSave())
					{
						this.restoreTroopsButton.Enabled = false;
					}
					if (GameEngine.Instance.World.isCapital(GameEngine.Instance.Castle.VillageID))
					{
						this.deleteCastleButton.Enabled = false;
						this.deleteMoatButton.Enabled = false;
						this.deletePitsButton.Enabled = false;
						this.deleteOilPotsButton.Enabled = false;
					}
				}
			}
			else
			{
				int num = 54;
				this.setup1Label.Text = SK.Text("Advanced_Castle_SETUP1", "Configuration 1");
				this.setup1Label.Color = global::ARGBColors.White;
				this.setup1Label.Position = new Point(13, 50);
				this.setup1Label.Size = new Size(335, 20);
				this.setup1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.setup1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.setup1Label);
				this.memoriseSetup1Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseSetup1Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseSetup1Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseSetup1Button.Position = new Point(25, 69);
				this.memoriseSetup1Button.Text.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseSetup1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseSetup1Button.Text.Color = global::ARGBColors.Black;
				this.memoriseSetup1Button.Data = 1;
				this.memoriseSetup1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseAttackClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseSetup1Button);
				this.restoreSetup1Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreSetup1Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreSetup1Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreSetup1Button.Position = new Point(195, 69);
				this.restoreSetup1Button.Text.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreSetup1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreSetup1Button.Text.Color = global::ARGBColors.Black;
				this.restoreSetup1Button.Data = 1;
				this.restoreSetup1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreAttackClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.restoreSetup1Button);
				this.setup2Label.Text = SK.Text("Advanced_Castle_SETUP2", "Configuration 2");
				this.setup2Label.Color = global::ARGBColors.White;
				this.setup2Label.Position = new Point(13, 50 + num);
				this.setup2Label.Size = new Size(335, 20);
				this.setup2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.setup2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.setup2Label);
				this.memoriseSetup2Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseSetup2Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseSetup2Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseSetup2Button.Position = new Point(25, 69 + num);
				this.memoriseSetup2Button.Text.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseSetup2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseSetup2Button.Text.Color = global::ARGBColors.Black;
				this.memoriseSetup2Button.Data = 2;
				this.memoriseSetup2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseAttackClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseSetup2Button);
				this.restoreSetup2Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreSetup2Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreSetup2Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreSetup2Button.Position = new Point(195, 69 + num);
				this.restoreSetup2Button.Text.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreSetup2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreSetup2Button.Text.Color = global::ARGBColors.Black;
				this.restoreSetup2Button.Data = 2;
				this.restoreSetup2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreAttackClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.restoreSetup2Button);
				this.setup3Label.Text = SK.Text("Advanced_Castle_SETUP3", "Configuration 3");
				this.setup3Label.Color = global::ARGBColors.White;
				this.setup3Label.Position = new Point(13, 50 + num * 2);
				this.setup3Label.Size = new Size(335, 20);
				this.setup3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.setup3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.setup3Label);
				this.memoriseSetup3Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseSetup3Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseSetup3Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseSetup3Button.Position = new Point(25, 69 + num * 2);
				this.memoriseSetup3Button.Text.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseSetup3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseSetup3Button.Text.Color = global::ARGBColors.Black;
				this.memoriseSetup3Button.Data = 3;
				this.memoriseSetup3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseAttackClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseSetup3Button);
				this.restoreSetup3Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreSetup3Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreSetup3Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreSetup3Button.Position = new Point(195, 69 + num * 2);
				this.restoreSetup3Button.Text.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreSetup3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreSetup3Button.Text.Color = global::ARGBColors.Black;
				this.restoreSetup3Button.Data = 3;
				this.restoreSetup3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreAttackClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.restoreSetup3Button);
				this.setup4Label.Text = SK.Text("Advanced_Castle_SETUP4", "Configuration 4");
				this.setup4Label.Color = global::ARGBColors.White;
				this.setup4Label.Position = new Point(13, 50 + num * 3);
				this.setup4Label.Size = new Size(335, 20);
				this.setup4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.setup4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.setup4Label);
				this.memoriseSetup4Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseSetup4Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseSetup4Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseSetup4Button.Position = new Point(25, 69 + num * 3);
				this.memoriseSetup4Button.Text.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseSetup4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseSetup4Button.Text.Color = global::ARGBColors.Black;
				this.memoriseSetup4Button.Data = 4;
				this.memoriseSetup4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseAttackClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseSetup4Button);
				this.restoreSetup4Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreSetup4Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreSetup4Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreSetup4Button.Position = new Point(195, 69 + num * 3);
				this.restoreSetup4Button.Text.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreSetup4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreSetup4Button.Text.Color = global::ARGBColors.Black;
				this.restoreSetup4Button.Data = 4;
				this.restoreSetup4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreAttackClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.restoreSetup4Button);
				this.setup5Label.Text = SK.Text("Advanced_Castle_SETUP5", "Configuration 5");
				this.setup5Label.Color = global::ARGBColors.White;
				this.setup5Label.Position = new Point(13, 50 + num * 4);
				this.setup5Label.Size = new Size(335, 20);
				this.setup5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.setup5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.setup5Label);
				this.memoriseSetup5Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.memoriseSetup5Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.memoriseSetup5Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.memoriseSetup5Button.Position = new Point(25, 69 + num * 4);
				this.memoriseSetup5Button.Text.Text = SK.Text("Advanced_Castle_Memorise", "Memorize");
				this.memoriseSetup5Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.memoriseSetup5Button.Text.Color = global::ARGBColors.Black;
				this.memoriseSetup5Button.Data = 5;
				this.memoriseSetup5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseAttackClicked), "AdvancedCastleOptionsPanel_memorise_troops");
				this.backgroundImage.addControl(this.memoriseSetup5Button);
				this.restoreSetup5Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.restoreSetup5Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.restoreSetup5Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.restoreSetup5Button.Position = new Point(195, 69 + num * 4);
				this.restoreSetup5Button.Text.Text = SK.Text("Advanced_Castle_Restore", "Restore");
				this.restoreSetup5Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.restoreSetup5Button.Text.Color = global::ARGBColors.Black;
				this.restoreSetup5Button.Data = 5;
				this.restoreSetup5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreAttackClicked), "AdvancedCastleOptionsPanel_memorise_infrastructure");
				this.backgroundImage.addControl(this.restoreSetup5Button);
				this.infoLabel.Text = "";
				this.infoLabel.Color = global::ARGBColors.White;
				this.infoLabel.Position = new Point(20, 329);
				this.infoLabel.Size = new Size(this.backgroundImage.Width, 20);
				this.infoLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.infoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.infoLabel);
				this.restoreSetup1Button.Enabled = false;
				this.restoreSetup2Button.Enabled = false;
				this.restoreSetup3Button.Enabled = false;
				this.restoreSetup4Button.Enabled = false;
				this.restoreSetup5Button.Enabled = false;
				if (GameEngine.Instance.CastleAttackerSetup != null)
				{
					if (GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(1))
					{
						this.restoreSetup1Button.Enabled = true;
					}
					if (GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(2))
					{
						this.restoreSetup2Button.Enabled = true;
					}
					if (GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(3))
					{
						this.restoreSetup3Button.Enabled = true;
					}
					if (GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(4))
					{
						this.restoreSetup4Button.Enabled = true;
					}
					if (GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(5))
					{
						this.restoreSetup5Button.Enabled = true;
					}
					bool enabled = GameEngine.Instance.CastleAttackerSetup.canMemoriseAttackSetup();
					this.memoriseSetup1Button.Enabled = enabled;
					this.memoriseSetup2Button.Enabled = enabled;
					this.memoriseSetup3Button.Enabled = enabled;
					this.memoriseSetup4Button.Enabled = enabled;
					this.memoriseSetup5Button.Enabled = enabled;
				}
			}
			this.okButton.ImageNorm = GFXLibrary.button_blue_01_normal;
			this.okButton.ImageOver = GFXLibrary.button_blue_01_over;
			this.okButton.ImageClick = GFXLibrary.button_blue_01_in;
			this.okButton.Position = new Point(240, 325);
			this.okButton.Text.Text = SK.Text("GENERIC_OK", "OK");
			this.okButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.okButton.Text.Color = global::ARGBColors.Black;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.okClicked), "AdvancedCastleOptionsPanel_restore_ok");
			this.backgroundImage.addControl(this.okButton);
			parent.Size = this.backgroundImage.Size;
			base.Invalidate();
			parent.Invalidate();
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000AA80 File Offset: 0x00008C80
		public void okClicked()
		{
			InterfaceMgr.Instance.closeAdvancedCastleOptionsPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000627F4 File Offset: 0x000609F4
		public void memoriseTroopsClicked()
		{
			if (GameEngine.Instance.Castle != null)
			{
				if (GameEngine.Instance.Castle.memoriseTroops())
				{
					this.infoLabel.Text = SK.Text("Advanced_Castle_Troops_Saves", "Troops Memorized");
					return;
				}
				this.infoLabel.Text = SK.Text("Advanced_Castle_Troops_Saves_failed", "Troops Memorize Failed");
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00062854 File Offset: 0x00060A54
		public void memoriseCastleClicked()
		{
			if (GameEngine.Instance.Castle != null)
			{
				if (GameEngine.Instance.Castle.memoriseInfrastructure())
				{
					this.infoLabel.Text = SK.Text("Advanced_Castle_Infrastructure_Saves", "Infrastructure Memorized");
					return;
				}
				this.infoLabel.Text = SK.Text("Advanced_Castle_Infrastructure_Saves_failed", "Infrastructure Memorize Failed");
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x000628B4 File Offset: 0x00060AB4
		public void restoreTroopsClicked()
		{
			if (GameEngine.Instance.Castle != null)
			{
				int num = GameEngine.Instance.Castle.restoreTroops();
				if (num > 0)
				{
					this.okClicked();
					return;
				}
				if (num == 0)
				{
					this.infoLabel.Text = SK.Text("Advanced_Castle_Restore_Troop_None", "No Troops placed");
					return;
				}
				this.infoLabel.Text = SK.Text("Advanced_Castle_Restore_Troop_Error", "Error reading file");
			}
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00062920 File Offset: 0x00060B20
		public void restoreCastleClicked()
		{
			if (GameEngine.Instance.Castle != null)
			{
				int num = GameEngine.Instance.Castle.restoreInfrastructure();
				if (num > 0)
				{
					this.okClicked();
					return;
				}
				if (num == 0)
				{
					this.infoLabel.Text = SK.Text("Advanced_Castle_Restore_Infrastructure_None", "Nothing placed");
					return;
				}
				this.infoLabel.Text = SK.Text("Advanced_Castle_Restore_Infrastructure_Error", "Error reading file");
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0006298C File Offset: 0x00060B8C
		public void deleteCastleClicked()
		{
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("Advanced_Castle_Delete_Castle_message", "You are about to delete your entire castle. Are you really sure about this?"), SK.Text("Advanced_Castle_Delete_Castle", "Delete All Castle Infrastructure"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.DeleteCastle();
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000AAAC File Offset: 0x00008CAC
		private void DeleteCastle()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.deleteAllElements();
				this.deleteCastleButton.Enabled = false;
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000629C8 File Offset: 0x00060BC8
		public void deleteMoatClicked()
		{
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("Advanced_Castle_Delete_Castle_message_moat", "You are about to delete all your Moat from your castle. Are you really sure about this?"), SK.Text("Advanced_Castle_Delete_Castle", "Delete All Castle Infrastructure"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.DeleteMoat();
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000AAD5 File Offset: 0x00008CD5
		private void DeleteMoat()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.deleteAllMoatElements();
				this.deleteMoatButton.Enabled = false;
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00062A04 File Offset: 0x00060C04
		public void deletePitsClicked()
		{
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("Advanced_Castle_Delete_Castle_message_pits", "You are about to delete all your Killing Pits castle. Are you really sure about this?"), SK.Text("Advanced_Castle_Delete_Castle_pits", "Delete All Killing Pits"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.DeletePits();
			}
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000AAFE File Offset: 0x00008CFE
		private void DeletePits()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.deleteAllPitsElements();
				this.deletePitsButton.Enabled = false;
			}
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00062A40 File Offset: 0x00060C40
		public void deleteOilPotsClicked()
		{
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("Advanced_Castle_Delete_Castle_message_oil", "You are about to delete all your Oil Pots castle. Are you really sure about this?"), SK.Text("Advanced_Castle_Delete_Castle_oil_pots", "Delete All Oil Pots"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.DeleteOilPots();
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0000AB27 File Offset: 0x00008D27
		private void DeleteOilPots()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.deleteAllOilPotElements();
				this.deleteOilPotsButton.Enabled = false;
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00062A7C File Offset: 0x00060C7C
		private void memoriseAttackClicked()
		{
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			if (clickedControl == null)
			{
				return;
			}
			int data = clickedControl.Data;
			if (GameEngine.Instance.CastleAttackerSetup == null)
			{
				return;
			}
			if (GameEngine.Instance.CastleAttackerSetup.memoriseAttackSetup(data))
			{
				this.infoLabel.Text = SK.Text("Advanced_Castle_Troops_Saves", "Troops Memorized");
				if (data == 1 && GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(1))
				{
					this.restoreSetup1Button.Enabled = true;
				}
				if (data == 2 && GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(2))
				{
					this.restoreSetup2Button.Enabled = true;
				}
				if (data == 3 && GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(3))
				{
					this.restoreSetup3Button.Enabled = true;
				}
				if (data == 4 && GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(4))
				{
					this.restoreSetup4Button.Enabled = true;
				}
				if (data == 5 && GameEngine.Instance.CastleAttackerSetup.gotAttackSetupSave(5))
				{
					this.restoreSetup5Button.Enabled = true;
					return;
				}
			}
			else
			{
				this.infoLabel.Text = SK.Text("Advanced_Castle_Troops_Saves_failed", "Troops Memorize Failed");
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00062B9C File Offset: 0x00060D9C
		private void restoreAttackClicked()
		{
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			if (clickedControl != null)
			{
				int data = clickedControl.Data;
				if (GameEngine.Instance.CastleAttackerSetup != null && GameEngine.Instance.CastleAttackerSetup.restoreAttackSetup(data))
				{
					this.okClicked();
				}
			}
		}

		// Token: 0x040005D0 RID: 1488
		private IContainer components;

		// Token: 0x040005D1 RID: 1489
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040005D2 RID: 1490
		private CustomSelfDrawPanel.CSDLabel captureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005D3 RID: 1491
		private CustomSelfDrawPanel.CSDLabel memoriseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005D4 RID: 1492
		private CustomSelfDrawPanel.CSDButton memoriseTroopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005D5 RID: 1493
		private CustomSelfDrawPanel.CSDButton memoriseCastleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005D6 RID: 1494
		private CustomSelfDrawPanel.CSDLabel restoreLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005D7 RID: 1495
		private CustomSelfDrawPanel.CSDButton restoreTroopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005D8 RID: 1496
		private CustomSelfDrawPanel.CSDButton restoreCastleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005D9 RID: 1497
		private CustomSelfDrawPanel.CSDButton deleteCastleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005DA RID: 1498
		private CustomSelfDrawPanel.CSDButton deletePitsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005DB RID: 1499
		private CustomSelfDrawPanel.CSDButton deleteMoatButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005DC RID: 1500
		private CustomSelfDrawPanel.CSDButton deleteOilPotsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005DD RID: 1501
		private CustomSelfDrawPanel.CSDLabel infoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005DE RID: 1502
		private CustomSelfDrawPanel.CSDLabel setup1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005DF RID: 1503
		private CustomSelfDrawPanel.CSDLabel setup2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005E0 RID: 1504
		private CustomSelfDrawPanel.CSDLabel setup3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005E1 RID: 1505
		private CustomSelfDrawPanel.CSDLabel setup4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005E2 RID: 1506
		private CustomSelfDrawPanel.CSDLabel setup5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005E3 RID: 1507
		private CustomSelfDrawPanel.CSDButton memoriseSetup1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E4 RID: 1508
		private CustomSelfDrawPanel.CSDButton memoriseSetup2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E5 RID: 1509
		private CustomSelfDrawPanel.CSDButton memoriseSetup3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E6 RID: 1510
		private CustomSelfDrawPanel.CSDButton memoriseSetup4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E7 RID: 1511
		private CustomSelfDrawPanel.CSDButton memoriseSetup5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E8 RID: 1512
		private CustomSelfDrawPanel.CSDButton restoreSetup1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005E9 RID: 1513
		private CustomSelfDrawPanel.CSDButton restoreSetup2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005EA RID: 1514
		private CustomSelfDrawPanel.CSDButton restoreSetup3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005EB RID: 1515
		private CustomSelfDrawPanel.CSDButton restoreSetup4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005EC RID: 1516
		private CustomSelfDrawPanel.CSDButton restoreSetup5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005ED RID: 1517
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005EE RID: 1518
		private MyMessageBoxPopUp PopUpRef;
	}
}
