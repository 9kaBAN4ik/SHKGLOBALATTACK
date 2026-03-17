namespace Kingdoms
{
	// Token: 0x02000231 RID: 561
	public partial class MainWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600187A RID: 6266 RVA: 0x000193A6 File Offset: 0x000175A6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00181CBC File Offset: 0x0017FEBC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.MainWindow));
			this.m_wndToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.dxBasePanel = new global::Kingdoms.DXPanel();
			this.mainRightHandPanel1 = new global::Kingdoms.MainRightHandPanel();
			this.topLeftMenu1 = new global::Kingdoms.TopLeftMenu2();
			this.topRightMenu1 = new global::Kingdoms.TopRightMenu();
			base.SuspendLayout();
			this.dxBasePanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dxBasePanel.BackColor = global::ARGBColors.Black;
			this.dxBasePanel.Location = new global::System.Drawing.Point(0, 120);
			this.dxBasePanel.Name = "dxBasePanel";
			this.dxBasePanel.Size = new global::System.Drawing.Size(1313, 966);
			this.dxBasePanel.TabIndex = 0;
			this.mainRightHandPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mainRightHandPanel1.BackColor = global::ARGBColors.Red;
			this.mainRightHandPanel1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.mainRightHandPanel1.Location = new global::System.Drawing.Point(1313, 120);
			this.mainRightHandPanel1.Size = new global::System.Drawing.Size(200, 240);
			this.mainRightHandPanel1.Name = "mainRightHandPanel1";
			this.mainRightHandPanel1.TabIndex = 2;
			this.topLeftMenu1.ClickThru = false;
			this.topLeftMenu1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.topLeftMenu1.Location = new global::System.Drawing.Point(0, 0);
			this.topLeftMenu1.Name = "topLeftMenu1";
			this.topLeftMenu1.PanelActive = true;
			this.topLeftMenu1.Size = new global::System.Drawing.Size(527, 120);
			this.topLeftMenu1.StoredGraphics = null;
			this.topLeftMenu1.TabIndex = 4;
			this.topRightMenu1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.topRightMenu1.BackColor = global::ARGBColors.Red;
			this.topRightMenu1.ClickThru = false;
			this.topRightMenu1.Location = new global::System.Drawing.Point(527, 0);
			this.topRightMenu1.MinimumSize = new global::System.Drawing.Size(463, 0);
			this.topRightMenu1.Name = "topRightMenu1";
			this.topRightMenu1.PanelActive = true;
			this.topRightMenu1.Size = new global::System.Drawing.Size(985, 120);
			this.topRightMenu1.StoredGraphics = null;
			this.topRightMenu1.TabIndex = 5;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(1512, 1086);
			base.Controls.Add(this.dxBasePanel);
			base.Controls.Add(this.mainRightHandPanel1);
			base.Controls.Add(this.topLeftMenu1);
			base.Controls.Add(this.topRightMenu1);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(1520, 1120);
			this.MinimumSize = new global::System.Drawing.Size(1000, 720);
			base.Name = "MainWindow";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stronghold Kingdoms";
			base.Deactivate += new global::System.EventHandler(this.MainWindowLarge_Deactivate);
			base.Load += new global::System.EventHandler(this.MainWindow_Load);
			base.ResizeBegin += new global::System.EventHandler(this.MainWindowLarge_ResizeBegin);
			base.SizeChanged += new global::System.EventHandler(this.MainWindowLarge_SizeChanged);
			base.Activated += new global::System.EventHandler(this.MainWindowLarge_Activated);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.MainWindowLarge_FormClosed);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			base.LocationChanged += new global::System.EventHandler(this.MainWindow_LocationChanged);
			base.ResizeEnd += new global::System.EventHandler(this.MainWindowLarge_ResizeEnd);
			base.ResumeLayout(false);
		}

		// Token: 0x040028E9 RID: 10473
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040028EA RID: 10474
		private global::Kingdoms.DXPanel dxBasePanel;

		// Token: 0x040028EB RID: 10475
		private global::Kingdoms.MainRightHandPanel mainRightHandPanel1;

		// Token: 0x040028EC RID: 10476
		private global::Kingdoms.TopLeftMenu2 topLeftMenu1;

		// Token: 0x040028ED RID: 10477
		private global::Kingdoms.TopRightMenu topRightMenu1;

		// Token: 0x040028EE RID: 10478
		private global::System.Windows.Forms.ToolTip m_wndToolTip;
	}
}
