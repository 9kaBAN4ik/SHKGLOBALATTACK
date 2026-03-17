using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004BC RID: 1212
	public class VacationCancelPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06002CBD RID: 11453 RVA: 0x00020D1E File Offset: 0x0001EF1E
		public Image HeaderImage
		{
			get
			{
				if (VacationCancelPopupPanel.headerImage == null)
				{
					VacationCancelPopupPanel.headerImage = WebStyleButtonImage.Generate(500, 30, this.TextCreateHeader, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return VacationCancelPopupPanel.headerImage;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06002CBE RID: 11454 RVA: 0x0023ABFC File Offset: 0x00238DFC
		public Image CloseImage
		{
			get
			{
				if (VacationCancelPopupPanel.closeImage == null)
				{
					VacationCancelPopupPanel.closeImage = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return VacationCancelPopupPanel.closeImage;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06002CBF RID: 11455 RVA: 0x0023AC48 File Offset: 0x00238E48
		public Image CloseImageOver
		{
			get
			{
				if (VacationCancelPopupPanel.closeImageOver == null)
				{
					VacationCancelPopupPanel.closeImageOver = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return VacationCancelPopupPanel.closeImageOver;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06002CC0 RID: 11456 RVA: 0x0023AC94 File Offset: 0x00238E94
		public Image CancelImage
		{
			get
			{
				if (VacationCancelPopupPanel.cancelImage == null)
				{
					VacationCancelPopupPanel.cancelImage = WebStyleButtonImage.Generate(400, this.WebButtonheight, this.strCancel, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return VacationCancelPopupPanel.cancelImage;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06002CC1 RID: 11457 RVA: 0x0023ACE0 File Offset: 0x00238EE0
		public Image CancelImageOver
		{
			get
			{
				if (VacationCancelPopupPanel.cancelImageOver == null)
				{
					VacationCancelPopupPanel.cancelImageOver = WebStyleButtonImage.Generate(400, this.WebButtonheight, this.strCancel, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return VacationCancelPopupPanel.cancelImageOver;
			}
		}

		// Token: 0x06002CC2 RID: 11458 RVA: 0x00020D5A File Offset: 0x0001EF5A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CC3 RID: 11459 RVA: 0x00020D79 File Offset: 0x0001EF79
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06002CC4 RID: 11460 RVA: 0x0023AD2C File Offset: 0x00238F2C
		public VacationCancelPopupPanel()
		{
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002CC5 RID: 11461 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		private void AddControlToPanel(CustomSelfDrawPanel.CSDControl c)
		{
			base.addControl(c);
		}

		// Token: 0x06002CC6 RID: 11462 RVA: 0x0023AE68 File Offset: 0x00239068
		public void init(int secondsLeft, int secondsLeftToCancel, bool canCancel)
		{
			secondsLeft += 30;
			secondsLeftToCancel += 30;
			this.m_secondsLeft = secondsLeft;
			this.m_secondsLeftToCancel = secondsLeftToCancel;
			base.clearControls();
			base.Controls.Clear();
			this.BackColor = global::ARGBColors.White;
			this.HeaderTitle = new CustomSelfDrawPanel.CSDImage();
			this.HeaderTitle.Image = this.HeaderImage;
			this.HeaderTitle.Position = new Point((base.Width - this.HeaderTitle.Width) / 2, 32);
			this.AddControlToPanel(this.HeaderTitle);
			this.expiresInLabel.Text = SK.Text("VACATION_Expires_In", "Vacation Mode Expires in") + " - " + VillageMap.createBuildTimeString(secondsLeft);
			this.expiresInLabel.Position = new Point(0, 120);
			this.expiresInLabel.Size = new Size(base.Width, 30);
			this.expiresInLabel.Color = global::ARGBColors.Black;
			this.expiresInLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.expiresInLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.AddControlToPanel(this.expiresInLabel);
			this.cancelButton.ImageNorm = this.CancelImage;
			this.cancelButton.ImageOver = this.CancelImageOver;
			this.cancelButton.Position = new Point(107, 200);
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick));
			this.cancelButton.Visible = false;
			this.AddControlToPanel(this.cancelButton);
			if (canCancel)
			{
				this.cancelButton.Visible = false;
			}
			else
			{
				this.cancelInLabel.Text = SK.Text("VACATION_Cancel_In", "You can cancel in") + " - " + VillageMap.createBuildTimeString(secondsLeftToCancel);
				this.cancelInLabel.Position = new Point(0, 200);
				this.cancelInLabel.Size = new Size(base.Width, 30);
				this.cancelInLabel.Color = global::ARGBColors.Black;
				this.cancelInLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.cancelInLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.cancelInLabel.Visible = true;
				this.AddControlToPanel(this.cancelInLabel);
			}
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = this.CloseImage;
			csdbutton.ImageOver = this.CloseImageOver;
			csdbutton.Position = new Point(400, 300);
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			this.AddControlToPanel(csdbutton);
			base.Invalidate();
		}

		// Token: 0x06002CC7 RID: 11463 RVA: 0x0023B108 File Offset: 0x00239308
		public void update()
		{
			TimeSpan timeSpan = DateTime.Now - this.m_startTime;
			int num = this.m_secondsLeft - (int)timeSpan.TotalSeconds;
			if (num < 0)
			{
				InterfaceMgr.Instance.closeVacationCancelPopupWindow();
			}
			else
			{
				this.expiresInLabel.TextDiffOnly = SK.Text("VACATION_Expires_In", "Vacation Mode Expires in") + " - " + VillageMap.createBuildTimeString(num);
			}
			int num2 = this.m_secondsLeftToCancel - (int)timeSpan.TotalSeconds;
			if (num2 < 0)
			{
				if (!this.cancelButton.Visible)
				{
					this.cancelButton.Visible = true;
					this.cancelInLabel.Visible = false;
					return;
				}
			}
			else
			{
				this.cancelInLabel.Text = SK.Text("VACATION_Cancel_In", "You can cancel in") + " - " + VillageMap.createBuildTimeString(num2);
			}
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x0023B1D4 File Offset: 0x002393D4
		private void cancelClick()
		{
			MyMessageBox.setForcedForm(base.ParentForm);
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("Vacation_Cancel_MessageBox_Body", "Are you sure you wish to Cancel Vacation Mode?"), SK.Text("Vacation_Cancel_MessageBox_Header", "Cancel Vacation Mode"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Program.profileLogin.cancelVacationMode();
			}
		}

		// Token: 0x06002CC9 RID: 11465 RVA: 0x00020D8D File Offset: 0x0001EF8D
		private void closeClick()
		{
			Program.profileLogin.btnExit_Click();
		}

		// Token: 0x040037BD RID: 14269
		private IContainer components;

		// Token: 0x040037BE RID: 14270
		private Font WebTextFontBold = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 10f, FontStyle.Bold);

		// Token: 0x040037BF RID: 14271
		private Font WebTextFontBoldCond = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 10f, FontStyle.Bold);

		// Token: 0x040037C0 RID: 14272
		private Color WebButtonblue = Color.FromArgb(85, 145, 203);

		// Token: 0x040037C1 RID: 14273
		private Color WebButtonRed = Color.FromArgb(160, 0, 0);

		// Token: 0x040037C2 RID: 14274
		private Color WebButtonYellow = Color.FromArgb(225, 225, 0);

		// Token: 0x040037C3 RID: 14275
		private Color WebButtonGrey = Color.FromArgb(225, 225, 225);

		// Token: 0x040037C4 RID: 14276
		private int WebButtonheight = 22;

		// Token: 0x040037C5 RID: 14277
		private int WebButtonRadius = 10;

		// Token: 0x040037C6 RID: 14278
		private string strClose = SK.Text("LogoutPanel_Logout", "Logout");

		// Token: 0x040037C7 RID: 14279
		private string TextCreateHeader = SK.Text("VACATION_CANCEL_HEADER", "Vacation Mode is Active");

		// Token: 0x040037C8 RID: 14280
		private string strCancel = SK.Text("Vacation_Cancel", "Cancel Vacation Mode");

		// Token: 0x040037C9 RID: 14281
		private CustomSelfDrawPanel.CSDImage HeaderTitle;

		// Token: 0x040037CA RID: 14282
		public static Image closeImage;

		// Token: 0x040037CB RID: 14283
		public static Image closeImageOver;

		// Token: 0x040037CC RID: 14284
		public static Image headerImage;

		// Token: 0x040037CD RID: 14285
		public static Image cancelImage;

		// Token: 0x040037CE RID: 14286
		public static Image cancelImageOver;

		// Token: 0x040037CF RID: 14287
		private CustomSelfDrawPanel.CSDLabel expiresInLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037D0 RID: 14288
		private CustomSelfDrawPanel.CSDLabel cancelInLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037D1 RID: 14289
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040037D2 RID: 14290
		private int m_secondsLeft;

		// Token: 0x040037D3 RID: 14291
		private int m_secondsLeftToCancel;

		// Token: 0x040037D4 RID: 14292
		private DateTime m_startTime = DateTime.Now;
	}
}
