using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000279 RID: 633
	public partial class PostTutorialWindow : Form
	{
		// Token: 0x06001C72 RID: 7282 RVA: 0x0001BE89 File Offset: 0x0001A089
		public PostTutorialWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x001BD090 File Offset: 0x001BB290
		public static void CreatePostTutorialWindow(bool fromTutorial)
		{
			InterfaceMgr.Instance.openGreyOutWindow(false);
			PostTutorialWindow postTutorialWindow = new PostTutorialWindow();
			postTutorialWindow.init(fromTutorial);
			postTutorialWindow.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001C74 RID: 7284 RVA: 0x001BD0C8 File Offset: 0x001BB2C8
		public void init(bool tutorialOpened)
		{
			PostTutorialWindow.instance = this;
			this.customPanel.init(tutorialOpened, this);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x06001C75 RID: 7285 RVA: 0x001BD140 File Offset: 0x001BB340
		public static void close()
		{
			try
			{
				if (PostTutorialWindow.instance != null)
				{
					InterfaceMgr.Instance.closeGreyOut();
					PostTutorialWindow.instance.Close();
					PostTutorialWindow.instance = null;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001C76 RID: 7286 RVA: 0x0001BEAC File Offset: 0x0001A0AC
		private void PostTutorialWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!this.inClosedForm)
			{
				this.inClosedForm = true;
				InterfaceMgr.Instance.closeGreyOut();
				this.inClosedForm = false;
			}
		}

		// Token: 0x04002D4B RID: 11595
		private static PostTutorialWindow instance;

		// Token: 0x04002D4C RID: 11596
		private bool inClosedForm;
	}
}
