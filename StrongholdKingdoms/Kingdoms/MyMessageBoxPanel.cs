using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200024B RID: 587
	public class MyMessageBoxPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001A08 RID: 6664 RVA: 0x0001A209 File Offset: 0x00018409
		public void setCustomYesText(string yesText)
		{
			this.customYesText = yesText;
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x0001A212 File Offset: 0x00018412
		public void setCustomNoText(string noText)
		{
			this.customNoText = noText;
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x0019C4F0 File Offset: 0x0019A6F0
		public MyMessageBoxPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x0001A21B File Offset: 0x0001841B
		public void UpdatePopupBodyText(string newText)
		{
			this.popupText.Text = newText;
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x0001A229 File Offset: 0x00018429
		public void init(MyMessageBoxPopUp myFormBaseParent, string message, int type, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate leftClickDelegate, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate noButtonClickDelegate, bool leaveGreaoutOpenOnClose)
		{
			this.leaveGreyoutOpen = leaveGreaoutOpenOnClose;
			this.init(myFormBaseParent, message, type, leftClickDelegate, noButtonClickDelegate);
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x0001A240 File Offset: 0x00018440
		public void init(MyMessageBoxPopUp myFormBaseParent, string message, int type, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate leftClickDelegate, bool leaveGreaoutOpenOnClose)
		{
			this.leaveGreyoutOpen = leaveGreaoutOpenOnClose;
			this.init(myFormBaseParent, message, type, leftClickDelegate, null);
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0019C55C File Offset: 0x0019A75C
		public void init(MyMessageBoxPopUp myFormBaseParent, string message, int type, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate leftClickDelegate, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate noClickDelegateSpecial)
		{
			base.clearControls();
			this.BackColor = global::ARGBColors.Transparent;
			this.typeOfPopUp = type;
			this.parent = myFormBaseParent;
			base.addControl(this.controlToAddTo);
			Graphics graphics = base.CreateGraphics();
			Size size = graphics.MeasureString(message, this.popupText.Font, 360).ToSize();
			graphics.Dispose();
			this.popupText.Size = new Size(360, size.Height);
			this.parent.Size = new Size(400, size.Height + 110);
			base.Size = new Size(400, size.Height + 70);
			this.popupText.Text = message;
			this.popupText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.popupText.Position = new Point(base.Size.Width / 2 - this.popupText.Width / 2, 15);
			this.controlToAddTo.addControl(this.popupText);
			this.buttonLeft.ImageNorm = GFXLibrary.button_132_normal;
			this.buttonLeft.ImageOver = GFXLibrary.button_132_over;
			this.buttonLeft.ImageClick = GFXLibrary.button_132_in;
			this.buttonLeft.Position = new Point(10, base.Size.Height - this.buttonLeft.Height - 5);
			this.buttonLeft.setClickDelegate(leftClickDelegate);
			this.buttonCenter.ImageNorm = GFXLibrary.button_132_normal;
			this.buttonCenter.ImageOver = GFXLibrary.button_132_over;
			this.buttonCenter.ImageClick = GFXLibrary.button_132_in;
			this.buttonCenter.Position = new Point(base.Size.Width / 2 - this.buttonCenter.Width / 2, base.Size.Height - this.buttonCenter.Height - 5);
			this.buttonRight.ImageNorm = GFXLibrary.button_132_normal;
			this.buttonRight.ImageOver = GFXLibrary.button_132_over;
			this.buttonRight.ImageClick = GFXLibrary.button_132_in;
			this.buttonRight.Position = new Point(base.Size.Width - this.buttonRight.Width - 10, base.Size.Height - this.buttonRight.Size.Height - 5);
			this.noSpecialDelegate = noClickDelegateSpecial;
			this.buttonRight.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClosePanel));
			switch (type)
			{
			case 0:
				if (this.customYesText.Length == 0)
				{
					this.buttonLeft.Text.Text = SK.Text("GENERIC_Yes", "Yes");
				}
				else
				{
					this.buttonLeft.Text.Text = this.customYesText;
				}
				if (this.customNoText.Length == 0)
				{
					this.buttonRight.Text.Text = SK.Text("GENERIC_No", "No");
				}
				else
				{
					this.buttonRight.Text.Text = this.customNoText;
				}
				this.controlToAddTo.addControl(this.buttonLeft);
				this.controlToAddTo.addControl(this.buttonRight);
				return;
			case 1:
			case 4:
			case 5:
				break;
			case 2:
				this.buttonCenter.Text.Text = SK.Text("GENERIC_OK", "OK");
				this.buttonCenter.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClosePanel));
				this.controlToAddTo.addControl(this.buttonCenter);
				return;
			case 3:
				this.buttonLeft.Text.Text = SK.Text("GENERIC_OK", "OK");
				this.buttonRight.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
				this.controlToAddTo.addControl(this.buttonLeft);
				this.controlToAddTo.addControl(this.buttonRight);
				return;
			case 6:
				this.buttonCenter.Text.Text = SK.Text("GENERIC_OK", "OK");
				this.buttonCenter.setClickDelegate(leftClickDelegate);
				this.controlToAddTo.addControl(this.buttonCenter);
				break;
			default:
				return;
			}
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void ButtonLeftClicked()
		{
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void ButtonCenterClicked()
		{
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x0001A256 File Offset: 0x00018456
		private void ClosePanel()
		{
			if (this.noSpecialDelegate != null)
			{
				this.noSpecialDelegate();
			}
			if (!this.leaveGreyoutOpen)
			{
				InterfaceMgr.Instance.closeGreyOut();
			}
			this.parent.closing = true;
			this.parent.Close();
		}

		// Token: 0x04002A7A RID: 10874
		public const int YESNO = 0;

		// Token: 0x04002A7B RID: 10875
		public const int YESNOCANCEL = 1;

		// Token: 0x04002A7C RID: 10876
		public const int OK = 2;

		// Token: 0x04002A7D RID: 10877
		public const int OKCANCEL = 3;

		// Token: 0x04002A7E RID: 10878
		public const int RETRYCANCEL = 4;

		// Token: 0x04002A7F RID: 10879
		public const int ABORTRETRYIGNORE = 5;

		// Token: 0x04002A80 RID: 10880
		public const int OKSPECIAL = 6;

		// Token: 0x04002A81 RID: 10881
		public const int NOBUTTONS = 7;

		// Token: 0x04002A82 RID: 10882
		public CustomSelfDrawPanel.CSDLabel popupText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002A83 RID: 10883
		private CustomSelfDrawPanel.CSDButton buttonLeft = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A84 RID: 10884
		private CustomSelfDrawPanel.CSDButton buttonCenter = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A85 RID: 10885
		private CustomSelfDrawPanel.CSDButton buttonRight = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A86 RID: 10886
		private CustomSelfDrawPanel.CSDArea controlToAddTo = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002A87 RID: 10887
		private MyMessageBoxPopUp parent;

		// Token: 0x04002A88 RID: 10888
		private string customYesText = "";

		// Token: 0x04002A89 RID: 10889
		private string customNoText = "";

		// Token: 0x04002A8A RID: 10890
		private CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate noSpecialDelegate;

		// Token: 0x04002A8B RID: 10891
		private int typeOfPopUp;

		// Token: 0x04002A8C RID: 10892
		private bool leaveGreyoutOpen;
	}
}
