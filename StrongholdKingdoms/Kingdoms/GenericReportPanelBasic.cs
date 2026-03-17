using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020001E6 RID: 486
	public class GenericReportPanelBasic : CustomSelfDrawPanel, IMailUserInterface
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060012D0 RID: 4816 RVA: 0x0001414A File Offset: 0x0001234A
		// (set) Token: 0x060012D1 RID: 4817 RVA: 0x00014151 File Offset: 0x00012351
		public static string[] MailUsersHistory
		{
			get
			{
				return GenericReportPanelBasic.mailUsersHistory;
			}
			set
			{
				GenericReportPanelBasic.mailUsersHistory = value;
				GenericReportPanelBasic.historyNeedsRefresh = false;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060012D2 RID: 4818 RVA: 0x0001415F File Offset: 0x0001235F
		// (set) Token: 0x060012D3 RID: 4819 RVA: 0x00014166 File Offset: 0x00012366
		public static string[] MailFavourites
		{
			get
			{
				return GenericReportPanelBasic.mailFavourites;
			}
			set
			{
				GenericReportPanelBasic.mailFavourites = value;
				GenericReportPanelBasic.historyNeedsRefresh = false;
			}
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x00138DC4 File Offset: 0x00136FC4
		public GenericReportPanelBasic()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new Size(580, 320);
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00014174 File Offset: 0x00012374
		public static void ForceHistoryRefresh()
		{
			GenericReportPanelBasic.historyNeedsRefresh = true;
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0001417C File Offset: 0x0001237C
		public static bool isHistoryRefreshNeeded()
		{
			return GenericReportPanelBasic.historyNeedsRefresh;
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x00014183 File Offset: 0x00012383
		public void init(IDockableControl parent, Size size)
		{
			this.init(parent, size, null);
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x0001418E File Offset: 0x0001238E
		public bool hasBackground()
		{
			return this.imgBackground.Image != null;
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x00138EAC File Offset: 0x001370AC
		public virtual void init(IDockableControl parent, Size size, object back)
		{
			this.imgBackground.Image = (Image)back;
			this.imgBackground.Alpha = 0.1f;
			this.m_parent = parent;
			base.Size = size;
			this.borderOffset = 20;
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnForward.Text.Text = SK.Text("GENERIC_Forward", "Forward");
			this.btnDelete.Text.Text = SK.Text("GENERIC_Delete", "Delete");
			this.lblMainText.Color = global::ARGBColors.Black;
			this.lblMainText.Position = new Point(this.borderOffset, 3 + this.borderOffset);
			this.lblMainText.Size = new Size(base.Width - this.borderOffset * 2, 57);
			this.lblMainText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lblMainText.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.lblSubTitle.Color = global::ARGBColors.Black;
			this.lblSubTitle.Position = new Point(20, this.lblMainText.Rectangle.Bottom);
			this.lblSubTitle.Size = new Size(base.Width - 40, 26);
			this.lblSubTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblSubTitle.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblSecondaryText.Color = global::ARGBColors.Black;
			this.lblSecondaryText.Position = new Point(20, this.lblSubTitle.Rectangle.Bottom);
			this.lblSecondaryText.Size = new Size(base.Width - 40, 60);
			this.lblSecondaryText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblSecondaryText.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.lblDate.Color = global::ARGBColors.Black;
			this.lblDate.Position = new Point(0, this.lblSecondaryText.Rectangle.Bottom);
			this.lblDate.Size = new Size(base.Width, 30);
			this.lblDate.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblDate.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.btnClose.ImageNorm = GFXLibrary.button_132_normal;
			this.btnClose.ImageOver = GFXLibrary.button_132_over;
			this.btnClose.ImageClick = GFXLibrary.button_132_in;
			this.btnClose.setSizeToImage();
			this.btnClose.Position = new Point(base.Width - this.btnClose.Width - 5 - this.borderOffset, base.Bottom - this.btnClose.Height - 8 - this.borderOffset);
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnClose.TextYOffset = -2;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Report_Close");
			this.btnClose.Enabled = true;
			this.btnDelete.ImageNorm = GFXLibrary.button_132_normal;
			this.btnDelete.ImageOver = GFXLibrary.button_132_over;
			this.btnDelete.ImageClick = GFXLibrary.button_132_in;
			this.btnDelete.setSizeToImage();
			this.btnDelete.Position = new Point(this.btnClose.Position.X, this.btnClose.Position.Y - this.btnDelete.Height - 3);
			this.btnDelete.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnDelete.TextYOffset = -2;
			this.btnDelete.Text.Color = global::ARGBColors.Black;
			this.btnDelete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClick), "Report_Delete");
			this.btnDelete.Enabled = true;
			this.btnForward.ImageNorm = GFXLibrary.button_132_normal;
			this.btnForward.ImageOver = GFXLibrary.button_132_over;
			this.btnForward.ImageClick = GFXLibrary.button_132_in;
			this.btnForward.setSizeToImage();
			this.btnForward.Position = new Point(5 + this.borderOffset, base.Bottom - this.btnForward.Height - 8 - this.borderOffset);
			this.btnForward.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnForward.TextYOffset = -2;
			this.btnForward.Text.Color = global::ARGBColors.Black;
			this.btnForward.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forwardClick), "Report_Forward");
			this.btnForward.Enabled = true;
			this.btnUtility.ImageNorm = GFXLibrary.button_132_normal;
			this.btnUtility.ImageOver = GFXLibrary.button_132_over;
			this.btnUtility.ImageClick = GFXLibrary.button_132_in;
			this.btnUtility.setSizeToImage();
			this.btnUtility.Position = new Point(this.btnForward.Position.X, this.btnForward.Position.Y - this.btnUtility.Height - 2);
			this.btnUtility.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnUtility.TextYOffset = -2;
			this.btnUtility.Text.Color = global::ARGBColors.Black;
			this.btnUtility.Enabled = true;
			this.btnUtility.Visible = false;
			this.lblFurther.Text = "";
			this.lblFurther.Color = global::ARGBColors.Black;
			this.lblFurther.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblFurther.Visible = false;
			this.lblFurther.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblFurther.Position = new Point(this.btnForward.Rectangle.Right + 5, this.btnDelete.Y);
			this.lblFurther.Size = new Size(this.btnDelete.X - this.btnForward.Rectangle.Right - 10, base.Height - this.lblFurther.Y);
			this.imgFurther.Tile = false;
			this.imgFurther.Visible = false;
			this.initBorder(GFXLibrary.panel_border_top_left, GFXLibrary.panel_border_top, GFXLibrary.panel_border_left);
			if (this.hasBackground())
			{
				this.imgBackground.Tile = true;
				this.imgBackground.Position = new Point(0, 0);
				this.imgBackground.Size = base.Size;
				base.addControl(this.imgBackground);
				this.imgBackground.addControl(this.btnClose);
				this.imgBackground.addControl(this.btnForward);
				this.imgBackground.addControl(this.btnUtility);
				this.imgBackground.addControl(this.btnDelete);
				this.imgBackground.addControl(this.lblMainText);
				this.imgBackground.addControl(this.lblSubTitle);
				this.imgBackground.addControl(this.lblSecondaryText);
				this.imgBackground.addControl(this.lblDate);
				this.imgBackground.addControl(this.borderPanel);
			}
			else
			{
				base.addControl(this.btnClose);
				base.addControl(this.btnForward);
				base.addControl(this.btnUtility);
				base.addControl(this.btnDelete);
				base.addControl(this.lblMainText);
				base.addControl(this.lblSubTitle);
				base.addControl(this.lblSecondaryText);
				base.addControl(this.lblDate);
				base.addControl(this.borderPanel);
			}
			bool worldEnded = GameEngine.Instance.World.WorldEnded;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x00139738 File Offset: 0x00137938
		public void initBorder(BaseImage cornerImage, BaseImage horizontalSideImage, BaseImage verticalSideImage)
		{
			Image image = cornerImage;
			Image image2 = (Image)image.Clone();
			image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
			Image image3 = (Image)image.Clone();
			image3.RotateFlip(RotateFlipType.Rotate180FlipNone);
			Image image4 = (Image)image.Clone();
			image4.RotateFlip(RotateFlipType.Rotate180FlipX);
			Image image5 = verticalSideImage;
			Image image6 = (Image)image5.Clone();
			image6.RotateFlip(RotateFlipType.RotateNoneFlipX);
			Image image7 = horizontalSideImage;
			Image image8 = (Image)image7.Clone();
			image8.RotateFlip(RotateFlipType.Rotate180FlipX);
			this.borderPanel.Size = base.Size;
			this.borderPanel.Create(image, image7, image2, image5, null, image6, image8, image8, image7);
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x001397EC File Offset: 0x001379EC
		public void popupClosed(bool ok)
		{
			if (ok && this.forwardRecipients.Count > 0)
			{
				RemoteServices.Instance.set_ForwardReport_UserCallBack(new RemoteServices.ForwardReport_UserCallBack(this.forwardReportCallback));
				RemoteServices.Instance.ForwardReport(this.reportID, this.forwardRecipients.ToArray());
				GenericReportPanelBasic.ForceHistoryRefresh();
			}
			base.Enabled = true;
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x00139848 File Offset: 0x00137A48
		public virtual void setData(GetReport_ReturnType returnData)
		{
			if (GenericReportPanelBasic.isHistoryRefreshNeeded())
			{
				RemoteServices.Instance.set_GetMailRecipientsHistory_UserCallBack(new RemoteServices.GetMailRecipientsHistory_UserCallBack(this.mailRecipientsCallback));
				RemoteServices.Instance.GetMailRecipientsHistory();
				this.btnForward.Enabled = false;
			}
			else
			{
				this.btnForward.Enabled = true;
			}
			this.m_returnData = returnData;
			this.reportID = returnData.reportID;
			NumberFormatInfo numberFormatInfo = GameEngine.NFI;
			this.lblDate.Text = returnData.reportTime.ToString();
			this.reportOwner = returnData.reportAboutUser;
			if (this.reportOwner == null || this.reportOwner.Length == 0)
			{
				this.reportOwner = RemoteServices.Instance.UserName;
			}
			this.lblMainText.Text = this.reportOwner;
			this.btnUtility.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilityClick), "Reports_Utility");
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x00139924 File Offset: 0x00137B24
		protected void showFurtherInfo()
		{
			this.lblFurther.Visible = true;
			this.imgFurther.Visible = true;
			if (this.hasBackground())
			{
				this.imgBackground.addControl(this.lblFurther);
				this.imgBackground.addControl(this.imgFurther);
				return;
			}
			base.addControl(this.lblFurther);
			base.addControl(this.imgFurther);
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x0001419E File Offset: 0x0001239E
		public void closeClick()
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_close");
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x0013998C File Offset: 0x00137B8C
		public void deleteClick()
		{
			if (this.m_returnData != null)
			{
				GameEngine.Instance.playInterfaceSound("ReportsGeneric_delete");
				if (InterfaceMgr.Instance.deleteReport(this.m_returnData.reportID))
				{
					this.m_parent.closeControl(true);
					InterfaceMgr.Instance.reactiveMainWindow();
				}
			}
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x001399E0 File Offset: 0x00137BE0
		private void forwardClick()
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_forward");
			this.forwardRecipients.Clear();
			base.Enabled = false;
			MailUserPopup mailUserPopup = new MailUserPopup();
			mailUserPopup.setAsReportForward();
			mailUserPopup.setParent(this, GenericReportPanelBasic.MailUsersHistory, GenericReportPanelBasic.MailFavourites, null);
			mailUserPopup.Show();
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected virtual void utilityClick()
		{
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x00139A34 File Offset: 0x00137C34
		public void forwardReportCallback(ForwardReport_ReturnType returnData)
		{
			if (returnData.Success)
			{
				MyMessageBox.Show(SK.Text("Reports_Forwarded", "Report Forwarded"), SK.Text("Reports_Reports", "Reports"));
				InterfaceMgr.Instance.reactiveMainWindow();
				if (base.ParentForm != null)
				{
					base.ParentForm.TopMost = true;
					base.ParentForm.Focus();
					base.ParentForm.BringToFront();
					base.ParentForm.TopMost = false;
				}
			}
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x000141C5 File Offset: 0x000123C5
		public void addRecipient(string recipient)
		{
			if (recipient.Length > 0 && !this.forwardRecipients.Contains(recipient))
			{
				this.forwardRecipients.Add(recipient);
			}
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x000141EA File Offset: 0x000123EA
		public void mailRecipientsCallback(GetMailRecipientsHistory_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GenericReportPanelBasic.MailFavourites = returnData.mailFavourites;
				GenericReportPanelBasic.MailUsersHistory = returnData.mailUsersHistory;
				this.btnForward.Enabled = true;
			}
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x00014216 File Offset: 0x00012416
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x00014235 File Offset: 0x00012435
		protected void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		// Token: 0x04001950 RID: 6480
		private static string[] mailUsersHistory = null;

		// Token: 0x04001951 RID: 6481
		private static string[] mailFavourites = null;

		// Token: 0x04001952 RID: 6482
		private static bool historyNeedsRefresh = true;

		// Token: 0x04001953 RID: 6483
		protected IDockableControl m_parent;

		// Token: 0x04001954 RID: 6484
		protected GetReport_ReturnType m_returnData;

		// Token: 0x04001955 RID: 6485
		protected string reportOwner = "";

		// Token: 0x04001956 RID: 6486
		protected long reportID = -1L;

		// Token: 0x04001957 RID: 6487
		protected int borderOffset;

		// Token: 0x04001958 RID: 6488
		protected NumberFormatInfo nfi = GameEngine.NFI;

		// Token: 0x04001959 RID: 6489
		protected CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400195A RID: 6490
		protected CustomSelfDrawPanel.CSDButton btnDelete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400195B RID: 6491
		protected CustomSelfDrawPanel.CSDButton btnForward = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400195C RID: 6492
		protected CustomSelfDrawPanel.CSDButton btnUtility = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400195D RID: 6493
		protected CustomSelfDrawPanel.CSDLabel lblDate = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400195E RID: 6494
		protected CustomSelfDrawPanel.CSDLabel lblSubTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400195F RID: 6495
		protected CustomSelfDrawPanel.CSDLabel lblMainText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001960 RID: 6496
		protected CustomSelfDrawPanel.CSDLabel lblSecondaryText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001961 RID: 6497
		protected CustomSelfDrawPanel.CSDImage imgBackground = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001962 RID: 6498
		protected CustomSelfDrawPanel.CSDImage imgFurther = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001963 RID: 6499
		protected CustomSelfDrawPanel.CSDLabel lblFurther = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001964 RID: 6500
		protected CustomSelfDrawPanel.CSDExtendingPanel borderPanel = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001965 RID: 6501
		private List<string> forwardRecipients = new List<string>();

		// Token: 0x04001966 RID: 6502
		private IContainer components;
	}
}
