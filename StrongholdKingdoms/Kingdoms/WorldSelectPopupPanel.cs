using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000523 RID: 1315
	public class WorldSelectPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06003394 RID: 13204 RVA: 0x00024F64 File Offset: 0x00023164
		public Image SelectImage
		{
			get
			{
				if (WorldSelectPopupPanel.selectImage == null)
				{
					WorldSelectPopupPanel.selectImage = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelect, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRedFaded, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectImage;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06003395 RID: 13205 RVA: 0x002A7734 File Offset: 0x002A5934
		public Image SelectImageSelected
		{
			get
			{
				if (WorldSelectPopupPanel.selectImageSelected == null)
				{
					WorldSelectPopupPanel.selectImageSelected = WebStyleButtonImage.Generate(260, this.WebButtonheight + 4, this.strStandardWorlds, this.WebTextFontBoldCond, this.WebButtonYellow2, this.WebButtonRed, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectImageSelected;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06003396 RID: 13206 RVA: 0x002A7784 File Offset: 0x002A5984
		public Image SelectImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.selectImageOver == null)
				{
					WorldSelectPopupPanel.selectImageOver = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelect, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectImageOver;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06003397 RID: 13207 RVA: 0x002A77D0 File Offset: 0x002A59D0
		public Image SelectSpecialImage
		{
			get
			{
				if (WorldSelectPopupPanel.selectSpecialImage == null)
				{
					WorldSelectPopupPanel.selectSpecialImage = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelectSpecial + "   (" + this.numSpecialWorlds.ToString() + ")", this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRedFaded, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectSpecialImage;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06003398 RID: 13208 RVA: 0x002A7838 File Offset: 0x002A5A38
		public Image SelectSpecialImageSelected
		{
			get
			{
				if (WorldSelectPopupPanel.selectSpecialImageSelected == null)
				{
					WorldSelectPopupPanel.selectSpecialImageSelected = WebStyleButtonImage.Generate(260, this.WebButtonheight + 4, this.strSpecialWorlds, this.WebTextFontBoldCond, this.WebButtonYellow2, this.WebButtonRed, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectSpecialImageSelected;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06003399 RID: 13209 RVA: 0x002A7888 File Offset: 0x002A5A88
		public Image SelectSpecialImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.selectSpecialImageOver == null)
				{
					WorldSelectPopupPanel.selectSpecialImageOver = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelectSpecial + "   (" + this.numSpecialWorlds.ToString() + ")", this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectSpecialImageOver;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600339A RID: 13210 RVA: 0x00024FA4 File Offset: 0x000231A4
		public Image SelectAIImage
		{
			get
			{
				if (WorldSelectPopupPanel.selectAIImage == null)
				{
					WorldSelectPopupPanel.selectAIImage = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelectAI, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRedFaded, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectAIImage;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x0600339B RID: 13211 RVA: 0x002A78F0 File Offset: 0x002A5AF0
		public Image SelectAIImageSelected
		{
			get
			{
				if (WorldSelectPopupPanel.selectAIImageSelected == null)
				{
					WorldSelectPopupPanel.selectAIImageSelected = WebStyleButtonImage.Generate(260, this.WebButtonheight + 4, this.strAIWorlds, this.WebTextFontBoldCond, this.WebButtonYellow2, this.WebButtonRed, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectAIImageSelected;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x0600339C RID: 13212 RVA: 0x002A7940 File Offset: 0x002A5B40
		public Image SelectAIImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.selectAIImageOver == null)
				{
					WorldSelectPopupPanel.selectAIImageOver = WebStyleButtonImage.Generate(260, this.WebButtonheight, this.strSelectAI, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.selectAIImageOver;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x0600339D RID: 13213 RVA: 0x002A798C File Offset: 0x002A5B8C
		public Image CloseImage
		{
			get
			{
				if (WorldSelectPopupPanel.closeImage == null)
				{
					WorldSelectPopupPanel.closeImage = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.closeImage;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x0600339E RID: 13214 RVA: 0x002A79D8 File Offset: 0x002A5BD8
		public Image CloseImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.closeImageOver == null)
				{
					WorldSelectPopupPanel.closeImageOver = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.closeImageOver;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x0600339F RID: 13215 RVA: 0x002A7A24 File Offset: 0x002A5C24
		public Image JoinImage
		{
			get
			{
				if (WorldSelectPopupPanel.joinImage == null)
				{
					WorldSelectPopupPanel.joinImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.joinImage;
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060033A0 RID: 13216 RVA: 0x002A7A70 File Offset: 0x002A5C70
		public Image JoinImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.joinImageOver == null)
				{
					WorldSelectPopupPanel.joinImageOver = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.joinImageOver;
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060033A1 RID: 13217 RVA: 0x002A7AC0 File Offset: 0x002A5CC0
		public Image PlayImage
		{
			get
			{
				if (WorldSelectPopupPanel.playImage == null)
				{
					WorldSelectPopupPanel.playImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strPlay, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.playImage;
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060033A2 RID: 13218 RVA: 0x002A7B0C File Offset: 0x002A5D0C
		public Image PlayImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.playImageOver == null)
				{
					WorldSelectPopupPanel.playImageOver = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strPlay, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.playImageOver;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060033A3 RID: 13219 RVA: 0x002A7B5C File Offset: 0x002A5D5C
		public Image ClosedImage
		{
			get
			{
				if (WorldSelectPopupPanel.closedImage == null)
				{
					WorldSelectPopupPanel.closedImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strClosed, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRed, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.closedImage;
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x060033A4 RID: 13220 RVA: 0x00024FE4 File Offset: 0x000231E4
		public Image SortByNameImage
		{
			get
			{
				if (WorldSelectPopupPanel.sortByNameImage == null)
				{
					WorldSelectPopupPanel.sortByNameImage = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strSortByName, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRedFaded, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.sortByNameImage;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x060033A5 RID: 13221 RVA: 0x002A7BA8 File Offset: 0x002A5DA8
		public Image SortByNameImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.sortByNameImageOver == null)
				{
					WorldSelectPopupPanel.sortByNameImageOver = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strSortByName, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.sortByNameImageOver;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x060033A6 RID: 13222 RVA: 0x00025024 File Offset: 0x00023224
		public Image SortByTimeImage
		{
			get
			{
				if (WorldSelectPopupPanel.sortByTimeImage == null)
				{
					WorldSelectPopupPanel.sortByTimeImage = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strSortByTime, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRedFaded, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.sortByTimeImage;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x060033A7 RID: 13223 RVA: 0x002A7BF4 File Offset: 0x002A5DF4
		public Image SortByTimeImageOver
		{
			get
			{
				if (WorldSelectPopupPanel.sortByTimeImageOver == null)
				{
					WorldSelectPopupPanel.sortByTimeImageOver = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strSortByTime, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return WorldSelectPopupPanel.sortByTimeImageOver;
			}
		}

		// Token: 0x060033A8 RID: 13224 RVA: 0x00025064 File Offset: 0x00023264
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060033A9 RID: 13225 RVA: 0x00025083 File Offset: 0x00023283
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x060033AA RID: 13226 RVA: 0x002A7C40 File Offset: 0x002A5E40
		public WorldSelectPopupPanel()
		{
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060033AB RID: 13227 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		private void AddControlToPanel(CustomSelfDrawPanel.CSDControl c)
		{
			base.addControl(c);
		}

		// Token: 0x060033AC RID: 13228 RVA: 0x00025097 File Offset: 0x00023297
		private void removeControlFromPanel(CustomSelfDrawPanel.CSDControl c)
		{
			base.removeControl(c);
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x002A8050 File Offset: 0x002A6250
		public void init(int villageID, bool reset)
		{
			int count = Program.profileLogin.GetAllPlayedWorlds().Count;
			int count2 = Program.profileLogin.GetNonPlayedBySupportCulture(ProfileLoginWindow.LastSelectedSupportCulture).Count;
			base.clearControls();
			this.languageArea.Size = base.Size;
			this.scrHeight = base.Height / 3 - 65;
			this.backgroundBorder.Image = GFXLibrary.world_list_background;
			this.AddControlToPanel(this.backgroundBorder);
			if (count >= 8)
			{
				this.scrHeight *= 2;
			}
			this.AddControlToPanel(this.languageArea);
			this.BackColor = global::ARGBColors.White;
			this.addTitleButtons();
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = this.CloseImage;
			csdbutton.ImageOver = this.CloseImageOver;
			csdbutton.setSizeToImage();
			csdbutton.Position = new Point(base.Width / 2 - csdbutton.Width / 2, 570);
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "WorldSelectPopupPanel_close");
			this.AddControlToPanel(csdbutton);
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Position = new Point(this.scrX - 3, this.scrY - 3);
			csdextendingPanel.Size = new Size(this.scrWidth + 30, this.scrHeight + 6);
			csdextendingPanel.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.AddControlToPanel(csdextendingPanel);
			this.playedScrollArea.Position = new Point(this.scrX, this.scrY);
			this.playedScrollArea.Size = new Size(this.scrWidth, this.scrHeight);
			this.playedScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(this.scrWidth, this.scrHeight));
			this.AddControlToPanel(this.playedScrollArea);
			this.playedWheelOverlay.Position = this.playedScrollArea.Position;
			this.playedWheelOverlay.Size = this.playedScrollArea.Size;
			this.playedWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.AddControlToPanel(this.playedWheelOverlay);
			int value = this.playedScrollBar.Value;
			this.playedScrollBar.Position = new Point(this.scrWidth + this.scrX, this.scrY);
			this.playedScrollBar.Size = new Size(24, this.scrHeight);
			this.AddControlToPanel(this.playedScrollBar);
			this.playedScrollBar.Value = 0;
			this.playedScrollBar.Max = 100;
			this.playedScrollBar.NumVisibleLines = this.playedScrollBar.Height;
			this.playedScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.playedScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.playedSortingButton.ImageNorm = this.SortByNameImage;
			this.playedSortingButton.ImageOver = this.SortByNameImageOver;
			this.playedSortingButton.setSizeToImage();
			this.playedSortingButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortingToggleClick));
			this.playedSortingButton.Position = new Point(csdextendingPanel.Rectangle.Right - this.playedSortingButton.Width - 2, csdextendingPanel.Y - this.playedSortingButton.Height - 5);
			this.AddControlToPanel(this.playedSortingButton);
			this.newUserPanel.Position = new Point(this.playedScrollArea.X, this.playedScrollArea.Y);
			this.newUserPanel.Size = new Size(this.playedScrollArea.Rectangle.Right - this.newUserPanel.X, this.playedScrollArea.Rectangle.Bottom - this.newUserPanel.Y);
			this.newUserPanel.FillColor = global::ARGBColors.Transparent;
			this.newUserPanel.Visible = false;
			this.AddControlToPanel(this.newUserPanel);
			this.lblSuggestedHeader.Text = SK.Text("WORLD_SELECT_Suggested", "Suggested For You");
			this.lblSuggestedHeader.Position = new Point(0, 5);
			this.lblSuggestedHeader.Size = new Size(this.newUserPanel.Width, 30);
			this.lblSuggestedHeader.Color = global::ARGBColors.Black;
			this.lblSuggestedHeader.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblSuggestedHeader.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.newUserPanel.addControl(this.lblSuggestedHeader);
			this.lblSuggestedName.Position = new Point(0, this.lblSuggestedHeader.Rectangle.Bottom + 5);
			this.lblSuggestedName.Size = new Size(this.newUserPanel.Width, 60);
			this.lblSuggestedName.Color = global::ARGBColors.Black;
			this.lblSuggestedName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblSuggestedName.Font = FontManager.GetFont("Arial", 40f, FontStyle.Bold);
			this.newUserPanel.addControl(this.lblSuggestedName);
			this.btnJoinSuggested.ImageNorm = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
			this.btnJoinSuggested.ImageOver = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
			this.btnJoinSuggested.setSizeToImage();
			this.btnJoinSuggested.Position = new Point(this.newUserPanel.Width / 2 - this.btnJoinSuggested.Width / 2, this.lblSuggestedName.Rectangle.Bottom);
			this.btnJoinSuggested.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnWorldAction_Click), "WorldSelectPopupPanel_world_select");
			this.newUserPanel.addControl(this.btnJoinSuggested);
			this.btnSuggestedInfo.ImageNorm = GFXLibrary.help_normal;
			this.btnSuggestedInfo.ImageOver = GFXLibrary.help_over;
			this.btnSuggestedInfo.ImageClick = GFXLibrary.help_pushed;
			this.btnSuggestedInfo.setSizeToImage();
			this.btnSuggestedInfo.Position = new Point(this.btnJoinSuggested.Rectangle.Right + 5, this.btnJoinSuggested.Y + this.btnJoinSuggested.Height / 2 - this.btnSuggestedInfo.Height / 2);
			this.btnSuggestedInfo.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoOverlayOpenedClick));
			int num = this.scrHeight * 2;
			if (count >= 8)
			{
				num = this.scrHeight / 2;
			}
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel2 = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel2.Position = new Point(this.scrX - 3, this.playedScrollArea.Rectangle.Bottom + 57);
			csdextendingPanel2.Size = new Size(this.scrWidth + 30, num + 6);
			csdextendingPanel2.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.AddControlToPanel(csdextendingPanel2);
			this.availableScrollArea.Position = new Point(this.scrX, this.playedScrollArea.Rectangle.Bottom + 60);
			this.availableScrollArea.Size = new Size(this.scrWidth, num);
			this.availableScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(this.scrWidth, num));
			this.AddControlToPanel(this.availableScrollArea);
			this.availableMouseWheelOverlay.Position = this.availableScrollArea.Position;
			this.availableMouseWheelOverlay.Size = this.availableScrollArea.Size;
			this.availableMouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.availableMouseWheelMoved));
			this.AddControlToPanel(this.availableMouseWheelOverlay);
			int value2 = this.playedScrollBar.Value;
			this.availableScrollBar.Position = new Point(this.scrWidth + this.scrX, this.playedScrollArea.Rectangle.Bottom + 60);
			this.availableScrollBar.Size = new Size(24, num);
			this.AddControlToPanel(this.availableScrollBar);
			this.availableScrollBar.Value = 0;
			this.availableScrollBar.Max = 100;
			this.availableScrollBar.NumVisibleLines = this.availableScrollBar.Height;
			this.availableScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.availableScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.availableScrollBarMoved));
			this.lblPlayedWorlds.Text = SK.Text("WorldSelect_YourWorlds", "Your Worlds");
			this.lblPlayedWorlds.Position = new Point(this.playedScrollArea.X + 50, 40);
			this.lblPlayedWorlds.Size = new Size(this.playedScrollArea.Width - 100, 50);
			this.lblPlayedWorlds.Color = global::ARGBColors.Black;
			this.lblPlayedWorlds.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblPlayedWorlds.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.AddControlToPanel(this.lblPlayedWorlds);
			this.lblAvailableWorlds.Text = SK.Text("WorldSelect_AvailableWorlds", "Available Worlds");
			this.lblAvailableWorlds.Position = new Point(this.availableScrollArea.X + 50, this.playedScrollArea.Rectangle.Bottom + 15);
			this.lblAvailableWorlds.Size = new Size(this.availableScrollArea.Width - 100, 50);
			this.lblAvailableWorlds.Color = global::ARGBColors.Black;
			this.lblAvailableWorlds.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblAvailableWorlds.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.AddControlToPanel(this.lblAvailableWorlds);
			this.showOwnWorlds.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.showOwnWorlds.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.showOwnWorlds.Position = new Point(15, 570);
			this.showOwnWorlds.Checked = WorldSelectPopupPanel.showOwnWorldsStatus;
			this.showOwnWorlds.CBLabel.Text = SK.Text("WORLD_Always_Show_Your_Worlds", "Always show worlds you are playing.");
			this.showOwnWorlds.CBLabel.Color = global::ARGBColors.Black;
			this.showOwnWorlds.CBLabel.Position = new Point(20, -1);
			this.showOwnWorlds.CBLabel.Size = new Size(400, 25);
			this.showOwnWorlds.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.showOwnWorlds.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.ownToggled));
			new Dictionary<string, LocalizationLanguage>();
			this.selectedWorldRect.Position = default(Point);
			this.selectedWorldRect.FillColor = Color.FromArgb(192, 192, 192);
			this.selectedWorldRect.Size = new Size(34, 22);
			this.languageArea.addControl(this.selectedWorldRect);
			this.selectedWorldRect2.Position = default(Point);
			this.selectedWorldRect2.FillColor = global::ARGBColors.Black;
			this.selectedWorldRect2.Size = new Size(32, 20);
			this.languageArea.addControl(this.selectedWorldRect2);
			this.lblLanguageSelect.Text = SK.Text("WorldSelect_SelectLanguage", "Select Language");
			this.lblLanguageSelect.Position = new Point(base.Width * 2 / 3 - 20, this.playedScrollArea.Rectangle.Bottom + 12);
			this.lblLanguageSelect.Size = new Size(base.Width / 3, 20);
			this.lblLanguageSelect.Color = global::ARGBColors.Black;
			this.lblLanguageSelect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lblLanguageSelect.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.AddControlToPanel(this.lblLanguageSelect);
			List<WorldInfo> worldList = ProfileLoginWindow.WorldList;
			List<string> list = new List<string>();
			list.Add("en");
			list.Add("de");
			list.Add("ru");
			list.Add("fr");
			list.Add("pl");
			list.Add("es");
			list.Add("it");
			list.Add("tr");
			list.Add("pt");
			list.Add("zh");
			for (int i = 0; i < list.Count; i++)
			{
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				LocalizationLanguage localizationLanguage = new LocalizationLanguage();
				localizationLanguage.CultureCode = list[i];
				string text = localizationLanguage.CultureCode;
				if (text == "pt" || text == "br")
				{
					text = "br";
				}
				csdimage.Image = GFXLibrary.getLoginWorldFlag(text);
				csdimage.Width = csdimage.Image.Width;
				csdimage.Height = csdimage.Image.Height;
				csdimage.Position = new Point(this.availableScrollArea.Rectangle.Right - csdimage.Width / 2 - (list.Count - i) * (csdimage.Width + 4), this.playedScrollArea.Rectangle.Bottom + 30);
				this.languageArea.addControl(csdimage);
				csdimage.Tag = localizationLanguage;
				csdimage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.language_Click), "WorldSelectPopupPanel_language_flags");
				if (i == 0)
				{
					this.lblLanguageSelect.X = csdimage.X;
				}
			}
			this.lastLang = ProfileLoginWindow.LastSelectedSupportCulture;
			this.updateFlagAlpha();
			this.infoOverlay.Position = new Point(0, 0);
			this.infoOverlay.Size = base.Size;
			this.infoOverlay.FillColor = Color.FromArgb(128, 0, 0, 0);
			this.infoOverlay.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoOverlayCloseClicked));
			this.infoOverlay.Visible = false;
			this.AddControlToPanel(this.infoOverlay);
			this.infoOverlayPanel.Position = new Point(200, 150);
			this.infoOverlayPanel.Size = new Size(base.Width - 400, base.Height - 300);
			this.infoOverlayPanel.FillColor = global::ARGBColors.White;
			this.infoOverlay.addControl(this.infoOverlayPanel);
			this.infoOverlayClose.ImageNorm = this.CloseImage;
			this.infoOverlayClose.ImageOver = this.CloseImageOver;
			this.infoOverlayClose.setSizeToImage();
			this.infoOverlayClose.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayClose.Width / 2, 270);
			this.infoOverlayClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoOverlayCloseClicked), "WorldSelectPopupPanel_close");
			this.infoOverlayPanel.addControl(this.infoOverlayClose);
			this.infoOverlayHeading.Position = new Point(81, 10);
			this.infoOverlayPanel.addControl(this.infoOverlayHeading);
			this.infoOverlayActivePlayers.Text = SK.Text("WorldSelect_ActivePlayer", "Active Players");
			this.infoOverlayActivePlayers.Position = new Point(0, 110);
			this.infoOverlayActivePlayers.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayActivePlayers.Color = global::ARGBColors.Black;
			this.infoOverlayActivePlayers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayActivePlayers.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayActivePlayers);
			this.infoOverlayActivePlayersValue.Text = "?";
			this.infoOverlayActivePlayersValue.Position = new Point(0, 130);
			this.infoOverlayActivePlayersValue.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayActivePlayersValue.Color = global::ARGBColors.Green;
			this.infoOverlayActivePlayersValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayActivePlayersValue.Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayActivePlayersValue);
			this.infoOverlayDuration.Text = SK.Text("WorldSelect_WorldDuration", "Days since World Start");
			this.infoOverlayDuration.Position = new Point(this.infoOverlayPanel.Width / 2, 110);
			this.infoOverlayDuration.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayDuration.Color = global::ARGBColors.Black;
			this.infoOverlayDuration.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayDuration.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayDuration);
			this.infoOverlayDurationValue.Text = "?";
			this.infoOverlayDurationValue.Position = new Point(this.infoOverlayPanel.Width / 2, 130);
			this.infoOverlayDurationValue.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayDurationValue.Color = global::ARGBColors.Green;
			this.infoOverlayDurationValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayDurationValue.Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayDurationValue);
			this.infoOverlayGameAge.Text = SK.Text("WorldSelect_GameAge", "Game Type");
			this.infoOverlayGameAge.Position = new Point(0, 190);
			this.infoOverlayGameAge.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayGameAge.Color = global::ARGBColors.Black;
			this.infoOverlayGameAge.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayGameAge.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayGameAge);
			this.infoOverlayGameAgeValue.Text = "?";
			this.infoOverlayGameAgeValue.Position = new Point(0, 210);
			this.infoOverlayGameAgeValue.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayGameAgeValue.Color = global::ARGBColors.Green;
			this.infoOverlayGameAgeValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayGameAgeValue.Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayGameAgeValue);
			this.infoOverlayHouses.Text = SK.Text("WorldSelect_RemainingHouses", "Houses Left in Glory Race");
			this.infoOverlayHouses.Position = new Point(this.infoOverlayPanel.Width / 2, 190);
			this.infoOverlayHouses.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayHouses.Color = global::ARGBColors.Black;
			this.infoOverlayHouses.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayHouses.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayHouses);
			this.infoOverlayHousesValue.Text = "?";
			this.infoOverlayHousesValue.Position = new Point(this.infoOverlayPanel.Width / 2, 210);
			this.infoOverlayHousesValue.Size = new Size(this.infoOverlayPanel.Width / 2, 50);
			this.infoOverlayHousesValue.Color = global::ARGBColors.Green;
			this.infoOverlayHousesValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.infoOverlayHousesValue.Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold);
			this.infoOverlayPanel.addControl(this.infoOverlayHousesValue);
			this.infoOverlayPanel.addControl(this.infoOverlayAgeIcon);
			Program.profileLogin.GetWorldsBySupportCulture(ProfileLoginWindow.LastSelectedSupportCulture, WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.BuildOnlineWorldList(Program.profileLogin.GetAllPlayedWorlds(), Program.profileLogin.GetNonPlayedBySupportCulture(ProfileLoginWindow.LastSelectedSupportCulture));
		}

		// Token: 0x060033AE RID: 13230 RVA: 0x002A95A8 File Offset: 0x002A77A8
		private void updateFlagAlpha()
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.languageArea.Controls)
			{
				try
				{
					if (csdcontrol.Tag != null)
					{
						CustomSelfDrawPanel.CSDImage csdimage = (CustomSelfDrawPanel.CSDImage)csdcontrol;
						if (((LocalizationLanguage)csdimage.Tag).CultureCode == this.lastLang)
						{
							csdimage.Colorise = global::ARGBColors.White;
							csdimage.Alpha = 1f;
							this.selectedWorldRect.Position = new Point(csdimage.Position.X - 2, csdimage.Position.Y - 2);
							this.selectedWorldRect2.Position = new Point(csdimage.Position.X - 1, csdimage.Position.Y - 1);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060033AF RID: 13231 RVA: 0x002A96B8 File Offset: 0x002A78B8
		private bool areThereSpecialWorlds()
		{
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", true, 0);
			foreach (WorldInfo worldInfo in worldsBySupportCulture)
			{
				if (ProfileLoginWindow.isSpecialWorld(worldInfo.KingdomsWorldID))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060033B0 RID: 13232 RVA: 0x002A9728 File Offset: 0x002A7928
		private int countAIWorlds()
		{
			int num = 0;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", true, 0);
			foreach (WorldInfo worldInfo in worldsBySupportCulture)
			{
				if (ProfileLoginWindow.isAIWorld(worldInfo.KingdomsWorldID))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060033B1 RID: 13233 RVA: 0x002A9798 File Offset: 0x002A7998
		private bool areThereAIWorlds()
		{
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", true, 0);
			foreach (WorldInfo worldInfo in worldsBySupportCulture)
			{
				if (ProfileLoginWindow.isAIWorld(worldInfo.KingdomsWorldID))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060033B2 RID: 13234 RVA: 0x002A9808 File Offset: 0x002A7A08
		private bool areTherePlayedAIWorlds()
		{
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", true, 0);
			foreach (WorldInfo worldInfo in worldsBySupportCulture)
			{
				if (ProfileLoginWindow.isAIWorld(worldInfo.KingdomsWorldID) && worldInfo.Playing)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060033B3 RID: 13235 RVA: 0x002A9880 File Offset: 0x002A7A80
		private void addTitleButtons()
		{
			this.pulseTitleButton = false;
			this.playedScrollBar.Value = 0;
			this.wallScrollBarMoved();
			if (this.titleImage != null)
			{
				this.removeControlFromPanel(this.titleImage);
			}
			if (this.titleButton != null)
			{
				this.removeControlFromPanel(this.titleButton);
			}
			if (this.titleButton2 != null)
			{
				this.removeControlFromPanel(this.titleButton2);
			}
			if (this.numSpecialWorlds < 0)
			{
				this.numSpecialWorlds = this.countAIWorlds();
			}
			if (WorldSelectPopupPanel.showSpecialWorlds == -1)
			{
				if (this.areThereSpecialWorlds())
				{
					this.titleButton = new CustomSelfDrawPanel.CSDButton();
					this.titleButton.ImageNorm = this.SelectSpecialImage;
					this.titleButton.ImageOver = this.SelectSpecialImageOver;
					this.titleButton.Position = new Point(281, 10);
					this.titleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.specialWorldsClick));
				}
				else
				{
					this.titleButton = null;
				}
				if (this.areThereAIWorlds())
				{
					this.titleButton2 = new CustomSelfDrawPanel.CSDButton();
					this.titleButton2.ImageNorm = this.SelectSpecialImage;
					this.titleButton2.ImageOver = this.SelectSpecialImageOver;
					this.titleButton2.Position = new Point(551, 10);
					this.titleButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aiWorldsClick));
					if (!this.areTherePlayedAIWorlds())
					{
						this.pulseTitleButton = true;
					}
				}
				else
				{
					this.titleButton2 = null;
				}
				this.titleImage = new CustomSelfDrawPanel.CSDImage();
				this.titleImage.Image = this.SelectImageSelected;
				this.titleImage.Position = new Point(11, 8);
				this.supportLabel.Visible = true;
				this.languageArea.Visible = true;
				return;
			}
			if (WorldSelectPopupPanel.showSpecialWorlds == 1)
			{
				this.titleButton = new CustomSelfDrawPanel.CSDButton();
				this.titleButton.ImageNorm = this.SelectImage;
				this.titleButton.ImageOver = this.SelectImageOver;
				this.titleButton.Position = new Point(11, 10);
				this.titleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.standardWorldsClick));
				this.titleImage = new CustomSelfDrawPanel.CSDImage();
				this.titleImage.Image = this.SelectSpecialImageSelected;
				this.titleImage.Position = new Point(281, 8);
				if (this.areThereAIWorlds())
				{
					this.titleButton2 = new CustomSelfDrawPanel.CSDButton();
					this.titleButton2.ImageNorm = this.SelectSpecialImage;
					this.titleButton2.ImageOver = this.SelectSpecialImageOver;
					this.titleButton2.Position = new Point(551, 10);
					this.titleButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aiWorldsClick));
					if (!this.areTherePlayedAIWorlds())
					{
						this.pulseTitleButton = true;
					}
				}
				else
				{
					this.titleButton2 = null;
				}
				this.supportLabel.Visible = false;
				this.languageArea.Visible = false;
				return;
			}
			if (WorldSelectPopupPanel.showSpecialWorlds == 2)
			{
				this.titleButton = new CustomSelfDrawPanel.CSDButton();
				this.titleButton.ImageNorm = this.SelectImage;
				this.titleButton.ImageOver = this.SelectImageOver;
				this.titleButton.Position = new Point(11, 10);
				this.titleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.standardWorldsClick));
				this.titleImage = new CustomSelfDrawPanel.CSDImage();
				this.titleImage.Image = this.SelectSpecialImageSelected;
				this.titleImage.Position = new Point(551, 8);
				if (this.areThereSpecialWorlds())
				{
					this.titleButton = new CustomSelfDrawPanel.CSDButton();
					this.titleButton.ImageNorm = this.SelectSpecialImage;
					this.titleButton.ImageOver = this.SelectSpecialImageOver;
					this.titleButton.Position = new Point(281, 10);
					this.titleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.specialWorldsClick));
				}
				else
				{
					this.titleButton = null;
				}
				this.supportLabel.Visible = false;
				this.languageArea.Visible = false;
			}
		}

		// Token: 0x060033B4 RID: 13236 RVA: 0x002A9C74 File Offset: 0x002A7E74
		private void language_Click()
		{
			this.lastLang = ((LocalizationLanguage)this.ClickedControl.Tag).CultureCode;
			this.updateFlagAlpha();
			Program.profileLogin.GetWorldsBySupportCulture(((LocalizationLanguage)this.ClickedControl.Tag).CultureCode, WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.playedScrollBar.Value = 0;
			this.wallScrollBarMoved();
			this.availableScrollBar.Value = 0;
			this.availableScrollBarMoved();
			this.BuildOnlineWorldList(Program.profileLogin.GetAllPlayedWorlds(), Program.profileLogin.GetNonPlayedBySupportCulture(ProfileLoginWindow.LastSelectedSupportCulture));
		}

		// Token: 0x060033B5 RID: 13237 RVA: 0x002A9D10 File Offset: 0x002A7F10
		public void update()
		{
			if (this.pulseTitleButton && this.titleButton2 != null)
			{
				this.pulse++;
				if (this.pulse == 768)
				{
					this.pulse = 0;
				}
				float num = (float)(this.pulse / 3);
				if (num > 128f)
				{
					num = 256f - num;
				}
				num = (num + 128f) / 255f;
				this.titleButton2.Alpha = num;
				this.titleButton2.invalidate();
			}
		}

		// Token: 0x060033B6 RID: 13238 RVA: 0x000250A0 File Offset: 0x000232A0
		private void closeClick()
		{
			InterfaceMgr.Instance.closeWorldSelectPopupWindow();
		}

		// Token: 0x060033B7 RID: 13239 RVA: 0x002A9D90 File Offset: 0x002A7F90
		private void standardWorldsClick()
		{
			WorldSelectPopupPanel.showSpecialWorlds = -1;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture(this.lastLang, WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.BuildOnlineWorldList(worldsBySupportCulture);
			this.addTitleButtons();
		}

		// Token: 0x060033B8 RID: 13240 RVA: 0x002A9DCC File Offset: 0x002A7FCC
		private void specialWorldsClick()
		{
			WorldSelectPopupPanel.showSpecialWorlds = 1;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.BuildOnlineWorldList(worldsBySupportCulture);
			this.addTitleButtons();
		}

		// Token: 0x060033B9 RID: 13241 RVA: 0x002A9E08 File Offset: 0x002A8008
		private void aiWorldsClick()
		{
			WorldSelectPopupPanel.showSpecialWorlds = 2;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.BuildOnlineWorldList(worldsBySupportCulture);
			this.addTitleButtons();
		}

		// Token: 0x060033BA RID: 13242 RVA: 0x002A9E44 File Offset: 0x002A8044
		private void sortingToggleClick()
		{
			this.sortPlayedWorldsByName = !this.sortPlayedWorldsByName;
			if (this.sortPlayedWorldsByName)
			{
				this.playedSortingButton.ImageNorm = this.SortByTimeImage;
				this.playedSortingButton.ImageOver = this.SortByTimeImageOver;
			}
			else
			{
				this.playedSortingButton.ImageNorm = this.SortByNameImage;
				this.playedSortingButton.ImageOver = this.SortByNameImageOver;
			}
			this.BuildOnlineWorldList(Program.profileLogin.GetAllPlayedWorlds(), Program.profileLogin.GetNonPlayedBySupportCulture(ProfileLoginWindow.LastSelectedSupportCulture));
			this.playedSortingButton.invalidate();
		}

		// Token: 0x060033BB RID: 13243 RVA: 0x002A9ED8 File Offset: 0x002A80D8
		private void wallScrollBarMoved()
		{
			int value = this.playedScrollBar.Value;
			this.playedScrollArea.Position = new Point(this.playedScrollArea.X, this.scrY - value);
			this.playedScrollArea.ClipRect = new Rectangle(this.playedScrollArea.ClipRect.X, value, this.playedScrollArea.ClipRect.Width, this.playedScrollArea.ClipRect.Height);
			this.playedScrollArea.invalidate();
			this.playedScrollBar.invalidate();
		}

		// Token: 0x060033BC RID: 13244 RVA: 0x002A9F74 File Offset: 0x002A8174
		private void availableScrollBarMoved()
		{
			int value = this.availableScrollBar.Value;
			this.availableScrollArea.Position = new Point(this.availableScrollArea.X, this.scrY + this.scrHeight + 60 - value);
			this.availableScrollArea.ClipRect = new Rectangle(this.availableScrollArea.ClipRect.X, value, this.availableScrollArea.ClipRect.Width, this.availableScrollArea.ClipRect.Height);
			this.availableScrollArea.invalidate();
			this.availableScrollBar.invalidate();
		}

		// Token: 0x060033BD RID: 13245 RVA: 0x000250AC File Offset: 0x000232AC
		private void mouseWheelMoved(int delta)
		{
			if (this.playedScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.playedScrollBar.scrollDown(10);
					return;
				}
				if (delta > 0)
				{
					this.playedScrollBar.scrollUp(10);
				}
			}
		}

		// Token: 0x060033BE RID: 13246 RVA: 0x000250DE File Offset: 0x000232DE
		private void availableMouseWheelMoved(int delta)
		{
			if (this.availableScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.availableScrollBar.scrollDown(10);
					return;
				}
				if (delta > 0)
				{
					this.availableScrollBar.scrollUp(10);
				}
			}
		}

		// Token: 0x060033BF RID: 13247 RVA: 0x002AA01C File Offset: 0x002A821C
		public void BuildOnlineWorldList(List<WorldInfo> playedList, List<WorldInfo> availableList)
		{
			this.loggedInWorldControls.Clear();
			this.playedScrollArea.clearControls();
			this.availableScrollArea.clearControls();
			if (playedList.Count <= 0 && availableList.Count <= 0)
			{
				return;
			}
			availableList.Sort(new XmlRpcAuthResponse.WorldsComparer());
			playedList.Sort(new XmlRpcAuthResponse.PlayedWorldsComparer
			{
				sortByName = this.sortPlayedWorldsByName
			});
			new DateTime(2019, 7, 4, 15, 0, 0);
			int num = 0;
			bool flag = false;
			if (playedList.Count > 0)
			{
				this.playedScrollArea.Visible = true;
				this.playedScrollBar.Visible = true;
				this.playedWheelOverlay.Enabled = true;
				this.lblPlayedWorlds.Visible = true;
				this.newUserPanel.Visible = false;
				for (int i = 0; i < playedList.Count; i++)
				{
					if (num > 0)
					{
						num += 10;
					}
					WorldListEntry worldListEntry = new WorldListEntry();
					worldListEntry.Init(playedList[i], flag, this);
					worldListEntry.Position = new Point(0, num);
					flag = !flag;
					this.playedScrollArea.addControl(worldListEntry);
					num += worldListEntry.Height;
					if (i == 0)
					{
						this.mouseWheelDelta = 10;
					}
				}
				num += 10;
				this.playedScrollArea.Size = new Size(this.playedScrollArea.Width, num);
				if (num <= this.playedScrollBar.Height)
				{
					this.playedScrollBar.Visible = false;
				}
				else
				{
					this.playedScrollBar.Visible = true;
					this.playedScrollBar.NumVisibleLines = this.playedScrollBar.Height;
					this.playedScrollBar.Max = num - this.playedScrollBar.Height;
				}
				this.playedScrollArea.invalidate();
				this.playedScrollBar.invalidate();
			}
			else
			{
				this.playedScrollArea.Visible = false;
				this.playedScrollBar.Visible = false;
				this.lblPlayedWorlds.Visible = false;
				this.playedWheelOverlay.Enabled = false;
				foreach (WorldInfo worldInfo in availableList)
				{
					if (worldInfo.Online && worldInfo.AvailableToJoin)
					{
						this.newUserPanel.Visible = true;
						this.lblSuggestedName.Text = ProfileLoginWindow.getWorldShortDesc(worldInfo);
						this.btnJoinSuggested.Tag = worldInfo;
						this.btnSuggestedInfo.Data = worldInfo.KingdomsWorldID;
						break;
					}
				}
			}
			num = 0;
			flag = false;
			for (int j = 0; j < availableList.Count; j++)
			{
				if (num > 0)
				{
					num += 10;
				}
				WorldListEntry worldListEntry2 = new WorldListEntry();
				worldListEntry2.Init(availableList[j], flag, this);
				worldListEntry2.Position = new Point(0, num);
				flag = !flag;
				this.availableScrollArea.addControl(worldListEntry2);
				num += worldListEntry2.Height;
			}
			num += 10;
			this.availableScrollArea.Size = new Size(this.availableScrollArea.Width, num);
			if (num <= this.availableScrollBar.Height)
			{
				this.availableScrollBar.Visible = false;
			}
			else
			{
				this.availableScrollBar.Visible = true;
				this.availableScrollBar.NumVisibleLines = this.availableScrollBar.Height;
				this.availableScrollBar.Max = num - this.availableScrollBar.Height;
			}
			this.availableScrollArea.invalidate();
			this.availableScrollBar.invalidate();
			base.Invalidate();
		}

		// Token: 0x060033C0 RID: 13248 RVA: 0x002AA38C File Offset: 0x002A858C
		public void BuildOnlineWorldList(List<WorldInfo> list)
		{
			this.loggedInWorldControls.Clear();
			this.playedScrollArea.clearControls();
			if (list.Count <= 0)
			{
				return;
			}
			DateTime t = new DateTime(2019, 7, 4, 15, 0, 0);
			bool playing = list[0].Playing;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
				CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
				CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
				if (list[i].Playing != playing)
				{
					playing = list[i].Playing;
					num += 20;
				}
				if ((i & 1) == 0)
				{
					csdimage3.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				else
				{
					csdimage3.Image = GFXLibrary.lineitem_strip_02_light;
				}
				csdimage3.Position = new Point(0, num);
				this.loggedInWorldControls.Add(csdimage3);
				num2 = num + 40;
				csdimage.Y = num + 7;
				csdimage2.Y = num + 4;
				csdlabel.Y = num + 9;
				csdlabel2.Y = num + 9;
				csdlabel.Width = 144;
				csdlabel.Height = this.worldControlHeight;
				csdlabel2.Width = 105;
				csdlabel2.Height = this.worldControlHeight;
				csdlabel.Text = ProfileLoginWindow.getWorldShortDesc(list[i]);
				csdimage.Image = GFXLibrary.getLoginWorldFlag(list[i].Supportculture);
				csdimage.Width = csdimage.Image.Width;
				csdimage.Height = csdimage.Image.Height;
				csdimage2.Image = GFXLibrary.getLoginWorldMap(list[i].MapCulture);
				csdimage2.Width = csdimage2.Image.Width;
				csdimage2.Height = csdimage2.Image.Height;
				string supportculture = list[i].Supportculture;
				if (supportculture != null)
				{
					uint num3 = PrivateImplementationDetails.ComputeStringHash(supportculture);
					if (num3 <= 1195724803U)
					{
						if (num3 <= 1164435231U)
						{
							if (num3 != 507104076U)
							{
								if (num3 != 1092248970U)
								{
									if (num3 == 1164435231U)
									{
										if (supportculture == "zh")
										{
											csdimage.CustomTooltipID = 4046;
										}
									}
								}
								else if (supportculture == "en")
								{
									csdimage.CustomTooltipID = 4001;
								}
							}
							else if (supportculture == "pl=")
							{
								csdimage.CustomTooltipID = 4020;
							}
						}
						else if (num3 != 1176137065U)
						{
							if (num3 != 1194886160U)
							{
								if (num3 == 1195724803U)
								{
									if (supportculture == "tr")
									{
										csdimage.CustomTooltipID = 4023;
									}
								}
							}
							else if (supportculture == "it")
							{
								csdimage.CustomTooltipID = 4027;
							}
						}
						else if (supportculture == "es")
						{
							csdimage.CustomTooltipID = 4016;
						}
					}
					else
					{
						if (num3 <= 1229868421U)
						{
							if (num3 != 1209692303U)
							{
								if (num3 != 1213488160U)
								{
									if (num3 != 1229868421U)
									{
										goto IL_493;
									}
									if (!(supportculture == "ph"))
									{
										goto IL_493;
									}
								}
								else
								{
									if (!(supportculture == "ru"))
									{
										goto IL_493;
									}
									csdimage.CustomTooltipID = 4004;
									goto IL_493;
								}
							}
							else
							{
								if (!(supportculture == "eu"))
								{
									goto IL_493;
								}
								csdimage.CustomTooltipID = 4031;
								goto IL_493;
							}
						}
						else if (num3 <= 1531424278U)
						{
							if (num3 != 1461901041U)
							{
								if (num3 != 1531424278U)
								{
									goto IL_493;
								}
								if (!(supportculture == "wd"))
								{
									goto IL_493;
								}
							}
							else
							{
								if (!(supportculture == "fr"))
								{
									goto IL_493;
								}
								csdimage.CustomTooltipID = 4003;
								goto IL_493;
							}
						}
						else if (num3 != 1545391778U)
						{
							if (num3 != 1565420801U)
							{
								goto IL_493;
							}
							if (!(supportculture == "pt"))
							{
								goto IL_493;
							}
							csdimage.CustomTooltipID = 4035;
							goto IL_493;
						}
						else
						{
							if (!(supportculture == "de"))
							{
								goto IL_493;
							}
							csdimage.CustomTooltipID = 4002;
							goto IL_493;
						}
						csdimage.CustomTooltipID = 4041;
					}
				}
				IL_493:
				string mapCulture = list[i].MapCulture;
				if (mapCulture != null)
				{
					uint num3 = PrivateImplementationDetails.ComputeStringHash(mapCulture);
					if (num3 <= 1195724803U)
					{
						if (num3 <= 1164435231U)
						{
							if (num3 != 1092248970U)
							{
								if (num3 != 1162757945U)
								{
									if (num3 == 1164435231U)
									{
										if (mapCulture == "zh")
										{
											csdimage2.CustomTooltipID = 4047;
										}
									}
								}
								else if (mapCulture == "pl")
								{
									csdimage2.CustomTooltipID = 4021;
								}
							}
							else if (mapCulture == "en")
							{
								csdimage2.CustomTooltipID = 4005;
							}
						}
						else if (num3 <= 1178800089U)
						{
							if (num3 != 1176137065U)
							{
								if (num3 == 1178800089U)
								{
									if (mapCulture == "us")
									{
										csdimage2.CustomTooltipID = 4030;
									}
								}
							}
							else if (mapCulture == "es")
							{
								csdimage2.CustomTooltipID = 4017;
							}
						}
						else if (num3 != 1194886160U)
						{
							if (num3 == 1195724803U)
							{
								if (mapCulture == "tr")
								{
									csdimage2.CustomTooltipID = 4024;
								}
							}
						}
						else if (mapCulture == "it")
						{
							csdimage2.CustomTooltipID = 4028;
						}
					}
					else if (num3 <= 1245513207U)
					{
						if (num3 <= 1213488160U)
						{
							if (num3 != 1209692303U)
							{
								if (num3 == 1213488160U)
								{
									if (mapCulture == "ru")
									{
										csdimage2.CustomTooltipID = 4008;
									}
								}
							}
							else if (mapCulture == "eu")
							{
								csdimage2.CustomTooltipID = 4032;
							}
						}
						else if (num3 != 1229868421U)
						{
							if (num3 == 1245513207U)
							{
								if (mapCulture == "kg")
								{
									csdimage2.CustomTooltipID = 4049;
								}
							}
						}
						else if (mapCulture == "ph")
						{
							csdimage2.CustomTooltipID = 4043;
						}
					}
					else if (num3 <= 1531424278U)
					{
						if (num3 != 1461901041U)
						{
							if (num3 == 1531424278U)
							{
								if (mapCulture == "wd")
								{
									csdimage2.CustomTooltipID = 4042;
								}
							}
						}
						else if (mapCulture == "fr")
						{
							csdimage2.CustomTooltipID = 4007;
						}
					}
					else if (num3 != 1545391778U)
					{
						if (num3 == 1565420801U)
						{
							if (mapCulture == "pt")
							{
								csdimage2.CustomTooltipID = 4036;
							}
						}
					}
					else if (mapCulture == "de")
					{
						csdimage2.CustomTooltipID = 4006;
					}
				}
				csdlabel.X = 24;
				csdimage.X = csdlabel.X - 20 - 57 + csdlabel.Width + 8 + 75 + 30;
				csdimage2.X = csdimage.X + csdimage.Width + 8 + 75;
				csdlabel2.X = csdimage2.X + csdimage2.Width + 8 + 75 - 40;
				if (list[i].ShortDesc.Contains("******"))
				{
					csdimage4.Image = GFXLibrary.age_seventh_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4045;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (list[i].ShortDesc.Contains("*****"))
				{
					csdimage4.Image = GFXLibrary.age_sixth_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4044;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (list[i].ShortDesc.Contains("****"))
				{
					csdimage4.Image = GFXLibrary.age_fifth_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4039;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (list[i].ShortDesc.Contains("***"))
				{
					csdimage4.Image = GFXLibrary.age_fourth_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4034;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (list[i].ShortDesc.Contains("**"))
				{
					csdimage4.Image = GFXLibrary.age_third_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4026;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (list[i].ShortDesc.Contains("*"))
				{
					csdimage4.Image = GFXLibrary.age_second_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4019;
					this.loggedInWorldControls.Add(csdimage4);
				}
				else if (!ProfileLoginWindow.isAIWorld(list[i].KingdomsWorldID) && !ProfileLoginWindow.isSpecialWorld(list[i].KingdomsWorldID))
				{
					csdimage4.Image = GFXLibrary.age_first_age_28x16;
					csdimage4.Position = new Point(csdimage.X - 80, num + 7 - 5);
					csdimage4.CustomTooltipID = 4038;
					this.loggedInWorldControls.Add(csdimage4);
				}
				if (list[i].Online)
				{
					csdlabel2.Text = this.strOnline;
					csdlabel2.Color = global::ARGBColors.Green;
					CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
					csdbutton.Width = this.worldControlWidth;
					csdbutton.Height = this.worldControlHeight;
					csdbutton.Y = num + 5;
					csdbutton.Tag = list[i];
					csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnWorldAction_Click), "WorldSelectPopupPanel_world_select");
					if (list[i].Playing)
					{
						csdbutton.ImageNorm = this.PlayImage;
						csdbutton.ImageOver = this.PlayImageOver;
					}
					else if (list[i].AvailableToJoin)
					{
						csdbutton.ImageNorm = this.JoinImage;
						csdbutton.ImageOver = this.JoinImageOver;
					}
					else
					{
						csdbutton.ImageNorm = this.ClosedImage;
						csdbutton.ImageOver = this.ClosedImage;
						csdbutton.setClickDelegate(null);
						csdbutton.Active = false;
					}
					csdbutton.Width = csdbutton.ImageNorm.Width;
					csdbutton.Height = csdbutton.ImageNorm.Height;
					csdbutton.X = 596 - csdbutton.Width;
					this.loggedInWorldControls.Add(csdbutton);
					if (csdbutton.Active)
					{
						CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
						csdbutton2.ImageNorm = GFXLibrary.help_normal;
						csdbutton2.ImageOver = GFXLibrary.help_over;
						csdbutton2.ImageClick = GFXLibrary.help_pushed;
						csdbutton2.Position = new Point(608, num + 8);
						csdbutton2.Data = list[i].KingdomsWorldID;
						csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoOverlayOpenedClick));
						this.loggedInWorldControls.Add(csdbutton2);
					}
					csdlabel2.CustomTooltipID = 4010;
				}
				else
				{
					if (list[i].KingdomsWorldID == 2550 && DateTime.UtcNow > t)
					{
						csdlabel2.Text = this.strWorldEnded;
						csdlabel2.Width = 300;
					}
					else
					{
						csdlabel2.Text = this.strOffline;
						csdlabel2.Color = global::ARGBColors.Red;
					}
					csdlabel2.CustomTooltipID = 4009;
				}
				if (WorldSelectPopupPanel.showSpecialWorlds <= 0)
				{
					this.loggedInWorldControls.Add(csdimage);
				}
				this.loggedInWorldControls.Add(csdimage2);
				this.loggedInWorldControls.Add(csdlabel);
				this.loggedInWorldControls.Add(csdlabel2);
				num += 40;
			}
			foreach (CustomSelfDrawPanel.CSDControl control in this.loggedInWorldControls)
			{
				this.playedScrollArea.addControl(control);
			}
			this.playedScrollArea.Size = new Size(this.playedScrollArea.Width, num2);
			if (num2 < this.playedScrollBar.Height)
			{
				this.playedScrollBar.Visible = false;
			}
			else
			{
				this.playedScrollBar.Visible = true;
				this.playedScrollBar.NumVisibleLines = this.playedScrollBar.Height;
				this.playedScrollBar.Max = num2 - this.playedScrollBar.Height;
			}
			this.playedScrollArea.invalidate();
			this.playedScrollBar.invalidate();
			base.Invalidate();
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x002AB210 File Offset: 0x002A9410
		public void btnWorldAction_Click()
		{
			WorldInfo i = (WorldInfo)this.ClickedControl.Tag;
			this.closeClick();
			Program.profileLogin.btnWorldAction_Click(i);
		}

		// Token: 0x060033C2 RID: 13250 RVA: 0x002AB240 File Offset: 0x002A9440
		private void ownToggled()
		{
			WorldSelectPopupPanel.showOwnWorldsStatus = this.showOwnWorlds.Checked;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture(this.lastLang, WorldSelectPopupPanel.showOwnWorldsStatus, WorldSelectPopupPanel.showSpecialWorlds);
			this.BuildOnlineWorldList(worldsBySupportCulture);
		}

		// Token: 0x060033C3 RID: 13251 RVA: 0x002AB280 File Offset: 0x002A9480
		public void infoOverlayOpenedClick()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			List<WorldInfo> worldsBySupportCulture = Program.profileLogin.GetWorldsBySupportCulture("", true, 0);
			foreach (WorldInfo worldInfo in worldsBySupportCulture)
			{
				if (worldInfo.KingdomsWorldID == data)
				{
					this.openInfoOverlay(worldInfo);
					break;
				}
			}
		}

		// Token: 0x060033C4 RID: 13252 RVA: 0x002AB304 File Offset: 0x002A9504
		private void openInfoOverlay(WorldInfo info)
		{
			string worldShortDesc = ProfileLoginWindow.getWorldShortDesc(info);
			this.infoOverlay.Visible = true;
			this.infoOverlayAgeIcon.Visible = false;
			if (WorldSelectPopupPanel.InfoOverlayHeadings[info.KingdomsWorldID] == null)
			{
				Image value = WebStyleButtonImage.Generate(260, this.WebButtonheight + 4, worldShortDesc, this.WebTextFontBoldCond, global::ARGBColors.Black, global::ARGBColors.Transparent, this.WebButtonRadius);
				WorldSelectPopupPanel.InfoOverlayHeadings[info.KingdomsWorldID] = value;
			}
			this.infoOverlayHeading.Image = (Image)WorldSelectPopupPanel.InfoOverlayHeadings[info.KingdomsWorldID];
			this.infoOverlayDurationValue.Text = "?";
			this.infoOverlayGameAgeValue.Text = "?";
			this.infoOverlayHousesValue.Text = "?";
			this.infoOverlayActivePlayersValue.Text = "?";
			if (WorldSelectPopupPanel.InfoOverlayData[info.KingdomsWorldID] == null)
			{
				URLs.GameRPCAddress = info.HostExt;
				RemoteServices.Instance.init(URLs.GameRPC);
				RemoteServices.Instance.set_WorldInfo_UserCallBack(new RemoteServices.WorldInfo_UserCallBack(this.WorldInfoCallback));
				RemoteServices.Instance.WorldInfo();
				return;
			}
			this.infoOverlayFillinData((WorldInfoData)WorldSelectPopupPanel.InfoOverlayData[info.KingdomsWorldID]);
		}

		// Token: 0x060033C5 RID: 13253 RVA: 0x00025110 File Offset: 0x00023310
		private void infoOverlayCloseClicked()
		{
			this.infoOverlay.Visible = false;
		}

		// Token: 0x060033C6 RID: 13254 RVA: 0x002AB448 File Offset: 0x002A9648
		private void WorldInfoCallback(WorldInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.worldInfo != null && returnData.worldInfo.worldID != 0)
				{
					WorldSelectPopupPanel.InfoOverlayData[returnData.worldInfo.worldID] = returnData.worldInfo;
					this.infoOverlayFillinData(returnData.worldInfo);
					return;
				}
				this.infoOverlay.Visible = false;
			}
		}

		// Token: 0x060033C7 RID: 13255 RVA: 0x002AB4A8 File Offset: 0x002A96A8
		private void infoOverlayFillinData(WorldInfoData data)
		{
			if (data == null || data.worldID == 0)
			{
				this.infoOverlay.Visible = false;
				return;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.infoOverlayDurationValue.Text = data.daysOld.ToString("N", nfi);
			if (data.worldID >= 2500 && data.worldID <= 2599)
			{
				this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_Domination", "Domination");
				this.infoOverlayGameAgeValue.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			}
			else if (data.worldID >= 3500 && data.worldID <= 3599)
			{
				this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_AI", "AI");
				data.age = 0;
			}
			else if (data.worldID % 100 < 50)
			{
				switch (data.age)
				{
				case 0:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_1stAge", "1st Age");
					break;
				case 1:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_2ndAge", "2nd Age");
					break;
				case 2:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_3rdAge", "3rd Age");
					break;
				case 3:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_4thAge", "4th Age");
					break;
				case 4:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_5thAge", "5th Age");
					break;
				case 5:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_6thAge", "6th Age");
					break;
				case 6:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_FinalAge", "Final Age");
					break;
				}
			}
			else
			{
				switch (data.age)
				{
				case 0:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_1stEra", "1st Era");
					break;
				case 1:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_2ndEra", "2nd Era");
					break;
				case 2:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_3rdEra", "3rd Era");
					break;
				case 3:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_4thEra", "4th Era");
					break;
				case 4:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_5thEra", "5th Era");
					break;
				case 5:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_6thEra", "6th Era");
					break;
				case 6:
					this.infoOverlayGameAgeValue.Text = SK.Text("WorldSelect_FinalEra", "Final Era");
					break;
				}
			}
			this.infoOverlayHousesValue.Text = data.housesInGlory.ToString("N", nfi);
			this.infoOverlayActivePlayersValue.Text = data.activePlayers.ToString("N", nfi);
			switch (data.age)
			{
			case 1:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_second_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4026;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			case 2:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_third_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4026;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			case 3:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_fourth_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4034;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			case 4:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_fifth_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4039;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			case 5:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_sixth_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4044;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			case 6:
				this.infoOverlayAgeIcon.Image = GFXLibrary.age_seventh_age_x65;
				this.infoOverlayAgeIcon.setSizeToImage();
				this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
				this.infoOverlayAgeIcon.CustomTooltipID = 4045;
				this.infoOverlayAgeIcon.Visible = true;
				break;
			default:
				if (data.worldID < 2500)
				{
					this.infoOverlayAgeIcon.Image = GFXLibrary.age_first_age_x65;
					this.infoOverlayAgeIcon.setSizeToImage();
					this.infoOverlayAgeIcon.Position = new Point(this.infoOverlayPanel.Width / 2 - this.infoOverlayAgeIcon.Width / 2, 40);
					this.infoOverlayAgeIcon.CustomTooltipID = 4038;
					this.infoOverlayPanel.addControl(this.infoOverlayAgeIcon);
					this.infoOverlayAgeIcon.Visible = true;
				}
				break;
			}
			this.infoOverlayPanel.invalidate();
		}

		// Token: 0x04004051 RID: 16465
		private const int extraWidth = 124;

		// Token: 0x04004052 RID: 16466
		private const int extraHeight = 160;

		// Token: 0x04004053 RID: 16467
		private const int columnExtra = 50;

		// Token: 0x04004054 RID: 16468
		private IContainer components;

		// Token: 0x04004055 RID: 16469
		private static bool showOwnWorldsStatus = true;

		// Token: 0x04004056 RID: 16470
		private static int showSpecialWorlds = -1;

		// Token: 0x04004057 RID: 16471
		public static int defaultWidth = 824;

		// Token: 0x04004058 RID: 16472
		public static int defaultHeight = 605;

		// Token: 0x04004059 RID: 16473
		private string strSelect = SK.Text("WORLD_Select_Standard", "Select Standard Worlds");

		// Token: 0x0400405A RID: 16474
		private string strSelectSpecial = SK.Text("WORLD_Select_Special", "Select Special Worlds");

		// Token: 0x0400405B RID: 16475
		private string strSelectAI = SK.Text("WORLD_Select_AI", "Select AI Worlds");

		// Token: 0x0400405C RID: 16476
		private string strStandardWorlds = SK.Text("WORLD_Standard_Worlds", "Standard Worlds");

		// Token: 0x0400405D RID: 16477
		private string strSpecialWorlds = SK.Text("WORLD_Special_Worlds", "Special Worlds");

		// Token: 0x0400405E RID: 16478
		private string strAIWorlds = SK.Text("WORLD_Special_AI", "AI Worlds");

		// Token: 0x0400405F RID: 16479
		private string strClose = SK.Text("GENERIC_Close", "Close");

		// Token: 0x04004060 RID: 16480
		private string strOnline = SK.Text("WORLD_Online", "Online");

		// Token: 0x04004061 RID: 16481
		private string strWorldEnded = SK.Text("WorldEnded", "This World has ended.");

		// Token: 0x04004062 RID: 16482
		private string strOffline = SK.Text("WORLD_Offline", "Offline");

		// Token: 0x04004063 RID: 16483
		private string strJoin = SK.Text("WORLD_Join", "Join");

		// Token: 0x04004064 RID: 16484
		private string strPlay = SK.Text("WORLD_Play", "Play");

		// Token: 0x04004065 RID: 16485
		private string strClosed = SK.Text("FactionInvites_Membership_closed", "Closed");

		// Token: 0x04004066 RID: 16486
		private string strSortByTime = SK.Text("WORLD_Sort_By_Time", "Sort By Last Login");

		// Token: 0x04004067 RID: 16487
		private string strSortByName = SK.Text("Card_Sorting_Name", "Sort By Name");

		// Token: 0x04004068 RID: 16488
		private Font WebTextFontBold = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 10f, FontStyle.Bold);

		// Token: 0x04004069 RID: 16489
		private Font WebTextFontBoldCond = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 10f, FontStyle.Bold);

		// Token: 0x0400406A RID: 16490
		private Color WebButtonblue = Color.FromArgb(85, 145, 203);

		// Token: 0x0400406B RID: 16491
		private Color WebButtonRed = Color.FromArgb(160, 0, 0);

		// Token: 0x0400406C RID: 16492
		private Color WebButtonRedFaded = Color.FromArgb(160, 96, 96);

		// Token: 0x0400406D RID: 16493
		private Color WebButtonYellow = Color.FromArgb(225, 225, 0);

		// Token: 0x0400406E RID: 16494
		private Color WebButtonYellow2 = Color.FromArgb(255, 238, 8);

		// Token: 0x0400406F RID: 16495
		private Color WebButtonGrey = Color.FromArgb(225, 225, 225);

		// Token: 0x04004070 RID: 16496
		private int WebButtonWidth = 120;

		// Token: 0x04004071 RID: 16497
		private int WebButtonheight = 22;

		// Token: 0x04004072 RID: 16498
		private int WebButtonRadius = 10;

		// Token: 0x04004073 RID: 16499
		public int numSpecialWorlds = -1;

		// Token: 0x04004074 RID: 16500
		public static Image closeImage;

		// Token: 0x04004075 RID: 16501
		public static Image closeImageOver;

		// Token: 0x04004076 RID: 16502
		public static Image selectImageSelected;

		// Token: 0x04004077 RID: 16503
		public static Image selectImage;

		// Token: 0x04004078 RID: 16504
		public static Image selectImageOver;

		// Token: 0x04004079 RID: 16505
		public static Image selectSpecialImage;

		// Token: 0x0400407A RID: 16506
		public static Image selectSpecialImageSelected;

		// Token: 0x0400407B RID: 16507
		public static Image selectSpecialImageOver;

		// Token: 0x0400407C RID: 16508
		public static Image sortByNameImage;

		// Token: 0x0400407D RID: 16509
		public static Image sortByNameImageOver;

		// Token: 0x0400407E RID: 16510
		public static Image sortByTimeImage;

		// Token: 0x0400407F RID: 16511
		public static Image sortByTimeImageOver;

		// Token: 0x04004080 RID: 16512
		public static Image selectAIImage;

		// Token: 0x04004081 RID: 16513
		public static Image selectAIImageSelected;

		// Token: 0x04004082 RID: 16514
		public static Image selectAIImageOver;

		// Token: 0x04004083 RID: 16515
		public static Image joinImage;

		// Token: 0x04004084 RID: 16516
		public static Image joinImageOver;

		// Token: 0x04004085 RID: 16517
		public static Image playImage;

		// Token: 0x04004086 RID: 16518
		public static Image playImageOver;

		// Token: 0x04004087 RID: 16519
		public static Image closedImage;

		// Token: 0x04004088 RID: 16520
		private CustomSelfDrawPanel.CSDImage backgroundBorder = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04004089 RID: 16521
		private CustomSelfDrawPanel.CSDButton playedSortingButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400408A RID: 16522
		private CustomSelfDrawPanel.CSDVertScrollBar playedScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400408B RID: 16523
		private CustomSelfDrawPanel.CSDArea playedScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400408C RID: 16524
		private CustomSelfDrawPanel.CSDControl playedWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x0400408D RID: 16525
		private CustomSelfDrawPanel.CSDVertScrollBar availableScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400408E RID: 16526
		private CustomSelfDrawPanel.CSDArea availableScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400408F RID: 16527
		private CustomSelfDrawPanel.CSDControl availableMouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04004090 RID: 16528
		private CustomSelfDrawPanel.CSDLabel lblPlayedWorlds = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04004091 RID: 16529
		private CustomSelfDrawPanel.CSDLabel lblAvailableWorlds = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04004092 RID: 16530
		private CustomSelfDrawPanel.CSDCheckBox showOwnWorlds = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04004093 RID: 16531
		private CustomSelfDrawPanel.CSDFill selectedWorldRect = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04004094 RID: 16532
		private CustomSelfDrawPanel.CSDFill selectedWorldRect2 = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04004095 RID: 16533
		private CustomSelfDrawPanel.CSDArea languageArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04004096 RID: 16534
		private CustomSelfDrawPanel.CSDLabel lblLanguageSelect = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04004097 RID: 16535
		private CustomSelfDrawPanel.CSDFill newUserPanel = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04004098 RID: 16536
		private CustomSelfDrawPanel.CSDLabel lblSuggestedHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04004099 RID: 16537
		private CustomSelfDrawPanel.CSDLabel lblSuggestedName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400409A RID: 16538
		private CustomSelfDrawPanel.CSDButton btnJoinSuggested = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400409B RID: 16539
		private CustomSelfDrawPanel.CSDButton btnSuggestedInfo = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400409C RID: 16540
		private CustomSelfDrawPanel.CSDFill infoOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400409D RID: 16541
		private CustomSelfDrawPanel.CSDFill infoOverlayPanel = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400409E RID: 16542
		private CustomSelfDrawPanel.CSDButton infoOverlayClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400409F RID: 16543
		private CustomSelfDrawPanel.CSDImage infoOverlayHeading = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040A0 RID: 16544
		private CustomSelfDrawPanel.CSDImage infoOverlayCornerLeft = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040A1 RID: 16545
		private CustomSelfDrawPanel.CSDImage infoOverlayCornerRight = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040A2 RID: 16546
		private CustomSelfDrawPanel.CSDLabel infoOverlayDuration = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A3 RID: 16547
		private CustomSelfDrawPanel.CSDLabel infoOverlayDurationValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A4 RID: 16548
		private CustomSelfDrawPanel.CSDLabel infoOverlayGameAge = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A5 RID: 16549
		private CustomSelfDrawPanel.CSDLabel infoOverlayGameAgeValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A6 RID: 16550
		private CustomSelfDrawPanel.CSDLabel infoOverlayHouses = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A7 RID: 16551
		private CustomSelfDrawPanel.CSDLabel infoOverlayHousesValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A8 RID: 16552
		private CustomSelfDrawPanel.CSDLabel infoOverlayActivePlayers = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040A9 RID: 16553
		private CustomSelfDrawPanel.CSDLabel infoOverlayActivePlayersValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040AA RID: 16554
		private CustomSelfDrawPanel.CSDImage infoOverlayAgeIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040040AB RID: 16555
		private static SparseArray InfoOverlayHeadings = new SparseArray();

		// Token: 0x040040AC RID: 16556
		private static SparseArray InfoOverlayData = new SparseArray();

		// Token: 0x040040AD RID: 16557
		private CustomSelfDrawPanel.CSDLabel supportLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040040AE RID: 16558
		private int scrWidth = 669;

		// Token: 0x040040AF RID: 16559
		private int scrHeight;

		// Token: 0x040040B0 RID: 16560
		private int scrX = 75;

		// Token: 0x040040B1 RID: 16561
		private int scrY = 90;

		// Token: 0x040040B2 RID: 16562
		private string lastLang = "";

		// Token: 0x040040B3 RID: 16563
		private CustomSelfDrawPanel.CSDImage titleImage;

		// Token: 0x040040B4 RID: 16564
		private CustomSelfDrawPanel.CSDButton titleButton;

		// Token: 0x040040B5 RID: 16565
		private CustomSelfDrawPanel.CSDButton titleButton2;

		// Token: 0x040040B6 RID: 16566
		private bool pulseTitleButton;

		// Token: 0x040040B7 RID: 16567
		public int pulse;

		// Token: 0x040040B8 RID: 16568
		private int mouseWheelDelta;

		// Token: 0x040040B9 RID: 16569
		public List<CustomSelfDrawPanel.CSDControl> loggedInWorldControls = new List<CustomSelfDrawPanel.CSDControl>();

		// Token: 0x040040BA RID: 16570
		private int worldControlWidth = 80;

		// Token: 0x040040BB RID: 16571
		private int worldControlHeight = 24;

		// Token: 0x040040BC RID: 16572
		private bool sortPlayedWorldsByName;
	}
}
