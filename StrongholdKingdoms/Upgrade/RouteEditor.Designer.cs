namespace Upgrade
{
	// Token: 0x0200002D RID: 45
	public partial class RouteEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060001EF RID: 495 RVA: 0x0000907F File Offset: 0x0000727F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00045864 File Offset: 0x00043A64
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.checkBox_ToAll = new global::System.Windows.Forms.CheckBox();
			this.checkBox_FromAll = new global::System.Windows.Forms.CheckBox();
			this.listBox_To = new global::System.Windows.Forms.ListBox();
			this.contextMenuStrip_ReceiverQuickSelector = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem11 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem12 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem13 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem14 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem15 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem16 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem17 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem18 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem19 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem20 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem21 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.listBox_From = new global::System.Windows.Forms.ListBox();
			this.contextMenuStrip_SenderQuickSelector = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllLowlandsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllHighlandsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllRivers1ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllRivers2ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllMountainPeaksToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllMarshsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllValleySidesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllForestsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allIronProducingVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allNonIronVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allPitchProduingVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allNonPitchVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allFishProducingVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allNonFishVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.vegetablesBreadLowlandPlainsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allNonBanquetToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.listBox_Res = new global::System.Windows.Forms.ListBox();
			this.contextMenuStrip_ResourcesQuickSelector = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllStockpileGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllFoodToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllBanquetsGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllWeaponsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkBox_AllRes = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Enable = new global::System.Windows.Forms.CheckBox();
			this.label_Name = new global::System.Windows.Forms.Label();
			this.textBox_Name = new global::System.Windows.Forms.TextBox();
			this.numericUpDown_MinKeep = new global::System.Windows.Forms.NumericUpDown();
			this.label_MinKeep = new global::System.Windows.Forms.Label();
			this.label_MaxSend = new global::System.Windows.Forms.Label();
			this.button_Save = new global::System.Windows.Forms.Button();
			this.numericUpDown_SendMax = new global::System.Windows.Forms.NumericUpDown();
			this.label_from = new global::System.Windows.Forms.Label();
			this.label_to = new global::System.Windows.Forms.Label();
			this.button_InvertSelection = new global::System.Windows.Forms.Button();
			this.groupBox_maxDistance = new global::System.Windows.Forms.GroupBox();
			this.checkBox_IsDistanceLimited = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_maxDistanceLimit = new global::System.Windows.Forms.NumericUpDown();
			this.label_maxDistanceLimit = new global::System.Windows.Forms.Label();
			this.label_maxDistanceTimeValue = new global::System.Windows.Forms.Label();
			this.label_maxDistanceValue = new global::System.Windows.Forms.Label();
			this.label_maxDistanceToValue = new global::System.Windows.Forms.Label();
			this.label_maxDistanceFromValue = new global::System.Windows.Forms.Label();
			this.label_maxDistanceTime = new global::System.Windows.Forms.Label();
			this.label_maxDistancePoints = new global::System.Windows.Forms.Label();
			this.label_maxDistanceTo = new global::System.Windows.Forms.Label();
			this.label_maxDistanceFrom = new global::System.Windows.Forms.Label();
			this.numericUpDown_MaxMerchantsPerTransaction = new global::System.Windows.Forms.NumericUpDown();
			this.label_MaxMerchantsPerTransaction = new global::System.Windows.Forms.Label();
			this.listBox_Trips = new global::System.Windows.Forms.ListBox();
			this.label_resultingSchedule = new global::System.Windows.Forms.Label();
			this.contextMenuStrip_ReceiverQuickSelector.SuspendLayout();
			this.contextMenuStrip_SenderQuickSelector.SuspendLayout();
			this.contextMenuStrip_ResourcesQuickSelector.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MinKeep).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_SendMax).BeginInit();
			this.groupBox_maxDistance.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_maxDistanceLimit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MaxMerchantsPerTransaction).BeginInit();
			base.SuspendLayout();
			this.checkBox_ToAll.AutoSize = true;
			this.checkBox_ToAll.Location = new global::System.Drawing.Point(320, 7);
			this.checkBox_ToAll.Name = "checkBox_ToAll";
			this.checkBox_ToAll.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_ToAll.TabIndex = 10;
			this.checkBox_ToAll.UseVisualStyleBackColor = true;
			this.checkBox_ToAll.CheckedChanged += new global::System.EventHandler(this.checkBox_ToAll_CheckedChanged);
			this.checkBox_FromAll.AutoSize = true;
			this.checkBox_FromAll.Location = new global::System.Drawing.Point(127, 7);
			this.checkBox_FromAll.Name = "checkBox_FromAll";
			this.checkBox_FromAll.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_FromAll.TabIndex = 9;
			this.checkBox_FromAll.UseVisualStyleBackColor = true;
			this.checkBox_FromAll.CheckedChanged += new global::System.EventHandler(this.checkBox_FromAll_CheckedChanged);
			this.listBox_To.ContextMenuStrip = this.contextMenuStrip_ReceiverQuickSelector;
			this.listBox_To.FormattingEnabled = true;
			this.listBox_To.Location = new global::System.Drawing.Point(199, 27);
			this.listBox_To.Name = "listBox_To";
			this.listBox_To.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_To.Size = new global::System.Drawing.Size(136, 381);
			this.listBox_To.TabIndex = 7;
			this.listBox_To.SelectedIndexChanged += new global::System.EventHandler(this.listBox_To_SelectedIndexChanged);
			this.contextMenuStrip_ReceiverQuickSelector.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripMenuItem1,
				this.toolStripMenuItem2,
				this.toolStripMenuItem3,
				this.toolStripMenuItem4,
				this.toolStripMenuItem5,
				this.toolStripMenuItem6,
				this.toolStripMenuItem7,
				this.toolStripMenuItem8,
				this.toolStripMenuItem9,
				this.toolStripMenuItem10,
				this.toolStripMenuItem11,
				this.toolStripMenuItem12,
				this.toolStripMenuItem13,
				this.toolStripMenuItem14,
				this.toolStripMenuItem15,
				this.toolStripMenuItem16,
				this.toolStripMenuItem17,
				this.toolStripMenuItem18,
				this.toolStripMenuItem19,
				this.toolStripMenuItem20,
				this.toolStripMenuItem21
			});
			this.contextMenuStrip_ReceiverQuickSelector.Name = "contextMenuStrip_SenderQuickSelector";
			this.contextMenuStrip_ReceiverQuickSelector.Size = new global::System.Drawing.Size(345, 466);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem1.Text = "Select All";
			this.toolStripMenuItem1.Click += new global::System.EventHandler(this.selectAllToolStripMenuItem_Click);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem2.Text = "Select All Lowlands";
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem3.Text = "Select All Highlands";
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem4.Text = "Select All Rivers 1";
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem5.Text = "Select All Rivers 2";
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem6.Text = "Select All Mountain Peaks";
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem7.Text = "Select All Salt Flats";
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem8.Text = "Select All Marshs";
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem9.Text = "Select All Plains";
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem10.Text = "Select All Valley Sides";
			this.toolStripMenuItem11.Name = "toolStripMenuItem11";
			this.toolStripMenuItem11.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem11.Text = "Select All Forests";
			this.toolStripMenuItem12.Name = "toolStripMenuItem12";
			this.toolStripMenuItem12.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem12.Text = "Iron villages (Lowland+Highland+Mountain Peak)";
			this.toolStripMenuItem12.Click += new global::System.EventHandler(this.allIronProducingVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem13.Name = "toolStripMenuItem13";
			this.toolStripMenuItem13.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem13.Text = "All Non-Iron villages";
			this.toolStripMenuItem13.Click += new global::System.EventHandler(this.allNonIronVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem14.Name = "toolStripMenuItem14";
			this.toolStripMenuItem14.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem14.Text = "Pitch villages (Highland+Marsh)";
			this.toolStripMenuItem14.Click += new global::System.EventHandler(this.allPitchProduingVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem15.Name = "toolStripMenuItem15";
			this.toolStripMenuItem15.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem15.Text = "All Non-Pitch villages";
			this.toolStripMenuItem15.Click += new global::System.EventHandler(this.allNonPitchVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem16.Name = "toolStripMenuItem16";
			this.toolStripMenuItem16.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem16.Text = "Fish villages (River 1+River 2)";
			this.toolStripMenuItem16.Click += new global::System.EventHandler(this.allFishProducingVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem17.Name = "toolStripMenuItem17";
			this.toolStripMenuItem17.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem17.Text = "All Non-Fish villages";
			this.toolStripMenuItem17.Click += new global::System.EventHandler(this.allNonFishVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem18.Name = "toolStripMenuItem18";
			this.toolStripMenuItem18.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem18.Text = "Vegetables+Bread (Lowland+Plains)";
			this.toolStripMenuItem18.Click += new global::System.EventHandler(this.vegetablesBreadLowlandPlainsToolStripMenuItem_Click);
			this.toolStripMenuItem19.Name = "toolStripMenuItem19";
			this.toolStripMenuItem19.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem19.Text = "All Non-Vegetables and Non-Bread villages";
			this.toolStripMenuItem19.Click += new global::System.EventHandler(this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem_Click);
			this.toolStripMenuItem20.Name = "toolStripMenuItem20";
			this.toolStripMenuItem20.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem20.Text = "5-8 Banquets (Valley Side+Salt Flat+River 1+River 2)";
			this.toolStripMenuItem20.Click += new global::System.EventHandler(this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem_Click);
			this.toolStripMenuItem21.Name = "toolStripMenuItem21";
			this.toolStripMenuItem21.Size = new global::System.Drawing.Size(344, 22);
			this.toolStripMenuItem21.Text = "1-4 Banquets (Lowland+Highland+Mountain Peak)";
			this.toolStripMenuItem21.Click += new global::System.EventHandler(this.allIronProducingVillagesToolStripMenuItem_Click);
			this.listBox_From.BackColor = global::System.Drawing.SystemColors.Window;
			this.listBox_From.ContextMenuStrip = this.contextMenuStrip_SenderQuickSelector;
			this.listBox_From.FormattingEnabled = true;
			this.listBox_From.Location = new global::System.Drawing.Point(7, 27);
			this.listBox_From.Name = "listBox_From";
			this.listBox_From.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_From.Size = new global::System.Drawing.Size(135, 381);
			this.listBox_From.TabIndex = 6;
			this.listBox_From.SelectedIndexChanged += new global::System.EventHandler(this.listBox_From_SelectedIndexChanged);
			this.contextMenuStrip_SenderQuickSelector.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectAllToolStripMenuItem,
				this.selectAllLowlandsToolStripMenuItem,
				this.selectAllHighlandsToolStripMenuItem,
				this.selectAllRivers1ToolStripMenuItem,
				this.selectAllRivers2ToolStripMenuItem,
				this.selectAllMountainPeaksToolStripMenuItem,
				this.selectAllToolStripMenuItem1,
				this.selectAllMarshsToolStripMenuItem,
				this.selectAllToolStripMenuItem2,
				this.selectAllValleySidesToolStripMenuItem,
				this.selectAllForestsToolStripMenuItem,
				this.allIronProducingVillagesToolStripMenuItem,
				this.allNonIronVillagesToolStripMenuItem,
				this.allPitchProduingVillagesToolStripMenuItem,
				this.allNonPitchVillagesToolStripMenuItem,
				this.allFishProducingVillagesToolStripMenuItem,
				this.allNonFishVillagesToolStripMenuItem,
				this.vegetablesBreadLowlandPlainsToolStripMenuItem,
				this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem,
				this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem,
				this.allNonBanquetToolStripMenuItem
			});
			this.contextMenuStrip_SenderQuickSelector.Name = "contextMenuStrip_SenderQuickSelector";
			this.contextMenuStrip_SenderQuickSelector.Size = new global::System.Drawing.Size(345, 466);
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllToolStripMenuItem_Click);
			this.selectAllLowlandsToolStripMenuItem.Name = "selectAllLowlandsToolStripMenuItem";
			this.selectAllLowlandsToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllLowlandsToolStripMenuItem.Text = "Select All Lowlands";
			this.selectAllHighlandsToolStripMenuItem.Name = "selectAllHighlandsToolStripMenuItem";
			this.selectAllHighlandsToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllHighlandsToolStripMenuItem.Text = "Select All Highlands";
			this.selectAllRivers1ToolStripMenuItem.Name = "selectAllRivers1ToolStripMenuItem";
			this.selectAllRivers1ToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllRivers1ToolStripMenuItem.Text = "Select All Rivers 1";
			this.selectAllRivers2ToolStripMenuItem.Name = "selectAllRivers2ToolStripMenuItem";
			this.selectAllRivers2ToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllRivers2ToolStripMenuItem.Text = "Select All Rivers 2";
			this.selectAllMountainPeaksToolStripMenuItem.Name = "selectAllMountainPeaksToolStripMenuItem";
			this.selectAllMountainPeaksToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllMountainPeaksToolStripMenuItem.Text = "Select All Mountain Peaks";
			this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
			this.selectAllToolStripMenuItem1.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllToolStripMenuItem1.Text = "Select All Salt Flats";
			this.selectAllMarshsToolStripMenuItem.Name = "selectAllMarshsToolStripMenuItem";
			this.selectAllMarshsToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllMarshsToolStripMenuItem.Text = "Select All Marshs";
			this.selectAllToolStripMenuItem2.Name = "selectAllToolStripMenuItem2";
			this.selectAllToolStripMenuItem2.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllToolStripMenuItem2.Text = "Select All Plains";
			this.selectAllValleySidesToolStripMenuItem.Name = "selectAllValleySidesToolStripMenuItem";
			this.selectAllValleySidesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllValleySidesToolStripMenuItem.Text = "Select All Valley Sides";
			this.selectAllForestsToolStripMenuItem.Name = "selectAllForestsToolStripMenuItem";
			this.selectAllForestsToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.selectAllForestsToolStripMenuItem.Text = "Select All Forests";
			this.allIronProducingVillagesToolStripMenuItem.Name = "allIronProducingVillagesToolStripMenuItem";
			this.allIronProducingVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allIronProducingVillagesToolStripMenuItem.Text = "Iron villages (Lowland+Highland+Mountain Peak)";
			this.allIronProducingVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allIronProducingVillagesToolStripMenuItem_Click);
			this.allNonIronVillagesToolStripMenuItem.Name = "allNonIronVillagesToolStripMenuItem";
			this.allNonIronVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allNonIronVillagesToolStripMenuItem.Text = "All Non-Iron villages";
			this.allNonIronVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allNonIronVillagesToolStripMenuItem_Click);
			this.allPitchProduingVillagesToolStripMenuItem.Name = "allPitchProduingVillagesToolStripMenuItem";
			this.allPitchProduingVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allPitchProduingVillagesToolStripMenuItem.Text = "Pitch villages (Highland+Marsh)";
			this.allPitchProduingVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allPitchProduingVillagesToolStripMenuItem_Click);
			this.allNonPitchVillagesToolStripMenuItem.Name = "allNonPitchVillagesToolStripMenuItem";
			this.allNonPitchVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allNonPitchVillagesToolStripMenuItem.Text = "All Non-Pitch villages";
			this.allNonPitchVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allNonPitchVillagesToolStripMenuItem_Click);
			this.allFishProducingVillagesToolStripMenuItem.Name = "allFishProducingVillagesToolStripMenuItem";
			this.allFishProducingVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allFishProducingVillagesToolStripMenuItem.Text = "Fish villages (River 1+River 2)";
			this.allFishProducingVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allFishProducingVillagesToolStripMenuItem_Click);
			this.allNonFishVillagesToolStripMenuItem.Name = "allNonFishVillagesToolStripMenuItem";
			this.allNonFishVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allNonFishVillagesToolStripMenuItem.Text = "All Non-Fish villages";
			this.allNonFishVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allNonFishVillagesToolStripMenuItem_Click);
			this.vegetablesBreadLowlandPlainsToolStripMenuItem.Name = "vegetablesBreadLowlandPlainsToolStripMenuItem";
			this.vegetablesBreadLowlandPlainsToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.vegetablesBreadLowlandPlainsToolStripMenuItem.Text = "Vegetables+Bread (Lowland+Plains)";
			this.vegetablesBreadLowlandPlainsToolStripMenuItem.Click += new global::System.EventHandler(this.vegetablesBreadLowlandPlainsToolStripMenuItem_Click);
			this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem.Name = "allNonVegetablesAndNonBreadVillagesToolStripMenuItem";
			this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem.Text = "All Non-Vegetables and Non-Bread villages";
			this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem.Click += new global::System.EventHandler(this.allNonVegetablesAndNonBreadVillagesToolStripMenuItem_Click);
			this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem.Name = "allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem";
			this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem.Text = "5-8 Banquets (Valley Side+Salt Flat+River 1+River 2)";
			this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem.Click += new global::System.EventHandler(this.allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem_Click);
			this.allNonBanquetToolStripMenuItem.Name = "allNonBanquetToolStripMenuItem";
			this.allNonBanquetToolStripMenuItem.Size = new global::System.Drawing.Size(344, 22);
			this.allNonBanquetToolStripMenuItem.Text = "1-4 Banquets (Lowland+Highland+Mountain Peak)";
			this.allNonBanquetToolStripMenuItem.Click += new global::System.EventHandler(this.allIronProducingVillagesToolStripMenuItem_Click);
			this.listBox_Res.ContextMenuStrip = this.contextMenuStrip_ResourcesQuickSelector;
			this.listBox_Res.FormattingEnabled = true;
			this.listBox_Res.Location = new global::System.Drawing.Point(341, 27);
			this.listBox_Res.Name = "listBox_Res";
			this.listBox_Res.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_Res.Size = new global::System.Drawing.Size(136, 381);
			this.listBox_Res.TabIndex = 11;
			this.contextMenuStrip_ResourcesQuickSelector.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectAllToolStripMenuItem3,
				this.selectAllStockpileGoodsToolStripMenuItem,
				this.selectAllFoodToolStripMenuItem,
				this.selectAllBanquetsGoodsToolStripMenuItem,
				this.selectAllWeaponsToolStripMenuItem
			});
			this.contextMenuStrip_ResourcesQuickSelector.Name = "contextMenuStrip_ResourcesQuickSelector";
			this.contextMenuStrip_ResourcesQuickSelector.Size = new global::System.Drawing.Size(212, 114);
			this.selectAllToolStripMenuItem3.Name = "selectAllToolStripMenuItem3";
			this.selectAllToolStripMenuItem3.Size = new global::System.Drawing.Size(211, 22);
			this.selectAllToolStripMenuItem3.Text = "Select All";
			this.selectAllToolStripMenuItem3.Click += new global::System.EventHandler(this.selectAllToolStripMenuItem3_Click);
			this.selectAllStockpileGoodsToolStripMenuItem.Name = "selectAllStockpileGoodsToolStripMenuItem";
			this.selectAllStockpileGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(211, 22);
			this.selectAllStockpileGoodsToolStripMenuItem.Text = "Select All Stockpile Goods";
			this.selectAllStockpileGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllStockpileGoodsToolStripMenuItem_Click);
			this.selectAllFoodToolStripMenuItem.Name = "selectAllFoodToolStripMenuItem";
			this.selectAllFoodToolStripMenuItem.Size = new global::System.Drawing.Size(211, 22);
			this.selectAllFoodToolStripMenuItem.Text = "Select All Food";
			this.selectAllFoodToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllFoodToolStripMenuItem_Click);
			this.selectAllBanquetsGoodsToolStripMenuItem.Name = "selectAllBanquetsGoodsToolStripMenuItem";
			this.selectAllBanquetsGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(211, 22);
			this.selectAllBanquetsGoodsToolStripMenuItem.Text = "Select All Banquets Goods";
			this.selectAllBanquetsGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllBanquetsGoodsToolStripMenuItem_Click);
			this.selectAllWeaponsToolStripMenuItem.Name = "selectAllWeaponsToolStripMenuItem";
			this.selectAllWeaponsToolStripMenuItem.Size = new global::System.Drawing.Size(211, 22);
			this.selectAllWeaponsToolStripMenuItem.Text = "Select All Weapons";
			this.selectAllWeaponsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllWeaponsToolStripMenuItem_Click);
			this.checkBox_AllRes.AutoSize = true;
			this.checkBox_AllRes.Location = new global::System.Drawing.Point(462, 7);
			this.checkBox_AllRes.Name = "checkBox_AllRes";
			this.checkBox_AllRes.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_AllRes.TabIndex = 12;
			this.checkBox_AllRes.UseVisualStyleBackColor = true;
			this.checkBox_AllRes.CheckedChanged += new global::System.EventHandler(this.checkBox_AllRes_CheckedChanged);
			this.checkBox_Enable.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_Enable.Location = new global::System.Drawing.Point(486, 62);
			this.checkBox_Enable.Name = "checkBox_Enable";
			this.checkBox_Enable.Size = new global::System.Drawing.Size(212, 17);
			this.checkBox_Enable.TabIndex = 13;
			this.checkBox_Enable.Text = "Enable";
			this.checkBox_Enable.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_Enable.UseVisualStyleBackColor = true;
			this.label_Name.Location = new global::System.Drawing.Point(486, 39);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new global::System.Drawing.Size(192, 13);
			this.label_Name.TabIndex = 14;
			this.label_Name.Text = "Route Name:";
			this.label_Name.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.textBox_Name.Location = new global::System.Drawing.Point(684, 36);
			this.textBox_Name.Name = "textBox_Name";
			this.textBox_Name.Size = new global::System.Drawing.Size(82, 20);
			this.textBox_Name.TabIndex = 15;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_MinKeep;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Increment = new decimal(array);
			this.numericUpDown_MinKeep.Location = new global::System.Drawing.Point(684, 85);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_MinKeep;
			int[] array2 = new int[4];
			array2[0] = 1000000;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_MinKeep.Name = "numericUpDown_MinKeep";
			this.numericUpDown_MinKeep.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.numericUpDown_MinKeep.Size = new global::System.Drawing.Size(83, 20);
			this.numericUpDown_MinKeep.TabIndex = 16;
			this.numericUpDown_MinKeep.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_MinKeep.ThousandsSeparator = true;
			this.label_MinKeep.Location = new global::System.Drawing.Point(486, 82);
			this.label_MinKeep.Name = "label_MinKeep";
			this.label_MinKeep.Size = new global::System.Drawing.Size(192, 31);
			this.label_MinKeep.TabIndex = 18;
			this.label_MinKeep.Text = "Minimum amount of resource to keep in the source village:";
			this.label_MaxSend.Location = new global::System.Drawing.Point(486, 144);
			this.label_MaxSend.Name = "label_MaxSend";
			this.label_MaxSend.Size = new global::System.Drawing.Size(192, 31);
			this.label_MaxSend.TabIndex = 19;
			this.label_MaxSend.Text = "Maximum amount of resource to store in the target village:";
			this.button_Save.Location = new global::System.Drawing.Point(670, 222);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new global::System.Drawing.Size(93, 35);
			this.button_Save.TabIndex = 20;
			this.button_Save.Text = "Save";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new global::System.EventHandler(this.button_Save_Click);
			this.numericUpDown_SendMax.BackColor = global::System.Drawing.SystemColors.Window;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_SendMax;
			int[] array3 = new int[4];
			array3[0] = 1000;
			numericUpDown3.Increment = new decimal(array3);
			this.numericUpDown_SendMax.Location = new global::System.Drawing.Point(684, 144);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_SendMax;
			int[] array4 = new int[4];
			array4[0] = 1000000;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDown_SendMax.Name = "numericUpDown_SendMax";
			this.numericUpDown_SendMax.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.numericUpDown_SendMax.Size = new global::System.Drawing.Size(83, 20);
			this.numericUpDown_SendMax.TabIndex = 21;
			this.numericUpDown_SendMax.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_SendMax.ThousandsSeparator = true;
			this.label_from.AutoSize = true;
			this.label_from.Location = new global::System.Drawing.Point(7, 7);
			this.label_from.Name = "label_from";
			this.label_from.Size = new global::System.Drawing.Size(68, 13);
			this.label_from.TabIndex = 22;
			this.label_from.Text = "From villages";
			this.label_to.AutoSize = true;
			this.label_to.Location = new global::System.Drawing.Point(199, 7);
			this.label_to.Name = "label_to";
			this.label_to.Size = new global::System.Drawing.Size(58, 13);
			this.label_to.TabIndex = 23;
			this.label_to.Text = "To villages";
			this.button_InvertSelection.Location = new global::System.Drawing.Point(155, 205);
			this.button_InvertSelection.Name = "button_InvertSelection";
			this.button_InvertSelection.Size = new global::System.Drawing.Size(31, 23);
			this.button_InvertSelection.TabIndex = 24;
			this.button_InvertSelection.Text = "<>";
			this.button_InvertSelection.UseVisualStyleBackColor = true;
			this.button_InvertSelection.Click += new global::System.EventHandler(this.button_InvertSelection_Click);
			this.groupBox_maxDistance.Controls.Add(this.checkBox_IsDistanceLimited);
			this.groupBox_maxDistance.Controls.Add(this.numericUpDown_maxDistanceLimit);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceLimit);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceTimeValue);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceValue);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceToValue);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceFromValue);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceTime);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistancePoints);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceTo);
			this.groupBox_maxDistance.Controls.Add(this.label_maxDistanceFrom);
			this.groupBox_maxDistance.Location = new global::System.Drawing.Point(489, 283);
			this.groupBox_maxDistance.Name = "groupBox_maxDistance";
			this.groupBox_maxDistance.Size = new global::System.Drawing.Size(278, 119);
			this.groupBox_maxDistance.TabIndex = 25;
			this.groupBox_maxDistance.TabStop = false;
			this.groupBox_maxDistance.Text = "Max Distance";
			this.checkBox_IsDistanceLimited.AutoSize = true;
			this.checkBox_IsDistanceLimited.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_IsDistanceLimited.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_IsDistanceLimited.Name = "checkBox_IsDistanceLimited";
			this.checkBox_IsDistanceLimited.Size = new global::System.Drawing.Size(96, 17);
			this.checkBox_IsDistanceLimited.TabIndex = 10;
			this.checkBox_IsDistanceLimited.Text = "Limit distance?";
			this.checkBox_IsDistanceLimited.UseVisualStyleBackColor = true;
			this.checkBox_IsDistanceLimited.CheckedChanged += new global::System.EventHandler(this.checkBox_IsDistanceLimited_CheckedChanged);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_maxDistanceLimit;
			int[] array5 = new int[4];
			array5[0] = 10;
			numericUpDown5.Increment = new decimal(array5);
			this.numericUpDown_maxDistanceLimit.Location = new global::System.Drawing.Point(89, 90);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_maxDistanceLimit;
			int[] array6 = new int[4];
			array6[0] = 10000;
			numericUpDown6.Maximum = new decimal(array6);
			this.numericUpDown_maxDistanceLimit.Name = "numericUpDown_maxDistanceLimit";
			this.numericUpDown_maxDistanceLimit.Size = new global::System.Drawing.Size(56, 20);
			this.numericUpDown_maxDistanceLimit.TabIndex = 9;
			this.numericUpDown_maxDistanceLimit.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_maxDistanceLimit.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_maxDistanceLimit;
			int[] array7 = new int[4];
			array7[0] = 32;
			numericUpDown7.Value = new decimal(array7);
			this.numericUpDown_maxDistanceLimit.ValueChanged += new global::System.EventHandler(this.numericUpDown_maxDistanceLimit_ValueChanged);
			this.label_maxDistanceLimit.Location = new global::System.Drawing.Point(7, 90);
			this.label_maxDistanceLimit.Name = "label_maxDistanceLimit";
			this.label_maxDistanceLimit.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceLimit.TabIndex = 8;
			this.label_maxDistanceLimit.Text = "Limit:";
			this.label_maxDistanceLimit.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceTimeValue.AutoSize = true;
			this.label_maxDistanceTimeValue.Location = new global::System.Drawing.Point(86, 59);
			this.label_maxDistanceTimeValue.Name = "label_maxDistanceTimeValue";
			this.label_maxDistanceTimeValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceTimeValue.TabIndex = 7;
			this.label_maxDistanceTimeValue.Text = "no data";
			this.label_maxDistanceValue.AutoSize = true;
			this.label_maxDistanceValue.Location = new global::System.Drawing.Point(86, 46);
			this.label_maxDistanceValue.Name = "label_maxDistanceValue";
			this.label_maxDistanceValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceValue.TabIndex = 6;
			this.label_maxDistanceValue.Text = "no data";
			this.label_maxDistanceToValue.AutoSize = true;
			this.label_maxDistanceToValue.Location = new global::System.Drawing.Point(86, 33);
			this.label_maxDistanceToValue.Name = "label_maxDistanceToValue";
			this.label_maxDistanceToValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceToValue.TabIndex = 5;
			this.label_maxDistanceToValue.Text = "no data";
			this.label_maxDistanceFromValue.AutoSize = true;
			this.label_maxDistanceFromValue.Location = new global::System.Drawing.Point(86, 20);
			this.label_maxDistanceFromValue.Name = "label_maxDistanceFromValue";
			this.label_maxDistanceFromValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceFromValue.TabIndex = 4;
			this.label_maxDistanceFromValue.Text = "no data";
			this.label_maxDistanceTime.Location = new global::System.Drawing.Point(7, 59);
			this.label_maxDistanceTime.Name = "label_maxDistanceTime";
			this.label_maxDistanceTime.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceTime.TabIndex = 3;
			this.label_maxDistanceTime.Text = "Time:";
			this.label_maxDistanceTime.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistancePoints.Location = new global::System.Drawing.Point(7, 46);
			this.label_maxDistancePoints.Name = "label_maxDistancePoints";
			this.label_maxDistancePoints.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistancePoints.TabIndex = 2;
			this.label_maxDistancePoints.Text = "Distance:";
			this.label_maxDistancePoints.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceTo.Location = new global::System.Drawing.Point(6, 33);
			this.label_maxDistanceTo.Name = "label_maxDistanceTo";
			this.label_maxDistanceTo.Size = new global::System.Drawing.Size(74, 13);
			this.label_maxDistanceTo.TabIndex = 1;
			this.label_maxDistanceTo.Text = "To:";
			this.label_maxDistanceTo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceFrom.Location = new global::System.Drawing.Point(7, 20);
			this.label_maxDistanceFrom.Name = "label_maxDistanceFrom";
			this.label_maxDistanceFrom.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceFrom.TabIndex = 0;
			this.label_maxDistanceFrom.Text = "From:";
			this.label_maxDistanceFrom.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.numericUpDown_MaxMerchantsPerTransaction.BackColor = global::System.Drawing.SystemColors.Window;
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_MaxMerchantsPerTransaction;
			int[] array8 = new int[4];
			array8[0] = 5;
			numericUpDown8.Increment = new decimal(array8);
			this.numericUpDown_MaxMerchantsPerTransaction.Location = new global::System.Drawing.Point(684, 116);
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numericUpDown_MaxMerchantsPerTransaction;
			int[] array9 = new int[4];
			array9[0] = 50;
			numericUpDown9.Maximum = new decimal(array9);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.numericUpDown_MaxMerchantsPerTransaction;
			int[] array10 = new int[4];
			array10[0] = 1;
			numericUpDown10.Minimum = new decimal(array10);
			this.numericUpDown_MaxMerchantsPerTransaction.Name = "numericUpDown_MaxMerchantsPerTransaction";
			this.numericUpDown_MaxMerchantsPerTransaction.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.numericUpDown_MaxMerchantsPerTransaction.Size = new global::System.Drawing.Size(83, 20);
			this.numericUpDown_MaxMerchantsPerTransaction.TabIndex = 27;
			this.numericUpDown_MaxMerchantsPerTransaction.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_MaxMerchantsPerTransaction.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.numericUpDown_MaxMerchantsPerTransaction;
			int[] array11 = new int[4];
			array11[0] = 5;
			numericUpDown11.Value = new decimal(array11);
			this.label_MaxMerchantsPerTransaction.Location = new global::System.Drawing.Point(486, 113);
			this.label_MaxMerchantsPerTransaction.Name = "label_MaxMerchantsPerTransaction";
			this.label_MaxMerchantsPerTransaction.Size = new global::System.Drawing.Size(192, 31);
			this.label_MaxMerchantsPerTransaction.TabIndex = 26;
			this.label_MaxMerchantsPerTransaction.Text = "Maximum merchants per transaction:";
			this.listBox_Trips.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.listBox_Trips.FormattingEnabled = true;
			this.listBox_Trips.HorizontalScrollbar = true;
			this.listBox_Trips.Location = new global::System.Drawing.Point(0, 434);
			this.listBox_Trips.Name = "listBox_Trips";
			this.listBox_Trips.Size = new global::System.Drawing.Size(769, 173);
			this.listBox_Trips.TabIndex = 28;
			this.label_resultingSchedule.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_resultingSchedule.AutoSize = true;
			this.label_resultingSchedule.Location = new global::System.Drawing.Point(4, 413);
			this.label_resultingSchedule.Name = "label_resultingSchedule";
			this.label_resultingSchedule.Size = new global::System.Drawing.Size(100, 13);
			this.label_resultingSchedule.TabIndex = 29;
			this.label_resultingSchedule.Text = "Resulting schedule:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(769, 607);
			base.Controls.Add(this.label_resultingSchedule);
			base.Controls.Add(this.listBox_Trips);
			base.Controls.Add(this.numericUpDown_MaxMerchantsPerTransaction);
			base.Controls.Add(this.label_MaxMerchantsPerTransaction);
			base.Controls.Add(this.groupBox_maxDistance);
			base.Controls.Add(this.button_InvertSelection);
			base.Controls.Add(this.label_to);
			base.Controls.Add(this.label_from);
			base.Controls.Add(this.numericUpDown_SendMax);
			base.Controls.Add(this.button_Save);
			base.Controls.Add(this.label_MaxSend);
			base.Controls.Add(this.label_MinKeep);
			base.Controls.Add(this.numericUpDown_MinKeep);
			base.Controls.Add(this.textBox_Name);
			base.Controls.Add(this.label_Name);
			base.Controls.Add(this.checkBox_Enable);
			base.Controls.Add(this.checkBox_AllRes);
			base.Controls.Add(this.listBox_Res);
			base.Controls.Add(this.checkBox_ToAll);
			base.Controls.Add(this.checkBox_FromAll);
			base.Controls.Add(this.listBox_To);
			base.Controls.Add(this.listBox_From);
			base.Name = "RouteEditor";
			this.Text = "Route Editor";
			this.contextMenuStrip_ReceiverQuickSelector.ResumeLayout(false);
			this.contextMenuStrip_SenderQuickSelector.ResumeLayout(false);
			this.contextMenuStrip_ResourcesQuickSelector.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MinKeep).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_SendMax).EndInit();
			this.groupBox_maxDistance.ResumeLayout(false);
			this.groupBox_maxDistance.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_maxDistanceLimit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MaxMerchantsPerTransaction).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000338 RID: 824
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.CheckBox checkBox_ToAll;

		// Token: 0x0400033A RID: 826
		private global::System.Windows.Forms.CheckBox checkBox_FromAll;

		// Token: 0x0400033B RID: 827
		private global::System.Windows.Forms.ListBox listBox_To;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.ListBox listBox_From;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.ListBox listBox_Res;

		// Token: 0x0400033E RID: 830
		private global::System.Windows.Forms.CheckBox checkBox_AllRes;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.CheckBox checkBox_Enable;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.Label label_Name;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.TextBox textBox_Name;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.NumericUpDown numericUpDown_MinKeep;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.Label label_MinKeep;

		// Token: 0x04000344 RID: 836
		private global::System.Windows.Forms.Label label_MaxSend;

		// Token: 0x04000345 RID: 837
		private global::System.Windows.Forms.Button button_Save;

		// Token: 0x04000346 RID: 838
		private global::System.Windows.Forms.NumericUpDown numericUpDown_SendMax;

		// Token: 0x04000347 RID: 839
		private global::System.Windows.Forms.Label label_from;

		// Token: 0x04000348 RID: 840
		private global::System.Windows.Forms.Label label_to;

		// Token: 0x04000349 RID: 841
		private global::System.Windows.Forms.Button button_InvertSelection;

		// Token: 0x0400034A RID: 842
		private global::System.Windows.Forms.GroupBox groupBox_maxDistance;

		// Token: 0x0400034B RID: 843
		private global::System.Windows.Forms.Label label_maxDistanceTimeValue;

		// Token: 0x0400034C RID: 844
		private global::System.Windows.Forms.Label label_maxDistanceValue;

		// Token: 0x0400034D RID: 845
		private global::System.Windows.Forms.Label label_maxDistanceToValue;

		// Token: 0x0400034E RID: 846
		private global::System.Windows.Forms.Label label_maxDistanceFromValue;

		// Token: 0x0400034F RID: 847
		private global::System.Windows.Forms.Label label_maxDistanceTime;

		// Token: 0x04000350 RID: 848
		private global::System.Windows.Forms.Label label_maxDistancePoints;

		// Token: 0x04000351 RID: 849
		private global::System.Windows.Forms.Label label_maxDistanceTo;

		// Token: 0x04000352 RID: 850
		private global::System.Windows.Forms.Label label_maxDistanceFrom;

		// Token: 0x04000353 RID: 851
		private global::System.Windows.Forms.CheckBox checkBox_IsDistanceLimited;

		// Token: 0x04000354 RID: 852
		private global::System.Windows.Forms.NumericUpDown numericUpDown_maxDistanceLimit;

		// Token: 0x04000355 RID: 853
		private global::System.Windows.Forms.Label label_maxDistanceLimit;

		// Token: 0x04000356 RID: 854
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip_SenderQuickSelector;

		// Token: 0x04000357 RID: 855
		private global::System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;

		// Token: 0x04000358 RID: 856
		private global::System.Windows.Forms.ToolStripMenuItem selectAllLowlandsToolStripMenuItem;

		// Token: 0x04000359 RID: 857
		private global::System.Windows.Forms.ToolStripMenuItem selectAllHighlandsToolStripMenuItem;

		// Token: 0x0400035A RID: 858
		private global::System.Windows.Forms.ToolStripMenuItem selectAllRivers1ToolStripMenuItem;

		// Token: 0x0400035B RID: 859
		private global::System.Windows.Forms.ToolStripMenuItem selectAllRivers2ToolStripMenuItem;

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.ToolStripMenuItem selectAllMountainPeaksToolStripMenuItem;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.ToolStripMenuItem selectAllMarshsToolStripMenuItem;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem2;

		// Token: 0x04000360 RID: 864
		private global::System.Windows.Forms.ToolStripMenuItem selectAllValleySidesToolStripMenuItem;

		// Token: 0x04000361 RID: 865
		private global::System.Windows.Forms.ToolStripMenuItem selectAllForestsToolStripMenuItem;

		// Token: 0x04000362 RID: 866
		private global::System.Windows.Forms.ToolStripMenuItem allIronProducingVillagesToolStripMenuItem;

		// Token: 0x04000363 RID: 867
		private global::System.Windows.Forms.ToolStripMenuItem allNonIronVillagesToolStripMenuItem;

		// Token: 0x04000364 RID: 868
		private global::System.Windows.Forms.ToolStripMenuItem allPitchProduingVillagesToolStripMenuItem;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.ToolStripMenuItem allNonPitchVillagesToolStripMenuItem;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.ToolStripMenuItem allFishProducingVillagesToolStripMenuItem;

		// Token: 0x04000367 RID: 871
		private global::System.Windows.Forms.ToolStripMenuItem allNonFishVillagesToolStripMenuItem;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.ToolStripMenuItem vegetablesBreadLowlandPlainsToolStripMenuItem;

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.ToolStripMenuItem allNonVegetablesAndNonBreadVillagesToolStripMenuItem;

		// Token: 0x0400036A RID: 874
		private global::System.Windows.Forms.ToolStripMenuItem allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.ToolStripMenuItem allNonBanquetToolStripMenuItem;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip_ReceiverQuickSelector;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

		// Token: 0x0400036F RID: 879
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

		// Token: 0x04000370 RID: 880
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

		// Token: 0x04000371 RID: 881
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;

		// Token: 0x04000372 RID: 882
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;

		// Token: 0x04000373 RID: 883
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;

		// Token: 0x04000374 RID: 884
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;

		// Token: 0x04000375 RID: 885
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;

		// Token: 0x04000378 RID: 888
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;

		// Token: 0x0400037D RID: 893
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;

		// Token: 0x0400037E RID: 894
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;

		// Token: 0x0400037F RID: 895
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;

		// Token: 0x04000380 RID: 896
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;

		// Token: 0x04000381 RID: 897
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;

		// Token: 0x04000382 RID: 898
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip_ResourcesQuickSelector;

		// Token: 0x04000383 RID: 899
		private global::System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem3;

		// Token: 0x04000384 RID: 900
		private global::System.Windows.Forms.ToolStripMenuItem selectAllStockpileGoodsToolStripMenuItem;

		// Token: 0x04000385 RID: 901
		private global::System.Windows.Forms.ToolStripMenuItem selectAllFoodToolStripMenuItem;

		// Token: 0x04000386 RID: 902
		private global::System.Windows.Forms.ToolStripMenuItem selectAllBanquetsGoodsToolStripMenuItem;

		// Token: 0x04000387 RID: 903
		private global::System.Windows.Forms.ToolStripMenuItem selectAllWeaponsToolStripMenuItem;

		// Token: 0x04000388 RID: 904
		private global::System.Windows.Forms.NumericUpDown numericUpDown_MaxMerchantsPerTransaction;

		// Token: 0x04000389 RID: 905
		private global::System.Windows.Forms.Label label_MaxMerchantsPerTransaction;

		// Token: 0x0400038A RID: 906
		private global::System.Windows.Forms.ListBox listBox_Trips;

		// Token: 0x0400038B RID: 907
		private global::System.Windows.Forms.Label label_resultingSchedule;
	}
}
