using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DXGraphics;
using Kingdoms;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x0200002C RID: 44
	public partial class RadarPopupMessage : Form
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x00043BAC File Offset: 0x00041DAC
		internal RadarPopupMessage(Image image, string eventType, string from, string to, string faction, int house, double arrives, CloseAllMessages del)
		{
			this.InitializeComponent();
			this._timeLeft = arrives - DXTimer.GetCurrentMilliseconds() / 1000.0;
			if (this._timeLeft < 1.0)
			{
				this._timeLeft = 60.0;
			}
			LNG.TranslateSecondaryForms(this);
			this.t = new System.Threading.Timer(new TimerCallback(this.SetTime), null, 0, 1000);
			this.Text = eventType;
			this.pictureBox1.Image = image;
			this.label_from_Value.Text = from;
			this.label_To_Value.Text = to;
			this.label_Faction_Value.Text = faction;
			this.label_House_Value.Text = house.ToString();
			this.label_Arrives_Value.Text = DateTime.Now.AddSeconds(this._timeLeft).ToString();
			this.button_closeAll.Click += del.Invoke;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00043CAC File Offset: 0x00041EAC
		private void SetTime(object state)
		{
			if (base.IsDisposed || base.Disposing || this.label_Time_Value.IsDisposed || this.label_Time_Value.Disposing)
			{
				return;
			}
			try
			{
				Control control = this.label_Time_Value;
				double timeLeft = this._timeLeft;
				this._timeLeft = timeLeft - 1.0;
				control.Text = VillageMap.createBuildTimeString((int)timeLeft);
				if (this._timeLeft <= -1.0)
				{
					this.t.Dispose();
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00009024 File Offset: 0x00007224
		private void button_close_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00043D48 File Offset: 0x00041F48
		private void RadarPopupMessage_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.t.Dispose();
			}
			catch
			{
			}
		}

		// Token: 0x04000322 RID: 802
		private System.Threading.Timer t;

		// Token: 0x04000323 RID: 803
		private double _timeLeft;
	}
}
