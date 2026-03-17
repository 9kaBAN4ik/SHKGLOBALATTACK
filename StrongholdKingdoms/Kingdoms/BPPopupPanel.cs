using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000E6 RID: 230
	public class BPPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0008FE40 File Offset: 0x0008E040
		public Image CloseImage
		{
			get
			{
				if (BPPopupPanel.closeImage == null)
				{
					BPPopupPanel.closeImage = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return BPPopupPanel.closeImage;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x0008FE8C File Offset: 0x0008E08C
		public Image CloseImageOver
		{
			get
			{
				if (BPPopupPanel.closeImageOver == null)
				{
					BPPopupPanel.closeImageOver = WebStyleButtonImage.Generate(200, this.WebButtonheight, this.strClose, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return BPPopupPanel.closeImageOver;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0008FED8 File Offset: 0x0008E0D8
		public Image CompleteImage
		{
			get
			{
				if (BPPopupPanel.completeImage == null)
				{
					BPPopupPanel.completeImage = WebStyleButtonImage.Generate(400, this.WebButtonheight, this.strTryLogin, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return BPPopupPanel.completeImage;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0008FF24 File Offset: 0x0008E124
		public Image CompleteImageOver
		{
			get
			{
				if (BPPopupPanel.completeImageOver == null)
				{
					BPPopupPanel.completeImageOver = WebStyleButtonImage.Generate(400, this.WebButtonheight, this.strTryLogin, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return BPPopupPanel.completeImageOver;
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0008FF70 File Offset: 0x0008E170
		public BPPopupPanel()
		{
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x000900D4 File Offset: 0x0008E2D4
		public void init(ProfileLoginWindow parentForm)
		{
			this.m_parentForm = parentForm;
			base.clearControls();
			this.BackColor = global::ARGBColors.White;
			this.headingLabel.Text = SK.Text("BIGPOINT_PleaseLogin", "Please Log into Bigpoint in your Browser");
			this.headingLabel.Position = new Point(0, 10);
			this.headingLabel.Size = new Size(600, 30);
			this.headingLabel.Color = global::ARGBColors.Black;
			this.headingLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			base.addControl(this.headingLabel);
			this.bodyLabel.Text = SK.Text("BIGPOINT_ClickHere", "Click here once you have completed your Login");
			this.bodyLabel.Position = new Point(0, 80);
			this.bodyLabel.Size = new Size(600, 30);
			this.bodyLabel.Color = global::ARGBColors.Black;
			this.bodyLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.bodyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.bodyLabel.Visible = false;
			base.addControl(this.bodyLabel);
			this.closeButton.ImageNorm = this.CloseImage;
			this.closeButton.ImageOver = this.CloseImageOver;
			this.closeButton.Position = new Point(370, 160);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "WorldSelectPopupPanel_close");
			base.addControl(this.closeButton);
			this.completeButton.ImageNorm = this.CompleteImage;
			this.completeButton.ImageOver = this.CompleteImageOver;
			this.completeButton.Position = new Point(100, 100);
			this.completeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.completeClick), "WorldSelectPopupPanel_close");
			this.completeButton.Visible = false;
			base.addControl(this.completeButton);
			this.startedTime = DateTime.Now;
			this.firstAttemptTried = false;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000902F4 File Offset: 0x0008E4F4
		public void update()
		{
			if (!this.firstAttemptTried && (DateTime.Now - this.startedTime).TotalSeconds > 3.0)
			{
				this.firstAttemptTried = true;
				if (this.m_parentForm != null)
				{
					this.m_parentForm.bp2_autoLoginAttempt();
				}
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0000BB6D File Offset: 0x00009D6D
		public void attempt1Failed()
		{
			this.completeButton.Visible = true;
			this.bodyLabel.Visible = true;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0000BB87 File Offset: 0x00009D87
		private void closeClick()
		{
			InterfaceMgr.Instance.closeBPPopupWindow();
			if (this.m_parentForm != null)
			{
				this.m_parentForm.BP2_Closed();
			}
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0000BBA6 File Offset: 0x00009DA6
		private void completeClick()
		{
			this.closeButton.Enabled = false;
			this.completeButton.Enabled = false;
			if (this.m_parentForm != null)
			{
				this.m_parentForm.bp2_manualLoginAttempt();
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0000BBD3 File Offset: 0x00009DD3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0000BBF2 File Offset: 0x00009DF2
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04000923 RID: 2339
		private static bool showOwnWorldsStatus = true;

		// Token: 0x04000924 RID: 2340
		private static int showSpecialWorlds = -1;

		// Token: 0x04000925 RID: 2341
		private string strClose = SK.Text("GENERIC_Cancel", "Cancel");

		// Token: 0x04000926 RID: 2342
		private string strTryLogin = SK.Text("BIGPOINT_CompleteLogin", "Complete Login");

		// Token: 0x04000927 RID: 2343
		private Font WebTextFontBold = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 10f, FontStyle.Bold);

		// Token: 0x04000928 RID: 2344
		private Font WebTextFontBoldCond = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 10f, FontStyle.Bold);

		// Token: 0x04000929 RID: 2345
		private Color WebButtonblue = Color.FromArgb(85, 145, 203);

		// Token: 0x0400092A RID: 2346
		private Color WebButtonRed = Color.FromArgb(160, 0, 0);

		// Token: 0x0400092B RID: 2347
		private Color WebButtonRedFaded = Color.FromArgb(160, 96, 96);

		// Token: 0x0400092C RID: 2348
		private Color WebButtonYellow = Color.FromArgb(225, 225, 0);

		// Token: 0x0400092D RID: 2349
		private Color WebButtonYellow2 = Color.FromArgb(255, 238, 8);

		// Token: 0x0400092E RID: 2350
		private Color WebButtonGrey = Color.FromArgb(225, 225, 225);

		// Token: 0x0400092F RID: 2351
		private int WebButtonWidth = 120;

		// Token: 0x04000930 RID: 2352
		private int WebButtonheight = 22;

		// Token: 0x04000931 RID: 2353
		private int WebButtonRadius = 10;

		// Token: 0x04000932 RID: 2354
		public static Image closeImage;

		// Token: 0x04000933 RID: 2355
		public static Image closeImageOver;

		// Token: 0x04000934 RID: 2356
		public static Image completeImage;

		// Token: 0x04000935 RID: 2357
		public static Image completeImageOver;

		// Token: 0x04000936 RID: 2358
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000937 RID: 2359
		private CustomSelfDrawPanel.CSDButton completeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000938 RID: 2360
		private CustomSelfDrawPanel.CSDLabel bodyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000939 RID: 2361
		private CustomSelfDrawPanel.CSDLabel headingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400093A RID: 2362
		private DateTime startedTime = DateTime.MinValue;

		// Token: 0x0400093B RID: 2363
		private bool firstAttemptTried;

		// Token: 0x0400093C RID: 2364
		private ProfileLoginWindow m_parentForm;

		// Token: 0x0400093D RID: 2365
		private IContainer components;
	}
}
