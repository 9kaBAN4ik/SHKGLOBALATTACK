using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Kingdoms.Properties
{
	// Token: 0x02000527 RID: 1319
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	internal class Resources
	{
		// Token: 0x170002CE RID: 718
		// (get) Token: 0x060033E0 RID: 13280 RVA: 0x002AE324 File Offset: 0x002AC524
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Kingdoms.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x060033E1 RID: 13281 RVA: 0x0002527A File Offset: 0x0002347A
		// (set) Token: 0x060033E2 RID: 13282 RVA: 0x00025281 File Offset: 0x00023481
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060033E3 RID: 13283 RVA: 0x002AE360 File Offset: 0x002AC560
		internal static Bitmap connectinglogo
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("connectinglogo", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060033E4 RID: 13284 RVA: 0x002AE388 File Offset: 0x002AC588
		internal static Bitmap right_side_panel_large
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("right_side_panel_large", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060033E5 RID: 13285 RVA: 0x002AE3B0 File Offset: 0x002AC5B0
		internal static Bitmap right_side_panel_large_stone_tan
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("right_side_panel_large_stone_tan", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060033E6 RID: 13286 RVA: 0x002AE3D8 File Offset: 0x002AC5D8
		internal static Icon shk_icon
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("shk_icon", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060033E7 RID: 13287 RVA: 0x002AE400 File Offset: 0x002AC600
		internal static Icon shk_icon1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("shk_icon1", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060033E8 RID: 13288 RVA: 0x002AE428 File Offset: 0x002AC628
		internal static Bitmap splash_screen
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("splash_screen", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x00007CD8 File Offset: 0x00005ED8
		internal Resources()
		{
		}

		// Token: 0x040040FC RID: 16636
		private static ResourceManager resourceMan;

		// Token: 0x040040FD RID: 16637
		private static CultureInfo resourceCulture;
	}
}
