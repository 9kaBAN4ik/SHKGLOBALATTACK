using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200021A RID: 538
	public class MailAbuseSubmissionForm : UserControl, IDockableControl
	{
		// Token: 0x06001698 RID: 5784 RVA: 0x00017DEE File Offset: 0x00015FEE
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001699 RID: 5785 RVA: 0x00017DFE File Offset: 0x00015FFE
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x00017E0E File Offset: 0x0001600E
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y, true);
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x00017E21 File Offset: 0x00016021
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x00017E2E File Offset: 0x0001602E
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x00017E3C File Offset: 0x0001603C
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x00017E49 File Offset: 0x00016049
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x00017E56 File Offset: 0x00016056
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x00167320 File Offset: 0x00165520
		private void InitializeComponent()
		{
			this.lblAdvice = new Label();
			this.panel1 = new Panel();
			this.lblTitle = new Label();
			this.lblBlockReminder = new Label();
			this.tbDescription = new TextBox();
			this.lblTextTitle = new Label();
			this.cbReason = new ComboBox();
			this.lblReason = new Label();
			this.btnReport = new BitmapButton();
			this.btnClose = new BitmapButton();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.lblAdvice.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblAdvice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblAdvice.Location = new Point(12, 28);
			this.lblAdvice.Name = "lblAdvice";
			this.lblAdvice.Size = new Size(478, 144);
			this.lblAdvice.TabIndex = 0;
			this.lblAdvice.Text = "Nothing";
			this.lblAdvice.TextAlign = ContentAlignment.MiddleCenter;
			this.panel1.BackColor = Color.FromArgb(159, 180, 193);
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Controls.Add(this.lblAdvice);
			this.panel1.Location = new Point(28, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(507, 176);
			this.panel1.TabIndex = 2;
			this.lblTitle.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblTitle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTitle.Location = new Point(3, 6);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new Size(497, 22);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Nothing";
			this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
			this.lblBlockReminder.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblBlockReminder.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblBlockReminder.Location = new Point(51, 555);
			this.lblBlockReminder.Name = "lblBlockReminder";
			this.lblBlockReminder.Size = new Size(461, 52);
			this.lblBlockReminder.TabIndex = 4;
			this.lblBlockReminder.Text = "Please note that, on sending the report, the user in question will automatically be added to your \"Block Users\" list";
			this.lblBlockReminder.TextAlign = ContentAlignment.MiddleCenter;
			this.tbDescription.BackColor = global::ARGBColors.White;
			this.tbDescription.Location = new Point(32, 270);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ScrollBars = ScrollBars.Vertical;
			this.tbDescription.Size = new Size(498, 282);
			this.tbDescription.TabIndex = 7;
			this.tbDescription.TextChanged += this.tbDescription_TextChanged;
			this.lblTextTitle.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblTextTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblTextTitle.Location = new Point(14, 247);
			this.lblTextTitle.Name = "lblTextTitle";
			this.lblTextTitle.Size = new Size(535, 20);
			this.lblTextTitle.TabIndex = 8;
			this.lblTextTitle.Text = "Summary of the issue:";
			this.lblTextTitle.TextAlign = ContentAlignment.MiddleCenter;
			this.cbReason.FormattingEnabled = true;
			this.cbReason.Location = new Point(207, 202);
			this.cbReason.Name = "cbReason";
			this.cbReason.Size = new Size(236, 21);
			this.cbReason.TabIndex = 9;
			this.cbReason.SelectedIndexChanged += this.cbReason_SelectedIndexChanged;
			this.lblReason.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblReason.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblReason.Location = new Point(33, 203);
			this.lblReason.Name = "lblReason";
			this.lblReason.Size = new Size(168, 20);
			this.lblReason.TabIndex = 10;
			this.lblReason.Text = "Reason for reporting:";
			this.lblReason.TextAlign = ContentAlignment.MiddleRight;
			this.btnReport.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnReport.BackColor = Color.FromArgb(159, 180, 193);
			this.btnReport.BorderColor = global::ARGBColors.DarkBlue;
			this.btnReport.BorderDrawing = true;
			this.btnReport.Enabled = false;
			this.btnReport.FocusRectangleEnabled = false;
			this.btnReport.Image = null;
			this.btnReport.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnReport.ImageBorderEnabled = true;
			this.btnReport.ImageDropShadow = true;
			this.btnReport.ImageFocused = null;
			this.btnReport.ImageInactive = null;
			this.btnReport.ImageMouseOver = null;
			this.btnReport.ImageNormal = null;
			this.btnReport.ImagePressed = null;
			this.btnReport.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnReport.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnReport.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnReport.Location = new Point(15, 623);
			this.btnReport.Name = "btnReport";
			this.btnReport.OffsetPressedContent = true;
			this.btnReport.Padding2 = 5;
			this.btnReport.Size = new Size(111, 23);
			this.btnReport.StretchImage = false;
			this.btnReport.TabIndex = 6;
			this.btnReport.Text = "Report Mail";
			this.btnReport.TextDropShadow = false;
			this.btnReport.UseVisualStyleBackColor = false;
			this.btnReport.Click += this.btnReport_Click;
			this.btnClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnClose.BackColor = Color.FromArgb(159, 180, 193);
			this.btnClose.BorderColor = global::ARGBColors.DarkBlue;
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnClose.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnClose.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnClose.Location = new Point(469, 623);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new Size(76, 23);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += this.btnClose_Click;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Controls.Add(this.cbReason);
			base.Controls.Add(this.lblReason);
			base.Controls.Add(this.lblTextTitle);
			base.Controls.Add(this.tbDescription);
			base.Controls.Add(this.btnReport);
			base.Controls.Add(this.lblBlockReminder);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.panel1);
			base.Name = "MailAbuseSubmissionForm";
			base.Size = new Size(563, 659);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x00167C38 File Offset: 0x00165E38
		public MailAbuseSubmissionForm()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
			this.lblTextTitle.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.lblTitle.Font = FontManager.GetFont("Microsoft Sans Serif", 12f, FontStyle.Bold);
			this.lblAdvice.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.btnReport.Text = SK.Text("REPORT_ABUSE_Title", "Report Mail");
			this.lblTitle.Text = SK.Text("REPORT_ABUSE_Title", "Report Mail");
			this.lblAdvice.Text = SK.Text("REPORT_ABUSE_Advice", "If you believe that the contents of this mail need to be investigated by the game administration, you may report it using this form. Please select a reason for doing so from the choices listed below, and provide a summary as to why you feel investigation is required. Please note that being attacked through game mechanics is not a valid reason for reporting, and use of this system for inappropriate reasons will not be tolerated.");
			this.lblReason.Text = SK.Text("REPORT_ABUSE_SelectReason", "Reason for reporting:");
			this.lblTextTitle.Text = SK.Text("REPORT_ABUSE_SummaryTitle", "Summary of the issue (minimum 50 characters):");
			this.lblBlockReminder.Text = SK.Text("REPORT_ABUSE_BlockReminder", "Please note that, on sending the report, the user in question will automatically be added to your 'Blocked Users' list");
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_PleaseSelect", "Please select"));
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_Inappropriate", "Inappropriate Conduct"));
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_Personal", "Threats outside the game"));
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_Spam", "Advertisements or Links"));
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_Scam", "Scam or Phishing Attempt"));
			this.cbReason.Items.Add(SK.Text("REPORT_ABUSE_Proclamation", "Offensive Proclamation"));
			this.cbReason.SelectedIndex = 0;
			this.btnReport.Enabled = false;
			this.cbReason.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x00017E75 File Offset: 0x00016075
		public void InitReportData(MailScreen parentScreen, long itemID, long threadID, string userName)
		{
			this.parentMailscreen = parentScreen;
			this.selectedMailItemID = itemID;
			this.selectedMailThreadID = threadID;
			this.selectedUserName = userName;
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x00017E94 File Offset: 0x00016094
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_close");
			this.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x00167E7C File Offset: 0x0016607C
		private void btnReport_Click(object sender, EventArgs e)
		{
			if (this.reasonSelected && this.summaryProvided)
			{
				RemoteServices.Instance.set_ReportMail_UserCallBack(new RemoteServices.ReportMail_UserCallBack(this.parentMailscreen.ReportMailCallback));
				RemoteServices.Instance.ReportMail(this.selectedMailItemID, this.selectedMailThreadID, this.cbReason.SelectedItem.ToString(), this.tbDescription.Text);
				GameEngine.Instance.playInterfaceSound("ReportsGeneric_close");
				this.closeControl(true);
				InterfaceMgr.Instance.reactiveMainWindow();
				if (this.selectedUserName.Length > 0)
				{
					MailUserBlockPopup mailUserBlockPopup = new MailUserBlockPopup();
					mailUserBlockPopup.init(this.parentMailscreen, this.selectedUserName);
					mailUserBlockPopup.ShowDialog(InterfaceMgr.Instance.ParentForm);
					mailUserBlockPopup.Dispose();
				}
			}
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x00167F48 File Offset: 0x00166148
		private void tbDescription_TextChanged(object sender, EventArgs e)
		{
			if (this.tbDescription.Text.Length >= 50)
			{
				this.summaryProvided = true;
				if (this.reasonSelected)
				{
					this.btnReport.Enabled = true;
					return;
				}
			}
			else
			{
				this.summaryProvided = false;
				this.btnReport.Enabled = false;
			}
		}

		// Token: 0x060016A6 RID: 5798 RVA: 0x00017EB6 File Offset: 0x000160B6
		private void cbReason_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbReason.SelectedIndex != 0)
			{
				this.reasonSelected = true;
				if (this.summaryProvided)
				{
					this.btnReport.Enabled = true;
					return;
				}
			}
			else
			{
				this.reasonSelected = false;
				this.btnReport.Enabled = false;
			}
		}

		// Token: 0x040026EB RID: 9963
		private DockableControl dockableControl;

		// Token: 0x040026EC RID: 9964
		private IContainer components;

		// Token: 0x040026ED RID: 9965
		private Label lblAdvice;

		// Token: 0x040026EE RID: 9966
		private Panel panel1;

		// Token: 0x040026EF RID: 9967
		private BitmapButton btnClose;

		// Token: 0x040026F0 RID: 9968
		private Label lblBlockReminder;

		// Token: 0x040026F1 RID: 9969
		private BitmapButton btnReport;

		// Token: 0x040026F2 RID: 9970
		private Label lblTitle;

		// Token: 0x040026F3 RID: 9971
		private TextBox tbDescription;

		// Token: 0x040026F4 RID: 9972
		private Label lblTextTitle;

		// Token: 0x040026F5 RID: 9973
		private ComboBox cbReason;

		// Token: 0x040026F6 RID: 9974
		private Label lblReason;

		// Token: 0x040026F7 RID: 9975
		private MailScreen parentMailscreen;

		// Token: 0x040026F8 RID: 9976
		private long selectedMailItemID = -1L;

		// Token: 0x040026F9 RID: 9977
		private long selectedMailThreadID = -1L;

		// Token: 0x040026FA RID: 9978
		private string selectedUserName = "";

		// Token: 0x040026FB RID: 9979
		private bool reasonSelected;

		// Token: 0x040026FC RID: 9980
		private bool summaryProvided;
	}
}
