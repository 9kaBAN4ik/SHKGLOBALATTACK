using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000255 RID: 597
	public partial class NewQuestRewardPopup : Form
	{
		// Token: 0x06001A4E RID: 6734 RVA: 0x0001A58C File Offset: 0x0001878C
		public NewQuestRewardPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x0001A5AF File Offset: 0x000187AF
		public void init(int questID, int villageID, NewQuestsPanel parent)
		{
			this.newQuestRewardPanel.Visible = true;
			this.newQuestRewardPanel.init(questID, villageID, parent, this);
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x0001A5CC File Offset: 0x000187CC
		public void update()
		{
			this.newQuestRewardPanel.update();
		}
	}
}
