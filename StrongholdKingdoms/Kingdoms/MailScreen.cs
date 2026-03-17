using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000225 RID: 549
	public class MailScreen : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001736 RID: 5942 RVA: 0x0016EEFC File Offset: 0x0016D0FC
		public MailScreen()
		{
			this.mailController = MailManager.Instance;
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.tbMain.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Regular);
			this.tbSubject.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x00018586 File Offset: 0x00016786
		public static void setFromFaction()
		{
			MailScreen.fromFaction = true;
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x0016F9A4 File Offset: 0x0016DBA4
		public void init(MailScreenPanel parent)
		{
			this.m_parent = parent;
			base.clearControls();
			MailScreen.factionClose = MailScreen.fromFaction;
			MailScreen.fromFaction = false;
			this.mainBackgroundImage.Size = new Size(base.Width, base.Height - 40);
			this.mainBackgroundImage.Position = new Point(0, 40);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.mainBodyArea.Position = new Point(0, 5);
			this.mainBodyArea.Size = new Size(992, 521);
			this.mainBackgroundImage.addControl(this.mainBodyArea);
			this.mainHeaderArea.Position = new Point(0, -40);
			this.mainHeaderArea.Size = new Size(992, 45);
			this.mainBackgroundImage.addControl(this.mainHeaderArea);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			this.mainHeaderArea.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			this.headerLabel.Text = SK.Text("MailScreen_Mail", "Mail");
			this.headerLabel.Color = global::ARGBColors.White;
			this.headerLabel.DropShadowColor = global::ARGBColors.Black;
			this.headerLabel.Position = new Point(9, 5);
			this.headerLabel.Size = new Size(700, 50);
			this.headerLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.headerLabel);
			this.headerLabel2.Text = "";
			this.headerLabel2.Color = global::ARGBColors.White;
			this.headerLabel2.DropShadowColor = global::ARGBColors.Black;
			this.headerLabel2.Size = new Size(700, 24);
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.headerLabel2.Position = new Point(280, 12);
			}
			else if (Program.mySettings.LanguageIdent == "fr")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "es")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "tr")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "it")
			{
				this.headerLabel2.Position = new Point(330, 12);
				this.headerLabel2.Size = new Size(570, 24);
			}
			else if (Program.mySettings.LanguageIdent == "pt")
			{
				this.headerLabel2.Position = new Point(300, 12);
				this.headerLabel2.Size = new Size(600, 24);
			}
			else if (Program.mySettings.LanguageIdent == "pl")
			{
				this.headerLabel2.Position = new Point(280, 12);
				this.headerLabel2.Size = new Size(620, 24);
			}
			else
			{
				this.headerLabel2.Position = new Point(200, 12);
			}
			this.headerLabel2.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.headerLabel2);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 4);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MailScreen_close");
			this.closeButton.CustomTooltipID = 502;
			this.mainHeaderArea.addControl(this.closeButton);
			this.dockButton.ImageNorm = GFXLibrary.mail2_detach_attach_window_normal;
			this.dockButton.ImageOver = GFXLibrary.mail2_detach_attach_window_over;
			this.dockButton.ImageClick = GFXLibrary.mail2_detach_attach_window_in;
			this.dockButton.Position = new Point(908, 4);
			this.dockButton.CustomTooltipID = 500;
			this.dockButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.dockClick), "MailScreen_dock");
			this.mainHeaderArea.addControl(this.dockButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainHeaderArea, 26, new Point(868, 3));
			this.mailListArea.Position = new Point(0, 0);
			this.mailListArea.Size = this.mainBodyArea.Size;
			this.mailListArea.Visible = false;
			this.mainBodyArea.addControl(this.mailListArea);
			this.mailList_folderArea.Position = new Point(15, 8);
			this.mailList_folderArea.Size = new Size(102, 504);
			this.mailListArea.addControl(this.mailList_folderArea);
			Size size = this.mailList_folderArea.Size;
			Point position = this.mailList_folderArea.Position;
			this.mailList_folderShadowTR.Image = GFXLibrary.mail_shadow_top_right;
			this.mailList_folderShadowTR.Position = new Point(position.X + size.Width, position.Y);
			this.mailListArea.addControl(this.mailList_folderShadowTR);
			this.mailList_folderShadowBR.Image = GFXLibrary.mail_shadow_bottom_right;
			this.mailList_folderShadowBR.Position = new Point(position.X + size.Width, position.Y + size.Height);
			this.mailListArea.addControl(this.mailList_folderShadowBR);
			this.mailList_folderShadowBL.Image = GFXLibrary.mail_shadow_bottom_left;
			this.mailList_folderShadowBL.Position = new Point(position.X, position.Y + size.Height);
			this.mailListArea.addControl(this.mailList_folderShadowBL);
			this.mailList_folderShadowR.Image = GFXLibrary.mail_shadow_right;
			this.mailList_folderShadowR.Position = new Point(position.X + size.Width, position.Y + GFXLibrary.mail_shadow_top_right.Height);
			this.mailList_folderShadowR.Size = new Size(GFXLibrary.mail_shadow_right.Width, size.Height - GFXLibrary.mail_shadow_top_right.Height);
			this.mailListArea.addControl(this.mailList_folderShadowR);
			this.mailList_folderShadowB.Image = GFXLibrary.mail_shadow_bottom;
			this.mailList_folderShadowB.Position = new Point(position.X + GFXLibrary.mail_shadow_bottom_left.Width, position.Y + size.Height);
			this.mailList_folderShadowB.Size = new Size(size.Width - GFXLibrary.mail_shadow_bottom_left.Width, GFXLibrary.mail_shadow_bottom.Height);
			this.mailListArea.addControl(this.mailList_folderShadowB);
			this.mailList_folderHeaderImage.Size = new Size(102, 18);
			this.mailList_folderHeaderImage.Position = new Point(0, 0);
			this.mailList_folderArea.addControl(this.mailList_folderHeaderImage);
			this.mailList_folderHeaderImage.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailList_folderHeaderLabel.Text = SK.Text("MailScreen_Folder", "Folder");
			this.mailList_folderHeaderLabel.Color = global::ARGBColors.Black;
			this.mailList_folderHeaderLabel.Position = new Point(0, 0);
			this.mailList_folderHeaderLabel.Size = new Size(this.mailList_folderHeaderImage.Width, this.mailList_folderHeaderImage.Height);
			this.mailList_folderHeaderLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailList_folderHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mailList_folderHeaderImage.addControl(this.mailList_folderHeaderLabel);
			for (int i = 0; i < 27; i++)
			{
				MailScreen.MailFolderLine folderLine = this.getFolderLine(i);
				folderLine.Position = new Point(0, 17 + i * 18);
				folderLine.Size = new Size(this.mailList_folderArea.Size.Width, 18);
				folderLine.Text.Text = "";
				folderLine.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				folderLine.Data = i;
				folderLine.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.folderLineClicked), "MailScreen_change_folder");
				this.mailList_folderArea.addControl(folderLine);
				folderLine.setup();
			}
			MailScreen.MailFolderLine folderLine2 = this.getFolderLine(0);
			folderLine2.Text.Text = SK.Text("MailScreen_Inbox", "Inbox");
			folderLine2.Icon.Image = GFXLibrary.mail_folder_icon_open;
			this.mailList_listArea.Position = new Point(127, 8);
			this.mailList_listArea.Size = new Size(621, 504);
			this.mailListArea.addControl(this.mailList_listArea);
			size = this.mailList_listArea.Size;
			position = this.mailList_listArea.Position;
			size.Width += 16;
			this.mailList_listShadowTR.Image = GFXLibrary.mail_shadow_top_right;
			this.mailList_listShadowTR.Position = new Point(position.X + size.Width, position.Y);
			this.mailListArea.addControl(this.mailList_listShadowTR);
			this.mailList_listShadowBR.Image = GFXLibrary.mail_shadow_bottom_right;
			this.mailList_listShadowBR.Position = new Point(position.X + size.Width, position.Y + size.Height);
			this.mailListArea.addControl(this.mailList_listShadowBR);
			this.mailList_listShadowBL.Image = GFXLibrary.mail_shadow_bottom_left;
			this.mailList_listShadowBL.Position = new Point(position.X, position.Y + size.Height);
			this.mailListArea.addControl(this.mailList_listShadowBL);
			this.mailList_listShadowR.Image = GFXLibrary.mail_shadow_right;
			this.mailList_listShadowR.Position = new Point(position.X + size.Width, position.Y + GFXLibrary.mail_shadow_top_right.Height);
			this.mailList_listShadowR.Size = new Size(GFXLibrary.mail_shadow_right.Width, size.Height - GFXLibrary.mail_shadow_top_right.Height);
			this.mailListArea.addControl(this.mailList_listShadowR);
			this.mailList_listShadowB.Image = GFXLibrary.mail_shadow_bottom;
			this.mailList_listShadowB.Position = new Point(position.X + GFXLibrary.mail_shadow_bottom_left.Width, position.Y + size.Height);
			this.mailList_listShadowB.Size = new Size(size.Width - GFXLibrary.mail_shadow_bottom_left.Width, GFXLibrary.mail_shadow_bottom.Height);
			this.mailListArea.addControl(this.mailList_listShadowB);
			this.mailList_mainHeaderImage1.Size = new Size(22, 18);
			this.mailList_mainHeaderImage1.Position = new Point(0, 0);
			this.mailList_listArea.addControl(this.mailList_mainHeaderImage1);
			this.mailList_mainHeaderImage1.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailList_mainHeaderImage2.Size = new Size(241, 18);
			this.mailList_mainHeaderImage2.Position = new Point(22, 0);
			this.mailList_listArea.addControl(this.mailList_mainHeaderImage2);
			this.mailList_mainHeaderImage2.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailList_mainHeaderLabel2.Text = SK.Text("MailScreen_Subject", "Subject");
			this.mailList_mainHeaderLabel2.Color = global::ARGBColors.Black;
			this.mailList_mainHeaderLabel2.Position = new Point(21, 0);
			this.mailList_mainHeaderLabel2.Size = new Size(this.mailList_mainHeaderImage2.Width - 21, this.mailList_mainHeaderImage2.Height);
			this.mailList_mainHeaderLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailList_mainHeaderLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailList_mainHeaderImage2.addControl(this.mailList_mainHeaderLabel2);
			this.mailList_mainHeaderImage3.Size = new Size(120, 18);
			this.mailList_mainHeaderImage3.Position = new Point(263, 0);
			this.mailList_listArea.addControl(this.mailList_mainHeaderImage3);
			this.mailList_mainHeaderImage3.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailList_mainHeaderLabel3.Text = SK.Text("MailScreen_Date", "Date");
			this.mailList_mainHeaderLabel3.Color = global::ARGBColors.Black;
			this.mailList_mainHeaderLabel3.Position = new Point(8, 0);
			this.mailList_mainHeaderLabel3.Size = new Size(this.mailList_mainHeaderImage3.Width - 8, this.mailList_mainHeaderImage3.Height);
			this.mailList_mainHeaderLabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailList_mainHeaderLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailList_mainHeaderImage3.addControl(this.mailList_mainHeaderLabel3);
			this.mailList_mainHeaderImage4.Size = new Size(238, 18);
			this.mailList_mainHeaderImage4.Position = new Point(383, 0);
			this.mailList_listArea.addControl(this.mailList_mainHeaderImage4);
			this.mailList_mainHeaderImage4.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailList_mainHeaderLabel4.Text = SK.Text("MailScreen_From_To", "From / To");
			this.mailList_mainHeaderLabel4.Color = global::ARGBColors.Black;
			this.mailList_mainHeaderLabel4.Position = new Point(8, 0);
			this.mailList_mainHeaderLabel4.Size = new Size(this.mailList_mainHeaderImage4.Width - 8, this.mailList_mainHeaderImage4.Height);
			this.mailList_mainHeaderLabel4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailList_mainHeaderLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailList_mainHeaderImage4.addControl(this.mailList_mainHeaderLabel4);
			for (int j = 0; j < 27; j++)
			{
				MailScreen.MailListLine mailListLine = this.getMailListLine(j);
				mailListLine.Position = new Point(0, 17 + j * 18);
				mailListLine.Size = new Size(621, 18);
				mailListLine.Subject.Text = "";
				mailListLine.Subject.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailListLine.Sender.Text = "";
				mailListLine.Sender.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailListLine.Date = DateTime.MinValue;
				mailListLine.DateLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailListLine.Data = j;
				mailListLine.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailLineClicked));
				this.mailList_listArea.addControl(mailListLine);
				mailListLine.setup();
			}
			this.lastMailLineClicked = -1;
			this.mailList_scrollBar.Position = new Point(622, 17);
			this.mailList_scrollBar.Size = new Size(16, this.mailList_listArea.Size.Height - 17 - 17 - 1);
			this.mailList_listArea.addControl(this.mailList_scrollBar);
			this.mailList_scrollBar.Value = 0;
			this.mailList_scrollBar.Max = 0;
			this.mailList_scrollBar.NumVisibleLines = 27;
			this.mailList_scrollBar.TabMinSize = 26;
			this.mailList_scrollBar.OffsetTL = new Point(0, 0);
			this.mailList_scrollBar.OffsetBR = new Point(0, 0);
			this.mailList_scrollBar.Create(GFXLibrary.mail2_blue_scrollbar_bar_top, GFXLibrary.mail2_blue_scrollbar_bar_middle, GFXLibrary.mail2_blue_scrollbar_bar_bottom, GFXLibrary.mail2_blue_scrollbar_thumb_top, GFXLibrary.mail2_blue_scrollbar_thumb_mid, GFXLibrary.mail2_blue_scrollbar_thumb_bottom);
			this.mailList_scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.mailList_scrollBarValueMoved));
			this.mailList_scrollBar.setScrollChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate(this.mailList_scrollBarMoved));
			this.mailList_upArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_toparrow_normal;
			this.mailList_upArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_toparrow_over;
			this.mailList_upArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_toparrow_in;
			this.mailList_upArrow.Position = new Point(this.mailList_scrollBar.Position.X, 0);
			this.mailList_upArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_ScrollUp), "MailScreen_scroll_up");
			this.mailList_listArea.addControl(this.mailList_upArrow);
			this.mailList_downArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_bottomarrow_normal;
			this.mailList_downArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_bottomarrow_over;
			this.mailList_downArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_bottomarrow_in;
			this.mailList_downArrow.Position = new Point(this.mailList_scrollBar.Position.X, this.mailList_scrollBar.Position.Y + this.mailList_scrollBar.Size.Height);
			this.mailList_downArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_ScrollDown), "MailScreen_scroll_down");
			this.mailList_listArea.addControl(this.mailList_downArrow);
			this.mailList_scrollTabLines.Image = GFXLibrary.mail2_blue_scrollbar_thumb_mid_lines;
			this.mailList_scrollTabLines.Position = new Point(this.mailList_scrollBar.TabPosition.X, (this.mailList_scrollBar.TabSize - 8) / 2 + this.mailList_scrollBar.TabPosition.Y);
			this.mailList_scrollBar.addControl(this.mailList_scrollTabLines);
			this.mailList_mouseWheelArea.Position = new Point(0, 0);
			this.mailList_mouseWheelArea.Size = this.mailList_listArea.Size;
			this.mailList_mouseWheelArea.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mailList_MouseWheel));
			this.mailList_listArea.addControl(this.mailList_mouseWheelArea);
			this.mailList_iconArea.Position = new Point(776, 8);
			this.mailList_iconArea.Size = new Size(209, 504);
			this.mailListArea.addControl(this.mailList_iconArea);
			this.mailList_iconNewMail.ImageNorm = GFXLibrary.mail2_large_button_normal;
			this.mailList_iconNewMail.ImageOver = GFXLibrary.mail2_large_button_over;
			this.mailList_iconNewMail.ImageClick = GFXLibrary.mail2_large_button_over;
			this.mailList_iconNewMail.Position = new Point(6, 19);
			this.mailList_iconNewMail.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			if (Program.mySettings.LanguageIdent == "ko")
			{
				this.mailList_iconNewMail.Text.Position = new Point(55, 0);
				this.mailList_iconNewMail.Text.Size = new Size(127, this.mailList_iconNewMail.Text.Size.Height);
				this.mailList_iconNewMail.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			}
			else
			{
				this.mailList_iconNewMail.Text.Position = new Point(63, 0);
				this.mailList_iconNewMail.Text.Size = new Size(107, this.mailList_iconNewMail.Text.Size.Height);
				this.mailList_iconNewMail.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			}
			this.mailList_iconNewMail.TextYOffset = -6;
			this.mailList_iconNewMail.Text.Text = SK.Text("MailScreen_New_Mail", "New Mail");
			this.mailList_iconNewMail.Text.Color = global::ARGBColors.Black;
			this.mailList_iconNewMail.ImageIcon = GFXLibrary.mail2_folder_icon_64_open;
			this.mailList_iconNewMail.ImageIconPosition = new Point(5, -24);
			this.mailList_iconNewMail.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_NewMail), "MailScreen_new_mail");
			this.mailList_iconArea.addControl(this.mailList_iconNewMail);
			this.mailList_manageBlocked.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_manageBlocked.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_manageBlocked.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_manageBlocked.Position = new Point(22, 460);
			this.mailList_manageBlocked.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_manageBlocked.TextYOffset = -2;
			this.mailList_manageBlocked.Text.Text = SK.Text("MailBlock_manage", "Manage Blocked Users");
			this.mailList_manageBlocked.Text.Color = global::ARGBColors.Black;
			this.mailList_manageBlocked.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_BlockUser2), "MailScreen_block");
			this.mailList_iconArea.addControl(this.mailList_manageBlocked);
			this.mailList_userFilterLabel.Text = SK.Text("MailBlock_username_filter", "Filter By Username");
			this.mailList_userFilterLabel.Position = new Point(0, 407);
			this.mailList_userFilterLabel.Size = new Size(196, 20);
			this.mailList_userFilterLabel.Color = global::ARGBColors.Black;
			this.mailList_userFilterLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_userFilterLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mailList_iconArea.addControl(this.mailList_userFilterLabel);
			int num = 160;
			this.mailList_iconSelectedBack.Image = GFXLibrary.mail2_new_mail_tab_panel;
			this.mailList_iconSelectedBack.Position = new Point(6, 119 - num);
			this.mailList_iconSelectedBack.ClipRect = new Rectangle(0, num, this.mailList_iconSelectedBack.Image.Width, 366 - num);
			this.mailList_iconSelectedBack.Visible = false;
			this.mailList_iconArea.addControl(this.mailList_iconSelectedBack);
			this.mailList_iconSelected.Image = GFXLibrary.mail2_large_button_normal;
			this.mailList_iconSelected.Position = new Point(6, 94);
			this.mailList_iconSelected.Visible = false;
			this.mailList_iconArea.addControl(this.mailList_iconSelected);
			this.mailList_iconSelectedIcon.Image = GFXLibrary.mail2_mail_icon;
			this.mailList_iconSelectedIcon.Position = new Point(6, -24);
			this.mailList_iconSelected.addControl(this.mailList_iconSelectedIcon);
			this.mailList_iconSelectedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailList_iconSelectedLabel.Position = new Point(57, -6);
			this.mailList_iconSelectedLabel.Size = new Size(this.mailList_iconSelected.Size.Width - 63, this.mailList_iconSelected.Size.Height);
			this.mailList_iconSelectedLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.mailList_iconSelectedLabel.Text = SK.Text("MailScreen_Selected_Mail", "Selected Mail");
			this.mailList_iconSelectedLabel.Color = global::ARGBColors.Black;
			this.mailList_iconSelected.addControl(this.mailList_iconSelectedLabel);
			this.mailList_iconSelectedOpen.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_iconSelectedOpen.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_iconSelectedOpen.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_iconSelectedOpen.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 120);
			this.mailList_iconSelectedOpen.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_iconSelectedOpen.TextYOffset = -2;
			this.mailList_iconSelectedOpen.Text.Text = SK.Text("MailScreen_Open", "Open");
			this.mailList_iconSelectedOpen.Text.Color = global::ARGBColors.Black;
			this.mailList_iconSelectedOpen.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_OpenMail), "MailScreen_open_mail");
			this.mailList_iconSelectedBack.addControl(this.mailList_iconSelectedOpen);
			this.mailList_iconSelectedUnread.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_iconSelectedUnread.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_iconSelectedUnread.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_iconSelectedUnread.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 90);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr")
			{
				this.mailList_iconSelectedUnread.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			}
			else
			{
				this.mailList_iconSelectedUnread.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			}
			this.mailList_iconSelectedUnread.TextYOffset = -2;
			this.mailList_iconSelectedUnread.Text.Text = SK.Text("MailScreen_Mark_As_Unread", "Mark as Unread");
			this.mailList_iconSelectedUnread.Text.Color = global::ARGBColors.Black;
			this.mailList_iconSelectedUnread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_MarkAsUnRead), "MailScreen_mark_as_unread");
			this.mailList_iconSelectedBack.addControl(this.mailList_iconSelectedUnread);
			this.mailList_iconSelectedRead.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_iconSelectedRead.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_iconSelectedRead.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_iconSelectedRead.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 60);
			this.mailList_iconSelectedRead.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_iconSelectedRead.TextYOffset = -2;
			this.mailList_iconSelectedRead.Text.Text = SK.Text("MailScreen_Mark_As_Read", "Mark as Read");
			this.mailList_iconSelectedRead.Text.Color = global::ARGBColors.Black;
			this.mailList_iconSelectedRead.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_MarkAsRead), "MailScreen_mark_as_read");
			this.mailList_iconSelectedBack.addControl(this.mailList_iconSelectedRead);
			this.mailList_iconSelectedMoveThread.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_iconSelectedMoveThread.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_iconSelectedMoveThread.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_iconSelectedMoveThread.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 30);
			this.mailList_iconSelectedMoveThread.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_iconSelectedMoveThread.TextYOffset = -2;
			this.mailList_iconSelectedMoveThread.Text.Text = SK.Text("MailScreen_Move_This_Thread", "Move This Thread");
			this.mailList_iconSelectedMoveThread.Text.Color = global::ARGBColors.Black;
			this.mailList_iconSelectedMoveThread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_MoveThread), "MailScreen_move_thread");
			this.mailList_iconSelectedBack.addControl(this.mailList_iconSelectedMoveThread);
			this.mailList_iconSelectedDelete.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_iconSelectedDelete.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_iconSelectedDelete.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_iconSelectedDelete.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50);
			this.mailList_iconSelectedDelete.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_iconSelectedDelete.TextYOffset = -2;
			this.mailList_iconSelectedDelete.Text.Text = SK.Text("MailScreen_Delete_Thread", "Delete Thread");
			this.mailList_iconSelectedDelete.Text.Color = global::ARGBColors.Black;
			this.mailList_iconSelectedDelete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_DeleteThread), "MailScreen_delete_thread");
			this.mailList_iconSelectedBack.addControl(this.mailList_iconSelectedDelete);
			this.mailList_MoveFolderLabel.Text = "<- " + SK.Text("MailScreen_Select_Target_Folder", "Select Target Folder for the Selected Mail.");
			this.mailList_MoveFolderLabel.Color = global::ARGBColors.White;
			this.mailList_MoveFolderLabel.DropShadowColor = global::ARGBColors.Black;
			this.mailList_MoveFolderLabel.Position = new Point(140, 30);
			this.mailList_MoveFolderLabel.Size = new Size(500, 100);
			this.mailList_MoveFolderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.mailList_MoveFolderLabel.Visible = false;
			this.mailListArea.addControl(this.mailList_MoveFolderLabel);
			this.mailList_MoveFolderCancel.ImageNorm = GFXLibrary.mail2_large_button_normal;
			this.mailList_MoveFolderCancel.ImageOver = GFXLibrary.mail2_large_button_over;
			this.mailList_MoveFolderCancel.ImageClick = GFXLibrary.mail2_large_button_over;
			this.mailList_MoveFolderCancel.Position = new Point(782, 27);
			this.mailList_MoveFolderCancel.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mailList_MoveFolderCancel.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.mailList_MoveFolderCancel.TextYOffset = -6;
			this.mailList_MoveFolderCancel.Text.Text = SK.Text("MailScreen_Cancel_Move", "Cancel Move");
			this.mailList_MoveFolderCancel.Text.Color = global::ARGBColors.Black;
			this.mailList_MoveFolderCancel.Visible = false;
			this.mailList_MoveFolderCancel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_CancelMove), "MailScreen_cancel_move");
			this.mailListArea.addControl(this.mailList_MoveFolderCancel);
			this.mailThreadArea.Position = new Point(0, 0);
			this.mailThreadArea.Size = this.mainBodyArea.Size;
			this.mailThreadArea.Visible = false;
			this.mainBodyArea.addControl(this.mailThreadArea);
			this.newMailArea.Position = new Point(0, 0);
			this.newMailArea.Size = this.mainBodyArea.Size;
			this.newMailArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			this.tbSubject.MaxLength = 100;
			this.mainBodyArea.addControl(this.newMailArea);
			this.mailCreateFolderArea.Position = new Point(0, 0);
			this.mailCreateFolderArea.Size = this.mainBodyArea.Size;
			this.mailCreateFolderArea.Visible = false;
			this.mainBodyArea.addControl(this.mailCreateFolderArea);
			num = 204;
			this.mailList_createFolderBack.Image = GFXLibrary.mail2_new_mail_tab_panel;
			int x = (this.mailCreateFolderArea.Size.Width - this.mailList_iconSelectedBack.Image.Width) / 2;
			int num2 = 50;
			this.mailList_createFolderBack.Position = new Point(x, 119 - num + num2);
			this.mailList_createFolderBack.ClipRect = new Rectangle(0, num, this.mailList_iconSelectedBack.Image.Width, 366 - num);
			this.mailCreateFolderArea.addControl(this.mailList_createFolderBack);
			this.mailList_createFolderHeader.Image = GFXLibrary.mail2_large_button_normal;
			this.mailList_createFolderHeader.Position = new Point(x, 94 + num2);
			this.mailCreateFolderArea.addControl(this.mailList_createFolderHeader);
			this.mailList_createFolderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mailList_createFolderLabel.Position = new Point(0, 0);
			this.mailList_createFolderLabel.Size = new Size(this.mailList_createFolderHeader.Size.Width, this.mailList_createFolderHeader.Size.Height - 8);
			this.mailList_createFolderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mailList_createFolderLabel.Text = SK.Text("MailScreen_Create_New_Folder", "Create New Folder");
			this.mailList_createFolderLabel.Color = global::ARGBColors.Black;
			this.mailList_createFolderHeader.addControl(this.mailList_createFolderLabel);
			this.mailList_createFolderOK.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_createFolderOK.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_createFolderOK.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_createFolderOK.Position = new Point(14, this.mailList_createFolderBack.Height - 50 - 30);
			this.mailList_createFolderOK.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_createFolderOK.TextYOffset = -2;
			this.mailList_createFolderOK.Text.Text = SK.Text("MailScreen_Create_Folder", "Create Folder");
			this.mailList_createFolderOK.Text.Color = global::ARGBColors.Black;
			this.mailList_createFolderOK.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_CreateFolder), "MailScreen_create_folder");
			this.mailList_createFolderBack.addControl(this.mailList_createFolderOK);
			this.mailList_createFolderCancel.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailList_createFolderCancel.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailList_createFolderCancel.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailList_createFolderCancel.Position = new Point(14, this.mailList_createFolderBack.Height - 50);
			this.mailList_createFolderCancel.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailList_createFolderCancel.TextYOffset = -2;
			this.mailList_createFolderCancel.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.mailList_createFolderCancel.Text.Color = global::ARGBColors.Black;
			this.mailList_createFolderCancel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_CancelCreateFolder), "MailScreen_cancel_create_folder");
			this.mailList_createFolderBack.addControl(this.mailList_createFolderCancel);
			this.mailThread_listArea.Position = new Point(15, 8);
			this.mailThread_listArea.Size = new Size(748, 504);
			this.mailThreadArea.addControl(this.mailThread_listArea);
			size = this.mailThread_listArea.Size;
			position = this.mailThread_listArea.Position;
			this.mailThread_listShadowTR.Image = GFXLibrary.mail_shadow_top_right;
			this.mailThread_listShadowTR.Position = new Point(position.X + size.Width, position.Y);
			this.mailThreadArea.addControl(this.mailThread_listShadowTR);
			this.mailThread_listShadowBR.Image = GFXLibrary.mail_shadow_bottom_right;
			this.mailThread_listShadowBR.Position = new Point(position.X + size.Width, position.Y + size.Height);
			this.mailThreadArea.addControl(this.mailThread_listShadowBR);
			this.mailThread_listShadowBL.Image = GFXLibrary.mail_shadow_bottom_left;
			this.mailThread_listShadowBL.Position = new Point(position.X, position.Y + size.Height);
			this.mailThreadArea.addControl(this.mailThread_listShadowBL);
			this.mailThread_listShadowR.Image = GFXLibrary.mail_shadow_right;
			this.mailThread_listShadowR.Position = new Point(position.X + size.Width, position.Y + GFXLibrary.mail_shadow_top_right.Height);
			this.mailThread_listShadowR.Size = new Size(GFXLibrary.mail_shadow_right.Width, size.Height - GFXLibrary.mail_shadow_top_right.Height);
			this.mailThreadArea.addControl(this.mailThread_listShadowR);
			this.mailThread_listShadowB.Image = GFXLibrary.mail_shadow_bottom;
			this.mailThread_listShadowB.Position = new Point(position.X + GFXLibrary.mail_shadow_bottom_left.Width, position.Y + size.Height);
			this.mailThread_listShadowB.Size = new Size(size.Width - GFXLibrary.mail_shadow_bottom_left.Width, GFXLibrary.mail_shadow_bottom.Height);
			this.mailThreadArea.addControl(this.mailThread_listShadowB);
			this.mailThread_mainHeaderImage1.Size = new Size(250, 18);
			this.mailThread_mainHeaderImage1.Position = new Point(0, 0);
			this.mailThread_listArea.addControl(this.mailThread_mainHeaderImage1);
			this.mailThread_mainHeaderImage1.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailThread_mainHeaderLabel1.Text = SK.Text("MailScreen_Subject", "Subject");
			this.mailThread_mainHeaderLabel1.Color = global::ARGBColors.Black;
			this.mailThread_mainHeaderLabel1.Position = new Point(4, 0);
			this.mailThread_mainHeaderLabel1.Size = new Size(this.mailThread_mainHeaderImage1.Width - 21, this.mailThread_mainHeaderImage1.Height);
			this.mailThread_mainHeaderLabel1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailThread_mainHeaderLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailThread_mainHeaderImage1.addControl(this.mailThread_mainHeaderLabel1);
			this.mailThread_mainHeaderImage2.Size = new Size(94, 18);
			this.mailThread_mainHeaderImage2.Position = new Point(250, 0);
			this.mailThread_listArea.addControl(this.mailThread_mainHeaderImage2);
			this.mailThread_mainHeaderImage2.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailThread_mainHeaderLabel2.Text = SK.Text("MailScreen_Date", "Date");
			this.mailThread_mainHeaderLabel2.Color = global::ARGBColors.Black;
			this.mailThread_mainHeaderLabel2.Position = new Point(4, 0);
			this.mailThread_mainHeaderLabel2.Size = new Size(this.mailThread_mainHeaderImage2.Width - 8, this.mailThread_mainHeaderImage2.Height);
			this.mailThread_mainHeaderLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailThread_mainHeaderLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailThread_mainHeaderImage2.addControl(this.mailThread_mainHeaderLabel2);
			this.mailThread_mainHeaderImage3.Size = new Size(112, 18);
			this.mailThread_mainHeaderImage3.Position = new Point(344, 0);
			this.mailThread_listArea.addControl(this.mailThread_mainHeaderImage3);
			this.mailThread_mainHeaderImage3.Create(GFXLibrary.mail_topbar_left_normal, GFXLibrary.mail_topbar_middle_normal, GFXLibrary.mail_topbar_right_normal);
			this.mailThread_mainHeaderLabel3.Text = SK.Text("MailScreen_From", "From");
			this.mailThread_mainHeaderLabel3.Color = global::ARGBColors.Black;
			this.mailThread_mainHeaderLabel3.Position = new Point(4, 0);
			this.mailThread_mainHeaderLabel3.Size = new Size(this.mailThread_mainHeaderImage3.Width - 8, this.mailThread_mainHeaderImage3.Height);
			this.mailThread_mainHeaderLabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.mailThread_mainHeaderLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mailThread_mainHeaderImage3.addControl(this.mailThread_mainHeaderLabel3);
			for (int k = 0; k < 27; k++)
			{
				MailScreen.MailThreadLine mailThreadLine = this.getMailThreadLine(k);
				mailThreadLine.Position = new Point(0, 17 + k * 18);
				mailThreadLine.Size = new Size(456, 18);
				mailThreadLine.BodyText.Text = "";
				mailThreadLine.BodyText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailThreadLine.BodyText.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
				mailThreadLine.Sender.Text = "";
				mailThreadLine.Sender.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailThreadLine.Sender.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
				mailThreadLine.Date = DateTime.MinValue;
				mailThreadLine.DateLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				mailThreadLine.Data = k;
				mailThreadLine.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailItemClicked));
				this.mailThread_listArea.addControl(mailThreadLine);
				mailThreadLine.setup();
			}
			this.lastMailItemClicked = -1;
			this.mailThread_scrollBar.Position = new Point(456, 17);
			this.mailThread_scrollBar.Size = new Size(16, this.mailThread_listArea.Size.Height - 17 - 17 - 1);
			this.mailThread_listArea.addControl(this.mailThread_scrollBar);
			this.mailThread_scrollBar.Value = 0;
			this.mailThread_scrollBar.Max = 0;
			this.mailThread_scrollBar.NumVisibleLines = 27;
			this.mailThread_scrollBar.TabMinSize = 26;
			this.mailThread_scrollBar.OffsetTL = new Point(0, 0);
			this.mailThread_scrollBar.OffsetBR = new Point(0, 0);
			this.mailThread_scrollBar.Create(GFXLibrary.mail2_blue_scrollbar_bar_top, GFXLibrary.mail2_blue_scrollbar_bar_middle, GFXLibrary.mail2_blue_scrollbar_bar_bottom, GFXLibrary.mail2_blue_scrollbar_thumb_top, GFXLibrary.mail2_blue_scrollbar_thumb_mid, GFXLibrary.mail2_blue_scrollbar_thumb_bottom);
			this.mailThread_scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.mailThread_scrollBarValueMoved));
			this.mailThread_scrollBar.setScrollChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate(this.mailThread_scrollBarMoved));
			this.mailThread_upArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_toparrow_normal;
			this.mailThread_upArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_toparrow_over;
			this.mailThread_upArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_toparrow_in;
			this.mailThread_upArrow.Position = new Point(this.mailThread_scrollBar.Position.X, 0);
			this.mailThread_upArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailThread_ScrollUp), "MailScreen_scroll_up");
			this.mailThread_listArea.addControl(this.mailThread_upArrow);
			this.mailThread_downArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_bottomarrow_normal;
			this.mailThread_downArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_bottomarrow_over;
			this.mailThread_downArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_bottomarrow_in;
			this.mailThread_downArrow.Position = new Point(this.mailThread_scrollBar.Position.X, this.mailThread_scrollBar.Position.Y + this.mailThread_scrollBar.Size.Height);
			this.mailThread_downArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailThread_ScrollDown), "MailScreen_scroll_down");
			this.mailThread_listArea.addControl(this.mailThread_downArrow);
			this.mailThread_scrollTabLines.Image = GFXLibrary.mail2_blue_scrollbar_thumb_mid_lines;
			this.mailThread_scrollTabLines.Position = new Point(this.mailThread_scrollBar.TabPosition.X, (this.mailThread_scrollBar.TabSize - 8) / 2 + this.mailThread_scrollBar.TabPosition.Y);
			this.mailThread_scrollBar.addControl(this.mailThread_scrollTabLines);
			this.mailThread_mailHeaderBack.Position = new Point(471, 0);
			this.mailThread_mailHeaderBack.Size = new Size(277, 37);
			this.mailThread_mailHeaderBack.FillColor = CustomSelfDrawPanel.MailBodyColor;
			this.mailThread_listArea.addControl(this.mailThread_mailHeaderBack);
			this.mailThread_mailBodyBack.Position = new Point(471, 38);
			this.mailThread_mailBodyBack.Size = new Size(277, 466);
			this.mailThread_mailBodyBack.FillColor = CustomSelfDrawPanel.MailBodyColor;
			this.mailThread_listArea.addControl(this.mailThread_mailBodyBack);
			this.mailThread_mailHeaderFromLabel.Text = SK.Text("MailScreen_From", "From") + " :";
			this.mailThread_mailHeaderFromLabel.Color = global::ARGBColors.Black;
			this.mailThread_mailHeaderFromLabel.Position = new Point(6, 3);
			this.mailThread_mailHeaderFromLabel.Size = new Size(this.mailThread_mailHeaderBack.Width - 10, 20);
			this.mailThread_mailHeaderFromLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.mailThread_mailHeaderFromLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mailThread_mailHeaderBack.addControl(this.mailThread_mailHeaderFromLabel);
			this.mailThread_mailHeaderFromNameLabel.Text = "";
			this.mailThread_mailHeaderFromNameLabel.Color = global::ARGBColors.Black;
			this.mailThread_mailHeaderFromNameLabel.Position = new Point(56, 3);
			this.mailThread_mailHeaderFromNameLabel.Size = new Size(this.mailThread_mailHeaderBack.Width - 60, 20);
			this.mailThread_mailHeaderFromNameLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.mailThread_mailHeaderFromNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mailThread_mailHeaderFromNameLabel.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
			this.mailThread_mailHeaderBack.addControl(this.mailThread_mailHeaderFromNameLabel);
			this.mailThread_mailHeaderDateLabel.Text = SK.Text("MailScreen_Date", "Date") + " :";
			this.mailThread_mailHeaderDateLabel.Color = global::ARGBColors.Black;
			this.mailThread_mailHeaderDateLabel.Position = new Point(6, 20);
			this.mailThread_mailHeaderDateLabel.Size = new Size(this.mailThread_mailHeaderBack.Width - 10, 20);
			this.mailThread_mailHeaderDateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.mailThread_mailHeaderDateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mailThread_mailHeaderBack.addControl(this.mailThread_mailHeaderDateLabel);
			this.mailThread_mailHeaderDateValueLabel.Text = "";
			this.mailThread_mailHeaderDateValueLabel.Color = global::ARGBColors.Black;
			this.mailThread_mailHeaderDateValueLabel.Position = new Point(56, 20);
			this.mailThread_mailHeaderDateValueLabel.Size = new Size(this.mailThread_mailHeaderBack.Width - 60, 20);
			this.mailThread_mailHeaderDateValueLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.mailThread_mailHeaderDateValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mailThread_mailHeaderBack.addControl(this.mailThread_mailHeaderDateValueLabel);
			this.mailThread_fromShield.Image = null;
			this.mailThread_fromShield.Position = new Point(242, 3);
			this.mailThread_fromShield.Visible = false;
			this.mailThread_mailHeaderBack.addControl(this.mailThread_fromShield);
			this.mailThread_mailBodyText.Text = "";
			this.mailThread_mailBodyText.Color = global::ARGBColors.Black;
			this.mailThread_mailBodyText.Position = new Point(4, 4);
			this.mailThread_mailBodyText.Size = new Size(this.mailThread_mailBodyBack.Width - 8 - 16, this.mailThread_mailBodyBack.Height - 8);
			this.mailThread_mailBodyText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_mailBodyText.setTextHeightChangedCallback(new CustomSelfDrawPanel.CSDScrollLabel.CSD_TextHeightChanged(this.bodyTextHeightChanged));
			this.mailThread_mailBodyText.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
			this.mailThread_mailBodyText.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailTextClicked));
			this.mailThread_mailBodyBack.addControl(this.mailThread_mailBodyText);
			this.mailThreadBody_scrollBar.Position = new Point(this.mailThread_mailBodyBack.Width - 16, 17);
			this.mailThreadBody_scrollBar.Size = new Size(16, this.mailThread_mailBodyBack.Size.Height - 17 - 17 - 1);
			this.mailThread_mailBodyBack.addControl(this.mailThreadBody_scrollBar);
			this.mailThreadBody_scrollBar.Value = 0;
			this.mailThreadBody_scrollBar.Max = 0;
			this.mailThreadBody_scrollBar.NumVisibleLines = this.mailThread_mailBodyText.Height;
			this.mailThreadBody_scrollBar.TabMinSize = 26;
			this.mailThreadBody_scrollBar.OffsetTL = new Point(0, 0);
			this.mailThreadBody_scrollBar.OffsetBR = new Point(0, 0);
			this.mailThreadBody_scrollBar.Create(GFXLibrary.mail2_blue_scrollbar_bar_top, GFXLibrary.mail2_blue_scrollbar_bar_middle, GFXLibrary.mail2_blue_scrollbar_bar_bottom, GFXLibrary.mail2_blue_scrollbar_thumb_top, GFXLibrary.mail2_blue_scrollbar_thumb_mid, GFXLibrary.mail2_blue_scrollbar_thumb_bottom);
			this.mailThreadBody_scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.mailThreadBody_scrollBarValueMoved));
			this.mailThreadBody_scrollBar.setScrollChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate(this.mailThreadBody_scrollBarMoved));
			this.mailThreadBody_upArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_toparrow_normal;
			this.mailThreadBody_upArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_toparrow_over;
			this.mailThreadBody_upArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_toparrow_in;
			this.mailThreadBody_upArrow.Position = new Point(this.mailThreadBody_scrollBar.Position.X, 0);
			this.mailThreadBody_upArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailThreadBody_ScrollUp), "MailScreen_scroll_up");
			this.mailThread_mailBodyBack.addControl(this.mailThreadBody_upArrow);
			this.mailThreadBody_downArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_bottomarrow_normal;
			this.mailThreadBody_downArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_bottomarrow_over;
			this.mailThreadBody_downArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_bottomarrow_in;
			this.mailThreadBody_downArrow.Position = new Point(this.mailThreadBody_scrollBar.Position.X, this.mailThreadBody_scrollBar.Position.Y + this.mailThreadBody_scrollBar.Size.Height);
			this.mailThreadBody_downArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailThreadBody_ScrollDown), "MailScreen_scroll_down");
			this.mailThread_mailBodyBack.addControl(this.mailThreadBody_downArrow);
			this.mailThreadBody_scrollTabLines.Image = GFXLibrary.mail2_blue_scrollbar_thumb_mid_lines;
			this.mailThreadBody_scrollTabLines.Position = new Point(this.mailThreadBody_scrollBar.TabPosition.X, (this.mailThreadBody_scrollBar.TabSize - 8) / 2 + this.mailThreadBody_scrollBar.TabPosition.Y);
			this.mailThreadBody_scrollBar.addControl(this.mailThreadBody_scrollTabLines);
			this.mailThread_mouseWheelArea.Position = new Point(0, 0);
			this.mailThread_mouseWheelArea.Size = new Size(471, this.mailList_listArea.Size.Height);
			this.mailThread_mouseWheelArea.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mailThread_MouseWheel));
			this.mailThread_listArea.addControl(this.mailThread_mouseWheelArea);
			this.mailThreadBody_mouseWheelArea.Position = new Point(471, 0);
			this.mailThreadBody_mouseWheelArea.Size = new Size(284, this.mailList_listArea.Size.Height);
			this.mailThreadBody_mouseWheelArea.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mailThreadBody_MouseWheel));
			this.mailThread_listArea.addControl(this.mailThreadBody_mouseWheelArea);
			this.mailThread_iconArea.Position = new Point(776, 8);
			this.mailThread_iconArea.Size = new Size(209, 504);
			this.mailThreadArea.addControl(this.mailThread_iconArea);
			this.mailThread_iconBack.ImageNorm = GFXLibrary.mail2_large_button_normal;
			this.mailThread_iconBack.ImageOver = GFXLibrary.mail2_large_button_over;
			this.mailThread_iconBack.ImageClick = GFXLibrary.mail2_large_button_over;
			this.mailThread_iconBack.Position = new Point(6, 19);
			this.mailThread_iconBack.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.mailThread_iconBack.Text.Position = new Point(55, 0);
				this.mailThread_iconBack.Text.Size = new Size(this.mailThread_iconBack.Size.Width - 55, this.mailThread_iconBack.Size.Height);
			}
			else if (Program.mySettings.LanguageIdent == "de")
			{
				this.mailThread_iconBack.Text.Position = new Point(55, 0);
			}
			else if (Program.mySettings.LanguageIdent == "ko")
			{
				this.mailThread_iconBack.Text.Position = new Point(19, 0);
			}
			else
			{
				this.mailThread_iconBack.Text.Position = new Point(63, 0);
			}
			this.mailThread_iconBack.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mailThread_iconBack.TextYOffset = -6;
			this.mailThread_iconBack.Text.Text = SK.Text("MailScreen_Back_To_Mail_List", "Back To Mail List");
			this.mailThread_iconBack.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconBack.ImageIcon = GFXLibrary.mail2_mail_icon;
			this.mailThread_iconBack.ImageIconPosition = new Point(5, -24);
			this.mailThread_iconBack.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.returnToMailList), "MailScreen_back_to_mail_list");
			this.mailThread_iconArea.addControl(this.mailThread_iconBack);
			num = 100;
			this.mailThread_iconSelectedBack.Image = GFXLibrary.mail2_new_mail_tab_panel;
			this.mailThread_iconSelectedBack.Position = new Point(6, 119 - num);
			this.mailThread_iconSelectedBack.ClipRect = new Rectangle(0, num, this.mailList_iconSelectedBack.Image.Width, 366 - num);
			this.mailThread_iconSelectedBack.Visible = false;
			this.mailThread_iconArea.addControl(this.mailThread_iconSelectedBack);
			this.mailThread_iconSelected.Image = GFXLibrary.mail2_large_button_normal;
			this.mailThread_iconSelected.Position = new Point(6, 94);
			this.mailThread_iconSelected.Visible = false;
			this.mailThread_iconArea.addControl(this.mailThread_iconSelected);
			this.mailThread_iconSelectedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mailThread_iconSelectedLabel.Position = new Point(0, 0);
			this.mailThread_iconSelectedLabel.Size = new Size(this.mailList_iconSelected.Size.Width, this.mailList_iconSelected.Size.Height - 6);
			this.mailThread_iconSelectedLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mailThread_iconSelectedLabel.Text = SK.Text("MailScreen_Selected_Mail", "Selected Mail");
			this.mailThread_iconSelectedLabel.Color = global::ARGBColors.Black;
			this.mailThread_iconSelected.addControl(this.mailThread_iconSelectedLabel);
			this.mailThread_iconSelectedReply.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_iconSelectedReply.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_iconSelectedReply.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_iconSelectedReply.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 150);
			this.mailThread_iconSelectedReply.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_iconSelectedReply.TextYOffset = -2;
			this.mailThread_iconSelectedReply.Text.Text = SK.Text("MailScreen_Reply_To_Thread", "Reply To Thread");
			this.mailThread_iconSelectedReply.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconSelectedReply.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailThread_reply), "MailScreen_reply");
			this.mailThread_iconSelectedBack.addControl(this.mailThread_iconSelectedReply);
			this.mailThread_iconSelectedView.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_iconSelectedView.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_iconSelectedView.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_iconSelectedView.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 180);
			this.mailThread_iconSelectedView.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_iconSelectedView.TextYOffset = -2;
			this.mailThread_iconSelectedView.Text.Text = SK.Text("MailScreen_View_Mail_Post", "View");
			this.mailThread_iconSelectedView.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailTextClicked), "MailScreen_reply");
			this.mailThread_iconSelectedView.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconSelectedBack.addControl(this.mailThread_iconSelectedView);
			this.mailThread_iconSelectedForward.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_iconSelectedForward.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_iconSelectedForward.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_iconSelectedForward.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 120);
			this.mailThread_iconSelectedForward.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_iconSelectedForward.TextYOffset = -2;
			this.mailThread_iconSelectedForward.Text.Text = SK.Text("MailScreen_Forward_Thread", "Forward Thread");
			this.mailThread_iconSelectedForward.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconSelectedForward.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_ForwardMail), "MailScreen_forward");
			this.mailThread_iconSelectedBack.addControl(this.mailThread_iconSelectedForward);
			this.mailThread_iconSelectedBlockPoster.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_iconSelectedBlockPoster.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_iconSelectedBlockPoster.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_iconSelectedBlockPoster.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 90);
			this.mailThread_iconSelectedBlockPoster.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_iconSelectedBlockPoster.TextYOffset = -2;
			this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailScreen_Block_This_User", "Block This User");
			this.mailThread_iconSelectedBlockPoster.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconSelectedBlockPoster.Enabled = false;
			this.mailThread_iconSelectedBlockPoster.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_BlockUser), "MailScreen_block");
			this.mailThread_iconSelectedBack.addControl(this.mailThread_iconSelectedBlockPoster);
			this.mailThread_iconSelectedReportMail.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_iconSelectedReportMail.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_iconSelectedReportMail.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_iconSelectedReportMail.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 60);
			this.mailThread_iconSelectedReportMail.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_iconSelectedReportMail.TextYOffset = -2;
			this.mailThread_iconSelectedReportMail.Text.Text = SK.Text("MailScreen_Report_This_Mail", "Report This Mail");
			this.mailThread_iconSelectedReportMail.Text.Color = global::ARGBColors.Black;
			this.mailThread_iconSelectedReportMail.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_ReportMail), "MailScreen_report");
			this.mailThread_iconSelectedReportMail.CustomTooltipID = 503;
			this.mailThread_iconSelectedBack.addControl(this.mailThread_iconSelectedReportMail);
			this.mailThread_openAttachments.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.mailThread_openAttachments.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.mailThread_openAttachments.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.mailThread_openAttachments.Position = new Point(14, this.mailList_iconSelectedBack.Height - 50 - 30);
			this.mailThread_openAttachments.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.mailThread_openAttachments.TextYOffset = -2;
			this.mailThread_openAttachments.Text.Text = SK.Text("MailScreen_Open_Attachments", "Open Targets");
			this.mailThread_openAttachments.Text.Color = global::ARGBColors.Black;
			this.mailThread_openAttachments.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailList_OpenAttachmentWindow), "MailScreen_attachments");
			this.mailThread_openAttachments.CustomTooltipID = 514;
			this.mailThread_iconSelectedBack.addControl(this.mailThread_openAttachments);
			this.newMail_newMailArea.Position = new Point(16, 6);
			this.newMail_newMailArea.Size = new Size(748, 504);
			this.newMailArea.addControl(this.newMail_newMailArea);
			this.newMail_mailHeaderBack.Position = new Point(0, 0);
			this.newMail_mailHeaderBack.Size = new Size(748, 33);
			this.newMail_mailHeaderBack.FillColor = CustomSelfDrawPanel.MailBodyColor;
			this.newMail_newMailArea.addControl(this.newMail_mailHeaderBack);
			this.newMail_mailBodyBack.Position = new Point(0, 34);
			this.newMail_mailBodyBack.Size = new Size(748, 470);
			this.newMail_mailBodyBack.FillColor = CustomSelfDrawPanel.MailBodyColor;
			this.newMail_newMailArea.addControl(this.newMail_mailBodyBack);
			this.newMail_breakbar.Image = GFXLibrary.mail_horizontal_bar;
			this.newMail_breakbar.Position = new Point(0, 26);
			this.newMail_newMailArea.addControl(this.newMail_breakbar);
			size = this.newMail_newMailArea.Size;
			position = this.newMail_newMailArea.Position;
			this.newMail_bodyShadowTR.Image = GFXLibrary.mail_shadow_top_right;
			this.newMail_bodyShadowTR.Position = new Point(position.X + size.Width, position.Y);
			this.newMailArea.addControl(this.newMail_bodyShadowTR);
			this.newMail_bodyShadowBR.Image = GFXLibrary.mail_shadow_bottom_right;
			this.newMail_bodyShadowBR.Position = new Point(position.X + size.Width, position.Y + size.Height);
			this.newMailArea.addControl(this.newMail_bodyShadowBR);
			this.newMail_bodyShadowBL.Image = GFXLibrary.mail_shadow_bottom_left;
			this.newMail_bodyShadowBL.Position = new Point(position.X, position.Y + size.Height);
			this.newMailArea.addControl(this.newMail_bodyShadowBL);
			this.newMail_bodyShadowR.Image = GFXLibrary.mail_shadow_right;
			this.newMail_bodyShadowR.Position = new Point(position.X + size.Width, position.Y + GFXLibrary.mail_shadow_top_right.Height);
			this.newMail_bodyShadowR.Size = new Size(GFXLibrary.mail_shadow_right.Width, size.Height - GFXLibrary.mail_shadow_top_right.Height);
			this.newMailArea.addControl(this.newMail_bodyShadowR);
			this.newMail_bodyShadowB.Image = GFXLibrary.mail_shadow_bottom;
			this.newMail_bodyShadowB.Position = new Point(position.X + GFXLibrary.mail_shadow_bottom_left.Width, position.Y + size.Height);
			this.newMail_bodyShadowB.Size = new Size(size.Width - GFXLibrary.mail_shadow_bottom_left.Width, GFXLibrary.mail_shadow_bottom.Height);
			this.newMailArea.addControl(this.newMail_bodyShadowB);
			this.newMail_SubjectBorder.Size = new Size(663, 17);
			this.newMail_SubjectBorder.Position = new Point(78, 5);
			this.newMail_mailHeaderBack.addControl(this.newMail_SubjectBorder);
			this.newMail_SubjectBorder.Create(GFXLibrary.mail_inset_white_left, GFXLibrary.mail_inset_white_middle, GFXLibrary.mail_inset_white_right);
			this.newMail_ToLabel.Text = SK.Text("MailScreen_To", "To") + " :";
			this.newMail_ToLabel.Color = global::ARGBColors.Black;
			this.newMail_ToLabel.Position = new Point(4, 7);
			this.newMail_ToLabel.Size = new Size(75, 20);
			this.newMail_ToLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.newMail_ToLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.newMail_mailBodyBack.addControl(this.newMail_ToLabel);
			this.newMail_SubjectLabel.Text = SK.Text("MailScreen_Subject", "Subject") + " :";
			this.newMail_SubjectLabel.Color = global::ARGBColors.Black;
			this.newMail_SubjectLabel.Position = new Point(6, 5);
			this.newMail_SubjectLabel.Size = new Size(75, 20);
			this.newMail_SubjectLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.newMail_SubjectLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.newMail_mailHeaderBack.addControl(this.newMail_SubjectLabel);
			this.newMail_separater.Position = new Point(170, 0);
			this.newMail_separater.Size = new Size(0, this.newMail_mailBodyBack.Size.Height);
			this.newMail_separater.LineColor = Color.FromArgb(185, 155, 127);
			this.newMail_mailBodyBack.addControl(this.newMail_separater);
			this.newMail_separater2.Position = new Point(0, 416);
			this.newMail_separater2.Size = new Size(170, 0);
			this.newMail_separater2.LineColor = Color.FromArgb(185, 155, 127);
			this.newMail_mailBodyBack.addControl(this.newMail_separater2);
			this.newMail_ToList.Position = new Point(1, 30);
			this.newMail_ToList.Size = new Size(171, 342);
			this.newMail_mailBodyBack.addControl(this.newMail_ToList);
			this.newMail_ToList.Create(19, 18);
			this.newMail_ToList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_ToLineClicked));
			this.newMail_iconArea.Position = new Point(776, 8);
			this.newMail_iconArea.Size = new Size(209, 504);
			this.newMailArea.addControl(this.newMail_iconArea);
			this.newMail_iconBackButton.ImageNorm = GFXLibrary.mail2_large_button_normal;
			this.newMail_iconBackButton.ImageOver = GFXLibrary.mail2_large_button_over;
			this.newMail_iconBackButton.ImageClick = GFXLibrary.mail2_large_button_over;
			this.newMail_iconBackButton.Position = new Point(6, 19);
			this.newMail_iconBackButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "pt" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it")
			{
				this.newMail_iconBackButton.Text.Position = new Point(55, 0);
				this.newMail_iconBackButton.Text.Size = new Size(this.newMail_iconBackButton.Size.Width - 55, this.newMail_iconBackButton.Size.Height);
			}
			else if (Program.mySettings.LanguageIdent == "de")
			{
				this.newMail_iconBackButton.Text.Position = new Point(55, 0);
			}
			else if (Program.mySettings.LanguageIdent == "ko")
			{
				this.newMail_iconBackButton.Text.Position = new Point(19, 0);
			}
			else
			{
				this.newMail_iconBackButton.Text.Position = new Point(63, 0);
			}
			this.newMail_iconBackButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.newMail_iconBackButton.TextYOffset = -6;
			this.newMail_iconBackButton.Text.Text = SK.Text("MailScreen_Back_To_Mail_List", "Back To Mail List");
			this.newMail_iconBackButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconBackButton.ImageIcon = GFXLibrary.mail2_mail_icon;
			this.newMail_iconBackButton.ImageIconPosition = new Point(5, -24);
			this.newMail_iconBackButton.ClickArea = new Rectangle(0, 0, this.newMail_iconBackButton.Size.Width, this.newMail_iconBackButton.Size.Height - 11);
			this.newMail_iconBackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.returnFromNewMail), "MailScreen_back_to_mail_list");
			this.newMail_iconArea.addControl(this.newMail_iconBackButton);
			num = 3;
			this.newMail_iconBackground.Image = GFXLibrary.mail2_new_mail_tab_panel;
			this.newMail_iconBackground.Position = new Point(6, 95 - num);
			this.newMail_iconBackground.ClipRect = new Rectangle(0, num, this.newMail_iconBackground.Image.Width, 366 - num);
			this.newMail_iconBackground.Visible = true;
			this.newMail_iconArea.addControl(this.newMail_iconBackground);
			this.newMail_iconTab1Area.Position = new Point(0, num + 34);
			this.newMail_iconTab1Area.Size = new Size(this.newMail_iconBackground.Size.Width, 422 - num - 34);
			this.newMail_iconBackground.addControl(this.newMail_iconTab1Area);
			this.newMail_iconTab2Area.Position = new Point(0, num + 34);
			this.newMail_iconTab2Area.Size = new Size(this.newMail_iconBackground.Size.Width, 422 - num - 34);
			this.newMail_iconBackground.addControl(this.newMail_iconTab2Area);
			this.newMail_iconTab3Area.Position = new Point(0, num + 34);
			this.newMail_iconTab3Area.Size = new Size(this.newMail_iconBackground.Size.Width, 422 - num - 34);
			this.newMail_iconBackground.addControl(this.newMail_iconTab3Area);
			this.newMail_iconTab4Area.Position = new Point(0, num + 34);
			this.newMail_iconTab4Area.Size = new Size(this.newMail_iconBackground.Size.Width, 422 - num - 34);
			this.newMail_iconBackground.addControl(this.newMail_iconTab4Area);
			this.newMail_iconTab1Button.Position = new Point(6, 70);
			this.newMail_iconTab1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchTab1Clicked), "MailScreen_tab_1");
			this.newMail_iconTab1Button.CustomTooltipID = 505;
			this.newMail_iconArea.addControl(this.newMail_iconTab1Button);
			this.newMail_iconTab2Button.Position = new Point(57, 70);
			this.newMail_iconTab2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchTab2Clicked), "MailScreen_tab_2");
			this.newMail_iconTab2Button.CustomTooltipID = 506;
			this.newMail_iconArea.addControl(this.newMail_iconTab2Button);
			this.newMail_iconTab3Button.Position = new Point(104, 70);
			this.newMail_iconTab3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchTab3Clicked), "MailScreen_tab_3");
			this.newMail_iconTab3Button.CustomTooltipID = 507;
			this.newMail_iconArea.addControl(this.newMail_iconTab3Button);
			this.newMail_iconTab4Button.Position = new Point(151, 70);
			this.newMail_iconTab4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchTab4Clicked), "MailScreen_tab_4");
			this.newMail_iconTab4Button.CustomTooltipID = 508;
			this.newMail_iconArea.addControl(this.newMail_iconTab4Button);
			this.newMail_iconFindList.Position = new Point(17, 31);
			this.newMail_iconFindList.Size = new Size(160, 216);
			this.newMail_iconTab1Area.addControl(this.newMail_iconFindList);
			this.newMail_iconFindList.Create(12, 18);
			this.newMail_iconFindList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_FindLineClicked));
			this.newMail_iconFindList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_FindLineDoubleClicked));
			this.newMail_iconFindAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconFindAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconFindAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconFindAddButton.Position = new Point(14, 290);
			this.newMail_iconFindAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconFindAddButton.TextYOffset = -2;
			this.newMail_iconFindAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.newMail_iconFindAddButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconFindAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addFindNameToRecipients), "MailScreen_add");
			this.newMail_iconTab1Area.addControl(this.newMail_iconFindAddButton);
			this.newMail_iconFindFavouritesButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconFindFavouritesButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconFindFavouritesButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconFindFavouritesButton.Position = new Point(14, 260);
			this.newMail_iconFindFavouritesButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconFindFavouritesButton.TextYOffset = -2;
			this.newMail_iconFindFavouritesButton.Text.Text = SK.Text("MailScreen_Add_To_Favourites", "Add To Favourites");
			this.newMail_iconFindFavouritesButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconFindFavouritesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addFindNameToFavourites), "MailScreen_add_to_favourites");
			this.newMail_iconTab1Area.addControl(this.newMail_iconFindFavouritesButton);
			this.changeSearchTab(0, false);
			this.newMail_iconRecentList.Position = new Point(17, 13);
			this.newMail_iconRecentList.Size = new Size(160, 234);
			this.newMail_iconTab2Area.addControl(this.newMail_iconRecentList);
			this.newMail_iconRecentList.Create(13, 18);
			this.newMail_iconRecentList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_RecentLineClicked));
			this.newMail_iconRecentList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_RecentLineDoubleClicked));
			this.newMail_iconRecentAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconRecentAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconRecentAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconRecentAddButton.Position = new Point(14, 290);
			this.newMail_iconRecentAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconRecentAddButton.TextYOffset = -2;
			this.newMail_iconRecentAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.newMail_iconRecentAddButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconRecentAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addRecentNameToRecipients), "MailScreen_add");
			this.newMail_iconTab2Area.addControl(this.newMail_iconRecentAddButton);
			this.newMail_iconRecentFavouritesButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconRecentFavouritesButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconRecentFavouritesButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconRecentFavouritesButton.Position = new Point(14, 260);
			this.newMail_iconRecentFavouritesButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconRecentFavouritesButton.TextYOffset = -2;
			this.newMail_iconRecentFavouritesButton.Text.Text = SK.Text("MailScreen_Add_To_Favourites", "Add To Favourites");
			this.newMail_iconRecentFavouritesButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconRecentFavouritesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addRecentNameToFavourites), "MailScreen_add_to_favourites");
			this.newMail_iconTab2Area.addControl(this.newMail_iconRecentFavouritesButton);
			this.newMail_iconFavouritesList.Position = new Point(17, 13);
			this.newMail_iconFavouritesList.Size = new Size(160, 234);
			this.newMail_iconTab3Area.addControl(this.newMail_iconFavouritesList);
			this.newMail_iconFavouritesList.Create(13, 18);
			this.newMail_iconFavouritesList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_FavouritesLineClicked));
			this.newMail_iconFavouritesList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_FavouritesLineDoubleClicked));
			this.newMail_iconFavouritesRemoveButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconFavouritesRemoveButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconFavouritesRemoveButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconFavouritesRemoveButton.Position = new Point(14, 260);
			this.newMail_iconFavouritesRemoveButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconFavouritesRemoveButton.TextYOffset = -2;
			this.newMail_iconFavouritesRemoveButton.Text.Text = SK.Text("MailScreen_Removes_From_Favourites", "Remove From Favourites");
			this.newMail_iconFavouritesRemoveButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconFavouritesRemoveButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.removeNameFromFavourites), "MailScreen_remove_from_favourites");
			this.newMail_iconTab3Area.addControl(this.newMail_iconFavouritesRemoveButton);
			this.newMail_iconFavouritesAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconFavouritesAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconFavouritesAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconFavouritesAddButton.Position = new Point(14, 290);
			this.newMail_iconFavouritesAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconFavouritesAddButton.TextYOffset = -2;
			this.newMail_iconFavouritesAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.newMail_iconFavouritesAddButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconFavouritesAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addFavouritesNameToRecipients), "MailScreen_add");
			this.newMail_iconTab3Area.addControl(this.newMail_iconFavouritesAddButton);
			this.newMail_iconKnownList.Position = new Point(17, 13);
			this.newMail_iconKnownList.Size = new Size(160, 234);
			this.newMail_iconTab4Area.addControl(this.newMail_iconKnownList);
			this.newMail_iconKnownList.Create(13, 18);
			this.newMail_iconKnownList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_KnownLineClicked));
			this.newMail_iconKnownList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.newMail_KnownLineDoubleClicked));
			this.newMail_iconKnownAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconKnownAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconKnownAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconKnownAddButton.Position = new Point(14, 290);
			this.newMail_iconKnownAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconKnownAddButton.TextYOffset = -2;
			this.newMail_iconKnownAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.newMail_iconKnownAddButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconKnownAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addKnownNameToRecipients), "MailScreen_add");
			this.newMail_iconTab4Area.addControl(this.newMail_iconKnownAddButton);
			this.newMail_iconKnownFavouritesButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.newMail_iconKnownFavouritesButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.newMail_iconKnownFavouritesButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.newMail_iconKnownFavouritesButton.Position = new Point(14, 260);
			this.newMail_iconKnownFavouritesButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_iconKnownFavouritesButton.TextYOffset = -2;
			this.newMail_iconKnownFavouritesButton.Text.Text = SK.Text("MailScreen_Add_To_Favourites", "Add To Favourites");
			this.newMail_iconKnownFavouritesButton.Text.Color = global::ARGBColors.Black;
			this.newMail_iconKnownFavouritesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addKnownNameToFavourites), "MailScreen_add_to_favourites");
			this.newMail_iconTab4Area.addControl(this.newMail_iconKnownFavouritesButton);
			this.newMail_iconSendMail.ImageNorm = GFXLibrary.mail2_large_button_normal;
			this.newMail_iconSendMail.ImageOver = GFXLibrary.mail2_large_button_over;
			this.newMail_iconSendMail.ImageClick = GFXLibrary.mail2_large_button_over;
			this.newMail_iconSendMail.Position = new Point(6, 456);
			this.newMail_iconSendMail.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.newMail_iconSendMail.Text.Position = new Point(63, 0);
			this.newMail_iconSendMail.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.newMail_iconSendMail.TextYOffset = -6;
			this.newMail_iconSendMail.Text.Text = SK.Text("MailScreen_Send_Mail", "Send Mail");
			this.newMail_iconSendMail.Text.Color = global::ARGBColors.Black;
			this.newMail_iconSendMail.ImageIcon = GFXLibrary.mail_folder_icon_64_open;
			this.newMail_iconSendMail.ImageIconPosition = new Point(5, -8);
			this.newMail_iconSendMail.Enabled = false;
			this.newMail_iconSendMail.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendMail), "MailScreen_send_mail");
			this.newMail_iconArea.addControl(this.newMail_iconSendMail);
			this.newMail_removeRecipient.ImageNorm = GFXLibrary.button_132_normal;
			this.newMail_removeRecipient.ImageOver = GFXLibrary.button_132_over;
			this.newMail_removeRecipient.ImageClick = GFXLibrary.button_132_in;
			this.newMail_removeRecipient.Position = new Point(19, 377);
			this.newMail_removeRecipient.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_removeRecipient.TextYOffset = -2;
			this.newMail_removeRecipient.Text.Text = SK.Text("MailScreen_Remove", "Remove");
			this.newMail_removeRecipient.Text.Color = global::ARGBColors.Black;
			this.newMail_removeRecipient.Enabled = false;
			this.newMail_removeRecipient.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.removeNameFromRecipients), "MailScreen_remove");
			this.newMail_mailBodyBack.addControl(this.newMail_removeRecipient);
			this.newMail_addAttachments.ImageNorm = GFXLibrary.button_132_normal;
			this.newMail_addAttachments.ImageOver = GFXLibrary.button_132_over;
			this.newMail_addAttachments.ImageClick = GFXLibrary.button_132_in;
			this.newMail_addAttachments.Position = new Point(19, this.newMail_separater2.Y + 8);
			this.newMail_addAttachments.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.newMail_addAttachments.TextYOffset = -2;
			this.newMail_addAttachments.Text.Text = SK.Text("MailScreen_Attachments", "Targets");
			this.newMail_addAttachments.Text.Color = global::ARGBColors.Black;
			this.newMail_addAttachments.Enabled = true;
			this.newMail_addAttachments.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openNewAttachmentsPopup), "MailScreen_openAddAttachments");
			this.newMail_mailBodyBack.addControl(this.newMail_addAttachments);
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x001750EC File Offset: 0x001732EC
		private void changeSearchTab(int tab, bool fromClick)
		{
			this.currentSearchTab = tab;
			this.newMail_iconTab1Button.ImageNorm = GFXLibrary.mail2_users_find_normal;
			this.newMail_iconTab1Button.ImageOver = GFXLibrary.mail2_users_find_over;
			this.newMail_iconTab1Button.ImageClick = GFXLibrary.mail2_users_find_normal;
			this.newMail_iconTab2Button.ImageNorm = GFXLibrary.mail2_users_recent_normal;
			this.newMail_iconTab2Button.ImageOver = GFXLibrary.mail2_users_recent_over;
			this.newMail_iconTab2Button.ImageClick = GFXLibrary.mail2_users_recent_normal;
			this.newMail_iconTab3Button.ImageNorm = GFXLibrary.mail2_users_favourites_normal;
			this.newMail_iconTab3Button.ImageOver = GFXLibrary.mail2_users_favourites_over;
			this.newMail_iconTab3Button.ImageClick = GFXLibrary.mail2_users_favourites_normal;
			this.newMail_iconTab4Button.ImageNorm = GFXLibrary.mail2_users_groups_normal;
			this.newMail_iconTab4Button.ImageOver = GFXLibrary.mail2_users_groups_over;
			this.newMail_iconTab4Button.ImageClick = GFXLibrary.mail2_users_groups_normal;
			this.newMail_iconTab1Area.Visible = false;
			this.newMail_iconTab2Area.Visible = false;
			this.newMail_iconTab3Area.Visible = false;
			this.newMail_iconTab4Area.Visible = false;
			switch (tab)
			{
			case 0:
				this.newMail_iconTab1Button.ImageNorm = GFXLibrary.mail2_users_find_selected;
				this.newMail_iconTab1Button.ImageOver = GFXLibrary.mail2_users_find_selected;
				this.newMail_iconTab1Button.ImageClick = GFXLibrary.mail2_users_find_selected;
				this.newMail_iconTab1Area.Visible = true;
				break;
			case 1:
				this.newMail_iconTab2Button.ImageNorm = GFXLibrary.mail2_users_recent_selected;
				this.newMail_iconTab2Button.ImageOver = GFXLibrary.mail2_users_recent_selected;
				this.newMail_iconTab2Button.ImageClick = GFXLibrary.mail2_users_recent_selected;
				this.newMail_iconTab2Area.Visible = true;
				break;
			case 2:
				this.newMail_iconTab3Button.ImageNorm = GFXLibrary.mail2_users_favourites_selected;
				this.newMail_iconTab3Button.ImageOver = GFXLibrary.mail2_users_favourites_selected;
				this.newMail_iconTab3Button.ImageClick = GFXLibrary.mail2_users_favourites_selected;
				this.newMail_iconTab3Area.Visible = true;
				break;
			case 3:
				this.newMail_iconTab4Button.ImageNorm = GFXLibrary.mail2_users_groups_selected;
				this.newMail_iconTab4Button.ImageOver = GFXLibrary.mail2_users_groups_selected;
				this.newMail_iconTab4Button.ImageClick = GFXLibrary.mail2_users_groups_selected;
				this.newMail_iconTab4Area.Visible = true;
				break;
			}
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			switch (tab)
			{
			case 0:
				if (this.newMail_iconFindList.getSelectedItem() == null)
				{
					this.newMail_iconFindAddButton.Enabled = false;
					this.newMail_iconFindFavouritesButton.Enabled = false;
				}
				else
				{
					this.newMail_iconFindAddButton.Enabled = true;
					this.newMail_iconFindFavouritesButton.Enabled = true;
				}
				if (fromClick)
				{
					this.tbFindInput.Focus();
					return;
				}
				break;
			case 1:
				this.fillRecentList();
				if (this.newMail_iconRecentList.getSelectedItem() == null)
				{
					this.newMail_iconRecentAddButton.Enabled = false;
					this.newMail_iconRecentFavouritesButton.Enabled = false;
					return;
				}
				this.newMail_iconRecentAddButton.Enabled = true;
				this.newMail_iconRecentFavouritesButton.Enabled = true;
				return;
			case 2:
				this.fillFavouritesList();
				if (this.newMail_iconFavouritesList.getSelectedItem() == null)
				{
					this.newMail_iconFavouritesAddButton.Enabled = false;
					this.newMail_iconFavouritesRemoveButton.Enabled = false;
					return;
				}
				this.newMail_iconFavouritesAddButton.Enabled = true;
				this.newMail_iconFavouritesRemoveButton.Enabled = true;
				return;
			case 3:
				this.fillKnownList();
				if (this.newMail_iconKnownList.getSelectedItem() == null)
				{
					this.newMail_iconKnownAddButton.Enabled = false;
					this.newMail_iconKnownFavouritesButton.Enabled = false;
					return;
				}
				this.newMail_iconKnownAddButton.Enabled = true;
				this.newMail_iconKnownFavouritesButton.Enabled = true;
				break;
			default:
				return;
			}
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x001754DC File Offset: 0x001736DC
		public void open(bool fresh, bool fromSelf)
		{
			this.headerLabel2.Size = new Size(700, 24);
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.headerLabel2.Position = new Point(280, 12);
			}
			else if (Program.mySettings.LanguageIdent == "fr")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "es")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "tr")
			{
				this.headerLabel2.Position = new Point(230, 12);
			}
			else if (Program.mySettings.LanguageIdent == "it")
			{
				this.headerLabel2.Position = new Point(330, 12);
				this.headerLabel2.Size = new Size(570, 24);
			}
			else if (Program.mySettings.LanguageIdent == "pt")
			{
				this.headerLabel2.Position = new Point(300, 12);
				this.headerLabel2.Size = new Size(600, 24);
			}
			else if (Program.mySettings.LanguageIdent == "pl")
			{
				this.headerLabel2.Position = new Point(280, 12);
				this.headerLabel2.Size = new Size(620, 24);
			}
			else
			{
				this.headerLabel2.Position = new Point(200, 12);
			}
			if (this.mailController.initialRequest)
			{
				this.mailController.loadMail();
				this.mailController.loadBlockedList();
			}
			if (fresh)
			{
				if (!fromSelf)
				{
					this.mailController.selectedFolderID = -1L;
				}
				this.closeMoveMail();
				if (!this.mailController.gotFolders)
				{
					this.mailController.getFolders(new MailManager.GenericUIDelegate(this.updateFolderList));
					Thread.Sleep(500);
					this.mailController.gotFolders = true;
				}
				else
				{
					this.updateFolderList();
				}
				int mode = 5;
				bool initialRequest = this.mailController.initialRequest;
				if (this.mailController.initialRequest && this.mailController.lastTimeThreadsReceived > DateTime.Now.AddYears(-49))
				{
					mode = 6;
				}
				this.mailController.GetMailThreadList(this.mailController.initialRequest, mode, new MailManager.GenericUIDelegate(this.repopulateTable));
				if (!fromSelf)
				{
					this.selectedMailThreadID = -1000L;
					this.selectedMailThreadIDList.Clear();
					this.mailList_iconSelected.Visible = false;
					this.mailList_iconSelectedBack.Visible = false;
				}
				this.mailListArea.Visible = true;
				this.mailThreadArea.Visible = false;
				this.newMailArea.Visible = false;
				this.mailCreateFolderArea.Visible = false;
				this.tbMain.Visible = this.newMailArea.Visible;
				this.tbUserFilter.Visible = this.mailListArea.Visible;
				this.tbSubject.Visible = this.newMailArea.Visible;
				this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
				this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
				this.headerLabel.Text = SK.Text("MailScreen_Mail", "Mail");
				this.headerLabel2.Text = "";
				if (!fromSelf && (initialRequest || this.mailSent))
				{
					Thread.Sleep(500);
					this.mailController.getRecipientHistory();
				}
				this.mailController.initialRequest = false;
				this.mailSent = false;
			}
			if (this.m_parent != null)
			{
				if (this.m_parent.isDocked())
				{
					this.dockButton.CustomTooltipID = 500;
					this.dockButton.ImageNorm = GFXLibrary.mail2_detach_window_normal;
					this.dockButton.ImageOver = GFXLibrary.mail2_detach_window_over;
					this.dockButton.ImageClick = GFXLibrary.mail2_detach_window_in;
				}
				else
				{
					this.dockButton.CustomTooltipID = 501;
					this.dockButton.ImageNorm = GFXLibrary.mail2_detach_attach_window_normal;
					this.dockButton.ImageOver = GFXLibrary.mail2_detach_attach_window_over;
					this.dockButton.ImageClick = GFXLibrary.mail2_detach_attach_window_in;
				}
			}
			this.update();
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x0001858E File Offset: 0x0001678E
		public void refreshMail()
		{
			if (this.mailListArea.Visible && this.mailList_listArea.Visible)
			{
				this.open(true, true);
			}
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x00175994 File Offset: 0x00173B94
		private void repopulateTable()
		{
			int num = this.mailList_scrollBar.Max + 27;
			if (this.mailController.preSortedHeaders != null)
			{
				int num2 = this.mailController.preSortedHeaders.Count;
				for (int i = 0; i < this.mailController.preSortedHeaders.Count; i++)
				{
					MailThreadListItem mailThreadListItem = this.mailController.preSortedHeaders[i];
					if (mailThreadListItem != null)
					{
						bool flag = false;
						bool flag2 = false;
						if (mailThreadListItem.otherUser != null)
						{
							if (mailThreadListItem.otherUser.Length == 0)
							{
								flag2 = (this.tbUserFilter.Text.Length <= 0 || !mailThreadListItem.readOnly);
							}
							else
							{
								int num3 = 0;
								for (int j = 0; j < mailThreadListItem.otherUser.Length; j++)
								{
									if (this.mailController.blockedList.Contains(mailThreadListItem.otherUser[j]))
									{
										num3++;
									}
									if (this.tbUserFilter.Text.Length > 0)
									{
										if (mailThreadListItem.otherUser[j].ToLowerInvariant().Contains(this.tbUserFilter.Text.ToLowerInvariant()))
										{
											flag2 = true;
										}
									}
									else
									{
										flag2 = true;
									}
								}
								if (this.mailController.AggressiveBlocking)
								{
									if (num3 > 0)
									{
										flag = true;
									}
								}
								else if (num3 == mailThreadListItem.otherUser.Length)
								{
									flag = true;
								}
							}
						}
						else
						{
							flag2 = true;
						}
						if (flag || !flag2)
						{
							num2--;
						}
					}
				}
				if (num > num2)
				{
					int num4 = Math.Max(0, num2 - 27);
					if (this.mailList_scrollBar.Value > num4)
					{
						this.mailList_scrollBar.Value = num4;
					}
					this.mailList_scrollBar.Max = num4;
				}
				else
				{
					this.mailList_scrollBar.Max = Math.Max(0, num2 - 27);
				}
			}
			else
			{
				this.mailList_scrollBar.Max = 0;
			}
			for (int k = 0; k < 27; k++)
			{
				MailScreen.MailListLine mailListLine = this.getMailListLine(k);
				mailListLine.Subject.Text = "";
				mailListLine.Sender.Text = "";
				mailListLine.DateLabel.Text = "";
				mailListLine.Icon.Image = null;
				mailListLine.reset();
				mailListLine.Subject.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			}
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			if (this.mailController.preSortedAllHeader != null)
			{
				for (int l = 0; l < this.mailController.preSortedAllHeader.Count; l++)
				{
					MailThreadListItem mailThreadListItem2 = this.mailController.preSortedAllHeader[l];
					if (mailThreadListItem2 != null)
					{
						if (mailThreadListItem2.mailThreadID == -1L)
						{
							num9 = 1;
						}
						else if (mailThreadListItem2.mailThreadID == -2L)
						{
							num9 = 2;
						}
						else if (mailThreadListItem2.mailThreadID == -3L)
						{
							num9 = 3;
						}
						else if (mailThreadListItem2.mailThreadID == -4L)
						{
							num9 = 4;
						}
						else if (!mailThreadListItem2.readStatus)
						{
							switch (num9)
							{
							case 1:
								num5++;
								break;
							case 2:
								num6++;
								break;
							case 3:
								num7++;
								break;
							case 4:
								num8++;
								break;
							}
						}
					}
				}
			}
			for (int m = 0; m < 27; m++)
			{
				MailScreen.MailListLine mailListLine2 = this.getMailListLine(m);
				mailListLine2.Data = -1;
			}
			if (this.mailController.preSortedHeaders != null)
			{
				int num10 = this.mailList_scrollBar.Value;
				int num11 = 0;
				while (num11 < 27 && num10 < this.mailController.preSortedHeaders.Count)
				{
					MailThreadListItem mailThreadListItem3 = this.mailController.preSortedHeaders[num10];
					MailScreen.MailListLine mailListLine3 = this.getMailListLine(num11);
					mailListLine3.Data = num10;
					if (mailThreadListItem3 != null && mailListLine3 != null)
					{
						if (mailThreadListItem3.mailThreadID < 0L)
						{
							long mailThreadID = mailThreadListItem3.mailThreadID;
							if (mailThreadID <= -1L && mailThreadID >= -5L)
							{
								long num12 = mailThreadID - -5L;
								long num13 = num12;
								if (num13 <= 4L)
								{
									switch ((uint)num13)
									{
									case 0U:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Date_All", "Date: All");
										if (!this.mailController.openAll)
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_plus;
										}
										else
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_minus;
										}
										break;
									case 1U:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Date_Last_30_Days", "Date: Last 30 Days");
										if (num8 > 0)
										{
											CustomSelfDrawPanel.CSDLabel subject = mailListLine3.Subject;
											subject.Text = subject.Text + " (" + num8.ToString() + ")";
										}
										if (!this.mailController.openThisMonth)
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_plus;
										}
										else
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_minus;
										}
										break;
									case 2U:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Date_Last_7_Days", "Date: Last 7 Days");
										if (num7 > 0)
										{
											CustomSelfDrawPanel.CSDLabel subject2 = mailListLine3.Subject;
											subject2.Text = subject2.Text + " (" + num7.ToString() + ")";
										}
										if (!this.mailController.openThisWeek)
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_plus;
										}
										else
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_minus;
										}
										break;
									case 3U:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Date_Last_3_Days", "Date: Last 3 Days");
										if (num6 > 0)
										{
											CustomSelfDrawPanel.CSDLabel subject3 = mailListLine3.Subject;
											subject3.Text = subject3.Text + " (" + num6.ToString() + ")";
										}
										if (!this.mailController.open3Days)
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_plus;
										}
										else
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_minus;
										}
										break;
									case 4U:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Date_Yesterday", "Date: Yesterday");
										if (num5 > 0)
										{
											CustomSelfDrawPanel.CSDLabel subject4 = mailListLine3.Subject;
											subject4.Text = subject4.Text + " (" + num5.ToString() + ")";
										}
										if (!this.mailController.openYesterday)
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_plus;
										}
										else
										{
											mailListLine3.Icon.Image = GFXLibrary.mail_minus;
										}
										break;
									}
								}
							}
							mailListLine3.Sender.Text = "";
							mailListLine3.DateLabel.Text = "";
							mailListLine3.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
							mailListLine3.LineColor = CustomSelfDrawPanel.MailSelectedColor;
							mailListLine3.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
							mailListLine3.LineOverColor = CustomSelfDrawPanel.MailSelectedOverColor;
							mailListLine3.Subject.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						}
						else
						{
							string text = SK.Text("MAILSCREEN_NO_RECIPIENTS", "No Recipients?");
							bool flag3 = false;
							bool flag4 = false;
							int num14 = 0;
							bool flag5 = false;
							if (mailThreadListItem3.otherUser != null)
							{
								if (mailThreadListItem3.otherUser.Length == 0)
								{
									flag5 = (this.tbUserFilter.Text.Length <= 0 || !mailThreadListItem3.readOnly);
								}
								else
								{
									flag4 = true;
									text = mailThreadListItem3.otherUser[0];
									for (int n = 0; n < mailThreadListItem3.otherUser.Length; n++)
									{
										if (this.mailController.blockedList.Contains(mailThreadListItem3.otherUser[n]))
										{
											num14++;
										}
										if (this.tbUserFilter.Text.Length > 0)
										{
											if (mailThreadListItem3.otherUser[n].ToLowerInvariant().Contains(this.tbUserFilter.Text.ToLowerInvariant()))
											{
												flag5 = true;
											}
										}
										else
										{
											flag5 = true;
										}
									}
									if (num14 > 0)
									{
										flag3 = true;
									}
								}
								for (int num15 = 1; num15 < mailThreadListItem3.otherUser.Length; num15++)
								{
									text = text + ", " + mailThreadListItem3.otherUser[num15];
								}
							}
							else
							{
								flag5 = true;
							}
							if (!flag3 && flag5)
							{
								mailListLine3.Subject.Text = mailThreadListItem3.subject;
								if (mailThreadListItem3.readOnly)
								{
									switch (mailThreadListItem3.specialType)
									{
									case 1:
										text = SK.Text("The_Kingdoms_Team", "The Kingdoms Team");
										mailListLine3.Subject.Text = MailManager.languageSplitString(mailThreadListItem3.subject);
										break;
									case 2:
										mailListLine3.Subject.Text = SK.Text("MailScreen_House_Proclamation", "House Proclamation");
										if (!flag4)
										{
											text = RemoteServices.Instance.UserName;
										}
										break;
									case 3:
										mailListLine3.Subject.Text = "";
										break;
									case 4:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Parish_Proclamation", "Parish Proclamation") + " : " + GameEngine.Instance.World.getParishName(mailThreadListItem3.specialArea);
										if (!flag4)
										{
											text = RemoteServices.Instance.UserName;
										}
										break;
									case 5:
										mailListLine3.Subject.Text = SK.Text("MailScreen_County_Proclamation", "County Proclamation") + " : " + GameEngine.Instance.World.getCountyName(mailThreadListItem3.specialArea);
										if (!flag4)
										{
											text = RemoteServices.Instance.UserName;
										}
										break;
									case 6:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Province_Proclamation", "Province Proclamation") + " : " + GameEngine.Instance.World.getProvinceName(mailThreadListItem3.specialArea);
										if (!flag4)
										{
											text = RemoteServices.Instance.UserName;
										}
										break;
									case 7:
										mailListLine3.Subject.Text = SK.Text("MailScreen_Country_Proclamation", "Country Proclamation") + " : " + GameEngine.Instance.World.getCountryName(mailThreadListItem3.specialArea);
										if (!flag4)
										{
											text = RemoteServices.Instance.UserName;
										}
										break;
									}
								}
							}
							else
							{
								if (!flag5)
								{
									num11--;
									goto IL_B54;
								}
								if (this.mailController.AggressiveBlocking)
								{
									num11--;
									goto IL_B54;
								}
								if (num14 == mailThreadListItem3.otherUser.Length)
								{
									num11--;
									goto IL_B54;
								}
								mailListLine3.Subject.Text = "         * " + SK.Text("MailBlock_blocked", "Blocked") + " *";
							}
							mailListLine3.Sender.Text = text;
							mailListLine3.Date = mailThreadListItem3.mailTime;
							if (mailThreadListItem3.readStatus)
							{
								mailListLine3.Icon.Image = GFXLibrary.mail_letter_icon_open;
							}
							else
							{
								mailListLine3.Icon.Image = GFXLibrary.mail_letter_icon_closed;
								mailListLine3.Subject.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
							}
							if (mailThreadListItem3.mailThreadID == this.selectedMailThreadID || this.selectedMailThreadIDList.Contains(mailThreadListItem3.mailThreadID))
							{
								mailListLine3.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
								mailListLine3.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
							}
						}
						mailListLine3.invalidate();
					}
					IL_B54:
					num11++;
					num10++;
				}
			}
			if (this.selectedMailThreadID >= 0L)
			{
				this.mailList_iconSelected.Visible = true;
				this.mailList_iconSelectedBack.Visible = true;
			}
			else
			{
				this.mailList_iconSelected.Visible = false;
				this.mailList_iconSelectedBack.Visible = false;
			}
			this.mailList_scrollBar.recalc();
			this.mailList_scrollBar.invalidate();
			this.mailList_scrollBarMoved();
			this.updateFolderList();
		}

		// Token: 0x0600173D RID: 5949 RVA: 0x0017657C File Offset: 0x0017477C
		public void updateFolderList()
		{
			for (int i = 0; i < 27; i++)
			{
				MailScreen.MailFolderLine folderLine = this.getFolderLine(i);
				folderLine.Text.Text = "";
				folderLine.reset();
			}
			int num = 0;
			int[] array = new int[Math.Max(1, this.mailController.mailFolders.Count)];
			foreach (object obj in this.mailController.storedThreadHeaders)
			{
				MailThreadListItem mailThreadListItem = (MailThreadListItem)obj;
				if (!mailThreadListItem.readStatus)
				{
					if (mailThreadListItem.folderID == -1L)
					{
						num++;
					}
					else
					{
						for (int j = 0; j < this.mailController.mailFolders.Count; j++)
						{
							if (this.mailController.mailFolders[j].mailFolderID == mailThreadListItem.folderID)
							{
								array[j]++;
								break;
							}
						}
					}
				}
			}
			MailScreen.MailFolderLine folderLine2 = this.getFolderLine(0);
			folderLine2.Text.Text = SK.Text("MailScreen_Inbox", "Inbox");
			if (num > 0)
			{
				CustomSelfDrawPanel.CSDLabel text = folderLine2.Text;
				text.Text = text.Text + " (" + num.ToString() + ")";
			}
			if (this.mailController.selectedFolderID == -1L)
			{
				folderLine2.Icon.Image = GFXLibrary.mail2_folder_icon_open;
				folderLine2.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
				folderLine2.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
			}
			else
			{
				folderLine2.Icon.Image = GFXLibrary.mail2_folder_icon_closed;
			}
			folderLine2.invalidate();
			int num2 = 1;
			MailFolderItem mailFolderItem = null;
			foreach (MailFolderItem mailFolderItem2 in this.mailController.mailFolders)
			{
				MailScreen.MailFolderLine folderLine3 = this.getFolderLine(num2);
				folderLine3.Text.Text = mailFolderItem2.title;
				if (array[num2 - 1] > 0)
				{
					CustomSelfDrawPanel.CSDLabel text2 = folderLine3.Text;
					text2.Text = text2.Text + " (" + array[num2 - 1].ToString() + ")";
				}
				if (this.mailController.selectedFolderID == mailFolderItem2.mailFolderID)
				{
					mailFolderItem = mailFolderItem2;
					folderLine3.Icon.Image = GFXLibrary.mail2_folder_icon_open;
					folderLine3.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
					folderLine3.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
				}
				else
				{
					folderLine3.Icon.Image = GFXLibrary.mail2_folder_icon_closed;
				}
				folderLine3.invalidate();
				num2++;
				if (num2 >= 25)
				{
					break;
				}
			}
			if (this.m_moveThreadMode)
			{
				return;
			}
			MailScreen.MailFolderLine folderLine4 = this.getFolderLine(num2);
			folderLine4.Text.Text = SK.Text("MailScreen_New_Folder", "New Folder");
			folderLine4.Icon.Image = GFXLibrary.mail2_folder_icon_plus;
			folderLine4.invalidate();
			num2++;
			bool flag = true;
			if (mailFolderItem == null || this.mailController.selectedFolderID < 0L)
			{
				flag = false;
			}
			else if (mailFolderItem.title == "Archive")
			{
				flag = false;
			}
			if (flag)
			{
				MailScreen.MailFolderLine folderLine5 = this.getFolderLine(num2);
				if (folderLine5 != null)
				{
					folderLine5.Text.Text = SK.Text("MailScreen_Remove_Folder", "Remove Folder");
					folderLine5.Icon.Image = GFXLibrary.mail2_folder_icon_delete;
					folderLine5.invalidate();
				}
			}
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x0017691C File Offset: 0x00174B1C
		public void update()
		{
			bool scrollUp = GameEngine.scrollUp;
			bool scrollDown = GameEngine.scrollDown;
			if (this.mailListArea.Visible)
			{
				if (scrollUp)
				{
					if ((DateTime.Now - this.keyScrollTimer).TotalMilliseconds > 50.0)
					{
						this.keyScrollTimer = DateTime.Now;
						if (this.lastMailLineClicked >= 0 && this.lastMailLineClicked > 0)
						{
							if (this.lastMailLineClicked <= this.mailList_scrollBar.Value)
							{
								CustomSelfDrawPanel.CSDVertScrollBar csdvertScrollBar = this.mailList_scrollBar;
								int value = csdvertScrollBar.Value;
								csdvertScrollBar.Value = value - 1;
							}
							this.lastMailLineClicked--;
							this.mailLineDoubleClick = DateTime.MinValue;
							this.mailLineClicked(this.lastMailLineClicked, false);
						}
					}
				}
				else if (scrollDown && (DateTime.Now - this.keyScrollTimer).TotalMilliseconds > 50.0)
				{
					this.keyScrollTimer = DateTime.Now;
					if (this.lastMailLineClicked >= 0 && this.lastMailLineClicked < this.mailController.preSortedHeaders.Count - 1)
					{
						this.lastMailLineClicked++;
						if (this.lastMailLineClicked > this.mailList_scrollBar.Value + 26)
						{
							CustomSelfDrawPanel.CSDVertScrollBar csdvertScrollBar2 = this.mailList_scrollBar;
							int value = csdvertScrollBar2.Value;
							csdvertScrollBar2.Value = value + 1;
						}
						this.mailLineDoubleClick = DateTime.MinValue;
						this.mailLineClicked(this.lastMailLineClicked, false);
					}
				}
			}
			if (this.mailThreadArea.Visible)
			{
				if (scrollUp)
				{
					if ((DateTime.Now - this.keyScrollTimer).TotalMilliseconds > 50.0)
					{
						this.keyScrollTimer = DateTime.Now;
						if (this.lastMailItemClicked >= 0 && this.lastMailItemClicked > 0)
						{
							if (this.lastMailItemClicked <= this.mailThread_scrollBar.Value)
							{
								CustomSelfDrawPanel.CSDVertScrollBar csdvertScrollBar3 = this.mailThread_scrollBar;
								int value = csdvertScrollBar3.Value;
								csdvertScrollBar3.Value = value - 1;
							}
							this.lastMailItemClicked--;
							this.mailLineDoubleClick = DateTime.MinValue;
							this.mailItemClicked(this.lastMailItemClicked);
						}
					}
				}
				else if (scrollDown && (DateTime.Now - this.keyScrollTimer).TotalMilliseconds > 50.0)
				{
					this.keyScrollTimer = DateTime.Now;
					if (this.lastMailItemClicked >= 0 && this.lastMailItemClicked < this.currentThreadLength - 1)
					{
						this.lastMailItemClicked++;
						if (this.lastMailItemClicked > this.mailThread_scrollBar.Value + 26)
						{
							CustomSelfDrawPanel.CSDVertScrollBar csdvertScrollBar4 = this.mailThread_scrollBar;
							int value = csdvertScrollBar4.Value;
							csdvertScrollBar4.Value = value + 1;
						}
						this.mailLineDoubleClick = DateTime.MinValue;
						this.mailItemClicked(this.lastMailItemClicked);
					}
				}
			}
			if (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible)
			{
				this.mailController.updateSearch(this.tbFindInput.Text, new RemoteServices.GetMailUserSearch_UserCallBack(this.getMailUserSearchCallback));
			}
			if (this.attachmentWindow != null && this.attachmentWindow.Visible)
			{
				this.attachmentWindow.update();
			}
			if (this.m_flashFolderLine != null)
			{
				if (this.flashFolderCount % 6 == 0)
				{
					this.m_flashFolderLine.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
				}
				else if (this.flashFolderCount % 6 == 3)
				{
					this.m_flashFolderLine.BodyColor = CustomSelfDrawPanel.MailSelectedOverColor;
				}
				this.flashFolderCount++;
				if (this.flashFolderCount == 30)
				{
					this.m_flashFolderLine = null;
					this.flashFolderCount = 0;
					this.updateFolderList();
				}
			}
			if (this.doUpdateSendButton)
			{
				this.updateSendButton();
			}
		}

		// Token: 0x0600173F RID: 5951 RVA: 0x00176CB4 File Offset: 0x00174EB4
		public void closeClick()
		{
			if (this.attachmentWindow != null)
			{
				this.attachmentWindow.closeControl(true);
				this.attachmentWindow = null;
			}
			if (this.m_parent == null)
			{
				return;
			}
			if (!this.m_parent.isDocked())
			{
				this.m_parent.close(true);
				return;
			}
			if (!MailScreen.factionClose)
			{
				InterfaceMgr.Instance.changeTab(0);
				return;
			}
			GameEngine.Instance.setNextFactionPage(999);
			InterfaceMgr.Instance.changeTab(8);
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x00176D2C File Offset: 0x00174F2C
		public void dockClick()
		{
			if (this.m_parent != null)
			{
				this.m_parent.setAsReopen();
				if (this.m_parent.isDocked())
				{
					this.m_parent.open(false, true);
					InterfaceMgr.Instance.changeTab(0);
					return;
				}
				this.m_parent.setAsDocked();
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
			}
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x00176D90 File Offset: 0x00174F90
		private void folderLineClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			int num = clickedControl.Data;
			if (num == 0)
			{
				if (!this.m_moveThreadMode)
				{
					this.mailController.selectedFolderID = -1L;
				}
				else
				{
					long num2 = -1L;
					if (this.mailController.storedThreadHeaders[this.selectedMailThreadID] != null)
					{
						MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
						if (num2 != mailThreadListItem.folderID)
						{
							this.moveMail(this.selectedMailThreadIDList, num2, this.getFolderLine(0));
						}
						else
						{
							this.closeMoveMail();
						}
					}
				}
				this.mailController.preSortThreadHeaders();
				this.repopulateTable();
				this.selectedMailThreadID = -1000L;
				this.selectedMailThreadIDList.Clear();
				return;
			}
			num--;
			int num3 = this.mailController.mailFolders.Count;
			if (num3 >= 24)
			{
				num3 = 24;
			}
			if (num < num3)
			{
				if (!this.m_moveThreadMode)
				{
					this.mailController.selectedFolderID = this.mailController.mailFolders[num].mailFolderID;
				}
				else
				{
					long mailFolderID = this.mailController.mailFolders[num].mailFolderID;
					if (this.mailController.storedThreadHeaders[this.selectedMailThreadID] != null)
					{
						MailThreadListItem mailThreadListItem2 = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
						if (mailFolderID != mailThreadListItem2.folderID)
						{
							this.moveMail(this.selectedMailThreadIDList, mailFolderID, this.getFolderLine(num + 1));
						}
						else
						{
							this.closeMoveMail();
						}
					}
				}
				this.mailController.preSortThreadHeaders();
				this.repopulateTable();
				this.selectedMailThreadID = -1000L;
				this.selectedMailThreadIDList.Clear();
				return;
			}
			if (!this.m_moveThreadMode)
			{
				if (num == num3)
				{
					this.mailListArea.Visible = false;
					this.mailThreadArea.Visible = false;
					this.newMailArea.Visible = false;
					this.mailCreateFolderArea.Visible = true;
					this.tbNewFolder.Text = "";
					this.tbNewFolder.Visible = true;
					this.tbNewFolder.MaxLength = 10;
					this.mailList_createFolderOK.Enabled = false;
					return;
				}
				this.CloseRemoveFolderPopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false, base.ParentForm);
				this.removeFolderPopUp = new MyMessageBoxPopUp();
				this.removeFolderPopUp.init(SK.Text("MailScreen_Wish_To_Remove_Folder", "Do you wish to remove this folder?"), SK.Text("MailScreen_Remove_Mail_Folder", "Remove Mail Folder?"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.RemoveFolderConfirm));
				this.removeFolderPopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x000185B2 File Offset: 0x000167B2
		private void RemoveFolderConfirm()
		{
			this.mailController.RemoveFolder(this.mailController.selectedFolderID, new MailManager.GenericUIDelegate(this.repopulateTable));
			InterfaceMgr.Instance.closeGreyOut();
			this.removeFolderPopUp.Close();
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x000185EB File Offset: 0x000167EB
		private void CloseRemoveFolderPopUp()
		{
			if (this.removeFolderPopUp != null)
			{
				if (this.removeFolderPopUp.Created)
				{
					this.removeFolderPopUp.Close();
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.removeFolderPopUp = null;
			}
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x0001861E File Offset: 0x0001681E
		private void mailList_CreateFolder()
		{
			this.mailController.CreateFolder(this.tbNewFolder.Text, new MailManager.GenericUIDelegate(this.updateFolderList));
			this.returnToMailList();
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x00018648 File Offset: 0x00016848
		private void mailList_CancelCreateFolder()
		{
			this.returnToMailList();
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x00018650 File Offset: 0x00016850
		private void moveMail(List<long> threadIDs, long targetFolderID, MailScreen.MailFolderLine folderLine)
		{
			this.closeMoveMail();
			this.mailController.MoveThreadsToFolder(threadIDs, targetFolderID);
			this.selectedMailThreadIDList.Clear();
			this.selectedMailThreadID = -1000L;
			this.m_flashFolderLine = folderLine;
			this.flashFolderCount = 0;
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x0017702C File Offset: 0x0017522C
		private void closeMoveMail()
		{
			this.m_moveThreadMode = false;
			this.mailList_listArea.Visible = true;
			this.mailList_iconArea.Visible = true;
			this.mailList_scrollBar.Visible = true;
			this.mailList_scrollTabLines.Visible = true;
			this.mailList_upArrow.Visible = true;
			this.mailList_downArrow.Visible = true;
			this.mailList_listShadowTR.Visible = true;
			this.mailList_listShadowR.Visible = true;
			this.mailList_listShadowBR.Visible = true;
			this.mailList_listShadowB.Visible = true;
			this.mailList_listShadowBL.Visible = true;
			this.mailList_MoveFolderLabel.Visible = false;
			this.mailList_MoveFolderCancel.Visible = false;
		}

		// Token: 0x06001748 RID: 5960 RVA: 0x0001868A File Offset: 0x0001688A
		private void mailList_OpenMail()
		{
			if (this.selectedMailThreadID >= 0L)
			{
				this.openMailThread(this.selectedMailThreadID);
			}
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x001770DC File Offset: 0x001752DC
		private void mailList_MarkAsRead()
		{
			if (this.selectedMailThreadID >= 0L)
			{
				MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
				if (mailThreadListItem != null && (!mailThreadListItem.readStatus || this.selectedMailThreadIDList.Count > 0))
				{
					foreach (long num in this.selectedMailThreadIDList)
					{
						mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[num];
						if (mailThreadListItem != null && !mailThreadListItem.readStatus)
						{
							this.mailController.SetThreadReadStatus(num, true);
							mailThreadListItem.readStatus = true;
							if (this.mailController.storedThreads[num] != null)
							{
								MailThreadItem[] array = (MailThreadItem[])this.mailController.storedThreads[num];
								MailThreadItem[] array2 = array;
								foreach (MailThreadItem mailThreadItem in array2)
								{
									mailThreadItem.readStatus = true;
								}
							}
						}
					}
					this.repopulateTable();
				}
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x00177208 File Offset: 0x00175408
		private void mailList_MarkAsUnRead()
		{
			if (this.selectedMailThreadID >= 0L)
			{
				MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
				if (mailThreadListItem != null)
				{
					foreach (long num in this.selectedMailThreadIDList)
					{
						mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[num];
						if (mailThreadListItem != null)
						{
							this.mailController.SetThreadReadStatus(num, false);
							mailThreadListItem.readStatus = false;
							if (this.mailController.storedThreads[num] != null)
							{
								MailThreadItem[] array = (MailThreadItem[])this.mailController.storedThreads[num];
								MailThreadItem[] array2 = array;
								foreach (MailThreadItem mailThreadItem in array2)
								{
									mailThreadItem.readStatus = false;
								}
							}
						}
					}
					this.repopulateTable();
				}
			}
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x00177310 File Offset: 0x00175510
		private void mailList_DeleteThread()
		{
			if (this.selectedMailThreadID >= 0L)
			{
				this.CloseDeleteThreadPopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false, base.ParentForm);
				this.DeleteThreadPopUp = new MyMessageBoxPopUp();
				if (this.selectedMailThreadIDList.Count == 1)
				{
					this.DeleteThreadPopUp.init(SK.Text("MailScreen_Delete_This_Thread", "Delete this thread?"), SK.Text("MailScreen_Confirmation", "Confirmation"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DeleteThreadOkClick));
				}
				else
				{
					this.DeleteThreadPopUp.init(SK.Text("MailScreen_Delete_All_Threads", "Delete ALL selected threads?"), SK.Text("MailScreen_Confirmation", "Confirmation"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DeleteThreadOkClick));
				}
				this.DeleteThreadPopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x001773E0 File Offset: 0x001755E0
		private void DeleteThreadOkClick()
		{
			this.mailController.DeleteThreads(this.selectedMailThreadIDList);
			this.selectedMailThreadID = -1000L;
			this.selectedMailThreadIDList.Clear();
			this.repopulateTable();
			InterfaceMgr.Instance.closeGreyOut();
			this.DeleteThreadPopUp.Close();
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x000186A2 File Offset: 0x000168A2
		private void CloseDeleteThreadPopUp()
		{
			if (this.DeleteThreadPopUp != null)
			{
				if (this.DeleteThreadPopUp.Created)
				{
					this.DeleteThreadPopUp.Close();
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.DeleteThreadPopUp = null;
			}
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x00177430 File Offset: 0x00175630
		private void mailList_MoveThread()
		{
			this.m_moveThreadMode = true;
			this.mailList_listArea.Visible = false;
			this.mailList_iconArea.Visible = false;
			this.mailList_scrollBar.Visible = false;
			this.mailList_scrollTabLines.Visible = false;
			this.mailList_upArrow.Visible = false;
			this.mailList_downArrow.Visible = false;
			this.mailList_listShadowTR.Visible = false;
			this.mailList_listShadowR.Visible = false;
			this.mailList_listShadowBR.Visible = false;
			this.mailList_listShadowB.Visible = false;
			this.mailList_listShadowBL.Visible = false;
			this.mailList_MoveFolderLabel.Visible = true;
			this.mailList_MoveFolderCancel.Visible = true;
			this.updateFolderList();
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x000186D5 File Offset: 0x000168D5
		private void mailList_CancelMove()
		{
			this.closeMoveMail();
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x001774E8 File Offset: 0x001756E8
		private void returnToMailList()
		{
			this.mailListArea.Visible = true;
			this.mailThreadArea.Visible = false;
			this.newMailArea.Visible = false;
			this.mailCreateFolderArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
			this.headerLabel.Text = SK.Text("MailScreen_Mail", "Mail");
			this.headerLabel2.Text = "";
			this.repopulateTable();
			base.Focus();
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x000186DD File Offset: 0x000168DD
		private void returnFromNewMail()
		{
			if (this.sendThreadID < 0L)
			{
				this.returnToMailList();
				return;
			}
			this.openMailThread(this.sendThreadID);
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x001775DC File Offset: 0x001757DC
		private void openMailThread(long threadID)
		{
			if (this.mailController.storedThreadHeaders[threadID] == null)
			{
				return;
			}
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[threadID];
			if (mailThreadListItem == null)
			{
				return;
			}
			this.mailListArea.Visible = false;
			this.mailThreadArea.Visible = true;
			this.newMailArea.Visible = false;
			this.mailCreateFolderArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
			this.selectedMailItemID = -1000L;
			this.headerLabel.Text = SK.Text("MailScreen_Mail_Thread", "Mail Thread") + " : ";
			string str = this.lastSubject = this.mailController.GetSubject(mailThreadListItem);
			this.headerLabel2.Text = "\"" + str + "\"";
			this.mailThread_mailBodyText.Text = "";
			this.mailThread_mailHeaderDateValueLabel.Text = "";
			this.mailThread_mailHeaderFromNameLabel.Text = "";
			this.mailThread_fromShield.Visible = false;
			if (mailThreadListItem.readOnly)
			{
				this.mailThread_iconSelectedReply.Enabled = false;
				this.mailThread_iconSelectedForward.Enabled = false;
				if (mailThreadListItem.specialType == 1)
				{
					this.mailThread_iconSelectedBlockPoster.Enabled = false;
					this.mailThread_iconSelectedReportMail.Enabled = false;
				}
				else
				{
					this.mailThread_iconSelectedBlockPoster.Enabled = true;
					this.mailThread_iconSelectedReportMail.Enabled = true;
				}
			}
			else
			{
				this.mailThread_iconSelectedReply.Enabled = true;
				this.mailThread_iconSelectedForward.Enabled = true;
				this.mailThread_iconSelectedBlockPoster.Enabled = true;
				this.mailThread_iconSelectedReportMail.Enabled = true;
			}
			this.reportButtonAvailable = this.mailThread_iconSelectedReportMail.Enabled;
			this.blockButtonAvailable = this.mailThread_iconSelectedBlockPoster.Enabled;
			if (this.mailController.storedThreads[threadID] != null)
			{
				this.displayThread(threadID, false);
			}
			else
			{
				this.clearMailThread();
			}
			this.mailController.getMailThread(threadID, new MailManager.GetMailThreadUIDelegate(this.mailThreadCallback));
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x00177850 File Offset: 0x00175A50
		public void mailThreadCallback(long threadID)
		{
			if (!this.mailThreadArea.Visible || this.selectedMailThreadID != threadID)
			{
				return;
			}
			this.displayThread(threadID, true);
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[threadID];
			if (mailThreadListItem == null)
			{
				return;
			}
			if (mailThreadListItem.readOnly)
			{
				this.mailThread_iconSelectedReply.Enabled = false;
				this.mailThread_iconSelectedForward.Enabled = false;
				if (mailThreadListItem.specialType == 1)
				{
					this.mailThread_iconSelectedBlockPoster.Enabled = false;
					return;
				}
			}
			else
			{
				this.mailThread_iconSelectedReply.Enabled = true;
				this.mailThread_iconSelectedForward.Enabled = true;
			}
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x001778E8 File Offset: 0x00175AE8
		private void clearMailThread()
		{
			for (int i = 0; i < 27; i++)
			{
				MailScreen.MailThreadLine mailThreadLine = this.getMailThreadLine(i);
				mailThreadLine.BodyText.Text = "";
				mailThreadLine.Sender.Text = "";
				mailThreadLine.DateLabel.Text = "";
				mailThreadLine.Icon.Image = null;
				mailThreadLine.reset();
				mailThreadLine.BodyText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			}
			this.mailThread_mailHeaderFromNameLabel.Text = "";
			this.mailThread_mailHeaderDateValueLabel.Text = "";
			this.mailThread_fromShield.Visible = false;
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x00177994 File Offset: 0x00175B94
		private void displayThread(long threadID, bool fromOpen)
		{
			if (this.inDisplayThread)
			{
				return;
			}
			this.inDisplayThread = true;
			if (this.mailController.storedThreads[threadID] == null)
			{
				this.returnToMailList();
				this.inDisplayThread = false;
				return;
			}
			if (fromOpen)
			{
				this.selectedMailItemID = -1L;
			}
			MailThreadItem[] array = (MailThreadItem[])this.mailController.storedThreads[threadID];
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[threadID];
			int num = this.currentThreadLength = array.Length;
			foreach (MailThreadItem mailThreadItem in array)
			{
				if (this.mailController.blockedList.Contains(mailThreadItem.otherUser))
				{
					num--;
				}
			}
			int num2 = this.mailThread_scrollBar.Max + 27;
			if (num2 > num)
			{
				int num3 = Math.Max(0, num - 27);
				if (this.mailThread_scrollBar.Value > num3)
				{
					this.mailThread_scrollBar.Value = num3;
				}
				this.mailThread_scrollBar.Max = num3;
			}
			else
			{
				this.mailThread_scrollBar.Max = Math.Max(0, num - 27);
			}
			this.clearMailThread();
			char[] separator = new char[]
			{
				'\n',
				'\r'
			};
			int num4 = this.mailThread_scrollBar.Value;
			int num5 = -1;
			for (int j = 0; j < array.Length; j++)
			{
				MailThreadItem mailThreadItem2 = array[j];
				if (!this.mailController.blockedList.Contains(mailThreadItem2.otherUser) && !mailThreadItem2.readStatus)
				{
					num5 = j;
				}
			}
			for (int k = 0; k < 27; k++)
			{
				MailScreen.MailThreadLine mailThreadLine = this.getMailThreadLine(k);
				mailThreadLine.Data = -1;
			}
			int num6 = 0;
			while (num6 < 27 && num4 < array.Length)
			{
				MailThreadItem mailThreadItem3 = array[num4];
				bool flag = false;
				if (this.mailController.blockedList.Contains(mailThreadItem3.otherUser))
				{
					num6--;
				}
				else
				{
					MailScreen.MailThreadLine mailThreadLine2 = this.getMailThreadLine(num6);
					mailThreadLine2.Data = num4;
					string text = SK.Text("MAILSCREEN_NO_RECIPIENTS", "No Recipients?");
					if (mailThreadItem3.otherUser != null && mailThreadItem3.otherUser.Length > 0)
					{
						text = mailThreadItem3.otherUser;
					}
					if (mailThreadListItem != null && mailThreadListItem.readOnly && mailThreadListItem.specialType == 1)
					{
						text = SK.Text("The_Kingdoms_Team", "The Kingdoms Team");
					}
					string text2 = mailThreadItem3.body;
					if (mailThreadListItem != null && mailThreadListItem.readOnly && mailThreadListItem.specialType == 1)
					{
						text2 = MailManager.languageSplitString(text2);
					}
					string[] array3 = text2.Split(separator);
					if (array3.Length != 0 && !flag)
					{
						string text3 = this.parseAttachmentString(array3[0], false);
						mailThreadLine2.BodyText.Text = text3;
						if (this.mailController.stringContainsAttachments(array3[0]))
						{
							mailThreadLine2.hasAttachment = true;
						}
					}
					else
					{
						mailThreadLine2.BodyText.Text = "                   * " + SK.Text("MailBlock_blocked", "Blocked") + " *";
					}
					mailThreadLine2.Sender.Text = text;
					mailThreadLine2.Date = mailThreadItem3.mailTime;
					if (mailThreadItem3.readStatus)
					{
						mailThreadLine2.Icon.Image = GFXLibrary.mail_letter_icon_open;
					}
					else
					{
						mailThreadLine2.Icon.Image = GFXLibrary.mail_letter_icon_closed;
						mailThreadLine2.BodyText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
					}
					if (mailThreadItem3.mailID == this.selectedMailItemID)
					{
						mailThreadLine2.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
						mailThreadLine2.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
					}
					mailThreadLine2.invalidate();
				}
				num6++;
				num4++;
			}
			if (this.selectedMailItemID >= 0L)
			{
				this.mailThread_iconSelected.Visible = true;
				this.mailThread_iconSelectedBack.Visible = true;
			}
			else
			{
				this.mailThread_iconSelected.Visible = false;
				this.mailThread_iconSelectedBack.Visible = false;
			}
			this.mailThread_scrollBar.recalc();
			this.mailThread_scrollBar.invalidate();
			this.mailThread_scrollBarMoved();
			if (num > 0 && fromOpen)
			{
				bool flag2 = true;
				if (num5 >= 0)
				{
					this.showMailItem(num5);
					flag2 = false;
				}
				num4 = this.mailThread_scrollBar.Value;
				int num7 = 0;
				while (num7 < 27 && num4 < array.Length)
				{
					MailThreadItem mailThreadItem4 = array[num4];
					if (this.mailController.blockedList.Contains(mailThreadItem4.otherUser))
					{
						num7--;
					}
					else
					{
						if (flag2)
						{
							this.showMailItem(num4);
							flag2 = false;
							num5 = num4;
						}
						MailScreen.MailThreadLine mailThreadLine3 = this.getMailThreadLine(num7);
						if (num5 == num4)
						{
							this.selectedMailItemID = mailThreadItem4.mailID;
							mailThreadLine3.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
							mailThreadLine3.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
							mailThreadLine3.invalidate();
							this.mailThread_iconSelected.Visible = true;
							this.mailThread_iconSelectedBack.Visible = true;
							if (!(mailThreadItem4.otherUser != RemoteServices.Instance.UserName))
							{
								this.mailThread_iconSelectedBlockPoster.Enabled = false;
								this.selectedUserName = "";
								this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailScreen_Block_This_User", "Block This User");
								break;
							}
							this.mailThread_iconSelectedBlockPoster.Enabled = true;
							this.selectedUserName = mailThreadItem4.otherUser;
							if (this.mailController.blockedList.Contains(this.selectedUserName))
							{
								this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailBlock_manage", "Manage Blocked Users");
								break;
							}
							this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailScreen_Block_This_User", "Block This User");
							break;
						}
					}
					num7++;
					num4++;
				}
			}
			this.inDisplayThread = false;
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x00177F34 File Offset: 0x00176134
		private void mailList_ForwardMail()
		{
			this.proclamation = false;
			this.sendThreadID = this.selectedMailThreadID;
			this.sendAsForward = true;
			this.changeSearchTab(0, false);
			this.newMail_iconTab1Button.Visible = true;
			this.newMail_iconTab2Button.Visible = true;
			this.newMail_iconTab3Button.Visible = true;
			this.newMail_iconTab4Button.Visible = true;
			this.newMail_iconBackground.Visible = true;
			this.recipients.Clear();
			this.populateToList();
			this.newMail_ToList.Enabled = true;
			this.newMail_removeRecipient.Enabled = false;
			this.mailListArea.Visible = false;
			this.mailThreadArea.Visible = false;
			this.newMailArea.Visible = true;
			this.mailCreateFolderArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			this.tbSubject.Enabled = false;
			this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
			this.newMail_iconBackButton.Text.Text = SK.Text("MailScreen_Back_To_Mail", "Back To Mail");
			this.headerLabel.Text = SK.Text("MailScreen_Forward", "Forward");
			this.headerLabel2.Text = "";
			this.newMail_iconSendMail.Text.Text = SK.Text("MailScreen_Forward", "Forward");
			this.newMail_iconSendMail.Visible = true;
			this.tbMain.Text = "";
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
			if (mailThreadListItem != null)
			{
				this.tbSubject.Text = SK.Text("MailScreen_Forward_Abbreviation", "FW") + " : " + mailThreadListItem.subject;
			}
			this.tbMain.Focus();
			this.updateSendButton();
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x00178164 File Offset: 0x00176364
		private void mailList_BlockUser()
		{
			if (this.selectedUserName.Length > 0)
			{
				this.mailController.blockListChanged = false;
				MailUserBlockPopup.ShowPopup(this, this.selectedUserName);
				if (this.mailController.blockListChanged)
				{
					this.showMailItem(this.lastLineClicked);
				}
			}
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x000186FC File Offset: 0x000168FC
		private void mailList_BlockUser2()
		{
			this.mailController.blockListChanged = false;
			MailUserBlockPopup.ShowPopup(this, "");
			if (this.mailController.blockListChanged)
			{
				this.repopulateTable();
			}
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x001781B0 File Offset: 0x001763B0
		private void mailList_ReportMail()
		{
			MailAbuseSubmissionForm mailAbuseSubmissionForm = new MailAbuseSubmissionForm();
			mailAbuseSubmissionForm.initProperties(false, SK.Text("Report_Mail_Abuse_Heading", "Report Mail Abuse"), null);
			mailAbuseSubmissionForm.InitReportData(this, this.selectedMailItemID, this.selectedMailThreadID, this.selectedUserName);
			mailAbuseSubmissionForm.display(true, null, 0, 0);
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x00018728 File Offset: 0x00016928
		public void ReportMailCallback(ReportMail_ReturnType returnData)
		{
			if (returnData.Success)
			{
				MyMessageBox.Show(SK.Text("MailScreen_Has_Been_Reported", "This mail has been successfully reported."), SK.Text("MailScreen_Abuse_Report", "Abuse Report"));
			}
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x00018756 File Offset: 0x00016956
		private void mailList_selectLineOpenAttachments()
		{
			this.mailLineClicked();
			this.mailList_OpenAttachmentWindow();
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x00018764 File Offset: 0x00016964
		private void mailList_OpenAttachmentWindow()
		{
			if (this.attachmentWindow != null)
			{
				this.attachmentWindow.setReadOnly(true);
				this.attachmentWindow.display(true, null, 0, 0);
			}
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x00178200 File Offset: 0x00176400
		private void mailThread_reply()
		{
			if (this.attachmentWindow == null)
			{
				MailAttachmentPopup mailAttachmentPopup = new MailAttachmentPopup(this);
				mailAttachmentPopup.initProperties(false, SK.Text("MailScreen_Attachments", "Targets"), null);
				this.attachmentWindow = mailAttachmentPopup;
			}
			this.attachmentWindow.setReadOnly(false);
			this.attachmentWindow.clearContents(true);
			this.proclamation = false;
			this.sendThreadID = this.selectedMailThreadID;
			this.sendAsForward = false;
			this.changeSearchTab(-1, false);
			this.newMail_iconTab1Button.Visible = false;
			this.newMail_iconTab2Button.Visible = false;
			this.newMail_iconTab3Button.Visible = false;
			this.newMail_iconTab4Button.Visible = false;
			this.newMail_iconBackground.Visible = false;
			this.populateToFromCurrentMail();
			this.newMail_ToList.Enabled = false;
			this.mailListArea.Visible = false;
			this.mailThreadArea.Visible = false;
			this.newMailArea.Visible = true;
			this.mailCreateFolderArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbSubject.Enabled = false;
			this.tbFindInput.Visible = false;
			this.newMail_removeRecipient.Enabled = false;
			this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
			this.newMail_iconBackButton.Text.Text = SK.Text("MailScreen_Back_To_Mail", "Back To Mail");
			this.headerLabel.Text = SK.Text("MailScreen_Reply", "Reply");
			this.headerLabel2.Text = "";
			this.newMail_iconSendMail.Text.Text = SK.Text("MailScreen_Reply", "Reply");
			this.newMail_iconSendMail.Visible = true;
			this.tbMain.Text = "";
			this.tbMain.Focus();
			this.updateSendButton();
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x00018789 File Offset: 0x00016989
		public void mailTo(string username)
		{
			this.openNewMail("", "");
			this.addNameToRecipients(username);
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x00178404 File Offset: 0x00176604
		public void mailTo(string[] usernames)
		{
			this.openNewMail("", "");
			foreach (string name in usernames)
			{
				this.addNameToRecipients(name);
			}
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x0017843C File Offset: 0x0017663C
		public void sendProclamation(int mailType, int areaID)
		{
			this.openNewMail("", "");
			this.proclamation = true;
			this.specialType = mailType;
			this.specialArea = areaID;
			this.newMail_iconBackground.Visible = false;
			this.tbSubject.Text = "";
			this.tbSubject.Enabled = false;
			this.tbFindInput.Visible = false;
			this.newMail_iconTab1Button.Visible = false;
			this.newMail_iconTab2Button.Visible = false;
			this.newMail_iconTab3Button.Visible = false;
			this.newMail_iconTab4Button.Visible = false;
			switch (mailType)
			{
			case 1:
				this.tbSubject.Enabled = true;
				break;
			case 2:
				this.tbSubject.Text = SK.Text("MailScreen_House_Proclamation", "House Proclamation");
				this.headerLabel.Text = SK.Text("MailScreen_Send_House_Proclamation", "Send House Proclamation");
				break;
			case 3:
				this.tbSubject.Text = "";
				break;
			case 4:
				this.tbSubject.Text = SK.Text("MailScreen_Parish_Proclamation", "Parish Proclamation") + " : " + GameEngine.Instance.World.getParishName(areaID);
				this.headerLabel.Text = SK.Text("MailScreen_Send_Parish_Proclamation", "Send Parish Proclamation");
				break;
			case 5:
				this.tbSubject.Text = SK.Text("MailScreen_County_Proclamation", "County Proclamation") + " : " + GameEngine.Instance.World.getCountyName(areaID);
				this.headerLabel.Text = SK.Text("MailScreen_Send_County_Proclamation", "Send County Proclamation");
				break;
			case 6:
				this.tbSubject.Text = SK.Text("MailScreen_Province_Proclamation", "Province Proclamation") + " : " + GameEngine.Instance.World.getProvinceName(areaID);
				this.headerLabel.Text = SK.Text("MailScreen_Send_Province_Proclamation", "Send Province Proclamation");
				break;
			case 7:
				this.tbSubject.Text = SK.Text("MailScreen_Country_Proclamation", "Country Proclamation") + " : " + GameEngine.Instance.World.getCountryName(areaID);
				this.headerLabel.Text = SK.Text("MailScreen_Send_Country_Proclamation", "Send Country Proclamation");
				break;
			}
			this.updateSendButton();
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x001786A4 File Offset: 0x001768A4
		private void openNewMail(string subject, string body)
		{
			this.proclamation = false;
			if (this.attachmentWindow == null)
			{
				MailAttachmentPopup mailAttachmentPopup = new MailAttachmentPopup(this);
				mailAttachmentPopup.initProperties(false, SK.Text("MailScreen_Attachments", "Targets"), null);
				this.attachmentWindow = mailAttachmentPopup;
			}
			if (this.attachmentWindow != null)
			{
				this.attachmentWindow.clearContents(true);
				this.attachmentWindow.setReadOnly(false);
			}
			this.sendThreadID = -1L;
			this.sendAsForward = false;
			this.tbFindInput.Text = "";
			this.changeSearchTab(0, false);
			this.newMail_iconTab1Button.Visible = true;
			this.newMail_iconTab2Button.Visible = true;
			this.newMail_iconTab3Button.Visible = true;
			this.newMail_iconTab4Button.Visible = true;
			this.newMail_iconBackground.Visible = true;
			this.recipients.Clear();
			this.populateToList();
			this.newMail_ToList.Enabled = true;
			this.newMail_removeRecipient.Enabled = false;
			this.mailListArea.Visible = false;
			this.mailThreadArea.Visible = false;
			this.newMailArea.Visible = true;
			this.mailCreateFolderArea.Visible = false;
			this.tbMain.Visible = this.newMailArea.Visible;
			this.tbUserFilter.Visible = this.mailListArea.Visible;
			this.tbSubject.Visible = this.newMailArea.Visible;
			this.tbFindInput.Visible = (this.newMailArea.Visible && this.newMail_iconTab1Area.Visible);
			this.tbSubject.Enabled = true;
			this.tbNewFolder.Visible = this.mailCreateFolderArea.Visible;
			this.newMail_iconBackButton.Text.Text = SK.Text("MailScreen_Back_To_Mail_List", "Back To Mail List");
			this.headerLabel.Text = SK.Text("MailScreen_New_Mail", "New Mail");
			this.newMail_iconSendMail.Text.Text = SK.Text("MailScreen_Send_Mail", "Send Mail");
			this.newMail_iconSendMail.Visible = true;
			this.headerLabel2.Text = "";
			if (body.Length > 0)
			{
				this.tbMain.Text = this.parseAttachmentString(body, true);
			}
			else
			{
				this.tbMain.Text = body;
			}
			this.tbSubject.Text = subject;
			this.tbMain.Focus();
			this.updateSendButton();
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x000187A2 File Offset: 0x000169A2
		private void flagUpdateSendButton()
		{
			this.doUpdateSendButton = true;
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x00178908 File Offset: 0x00176B08
		private void updateSendButton()
		{
			this.doUpdateSendButton = false;
			bool flag = (this.tbMain.Text.Length > 0 && this.recipients.Count > 0 && (this.sendThreadID >= 0L || this.tbSubject.Text.Length > 0)) || (this.proclamation && this.tbMain.Text.Length > 0);
			if (flag != this.newMail_iconSendMail.Enabled)
			{
				this.newMail_iconSendMail.Enabled = flag;
				this.newMail_iconSendMail.invalidate();
			}
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x000187AB File Offset: 0x000169AB
		private void searchTab1Clicked()
		{
			this.changeSearchTab(0, true);
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x000187B5 File Offset: 0x000169B5
		private void searchTab2Clicked()
		{
			this.changeSearchTab(1, true);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x000187BF File Offset: 0x000169BF
		private void searchTab3Clicked()
		{
			this.changeSearchTab(2, true);
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x000187C9 File Offset: 0x000169C9
		private void searchTab4Clicked()
		{
			this.changeSearchTab(3, true);
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x001789A4 File Offset: 0x00176BA4
		private string generateAttachmentsString()
		{
			if (this.attachmentWindow == null)
			{
				return "";
			}
			List<MailLink> links = this.attachmentWindow.getLinks();
			return this.mailController.generateAttachmentsString(links);
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x001789D8 File Offset: 0x00176BD8
		private string parseAttachmentString(string bodyText, bool applyLinks)
		{
			bool flag = this.mailController.stringContainsAttachments(bodyText);
			this.mailThread_openAttachments.Enabled = (flag && applyLinks);
			this.mailThread_openAttachments.Visible = (flag && applyLinks);
			if (flag && applyLinks)
			{
				List<MailLink> inputList = this.mailController.parseAttachmentString(bodyText);
				if (this.attachmentWindow == null)
				{
					MailAttachmentPopup mailAttachmentPopup = new MailAttachmentPopup(this);
					mailAttachmentPopup.initProperties(false, SK.Text("MailScreen_Attachments", "Targets"), null);
					this.attachmentWindow = mailAttachmentPopup;
				}
				this.attachmentWindow.clearContents(true);
				this.attachmentWindow.SetLinks(inputList, true);
			}
			return this.mailController.getBodyTextFromString(bodyText);
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x00178A74 File Offset: 0x00176C74
		private void sendMail()
		{
			this.newMail_iconSendMail.Visible = false;
			foreach (string name in this.recipients)
			{
				this.addNameToRecent(name);
			}
			string body = this.tbMain.Text + this.generateAttachmentsString();
			if (!this.proclamation)
			{
				this.mailController.SendMail(this.tbSubject.Text, body, this.recipients.ToArray(), this.sendThreadID, this.sendAsForward, new RemoteServices.SendMail_UserCallBack(this.sendMailCallback));
			}
			else
			{
				this.mailController.SendProclamation(this.tbSubject.Text, body, this.specialType, this.specialArea, new RemoteServices.SendSpecialMail_UserCallBack(this.sendSpecialMailCallback));
			}
			this.mailSent = true;
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x00178B64 File Offset: 0x00176D64
		public void sendMailCallback(SendMail_ReturnType returnData)
		{
			this.newMail_iconSendMail.Visible = true;
			if (returnData.Success)
			{
				this.open(true, true);
				return;
			}
			ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
			if (errorCode - ErrorCodes.ErrorCode.MAIL_SUBJECT_TOO_LONG <= 3)
			{
				string errorString = ErrorCodes.getErrorString(returnData.m_errorCode);
				MyMessageBox.Show(errorString, SK.Text("MailScreen_Send_Mail_Failed", "Send Mail Failed"));
				return;
			}
			string errorString2 = ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID);
			MyMessageBox.Show(errorString2, SK.Text("MailScreen_Send_Mail_Failed", "Send Mail Failed"));
			InterfaceMgr.Instance.refreshForMail(false);
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x00178BF4 File Offset: 0x00176DF4
		public void sendSpecialMailCallback(SendSpecialMail_ReturnType returnData)
		{
			this.newMail_iconSendMail.Visible = true;
			if (returnData.Success)
			{
				this.open(true, true);
				if (this.specialType == 2)
				{
					try
					{
						FactionData yourFaction = GameEngine.Instance.World.YourFaction;
						int num = 0;
						if (yourFaction != null)
						{
							num = yourFaction.houseID;
						}
						HouseData[] houseInfo = GameEngine.Instance.World.HouseInfo;
						houseInfo[num].lastProclomationDate = VillageMap.getCurrentServerTime();
					}
					catch
					{
					}
				}
				return;
			}
			ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
			if (errorCode - ErrorCodes.ErrorCode.MAIL_SUBJECT_TOO_LONG <= 3)
			{
				string errorString = ErrorCodes.getErrorString(returnData.m_errorCode);
				MyMessageBox.Show(errorString, SK.Text("MailScreen_Send_Mail_Failed", "Send Mail Failed"));
				return;
			}
			string errorString2 = ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID);
			MyMessageBox.Show(errorString2, SK.Text("MailScreen_Send_Mail_Failed", "Send Mail Failed"));
			InterfaceMgr.Instance.refreshForMail(false);
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x00178CE0 File Offset: 0x00176EE0
		private MailScreen.MailFolderLine getFolderLine(int lineID)
		{
			switch (lineID)
			{
			case 0:
				return this.mailList_folderLine01;
			case 1:
				return this.mailList_folderLine02;
			case 2:
				return this.mailList_folderLine03;
			case 3:
				return this.mailList_folderLine04;
			case 4:
				return this.mailList_folderLine05;
			case 5:
				return this.mailList_folderLine06;
			case 6:
				return this.mailList_folderLine07;
			case 7:
				return this.mailList_folderLine08;
			case 8:
				return this.mailList_folderLine09;
			case 9:
				return this.mailList_folderLine10;
			case 10:
				return this.mailList_folderLine11;
			case 11:
				return this.mailList_folderLine12;
			case 12:
				return this.mailList_folderLine13;
			case 13:
				return this.mailList_folderLine14;
			case 14:
				return this.mailList_folderLine15;
			case 15:
				return this.mailList_folderLine16;
			case 16:
				return this.mailList_folderLine17;
			case 17:
				return this.mailList_folderLine18;
			case 18:
				return this.mailList_folderLine19;
			case 19:
				return this.mailList_folderLine20;
			case 20:
				return this.mailList_folderLine21;
			case 21:
				return this.mailList_folderLine22;
			case 22:
				return this.mailList_folderLine23;
			case 23:
				return this.mailList_folderLine24;
			case 24:
				return this.mailList_folderLine25;
			case 25:
				return this.mailList_folderLine26;
			case 26:
				return this.mailList_folderLine27;
			default:
				return null;
			}
		}

		// Token: 0x0600176E RID: 5998 RVA: 0x00178E24 File Offset: 0x00177024
		private MailScreen.MailListLine getMailListLine(int lineID)
		{
			switch (lineID)
			{
			case 0:
				return this.mailList_listLine01;
			case 1:
				return this.mailList_listLine02;
			case 2:
				return this.mailList_listLine03;
			case 3:
				return this.mailList_listLine04;
			case 4:
				return this.mailList_listLine05;
			case 5:
				return this.mailList_listLine06;
			case 6:
				return this.mailList_listLine07;
			case 7:
				return this.mailList_listLine08;
			case 8:
				return this.mailList_listLine09;
			case 9:
				return this.mailList_listLine10;
			case 10:
				return this.mailList_listLine11;
			case 11:
				return this.mailList_listLine12;
			case 12:
				return this.mailList_listLine13;
			case 13:
				return this.mailList_listLine14;
			case 14:
				return this.mailList_listLine15;
			case 15:
				return this.mailList_listLine16;
			case 16:
				return this.mailList_listLine17;
			case 17:
				return this.mailList_listLine18;
			case 18:
				return this.mailList_listLine19;
			case 19:
				return this.mailList_listLine20;
			case 20:
				return this.mailList_listLine21;
			case 21:
				return this.mailList_listLine22;
			case 22:
				return this.mailList_listLine23;
			case 23:
				return this.mailList_listLine24;
			case 24:
				return this.mailList_listLine25;
			case 25:
				return this.mailList_listLine26;
			case 26:
				return this.mailList_listLine27;
			default:
				return null;
			}
		}

		// Token: 0x0600176F RID: 5999 RVA: 0x000187D3 File Offset: 0x000169D3
		private void mailList_scrollBarValueMoved()
		{
			this.repopulateTable();
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x00178F68 File Offset: 0x00177168
		private void mailList_scrollBarMoved()
		{
			this.mailList_scrollTabLines.Position = new Point(this.mailList_scrollBar.TabPosition.X, (this.mailList_scrollBar.TabSize - 8) / 2 + this.mailList_scrollBar.TabPosition.Y);
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x000187DB File Offset: 0x000169DB
		private void mailList_ScrollUp()
		{
			this.mailList_scrollBar.scrollUp();
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x000187E8 File Offset: 0x000169E8
		private void mailList_ScrollDown()
		{
			this.mailList_scrollBar.scrollDown();
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x000187F5 File Offset: 0x000169F5
		private void mailList_MouseWheel(int delta)
		{
			if (delta < 0)
			{
				this.mailList_scrollBar.scrollDown();
				return;
			}
			if (delta > 0)
			{
				this.mailList_scrollBar.scrollUp();
			}
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x00178FBC File Offset: 0x001771BC
		private void mailList_NewMail()
		{
			if (this.attachmentWindow == null)
			{
				MailAttachmentPopup mailAttachmentPopup = new MailAttachmentPopup(this);
				mailAttachmentPopup.initProperties(false, SK.Text("MailScreen_Attachments", "Targets"), null);
				this.attachmentWindow = mailAttachmentPopup;
			}
			this.attachmentWindow.setReadOnly(false);
			this.openNewMail("", "");
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x00179014 File Offset: 0x00177214
		private void mailLineClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
				int data = clickedControl.Data;
				if (data >= 0)
				{
					this.mailLineClicked(data, true);
				}
			}
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x00179044 File Offset: 0x00177244
		private void mailLineClicked(int lineClicked, bool closeSections)
		{
			if (lineClicked >= 0)
			{
				try
				{
					this.lastMailLineClicked = lineClicked;
					bool shiftPressed = GameEngine.shiftPressed;
					bool flag = GameEngine.Instance.GFX.keyControlled;
					if (shiftPressed)
					{
						flag = false;
					}
					DateTime now = DateTime.Now;
					long mailThreadID = this.mailController.preSortedHeaders[lineClicked].mailThreadID;
					if (mailThreadID == this.selectedMailThreadID && !shiftPressed && !flag && (now - this.mailLineDoubleClick).TotalSeconds < 2.0)
					{
						GameEngine.Instance.playInterfaceSound("MailScreen_thread_opened");
						this.openMailThread(this.selectedMailThreadID);
						this.mailLineDoubleClick = DateTime.MinValue;
					}
					else
					{
						if ((shiftPressed || flag) && this.selectedMailThreadID >= 0L)
						{
							if (shiftPressed)
							{
								if (mailThreadID < 0L)
								{
									goto IL_40E;
								}
								long num = this.selectedMailThreadID;
								long num2 = mailThreadID;
								if (num == num2)
								{
									goto IL_40E;
								}
								bool flag2 = false;
								using (List<MailThreadListItem>.Enumerator enumerator = this.mailController.preSortedHeaders.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										MailThreadListItem mailThreadListItem = enumerator.Current;
										bool flag3 = flag2;
										if (mailThreadListItem.mailThreadID == num || mailThreadListItem.mailThreadID == num2)
										{
											if (!flag2)
											{
												flag2 = true;
												flag3 = true;
											}
											else
											{
												flag2 = false;
												flag3 = true;
											}
										}
										if (flag3 && !this.selectedMailThreadIDList.Contains(mailThreadListItem.mailThreadID))
										{
											this.selectedMailThreadIDList.Add(mailThreadListItem.mailThreadID);
										}
									}
									goto IL_40E;
								}
							}
							if (flag && mailThreadID >= 0L)
							{
								if (this.selectedMailThreadIDList.Contains(mailThreadID))
								{
									this.selectedMailThreadIDList.Remove(mailThreadID);
									if (this.selectedMailThreadID == mailThreadID)
									{
										if (this.selectedMailThreadIDList.Count > 0)
										{
											this.selectedMailThreadID = this.selectedMailThreadIDList[0];
										}
										else
										{
											this.selectedMailThreadID = -1L;
										}
									}
								}
								else
								{
									this.selectedMailThreadIDList.Add(mailThreadID);
								}
							}
						}
						else
						{
							this.selectedMailThreadID = mailThreadID;
							if (!closeSections && this.selectedMailThreadID < 0L)
							{
								goto IL_4B8;
							}
							this.selectedMailThreadIDList.Clear();
							this.selectedMailThreadIDList.Add(this.selectedMailThreadID);
							if (this.selectedMailThreadID < 0L)
							{
								GameEngine.Instance.playInterfaceSound("MailScreen_thread_toggled_old");
								long num3 = this.selectedMailThreadID;
								if (num3 <= -1L && num3 >= -5L)
								{
									long num4 = num3 - -5L;
									long num5 = num4;
									if (num5 <= 4L)
									{
										switch ((uint)num5)
										{
										case 0U:
											this.mailController.openAll = !this.mailController.openAll;
											if (!this.mailController.downloadedAll)
											{
												this.mailController.GetMailThreadList(true, 5, new MailManager.GenericUIDelegate(this.repopulateTable));
											}
											break;
										case 1U:
											this.mailController.openThisMonth = !this.mailController.openThisMonth;
											if (!this.mailController.downloadedThisMonth)
											{
												this.mailController.GetMailThreadList(true, 4, new MailManager.GenericUIDelegate(this.repopulateTable));
											}
											break;
										case 2U:
											this.mailController.openThisWeek = !this.mailController.openThisWeek;
											if (!this.mailController.downloadedThisWeek)
											{
												this.mailController.GetMailThreadList(true, 3, new MailManager.GenericUIDelegate(this.repopulateTable));
											}
											break;
										case 3U:
											this.mailController.open3Days = !this.mailController.open3Days;
											if (!this.mailController.downloaded3Days)
											{
												this.mailController.GetMailThreadList(true, 2, new MailManager.GenericUIDelegate(this.repopulateTable));
											}
											break;
										case 4U:
											this.mailController.openYesterday = !this.mailController.openYesterday;
											if (!this.mailController.downloadedYesterday)
											{
												this.mailController.GetMailThreadList(true, 1, new MailManager.GenericUIDelegate(this.repopulateTable));
											}
											break;
										}
									}
								}
								this.mailController.preSortThreadHeaders();
								this.selectedMailThreadID = -1000L;
								this.selectedMailThreadIDList.Clear();
							}
							else
							{
								GameEngine.Instance.playInterfaceSound("MailScreen_main_line_clicked");
								this.mailLineDoubleClick = now;
							}
						}
						IL_40E:
						this.repopulateTable();
						if (this.selectedMailThreadIDList.Count > 1)
						{
							this.mailList_iconSelectedOpen.Enabled = false;
							this.mailList_iconSelectedMoveThread.Text.Text = SK.Text("MailScreen_Move_These_Threads", "Move These Threads");
							this.mailList_iconSelectedDelete.Text.Text = SK.Text("MailScreen_Delete_Threads", "Delete Threads");
						}
						else
						{
							this.mailList_iconSelectedOpen.Enabled = true;
							this.mailList_iconSelectedMoveThread.Text.Text = SK.Text("MailScreen_Move_This_Thread", "Move This Thread");
							this.mailList_iconSelectedDelete.Text.Text = SK.Text("MailScreen_Delete_Thread", "Delete Thread");
						}
					}
					IL_4B8:;
				}
				catch (Exception ex)
				{
					UniversalDebugLog.Log("Exception when clicking mail " + ex.Message);
				}
			}
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0017955C File Offset: 0x0017775C
		private MailScreen.MailThreadLine getMailThreadLine(int lineID)
		{
			switch (lineID)
			{
			case 0:
				return this.mailThread_listLine01;
			case 1:
				return this.mailThread_listLine02;
			case 2:
				return this.mailThread_listLine03;
			case 3:
				return this.mailThread_listLine04;
			case 4:
				return this.mailThread_listLine05;
			case 5:
				return this.mailThread_listLine06;
			case 6:
				return this.mailThread_listLine07;
			case 7:
				return this.mailThread_listLine08;
			case 8:
				return this.mailThread_listLine09;
			case 9:
				return this.mailThread_listLine10;
			case 10:
				return this.mailThread_listLine11;
			case 11:
				return this.mailThread_listLine12;
			case 12:
				return this.mailThread_listLine13;
			case 13:
				return this.mailThread_listLine14;
			case 14:
				return this.mailThread_listLine15;
			case 15:
				return this.mailThread_listLine16;
			case 16:
				return this.mailThread_listLine17;
			case 17:
				return this.mailThread_listLine18;
			case 18:
				return this.mailThread_listLine19;
			case 19:
				return this.mailThread_listLine20;
			case 20:
				return this.mailThread_listLine21;
			case 21:
				return this.mailThread_listLine22;
			case 22:
				return this.mailThread_listLine23;
			case 23:
				return this.mailThread_listLine24;
			case 24:
				return this.mailThread_listLine25;
			case 25:
				return this.mailThread_listLine26;
			case 26:
				return this.mailThread_listLine27;
			default:
				return null;
			}
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x00018816 File Offset: 0x00016A16
		private void mailThread_scrollBarValueMoved()
		{
			this.displayThread(this.selectedMailThreadID, false);
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x001796A0 File Offset: 0x001778A0
		private void mailThread_scrollBarMoved()
		{
			this.mailThread_scrollTabLines.Position = new Point(this.mailThread_scrollBar.TabPosition.X, (this.mailThread_scrollBar.TabSize - 8) / 2 + this.mailThread_scrollBar.TabPosition.Y);
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x00018825 File Offset: 0x00016A25
		private void mailThread_ScrollUp()
		{
			this.mailThread_scrollBar.scrollUp();
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x00018832 File Offset: 0x00016A32
		private void mailThread_ScrollDown()
		{
			this.mailThread_scrollBar.scrollDown();
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0001883F File Offset: 0x00016A3F
		private void mailThread_MouseWheel(int delta)
		{
			if (delta < 0)
			{
				this.mailThread_scrollBar.scrollDown();
				return;
			}
			if (delta > 0)
			{
				this.mailThread_scrollBar.scrollUp();
			}
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x00018860 File Offset: 0x00016A60
		private void mailThreadBody_scrollBarValueMoved()
		{
			this.mailThread_mailBodyText.VerticalOffset = this.mailThreadBody_scrollBar.Value;
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x001796F4 File Offset: 0x001778F4
		private void mailThreadBody_scrollBarMoved()
		{
			this.mailThreadBody_scrollTabLines.Position = new Point(this.mailThreadBody_scrollBar.TabPosition.X, (this.mailThreadBody_scrollBar.TabSize - 8) / 2 + this.mailThreadBody_scrollBar.TabPosition.Y);
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x00018878 File Offset: 0x00016A78
		private void mailThreadBody_ScrollUp()
		{
			this.mailThreadBody_scrollBar.scrollUp();
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x00018885 File Offset: 0x00016A85
		private void mailThreadBody_ScrollDown()
		{
			this.mailThreadBody_scrollBar.scrollDown();
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x00018892 File Offset: 0x00016A92
		private void mailThreadBody_MouseWheel(int delta)
		{
			if (delta < 0)
			{
				this.mailThreadBody_scrollBar.scrollDown();
				return;
			}
			if (delta > 0)
			{
				this.mailThreadBody_scrollBar.scrollUp();
			}
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x00179748 File Offset: 0x00177948
		private void bodyTextHeightChanged(int textHeight)
		{
			this.mailThreadBody_scrollBar.Value = 0;
			this.mailThreadBody_scrollBar.Max = Math.Max(0, textHeight - this.mailThread_mailBodyText.Height);
			this.mailThreadBody_scrollBar.invalidate();
			this.mailThread_mailBodyText.VerticalOffset = 0;
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x00179798 File Offset: 0x00177998
		private void mailTextClicked()
		{
			ViewMailPopup viewMailPopup = new ViewMailPopup();
			viewMailPopup.init(this, this.lastSubject, this.mailThread_mailBodyText.Text, this.mailThread_mailHeaderFromNameLabel.Text, this.mailThread_mailHeaderDateValueLabel.Text);
			viewMailPopup.ShowDialog(base.ParentForm);
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x001797E8 File Offset: 0x001779E8
		private void copyTextToClipboardClick()
		{
			try
			{
				if (this.ClickedControl != null && this.ClickedControl.GetType() == typeof(CustomSelfDrawPanel.CSDLabel))
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = (CustomSelfDrawPanel.CSDLabel)this.ClickedControl;
					Clipboard.SetText(csdlabel.Text);
				}
				if (this.ClickedControl != null && this.ClickedControl.GetType() == typeof(CustomSelfDrawPanel.CSDScrollLabel))
				{
					CustomSelfDrawPanel.CSDScrollLabel csdscrollLabel = (CustomSelfDrawPanel.CSDScrollLabel)this.ClickedControl;
					Clipboard.SetText(csdscrollLabel.Text);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x00179878 File Offset: 0x00177A78
		private void mailItemClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
				int data = clickedControl.Data;
				if (data >= 0)
				{
					this.mailItemClicked(data);
				}
			}
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x001798A8 File Offset: 0x00177AA8
		private void mailItemClicked(int lineClicked)
		{
			try
			{
				this.lastMailItemClicked = lineClicked;
				DateTime now = DateTime.Now;
				MailThreadItem[] array = (MailThreadItem[])this.mailController.storedThreads[this.selectedMailThreadID];
				long num = this.selectedMailItemID = array[lineClicked].mailID;
				GameEngine.Instance.playInterfaceSound("MailScreen_mail_post_clicked");
				this.showMailItem(lineClicked);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x0017991C File Offset: 0x00177B1C
		private void showMailItem(int lineClicked)
		{
			this.lastLineClicked = lineClicked;
			MailThreadItem[] array = (MailThreadItem[])this.mailController.storedThreads[this.selectedMailThreadID];
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
			if (!array[lineClicked].readStatus)
			{
				array[lineClicked].readStatus = true;
				bool flag = true;
				MailThreadItem[] array2 = array;
				foreach (MailThreadItem mailThreadItem in array2)
				{
					if (!mailThreadItem.readStatus)
					{
						flag = false;
						break;
					}
				}
				if (flag && this.mailController.storedThreadHeaders[this.selectedMailThreadID] != null)
				{
					mailThreadListItem.readStatus = true;
				}
				this.mailController.SetMailRead(array[lineClicked].mailID);
			}
			this.displayThread(this.selectedMailThreadID, false);
			this.mailThreadBody_scrollBar.Value = 0;
			this.mailThreadBody_scrollBar.Max = 0;
			this.mailThread_mailHeaderFromNameLabel.Text = array[lineClicked].otherUser;
			this.mailThread_fromShield.Image = GameEngine.Instance.World.getWorldShield(array[lineClicked].otherUserID, 25, 28);
			this.mailThread_fromShield.Visible = (this.mailThread_fromShield.Image != null);
			if (mailThreadListItem != null && mailThreadListItem.readOnly && mailThreadListItem.specialType == 1)
			{
				this.mailThread_mailBodyText.Text = MailManager.languageSplitString(array[lineClicked].body);
				this.mailThread_mailHeaderFromNameLabel.Text = SK.Text("The_Kingdoms_Team", "The Kingdoms Team");
				this.mailThread_fromShield.Visible = false;
			}
			else if (!this.mailController.blockedList.Contains(array[lineClicked].otherUser))
			{
				this.mailThread_mailBodyText.Text = this.parseAttachmentString(array[lineClicked].body, true);
			}
			else
			{
				this.mailThread_mailBodyText.Text = "* " + SK.Text("MailBlock_blocked", "Blocked") + " *";
			}
			this.mailThread_mailHeaderDateValueLabel.Text = string.Concat(new string[]
			{
				array[lineClicked].mailTime.ToShortDateString(),
				" ",
				array[lineClicked].mailTime.Hour.ToString("00"),
				":",
				array[lineClicked].mailTime.Minute.ToString("00")
			});
			if (array[lineClicked].otherUser != RemoteServices.Instance.UserName)
			{
				this.mailThread_iconSelectedBlockPoster.Enabled = true;
				this.selectedUserName = array[lineClicked].otherUser;
				if (this.mailController.blockedList.Contains(this.selectedUserName))
				{
					this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailBlock_manage", "Manage Blocked Users");
				}
				else
				{
					this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailScreen_Block_This_User", "Block This User");
				}
			}
			else
			{
				this.mailThread_iconSelectedBlockPoster.Enabled = false;
				this.selectedUserName = "";
				this.mailThread_iconSelectedBlockPoster.Text.Text = SK.Text("MailScreen_Block_This_User", "Block This User");
			}
			if (array[lineClicked].otherUserID == RemoteServices.Instance.UserID && !RemoteServices.Instance.Admin && !RemoteServices.Instance.Moderator)
			{
				this.mailThread_iconSelectedReportMail.Enabled = false;
				return;
			}
			this.mailThread_iconSelectedReportMail.Enabled = this.reportButtonAvailable;
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x00179C88 File Offset: 0x00177E88
		public void getMailUserSearchCallback(GetMailUserSearch_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			if (returnData.mailUsersSearch != null)
			{
				string[] mailUsersSearch = returnData.mailUsersSearch;
				foreach (string text in mailUsersSearch)
				{
					list.Add(new CustomSelfDrawPanel.CSDListItem
					{
						Text = text
					});
				}
			}
			this.newMail_iconFindList.populate(list);
			if (this.newMail_iconFindList.getSelectedItem() == null)
			{
				this.newMail_iconFindAddButton.Enabled = false;
				this.newMail_iconFindFavouritesButton.Enabled = false;
				return;
			}
			this.newMail_iconFindAddButton.Enabled = true;
			this.newMail_iconFindFavouritesButton.Enabled = true;
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x00018231 File Offset: 0x00016431
		private void tbFindInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x000188B3 File Offset: 0x00016AB3
		private void tbFindInput_KeyUp(object sender, KeyEventArgs e)
		{
			this.mailController.resetUpdateTimer();
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x000188B3 File Offset: 0x00016AB3
		private void tbFindInput_TextChanged(object sender, EventArgs e)
		{
			this.mailController.resetUpdateTimer();
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x000188C0 File Offset: 0x00016AC0
		private void newMail_FindLineClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.newMail_iconFindAddButton.Enabled = true;
				this.newMail_iconFindFavouritesButton.Enabled = true;
				return;
			}
			this.newMail_iconFindAddButton.Enabled = false;
			this.newMail_iconFindFavouritesButton.Enabled = false;
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x000188F6 File Offset: 0x00016AF6
		private void newMail_FindLineDoubleClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.addNameToRecipients(item.Text);
			}
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x00179D2C File Offset: 0x00177F2C
		private void fillRecentList()
		{
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			if (this.mailController.mailUsersHistory != null)
			{
				string[] mailUsersHistory = this.mailController.mailUsersHistory;
				foreach (string text in mailUsersHistory)
				{
					list.Add(new CustomSelfDrawPanel.CSDListItem
					{
						Text = text
					});
				}
			}
			this.newMail_iconRecentList.populate(list);
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x00179D94 File Offset: 0x00177F94
		private void fillFavouritesList()
		{
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			if (this.mailController.mailFavourites != null)
			{
				string[] mailFavourites = this.mailController.mailFavourites;
				foreach (string text in mailFavourites)
				{
					list.Add(new CustomSelfDrawPanel.CSDListItem
					{
						Text = text
					});
				}
			}
			this.newMail_iconFavouritesList.populate(list);
		}

		// Token: 0x06001790 RID: 6032 RVA: 0x00179DFC File Offset: 0x00177FFC
		private void fillKnownList()
		{
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			bool flag = false;
			if (RemoteServices.Instance.UserFactionID >= 0)
			{
				FactionMemberData[] factionMemberData = GameEngine.Instance.World.getFactionMemberData(RemoteServices.Instance.UserFactionID, ref flag);
				if (factionMemberData != null)
				{
					FactionMemberData[] array = factionMemberData;
					foreach (FactionMemberData factionMemberData2 in array)
					{
						if (factionMemberData2.userID != RemoteServices.Instance.UserID)
						{
							list.Add(new CustomSelfDrawPanel.CSDListItem
							{
								Text = factionMemberData2.userName
							});
						}
					}
				}
			}
			List<UserRelationship> userRelations = GameEngine.Instance.World.UserRelations;
			if (userRelations != null && userRelations.Count > 0)
			{
				foreach (UserRelationship userRelationship in userRelations)
				{
					if (userRelationship.friendly)
					{
						list.Add(new CustomSelfDrawPanel.CSDListItem
						{
							Text = userRelationship.userName
						});
					}
				}
			}
			this.newMail_iconKnownList.populate(list);
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x00179F18 File Offset: 0x00178118
		private void addFindNameToRecipients()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconFindList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToRecipients(selectedItem.Text);
			}
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x00179F40 File Offset: 0x00178140
		private void addRecentNameToRecipients()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconRecentList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToRecipients(selectedItem.Text);
			}
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x00179F68 File Offset: 0x00178168
		private void addFavouritesNameToRecipients()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconFavouritesList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToRecipients(selectedItem.Text);
			}
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x00179F90 File Offset: 0x00178190
		private void addKnownNameToRecipients()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconKnownList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToRecipients(selectedItem.Text);
			}
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x00018907 File Offset: 0x00016B07
		private void newMail_RecentLineClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.newMail_iconRecentAddButton.Enabled = true;
				this.newMail_iconRecentFavouritesButton.Enabled = true;
				return;
			}
			this.newMail_iconRecentAddButton.Enabled = false;
			this.newMail_iconRecentFavouritesButton.Enabled = false;
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x000188F6 File Offset: 0x00016AF6
		private void newMail_RecentLineDoubleClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.addNameToRecipients(item.Text);
			}
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x0001893D File Offset: 0x00016B3D
		private void newMail_FavouritesLineClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.newMail_iconFavouritesAddButton.Enabled = true;
				this.newMail_iconFavouritesRemoveButton.Enabled = true;
				return;
			}
			this.newMail_iconFavouritesAddButton.Enabled = false;
			this.newMail_iconFavouritesRemoveButton.Enabled = false;
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x000188F6 File Offset: 0x00016AF6
		private void newMail_FavouritesLineDoubleClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.addNameToRecipients(item.Text);
			}
		}

		// Token: 0x06001799 RID: 6041 RVA: 0x00018973 File Offset: 0x00016B73
		private void newMail_KnownLineClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.newMail_iconKnownAddButton.Enabled = true;
				this.newMail_iconKnownFavouritesButton.Enabled = true;
				return;
			}
			this.newMail_iconKnownAddButton.Enabled = false;
			this.newMail_iconKnownFavouritesButton.Enabled = false;
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x000188F6 File Offset: 0x00016AF6
		private void newMail_KnownLineDoubleClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.addNameToRecipients(item.Text);
			}
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x00179FB8 File Offset: 0x001781B8
		private void addFindNameToFavourites()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconFindList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToFavourites(selectedItem.Text);
			}
		}

		// Token: 0x0600179C RID: 6044 RVA: 0x00179FE0 File Offset: 0x001781E0
		private void removeNameFromFavourites()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconFavouritesList.getSelectedItem();
			if (selectedItem == null)
			{
				return;
			}
			List<string> list = new List<string>();
			if (this.mailController.mailFavourites != null)
			{
				string[] mailFavourites = this.mailController.mailFavourites;
				foreach (string text in mailFavourites)
				{
					if (!(text == selectedItem.Text))
					{
						list.Add(text);
					}
				}
			}
			if (this.mailController.mailFavourites.Length != list.Count)
			{
				this.mailController.mailFavourites = list.ToArray();
				RemoteServices.Instance.RemoveUserFromFavourites(selectedItem.Text);
				this.fillFavouritesList();
			}
		}

		// Token: 0x0600179D RID: 6045 RVA: 0x0017A08C File Offset: 0x0017828C
		private void addRecentNameToFavourites()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconRecentList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToFavourites(selectedItem.Text);
			}
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x0017A0B4 File Offset: 0x001782B4
		private void addKnownNameToFavourites()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_iconKnownList.getSelectedItem();
			if (selectedItem != null)
			{
				this.addNameToFavourites(selectedItem.Text);
			}
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x000189A9 File Offset: 0x00016BA9
		private void addNameToFavourites(string name)
		{
			this.mailController.AddNameToFavourites(name);
			this.fillFavouritesList();
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x000189BD File Offset: 0x00016BBD
		private void addNameToRecent(string name)
		{
			this.mailController.AddNameToRecent(name);
			this.fillRecentList();
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x000189D1 File Offset: 0x00016BD1
		private void addNameToRecipients(string name)
		{
			if (!this.recipients.Contains(name) && this.recipients.Count < 60)
			{
				this.recipients.Add(name);
				this.populateToList();
			}
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x0017A0DC File Offset: 0x001782DC
		private void populateToList()
		{
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			foreach (string text in this.recipients)
			{
				list.Add(new CustomSelfDrawPanel.CSDListItem
				{
					Text = text
				});
			}
			this.newMail_ToList.populate(list);
			this.updateSendButton();
		}

		// Token: 0x060017A3 RID: 6051 RVA: 0x0017A154 File Offset: 0x00178354
		private void populateToFromCurrentMail()
		{
			this.recipients.Clear();
			MailThreadListItem mailThreadListItem = (MailThreadListItem)this.mailController.storedThreadHeaders[this.selectedMailThreadID];
			if (mailThreadListItem != null)
			{
				if (mailThreadListItem.otherUser != null)
				{
					this.recipients.AddRange(mailThreadListItem.otherUser);
				}
				this.tbSubject.Text = mailThreadListItem.subject;
			}
			this.populateToList();
		}

		// Token: 0x060017A4 RID: 6052 RVA: 0x00018A02 File Offset: 0x00016C02
		private void tbMain_TextChanged(object sender, EventArgs e)
		{
			this.flagUpdateSendButton();
		}

		// Token: 0x060017A5 RID: 6053 RVA: 0x00018A02 File Offset: 0x00016C02
		private void tbSubject_TextChanged(object sender, EventArgs e)
		{
			this.flagUpdateSendButton();
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x00018A0A File Offset: 0x00016C0A
		private void newMail_ToLineClicked(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.newMail_removeRecipient.Enabled = true;
				return;
			}
			this.newMail_removeRecipient.Enabled = false;
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0017A1BC File Offset: 0x001783BC
		private void removeNameFromRecipients()
		{
			CustomSelfDrawPanel.CSDListItem selectedItem = this.newMail_ToList.getSelectedItem();
			if (selectedItem == null)
			{
				return;
			}
			string text = selectedItem.Text;
			if (this.recipients.Contains(text))
			{
				this.recipients.Remove(text);
				this.populateToList();
				if (this.recipients.Count == 0)
				{
					this.newMail_removeRecipient.Enabled = false;
				}
			}
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x00018A28 File Offset: 0x00016C28
		private void openNewAttachmentsPopup()
		{
			if (this.attachmentWindow != null)
			{
				this.attachmentWindow.display(true, null, 0, 0);
			}
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x00018A41 File Offset: 0x00016C41
		public void closeAttachmentsPopup(bool clearContents)
		{
			if (this.attachmentWindow != null)
			{
				if (clearContents)
				{
					this.attachmentWindow.clearContents(true);
				}
				this.attachmentWindow.closeControl(true);
			}
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x0017A21C File Offset: 0x0017841C
		private void tbNewFolder_TextChanged(object sender, EventArgs e)
		{
			if (this.mailController.DoesFolderAlreadyExist(this.tbNewFolder.Text))
			{
				this.mailList_createFolderOK.Enabled = false;
				return;
			}
			this.mailList_createFolderOK.Enabled = (this.tbNewFolder.Text.Length > 0);
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x00018231 File Offset: 0x00016431
		private void tbNewFolder_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
			}
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x000187D3 File Offset: 0x000169D3
		private void tbUserFilter_TextChanged(object sender, EventArgs e)
		{
			this.repopulateTable();
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x00018A66 File Offset: 0x00016C66
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x00018A76 File Offset: 0x00016C76
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060017AF RID: 6063 RVA: 0x00018A86 File Offset: 0x00016C86
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y, false, true);
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x00018A9A File Offset: 0x00016C9A
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x00018AA7 File Offset: 0x00016CA7
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x00018AB5 File Offset: 0x00016CB5
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x00018AC2 File Offset: 0x00016CC2
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x00018ACF File Offset: 0x00016CCF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x0017A26C File Offset: 0x0017846C
		private void InitializeComponent()
		{
			this.tbMain = new TextBox();
			this.tbSubject = new TextBox();
			this.tbFindInput = new TextBox();
			this.tbNewFolder = new TextBox();
			this.tbUserFilter = new TextBox();
			base.SuspendLayout();
			this.tbMain.BackColor = Color.FromArgb(235, 245, 253);
			this.tbMain.BorderStyle = BorderStyle.None;
			this.tbMain.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbMain.ForeColor = global::ARGBColors.Black;
			this.tbMain.Location = new Point(191, 86);
			this.tbMain.MaxLength = 6000;
			this.tbMain.Multiline = true;
			this.tbMain.Name = "tbMain";
			this.tbMain.ScrollBars = ScrollBars.Vertical;
			this.tbMain.Size = new Size(573, 468);
			this.tbMain.TabIndex = 1;
			this.tbMain.TextChanged += this.tbMain_TextChanged;
			this.tbSubject.BackColor = Color.FromArgb(247, 252, 254);
			this.tbSubject.BorderStyle = BorderStyle.None;
			this.tbSubject.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbSubject.ForeColor = global::ARGBColors.Black;
			this.tbSubject.Location = new Point(98, 58);
			this.tbSubject.MaxLength = 150;
			this.tbSubject.Name = "tbSubject";
			this.tbSubject.Size = new Size(657, 13);
			this.tbSubject.TabIndex = 0;
			this.tbSubject.TextChanged += this.tbSubject_TextChanged;
			this.tbFindInput.BackColor = Color.FromArgb(247, 252, 254);
			this.tbFindInput.ForeColor = Color.FromArgb(0, 0, 0);
			this.tbFindInput.Location = new Point(799, 187);
			this.tbFindInput.MaxLength = 50;
			this.tbFindInput.Name = "tbFindInput";
			this.tbFindInput.Size = new Size(160, 20);
			this.tbFindInput.TabIndex = 11;
			this.tbFindInput.TextChanged += this.tbFindInput_TextChanged;
			this.tbFindInput.KeyUp += this.tbFindInput_KeyUp;
			this.tbFindInput.KeyPress += this.tbFindInput_KeyPress;
			this.tbNewFolder.BackColor = Color.FromArgb(247, 252, 254);
			this.tbNewFolder.ForeColor = Color.FromArgb(0, 0, 0);
			this.tbNewFolder.Location = new Point(427, 249);
			this.tbNewFolder.MaxLength = 19;
			this.tbNewFolder.Name = "tbNewFolder";
			this.tbNewFolder.Size = new Size(137, 20);
			this.tbNewFolder.TabIndex = 12;
			this.tbNewFolder.Visible = false;
			this.tbNewFolder.TextChanged += this.tbNewFolder_TextChanged;
			this.tbNewFolder.KeyPress += this.tbNewFolder_KeyPress;
			this.tbUserFilter.BackColor = Color.FromArgb(247, 252, 254);
			this.tbUserFilter.ForeColor = Color.FromArgb(0, 0, 0);
			this.tbUserFilter.Location = new Point(799, 480);
			this.tbUserFilter.MaxLength = 50;
			this.tbUserFilter.Name = "tbUserFilter";
			this.tbUserFilter.Size = new Size(160, 20);
			this.tbUserFilter.TabIndex = 13;
			this.tbUserFilter.TextChanged += this.tbUserFilter_TextChanged;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.tbUserFilter);
			base.Controls.Add(this.tbNewFolder);
			base.Controls.Add(this.tbFindInput);
			base.Controls.Add(this.tbSubject);
			base.Controls.Add(this.tbMain);
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "MailScreen";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002763 RID: 10083
		private const int flashFolderSpeed = 6;

		// Token: 0x04002764 RID: 10084
		public readonly MailManager mailController;

		// Token: 0x04002765 RID: 10085
		private int lastMailLineClicked = -1;

		// Token: 0x04002766 RID: 10086
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002767 RID: 10087
		private CustomSelfDrawPanel.CSDExtendingPanel mainBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002768 RID: 10088
		private CustomSelfDrawPanel.CSDArea mainHeaderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002769 RID: 10089
		private CustomSelfDrawPanel.CSDArea mainBodyArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400276A RID: 10090
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400276B RID: 10091
		private CustomSelfDrawPanel.CSDLabel headerLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400276C RID: 10092
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400276D RID: 10093
		private CustomSelfDrawPanel.CSDButton dockButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400276E RID: 10094
		private CustomSelfDrawPanel.CSDArea mailListArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400276F RID: 10095
		private CustomSelfDrawPanel.CSDArea newMailArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002770 RID: 10096
		private CustomSelfDrawPanel.CSDArea mailThreadArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002771 RID: 10097
		private CustomSelfDrawPanel.CSDArea mailCreateFolderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002772 RID: 10098
		private CustomSelfDrawPanel.CSDArea mailList_folderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002773 RID: 10099
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailList_folderHeaderImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002774 RID: 10100
		private CustomSelfDrawPanel.CSDLabel mailList_folderHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002775 RID: 10101
		private CustomSelfDrawPanel.CSDImage mailList_folderShadowTR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002776 RID: 10102
		private CustomSelfDrawPanel.CSDImage mailList_folderShadowR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002777 RID: 10103
		private CustomSelfDrawPanel.CSDImage mailList_folderShadowBR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002778 RID: 10104
		private CustomSelfDrawPanel.CSDImage mailList_folderShadowB = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002779 RID: 10105
		private CustomSelfDrawPanel.CSDImage mailList_folderShadowBL = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400277A RID: 10106
		private MailScreen.MailFolderLine mailList_folderLine01 = new MailScreen.MailFolderLine();

		// Token: 0x0400277B RID: 10107
		private MailScreen.MailFolderLine mailList_folderLine02 = new MailScreen.MailFolderLine();

		// Token: 0x0400277C RID: 10108
		private MailScreen.MailFolderLine mailList_folderLine03 = new MailScreen.MailFolderLine();

		// Token: 0x0400277D RID: 10109
		private MailScreen.MailFolderLine mailList_folderLine04 = new MailScreen.MailFolderLine();

		// Token: 0x0400277E RID: 10110
		private MailScreen.MailFolderLine mailList_folderLine05 = new MailScreen.MailFolderLine();

		// Token: 0x0400277F RID: 10111
		private MailScreen.MailFolderLine mailList_folderLine06 = new MailScreen.MailFolderLine();

		// Token: 0x04002780 RID: 10112
		private MailScreen.MailFolderLine mailList_folderLine07 = new MailScreen.MailFolderLine();

		// Token: 0x04002781 RID: 10113
		private MailScreen.MailFolderLine mailList_folderLine08 = new MailScreen.MailFolderLine();

		// Token: 0x04002782 RID: 10114
		private MailScreen.MailFolderLine mailList_folderLine09 = new MailScreen.MailFolderLine();

		// Token: 0x04002783 RID: 10115
		private MailScreen.MailFolderLine mailList_folderLine10 = new MailScreen.MailFolderLine();

		// Token: 0x04002784 RID: 10116
		private MailScreen.MailFolderLine mailList_folderLine11 = new MailScreen.MailFolderLine();

		// Token: 0x04002785 RID: 10117
		private MailScreen.MailFolderLine mailList_folderLine12 = new MailScreen.MailFolderLine();

		// Token: 0x04002786 RID: 10118
		private MailScreen.MailFolderLine mailList_folderLine13 = new MailScreen.MailFolderLine();

		// Token: 0x04002787 RID: 10119
		private MailScreen.MailFolderLine mailList_folderLine14 = new MailScreen.MailFolderLine();

		// Token: 0x04002788 RID: 10120
		private MailScreen.MailFolderLine mailList_folderLine15 = new MailScreen.MailFolderLine();

		// Token: 0x04002789 RID: 10121
		private MailScreen.MailFolderLine mailList_folderLine16 = new MailScreen.MailFolderLine();

		// Token: 0x0400278A RID: 10122
		private MailScreen.MailFolderLine mailList_folderLine17 = new MailScreen.MailFolderLine();

		// Token: 0x0400278B RID: 10123
		private MailScreen.MailFolderLine mailList_folderLine18 = new MailScreen.MailFolderLine();

		// Token: 0x0400278C RID: 10124
		private MailScreen.MailFolderLine mailList_folderLine19 = new MailScreen.MailFolderLine();

		// Token: 0x0400278D RID: 10125
		private MailScreen.MailFolderLine mailList_folderLine20 = new MailScreen.MailFolderLine();

		// Token: 0x0400278E RID: 10126
		private MailScreen.MailFolderLine mailList_folderLine21 = new MailScreen.MailFolderLine();

		// Token: 0x0400278F RID: 10127
		private MailScreen.MailFolderLine mailList_folderLine22 = new MailScreen.MailFolderLine();

		// Token: 0x04002790 RID: 10128
		private MailScreen.MailFolderLine mailList_folderLine23 = new MailScreen.MailFolderLine();

		// Token: 0x04002791 RID: 10129
		private MailScreen.MailFolderLine mailList_folderLine24 = new MailScreen.MailFolderLine();

		// Token: 0x04002792 RID: 10130
		private MailScreen.MailFolderLine mailList_folderLine25 = new MailScreen.MailFolderLine();

		// Token: 0x04002793 RID: 10131
		private MailScreen.MailFolderLine mailList_folderLine26 = new MailScreen.MailFolderLine();

		// Token: 0x04002794 RID: 10132
		private MailScreen.MailFolderLine mailList_folderLine27 = new MailScreen.MailFolderLine();

		// Token: 0x04002795 RID: 10133
		private CustomSelfDrawPanel.CSDArea mailList_listArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002796 RID: 10134
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailList_mainHeaderImage1 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002797 RID: 10135
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailList_mainHeaderImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002798 RID: 10136
		private CustomSelfDrawPanel.CSDLabel mailList_mainHeaderLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002799 RID: 10137
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailList_mainHeaderImage3 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400279A RID: 10138
		private CustomSelfDrawPanel.CSDLabel mailList_mainHeaderLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400279B RID: 10139
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailList_mainHeaderImage4 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400279C RID: 10140
		private CustomSelfDrawPanel.CSDLabel mailList_mainHeaderLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400279D RID: 10141
		private CustomSelfDrawPanel.CSDImage mailList_listShadowTR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400279E RID: 10142
		private CustomSelfDrawPanel.CSDImage mailList_listShadowR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400279F RID: 10143
		private CustomSelfDrawPanel.CSDImage mailList_listShadowBR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027A0 RID: 10144
		private CustomSelfDrawPanel.CSDImage mailList_listShadowB = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027A1 RID: 10145
		private CustomSelfDrawPanel.CSDImage mailList_listShadowBL = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027A2 RID: 10146
		private MailScreen.MailListLine mailList_listLine01 = new MailScreen.MailListLine();

		// Token: 0x040027A3 RID: 10147
		private MailScreen.MailListLine mailList_listLine02 = new MailScreen.MailListLine();

		// Token: 0x040027A4 RID: 10148
		private MailScreen.MailListLine mailList_listLine03 = new MailScreen.MailListLine();

		// Token: 0x040027A5 RID: 10149
		private MailScreen.MailListLine mailList_listLine04 = new MailScreen.MailListLine();

		// Token: 0x040027A6 RID: 10150
		private MailScreen.MailListLine mailList_listLine05 = new MailScreen.MailListLine();

		// Token: 0x040027A7 RID: 10151
		private MailScreen.MailListLine mailList_listLine06 = new MailScreen.MailListLine();

		// Token: 0x040027A8 RID: 10152
		private MailScreen.MailListLine mailList_listLine07 = new MailScreen.MailListLine();

		// Token: 0x040027A9 RID: 10153
		private MailScreen.MailListLine mailList_listLine08 = new MailScreen.MailListLine();

		// Token: 0x040027AA RID: 10154
		private MailScreen.MailListLine mailList_listLine09 = new MailScreen.MailListLine();

		// Token: 0x040027AB RID: 10155
		private MailScreen.MailListLine mailList_listLine10 = new MailScreen.MailListLine();

		// Token: 0x040027AC RID: 10156
		private MailScreen.MailListLine mailList_listLine11 = new MailScreen.MailListLine();

		// Token: 0x040027AD RID: 10157
		private MailScreen.MailListLine mailList_listLine12 = new MailScreen.MailListLine();

		// Token: 0x040027AE RID: 10158
		private MailScreen.MailListLine mailList_listLine13 = new MailScreen.MailListLine();

		// Token: 0x040027AF RID: 10159
		private MailScreen.MailListLine mailList_listLine14 = new MailScreen.MailListLine();

		// Token: 0x040027B0 RID: 10160
		private MailScreen.MailListLine mailList_listLine15 = new MailScreen.MailListLine();

		// Token: 0x040027B1 RID: 10161
		private MailScreen.MailListLine mailList_listLine16 = new MailScreen.MailListLine();

		// Token: 0x040027B2 RID: 10162
		private MailScreen.MailListLine mailList_listLine17 = new MailScreen.MailListLine();

		// Token: 0x040027B3 RID: 10163
		private MailScreen.MailListLine mailList_listLine18 = new MailScreen.MailListLine();

		// Token: 0x040027B4 RID: 10164
		private MailScreen.MailListLine mailList_listLine19 = new MailScreen.MailListLine();

		// Token: 0x040027B5 RID: 10165
		private MailScreen.MailListLine mailList_listLine20 = new MailScreen.MailListLine();

		// Token: 0x040027B6 RID: 10166
		private MailScreen.MailListLine mailList_listLine21 = new MailScreen.MailListLine();

		// Token: 0x040027B7 RID: 10167
		private MailScreen.MailListLine mailList_listLine22 = new MailScreen.MailListLine();

		// Token: 0x040027B8 RID: 10168
		private MailScreen.MailListLine mailList_listLine23 = new MailScreen.MailListLine();

		// Token: 0x040027B9 RID: 10169
		private MailScreen.MailListLine mailList_listLine24 = new MailScreen.MailListLine();

		// Token: 0x040027BA RID: 10170
		private MailScreen.MailListLine mailList_listLine25 = new MailScreen.MailListLine();

		// Token: 0x040027BB RID: 10171
		private MailScreen.MailListLine mailList_listLine26 = new MailScreen.MailListLine();

		// Token: 0x040027BC RID: 10172
		private MailScreen.MailListLine mailList_listLine27 = new MailScreen.MailListLine();

		// Token: 0x040027BD RID: 10173
		private CustomSelfDrawPanel.CSDVertScrollBar mailList_scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040027BE RID: 10174
		private CustomSelfDrawPanel.CSDImage mailList_scrollTabLines = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027BF RID: 10175
		private CustomSelfDrawPanel.CSDButton mailList_upArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027C0 RID: 10176
		private CustomSelfDrawPanel.CSDButton mailList_downArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027C1 RID: 10177
		private CustomSelfDrawPanel.CSDControl mailList_mouseWheelArea = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040027C2 RID: 10178
		private CustomSelfDrawPanel.CSDLabel mailList_MoveFolderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027C3 RID: 10179
		private CustomSelfDrawPanel.CSDButton mailList_MoveFolderCancel = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027C4 RID: 10180
		private CustomSelfDrawPanel.CSDArea mailList_iconArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040027C5 RID: 10181
		private CustomSelfDrawPanel.CSDButton mailList_iconNewMail = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027C6 RID: 10182
		private CustomSelfDrawPanel.CSDImage mailList_iconSelected = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027C7 RID: 10183
		private CustomSelfDrawPanel.CSDImage mailList_iconSelectedIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027C8 RID: 10184
		private CustomSelfDrawPanel.CSDLabel mailList_iconSelectedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027C9 RID: 10185
		private CustomSelfDrawPanel.CSDImage mailList_iconSelectedBack = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027CA RID: 10186
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedOpen = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027CB RID: 10187
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedUnread = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027CC RID: 10188
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedRead = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027CD RID: 10189
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedBlockPlayer = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027CE RID: 10190
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedMoveThread = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027CF RID: 10191
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedArchive = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027D0 RID: 10192
		private CustomSelfDrawPanel.CSDButton mailList_iconSelectedDelete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027D1 RID: 10193
		private CustomSelfDrawPanel.CSDButton mailList_manageBlocked = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027D2 RID: 10194
		private CustomSelfDrawPanel.CSDLabel mailList_userFilterLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027D3 RID: 10195
		private CustomSelfDrawPanel.CSDImage mailList_createFolderHeader = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027D4 RID: 10196
		private CustomSelfDrawPanel.CSDLabel mailList_createFolderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027D5 RID: 10197
		private CustomSelfDrawPanel.CSDImage mailList_createFolderBack = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027D6 RID: 10198
		private CustomSelfDrawPanel.CSDButton mailList_createFolderOK = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027D7 RID: 10199
		private CustomSelfDrawPanel.CSDButton mailList_createFolderCancel = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040027D8 RID: 10200
		private CustomSelfDrawPanel.CSDArea mailThread_listArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040027D9 RID: 10201
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailThread_mainHeaderImage1 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040027DA RID: 10202
		private CustomSelfDrawPanel.CSDLabel mailThread_mainHeaderLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027DB RID: 10203
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailThread_mainHeaderImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040027DC RID: 10204
		private CustomSelfDrawPanel.CSDLabel mailThread_mainHeaderLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027DD RID: 10205
		private CustomSelfDrawPanel.CSDHorzExtendingPanel mailThread_mainHeaderImage3 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040027DE RID: 10206
		private CustomSelfDrawPanel.CSDLabel mailThread_mainHeaderLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040027DF RID: 10207
		private CustomSelfDrawPanel.CSDImage mailThread_listShadowTR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027E0 RID: 10208
		private CustomSelfDrawPanel.CSDImage mailThread_listShadowR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027E1 RID: 10209
		private CustomSelfDrawPanel.CSDImage mailThread_listShadowBR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027E2 RID: 10210
		private CustomSelfDrawPanel.CSDImage mailThread_listShadowB = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027E3 RID: 10211
		private CustomSelfDrawPanel.CSDImage mailThread_listShadowBL = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040027E4 RID: 10212
		private MailScreen.MailThreadLine mailThread_listLine01 = new MailScreen.MailThreadLine();

		// Token: 0x040027E5 RID: 10213
		private MailScreen.MailThreadLine mailThread_listLine02 = new MailScreen.MailThreadLine();

		// Token: 0x040027E6 RID: 10214
		private MailScreen.MailThreadLine mailThread_listLine03 = new MailScreen.MailThreadLine();

		// Token: 0x040027E7 RID: 10215
		private MailScreen.MailThreadLine mailThread_listLine04 = new MailScreen.MailThreadLine();

		// Token: 0x040027E8 RID: 10216
		private MailScreen.MailThreadLine mailThread_listLine05 = new MailScreen.MailThreadLine();

		// Token: 0x040027E9 RID: 10217
		private MailScreen.MailThreadLine mailThread_listLine06 = new MailScreen.MailThreadLine();

		// Token: 0x040027EA RID: 10218
		private MailScreen.MailThreadLine mailThread_listLine07 = new MailScreen.MailThreadLine();

		// Token: 0x040027EB RID: 10219
		private MailScreen.MailThreadLine mailThread_listLine08 = new MailScreen.MailThreadLine();

		// Token: 0x040027EC RID: 10220
		private MailScreen.MailThreadLine mailThread_listLine09 = new MailScreen.MailThreadLine();

		// Token: 0x040027ED RID: 10221
		private MailScreen.MailThreadLine mailThread_listLine10 = new MailScreen.MailThreadLine();

		// Token: 0x040027EE RID: 10222
		private MailScreen.MailThreadLine mailThread_listLine11 = new MailScreen.MailThreadLine();

		// Token: 0x040027EF RID: 10223
		private MailScreen.MailThreadLine mailThread_listLine12 = new MailScreen.MailThreadLine();

		// Token: 0x040027F0 RID: 10224
		private MailScreen.MailThreadLine mailThread_listLine13 = new MailScreen.MailThreadLine();

		// Token: 0x040027F1 RID: 10225
		private MailScreen.MailThreadLine mailThread_listLine14 = new MailScreen.MailThreadLine();

		// Token: 0x040027F2 RID: 10226
		private MailScreen.MailThreadLine mailThread_listLine15 = new MailScreen.MailThreadLine();

		// Token: 0x040027F3 RID: 10227
		private MailScreen.MailThreadLine mailThread_listLine16 = new MailScreen.MailThreadLine();

		// Token: 0x040027F4 RID: 10228
		private MailScreen.MailThreadLine mailThread_listLine17 = new MailScreen.MailThreadLine();

		// Token: 0x040027F5 RID: 10229
		private MailScreen.MailThreadLine mailThread_listLine18 = new MailScreen.MailThreadLine();

		// Token: 0x040027F6 RID: 10230
		private MailScreen.MailThreadLine mailThread_listLine19 = new MailScreen.MailThreadLine();

		// Token: 0x040027F7 RID: 10231
		private MailScreen.MailThreadLine mailThread_listLine20 = new MailScreen.MailThreadLine();

		// Token: 0x040027F8 RID: 10232
		private MailScreen.MailThreadLine mailThread_listLine21 = new MailScreen.MailThreadLine();

		// Token: 0x040027F9 RID: 10233
		private MailScreen.MailThreadLine mailThread_listLine22 = new MailScreen.MailThreadLine();

		// Token: 0x040027FA RID: 10234
		private MailScreen.MailThreadLine mailThread_listLine23 = new MailScreen.MailThreadLine();

		// Token: 0x040027FB RID: 10235
		private MailScreen.MailThreadLine mailThread_listLine24 = new MailScreen.MailThreadLine();

		// Token: 0x040027FC RID: 10236
		private MailScreen.MailThreadLine mailThread_listLine25 = new MailScreen.MailThreadLine();

		// Token: 0x040027FD RID: 10237
		private MailScreen.MailThreadLine mailThread_listLine26 = new MailScreen.MailThreadLine();

		// Token: 0x040027FE RID: 10238
		private MailScreen.MailThreadLine mailThread_listLine27 = new MailScreen.MailThreadLine();

		// Token: 0x040027FF RID: 10239
		private CustomSelfDrawPanel.CSDControl mailThread_mouseWheelArea = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002800 RID: 10240
		private CustomSelfDrawPanel.CSDVertScrollBar mailThread_scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002801 RID: 10241
		private CustomSelfDrawPanel.CSDImage mailThread_scrollTabLines = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002802 RID: 10242
		private CustomSelfDrawPanel.CSDButton mailThread_upArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002803 RID: 10243
		private CustomSelfDrawPanel.CSDButton mailThread_downArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002804 RID: 10244
		private CustomSelfDrawPanel.CSDFill mailThread_mailHeaderBack = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002805 RID: 10245
		private CustomSelfDrawPanel.CSDFill mailThread_mailBodyBack = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002806 RID: 10246
		private CustomSelfDrawPanel.CSDImage mailThread_fromShield = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002807 RID: 10247
		private CustomSelfDrawPanel.CSDLabel mailThread_mailHeaderFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002808 RID: 10248
		private CustomSelfDrawPanel.CSDLabel mailThread_mailHeaderFromNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002809 RID: 10249
		private CustomSelfDrawPanel.CSDLabel mailThread_mailHeaderDateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400280A RID: 10250
		private CustomSelfDrawPanel.CSDLabel mailThread_mailHeaderDateValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400280B RID: 10251
		private CustomSelfDrawPanel.CSDScrollLabel mailThread_mailBodyText = new CustomSelfDrawPanel.CSDScrollLabel();

		// Token: 0x0400280C RID: 10252
		private CustomSelfDrawPanel.CSDVertScrollBar mailThreadBody_scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400280D RID: 10253
		private CustomSelfDrawPanel.CSDImage mailThreadBody_scrollTabLines = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400280E RID: 10254
		private CustomSelfDrawPanel.CSDButton mailThreadBody_upArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400280F RID: 10255
		private CustomSelfDrawPanel.CSDButton mailThreadBody_downArrow = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002810 RID: 10256
		private CustomSelfDrawPanel.CSDControl mailThreadBody_mouseWheelArea = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002811 RID: 10257
		private CustomSelfDrawPanel.CSDArea mailThread_iconArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002812 RID: 10258
		private CustomSelfDrawPanel.CSDButton mailThread_iconBack = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002813 RID: 10259
		private CustomSelfDrawPanel.CSDImage mailThread_iconSelected = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002814 RID: 10260
		private CustomSelfDrawPanel.CSDImage mailThread_iconSelectedIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002815 RID: 10261
		private CustomSelfDrawPanel.CSDLabel mailThread_iconSelectedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002816 RID: 10262
		private CustomSelfDrawPanel.CSDImage mailThread_iconSelectedBack = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002817 RID: 10263
		private CustomSelfDrawPanel.CSDButton mailThread_iconSelectedView = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002818 RID: 10264
		private CustomSelfDrawPanel.CSDButton mailThread_iconSelectedReply = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002819 RID: 10265
		private CustomSelfDrawPanel.CSDButton mailThread_iconSelectedForward = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400281A RID: 10266
		private CustomSelfDrawPanel.CSDButton mailThread_iconSelectedBlockPoster = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400281B RID: 10267
		private CustomSelfDrawPanel.CSDButton mailThread_iconSelectedReportMail = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400281C RID: 10268
		private CustomSelfDrawPanel.CSDButton mailThread_openAttachments = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400281D RID: 10269
		private CustomSelfDrawPanel.CSDArea newMail_newMailArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400281E RID: 10270
		private CustomSelfDrawPanel.CSDFill newMail_mailHeaderBack = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400281F RID: 10271
		private CustomSelfDrawPanel.CSDFill newMail_mailBodyBack = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002820 RID: 10272
		private CustomSelfDrawPanel.CSDImage newMail_bodyShadowTR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002821 RID: 10273
		private CustomSelfDrawPanel.CSDImage newMail_bodyShadowR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002822 RID: 10274
		private CustomSelfDrawPanel.CSDImage newMail_bodyShadowBR = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002823 RID: 10275
		private CustomSelfDrawPanel.CSDImage newMail_bodyShadowB = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002824 RID: 10276
		private CustomSelfDrawPanel.CSDImage newMail_bodyShadowBL = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002825 RID: 10277
		private CustomSelfDrawPanel.CSDLabel newMail_ToLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002826 RID: 10278
		private CustomSelfDrawPanel.CSDLabel newMail_SubjectLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002827 RID: 10279
		private CustomSelfDrawPanel.CSDLine newMail_separater = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04002828 RID: 10280
		private CustomSelfDrawPanel.CSDLine newMail_separater2 = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04002829 RID: 10281
		private CustomSelfDrawPanel.CSDListBox newMail_ToList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x0400282A RID: 10282
		private CustomSelfDrawPanel.CSDImage newMail_breakbar = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400282B RID: 10283
		private CustomSelfDrawPanel.CSDHorzExtendingPanel newMail_SubjectBorder = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400282C RID: 10284
		private CustomSelfDrawPanel.CSDArea newMail_iconArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400282D RID: 10285
		private CustomSelfDrawPanel.CSDButton newMail_iconBackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400282E RID: 10286
		private CustomSelfDrawPanel.CSDArea newMail_iconTab1Area = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400282F RID: 10287
		private CustomSelfDrawPanel.CSDArea newMail_iconTab2Area = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002830 RID: 10288
		private CustomSelfDrawPanel.CSDArea newMail_iconTab3Area = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002831 RID: 10289
		private CustomSelfDrawPanel.CSDArea newMail_iconTab4Area = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002832 RID: 10290
		private CustomSelfDrawPanel.CSDButton newMail_iconTab1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002833 RID: 10291
		private CustomSelfDrawPanel.CSDButton newMail_iconTab2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002834 RID: 10292
		private CustomSelfDrawPanel.CSDButton newMail_iconTab3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002835 RID: 10293
		private CustomSelfDrawPanel.CSDButton newMail_iconTab4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002836 RID: 10294
		private CustomSelfDrawPanel.CSDImage newMail_iconBackground = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002837 RID: 10295
		private CustomSelfDrawPanel.CSDListBox newMail_iconFindList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x04002838 RID: 10296
		private CustomSelfDrawPanel.CSDButton newMail_iconFindAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002839 RID: 10297
		private CustomSelfDrawPanel.CSDButton newMail_iconFindFavouritesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400283A RID: 10298
		private CustomSelfDrawPanel.CSDListBox newMail_iconRecentList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x0400283B RID: 10299
		private CustomSelfDrawPanel.CSDButton newMail_iconRecentAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400283C RID: 10300
		private CustomSelfDrawPanel.CSDButton newMail_iconRecentFavouritesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400283D RID: 10301
		private CustomSelfDrawPanel.CSDListBox newMail_iconFavouritesList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x0400283E RID: 10302
		private CustomSelfDrawPanel.CSDButton newMail_iconFavouritesAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400283F RID: 10303
		private CustomSelfDrawPanel.CSDButton newMail_iconFavouritesRemoveButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002840 RID: 10304
		private CustomSelfDrawPanel.CSDListBox newMail_iconKnownList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x04002841 RID: 10305
		private CustomSelfDrawPanel.CSDButton newMail_iconKnownAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002842 RID: 10306
		private CustomSelfDrawPanel.CSDButton newMail_iconKnownFavouritesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002843 RID: 10307
		private CustomSelfDrawPanel.CSDButton newMail_removeRecipient = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002844 RID: 10308
		private CustomSelfDrawPanel.CSDButton newMail_addAttachments = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002845 RID: 10309
		private CustomSelfDrawPanel.CSDButton newMail_iconSendMail = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002846 RID: 10310
		private static bool fromFaction;

		// Token: 0x04002847 RID: 10311
		private static bool factionClose;

		// Token: 0x04002848 RID: 10312
		private MailScreenPanel m_parent;

		// Token: 0x04002849 RID: 10313
		private int currentSearchTab = -1;

		// Token: 0x0400284A RID: 10314
		private List<long> selectedMailThreadIDList = new List<long>();

		// Token: 0x0400284B RID: 10315
		private long selectedMailThreadID = -1000L;

		// Token: 0x0400284C RID: 10316
		private long selectedMailItemID = -1000L;

		// Token: 0x0400284D RID: 10317
		private string selectedUserName = "";

		// Token: 0x0400284E RID: 10318
		private bool mailSent;

		// Token: 0x0400284F RID: 10319
		private DateTime keyScrollTimer = DateTime.MinValue;

		// Token: 0x04002850 RID: 10320
		private int flashFolderCount;

		// Token: 0x04002851 RID: 10321
		private MyMessageBoxPopUp removeFolderPopUp;

		// Token: 0x04002852 RID: 10322
		private MailScreen.MailFolderLine m_flashFolderLine;

		// Token: 0x04002853 RID: 10323
		private MyMessageBoxPopUp DeleteThreadPopUp;

		// Token: 0x04002854 RID: 10324
		private bool m_moveThreadMode;

		// Token: 0x04002855 RID: 10325
		private bool reportButtonAvailable;

		// Token: 0x04002856 RID: 10326
		private bool blockButtonAvailable;

		// Token: 0x04002857 RID: 10327
		private string lastSubject = "";

		// Token: 0x04002858 RID: 10328
		private int currentThreadLength;

		// Token: 0x04002859 RID: 10329
		private bool inDisplayThread;

		// Token: 0x0400285A RID: 10330
		private List<MailLink> outputListExtUnity = new List<MailLink>();

		// Token: 0x0400285B RID: 10331
		private bool proclamation;

		// Token: 0x0400285C RID: 10332
		private int specialType;

		// Token: 0x0400285D RID: 10333
		private int specialArea;

		// Token: 0x0400285E RID: 10334
		private bool doUpdateSendButton;

		// Token: 0x0400285F RID: 10335
		private long sendThreadID = -1L;

		// Token: 0x04002860 RID: 10336
		private bool sendAsForward;

		// Token: 0x04002861 RID: 10337
		private DateTime mailLineDoubleClick = DateTime.MinValue;

		// Token: 0x04002862 RID: 10338
		private DateTime lastClicked = DateTime.MinValue;

		// Token: 0x04002863 RID: 10339
		private int lastMailItemClicked = -1;

		// Token: 0x04002864 RID: 10340
		private int lastLineClicked = -1;

		// Token: 0x04002865 RID: 10341
		private List<string> recipients = new List<string>();

		// Token: 0x04002866 RID: 10342
		private MailAttachmentPopup attachmentWindow;

		// Token: 0x04002867 RID: 10343
		private DockableControl dockableControl;

		// Token: 0x04002868 RID: 10344
		private IContainer components;

		// Token: 0x04002869 RID: 10345
		private TextBox tbMain;

		// Token: 0x0400286A RID: 10346
		private TextBox tbSubject;

		// Token: 0x0400286B RID: 10347
		private TextBox tbFindInput;

		// Token: 0x0400286C RID: 10348
		private TextBox tbNewFolder;

		// Token: 0x0400286D RID: 10349
		private TextBox tbUserFilter;

		// Token: 0x02000226 RID: 550
		private class MailFolderLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170001B8 RID: 440
			// (set) Token: 0x060017B6 RID: 6070 RVA: 0x00018AEE File Offset: 0x00016CEE
			public Color BodyColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.bodyColor != value)
						{
							this.main.invalidate();
						}
						this.main.FillColor = value;
					}
					this.bodyColor = value;
				}
			}

			// Token: 0x170001B9 RID: 441
			// (set) Token: 0x060017B7 RID: 6071 RVA: 0x00018B24 File Offset: 0x00016D24
			public Color LineColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.lineColor != value)
						{
							this.line.invalidate();
						}
						this.line.FillColor = value;
					}
					this.lineColor = value;
				}
			}

			// Token: 0x170001BA RID: 442
			// (set) Token: 0x060017B8 RID: 6072 RVA: 0x00018B5A File Offset: 0x00016D5A
			public Color OverColor
			{
				set
				{
					this.overColor = value;
				}
			}

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x060017B9 RID: 6073 RVA: 0x00018B63 File Offset: 0x00016D63
			public CustomSelfDrawPanel.CSDLabel Text
			{
				get
				{
					return this.label;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x060017BA RID: 6074 RVA: 0x00018B6B File Offset: 0x00016D6B
			public CustomSelfDrawPanel.CSDImage Icon
			{
				get
				{
					return this.icon;
				}
			}

			// Token: 0x060017BB RID: 6075 RVA: 0x0017A750 File Offset: 0x00178950
			public void reset()
			{
				this.bodyColor = CustomSelfDrawPanel.MailBodyColor;
				this.lineColor = CustomSelfDrawPanel.MailLineColor;
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
				this.icon.Image = null;
			}

			// Token: 0x060017BC RID: 6076 RVA: 0x0017A7A4 File Offset: 0x001789A4
			public void setup()
			{
				this.main.Size = new Size(this.Size.Width, this.Size.Height - 1);
				this.main.FillColor = this.bodyColor;
				this.line.Position = new Point(0, this.Size.Height - 1);
				this.line.Size = new Size(this.Size.Width, 1);
				this.line.FillColor = this.lineColor;
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseLeave));
				this.label.Position = new Point(19, 2);
				this.label.Size = new Size(this.Size.Width - 19, this.Size.Height - 4);
				this.label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.icon.Position = new Point(2, 0);
				base.addControl(this.main);
				base.addControl(this.line);
				this.main.addControl(this.label);
				this.main.addControl(this.icon);
				this.setupComplete = true;
			}

			// Token: 0x060017BD RID: 6077 RVA: 0x00018B73 File Offset: 0x00016D73
			private void mouseOver()
			{
				if (this.label.Text.Length > 0)
				{
					this.main.FillColor = this.overColor;
				}
			}

			// Token: 0x060017BE RID: 6078 RVA: 0x00018B99 File Offset: 0x00016D99
			private void mouseLeave()
			{
				this.main.FillColor = this.bodyColor;
			}

			// Token: 0x0400286E RID: 10350
			private bool setupComplete;

			// Token: 0x0400286F RID: 10351
			private CustomSelfDrawPanel.CSDFill main = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002870 RID: 10352
			private CustomSelfDrawPanel.CSDFill line = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002871 RID: 10353
			private CustomSelfDrawPanel.CSDLabel label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002872 RID: 10354
			private CustomSelfDrawPanel.CSDImage icon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002873 RID: 10355
			private Color bodyColor = CustomSelfDrawPanel.MailBodyColor;

			// Token: 0x04002874 RID: 10356
			private Color lineColor = CustomSelfDrawPanel.MailLineColor;

			// Token: 0x04002875 RID: 10357
			private Color overColor = CustomSelfDrawPanel.MailOverColor;
		}

		// Token: 0x02000227 RID: 551
		private class MailListLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170001BD RID: 445
			// (set) Token: 0x060017C0 RID: 6080 RVA: 0x00018BAC File Offset: 0x00016DAC
			public Color BodyColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.bodyColor != value)
						{
							this.main.invalidate();
						}
						this.main.FillColor = value;
					}
					this.bodyColor = value;
				}
			}

			// Token: 0x170001BE RID: 446
			// (set) Token: 0x060017C1 RID: 6081 RVA: 0x00018BE2 File Offset: 0x00016DE2
			public Color LineColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.lineColor != value)
						{
							this.line.invalidate();
						}
						this.line.FillColor = value;
					}
					this.lineColor = value;
				}
			}

			// Token: 0x170001BF RID: 447
			// (set) Token: 0x060017C2 RID: 6082 RVA: 0x00018C18 File Offset: 0x00016E18
			public Color OverColor
			{
				set
				{
					this.overColor = value;
				}
			}

			// Token: 0x170001C0 RID: 448
			// (set) Token: 0x060017C3 RID: 6083 RVA: 0x00018C21 File Offset: 0x00016E21
			public Color LineOverColor
			{
				set
				{
					this.lineOverColor = value;
				}
			}

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x060017C4 RID: 6084 RVA: 0x00018C2A File Offset: 0x00016E2A
			public CustomSelfDrawPanel.CSDLabel Subject
			{
				get
				{
					return this.subjectLabel;
				}
			}

			// Token: 0x170001C2 RID: 450
			// (set) Token: 0x060017C5 RID: 6085 RVA: 0x0017A964 File Offset: 0x00178B64
			public DateTime Date
			{
				set
				{
					if (this.Subject.Text.Length > 0 || this.Sender.Text.Length > 0)
					{
						this.dateLabel.Text = string.Concat(new string[]
						{
							value.ToShortDateString(),
							"  ",
							value.Hour.ToString("00"),
							":",
							value.Minute.ToString("00")
						});
					}
				}
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x060017C6 RID: 6086 RVA: 0x00018C32 File Offset: 0x00016E32
			public CustomSelfDrawPanel.CSDLabel DateLabel
			{
				get
				{
					return this.dateLabel;
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x060017C7 RID: 6087 RVA: 0x00018C3A File Offset: 0x00016E3A
			public CustomSelfDrawPanel.CSDLabel Sender
			{
				get
				{
					return this.senderLabel;
				}
			}

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x060017C8 RID: 6088 RVA: 0x00018C42 File Offset: 0x00016E42
			public CustomSelfDrawPanel.CSDImage Icon
			{
				get
				{
					return this.icon;
				}
			}

			// Token: 0x060017C9 RID: 6089 RVA: 0x0017A9F8 File Offset: 0x00178BF8
			public void reset()
			{
				this.bodyColor = CustomSelfDrawPanel.MailBodyColor;
				this.lineColor = CustomSelfDrawPanel.MailLineColor;
				this.overColor = CustomSelfDrawPanel.MailOverColor;
				this.lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
			}

			// Token: 0x060017CA RID: 6090 RVA: 0x0017AA54 File Offset: 0x00178C54
			public void setup()
			{
				this.main.Size = new Size(this.Size.Width, this.Size.Height - 1);
				this.main.FillColor = this.bodyColor;
				this.line.Position = new Point(0, this.Size.Height - 1);
				this.line.Size = new Size(this.Size.Width, 1);
				this.line.FillColor = this.lineColor;
				this.sep1.Position = new Point(21, 0);
				this.sep1.Size = new Size(1, this.Size.Height - 1);
				this.sep1.FillColor = this.lineColor;
				this.sep2.Position = new Point(262, 0);
				this.sep2.Size = new Size(1, this.Size.Height - 1);
				this.sep2.FillColor = this.lineColor;
				this.sep3.Position = new Point(382, 0);
				this.sep3.Size = new Size(1, this.Size.Height - 1);
				this.sep3.FillColor = this.lineColor;
				this.subjectLabel.Position = new Point(43, 2);
				this.subjectLabel.Size = new Size(219, this.Size.Height - 4);
				this.subjectLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.dateLabel.Position = new Point(265, 0);
				this.dateLabel.Size = new Size(118, this.Size.Height);
				this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.senderLabel.Position = new Point(385, 2);
				this.senderLabel.Size = new Size(this.Size.Width - 385, this.Size.Height - 4);
				this.senderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.icon.Position = new Point(23, 2);
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseLeave));
				base.addControl(this.main);
				base.addControl(this.line);
				base.addControl(this.sep1);
				base.addControl(this.sep2);
				base.addControl(this.sep3);
				this.main.addControl(this.subjectLabel);
				this.main.addControl(this.dateLabel);
				this.main.addControl(this.senderLabel);
				this.main.addControl(this.icon);
				this.setupComplete = true;
			}

			// Token: 0x060017CB RID: 6091 RVA: 0x0017AD5C File Offset: 0x00178F5C
			private void mouseOver()
			{
				if (this.subjectLabel.Text.Length > 0)
				{
					this.main.FillColor = this.overColor;
					this.line.FillColor = this.lineOverColor;
					this.sep1.FillColor = this.lineOverColor;
					this.sep2.FillColor = this.lineOverColor;
					this.sep3.FillColor = this.lineOverColor;
				}
			}

			// Token: 0x060017CC RID: 6092 RVA: 0x0017ADD4 File Offset: 0x00178FD4
			private void mouseLeave()
			{
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
				this.sep1.FillColor = this.lineColor;
				this.sep2.FillColor = this.lineColor;
				this.sep3.FillColor = this.lineColor;
			}

			// Token: 0x04002876 RID: 10358
			private bool setupComplete;

			// Token: 0x04002877 RID: 10359
			private CustomSelfDrawPanel.CSDFill main = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002878 RID: 10360
			private CustomSelfDrawPanel.CSDFill line = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002879 RID: 10361
			private CustomSelfDrawPanel.CSDLabel subjectLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400287A RID: 10362
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400287B RID: 10363
			private CustomSelfDrawPanel.CSDLabel senderLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400287C RID: 10364
			private CustomSelfDrawPanel.CSDImage icon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400287D RID: 10365
			private CustomSelfDrawPanel.CSDFill sep1 = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400287E RID: 10366
			private CustomSelfDrawPanel.CSDFill sep2 = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400287F RID: 10367
			private CustomSelfDrawPanel.CSDFill sep3 = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002880 RID: 10368
			private Color bodyColor = CustomSelfDrawPanel.MailBodyColor;

			// Token: 0x04002881 RID: 10369
			private Color lineColor = CustomSelfDrawPanel.MailLineColor;

			// Token: 0x04002882 RID: 10370
			private Color overColor = CustomSelfDrawPanel.MailOverColor;

			// Token: 0x04002883 RID: 10371
			private Color lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
		}

		// Token: 0x02000228 RID: 552
		private class MailThreadLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170001C6 RID: 454
			// (set) Token: 0x060017CE RID: 6094 RVA: 0x00018C4A File Offset: 0x00016E4A
			public Color BodyColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.bodyColor != value)
						{
							this.main.invalidate();
						}
						this.main.FillColor = value;
					}
					this.bodyColor = value;
				}
			}

			// Token: 0x170001C7 RID: 455
			// (set) Token: 0x060017CF RID: 6095 RVA: 0x00018C80 File Offset: 0x00016E80
			public Color LineColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.lineColor != value)
						{
							this.line.invalidate();
						}
						this.line.FillColor = value;
					}
					this.lineColor = value;
				}
			}

			// Token: 0x170001C8 RID: 456
			// (set) Token: 0x060017D0 RID: 6096 RVA: 0x00018CB6 File Offset: 0x00016EB6
			public Color OverColor
			{
				set
				{
					this.overColor = value;
				}
			}

			// Token: 0x170001C9 RID: 457
			// (set) Token: 0x060017D1 RID: 6097 RVA: 0x00018CBF File Offset: 0x00016EBF
			public Color LineOverColor
			{
				set
				{
					this.lineOverColor = value;
				}
			}

			// Token: 0x170001CA RID: 458
			// (set) Token: 0x060017D2 RID: 6098 RVA: 0x00018CC8 File Offset: 0x00016EC8
			public bool hasAttachment
			{
				set
				{
					this.attachmentPresent = value;
					this.attachmentIcon.Visible = value;
				}
			}

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060017D3 RID: 6099 RVA: 0x00018CDD File Offset: 0x00016EDD
			public CustomSelfDrawPanel.CSDLabel BodyText
			{
				get
				{
					return this.subjectLabel;
				}
			}

			// Token: 0x170001CC RID: 460
			// (set) Token: 0x060017D4 RID: 6100 RVA: 0x0017AEDC File Offset: 0x001790DC
			public DateTime Date
			{
				set
				{
					if (this.BodyText.Text.Length > 0 || this.Sender.Text.Length > 0)
					{
						this.dateLabel.Text = string.Concat(new string[]
						{
							value.ToShortDateString(),
							" ",
							value.Hour.ToString("00"),
							":",
							value.Minute.ToString("00")
						});
					}
				}
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x060017D5 RID: 6101 RVA: 0x00018CE5 File Offset: 0x00016EE5
			public CustomSelfDrawPanel.CSDLabel DateLabel
			{
				get
				{
					return this.dateLabel;
				}
			}

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x060017D6 RID: 6102 RVA: 0x00018CED File Offset: 0x00016EED
			public CustomSelfDrawPanel.CSDLabel Sender
			{
				get
				{
					return this.senderLabel;
				}
			}

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x060017D7 RID: 6103 RVA: 0x00018CF5 File Offset: 0x00016EF5
			public CustomSelfDrawPanel.CSDImage Icon
			{
				get
				{
					return this.icon;
				}
			}

			// Token: 0x060017D8 RID: 6104 RVA: 0x0017AF70 File Offset: 0x00179170
			public void reset()
			{
				this.bodyColor = CustomSelfDrawPanel.MailBodyColor;
				this.lineColor = CustomSelfDrawPanel.MailLineColor;
				this.overColor = CustomSelfDrawPanel.MailOverColor;
				this.lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
				this.hasAttachment = false;
			}

			// Token: 0x060017D9 RID: 6105 RVA: 0x0017AFD4 File Offset: 0x001791D4
			public void setup()
			{
				this.main.Size = new Size(this.Size.Width, this.Size.Height - 1);
				this.main.FillColor = this.bodyColor;
				this.line.Position = new Point(0, this.Size.Height - 1);
				this.line.Size = new Size(this.Size.Width, 1);
				this.line.FillColor = this.lineColor;
				this.attachmentIcon.Image = GFXLibrary.mail2_attach_icon;
				this.attachmentIcon.Size = new Size(this.Size.Height, this.Size.Height);
				this.attachmentIcon.Position = new Point(0, 0);
				this.attachmentIcon.Visible = false;
				this.sep1.Position = new Point(249 + this.Size.Height, 0);
				this.sep1.Size = new Size(1, this.Size.Height - 1);
				this.sep1.FillColor = this.lineColor;
				this.sep2.Position = new Point(343 + this.Size.Height, 0);
				this.sep2.Size = new Size(1, this.Size.Height - 1);
				this.sep2.FillColor = this.lineColor;
				this.subjectLabel.Position = new Point(23 + this.Size.Height, 2);
				this.subjectLabel.Size = new Size(227, this.Size.Height - 4);
				this.subjectLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.dateLabel.Position = new Point(253 + this.Size.Height, 0);
				this.dateLabel.Size = new Size(95, this.Size.Height);
				this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.senderLabel.Position = new Point(347 + this.Size.Height, 2);
				this.senderLabel.Size = new Size(this.Size.Width - 347, this.Size.Height - 4);
				this.senderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.icon.Position = new Point(3 + this.Size.Height, 0);
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseLeave));
				base.addControl(this.main);
				base.addControl(this.line);
				base.addControl(this.attachmentIcon);
				base.addControl(this.sep1);
				base.addControl(this.sep2);
				this.main.addControl(this.subjectLabel);
				this.main.addControl(this.dateLabel);
				this.main.addControl(this.senderLabel);
				this.main.addControl(this.icon);
				this.setupComplete = true;
			}

			// Token: 0x060017DA RID: 6106 RVA: 0x0017B350 File Offset: 0x00179550
			private void mouseOver()
			{
				if (this.subjectLabel.Text.Length > 0)
				{
					this.main.FillColor = this.overColor;
					this.line.FillColor = this.lineOverColor;
					this.sep1.FillColor = this.lineOverColor;
					this.sep2.FillColor = this.lineOverColor;
				}
			}

			// Token: 0x060017DB RID: 6107 RVA: 0x0017B3B4 File Offset: 0x001795B4
			private void mouseLeave()
			{
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
				this.sep1.FillColor = this.lineColor;
				this.sep2.FillColor = this.lineColor;
			}

			// Token: 0x060017DC RID: 6108 RVA: 0x00007CE0 File Offset: 0x00005EE0
			private void attachmentClick()
			{
			}

			// Token: 0x04002884 RID: 10372
			private bool setupComplete;

			// Token: 0x04002885 RID: 10373
			public bool attachmentPresent;

			// Token: 0x04002886 RID: 10374
			private CustomSelfDrawPanel.CSDFill main = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002887 RID: 10375
			private CustomSelfDrawPanel.CSDFill line = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x04002888 RID: 10376
			private CustomSelfDrawPanel.CSDLabel subjectLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002889 RID: 10377
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400288A RID: 10378
			private CustomSelfDrawPanel.CSDLabel senderLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400288B RID: 10379
			private CustomSelfDrawPanel.CSDImage icon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400288C RID: 10380
			public CustomSelfDrawPanel.CSDImage attachmentIcon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400288D RID: 10381
			private CustomSelfDrawPanel.CSDFill sep1 = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400288E RID: 10382
			private CustomSelfDrawPanel.CSDFill sep2 = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400288F RID: 10383
			private Color bodyColor = CustomSelfDrawPanel.MailBodyColor;

			// Token: 0x04002890 RID: 10384
			private Color lineColor = CustomSelfDrawPanel.MailLineColor;

			// Token: 0x04002891 RID: 10385
			private Color overColor = CustomSelfDrawPanel.MailOverColor;

			// Token: 0x04002892 RID: 10386
			private Color lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
		}
	}
}
