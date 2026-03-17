using System;
using System.Windows.Forms;

namespace Upgrade.Services
{
	// Token: 0x020000AA RID: 170
	internal class WorkCycle
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x0005CFF4 File Offset: 0x0005B1F4
		internal static bool ShouldModuleSleep()
		{
			double totalMinutes = (DateTime.Now - WorkCycle.CurrentCycleStartTime).TotalMinutes;
			if (totalMinutes > (double)(WorkCycle.WorkPeriod + WorkCycle.SleepPeriod))
			{
				WorkCycle.CurrentCycleStartTime = DateTime.Now;
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(string.Format("{0} {1}.", LNG.Print("Started new Bot life cycle at"), WorkCycle.CurrentCycleStartTime), ControlForm.Tab.Main, false);
				}
				if (WorkCycle.RandomPeriods)
				{
					WorkCycle.SetRandomPeriods();
					ControlForm controlForm2 = DX.ControlForm;
					if (controlForm2 != null && controlForm2.IsHandleCreated)
					{
						ControlForm controlForm3 = DX.ControlForm;
						if (controlForm3 != null)
						{
							controlForm3.BeginInvoke(new MethodInvoker(delegate()
							{
								ControlForm controlForm8 = DX.ControlForm;
								if (controlForm8 == null)
								{
									return;
								}
								controlForm8.DisplayWorkCycleStatus(LNG.Print("Working"), WorkCycle.WorkPeriod, WorkCycle.SleepPeriod);
							}));
						}
					}
				}
				else
				{
					ControlForm controlForm4 = DX.ControlForm;
					if (controlForm4 != null && controlForm4.IsHandleCreated)
					{
						ControlForm controlForm5 = DX.ControlForm;
						if (controlForm5 != null)
						{
							controlForm5.BeginInvoke(new MethodInvoker(delegate()
							{
								ControlForm controlForm8 = DX.ControlForm;
								if (controlForm8 == null)
								{
									return;
								}
								controlForm8.DisplayWorkCycleStatus(LNG.Print("Working"), -1, -1);
							}));
						}
					}
				}
				return false;
			}
			bool flag = totalMinutes > (double)WorkCycle.WorkPeriod;
			if (flag != WorkCycle._lastStatus)
			{
				string status = flag ? LNG.Print("Sleeping") : LNG.Print("Working");
				ControlForm controlForm6 = DX.ControlForm;
				if (controlForm6 != null && controlForm6.IsHandleCreated)
				{
					ControlForm controlForm7 = DX.ControlForm;
					if (controlForm7 != null)
					{
						controlForm7.BeginInvoke(new MethodInvoker(delegate()
						{
							ControlForm controlForm8 = DX.ControlForm;
							if (controlForm8 == null)
							{
								return;
							}
							controlForm8.DisplayWorkCycleStatus(status, -1, -1);
						}));
					}
				}
				WorkCycle._lastStatus = flag;
			}
			return flag;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0005D16C File Offset: 0x0005B36C
		private static void SetRandomPeriods()
		{
			WorkCycle.WorkPeriod = ASubscribed._random.Next(10, 180);
			int num = ASubscribed._random.Next(25, 33);
			WorkCycle.SleepPeriod = WorkCycle.WorkPeriod * num / 100;
		}

		// Token: 0x0400057A RID: 1402
		internal static DateTime CurrentCycleStartTime = DateTime.Now;

		// Token: 0x0400057B RID: 1403
		internal static int WorkPeriod = 45;

		// Token: 0x0400057C RID: 1404
		internal static int SleepPeriod = 15;

		// Token: 0x0400057D RID: 1405
		internal static bool RandomPeriods = true;

		// Token: 0x0400057E RID: 1406
		private static bool _lastStatus = false;
	}
}
