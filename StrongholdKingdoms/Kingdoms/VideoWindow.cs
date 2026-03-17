using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C5 RID: 1221
	public partial class VideoWindow : MyFormBase
	{
		// Token: 0x06002D3F RID: 11583 RVA: 0x0002145E File Offset: 0x0001F65E
		public VideoWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002D40 RID: 11584 RVA: 0x0023F788 File Offset: 0x0023D988
		public static void ShowVideo(string url, bool video)
		{
			if (VideoWindow.instance != null)
			{
				try
				{
					VideoWindow.instance.Close();
					VideoWindow.instance = null;
				}
				catch (Exception)
				{
				}
			}
			VideoWindow.vidLoaded = false;
			VideoWindow videoWindow = new VideoWindow();
			videoWindow.setMode(video);
			videoWindow.closeCallback = new MyFormBase.MFBClose(VideoWindow.closing);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			if (parentForm != null && parentForm.WindowState != FormWindowState.Minimized)
			{
				Point location = parentForm.Location;
				Size size = parentForm.Size;
				Size size2 = videoWindow.Size;
				Form form = videoWindow;
				Point location2 = new Point((size.Width - size2.Width) / 2 + location.X, (size.Height - size2.Height) / 2 + location.Y);
				form.Location = location2;
			}
			else
			{
				videoWindow.StartPosition = FormStartPosition.CenterScreen;
			}
			videoWindow.Show(parentForm);
			VideoWindow.instance = videoWindow;
			while (!VideoWindow.vidLoaded)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			Thread.Sleep(500);
			videoWindow.videoPane.Visible = true;
			videoWindow.videoPane.openPage(url);
		}

		// Token: 0x06002D41 RID: 11585 RVA: 0x0002146C File Offset: 0x0001F66C
		public static void closing()
		{
			VideoWindow.instance = null;
		}

		// Token: 0x06002D42 RID: 11586 RVA: 0x0023F8A8 File Offset: 0x0023DAA8
		public static void ClosePopup()
		{
			try
			{
				if (VideoWindow.instance != null)
				{
					VideoWindow.instance.Close();
					VideoWindow.instance = null;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06002D43 RID: 11587 RVA: 0x0023F8E4 File Offset: 0x0023DAE4
		public void setMode(bool video)
		{
			string text;
			if (video)
			{
				text = (this.Text = (base.Title = SK.Text("HELP_Help_Video", "Tutorial Video")));
				return;
			}
			text = (this.Text = (base.Title = SK.Text("Admin_Message", "Admin's Message")));
			base.Size = new Size(854, base.Size.Height);
			this.videoPane.Size = new Size(850, this.videoPane.Size.Height);
		}

		// Token: 0x06002D44 RID: 11588 RVA: 0x00021474 File Offset: 0x0001F674
		private void VideoWindow_Load(object sender, EventArgs e)
		{
			VideoWindow.vidLoaded = true;
		}

		// Token: 0x04003839 RID: 14393
		private static VideoWindow instance;

		// Token: 0x0400383A RID: 14394
		public static bool vidLoaded;
	}
}
