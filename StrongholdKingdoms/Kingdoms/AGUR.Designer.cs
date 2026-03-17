namespace Kingdoms
{
	// Token: 0x020000BF RID: 191
	public partial class AGUR : global::System.Windows.Forms.Form
	{
		// Token: 0x06000546 RID: 1350 RVA: 0x0000AD4F File Offset: 0x00008F4F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00063E44 File Offset: 0x00062044
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.AGUR));
			this.btnGiveResources = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.tbAmount = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.rbWood = new global::System.Windows.Forms.RadioButton();
			this.rbStone = new global::System.Windows.Forms.RadioButton();
			this.rbIron = new global::System.Windows.Forms.RadioButton();
			this.rbPitch = new global::System.Windows.Forms.RadioButton();
			this.rbApples = new global::System.Windows.Forms.RadioButton();
			this.rbMeat = new global::System.Windows.Forms.RadioButton();
			this.rbCheese = new global::System.Windows.Forms.RadioButton();
			this.rbBread = new global::System.Windows.Forms.RadioButton();
			this.rbVeg = new global::System.Windows.Forms.RadioButton();
			this.rbFish = new global::System.Windows.Forms.RadioButton();
			this.rbAle = new global::System.Windows.Forms.RadioButton();
			this.rbBows = new global::System.Windows.Forms.RadioButton();
			this.rbPikes = new global::System.Windows.Forms.RadioButton();
			this.rbSwords = new global::System.Windows.Forms.RadioButton();
			this.rbArmour = new global::System.Windows.Forms.RadioButton();
			this.rbCatapults = new global::System.Windows.Forms.RadioButton();
			this.rbVenison = new global::System.Windows.Forms.RadioButton();
			this.rbClothes = new global::System.Windows.Forms.RadioButton();
			this.rbFurniture = new global::System.Windows.Forms.RadioButton();
			this.rbWine = new global::System.Windows.Forms.RadioButton();
			this.rbSalt = new global::System.Windows.Forms.RadioButton();
			this.rbMetalware = new global::System.Windows.Forms.RadioButton();
			this.rbSpices = new global::System.Windows.Forms.RadioButton();
			this.rbSilk = new global::System.Windows.Forms.RadioButton();
			base.SuspendLayout();
			this.btnGiveResources.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnGiveResources.Location = new global::System.Drawing.Point(294, 244);
			this.btnGiveResources.Name = "btnGiveResources";
			this.btnGiveResources.Size = new global::System.Drawing.Size(116, 26);
			this.btnGiveResources.TabIndex = 0;
			this.btnGiveResources.Text = "Give Resources";
			this.btnGiveResources.UseVisualStyleBackColor = true;
			this.btnGiveResources.Click += new global::System.EventHandler(this.btnGiveResources_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.Location = new global::System.Drawing.Point(172, 244);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(116, 26);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.tbAmount.Location = new global::System.Drawing.Point(21, 207);
			this.tbAmount.Name = "tbAmount";
			this.tbAmount.Size = new global::System.Drawing.Size(100, 20);
			this.tbAmount.TabIndex = 2;
			this.tbAmount.Text = "0";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(127, 210);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(100, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Amount (1-100,000)";
			this.rbWood.AutoSize = true;
			this.rbWood.Checked = true;
			this.rbWood.Location = new global::System.Drawing.Point(21, 12);
			this.rbWood.Name = "rbWood";
			this.rbWood.Size = new global::System.Drawing.Size(54, 17);
			this.rbWood.TabIndex = 4;
			this.rbWood.TabStop = true;
			this.rbWood.Text = "Wood";
			this.rbWood.UseVisualStyleBackColor = true;
			this.rbStone.AutoSize = true;
			this.rbStone.Location = new global::System.Drawing.Point(21, 35);
			this.rbStone.Name = "rbStone";
			this.rbStone.Size = new global::System.Drawing.Size(53, 17);
			this.rbStone.TabIndex = 5;
			this.rbStone.Text = "Stone";
			this.rbStone.UseVisualStyleBackColor = true;
			this.rbIron.AutoSize = true;
			this.rbIron.Location = new global::System.Drawing.Point(21, 58);
			this.rbIron.Name = "rbIron";
			this.rbIron.Size = new global::System.Drawing.Size(43, 17);
			this.rbIron.TabIndex = 6;
			this.rbIron.Text = "Iron";
			this.rbIron.UseVisualStyleBackColor = true;
			this.rbPitch.AutoSize = true;
			this.rbPitch.Location = new global::System.Drawing.Point(21, 81);
			this.rbPitch.Name = "rbPitch";
			this.rbPitch.Size = new global::System.Drawing.Size(49, 17);
			this.rbPitch.TabIndex = 7;
			this.rbPitch.Text = "Pitch";
			this.rbPitch.UseVisualStyleBackColor = true;
			this.rbApples.AutoSize = true;
			this.rbApples.Location = new global::System.Drawing.Point(105, 12);
			this.rbApples.Name = "rbApples";
			this.rbApples.Size = new global::System.Drawing.Size(57, 17);
			this.rbApples.TabIndex = 8;
			this.rbApples.Text = "Apples";
			this.rbApples.UseVisualStyleBackColor = true;
			this.rbMeat.AutoSize = true;
			this.rbMeat.Location = new global::System.Drawing.Point(105, 35);
			this.rbMeat.Name = "rbMeat";
			this.rbMeat.Size = new global::System.Drawing.Size(49, 17);
			this.rbMeat.TabIndex = 9;
			this.rbMeat.Text = "Meat";
			this.rbMeat.UseVisualStyleBackColor = true;
			this.rbCheese.AutoSize = true;
			this.rbCheese.Location = new global::System.Drawing.Point(105, 58);
			this.rbCheese.Name = "rbCheese";
			this.rbCheese.Size = new global::System.Drawing.Size(61, 17);
			this.rbCheese.TabIndex = 10;
			this.rbCheese.Text = "Cheese";
			this.rbCheese.UseVisualStyleBackColor = true;
			this.rbBread.AutoSize = true;
			this.rbBread.Location = new global::System.Drawing.Point(105, 81);
			this.rbBread.Name = "rbBread";
			this.rbBread.Size = new global::System.Drawing.Size(53, 17);
			this.rbBread.TabIndex = 11;
			this.rbBread.Text = "Bread";
			this.rbBread.UseVisualStyleBackColor = true;
			this.rbVeg.AutoSize = true;
			this.rbVeg.Location = new global::System.Drawing.Point(105, 104);
			this.rbVeg.Name = "rbVeg";
			this.rbVeg.Size = new global::System.Drawing.Size(44, 17);
			this.rbVeg.TabIndex = 12;
			this.rbVeg.Text = "Veg";
			this.rbVeg.UseVisualStyleBackColor = true;
			this.rbFish.AutoSize = true;
			this.rbFish.Location = new global::System.Drawing.Point(105, 127);
			this.rbFish.Name = "rbFish";
			this.rbFish.Size = new global::System.Drawing.Size(44, 17);
			this.rbFish.TabIndex = 13;
			this.rbFish.Text = "Fish";
			this.rbFish.UseVisualStyleBackColor = true;
			this.rbAle.AutoSize = true;
			this.rbAle.Location = new global::System.Drawing.Point(21, 127);
			this.rbAle.Name = "rbAle";
			this.rbAle.Size = new global::System.Drawing.Size(40, 17);
			this.rbAle.TabIndex = 14;
			this.rbAle.Text = "Ale";
			this.rbAle.UseVisualStyleBackColor = true;
			this.rbBows.AutoSize = true;
			this.rbBows.Location = new global::System.Drawing.Point(201, 12);
			this.rbBows.Name = "rbBows";
			this.rbBows.Size = new global::System.Drawing.Size(51, 17);
			this.rbBows.TabIndex = 15;
			this.rbBows.Text = "Bows";
			this.rbBows.UseVisualStyleBackColor = true;
			this.rbPikes.AutoSize = true;
			this.rbPikes.Location = new global::System.Drawing.Point(201, 35);
			this.rbPikes.Name = "rbPikes";
			this.rbPikes.Size = new global::System.Drawing.Size(51, 17);
			this.rbPikes.TabIndex = 16;
			this.rbPikes.Text = "Pikes";
			this.rbPikes.UseVisualStyleBackColor = true;
			this.rbSwords.AutoSize = true;
			this.rbSwords.Location = new global::System.Drawing.Point(201, 58);
			this.rbSwords.Name = "rbSwords";
			this.rbSwords.Size = new global::System.Drawing.Size(60, 17);
			this.rbSwords.TabIndex = 17;
			this.rbSwords.Text = "Swords";
			this.rbSwords.UseVisualStyleBackColor = true;
			this.rbArmour.AutoSize = true;
			this.rbArmour.Location = new global::System.Drawing.Point(201, 81);
			this.rbArmour.Name = "rbArmour";
			this.rbArmour.Size = new global::System.Drawing.Size(58, 17);
			this.rbArmour.TabIndex = 18;
			this.rbArmour.Text = "Armour";
			this.rbArmour.UseVisualStyleBackColor = true;
			this.rbCatapults.AutoSize = true;
			this.rbCatapults.Location = new global::System.Drawing.Point(201, 104);
			this.rbCatapults.Name = "rbCatapults";
			this.rbCatapults.Size = new global::System.Drawing.Size(69, 17);
			this.rbCatapults.TabIndex = 19;
			this.rbCatapults.Text = "Catapults";
			this.rbCatapults.UseVisualStyleBackColor = true;
			this.rbVenison.AutoSize = true;
			this.rbVenison.Location = new global::System.Drawing.Point(298, 12);
			this.rbVenison.Name = "rbVenison";
			this.rbVenison.Size = new global::System.Drawing.Size(63, 17);
			this.rbVenison.TabIndex = 20;
			this.rbVenison.Text = "Venison";
			this.rbVenison.UseVisualStyleBackColor = true;
			this.rbClothes.AutoSize = true;
			this.rbClothes.Location = new global::System.Drawing.Point(298, 35);
			this.rbClothes.Name = "rbClothes";
			this.rbClothes.Size = new global::System.Drawing.Size(60, 17);
			this.rbClothes.TabIndex = 21;
			this.rbClothes.Text = "Clothes";
			this.rbClothes.UseVisualStyleBackColor = true;
			this.rbFurniture.AutoSize = true;
			this.rbFurniture.Location = new global::System.Drawing.Point(298, 58);
			this.rbFurniture.Name = "rbFurniture";
			this.rbFurniture.Size = new global::System.Drawing.Size(66, 17);
			this.rbFurniture.TabIndex = 22;
			this.rbFurniture.Text = "Furniture";
			this.rbFurniture.UseVisualStyleBackColor = true;
			this.rbWine.AutoSize = true;
			this.rbWine.Location = new global::System.Drawing.Point(298, 81);
			this.rbWine.Name = "rbWine";
			this.rbWine.Size = new global::System.Drawing.Size(50, 17);
			this.rbWine.TabIndex = 23;
			this.rbWine.Text = "Wine";
			this.rbWine.UseVisualStyleBackColor = true;
			this.rbSalt.AutoSize = true;
			this.rbSalt.Location = new global::System.Drawing.Point(298, 104);
			this.rbSalt.Name = "rbSalt";
			this.rbSalt.Size = new global::System.Drawing.Size(43, 17);
			this.rbSalt.TabIndex = 24;
			this.rbSalt.Text = "Salt";
			this.rbSalt.UseVisualStyleBackColor = true;
			this.rbMetalware.AutoSize = true;
			this.rbMetalware.Location = new global::System.Drawing.Point(298, 127);
			this.rbMetalware.Name = "rbMetalware";
			this.rbMetalware.Size = new global::System.Drawing.Size(74, 17);
			this.rbMetalware.TabIndex = 25;
			this.rbMetalware.Text = "Metalware";
			this.rbMetalware.UseVisualStyleBackColor = true;
			this.rbSpices.AutoSize = true;
			this.rbSpices.Location = new global::System.Drawing.Point(298, 150);
			this.rbSpices.Name = "rbSpices";
			this.rbSpices.Size = new global::System.Drawing.Size(57, 17);
			this.rbSpices.TabIndex = 26;
			this.rbSpices.Text = "Spices";
			this.rbSpices.UseVisualStyleBackColor = true;
			this.rbSilk.AutoSize = true;
			this.rbSilk.Location = new global::System.Drawing.Point(298, 173);
			this.rbSilk.Name = "rbSilk";
			this.rbSilk.Size = new global::System.Drawing.Size(42, 17);
			this.rbSilk.TabIndex = 27;
			this.rbSilk.Text = "Silk";
			this.rbSilk.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(422, 282);
			base.Controls.Add(this.rbSilk);
			base.Controls.Add(this.rbSpices);
			base.Controls.Add(this.rbMetalware);
			base.Controls.Add(this.rbSalt);
			base.Controls.Add(this.rbWine);
			base.Controls.Add(this.rbFurniture);
			base.Controls.Add(this.rbClothes);
			base.Controls.Add(this.rbVenison);
			base.Controls.Add(this.rbCatapults);
			base.Controls.Add(this.rbArmour);
			base.Controls.Add(this.rbSwords);
			base.Controls.Add(this.rbPikes);
			base.Controls.Add(this.rbBows);
			base.Controls.Add(this.rbAle);
			base.Controls.Add(this.rbFish);
			base.Controls.Add(this.rbVeg);
			base.Controls.Add(this.rbBread);
			base.Controls.Add(this.rbCheese);
			base.Controls.Add(this.rbMeat);
			base.Controls.Add(this.rbApples);
			base.Controls.Add(this.rbPitch);
			base.Controls.Add(this.rbIron);
			base.Controls.Add(this.rbStone);
			base.Controls.Add(this.rbWood);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tbAmount);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnGiveResources);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "AGUR";
			this.Text = "Give Resources";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000609 RID: 1545
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400060A RID: 1546
		private global::System.Windows.Forms.Button btnGiveResources;

		// Token: 0x0400060B RID: 1547
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400060C RID: 1548
		private global::System.Windows.Forms.TextBox tbAmount;

		// Token: 0x0400060D RID: 1549
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400060E RID: 1550
		private global::System.Windows.Forms.RadioButton rbWood;

		// Token: 0x0400060F RID: 1551
		private global::System.Windows.Forms.RadioButton rbStone;

		// Token: 0x04000610 RID: 1552
		private global::System.Windows.Forms.RadioButton rbIron;

		// Token: 0x04000611 RID: 1553
		private global::System.Windows.Forms.RadioButton rbPitch;

		// Token: 0x04000612 RID: 1554
		private global::System.Windows.Forms.RadioButton rbApples;

		// Token: 0x04000613 RID: 1555
		private global::System.Windows.Forms.RadioButton rbMeat;

		// Token: 0x04000614 RID: 1556
		private global::System.Windows.Forms.RadioButton rbCheese;

		// Token: 0x04000615 RID: 1557
		private global::System.Windows.Forms.RadioButton rbBread;

		// Token: 0x04000616 RID: 1558
		private global::System.Windows.Forms.RadioButton rbVeg;

		// Token: 0x04000617 RID: 1559
		private global::System.Windows.Forms.RadioButton rbFish;

		// Token: 0x04000618 RID: 1560
		private global::System.Windows.Forms.RadioButton rbAle;

		// Token: 0x04000619 RID: 1561
		private global::System.Windows.Forms.RadioButton rbBows;

		// Token: 0x0400061A RID: 1562
		private global::System.Windows.Forms.RadioButton rbPikes;

		// Token: 0x0400061B RID: 1563
		private global::System.Windows.Forms.RadioButton rbSwords;

		// Token: 0x0400061C RID: 1564
		private global::System.Windows.Forms.RadioButton rbArmour;

		// Token: 0x0400061D RID: 1565
		private global::System.Windows.Forms.RadioButton rbCatapults;

		// Token: 0x0400061E RID: 1566
		private global::System.Windows.Forms.RadioButton rbVenison;

		// Token: 0x0400061F RID: 1567
		private global::System.Windows.Forms.RadioButton rbClothes;

		// Token: 0x04000620 RID: 1568
		private global::System.Windows.Forms.RadioButton rbFurniture;

		// Token: 0x04000621 RID: 1569
		private global::System.Windows.Forms.RadioButton rbWine;

		// Token: 0x04000622 RID: 1570
		private global::System.Windows.Forms.RadioButton rbSalt;

		// Token: 0x04000623 RID: 1571
		private global::System.Windows.Forms.RadioButton rbMetalware;

		// Token: 0x04000624 RID: 1572
		private global::System.Windows.Forms.RadioButton rbSpices;

		// Token: 0x04000625 RID: 1573
		private global::System.Windows.Forms.RadioButton rbSilk;
	}
}
