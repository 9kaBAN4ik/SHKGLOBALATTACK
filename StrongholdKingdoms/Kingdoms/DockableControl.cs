using System;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200019C RID: 412
	public class DockableControl
	{
		// Token: 0x06000FCD RID: 4045 RVA: 0x001161BC File Offset: 0x001143BC
		public DockableControl(UserControl self)
		{
			this.m_self = self;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x00011861 File Offset: 0x0000FA61
		public void setPosition(int x, int y)
		{
			if (this.m_self != null)
			{
				this.m_self.Location = new Point(x, y);
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0001187D File Offset: 0x0000FA7D
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.controlDockable = dockable;
			if (title != null)
			{
				this.popupTitle = title;
			}
			if (parent != null)
			{
				this.controlParentControl = parent;
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0001189A File Offset: 0x0000FA9A
		public void initProperties(bool dockable, string title, ContainerControl parent, bool showBar)
		{
			this.showTitleBar = showBar;
			this.initProperties(dockable, title, parent);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x000118AD File Offset: 0x0000FAAD
		public void initProperties(bool dockable, string title, ContainerControl parent, bool showBar, Color topColor, Color bottomColor)
		{
			this.topGradientColor = topColor;
			this.bottomGradientColor = bottomColor;
			this.initProperties(dockable, title, parent, showBar);
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x000118CA File Offset: 0x0000FACA
		public void setSizeableWindow()
		{
			this.sizeableWindow = true;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x000118D3 File Offset: 0x0000FAD3
		public void display(ContainerControl parent, int x, int y)
		{
			this.display(this.controlAsPopup, parent, x, y, false);
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000118E5 File Offset: 0x0000FAE5
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.display(asPopup, parent, x, y, false);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x000118F3 File Offset: 0x0000FAF3
		public void display(bool asPopup, ContainerControl parent, int x, int y, bool asCustomPanel)
		{
			this.display(asPopup, parent, x, y, asCustomPanel, false);
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x00116230 File Offset: 0x00114430
		public void display(bool asPopup, ContainerControl parent, int x, int y, bool asCustomPanel, bool inTaskBar)
		{
			this.closeControl(true);
			if (parent != null)
			{
				this.controlParentControl = parent;
			}
			this.controlAsPopup = asPopup;
			int num = this.showTitleBar ? 30 : 0;
			if (!asPopup)
			{
				if (x != -10000)
				{
					this.controlDockedX = x;
					this.controlDockedY = y;
				}
				IDockWindow dockWindow = (IDockWindow)this.controlParentControl;
				if (dockWindow != null)
				{
					dockWindow.AddControl(this.m_self, this.controlDockedX, this.controlDockedY);
					this.controlActive = true;
				}
				return;
			}
			if (!asCustomPanel)
			{
				this.m_popup = new SHKForm();
			}
			else
			{
				MyFormBase myFormBase = new MyFormBase();
				myFormBase.ShowBar = this.showTitleBar;
				myFormBase.setGradient(this.topGradientColor, this.bottomGradientColor);
				this.m_popup = myFormBase;
			}
			if (inTaskBar)
			{
				this.m_popup.ShowInTaskbar = true;
			}
			this.m_popup.SuspendLayout();
			this.m_popup.Icon = Resources.shk_icon;
			this.m_popup.ClientSize = new Size(this.m_self.Size.Width, this.m_self.Size.Height);
			bool flag = false;
			if (this.m_self.Name == "ChatScreen")
			{
				flag = true;
				this.m_popup.MaximizeBox = true;
				this.m_popup.MinimizeBox = true;
				this.m_popup.ControlBox = true;
				this.m_popup.FormClosing += ((ChatScreen)this.m_self).closeClickForm;
				((MyFormBase)this.m_popup).Resizable = true;
			}
			else
			{
				this.m_popup.MaximizeBox = false;
				this.m_popup.MinimizeBox = false;
				this.m_popup.ControlBox = false;
			}
			this.m_popup.Name = this.m_self.Name + "Popup";
			if (this.controlPopupX == -10000)
			{
				this.m_popup.StartPosition = FormStartPosition.WindowsDefaultLocation;
			}
			else
			{
				this.m_popup.StartPosition = FormStartPosition.Manual;
				this.m_popup.Location = new Point(this.controlPopupX, this.controlPopupY);
			}
			if (!asCustomPanel)
			{
				this.m_self.Location = new Point(0, 0);
			}
			else
			{
				this.m_self.Location = new Point(0, num);
				this.m_popup.StartPosition = FormStartPosition.CenterScreen;
			}
			this.m_popup.Text = this.popupTitle;
			if (asCustomPanel)
			{
				((MyFormBase)this.m_popup).Title = this.popupTitle;
				this.m_popup.Text = this.popupTitle;
				this.m_self.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.m_popup.MinimumSize = new Size(this.m_self.Width, this.m_self.Height + num);
			}
			else if (this.sizeableWindow)
			{
				this.m_self.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.m_popup.MinimumSize = new Size(this.m_self.MinimumSize.Width, this.m_self.MinimumSize.Height + num);
			}
			else
			{
				this.m_popup.MinimumSize = new Size(this.m_self.Size.Width, this.m_self.Size.Height);
			}
			this.m_popup.Controls.Add(this.m_self);
			if (asCustomPanel)
			{
				this.m_popup.FormBorderStyle = FormBorderStyle.None;
				if (flag)
				{
					((MyFormBase)this.m_popup).ShowClose = true;
					((MyFormBase)this.m_popup).showMinMax();
				}
			}
			else if (!this.sizeableWindow)
			{
				this.m_popup.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			}
			else if (!flag)
			{
				this.m_popup.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
			else
			{
				this.m_popup.FormBorderStyle = FormBorderStyle.Sizable;
			}
			this.m_popup.FormClosing += this.formClosingCallback;
			this.m_popup.ResumeLayout(false);
			this.m_popup.PerformLayout();
			this.m_popup.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.m_popup.Show();
			this.controlPopupX = this.m_popup.Location.X;
			this.controlPopupY = this.m_popup.Location.Y;
			this.controlActive = true;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00011903 File Offset: 0x0000FB03
		public void controlDockToggle()
		{
			if (this.controlAsPopup)
			{
				this.display(false, this.controlParentControl, this.controlDockedX, this.controlDockedY);
				return;
			}
			this.display(true, this.controlParentControl, this.controlPopupX, this.controlPopupY);
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00116688 File Offset: 0x00114888
		public void closeControl(bool closeAllIncludingPopups)
		{
			if (!this.controlActive || (!closeAllIncludingPopups && this.controlAsPopup))
			{
				return;
			}
			if (!this.controlAsPopup)
			{
				IDockWindow dockWindow = (IDockWindow)this.controlParentControl;
				dockWindow.RemoveControl(this.m_self);
			}
			else if (this.m_popup != null)
			{
				if (this.m_popup.Created)
				{
					this.controlPopupX = this.m_popup.Location.X;
					this.controlPopupY = this.m_popup.Location.Y;
					this.m_popup.Controls.Remove(this.m_self);
					this.controlActive = false;
					this.m_popup.Close();
				}
				this.m_popup = null;
			}
			this.controlActive = false;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00011940 File Offset: 0x0000FB40
		public bool isVisible()
		{
			return this.controlActive;
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x00011948 File Offset: 0x0000FB48
		public bool isPopup()
		{
			return this.controlActive && this.controlAsPopup;
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x0001195A File Offset: 0x0000FB5A
		private void formClosingCallback(object sender, FormClosingEventArgs e)
		{
			if (this.controlActive)
			{
				if (this.controlDockable)
				{
					this.display(false, this.controlParentControl, this.controlDockedX, this.controlDockedY);
					return;
				}
				this.closeControl(true);
			}
		}

		// Token: 0x040015F4 RID: 5620
		private UserControl m_self;

		// Token: 0x040015F5 RID: 5621
		private Form m_popup;

		// Token: 0x040015F6 RID: 5622
		private bool controlActive;

		// Token: 0x040015F7 RID: 5623
		private bool controlAsPopup;

		// Token: 0x040015F8 RID: 5624
		private int controlDockedX;

		// Token: 0x040015F9 RID: 5625
		private int controlDockedY;

		// Token: 0x040015FA RID: 5626
		private int controlPopupX = -10000;

		// Token: 0x040015FB RID: 5627
		private int controlPopupY = -10000;

		// Token: 0x040015FC RID: 5628
		private ContainerControl controlParentControl;

		// Token: 0x040015FD RID: 5629
		private bool controlDockable = true;

		// Token: 0x040015FE RID: 5630
		private bool showTitleBar = true;

		// Token: 0x040015FF RID: 5631
		private string popupTitle = "";

		// Token: 0x04001600 RID: 5632
		private Color topGradientColor = Color.FromArgb(86, 98, 106);

		// Token: 0x04001601 RID: 5633
		private Color bottomGradientColor = Color.FromArgb(159, 180, 193);

		// Token: 0x04001602 RID: 5634
		private bool sizeableWindow;
	}
}
