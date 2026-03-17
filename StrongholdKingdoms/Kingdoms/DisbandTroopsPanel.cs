using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000199 RID: 409
	public class DisbandTroopsPanel : CustomSelfDrawPanel
	{
		// Token: 0x06000FBC RID: 4028 RVA: 0x00115498 File Offset: 0x00113698
		public DisbandTroopsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00011772 File Offset: 0x0000F972
		public void init(MyFormBase parent, int troopType, bool isTroops)
		{
			this.init(parent, troopType, isTroops, null);
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x00115528 File Offset: 0x00113728
		public void init(MyFormBase parent, int troopType, bool isTroops, object back)
		{
			base.clearControls();
			this.imgBackground.Image = (Image)back;
			this.m_isTroops = isTroops;
			this.m_parent = parent;
			base.Size = this.m_parent.Size;
			this.BackColor = global::ARGBColors.Transparent;
			this.imgBackground.Size = base.Size;
			this.imgBackground.Position = new Point(0, 0);
			this.imgBackground.Visible = true;
			base.addControl(this.imgBackground);
			VillageMap village = GameEngine.Instance.Village;
			this.m_troopType = troopType;
			int max = 0;
			this.lblTroopType.Text = "";
			this.lblTroopType.Color = global::ARGBColors.White;
			this.lblTroopType.DropShadowColor = global::ARGBColors.Black;
			this.lblTroopType.Position = new Point(0, 10);
			this.lblTroopType.Size = new Size(base.Width, 24);
			this.lblTroopType.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblTroopType.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.lblMax.Text = "";
			if (village != null)
			{
				switch (troopType)
				{
				case 1:
					this.lblTroopType.Text = SK.Text("GENERIC_Monks", "Monks");
					max = village.calcTotalMonksAtHome();
					break;
				case 2:
					this.lblTroopType.Text = SK.Text("GENERIC_Merchants", "Merchants");
					max = village.calcTotalTradersAtHome();
					break;
				case 3:
					this.lblTroopType.Text = SK.Text("GENERIC_Spiese", "Spies");
					max = 0;
					break;
				case 4:
					this.lblTroopType.Text = SK.Text("GENERIC_Scouts", "Scouts");
					max = village.calcTotalScoutsAtHome();
					break;
				default:
					switch (troopType)
					{
					case 70:
						this.lblTroopType.Text = SK.Text("GENERIC_Peasants", "Peasants");
						max = village.m_numPeasants;
						break;
					case 71:
						this.lblTroopType.Text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
						max = village.m_numSwordsmen;
						break;
					case 72:
						this.lblTroopType.Text = SK.Text("GENERIC_Archers", "Archers");
						max = village.m_numArchers;
						break;
					case 73:
						this.lblTroopType.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
						max = village.m_numPikemen;
						break;
					case 74:
						this.lblTroopType.Text = SK.Text("GENERIC_Catapults", "Catapults");
						max = village.m_numCatapults;
						break;
					default:
						if (troopType == 100)
						{
							this.lblTroopType.Text = SK.Text("GENERIC_Captains", "Captains");
							max = village.m_numCaptains;
						}
						break;
					}
					break;
				}
				this.lblMax.Text = max.ToString();
			}
			this.tbTroopsDisband.Position = new Point(base.Width / 2 - GFXLibrary.int_slidebar_ruler.Width / 2, 40);
			this.tbTroopsDisband.Size = new Size(base.Width - 50, 23);
			this.tbTroopsDisband.StepValue = 1;
			this.tbTroopsDisband.Value = 0;
			this.tbTroopsDisband.Max = max;
			this.tbTroopsDisband.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.trackMoved));
			this.tbTroopsDisband.Create(GFXLibrary.int_slidebar_ruler, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.lblMin.Text = "0";
			this.lblMin.Color = global::ARGBColors.White;
			this.lblMin.DropShadowColor = global::ARGBColors.Black;
			this.lblMin.Position = new Point(0, this.tbTroopsDisband.Position.Y);
			this.lblMin.Size = new Size(this.tbTroopsDisband.Position.X - 10, this.tbTroopsDisband.Height);
			this.lblMin.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.lblMin.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.lblMax.Color = global::ARGBColors.White;
			this.lblMax.DropShadowColor = global::ARGBColors.Black;
			this.lblMax.Position = new Point(this.tbTroopsDisband.Rectangle.Right + 5, this.tbTroopsDisband.Position.Y);
			this.lblMax.Size = new Size(base.Width - this.tbTroopsDisband.Rectangle.Right - 10, this.tbTroopsDisband.Height);
			this.lblMax.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lblMax.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.lblCurValue.Text = SK.Text("GENERIC_Disband", "Disband");
			CustomSelfDrawPanel.CSDLabel csdlabel = this.lblCurValue;
			csdlabel.Text += ": 0";
			this.lblCurValue.Color = global::ARGBColors.White;
			this.lblCurValue.DropShadowColor = global::ARGBColors.Black;
			this.lblCurValue.Position = new Point(this.tbTroopsDisband.Position.X, this.tbTroopsDisband.Rectangle.Bottom + 10);
			this.lblCurValue.Size = new Size(base.Width, 26);
			this.lblCurValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lblCurValue.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.btnDisband.Text.Text = SK.Text("GENERIC_Disband", "Disband");
			this.btnDisband.ImageNorm = GFXLibrary.button_132_normal;
			this.btnDisband.ImageOver = GFXLibrary.button_132_over;
			this.btnDisband.ImageClick = GFXLibrary.button_132_in;
			this.btnDisband.setSizeToImage();
			this.btnDisband.Position = new Point(base.Width / 2 - this.btnDisband.Width / 2, this.lblCurValue.Rectangle.Bottom + 10);
			this.btnDisband.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnDisband.TextYOffset = -2;
			this.btnDisband.Text.Color = global::ARGBColors.Black;
			this.btnDisband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandClick), "Disband_Disband");
			this.btnDisband.Enabled = true;
			this.btnEdit.ImageNorm = GFXLibrary.faction_pen;
			this.btnEdit.ImageOver = GFXLibrary.faction_pen;
			this.btnEdit.ImageClick = GFXLibrary.faction_pen;
			this.btnEdit.setSizeToImage();
			this.btnEdit.MoveOnClick = true;
			this.btnEdit.OverBrighten = true;
			this.btnEdit.Position = new Point(this.tbTroopsDisband.Rectangle.Right - this.btnEdit.Width, this.lblCurValue.Position.Y);
			this.btnEdit.Data = 1;
			this.btnEdit.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editValue), "Disband_EditValue");
			if (this.imgBackground.Image != null)
			{
				this.imgBackground.addControl(this.btnEdit);
				this.imgBackground.addControl(this.btnDisband);
				this.imgBackground.addControl(this.lblCurValue);
				this.imgBackground.addControl(this.lblMax);
				this.imgBackground.addControl(this.lblMin);
				this.imgBackground.addControl(this.tbTroopsDisband);
				this.imgBackground.addControl(this.lblTroopType);
				return;
			}
			base.addControl(this.btnEdit);
			base.addControl(this.btnDisband);
			base.addControl(this.lblCurValue);
			base.addControl(this.lblMax);
			base.addControl(this.lblMin);
			base.addControl(this.tbTroopsDisband);
			base.addControl(this.lblTroopType);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00115DC4 File Offset: 0x00113FC4
		private void trackMoved()
		{
			this.lblCurValue.Text = SK.Text("GENERIC_Disband", "Disband");
			CustomSelfDrawPanel.CSDLabel csdlabel = this.lblCurValue;
			csdlabel.Text = csdlabel.Text + ": " + this.tbTroopsDisband.Value.ToString();
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x00115E1C File Offset: 0x0011401C
		private void disbandClick()
		{
			int value = this.tbTroopsDisband.Value;
			if (value <= 0)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				GameEngine.Instance.playInterfaceSound("DisbandTroopsPopup_disband");
				if (this.m_isTroops)
				{
					village.disbandTroops(this.m_troopType, value);
				}
				else
				{
					village.disbandPeople(this.m_troopType, value);
				}
				this.m_parent.Close();
			}
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00115E88 File Offset: 0x00114088
		private void editValue()
		{
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.setTrackCB));
			Point point = this.m_parent.PointToScreen(new Point(this.btnEdit.Rectangle.Right, this.btnEdit.Y + 34));
			FloatingInput.openDisband(point.X, point.Y, this.tbTroopsDisband.Value, this.tbTroopsDisband.Max, this.m_parent);
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0001177E File Offset: 0x0000F97E
		private void setTrackCB(int value)
		{
			this.tbTroopsDisband.Value = value;
			this.tbTroopsDisband.invalidate();
			base.Invalidate();
			this.trackMoved();
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x000117A3 File Offset: 0x0000F9A3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x000117C2 File Offset: 0x0000F9C2
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		// Token: 0x040015E2 RID: 5602
		private MyFormBase m_parent;

		// Token: 0x040015E3 RID: 5603
		private CustomSelfDrawPanel.CSDButton btnDisband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040015E4 RID: 5604
		private CustomSelfDrawPanel.CSDButton btnCancel = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040015E5 RID: 5605
		private CustomSelfDrawPanel.CSDLabel lblTroopType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015E6 RID: 5606
		private CustomSelfDrawPanel.CSDLabel lblMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015E7 RID: 5607
		private CustomSelfDrawPanel.CSDLabel lblMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015E8 RID: 5608
		private CustomSelfDrawPanel.CSDLabel lblCurValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015E9 RID: 5609
		private CustomSelfDrawPanel.CSDTrackBar tbTroopsDisband = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040015EA RID: 5610
		private CustomSelfDrawPanel.CSDButton btnEdit = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040015EB RID: 5611
		private CustomSelfDrawPanel.CSDImage imgBackground = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040015EC RID: 5612
		private bool m_isTroops;

		// Token: 0x040015ED RID: 5613
		private int m_troopType = -1;

		// Token: 0x040015EE RID: 5614
		private IContainer components;
	}
}
