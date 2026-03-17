namespace Upgrade
{
	// Token: 0x0200002C RID: 44
	public partial class RadarPopupMessage : global::System.Windows.Forms.Form
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x0000902C File Offset: 0x0000722C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00043D78 File Offset: 0x00041F78
		private void InitializeComponent()
		{
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label_from = new global::System.Windows.Forms.Label();
			this.label_to = new global::System.Windows.Forms.Label();
			this.label_faction = new global::System.Windows.Forms.Label();
			this.label_house = new global::System.Windows.Forms.Label();
			this.label_timeLeft = new global::System.Windows.Forms.Label();
			this.label_arrives = new global::System.Windows.Forms.Label();
			this.button_close = new global::System.Windows.Forms.Button();
			this.button_closeAll = new global::System.Windows.Forms.Button();
			this.label_from_Value = new global::System.Windows.Forms.Label();
			this.label_To_Value = new global::System.Windows.Forms.Label();
			this.label_Faction_Value = new global::System.Windows.Forms.Label();
			this.label_House_Value = new global::System.Windows.Forms.Label();
			this.label_Time_Value = new global::System.Windows.Forms.Label();
			this.label_Arrives_Value = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Location = new global::System.Drawing.Point(12, 12);
			this.pictureBox1.MinimumSize = new global::System.Drawing.Size(665, 169);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(665, 169);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.label_from.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_from.Location = new global::System.Drawing.Point(12, 184);
			this.label_from.Name = "label_from";
			this.label_from.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_from.Size = new global::System.Drawing.Size(230, 29);
			this.label_from.TabIndex = 1;
			this.label_from.Text = "From:";
			this.label_from.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_to.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_to.Location = new global::System.Drawing.Point(12, 213);
			this.label_to.Name = "label_to";
			this.label_to.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_to.Size = new global::System.Drawing.Size(230, 29);
			this.label_to.TabIndex = 6;
			this.label_to.Text = "To:";
			this.label_to.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_faction.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_faction.Location = new global::System.Drawing.Point(12, 242);
			this.label_faction.Name = "label_faction";
			this.label_faction.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_faction.Size = new global::System.Drawing.Size(230, 29);
			this.label_faction.TabIndex = 7;
			this.label_faction.Text = "Faction:";
			this.label_faction.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_house.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_house.Location = new global::System.Drawing.Point(12, 271);
			this.label_house.Name = "label_house";
			this.label_house.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_house.Size = new global::System.Drawing.Size(230, 29);
			this.label_house.TabIndex = 8;
			this.label_house.Text = "House:";
			this.label_house.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_timeLeft.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_timeLeft.Location = new global::System.Drawing.Point(7, 300);
			this.label_timeLeft.Name = "label_timeLeft";
			this.label_timeLeft.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_timeLeft.Size = new global::System.Drawing.Size(235, 29);
			this.label_timeLeft.TabIndex = 9;
			this.label_timeLeft.Text = "Time left:";
			this.label_timeLeft.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_arrives.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_arrives.Location = new global::System.Drawing.Point(12, 329);
			this.label_arrives.Name = "label_arrives";
			this.label_arrives.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.label_arrives.Size = new global::System.Drawing.Size(230, 29);
			this.label_arrives.TabIndex = 10;
			this.label_arrives.Text = "Arrives:";
			this.label_arrives.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.button_close.Location = new global::System.Drawing.Point(314, 361);
			this.button_close.Name = "button_close";
			this.button_close.Size = new global::System.Drawing.Size(164, 30);
			this.button_close.TabIndex = 11;
			this.button_close.Text = "Close";
			this.button_close.UseVisualStyleBackColor = true;
			this.button_close.Click += new global::System.EventHandler(this.button_close_Click);
			this.button_closeAll.Location = new global::System.Drawing.Point(513, 361);
			this.button_closeAll.Name = "button_closeAll";
			this.button_closeAll.Size = new global::System.Drawing.Size(164, 30);
			this.button_closeAll.TabIndex = 12;
			this.button_closeAll.Text = "Close All";
			this.button_closeAll.UseVisualStyleBackColor = true;
			this.label_from_Value.AutoSize = true;
			this.label_from_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_from_Value.Location = new global::System.Drawing.Point(248, 184);
			this.label_from_Value.Name = "label_from_Value";
			this.label_from_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_from_Value.TabIndex = 13;
			this.label_To_Value.AutoSize = true;
			this.label_To_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_To_Value.Location = new global::System.Drawing.Point(248, 213);
			this.label_To_Value.Name = "label_To_Value";
			this.label_To_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_To_Value.TabIndex = 14;
			this.label_Faction_Value.AutoSize = true;
			this.label_Faction_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_Faction_Value.Location = new global::System.Drawing.Point(248, 242);
			this.label_Faction_Value.Name = "label_Faction_Value";
			this.label_Faction_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_Faction_Value.TabIndex = 15;
			this.label_House_Value.AutoSize = true;
			this.label_House_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_House_Value.Location = new global::System.Drawing.Point(248, 271);
			this.label_House_Value.Name = "label_House_Value";
			this.label_House_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_House_Value.TabIndex = 16;
			this.label_Time_Value.AutoSize = true;
			this.label_Time_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_Time_Value.Location = new global::System.Drawing.Point(248, 300);
			this.label_Time_Value.Name = "label_Time_Value";
			this.label_Time_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_Time_Value.TabIndex = 17;
			this.label_Arrives_Value.AutoSize = true;
			this.label_Arrives_Value.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label_Arrives_Value.Location = new global::System.Drawing.Point(248, 329);
			this.label_Arrives_Value.Name = "label_Arrives_Value";
			this.label_Arrives_Value.Size = new global::System.Drawing.Size(0, 29);
			this.label_Arrives_Value.TabIndex = 18;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(689, 403);
			base.Controls.Add(this.label_Arrives_Value);
			base.Controls.Add(this.label_Time_Value);
			base.Controls.Add(this.label_House_Value);
			base.Controls.Add(this.label_Faction_Value);
			base.Controls.Add(this.label_To_Value);
			base.Controls.Add(this.label_from_Value);
			base.Controls.Add(this.button_closeAll);
			base.Controls.Add(this.button_close);
			base.Controls.Add(this.label_arrives);
			base.Controls.Add(this.label_timeLeft);
			base.Controls.Add(this.label_house);
			base.Controls.Add(this.label_faction);
			base.Controls.Add(this.label_to);
			base.Controls.Add(this.label_from);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(705, 342);
			base.Name = "RadarPopupMessage";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RadarPopupMessages";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.RadarPopupMessage_FormClosing);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000324 RID: 804
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000325 RID: 805
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000326 RID: 806
		private global::System.Windows.Forms.Label label_from;

		// Token: 0x04000327 RID: 807
		private global::System.Windows.Forms.Label label_to;

		// Token: 0x04000328 RID: 808
		private global::System.Windows.Forms.Label label_faction;

		// Token: 0x04000329 RID: 809
		private global::System.Windows.Forms.Label label_house;

		// Token: 0x0400032A RID: 810
		private global::System.Windows.Forms.Label label_timeLeft;

		// Token: 0x0400032B RID: 811
		private global::System.Windows.Forms.Label label_arrives;

		// Token: 0x0400032C RID: 812
		private global::System.Windows.Forms.Button button_close;

		// Token: 0x0400032D RID: 813
		private global::System.Windows.Forms.Button button_closeAll;

		// Token: 0x0400032E RID: 814
		private global::System.Windows.Forms.Label label_from_Value;

		// Token: 0x0400032F RID: 815
		private global::System.Windows.Forms.Label label_To_Value;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.Label label_Faction_Value;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.Label label_House_Value;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.Label label_Time_Value;

		// Token: 0x04000333 RID: 819
		private global::System.Windows.Forms.Label label_Arrives_Value;
	}
}
