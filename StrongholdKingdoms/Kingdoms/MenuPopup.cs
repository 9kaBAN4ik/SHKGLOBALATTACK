using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000241 RID: 577
	public partial class MenuPopup : Form
	{
		// Token: 0x170001D6 RID: 470
		// (set) Token: 0x0600198E RID: 6542 RVA: 0x00019D40 File Offset: 0x00017F40
		public bool CloseOnClick
		{
			set
			{
				this.closeOnClick = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (set) Token: 0x0600198F RID: 6543 RVA: 0x00019D49 File Offset: 0x00017F49
		public bool CloseOnDoubleClick
		{
			set
			{
				this.closeOnDoubleClick = value;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06001990 RID: 6544 RVA: 0x0000A849 File Offset: 0x00008A49
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x0019963C File Offset: 0x0019783C
		public MenuPopup()
		{
			InterfaceMgr.Instance.closeMenuPopup();
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.BackColor = Color.FromArgb(255, 232, 230, 228);
			this.background.MouseEnter += this.MenuPopup_MouseEnter;
			this.background.MouseLeave += this.MenuPopup_MouseLeave;
			base.Controls.Add(this.background);
			this.currentControls.Clear();
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x00019D52 File Offset: 0x00017F52
		public void setLineHeight(int height)
		{
			this.lineHeight = height;
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00019D5B File Offset: 0x00017F5B
		public void setBackColour(Color col)
		{
			this.BackColor = col;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x00019D64 File Offset: 0x00017F64
		public void setFixedWidth(int width)
		{
			this.fixedWidth = width;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00019D6D File Offset: 0x00017F6D
		public void closeOnClickOnly()
		{
			this.background.MouseEnter -= this.MenuPopup_MouseEnter;
			this.background.MouseLeave -= this.MenuPopup_MouseLeave;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x0019973C File Offset: 0x0019793C
		public static bool isAMenuVisible()
		{
			MenuPopup menuPopup = InterfaceMgr.Instance.getMenuPopup();
			return menuPopup != null && menuPopup.Visible;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x0001143B File Offset: 0x0000F63B
		public void setPosition(int x, int y)
		{
			base.Location = new Point(x, y);
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x00019D9D File Offset: 0x00017F9D
		public void setCallBack(MenuPopup.MenuCallback callback)
		{
			this.menuCallback = callback;
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x00019DA6 File Offset: 0x00017FA6
		public void setDoubleClickCallBack(MenuPopup.MenuCallback callback)
		{
			this.doubleClickCallback = callback;
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x00019DAF File Offset: 0x00017FAF
		public void mouseOverDelegates(MenuPopup.MenuItemRolloverDelegate overDel, MenuPopup.MenuItemRolloverDelegate leaveDel)
		{
			this.mouseOverDelegate = overDel;
			this.mouseLeaveDelegate = leaveDel;
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x00019DBF File Offset: 0x00017FBF
		public void mouseOverItem()
		{
			if (this.mouseOverDelegate != null && this.background.OverControl != null)
			{
				this.mouseOverDelegate(this.background.OverControl.Data);
			}
		}

		// Token: 0x0600199C RID: 6556 RVA: 0x00019DF1 File Offset: 0x00017FF1
		public void mouseLeaveItem()
		{
			if (this.mouseLeaveDelegate != null)
			{
				this.mouseLeaveDelegate(0);
			}
		}

		// Token: 0x0600199D RID: 6557 RVA: 0x00019E07 File Offset: 0x00018007
		public CustomSelfDrawPanel.CSDButton addMenuItem(string ident, int id)
		{
			return this.addMenuItem(ident, id, false);
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x00199764 File Offset: 0x00197964
		public CustomSelfDrawPanel.CSDButton addMenuItem(string ident, int id, bool bold)
		{
			FontStyle style = FontStyle.Regular;
			if (bold)
			{
				style = FontStyle.Bold;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.Position = new Point(this.curXPos, this.curYPos);
			Graphics graphics = base.CreateGraphics();
			Size size = graphics.MeasureString(ident, FontManager.GetFont("Microsoft Sans Serif", 8.25f, style), 1000).ToSize();
			graphics.Dispose();
			csdbutton.Size = new Size(size.Width + 4 + 8, this.lineHeight);
			csdbutton.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			csdbutton.Text.Text = ident;
			csdbutton.Text.Position = new Point(4, 0);
			csdbutton.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, style);
			csdbutton.Text.Color = global::ARGBColors.Black;
			csdbutton.TextYOffset = 0;
			csdbutton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			if (this.mouseOverDelegate != null)
			{
				csdbutton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseOverItem), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseLeaveItem));
			}
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.Button_Click));
			csdbutton.Data = id;
			this.background.addControl(csdbutton);
			this.currentControls.Add(csdbutton);
			int width = csdbutton.Width;
			if (width > this.columnWidth)
			{
				this.columnWidth = width;
			}
			this.curYPos += 1 + csdbutton.Height;
			int num = 0;
			if (this.curYPos > this.maxYPos + num)
			{
				this.maxYPos = this.curYPos - num;
			}
			return csdbutton;
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x001998FC File Offset: 0x00197AFC
		public void addBar()
		{
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.Position = new Point(this.curXPos + 3, this.curYPos + 3);
			csdfill.FillColor = Color.FromArgb(96, 0, 0, 0);
			csdfill.Size = new Size(6, 2);
			this.background.addControl(csdfill);
			this.currentControls.Add(csdfill);
			this.curYPos += 8;
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x00199970 File Offset: 0x00197B70
		private void updateCurrentControls(int width)
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.currentControls)
			{
				if (csdcontrol.GetType() == typeof(CustomSelfDrawPanel.CSDButton))
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)csdcontrol;
					csdbutton.Size = new Size(width, csdbutton.Height);
				}
				else if (csdcontrol.GetType() == typeof(CustomSelfDrawPanel.CSDFill))
				{
					CustomSelfDrawPanel.CSDFill csdfill = (CustomSelfDrawPanel.CSDFill)csdcontrol;
					csdfill.Size = new Size(width + 4 - 10, csdfill.Height);
				}
			}
			this.currentControls.Clear();
			this.maxWidth += width + 8;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x00019E12 File Offset: 0x00018012
		public void newColumn()
		{
			this.updateCurrentControls(this.columnWidth);
			this.curXPos += this.columnWidth + 4;
			this.curYPos = 4;
			this.columnWidth = 0;
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x00199A34 File Offset: 0x00197C34
		public void clearHighlights()
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.background.baseControl.Controls)
			{
				if (csdcontrol.GetType() == typeof(CustomSelfDrawPanel.CSDButton))
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)csdcontrol;
					if (csdbutton.FillRectVariant)
					{
						csdbutton.FillRectVariant = false;
						csdbutton.invalidate();
					}
				}
			}
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x00199AB8 File Offset: 0x00197CB8
		public void highlightByID(int id, Color col)
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.background.baseControl.Controls)
			{
				if (csdcontrol.GetType() == typeof(CustomSelfDrawPanel.CSDButton))
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)csdcontrol;
					if (csdbutton.Data == id)
					{
						csdbutton.FillRectColor = col;
						csdbutton.invalidate();
					}
				}
			}
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x00199B40 File Offset: 0x00197D40
		public void showMenu()
		{
			if (this.fixedWidth >= 0)
			{
				this.columnWidth = this.fixedWidth - 8;
			}
			this.updateCurrentControls(this.columnWidth);
			base.Width = this.maxWidth;
			base.Height = this.maxYPos;
			this.background.Size = new Size(base.Width, base.Height);
			Rectangle windowRect = InterfaceMgr.Instance.getWindowRect();
			if (base.Location.X + base.Width > windowRect.Right)
			{
				Point location = base.Location;
				location.X = windowRect.Right - base.Width - 5;
				base.Location = location;
			}
			InterfaceMgr.Instance.setCurrentMenuPopup(this);
			base.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x00019E43 File Offset: 0x00018043
		private void MenuPopup_MouseEnter(object sender, EventArgs e)
		{
			this.entered = true;
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x00199C10 File Offset: 0x00197E10
		private void MenuPopup_MouseLeave(object sender, EventArgs e)
		{
			if (this.entered && InterfaceMgr.Instance.ParentForm != null)
			{
				Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
				InterfaceMgr.Instance.ParentForm.PointToClient(point);
				if (!new Rectangle(base.Location, base.Size).Contains(point))
				{
					InterfaceMgr.Instance.closeMenuPopup();
				}
			}
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x00199C8C File Offset: 0x00197E8C
		private void Button_Click()
		{
			if (this.doubleClickCallback != null)
			{
				if (this.background.ClickedControl.Data == this.lastClickedData && this.lastClickedData != -1000)
				{
					this.doubleClickCallback(this.lastClickedData);
					if (this.closeOnDoubleClick)
					{
						InterfaceMgr.Instance.closeMenuPopup();
					}
					return;
				}
				this.mouseClickedLastTime = DateTime.Now;
				this.lastClickedData = this.background.ClickedControl.Data;
				if (this.menuCallback != null)
				{
					this.menuCallback(this.background.ClickedControl.Data);
					return;
				}
			}
			else
			{
				if (this.closeOnClick)
				{
					InterfaceMgr.Instance.closeMenuPopup();
				}
				if (this.menuCallback != null)
				{
					this.menuCallback(this.background.ClickedControl.Data);
				}
			}
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x00199D68 File Offset: 0x00197F68
		public void update()
		{
			if (this.lastClickedData != -1000 && (DateTime.Now - this.mouseClickedLastTime).TotalMilliseconds > 500.0)
			{
				this.lastClickedData = -1000;
				if (this.closeOnClick)
				{
					InterfaceMgr.Instance.closeMenuPopup();
				}
			}
		}

		// Token: 0x04002A31 RID: 10801
		private int curYPos = 4;

		// Token: 0x04002A32 RID: 10802
		private int curXPos = 4;

		// Token: 0x04002A33 RID: 10803
		private int maxYPos = 4;

		// Token: 0x04002A34 RID: 10804
		private int columnWidth;

		// Token: 0x04002A35 RID: 10805
		private int maxWidth;

		// Token: 0x04002A36 RID: 10806
		private bool entered;

		// Token: 0x04002A37 RID: 10807
		private bool closeOnClick = true;

		// Token: 0x04002A38 RID: 10808
		private bool closeOnDoubleClick = true;

		// Token: 0x04002A39 RID: 10809
		private MenuBackground background = new MenuBackground();

		// Token: 0x04002A3A RID: 10810
		private int lineHeight = 23;

		// Token: 0x04002A3B RID: 10811
		private int fixedWidth = -1;

		// Token: 0x04002A3C RID: 10812
		private List<CustomSelfDrawPanel.CSDControl> currentControls = new List<CustomSelfDrawPanel.CSDControl>();

		// Token: 0x04002A3D RID: 10813
		private MenuPopup.MenuCallback menuCallback;

		// Token: 0x04002A3E RID: 10814
		private MenuPopup.MenuCallback doubleClickCallback;

		// Token: 0x04002A3F RID: 10815
		private MenuPopup.MenuItemRolloverDelegate mouseOverDelegate;

		// Token: 0x04002A40 RID: 10816
		private MenuPopup.MenuItemRolloverDelegate mouseLeaveDelegate;

		// Token: 0x04002A41 RID: 10817
		private int lastClickedData = -1000;

		// Token: 0x04002A42 RID: 10818
		private DateTime mouseClickedLastTime = DateTime.MinValue;

		// Token: 0x02000242 RID: 578
		// (Invoke) Token: 0x060019AC RID: 6572
		public delegate void MenuCallback(int id);

		// Token: 0x02000243 RID: 579
		// (Invoke) Token: 0x060019B0 RID: 6576
		public delegate void MenuItemRolloverDelegate(int id);
	}
}
