using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000229 RID: 553
	public class MailScreenPanel : UserControl, IDockableControl, IDockWindow
	{
		// Token: 0x060017DE RID: 6110 RVA: 0x00018CFD File Offset: 0x00016EFD
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x00018D0D File Offset: 0x00016F0D
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x00018D1D File Offset: 0x00016F1D
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x00018D2F File Offset: 0x00016F2F
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x00018D3C File Offset: 0x00016F3C
		public void closeControl(bool includePopups)
		{
			if (this.mailScreen.Visible)
			{
				this.mailScreen.closeAttachmentsPopup(true);
			}
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x00018D63 File Offset: 0x00016F63
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x00018D70 File Offset: 0x00016F70
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x00018D7D File Offset: 0x00016F7D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x0017B4AC File Offset: 0x001796AC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.Name = "MailScreenManager";
			base.Size = new Size(630, 458);
			base.ResumeLayout(false);
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x00018D9C File Offset: 0x00016F9C
		public void AddControl(UserControl control, int x, int y)
		{
			this.dockWindow.AddControl(control, x, y);
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x00018DAC File Offset: 0x00016FAC
		public void RemoveControl(UserControl control)
		{
			this.dockWindow.RemoveControl(control);
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x0017B4F8 File Offset: 0x001796F8
		public MailScreenPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.dockWindow = new DockWindow(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x00018DBA File Offset: 0x00016FBA
		public bool isDocked()
		{
			return this.docked;
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x00018DC2 File Offset: 0x00016FC2
		public bool isMailScreenVisible()
		{
			return this.mailScreen.isVisible();
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x00018DCF File Offset: 0x00016FCF
		public void setAsDocked()
		{
			this.docked = true;
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x00018DD8 File Offset: 0x00016FD8
		public void setAsReopen()
		{
			this.openFresh = false;
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x0017B558 File Offset: 0x00179758
		public void open(bool forceDock, bool forceFloat)
		{
			if (forceDock)
			{
				this.docked = true;
			}
			if (forceFloat)
			{
				this.docked = false;
			}
			this.close(true);
			if (this.docked)
			{
				this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
				this.mailScreen.initProperties(true, "Mail", this);
				this.mailScreen.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.mailScreen.display(false, this, (base.Size.Width - this.mailScreen.Size.Width) / 2, (base.Size.Height - this.mailScreen.Size.Height) / 2);
				this.mailScreen.BringToFront();
				if (this.initScreen)
				{
					this.mailScreen.init(this);
				}
				this.mailScreen.open(this.openFresh, false);
				this.currentPanelWidth = this.mailScreen.Size.Width;
				this.currentPanelHeight = this.mailScreen.Size.Height;
				this.currentPanelWidth -= 168;
				this.currentPanelHeight -= 168;
				if (base.ClientSize.Width > 0 && base.ClientSize.Height > 0)
				{
					this.OnPaint(null);
				}
			}
			else
			{
				if (this.initScreen)
				{
					this.mailScreen.init(this);
				}
				this.mailScreen.open(this.openFresh, false);
				this.mailScreen.display(true, this, this.lastFloatX, this.lastFloatY);
			}
			this.initScreen = false;
			this.openFresh = true;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x00018DE1 File Offset: 0x00016FE1
		public void mailTo(int userID, string userName)
		{
			this.startWithNewMessage(userID, userName);
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x00018DEB File Offset: 0x00016FEB
		public void mailTo(int userID, string[] userNames)
		{
			this.mailScreen.mailTo(userNames);
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x00018DF9 File Offset: 0x00016FF9
		public void sendProclamation(int mailType, int areaID)
		{
			this.mailScreen.sendProclamation(mailType, areaID);
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x00018E08 File Offset: 0x00017008
		public void startWithNewMessage(int userID, string userName)
		{
			this.mailScreen.mailTo(userName);
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void clearAllMail()
		{
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x00018E16 File Offset: 0x00017016
		public void mailUpdate()
		{
			this.mailScreen.update();
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x00018E23 File Offset: 0x00017023
		public void close(bool forceClose)
		{
			if (forceClose || this.docked)
			{
				this.mailScreen.closeControl(true);
			}
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0017B710 File Offset: 0x00179910
		public void screenResize()
		{
			if (this.docked)
			{
				this.mailScreen.Location = new Point((base.Size.Width - this.mailScreen.Size.Width) / 2, (base.Size.Height - this.mailScreen.Size.Height) / 2);
			}
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x00018E3C File Offset: 0x0001703C
		public void clearStoredMail()
		{
			MailManager.Instance.clearStoredMail();
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x00018E48 File Offset: 0x00017048
		public void mailPopupNewMail()
		{
			if (!this.docked && this.mailScreen.isVisible())
			{
				this.mailScreen.refreshMail();
			}
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x00018E6A File Offset: 0x0001706A
		public void logout()
		{
			this.mailScreen.mailController.logout();
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0017B780 File Offset: 0x00179980
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this._backBuffer == null || this.forceBackgroundRedraw)
			{
				if (this._backBuffer == null)
				{
					if (base.ClientSize.Width == 0 || base.ClientSize.Height == 0)
					{
						return;
					}
					this._backBuffer = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
				}
				this.forceBackgroundRedraw = false;
				Graphics graphics = Graphics.FromImage(this._backBuffer);
				if (this.backgroundImage != null)
				{
					for (int i = 0; i < base.ClientSize.Height; i += 512)
					{
						for (int j = 0; j < base.ClientSize.Width; j += 512)
						{
							graphics.DrawImageUnscaledAndClipped(this.backgroundImage, new Rectangle(j, i, 512, 512));
						}
					}
				}
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_topleft, 0, 0, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_topright, base.ClientSize.Width - 128, 0, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_bottomleft, 0, base.ClientSize.Height - 128, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_bottomright, base.ClientSize.Width - 128, base.ClientSize.Height - 128, 128, 128);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_top, 128f, 0f, (float)(base.ClientSize.Width - 256), 128f);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_bottom, 128f, (float)(base.ClientSize.Height - 128), (float)(base.ClientSize.Width - 256), 128f);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_left, 0f, 128f, 128f, (float)(base.ClientSize.Height - 256));
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_right, (float)(base.ClientSize.Width - 128), 128f, 128f, (float)(base.ClientSize.Height - 256));
				int num = (base.ClientSize.Width - this.currentPanelWidth) / 2 + 8;
				int num2 = (base.ClientSize.Height - this.currentPanelHeight) / 2 + 8;
				if (num > 0 || num2 > 0)
				{
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topleft, num - 128, num2 - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topright, num + this.currentPanelWidth, num2 - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomleft, num - 128, num2 + this.currentPanelHeight, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomright, num + this.currentPanelWidth, num2 + this.currentPanelHeight, 128, 128);
					if (num > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_top, (float)num, (float)(num2 - 128), (float)this.currentPanelWidth, 128f);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_bottom, (float)num, (float)(num2 + this.currentPanelHeight), (float)this.currentPanelWidth, 128f);
					}
					if (num2 > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_left, (float)(num - 128), (float)num2, 128f, (float)this.currentPanelHeight);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_right, (float)(num + this.currentPanelWidth), (float)num2, 128f, (float)this.currentPanelHeight);
					}
				}
				graphics.Dispose();
			}
			if (e != null)
			{
				e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
			}
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x000E3950 File Offset: 0x000E1B50
		private void drawImageStretched(Graphics g, Image image, float x, float y, float width, float height)
		{
			RectangleF srcRect = (image.Width == 1) ? new RectangleF(0f, 0f, 1E-05f, (float)image.Height) : new RectangleF(0f, 0f, (float)image.Width, 1E-05f);
			RectangleF destRect = new RectangleF(x, y, width, height);
			g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x00018E7C File Offset: 0x0001707C
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this._backBuffer != null)
			{
				this._backBuffer.Dispose();
				this._backBuffer = null;
				base.Invalidate();
			}
			base.OnSizeChanged(e);
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x00018EA5 File Offset: 0x000170A5
		public void setBackgroundImage(Image image)
		{
			if (this.backgroundImage != image)
			{
				this.backgroundImage = image;
				this.forceBackgroundRedraw = true;
			}
		}

		// Token: 0x04002893 RID: 10387
		private DockableControl dockableControl;

		// Token: 0x04002894 RID: 10388
		private IContainer components;

		// Token: 0x04002895 RID: 10389
		private DockWindow dockWindow;

		// Token: 0x04002896 RID: 10390
		private MailScreen mailScreen = new MailScreen();

		// Token: 0x04002897 RID: 10391
		private bool docked = true;

		// Token: 0x04002898 RID: 10392
		private bool openFresh = true;

		// Token: 0x04002899 RID: 10393
		private bool initScreen = true;

		// Token: 0x0400289A RID: 10394
		private int lastFloatX;

		// Token: 0x0400289B RID: 10395
		private int lastFloatY;

		// Token: 0x0400289C RID: 10396
		private Bitmap _backBuffer;

		// Token: 0x0400289D RID: 10397
		private int currentPanelWidth;

		// Token: 0x0400289E RID: 10398
		private int currentPanelHeight;

		// Token: 0x0400289F RID: 10399
		public bool forceBackgroundRedraw = true;

		// Token: 0x040028A0 RID: 10400
		private Image backgroundImage;
	}
}
