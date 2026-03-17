using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000470 RID: 1136
	public class ReportDeletePanel : CustomSelfDrawPanel
	{
		// Token: 0x060028F3 RID: 10483 RVA: 0x0001E38F File Offset: 0x0001C58F
		public ReportDeletePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060028F4 RID: 10484 RVA: 0x001F2C50 File Offset: 0x001F0E50
		public void init(int mode, ReportCapturePopup parent)
		{
			this.m_mode = mode;
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.popup_background_01;
			this.backgroundImage.Position = new Point(0, 0);
			base.addControl(this.backgroundImage);
			float pointSize = 9f;
			if (Program.mySettings.LanguageIdent == "pl")
			{
				pointSize = 8f;
			}
			if (mode == 2)
			{
				this.captureLabel.Text = SK.Text("Report_Marking_And_Deleting", "Report Marking and Deleting");
			}
			this.captureLabel.Color = global::ARGBColors.White;
			this.captureLabel.Position = new Point(13, 7);
			this.captureLabel.Size = new Size(335, 20);
			this.captureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.captureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.backgroundImage.addControl(this.captureLabel);
			this.okButton.ImageNorm = GFXLibrary.button_blue_01_normal;
			this.okButton.ImageOver = GFXLibrary.button_blue_01_over;
			this.okButton.ImageClick = GFXLibrary.button_blue_01_in;
			this.okButton.Position = new Point(240, 325);
			this.okButton.Text.Text = SK.Text("GENERIC_OK", "OK");
			this.okButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.okButton.Text.Color = global::ARGBColors.Black;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.okClicked), "ReportDeletePanel_ok");
			this.backgroundImage.addControl(this.okButton);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = SK.Text("ReportDeleting_Delete_Reports", "Delete Reports");
			csdlabel.Color = global::ARGBColors.Black;
			csdlabel.Position = new Point(0, 50);
			csdlabel.Size = new Size(this.backgroundImage.Width, 20);
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.backgroundImage.addControl(csdlabel);
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 70);
			csdbutton.Text.Text = SK.Text("ReportDeleting_All", "All");
			csdbutton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton.TextYOffset = -3;
			csdbutton.Text.Color = global::ARGBColors.Black;
			csdbutton.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.deleteAllReports();
			}, "ReportDeletePanel_delete_all");
			this.backgroundImage.addControl(csdbutton);
			CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
			csdbutton2.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton2.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton2.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton2.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 100);
			csdbutton2.Text.Text = SK.Text("ReportDeleting_All_Shown", "All Shown");
			csdbutton2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton2.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton2.TextYOffset = -3;
			csdbutton2.Text.Color = global::ARGBColors.Black;
			csdbutton2.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.deleteShownReports();
			}, "ReportDeletePanel_delete_shown");
			this.backgroundImage.addControl(csdbutton2);
			CustomSelfDrawPanel.CSDButton csdbutton3 = new CustomSelfDrawPanel.CSDButton();
			csdbutton3.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton3.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton3.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton3.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 130);
			csdbutton3.Text.Text = SK.Text("ReportDeleting_All_Marked", "All Marked");
			csdbutton3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton3.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton3.TextYOffset = -3;
			csdbutton3.Text.Color = global::ARGBColors.Black;
			csdbutton3.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.deleteMarkedReports();
			}, "ReportDeletePanel_delete_marked");
			this.backgroundImage.addControl(csdbutton3);
			CustomSelfDrawPanel.CSDButton csdbutton4 = new CustomSelfDrawPanel.CSDButton();
			csdbutton4.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton4.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton4.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton4.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 160);
			csdbutton4.Text.Text = SK.Text("ReportDeleting_All_Unarked", "All Unmarked");
			csdbutton4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton4.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton4.TextYOffset = -3;
			csdbutton4.Text.Color = global::ARGBColors.Black;
			csdbutton4.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.deleteUnmarkedReports();
			}, "ReportDeletePanel_delete_unmarked");
			this.backgroundImage.addControl(csdbutton4);
			CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel2.Text = SK.Text("ReportDeleting_Mark_As_Read", "Mark Reports As Read");
			csdlabel2.Color = global::ARGBColors.Black;
			csdlabel2.Position = new Point(0, 200);
			csdlabel2.Size = new Size(this.backgroundImage.Width, 20);
			csdlabel2.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.backgroundImage.addControl(csdlabel2);
			CustomSelfDrawPanel.CSDButton csdbutton5 = new CustomSelfDrawPanel.CSDButton();
			csdbutton5.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton5.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton5.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton5.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 220);
			csdbutton5.Text.Text = SK.Text("ReportDeleting_All", "All");
			csdbutton5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton5.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton5.TextYOffset = -3;
			csdbutton5.Text.Color = global::ARGBColors.Black;
			csdbutton5.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.markAsReadAllReports();
			}, "ReportDeletePanel_mark_all_as_read");
			this.backgroundImage.addControl(csdbutton5);
			CustomSelfDrawPanel.CSDButton csdbutton6 = new CustomSelfDrawPanel.CSDButton();
			csdbutton6.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton6.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton6.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton6.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 250);
			csdbutton6.Text.Text = SK.Text("ReportDeleting_All_Shown", "All Shown");
			csdbutton6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton6.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton6.TextYOffset = -3;
			csdbutton6.Text.Color = global::ARGBColors.Black;
			csdbutton6.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.markAsReadShownReports();
			}, "ReportDeletePanel_mark_shown_as_read");
			this.backgroundImage.addControl(csdbutton6);
			CustomSelfDrawPanel.CSDButton csdbutton7 = new CustomSelfDrawPanel.CSDButton();
			csdbutton7.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton7.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton7.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton7.Position = new Point((this.backgroundImage.Width - GFXLibrary.mail2_button_blue_141wide_normal.Width) / 2, 280);
			csdbutton7.Text.Text = SK.Text("ReportDeleting_All_Marked", "All Marked");
			csdbutton7.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton7.Text.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			csdbutton7.TextYOffset = -3;
			csdbutton7.Text.Color = global::ARGBColors.Black;
			csdbutton7.setClickDelegate(delegate()
			{
				ReportsPanel.Instance.markAsReadMarkedReports();
			}, "ReportDeletePanel_mark_marked_as_read");
			this.backgroundImage.addControl(csdbutton7);
			parent.Size = this.backgroundImage.Size;
			base.Invalidate();
			parent.Invalidate();
		}

		// Token: 0x060028F5 RID: 10485 RVA: 0x0001E3CA File Offset: 0x0001C5CA
		public void okClicked()
		{
			if (this.m_mode == 2)
			{
				InterfaceMgr.Instance.closeReportCaptureWindow();
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.TopMost = false;
			}
		}

		// Token: 0x060028F6 RID: 10486 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060028F7 RID: 10487 RVA: 0x0001E3FF File Offset: 0x0001C5FF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060028F8 RID: 10488 RVA: 0x001F35D0 File Offset: 0x001F17D0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "ReportDeletePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x0400321E RID: 12830
		private CustomSelfDrawPanel.CSDLabel captureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400321F RID: 12831
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003220 RID: 12832
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003221 RID: 12833
		private int m_mode;

		// Token: 0x04003222 RID: 12834
		private IContainer components;

		// Token: 0x04003223 RID: 12835
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate7;

		// Token: 0x04003224 RID: 12836
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate8;

		// Token: 0x04003225 RID: 12837
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate9;

		// Token: 0x04003226 RID: 12838
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegatea;

		// Token: 0x04003227 RID: 12839
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegateb;

		// Token: 0x04003228 RID: 12840
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegatec;

		// Token: 0x04003229 RID: 12841
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegated;
	}
}
