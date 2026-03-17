namespace Upgrade
{
	// Token: 0x02000028 RID: 40
	public partial class MonkRouteEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060001AF RID: 431 RVA: 0x00008F66 File Offset: 0x00007166
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00041D44 File Offset: 0x0003FF44
		private void InitializeComponent()
		{
			this.listBox_villages = new global::System.Windows.Forms.ListBox();
			this.checkBox_routeEnabled = new global::System.Windows.Forms.CheckBox();
			this.textBox_name = new global::System.Windows.Forms.TextBox();
			this.label_name = new global::System.Windows.Forms.Label();
			this.listBox_targetParishes = new global::System.Windows.Forms.ListBox();
			this.listBox_targetVillages = new global::System.Windows.Forms.ListBox();
			this.textBox_capitalId = new global::System.Windows.Forms.TextBox();
			this.textBox_villageId = new global::System.Windows.Forms.TextBox();
			this.button_addParish = new global::System.Windows.Forms.Button();
			this.button_addVillage = new global::System.Windows.Forms.Button();
			this.label_villages = new global::System.Windows.Forms.Label();
			this.button_SaveMonkRoute = new global::System.Windows.Forms.Button();
			this.groupBox_targetParishes = new global::System.Windows.Forms.GroupBox();
			this.numericUpDown_parishesRange = new global::System.Windows.Forms.NumericUpDown();
			this.button_clearParishes = new global::System.Windows.Forms.Button();
			this.button_addParishesInRange = new global::System.Windows.Forms.Button();
			this.button_addParishesImIn = new global::System.Windows.Forms.Button();
			this.button_addMyParishes = new global::System.Windows.Forms.Button();
			this.groupBox_targetVillages = new global::System.Windows.Forms.GroupBox();
			this.numericUpDown_villagesRange = new global::System.Windows.Forms.NumericUpDown();
			this.button_clearTargetVillages = new global::System.Windows.Forms.Button();
			this.button_addVillagesInRange = new global::System.Windows.Forms.Button();
			this.button_addMyVIllages = new global::System.Windows.Forms.Button();
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
			this.label_resultingSchedule = new global::System.Windows.Forms.Label();
			this.listBox_Trips = new global::System.Windows.Forms.ListBox();
			this.checkBox_allVillages = new global::System.Windows.Forms.CheckBox();
			this.label_command = new global::System.Windows.Forms.Label();
			this.comboBox_command = new global::System.Windows.Forms.ComboBox();
			this.label_stopCondition = new global::System.Windows.Forms.Label();
			this.comboBox_stopCondition = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_ExtraParameter = new global::System.Windows.Forms.NumericUpDown();
			this.label_ExtraParameter = new global::System.Windows.Forms.Label();
			this.label_specificStopCondition = new global::System.Windows.Forms.Label();
			this.groupBox_targetParishes.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_parishesRange).BeginInit();
			this.groupBox_targetVillages.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_villagesRange).BeginInit();
			this.groupBox_maxDistance.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_maxDistanceLimit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ExtraParameter).BeginInit();
			base.SuspendLayout();
			this.listBox_villages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_villages.FormattingEnabled = true;
			this.listBox_villages.Location = new global::System.Drawing.Point(15, 25);
			this.listBox_villages.Name = "listBox_villages";
			this.listBox_villages.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_villages.Size = new global::System.Drawing.Size(120, 381);
			this.listBox_villages.TabIndex = 0;
			this.listBox_villages.SelectedIndexChanged += new global::System.EventHandler(this.ListBox_villages_SelectedIndexChanged);
			this.checkBox_routeEnabled.AutoSize = true;
			this.checkBox_routeEnabled.Location = new global::System.Drawing.Point(535, 12);
			this.checkBox_routeEnabled.Name = "checkBox_routeEnabled";
			this.checkBox_routeEnabled.Size = new global::System.Drawing.Size(65, 17);
			this.checkBox_routeEnabled.TabIndex = 2;
			this.checkBox_routeEnabled.Text = "Enabled";
			this.checkBox_routeEnabled.UseVisualStyleBackColor = true;
			this.textBox_name.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_name.Location = new global::System.Drawing.Point(535, 35);
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.Size = new global::System.Drawing.Size(161, 20);
			this.textBox_name.TabIndex = 3;
			this.label_name.Location = new global::System.Drawing.Point(435, 38);
			this.label_name.Name = "label_name";
			this.label_name.Size = new global::System.Drawing.Size(100, 13);
			this.label_name.TabIndex = 4;
			this.label_name.Text = "Monk Route Name:";
			this.label_name.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.listBox_targetParishes.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_targetParishes.FormattingEnabled = true;
			this.listBox_targetParishes.Location = new global::System.Drawing.Point(6, 19);
			this.listBox_targetParishes.Name = "listBox_targetParishes";
			this.listBox_targetParishes.Size = new global::System.Drawing.Size(128, 264);
			this.listBox_targetParishes.TabIndex = 5;
			this.listBox_targetParishes.DoubleClick += new global::System.EventHandler(this.ListBox_targetParishes_DoubleClick);
			this.listBox_targetVillages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_targetVillages.FormattingEnabled = true;
			this.listBox_targetVillages.Location = new global::System.Drawing.Point(6, 19);
			this.listBox_targetVillages.Name = "listBox_targetVillages";
			this.listBox_targetVillages.Size = new global::System.Drawing.Size(128, 264);
			this.listBox_targetVillages.TabIndex = 6;
			this.listBox_targetVillages.DoubleClick += new global::System.EventHandler(this.ListBox_targetVillages_DoubleClick);
			this.textBox_capitalId.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.textBox_capitalId.Location = new global::System.Drawing.Point(79, 287);
			this.textBox_capitalId.Name = "textBox_capitalId";
			this.textBox_capitalId.Size = new global::System.Drawing.Size(55, 20);
			this.textBox_capitalId.TabIndex = 7;
			this.textBox_villageId.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.textBox_villageId.Location = new global::System.Drawing.Point(79, 287);
			this.textBox_villageId.Name = "textBox_villageId";
			this.textBox_villageId.Size = new global::System.Drawing.Size(55, 20);
			this.textBox_villageId.TabIndex = 8;
			this.button_addParish.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addParish.Location = new global::System.Drawing.Point(6, 285);
			this.button_addParish.Name = "button_addParish";
			this.button_addParish.Size = new global::System.Drawing.Size(67, 23);
			this.button_addParish.TabIndex = 9;
			this.button_addParish.Text = "Add";
			this.button_addParish.UseVisualStyleBackColor = true;
			this.button_addParish.Click += new global::System.EventHandler(this.Button_addParish_Click);
			this.button_addVillage.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addVillage.Location = new global::System.Drawing.Point(6, 285);
			this.button_addVillage.Name = "button_addVillage";
			this.button_addVillage.Size = new global::System.Drawing.Size(67, 23);
			this.button_addVillage.TabIndex = 10;
			this.button_addVillage.Text = "Add";
			this.button_addVillage.UseVisualStyleBackColor = true;
			this.button_addVillage.Click += new global::System.EventHandler(this.Button_addVillage_Click);
			this.label_villages.AutoSize = true;
			this.label_villages.Location = new global::System.Drawing.Point(12, 9);
			this.label_villages.Name = "label_villages";
			this.label_villages.Size = new global::System.Drawing.Size(89, 13);
			this.label_villages.TabIndex = 11;
			this.label_villages.Text = "Monking villages:";
			this.button_SaveMonkRoute.Location = new global::System.Drawing.Point(599, 246);
			this.button_SaveMonkRoute.Name = "button_SaveMonkRoute";
			this.button_SaveMonkRoute.Size = new global::System.Drawing.Size(100, 33);
			this.button_SaveMonkRoute.TabIndex = 14;
			this.button_SaveMonkRoute.Text = "Save";
			this.button_SaveMonkRoute.UseVisualStyleBackColor = true;
			this.button_SaveMonkRoute.Click += new global::System.EventHandler(this.Button_SaveMonkRoute_Click);
			this.groupBox_targetParishes.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox_targetParishes.Controls.Add(this.numericUpDown_parishesRange);
			this.groupBox_targetParishes.Controls.Add(this.button_clearParishes);
			this.groupBox_targetParishes.Controls.Add(this.button_addParishesInRange);
			this.groupBox_targetParishes.Controls.Add(this.button_addParishesImIn);
			this.groupBox_targetParishes.Controls.Add(this.button_addMyParishes);
			this.groupBox_targetParishes.Controls.Add(this.listBox_targetParishes);
			this.groupBox_targetParishes.Controls.Add(this.textBox_capitalId);
			this.groupBox_targetParishes.Controls.Add(this.button_addParish);
			this.groupBox_targetParishes.Location = new global::System.Drawing.Point(142, 9);
			this.groupBox_targetParishes.Name = "groupBox_targetParishes";
			this.groupBox_targetParishes.Size = new global::System.Drawing.Size(140, 416);
			this.groupBox_targetParishes.TabIndex = 15;
			this.groupBox_targetParishes.TabStop = false;
			this.groupBox_targetParishes.Text = "Target parishes";
			this.groupBox_targetParishes.VisibleChanged += new global::System.EventHandler(this.GroupBox_targetParishes_VisibleChanged);
			this.numericUpDown_parishesRange.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_parishesRange;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Increment = new decimal(array);
			this.numericUpDown_parishesRange.Location = new global::System.Drawing.Point(95, 365);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_parishesRange;
			int[] array2 = new int[4];
			array2[0] = 1000;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_parishesRange.Name = "numericUpDown_parishesRange";
			this.numericUpDown_parishesRange.Size = new global::System.Drawing.Size(46, 20);
			this.numericUpDown_parishesRange.TabIndex = 14;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_parishesRange;
			int[] array3 = new int[4];
			array3[0] = 32;
			numericUpDown3.Value = new decimal(array3);
			this.numericUpDown_parishesRange.ValueChanged += new global::System.EventHandler(this.NumericUpDown_parishesRange_ValueChanged);
			this.button_clearParishes.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_clearParishes.Location = new global::System.Drawing.Point(6, 390);
			this.button_clearParishes.Name = "button_clearParishes";
			this.button_clearParishes.Size = new global::System.Drawing.Size(128, 23);
			this.button_clearParishes.TabIndex = 13;
			this.button_clearParishes.Text = "Clear";
			this.button_clearParishes.UseVisualStyleBackColor = true;
			this.button_clearParishes.Click += new global::System.EventHandler(this.Button_clearParishes_Click);
			this.button_addParishesInRange.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addParishesInRange.Location = new global::System.Drawing.Point(5, 364);
			this.button_addParishesInRange.Name = "button_addParishesInRange";
			this.button_addParishesInRange.Size = new global::System.Drawing.Size(84, 23);
			this.button_addParishesInRange.TabIndex = 12;
			this.button_addParishesInRange.Text = "Add In Range";
			this.button_addParishesInRange.UseVisualStyleBackColor = true;
			this.button_addParishesInRange.Click += new global::System.EventHandler(this.Button_addParishesInRange_Click);
			this.button_addParishesImIn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addParishesImIn.Location = new global::System.Drawing.Point(6, 337);
			this.button_addParishesImIn.Name = "button_addParishesImIn";
			this.button_addParishesImIn.Size = new global::System.Drawing.Size(128, 23);
			this.button_addParishesImIn.TabIndex = 11;
			this.button_addParishesImIn.Text = "Add All I'm In";
			this.button_addParishesImIn.UseVisualStyleBackColor = true;
			this.button_addParishesImIn.Click += new global::System.EventHandler(this.Button_addParishesImIn_Click);
			this.button_addMyParishes.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addMyParishes.Location = new global::System.Drawing.Point(6, 311);
			this.button_addMyParishes.Name = "button_addMyParishes";
			this.button_addMyParishes.Size = new global::System.Drawing.Size(128, 23);
			this.button_addMyParishes.TabIndex = 10;
			this.button_addMyParishes.Text = "Add Mine";
			this.button_addMyParishes.UseVisualStyleBackColor = true;
			this.button_addMyParishes.Click += new global::System.EventHandler(this.Button_addMyParishes_Click);
			this.groupBox_targetVillages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox_targetVillages.Controls.Add(this.numericUpDown_villagesRange);
			this.groupBox_targetVillages.Controls.Add(this.button_clearTargetVillages);
			this.groupBox_targetVillages.Controls.Add(this.button_addVillagesInRange);
			this.groupBox_targetVillages.Controls.Add(this.button_addMyVIllages);
			this.groupBox_targetVillages.Controls.Add(this.listBox_targetVillages);
			this.groupBox_targetVillages.Controls.Add(this.textBox_villageId);
			this.groupBox_targetVillages.Controls.Add(this.button_addVillage);
			this.groupBox_targetVillages.Location = new global::System.Drawing.Point(289, 9);
			this.groupBox_targetVillages.Name = "groupBox_targetVillages";
			this.groupBox_targetVillages.Size = new global::System.Drawing.Size(140, 416);
			this.groupBox_targetVillages.TabIndex = 16;
			this.groupBox_targetVillages.TabStop = false;
			this.groupBox_targetVillages.Text = "Target villages";
			this.groupBox_targetVillages.VisibleChanged += new global::System.EventHandler(this.GroupBox_targetVillages_VisibleChanged);
			this.numericUpDown_villagesRange.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_villagesRange;
			int[] array4 = new int[4];
			array4[0] = 5;
			numericUpDown4.Increment = new decimal(array4);
			this.numericUpDown_villagesRange.Location = new global::System.Drawing.Point(94, 365);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_villagesRange;
			int[] array5 = new int[4];
			array5[0] = 1000;
			numericUpDown5.Maximum = new decimal(array5);
			this.numericUpDown_villagesRange.Name = "numericUpDown_villagesRange";
			this.numericUpDown_villagesRange.Size = new global::System.Drawing.Size(46, 20);
			this.numericUpDown_villagesRange.TabIndex = 17;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_villagesRange;
			int[] array6 = new int[4];
			array6[0] = 32;
			numericUpDown6.Value = new decimal(array6);
			this.numericUpDown_villagesRange.ValueChanged += new global::System.EventHandler(this.NumericUpDown_villagesRange_ValueChanged);
			this.button_clearTargetVillages.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_clearTargetVillages.Location = new global::System.Drawing.Point(6, 391);
			this.button_clearTargetVillages.Name = "button_clearTargetVillages";
			this.button_clearTargetVillages.Size = new global::System.Drawing.Size(128, 23);
			this.button_clearTargetVillages.TabIndex = 16;
			this.button_clearTargetVillages.Text = "Clear";
			this.button_clearTargetVillages.UseVisualStyleBackColor = true;
			this.button_clearTargetVillages.Click += new global::System.EventHandler(this.Button_clearTargetVillages_Click);
			this.button_addVillagesInRange.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addVillagesInRange.Location = new global::System.Drawing.Point(6, 364);
			this.button_addVillagesInRange.Name = "button_addVillagesInRange";
			this.button_addVillagesInRange.Size = new global::System.Drawing.Size(82, 23);
			this.button_addVillagesInRange.TabIndex = 15;
			this.button_addVillagesInRange.Text = "Add In Range";
			this.button_addVillagesInRange.UseVisualStyleBackColor = true;
			this.button_addVillagesInRange.Click += new global::System.EventHandler(this.Button_addVillagesInRange_Click);
			this.button_addMyVIllages.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_addMyVIllages.Location = new global::System.Drawing.Point(6, 311);
			this.button_addMyVIllages.Name = "button_addMyVIllages";
			this.button_addMyVIllages.Size = new global::System.Drawing.Size(128, 23);
			this.button_addMyVIllages.TabIndex = 11;
			this.button_addMyVIllages.Text = "Add Mine";
			this.button_addMyVIllages.UseVisualStyleBackColor = true;
			this.button_addMyVIllages.Click += new global::System.EventHandler(this.Button_addMyVIllages_Click);
			this.groupBox_maxDistance.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
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
			this.groupBox_maxDistance.Location = new global::System.Drawing.Point(435, 285);
			this.groupBox_maxDistance.Name = "groupBox_maxDistance";
			this.groupBox_maxDistance.Size = new global::System.Drawing.Size(264, 119);
			this.groupBox_maxDistance.TabIndex = 26;
			this.groupBox_maxDistance.TabStop = false;
			this.groupBox_maxDistance.Text = "Max Distance";
			this.checkBox_IsDistanceLimited.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkBox_IsDistanceLimited.AutoSize = true;
			this.checkBox_IsDistanceLimited.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_IsDistanceLimited.Location = new global::System.Drawing.Point(52, 73);
			this.checkBox_IsDistanceLimited.Name = "checkBox_IsDistanceLimited";
			this.checkBox_IsDistanceLimited.Size = new global::System.Drawing.Size(96, 17);
			this.checkBox_IsDistanceLimited.TabIndex = 10;
			this.checkBox_IsDistanceLimited.Text = "Limit distance?";
			this.checkBox_IsDistanceLimited.UseVisualStyleBackColor = true;
			this.checkBox_IsDistanceLimited.CheckedChanged += new global::System.EventHandler(this.CheckBox_IsDistanceLimited_CheckedChanged);
			this.numericUpDown_maxDistanceLimit.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_maxDistanceLimit;
			int[] array7 = new int[4];
			array7[0] = 10;
			numericUpDown7.Increment = new decimal(array7);
			this.numericUpDown_maxDistanceLimit.Location = new global::System.Drawing.Point(135, 90);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_maxDistanceLimit;
			int[] array8 = new int[4];
			array8[0] = 10000;
			numericUpDown8.Maximum = new decimal(array8);
			this.numericUpDown_maxDistanceLimit.Name = "numericUpDown_maxDistanceLimit";
			this.numericUpDown_maxDistanceLimit.Size = new global::System.Drawing.Size(56, 20);
			this.numericUpDown_maxDistanceLimit.TabIndex = 9;
			this.numericUpDown_maxDistanceLimit.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_maxDistanceLimit.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numericUpDown_maxDistanceLimit;
			int[] array9 = new int[4];
			array9[0] = 32;
			numericUpDown9.Value = new decimal(array9);
			this.numericUpDown_maxDistanceLimit.ValueChanged += new global::System.EventHandler(this.NumericUpDown_maxDistanceLimit_ValueChanged);
			this.label_maxDistanceLimit.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceLimit.Location = new global::System.Drawing.Point(53, 90);
			this.label_maxDistanceLimit.Name = "label_maxDistanceLimit";
			this.label_maxDistanceLimit.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceLimit.TabIndex = 8;
			this.label_maxDistanceLimit.Text = "Limit:";
			this.label_maxDistanceLimit.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceTimeValue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceTimeValue.AutoSize = true;
			this.label_maxDistanceTimeValue.Location = new global::System.Drawing.Point(132, 59);
			this.label_maxDistanceTimeValue.Name = "label_maxDistanceTimeValue";
			this.label_maxDistanceTimeValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceTimeValue.TabIndex = 7;
			this.label_maxDistanceTimeValue.Text = "no data";
			this.label_maxDistanceValue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceValue.AutoSize = true;
			this.label_maxDistanceValue.Location = new global::System.Drawing.Point(132, 46);
			this.label_maxDistanceValue.Name = "label_maxDistanceValue";
			this.label_maxDistanceValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceValue.TabIndex = 6;
			this.label_maxDistanceValue.Text = "no data";
			this.label_maxDistanceToValue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceToValue.AutoSize = true;
			this.label_maxDistanceToValue.Location = new global::System.Drawing.Point(132, 33);
			this.label_maxDistanceToValue.Name = "label_maxDistanceToValue";
			this.label_maxDistanceToValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceToValue.TabIndex = 5;
			this.label_maxDistanceToValue.Text = "no data";
			this.label_maxDistanceFromValue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceFromValue.AutoSize = true;
			this.label_maxDistanceFromValue.Location = new global::System.Drawing.Point(132, 20);
			this.label_maxDistanceFromValue.Name = "label_maxDistanceFromValue";
			this.label_maxDistanceFromValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_maxDistanceFromValue.TabIndex = 4;
			this.label_maxDistanceFromValue.Text = "no data";
			this.label_maxDistanceTime.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceTime.Location = new global::System.Drawing.Point(53, 59);
			this.label_maxDistanceTime.Name = "label_maxDistanceTime";
			this.label_maxDistanceTime.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceTime.TabIndex = 3;
			this.label_maxDistanceTime.Text = "Time:";
			this.label_maxDistanceTime.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistancePoints.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistancePoints.Location = new global::System.Drawing.Point(53, 46);
			this.label_maxDistancePoints.Name = "label_maxDistancePoints";
			this.label_maxDistancePoints.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistancePoints.TabIndex = 2;
			this.label_maxDistancePoints.Text = "Distance:";
			this.label_maxDistancePoints.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceTo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceTo.Location = new global::System.Drawing.Point(52, 33);
			this.label_maxDistanceTo.Name = "label_maxDistanceTo";
			this.label_maxDistanceTo.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceTo.TabIndex = 1;
			this.label_maxDistanceTo.Text = "To:";
			this.label_maxDistanceTo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_maxDistanceFrom.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_maxDistanceFrom.Location = new global::System.Drawing.Point(53, 20);
			this.label_maxDistanceFrom.Name = "label_maxDistanceFrom";
			this.label_maxDistanceFrom.Size = new global::System.Drawing.Size(73, 13);
			this.label_maxDistanceFrom.TabIndex = 0;
			this.label_maxDistanceFrom.Text = "From:";
			this.label_maxDistanceFrom.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_resultingSchedule.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_resultingSchedule.AutoSize = true;
			this.label_resultingSchedule.Location = new global::System.Drawing.Point(1, 412);
			this.label_resultingSchedule.Name = "label_resultingSchedule";
			this.label_resultingSchedule.Size = new global::System.Drawing.Size(100, 13);
			this.label_resultingSchedule.TabIndex = 31;
			this.label_resultingSchedule.Text = "Resulting schedule:";
			this.listBox_Trips.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.listBox_Trips.FormattingEnabled = true;
			this.listBox_Trips.HorizontalScrollbar = true;
			this.listBox_Trips.Location = new global::System.Drawing.Point(0, 435);
			this.listBox_Trips.Name = "listBox_Trips";
			this.listBox_Trips.Size = new global::System.Drawing.Size(708, 173);
			this.listBox_Trips.TabIndex = 30;
			this.checkBox_allVillages.AutoSize = true;
			this.checkBox_allVillages.Location = new global::System.Drawing.Point(122, 9);
			this.checkBox_allVillages.Name = "checkBox_allVillages";
			this.checkBox_allVillages.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_allVillages.TabIndex = 32;
			this.checkBox_allVillages.UseVisualStyleBackColor = true;
			this.checkBox_allVillages.CheckedChanged += new global::System.EventHandler(this.CheckBox_allVillages_CheckedChanged);
			this.label_command.Location = new global::System.Drawing.Point(435, 64);
			this.label_command.Name = "label_command";
			this.label_command.Size = new global::System.Drawing.Size(100, 13);
			this.label_command.TabIndex = 33;
			this.label_command.Text = "Monk Command:";
			this.label_command.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.comboBox_command.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_command.FormattingEnabled = true;
			this.comboBox_command.Location = new global::System.Drawing.Point(535, 61);
			this.comboBox_command.Name = "comboBox_command";
			this.comboBox_command.Size = new global::System.Drawing.Size(161, 21);
			this.comboBox_command.TabIndex = 34;
			this.comboBox_command.SelectedIndexChanged += new global::System.EventHandler(this.ComboBox_command_SelectedIndexChanged);
			this.label_stopCondition.Location = new global::System.Drawing.Point(435, 91);
			this.label_stopCondition.Name = "label_stopCondition";
			this.label_stopCondition.Size = new global::System.Drawing.Size(100, 13);
			this.label_stopCondition.TabIndex = 35;
			this.label_stopCondition.Text = "Stop condition:";
			this.label_stopCondition.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_stopCondition.Visible = false;
			this.comboBox_stopCondition.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.comboBox_stopCondition.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_stopCondition.FormattingEnabled = true;
			this.comboBox_stopCondition.Location = new global::System.Drawing.Point(535, 88);
			this.comboBox_stopCondition.Name = "comboBox_stopCondition";
			this.comboBox_stopCondition.Size = new global::System.Drawing.Size(161, 21);
			this.comboBox_stopCondition.TabIndex = 36;
			this.comboBox_stopCondition.Visible = false;
			this.comboBox_stopCondition.SelectedIndexChanged += new global::System.EventHandler(this.ComboBox_stopCondition_SelectedIndexChanged);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.numericUpDown_ExtraParameter;
			int[] array10 = new int[4];
			array10[0] = 4;
			numericUpDown10.Increment = new decimal(array10);
			this.numericUpDown_ExtraParameter.Location = new global::System.Drawing.Point(536, 115);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.numericUpDown_ExtraParameter;
			int[] array11 = new int[4];
			array11[0] = 100000;
			numericUpDown11.Maximum = new decimal(array11);
			this.numericUpDown_ExtraParameter.Name = "numericUpDown_ExtraParameter";
			this.numericUpDown_ExtraParameter.Size = new global::System.Drawing.Size(160, 20);
			this.numericUpDown_ExtraParameter.TabIndex = 37;
			this.numericUpDown_ExtraParameter.Visible = false;
			this.label_ExtraParameter.AutoSize = true;
			this.label_ExtraParameter.Location = new global::System.Drawing.Point(512, 117);
			this.label_ExtraParameter.Name = "label_ExtraParameter";
			this.label_ExtraParameter.Size = new global::System.Drawing.Size(23, 13);
			this.label_ExtraParameter.TabIndex = 38;
			this.label_ExtraParameter.Text = "X =";
			this.label_ExtraParameter.Visible = false;
			this.label_specificStopCondition.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_specificStopCondition.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_specificStopCondition.Location = new global::System.Drawing.Point(435, 142);
			this.label_specificStopCondition.Name = "label_specificStopCondition";
			this.label_specificStopCondition.Size = new global::System.Drawing.Size(261, 101);
			this.label_specificStopCondition.TabIndex = 39;
			this.label_specificStopCondition.Text = "no data";
			this.label_specificStopCondition.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(708, 608);
			base.Controls.Add(this.label_specificStopCondition);
			base.Controls.Add(this.label_ExtraParameter);
			base.Controls.Add(this.numericUpDown_ExtraParameter);
			base.Controls.Add(this.comboBox_stopCondition);
			base.Controls.Add(this.label_stopCondition);
			base.Controls.Add(this.comboBox_command);
			base.Controls.Add(this.label_command);
			base.Controls.Add(this.checkBox_allVillages);
			base.Controls.Add(this.label_resultingSchedule);
			base.Controls.Add(this.listBox_Trips);
			base.Controls.Add(this.groupBox_maxDistance);
			base.Controls.Add(this.groupBox_targetVillages);
			base.Controls.Add(this.groupBox_targetParishes);
			base.Controls.Add(this.button_SaveMonkRoute);
			base.Controls.Add(this.label_villages);
			base.Controls.Add(this.label_name);
			base.Controls.Add(this.textBox_name);
			base.Controls.Add(this.checkBox_routeEnabled);
			base.Controls.Add(this.listBox_villages);
			this.MinimumSize = new global::System.Drawing.Size(724, 647);
			base.Name = "MonkRouteEditor";
			this.Text = "Monks Route Editor v2.0";
			this.groupBox_targetParishes.ResumeLayout(false);
			this.groupBox_targetParishes.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_parishesRange).EndInit();
			this.groupBox_targetVillages.ResumeLayout(false);
			this.groupBox_targetVillages.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_villagesRange).EndInit();
			this.groupBox_maxDistance.ResumeLayout(false);
			this.groupBox_maxDistance.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_maxDistanceLimit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ExtraParameter).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002E6 RID: 742
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.ListBox listBox_villages;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.CheckBox checkBox_routeEnabled;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.TextBox textBox_name;

		// Token: 0x040002EA RID: 746
		private global::System.Windows.Forms.Label label_name;

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.ListBox listBox_targetParishes;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.ListBox listBox_targetVillages;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.TextBox textBox_capitalId;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.TextBox textBox_villageId;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.Button button_addParish;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.Button button_addVillage;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Label label_villages;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.Button button_SaveMonkRoute;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.GroupBox groupBox_targetParishes;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.GroupBox groupBox_targetVillages;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.GroupBox groupBox_maxDistance;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.CheckBox checkBox_IsDistanceLimited;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.NumericUpDown numericUpDown_maxDistanceLimit;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Label label_maxDistanceLimit;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.Label label_maxDistanceTimeValue;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.Label label_maxDistanceValue;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.Label label_maxDistanceToValue;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.Label label_maxDistanceFromValue;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.Label label_maxDistanceTime;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.Label label_maxDistancePoints;

		// Token: 0x040002FF RID: 767
		private global::System.Windows.Forms.Label label_maxDistanceTo;

		// Token: 0x04000300 RID: 768
		private global::System.Windows.Forms.Label label_maxDistanceFrom;

		// Token: 0x04000301 RID: 769
		private global::System.Windows.Forms.Label label_resultingSchedule;

		// Token: 0x04000302 RID: 770
		private global::System.Windows.Forms.ListBox listBox_Trips;

		// Token: 0x04000303 RID: 771
		private global::System.Windows.Forms.Button button_addParishesImIn;

		// Token: 0x04000304 RID: 772
		private global::System.Windows.Forms.Button button_addMyParishes;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.Button button_addMyVIllages;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.NumericUpDown numericUpDown_parishesRange;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.Button button_clearParishes;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.Button button_addParishesInRange;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.NumericUpDown numericUpDown_villagesRange;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.Button button_clearTargetVillages;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.Button button_addVillagesInRange;

		// Token: 0x0400030C RID: 780
		private global::System.Windows.Forms.CheckBox checkBox_allVillages;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.Label label_command;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.ComboBox comboBox_command;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.Label label_stopCondition;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.ComboBox comboBox_stopCondition;

		// Token: 0x04000311 RID: 785
		private global::System.Windows.Forms.NumericUpDown numericUpDown_ExtraParameter;

		// Token: 0x04000312 RID: 786
		private global::System.Windows.Forms.Label label_ExtraParameter;

		// Token: 0x04000313 RID: 787
		private global::System.Windows.Forms.Label label_specificStopCondition;
	}
}
