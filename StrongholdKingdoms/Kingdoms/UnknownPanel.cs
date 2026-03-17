using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020004AD RID: 1197
	public class UnknownPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002BC9 RID: 11209 RVA: 0x00020264 File Offset: 0x0001E464
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002BCA RID: 11210 RVA: 0x00020274 File Offset: 0x0001E474
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002BCB RID: 11211 RVA: 0x00020284 File Offset: 0x0001E484
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002BCC RID: 11212 RVA: 0x00020296 File Offset: 0x0001E496
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002BCD RID: 11213 RVA: 0x000202A3 File Offset: 0x0001E4A3
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06002BCE RID: 11214 RVA: 0x000202B7 File Offset: 0x0001E4B7
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002BCF RID: 11215 RVA: 0x000202C4 File Offset: 0x0001E4C4
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002BD0 RID: 11216 RVA: 0x000202D1 File Offset: 0x0001E4D1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002BD1 RID: 11217 RVA: 0x0022B22C File Offset: 0x0022942C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "UnknownPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002BD2 RID: 11218 RVA: 0x0022B298 File Offset: 0x00229498
		public UnknownPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002BD3 RID: 11219 RVA: 0x0022B2EC File Offset: 0x002294EC
		public void init()
		{
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			this.barracksLabel.Text = "Coming Soon";
			this.barracksLabel.Color = Color.FromArgb(224, 203, 146);
			this.barracksLabel.DropShadowColor = Color.FromArgb(74, 67, 48);
			this.barracksLabel.Position = new Point(9, 9);
			this.barracksLabel.Size = new Size(992, 50);
			this.barracksLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.barracksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundArea.addControl(this.barracksLabel);
		}

		// Token: 0x06002BD4 RID: 11220 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x04003696 RID: 13974
		private DockableControl dockableControl;

		// Token: 0x04003697 RID: 13975
		private IContainer components;

		// Token: 0x04003698 RID: 13976
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003699 RID: 13977
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400369A RID: 13978
		private CustomSelfDrawPanel.CSDLabel barracksLabel = new CustomSelfDrawPanel.CSDLabel();
	}
}
