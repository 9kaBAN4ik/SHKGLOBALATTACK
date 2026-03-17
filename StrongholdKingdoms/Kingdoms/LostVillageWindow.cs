using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000219 RID: 537
	public partial class LostVillageWindow : Form
	{
		// Token: 0x06001690 RID: 5776 RVA: 0x00017D7D File Offset: 0x00015F7D
		public LostVillageWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x00017DA7 File Offset: 0x00015FA7
		public bool isCardsPopup()
		{
			return this.lastMode >= 0;
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x001670CC File Offset: 0x001652CC
		public void init(int age, int cardsMode)
		{
			if (age == 1000)
			{
				base.Width = 688;
				base.Height = 625;
				this.customPanel.Width = 688;
				this.customPanel.Height = 625;
			}
			this.lastMode = cardsMode;
			this.customPanel.init(this, age, cardsMode);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x00017DB5 File Offset: 0x00015FB5
		public void update()
		{
			this.customPanel.update();
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x00017DC2 File Offset: 0x00015FC2
		public void closePopup()
		{
			this.customPanel.closePopup();
		}

		// Token: 0x06001695 RID: 5781 RVA: 0x00167184 File Offset: 0x00165384
		private void LostVillageWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				GameEngine.Instance.closeNoVillagePopup(false);
				LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			}
		}

		// Token: 0x040026E7 RID: 9959
		private int lastMode = -1;

		// Token: 0x040026E8 RID: 9960
		public bool closing;
	}
}
