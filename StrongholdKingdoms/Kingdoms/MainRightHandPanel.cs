using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200022D RID: 557
	public class MainRightHandPanel : UserControl, IDockWindow
	{
		// Token: 0x0600184C RID: 6220 RVA: 0x000191A6 File Offset: 0x000173A6
		public void AddControl(UserControl control, int x, int y)
		{
			this.dockWindow.AddControl(control, x, y);
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x000191B6 File Offset: 0x000173B6
		public void RemoveControl(UserControl control)
		{
			this.dockWindow.RemoveControl(control);
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x000191C4 File Offset: 0x000173C4
		public MainRightHandPanel()
		{
			this.dockWindow = new DockWindow(this);
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x00180DE0 File Offset: 0x0017EFE0
		public static CustomSelfDrawPanel.CSDButton getMRHPButton(MainRightHandPanel.MRHPButton buttonType)
		{
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			switch (buttonType)
			{
			case MainRightHandPanel.MRHPButton.LAST_REPORT:
				csdbutton.ImageNorm = GFXLibrary.mrhp_reports;
				csdbutton.OverBrighten = true;
				csdbutton.MoveOnClick = true;
				break;
			case MainRightHandPanel.MRHPButton.ATTACK:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[1];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[8];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[15];
				break;
			case MainRightHandPanel.MRHPButton.REINFORCE:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[2];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[9];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[16];
				break;
			case MainRightHandPanel.MRHPButton.SCOUT:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[3];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[10];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[17];
				break;
			case MainRightHandPanel.MRHPButton.MONK:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[4];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[11];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[18];
				break;
			case MainRightHandPanel.MRHPButton.VASSAL:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[5];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[12];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[19];
				break;
			case MainRightHandPanel.MRHPButton.TRADE:
				csdbutton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[0];
				csdbutton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[7];
				csdbutton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[14];
				break;
			}
			return csdbutton;
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x000191FF File Offset: 0x000173FF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00180FA0 File Offset: 0x0017F1A0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			this.BackgroundImage = Resources.right_side_panel_large_stone_tan;
			base.Name = "MainRightHandPanel";
			base.Size = new Size(200, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040028CF RID: 10447
		private DockWindow dockWindow;

		// Token: 0x040028D0 RID: 10448
		private IContainer components;

		// Token: 0x0200022E RID: 558
		public enum MRHPButton
		{
			// Token: 0x040028D2 RID: 10450
			LAST_REPORT,
			// Token: 0x040028D3 RID: 10451
			ATTACK,
			// Token: 0x040028D4 RID: 10452
			REINFORCE,
			// Token: 0x040028D5 RID: 10453
			SCOUT,
			// Token: 0x040028D6 RID: 10454
			MONK,
			// Token: 0x040028D7 RID: 10455
			VASSAL,
			// Token: 0x040028D8 RID: 10456
			TRADE
		}
	}
}
