using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000130 RID: 304
	public class ChatScreenManager : UserControl, IDockableControl, IDockWindow
	{
		// Token: 0x06000B3F RID: 2879 RVA: 0x0000E5AD File Offset: 0x0000C7AD
		public void AddControl(UserControl control, int x, int y)
		{
			this.dockWindow.AddControl(control, x, y);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0000E5BD File Offset: 0x0000C7BD
		public void RemoveControl(UserControl control)
		{
			this.dockWindow.RemoveControl(control);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x000E3390 File Offset: 0x000E1590
		public ChatScreenManager()
		{
			this.dockableControl = new DockableControl(this);
			this.dockWindow = new DockWindow(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
			this.dockableControl.setSizeableWindow();
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0000E5CB File Offset: 0x0000C7CB
		public bool isDocked()
		{
			return this.docked;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0000E5D3 File Offset: 0x0000C7D3
		public void setAsDocked()
		{
			this.docked = true;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x000E33F0 File Offset: 0x000E15F0
		public void open(bool forceDock, bool forceFloat, int areaType, int areaID)
		{
			if (this.chatBanned)
			{
				MyMessageBox.Show(SK.Text("ChatScreenManager_Ban_Message_Chat", "Your chat privileges have been suspended for violations of the game rules or code of conduct.") + Environment.NewLine + URLs.IPSharingPage, SK.Text("GENERIC_Chat_Banned", "Chat Privileges Ban"));
				return;
			}
			if (forceDock)
			{
				this.docked = true;
			}
			if (forceFloat)
			{
				this.docked = false;
			}
			this.close(true, false);
			if (this.initScreen)
			{
				this.chatScreen.initProperties(true, "Chat", this);
				this.chatScreen.init(this);
			}
			RemoteServices.Instance.Chat_StartReceiving();
			this.chatScreen.openFresh(areaType, areaID);
			this.chatScreen.display(true, this, this.lastFloatX, this.lastFloatY);
			this.chatScreen.openUpdate();
			this.initScreen = false;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0000E5DC File Offset: 0x0000C7DC
		public Form ChatForm()
		{
			if (this.chatScreen != null)
			{
				return this.chatScreen.ParentForm;
			}
			return null;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0000E5F3 File Offset: 0x0000C7F3
		public void chatUpdate()
		{
			if (this.chatScreen.isActive())
			{
				this.chatScreen.update();
			}
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0000E60D File Offset: 0x0000C80D
		public void close(bool forceClose, bool closingChat)
		{
			if (forceClose || this.docked)
			{
				this.chatScreen.closeControl(true);
				if (closingChat)
				{
					RemoteServices.Instance.Chat_StopReceiving();
				}
			}
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0000E633 File Offset: 0x0000C833
		public void login()
		{
			this.chatBanned = false;
			RemoteServices.Instance.set_Chat_Login_UserCallBack(new RemoteServices.Chat_Login_UserCallBack(this.Chat_Login_Callback));
			RemoteServices.Instance.Chat_Login();
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void Chat_Login_Callback(Chat_Login_ReturnType returnData)
		{
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0000E65C File Offset: 0x0000C85C
		public void setChatBan(bool banned)
		{
			this.chatBanned = banned;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0000E665 File Offset: 0x0000C865
		public void logout()
		{
			RemoteServices.Instance.Chat_Logout();
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x000E34C0 File Offset: 0x000E16C0
		public void screenResize()
		{
			if (this.docked)
			{
				this.chatScreen.Location = new Point((base.Size.Width - this.chatScreen.Size.Width) / 2, (base.Size.Height - this.chatScreen.Size.Height) / 2);
			}
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x000E3530 File Offset: 0x000E1730
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this._backBuffer == null || this.forceBackgroundRedraw)
			{
				if (this._backBuffer == null)
				{
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

		// Token: 0x06000B4E RID: 2894 RVA: 0x000E3950 File Offset: 0x000E1B50
		private void drawImageStretched(Graphics g, Image image, float x, float y, float width, float height)
		{
			RectangleF srcRect = (image.Width == 1) ? new RectangleF(0f, 0f, 1E-05f, (float)image.Height) : new RectangleF(0f, 0f, (float)image.Width, 1E-05f);
			RectangleF destRect = new RectangleF(x, y, width, height);
			g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0000E671 File Offset: 0x0000C871
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

		// Token: 0x06000B51 RID: 2897 RVA: 0x0000E69A File Offset: 0x0000C89A
		public void setBackgroundImage(Image image)
		{
			if (this.backgroundImage != image)
			{
				this.backgroundImage = image;
				this.forceBackgroundRedraw = true;
			}
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0000E6B3 File Offset: 0x0000C8B3
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0000E6C3 File Offset: 0x0000C8C3
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0000E6D3 File Offset: 0x0000C8D3
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0000E6E5 File Offset: 0x0000C8E5
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0000E6F2 File Offset: 0x0000C8F2
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0000E700 File Offset: 0x0000C900
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0000E70D File Offset: 0x0000C90D
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0000E71A File Offset: 0x0000C91A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x000E39B8 File Offset: 0x000E1BB8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.Name = "ChatScreenManager";
			base.Size = new Size(630, 458);
			base.ResumeLayout(false);
		}

		// Token: 0x04000F6E RID: 3950
		private DockWindow dockWindow;

		// Token: 0x04000F6F RID: 3951
		private ChatScreen chatScreen = new ChatScreen();

		// Token: 0x04000F70 RID: 3952
		private bool docked;

		// Token: 0x04000F71 RID: 3953
		private bool initScreen = true;

		// Token: 0x04000F72 RID: 3954
		private bool chatBanned;

		// Token: 0x04000F73 RID: 3955
		private int lastFloatX;

		// Token: 0x04000F74 RID: 3956
		private int lastFloatY;

		// Token: 0x04000F75 RID: 3957
		private Bitmap _backBuffer;

		// Token: 0x04000F76 RID: 3958
		private int currentPanelWidth;

		// Token: 0x04000F77 RID: 3959
		private int currentPanelHeight;

		// Token: 0x04000F78 RID: 3960
		public bool forceBackgroundRedraw = true;

		// Token: 0x04000F79 RID: 3961
		private Image backgroundImage;

		// Token: 0x04000F7A RID: 3962
		private DockableControl dockableControl;

		// Token: 0x04000F7B RID: 3963
		private IContainer components;
	}
}
