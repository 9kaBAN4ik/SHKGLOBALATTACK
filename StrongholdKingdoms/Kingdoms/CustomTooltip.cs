using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000190 RID: 400
	public partial class CustomTooltip : Form
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000F78 RID: 3960 RVA: 0x0000A849 File Offset: 0x00008A49
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00011418 File Offset: 0x0000F618
		public CustomTooltip()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0001143B File Offset: 0x0000F63B
		public void setPosition(int x, int y)
		{
			base.Location = new Point(x, y);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0001144A File Offset: 0x0000F64A
		public void setText(string text, int tooltipID, int data, bool force)
		{
			this.customPanel.setText(text, tooltipID, data, this, force);
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x0001145D File Offset: 0x0000F65D
		public void hidingTooltip()
		{
			this.customPanel.hidingTooltip();
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0001146A File Offset: 0x0000F66A
		public void closing()
		{
			CustomTooltipManager.MouseLeaveTooltipAreaStored();
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x0010933C File Offset: 0x0010753C
		public void showTooltip(bool doShow, Form parentWindow)
		{
			try
			{
				InterfaceMgr.Instance.setCurrentCustomTooltip(this);
				if (parentWindow == null)
				{
					parentWindow = InterfaceMgr.Instance.ParentForm;
				}
				if (doShow)
				{
					base.Show(parentWindow);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x00109384 File Offset: 0x00107584
		public void updateLocation()
		{
			if (!base.IsDisposed)
			{
				Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
				int num = point.X + 15;
				int num2 = point.Y + 15;
				Screen screen = Screen.FromPoint(point);
				int num3 = num + base.Width;
				int num4 = 0;
				CustomTooltip.screenEdgeTooltip = false;
				if (num3 > screen.WorkingArea.Width + screen.WorkingArea.X)
				{
					num = screen.WorkingArea.Width + screen.WorkingArea.X - base.Width;
					num4++;
				}
				int num5 = num2 + base.Height;
				if (num5 > screen.WorkingArea.Height + screen.WorkingArea.Y)
				{
					num2 = screen.WorkingArea.Height + screen.WorkingArea.Y - base.Height;
					num4++;
				}
				if (num4 == 2)
				{
					CustomTooltip.screenEdgeTooltip = true;
				}
				this.setPosition(num, num2);
			}
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x001094AC File Offset: 0x001076AC
		public static void CreateToolTip(string text, int tooltipID, int data, Form parentWindow)
		{
			bool flag = false;
			CustomTooltip customTooltip = InterfaceMgr.Instance.getCustomTooltip();
			if (parentWindow == null)
			{
				parentWindow = InterfaceMgr.Instance.ParentForm;
			}
			if (customTooltip == null)
			{
				customTooltip = new CustomTooltip();
				flag = true;
				customTooltip.customPanel.MouseEnter += CustomTooltip.customPanel_MouseEnter;
				customTooltip.customPanel.MouseLeave += CustomTooltip.customPanel_MouseLeave;
			}
			else
			{
				if (parentWindow != CustomTooltip.lastParent)
				{
					customTooltip.Close();
					customTooltip = new CustomTooltip();
					flag = true;
					customTooltip.customPanel.MouseEnter += CustomTooltip.customPanel_MouseEnter;
					customTooltip.customPanel.MouseLeave += CustomTooltip.customPanel_MouseLeave;
				}
				if (!customTooltip.Created || !customTooltip.Visible)
				{
					flag = true;
				}
			}
			CustomTooltip.lastParent = parentWindow;
			customTooltip.updateLocation();
			customTooltip.setText(text, tooltipID, data, flag);
			customTooltip.showTooltip(flag, parentWindow);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00011471 File Offset: 0x0000F671
		public static void customPanel_MouseEnter(object sender, EventArgs e)
		{
			if (CustomTooltip.screenEdgeTooltip)
			{
				CustomTooltipManager.MouseEnterTooltipAreaStored();
			}
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x0001147F File Offset: 0x0000F67F
		public static void customPanel_MouseLeave(object sender, EventArgs e)
		{
			if (CustomTooltip.screenEdgeTooltip)
			{
				CustomTooltipManager.MouseLeaveTooltipAreaStored();
			}
		}

		// Token: 0x04001370 RID: 4976
		private static bool screenEdgeTooltip;

		// Token: 0x04001371 RID: 4977
		private static Form lastParent;
	}
}
