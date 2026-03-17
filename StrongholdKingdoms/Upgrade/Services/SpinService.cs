using System;
using System.Windows.Forms;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200008E RID: 142
	internal class SpinService : ABaseService
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x0000935B File Offset: 0x0000755B
		public SpinService(Log log) : base(log)
		{
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00009D5B File Offset: 0x00007F5B
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Spins, isError);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00056764 File Offset: 0x00054964
		private int[] CheckTickets()
		{
			return new int[]
			{
				GameEngine.Instance.World.getTickets(-1),
				GameEngine.Instance.World.getTickets(0),
				GameEngine.Instance.World.getTickets(1),
				GameEngine.Instance.World.getTickets(2),
				GameEngine.Instance.World.getTickets(3),
				GameEngine.Instance.World.getTickets(4)
			};
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000567EC File Offset: 0x000549EC
		public override void ConcreteAction()
		{
			this.LLog(LNG.Print("Checking Spin points"), false);
			int[] array = this.CheckTickets();
			this.LLog(string.Format("{0} quest spins, {1} Tier 1 spins, {2} Tier 2 spins, {3} Tier 3 spins, {4} Tier 4 spins, {5} Tier 5 spins are currently present", new object[]
			{
				array[0],
				array[1],
				array[2],
				array[3],
				array[4],
				array[5]
			}), false);
			int i = 0;
			while (i < array.Length && base.Enabled)
			{
				if (array[i] > 0)
				{
					this.LLog(string.Format("Spinning level {0}, {1} spins to do", i, array[i]), false);
					if (!InterfaceMgr.Instance.isWheelPopup())
					{
						ControlForm controlForm = DX.ControlForm;
						if (controlForm != null)
						{
							controlForm.Invoke(new MethodInvoker(delegate()
							{
								WheelPopup wheelPopup2 = InterfaceMgr.Instance.openWheelPopup(i - 1);
							}));
						}
					}
					WheelPopup wheelPopup = InterfaceMgr.Instance.getWheelPopup();
					int num = 0;
					while (num < array[i] && base.Enabled)
					{
						wheelPopup.wheelPanel.spinCard();
						this.LLog(LNG.Print("Spin performed"), false);
						if (base.RandomSleepOrExit(9000, 11000))
						{
							return;
						}
						num++;
					}
					ControlForm controlForm2 = DX.ControlForm;
					if (controlForm2 != null)
					{
						controlForm2.Invoke(new MethodInvoker(delegate()
						{
							InterfaceMgr.Instance.closeWheelPopup();
						}));
					}
					if (base.RandomSleepOrExit(1500, 2500))
					{
						return;
					}
				}
				int j = i;
				i = j + 1;
			}
			this.LLog(LNG.Print("Done spinning! Interface is released"), false);
		}
	}
}
