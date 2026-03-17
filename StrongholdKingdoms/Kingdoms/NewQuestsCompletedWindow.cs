using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000258 RID: 600
	public partial class NewQuestsCompletedWindow : Form
	{
		// Token: 0x06001A60 RID: 6752 RVA: 0x0001A6AE File Offset: 0x000188AE
		public NewQuestsCompletedWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x001A0850 File Offset: 0x0019EA50
		public void init(Form parent, List<int> quests, bool forQuestList, string questTag, int questID)
		{
			if (parent != null)
			{
				base.Location = new Point(parent.Location.X + (parent.Width - base.Width) / 2, parent.Location.Y + (parent.Height - base.Height) / 2);
			}
			this.newQuestsCompletedPanel.setCompletedQuests(quests);
			this.newQuestsCompletedPanel.init(this, forQuestList, questTag, questID);
		}
	}
}
