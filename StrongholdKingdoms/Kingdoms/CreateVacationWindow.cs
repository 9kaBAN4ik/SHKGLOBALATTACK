using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000158 RID: 344
	public partial class CreateVacationWindow : MyFormBase
	{
		// Token: 0x06000CE8 RID: 3304 RVA: 0x000F5E4C File Offset: 0x000F404C
		public CreateVacationWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblExplanation.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.Text = (base.Title = SK.Text("VM_Heading", "Start Vacation"));
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.btnStartVacation.Text = SK.Text("VM_Heading", "Start Vacation");
			this.lblNumAvailable.Text = GameEngine.Instance.World.NumVacationsAvailable.ToString();
			this.lblNumberVacationLabel.Text = SK.Text("VM_Num_Available", "Number of Vacations Available");
			this.lblDuration.Text = SK.Text("VM_Duration", "Duration");
			this.lblDurationValue.Text = this.trackNumDays.Value.ToString();
			this.lblDays.Text = SK.Text("Vacation_Days", "Days");
			this.lblExplanation.Text = SK.Text("Vacation_Explanation", "Going away on holiday? Set vacation mode to protect your villages from attack for up to 15 days.");
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x000F5F90 File Offset: 0x000F4190
		public static void showVacationMode()
		{
			if (GameEngine.Instance.World.NumVacationsAvailable > 0)
			{
				if (GameEngine.Instance.World.isAccount730Premium())
				{
					if (CreateVacationWindow.popup == null || !CreateVacationWindow.popup.Created)
					{
						CreateVacationWindow.popup = new CreateVacationWindow();
					}
					CreateVacationWindow.popup.init();
					Form parentForm = InterfaceMgr.Instance.ParentForm;
					CreateVacationWindow.popup.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - CreateVacationWindow.popup.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - CreateVacationWindow.popup.Height / 2);
					CreateVacationWindow.popup.Show(InterfaceMgr.Instance.ParentForm);
					return;
				}
				MyMessageBox.setForcedForm(InterfaceMgr.Instance.ParentForm);
				MyMessageBox.Show(SK.Text("VM_Not_Premium", "Vacation Mode requires you to have a 7 day or 30 day Premium Token active."), SK.Text("VM_Error", "Vacation Error"));
				return;
			}
			else
			{
				if (GameEngine.Instance.World.VacationNot30Days)
				{
					MyMessageBox.setForcedForm(InterfaceMgr.Instance.ParentForm);
					MyMessageBox.Show(SK.Text("VM_None_Available_30Days", "Vacation Mode is not available to you at this time. Your account must be at least 30 days old to be able to access Vacation Mode."), SK.Text("VM_Error", "Vacation Error"));
					return;
				}
				MyMessageBox.setForcedForm(InterfaceMgr.Instance.ParentForm);
				MyMessageBox.Show(SK.Text("VM_None_Available", "You have no Vacations Available at the current time."), SK.Text("VM_Error", "Vacation Error"));
				return;
			}
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void init()
		{
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x000F6110 File Offset: 0x000F4310
		private void btnStartVacation_Click(object sender, EventArgs e)
		{
			int value = this.trackNumDays.Value;
			MyMessageBox.setForcedForm(this);
			DialogResult dialogResult = ProfileLoginWindow.inSpecialWorld ? MyMessageBox.Show(string.Concat(new string[]
			{
				SK.Text("VM_start_vacation_warning1", "You are about to enter Vacation Mode."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning2", "During this time all your villages will be protected from new attacks across all worlds, but you will be unable to cancel this for 3 days and you will have no access to your account during this period."),
				Environment.NewLine,
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning10", "IMPORTANT: Special World Warning."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning11", "You are currently playing in a special world"),
				" : ",
				ProfileLoginWindow.specialWorldName,
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning12", "SPECIAL WORLDS CANNOT BE PROTECTED BY VACATION MODE. If you continue with applying Vacation Mode to your Stronghold Kingdoms account, your villages within the special world will not be protected by Vacation Mode leaving them vulnerable and you will not be able to login to the special world."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning3", "Are you sure you wish to start Vacation Mode? "),
				Environment.NewLine,
				"."
			}), SK.Text("VM_Heading", "Start Vacation"), MessageBoxButtons.YesNo) : MyMessageBox.Show(string.Concat(new string[]
			{
				SK.Text("VM_start_vacation_warning1", "You are about to enter Vacation Mode."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning2", "During this time all your villages will be protected from new attacks across all worlds, but you will be unable to cancel this for 3 days and you will have no access to your account during this period."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("VM_start_vacation_warning3", "Are you sure you wish to start Vacation Mode? "),
				Environment.NewLine,
				"."
			}), SK.Text("VM_Heading", "Start Vacation"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				RemoteServices.Instance.set_SetVacationMode_UserCallBack(new RemoteServices.SetVacationMode_UserCallBack(this.SetVacationMode_callback));
				RemoteServices.Instance.SetVacationMode(value);
			}
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x000F62FC File Offset: 0x000F44FC
		private void SetVacationMode_callback(SetVacationMode_ReturnType returnData)
		{
			if (returnData.Success)
			{
				base.Close();
				InterfaceMgr.Instance.openLogoutWindow(false);
				return;
			}
			MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("VM_Error", "Vacation Error"));
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00009024 File Offset: 0x00007224
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x000F634C File Offset: 0x000F454C
		private void trackNumDays_ValueChanged(object sender, EventArgs e)
		{
			this.lblDurationValue.Text = this.trackNumDays.Value.ToString();
		}

		// Token: 0x0400113C RID: 4412
		private static CreateVacationWindow popup;
	}
}
