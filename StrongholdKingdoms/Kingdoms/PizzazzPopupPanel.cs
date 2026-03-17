using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000271 RID: 625
	public class PizzazzPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001BE4 RID: 7140 RVA: 0x001B2930 File Offset: 0x001B0B30
		public PizzazzPopupPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x001B2A74 File Offset: 0x001B0C74
		public void init(int pizzazzImage)
		{
			Sound.playVillageEnvironmental(46, false, false);
			Sound.forceFullPlayOfNextEnvironmental();
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			this.background.Position = new Point(0, 0);
			this.background.Size = new Size(638, 328);
			base.addControl(this.background);
			this.background.Create(GFXLibrary._9sclice_fancy_top_left, GFXLibrary._9sclice_fancy_top_mid, GFXLibrary._9sclice_fancy_top_right, GFXLibrary._9sclice_fancy_mid_left, GFXLibrary._9sclice_fancy_mid_mid, GFXLibrary._9sclice_fancy_mid_right, GFXLibrary._9sclice_fancy_bottom_left, GFXLibrary._9sclice_fancy_bottom_mid, GFXLibrary._9sclice_fancy_bottom_right);
			this.background.ForceTiling();
			this.rewardArea.Position = new Point(191, 41);
			this.rewardArea.Size = new Size(256, 256);
			this.background.addControl(this.rewardArea);
			this.firework1.init(this.rewardArea, 36, 0);
			this.firework2.init(this.rewardArea, 32, 0);
			this.firework3.init(this.rewardArea, 28, 0);
			this.firework4.init(this.rewardArea, 24, 0);
			this.firework5.init(this.rewardArea, 20, 0);
			this.firework6.init(this.rewardArea, 16, 0);
			this.firework7.init(this.rewardArea, 12, 0);
			this.firework8.init(this.rewardArea, 8, 0);
			this.firework9.init(this.rewardArea, 4, 0);
			this.firework10.init(this.rewardArea, 0, 0);
			this.firework1a.init(this.rewardArea, 36, 1);
			this.firework2a.init(this.rewardArea, 32, 1);
			this.firework3a.init(this.rewardArea, 28, 1);
			this.firework4a.init(this.rewardArea, 24, 1);
			this.firework5a.init(this.rewardArea, 20, 1);
			this.firework6a.init(this.rewardArea, 16, 1);
			this.firework7a.init(this.rewardArea, 12, 1);
			this.firework8a.init(this.rewardArea, 8, 1);
			this.firework9a.init(this.rewardArea, 4, 1);
			this.firework10a.init(this.rewardArea, 0, 1);
			this.starImage.Image = GFXLibrary.wheel_star[0];
			this.starImage.Position = new Point(0, 0);
			this.starImage.RotateCentre = new PointF(128f, 128f);
			this.starImage.Visible = false;
			this.starSpinMode = 1;
			this.rewardArea.addControl(this.starImage);
			switch (pizzazzImage)
			{
			case 1:
				this.rewardImage.Image = GFXLibrary.getCommodity64DSImage(13);
				this.rewardImage.Position = new Point(83, 79);
				this.rewardArea.addControl(this.rewardImage);
				return;
			case 2:
				this.rewardImage.Image = GFXLibrary.getCommodity64DSImage(6);
				this.rewardImage.Position = new Point(76, 76);
				this.rewardArea.addControl(this.rewardImage);
				this.reward2Image.Image = GFXLibrary.getCommodity64DSImage(7);
				this.reward2Image.Position = new Point(96, 96);
				this.rewardArea.addControl(this.reward2Image);
				return;
			case 3:
			case 5:
			case 6:
			case 8:
			case 10:
			{
				int num = -1;
				switch (pizzazzImage)
				{
				case 3:
					num = 2;
					break;
				case 5:
					num = 15;
					break;
				case 6:
					num = 1;
					break;
				case 8:
					num = 5;
					break;
				case 10:
					num = 14;
					break;
				}
				this.rewardImage.Image = GFXLibrary.wheel_icons[num];
				this.rewardImage.Size = new Size(128, 128);
				this.rewardImage.Position = new Point(64, 64);
				this.rewardArea.addControl(this.rewardImage);
				return;
			}
			case 4:
				this.rewardImage.Image = GFXLibrary.com_64_honour_DS;
				this.rewardImage.Position = new Point(84, 84);
				this.rewardArea.addControl(this.rewardImage);
				return;
			case 7:
				this.rewardImage.Image = GFXLibrary.PremiumTokens[4113][0];
				this.rewardImage.Position = new Point(96, 96);
				this.rewardImage.Size = new Size(this.rewardImage.Image.Width / 2, this.rewardImage.Image.Height / 2);
				this.rewardArea.addControl(this.rewardImage);
				return;
			case 9:
				this.rewardImage.Image = GFXLibrary.getCommodity64DSImage(6);
				this.rewardImage.Position = new Point(83, 79);
				this.rewardArea.addControl(this.rewardImage);
				return;
			default:
				return;
			}
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x001B3018 File Offset: 0x001B1218
		public void update()
		{
			float num = 1f;
			this.firework1.update();
			this.firework2.update();
			this.firework3.update();
			this.firework4.update();
			this.firework5.update();
			this.firework6.update();
			this.firework7.update();
			this.firework8.update();
			this.firework9.update();
			this.firework10.update();
			this.firework1a.update();
			this.firework2a.update();
			this.firework3a.update();
			this.firework4a.update();
			this.firework5a.update();
			this.firework6a.update();
			this.firework7a.update();
			this.firework8a.update();
			this.firework9a.update();
			this.firework10a.update();
			base.Invalidate();
			this.animCount += num;
			if (this.animCount >= 180f)
			{
				PizzazzPopupWindow.closePizzazz();
			}
			else if (this.animCount > 150f)
			{
				PizzazzPopupPanel.Firework.active = false;
			}
			if (this.starSpinMode <= 0)
			{
				return;
			}
			switch (this.starSpinMode)
			{
			case 1:
				this.starImage.Image = GFXLibrary.wheel_star[2];
				this.starImage.Visible = true;
				this.starImage.Alpha = 0.01f;
				this.starSpinMode++;
				this.starRotate = 0f;
				this.starRotateSpeed = 8f;
				this.starSpinCount = 200;
				break;
			case 2:
				this.starImage.Alpha += 0.2f * num;
				if (this.starImage.Alpha > 1f)
				{
					this.starImage.Alpha = 1f;
					this.starSpinMode++;
				}
				break;
			case 3:
				this.starSpinCount--;
				if (this.starSpinCount == 0)
				{
					this.starSpinMode++;
				}
				break;
			case 4:
				this.starImage.Alpha -= 0.1f * num;
				if (this.starImage.Alpha < 0f)
				{
					this.starImage.Alpha = 0f;
					this.starImage.Visible = false;
					this.starSpinMode = 0;
					this.starRotateSpeed = 0f;
				}
				break;
			}
			float num2 = this.starRotate;
			if (num2 >= 179.9f && num2 <= 180f)
			{
				num2 = 179.9f;
			}
			else if (num2 > 180f && num2 <= 180.1f)
			{
				num2 = 180.1f;
			}
			this.starImage.Rotate = num2;
			this.starRotate += this.starRotateSpeed * num;
			if (this.starRotate >= 360f)
			{
				this.starRotate -= 360f;
			}
			if (this.starRotateSpeed <= 8f)
			{
				this.starImage.Image = GFXLibrary.wheel_star[0];
			}
			else if (this.starRotateSpeed < 15f)
			{
				this.starImage.Image = GFXLibrary.wheel_star[1];
			}
			else
			{
				this.starImage.Image = GFXLibrary.wheel_star[2];
			}
			this.starImage.invalidate();
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x0001B9F3 File Offset: 0x00019BF3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x0001BA12 File Offset: 0x00019C12
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04002C9F RID: 11423
		public const int PIZZAZZ_IMAGE_APPLES = 1;

		// Token: 0x04002CA0 RID: 11424
		public const int PIZZAZZ_IMAGE_WOOD_STONE = 2;

		// Token: 0x04002CA1 RID: 11425
		public const int PIZZAZZ_IMAGE_RESEARCH_POINT = 3;

		// Token: 0x04002CA2 RID: 11426
		public const int PIZZAZZ_IMAGE_HONOUR = 4;

		// Token: 0x04002CA3 RID: 11427
		public const int PIZZAZZ_IMAGE_CARD_WOOD = 5;

		// Token: 0x04002CA4 RID: 11428
		public const int PIZZAZZ_IMAGE_CARD_POINTS = 6;

		// Token: 0x04002CA5 RID: 11429
		public const int PIZZAZZ_IMAGE_PREMIUM = 7;

		// Token: 0x04002CA6 RID: 11430
		public const int PIZZAZZ_IMAGE_GOLD = 8;

		// Token: 0x04002CA7 RID: 11431
		public const int PIZZAZZ_IMAGE_WOOD = 9;

		// Token: 0x04002CA8 RID: 11432
		public const int PIZZAZZ_IMAGE_CARD_CASTLE = 10;

		// Token: 0x04002CA9 RID: 11433
		private const int CENTER_X = 191;

		// Token: 0x04002CAA RID: 11434
		private const int CENTER_Y = 41;

		// Token: 0x04002CAB RID: 11435
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002CAC RID: 11436
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002CAD RID: 11437
		private CustomSelfDrawPanel.CSDImage starImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CAE RID: 11438
		private CustomSelfDrawPanel.CSDArea rewardArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002CAF RID: 11439
		private CustomSelfDrawPanel.CSDImage rewardImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CB0 RID: 11440
		private CustomSelfDrawPanel.CSDImage reward2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CB1 RID: 11441
		private int starSpinMode;

		// Token: 0x04002CB2 RID: 11442
		private int starSpinCount;

		// Token: 0x04002CB3 RID: 11443
		private float starRotate;

		// Token: 0x04002CB4 RID: 11444
		private float starRotateSpeed;

		// Token: 0x04002CB5 RID: 11445
		private float animCount;

		// Token: 0x04002CB6 RID: 11446
		private PizzazzPopupPanel.Firework firework1 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CB7 RID: 11447
		private PizzazzPopupPanel.Firework firework2 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CB8 RID: 11448
		private PizzazzPopupPanel.Firework firework3 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CB9 RID: 11449
		private PizzazzPopupPanel.Firework firework4 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBA RID: 11450
		private PizzazzPopupPanel.Firework firework5 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBB RID: 11451
		private PizzazzPopupPanel.Firework firework6 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBC RID: 11452
		private PizzazzPopupPanel.Firework firework7 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBD RID: 11453
		private PizzazzPopupPanel.Firework firework8 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBE RID: 11454
		private PizzazzPopupPanel.Firework firework9 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CBF RID: 11455
		private PizzazzPopupPanel.Firework firework10 = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC0 RID: 11456
		private PizzazzPopupPanel.Firework firework1a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC1 RID: 11457
		private PizzazzPopupPanel.Firework firework2a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC2 RID: 11458
		private PizzazzPopupPanel.Firework firework3a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC3 RID: 11459
		private PizzazzPopupPanel.Firework firework4a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC4 RID: 11460
		private PizzazzPopupPanel.Firework firework5a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC5 RID: 11461
		private PizzazzPopupPanel.Firework firework6a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC6 RID: 11462
		private PizzazzPopupPanel.Firework firework7a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC7 RID: 11463
		private PizzazzPopupPanel.Firework firework8a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC8 RID: 11464
		private PizzazzPopupPanel.Firework firework9a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CC9 RID: 11465
		private PizzazzPopupPanel.Firework firework10a = new PizzazzPopupPanel.Firework();

		// Token: 0x04002CCA RID: 11466
		private IContainer components;

		// Token: 0x02000272 RID: 626
		public class Firework : CustomSelfDrawPanel.CSDImage
		{
			// Token: 0x06001BE9 RID: 7145 RVA: 0x001B3388 File Offset: 0x001B1588
			public void init(CustomSelfDrawPanel.CSDControl parentControl, int initialProgress, int band)
			{
				PizzazzPopupPanel.Firework.active = true;
				this.m_band = band;
				base.Image = GFXLibrary.tutorial_reward_anim[0];
				base.RotateCentre = new PointF(64f, 64f);
				base.Visible = true;
				parentControl.addControl(this);
				this.restart();
				for (int i = 0; i < initialProgress; i++)
				{
					this.update();
				}
			}

			// Token: 0x06001BEA RID: 7146 RVA: 0x001B33F0 File Offset: 0x001B15F0
			public void restart()
			{
				if (PizzazzPopupPanel.Firework.active)
				{
					int degrees = PizzazzPopupPanel.Firework.baseAngle1;
					if (this.m_band == 0)
					{
						PizzazzPopupPanel.Firework.baseAngle1 -= 37;
					}
					else if (this.m_band == 1)
					{
						PizzazzPopupPanel.Firework.baseAngle2 -= 37;
						degrees = PizzazzPopupPanel.Firework.baseAngle2;
					}
					PointF pointF = GameEngine.Instance.GFX.rotatePoint(new PointF(1f, 0f), degrees);
					this.dx = pointF.X;
					this.dy = pointF.Y;
					this.pos = new PointF(64f, 64f);
					this.Position = new Point(64, 64);
					this.Rotate = 0f;
					this.count = 0f;
					base.Alpha = 1f;
					return;
				}
				base.Visible = false;
			}

			// Token: 0x06001BEB RID: 7147 RVA: 0x001B34C8 File Offset: 0x001B16C8
			public void update()
			{
				float num = 1f;
				if (this.count > 30f)
				{
					int num2 = (int)(40f - this.count);
					if (num2 > 10)
					{
						num2 = 10;
					}
					else if (num2 < 0)
					{
						num2 = 0;
					}
					base.Alpha = (float)num2 / 10f;
				}
				this.pos = new PointF(this.pos.X + this.dx * 4f * num, this.pos.Y + this.dy * 4f * num);
				this.Position = new Point((int)this.pos.X, (int)this.pos.Y);
				this.count += num;
				if (this.count >= 40f)
				{
					this.restart();
				}
				base.Image = GFXLibrary.tutorial_reward_anim[Math.Min((int)this.count / 2, 19)];
			}

			// Token: 0x04002CCB RID: 11467
			private const float rate = 4f;

			// Token: 0x04002CCC RID: 11468
			private const int max = 40;

			// Token: 0x04002CCD RID: 11469
			public static bool active = false;

			// Token: 0x04002CCE RID: 11470
			private static Random rand = new Random();

			// Token: 0x04002CCF RID: 11471
			private float dx;

			// Token: 0x04002CD0 RID: 11472
			private float dy;

			// Token: 0x04002CD1 RID: 11473
			private PointF pos;

			// Token: 0x04002CD2 RID: 11474
			private float count;

			// Token: 0x04002CD3 RID: 11475
			private static int baseAngle1 = 0;

			// Token: 0x04002CD4 RID: 11476
			private static int baseAngle2 = 180;

			// Token: 0x04002CD5 RID: 11477
			private int m_band;
		}
	}
}
