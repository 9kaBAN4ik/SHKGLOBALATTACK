using System;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200003D RID: 61
	internal class FreeCardCollector : ABaseService, IDisposable
	{
		// Token: 0x0600023A RID: 570 RVA: 0x0000935B File Offset: 0x0000755B
		internal FreeCardCollector(Log log) : base(log)
		{
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00048E2C File Offset: 0x0004702C
		public override void ConcreteAction()
		{
			TimeSpan timeSpan = GameEngine.Instance.World.FreeCardInfo.timeUntilNextFreeCard();
			if (timeSpan.TotalSeconds > 0.0 || !GameEngine.Instance.World.FreeCardInfo.VeteranStages[0] || GameEngine.Instance.World.FreeCardInfo.CurrentVeteranLevel <= 0)
			{
				this.Log(LNG.Print("Time untill next card") + ": " + VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds), ControlForm.Tab.Main, false);
				return;
			}
			this.Log(LNG.Print("Mocking Free Card Panel"), ControlForm.Tab.Main, false);
			this.currentPanel = new FreeCardsPanel();
			this.currentPanel.init(true);
			if (base.SleepOrExit(5000))
			{
				return;
			}
			this.Log(LNG.Print("Revealing Free Card"), ControlForm.Tab.Main, false);
			this.currentPanel.RevealCardBG();
			base.SleepOrExit(5000);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00009364 File Offset: 0x00007564
		public void Dispose()
		{
			this.currentPanel.Dispose();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x040003C0 RID: 960
		private FreeCardsPanel currentPanel;
	}
}
