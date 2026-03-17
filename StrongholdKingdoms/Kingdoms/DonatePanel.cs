using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200019F RID: 415
	public class DonatePanel : CustomSelfDrawPanel
	{
		// Token: 0x06000FE5 RID: 4069 RVA: 0x000119E8 File Offset: 0x0000FBE8
		public DonatePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x00116C08 File Offset: 0x00114E08
		public void setText(ParishWallDetailInfo_ReturnType returnData, DonatePopup parent)
		{
			base.clearControls();
			int num = 0;
			foreach (WallInfo wallInfo in returnData.detailedInfo)
			{
				if (wallInfo.detailedInfo.detail1 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail2 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail3 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail4 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail5 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail6 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail7 > 0)
				{
					num++;
				}
				if (wallInfo.detailedInfo.detail8 > 0)
				{
					num++;
				}
			}
			int num2 = GFXLibrary.parishwall_tan_bar_01_short.Height + 3;
			this.backgroundImage.Size = new Size(GFXLibrary.parishwall_tan_bar_01_short.Width + 20, num2 * num + 20 - 3);
			this.backgroundImage.Position = new Point(0, 0);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_right, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_right, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_right);
			int num3 = 0;
			foreach (WallInfo wallInfo2 in returnData.detailedInfo)
			{
				if (wallInfo2.detailedInfo.detail1 > 0)
				{
					int requiredResourceType = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 0);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail1, requiredResourceType));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail2 > 0)
				{
					int requiredResourceType2 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 1);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail2, requiredResourceType2));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail3 > 0)
				{
					int requiredResourceType3 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 2);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail3, requiredResourceType3));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail4 > 0)
				{
					int requiredResourceType4 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 3);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail4, requiredResourceType4));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail5 > 0)
				{
					int requiredResourceType5 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 4);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail5, requiredResourceType5));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail6 > 0)
				{
					int requiredResourceType6 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 5);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail6, requiredResourceType6));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail7 > 0)
				{
					int requiredResourceType7 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 6);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail7, requiredResourceType7));
					num3++;
				}
				if (wallInfo2.detailedInfo.detail8 > 0)
				{
					int requiredResourceType8 = VillageBuildingsData.getRequiredResourceType(wallInfo2.data1, 7);
					this.backgroundImage.addControl(this.addRow(num3, wallInfo2.data1, wallInfo2.detailedInfo.detail8, requiredResourceType8));
					num3++;
				}
			}
			parent.Size = this.backgroundImage.Size;
			base.Invalidate();
			parent.Invalidate();
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x00117074 File Offset: 0x00115274
		private CustomSelfDrawPanel.CSDImage addRow(int index, int buildingType, int amount, int resource)
		{
			int num = GFXLibrary.parishwall_tan_bar_01_short.Height + 3;
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.parishwall_tan_bar_01_short;
			csdimage.Position = new Point(10, 10 + num * index);
			csdimage.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = VillageBuildingsData.getBuildingName(buildingType),
				Color = global::ARGBColors.Black,
				Position = new Point(10, 0),
				Size = new Size(csdimage.Width - 20, csdimage.Height),
				Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			csdimage.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = amount.ToString(),
				Color = global::ARGBColors.Black,
				Position = new Point(10, 0),
				Size = new Size(csdimage.Width - 60, csdimage.Height),
				Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT
			});
			csdimage.addControl(new CustomSelfDrawPanel.CSDImage
			{
				Image = GFXLibrary.getCommodity32Image(resource),
				Position = new Point(csdimage.Width - 45, 2)
			});
			return csdimage;
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x00011A18 File Offset: 0x0000FC18
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x001171C4 File Offset: 0x001153C4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "DonatePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x04001608 RID: 5640
		private CustomSelfDrawPanel.CSDLabel bodyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001609 RID: 5641
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400160A RID: 5642
		private IContainer components;
	}
}
