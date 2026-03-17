using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000B3 RID: 179
	public partial class AchievementPopup : Form
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0000A849 File Offset: 0x00008A49
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0005EFBC File Offset: 0x0005D1BC
		public AchievementPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.BackColor = Color.FromArgb(255, 240, 240, 240);
			this.background.Size = new Size(300, 100);
			this.background.BackColor = Color.FromArgb(255, 240, 240, 240);
			base.Controls.Add(this.background);
			this.background.MouseEnter += this.enterFunction;
			this.background.MouseLeave += this.exitFunction;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0000A86B File Offset: 0x00008A6B
		private void enterFunction(object sender, EventArgs e)
		{
			this.isInside = (this.lifespan > 15 && this.lifespan < 446);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0000A88D File Offset: 0x00008A8D
		private void exitFunction(object sender, EventArgs e)
		{
			this.isInside = false;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0005F0C8 File Offset: 0x0005D2C8
		public void activate(int id)
		{
			base.Location = new Point(InterfaceMgr.Instance.ParentMainWindow.Location.X + InterfaceMgr.Instance.ParentMainWindow.Width / 2 - 150, InterfaceMgr.Instance.ParentMainWindow.Location.Y + InterfaceMgr.Instance.ParentMainWindow.Height - 100 - 10);
			base.Width = 300;
			base.Height = 100;
			this.lifespan = 450;
			FontStyle style = FontStyle.Bold;
			this.title.Size = new Size(300, 20);
			this.title.Text = "";
			this.title.Position = new Point(0, 10);
			this.title.Font = FontManager.GetFont("Microsoft Sans Serif", 12f, style);
			this.title.Color = global::ARGBColors.Black;
			this.title.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.title.Visible = true;
			this.background.addControl(this.title);
			style = FontStyle.Regular;
			this.content.Size = new Size(200, 60);
			this.content.Text = "";
			this.content.Position = new Point(50, 30);
			this.content.Font = FontManager.GetFont("Microsoft Sans Serif", 10f, style);
			this.content.Color = global::ARGBColors.Black;
			this.content.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.content.Visible = true;
			this.background.addControl(this.content);
			this.gotoButton.Size = new Size(290, 90);
			this.gotoButton.Position = new Point(5, 5);
			this.gotoButton.FillRectColor = Color.FromArgb(0, 200, 220, 200);
			this.gotoButton.FillRectOverColor = Color.FromArgb(0, 210, 230, 210);
			this.gotoButton.Text.Position = new Point(0, 0);
			this.gotoButton.Text.Size = new Size(140, 20);
			this.gotoButton.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, style);
			this.gotoButton.Text.Color = global::ARGBColors.Black;
			this.gotoButton.TextYOffset = 0;
			this.gotoButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.gotoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openAchievementsFunction));
			this.background.addControl(this.gotoButton);
			this.closeButton.Size = new Size(150, 30);
			this.closeButton.Position = new Point(90, 70);
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Text.Position = new Point(0, 7);
			this.closeButton.Text.Size = new Size(150, 20);
			this.closeButton.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, style);
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.closeButton.TextYOffset = 0;
			this.closeButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeFunction));
			this.closeButton.ImageNorm = GFXLibrary.button_blue_01_normal;
			this.closeButton.ImageOver = GFXLibrary.button_blue_01_over;
			this.background.addControl(this.closeButton);
			this.icon.Position = new Point(2, 10);
			this.icon.Image = GFXLibrary.achievement_ribbons_centre[0];
			this.background.addControl(this.icon);
			base.Opacity = 0.0;
			this.populateControls(id);
			base.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0005F514 File Offset: 0x0005D714
		public void populateControls(int id)
		{
			if (id >= 1000)
			{
				this.title.Text = SK.Text("ACHIEVEMENT_OBTAINED", "Achievement Obtained!");
				string text = CustomTooltipManager.getAchievementTitle(id - 1000) + " (" + CustomTooltipManager.getAchievementRank(id - 1000) + ")";
				this.content.Text = text;
				this.icon.Image = GFXLibrary.medal_images[CustomSelfDrawPanel.MedalImage.getAchievementImage(id - 1000 & 4095)];
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0005F5A0 File Offset: 0x0005D7A0
		public void move()
		{
			base.Location = new Point(InterfaceMgr.Instance.ParentMainWindow.Location.X + InterfaceMgr.Instance.ParentMainWindow.Width / 2 - 150, InterfaceMgr.Instance.ParentMainWindow.Location.Y + InterfaceMgr.Instance.ParentMainWindow.Height - 100 - 10 + this.offsetY);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0005F61C File Offset: 0x0005D81C
		public void update()
		{
			base.Location = new Point(InterfaceMgr.Instance.ParentMainWindow.Location.X + InterfaceMgr.Instance.ParentMainWindow.Width / 2 - 150, InterfaceMgr.Instance.ParentMainWindow.Location.Y + InterfaceMgr.Instance.ParentMainWindow.Height - 100 - 10);
			if (!this.isInside)
			{
				if (this.lifespan > 0)
				{
					this.lifespan--;
				}
				if (this.lifespan > 445)
				{
					base.Opacity += 0.15;
				}
				else if (this.lifespan < 16)
				{
					base.Height -= 10;
					this.offsetY += 10;
					base.Location = new Point(base.Location.X, base.Location.Y + this.offsetY);
				}
				if (this.lifespan == 4)
				{
					base.Visible = false;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000A896 File Offset: 0x00008A96
		public bool isActive()
		{
			return this.lifespan > 0;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000A8A1 File Offset: 0x00008AA1
		private void closeFunction()
		{
			base.Visible = false;
			this.lifespan = 0;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000A8B1 File Offset: 0x00008AB1
		private void openAchievementsFunction()
		{
			this.closeFunction();
			InterfaceMgr.Instance.getMainTabBar().changeTab(4);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000A8C9 File Offset: 0x00008AC9
		public void setClickDelegate(CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate del)
		{
			this.gotoButton.setClickDelegate(del);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000A8D7 File Offset: 0x00008AD7
		public bool isMouseInside()
		{
			return this.isInside;
		}

		// Token: 0x040005AC RID: 1452
		private const int MAX_LIFESPAN = 450;

		// Token: 0x040005AE RID: 1454
		private int lifespan;

		// Token: 0x040005AF RID: 1455
		private int offsetY;

		// Token: 0x040005B0 RID: 1456
		private bool isInside;

		// Token: 0x040005B1 RID: 1457
		private MenuBackground background = new MenuBackground();

		// Token: 0x040005B2 RID: 1458
		private CustomSelfDrawPanel.CSDButton gotoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005B3 RID: 1459
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040005B4 RID: 1460
		private CustomSelfDrawPanel.CSDLabel title = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005B5 RID: 1461
		private CustomSelfDrawPanel.CSDLabel content = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040005B6 RID: 1462
		private CustomSelfDrawPanel.CSDImage icon = new CustomSelfDrawPanel.CSDImage();
	}
}
