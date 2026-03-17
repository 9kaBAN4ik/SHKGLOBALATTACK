using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020001E8 RID: 488
	public sealed class GFXLibrary
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x0001432B File Offset: 0x0001252B
		public static GFXLibrary Instance
		{
			get
			{
				return GFXLibrary.instance;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060012F5 RID: 4853 RVA: 0x00014332 File Offset: 0x00012532
		public int WorldMapIconsTexID
		{
			get
			{
				if (this.worldMapIconsTexID == -1)
				{
					this.worldMapIconsTexID = this.gfx.loadSprites("assets\\world_map_icons.uv");
				}
				return this.worldMapIconsTexID;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060012F6 RID: 4854 RVA: 0x00139BDC File Offset: 0x00137DDC
		public int EffectLayerTexID
		{
			get
			{
				if (this.effectLayerTexID == -1)
				{
					if (Program.ShowSeasonalGraphics)
					{
						this.effectLayerTexID = this.gfx.loadSprites("assets\\effectLayer_snow.uv");
					}
					else
					{
						this.effectLayerTexID = this.gfx.loadSprites("assets\\effectLayer.uv");
					}
				}
				return this.effectLayerTexID;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060012F7 RID: 4855 RVA: 0x00139C30 File Offset: 0x00137E30
		public int MapElementsTexID
		{
			get
			{
				if (this.mapElementsTexID == -1)
				{
					if (Program.ShowSeasonalGraphics)
					{
						this.mapElementsTexID = this.gfx.loadSprites("assets\\map_elements_snow.uv");
					}
					else
					{
						this.mapElementsTexID = this.gfx.loadSprites("assets\\map_elements.uv");
					}
				}
				return this.mapElementsTexID;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060012F8 RID: 4856 RVA: 0x00139C84 File Offset: 0x00137E84
		public int WorldMapTilesTexID
		{
			get
			{
				if (this.worldMapTilesTexID == -1)
				{
					if (Program.ShowSeasonalGraphics)
					{
						this.worldMapTilesTexID = this.gfx.loadSprites("assets\\world_tiles_snow.uv");
					}
					else
					{
						this.worldMapTilesTexID = this.gfx.loadSprites("assets\\world_tiles.uv");
					}
				}
				return this.worldMapTilesTexID;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060012F9 RID: 4857 RVA: 0x00014359 File Offset: 0x00012559
		public int Goods1TexID
		{
			get
			{
				if (this.goods1TexID == -1)
				{
					this.goods1TexID = this.gfx.loadSprites("assets\\bld_goods.uv");
				}
				return this.goods1TexID;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060012FA RID: 4858 RVA: 0x00014380 File Offset: 0x00012580
		public int TownBuildindsTexID
		{
			get
			{
				if (this.townBuildindsTexID == -1)
				{
					this.townBuildindsTexID = this.gfx.loadSprites("assets\\town_buildings_01.uv");
				}
				return this.townBuildindsTexID;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060012FB RID: 4859 RVA: 0x000143A7 File Offset: 0x000125A7
		public int Goods2TexID
		{
			get
			{
				if (this.goods2TexID == -1)
				{
					this.goods2TexID = this.gfx.loadSprites("assets\\bld_goods_2.uv");
				}
				return this.goods2TexID;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060012FC RID: 4860 RVA: 0x000143CE File Offset: 0x000125CE
		public int Body_stonemasonTexID
		{
			get
			{
				if (this.body_stonemasonTexID == -1)
				{
					this.body_stonemasonTexID = this.gfx.loadSprites("assets\\MRG_stone_working.uv");
				}
				return this.body_stonemasonTexID;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060012FD RID: 4861 RVA: 0x000143F5 File Offset: 0x000125F5
		public int StonemasonAnimTexID
		{
			get
			{
				if (this.stonemasonAnimTexID == -1)
				{
					this.stonemasonAnimTexID = this.Body_stonemasonTexID * 10000 + 1;
				}
				return this.stonemasonAnimTexID;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060012FE RID: 4862 RVA: 0x0001441A File Offset: 0x0001261A
		public int Body_troubadourTexID
		{
			get
			{
				if (this.body_troubadourTexID == -1)
				{
					this.body_troubadourTexID = this.Body_stonemasonTexID * 10000 + 2;
				}
				return this.body_troubadourTexID;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060012FF RID: 4863 RVA: 0x0001443F File Offset: 0x0001263F
		public int Body_theaterworkerTexID
		{
			get
			{
				if (this.body_theaterworkerTexID == -1)
				{
					this.body_theaterworkerTexID = this.Body_stonemasonTexID * 10000 + 3;
				}
				return this.body_theaterworkerTexID;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06001300 RID: 4864 RVA: 0x00014464 File Offset: 0x00012664
		public int VillageOverlaysAnimTexID
		{
			get
			{
				if (this.villageOverlaysAnimTexID == -1)
				{
					this.villageOverlaysAnimTexID = this.Body_stonemasonTexID * 10000 + 4;
				}
				return this.villageOverlaysAnimTexID;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06001301 RID: 4865 RVA: 0x00014489 File Offset: 0x00012689
		public int WoodcutterAnimTexID
		{
			get
			{
				if (this.woodcutterAnimTexID == -1)
				{
					this.woodcutterAnimTexID = this.gfx.loadSprites("assets\\woodcutter_anims.uv");
				}
				return this.woodcutterAnimTexID;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06001302 RID: 4866 RVA: 0x000144B0 File Offset: 0x000126B0
		public int FarmerAnimTexID
		{
			get
			{
				if (this.farmerAnimTexID == -1)
				{
					this.farmerAnimTexID = this.gfx.loadSprites("assets\\body_farmer.uv");
				}
				return this.farmerAnimTexID;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06001303 RID: 4867 RVA: 0x000144D7 File Offset: 0x000126D7
		public int Farmer2AnimTexID
		{
			get
			{
				if (this.farmer2AnimTexID == -1)
				{
					this.farmer2AnimTexID = this.gfx.loadSprites("assets\\body_farmer_2.uv");
				}
				return this.farmer2AnimTexID;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06001304 RID: 4868 RVA: 0x000144FE File Offset: 0x000126FE
		public int Farmer3AnimTexID
		{
			get
			{
				if (this.farmer3AnimTexID == -1)
				{
					this.farmer3AnimTexID = this.gfx.loadSprites("assets\\body_farmer_3.uv");
				}
				return this.farmer3AnimTexID;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06001305 RID: 4869 RVA: 0x00014525 File Offset: 0x00012725
		public int BakerAnimTexID
		{
			get
			{
				if (this.bakerAnimTexID == -1)
				{
					this.bakerAnimTexID = this.gfx.loadSprites("assets\\body_baker.uv");
				}
				return this.bakerAnimTexID;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06001306 RID: 4870 RVA: 0x0001454C File Offset: 0x0001274C
		public int MetalWorkerAnimTexID
		{
			get
			{
				if (this.metalWorkerAnimTexID == -1)
				{
					this.metalWorkerAnimTexID = this.gfx.loadSprites("assets\\body_metalworker.uv");
				}
				return this.metalWorkerAnimTexID;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06001307 RID: 4871 RVA: 0x00014573 File Offset: 0x00012773
		public int FletcherAnimTexID
		{
			get
			{
				if (this.fletcherAnimTexID == -1)
				{
					this.fletcherAnimTexID = this.gfx.loadSprites("assets\\body_fletcher.uv");
				}
				return this.fletcherAnimTexID;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06001308 RID: 4872 RVA: 0x0001459A File Offset: 0x0001279A
		public int PitchworkerAnimTexID
		{
			get
			{
				if (this.pitchworkerAnimTexID == -1)
				{
					this.pitchworkerAnimTexID = this.gfx.loadSprites("assets\\body_pitchworker.uv");
				}
				return this.pitchworkerAnimTexID;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06001309 RID: 4873 RVA: 0x000145C1 File Offset: 0x000127C1
		public int PoleturnerAnimTexID
		{
			get
			{
				if (this.poleturnerAnimTexID == -1)
				{
					this.poleturnerAnimTexID = this.gfx.loadSprites("assets\\body_poleturner.uv");
				}
				return this.poleturnerAnimTexID;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600130A RID: 4874 RVA: 0x000145E8 File Offset: 0x000127E8
		public int CowAnimTexID
		{
			get
			{
				if (this.cowAnimTexID == -1)
				{
					this.cowAnimTexID = this.gfx.loadSprites("assets\\body_cow.uv");
				}
				return this.cowAnimTexID;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600130B RID: 4875 RVA: 0x0001460F File Offset: 0x0001280F
		public int BlacksmithAnimTexID
		{
			get
			{
				if (this.blacksmithAnimTexID == -1)
				{
					this.blacksmithAnimTexID = this.gfx.loadSprites("assets\\body_blacksmith.uv");
				}
				return this.blacksmithAnimTexID;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600130C RID: 4876 RVA: 0x00014636 File Offset: 0x00012836
		public int ArmourerAnimTexID
		{
			get
			{
				if (this.armourerAnimTexID == -1)
				{
					this.armourerAnimTexID = this.gfx.loadSprites("assets\\body_armourer.uv");
				}
				return this.armourerAnimTexID;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600130D RID: 4877 RVA: 0x0001465D File Offset: 0x0001285D
		public int SheepAnimTexID
		{
			get
			{
				if (this.sheepAnimTexID == -1)
				{
					this.sheepAnimTexID = this.gfx.loadSprites("assets\\MRG_animals1.uv");
				}
				return this.sheepAnimTexID;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600130E RID: 4878 RVA: 0x00014684 File Offset: 0x00012884
		public int ChickenBrownAnimTexID
		{
			get
			{
				if (this.chickenBrownAnimTexID == -1)
				{
					this.chickenBrownAnimTexID = this.SheepAnimTexID * 10000 + 1;
				}
				return this.chickenBrownAnimTexID;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600130F RID: 4879 RVA: 0x000146A9 File Offset: 0x000128A9
		public int ChickenWhiteAnimTexID
		{
			get
			{
				if (this.chickenWhiteAnimTexID == -1)
				{
					this.chickenWhiteAnimTexID = this.SheepAnimTexID * 10000 + 2;
				}
				return this.chickenWhiteAnimTexID;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06001310 RID: 4880 RVA: 0x000146CE File Offset: 0x000128CE
		public int PigAnimTexID
		{
			get
			{
				if (this.pigAnimTexID == -1)
				{
					this.pigAnimTexID = this.SheepAnimTexID * 10000 + 3;
				}
				return this.pigAnimTexID;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06001311 RID: 4881 RVA: 0x000146F3 File Offset: 0x000128F3
		public int TraderAnimTexID
		{
			get
			{
				if (this.traderAnimTexID == -1)
				{
					this.traderAnimTexID = this.SheepAnimTexID * 10000 + 4;
				}
				return this.traderAnimTexID;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x00014718 File Offset: 0x00012918
		public int Bld_17x17_1TexID
		{
			get
			{
				if (this.bld_17x17_1TexID == -1)
				{
					this.bld_17x17_1TexID = this.gfx.loadSprites("assets\\MRG_large_buildings.uv");
				}
				return this.bld_17x17_1TexID;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06001313 RID: 4883 RVA: 0x0001473F File Offset: 0x0001293F
		public int Bld_7x7_1TexID
		{
			get
			{
				if (this.bld_7x7_1TexID == -1)
				{
					this.bld_7x7_1TexID = this.Bld_17x17_1TexID * 10000 + 1;
				}
				return this.bld_7x7_1TexID;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x00014764 File Offset: 0x00012964
		public int Bld_9x9_1TexID
		{
			get
			{
				if (this.bld_9x9_1TexID == -1)
				{
					this.bld_9x9_1TexID = this.Bld_17x17_1TexID * 10000 + 2;
				}
				return this.bld_9x9_1TexID;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06001315 RID: 4885 RVA: 0x00014789 File Offset: 0x00012989
		public int Bld_11x11_1TexID
		{
			get
			{
				if (this.bld_11x11_1TexID == -1)
				{
					this.bld_11x11_1TexID = this.Bld_17x17_1TexID * 10000 + 3;
				}
				return this.bld_11x11_1TexID;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x000147AE File Offset: 0x000129AE
		public int Bld_13x13_1TexID
		{
			get
			{
				if (this.bld_13x13_1TexID == -1)
				{
					this.bld_13x13_1TexID = this.Bld_17x17_1TexID * 10000 + 4;
				}
				return this.bld_13x13_1TexID;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06001317 RID: 4887 RVA: 0x000147D3 File Offset: 0x000129D3
		public int Bld_13x13_2TexID
		{
			get
			{
				if (this.bld_13x13_2TexID == -1)
				{
					this.bld_13x13_2TexID = this.Bld_17x17_1TexID * 10000 + 5;
				}
				return this.bld_13x13_2TexID;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06001318 RID: 4888 RVA: 0x000147F8 File Offset: 0x000129F8
		public int Bld_4x4_1TexID
		{
			get
			{
				if (this.bld_4x4_1TexID == -1)
				{
					this.bld_4x4_1TexID = this.gfx.loadSprites("assets\\MRG_small_buildings.uv");
				}
				return this.bld_4x4_1TexID;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06001319 RID: 4889 RVA: 0x0001481F File Offset: 0x00012A1F
		public int Bld_5x5_1TexID
		{
			get
			{
				if (this.bld_5x5_1TexID == -1)
				{
					this.bld_5x5_1TexID = this.Bld_4x4_1TexID * 10000 + 1;
				}
				return this.bld_5x5_1TexID;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600131A RID: 4890 RVA: 0x00014844 File Offset: 0x00012A44
		public int Body_carpenterTexID
		{
			get
			{
				if (this.body_carpenterTexID == -1)
				{
					this.body_carpenterTexID = this.gfx.loadSprites("assets\\MRG_carp_dock.uv");
				}
				return this.body_carpenterTexID;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x0001486B File Offset: 0x00012A6B
		public int DockworkerAnimTexID
		{
			get
			{
				if (this.dockworkerAnimTexID == -1)
				{
					this.dockworkerAnimTexID = this.Body_carpenterTexID * 10000 + 1;
				}
				return this.dockworkerAnimTexID;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x00014890 File Offset: 0x00012A90
		public int IronMinerAnimTexID
		{
			get
			{
				if (this.ironMinerAnimTexID == -1)
				{
					this.ironMinerAnimTexID = this.gfx.loadSprites("assets\\MRG_iron.uv");
				}
				return this.ironMinerAnimTexID;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x000148B7 File Offset: 0x00012AB7
		public int Body_iron_mine_workTexID
		{
			get
			{
				if (this.body_iron_mine_workTexID == -1)
				{
					this.body_iron_mine_workTexID = this.IronMinerAnimTexID * 10000 + 1;
				}
				return this.body_iron_mine_workTexID;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x000148DC File Offset: 0x00012ADC
		public int Body_hunterTexID
		{
			get
			{
				if (this.body_hunterTexID == -1)
				{
					this.body_hunterTexID = this.gfx.loadSprites("assets\\MRG_hunt_brew.uv");
				}
				return this.body_hunterTexID;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600131F RID: 4895 RVA: 0x00014903 File Offset: 0x00012B03
		public int Body_brewerTexID
		{
			get
			{
				if (this.body_brewerTexID == -1)
				{
					this.body_brewerTexID = this.Body_hunterTexID * 10000 + 1;
				}
				return this.body_brewerTexID;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x00014928 File Offset: 0x00012B28
		public int Body_tailorTexID
		{
			get
			{
				if (this.body_tailorTexID == -1)
				{
					this.body_tailorTexID = this.gfx.loadSprites("assets\\MRG_tailor_siege.uv");
				}
				return this.body_tailorTexID;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06001321 RID: 4897 RVA: 0x0001494F File Offset: 0x00012B4F
		public int Body_siegeworkerTexID
		{
			get
			{
				if (this.body_siegeworkerTexID == -1)
				{
					this.body_siegeworkerTexID = this.Body_tailorTexID * 10000 + 1;
				}
				return this.body_siegeworkerTexID;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x00014974 File Offset: 0x00012B74
		public int Body_pitchworkerTexID
		{
			get
			{
				if (this.body_pitchworkerTexID == -1)
				{
					this.body_pitchworkerTexID = this.gfx.loadSprites("assets\\MRG_pitch_horse.uv");
				}
				return this.body_pitchworkerTexID;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x0001499B File Offset: 0x00012B9B
		public int TraderHorseAnimTexID
		{
			get
			{
				if (this.traderHorseAnimTexID == -1)
				{
					this.traderHorseAnimTexID = this.Body_pitchworkerTexID * 10000 + 1;
				}
				return this.traderHorseAnimTexID;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x000149C0 File Offset: 0x00012BC0
		public int Bld_8x8_1TexID
		{
			get
			{
				if (this.bld_8x8_1TexID == -1)
				{
					this.bld_8x8_1TexID = this.gfx.loadSprites("assets\\bld_8x8_1.uv");
				}
				return this.bld_8x8_1TexID;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06001325 RID: 4901 RVA: 0x000149E7 File Offset: 0x00012BE7
		public int Woodcutter_animsTexID
		{
			get
			{
				if (this.woodcutter_animsTexID == -1)
				{
					this.woodcutter_animsTexID = this.gfx.loadSprites("assets\\woodcutter_anims.uv");
				}
				return this.woodcutter_animsTexID;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x00014A0E File Offset: 0x00012C0E
		public int Bld_6x6_1TexID
		{
			get
			{
				if (this.bld_6x6_1TexID == -1)
				{
					this.bld_6x6_1TexID = this.gfx.loadSprites("assets\\bld_6x6_1.uv");
				}
				return this.bld_6x6_1TexID;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06001327 RID: 4903 RVA: 0x00014A35 File Offset: 0x00012C35
		public int Body_farmer_3TexID
		{
			get
			{
				if (this.body_farmer_3TexID == -1)
				{
					this.body_farmer_3TexID = this.gfx.loadSprites("assets\\body_farmer_3.uv");
				}
				return this.body_farmer_3TexID;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x00014A5C File Offset: 0x00012C5C
		public int Body_metalworkerTexID
		{
			get
			{
				if (this.body_metalworkerTexID == -1)
				{
					this.body_metalworkerTexID = this.gfx.loadSprites("assets\\body_metalworker.uv");
				}
				return this.body_metalworkerTexID;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x00014A83 File Offset: 0x00012C83
		public int Body_bakerTexID
		{
			get
			{
				if (this.body_bakerTexID == -1)
				{
					this.body_bakerTexID = this.gfx.loadSprites("assets\\body_baker.uv");
				}
				return this.body_bakerTexID;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x00014AAA File Offset: 0x00012CAA
		public int Body_poleturnerTexID
		{
			get
			{
				if (this.body_poleturnerTexID == -1)
				{
					this.body_poleturnerTexID = this.gfx.loadSprites("assets\\body_poleturner.uv");
				}
				return this.body_poleturnerTexID;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600132B RID: 4907 RVA: 0x00014AD1 File Offset: 0x00012CD1
		public int Body_fletcherTexID
		{
			get
			{
				if (this.body_fletcherTexID == -1)
				{
					this.body_fletcherTexID = this.gfx.loadSprites("assets\\body_fletcher.uv");
				}
				return this.body_fletcherTexID;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600132C RID: 4908 RVA: 0x00014AF8 File Offset: 0x00012CF8
		public int Body_blacksmithTexID
		{
			get
			{
				if (this.body_blacksmithTexID == -1)
				{
					this.body_blacksmithTexID = this.gfx.loadSprites("assets\\body_blacksmith.uv");
				}
				return this.body_blacksmithTexID;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600132D RID: 4909 RVA: 0x00014B1F File Offset: 0x00012D1F
		public int Body_armourerTexID
		{
			get
			{
				if (this.body_armourerTexID == -1)
				{
					this.body_armourerTexID = this.gfx.loadSprites("assets\\body_armourer.uv");
				}
				return this.body_armourerTexID;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600132E RID: 4910 RVA: 0x00014B46 File Offset: 0x00012D46
		public int Bld_Various_01TexID
		{
			get
			{
				if (this.bld_Various_01TexID == -1)
				{
					this.bld_Various_01TexID = this.gfx.loadSprites("assets\\bld_Various_01.uv");
				}
				return this.bld_Various_01TexID;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x00014B6D File Offset: 0x00012D6D
		public int Body_jesterTexID
		{
			get
			{
				if (this.body_jesterTexID == -1)
				{
					this.body_jesterTexID = this.gfx.loadSprites("assets\\body_jester.uv");
				}
				return this.body_jesterTexID;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06001330 RID: 4912 RVA: 0x00014B94 File Offset: 0x00012D94
		public int Anim_dancing_bearTexID
		{
			get
			{
				if (this.anim_dancing_bearTexID == -1)
				{
					this.anim_dancing_bearTexID = this.gfx.loadSprites("assets\\MRG_fun_tort.uv");
				}
				return this.anim_dancing_bearTexID;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x00014BBB File Offset: 0x00012DBB
		public int Anim_maypoleTexID
		{
			get
			{
				if (this.anim_maypoleTexID == -1)
				{
					this.anim_maypoleTexID = this.Anim_dancing_bearTexID * 10000 + 1;
				}
				return this.anim_maypoleTexID;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06001332 RID: 4914 RVA: 0x00014BE0 File Offset: 0x00012DE0
		public int Anim_rackTexID
		{
			get
			{
				if (this.anim_rackTexID == -1)
				{
					this.anim_rackTexID = this.Anim_dancing_bearTexID * 10000 + 2;
				}
				return this.anim_rackTexID;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x00014C05 File Offset: 0x00012E05
		public int Anim_stakeTexID
		{
			get
			{
				if (this.anim_stakeTexID == -1)
				{
					this.anim_stakeTexID = this.Anim_dancing_bearTexID * 10000 + 3;
				}
				return this.anim_stakeTexID;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06001334 RID: 4916 RVA: 0x00014C2A File Offset: 0x00012E2A
		public int Anim_gibbetTexID
		{
			get
			{
				if (this.anim_gibbetTexID == -1)
				{
					this.anim_gibbetTexID = this.Anim_dancing_bearTexID * 10000 + 4;
				}
				return this.anim_gibbetTexID;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x00014C4F File Offset: 0x00012E4F
		public int Anim_stocksTexID
		{
			get
			{
				if (this.anim_stocksTexID == -1)
				{
					this.anim_stocksTexID = this.Anim_dancing_bearTexID * 10000 + 5;
				}
				return this.anim_stocksTexID;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06001336 RID: 4918 RVA: 0x00014C74 File Offset: 0x00012E74
		public int ArcherAnimTexID
		{
			get
			{
				if (this.archerAnimTexID == -1)
				{
					this.archerAnimTexID = this.gfx.loadSprites("assets\\MRG_archer1.uv");
				}
				return this.archerAnimTexID;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x00014C9B File Offset: 0x00012E9B
		public int ArcherRedAnimTexID
		{
			get
			{
				if (this.archerRedAnimTexID == -1)
				{
					this.archerRedAnimTexID = this.ArcherAnimTexID * 10000 + 1;
				}
				return this.archerRedAnimTexID;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x00014CC0 File Offset: 0x00012EC0
		public int ArcherGreenAnimTexID
		{
			get
			{
				if (this.archerGreenAnimTexID == -1)
				{
					this.archerGreenAnimTexID = this.ArcherAnimTexID * 10000 + 2;
				}
				return this.archerGreenAnimTexID;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06001339 RID: 4921 RVA: 0x00014CE5 File Offset: 0x00012EE5
		public int PeasantAnimTexID
		{
			get
			{
				if (this.peasantAnimTexID == -1)
				{
					this.peasantAnimTexID = this.gfx.loadSprites("assets\\MRG_peasant1.uv");
				}
				return this.peasantAnimTexID;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x00014D0C File Offset: 0x00012F0C
		public int PeasantRedAnimTexID
		{
			get
			{
				if (this.peasantRedAnimTexID == -1)
				{
					this.peasantRedAnimTexID = this.PeasantAnimTexID * 10000 + 1;
				}
				return this.peasantRedAnimTexID;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600133B RID: 4923 RVA: 0x00014D31 File Offset: 0x00012F31
		public int PeasantGreenAnimTexID
		{
			get
			{
				if (this.peasantGreenAnimTexID == -1)
				{
					this.peasantGreenAnimTexID = this.PeasantAnimTexID * 10000 + 2;
				}
				return this.peasantGreenAnimTexID;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600133C RID: 4924 RVA: 0x00014D56 File Offset: 0x00012F56
		public int PikemanAnimTexID
		{
			get
			{
				if (this.pikemanAnimTexID == -1)
				{
					this.pikemanAnimTexID = this.gfx.loadSprites("assets\\MRG_pikeman1.uv");
				}
				return this.pikemanAnimTexID;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x00014D7D File Offset: 0x00012F7D
		public int PikemanRedAnimTexID
		{
			get
			{
				if (this.pikemanRedAnimTexID == -1)
				{
					this.pikemanRedAnimTexID = this.PikemanAnimTexID * 10000 + 1;
				}
				return this.pikemanRedAnimTexID;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600133E RID: 4926 RVA: 0x00014DA2 File Offset: 0x00012FA2
		public int PikemanGreenAnimTexID
		{
			get
			{
				if (this.pikemanGreenAnimTexID == -1)
				{
					this.pikemanGreenAnimTexID = this.PikemanAnimTexID * 10000 + 2;
				}
				return this.pikemanGreenAnimTexID;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x00014DC7 File Offset: 0x00012FC7
		public int SwordsmanAnimTexID
		{
			get
			{
				if (this.swordsmanAnimTexID == -1)
				{
					this.swordsmanAnimTexID = this.gfx.loadSprites("assets\\MRG_swordsman1.uv");
				}
				return this.swordsmanAnimTexID;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06001340 RID: 4928 RVA: 0x00014DEE File Offset: 0x00012FEE
		public int SwordsmanRedAnimTexID
		{
			get
			{
				if (this.swordsmanRedAnimTexID == -1)
				{
					this.swordsmanRedAnimTexID = this.SwordsmanAnimTexID * 10000 + 1;
				}
				return this.swordsmanRedAnimTexID;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06001341 RID: 4929 RVA: 0x00014E13 File Offset: 0x00013013
		public int SwordsmanGreenAnimTexID
		{
			get
			{
				if (this.swordsmanGreenAnimTexID == -1)
				{
					this.swordsmanGreenAnimTexID = this.SwordsmanAnimTexID * 10000 + 2;
				}
				return this.swordsmanGreenAnimTexID;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06001342 RID: 4930 RVA: 0x00014E38 File Offset: 0x00013038
		public int KnightAnimTexID
		{
			get
			{
				if (this.knightAnimTexID == -1)
				{
					this.knightAnimTexID = this.gfx.loadSprites("assets\\MRG_knight.uv");
				}
				return this.knightAnimTexID;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06001343 RID: 4931 RVA: 0x00014E5F File Offset: 0x0001305F
		public int KnightTopAnimTexID
		{
			get
			{
				if (this.knightTopAnimTexID == -1)
				{
					this.knightTopAnimTexID = this.KnightAnimTexID * 10000 + 1;
				}
				return this.knightTopAnimTexID;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06001344 RID: 4932 RVA: 0x00014E84 File Offset: 0x00013084
		public int ArcherCarryAnimTexID
		{
			get
			{
				if (this.archerCarryAnimTexID == -1)
				{
					this.archerCarryAnimTexID = this.gfx.loadSprites("assets\\MRG_troops_carrying.uv");
				}
				return this.archerCarryAnimTexID;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x00014EAB File Offset: 0x000130AB
		public int PeasantCarryAnimTexID
		{
			get
			{
				if (this.peasantCarryAnimTexID == -1)
				{
					this.peasantCarryAnimTexID = this.ArcherCarryAnimTexID * 10000 + 1;
				}
				return this.peasantCarryAnimTexID;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06001346 RID: 4934 RVA: 0x00014ED0 File Offset: 0x000130D0
		public int PikemanCarryAnimTexID
		{
			get
			{
				if (this.pikemanCarryAnimTexID == -1)
				{
					this.pikemanCarryAnimTexID = this.ArcherCarryAnimTexID * 10000 + 2;
				}
				return this.pikemanCarryAnimTexID;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x00014EF5 File Offset: 0x000130F5
		public int SwordsmanCarryAnimTexID
		{
			get
			{
				if (this.swordsmanCarryAnimTexID == -1)
				{
					this.swordsmanCarryAnimTexID = this.ArcherCarryAnimTexID * 10000 + 3;
				}
				return this.swordsmanCarryAnimTexID;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06001348 RID: 4936 RVA: 0x00014F1A File Offset: 0x0001311A
		public int CaptainAnimTexID
		{
			get
			{
				if (this.captainAnimTexID == -1)
				{
					this.captainAnimTexID = this.gfx.loadSprites("assets\\MRG_lord.uv");
				}
				return this.captainAnimTexID;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06001349 RID: 4937 RVA: 0x00014F41 File Offset: 0x00013141
		public int CaptainAnimRedTexID
		{
			get
			{
				if (this.captainAnimRedTexID == -1)
				{
					this.captainAnimRedTexID = this.CaptainAnimTexID * 10000 + 1;
				}
				return this.captainAnimRedTexID;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600134A RID: 4938 RVA: 0x00014F66 File Offset: 0x00013166
		public int CatapultAnimTexID
		{
			get
			{
				if (this.catapultAnimTexID == -1)
				{
					this.catapultAnimTexID = this.gfx.loadSprites("assets\\MRG_castle_misc.uv");
				}
				return this.catapultAnimTexID;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600134B RID: 4939 RVA: 0x00014F8D File Offset: 0x0001318D
		public int ManOnFireTexID
		{
			get
			{
				if (this.manOnFireTexID == -1)
				{
					this.manOnFireTexID = this.CatapultAnimTexID * 10000 + 1;
				}
				return this.manOnFireTexID;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600134C RID: 4940 RVA: 0x00014FB2 File Offset: 0x000131B2
		public int Peasant2AnimTexID
		{
			get
			{
				if (this.peasant2AnimTexID == -1)
				{
					this.peasant2AnimTexID = this.CatapultAnimTexID * 10000 + 2;
				}
				return this.peasant2AnimTexID;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600134D RID: 4941 RVA: 0x00014FD7 File Offset: 0x000131D7
		public int Peasant2RedAnimTexID
		{
			get
			{
				if (this.peasant2RedAnimTexID == -1)
				{
					this.peasant2RedAnimTexID = this.CatapultAnimTexID * 10000 + 3;
				}
				return this.peasant2RedAnimTexID;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x00014FFC File Offset: 0x000131FC
		public int Peasant2GreenAnimTexID
		{
			get
			{
				if (this.peasant2GreenAnimTexID == -1)
				{
					this.peasant2GreenAnimTexID = this.CatapultAnimTexID * 10000 + 4;
				}
				return this.peasant2GreenAnimTexID;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x00015021 File Offset: 0x00013221
		public int WolfAnimTexID
		{
			get
			{
				if (this.wolfAnimTexID == -1)
				{
					this.wolfAnimTexID = this.gfx.loadSprites("assets\\body_wolf.uv");
				}
				return this.wolfAnimTexID;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06001350 RID: 4944 RVA: 0x00015048 File Offset: 0x00013248
		public int Archer2AnimTexID
		{
			get
			{
				if (this.archer2AnimTexID == -1)
				{
					this.archer2AnimTexID = this.gfx.loadSprites("assets\\body_archer2.uv");
				}
				return this.archer2AnimTexID;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06001351 RID: 4945 RVA: 0x0001506F File Offset: 0x0001326F
		public int Archer2RedAnimTexID
		{
			get
			{
				if (this.archer2RedAnimTexID == -1)
				{
					this.archer2RedAnimTexID = this.gfx.loadSprites("assets\\body_archer2_red.uv");
				}
				return this.archer2RedAnimTexID;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06001352 RID: 4946 RVA: 0x00015096 File Offset: 0x00013296
		public int Archer2GreenAnimTexID
		{
			get
			{
				if (this.archer2GreenAnimTexID == -1)
				{
					this.archer2GreenAnimTexID = this.gfx.loadSprites("assets\\body_archer2_green.uv");
				}
				return this.archer2GreenAnimTexID;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06001353 RID: 4947 RVA: 0x000150BD File Offset: 0x000132BD
		public int MissileTexID
		{
			get
			{
				if (this.missileTexID == -1)
				{
					this.missileTexID = this.gfx.loadSprites("assets\\body_missile.uv");
				}
				return this.missileTexID;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06001354 RID: 4948 RVA: 0x000150E4 File Offset: 0x000132E4
		public int Missile2TexID
		{
			get
			{
				if (this.missile2TexID == -1)
				{
					this.missile2TexID = this.gfx.loadSprites("assets\\body_missile_2.uv");
				}
				return this.missile2TexID;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x0001510B File Offset: 0x0001330B
		public int AnimKillingPitsTexID
		{
			get
			{
				if (this.animKillingPitsTexID == -1)
				{
					this.animKillingPitsTexID = this.gfx.loadSprites("assets\\anim_killing_pits.uv");
				}
				return this.animKillingPitsTexID;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06001356 RID: 4950 RVA: 0x00015132 File Offset: 0x00013332
		public int FireTexID
		{
			get
			{
				if (this.fireTexID == -1)
				{
					this.fireTexID = this.gfx.loadSprites("assets\\body_fire2.uv");
				}
				return this.fireTexID;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06001357 RID: 4951 RVA: 0x00015159 File Offset: 0x00013359
		public int Smoke1TexID
		{
			get
			{
				if (this.smoke1TexID == -1)
				{
					this.smoke1TexID = this.gfx.loadSprites("assets\\anim_smoke_light.uv");
				}
				return this.smoke1TexID;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06001358 RID: 4952 RVA: 0x00015180 File Offset: 0x00013380
		public int OilPotAnimTexID
		{
			get
			{
				if (this.oilPotAnimTexID == -1)
				{
					this.oilPotAnimTexID = this.gfx.loadSprites("assets\\body_oil_pot.uv");
				}
				return this.oilPotAnimTexID;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06001359 RID: 4953 RVA: 0x000151A7 File Offset: 0x000133A7
		public int HpsBarsTexID
		{
			get
			{
				if (this.hpsBarsTexID == -1)
				{
					this.hpsBarsTexID = this.gfx.loadSprites("assets\\misc_bars.uv");
				}
				return this.hpsBarsTexID;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x000151CE File Offset: 0x000133CE
		public int CastleBackgroundTexID
		{
			get
			{
				if (this.castleBackgroundTexID == -1)
				{
					this.castleBackgroundTexID = this.gfx.loadSprites("assets\\MRG_castle.uv");
				}
				return this.castleBackgroundTexID;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600135B RID: 4955 RVA: 0x000151F5 File Offset: 0x000133F5
		public int CastleSpritesTexID
		{
			get
			{
				if (this.castleSpritesTexID == -1)
				{
					this.castleSpritesTexID = this.CastleBackgroundTexID * 10000 + 1;
				}
				return this.castleSpritesTexID;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600135C RID: 4956 RVA: 0x0001521A File Offset: 0x0001341A
		public int BallistaTexID
		{
			get
			{
				if (this.ballistaTexID == -1)
				{
					this.ballistaTexID = this.gfx.loadSprites("assets\\body_ballista.uv");
				}
				return this.ballistaTexID;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x00015241 File Offset: 0x00013441
		public int ArmyAnimsTexID
		{
			get
			{
				if (this.armyAnimsTexID == -1)
				{
					this.armyAnimsTexID = this.gfx.loadSprites("assets\\army_anim_bits.uv");
				}
				return this.armyAnimsTexID;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600135E RID: 4958 RVA: 0x00015268 File Offset: 0x00013468
		public int TutorialIconNormalID
		{
			get
			{
				if (this.tutorialIconNormalID == -1)
				{
					this.tutorialIconNormalID = this.gfx.loadSprites("assets\\tutorial_button_open_normal.uv");
				}
				return this.tutorialIconNormalID;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x0001528F File Offset: 0x0001348F
		public int TutorialIconOverID
		{
			get
			{
				if (this.tutorialIconOverID == -1)
				{
					this.tutorialIconOverID = this.gfx.loadSprites("assets\\tutorial_button_open_over.uv");
				}
				return this.tutorialIconOverID;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06001360 RID: 4960 RVA: 0x000152B6 File Offset: 0x000134B6
		public int FreeCardIconsID
		{
			get
			{
				if (this.freeCardIconsID == -1)
				{
					this.freeCardIconsID = this.gfx.loadSprites("assets\\free_card_bits.uv");
				}
				return this.freeCardIconsID;
			}
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x000152DD File Offset: 0x000134DD
		public void changeView(string view)
		{
			AssetLoader.instance.recordViewChange(view);
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x00139CD8 File Offset: 0x00137ED8
		public static string getPanelDescFromID(int panelid)
		{
			if (panelid <= 41)
			{
				switch (panelid)
				{
				case 1:
					return "village_banquet";
				case 2:
				case 6:
				case 7:
					break;
				case 3:
					return "village_trade";
				case 4:
					return "village_army";
				case 5:
					return "village_resources";
				case 8:
					return "village_vassal";
				default:
					switch (panelid)
					{
					case 18:
						return "village_scouting";
					case 19:
						return "rankup";
					case 20:
					case 25:
						break;
					case 21:
						return "reports";
					case 22:
						return "glory_race";
					case 23:
						return "combat";
					case 24:
						return "vassal_overview";
					case 26:
						return "quests";
					default:
						if (panelid == 41)
						{
							return "faction";
						}
						break;
					}
					break;
				}
			}
			else if (panelid <= 52)
			{
				if (panelid == 51)
				{
					return "all_houses";
				}
				if (panelid == 52)
				{
					return "house_view";
				}
			}
			else
			{
				switch (panelid)
				{
				case 201:
					return "tab_worldmap";
				case 202:
					return "tab_villagemap";
				case 203:
					return "tab_capital";
				case 204:
					return "tab_research";
				case 205:
					return "tab_ranking";
				case 206:
					return "tab_quests";
				case 207:
					return "tab_attacks";
				case 208:
					return "tab_reports";
				case 209:
					return "tab_factions";
				default:
					switch (panelid)
					{
					case 1003:
						return "parish_trade";
					case 1004:
						return "parish_army";
					case 1005:
						return "parish_resources";
					case 1006:
						return "parish_voting";
					case 1007:
						return "parish_forum";
					case 1008:
						return "parish_wall";
					}
					break;
				}
			}
			return "unknown_panel";
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x000152EA File Offset: 0x000134EA
		public void recordTextureUse(string texturename, int width, int height)
		{
			AssetLoader.instance.recordTextureUse(texturename, width, height);
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x00139E78 File Offset: 0x00138078
		private GFXLibrary()
		{
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x000152F9 File Offset: 0x000134F9
		public static BaseImage getLoginWorldFlag(string code)
		{
			if (GFXLibrary.LoginWorldFlags.ContainsKey(code) && GFXLibrary.LoginWorldFlags[code] != null)
			{
				return GFXLibrary.LoginWorldFlags[code];
			}
			return GFXLibrary.LoginWorldFlags["en"];
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x00015330 File Offset: 0x00013530
		public static BaseImage getLoginWorldMap(string code)
		{
			if (GFXLibrary.LoginWorldMaps.ContainsKey(code) && GFXLibrary.LoginWorldMaps[code] != null)
			{
				return GFXLibrary.LoginWorldMaps[code];
			}
			return GFXLibrary.LoginWorldMaps["en"];
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0013A1B0 File Offset: 0x001383B0
		public static BaseImage getResearchIllustration(int researchType)
		{
			switch (researchType)
			{
			case 0:
				return GFXLibrary.research_ill_stone_quarrying;
			case 1:
				return GFXLibrary.research_ill_forestry;
			case 2:
				return GFXLibrary.research_ill_iron_mining;
			case 3:
				return GFXLibrary.research_ill_pitch_extraction;
			case 4:
				return GFXLibrary.research_ill_tools;
			case 5:
				return GFXLibrary.research_ill_salt_working;
			case 6:
				return GFXLibrary.research_ill_craftsmanship;
			case 7:
				return GFXLibrary.research_ill_tailoring;
			case 8:
				return GFXLibrary.research_ill_carpentry;
			case 9:
				return GFXLibrary.research_ill_metal_working;
			case 10:
				return GFXLibrary.research_ill_brewing;
			case 11:
				return GFXLibrary.research_ill_butchery;
			case 12:
				return GFXLibrary.research_ill_bakery;
			case 13:
				return GFXLibrary.research_ill_weapon_making;
			case 14:
				return GFXLibrary.research_ill_siege_mechanics;
			case 15:
				return GFXLibrary.research_ill_blacksmithing;
			case 16:
				return GFXLibrary.research_ill_pole_turning;
			case 17:
				return GFXLibrary.research_ill_armour_working;
			case 18:
				return GFXLibrary.research_ill_fletching;
			case 19:
				return GFXLibrary.research_ill_castellation;
			case 20:
				return GFXLibrary.research_ill_construction;
			case 21:
				return GFXLibrary.research_ill_defences;
			case 22:
				return GFXLibrary.research_ill_vaults;
			case 23:
				return GFXLibrary.research_ill_fortification;
			case 24:
				return GFXLibrary.research_ill_command;
			case 25:
				return GFXLibrary.research_ill_captains;
			case 26:
				return GFXLibrary.research_ill_catapult;
			case 27:
				return GFXLibrary.research_ill_sword;
			case 28:
				return GFXLibrary.research_ill_pike;
			case 29:
				return GFXLibrary.research_ill_longbow;
			case 30:
				return GFXLibrary.research_ill_conscription;
			case 31:
				return GFXLibrary.research_ill_espionage;
			case 32:
				return GFXLibrary.research_ill_mathematics;
			case 33:
				return GFXLibrary.research_ill_architecture;
			case 34:
				return GFXLibrary.research_ill_commerce;
			case 35:
				return GFXLibrary.research_ill_trade_agreements;
			case 36:
				return GFXLibrary.research_ill_land_trade;
			case 37:
				return GFXLibrary.research_ill_foraging;
			case 38:
				return GFXLibrary.research_ill_silk_trade;
			case 39:
				return GFXLibrary.research_ill_spice_trade;
			case 40:
				return GFXLibrary.research_ill_engineering;
			case 41:
				return GFXLibrary.research_ill_hall_capacity;
			case 42:
				return GFXLibrary.research_ill_housing_capacity;
			case 43:
				return GFXLibrary.research_ill_armoury_capacity;
			case 44:
				return GFXLibrary.research_ill_inn_capacity;
			case 45:
				return GFXLibrary.research_ill_granary_capacity;
			case 46:
				return GFXLibrary.research_ill_stockpile_capacity;
			case 47:
				return GFXLibrary.research_ill_literature;
			case 48:
				return GFXLibrary.research_ill_philosophy;
			case 49:
				return GFXLibrary.research_ill_theology;
			case 50:
				return GFXLibrary.research_ill_extreme_unction;
			case 51:
				return GFXLibrary.research_ill_confession;
			case 52:
				return GFXLibrary.research_ill_ordination;
			case 53:
				return GFXLibrary.research_ill_eucharist;
			case 54:
				return GFXLibrary.research_ill_confirmation;
			case 55:
				return GFXLibrary.research_ill_baptism;
			case 56:
				return GFXLibrary.research_ill_marriage;
			case 57:
				return GFXLibrary.research_ill_diplomacy;
			case 58:
				return GFXLibrary.research_ill_justice;
			case 59:
				return GFXLibrary.research_ill_arts;
			case 60:
				return GFXLibrary.research_ill_gardening;
			case 61:
				return GFXLibrary.research_ill_animal_husbandry;
			case 62:
				return GFXLibrary.research_ill_pig_breeding;
			case 63:
				return GFXLibrary.research_ill_hunting;
			case 64:
				return GFXLibrary.research_ill_dairy_farming;
			case 65:
				return GFXLibrary.research_ill_fishing;
			case 66:
				return GFXLibrary.research_ill_apple_farming;
			case 67:
				return GFXLibrary.research_ill_hops_farming;
			case 68:
				return GFXLibrary.research_ill_plough;
			case 69:
				return GFXLibrary.research_ill_wine_production;
			case 70:
				return GFXLibrary.research_ill_wheat_farming;
			case 71:
				return GFXLibrary.research_ill_vegetable_cropping;
			case 72:
				return GFXLibrary.research_ill_pilgrimage;
			case 73:
				return GFXLibrary.research_ill_tactics;
			case 74:
				return GFXLibrary.research_ill_leadership;
			case 75:
				return GFXLibrary.research_ill_scouts;
			case 76:
				return GFXLibrary.research_ill_horsemanship;
			case 77:
				return GFXLibrary.research_ill_surveillance;
			case 78:
				return GFXLibrary.research_ill_pillage;
			case 79:
				return GFXLibrary.research_ill_intelligence_gathering;
			case 80:
				return GFXLibrary.research_ill_counter_surveillance;
			case 81:
				return GFXLibrary.research_ill_bounties;
			case 82:
				return GFXLibrary.research_ill_logistics;
			case 83:
				return GFXLibrary.research_ill_civil_service;
			case 84:
				return GFXLibrary.research_ill_sally_forth;
			case 85:
				return GFXLibrary.research_ill_ransacking;
			case 86:
				return GFXLibrary.research_ill_forced_march;
			default:
				return null;
			}
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x0013A530 File Offset: 0x00138730
		public void loadGFX(GraphicsMgr mgr)
		{
			this.gfx = mgr;
			if (Program.ShowSeasonalFXOption)
			{
				SnowSystem.getInstance().loadSnowTexture(this.gfx.D3DDevice, Application.StartupPath + "\\assets\\snowball.png");
			}
			int num = this.MapElementsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num2 = this.EffectLayerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num3 = this.WorldMapTilesTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num4 = this.WorldMapIconsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			this.worldMapLoaded = true;
			this.ImageSurroundTexID2 = this.gfx.loadTextureFromBitmap((Bitmap)GFXLibrary.int_banquette_background_tile_orig);
			this.ImageSurroundTexID3 = this.gfx.loadTextureFromBitmap((Bitmap)GFXLibrary.int_banquette_background_tile_tan);
			Bitmap bitmap = new Bitmap(64, 64);
			bitmap.MakeTransparent();
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(GFXLibrary.int_button_Q_normal, new Point(0, 0));
			graphics.Dispose();
			this.WikiHelpIconNormal = this.gfx.loadTextureFromBitmap(bitmap);
			bitmap.Dispose();
			bitmap = new Bitmap(64, 64);
			bitmap.MakeTransparent();
			graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(GFXLibrary.int_button_Q_over, new Point(0, 0));
			graphics.Dispose();
			this.WikiHelpIconOver = this.gfx.loadTextureFromBitmap(bitmap);
			bitmap.Dispose();
			Bitmap bitmap2 = new Bitmap(8, 8);
			for (int i = 0; i < bitmap2.Height; i++)
			{
				for (int j = 0; j < bitmap2.Width; j++)
				{
					bitmap2.SetPixel(i, j, Color.FromArgb(64, global::ARGBColors.Black));
				}
			}
			this.ImageSurroundShadowTexID = this.gfx.loadTextureFromBitmap(bitmap2);
			int num5 = this.WoodcutterAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num6 = this.ArmourerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num7 = this.BakerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num8 = this.StonemasonAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num9 = this.IronMinerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num10 = this.FarmerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num11 = this.Farmer2AnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num12 = this.Farmer3AnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num13 = this.PitchworkerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num14 = this.DockworkerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num15 = this.PigAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num16 = this.SheepAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num17 = this.ChickenWhiteAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num18 = this.ChickenBrownAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num19 = this.MetalWorkerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num20 = this.FletcherAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num21 = this.PoleturnerAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num22 = this.BlacksmithAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num23 = this.CowAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num24 = this.Goods1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num25 = this.Goods2TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num26 = this.TownBuildindsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num27 = this.Bld_9x9_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num28 = this.Bld_4x4_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num29 = this.Bld_8x8_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num30 = this.Woodcutter_animsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num31 = this.Bld_6x6_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num32 = this.Body_stonemasonTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num33 = this.Body_iron_mine_workTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num34 = this.Body_pitchworkerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num35 = this.Bld_13x13_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num36 = this.Bld_13x13_2TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num37 = this.Body_brewerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num38 = this.Body_farmer_3TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num39 = this.Body_bakerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num40 = this.Bld_11x11_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num41 = this.Bld_7x7_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num42 = this.Bld_17x17_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num43 = this.Body_tailorTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num44 = this.Body_carpenterTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num45 = this.Body_hunterTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num46 = this.Body_metalworkerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num47 = this.Bld_5x5_1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num48 = this.Body_poleturnerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num49 = this.Body_fletcherTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num50 = this.Body_blacksmithTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num51 = this.Body_armourerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num52 = this.Body_siegeworkerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num53 = this.Bld_Various_01TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num54 = this.Anim_stocksTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num55 = this.Anim_stakeTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num56 = this.Anim_gibbetTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num57 = this.Anim_rackTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num58 = this.Anim_maypoleTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num59 = this.Anim_dancing_bearTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num60 = this.Body_theaterworkerTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num61 = this.Body_jesterTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num62 = this.Body_troubadourTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num63 = this.VillageOverlaysAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			int num64 = this.ArcherAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num65 = this.Archer2AnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num66 = this.PikemanAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num67 = this.SwordsmanAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num68 = this.PeasantAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num69 = this.Peasant2AnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num70 = this.CatapultAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num71 = this.WolfAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num72 = this.ArcherRedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num73 = this.Archer2RedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num74 = this.PikemanRedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num75 = this.SwordsmanRedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num76 = this.PeasantRedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num77 = this.Peasant2RedAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num78 = this.ArcherGreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num79 = this.Archer2GreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num80 = this.PikemanGreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num81 = this.SwordsmanGreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num82 = this.PeasantGreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num83 = this.Peasant2GreenAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num84 = this.ArcherCarryAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num85 = this.PeasantCarryAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num86 = this.PikemanCarryAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num87 = this.SwordsmanCarryAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			int num88 = this.KnightAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num89 = this.KnightTopAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num90 = this.CaptainAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num91 = this.MissileTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num92 = this.Missile2TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num93 = this.AnimKillingPitsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num94 = this.FireTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num95 = this.OilPotAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num96 = this.ManOnFireTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num97 = this.Smoke1TexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num98 = this.HpsBarsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num99 = this.TraderAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num100 = this.TraderHorseAnimTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num101 = this.CastleBackgroundTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num102 = this.CastleSpritesTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num103 = this.BallistaTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num104 = this.ArmyAnimsTexID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num105 = this.TutorialIconNormalID;
			if (GameEngine.Instance.cancelLoading())
			{
				return;
			}
			int num106 = this.TutorialIconOverID;
			if (!GameEngine.Instance.cancelLoading())
			{
				int num107 = this.FreeCardIconsID;
				if (!GameEngine.Instance.cancelLoading())
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
			}
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x0013AF1C File Offset: 0x0013911C
		public int getVillageBuildingTexture(string texName)
		{
			if (texName.Contains("bld_9x9_1.uv"))
			{
				return this.Bld_9x9_1TexID;
			}
			if (texName.Contains("bld_4x4_1.uv"))
			{
				return this.Bld_4x4_1TexID;
			}
			if (texName.Contains("bld_8x8_1.uv"))
			{
				return this.Bld_8x8_1TexID;
			}
			if (texName.Contains("woodcutter_anims.uv"))
			{
				return this.Woodcutter_animsTexID;
			}
			if (texName.Contains("bld_6x6_1.uv"))
			{
				return this.Bld_6x6_1TexID;
			}
			if (texName.Contains("body_stonemason anims.uv"))
			{
				return this.Body_stonemasonTexID;
			}
			if (texName.Contains("body_iron_mine_work.uv"))
			{
				return this.Body_iron_mine_workTexID;
			}
			if (texName.Contains("body_pitchworker anims.uv"))
			{
				return this.Body_pitchworkerTexID;
			}
			if (texName.Contains("bld_13x13_1.uv"))
			{
				return this.Bld_13x13_1TexID;
			}
			if (texName.Contains("bld_13x13_2.uv"))
			{
				return this.Bld_13x13_2TexID;
			}
			if (texName.Contains("body_brewer.uv"))
			{
				return this.Body_brewerTexID;
			}
			if (texName.Contains("body_farmer_3.uv"))
			{
				return this.Body_farmer_3TexID;
			}
			if (texName.Contains("body_baker.uv"))
			{
				return this.Body_bakerTexID;
			}
			if (texName.Contains("bld_11x11_1.uv"))
			{
				return this.Bld_11x11_1TexID;
			}
			if (texName.Contains("bld_7x7_1.uv"))
			{
				return this.Bld_7x7_1TexID;
			}
			if (texName.Contains("bld_17x17_1.uv"))
			{
				return this.Bld_17x17_1TexID;
			}
			if (texName.Contains("body_tailor.uv"))
			{
				return this.Body_tailorTexID;
			}
			if (texName.Contains("body_carpenter.uv"))
			{
				return this.Body_carpenterTexID;
			}
			if (texName.Contains("body_hunter.uv"))
			{
				return this.Body_hunterTexID;
			}
			if (texName.Contains("body_metalworker.uv"))
			{
				return this.Body_metalworkerTexID;
			}
			if (texName.Contains("bld_5x5_1.uv"))
			{
				return this.Bld_5x5_1TexID;
			}
			if (texName.Contains("body_poleturner.uv"))
			{
				return this.Body_poleturnerTexID;
			}
			if (texName.Contains("body_fletcher.uv"))
			{
				return this.Body_fletcherTexID;
			}
			if (texName.Contains("body_blacksmith.uv"))
			{
				return this.Body_blacksmithTexID;
			}
			if (texName.Contains("body_armourer.uv"))
			{
				return this.Body_armourerTexID;
			}
			if (texName.Contains("body_siegeworker.uv"))
			{
				return this.Body_siegeworkerTexID;
			}
			if (texName.Contains("bld_Various_01.uv"))
			{
				return this.Bld_Various_01TexID;
			}
			if (texName.Contains("anim_stocks.uv"))
			{
				return this.Anim_stocksTexID;
			}
			if (texName.Contains("anim_stake.uv"))
			{
				return this.Anim_stakeTexID;
			}
			if (texName.Contains("anim_gibbet.uv"))
			{
				return this.Anim_gibbetTexID;
			}
			if (texName.Contains("anim_rack.uv"))
			{
				return this.Anim_rackTexID;
			}
			if (texName.Contains("anim_maypole.uv"))
			{
				return this.Anim_maypoleTexID;
			}
			if (texName.Contains("anim_dancing_bear.uv"))
			{
				return this.Anim_dancing_bearTexID;
			}
			if (texName.Contains("body_theaterworker.uv"))
			{
				return this.Body_theaterworkerTexID;
			}
			if (texName.Contains("body_jester.uv"))
			{
				return this.Body_jesterTexID;
			}
			if (texName.Contains("body_troubadour.uv"))
			{
				return this.Body_troubadourTexID;
			}
			if (texName.Contains("town_buildings_01.uv"))
			{
				return this.TownBuildindsTexID;
			}
			return -1;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x0013B210 File Offset: 0x00139410
		public void initAssetDictionaries()
		{
			GFXLibrary.CardPackImages = new Dictionary<string, BaseImage>();
			GFXLibrary.CardPackImages.Add("card_pack_army_gold_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_gold_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_army_gold_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_gold_over"));
			GFXLibrary.CardPackImages.Add("card_pack_army_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_army_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_army_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_army_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_army_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_castle_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_castle_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_castle_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_castle_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_gold_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_gold_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_gold_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_gold_over"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_defence_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_defence_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_food_gold_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_gold_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_food_gold_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_gold_over"));
			GFXLibrary.CardPackImages.Add("card_pack_food_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_food_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_food_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_food_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_food_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_gold_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_gold_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_gold_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_gold_over"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_Industry_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_Industry_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_random_gold_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_gold_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_random_gold_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_gold_over"));
			GFXLibrary.CardPackImages.Add("card_pack_random_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_random_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_random_standard_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_standard_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_random_standard_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_random_standard_over"));
			GFXLibrary.CardPackImages.Add("card_pack_exclusive_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_exclusive_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_exclusive_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_exclusive_silver_over"));
			GFXLibrary.CardPackImages.Add("card_pack_research_silver_normal", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_research_silver_normal"));
			GFXLibrary.CardPackImages.Add("card_pack_research_silver_over", new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_research_silver_over"));
			GFXLibrary.CardSlotStillSymbols = new Dictionary<int, BaseImage>();
			GFXLibrary.CardSlotStillSymbols.Add(16777216, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_apple.png"));
			GFXLibrary.CardSlotStillSymbols.Add(268435456, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_castle.png"));
			GFXLibrary.CardSlotStillSymbols.Add(1073741824, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_crown.png"));
			GFXLibrary.CardSlotStillSymbols.Add(67108864, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_hawk.png"));
			GFXLibrary.CardSlotStillSymbols.Add(536870912, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_jester.png"));
			GFXLibrary.CardSlotStillSymbols.Add(134217728, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_shield.png"));
			GFXLibrary.CardSlotStillSymbols.Add(33554432, new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_wolf.png"));
			GFXLibrary.LoginWorldFlags.Add("en", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_en.png"));
			GFXLibrary.LoginWorldFlags.Add("de", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_de.png"));
			GFXLibrary.LoginWorldFlags.Add("fr", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_fr.png"));
			GFXLibrary.LoginWorldFlags.Add("ru", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_ru.png"));
			GFXLibrary.LoginWorldFlags.Add("es", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_es.png"));
			GFXLibrary.LoginWorldFlags.Add("pl", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_pl.png"));
			GFXLibrary.LoginWorldFlags.Add("br", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_br.png"));
			GFXLibrary.LoginWorldFlags.Add("pt", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_esbr.png"));
			GFXLibrary.LoginWorldFlags.Add("it", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_it.png"));
			GFXLibrary.LoginWorldFlags.Add("tr", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_tk.png"));
			GFXLibrary.LoginWorldFlags.Add("eu", new BaseImage(AssetPaths.AssetIconsMisc, "flag_eu.png"));
			GFXLibrary.LoginWorldFlags.Add("wd", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_wd.png"));
			GFXLibrary.LoginWorldFlags.Add("zh", new BaseImage(AssetPaths.AssetIconsCardPanel, "flag_ch.png"));
			GFXLibrary.LoginWorldMaps.Add("en", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_en"));
			GFXLibrary.LoginWorldMaps.Add("de", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_de"));
			GFXLibrary.LoginWorldMaps.Add("fr", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_fr"));
			GFXLibrary.LoginWorldMaps.Add("ru", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_ru"));
			GFXLibrary.LoginWorldMaps.Add("es", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_es"));
			GFXLibrary.LoginWorldMaps.Add("pl", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_pl"));
			GFXLibrary.LoginWorldMaps.Add("tr", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_tk"));
			GFXLibrary.LoginWorldMaps.Add("us", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_us"));
			GFXLibrary.LoginWorldMaps.Add("it", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_it"));
			GFXLibrary.LoginWorldMaps.Add("eu", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_eu"));
			GFXLibrary.LoginWorldMaps.Add("pt", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_sa"));
			GFXLibrary.LoginWorldMaps.Add("wd", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_wd"));
			GFXLibrary.LoginWorldMaps.Add("ph", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_ph"));
			GFXLibrary.LoginWorldMaps.Add("zh", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_ch"));
			GFXLibrary.LoginWorldMaps.Add("kg", new BaseImage(AssetPaths.AssetIconsCardPanel, "map_kg"));
			GFXLibrary.PremiumTokens = new Dictionary<int, BaseImage[]>();
			GFXLibrary.PremiumTokens.Add(4112, new BaseImage[]
			{
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_normal.png"),
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_over.png")
			});
			GFXLibrary.PremiumTokens.Add(4113, new BaseImage[]
			{
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_2_normal.png"),
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_2_over.png")
			});
			GFXLibrary.PremiumTokens.Add(4114, new BaseImage[]
			{
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_30_normal.png"),
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_30_over.png")
			});
			GFXLibrary.PremiumTokens.Add(4116, new BaseImage[]
			{
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_x_normal.png"),
				new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_x_over.png")
			});
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0013BB74 File Offset: 0x00139D74
		public void flushSnowGFX()
		{
			this.effectLayerTexID = -1;
			this.mapElementsTexID = -1;
			this.worldMapTilesTexID = -1;
			UVSpriteLoader.loadUVX("assets\\uvx.resources");
			int num = this.EffectLayerTexID;
			int num2 = this.MapElementsTexID;
			int num3 = this.WorldMapTilesTexID;
			UVSpriteLoader.closeUVX();
			GameEngine.Instance.World.updateSeasonalGFX();
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0013BBCC File Offset: 0x00139DCC
		public void loadResources()
		{
			GFXLibrary.LoginWorldFlags = new Dictionary<string, BaseImage>();
			GFXLibrary.LoginWorldMaps = new Dictionary<string, BaseImage>();
			this.initAssetDictionaries();
			this.loadCards();
			AssetLoader.instance.onStartup();
			int num = GFXLibrary.avatar_parchment_top_multiply.Width * GFXLibrary.avatar_parchment_top_multiply.Height * 4;
			GFXLibrary.parchementOverlay = new byte[num];
			Rectangle rect = new Rectangle(0, 0, GFXLibrary.avatar_parchment_top_multiply.Width, GFXLibrary.avatar_parchment_top_multiply.Height);
			Bitmap bitmap = (Bitmap)GFXLibrary.avatar_parchment_top_multiply;
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			Marshal.Copy(scan, GFXLibrary.parchementOverlay, 0, num);
			bitmap.UnlockBits(bitmapData);
			GFXLibrary.avatar_parchment_top_multiply = null;
			bitmap.Dispose();
			InterfaceMgr.Instance.getTopLeftMenu().init();
			InterfaceMgr.Instance.getTopRightMenu().init();
			InterfaceMgr.Instance.getMainTabBar().initImages();
			InterfaceMgr.Instance.getVillageTabBar().initImages();
			InterfaceMgr.Instance.getFactionTabBar().initImages();
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0013BCD8 File Offset: 0x00139ED8
		public void loadCards()
		{
			GFXLibrary.CardSlotAnimData = new int[GFXLibrary.CardSlotAnimFrames.Length];
			int i = 0;
			while (i < GFXLibrary.CardSlotAnimData.Length)
			{
				if (i <= 6)
				{
					if (i != 0)
					{
						if (i != 3)
						{
							if (i != 6)
							{
								goto IL_BC;
							}
							GFXLibrary.CardSlotAnimData[i] = 1073741824;
						}
						else
						{
							GFXLibrary.CardSlotAnimData[i] = 268435456;
						}
					}
					else
					{
						GFXLibrary.CardSlotAnimData[i] = 16777216;
					}
				}
				else if (i <= 12)
				{
					if (i != 9)
					{
						if (i != 12)
						{
							goto IL_BC;
						}
						GFXLibrary.CardSlotAnimData[i] = 536870912;
					}
					else
					{
						GFXLibrary.CardSlotAnimData[i] = 67108864;
					}
				}
				else if (i != 15)
				{
					if (i != 18)
					{
						goto IL_BC;
					}
					GFXLibrary.CardSlotAnimData[i] = 33554432;
				}
				else
				{
					GFXLibrary.CardSlotAnimData[i] = 134217728;
				}
				IL_C5:
				i++;
				continue;
				IL_BC:
				GFXLibrary.CardSlotAnimData[i] = 0;
				goto IL_C5;
			}
			ResourceLoader resourceLoader = new ResourceLoader("AssetIcons\\Cards\\Panel\\Panel.resources");
			Random random = new Random();
			GFXLibrary.invite_ad_colour = random.Next(5);
			string languageIdent = Program.mySettings.LanguageIdent;
			string text;
			string text2;
			if (languageIdent != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
				if (num <= 1195724803U)
				{
					if (num <= 1164435231U)
					{
						if (num != 1111292255U)
						{
							if (num != 1162757945U)
							{
								if (num == 1164435231U)
								{
									if (languageIdent == "zh")
									{
										text = "ad_invite__0009__sc";
										text2 = "ad_invite_quest-top__0009__sc";
										goto IL_37F;
									}
								}
							}
							else if (languageIdent == "pl")
							{
								text = "ad_invite__0008__pl";
								text2 = "ad_invite_quest-top__0008__pl";
								goto IL_37F;
							}
						}
						else if (languageIdent == "ko")
						{
							text = "ad_invite__0011__ko";
							text2 = "ad_invite_quest-top__0011__ko";
							goto IL_37F;
						}
					}
					else if (num != 1176137065U)
					{
						if (num != 1194886160U)
						{
							if (num == 1195724803U)
							{
								if (languageIdent == "tr")
								{
									text = "ad_invite__0007__tr";
									text2 = "ad_invite_quest_top__0007__tr";
									goto IL_37F;
								}
							}
						}
						else if (languageIdent == "it")
						{
							text = "ad_invite__0003__it";
							text2 = "ad_invite_quest_top__0003__it";
							goto IL_37F;
						}
					}
					else if (languageIdent == "es")
					{
						text = "ad_invite__0002__sp";
						text2 = "ad_invite_quest_top__0002__sp";
						goto IL_37F;
					}
				}
				else if (num <= 1461901041U)
				{
					if (num != 1213488160U)
					{
						if (num != 1241987482U)
						{
							if (num == 1461901041U)
							{
								if (languageIdent == "fr")
								{
									text = "ad_invite__0006__fr";
									text2 = "ad_invite_quest_top__0006__fr";
									goto IL_37F;
								}
							}
						}
						else if (languageIdent == "zhhk")
						{
							text = "ad_invite__0010__tc";
							text2 = "ad_invite_quest-top__0010__tc";
							goto IL_37F;
						}
					}
					else if (languageIdent == "ru")
					{
						text = "ad_invite__0005__ru";
						text2 = "ad_invite_quest_top__0005__ru";
						goto IL_37F;
					}
				}
				else if (num != 1545391778U)
				{
					if (num != 1564435063U)
					{
						if (num == 1565420801U)
						{
							if (languageIdent == "pt")
							{
								text = "ad_invite__0001__pt";
								text2 = "ad_invite_quest_top__0001__pt";
								goto IL_37F;
							}
						}
					}
					else if (languageIdent == "jp")
					{
						text = "ad_invite__0012__jp";
						text2 = "ad_invite_quest-top__0012__jp";
						goto IL_37F;
					}
				}
				else if (languageIdent == "de")
				{
					text = "ad_invite__0004__de";
					text2 = "ad_invite_quest_top__0004__de";
					goto IL_37F;
				}
			}
			text = "ad_invite__0000__en";
			text2 = "ad_invite_quest_top__0000__en";
			IL_37F:
			text += ".png";
			GFXLibrary.banner_ad_friend = new BaseImage(AssetPaths.AssetIconsCardPanel, text);
			text2 += ".png";
			GFXLibrary.banner_ad_friend_quest = new BaseImage(AssetPaths.AssetIconsCardPanel, text2);
			resourceLoader.Close();
			Image image = new Bitmap(1, 1);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.Clear(global::ARGBColors.Transparent);
			}
			GFXLibrary.dummy = image;
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x0013C0E8 File Offset: 0x0013A2E8
		public BaseImage getCardImageBig(int cardType)
		{
			BaseImage result = GFXLibrary.NoImageCardBig;
			BaseImage baseImage = (BaseImage)this.cardImagesBig[CardTypes.getCardType(cardType)];
			if (baseImage == null)
			{
				CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(cardType);
				string text = CardTypes.getStringFromCard(cardDefinition.id) + ".jpg";
				if (cardDefinition.available == 1 || text.ToLower().Contains("cardtype_"))
				{
					this.cardImagesBig[CardTypes.getCardType(cardType)] = new BaseImage(AssetPaths.AssetIconsBigCards, text, BaseImage.loadType.CARD);
					if (this.cardImagesBig[CardTypes.getCardType(cardType)] != null)
					{
						result = (BaseImage)this.cardImagesBig[CardTypes.getCardType(cardType)];
					}
				}
			}
			else
			{
				result = baseImage;
			}
			return result;
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x00015367 File Offset: 0x00013567
		public void closeBigCardsLoader()
		{
			if (this.cachedBigCardsLoader != null)
			{
				this.cachedBigCardsLoader.Close();
			}
			this.cachedBigCardsLoader = null;
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x0013C19C File Offset: 0x0013A39C
		public static int getCommodity32GFXno(int resource)
		{
			int result = -1;
			switch (resource)
			{
			case 6:
				result = 27;
				break;
			case 7:
				result = 22;
				break;
			case 8:
				result = 12;
				break;
			case 9:
				result = 18;
				break;
			case 12:
				result = 0;
				break;
			case 13:
				result = 1;
				break;
			case 14:
				result = 4;
				break;
			case 15:
				result = 24;
				break;
			case 16:
				result = 13;
				break;
			case 17:
				result = 6;
				break;
			case 18:
				result = 8;
				break;
			case 19:
				result = 7;
				break;
			case 21:
				result = 10;
				break;
			case 22:
				result = 25;
				break;
			case 23:
				result = 19;
				break;
			case 24:
				result = 21;
				break;
			case 25:
				result = 20;
				break;
			case 26:
				result = 14;
				break;
			case 28:
				result = 17;
				break;
			case 29:
				result = 3;
				break;
			case 30:
				result = 23;
				break;
			case 31:
				result = 2;
				break;
			case 32:
				result = 5;
				break;
			case 33:
				result = 26;
				break;
			}
			return result;
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0013C294 File Offset: 0x0013A494
		public static BaseImage getCommodity32Image(int resource)
		{
			switch (resource)
			{
			case 6:
				return GFXLibrary.com_32_wood;
			case 7:
				return GFXLibrary.com_32_stone;
			case 8:
				return GFXLibrary.com_32_iron;
			case 9:
				return GFXLibrary.com_32_pitch;
			case 12:
				return GFXLibrary.com_32_ale;
			case 13:
				return GFXLibrary.com_32_apples;
			case 14:
				return GFXLibrary.com_32_bread;
			case 15:
				return GFXLibrary.com_32_veg;
			case 16:
				return GFXLibrary.com_32_meat;
			case 17:
				return GFXLibrary.com_32_cheese;
			case 18:
				return GFXLibrary.com_32_fish;
			case 19:
				return GFXLibrary.com_32_clothing;
			case 21:
				return GFXLibrary.com_32_furniture;
			case 22:
				return GFXLibrary.com_32_venison;
			case 23:
				return GFXLibrary.com_32_salt;
			case 24:
				return GFXLibrary.com_32_spice;
			case 25:
				return GFXLibrary.com_32_silk;
			case 26:
				return GFXLibrary.com_32_metalwork;
			case 28:
				return GFXLibrary.com_32_pikes;
			case 29:
				return GFXLibrary.com_32_bows;
			case 30:
				return GFXLibrary.com_32_swords;
			case 31:
				return GFXLibrary.com_32_armour;
			case 32:
				return GFXLibrary.com_32_catapults;
			case 33:
				return GFXLibrary.com_32_wine;
			}
			return null;
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0013C3B0 File Offset: 0x0013A5B0
		public static BaseImage getCommodity64DSImage(int resource)
		{
			switch (resource)
			{
			case 6:
				return GFXLibrary.com_64_wood_DS;
			case 7:
				return GFXLibrary.com_64_stone_DS;
			case 8:
				return GFXLibrary.com_64_iron_DS;
			case 9:
				return GFXLibrary.com_64_pitch_DS;
			case 12:
				return GFXLibrary.com_64_ale_DS;
			case 13:
				return GFXLibrary.com_64_apples_DS;
			case 14:
				return GFXLibrary.com_64_bread_DS;
			case 15:
				return GFXLibrary.com_64_veg_DS;
			case 16:
				return GFXLibrary.com_64_meat_DS;
			case 17:
				return GFXLibrary.com_64_cheese_DS;
			case 18:
				return GFXLibrary.com_64_fish_DS;
			case 19:
				return GFXLibrary.com_64_clothes_DS;
			case 21:
				return GFXLibrary.com_64_furniture_DS;
			case 22:
				return GFXLibrary.com_64_venison_DS;
			case 23:
				return GFXLibrary.com_64_salt_DS;
			case 24:
				return GFXLibrary.com_64_spices_DS;
			case 25:
				return GFXLibrary.com_64_silk_DS;
			case 26:
				return GFXLibrary.com_64_metalware_DS;
			case 28:
				return GFXLibrary.com_64_pikes_DS;
			case 29:
				return GFXLibrary.com_64_bows_DS;
			case 30:
				return GFXLibrary.com_64_swords_DS;
			case 31:
				return GFXLibrary.com_64_armour_DS;
			case 32:
				return GFXLibrary.com_64_catapults_DS;
			case 33:
				return GFXLibrary.com_64_wine_DS;
			}
			return null;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0013C4CC File Offset: 0x0013A6CC
		public static BaseImage getCommodity32DSImage(int resource)
		{
			switch (resource)
			{
			case 6:
				return GFXLibrary.com_32_wood_DS;
			case 7:
				return GFXLibrary.com_32_stone_DS;
			case 8:
				return GFXLibrary.com_32_iron_DS;
			case 9:
				return GFXLibrary.com_32_pitch_DS;
			case 12:
				return GFXLibrary.com_32_ale_DS;
			case 13:
				return GFXLibrary.com_32_apples_DS;
			case 14:
				return GFXLibrary.com_32_bread_DS;
			case 15:
				return GFXLibrary.com_32_veg_DS;
			case 16:
				return GFXLibrary.com_32_meat_DS;
			case 17:
				return GFXLibrary.com_32_cheese_DS;
			case 18:
				return GFXLibrary.com_32_fish_DS;
			case 19:
				return GFXLibrary.com_32_clothes_DS;
			case 21:
				return GFXLibrary.com_32_furniture_DS;
			case 22:
				return GFXLibrary.com_32_venison_DS;
			case 23:
				return GFXLibrary.com_32_salt_DS;
			case 24:
				return GFXLibrary.com_32_spices_DS;
			case 25:
				return GFXLibrary.com_32_silk_DS;
			case 26:
				return GFXLibrary.com_32_metalware_DS;
			case 28:
				return GFXLibrary.com_32_pikes_DS;
			case 29:
				return GFXLibrary.com_32_bows_DS;
			case 30:
				return GFXLibrary.com_32_swords_DS;
			case 31:
				return GFXLibrary.com_32_armour_DS;
			case 32:
				return GFXLibrary.com_32_catapults_DS;
			case 33:
				return GFXLibrary.com_32_wine_DS;
			}
			return null;
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0013C5E8 File Offset: 0x0013A7E8
		public static BaseImage GetLeaderboardCategoryIcon(int category)
		{
			switch (category)
			{
			case -6:
				return GFXLibrary.catagory_icons_villages_pushed;
			case -5:
				return GFXLibrary.catagory_icons_rank_pushed;
			case -1:
				return GFXLibrary.catagory_icons_points_pushed;
			case 0:
				return GFXLibrary.catagory_icons_pillager_pushed;
			case 1:
				return GFXLibrary.catagory_icons_defender_pushed;
			case 2:
				return GFXLibrary.catagory_icons_destroyer_pushed;
			case 3:
				return GFXLibrary.catagory_icons_wolfbane_pushed;
			case 4:
				return GFXLibrary.catagory_icons_banditslayer_pushed;
			case 5:
				return GFXLibrary.catagory_icons_aikiller_pushed;
			case 6:
				return GFXLibrary.catagory_icons_merchant_pushed;
			case 7:
				return GFXLibrary.catagory_icons_forger_pushed;
			case 8:
				return GFXLibrary.catagory_icons_worker_pushed;
			case 9:
				return GFXLibrary.catagory_icons_farmer_pushed;
			case 10:
				return GFXLibrary.catagory_icons_brewer_pushed;
			case 11:
				return GFXLibrary.catagory_icons_blacksmith_pushed;
			case 12:
				return GFXLibrary.catagory_icons_banquet_pushed;
			case 13:
				return GFXLibrary.catagory_icons_achiever_pushed;
			case 14:
				return GFXLibrary.catagory_icons_donator_pushed;
			case 15:
				return GFXLibrary.catagory_icons_capture_pushed;
			case 16:
				return GFXLibrary.catagory_icons_raze_pushed;
			case 17:
				return GFXLibrary.catagory_icons_glory_pushed;
			case 18:
				return GFXLibrary.catagory_icons_killstreak_pushed;
			}
			return null;
		}

		// Token: 0x0400196B RID: 6507
		public static bool AssetsLoaded = false;

		// Token: 0x0400196C RID: 6508
		private static readonly GFXLibrary instance = new GFXLibrary();

		// Token: 0x0400196D RID: 6509
		private GraphicsMgr gfx;

		// Token: 0x0400196E RID: 6510
		public static Dictionary<string, BaseImage> LoginWorldFlags;

		// Token: 0x0400196F RID: 6511
		public static Dictionary<string, BaseImage> LoginWorldMaps;

		// Token: 0x04001970 RID: 6512
		public static Dictionary<int, BaseImage> CardSlotStillSymbols;

		// Token: 0x04001971 RID: 6513
		public static int ButtonStateNormal = 0;

		// Token: 0x04001972 RID: 6514
		public static int ButtonStateOver = 1;

		// Token: 0x04001973 RID: 6515
		public static int ButtonStatePressed = 2;

		// Token: 0x04001974 RID: 6516
		public static Dictionary<int, BaseImage[][]> CardFilterButtons;

		// Token: 0x04001975 RID: 6517
		public static Dictionary<int, BaseImage[]> PremiumTokens;

		// Token: 0x04001976 RID: 6518
		public static int[] CardSlotAnimData;

		// Token: 0x04001977 RID: 6519
		public static BaseImage bubble_normal = new BaseImage(AssetPaths.AssetIconsMainResources, "bubble_normal.png");

		// Token: 0x04001978 RID: 6520
		public static BaseImage bubble_over = new BaseImage(AssetPaths.AssetIconsMainResources, "bubble_over.png");

		// Token: 0x04001979 RID: 6521
		public static BaseImage com_16_ale = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_ale.png");

		// Token: 0x0400197A RID: 6522
		public static BaseImage com_16_apples = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_apples.png");

		// Token: 0x0400197B RID: 6523
		public static BaseImage com_16_armour = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_armour.png");

		// Token: 0x0400197C RID: 6524
		public static BaseImage com_16_bows = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_bows.png");

		// Token: 0x0400197D RID: 6525
		public static BaseImage com_16_bread = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_bread.png");

		// Token: 0x0400197E RID: 6526
		public static BaseImage com_16_catapults = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_catapults.png");

		// Token: 0x0400197F RID: 6527
		public static BaseImage com_16_cheese = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_cheese.png");

		// Token: 0x04001980 RID: 6528
		public static BaseImage com_16_clothing = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_clothing.png");

		// Token: 0x04001981 RID: 6529
		public static BaseImage com_16_fish = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_fish.png");

		// Token: 0x04001982 RID: 6530
		public static BaseImage com_16_food = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_food.png");

		// Token: 0x04001983 RID: 6531
		public static BaseImage com_16_furniture = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_furniture.png");

		// Token: 0x04001984 RID: 6532
		public static BaseImage com_16_honour = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_honour.png");

		// Token: 0x04001985 RID: 6533
		public static BaseImage com_16_iron = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_iron.png");

		// Token: 0x04001986 RID: 6534
		public static BaseImage com_16_meat = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_meat.png");

		// Token: 0x04001987 RID: 6535
		public static BaseImage com_16_metalwork = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_metalwork.png");

		// Token: 0x04001988 RID: 6536
		public static BaseImage com_16_money = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_money.png");

		// Token: 0x04001989 RID: 6537
		public static BaseImage com_16_people = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_people.png");

		// Token: 0x0400198A RID: 6538
		public static BaseImage com_16_pikes = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_pikes.png");

		// Token: 0x0400198B RID: 6539
		public static BaseImage com_16_pitch = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_pitch.png");

		// Token: 0x0400198C RID: 6540
		public static BaseImage com_16_salt = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_salt.png");

		// Token: 0x0400198D RID: 6541
		public static BaseImage com_16_silk = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_silk.png");

		// Token: 0x0400198E RID: 6542
		public static BaseImage com_16_spice = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_spice.png");

		// Token: 0x0400198F RID: 6543
		public static BaseImage com_16_stone = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_stone.png");

		// Token: 0x04001990 RID: 6544
		public static BaseImage com_16_swords = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_swords.png");

		// Token: 0x04001991 RID: 6545
		public static BaseImage com_16_veg = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_veg.png");

		// Token: 0x04001992 RID: 6546
		public static BaseImage com_16_venison = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_venison.png");

		// Token: 0x04001993 RID: 6547
		public static BaseImage com_16_wine = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_wine.png");

		// Token: 0x04001994 RID: 6548
		public static BaseImage com_16_wood = new BaseImage(AssetPaths.AssetIconsMainResources, "com_16_wood.png");

		// Token: 0x04001995 RID: 6549
		public static BaseImage com_32_ale = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_ale.png");

		// Token: 0x04001996 RID: 6550
		public static BaseImage com_32_apples = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_apples.png");

		// Token: 0x04001997 RID: 6551
		public static BaseImage com_32_armour = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_armour.png");

		// Token: 0x04001998 RID: 6552
		public static BaseImage com_32_bows = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_bows.png");

		// Token: 0x04001999 RID: 6553
		public static BaseImage com_32_bread = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_bread.png");

		// Token: 0x0400199A RID: 6554
		public static BaseImage com_32_catapults = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_catapults.png");

		// Token: 0x0400199B RID: 6555
		public static BaseImage com_32_cheese = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_cheese.png");

		// Token: 0x0400199C RID: 6556
		public static BaseImage com_32_clothing = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_clothing.png");

		// Token: 0x0400199D RID: 6557
		public static BaseImage com_32_fish = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_fish.png");

		// Token: 0x0400199E RID: 6558
		public static BaseImage com_32_food = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_food.png");

		// Token: 0x0400199F RID: 6559
		public static BaseImage com_32_furniture = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_furniture.png");

		// Token: 0x040019A0 RID: 6560
		public static BaseImage com_32_honour = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_honour.png");

		// Token: 0x040019A1 RID: 6561
		public static BaseImage com_32_iron = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_iron.png");

		// Token: 0x040019A2 RID: 6562
		public static BaseImage com_32_meat = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_meat.png");

		// Token: 0x040019A3 RID: 6563
		public static BaseImage com_32_metalwork = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_metalwork.png");

		// Token: 0x040019A4 RID: 6564
		public static BaseImage com_32_money = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_money.png");

		// Token: 0x040019A5 RID: 6565
		public static BaseImage com_32_people = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_people.png");

		// Token: 0x040019A6 RID: 6566
		public static BaseImage com_32_pikes = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_pikes.png");

		// Token: 0x040019A7 RID: 6567
		public static BaseImage com_32_pitch = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_pitch.png");

		// Token: 0x040019A8 RID: 6568
		public static BaseImage com_32_research = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_research.png");

		// Token: 0x040019A9 RID: 6569
		public static BaseImage com_32_salt = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_salt.png");

		// Token: 0x040019AA RID: 6570
		public static BaseImage com_32_silk = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_silk.png");

		// Token: 0x040019AB RID: 6571
		public static BaseImage com_32_spice = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_spice.png");

		// Token: 0x040019AC RID: 6572
		public static BaseImage com_32_stone = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_stone.png");

		// Token: 0x040019AD RID: 6573
		public static BaseImage com_32_swords = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_swords.png");

		// Token: 0x040019AE RID: 6574
		public static BaseImage com_32_veg = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_veg.png");

		// Token: 0x040019AF RID: 6575
		public static BaseImage com_32_venison = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_venison.png");

		// Token: 0x040019B0 RID: 6576
		public static BaseImage com_32_wine = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_wine.png");

		// Token: 0x040019B1 RID: 6577
		public static BaseImage com_32_wood = new BaseImage(AssetPaths.AssetIconsMainResources, "com_32_wood.png");

		// Token: 0x040019B2 RID: 6578
		public static BaseImage ContextMenuBackground = new BaseImage(AssetPaths.AssetIconsMainResources, "ContextMenuBackground.png");

		// Token: 0x040019B3 RID: 6579
		public static BaseImage int_world_icon_castle = new BaseImage(AssetPaths.AssetIconsMainResources, "int_world_icon_castle.png");

		// Token: 0x040019B4 RID: 6580
		public static BaseImage int_world_icon_no_attack = new BaseImage(AssetPaths.AssetIconsMainResources, "int_world_icon_no_attack.png");

		// Token: 0x040019B5 RID: 6581
		public static BaseImage int_world_icon_resource = new BaseImage(AssetPaths.AssetIconsMainResources, "int_world_icon_resource.png");

		// Token: 0x040019B6 RID: 6582
		public static BaseImage int_world_icon_troops = new BaseImage(AssetPaths.AssetIconsMainResources, "int_world_icon_troops.png");

		// Token: 0x040019B7 RID: 6583
		public static BaseImage int_world_icon_village = new BaseImage(AssetPaths.AssetIconsMainResources, "int_world_icon_village.png");

		// Token: 0x040019B8 RID: 6584
		public static BaseImage mail_menubar_closed = new BaseImage(AssetPaths.AssetIconsMainResources, "mail_menubar_closed.png");

		// Token: 0x040019B9 RID: 6585
		public static BaseImage mail_menubar_closed_bright = new BaseImage(AssetPaths.AssetIconsMainResources, "mail_menubar_closed_bright.png");

		// Token: 0x040019BA RID: 6586
		public static BaseImage mail_menubar_open = new BaseImage(AssetPaths.AssetIconsMainResources, "mail_menubar_open.png");

		// Token: 0x040019BB RID: 6587
		public static BaseImage mail_menubar_open_bright = new BaseImage(AssetPaths.AssetIconsMainResources, "mail_menubar_open_bright.png");

		// Token: 0x040019BC RID: 6588
		public static BaseImage MainWindowBackground_paper = new BaseImage(AssetPaths.AssetIconsMainResources, "MainWindowBackground_paper.png");

		// Token: 0x040019BD RID: 6589
		public static BaseImage menu_Background = new BaseImage(AssetPaths.AssetIconsMainResources, "menu_Background.png");

		// Token: 0x040019BE RID: 6590
		public static BaseImage menubar_connecter_left = new BaseImage(AssetPaths.AssetIconsMainResources, "menubar_connecter_left.png");

		// Token: 0x040019BF RID: 6591
		public static BaseImage menubar_left_faith = new BaseImage(AssetPaths.AssetIconsMainResources, "menubar_left_faith.png");

		// Token: 0x040019C0 RID: 6592
		public static BaseImage menubar_middle = new BaseImage(AssetPaths.AssetIconsMainResources, "menubar_middle.png");

		// Token: 0x040019C1 RID: 6593
		public static BaseImage menubar_top = new BaseImage(AssetPaths.AssetIconsMainResources, "menubar_top.png");

		// Token: 0x040019C2 RID: 6594
		public static BaseImage ParishFlag = new BaseImage(AssetPaths.AssetIconsMainResources, "ParishFlag.png");

		// Token: 0x040019C3 RID: 6595
		public static BaseImage Plague_32x32 = new BaseImage(AssetPaths.AssetIconsMainResources, "Plague_32x32.png");

		// Token: 0x040019C4 RID: 6596
		public static BaseImage points_menubar_bright = new BaseImage(AssetPaths.AssetIconsMainResources, "points_menubar_bright.png");

		// Token: 0x040019C5 RID: 6597
		public static BaseImage points_menubar_normal = new BaseImage(AssetPaths.AssetIconsMainResources, "points_menubar_normal.png");

		// Token: 0x040019C6 RID: 6598
		public static BaseImage population_bed = new BaseImage(AssetPaths.AssetIconsMainResources, "population_bed.png");

		// Token: 0x040019C7 RID: 6599
		public static BaseImage population_head = new BaseImage(AssetPaths.AssetIconsMainResources, "population_head.png");

		// Token: 0x040019C8 RID: 6600
		public static BaseImage r_arrow_small_left_norm = new BaseImage(AssetPaths.AssetIconsMainResources, "r_arrow_small_left_norm.png");

		// Token: 0x040019C9 RID: 6601
		public static BaseImage r_arrow_small_left_over = new BaseImage(AssetPaths.AssetIconsMainResources, "r_arrow_small_left_over.png");

		// Token: 0x040019CA RID: 6602
		public static BaseImage r_arrow_small_right_norm = new BaseImage(AssetPaths.AssetIconsMainResources, "r_arrow_small_right_norm.png");

		// Token: 0x040019CB RID: 6603
		public static BaseImage r_arrow_small_right_over = new BaseImage(AssetPaths.AssetIconsMainResources, "r_arrow_small_right_over.png");

		// Token: 0x040019CC RID: 6604
		public static BaseImage ReadMail = new BaseImage(AssetPaths.AssetIconsMainResources, "ReadMail.png");

		// Token: 0x040019CD RID: 6605
		public static BaseImage contest_menubar_bright = new BaseImage(AssetPaths.AssetIconsMainResources, "contest_menubar_over.png");

		// Token: 0x040019CE RID: 6606
		public static BaseImage contest_menubar_normal = new BaseImage(AssetPaths.AssetIconsMainResources, "contest_menubar_normal.png");

		// Token: 0x040019CF RID: 6607
		public static BaseImage scroll_inset_bottom = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_inset_bottom.png");

		// Token: 0x040019D0 RID: 6608
		public static BaseImage scroll_inset_mid = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_inset_mid.png");

		// Token: 0x040019D1 RID: 6609
		public static BaseImage scroll_inset_top = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_inset_top.png");

		// Token: 0x040019D2 RID: 6610
		public static BaseImage scroll_thumb_bottom = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_thumb_bottom.png");

		// Token: 0x040019D3 RID: 6611
		public static BaseImage scroll_thumb_mid = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_thumb_mid.png");

		// Token: 0x040019D4 RID: 6612
		public static BaseImage scroll_thumb_top = new BaseImage(AssetPaths.AssetIconsMainResources, "scroll_thumb_top.png");

		// Token: 0x040019D5 RID: 6613
		public static BaseImage UnreadMail = new BaseImage(AssetPaths.AssetIconsMainResources, "UnreadMail.png");

		// Token: 0x040019D6 RID: 6614
		public static BaseImage villagename_body = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_body.png");

		// Token: 0x040019D7 RID: 6615
		public static BaseImage villagename_button_left_highlight = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_left_highlight.png");

		// Token: 0x040019D8 RID: 6616
		public static BaseImage villagename_button_left_normal = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_left_normal.png");

		// Token: 0x040019D9 RID: 6617
		public static BaseImage villagename_button_left_selected = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_left_selected.png");

		// Token: 0x040019DA RID: 6618
		public static BaseImage villagename_button_right_highlight = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_right_highlight.png");

		// Token: 0x040019DB RID: 6619
		public static BaseImage villagename_button_right_normal = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_right_normal.png");

		// Token: 0x040019DC RID: 6620
		public static BaseImage villagename_button_right_selected = new BaseImage(AssetPaths.AssetIconsMainResources, "villagename_button_right_selected.png");

		// Token: 0x040019DD RID: 6621
		public static BaseImage[] blue_screen_button_array = BaseImage.createFromUV(AssetPaths.AssetIconsMisc, "blue_screen_button_array", 6);

		// Token: 0x040019DE RID: 6622
		public static BaseImage[] villageOverviewIcons = BaseImage.createFromUV(AssetPaths.AssetIconsMisc, "Village_Overview_icons", 20);

		// Token: 0x040019DF RID: 6623
		public static BaseImage[] wl_moving_unit_icons = BaseImage.createFromUV(AssetPaths.AssetIconsMisc, "wl_moving_unit_icons", 59);

		// Token: 0x040019E0 RID: 6624
		public static BaseImage[] attack_tabs_comp = BaseImage.createFromUV(AssetPaths.AssetIconsMisc, "attack_tabs_comp", 15);

		// Token: 0x040019E1 RID: 6625
		public static BaseImage[] sea_conditions = BaseImage.createFromUV(AssetPaths.AssetIconsMisc, "seaconditions", 9);

		// Token: 0x040019E2 RID: 6626
		public static BaseImage aeriaPoints = new BaseImage(AssetPaths.AssetIconsMisc, "AeriaPoints");

		// Token: 0x040019E3 RID: 6627
		public static BaseImage facebookLogin_EN = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_EN.png");

		// Token: 0x040019E4 RID: 6628
		public static BaseImage facebookLogin_FR = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_fr.png");

		// Token: 0x040019E5 RID: 6629
		public static BaseImage facebookLogin_DE = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_de.png");

		// Token: 0x040019E6 RID: 6630
		public static BaseImage facebookLogin_RU = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_ru.png");

		// Token: 0x040019E7 RID: 6631
		public static BaseImage facebookLogin_ES = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_es.png");

		// Token: 0x040019E8 RID: 6632
		public static BaseImage facebookLogin_PL = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_pl.png");

		// Token: 0x040019E9 RID: 6633
		public static BaseImage facebookLogin_TR = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_tr.png");

		// Token: 0x040019EA RID: 6634
		public static BaseImage facebookLogin_IT = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_it.png");

		// Token: 0x040019EB RID: 6635
		public static BaseImage facebookLogin_PT = new BaseImage(AssetPaths.AssetIconsMisc, "FacebookLogin_pt.png");

		// Token: 0x040019EC RID: 6636
		public static BaseImage facebookGeneric = new BaseImage(AssetPaths.AssetIconsMisc, "Facebook_generic.png");

		// Token: 0x040019ED RID: 6637
		public static BaseImage r_popularity_panel_icon_ale_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_icon_ale_over.png");

		// Token: 0x040019EE RID: 6638
		public static BaseImage r_popularity_panel_icon_buildings_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_icon_buildings_over.png");

		// Token: 0x040019EF RID: 6639
		public static BaseImage r_popularity_panel_icon_housing_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_icon_housing_over.png");

		// Token: 0x040019F0 RID: 6640
		public static BaseImage r_popularity_panel_icon_rations_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_icon_rations_over.png");

		// Token: 0x040019F1 RID: 6641
		public static BaseImage r_popularity_panel_icon_taxes_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_icon_taxes_over.png");

		// Token: 0x040019F2 RID: 6642
		public static BaseImage r_popularity_panel_indent_b_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_indent_b_over.png");

		// Token: 0x040019F3 RID: 6643
		public static BaseImage r_popularity_panel_indent_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_indent_over.png");

		// Token: 0x040019F4 RID: 6644
		public static BaseImage r_popularity_panel_indent_a_over = new BaseImage(AssetPaths.AssetIconsMisc, "r_popularity_panel_indent_a_over.png");

		// Token: 0x040019F5 RID: 6645
		public static BaseImage mouse_help_middle_bottom = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_middle_bottom.png");

		// Token: 0x040019F6 RID: 6646
		public static BaseImage mouse_help_left_top = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_left_top.png");

		// Token: 0x040019F7 RID: 6647
		public static BaseImage mouse_help_left_middle = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_left_middle.png");

		// Token: 0x040019F8 RID: 6648
		public static BaseImage mouse_help_left_bottom = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_left_bottom.png");

		// Token: 0x040019F9 RID: 6649
		public static BaseImage mouse_help_right_top = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_right_top.png");

		// Token: 0x040019FA RID: 6650
		public static BaseImage mouse_help_right_middle = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_right_middle.png");

		// Token: 0x040019FB RID: 6651
		public static BaseImage mouse_help_right_bottom = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_right_bottom.png");

		// Token: 0x040019FC RID: 6652
		public static BaseImage mouse_help_middle_top = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_middle_top.png");

		// Token: 0x040019FD RID: 6653
		public static BaseImage mouse_help_middle_middle = new BaseImage(AssetPaths.AssetIconsMisc, "mouse_help_middle_middle.png");

		// Token: 0x040019FE RID: 6654
		public static BaseImage worldSelect_Background = new BaseImage(AssetPaths.AssetIconsMisc, "enter_world_lrg");

		// Token: 0x040019FF RID: 6655
		public static BaseImage worldSelect_manual_norm = new BaseImage(AssetPaths.AssetIconsMisc, "manual_up.png");

		// Token: 0x04001A00 RID: 6656
		public static BaseImage worldSelect_manual_over = new BaseImage(AssetPaths.AssetIconsMisc, "manual_over.png");

		// Token: 0x04001A01 RID: 6657
		public static BaseImage worldSelect_manual_pushed = new BaseImage(AssetPaths.AssetIconsMisc, "manual_down.png");

		// Token: 0x04001A02 RID: 6658
		public static BaseImage worldSelect_random_norm = new BaseImage(AssetPaths.AssetIconsMisc, "random_up.png");

		// Token: 0x04001A03 RID: 6659
		public static BaseImage worldSelect_random_over = new BaseImage(AssetPaths.AssetIconsMisc, "random_over.png");

		// Token: 0x04001A04 RID: 6660
		public static BaseImage worldSelect_random_pushed = new BaseImage(AssetPaths.AssetIconsMisc, "random_down.png");

		// Token: 0x04001A05 RID: 6661
		public static BaseImage world_select_map_en = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_a.png");

		// Token: 0x04001A06 RID: 6662
		public static BaseImage world_select_map_de = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_de.png");

		// Token: 0x04001A07 RID: 6663
		public static BaseImage world_select_map_fr = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_fr.png");

		// Token: 0x04001A08 RID: 6664
		public static BaseImage world_select_map_ru = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_ru.png");

		// Token: 0x04001A09 RID: 6665
		public static BaseImage world_select_map_sa = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_sa.png");

		// Token: 0x04001A0A RID: 6666
		public static BaseImage world_select_map_es = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_es.png");

		// Token: 0x04001A0B RID: 6667
		public static BaseImage world_select_map_pl = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_pl.png");

		// Token: 0x04001A0C RID: 6668
		public static BaseImage world_select_map_eu = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_eu.png");

		// Token: 0x04001A0D RID: 6669
		public static BaseImage world_select_map_tr = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_tr.png");

		// Token: 0x04001A0E RID: 6670
		public static BaseImage world_select_map_us = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_us.png");

		// Token: 0x04001A0F RID: 6671
		public static BaseImage world_select_map_it = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_it.png");

		// Token: 0x04001A10 RID: 6672
		public static BaseImage world_select_map_world = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_world.png");

		// Token: 0x04001A11 RID: 6673
		public static BaseImage world_select_map_china = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_China.png");

		// Token: 0x04001A12 RID: 6674
		public static BaseImage world_select_map_ph = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_ph.png");

		// Token: 0x04001A13 RID: 6675
		public static BaseImage world_select_map_kingmaker = new BaseImage(AssetPaths.AssetIconsMisc, "WorldMap_king.png");

		// Token: 0x04001A14 RID: 6676
		public static BaseImage world_list_background = new BaseImage(AssetPaths.AssetIconsMisc, "worldListBackground.png");

		// Token: 0x04001A15 RID: 6677
		public static BaseImage age_first_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_first_age_28x16");

		// Token: 0x04001A16 RID: 6678
		public static BaseImage age_first_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_first_age_x65");

		// Token: 0x04001A17 RID: 6679
		public static BaseImage age_second_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_second_age_28x16");

		// Token: 0x04001A18 RID: 6680
		public static BaseImage age_second_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_second_age_x65");

		// Token: 0x04001A19 RID: 6681
		public static BaseImage age_third_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_third_age_28x16");

		// Token: 0x04001A1A RID: 6682
		public static BaseImage age_third_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_third_age_x65");

		// Token: 0x04001A1B RID: 6683
		public static BaseImage age_fourth_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_fourth_age_58x30");

		// Token: 0x04001A1C RID: 6684
		public static BaseImage age_fourth_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_fourth_age_x65");

		// Token: 0x04001A1D RID: 6685
		public static BaseImage age_fifth_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_fifth_age_58x30");

		// Token: 0x04001A1E RID: 6686
		public static BaseImage age_fifth_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_fifth_age_x65");

		// Token: 0x04001A1F RID: 6687
		public static BaseImage age_sixth_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_sixth_age_58x30");

		// Token: 0x04001A20 RID: 6688
		public static BaseImage age_sixth_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_sixth_age_x65");

		// Token: 0x04001A21 RID: 6689
		public static BaseImage age_seventh_age_28x16 = new BaseImage(AssetPaths.AssetIconsMisc, "age_seventh_age_58x30");

		// Token: 0x04001A22 RID: 6690
		public static BaseImage age_seventh_age_x65 = new BaseImage(AssetPaths.AssetIconsMisc, "age_seventh_age_x65");

		// Token: 0x04001A23 RID: 6691
		public static BaseImage age_seventh_age_x130 = new BaseImage(AssetPaths.AssetIconsMisc, "age_seventh_300x130.png");

		// Token: 0x04001A24 RID: 6692
		public static BaseImage eow_globe = new BaseImage(AssetPaths.AssetIconsMisc, "globe.png");

		// Token: 0x04001A25 RID: 6693
		public static BaseImage secondAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_second_age.png");

		// Token: 0x04001A26 RID: 6694
		public static BaseImage thirdAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_third_age.png");

		// Token: 0x04001A27 RID: 6695
		public static BaseImage fourthAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_fourth_age.png");

		// Token: 0x04001A28 RID: 6696
		public static BaseImage fifthAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_fifth_age.png");

		// Token: 0x04001A29 RID: 6697
		public static BaseImage sixthAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_sixth_age.png");

		// Token: 0x04001A2A RID: 6698
		public static BaseImage seventhAgeLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_seventh_age.png");

		// Token: 0x04001A2B RID: 6699
		public static BaseImage dominationWorldLogo = new BaseImage(AssetPaths.AssetIconsMisc, "age_domination_age.png");

		// Token: 0x04001A2C RID: 6700
		public static BaseImage flag_blue_icon = new BaseImage(AssetPaths.AssetIconsMisc, "flag_blue_icon.png");

		// Token: 0x04001A2D RID: 6701
		public static BaseImage monk_icon = new BaseImage(AssetPaths.AssetIconsMisc, "monk_icon.png");

		// Token: 0x04001A2E RID: 6702
		public static BaseImage merchant_icon = new BaseImage(AssetPaths.AssetIconsMisc, "merchant_icon.png");

		// Token: 0x04001A2F RID: 6703
		public static BaseImage selector_square_normal = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_normal.png");

		// Token: 0x04001A30 RID: 6704
		public static BaseImage selector_square_over = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_over.png");

		// Token: 0x04001A31 RID: 6705
		public static BaseImage selector_square_pressed = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_pressed.png");

		// Token: 0x04001A32 RID: 6706
		public static BaseImage selector_square_orange_normal = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_orange_normal.png");

		// Token: 0x04001A33 RID: 6707
		public static BaseImage selector_square_orange_over = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_orange_over.png");

		// Token: 0x04001A34 RID: 6708
		public static BaseImage selector_square_orange_pressed = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_orange_pressed.png");

		// Token: 0x04001A35 RID: 6709
		public static BaseImage selector_square_red_normal = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_red_normal.png");

		// Token: 0x04001A36 RID: 6710
		public static BaseImage selector_square_red_over = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_red_over.png");

		// Token: 0x04001A37 RID: 6711
		public static BaseImage selector_square_red_pressed = new BaseImage(AssetPaths.AssetIconsMisc, "square_selector_red_pressed.png");

		// Token: 0x04001A38 RID: 6712
		public static BaseImage int_but_small_normal = new BaseImage(AssetPaths.AssetIconsMisc, "int_but_small_normal.png");

		// Token: 0x04001A39 RID: 6713
		public static BaseImage int_but_small_over = new BaseImage(AssetPaths.AssetIconsMisc, "int_but_small_over.png");

		// Token: 0x04001A3A RID: 6714
		public static BaseImage but_move_building_normal = new BaseImage(AssetPaths.AssetIconsMisc, "but_move-building_normal.png");

		// Token: 0x04001A3B RID: 6715
		public static BaseImage but_move_building_over = new BaseImage(AssetPaths.AssetIconsMisc, "but_move-building_over.png");

		// Token: 0x04001A3C RID: 6716
		public static BaseImage but_move_building_pushed = new BaseImage(AssetPaths.AssetIconsMisc, "but_move-building_pushed.png");

		// Token: 0x04001A3D RID: 6717
		public static BaseImage VillageTabBar_FORUM_Normal = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_FORUM_Normal.png");

		// Token: 0x04001A3E RID: 6718
		public static BaseImage VillageTabBar_FORUM_Selected = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_FORUM_Selected.png");

		// Token: 0x04001A3F RID: 6719
		public static BaseImage VillageTabBar_INFO_Normal = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_INFO_Normal.png");

		// Token: 0x04001A40 RID: 6720
		public static BaseImage VillageTabBar_INFO_Selected = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_INFO_Selected.png");

		// Token: 0x04001A41 RID: 6721
		public static BaseImage VillageTabBar_VOTE_Normal = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_VOTE_Normal.png");

		// Token: 0x04001A42 RID: 6722
		public static BaseImage VillageTabBar_VOTE_Selected = new BaseImage(AssetPaths.AssetIconsMisc, "VillageTabBar_VOTE_Selected.png");

		// Token: 0x04001A43 RID: 6723
		public static BaseImage icon_building = new BaseImage(AssetPaths.AssetIconsMisc, "icon_building");

		// Token: 0x04001A44 RID: 6724
		public static BaseImage icon_research = new BaseImage(AssetPaths.AssetIconsMisc, "icon_research");

		// Token: 0x04001A45 RID: 6725
		public static BaseImage messageboxtop = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_top");

		// Token: 0x04001A46 RID: 6726
		public static BaseImage messageboxtop_left = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_top_left");

		// Token: 0x04001A47 RID: 6727
		public static BaseImage messageboxtop_right = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_top_right");

		// Token: 0x04001A48 RID: 6728
		public static BaseImage messageboxtop_middle = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_top_middle");

		// Token: 0x04001A49 RID: 6729
		public static BaseImage messageboxclose = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_close");

		// Token: 0x04001A4A RID: 6730
		public static BaseImage messageboxclose_over = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_close_overl");

		// Token: 0x04001A4B RID: 6731
		public static BaseImage message_box_minimize_normal = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_minimize_normal");

		// Token: 0x04001A4C RID: 6732
		public static BaseImage message_box_minimize_over = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_minimize_over");

		// Token: 0x04001A4D RID: 6733
		public static BaseImage message_box_maximize_normal = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_maximize_normal");

		// Token: 0x04001A4E RID: 6734
		public static BaseImage message_box_maximize_over = new BaseImage(AssetPaths.AssetIconsMisc, "message_box_maximize_over");

		// Token: 0x04001A4F RID: 6735
		public static BaseImage misc_button_blue_210wide_normal = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_210wide_normal.png");

		// Token: 0x04001A50 RID: 6736
		public static BaseImage misc_button_blue_210wide_pushed = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_210wide_pushed.png");

		// Token: 0x04001A51 RID: 6737
		public static BaseImage misc_button_blue_210wide_over = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_210wide_over.png");

		// Token: 0x04001A52 RID: 6738
		public static BaseImage armies_screen_troops = new BaseImage(AssetPaths.AssetIconsMisc, "armies_screen_troops.png");

		// Token: 0x04001A53 RID: 6739
		public static BaseImage facebook = new BaseImage(AssetPaths.AssetIconsMisc, "facebook");

		// Token: 0x04001A54 RID: 6740
		public static BaseImage twitter = new BaseImage(AssetPaths.AssetIconsMisc, "twitter");

		// Token: 0x04001A55 RID: 6741
		public static BaseImage youtube = new BaseImage(AssetPaths.AssetIconsMisc, "youtube");

		// Token: 0x04001A56 RID: 6742
		public static BaseImage vk = new BaseImage(AssetPaths.AssetIconsMisc, "vkButton");

		// Token: 0x04001A57 RID: 6743
		public static BaseImage shieldOverlay_70x78 = new BaseImage(AssetPaths.AssetIconsMisc, "shield_overlay_70x78.png");

		// Token: 0x04001A58 RID: 6744
		public static BaseImage shieldOverlay_144x160 = new BaseImage(AssetPaths.AssetIconsMisc, "shield_overlay_144x160.png");

		// Token: 0x04001A59 RID: 6745
		public static BaseImage shieldOverlay_56x64 = new BaseImage(AssetPaths.AssetIconsMisc, "shield_overlay_56x64.png");

		// Token: 0x04001A5A RID: 6746
		public static BaseImage shieldOverlay_32x36 = new BaseImage(AssetPaths.AssetIconsMisc, "shield_overlay_32x36.png");

		// Token: 0x04001A5B RID: 6747
		public static BaseImage shieldOverlay_25x28 = new BaseImage(AssetPaths.AssetIconsMisc, "shield_overlay_25x28.png");

		// Token: 0x04001A5C RID: 6748
		public static BaseImage villageOverTab_down = new BaseImage(AssetPaths.AssetIconsMisc, "Village_Overview_tab_down");

		// Token: 0x04001A5D RID: 6749
		public static BaseImage villageOverTab_up = new BaseImage(AssetPaths.AssetIconsMisc, "Village_Overview_tab_up");

		// Token: 0x04001A5E RID: 6750
		public static BaseImage premium_menubar_normal = new BaseImage(AssetPaths.AssetIconsMisc, "premium_menubar_normal.png");

		// Token: 0x04001A5F RID: 6751
		public static BaseImage premium_menubar_over = new BaseImage(AssetPaths.AssetIconsMisc, "premium_menubar_over.png");

		// Token: 0x04001A60 RID: 6752
		public static BaseImage _9sclice_fancy_bottom_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_bottom_left");

		// Token: 0x04001A61 RID: 6753
		public static BaseImage _9sclice_fancy_bottom_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_bottom_mid");

		// Token: 0x04001A62 RID: 6754
		public static BaseImage _9sclice_fancy_bottom_mid_over = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_bottom_mid_over");

		// Token: 0x04001A63 RID: 6755
		public static BaseImage _9sclice_fancy_bottom_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_bottom_right");

		// Token: 0x04001A64 RID: 6756
		public static BaseImage _9sclice_fancy_mid_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_mid_left");

		// Token: 0x04001A65 RID: 6757
		public static BaseImage _9sclice_fancy_mid_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_mid_mid");

		// Token: 0x04001A66 RID: 6758
		public static BaseImage _9sclice_fancy_mid_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_mid_right");

		// Token: 0x04001A67 RID: 6759
		public static BaseImage _9sclice_fancy_top_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_left");

		// Token: 0x04001A68 RID: 6760
		public static BaseImage _9sclice_fancy_top_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_mid");

		// Token: 0x04001A69 RID: 6761
		public static BaseImage _9sclice_fancy_top_mid_over_01 = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_mid_over_01");

		// Token: 0x04001A6A RID: 6762
		public static BaseImage _9sclice_fancy_top_mid_over_02 = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_mid_over_02");

		// Token: 0x04001A6B RID: 6763
		public static BaseImage _9sclice_fancy_top_mid_over_03 = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_mid_over_03");

		// Token: 0x04001A6C RID: 6764
		public static BaseImage _9sclice_fancy_top_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_fancy_top_right");

		// Token: 0x04001A6D RID: 6765
		public static BaseImage worldSelect_swap_norm = new BaseImage(AssetPaths.AssetIconsMisc, "swap_world_up.png");

		// Token: 0x04001A6E RID: 6766
		public static BaseImage worldSelect_swap_over = new BaseImage(AssetPaths.AssetIconsMisc, "swap_world_over.png");

		// Token: 0x04001A6F RID: 6767
		public static BaseImage worldSelect_swap_pushed = new BaseImage(AssetPaths.AssetIconsMisc, "swap_world_down.png");

		// Token: 0x04001A70 RID: 6768
		public static BaseImage pt_rank = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Rank_up.png");

		// Token: 0x04001A71 RID: 6769
		public static BaseImage pt_Quests = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Quests_up.png");

		// Token: 0x04001A72 RID: 6770
		public static BaseImage pt_Parish_Wall = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Parish_wall_up.png");

		// Token: 0x04001A73 RID: 6771
		public static BaseImage pt_Mail = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Mail_up.png");

		// Token: 0x04001A74 RID: 6772
		public static BaseImage pt_Invite_a_Friend = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Invite_a_friend_up.png");

		// Token: 0x04001A75 RID: 6773
		public static BaseImage pt_Coat_of_Arms = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Coat_of_arms_up.png");

		// Token: 0x04001A76 RID: 6774
		public static BaseImage pt_Avatar = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Avatar_up.png");

		// Token: 0x04001A77 RID: 6775
		public static BaseImage pt_Achievements = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Achievements_up.png");

		// Token: 0x04001A78 RID: 6776
		public static BaseImage pt_Research = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Research_up.png");

		// Token: 0x04001A79 RID: 6777
		public static BaseImage pt_Reports = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Reports_up.png");

		// Token: 0x04001A7A RID: 6778
		public static BaseImage pt_rank_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Rank_down.png");

		// Token: 0x04001A7B RID: 6779
		public static BaseImage pt_Quests_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Quest_down.png");

		// Token: 0x04001A7C RID: 6780
		public static BaseImage pt_Parish_Wall_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Parish_wall_down.png");

		// Token: 0x04001A7D RID: 6781
		public static BaseImage pt_Mail_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Mail_down.png");

		// Token: 0x04001A7E RID: 6782
		public static BaseImage pt_Invite_a_Friend_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Invite_a_friend_down.png");

		// Token: 0x04001A7F RID: 6783
		public static BaseImage pt_Coat_of_Arms_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Coat_of_arms_down.png");

		// Token: 0x04001A80 RID: 6784
		public static BaseImage pt_Avatar_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Avatar_down.png");

		// Token: 0x04001A81 RID: 6785
		public static BaseImage pt_Achievements_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Achievements_down.png");

		// Token: 0x04001A82 RID: 6786
		public static BaseImage pt_Research_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Research_down.png");

		// Token: 0x04001A83 RID: 6787
		public static BaseImage pt_Reports_down = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Reports_down.png");

		// Token: 0x04001A84 RID: 6788
		public static BaseImage pt_rank_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Rank_over.png");

		// Token: 0x04001A85 RID: 6789
		public static BaseImage pt_Quests_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Quests_over.png");

		// Token: 0x04001A86 RID: 6790
		public static BaseImage pt_Parish_Wall_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Parish_wall_over.png");

		// Token: 0x04001A87 RID: 6791
		public static BaseImage pt_Mail_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Mail_over.png");

		// Token: 0x04001A88 RID: 6792
		public static BaseImage pt_Invite_a_Friend_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Invite_a_friend_over.png");

		// Token: 0x04001A89 RID: 6793
		public static BaseImage pt_Coat_of_Arms_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Coat_of_arms_over.png");

		// Token: 0x04001A8A RID: 6794
		public static BaseImage pt_Avatar_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Avatar_over.png");

		// Token: 0x04001A8B RID: 6795
		public static BaseImage pt_Achievements_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Achievements_over.png");

		// Token: 0x04001A8C RID: 6796
		public static BaseImage pt_Research_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Research_over.png");

		// Token: 0x04001A8D RID: 6797
		public static BaseImage pt_Reports_over = new BaseImage(AssetPaths.AssetIconsMisc, "pt_Reports_over.png");

		// Token: 0x04001A8E RID: 6798
		public static BaseImage facebookBlueNorm = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_fb_141wide_normal.png");

		// Token: 0x04001A8F RID: 6799
		public static BaseImage facebookBlueOver = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_fb_141wide_over.png");

		// Token: 0x04001A90 RID: 6800
		public static BaseImage facebookBlueClick = new BaseImage(AssetPaths.AssetIconsMisc, "button_blue_fb_141wide_pushed.png");

		// Token: 0x04001A91 RID: 6801
		public static BaseImage facebookBrownNorm = new BaseImage(AssetPaths.AssetIconsMisc, "button_brown_fb_141wide_normal.png");

		// Token: 0x04001A92 RID: 6802
		public static BaseImage facebookBrownOver = new BaseImage(AssetPaths.AssetIconsMisc, "button_brown_fb_141wide_over.png");

		// Token: 0x04001A93 RID: 6803
		public static BaseImage facebookBrownClick = new BaseImage(AssetPaths.AssetIconsMisc, "button_brown_fb_141wide_pushed.png");

		// Token: 0x04001A94 RID: 6804
		public static BaseImage dominationEnd = new BaseImage(AssetPaths.AssetIconsMisc, "dominationEnd2.png");

		// Token: 0x04001A95 RID: 6805
		public static BaseImage HOLlink = new BaseImage(AssetPaths.AssetIconsMisc, "HOL_button.png");

		// Token: 0x04001A96 RID: 6806
		public static BaseImage playbackBackground = new BaseImage(AssetPaths.AssetIconsMisc, "playback_background.png");

		// Token: 0x04001A97 RID: 6807
		public static BaseImage playbackPlay = new BaseImage(AssetPaths.AssetIconsMisc, "playback_play.png");

		// Token: 0x04001A98 RID: 6808
		public static BaseImage playbackPause = new BaseImage(AssetPaths.AssetIconsMisc, "playback_pause.png");

		// Token: 0x04001A99 RID: 6809
		public static BaseImage playbackStop = new BaseImage(AssetPaths.AssetIconsMisc, "playback_stop.png");

		// Token: 0x04001A9A RID: 6810
		public static BaseImage playbackSpeed1 = new BaseImage(AssetPaths.AssetIconsMisc, "playback_speed1.png");

		// Token: 0x04001A9B RID: 6811
		public static BaseImage playbackSpeed2 = new BaseImage(AssetPaths.AssetIconsMisc, "playback_speed2.png");

		// Token: 0x04001A9C RID: 6812
		public static BaseImage playbackSpeed4 = new BaseImage(AssetPaths.AssetIconsMisc, "playback_speed4.png");

		// Token: 0x04001A9D RID: 6813
		public static BaseImage playbackTrack = new BaseImage(AssetPaths.AssetIconsMisc, "playback_track.png");

		// Token: 0x04001A9E RID: 6814
		public static BaseImage playbackBlank = new BaseImage(AssetPaths.AssetIconsMisc, "playback_blank.png");

		// Token: 0x04001A9F RID: 6815
		public static BaseImage playbackExpand = new BaseImage(AssetPaths.AssetIconsMisc, "playback_expand.png");

		// Token: 0x04001AA0 RID: 6816
		public static BaseImage playbackContract = new BaseImage(AssetPaths.AssetIconsMisc, "playback_contract.png");

		// Token: 0x04001AA1 RID: 6817
		public static BaseImage _9sclice_generic_bottom_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_bottom_left");

		// Token: 0x04001AA2 RID: 6818
		public static BaseImage _9sclice_generic_bottom_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_bottom_mid");

		// Token: 0x04001AA3 RID: 6819
		public static BaseImage _9sclice_generic_bottom_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_bottom_right");

		// Token: 0x04001AA4 RID: 6820
		public static BaseImage _9sclice_generic_mid_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_mid_left");

		// Token: 0x04001AA5 RID: 6821
		public static BaseImage _9sclice_generic_mid_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_mid_mid");

		// Token: 0x04001AA6 RID: 6822
		public static BaseImage _9sclice_generic_mid_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_mid_right");

		// Token: 0x04001AA7 RID: 6823
		public static BaseImage _9sclice_generic_top_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_top_left");

		// Token: 0x04001AA8 RID: 6824
		public static BaseImage _9sclice_generic_top_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_top_mid");

		// Token: 0x04001AA9 RID: 6825
		public static BaseImage _9sclice_generic_top_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_generic_top_right");

		// Token: 0x04001AAA RID: 6826
		public static BaseImage _9sclice_bracket_bottom_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_bracket_bottom_left");

		// Token: 0x04001AAB RID: 6827
		public static BaseImage _9sclice_bracket_bottom_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_bracket_bottom_right");

		// Token: 0x04001AAC RID: 6828
		public static BaseImage _9sclice_bracket_mid_mid = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_bracket_mid_mid");

		// Token: 0x04001AAD RID: 6829
		public static BaseImage _9sclice_bracket_top_left = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_bracket_top_left");

		// Token: 0x04001AAE RID: 6830
		public static BaseImage _9sclice_bracket_top_right = new BaseImage(AssetPaths.AssetIconsMisc, "nineslice_bracket_top_right");

		// Token: 0x04001AAF RID: 6831
		public static BaseImage prizeGold = new BaseImage(AssetPaths.AssetIconsMisc, "prizeGold");

		// Token: 0x04001AB0 RID: 6832
		public static BaseImage prizeFaith = new BaseImage(AssetPaths.AssetIconsMisc, "prizeFaith");

		// Token: 0x04001AB1 RID: 6833
		public static BaseImage prizeHonour = new BaseImage(AssetPaths.AssetIconsMisc, "prizeHonour");

		// Token: 0x04001AB2 RID: 6834
		public static BaseImage prizeCardPack = new BaseImage(AssetPaths.AssetIconsMisc, "prizeCardPack");

		// Token: 0x04001AB3 RID: 6835
		public static BaseImage prizeReputation = new BaseImage(AssetPaths.AssetIconsMisc, "prizeReputation");

		// Token: 0x04001AB4 RID: 6836
		public static BaseImage prizeTokens = new BaseImage(AssetPaths.AssetIconsMisc, "prizeTokens");

		// Token: 0x04001AB5 RID: 6837
		public static BaseImage prizeWheelspins = new BaseImage(AssetPaths.AssetIconsMisc, "prizeWheelspins");

		// Token: 0x04001AB6 RID: 6838
		public static BaseImage prizeShield = new BaseImage(AssetPaths.AssetIconsMisc, "prizeShield");

		// Token: 0x04001AB7 RID: 6839
		public static BaseImage prizeBlank = new BaseImage(AssetPaths.AssetIconsMisc, "prizeBlank");

		// Token: 0x04001AB8 RID: 6840
		public static BaseImage prizePremium = new BaseImage(AssetPaths.AssetIconsMisc, "prizePremium");

		// Token: 0x04001AB9 RID: 6841
		public static BaseImage prizePremium2 = new BaseImage(AssetPaths.AssetIconsMisc, "prizePremium2");

		// Token: 0x04001ABA RID: 6842
		public static BaseImage prizePremium7 = new BaseImage(AssetPaths.AssetIconsMisc, "prizePremium7");

		// Token: 0x04001ABB RID: 6843
		public static BaseImage prizePremium30 = new BaseImage(AssetPaths.AssetIconsMisc, "prizePremium30");

		// Token: 0x04001ABC RID: 6844
		public static BaseImage prizeSpin1 = new BaseImage(AssetPaths.AssetIconsMisc, "prizeSpin1");

		// Token: 0x04001ABD RID: 6845
		public static BaseImage prizeSpin2 = new BaseImage(AssetPaths.AssetIconsMisc, "prizeSpin2");

		// Token: 0x04001ABE RID: 6846
		public static BaseImage prizeSpin3 = new BaseImage(AssetPaths.AssetIconsMisc, "prizeSpin3");

		// Token: 0x04001ABF RID: 6847
		public static BaseImage prizeSpin4 = new BaseImage(AssetPaths.AssetIconsMisc, "prizeSpin4");

		// Token: 0x04001AC0 RID: 6848
		public static BaseImage prizeSpin5 = new BaseImage(AssetPaths.AssetIconsMisc, "prizeSpin5");

		// Token: 0x04001AC1 RID: 6849
		public static BaseImage contestSupportHorse = new BaseImage(AssetPaths.AssetIconsMisc, "contestSupportHorse");

		// Token: 0x04001AC2 RID: 6850
		public static BaseImage contestSupportLion = new BaseImage(AssetPaths.AssetIconsMisc, "contestSupportLion");

		// Token: 0x04001AC3 RID: 6851
		public static BaseImage contestTrumpetLeft = new BaseImage(AssetPaths.AssetIconsMisc, "contestTrumpetLeft");

		// Token: 0x04001AC4 RID: 6852
		public static BaseImage contestTrumpetRight = new BaseImage(AssetPaths.AssetIconsMisc, "contestTrumpetRight");

		// Token: 0x04001AC5 RID: 6853
		public static BaseImage contestTrumpetLeftSmall = new BaseImage(AssetPaths.AssetIconsMisc, "contestTrumpetLeftSmall");

		// Token: 0x04001AC6 RID: 6854
		public static BaseImage contestTrumpetRightSmall = new BaseImage(AssetPaths.AssetIconsMisc, "contestTrumpetRightSmall");

		// Token: 0x04001AC7 RID: 6855
		public static BaseImage contestTitleLeft = new BaseImage(AssetPaths.AssetIconsMisc, "contest_title_bar_left");

		// Token: 0x04001AC8 RID: 6856
		public static BaseImage contestTitleMid = new BaseImage(AssetPaths.AssetIconsMisc, "contest_title_bar_mid");

		// Token: 0x04001AC9 RID: 6857
		public static BaseImage contestTitleRight = new BaseImage(AssetPaths.AssetIconsMisc, "contest_title_bar_right");

		// Token: 0x04001ACA RID: 6858
		public static BaseImage contestArrowLeft = new BaseImage(AssetPaths.AssetIconsMisc, "contestLeftArrow");

		// Token: 0x04001ACB RID: 6859
		public static BaseImage contestArrowRight = new BaseImage(AssetPaths.AssetIconsMisc, "contestRightArrow");

		// Token: 0x04001ACC RID: 6860
		public static BaseImage castle_damage = new BaseImage(AssetPaths.AssetIconsMisc, "castle_damage");

		// Token: 0x04001ACD RID: 6861
		public static BaseImage research_border_research_ill_normal = new BaseImage(AssetPaths.AssetIconsResearch, "border_research_ill_normal.png");

		// Token: 0x04001ACE RID: 6862
		public static BaseImage research_border_research_ill_over = new BaseImage(AssetPaths.AssetIconsResearch, "border_research_ill_over.png");

		// Token: 0x04001ACF RID: 6863
		public static BaseImage research_tech_tree_inset_54_tall_left = new BaseImage(AssetPaths.AssetIconsResearch, "tech-tree_inset_54-tall_left.png");

		// Token: 0x04001AD0 RID: 6864
		public static BaseImage research_tech_tree_inset_54_tall_mid = new BaseImage(AssetPaths.AssetIconsResearch, "tech-tree_inset_54-tall_mid.png");

		// Token: 0x04001AD1 RID: 6865
		public static BaseImage research_tech_tree_inset_54_tall_right = new BaseImage(AssetPaths.AssetIconsResearch, "tech-tree_inset_54-tall_right.png");

		// Token: 0x04001AD2 RID: 6866
		public static BaseImage tech_tree_dots_yellow_x16 = new BaseImage(AssetPaths.AssetIconsResearch, "tech_tree_dots_yellow_x16.png");

		// Token: 0x04001AD3 RID: 6867
		public static BaseImage mix_ycf_0001_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_0001-bl_0010.png");

		// Token: 0x04001AD4 RID: 6868
		public static BaseImage mix_ycf_0001_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_0001-bl_0100.png");

		// Token: 0x04001AD5 RID: 6869
		public static BaseImage mix_ycf_0001_bl_0110 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_0001-bl_0110.png");

		// Token: 0x04001AD6 RID: 6870
		public static BaseImage mix_ycf_0011_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_0011-bl_0100.png");

		// Token: 0x04001AD7 RID: 6871
		public static BaseImage mix_ycf_0101_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_0101-bl_0010.png");

		// Token: 0x04001AD8 RID: 6872
		public static BaseImage mix_ych_0001_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ych_0001-bl_0010.png");

		// Token: 0x04001AD9 RID: 6873
		public static BaseImage mix_ych_0001_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ych_0001-bl_0100.png");

		// Token: 0x04001ADA RID: 6874
		public static BaseImage mix_ych_0001_bl_0110 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ych_0001-bl_0110.png");

		// Token: 0x04001ADB RID: 6875
		public static BaseImage ycf_0001 = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0001.png");

		// Token: 0x04001ADC RID: 6876
		public static BaseImage ycf_0011 = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0011.png");

		// Token: 0x04001ADD RID: 6877
		public static BaseImage ycf_0101 = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0101.png");

		// Token: 0x04001ADE RID: 6878
		public static BaseImage ycf_0111 = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0111.png");

		// Token: 0x04001ADF RID: 6879
		public static BaseImage ych_0001 = new BaseImage(AssetPaths.AssetIconsResearch, "ych_0001.png");

		// Token: 0x04001AE0 RID: 6880
		public static BaseImage yline_1100 = new BaseImage(AssetPaths.AssetIconsResearch, "yline_1100.png");

		// Token: 0x04001AE1 RID: 6881
		public static BaseImage yline_1110 = new BaseImage(AssetPaths.AssetIconsResearch, "yline_1110.png");

		// Token: 0x04001AE2 RID: 6882
		public static BaseImage yline_vertical = new BaseImage(AssetPaths.AssetIconsResearch, "yline_vertical.png");

		// Token: 0x04001AE3 RID: 6883
		public static BaseImage ill_back_yline_1100 = new BaseImage(AssetPaths.AssetIconsResearch, "ill_back_yline_1100.png");

		// Token: 0x04001AE4 RID: 6884
		public static BaseImage ill_back_yline_0101 = new BaseImage(AssetPaths.AssetIconsResearch, "ill_back_yline_0101.png");

		// Token: 0x04001AE5 RID: 6885
		public static BaseImage ill_back_yellow_textback = new BaseImage(AssetPaths.AssetIconsResearch, "ill_back_yellow_textback.png");

		// Token: 0x04001AE6 RID: 6886
		public static BaseImage ycf_01gG = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_01gG.png");

		// Token: 0x04001AE7 RID: 6887
		public static BaseImage ycf_0g1G = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0g1G.png");

		// Token: 0x04001AE8 RID: 6888
		public static BaseImage ycf_011G = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_011G.png");

		// Token: 0x04001AE9 RID: 6889
		public static BaseImage ycf_010G = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_010G.png");

		// Token: 0x04001AEA RID: 6890
		public static BaseImage ycf_001G = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_001G.png");

		// Token: 0x04001AEB RID: 6891
		public static BaseImage ycf_0ggG = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_0ggG.png");

		// Token: 0x04001AEC RID: 6892
		public static BaseImage ycf_000G = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_000G.png");

		// Token: 0x04001AED RID: 6893
		public static BaseImage mix_ycf_000G_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch, "mix-ycf_000G-bl_0100.png");

		// Token: 0x04001AEE RID: 6894
		public static BaseImage ycf_00gG = new BaseImage(AssetPaths.AssetIconsResearch, "ycf_00gG.png");

		// Token: 0x04001AEF RID: 6895
		public static BaseImage border_research_ill_selected_normal = new BaseImage(AssetPaths.AssetIconsResearch, "border_research_ill_selected_normal.png");

		// Token: 0x04001AF0 RID: 6896
		public static BaseImage[] tech_numbers = BaseImage.createFromUV(AssetPaths.AssetIconsResearch2, "numbers_array", 30);

		// Token: 0x04001AF1 RID: 6897
		public static BaseImage bcf_0000 = new BaseImage(AssetPaths.AssetIconsResearch2, "bcf_0000.png");

		// Token: 0x04001AF2 RID: 6898
		public static BaseImage bcf_0001 = new BaseImage(AssetPaths.AssetIconsResearch2, "bcf_0001.png");

		// Token: 0x04001AF3 RID: 6899
		public static BaseImage bcf_0011 = new BaseImage(AssetPaths.AssetIconsResearch2, "bcf_0011.png");

		// Token: 0x04001AF4 RID: 6900
		public static BaseImage bcf_0101 = new BaseImage(AssetPaths.AssetIconsResearch2, "bcf_0101.png");

		// Token: 0x04001AF5 RID: 6901
		public static BaseImage bcf_0111 = new BaseImage(AssetPaths.AssetIconsResearch2, "bcf_0111.png");

		// Token: 0x04001AF6 RID: 6902
		public static BaseImage bline_vertical = new BaseImage(AssetPaths.AssetIconsResearch2, "bline_vertical.png");

		// Token: 0x04001AF7 RID: 6903
		public static BaseImage gcf_0001 = new BaseImage(AssetPaths.AssetIconsResearch2, "gcf_0001.png");

		// Token: 0x04001AF8 RID: 6904
		public static BaseImage gcf_0011 = new BaseImage(AssetPaths.AssetIconsResearch2, "gcf_0011.png");

		// Token: 0x04001AF9 RID: 6905
		public static BaseImage gcf_0101 = new BaseImage(AssetPaths.AssetIconsResearch2, "gcf_0101.png");

		// Token: 0x04001AFA RID: 6906
		public static BaseImage gcf_0111 = new BaseImage(AssetPaths.AssetIconsResearch2, "gcf_0111.png");

		// Token: 0x04001AFB RID: 6907
		public static BaseImage gch_0001 = new BaseImage(AssetPaths.AssetIconsResearch2, "gch_0001.png");

		// Token: 0x04001AFC RID: 6908
		public static BaseImage gch_0011 = new BaseImage(AssetPaths.AssetIconsResearch2, "gch_0011.png");

		// Token: 0x04001AFD RID: 6909
		public static BaseImage gch_0101 = new BaseImage(AssetPaths.AssetIconsResearch2, "gch_0101.png");

		// Token: 0x04001AFE RID: 6910
		public static BaseImage gch_0111 = new BaseImage(AssetPaths.AssetIconsResearch2, "gch_0111.png");

		// Token: 0x04001AFF RID: 6911
		public static BaseImage gline_1100 = new BaseImage(AssetPaths.AssetIconsResearch2, "gline_1100.png");

		// Token: 0x04001B00 RID: 6912
		public static BaseImage gline_1110 = new BaseImage(AssetPaths.AssetIconsResearch2, "gline_1110.png");

		// Token: 0x04001B01 RID: 6913
		public static BaseImage gline_vertical = new BaseImage(AssetPaths.AssetIconsResearch2, "gline_vertical.png");

		// Token: 0x04001B02 RID: 6914
		public static BaseImage ill_back_bline_0000 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0000.png");

		// Token: 0x04001B03 RID: 6915
		public static BaseImage ill_back_bline_0001 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0001.png");

		// Token: 0x04001B04 RID: 6916
		public static BaseImage ill_back_bline_0010 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0010.png");

		// Token: 0x04001B05 RID: 6917
		public static BaseImage ill_back_bline_0011 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0011.png");

		// Token: 0x04001B06 RID: 6918
		public static BaseImage ill_back_bline_0100 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0100.png");

		// Token: 0x04001B07 RID: 6919
		public static BaseImage ill_back_bline_0101 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0101.png");

		// Token: 0x04001B08 RID: 6920
		public static BaseImage ill_back_bline_0110 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_0110.png");

		// Token: 0x04001B09 RID: 6921
		public static BaseImage ill_back_bline_1000 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_1000.png");

		// Token: 0x04001B0A RID: 6922
		public static BaseImage ill_back_bline_1001 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_1001.png");

		// Token: 0x04001B0B RID: 6923
		public static BaseImage ill_back_bline_1010 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_1010.png");

		// Token: 0x04001B0C RID: 6924
		public static BaseImage ill_back_bline_1100 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_bline_1100.png");

		// Token: 0x04001B0D RID: 6925
		public static BaseImage ill_back_gline_0001 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0001.png");

		// Token: 0x04001B0E RID: 6926
		public static BaseImage ill_back_gline_0010 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0010.png");

		// Token: 0x04001B0F RID: 6927
		public static BaseImage ill_back_gline_0011 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0011.png");

		// Token: 0x04001B10 RID: 6928
		public static BaseImage ill_back_gline_0100 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0100.png");

		// Token: 0x04001B11 RID: 6929
		public static BaseImage ill_back_gline_0101 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0101.png");

		// Token: 0x04001B12 RID: 6930
		public static BaseImage ill_back_gline_0110 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_0110.png");

		// Token: 0x04001B13 RID: 6931
		public static BaseImage ill_back_gline_1000 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_1000.png");

		// Token: 0x04001B14 RID: 6932
		public static BaseImage ill_back_gline_1001 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_1001.png");

		// Token: 0x04001B15 RID: 6933
		public static BaseImage ill_back_gline_1010 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_1010.png");

		// Token: 0x04001B16 RID: 6934
		public static BaseImage ill_back_gline_1100 = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_gline_1100.png");

		// Token: 0x04001B17 RID: 6935
		public static BaseImage ill_back_green_textback = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_back_green_textback.png");

		// Token: 0x04001B18 RID: 6936
		public static BaseImage ill_shield = new BaseImage(AssetPaths.AssetIconsResearch2, "ill_shield.png");

		// Token: 0x04001B19 RID: 6937
		public static BaseImage mix_gcf_0001_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gcf_0001-bl_0010.png");

		// Token: 0x04001B1A RID: 6938
		public static BaseImage mix_gcf_0001_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gcf_0001-bl_0100.png");

		// Token: 0x04001B1B RID: 6939
		public static BaseImage mix_gcf_0001_bl_0110 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gcf_0001-bl_0110.png");

		// Token: 0x04001B1C RID: 6940
		public static BaseImage mix_gcf_0011_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gcf_0011-bl_0100.png");

		// Token: 0x04001B1D RID: 6941
		public static BaseImage mix_gcf_0101_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gcf_0101-bl_0010.png");

		// Token: 0x04001B1E RID: 6942
		public static BaseImage mix_gch_0001_bl_0010 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gch_0001-bl_0010.png");

		// Token: 0x04001B1F RID: 6943
		public static BaseImage mix_gch_0001_bl_0100 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gch_0001-bl_0100.png");

		// Token: 0x04001B20 RID: 6944
		public static BaseImage mix_gch_0001_bl_0110 = new BaseImage(AssetPaths.AssetIconsResearch2, "mix-gch_0001-bl_0110.png");

		// Token: 0x04001B21 RID: 6945
		public static BaseImage tech_list_but_big_in = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-list_but_big_in.png");

		// Token: 0x04001B22 RID: 6946
		public static BaseImage tech_list_but_big_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-list_but_big_normal.png");

		// Token: 0x04001B23 RID: 6947
		public static BaseImage tech_list_but_big_over = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-list_but_big_over.png");

		// Token: 0x04001B24 RID: 6948
		public static BaseImage tech_list_insets_X2 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-list_insets_X2.png");

		// Token: 0x04001B25 RID: 6949
		public static BaseImage tech_number_10_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_10_green.png");

		// Token: 0x04001B26 RID: 6950
		public static BaseImage tech_number_10_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_10_olive.png");

		// Token: 0x04001B27 RID: 6951
		public static BaseImage tech_number_10_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_10_tan.png");

		// Token: 0x04001B28 RID: 6952
		public static BaseImage tech_number_11_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_11_green.png");

		// Token: 0x04001B29 RID: 6953
		public static BaseImage tech_number_11_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_11_olive.png");

		// Token: 0x04001B2A RID: 6954
		public static BaseImage tech_number_11_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_11_tan.png");

		// Token: 0x04001B2B RID: 6955
		public static BaseImage tech_number_12_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_12_green.png");

		// Token: 0x04001B2C RID: 6956
		public static BaseImage tech_number_12_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_12_olive.png");

		// Token: 0x04001B2D RID: 6957
		public static BaseImage tech_number_12_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_12_tan.png");

		// Token: 0x04001B2E RID: 6958
		public static BaseImage tech_number_13_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_13_green.png");

		// Token: 0x04001B2F RID: 6959
		public static BaseImage tech_number_13_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_13_olive.png");

		// Token: 0x04001B30 RID: 6960
		public static BaseImage tech_number_13_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_13_tan.png");

		// Token: 0x04001B31 RID: 6961
		public static BaseImage tech_number_14_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_14_green.png");

		// Token: 0x04001B32 RID: 6962
		public static BaseImage tech_number_14_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_14_olive.png");

		// Token: 0x04001B33 RID: 6963
		public static BaseImage tech_number_14_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_14_tan.png");

		// Token: 0x04001B34 RID: 6964
		public static BaseImage tech_number_15_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_15_green.png");

		// Token: 0x04001B35 RID: 6965
		public static BaseImage tech_number_15_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_15_olive.png");

		// Token: 0x04001B36 RID: 6966
		public static BaseImage tech_number_15_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_15_tan.png");

		// Token: 0x04001B37 RID: 6967
		public static BaseImage tech_number_16_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_16_green.png");

		// Token: 0x04001B38 RID: 6968
		public static BaseImage tech_number_16_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_16_olive.png");

		// Token: 0x04001B39 RID: 6969
		public static BaseImage tech_number_16_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_16_tan.png");

		// Token: 0x04001B3A RID: 6970
		public static BaseImage tech_number_1_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_1_green.png");

		// Token: 0x04001B3B RID: 6971
		public static BaseImage tech_number_1_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_1_olive.png");

		// Token: 0x04001B3C RID: 6972
		public static BaseImage tech_number_1_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_1_tan.png");

		// Token: 0x04001B3D RID: 6973
		public static BaseImage tech_number_2_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_2_green.png");

		// Token: 0x04001B3E RID: 6974
		public static BaseImage tech_number_2_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_2_olive.png");

		// Token: 0x04001B3F RID: 6975
		public static BaseImage tech_number_2_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_2_tan.png");

		// Token: 0x04001B40 RID: 6976
		public static BaseImage tech_number_3_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_3_green.png");

		// Token: 0x04001B41 RID: 6977
		public static BaseImage tech_number_3_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_3_olive.png");

		// Token: 0x04001B42 RID: 6978
		public static BaseImage tech_number_3_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_3_tan.png");

		// Token: 0x04001B43 RID: 6979
		public static BaseImage tech_number_4_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_4_green.png");

		// Token: 0x04001B44 RID: 6980
		public static BaseImage tech_number_4_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_4_olive.png");

		// Token: 0x04001B45 RID: 6981
		public static BaseImage tech_number_4_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_4_tan.png");

		// Token: 0x04001B46 RID: 6982
		public static BaseImage tech_number_5_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_5_green.png");

		// Token: 0x04001B47 RID: 6983
		public static BaseImage tech_number_5_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_5_olive.png");

		// Token: 0x04001B48 RID: 6984
		public static BaseImage tech_number_5_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_5_tan.png");

		// Token: 0x04001B49 RID: 6985
		public static BaseImage tech_number_6_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_6_green.png");

		// Token: 0x04001B4A RID: 6986
		public static BaseImage tech_number_6_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_6_olive.png");

		// Token: 0x04001B4B RID: 6987
		public static BaseImage tech_number_6_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_6_tan.png");

		// Token: 0x04001B4C RID: 6988
		public static BaseImage tech_number_7_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_7_green.png");

		// Token: 0x04001B4D RID: 6989
		public static BaseImage tech_number_7_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_7_olive.png");

		// Token: 0x04001B4E RID: 6990
		public static BaseImage tech_number_7_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_7_tan.png");

		// Token: 0x04001B4F RID: 6991
		public static BaseImage tech_number_8_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_8_green.png");

		// Token: 0x04001B50 RID: 6992
		public static BaseImage tech_number_8_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_8_olive.png");

		// Token: 0x04001B51 RID: 6993
		public static BaseImage tech_number_8_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_8_tan.png");

		// Token: 0x04001B52 RID: 6994
		public static BaseImage tech_number_9_green = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_9_green.png");

		// Token: 0x04001B53 RID: 6995
		public static BaseImage tech_number_9_olive = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_9_olive.png");

		// Token: 0x04001B54 RID: 6996
		public static BaseImage tech_number_9_tan = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-number_9_tan.png");

		// Token: 0x04001B55 RID: 6997
		public static BaseImage tech_tree_inset_left = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_left.png");

		// Token: 0x04001B56 RID: 6998
		public static BaseImage tech_tree_inset_mid = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_mid.png");

		// Token: 0x04001B57 RID: 6999
		public static BaseImage tech_tree_inset_right = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_right.png");

		// Token: 0x04001B58 RID: 7000
		public static BaseImage tech_tree_inset_tall_left = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_tall_left.png");

		// Token: 0x04001B59 RID: 7001
		public static BaseImage tech_tree_inset_tall_mid = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_tall_mid.png");

		// Token: 0x04001B5A RID: 7002
		public static BaseImage tech_tree_inset_tall_right = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_inset_tall_right.png");

		// Token: 0x04001B5B RID: 7003
		public static BaseImage tech_tree_progbar_green_left = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_green_left.png");

		// Token: 0x04001B5C RID: 7004
		public static BaseImage tech_tree_progbar_green_mid = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_green_mid.png");

		// Token: 0x04001B5D RID: 7005
		public static BaseImage tech_tree_progbar_green_right = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_green_right.png");

		// Token: 0x04001B5E RID: 7006
		public static BaseImage tech_tree_progbar_olive_left = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_olive_left.png");

		// Token: 0x04001B5F RID: 7007
		public static BaseImage tech_tree_progbar_olive_mid = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_olive_mid.png");

		// Token: 0x04001B60 RID: 7008
		public static BaseImage tech_tree_progbar_olive_right = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_progbar_olive_right.png");

		// Token: 0x04001B61 RID: 7009
		public static BaseImage tech_tree_tab_list_highlight = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-list_highlight.png");

		// Token: 0x04001B62 RID: 7010
		public static BaseImage tech_tree_tab_list_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-list_normal.png");

		// Token: 0x04001B63 RID: 7011
		public static BaseImage tech_tree_tab_tree_highlight = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-tree_highlight.png");

		// Token: 0x04001B64 RID: 7012
		public static BaseImage tech_tree_tab_tree_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-tree_normal.png");

		// Token: 0x04001B65 RID: 7013
		public static BaseImage tech_tree_tab_01_highlight = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-01_highlight.png");

		// Token: 0x04001B66 RID: 7014
		public static BaseImage tech_tree_tab_01_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab-01_normal.png");

		// Token: 0x04001B67 RID: 7015
		public static BaseImage tech_tree_tab_highlight = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab_highlight.png");

		// Token: 0x04001B68 RID: 7016
		public static BaseImage tech_tree_tab_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "tech-tree_tab_normal.png");

		// Token: 0x04001B69 RID: 7017
		public static BaseImage techtree_button_in = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_button_in.png");

		// Token: 0x04001B6A RID: 7018
		public static BaseImage techtree_button_normal = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_button_normal.png");

		// Token: 0x04001B6B RID: 7019
		public static BaseImage techtree_button_over = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_button_over.png");

		// Token: 0x04001B6C RID: 7020
		public static BaseImage techtree_inset_edge_bottom = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_bottom.png");

		// Token: 0x04001B6D RID: 7021
		public static BaseImage techtree_inset_edge_bottomleft = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_bottomleft.png");

		// Token: 0x04001B6E RID: 7022
		public static BaseImage techtree_inset_edge_bottomright = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_bottomright.png");

		// Token: 0x04001B6F RID: 7023
		public static BaseImage techtree_inset_edge_left = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_left.png");

		// Token: 0x04001B70 RID: 7024
		public static BaseImage techtree_inset_edge_right = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_right.png");

		// Token: 0x04001B71 RID: 7025
		public static BaseImage techtree_inset_edge_top = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_top.png");

		// Token: 0x04001B72 RID: 7026
		public static BaseImage techtree_inset_edge_topleft = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_topleft.png");

		// Token: 0x04001B73 RID: 7027
		public static BaseImage techtree_inset_edge_topright = new BaseImage(AssetPaths.AssetIconsResearch2, "techtree_inset-edge_topright.png");

		// Token: 0x04001B74 RID: 7028
		public static BaseImage tech_tree_dots_black_x04 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x04.png");

		// Token: 0x04001B75 RID: 7029
		public static BaseImage tech_tree_dots_black_x05 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x05.png");

		// Token: 0x04001B76 RID: 7030
		public static BaseImage tech_tree_dots_black_x08 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x08.png");

		// Token: 0x04001B77 RID: 7031
		public static BaseImage tech_tree_dots_black_x10 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x10.png");

		// Token: 0x04001B78 RID: 7032
		public static BaseImage tech_tree_dots_black_x16 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x16.png");

		// Token: 0x04001B79 RID: 7033
		public static BaseImage tech_tree_dots_black_x15 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x15.png");

		// Token: 0x04001B7A RID: 7034
		public static BaseImage tech_tree_dots_black_x13 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_black_x13.png");

		// Token: 0x04001B7B RID: 7035
		public static BaseImage tech_tree_dots_green_x16 = new BaseImage(AssetPaths.AssetIconsResearch2, "tech_tree_dots_green_x16.png");

		// Token: 0x04001B7C RID: 7036
		public static BaseImage r_building_bar_building_info_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_building-info_norm.png");

		// Token: 0x04001B7D RID: 7037
		public static BaseImage r_building_bar_building_info_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_building-info_over.png");

		// Token: 0x04001B7E RID: 7038
		public static BaseImage r_building_bar_tab1_arrow_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1-arrow_in.png");

		// Token: 0x04001B7F RID: 7039
		public static BaseImage r_building_bar_tab1_arrow_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1-arrow_norm.png");

		// Token: 0x04001B80 RID: 7040
		public static BaseImage r_building_bar_tab1_arrow_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1-arrow_over.png");

		// Token: 0x04001B81 RID: 7041
		public static BaseImage r_building_bar_tab1_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1_in.png");

		// Token: 0x04001B82 RID: 7042
		public static BaseImage r_building_bar_tab1_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1_norm.png");

		// Token: 0x04001B83 RID: 7043
		public static BaseImage r_building_bar_tab1_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab1_over.png");

		// Token: 0x04001B84 RID: 7044
		public static BaseImage r_building_bar_tab2_arrow_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2-arrow_in.png");

		// Token: 0x04001B85 RID: 7045
		public static BaseImage r_building_bar_tab2_arrow_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2-arrow_norm.png");

		// Token: 0x04001B86 RID: 7046
		public static BaseImage r_building_bar_tab2_arrow_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2-arrow_over.png");

		// Token: 0x04001B87 RID: 7047
		public static BaseImage r_building_bar_tab2_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2_in.png");

		// Token: 0x04001B88 RID: 7048
		public static BaseImage r_building_bar_tab2_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2_norm.png");

		// Token: 0x04001B89 RID: 7049
		public static BaseImage r_building_bar_tab2_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab2_over.png");

		// Token: 0x04001B8A RID: 7050
		public static BaseImage r_building_bar_tab3_arrow_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3-arrow_in.png");

		// Token: 0x04001B8B RID: 7051
		public static BaseImage r_building_bar_tab3_arrow_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3-arrow_norm.png");

		// Token: 0x04001B8C RID: 7052
		public static BaseImage r_building_bar_tab3_arrow_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3-arrow_over.png");

		// Token: 0x04001B8D RID: 7053
		public static BaseImage r_building_bar_tab3_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3_in.png");

		// Token: 0x04001B8E RID: 7054
		public static BaseImage r_building_bar_tab3_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3_norm.png");

		// Token: 0x04001B8F RID: 7055
		public static BaseImage r_building_bar_tab3_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab3_over.png");

		// Token: 0x04001B90 RID: 7056
		public static BaseImage r_building_bar_tab4_arrow_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4-arrow_in.png");

		// Token: 0x04001B91 RID: 7057
		public static BaseImage r_building_bar_tab4_arrow_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4-arrow_norm.png");

		// Token: 0x04001B92 RID: 7058
		public static BaseImage r_building_bar_tab4_arrow_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4-arrow_over.png");

		// Token: 0x04001B93 RID: 7059
		public static BaseImage r_building_bar_tab4_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4_in.png");

		// Token: 0x04001B94 RID: 7060
		public static BaseImage r_building_bar_tab4_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4_norm.png");

		// Token: 0x04001B95 RID: 7061
		public static BaseImage r_building_bar_tab4_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab4_over.png");

		// Token: 0x04001B96 RID: 7062
		public static BaseImage r_building_bar_tab5_arrow_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5-arrow_in.png");

		// Token: 0x04001B97 RID: 7063
		public static BaseImage r_building_bar_tab5_arrow_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5-arrow_norm.png");

		// Token: 0x04001B98 RID: 7064
		public static BaseImage r_building_bar_tab5_arrow_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5-arrow_over.png");

		// Token: 0x04001B99 RID: 7065
		public static BaseImage r_building_bar_tab5_in = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5_in.png");

		// Token: 0x04001B9A RID: 7066
		public static BaseImage r_building_bar_tab5_norm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5_norm.png");

		// Token: 0x04001B9B RID: 7067
		public static BaseImage r_building_bar_tab5_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_bar_tab5_over.png");

		// Token: 0x04001B9C RID: 7068
		public static BaseImage r_building_miltary_archer = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_archer.png");

		// Token: 0x04001B9D RID: 7069
		public static BaseImage r_building_miltary_archer_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_archer_over.png");

		// Token: 0x04001B9E RID: 7070
		public static BaseImage r_building_miltary_catapult = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_catapult.png");

		// Token: 0x04001B9F RID: 7071
		public static BaseImage r_building_miltary_catapult_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_catapult_over.png");

		// Token: 0x04001BA0 RID: 7072
		public static BaseImage r_building_miltary_gatehouse = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_gatehouse.png");

		// Token: 0x04001BA1 RID: 7073
		public static BaseImage r_building_miltary_gatehouse_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_gatehouse_over.png");

		// Token: 0x04001BA2 RID: 7074
		public static BaseImage r_building_miltary_greattower = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_greattower.png");

		// Token: 0x04001BA3 RID: 7075
		public static BaseImage r_building_miltary_greattower_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_greattower_over.png");

		// Token: 0x04001BA4 RID: 7076
		public static BaseImage r_building_miltary_guardhouse = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse.png");

		// Token: 0x04001BA5 RID: 7077
		public static BaseImage r_building_miltary_guardhouse2 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse2.png");

		// Token: 0x04001BA6 RID: 7078
		public static BaseImage r_building_miltary_guardhouse2_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse2_over.png");

		// Token: 0x04001BA7 RID: 7079
		public static BaseImage r_building_miltary_guardhouse3 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse3.png");

		// Token: 0x04001BA8 RID: 7080
		public static BaseImage r_building_miltary_guardhouse3_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse3_over.png");

		// Token: 0x04001BA9 RID: 7081
		public static BaseImage r_building_miltary_guardhouse4 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse4.png");

		// Token: 0x04001BAA RID: 7082
		public static BaseImage r_building_miltary_guardhouse4_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse4_over.png");

		// Token: 0x04001BAB RID: 7083
		public static BaseImage r_building_miltary_guardhouse_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_guardhouse_over.png");

		// Token: 0x04001BAC RID: 7084
		public static BaseImage r_building_miltary_killingpits = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_killingpits.png");

		// Token: 0x04001BAD RID: 7085
		public static BaseImage r_building_miltary_killingpits_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_killingpits_over.png");

		// Token: 0x04001BAE RID: 7086
		public static BaseImage r_building_miltary_largetower = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_largetower.png");

		// Token: 0x04001BAF RID: 7087
		public static BaseImage r_building_miltary_largetower_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_largetower_over.png");

		// Token: 0x04001BB0 RID: 7088
		public static BaseImage r_building_miltary_lookouttower = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_lookouttower.png");

		// Token: 0x04001BB1 RID: 7089
		public static BaseImage r_building_miltary_lookouttower_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_lookouttower_over.png");

		// Token: 0x04001BB2 RID: 7090
		public static BaseImage r_building_miltary_moat = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_moat.png");

		// Token: 0x04001BB3 RID: 7091
		public static BaseImage r_building_miltary_moat_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_moat_over.png");

		// Token: 0x04001BB4 RID: 7092
		public static BaseImage r_building_miltary_oilpots = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_oilpots.png");

		// Token: 0x04001BB5 RID: 7093
		public static BaseImage r_building_miltary_oilpots_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_oilpots_over.png");

		// Token: 0x04001BB6 RID: 7094
		public static BaseImage r_building_miltary_peasent = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_peasent.png");

		// Token: 0x04001BB7 RID: 7095
		public static BaseImage r_building_miltary_peasent_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_peasent_over.png");

		// Token: 0x04001BB8 RID: 7096
		public static BaseImage r_building_miltary_pikemen = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_pikemen.png");

		// Token: 0x04001BB9 RID: 7097
		public static BaseImage r_building_miltary_pikemen_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_pikemen_over.png");

		// Token: 0x04001BBA RID: 7098
		public static BaseImage r_building_miltary_pitchrig = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_pitchrig.png");

		// Token: 0x04001BBB RID: 7099
		public static BaseImage r_building_miltary_pitchrig_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_pitchrig_over.png");

		// Token: 0x04001BBC RID: 7100
		public static BaseImage r_building_miltary_scout = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_scout.png");

		// Token: 0x04001BBD RID: 7101
		public static BaseImage r_building_miltary_scout_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_scout_over.png");

		// Token: 0x04001BBE RID: 7102
		public static BaseImage r_building_miltary_smalltower = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_smalltower.png");

		// Token: 0x04001BBF RID: 7103
		public static BaseImage r_building_miltary_smalltower_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_smalltower_over.png");

		// Token: 0x04001BC0 RID: 7104
		public static BaseImage r_building_miltary_smelter = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_smelter.png");

		// Token: 0x04001BC1 RID: 7105
		public static BaseImage r_building_miltary_smelter_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_smelter_over.png");

		// Token: 0x04001BC2 RID: 7106
		public static BaseImage r_building_miltary_stonewall = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_stonewall.png");

		// Token: 0x04001BC3 RID: 7107
		public static BaseImage r_building_miltary_stonewall_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_stonewall_over.png");

		// Token: 0x04001BC4 RID: 7108
		public static BaseImage r_building_miltary_swordsman = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_swordsman.png");

		// Token: 0x04001BC5 RID: 7109
		public static BaseImage r_building_miltary_swordsman_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_swordsman_over.png");

		// Token: 0x04001BC6 RID: 7110
		public static BaseImage r_building_miltary_woodtower = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodtower.png");

		// Token: 0x04001BC7 RID: 7111
		public static BaseImage r_building_miltary_woodtower_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodtower_over.png");

		// Token: 0x04001BC8 RID: 7112
		public static BaseImage r_building_miltary_woodwall = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodwall.png");

		// Token: 0x04001BC9 RID: 7113
		public static BaseImage r_building_miltary_woodwall_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodwall_over.png");

		// Token: 0x04001BCA RID: 7114
		public static BaseImage r_building_miltary_stonewallblock = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_stonewallblock.png");

		// Token: 0x04001BCB RID: 7115
		public static BaseImage r_building_miltary_stonewallblock_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_stonewallblock_over.png");

		// Token: 0x04001BCC RID: 7116
		public static BaseImage r_building_miltary_woodwallblock = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodwallblock.png");

		// Token: 0x04001BCD RID: 7117
		public static BaseImage r_building_miltary_woodwallblock_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_miltary_woodwallblock_over.png");

		// Token: 0x04001BCE RID: 7118
		public static BaseImage r_building_panel_back = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_back.png");

		// Token: 0x04001BCF RID: 7119
		public static BaseImage r_building_panel_bld_icon_food_apple_orchard = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_apple-orchard.png");

		// Token: 0x04001BD0 RID: 7120
		public static BaseImage r_building_panel_bld_icon_food_apple_orchard_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_apple-orchard_over.png");

		// Token: 0x04001BD1 RID: 7121
		public static BaseImage r_building_panel_bld_icon_food_bakery = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_bakery.png");

		// Token: 0x04001BD2 RID: 7122
		public static BaseImage r_building_panel_bld_icon_food_bakery_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_bakery_over.png");

		// Token: 0x04001BD3 RID: 7123
		public static BaseImage r_building_panel_bld_icon_food_brewery = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_brewery.png");

		// Token: 0x04001BD4 RID: 7124
		public static BaseImage r_building_panel_bld_icon_food_brewery_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_brewery_over.png");

		// Token: 0x04001BD5 RID: 7125
		public static BaseImage r_building_panel_bld_icon_food_dairy_farm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_dairy-farm.png");

		// Token: 0x04001BD6 RID: 7126
		public static BaseImage r_building_panel_bld_icon_food_dairy_farm_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_dairy-farm_over.png");

		// Token: 0x04001BD7 RID: 7127
		public static BaseImage r_building_panel_bld_icon_food_fishing_jetty = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_fishing-jetty.png");

		// Token: 0x04001BD8 RID: 7128
		public static BaseImage r_building_panel_bld_icon_food_fishing_jetty_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_fishing-jetty_over.png");

		// Token: 0x04001BD9 RID: 7129
		public static BaseImage r_building_panel_bld_icon_food_granary = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_granary.png");

		// Token: 0x04001BDA RID: 7130
		public static BaseImage r_building_panel_bld_icon_food_granary_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_granary_over.png");

		// Token: 0x04001BDB RID: 7131
		public static BaseImage r_building_panel_bld_icon_food_inn = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_inn.png");

		// Token: 0x04001BDC RID: 7132
		public static BaseImage r_building_panel_bld_icon_food_inn_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_inn_over.png");

		// Token: 0x04001BDD RID: 7133
		public static BaseImage r_building_panel_bld_icon_food_pig_farm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_pig-farm.png");

		// Token: 0x04001BDE RID: 7134
		public static BaseImage r_building_panel_bld_icon_food_pig_farm_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_pig-farm_over.png");

		// Token: 0x04001BDF RID: 7135
		public static BaseImage r_building_panel_bld_icon_food_vegetable_farm = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_vegetable-farm.png");

		// Token: 0x04001BE0 RID: 7136
		public static BaseImage r_building_panel_bld_icon_food_vegetable_farm_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_food_vegetable-farm_over.png");

		// Token: 0x04001BE1 RID: 7137
		public static BaseImage r_building_panel_bld_icon_hon_carpenters_workshop = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_carpenters-workshop.png");

		// Token: 0x04001BE2 RID: 7138
		public static BaseImage r_building_panel_bld_icon_hon_carpenters_workshop_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_carpenters-workshop_over.png");

		// Token: 0x04001BE3 RID: 7139
		public static BaseImage r_building_panel_bld_icon_hon_hunters_hut = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_hunters-hut.png");

		// Token: 0x04001BE4 RID: 7140
		public static BaseImage r_building_panel_bld_icon_hon_hunters_hut_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_hunters-hut_over.png");

		// Token: 0x04001BE5 RID: 7141
		public static BaseImage r_building_panel_bld_icon_hon_metalworks_workshop = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_metalworks-workshop.png");

		// Token: 0x04001BE6 RID: 7142
		public static BaseImage r_building_panel_bld_icon_hon_metalworks_workshop_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_metalworks-workshop_over.png");

		// Token: 0x04001BE7 RID: 7143
		public static BaseImage r_building_panel_bld_icon_hon_salt_pan = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_salt-pan.png");

		// Token: 0x04001BE8 RID: 7144
		public static BaseImage r_building_panel_bld_icon_hon_salt_pan_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_salt-pan_over.png");

		// Token: 0x04001BE9 RID: 7145
		public static BaseImage r_building_panel_bld_icon_hon_silk_docs = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_silk-docs.png");

		// Token: 0x04001BEA RID: 7146
		public static BaseImage r_building_panel_bld_icon_hon_silk_docs_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_silk-docs_over.png");

		// Token: 0x04001BEB RID: 7147
		public static BaseImage r_building_panel_bld_icon_hon_spice_docs = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_spice-docs.png");

		// Token: 0x04001BEC RID: 7148
		public static BaseImage r_building_panel_bld_icon_hon_spice_docs_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_spice-docs_over.png");

		// Token: 0x04001BED RID: 7149
		public static BaseImage r_building_panel_bld_icon_hon_tailers_workshop = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_tailers-workshop.png");

		// Token: 0x04001BEE RID: 7150
		public static BaseImage r_building_panel_bld_icon_hon_tailers_workshop_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_tailers-workshop_over.png");

		// Token: 0x04001BEF RID: 7151
		public static BaseImage r_building_panel_bld_icon_hon_vinyard = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_vinyard.png");

		// Token: 0x04001BF0 RID: 7152
		public static BaseImage r_building_panel_bld_icon_hon_vinyard_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_hon_vinyard_over.png");

		// Token: 0x04001BF1 RID: 7153
		public static BaseImage r_building_panel_bld_icon_ind_iron_mine = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_iron-mine.png");

		// Token: 0x04001BF2 RID: 7154
		public static BaseImage r_building_panel_bld_icon_ind_iron_mine_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_iron-mine_over.png");

		// Token: 0x04001BF3 RID: 7155
		public static BaseImage r_building_panel_bld_icon_ind_market = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_market.png");

		// Token: 0x04001BF4 RID: 7156
		public static BaseImage r_building_panel_bld_icon_ind_market_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_market_over.png");

		// Token: 0x04001BF5 RID: 7157
		public static BaseImage r_building_panel_bld_icon_ind_pitch_rig = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_pitch-rig.png");

		// Token: 0x04001BF6 RID: 7158
		public static BaseImage r_building_panel_bld_icon_ind_pitch_rig_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_pitch-rig_over.png");

		// Token: 0x04001BF7 RID: 7159
		public static BaseImage r_building_panel_bld_icon_ind_stockpile = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_stockpile.png");

		// Token: 0x04001BF8 RID: 7160
		public static BaseImage r_building_panel_bld_icon_ind_stockpile_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_stockpile_over.png");

		// Token: 0x04001BF9 RID: 7161
		public static BaseImage r_building_panel_bld_icon_ind_stone_quarry = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_stone-quarry.png");

		// Token: 0x04001BFA RID: 7162
		public static BaseImage r_building_panel_bld_icon_ind_stone_quarry_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_stone-quarry_over.png");

		// Token: 0x04001BFB RID: 7163
		public static BaseImage r_building_panel_bld_icon_ind_woodcutters_hut = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_woodcutters-hut.png");

		// Token: 0x04001BFC RID: 7164
		public static BaseImage r_building_panel_bld_icon_ind_woodcutters_hut_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_ind_woodcutters-hut_over.png");

		// Token: 0x04001BFD RID: 7165
		public static BaseImage r_building_panel_bld_icon_mil_armourer = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_armourer.png");

		// Token: 0x04001BFE RID: 7166
		public static BaseImage r_building_panel_bld_icon_mil_armourer_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_armourer_over.png");

		// Token: 0x04001BFF RID: 7167
		public static BaseImage r_building_panel_bld_icon_mil_armoury = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_armoury.png");

		// Token: 0x04001C00 RID: 7168
		public static BaseImage r_building_panel_bld_icon_mil_armoury_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_armoury_over.png");

		// Token: 0x04001C01 RID: 7169
		public static BaseImage r_building_panel_bld_icon_mil_barracks = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_barracks.png");

		// Token: 0x04001C02 RID: 7170
		public static BaseImage r_building_panel_bld_icon_mil_barracks_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_barracks_over.png");

		// Token: 0x04001C03 RID: 7171
		public static BaseImage r_building_panel_bld_icon_mil_blacksmith = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_blacksmith.png");

		// Token: 0x04001C04 RID: 7172
		public static BaseImage r_building_panel_bld_icon_mil_blacksmith_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_blacksmith_over.png");

		// Token: 0x04001C05 RID: 7173
		public static BaseImage r_building_panel_bld_icon_mil_fletcher = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_fletcher.png");

		// Token: 0x04001C06 RID: 7174
		public static BaseImage r_building_panel_bld_icon_mil_fletcher_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_fletcher_over.png");

		// Token: 0x04001C07 RID: 7175
		public static BaseImage r_building_panel_bld_icon_mil_pole_turner = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_pole-turner.png");

		// Token: 0x04001C08 RID: 7176
		public static BaseImage r_building_panel_bld_icon_mil_pole_turner_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_pole-turner_over.png");

		// Token: 0x04001C09 RID: 7177
		public static BaseImage r_building_panel_bld_icon_mil_siege_workshop = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_siege-workshop.png");

		// Token: 0x04001C0A RID: 7178
		public static BaseImage r_building_panel_bld_icon_mil_siege_workshop_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld-icon_mil_siege-workshop_over.png");

		// Token: 0x04001C0B RID: 7179
		public static BaseImage r_building_panel_bld_back = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_back.png");

		// Token: 0x04001C0C RID: 7180
		public static BaseImage r_building_panel_bld_back_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_back_over.png");

		// Token: 0x04001C0D RID: 7181
		public static BaseImage r_building_panel_bld_civ_dec_dovecote = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_dovecote.png");

		// Token: 0x04001C0E RID: 7182
		public static BaseImage r_building_panel_bld_civ_dec_dovecote_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_dovecote_over.png");

		// Token: 0x04001C0F RID: 7183
		public static BaseImage r_building_panel_bld_civ_dec_garden_lrg_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-lrg_variant.png");

		// Token: 0x04001C10 RID: 7184
		public static BaseImage r_building_panel_bld_civ_dec_garden_lrg_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-lrg_variant_over.png");

		// Token: 0x04001C11 RID: 7185
		public static BaseImage r_building_panel_bld_civ_dec_garden_med_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-med_variant.png");

		// Token: 0x04001C12 RID: 7186
		public static BaseImage r_building_panel_bld_civ_dec_garden_med_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-med_variant_over.png");

		// Token: 0x04001C13 RID: 7187
		public static BaseImage r_building_panel_bld_civ_dec_garden_sml_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-sml_variant.png");

		// Token: 0x04001C14 RID: 7188
		public static BaseImage r_building_panel_bld_civ_dec_garden_sml_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-sml_variant_over.png");

		// Token: 0x04001C15 RID: 7189
		public static BaseImage r_building_panel_bld_civ_dec_garden_water_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-water_variant.png");

		// Token: 0x04001C16 RID: 7190
		public static BaseImage r_building_panel_bld_civ_dec_garden_water_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_garden-water_variant_over.png");

		// Token: 0x04001C17 RID: 7191
		public static BaseImage r_building_panel_bld_civ_dec_large_garden = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden.png");

		// Token: 0x04001C18 RID: 7192
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_01png = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_01png.png");

		// Token: 0x04001C19 RID: 7193
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_01png_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_01png_over.png");

		// Token: 0x04001C1A RID: 7194
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_02.png");

		// Token: 0x04001C1B RID: 7195
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_02_over.png");

		// Token: 0x04001C1C RID: 7196
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_03 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_03.png");

		// Token: 0x04001C1D RID: 7197
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_03_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_03_over.png");

		// Token: 0x04001C1E RID: 7198
		public static BaseImage r_building_panel_bld_civ_dec_large_garden_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-garden_over.png");

		// Token: 0x04001C1F RID: 7199
		public static BaseImage r_building_panel_bld_civ_dec_large_statue = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue.png");

		// Token: 0x04001C20 RID: 7200
		public static BaseImage r_building_panel_bld_civ_dec_large_statue_01 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue_01.png");

		// Token: 0x04001C21 RID: 7201
		public static BaseImage r_building_panel_bld_civ_dec_large_statue_01_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue_01_over.png");

		// Token: 0x04001C22 RID: 7202
		public static BaseImage r_building_panel_bld_civ_dec_large_statue_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue_02.png");

		// Token: 0x04001C23 RID: 7203
		public static BaseImage r_building_panel_bld_civ_dec_large_statue_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue_02_over.png");

		// Token: 0x04001C24 RID: 7204
		public static BaseImage r_building_panel_bld_civ_dec_large_statue_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_large-statue_over.png");

		// Token: 0x04001C25 RID: 7205
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_01 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_01.png");

		// Token: 0x04001C26 RID: 7206
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_01_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_01_over.png");

		// Token: 0x04001C27 RID: 7207
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_02.png");

		// Token: 0x04001C28 RID: 7208
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_02_over.png");

		// Token: 0x04001C29 RID: 7209
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_03 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_03.png");

		// Token: 0x04001C2A RID: 7210
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_03_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_03_over.png");

		// Token: 0x04001C2B RID: 7211
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_04 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_04.png");

		// Token: 0x04001C2C RID: 7212
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_04_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_04_over.png");

		// Token: 0x04001C2D RID: 7213
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_05 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_05.png");

		// Token: 0x04001C2E RID: 7214
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_05_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_05_over.png");

		// Token: 0x04001C2F RID: 7215
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_06 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_06.png");

		// Token: 0x04001C30 RID: 7216
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_06_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_06_over.png");

		// Token: 0x04001C31 RID: 7217
		public static BaseImage r_building_panel_bld_civ_dec_small_garden_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-garden_over.png");

		// Token: 0x04001C32 RID: 7218
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_01 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_01.png");

		// Token: 0x04001C33 RID: 7219
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_01_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_01_over.png");

		// Token: 0x04001C34 RID: 7220
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_02.png");

		// Token: 0x04001C35 RID: 7221
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_02_over.png");

		// Token: 0x04001C36 RID: 7222
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_03 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_03.png");

		// Token: 0x04001C37 RID: 7223
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_03_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_03_over.png");

		// Token: 0x04001C38 RID: 7224
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_04 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_04.png");

		// Token: 0x04001C39 RID: 7225
		public static BaseImage r_building_panel_bld_civ_dec_small_statue_04_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_small-statue_04_over.png");

		// Token: 0x04001C3A RID: 7226
		public static BaseImage r_building_panel_bld_civ_dec_statue_lrg_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_statue-lrg_variant.png");

		// Token: 0x04001C3B RID: 7227
		public static BaseImage r_building_panel_bld_civ_dec_statue_lrg_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_statue-lrg_variant_over.png");

		// Token: 0x04001C3C RID: 7228
		public static BaseImage r_building_panel_bld_civ_dec_statue_sml_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_statue-sml_variant.png");

		// Token: 0x04001C3D RID: 7229
		public static BaseImage r_building_panel_bld_civ_dec_statue_sml_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_statue-sml_variant_over.png");

		// Token: 0x04001C3E RID: 7230
		public static BaseImage r_building_panel_bld_civ_dec_sub_category = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_sub-category.png");

		// Token: 0x04001C3F RID: 7231
		public static BaseImage r_building_panel_bld_civ_dec_sub_category_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-dec_sub-category_over.png");

		// Token: 0x04001C40 RID: 7232
		public static BaseImage r_building_panel_bld_civ_ent_sub_category = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-ent_sub-category.png");

		// Token: 0x04001C41 RID: 7233
		public static BaseImage r_building_panel_bld_civ_ent_sub_category_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-ent_sub-category_over.png");

		// Token: 0x04001C42 RID: 7234
		public static BaseImage r_building_panel_bld_civ_jus_sub_category = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-jus_sub-category.png");

		// Token: 0x04001C43 RID: 7235
		public static BaseImage r_building_panel_bld_civ_jus_sub_category_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-jus_sub-category_over.png");

		// Token: 0x04001C44 RID: 7236
		public static BaseImage r_building_panel_bld_civ_rel_large_church = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-church.png");

		// Token: 0x04001C45 RID: 7237
		public static BaseImage r_building_panel_bld_civ_rel_large_church_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-church_over.png");

		// Token: 0x04001C46 RID: 7238
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines.png");

		// Token: 0x04001C47 RID: 7239
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines_01 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines_01.png");

		// Token: 0x04001C48 RID: 7240
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines_01_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines_01_over.png");

		// Token: 0x04001C49 RID: 7241
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines_02.png");

		// Token: 0x04001C4A RID: 7242
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines_02_over.png");

		// Token: 0x04001C4B RID: 7243
		public static BaseImage r_building_panel_bld_civ_rel_large_shrines_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_large-shrines_over.png");

		// Token: 0x04001C4C RID: 7244
		public static BaseImage r_building_panel_bld_civ_rel_medium_church = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_medium-church.png");

		// Token: 0x04001C4D RID: 7245
		public static BaseImage r_building_panel_bld_civ_rel_medium_church_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_medium-church_over.png");

		// Token: 0x04001C4E RID: 7246
		public static BaseImage r_building_panel_bld_civ_rel_shrine_lrg_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_shrine-lrg_variant.png");

		// Token: 0x04001C4F RID: 7247
		public static BaseImage r_building_panel_bld_civ_rel_shrine_lrg_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_shrine-lrg_variant_over.png");

		// Token: 0x04001C50 RID: 7248
		public static BaseImage r_building_panel_bld_civ_rel_shrine_sml_variant = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_shrine-sml_variant.png");

		// Token: 0x04001C51 RID: 7249
		public static BaseImage r_building_panel_bld_civ_rel_shrine_sml_variant_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_shrine-sml_variant_over.png");

		// Token: 0x04001C52 RID: 7250
		public static BaseImage r_building_panel_bld_civ_rel_small_church = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-church.png");

		// Token: 0x04001C53 RID: 7251
		public static BaseImage r_building_panel_bld_civ_rel_small_church_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-church_over.png");

		// Token: 0x04001C54 RID: 7252
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines.png");

		// Token: 0x04001C55 RID: 7253
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_01 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_01.png");

		// Token: 0x04001C56 RID: 7254
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_01_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_01_over.png");

		// Token: 0x04001C57 RID: 7255
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_02 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_02.png");

		// Token: 0x04001C58 RID: 7256
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_02_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_02_over.png");

		// Token: 0x04001C59 RID: 7257
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_03 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_03.png");

		// Token: 0x04001C5A RID: 7258
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_03_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_03_over.png");

		// Token: 0x04001C5B RID: 7259
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_04 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_04.png");

		// Token: 0x04001C5C RID: 7260
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_04_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_04_over.png");

		// Token: 0x04001C5D RID: 7261
		public static BaseImage r_building_panel_bld_civ_rel_small_shrines_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_small-shrines_over.png");

		// Token: 0x04001C5E RID: 7262
		public static BaseImage r_building_panel_bld_civ_rel_sub_category = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_sub-category.png");

		// Token: 0x04001C5F RID: 7263
		public static BaseImage r_building_panel_bld_civ_rel_sub_category_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ-rel_sub-category_over.png");

		// Token: 0x04001C60 RID: 7264
		public static BaseImage r_building_panel_bld_civ_hall_1 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_1.png");

		// Token: 0x04001C61 RID: 7265
		public static BaseImage r_building_panel_bld_civ_hall_1_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_1_over.png");

		// Token: 0x04001C62 RID: 7266
		public static BaseImage r_building_panel_bld_civ_hall_2 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_2.png");

		// Token: 0x04001C63 RID: 7267
		public static BaseImage r_building_panel_bld_civ_hall_2_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_2_over.png");

		// Token: 0x04001C64 RID: 7268
		public static BaseImage r_building_panel_bld_civ_hall_3 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_3.png");

		// Token: 0x04001C65 RID: 7269
		public static BaseImage r_building_panel_bld_civ_hall_3_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_hall_3_over.png");

		// Token: 0x04001C66 RID: 7270
		public static BaseImage r_building_panel_bld_civ_house_1 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_1.png");

		// Token: 0x04001C67 RID: 7271
		public static BaseImage r_building_panel_bld_civ_house_1_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_1_over.png");

		// Token: 0x04001C68 RID: 7272
		public static BaseImage r_building_panel_bld_civ_house_2 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_2.png");

		// Token: 0x04001C69 RID: 7273
		public static BaseImage r_building_panel_bld_civ_house_2_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_2_over.png");

		// Token: 0x04001C6A RID: 7274
		public static BaseImage r_building_panel_bld_civ_house_3 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_3.png");

		// Token: 0x04001C6B RID: 7275
		public static BaseImage r_building_panel_bld_civ_house_3_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_3_over.png");

		// Token: 0x04001C6C RID: 7276
		public static BaseImage r_building_panel_bld_civ_house_4 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_4.png");

		// Token: 0x04001C6D RID: 7277
		public static BaseImage r_building_panel_bld_civ_house_4_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_4_over.png");

		// Token: 0x04001C6E RID: 7278
		public static BaseImage r_building_panel_bld_civ_house_5 = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_5.png");

		// Token: 0x04001C6F RID: 7279
		public static BaseImage r_building_panel_bld_civ_house_5_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_civ_house_5_over.png");

		// Token: 0x04001C70 RID: 7280
		public static BaseImage r_building_panel_bld_ent_dancing_bear = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_dancing-bear.png");

		// Token: 0x04001C71 RID: 7281
		public static BaseImage r_building_panel_bld_ent_dancing_bear_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_dancing-bear_over.png");

		// Token: 0x04001C72 RID: 7282
		public static BaseImage r_building_panel_bld_ent_jesters_court = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_jesters-court.png");

		// Token: 0x04001C73 RID: 7283
		public static BaseImage r_building_panel_bld_ent_jesters_court_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_jesters-court_over.png");

		// Token: 0x04001C74 RID: 7284
		public static BaseImage r_building_panel_bld_ent_maypole = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_maypole.png");

		// Token: 0x04001C75 RID: 7285
		public static BaseImage r_building_panel_bld_ent_maypole_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_maypole_over.png");

		// Token: 0x04001C76 RID: 7286
		public static BaseImage r_building_panel_bld_ent_theatre = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_theatre.png");

		// Token: 0x04001C77 RID: 7287
		public static BaseImage r_building_panel_bld_ent_theatre_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_theatre_over.png");

		// Token: 0x04001C78 RID: 7288
		public static BaseImage r_building_panel_bld_ent_troubadours_arbor = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_troubadours-arbor.png");

		// Token: 0x04001C79 RID: 7289
		public static BaseImage r_building_panel_bld_ent_troubadours_arbor_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_ent_troubadours-arbor_over.png");

		// Token: 0x04001C7A RID: 7290
		public static BaseImage r_building_panel_bld_jus_burning_post = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_burning-post.png");

		// Token: 0x04001C7B RID: 7291
		public static BaseImage r_building_panel_bld_jus_burning_post_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_burning-post_over.png");

		// Token: 0x04001C7C RID: 7292
		public static BaseImage r_building_panel_bld_jus_gibbet = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_gibbet.png");

		// Token: 0x04001C7D RID: 7293
		public static BaseImage r_building_panel_bld_jus_gibbet_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_gibbet_over.png");

		// Token: 0x04001C7E RID: 7294
		public static BaseImage r_building_panel_bld_jus_stocks = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_stocks.png");

		// Token: 0x04001C7F RID: 7295
		public static BaseImage r_building_panel_bld_jus_stocks_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_stocks_over.png");

		// Token: 0x04001C80 RID: 7296
		public static BaseImage r_building_panel_bld_jus_stretching_rack = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_stretching-rack.png");

		// Token: 0x04001C81 RID: 7297
		public static BaseImage r_building_panel_bld_jus_stretching_rack_over = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_bld_jus_stretching-rack_over.png");

		// Token: 0x04001C82 RID: 7298
		public static BaseImage r_building_panel_inset = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset.png");

		// Token: 0x04001C83 RID: 7299
		public static BaseImage r_building_panel_inset_icon_clay = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset_icon_clay.png");

		// Token: 0x04001C84 RID: 7300
		public static BaseImage r_building_panel_inset_icon_gold = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset_icon_gold.png");

		// Token: 0x04001C85 RID: 7301
		public static BaseImage r_building_panel_inset_icon_stone = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset_icon_stone.png");

		// Token: 0x04001C86 RID: 7302
		public static BaseImage r_building_panel_inset_icon_time = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset_icon_time.png");

		// Token: 0x04001C87 RID: 7303
		public static BaseImage r_building_panel_inset_icon_wood = new BaseImage(AssetPaths.AssetIconsBuildings, "r_building_panel_inset_icon_wood.png");

		// Token: 0x04001C88 RID: 7304
		public static BaseImage extrasbar_01 = new BaseImage(AssetPaths.AssetIconsResources, "extrasbar_01.png");

		// Token: 0x04001C89 RID: 7305
		public static BaseImage extrasbar_01_over = new BaseImage(AssetPaths.AssetIconsResources, "extrasbar_01_over.png");

		// Token: 0x04001C8A RID: 7306
		public static BaseImage infobar_01 = new BaseImage(AssetPaths.AssetIconsResources, "infobar_01.png");

		// Token: 0x04001C8B RID: 7307
		public static BaseImage infobar_01_over = new BaseImage(AssetPaths.AssetIconsResources, "infobar_01_over.png");

		// Token: 0x04001C8C RID: 7308
		public static BaseImage infobar_02 = new BaseImage(AssetPaths.AssetIconsResources, "infobar_02.png");

		// Token: 0x04001C8D RID: 7309
		public static BaseImage infobar_02_over = new BaseImage(AssetPaths.AssetIconsResources, "infobar_02_over.png");

		// Token: 0x04001C8E RID: 7310
		public static BaseImage infobar_03 = new BaseImage(AssetPaths.AssetIconsResources, "infobar_03.png");

		// Token: 0x04001C8F RID: 7311
		public static BaseImage infobar_03_over = new BaseImage(AssetPaths.AssetIconsResources, "infobar_03_over.png");

		// Token: 0x04001C90 RID: 7312
		public static BaseImage int_but_delete_norm = new BaseImage(AssetPaths.AssetIconsResources, "int_but_delete_norm.png");

		// Token: 0x04001C91 RID: 7313
		public static BaseImage int_but_delete_over = new BaseImage(AssetPaths.AssetIconsResources, "int_but_delete_over.png");

		// Token: 0x04001C92 RID: 7314
		public static BaseImage int_but_delete_blue_norm = new BaseImage(AssetPaths.AssetIconsResources, "int_but_delete_blue_norm.png");

		// Token: 0x04001C93 RID: 7315
		public static BaseImage int_but_delete_blue_over = new BaseImage(AssetPaths.AssetIconsResources, "int_but_delete_blue_over.png");

		// Token: 0x04001C94 RID: 7316
		public static BaseImage int_but_industry_blank_norm = new BaseImage(AssetPaths.AssetIconsResources, "int_but_industry-blank_norm.png");

		// Token: 0x04001C95 RID: 7317
		public static BaseImage int_but_industry_blank_over = new BaseImage(AssetPaths.AssetIconsResources, "int_but_industry-blank_over.png");

		// Token: 0x04001C96 RID: 7318
		public static BaseImage interface_inner_shadow_128_bottom = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_bottom.png");

		// Token: 0x04001C97 RID: 7319
		public static BaseImage interface_inner_shadow_128_bottomleft = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_bottomleft.png");

		// Token: 0x04001C98 RID: 7320
		public static BaseImage interface_inner_shadow_128_bottomright = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_bottomright.png");

		// Token: 0x04001C99 RID: 7321
		public static BaseImage interface_inner_shadow_128_left = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_left.png");

		// Token: 0x04001C9A RID: 7322
		public static BaseImage interface_inner_shadow_128_right = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_right.png");

		// Token: 0x04001C9B RID: 7323
		public static BaseImage interface_inner_shadow_128_top = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_top.png");

		// Token: 0x04001C9C RID: 7324
		public static BaseImage interface_inner_shadow_128_topleft = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_topleft.png");

		// Token: 0x04001C9D RID: 7325
		public static BaseImage interface_inner_shadow_128_topright = new BaseImage(AssetPaths.AssetIconsResources, "interface_inner_shadow_128_topright.png");

		// Token: 0x04001C9E RID: 7326
		public static BaseImage interface_under_shadow_128_bottom = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_bottom.png");

		// Token: 0x04001C9F RID: 7327
		public static BaseImage interface_under_shadow_128_bottomleft = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_bottomleft.png");

		// Token: 0x04001CA0 RID: 7328
		public static BaseImage interface_under_shadow_128_bottomright = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_bottomright.png");

		// Token: 0x04001CA1 RID: 7329
		public static BaseImage interface_under_shadow_128_left = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_left.png");

		// Token: 0x04001CA2 RID: 7330
		public static BaseImage interface_under_shadow_128_right = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_right.png");

		// Token: 0x04001CA3 RID: 7331
		public static BaseImage interface_under_shadow_128_top = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_top.png");

		// Token: 0x04001CA4 RID: 7332
		public static BaseImage interface_under_shadow_128_topleft = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_topleft.png");

		// Token: 0x04001CA5 RID: 7333
		public static BaseImage interface_under_shadow_128_topright = new BaseImage(AssetPaths.AssetIconsResources, "interface_under_shadow_128_topright.png");

		// Token: 0x04001CA6 RID: 7334
		public static BaseImage VillageTabBar_1_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_1_Normal.png");

		// Token: 0x04001CA7 RID: 7335
		public static BaseImage VillageTabBar_1_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_1_Selected.png");

		// Token: 0x04001CA8 RID: 7336
		public static BaseImage VillageTabBar_2_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_2_Normal.png");

		// Token: 0x04001CA9 RID: 7337
		public static BaseImage VillageTabBar_2_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_2_Selected.png");

		// Token: 0x04001CAA RID: 7338
		public static BaseImage VillageTabBar_3_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_3_Normal.png");

		// Token: 0x04001CAB RID: 7339
		public static BaseImage VillageTabBar_3_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_3_Selected.png");

		// Token: 0x04001CAC RID: 7340
		public static BaseImage VillageTabBar_4_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_4_Normal.png");

		// Token: 0x04001CAD RID: 7341
		public static BaseImage VillageTabBar_4_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_4_Selected.png");

		// Token: 0x04001CAE RID: 7342
		public static BaseImage VillageTabBar_5_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_5_Normal.png");

		// Token: 0x04001CAF RID: 7343
		public static BaseImage VillageTabBar_5_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_5_Selected.png");

		// Token: 0x04001CB0 RID: 7344
		public static BaseImage VillageTabBar_6_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_6_Normal.png");

		// Token: 0x04001CB1 RID: 7345
		public static BaseImage VillageTabBar_6_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_6_Selected.png");

		// Token: 0x04001CB2 RID: 7346
		public static BaseImage VillageTabBar_7_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_7_Normal.png");

		// Token: 0x04001CB3 RID: 7347
		public static BaseImage VillageTabBar_7_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_7_Selected.png");

		// Token: 0x04001CB4 RID: 7348
		public static BaseImage VillageTabBar_8_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_8_Normal.png");

		// Token: 0x04001CB5 RID: 7349
		public static BaseImage VillageTabBar_8_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_8_Selected.png");

		// Token: 0x04001CB6 RID: 7350
		public static BaseImage VillageTabBar_9_Normal = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_9_Normal.png");

		// Token: 0x04001CB7 RID: 7351
		public static BaseImage VillageTabBar_9_Selected = new BaseImage(AssetPaths.AssetIconsTabs, "VillageTabBar_9_Selected.png");

		// Token: 0x04001CB8 RID: 7352
		public static BaseImage tab_3b_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3b_normal.png");

		// Token: 0x04001CB9 RID: 7353
		public static BaseImage tab_3b_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3b_selected.png");

		// Token: 0x04001CBA RID: 7354
		public static BaseImage tab_3c_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3c_normal.png");

		// Token: 0x04001CBB RID: 7355
		public static BaseImage tab_3c_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3c_selected.png");

		// Token: 0x04001CBC RID: 7356
		public static BaseImage tab_3_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3_normal.png");

		// Token: 0x04001CBD RID: 7357
		public static BaseImage tab_3_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_3_selected.png");

		// Token: 0x04001CBE RID: 7358
		public static BaseImage tab_4_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_4_normal.png");

		// Token: 0x04001CBF RID: 7359
		public static BaseImage tab_4_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_4_selected.png");

		// Token: 0x04001CC0 RID: 7360
		public static BaseImage tab_4b_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_4b_normal.png");

		// Token: 0x04001CC1 RID: 7361
		public static BaseImage tab_4b_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_4b_selected.png");

		// Token: 0x04001CC2 RID: 7362
		public static BaseImage tab_5b_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5b_normal.png");

		// Token: 0x04001CC3 RID: 7363
		public static BaseImage tab_5b_normal_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5b_normal_bright.png");

		// Token: 0x04001CC4 RID: 7364
		public static BaseImage tab_5b_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5b_selected.png");

		// Token: 0x04001CC5 RID: 7365
		public static BaseImage tab_5b_selected_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5b_selected_bright.png");

		// Token: 0x04001CC6 RID: 7366
		public static BaseImage tab_5_normal_newReports = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5_normal-newReports.png");

		// Token: 0x04001CC7 RID: 7367
		public static BaseImage tab_5_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5_normal.png");

		// Token: 0x04001CC8 RID: 7368
		public static BaseImage tab_5_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_5_selected.png");

		// Token: 0x04001CC9 RID: 7369
		public static BaseImage tab_6B_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6B_normal.png");

		// Token: 0x04001CCA RID: 7370
		public static BaseImage tab_6B_normal_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6B_normal_bright.png");

		// Token: 0x04001CCB RID: 7371
		public static BaseImage tab_6B_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6B_selected.png");

		// Token: 0x04001CCC RID: 7372
		public static BaseImage tab_6B_selected_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6B_selected_bright.png");

		// Token: 0x04001CCD RID: 7373
		public static BaseImage tab_6_normal_newReports = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6_normal-newReports.png");

		// Token: 0x04001CCE RID: 7374
		public static BaseImage tab_6_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6_normal.png");

		// Token: 0x04001CCF RID: 7375
		public static BaseImage tab_6_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_6_selected.png");

		// Token: 0x04001CD0 RID: 7376
		public static BaseImage tab_7b_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_7b_normal.png");

		// Token: 0x04001CD1 RID: 7377
		public static BaseImage tab_7b_normal_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_7b_normal_bright.png");

		// Token: 0x04001CD2 RID: 7378
		public static BaseImage tab_7b_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_7b_selected.png");

		// Token: 0x04001CD3 RID: 7379
		public static BaseImage tab_7_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_7_normal.png");

		// Token: 0x04001CD4 RID: 7380
		public static BaseImage tab_7_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_7_selected.png");

		// Token: 0x04001CD5 RID: 7381
		public static BaseImage tab_8_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_8_normal.png");

		// Token: 0x04001CD6 RID: 7382
		public static BaseImage tab_8_normal_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_8_normal_bright.png");

		// Token: 0x04001CD7 RID: 7383
		public static BaseImage tab_8_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_8_selected.png");

		// Token: 0x04001CD8 RID: 7384
		public static BaseImage tab_8_selected_bright = new BaseImage(AssetPaths.AssetIconsTabs, "tab_8_selected_bright.png");

		// Token: 0x04001CD9 RID: 7385
		public static BaseImage tab_9_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_9_normal.png");

		// Token: 0x04001CDA RID: 7386
		public static BaseImage tab_9_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_9_selected.png");

		// Token: 0x04001CDB RID: 7387
		public static BaseImage tab_capital_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_capital_normal.png");

		// Token: 0x04001CDC RID: 7388
		public static BaseImage tab_capital_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_capital_selected.png");

		// Token: 0x04001CDD RID: 7389
		public static BaseImage tab_quest_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_quest_normal.png");

		// Token: 0x04001CDE RID: 7390
		public static BaseImage tab_quest_glow = new BaseImage(AssetPaths.AssetIconsTabs, "tab_quest_glow.png");

		// Token: 0x04001CDF RID: 7391
		public static BaseImage tab_quest_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_quest_selected.png");

		// Token: 0x04001CE0 RID: 7392
		public static BaseImage tab_village_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_village_normal.png");

		// Token: 0x04001CE1 RID: 7393
		public static BaseImage tab_village_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_village_selected.png");

		// Token: 0x04001CE2 RID: 7394
		public static BaseImage tab_world_normal = new BaseImage(AssetPaths.AssetIconsTabs, "tab_world_normal.png");

		// Token: 0x04001CE3 RID: 7395
		public static BaseImage tab_world_rollover = new BaseImage(AssetPaths.AssetIconsTabs, "tab_world_rollover.png");

		// Token: 0x04001CE4 RID: 7396
		public static BaseImage tab_world_selected = new BaseImage(AssetPaths.AssetIconsTabs, "tab_world_selected.png");

		// Token: 0x04001CE5 RID: 7397
		public static BaseImage r_popularity_bar_back_glow = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_back_glow.png");

		// Token: 0x04001CE6 RID: 7398
		public static BaseImage r_popularity_bar_back_green = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_back_green.png");

		// Token: 0x04001CE7 RID: 7399
		public static BaseImage r_popularity_bar_back_red = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_back_red.png");

		// Token: 0x04001CE8 RID: 7400
		public static BaseImage r_popularity_bar_back_yellow = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_back_yellow.png");

		// Token: 0x04001CE9 RID: 7401
		public static BaseImage r_popularity_bar_walker_in = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_in.png");

		// Token: 0x04001CEA RID: 7402
		public static BaseImage r_popularity_bar_walker_in_x2 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_in_x2.png");

		// Token: 0x04001CEB RID: 7403
		public static BaseImage r_popularity_bar_walker_in_x3 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_in_x3.png");

		// Token: 0x04001CEC RID: 7404
		public static BaseImage r_popularity_bar_walker_in_x4 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_in_x4.png");

		// Token: 0x04001CED RID: 7405
		public static BaseImage r_popularity_bar_walker_in_x5 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_in_x5.png");

		// Token: 0x04001CEE RID: 7406
		public static BaseImage r_popularity_bar_walker_out = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out.png");

		// Token: 0x04001CEF RID: 7407
		public static BaseImage r_popularity_bar_walker_out_x2 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x02.png");

		// Token: 0x04001CF0 RID: 7408
		public static BaseImage r_popularity_bar_walker_out_x3 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x03.png");

		// Token: 0x04001CF1 RID: 7409
		public static BaseImage r_popularity_bar_walker_out_x4 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x04.png");

		// Token: 0x04001CF2 RID: 7410
		public static BaseImage r_popularity_bar_walker_out_x5 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x05.png");

		// Token: 0x04001CF3 RID: 7411
		public static BaseImage r_popularity_bar_walker_out_x6 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x06.png");

		// Token: 0x04001CF4 RID: 7412
		public static BaseImage r_popularity_bar_walker_out_x7 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x07.png");

		// Token: 0x04001CF5 RID: 7413
		public static BaseImage r_popularity_bar_walker_out_x8 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x08.png");

		// Token: 0x04001CF6 RID: 7414
		public static BaseImage r_popularity_bar_walker_out_x9 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x09.png");

		// Token: 0x04001CF7 RID: 7415
		public static BaseImage r_popularity_bar_walker_out_x10 = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_out_x10.png");

		// Token: 0x04001CF8 RID: 7416
		public static BaseImage r_popularity_bar_walker_stand = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_bar_walker_stand.png");

		// Token: 0x04001CF9 RID: 7417
		public static BaseImage r_popularity_panel_back = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_back.png");

		// Token: 0x04001CFA RID: 7418
		public static BaseImage r_popularity_panel_but_minus_in = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_minus_in.png");

		// Token: 0x04001CFB RID: 7419
		public static BaseImage r_popularity_panel_but_minus_norm = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_minus_norm.png");

		// Token: 0x04001CFC RID: 7420
		public static BaseImage r_popularity_panel_but_minus_over = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_minus_over.png");

		// Token: 0x04001CFD RID: 7421
		public static BaseImage r_popularity_panel_but_plus_in = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_plus_in.png");

		// Token: 0x04001CFE RID: 7422
		public static BaseImage r_popularity_panel_but_plus_norm = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_plus_norm.png");

		// Token: 0x04001CFF RID: 7423
		public static BaseImage r_popularity_panel_but_plus_over = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_but_plus_over.png");

		// Token: 0x04001D00 RID: 7424
		public static BaseImage r_popularity_panel_circle_inset_green = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_circle-inset_green.png");

		// Token: 0x04001D01 RID: 7425
		public static BaseImage r_popularity_panel_circle_inset_red = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_circle-inset_red.png");

		// Token: 0x04001D02 RID: 7426
		public static BaseImage r_popularity_panel_circle_inset_tan = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_circle-inset_tan.png");

		// Token: 0x04001D03 RID: 7427
		public static BaseImage r_popularity_panel_colorbar_green_back = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_green_back.png");

		// Token: 0x04001D04 RID: 7428
		public static BaseImage r_popularity_panel_colorbar_green_bar_left = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_green_bar-left.png");

		// Token: 0x04001D05 RID: 7429
		public static BaseImage r_popularity_panel_colorbar_green_bar_mid = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_green_bar-mid.png");

		// Token: 0x04001D06 RID: 7430
		public static BaseImage r_popularity_panel_colorbar_green_bar_right = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_green_bar-right.png");

		// Token: 0x04001D07 RID: 7431
		public static BaseImage r_popularity_panel_colorbar_red_back = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_red_back.png");

		// Token: 0x04001D08 RID: 7432
		public static BaseImage r_popularity_panel_colorbar_red_bar_left = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_red_bar-left.png");

		// Token: 0x04001D09 RID: 7433
		public static BaseImage r_popularity_panel_colorbar_red_bar_mid = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_red_bar-mid.png");

		// Token: 0x04001D0A RID: 7434
		public static BaseImage r_popularity_panel_colorbar_red_bar_right = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_colorbar_red_bar-right.png");

		// Token: 0x04001D0B RID: 7435
		public static BaseImage r_popularity_panel_events_textbar_green = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_events_textbar_green.png");

		// Token: 0x04001D0C RID: 7436
		public static BaseImage r_popularity_panel_events_textbar_red = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_events_textbar_red.png");

		// Token: 0x04001D0D RID: 7437
		public static BaseImage r_popularity_panel_extension_back = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_extension_back.png");

		// Token: 0x04001D0E RID: 7438
		public static BaseImage r_popularity_panel_icon_ale = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_icon_ale.png");

		// Token: 0x04001D0F RID: 7439
		public static BaseImage r_popularity_panel_icon_buildings = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_icon_buildings.png");

		// Token: 0x04001D10 RID: 7440
		public static BaseImage r_popularity_panel_icon_housing = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_icon_housing.png");

		// Token: 0x04001D11 RID: 7441
		public static BaseImage r_popularity_panel_icon_rations = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_icon_rations.png");

		// Token: 0x04001D12 RID: 7442
		public static BaseImage r_popularity_panel_icon_taxes = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_icon_taxes.png");

		// Token: 0x04001D13 RID: 7443
		public static BaseImage r_popularity_panel_indent = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_indent.png");

		// Token: 0x04001D14 RID: 7444
		public static BaseImage r_popularity_panel_indent_a = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_indent_a.png");

		// Token: 0x04001D15 RID: 7445
		public static BaseImage r_popularity_panel_indent_b = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_indent_b.png");

		// Token: 0x04001D16 RID: 7446
		public static BaseImage r_popularity_panel_inset_small = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_inset_small.png");

		// Token: 0x04001D17 RID: 7447
		public static BaseImage r_popularity_panel_pop_change_green = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_pop-change_green.png");

		// Token: 0x04001D18 RID: 7448
		public static BaseImage r_popularity_panel_pop_change_red = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_pop-change_red.png");

		// Token: 0x04001D19 RID: 7449
		public static BaseImage r_popularity_panel_pop_change_yellow = new BaseImage(AssetPaths.AssetIconsPopularity, "r_popularity_panel_pop-change_yellow.png");

		// Token: 0x04001D1A RID: 7450
		public static BaseImage research_ill_animal_husbandry = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_animal_husbandry.png");

		// Token: 0x04001D1B RID: 7451
		public static BaseImage research_ill_apple_farming = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_apple_farming.png");

		// Token: 0x04001D1C RID: 7452
		public static BaseImage research_ill_architecture = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_architecture.png");

		// Token: 0x04001D1D RID: 7453
		public static BaseImage research_ill_armour_working = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_armour_working.png");

		// Token: 0x04001D1E RID: 7454
		public static BaseImage research_ill_armoury_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_armoury_capacity.png");

		// Token: 0x04001D1F RID: 7455
		public static BaseImage research_ill_arts = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_arts.png");

		// Token: 0x04001D20 RID: 7456
		public static BaseImage research_ill_bakery = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_bakery.png");

		// Token: 0x04001D21 RID: 7457
		public static BaseImage research_ill_baptism = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_baptism.png");

		// Token: 0x04001D22 RID: 7458
		public static BaseImage research_ill_blacksmithing = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_blacksmithing.png");

		// Token: 0x04001D23 RID: 7459
		public static BaseImage research_ill_boiling_oil = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_boiling_oil.png");

		// Token: 0x04001D24 RID: 7460
		public static BaseImage research_ill_bounties = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_bounties.png");

		// Token: 0x04001D25 RID: 7461
		public static BaseImage research_ill_brewing = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_brewing.png");

		// Token: 0x04001D26 RID: 7462
		public static BaseImage research_ill_butchery = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_butchery.png");

		// Token: 0x04001D27 RID: 7463
		public static BaseImage research_ill_captains = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_captains.png");

		// Token: 0x04001D28 RID: 7464
		public static BaseImage research_ill_carpentry = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_carpentry.png");

		// Token: 0x04001D29 RID: 7465
		public static BaseImage research_ill_castellation = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_castellation.png");

		// Token: 0x04001D2A RID: 7466
		public static BaseImage research_ill_catapult = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_catapult.png");

		// Token: 0x04001D2B RID: 7467
		public static BaseImage research_ill_civil_service = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_civil_service.png");

		// Token: 0x04001D2C RID: 7468
		public static BaseImage research_ill_command = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_command.png");

		// Token: 0x04001D2D RID: 7469
		public static BaseImage research_ill_commerce = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_commerce.png");

		// Token: 0x04001D2E RID: 7470
		public static BaseImage research_ill_confession = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_confession.png");

		// Token: 0x04001D2F RID: 7471
		public static BaseImage research_ill_confirmation = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_confirmation.png");

		// Token: 0x04001D30 RID: 7472
		public static BaseImage research_ill_conscription = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_conscription.png");

		// Token: 0x04001D31 RID: 7473
		public static BaseImage research_ill_construction = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_construction.png");

		// Token: 0x04001D32 RID: 7474
		public static BaseImage research_ill_counter_espionage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_counter_espionage.png");

		// Token: 0x04001D33 RID: 7475
		public static BaseImage research_ill_counter_surveillance = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_counter_surveillance.png");

		// Token: 0x04001D34 RID: 7476
		public static BaseImage research_ill_courtiers = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_courtiers.png");

		// Token: 0x04001D35 RID: 7477
		public static BaseImage research_ill_craftsmanship = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_craftsmanship.png");

		// Token: 0x04001D36 RID: 7478
		public static BaseImage research_ill_dairy_farming = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_dairy_farming.png");

		// Token: 0x04001D37 RID: 7479
		public static BaseImage research_ill_defences = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_defences.png");

		// Token: 0x04001D38 RID: 7480
		public static BaseImage research_ill_diplomacy = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_diplomacy.png");

		// Token: 0x04001D39 RID: 7481
		public static BaseImage research_ill_education = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_education.png");

		// Token: 0x04001D3A RID: 7482
		public static BaseImage research_ill_engineering = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_engineering.png");

		// Token: 0x04001D3B RID: 7483
		public static BaseImage research_ill_espionage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_espionage.png");

		// Token: 0x04001D3C RID: 7484
		public static BaseImage research_ill_eucharist = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_eucharist.png");

		// Token: 0x04001D3D RID: 7485
		public static BaseImage research_ill_extreme_unction = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_extreme_unction.png");

		// Token: 0x04001D3E RID: 7486
		public static BaseImage research_ill_farming = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_farming.png");

		// Token: 0x04001D3F RID: 7487
		public static BaseImage research_ill_fishing = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_fishing.png");

		// Token: 0x04001D40 RID: 7488
		public static BaseImage research_ill_fletching = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_fletching.png");

		// Token: 0x04001D41 RID: 7489
		public static BaseImage research_ill_forestry = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_forestry.png");

		// Token: 0x04001D42 RID: 7490
		public static BaseImage research_ill_fortification = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_fortification.png");

		// Token: 0x04001D43 RID: 7491
		public static BaseImage research_ill_gardening = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_gardening.png");

		// Token: 0x04001D44 RID: 7492
		public static BaseImage research_ill_granary_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_granary_capacity.png");

		// Token: 0x04001D45 RID: 7493
		public static BaseImage research_ill_guard_houses = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_guard_houses.png");

		// Token: 0x04001D46 RID: 7494
		public static BaseImage research_ill_hall_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_hall_capacity.png");

		// Token: 0x04001D47 RID: 7495
		public static BaseImage research_ill_hops_farming = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_hops_farming.png");

		// Token: 0x04001D48 RID: 7496
		public static BaseImage research_ill_horsemanship = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_horsemanship.png");

		// Token: 0x04001D49 RID: 7497
		public static BaseImage research_ill_housing_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_housing_capacity.png");

		// Token: 0x04001D4A RID: 7498
		public static BaseImage research_ill_hunting = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_hunting.png");

		// Token: 0x04001D4B RID: 7499
		public static BaseImage research_ill_industry = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_industry.png");

		// Token: 0x04001D4C RID: 7500
		public static BaseImage research_ill_inn_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_inn_capacity.png");

		// Token: 0x04001D4D RID: 7501
		public static BaseImage research_ill_intelligence = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_intelligence.png");

		// Token: 0x04001D4E RID: 7502
		public static BaseImage research_ill_intelligence_gathering = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_intelligence_gathering.png");

		// Token: 0x04001D4F RID: 7503
		public static BaseImage research_ill_iron_mining = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_iron_mining.png");

		// Token: 0x04001D50 RID: 7504
		public static BaseImage research_ill_justice = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_justice.png");

		// Token: 0x04001D51 RID: 7505
		public static BaseImage research_ill_land_trade = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_land_trade.png");

		// Token: 0x04001D52 RID: 7506
		public static BaseImage research_ill_leadership = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_leadership.png");

		// Token: 0x04001D53 RID: 7507
		public static BaseImage research_ill_literature = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_literature.png");

		// Token: 0x04001D54 RID: 7508
		public static BaseImage research_ill_longbow = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_longbow.png");

		// Token: 0x04001D55 RID: 7509
		public static BaseImage research_ill_marriage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_marriage.png");

		// Token: 0x04001D56 RID: 7510
		public static BaseImage research_ill_mathematics = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_mathematics.png");

		// Token: 0x04001D57 RID: 7511
		public static BaseImage research_ill_metal_working = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_metal_working.png");

		// Token: 0x04001D58 RID: 7512
		public static BaseImage research_ill_military = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_military.png");

		// Token: 0x04001D59 RID: 7513
		public static BaseImage research_ill_moats = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_moats.png");

		// Token: 0x04001D5A RID: 7514
		public static BaseImage research_ill_ordination = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_ordination.png");

		// Token: 0x04001D5B RID: 7515
		public static BaseImage research_ill_overlay = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_overlay.png");

		// Token: 0x04001D5C RID: 7516
		public static BaseImage research_ill_philosophy = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_philosophy.png");

		// Token: 0x04001D5D RID: 7517
		public static BaseImage research_ill_pig_breeding = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pig_breeding.png");

		// Token: 0x04001D5E RID: 7518
		public static BaseImage research_ill_pike = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pike.png");

		// Token: 0x04001D5F RID: 7519
		public static BaseImage research_ill_pilgrimage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pilgrimage.png");

		// Token: 0x04001D60 RID: 7520
		public static BaseImage research_ill_pitch_extraction = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pitch_extraction.png");

		// Token: 0x04001D61 RID: 7521
		public static BaseImage research_ill_plough = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_plough.png");

		// Token: 0x04001D62 RID: 7522
		public static BaseImage research_ill_pole_turning = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pole_turning.png");

		// Token: 0x04001D63 RID: 7523
		public static BaseImage research_ill_salt_working = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_salt_working.png");

		// Token: 0x04001D64 RID: 7524
		public static BaseImage research_ill_scouts = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_scouts.png");

		// Token: 0x04001D65 RID: 7525
		public static BaseImage research_ill_shipping = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_shipping.png");

		// Token: 0x04001D66 RID: 7526
		public static BaseImage research_ill_siege_mechanics = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_siege_mechanics.png");

		// Token: 0x04001D67 RID: 7527
		public static BaseImage research_ill_silk_trade = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_silk_trade.png");

		// Token: 0x04001D68 RID: 7528
		public static BaseImage research_ill_spice_trade = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_spice_trade.png");

		// Token: 0x04001D69 RID: 7529
		public static BaseImage research_ill_spy_training = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_spy_training.png");

		// Token: 0x04001D6A RID: 7530
		public static BaseImage research_ill_stake_traps = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_stake traps.png");

		// Token: 0x04001D6B RID: 7531
		public static BaseImage research_ill_stockpile_capacity = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_stockpile_capacity.png");

		// Token: 0x04001D6C RID: 7532
		public static BaseImage research_ill_stone_quarrying = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_stone_quarrying.png");

		// Token: 0x04001D6D RID: 7533
		public static BaseImage research_ill_surveillance = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_surveillance.png");

		// Token: 0x04001D6E RID: 7534
		public static BaseImage research_ill_sword = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_sword.png");

		// Token: 0x04001D6F RID: 7535
		public static BaseImage research_ill_tactics = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_tactics.png");

		// Token: 0x04001D70 RID: 7536
		public static BaseImage research_ill_tailoring = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_tailoring.png");

		// Token: 0x04001D71 RID: 7537
		public static BaseImage research_ill_theology = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_theology.png");

		// Token: 0x04001D72 RID: 7538
		public static BaseImage research_ill_tools = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_tools.png");

		// Token: 0x04001D73 RID: 7539
		public static BaseImage research_ill_trade_agreements = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_trade_agreements.png");

		// Token: 0x04001D74 RID: 7540
		public static BaseImage research_ill_vaults = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_vaults.png");

		// Token: 0x04001D75 RID: 7541
		public static BaseImage research_ill_vegetable_cropping = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_vegetable_cropping.png");

		// Token: 0x04001D76 RID: 7542
		public static BaseImage research_ill_weapon_making = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_weapon_making.png");

		// Token: 0x04001D77 RID: 7543
		public static BaseImage research_ill_wheat_farming = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_wheat_farming.png");

		// Token: 0x04001D78 RID: 7544
		public static BaseImage research_ill_wine_production = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_wine_production.png");

		// Token: 0x04001D79 RID: 7545
		public static BaseImage research_ill_foraging = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_foraging.png");

		// Token: 0x04001D7A RID: 7546
		public static BaseImage research_ill_none = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_none.png");

		// Token: 0x04001D7B RID: 7547
		public static BaseImage research_ill_pillage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_pillage.png");

		// Token: 0x04001D7C RID: 7548
		public static BaseImage research_ill_sally_forth = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_sally_forth.png");

		// Token: 0x04001D7D RID: 7549
		public static BaseImage research_ill_vassalage = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_vassalage.png");

		// Token: 0x04001D7E RID: 7550
		public static BaseImage research_ill_villages = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_villages.png");

		// Token: 0x04001D7F RID: 7551
		public static BaseImage research_ill_ransacking = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_ransacking.png");

		// Token: 0x04001D80 RID: 7552
		public static BaseImage research_ill_forced_march = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_forced_march");

		// Token: 0x04001D81 RID: 7553
		public static BaseImage research_ill_logistics = new BaseImage(AssetPaths.AssetIconsResearchIllustrations, "research_ill_logistics");

		// Token: 0x04001D82 RID: 7554
		public static BaseImage com_64_venison_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_venison_on-larger_dropshadow.png");

		// Token: 0x04001D83 RID: 7555
		public static BaseImage com_64_salt_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_salt_on-larger_dropshadow.png");

		// Token: 0x04001D84 RID: 7556
		public static BaseImage com_64_spices_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_spice_on-larger_dropshadow.png");

		// Token: 0x04001D85 RID: 7557
		public static BaseImage com_64_silk_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_silk_on-larger_dropshadow.png");

		// Token: 0x04001D86 RID: 7558
		public static BaseImage com_64_wine_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_wine_on-larger_dropshadow.png");

		// Token: 0x04001D87 RID: 7559
		public static BaseImage com_64_furniture_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_furniture_on-larger_dropshadow.png");

		// Token: 0x04001D88 RID: 7560
		public static BaseImage com_64_clothes_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_clothing_on-larger_dropshadow.png");

		// Token: 0x04001D89 RID: 7561
		public static BaseImage com_64_metalware_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_metalwork_on-larger_dropshadow.png");

		// Token: 0x04001D8A RID: 7562
		public static BaseImage com_64_ale_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_ale_on-larger_dropshadow.png");

		// Token: 0x04001D8B RID: 7563
		public static BaseImage com_64_apples_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_apples_on-larger_dropshadow.png");

		// Token: 0x04001D8C RID: 7564
		public static BaseImage com_64_armour_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_armour_on-larger_dropshadow.png");

		// Token: 0x04001D8D RID: 7565
		public static BaseImage com_64_bows_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_bows_on-larger_dropshadow.png");

		// Token: 0x04001D8E RID: 7566
		public static BaseImage com_64_bread_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_bread_on-larger_dropshadow.png");

		// Token: 0x04001D8F RID: 7567
		public static BaseImage com_64_catapults_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_catapults_on-larger_dropshadow.png");

		// Token: 0x04001D90 RID: 7568
		public static BaseImage com_64_cheese_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_cheese_on-larger_dropshadow.png");

		// Token: 0x04001D91 RID: 7569
		public static BaseImage com_64_fish_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_fish_on-larger_dropshadow.png");

		// Token: 0x04001D92 RID: 7570
		public static BaseImage com_64_food_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_food_on-larger_dropshadow.png");

		// Token: 0x04001D93 RID: 7571
		public static BaseImage com_64_honour_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_honour_on-larger_dropshadow.png");

		// Token: 0x04001D94 RID: 7572
		public static BaseImage com_64_iron_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_iron_on-larger_dropshadow.png");

		// Token: 0x04001D95 RID: 7573
		public static BaseImage com_64_meat_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_meat_on-larger_dropshadow.png");

		// Token: 0x04001D96 RID: 7574
		public static BaseImage com_64_money_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_money_on-larger_dropshadow.png");

		// Token: 0x04001D97 RID: 7575
		public static BaseImage com_64_people_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_people_on-larger_dropshadow.png");

		// Token: 0x04001D98 RID: 7576
		public static BaseImage com_64_pikes_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_pikes_on-larger_dropshadow.png");

		// Token: 0x04001D99 RID: 7577
		public static BaseImage com_64_pitch_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_pitch_on-larger_dropshadow.png");

		// Token: 0x04001D9A RID: 7578
		public static BaseImage com_64_stone_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_stone_on-larger_dropshadow.png");

		// Token: 0x04001D9B RID: 7579
		public static BaseImage com_64_swords_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_swords_on-larger_dropshadow.png");

		// Token: 0x04001D9C RID: 7580
		public static BaseImage com_64_veg_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_veg_on-larger_dropshadow.png");

		// Token: 0x04001D9D RID: 7581
		public static BaseImage com_64_wood_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_64_wood_on-larger_dropshadow.png");

		// Token: 0x04001D9E RID: 7582
		public static BaseImage com_32_venison_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_venison_on-larger_dropshadow.png");

		// Token: 0x04001D9F RID: 7583
		public static BaseImage com_32_salt_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_salt_on-larger_dropshadow.png");

		// Token: 0x04001DA0 RID: 7584
		public static BaseImage com_32_spices_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_spice_on-larger_dropshadow.png");

		// Token: 0x04001DA1 RID: 7585
		public static BaseImage com_32_silk_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_silk_on-larger_dropshadow.png");

		// Token: 0x04001DA2 RID: 7586
		public static BaseImage com_32_wine_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_wine_on-larger_dropshadow.png");

		// Token: 0x04001DA3 RID: 7587
		public static BaseImage com_32_furniture_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_furniture_on-larger_dropshadow.png");

		// Token: 0x04001DA4 RID: 7588
		public static BaseImage com_32_clothes_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_clothing_on-larger_dropshadow.png");

		// Token: 0x04001DA5 RID: 7589
		public static BaseImage com_32_metalware_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_metalwork_on-larger_dropshadow.png");

		// Token: 0x04001DA6 RID: 7590
		public static BaseImage com_32_ale_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_ale_on-larger_dropshadow.png");

		// Token: 0x04001DA7 RID: 7591
		public static BaseImage com_32_apples_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_apples_on-larger_dropshadow.png");

		// Token: 0x04001DA8 RID: 7592
		public static BaseImage com_32_armour_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_armour_on-larger_dropshadow.png");

		// Token: 0x04001DA9 RID: 7593
		public static BaseImage com_32_bows_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_bows_on-larger_dropshadow.png");

		// Token: 0x04001DAA RID: 7594
		public static BaseImage com_32_bread_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_bread_on-larger_dropshadow.png");

		// Token: 0x04001DAB RID: 7595
		public static BaseImage com_32_catapults_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_catapults_on-larger_dropshadow.png");

		// Token: 0x04001DAC RID: 7596
		public static BaseImage com_32_cheese_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_cheese_on-larger_dropshadow.png");

		// Token: 0x04001DAD RID: 7597
		public static BaseImage com_32_fish_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_fish_on-larger_dropshadow.png");

		// Token: 0x04001DAE RID: 7598
		public static BaseImage com_32_food_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_food_on-larger_dropshadow.png");

		// Token: 0x04001DAF RID: 7599
		public static BaseImage com_32_honour_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_honour_on-larger_dropshadow.png");

		// Token: 0x04001DB0 RID: 7600
		public static BaseImage com_32_iron_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_iron_on-larger_dropshadow.png");

		// Token: 0x04001DB1 RID: 7601
		public static BaseImage com_32_meat_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_meat_on-larger_dropshadow.png");

		// Token: 0x04001DB2 RID: 7602
		public static BaseImage com_32_money_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_money_on-larger_dropshadow.png");

		// Token: 0x04001DB3 RID: 7603
		public static BaseImage com_32_people_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_people_on-larger_dropshadow.png");

		// Token: 0x04001DB4 RID: 7604
		public static BaseImage com_32_pikes_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_pikes_on-larger_dropshadow.png");

		// Token: 0x04001DB5 RID: 7605
		public static BaseImage com_32_pitch_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_pitch_on-larger_dropshadow.png");

		// Token: 0x04001DB6 RID: 7606
		public static BaseImage com_32_stone_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_stone_on-larger_dropshadow.png");

		// Token: 0x04001DB7 RID: 7607
		public static BaseImage com_32_swords_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_swords_on-larger_dropshadow.png");

		// Token: 0x04001DB8 RID: 7608
		public static BaseImage com_32_veg_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_veg_on-larger_dropshadow.png");

		// Token: 0x04001DB9 RID: 7609
		public static BaseImage com_32_wood_DS = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_wood_on-larger_dropshadow.png");

		// Token: 0x04001DBA RID: 7610
		public static BaseImage com_32_honor_on_larger_dropshadow = new BaseImage(AssetPaths.AssetIconsCommodities, "com_32_honor_on-larger_dropshadow.png");

		// Token: 0x04001DBB RID: 7611
		public static BaseImage body_background_001 = new BaseImage(AssetPaths.AssetIconsCommon, "body_background_001.png");

		// Token: 0x04001DBC RID: 7612
		public static BaseImage body_background_002 = new BaseImage(AssetPaths.AssetIconsCommon, "body_background_002.png");

		// Token: 0x04001DBD RID: 7613
		public static BaseImage body_background_canvas = new BaseImage(AssetPaths.AssetIconsCommon, "background_canvas.png");

		// Token: 0x04001DBE RID: 7614
		public static BaseImage body_background_canvas_left_edge = new BaseImage(AssetPaths.AssetIconsCommon, "background_canvas_left_edge.png");

		// Token: 0x04001DBF RID: 7615
		public static BaseImage panel_border_top_left = new BaseImage(AssetPaths.AssetIconsCommon, "panel_corner.png");

		// Token: 0x04001DC0 RID: 7616
		public static BaseImage panel_border_top = new BaseImage(AssetPaths.AssetIconsCommon, "panel_blank.png");

		// Token: 0x04001DC1 RID: 7617
		public static BaseImage panel_border_left = new BaseImage(AssetPaths.AssetIconsCommon, "panel_blank.png");

		// Token: 0x04001DC2 RID: 7618
		public static BaseImage int_banquette_background_tile_orig = new BaseImage(AssetPaths.AssetIconsCommon, "int_banquette_background_tile.png");

		// Token: 0x04001DC3 RID: 7619
		public static BaseImage int_banquette_background_tile = new BaseImage(AssetPaths.AssetIconsCommon, "int_banquette_background_tile_tan.png");

		// Token: 0x04001DC4 RID: 7620
		public static BaseImage int_banquette_background_tile_tan = new BaseImage(AssetPaths.AssetIconsCommon, "int_banquette_background_tile_tan.png");

		// Token: 0x04001DC5 RID: 7621
		public static BaseImage int_button_close_normal = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_close_normal.png");

		// Token: 0x04001DC6 RID: 7622
		public static BaseImage int_button_close_over = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_close_over.png");

		// Token: 0x04001DC7 RID: 7623
		public static BaseImage int_button_close_in = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_close_in.png");

		// Token: 0x04001DC8 RID: 7624
		public static BaseImage int_button_Q_normal = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_Q_normal.png");

		// Token: 0x04001DC9 RID: 7625
		public static BaseImage int_button_Q_over = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_Q_over.png");

		// Token: 0x04001DCA RID: 7626
		public static BaseImage int_button_Q_in = new BaseImage(AssetPaths.AssetIconsCommon, "int_button_Q_in.png");

		// Token: 0x04001DCB RID: 7627
		public static BaseImage int_insetbar_a_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetbar-a_left.png");

		// Token: 0x04001DCC RID: 7628
		public static BaseImage int_insetbar_a_middle = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetbar-a_middle.png");

		// Token: 0x04001DCD RID: 7629
		public static BaseImage int_insetbar_a_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetbar-a_right.png");

		// Token: 0x04001DCE RID: 7630
		public static BaseImage int_insetpanel_a_bottom_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_bottom-left.png");

		// Token: 0x04001DCF RID: 7631
		public static BaseImage int_insetpanel_a_bottom_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_bottom-right.png");

		// Token: 0x04001DD0 RID: 7632
		public static BaseImage int_insetpanel_a_middle_bottom = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_middle-bottom.png");

		// Token: 0x04001DD1 RID: 7633
		public static BaseImage int_insetpanel_a_middle_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_middle-left.png");

		// Token: 0x04001DD2 RID: 7634
		public static BaseImage int_insetpanel_a_middle_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_middle-right.png");

		// Token: 0x04001DD3 RID: 7635
		public static BaseImage int_insetpanel_a_middle_top = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_middle-top.png");

		// Token: 0x04001DD4 RID: 7636
		public static BaseImage int_insetpanel_a_middle = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_middle.png");

		// Token: 0x04001DD5 RID: 7637
		public static BaseImage int_insetpanel_a_top_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_top-left.png");

		// Token: 0x04001DD6 RID: 7638
		public static BaseImage int_insetpanel_a_top_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-a_top-right.png");

		// Token: 0x04001DD7 RID: 7639
		public static BaseImage int_buttonbar_left_normal = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-left_normal.png");

		// Token: 0x04001DD8 RID: 7640
		public static BaseImage int_buttonbar_left_over = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-left_over.png");

		// Token: 0x04001DD9 RID: 7641
		public static BaseImage int_buttonbar_middle_normal = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-middle_normal.png");

		// Token: 0x04001DDA RID: 7642
		public static BaseImage int_buttonbar_middle_over = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-middle_over.png");

		// Token: 0x04001DDB RID: 7643
		public static BaseImage int_buttonbar_right_normal = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-right_normal.png");

		// Token: 0x04001DDC RID: 7644
		public static BaseImage int_buttonbar_right_over = new BaseImage(AssetPaths.AssetIconsCommon, "int_buttonbar-right_over.png");

		// Token: 0x04001DDD RID: 7645
		public static BaseImage int_insetpanel_lighten_bottom_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-lighten_bottom-left.png");

		// Token: 0x04001DDE RID: 7646
		public static BaseImage int_insetpanel_lighten_bottom_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-lighten_bottom-right.png");

		// Token: 0x04001DDF RID: 7647
		public static BaseImage int_insetpanel_lighten_middle = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-lighten_middle.png");

		// Token: 0x04001DE0 RID: 7648
		public static BaseImage int_insetpanel_lighten_top_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-lighten_top-left.png");

		// Token: 0x04001DE1 RID: 7649
		public static BaseImage int_insetpanel_lighten_top_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_insetpanel-lighten_top-right.png");

		// Token: 0x04001DE2 RID: 7650
		public static BaseImage int_parenthesis_left = new BaseImage(AssetPaths.AssetIconsCommon, "int_parenthesis_left.png");

		// Token: 0x04001DE3 RID: 7651
		public static BaseImage int_parenthesis_right = new BaseImage(AssetPaths.AssetIconsCommon, "int_parenthesis_right.png");

		// Token: 0x04001DE4 RID: 7652
		public static BaseImage int_multiplyer_shadow_x1 = new BaseImage(AssetPaths.AssetIconsCommon, "int_multiplyer_shadow_x1.png");

		// Token: 0x04001DE5 RID: 7653
		public static BaseImage int_multiplyer_shadow_x2 = new BaseImage(AssetPaths.AssetIconsCommon, "int_multiplyer_shadow_x2.png");

		// Token: 0x04001DE6 RID: 7654
		public static BaseImage int_multiplyer_shadow_x3 = new BaseImage(AssetPaths.AssetIconsCommon, "int_multiplyer_shadow_x3.png");

		// Token: 0x04001DE7 RID: 7655
		public static BaseImage r_bld_icon_mil_guardhouse_2 = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_2.png");

		// Token: 0x04001DE8 RID: 7656
		public static BaseImage r_bld_icon_mil_guardhouse_2_over = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_2_over.png");

		// Token: 0x04001DE9 RID: 7657
		public static BaseImage r_bld_icon_mil_guardhouse_3 = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_3.png");

		// Token: 0x04001DEA RID: 7658
		public static BaseImage r_bld_icon_mil_guardhouse_3_over = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_3_over.png");

		// Token: 0x04001DEB RID: 7659
		public static BaseImage r_bld_icon_mil_guardhouse_4 = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_4.png");

		// Token: 0x04001DEC RID: 7660
		public static BaseImage r_bld_icon_mil_guardhouse_4_over = new BaseImage(AssetPaths.AssetIconsCommon, "r_bld-icon_mil_guardhouse_4_over.png");

		// Token: 0x04001DED RID: 7661
		public static BaseImage r_popularity_panel_events_illustration_bandits = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_bandits.png");

		// Token: 0x04001DEE RID: 7662
		public static BaseImage r_popularity_panel_events_illustration_beginner = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_beginner.png");

		// Token: 0x04001DEF RID: 7663
		public static BaseImage r_popularity_panel_events_illustration_plague = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_plague.png");

		// Token: 0x04001DF0 RID: 7664
		public static BaseImage r_popularity_panel_events_illustration_rats = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_rats.png");

		// Token: 0x04001DF1 RID: 7665
		public static BaseImage r_popularity_panel_events_illustration_rebellion = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_rebellion.png");

		// Token: 0x04001DF2 RID: 7666
		public static BaseImage r_popularity_panel_events_illustration_storms = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_storms.png");

		// Token: 0x04001DF3 RID: 7667
		public static BaseImage r_popularity_panel_events_illustration_weather_bad_1 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_-1.png");

		// Token: 0x04001DF4 RID: 7668
		public static BaseImage r_popularity_panel_events_illustration_weather_bad_2 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_-2.png");

		// Token: 0x04001DF5 RID: 7669
		public static BaseImage r_popularity_panel_events_illustration_weather_bad_3 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_-3.png");

		// Token: 0x04001DF6 RID: 7670
		public static BaseImage r_popularity_panel_events_illustration_weather_bad_4 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_-4.png");

		// Token: 0x04001DF7 RID: 7671
		public static BaseImage r_popularity_panel_events_illustration_weather_bad_5 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_-5.png");

		// Token: 0x04001DF8 RID: 7672
		public static BaseImage r_popularity_panel_events_illustration_weather_neutral = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_0.png");

		// Token: 0x04001DF9 RID: 7673
		public static BaseImage r_popularity_panel_events_illustration_weather_good_1 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_plus1.png");

		// Token: 0x04001DFA RID: 7674
		public static BaseImage r_popularity_panel_events_illustration_weather_good_2 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_plus2.png");

		// Token: 0x04001DFB RID: 7675
		public static BaseImage r_popularity_panel_events_illustration_weather_good_3 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_plus3.png");

		// Token: 0x04001DFC RID: 7676
		public static BaseImage r_popularity_panel_events_illustration_weather_good_4 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_plus4.png");

		// Token: 0x04001DFD RID: 7677
		public static BaseImage r_popularity_panel_events_illustration_weather_good_5 = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_weather_plus5.png");

		// Token: 0x04001DFE RID: 7678
		public static BaseImage r_popularity_panel_events_illustration_wolves = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_wolves.png");

		// Token: 0x04001DFF RID: 7679
		public static BaseImage r_popularity_panel_events_illustration_castle = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_castle.png");

		// Token: 0x04001E00 RID: 7680
		public static BaseImage r_popularity_panel_events_illustration_castle_green = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_castle_green.png");

		// Token: 0x04001E01 RID: 7681
		public static BaseImage r_popularity_panel_events_illustration_blessing = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_blessings.png");

		// Token: 0x04001E02 RID: 7682
		public static BaseImage r_popularity_panel_events_illustration_inquisition = new BaseImage(AssetPaths.AssetIconsCommon, "r_popularity_panel_events_illustration_Inquisition.png");

		// Token: 0x04001E03 RID: 7683
		public static BaseImage popularityFace = new BaseImage(AssetPaths.AssetIconsCommon, "popularity_face.png");

		// Token: 0x04001E04 RID: 7684
		public static BaseImage int_tax_panel_back_semipopulated = new BaseImage(AssetPaths.AssetIconsCommon, "int_tax_panel_back_semipopulated.png");

		// Token: 0x04001E05 RID: 7685
		public static BaseImage interface_bar_top_left_empty = new BaseImage(AssetPaths.AssetIconsCommon, "menubar_left.png");

		// Token: 0x04001E06 RID: 7686
		public static BaseImage goods_background = new BaseImage(AssetPaths.AssetIconsCommon, "goods_background.png");

		// Token: 0x04001E07 RID: 7687
		public static BaseImage building_icon_circle = new BaseImage(AssetPaths.AssetIconsCommon, "building_icon_circle.png");

		// Token: 0x04001E08 RID: 7688
		public static BaseImage r_building_panel_inset_small = new BaseImage(AssetPaths.AssetIconsCommon, "r_building_panel_inset_small.png");

		// Token: 0x04001E09 RID: 7689
		public static BaseImage lite_9slice_panel_top_left = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_top_left");

		// Token: 0x04001E0A RID: 7690
		public static BaseImage lite_9slice_panel_top_mid = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_top_mid");

		// Token: 0x04001E0B RID: 7691
		public static BaseImage lite_9slice_panel_top_right = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_top_right");

		// Token: 0x04001E0C RID: 7692
		public static BaseImage lite_9slice_panel_mid_left = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_mid_left");

		// Token: 0x04001E0D RID: 7693
		public static BaseImage lite_9slice_panel_mid_mid = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_mid_mid");

		// Token: 0x04001E0E RID: 7694
		public static BaseImage lite_9slice_panel_mid_right = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_mid_right");

		// Token: 0x04001E0F RID: 7695
		public static BaseImage lite_9slice_panel_bottom_left = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_bottom_left");

		// Token: 0x04001E10 RID: 7696
		public static BaseImage lite_9slice_panel_bottom_mid = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_bottom_mid");

		// Token: 0x04001E11 RID: 7697
		public static BaseImage lite_9slice_panel_bottom_right = new BaseImage(AssetPaths.AssetIconsCommon, "nineslice_lite_inset_bottom_right");

		// Token: 0x04001E12 RID: 7698
		public static BaseImage brown_24wide_thumb_bottom = new BaseImage(AssetPaths.AssetIconsCommon, "brown_24wide_thumb_bottom.png");

		// Token: 0x04001E13 RID: 7699
		public static BaseImage brown_24wide_thumb_middle = new BaseImage(AssetPaths.AssetIconsCommon, "brown_24wide_thumb_middle.png");

		// Token: 0x04001E14 RID: 7700
		public static BaseImage brown_24wide_thumb_top = new BaseImage(AssetPaths.AssetIconsCommon, "brown_24wide_thumb_top.png");

		// Token: 0x04001E15 RID: 7701
		public static BaseImage brown_mail2_button_blue_141wide_normal = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_141wide_normal.png");

		// Token: 0x04001E16 RID: 7702
		public static BaseImage brown_mail2_button_blue_141wide_over = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_141wide_over.png");

		// Token: 0x04001E17 RID: 7703
		public static BaseImage brown_mail2_button_blue_141wide_pushed = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_141wide_pushed.png");

		// Token: 0x04001E18 RID: 7704
		public static BaseImage brown_misc_button_blue_210wide_normal = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_210wide_normal.png");

		// Token: 0x04001E19 RID: 7705
		public static BaseImage brown_misc_button_blue_210wide_pushed = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_210wide_pushed.png");

		// Token: 0x04001E1A RID: 7706
		public static BaseImage brown_misc_button_blue_210wide_over = new BaseImage(AssetPaths.AssetIconsCommon, "brown_button_blue_210wide_over.png");

		// Token: 0x04001E1B RID: 7707
		public static BaseImage brown_mail2_field_bar_mail_divider = new BaseImage(AssetPaths.AssetIconsCommon, "brown_field_bar_mail_divider.png");

		// Token: 0x04001E1C RID: 7708
		public static BaseImage brown_mail2_field_bar_mail_left = new BaseImage(AssetPaths.AssetIconsCommon, "brown_field_bar_mail_left.png");

		// Token: 0x04001E1D RID: 7709
		public static BaseImage brown_mail2_field_bar_mail_middle = new BaseImage(AssetPaths.AssetIconsCommon, "brown_field_bar_mail_middle.png");

		// Token: 0x04001E1E RID: 7710
		public static BaseImage brown_mail2_field_bar_mail_right = new BaseImage(AssetPaths.AssetIconsCommon, "brown_field_bar_mail_right.png");

		// Token: 0x04001E1F RID: 7711
		public static BaseImage brown_lineitem_strip_02_dark = new BaseImage(AssetPaths.AssetIconsCommon, "brown_lineitem_strip_02_dark.png");

		// Token: 0x04001E20 RID: 7712
		public static BaseImage brown_lineitem_strip_02_light = new BaseImage(AssetPaths.AssetIconsCommon, "brown_lineitem_strip_02_light.png");

		// Token: 0x04001E21 RID: 7713
		public static BaseImage[] se_tabs = BaseImage.createFromUV(AssetPaths.AssetIconsStockExchange, "tabs_market", 4);

		// Token: 0x04001E22 RID: 7714
		public static BaseImage[] int_hilow_buttons = BaseImage.createFromUV(AssetPaths.AssetIconsStockExchange, "int_button_hi_low", 6);

		// Token: 0x04001E23 RID: 7715
		public static BaseImage int_insetpanel_b_bottom_left = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_bottom_left.png");

		// Token: 0x04001E24 RID: 7716
		public static BaseImage int_insetpanel_b_bottom_right = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_bottom_right.png");

		// Token: 0x04001E25 RID: 7717
		public static BaseImage int_insetpanel_b_middle_bottom = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_bottom_middle.png");

		// Token: 0x04001E26 RID: 7718
		public static BaseImage int_insetpanel_b_middle_left = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_middle_left.png");

		// Token: 0x04001E27 RID: 7719
		public static BaseImage int_insetpanel_b_middle_right = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_middle_right.png");

		// Token: 0x04001E28 RID: 7720
		public static BaseImage int_insetpanel_b_middle_top = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_top_middle.png");

		// Token: 0x04001E29 RID: 7721
		public static BaseImage int_insetpanel_b_middle = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_middle_middle.png");

		// Token: 0x04001E2A RID: 7722
		public static BaseImage int_insetpanel_b_top_left = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_top_left.png");

		// Token: 0x04001E2B RID: 7723
		public static BaseImage int_insetpanel_b_top_right = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_insetpanel-b_top_right.png");

		// Token: 0x04001E2C RID: 7724
		public static BaseImage int_button_droparrow_down = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow_down.png");

		// Token: 0x04001E2D RID: 7725
		public static BaseImage int_button_droparrow_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow_normal.png");

		// Token: 0x04001E2E RID: 7726
		public static BaseImage int_button_droparrow_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow_over.png");

		// Token: 0x04001E2F RID: 7727
		public static BaseImage int_button_droparrow_up_down = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow-up_down.png");

		// Token: 0x04001E30 RID: 7728
		public static BaseImage int_button_droparrow_up_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow-up_normal.png");

		// Token: 0x04001E31 RID: 7729
		public static BaseImage int_button_droparrow_up_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_droparrow-up_over.png");

		// Token: 0x04001E32 RID: 7730
		public static BaseImage int_button_findonmap_in = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_findonmap_in.png");

		// Token: 0x04001E33 RID: 7731
		public static BaseImage int_button_findonmap_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_findonmap_normal.png");

		// Token: 0x04001E34 RID: 7732
		public static BaseImage int_button_findonmap_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_button_findonmap_over.png");

		// Token: 0x04001E35 RID: 7733
		public static BaseImage int_icon_trader = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_icon_trader.png");

		// Token: 0x04001E36 RID: 7734
		public static BaseImage int_lineitem_inset_left = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_lineitem_inset_left.png");

		// Token: 0x04001E37 RID: 7735
		public static BaseImage int_lineitem_inset_middle = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_lineitem_inset_middle.png");

		// Token: 0x04001E38 RID: 7736
		public static BaseImage int_lineitem_inset_right = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_lineitem_inset_right.png");

		// Token: 0x04001E39 RID: 7737
		public static BaseImage int_slidebar_ruler = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_ruler.png");

		// Token: 0x04001E3A RID: 7738
		public static BaseImage int_slidebar_thumb_left_in = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_left_in.png");

		// Token: 0x04001E3B RID: 7739
		public static BaseImage int_slidebar_thumb_left_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_left_normal.png");

		// Token: 0x04001E3C RID: 7740
		public static BaseImage int_slidebar_thumb_left_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_left_over.png");

		// Token: 0x04001E3D RID: 7741
		public static BaseImage int_slidebar_thumb_middle_in = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_middle_in.png");

		// Token: 0x04001E3E RID: 7742
		public static BaseImage int_slidebar_thumb_middle_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_middle_normal.png");

		// Token: 0x04001E3F RID: 7743
		public static BaseImage int_slidebar_thumb_middle_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_middle_over.png");

		// Token: 0x04001E40 RID: 7744
		public static BaseImage int_slidebar_thumb_right_in = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_right_in.png");

		// Token: 0x04001E41 RID: 7745
		public static BaseImage int_slidebar_thumb_right_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_right_normal.png");

		// Token: 0x04001E42 RID: 7746
		public static BaseImage int_slidebar_thumb_right_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_slidebar_thumb_right_over.png");

		// Token: 0x04001E43 RID: 7747
		public static BaseImage int_storage_tab_01_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_01_normal.png");

		// Token: 0x04001E44 RID: 7748
		public static BaseImage int_storage_tab_01_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_01_over.png");

		// Token: 0x04001E45 RID: 7749
		public static BaseImage int_storage_tab_01_selected = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_01_selected.png");

		// Token: 0x04001E46 RID: 7750
		public static BaseImage int_storage_tab_02_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_02_normal.png");

		// Token: 0x04001E47 RID: 7751
		public static BaseImage int_storage_tab_02_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_02_over.png");

		// Token: 0x04001E48 RID: 7752
		public static BaseImage int_storage_tab_02_selected = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_02_selected.png");

		// Token: 0x04001E49 RID: 7753
		public static BaseImage int_storage_tab_03_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_03_normal.png");

		// Token: 0x04001E4A RID: 7754
		public static BaseImage int_storage_tab_03_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_03_over.png");

		// Token: 0x04001E4B RID: 7755
		public static BaseImage int_storage_tab_03_selected = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_03_selected.png");

		// Token: 0x04001E4C RID: 7756
		public static BaseImage int_storage_tab_04_normal = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_04_normal.png");

		// Token: 0x04001E4D RID: 7757
		public static BaseImage int_storage_tab_04_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_04_over.png");

		// Token: 0x04001E4E RID: 7758
		public static BaseImage int_storage_tab_04_selected = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_storage_tab_04_selected.png");

		// Token: 0x04001E4F RID: 7759
		public static BaseImage int_white_highlight_bar = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_white_highlight_bar.png");

		// Token: 0x04001E50 RID: 7760
		public static BaseImage int_villagelist_panel = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_villagelist_panel.png");

		// Token: 0x04001E51 RID: 7761
		public static BaseImage int_villagelist_panel_highlight = new BaseImage(AssetPaths.AssetIconsStockExchange, "int_villagelist_panel-highlight.png");

		// Token: 0x04001E52 RID: 7762
		public static BaseImage tab_villagename_forward = new BaseImage(AssetPaths.AssetIconsStockExchange, "tab_villagename_forward.png");

		// Token: 0x04001E53 RID: 7763
		public static BaseImage tab_villagename_back = new BaseImage(AssetPaths.AssetIconsStockExchange, "tab_villagename_back.png");

		// Token: 0x04001E54 RID: 7764
		public static BaseImage tab_villagename_over = new BaseImage(AssetPaths.AssetIconsStockExchange, "tab_villagename_over.png");

		// Token: 0x04001E55 RID: 7765
		public static BaseImage star_market_1 = new BaseImage(AssetPaths.AssetIconsStockExchange, "star_market_01.png");

		// Token: 0x04001E56 RID: 7766
		public static BaseImage star_market_2 = new BaseImage(AssetPaths.AssetIconsStockExchange, "star_market_02.png");

		// Token: 0x04001E57 RID: 7767
		public static BaseImage[] medal_images = BaseImage.createFromUV(AssetPaths.AssetIconsAchievements, "medal_images", 58);

		// Token: 0x04001E58 RID: 7768
		public static BaseImage[] achievement_ribbons_base = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_blue_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_cyan_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_green_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_grey_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_kelly_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_liteblue_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_magenta_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_mint_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_orange_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_pink_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_purple_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_red_desat"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_solid_yellow_desat")
		};

		// Token: 0x04001E59 RID: 7769
		public static BaseImage[] achievement_ribbons_edges = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_blue"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_cyan"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_green"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_grey"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_kelly"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_liteblue"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_magenta"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_mint"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_orange"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_pink"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_purple"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_red"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_edges_yellow")
		};

		// Token: 0x04001E5A RID: 7770
		public static BaseImage[] achievement_ribbons_centre = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_blue"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_cyan"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_green"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_grey"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_kelly"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_liteblue"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_magenta"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_mint"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_orange"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_pink"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_purple"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_red"),
			new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_yellow")
		};

		// Token: 0x04001E5B RID: 7771
		public static BaseImage achievement_woodback_middletile = new BaseImage(AssetPaths.AssetIconsAchievements, "achievements_woodback_middletile");

		// Token: 0x04001E5C RID: 7772
		public static BaseImage achievements_woodback_top_inset = new BaseImage(AssetPaths.AssetIconsAchievements, "achievements_woodback_top_inset");

		// Token: 0x04001E5D RID: 7773
		public static BaseImage panel_cover_top = new BaseImage(AssetPaths.AssetIconsAchievements, "panel_cover_top");

		// Token: 0x04001E5E RID: 7774
		public static BaseImage panel_cover_bottom = new BaseImage(AssetPaths.AssetIconsAchievements, "panel_cover_bottom");

		// Token: 0x04001E5F RID: 7775
		public static BaseImage char_achievementOverlay = new BaseImage(AssetPaths.AssetIconsAchievements, "char_achievement_overlay");

		// Token: 0x04001E60 RID: 7776
		public static BaseImage ribbon_comp_centerstripe_gold = new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_gold.png");

		// Token: 0x04001E61 RID: 7777
		public static BaseImage ribbon_comp_centerstripe_silver = new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_centerstripe_silver.png");

		// Token: 0x04001E62 RID: 7778
		public static BaseImage ribbon_comp_nail = new BaseImage(AssetPaths.AssetIconsAchievements, "ribbon_comp_nail.png");

		// Token: 0x04001E63 RID: 7779
		public static BaseImage[] captains_commands_icons = BaseImage.createFromUV(AssetPaths.AssetIconsCastle, "CaptainCommands", 24);

		// Token: 0x04001E64 RID: 7780
		public static BaseImage castlebar_defenses_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_defenses_normal.png");

		// Token: 0x04001E65 RID: 7781
		public static BaseImage castlebar_defenses_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_defenses_selected.png");

		// Token: 0x04001E66 RID: 7782
		public static BaseImage castlebar_stone_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_stone_normal.png");

		// Token: 0x04001E67 RID: 7783
		public static BaseImage castlebar_stone_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_stone_selected.png");

		// Token: 0x04001E68 RID: 7784
		public static BaseImage castlebar_unit_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_unit_normal.png");

		// Token: 0x04001E69 RID: 7785
		public static BaseImage castlebar_unit_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_unit_selected.png");

		// Token: 0x04001E6A RID: 7786
		public static BaseImage castlebar_wood_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_wood_normal.png");

		// Token: 0x04001E6B RID: 7787
		public static BaseImage castlebar_wood_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_wood_selected.png");

		// Token: 0x04001E6C RID: 7788
		public static BaseImage castlebar_lock_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_lock_normal.png");

		// Token: 0x04001E6D RID: 7789
		public static BaseImage castlebar_lock_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_lock_selected.png");

		// Token: 0x04001E6E RID: 7790
		public static BaseImage castlescreen_panelback_A = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_panelback_A.png");

		// Token: 0x04001E6F RID: 7791
		public static BaseImage castlescreen_panelback_B = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_panelback_B.png");

		// Token: 0x04001E70 RID: 7792
		public static BaseImage castlescreen_panelback_C = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_panelback_C.png");

		// Token: 0x04001E71 RID: 7793
		public static BaseImage castlescreen_panel_halfinset_def_select = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_panel-halfinset_def-select.png");

		// Token: 0x04001E72 RID: 7794
		public static BaseImage castlescreen_panel_halfinset_off_select = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_panel-halfinset_off-select.png");

		// Token: 0x04001E73 RID: 7795
		public static BaseImage castlescreen_sendback_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_sendback_normal.png");

		// Token: 0x04001E74 RID: 7796
		public static BaseImage castlescreen_sendback_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_sendback_over.png");

		// Token: 0x04001E75 RID: 7797
		public static BaseImage castlescreen_stance_def_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-def_normal.png");

		// Token: 0x04001E76 RID: 7798
		public static BaseImage castlescreen_stance_def_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-def_over.png");

		// Token: 0x04001E77 RID: 7799
		public static BaseImage castlescreen_stance_mix_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-mix_normal.png");

		// Token: 0x04001E78 RID: 7800
		public static BaseImage castlescreen_stance_mix_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-mix_over.png");

		// Token: 0x04001E79 RID: 7801
		public static BaseImage castlescreen_stance_off_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-off_normal.png");

		// Token: 0x04001E7A RID: 7802
		public static BaseImage castlescreen_stance_off_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_stance-off_over.png");

		// Token: 0x04001E7B RID: 7803
		public static BaseImage castlescreen_take_from_castle = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_take-from-castle.png");

		// Token: 0x04001E7C RID: 7804
		public static BaseImage castlescreen_unitbrush_1x1_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x1_normal.png");

		// Token: 0x04001E7D RID: 7805
		public static BaseImage castlescreen_unitbrush_1x1_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x1_over.png");

		// Token: 0x04001E7E RID: 7806
		public static BaseImage castlescreen_unitbrush_1x5_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x5_normal.png");

		// Token: 0x04001E7F RID: 7807
		public static BaseImage castlescreen_unitbrush_1x5_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x5_over.png");

		// Token: 0x04001E80 RID: 7808
		public static BaseImage castlescreen_unitbrush_3x3_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_3x3_normal.png");

		// Token: 0x04001E81 RID: 7809
		public static BaseImage castlescreen_unitbrush_3x3_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_3x3_over.png");

		// Token: 0x04001E82 RID: 7810
		public static BaseImage castlescreen_unitbrush_5x5_normal = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_5x5_normal.png");

		// Token: 0x04001E83 RID: 7811
		public static BaseImage castlescreen_unitbrush_5x5_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_5x5_over.png");

		// Token: 0x04001E84 RID: 7812
		public static BaseImage castlescreen_unit_capsule = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unit-capsule.png");

		// Token: 0x04001E85 RID: 7813
		public static BaseImage r_building_miltary_archer_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_archer_green.png");

		// Token: 0x04001E86 RID: 7814
		public static BaseImage r_building_miltary_archer_over_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_archer_over_green.png");

		// Token: 0x04001E87 RID: 7815
		public static BaseImage r_building_miltary_captain_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_captain_normal.png");

		// Token: 0x04001E88 RID: 7816
		public static BaseImage r_building_miltary_captain_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_captain_over.png");

		// Token: 0x04001E89 RID: 7817
		public static BaseImage r_building_miltary_castleinfo_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_castleinfo_normal.png");

		// Token: 0x04001E8A RID: 7818
		public static BaseImage r_building_miltary_castleinfo_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_castleinfo_over.png");

		// Token: 0x04001E8B RID: 7819
		public static BaseImage r_building_miltary_deletemode_off_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_deletemode-off_normal.png");

		// Token: 0x04001E8C RID: 7820
		public static BaseImage r_building_miltary_deletemode_off_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_deletemode-off_over.png");

		// Token: 0x04001E8D RID: 7821
		public static BaseImage r_building_miltary_deletemode_on_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_deletemode-on_normal.png");

		// Token: 0x04001E8E RID: 7822
		public static BaseImage r_building_miltary_deletemode_on_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_deletemode-on_over.png");

		// Token: 0x04001E8F RID: 7823
		public static BaseImage r_building_miltary_flag_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_flag_normal.png");

		// Token: 0x04001E90 RID: 7824
		public static BaseImage r_building_miltary_flag_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_flag_over.png");

		// Token: 0x04001E91 RID: 7825
		public static BaseImage r_building_miltary_peasent_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_peasent_green.png");

		// Token: 0x04001E92 RID: 7826
		public static BaseImage r_building_miltary_peasent_over_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_peasent_over_green.png");

		// Token: 0x04001E93 RID: 7827
		public static BaseImage r_building_miltary_pikemen_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_pikemen_green.png");

		// Token: 0x04001E94 RID: 7828
		public static BaseImage r_building_miltary_pikemen_over_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_pikemen_over_green.png");

		// Token: 0x04001E95 RID: 7829
		public static BaseImage r_building_miltary_repair_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_repair_normal.png");

		// Token: 0x04001E96 RID: 7830
		public static BaseImage r_building_miltary_repair_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_repair_over.png");

		// Token: 0x04001E97 RID: 7831
		public static BaseImage r_building_miltary_repair_pushed = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_repair_pushed.png");

		// Token: 0x04001E98 RID: 7832
		public static BaseImage r_building_miltary_sub_category_units = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_sub-category_units.png");

		// Token: 0x04001E99 RID: 7833
		public static BaseImage r_building_miltary_sub_category_units_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_sub-category_units_green.png");

		// Token: 0x04001E9A RID: 7834
		public static BaseImage r_building_miltary_sub_category_units_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_sub-category_units_over.png");

		// Token: 0x04001E9B RID: 7835
		public static BaseImage r_building_miltary_sub_category_units_over_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_sub-category_units_over_green.png");

		// Token: 0x04001E9C RID: 7836
		public static BaseImage r_building_miltary_swordsman_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_swordsman_green.png");

		// Token: 0x04001E9D RID: 7837
		public static BaseImage r_building_miltary_swordsman_over_green = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_swordsman_over_green.png");

		// Token: 0x04001E9E RID: 7838
		public static BaseImage r_building_miltary_viewmode_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_viewmode_normal.png");

		// Token: 0x04001E9F RID: 7839
		public static BaseImage r_building_miltary_viewmode_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_viewmode_over.png");

		// Token: 0x04001EA0 RID: 7840
		public static BaseImage r_building_miltary_viewmode_pushed = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_viewmode_pushed.png");

		// Token: 0x04001EA1 RID: 7841
		public static BaseImage r_building_miltary_ballista = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_ballista.png");

		// Token: 0x04001EA2 RID: 7842
		public static BaseImage r_building_miltary_ballista_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_ballista_over.png");

		// Token: 0x04001EA3 RID: 7843
		public static BaseImage r_building_miltary_tunnels = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_tunnels.png");

		// Token: 0x04001EA4 RID: 7844
		public static BaseImage r_building_miltary_tunnels_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_tunnels_over.png");

		// Token: 0x04001EA5 RID: 7845
		public static BaseImage r_building_miltary_turrets = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_turrets.png");

		// Token: 0x04001EA6 RID: 7846
		public static BaseImage r_building_miltary_turrets_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_turrets_over.png");

		// Token: 0x04001EA7 RID: 7847
		public static BaseImage r_building_miltary_bombard = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_bombard.png");

		// Token: 0x04001EA8 RID: 7848
		public static BaseImage r_building_miltary_bombard_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_bombard_over.png");

		// Token: 0x04001EA9 RID: 7849
		public static BaseImage castlebar_unit_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_unit_over.png");

		// Token: 0x04001EAA RID: 7850
		public static BaseImage castlebar_wood_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_wood_over.png");

		// Token: 0x04001EAB RID: 7851
		public static BaseImage castlebar_stone_overl = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_stone_overl.png");

		// Token: 0x04001EAC RID: 7852
		public static BaseImage castlebar_defenses_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_defenses_over.png");

		// Token: 0x04001EAD RID: 7853
		public static BaseImage castlebar_lock_over = new BaseImage(AssetPaths.AssetIconsCastle, "castlebar_lock_over.png");

		// Token: 0x04001EAE RID: 7854
		public static BaseImage r_building_miltary_gatehouse_wood_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_gatehouse_wood_over.png");

		// Token: 0x04001EAF RID: 7855
		public static BaseImage r_building_miltary_gatehouse_wood = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_gatehouse_wood.png");

		// Token: 0x04001EB0 RID: 7856
		public static BaseImage castlescreen_unitbrush_3x3_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_3x3_selected.png");

		// Token: 0x04001EB1 RID: 7857
		public static BaseImage r_building_miltary_flag_blue_over = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_flag-blue_over.png");

		// Token: 0x04001EB2 RID: 7858
		public static BaseImage castlescreen_unitbrush_1x1_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x1_selected.png");

		// Token: 0x04001EB3 RID: 7859
		public static BaseImage castlescreen_unitbrush_5x5_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_5x5_selected.png");

		// Token: 0x04001EB4 RID: 7860
		public static BaseImage r_building_miltary_flag_blue_normal = new BaseImage(AssetPaths.AssetIconsCastle, "r_building_miltary_flag-blue_normal.png");

		// Token: 0x04001EB5 RID: 7861
		public static BaseImage castlescreen_unitbrush_1x5_selected = new BaseImage(AssetPaths.AssetIconsCastle, "castlescreen_unitbrush_1x5_selected.png");

		// Token: 0x04001EB6 RID: 7862
		public static BaseImage formations_img = new BaseImage(AssetPaths.AssetIconsCastle, "formation_img");

		// Token: 0x04001EB7 RID: 7863
		public static BaseImage preset_castle_in = new BaseImage(AssetPaths.AssetIconsCastle, "preset_castle_in_up.png");

		// Token: 0x04001EB8 RID: 7864
		public static BaseImage preset_castle_in_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_castle_in_over.png");

		// Token: 0x04001EB9 RID: 7865
		public static BaseImage preset_castle_in_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_castle_in_down.png");

		// Token: 0x04001EBA RID: 7866
		public static BaseImage preset_castle_out = new BaseImage(AssetPaths.AssetIconsCastle, "preset_cloud_in_up.png");

		// Token: 0x04001EBB RID: 7867
		public static BaseImage preset_castle_out_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_cloud_in_over.png");

		// Token: 0x04001EBC RID: 7868
		public static BaseImage preset_castle_out_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_cloud_in_down.png");

		// Token: 0x04001EBD RID: 7869
		public static BaseImage preset_delete = new BaseImage(AssetPaths.AssetIconsCastle, "preset_delete_up.png");

		// Token: 0x04001EBE RID: 7870
		public static BaseImage preset_delete_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_delete_over.png");

		// Token: 0x04001EBF RID: 7871
		public static BaseImage preset_delete_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_delete_down.png");

		// Token: 0x04001EC0 RID: 7872
		public static BaseImage preset_rename = new BaseImage(AssetPaths.AssetIconsCastle, "preset_rename_up.png");

		// Token: 0x04001EC1 RID: 7873
		public static BaseImage preset_rename_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_rename_over.png");

		// Token: 0x04001EC2 RID: 7874
		public static BaseImage preset_rename_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_rename_down.png");

		// Token: 0x04001EC3 RID: 7875
		public static BaseImage preset_info = new BaseImage(AssetPaths.AssetIconsCastle, "preset_preview_up.png");

		// Token: 0x04001EC4 RID: 7876
		public static BaseImage preset_info_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_preview_over.png");

		// Token: 0x04001EC5 RID: 7877
		public static BaseImage preset_info_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_preview_down.png");

		// Token: 0x04001EC6 RID: 7878
		public static BaseImage preset_list = new BaseImage(AssetPaths.AssetIconsCastle, "preset_list_up.png");

		// Token: 0x04001EC7 RID: 7879
		public static BaseImage preset_list_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_list_over.png");

		// Token: 0x04001EC8 RID: 7880
		public static BaseImage preset_list_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_list_down.png");

		// Token: 0x04001EC9 RID: 7881
		public static BaseImage preset_upload = new BaseImage(AssetPaths.AssetIconsCastle, "preset_upload_normal.png");

		// Token: 0x04001ECA RID: 7882
		public static BaseImage preset_upload_over = new BaseImage(AssetPaths.AssetIconsCastle, "preset_upload_over.png");

		// Token: 0x04001ECB RID: 7883
		public static BaseImage preset_upload_down = new BaseImage(AssetPaths.AssetIconsCastle, "preset_upload_down.png");

		// Token: 0x04001ECC RID: 7884
		public static BaseImage preset_9slice_upload_top_left = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_top_left.png");

		// Token: 0x04001ECD RID: 7885
		public static BaseImage preset_9slice_upload_top_mid = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_top_mid.png");

		// Token: 0x04001ECE RID: 7886
		public static BaseImage preset_9slice_upload_top_right = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_top_right.png");

		// Token: 0x04001ECF RID: 7887
		public static BaseImage preset_9slice_upload_mid_left = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_mid_left.png");

		// Token: 0x04001ED0 RID: 7888
		public static BaseImage preset_9slice_upload_mid_mid = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_mid_mid.png");

		// Token: 0x04001ED1 RID: 7889
		public static BaseImage preset_9slice_upload_mid_right = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_mid_right.png");

		// Token: 0x04001ED2 RID: 7890
		public static BaseImage preset_9slice_upload_bottom_left = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_bottom_left.png");

		// Token: 0x04001ED3 RID: 7891
		public static BaseImage preset_9slice_upload_bottom_mid = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_bottom_mid.png");

		// Token: 0x04001ED4 RID: 7892
		public static BaseImage preset_9slice_upload_bottom_right = new BaseImage(AssetPaths.AssetIconsCastle, "nineslice_upload_bottom_right.png");

		// Token: 0x04001ED5 RID: 7893
		public static BaseImage preset_req_capital = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_capital.png");

		// Token: 0x04001ED6 RID: 7894
		public static BaseImage preset_req_defence = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_defence.png");

		// Token: 0x04001ED7 RID: 7895
		public static BaseImage preset_req_fortification = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_fortification.png");

		// Token: 0x04001ED8 RID: 7896
		public static BaseImage preset_req_capital_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_capital_red.png");

		// Token: 0x04001ED9 RID: 7897
		public static BaseImage preset_req_defence_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_defence_red.png");

		// Token: 0x04001EDA RID: 7898
		public static BaseImage preset_req_fortification_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_fortification_red.png");

		// Token: 0x04001EDB RID: 7899
		public static BaseImage preset_req_wood = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_wood.png");

		// Token: 0x04001EDC RID: 7900
		public static BaseImage preset_req_wood_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_wood_red.png");

		// Token: 0x04001EDD RID: 7901
		public static BaseImage preset_req_stone = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_stone.png");

		// Token: 0x04001EDE RID: 7902
		public static BaseImage preset_req_stone_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_stone_red.png");

		// Token: 0x04001EDF RID: 7903
		public static BaseImage preset_req_iron = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_iron.png");

		// Token: 0x04001EE0 RID: 7904
		public static BaseImage preset_req_iron_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_iron_red.png");

		// Token: 0x04001EE1 RID: 7905
		public static BaseImage preset_req_pitch = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_pitch.png");

		// Token: 0x04001EE2 RID: 7906
		public static BaseImage preset_req_pitch_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_pitch_red.png");

		// Token: 0x04001EE3 RID: 7907
		public static BaseImage preset_req_gold = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_gold.png");

		// Token: 0x04001EE4 RID: 7908
		public static BaseImage preset_req_gold_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_gold_red.png");

		// Token: 0x04001EE5 RID: 7909
		public static BaseImage preset_req_time = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_time.png");

		// Token: 0x04001EE6 RID: 7910
		public static BaseImage preset_req_archer = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_archer.png");

		// Token: 0x04001EE7 RID: 7911
		public static BaseImage preset_req_archer_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_archer_red.png");

		// Token: 0x04001EE8 RID: 7912
		public static BaseImage preset_req_captain = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_captain.png");

		// Token: 0x04001EE9 RID: 7913
		public static BaseImage preset_req_captain_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_captain_red.png");

		// Token: 0x04001EEA RID: 7914
		public static BaseImage preset_req_catapult = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_catapult.png");

		// Token: 0x04001EEB RID: 7915
		public static BaseImage preset_req_catapult_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_catapult_red.png");

		// Token: 0x04001EEC RID: 7916
		public static BaseImage preset_req_peasant = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_peasant.png");

		// Token: 0x04001EED RID: 7917
		public static BaseImage preset_req_peasant_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_peasant_red.png");

		// Token: 0x04001EEE RID: 7918
		public static BaseImage preset_req_pikeman = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_pikeman.png");

		// Token: 0x04001EEF RID: 7919
		public static BaseImage preset_req_pikeman_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_pikeman_red.png");

		// Token: 0x04001EF0 RID: 7920
		public static BaseImage preset_req_swordsman = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_swordsman.png");

		// Token: 0x04001EF1 RID: 7921
		public static BaseImage preset_req_swordsman_red = new BaseImage(AssetPaths.AssetIconsCastle, "preset_req_swordsman_red.png");

		// Token: 0x04001EF2 RID: 7922
		public static BaseImage barracks_background = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_background");

		// Token: 0x04001EF3 RID: 7923
		public static BaseImage barracks_fillbar_back = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_fillbar_back");

		// Token: 0x04001EF4 RID: 7924
		public static BaseImage barracks_fillbar_fill_left = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_fillbar_fill-left");

		// Token: 0x04001EF5 RID: 7925
		public static BaseImage barracks_fillbar_fill_mid = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_fillbar_fill-mid");

		// Token: 0x04001EF6 RID: 7926
		public static BaseImage barracks_fillbar_fill_right = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_fillbar_fill-right");

		// Token: 0x04001EF7 RID: 7927
		public static BaseImage barracks_unit_archer = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_archer");

		// Token: 0x04001EF8 RID: 7928
		public static BaseImage barracks_unit_captain = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_captain");

		// Token: 0x04001EF9 RID: 7929
		public static BaseImage barracks_unit_catapult = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_catapult");

		// Token: 0x04001EFA RID: 7930
		public static BaseImage barracks_unit_peasant = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_peasant");

		// Token: 0x04001EFB RID: 7931
		public static BaseImage barracks_unit_pikemen = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_pikemen");

		// Token: 0x04001EFC RID: 7932
		public static BaseImage barracks_unit_swordsman = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_unit_swordsman");

		// Token: 0x04001EFD RID: 7933
		public static BaseImage barracks_screen_bottom_units = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_screen_bottom_units");

		// Token: 0x04001EFE RID: 7934
		public static BaseImage barracks_i_button_normal = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_i_button_normal");

		// Token: 0x04001EFF RID: 7935
		public static BaseImage barracks_i_button_over = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_i_button_over");

		// Token: 0x04001F00 RID: 7936
		public static BaseImage barracks_little_button_normal = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_little_button_normal");

		// Token: 0x04001F01 RID: 7937
		public static BaseImage barracks_little_button_over = new BaseImage(AssetPaths.AssetIconsBarracks, "barracks_little_button_over");

		// Token: 0x04001F02 RID: 7938
		public static BaseImage button3comp_left_normal = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_left_normal");

		// Token: 0x04001F03 RID: 7939
		public static BaseImage button3comp_left_over = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_left_over");

		// Token: 0x04001F04 RID: 7940
		public static BaseImage button3comp_left_pressed = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_left_pressed");

		// Token: 0x04001F05 RID: 7941
		public static BaseImage button3comp_mid_normal = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_mid_normal");

		// Token: 0x04001F06 RID: 7942
		public static BaseImage button3comp_mid_over = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_mid_over");

		// Token: 0x04001F07 RID: 7943
		public static BaseImage button3comp_mid_pushed = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_mid_pushed");

		// Token: 0x04001F08 RID: 7944
		public static BaseImage button3comp_right_normal = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_right_normal");

		// Token: 0x04001F09 RID: 7945
		public static BaseImage button3comp_right_over = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_right_over");

		// Token: 0x04001F0A RID: 7946
		public static BaseImage button3comp_right_pushed = new BaseImage(AssetPaths.AssetIconsBarracks, "button3comp_right_pushed");

		// Token: 0x04001F0B RID: 7947
		public static BaseImage people_01 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_01");

		// Token: 0x04001F0C RID: 7948
		public static BaseImage people_02 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_02");

		// Token: 0x04001F0D RID: 7949
		public static BaseImage people_03 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_03");

		// Token: 0x04001F0E RID: 7950
		public static BaseImage people_04 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_04");

		// Token: 0x04001F0F RID: 7951
		public static BaseImage people_05 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_05");

		// Token: 0x04001F10 RID: 7952
		public static BaseImage people_unitspace_icon_01 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_unitspace_icon_01");

		// Token: 0x04001F11 RID: 7953
		public static BaseImage people_unitspace_icon_02 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_unitspace_icon_02");

		// Token: 0x04001F12 RID: 7954
		public static BaseImage people_unitspace_icon_03 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_unitspace_icon_03");

		// Token: 0x04001F13 RID: 7955
		public static BaseImage people_unitspace_icon_04 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_unitspace_icon_04");

		// Token: 0x04001F14 RID: 7956
		public static BaseImage people_unitspace_icon_05 = new BaseImage(AssetPaths.AssetIconsBarracks, "people_unitspace_icon_05");

		// Token: 0x04001F15 RID: 7957
		public static BaseImage people_background = new BaseImage(AssetPaths.AssetIconsBarracks, "people_background");

		// Token: 0x04001F16 RID: 7958
		public static BaseImage logout_ad_1premfor30crown_01 = new BaseImage(AssetPaths.AssetIconsLogout, "logout_ad_1premfor30crown_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x04001F17 RID: 7959
		public static BaseImage logout_ad_1premfor30crown_01_over = new BaseImage(AssetPaths.AssetIconsLogout, "logout_ad_1premfor30crown_%LANG%_over.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x04001F18 RID: 7960
		public static BaseImage[] logout_bits = BaseImage.createFromUV(AssetPaths.AssetIconsLogout, "logout_bits", 15);

		// Token: 0x04001F19 RID: 7961
		public static BaseImage checkbox_checked = new BaseImage(AssetPaths.AssetIconsLogout, "checkbox_checked.png");

		// Token: 0x04001F1A RID: 7962
		public static BaseImage checkbox_unchecked = new BaseImage(AssetPaths.AssetIconsLogout, "checkbox_unchecked.png");

		// Token: 0x04001F1B RID: 7963
		public static BaseImage logout_slider_back = new BaseImage(AssetPaths.AssetIconsLogout, "logoit_slider_back.png");

		// Token: 0x04001F1C RID: 7964
		public static BaseImage logout_slider_back2 = new BaseImage(AssetPaths.AssetIconsLogout, "logoit_slider_back2.png");

		// Token: 0x04001F1D RID: 7965
		public static BaseImage logout_slider_thumb = new BaseImage(AssetPaths.AssetIconsLogout, "logoit_slider_thumb.png");

		// Token: 0x04001F1E RID: 7966
		public static BaseImage logout_gradation_band = new BaseImage(AssetPaths.AssetIconsLogout, "logout-gradation_band.png");

		// Token: 0x04001F1F RID: 7967
		public static BaseImage logout_background_lhs = new BaseImage(AssetPaths.AssetIconsLogout, "logout_background_lhs.png");

		// Token: 0x04001F20 RID: 7968
		public static BaseImage logout_premium_token = new BaseImage(AssetPaths.AssetIconsLogout, "logout_premium_token.png");

		// Token: 0x04001F21 RID: 7969
		public static BaseImage logout_premium_token_2 = new BaseImage(AssetPaths.AssetIconsLogout, "logout_premium_token_2.png");

		// Token: 0x04001F22 RID: 7970
		public static BaseImage logout_premium_token_30 = new BaseImage(AssetPaths.AssetIconsLogout, "logout_premium_token_30.png");

		// Token: 0x04001F23 RID: 7971
		public static BaseImage logout_premium_token_extendable = new BaseImage(AssetPaths.AssetIconsLogout, "logout_premium_token_x.png");

		// Token: 0x04001F24 RID: 7972
		public static BaseImage logout_text_inset = new BaseImage(AssetPaths.AssetIconsLogout, "logout_text_inset.png");

		// Token: 0x04001F25 RID: 7973
		public static BaseImage logout_text_inset_downarrow_normal = new BaseImage(AssetPaths.AssetIconsLogout, "logout_text_inset_downarrow_normal.png");

		// Token: 0x04001F26 RID: 7974
		public static BaseImage logout_text_inset_downarrow_over = new BaseImage(AssetPaths.AssetIconsLogout, "logout_text_inset_downarrow_over.png");

		// Token: 0x04001F27 RID: 7975
		public static BaseImage RH_button_getpremium_tokens_normal = new BaseImage(AssetPaths.AssetIconsLogout, "RH_button_getpremium_tokens_normal.png");

		// Token: 0x04001F28 RID: 7976
		public static BaseImage RH_button_getpremium_tokens_over = new BaseImage(AssetPaths.AssetIconsLogout, "RH_button_getpremium_tokens_over.png");

		// Token: 0x04001F29 RID: 7977
		public static BaseImage mail_folder_icon_plus = new BaseImage(AssetPaths.AssetIconsMail, "folder_icon_plus.png");

		// Token: 0x04001F2A RID: 7978
		public static BaseImage mail_folder_icon_64_open = new BaseImage(AssetPaths.AssetIconsMail, "folder_icon_64_open.png");

		// Token: 0x04001F2B RID: 7979
		public static BaseImage mail_folder_icon_closed = new BaseImage(AssetPaths.AssetIconsMail, "folder_icon_closed.png");

		// Token: 0x04001F2C RID: 7980
		public static BaseImage mail_folder_icon_open = new BaseImage(AssetPaths.AssetIconsMail, "folder_icon_open.png");

		// Token: 0x04001F2D RID: 7981
		public static BaseImage mail_folder_icon_delete = new BaseImage(AssetPaths.AssetIconsMail, "folder_icon_delete.png");

		// Token: 0x04001F2E RID: 7982
		public static BaseImage mail_inset_white_left = new BaseImage(AssetPaths.AssetIconsMail, "inset_white_left.png");

		// Token: 0x04001F2F RID: 7983
		public static BaseImage mail_inset_white_middle = new BaseImage(AssetPaths.AssetIconsMail, "inset_white_middle.png");

		// Token: 0x04001F30 RID: 7984
		public static BaseImage mail_inset_white_right = new BaseImage(AssetPaths.AssetIconsMail, "inset_white_right.png");

		// Token: 0x04001F31 RID: 7985
		public static BaseImage mail_letter_icon_closed = new BaseImage(AssetPaths.AssetIconsMail, "letter_icon_closed.png");

		// Token: 0x04001F32 RID: 7986
		public static BaseImage mail_letter_icon_open = new BaseImage(AssetPaths.AssetIconsMail, "letter_icon_open.png");

		// Token: 0x04001F33 RID: 7987
		public static BaseImage mail_shadow_bottom = new BaseImage(AssetPaths.AssetIconsMail, "shadow_bottom.png");

		// Token: 0x04001F34 RID: 7988
		public static BaseImage mail_shadow_bottom_left = new BaseImage(AssetPaths.AssetIconsMail, "shadow_bottom_left.png");

		// Token: 0x04001F35 RID: 7989
		public static BaseImage mail_shadow_bottom_right = new BaseImage(AssetPaths.AssetIconsMail, "shadow_bottom_right.png");

		// Token: 0x04001F36 RID: 7990
		public static BaseImage mail_shadow_right = new BaseImage(AssetPaths.AssetIconsMail, "shadow_right.png");

		// Token: 0x04001F37 RID: 7991
		public static BaseImage mail_shadow_top_right = new BaseImage(AssetPaths.AssetIconsMail, "shadow_top_right.png");

		// Token: 0x04001F38 RID: 7992
		public static BaseImage mail_top_drag_bar_left = new BaseImage(AssetPaths.AssetIconsMail, "top-drag-bar_left.png");

		// Token: 0x04001F39 RID: 7993
		public static BaseImage mail_top_drag_bar_middle = new BaseImage(AssetPaths.AssetIconsMail, "top-drag-bar_middle.png");

		// Token: 0x04001F3A RID: 7994
		public static BaseImage mail_top_drag_bar_right = new BaseImage(AssetPaths.AssetIconsMail, "top-drag-bar_right.png");

		// Token: 0x04001F3B RID: 7995
		public static BaseImage mail_topbar_left_in = new BaseImage(AssetPaths.AssetIconsMail, "topbar_left_in.png");

		// Token: 0x04001F3C RID: 7996
		public static BaseImage mail_topbar_left_normal = new BaseImage(AssetPaths.AssetIconsMail, "topbar_left_normal.png");

		// Token: 0x04001F3D RID: 7997
		public static BaseImage mail_topbar_middle_in = new BaseImage(AssetPaths.AssetIconsMail, "topbar_middle_in.png");

		// Token: 0x04001F3E RID: 7998
		public static BaseImage mail_topbar_middle_normal = new BaseImage(AssetPaths.AssetIconsMail, "topbar_middle_normal.png");

		// Token: 0x04001F3F RID: 7999
		public static BaseImage mail_topbar_right_in = new BaseImage(AssetPaths.AssetIconsMail, "topbar_right_in.png");

		// Token: 0x04001F40 RID: 8000
		public static BaseImage mail_topbar_right_normal = new BaseImage(AssetPaths.AssetIconsMail, "topbar_right_normal.png");

		// Token: 0x04001F41 RID: 8001
		public static BaseImage mail_horizontal_bar = new BaseImage(AssetPaths.AssetIconsMail, "mail bar horizontal.png");

		// Token: 0x04001F42 RID: 8002
		public static BaseImage mail_plus = new BaseImage(AssetPaths.AssetIconsMail, "mail_plus.png");

		// Token: 0x04001F43 RID: 8003
		public static BaseImage mail_minus = new BaseImage(AssetPaths.AssetIconsMail, "mail_minus.png");

		// Token: 0x04001F44 RID: 8004
		public static BaseImage button_132_in = new BaseImage(AssetPaths.AssetIconsMail, "button_132_in.png");

		// Token: 0x04001F45 RID: 8005
		public static BaseImage button_132_normal = new BaseImage(AssetPaths.AssetIconsMail, "button_132_normal.png");

		// Token: 0x04001F46 RID: 8006
		public static BaseImage button_132_over = new BaseImage(AssetPaths.AssetIconsMail, "button_132_over.png");

		// Token: 0x04001F47 RID: 8007
		public static BaseImage button_132_in_gold = new BaseImage(AssetPaths.AssetIconsMail, "button_132_in_gold.png");

		// Token: 0x04001F48 RID: 8008
		public static BaseImage button_132_normal_gold = new BaseImage(AssetPaths.AssetIconsMail, "button_132_normal_gold.png");

		// Token: 0x04001F49 RID: 8009
		public static BaseImage button_132_over_gold = new BaseImage(AssetPaths.AssetIconsMail, "button_132_over_gold.png");

		// Token: 0x04001F4A RID: 8010
		public static BaseImage[] quest_rewards = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "quest_screen_rewards", 13);

		// Token: 0x04001F4B RID: 8011
		public static BaseImage[] quest_icons = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "quest_screen_quest_icons", 45);

		// Token: 0x04001F4C RID: 8012
		public static BaseImage[] quest_checkboxes = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "quest_screen_check-x", 4);

		// Token: 0x04001F4D RID: 8013
		public static BaseImage[] wheel_arrowBlur_royal = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "Arrow_Blur_Royal", 3);

		// Token: 0x04001F4E RID: 8014
		public static BaseImage[] wheel_arrowBlurShadow = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "Arrow_Blur_shadow", 3);

		// Token: 0x04001F4F RID: 8015
		public static BaseImage[] wheel_icons = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "icons", 62);

		// Token: 0x04001F50 RID: 8016
		public static BaseImage[] wheel_numbers = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "wheel_numbers", 36);

		// Token: 0x04001F51 RID: 8017
		public static BaseImage[] wheel_spinButton_royal = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "button_spin_royal", 2);

		// Token: 0x04001F52 RID: 8018
		public static BaseImage[] wheel_star = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "star_spinning", 3);

		// Token: 0x04001F53 RID: 8019
		public static BaseImage[] wheel_report_icons = BaseImage.createFromUV(AssetPaths.AssetIconsQuests, "WheelSpin_x5", 5);

		// Token: 0x04001F54 RID: 8020
		public static BaseImage quest_9sclice_grey_inset_bottom_left = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_bottom_left.png");

		// Token: 0x04001F55 RID: 8021
		public static BaseImage quest_9sclice_grey_inset_bottom_mid = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_bottom_mid.png");

		// Token: 0x04001F56 RID: 8022
		public static BaseImage quest_9sclice_grey_inset_bottom_right = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_bottom_right.png");

		// Token: 0x04001F57 RID: 8023
		public static BaseImage quest_9sclice_grey_inset_mid_left = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_mid_left.png");

		// Token: 0x04001F58 RID: 8024
		public static BaseImage quest_9sclice_grey_inset_mid_mid = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_mid_mid.png");

		// Token: 0x04001F59 RID: 8025
		public static BaseImage quest_9sclice_grey_inset_mid_right = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_mid_right.png");

		// Token: 0x04001F5A RID: 8026
		public static BaseImage quest_9sclice_grey_inset_top_left = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_top_left.png");

		// Token: 0x04001F5B RID: 8027
		public static BaseImage quest_9sclice_grey_inset_top_mid = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_top_mid.png");

		// Token: 0x04001F5C RID: 8028
		public static BaseImage quest_9sclice_grey_inset_top_right = new BaseImage(AssetPaths.AssetIconsQuests, "nineslice_grey_inset_top_right.png");

		// Token: 0x04001F5D RID: 8029
		public static BaseImage quest_screen_bar1 = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_bar1.png");

		// Token: 0x04001F5E RID: 8030
		public static BaseImage quest_screen_bar2 = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_bar2.png");

		// Token: 0x04001F5F RID: 8031
		public static BaseImage quest_screen_progbar_left = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_progbar_left.png");

		// Token: 0x04001F60 RID: 8032
		public static BaseImage quest_screen_progbar_mid = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_progbar_mid.png");

		// Token: 0x04001F61 RID: 8033
		public static BaseImage quest_screen_progbar_right = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_progbar_right.png");

		// Token: 0x04001F62 RID: 8034
		public static BaseImage quest_screen_top = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_top.png");

		// Token: 0x04001F63 RID: 8035
		public static BaseImage quest_screen_warm = new BaseImage(AssetPaths.AssetIconsQuests, "quest_screen_warm-corner.png");

		// Token: 0x04001F64 RID: 8036
		public static BaseImage quest_popup_hz_strip_01 = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_hz_strip_01.png");

		// Token: 0x04001F65 RID: 8037
		public static BaseImage quest_popup_hz_strip_02 = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_hz_strip_02.png");

		// Token: 0x04001F66 RID: 8038
		public static BaseImage quest_popup_hz_strip_03 = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_hz_strip_03.png");

		// Token: 0x04001F67 RID: 8039
		public static BaseImage quest_popup_inset_bottom = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_inset_bottom.png");

		// Token: 0x04001F68 RID: 8040
		public static BaseImage quest_popup_inset_highlight = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_inset_highlight.png");

		// Token: 0x04001F69 RID: 8041
		public static BaseImage quest_popup_inset_middle = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_inset_middle.png");

		// Token: 0x04001F6A RID: 8042
		public static BaseImage quest_popup_inset_top = new BaseImage(AssetPaths.AssetIconsQuests, "quest_popup_inset_top.png");

		// Token: 0x04001F6B RID: 8043
		public static BaseImage quest_button_glow = new BaseImage(AssetPaths.AssetIconsQuests, "quest_button_glowt.png");

		// Token: 0x04001F6C RID: 8044
		public static BaseImage reward_panel_background = new BaseImage(AssetPaths.AssetIconsQuests, "reward_panel_background");

		// Token: 0x04001F6D RID: 8045
		public static BaseImage wheel_wheel_royal = new BaseImage(AssetPaths.AssetIconsQuests, "wheel_background_royal");

		// Token: 0x04001F6E RID: 8046
		public static BaseImage townbuilding_ale_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_ale_normal.png");

		// Token: 0x04001F6F RID: 8047
		public static BaseImage townbuilding_ale_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_ale_over.png");

		// Token: 0x04001F70 RID: 8048
		public static BaseImage townbuilding_apples_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_apples_normal.png");

		// Token: 0x04001F71 RID: 8049
		public static BaseImage townbuilding_apples_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_apples_over.png");

		// Token: 0x04001F72 RID: 8050
		public static BaseImage townbuilding_archeryrange_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_archeryrange_normal.png");

		// Token: 0x04001F73 RID: 8051
		public static BaseImage townbuilding_archeryrange_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_archeryrange_over.png");

		// Token: 0x04001F74 RID: 8052
		public static BaseImage townbuilding_architectsguild_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_architectsguild_normal.png");

		// Token: 0x04001F75 RID: 8053
		public static BaseImage townbuilding_architectsguild_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_architectsguild_over.png");

		// Token: 0x04001F76 RID: 8054
		public static BaseImage townbuilding_armour_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_armour_normal.png");

		// Token: 0x04001F77 RID: 8055
		public static BaseImage townbuilding_armour_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_armour_over.png");

		// Token: 0x04001F78 RID: 8056
		public static BaseImage townbuilding_ballistamaker_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_ballistamaker_normal.png");

		// Token: 0x04001F79 RID: 8057
		public static BaseImage townbuilding_ballistamaker_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_ballistamaker_over.png");

		// Token: 0x04001F7A RID: 8058
		public static BaseImage townbuilding_banquette_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_banquette_normal.png");

		// Token: 0x04001F7B RID: 8059
		public static BaseImage townbuilding_banquette_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_banquette_over.png");

		// Token: 0x04001F7C RID: 8060
		public static BaseImage townbuilding_banquette_food_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_banquette_food_normal.png");

		// Token: 0x04001F7D RID: 8061
		public static BaseImage townbuilding_banquette_food_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_banquette_food_over.png");

		// Token: 0x04001F7E RID: 8062
		public static BaseImage townbuilding_barracks_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_barracks_normal.png");

		// Token: 0x04001F7F RID: 8063
		public static BaseImage townbuilding_barracks_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_barracks_over.png");

		// Token: 0x04001F80 RID: 8064
		public static BaseImage townbuilding_blank_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_blank_normal.png");

		// Token: 0x04001F81 RID: 8065
		public static BaseImage townbuilding_blank_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_blank_over.png");

		// Token: 0x04001F82 RID: 8066
		public static BaseImage townbuilding_bows_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_bows_normal.png");

		// Token: 0x04001F83 RID: 8067
		public static BaseImage townbuilding_bows_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_bows_over.png");

		// Token: 0x04001F84 RID: 8068
		public static BaseImage townbuilding_bread_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_bread_normal.png");

		// Token: 0x04001F85 RID: 8069
		public static BaseImage townbuilding_bread_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_bread_over.png");

		// Token: 0x04001F86 RID: 8070
		public static BaseImage townbuilding_carpenter_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_carpenter_normal.png");

		// Token: 0x04001F87 RID: 8071
		public static BaseImage townbuilding_carpenter_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_carpenter_over.png");

		// Token: 0x04001F88 RID: 8072
		public static BaseImage townbuilding_castellanshouse_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_castellanshouse_normal.png");

		// Token: 0x04001F89 RID: 8073
		public static BaseImage townbuilding_castellanshouse_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_castellanshouse_over.png");

		// Token: 0x04001F8A RID: 8074
		public static BaseImage townbuilding_catapults_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_catapults_normal.png");

		// Token: 0x04001F8B RID: 8075
		public static BaseImage townbuilding_catapults_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_catapults_over.png");

		// Token: 0x04001F8C RID: 8076
		public static BaseImage townbuilding_cheese_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_cheese_normal.png");

		// Token: 0x04001F8D RID: 8077
		public static BaseImage townbuilding_cheese_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_cheese_over.png");

		// Token: 0x04001F8E RID: 8078
		public static BaseImage townbuilding_church_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_church_normal.png");

		// Token: 0x04001F8F RID: 8079
		public static BaseImage townbuilding_church_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_church_over.png");

		// Token: 0x04001F90 RID: 8080
		public static BaseImage townbuilding_combatarena_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_combatarena_normal.png");

		// Token: 0x04001F91 RID: 8081
		public static BaseImage townbuilding_combatarena_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_combatarena_over.png");

		// Token: 0x04001F92 RID: 8082
		public static BaseImage townbuilding_fish_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_fish_normal.png");

		// Token: 0x04001F93 RID: 8083
		public static BaseImage townbuilding_fish_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_fish_over.png");

		// Token: 0x04001F94 RID: 8084
		public static BaseImage townbuilding_food_ale_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_food-ale_normal.png");

		// Token: 0x04001F95 RID: 8085
		public static BaseImage townbuilding_food_ale_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_food-ale_over.png");

		// Token: 0x04001F96 RID: 8086
		public static BaseImage townbuilding_iron_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_iron_normal.png");

		// Token: 0x04001F97 RID: 8087
		public static BaseImage townbuilding_iron_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_iron_over.png");

		// Token: 0x04001F98 RID: 8088
		public static BaseImage townbuilding_Labourersbillets_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_Labourersbillets_normal.png");

		// Token: 0x04001F99 RID: 8089
		public static BaseImage townbuilding_Labourersbillets_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_Labourersbillets_over.png");

		// Token: 0x04001F9A RID: 8090
		public static BaseImage townbuilding_meat_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_meat_normal.png");

		// Token: 0x04001F9B RID: 8091
		public static BaseImage townbuilding_meat_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_meat_over.png");

		// Token: 0x04001F9C RID: 8092
		public static BaseImage townbuilding_metalware_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_metalware_normal.png");

		// Token: 0x04001F9D RID: 8093
		public static BaseImage townbuilding_metalware_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_metalware_over.png");

		// Token: 0x04001F9E RID: 8094
		public static BaseImage townbuilding_militaryschool_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_militaryschool_normal.png");

		// Token: 0x04001F9F RID: 8095
		public static BaseImage townbuilding_militaryschool_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_militaryschool_over.png");

		// Token: 0x04001FA0 RID: 8096
		public static BaseImage townbuilding_officersquarters_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_officersquarters_normal.png");

		// Token: 0x04001FA1 RID: 8097
		public static BaseImage townbuilding_officersquarters_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_officersquarters_over.png");

		// Token: 0x04001FA2 RID: 8098
		public static BaseImage townbuilding_peasntshall_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_peasntshall_normal.png");

		// Token: 0x04001FA3 RID: 8099
		public static BaseImage townbuilding_peasntshall_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_peasntshall_over.png");

		// Token: 0x04001FA4 RID: 8100
		public static BaseImage townbuilding_pikemandrillyard_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pikemandrillyard_normal.png");

		// Token: 0x04001FA5 RID: 8101
		public static BaseImage townbuilding_pikemandrillyard_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pikemandrillyard_over.png");

		// Token: 0x04001FA6 RID: 8102
		public static BaseImage townbuilding_pikes_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pikes_normal.png");

		// Token: 0x04001FA7 RID: 8103
		public static BaseImage townbuilding_pikes_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pikes_over.png");

		// Token: 0x04001FA8 RID: 8104
		public static BaseImage townbuilding_pitch_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pitch_normal.png");

		// Token: 0x04001FA9 RID: 8105
		public static BaseImage townbuilding_pitch_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_pitch_over.png");

		// Token: 0x04001FAA RID: 8106
		public static BaseImage townbuilding_resource_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_resource_normal.png");

		// Token: 0x04001FAB RID: 8107
		public static BaseImage townbuilding_resource_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_resource_over.png");

		// Token: 0x04001FAC RID: 8108
		public static BaseImage townbuilding_salt_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_salt_normal.png");

		// Token: 0x04001FAD RID: 8109
		public static BaseImage townbuilding_salt_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_salt_over.png");

		// Token: 0x04001FAE RID: 8110
		public static BaseImage townbuilding_sergeantsatarmsoffice_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_sergeantsatarmsoffice_normal.png");

		// Token: 0x04001FAF RID: 8111
		public static BaseImage townbuilding_sergeantsatarmsoffice_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_sergeantsatarmsoffice_over.png");

		// Token: 0x04001FB0 RID: 8112
		public static BaseImage townbuilding_siegeengineersguild_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_siegeengineersguild_normal.png");

		// Token: 0x04001FB1 RID: 8113
		public static BaseImage townbuilding_siegeengineersguild_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_siegeengineersguild_over.png");

		// Token: 0x04001FB2 RID: 8114
		public static BaseImage townbuilding_silk_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_silk_normal.png");

		// Token: 0x04001FB3 RID: 8115
		public static BaseImage townbuilding_silk_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_silk_over.png");

		// Token: 0x04001FB4 RID: 8116
		public static BaseImage townbuilding_spice_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_spice_normal.png");

		// Token: 0x04001FB5 RID: 8117
		public static BaseImage townbuilding_spice_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_spice_over.png");

		// Token: 0x04001FB6 RID: 8118
		public static BaseImage townbuilding_stables_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_stables_normal.png");

		// Token: 0x04001FB7 RID: 8119
		public static BaseImage townbuilding_stables_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_stables_over.png");

		// Token: 0x04001FB8 RID: 8120
		public static BaseImage townbuilding_statue_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_statue_normal.png");

		// Token: 0x04001FB9 RID: 8121
		public static BaseImage townbuilding_statue_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_statue_over.png");

		// Token: 0x04001FBA RID: 8122
		public static BaseImage townbuilding_stonequarry_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_stonequarry_normal.png");

		// Token: 0x04001FBB RID: 8123
		public static BaseImage townbuilding_stonequarry_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_stonequarry_over.png");

		// Token: 0x04001FBC RID: 8124
		public static BaseImage townbuilding_supplydepot_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_supplydepot_normal.png");

		// Token: 0x04001FBD RID: 8125
		public static BaseImage townbuilding_supplydepot_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_supplydepot_over.png");

		// Token: 0x04001FBE RID: 8126
		public static BaseImage townbuilding_sword_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_sword_normal.png");

		// Token: 0x04001FBF RID: 8127
		public static BaseImage townbuilding_sword_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_sword_over.png");

		// Token: 0x04001FC0 RID: 8128
		public static BaseImage townbuilding_tailor_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_tailor_normal.png");

		// Token: 0x04001FC1 RID: 8129
		public static BaseImage townbuilding_tailor_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_tailor_over.png");

		// Token: 0x04001FC2 RID: 8130
		public static BaseImage townbuilding_towngarden_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_towngarden_normal.png");

		// Token: 0x04001FC3 RID: 8131
		public static BaseImage townbuilding_towngarden_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_towngarden_over.png");

		// Token: 0x04001FC4 RID: 8132
		public static BaseImage townbuilding_townhall_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_townhall_normal.png");

		// Token: 0x04001FC5 RID: 8133
		public static BaseImage townbuilding_townhall_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_townhall_over.png");

		// Token: 0x04001FC6 RID: 8134
		public static BaseImage townbuilding_tunnellorsguild_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_tunnellorsguild_normal.png");

		// Token: 0x04001FC7 RID: 8135
		public static BaseImage townbuilding_tunnellorsguild_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_tunnellorsguild_over.png");

		// Token: 0x04001FC8 RID: 8136
		public static BaseImage townbuilding_turretmaker_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_turretmaker_normal.png");

		// Token: 0x04001FC9 RID: 8137
		public static BaseImage townbuilding_turretmaker_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_turretmaker_over.png");

		// Token: 0x04001FCA RID: 8138
		public static BaseImage townbuilding_veg_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_veg_normal.png");

		// Token: 0x04001FCB RID: 8139
		public static BaseImage townbuilding_veg_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_veg_over.png");

		// Token: 0x04001FCC RID: 8140
		public static BaseImage townbuilding_venison_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_venison_normal.png");

		// Token: 0x04001FCD RID: 8141
		public static BaseImage townbuilding_venison_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_venison_over.png");

		// Token: 0x04001FCE RID: 8142
		public static BaseImage townbuilding_weapons_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_weapons_normal.png");

		// Token: 0x04001FCF RID: 8143
		public static BaseImage townbuilding_weapons_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_weapons_over.png");

		// Token: 0x04001FD0 RID: 8144
		public static BaseImage townbuilding_wine_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_wine_normal.png");

		// Token: 0x04001FD1 RID: 8145
		public static BaseImage townbuilding_wine_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_wine_over.png");

		// Token: 0x04001FD2 RID: 8146
		public static BaseImage townbuilding_Woodcutter_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_Woodcutter_normal.png");

		// Token: 0x04001FD3 RID: 8147
		public static BaseImage townbuilding_Woodcutter_over = new BaseImage(AssetPaths.AssetIconsCapital, "townbuilding_Woodcutter_over.png");

		// Token: 0x04001FD4 RID: 8148
		public static BaseImage townscreen_army_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_army_normal.png");

		// Token: 0x04001FD5 RID: 8149
		public static BaseImage townscreen_army_over = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_army_over.png");

		// Token: 0x04001FD6 RID: 8150
		public static BaseImage townscreen_army_selected = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_army_selected.png");

		// Token: 0x04001FD7 RID: 8151
		public static BaseImage townscreen_castle_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_castle_normal.png");

		// Token: 0x04001FD8 RID: 8152
		public static BaseImage townscreen_castle_over = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_castle_over.png");

		// Token: 0x04001FD9 RID: 8153
		public static BaseImage townscreen_castle_selected = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_castle_selected.png");

		// Token: 0x04001FDA RID: 8154
		public static BaseImage townscreen_civil_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_civil_normal.png");

		// Token: 0x04001FDB RID: 8155
		public static BaseImage townscreen_civil_over = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_civil_over.png");

		// Token: 0x04001FDC RID: 8156
		public static BaseImage townscreen_civil_selected = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_civil_selected.png");

		// Token: 0x04001FDD RID: 8157
		public static BaseImage townscreen_guild_normal = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_guild_normal.png");

		// Token: 0x04001FDE RID: 8158
		public static BaseImage townscreen_guild_over = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_guild_over.png");

		// Token: 0x04001FDF RID: 8159
		public static BaseImage townscreen_guild_selected = new BaseImage(AssetPaths.AssetIconsCapital, "townscreen_guild_selected.png");

		// Token: 0x04001FE0 RID: 8160
		public static BaseImage help_over = new BaseImage(AssetPaths.AssetIconsCapital, "help_over.png");

		// Token: 0x04001FE1 RID: 8161
		public static BaseImage help_normal = new BaseImage(AssetPaths.AssetIconsCapital, "help_normal.png");

		// Token: 0x04001FE2 RID: 8162
		public static BaseImage help_pushed = new BaseImage(AssetPaths.AssetIconsCapital, "help_pushed.png");

		// Token: 0x04001FE3 RID: 8163
		public static BaseImage help_gold_over = new BaseImage(AssetPaths.AssetIconsCapital, "help_over_gold.png");

		// Token: 0x04001FE4 RID: 8164
		public static BaseImage help_gold_normal = new BaseImage(AssetPaths.AssetIconsCapital, "help_normal_gold.png");

		// Token: 0x04001FE5 RID: 8165
		public static BaseImage help_gold_pushed = new BaseImage(AssetPaths.AssetIconsCapital, "help_pushed_gold.png");

		// Token: 0x04001FE6 RID: 8166
		public static BaseImage donate_illustration = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_illustration");

		// Token: 0x04001FE7 RID: 8167
		public static BaseImage donate_tick = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_check");

		// Token: 0x04001FE8 RID: 8168
		public static BaseImage donate_type_banquet = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_banquet.png");

		// Token: 0x04001FE9 RID: 8169
		public static BaseImage donate_type_food = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_food.png");

		// Token: 0x04001FEA RID: 8170
		public static BaseImage donate_type_weapons = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_weapons.png");

		// Token: 0x04001FEB RID: 8171
		public static BaseImage donate_type_resources = new BaseImage(AssetPaths.AssetIconsCapital, "parish_donate_resource.png");

		// Token: 0x04001FEC RID: 8172
		public static BaseImage[] scout_screen_icons = BaseImage.createFromUV(AssetPaths.AssetIconsScouting, "scout_screen_icons", 66);

		// Token: 0x04001FED RID: 8173
		public static BaseImage scout_screen_slider_bar = new BaseImage(AssetPaths.AssetIconsScouting, "scout_screen_slider_bar.png");

		// Token: 0x04001FEE RID: 8174
		public static BaseImage scout_screen_arrowbox = new BaseImage(AssetPaths.AssetIconsScouting, "scout_screen_arrowbox.png");

		// Token: 0x04001FEF RID: 8175
		public static BaseImage scout_screen_slider = new BaseImage(AssetPaths.AssetIconsScouting, "scout_screen_slider.png");

		// Token: 0x04001FF0 RID: 8176
		public static BaseImage button_with_inset_pushed = new BaseImage(AssetPaths.AssetIconsScouting, "button_with_inset_pushed.png");

		// Token: 0x04001FF1 RID: 8177
		public static BaseImage button_with_inset_over = new BaseImage(AssetPaths.AssetIconsScouting, "button_with_inset_over.png");

		// Token: 0x04001FF2 RID: 8178
		public static BaseImage button_with_inset_normal = new BaseImage(AssetPaths.AssetIconsScouting, "button_with_inset_normal.png");

		// Token: 0x04001FF3 RID: 8179
		public static BaseImage scout_screen_illustration_01 = new BaseImage(AssetPaths.AssetIconsScouting, "scout_screen_illustration_01.png");

		// Token: 0x04001FF4 RID: 8180
		public static BaseImage reinforce_back_left = new BaseImage(AssetPaths.AssetIconsScouting, "reinforce_back_left.png");

		// Token: 0x04001FF5 RID: 8181
		public static BaseImage reinforce_back_right = new BaseImage(AssetPaths.AssetIconsScouting, "reinforce_back_right.png");

		// Token: 0x04001FF6 RID: 8182
		public static BaseImage reinforce_slider = new BaseImage(AssetPaths.AssetIconsScouting, "reinforce_slider.png");

		// Token: 0x04001FF7 RID: 8183
		public static BaseImage reinforce_Vassal_screen_back = new BaseImage(AssetPaths.AssetIconsScouting, "Reinfoce_Vassal_screen_back.png");

		// Token: 0x04001FF8 RID: 8184
		public static BaseImage capital_troops_back = new BaseImage(AssetPaths.AssetIconsScouting, "capital_troops_back.png");

		// Token: 0x04001FF9 RID: 8185
		public static BaseImage button4comp_left_normal = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_left_normal");

		// Token: 0x04001FFA RID: 8186
		public static BaseImage button4comp_left_over = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_left_over");

		// Token: 0x04001FFB RID: 8187
		public static BaseImage button4comp_left_pressed = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_left_pressed");

		// Token: 0x04001FFC RID: 8188
		public static BaseImage button4comp_right_normal = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_right_normal");

		// Token: 0x04001FFD RID: 8189
		public static BaseImage button4comp_right_over = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_right_over");

		// Token: 0x04001FFE RID: 8190
		public static BaseImage button4comp_right_pushed = new BaseImage(AssetPaths.AssetIconsScouting, "button4comp_right_pushed");

		// Token: 0x04001FFF RID: 8191
		public static BaseImage[] rank_images = BaseImage.createFromUV(AssetPaths.AssetIconsHonour, "rank_progression_array", 66);

		// Token: 0x04002000 RID: 8192
		public static BaseImage honour_rank_slot_divider = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_divider.png");

		// Token: 0x04002001 RID: 8193
		public static BaseImage honour_rank_slot_green_left = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_green_left.png");

		// Token: 0x04002002 RID: 8194
		public static BaseImage honour_rank_slot_green_middle = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_green_middle.png");

		// Token: 0x04002003 RID: 8195
		public static BaseImage honour_rank_slot_green_right = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_green_right.png");

		// Token: 0x04002004 RID: 8196
		public static BaseImage honour_rank_slot_left = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_left.png");

		// Token: 0x04002005 RID: 8197
		public static BaseImage honour_rank_slot_middle = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_middle.png");

		// Token: 0x04002006 RID: 8198
		public static BaseImage honour_rank_slot_right = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_right.png");

		// Token: 0x04002007 RID: 8199
		public static BaseImage honour_rank_slot_yellow_left = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_yellow_left.png");

		// Token: 0x04002008 RID: 8200
		public static BaseImage honour_rank_slot_yellow_middle = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_yellow_middle.png");

		// Token: 0x04002009 RID: 8201
		public static BaseImage honour_rank_slot_yellow_right = new BaseImage(AssetPaths.AssetIconsHonour, "rank_slot_yellow_right.png");

		// Token: 0x0400200A RID: 8202
		public static BaseImage rank_progression_crown_prince = new BaseImage(AssetPaths.AssetIconsHonour, "rank_progression_crown_prince");

		// Token: 0x0400200B RID: 8203
		public static BaseImage[] RankAnim_Images = BaseImage.createFromUV(AssetPaths.AssetIconsRankAnim, "lords", 22);

		// Token: 0x0400200C RID: 8204
		public static BaseImage RankAnim_Images23 = new BaseImage(AssetPaths.AssetIconsRankAnim, "crown_prince");

		// Token: 0x0400200D RID: 8205
		public static BaseImage[] monk_screen_button_array_75x75 = BaseImage.createFromUV(AssetPaths.AssetIconsMonks, "monk_screen_button_array_75x75", 28);

		// Token: 0x0400200E RID: 8206
		public static BaseImage[] monk_screen_button_array = BaseImage.createFromUV(AssetPaths.AssetIconsMonks, "monk_screen_button_array", 6);

		// Token: 0x0400200F RID: 8207
		public static BaseImage[] radio_green = BaseImage.createFromUV(AssetPaths.AssetIconsMonks, "radio_green", 3);

		// Token: 0x04002010 RID: 8208
		public static BaseImage[] send_army_buttons = BaseImage.createFromUV(AssetPaths.AssetIconsMonks, "send_army_button_comp", 36);

		// Token: 0x04002011 RID: 8209
		public static BaseImage illustration_monks = new BaseImage(AssetPaths.AssetIconsMonks, "illustration_monks.png");

		// Token: 0x04002012 RID: 8210
		public static BaseImage monk_screen_buttongroup_inset = new BaseImage(AssetPaths.AssetIconsMonks, "monk_screen_buttongroup_inset.png");

		// Token: 0x04002013 RID: 8211
		public static BaseImage monk_screen_playerlist_inset = new BaseImage(AssetPaths.AssetIconsMonks, "monk_screen_playerlist_inset.png");

		// Token: 0x04002014 RID: 8212
		public static BaseImage monk_screen_slider = new BaseImage(AssetPaths.AssetIconsMonks, "monk_screen_slider.png");

		// Token: 0x04002015 RID: 8213
		public static BaseImage popup_border_bottom = new BaseImage(AssetPaths.AssetIconsMonks, "popup_border_bottom.png");

		// Token: 0x04002016 RID: 8214
		public static BaseImage popup_border_rhs = new BaseImage(AssetPaths.AssetIconsMonks, "popup_border_rhs.png");

		// Token: 0x04002017 RID: 8215
		public static BaseImage popup_title_bar = new BaseImage(AssetPaths.AssetIconsMonks, "title_bar.png");

		// Token: 0x04002018 RID: 8216
		public static BaseImage send_army_illustration = new BaseImage(AssetPaths.AssetIconsMonks, "send_army_illustration.png");

		// Token: 0x04002019 RID: 8217
		public static BaseImage send_army_slider = new BaseImage(AssetPaths.AssetIconsMonks, "send_army_slider.png");

		// Token: 0x0400201A RID: 8218
		public static BaseImage send_army_timer = new BaseImage(AssetPaths.AssetIconsMonks, "send_army_screen_timer_back.png");

		// Token: 0x0400201B RID: 8219
		public static BaseImage[] parishwall_village_center_achievement_icons = BaseImage.createFromUV(AssetPaths.AssetIconsParishWall, "village_center_achievement_icons", 20);

		// Token: 0x0400201C RID: 8220
		public static BaseImage parishwall_dividing_line = new BaseImage(AssetPaths.AssetIconsParishWall, "dividing_line.png");

		// Token: 0x0400201D RID: 8221
		public static BaseImage parishwall_tan_bar_01 = new BaseImage(AssetPaths.AssetIconsParishWall, "tan_bar_01.png");

		// Token: 0x0400201E RID: 8222
		public static BaseImage parishwall_tan_bar_01_short = new BaseImage(AssetPaths.AssetIconsParishWall, "tan_bar_01_short.png");

		// Token: 0x0400201F RID: 8223
		public static BaseImage parishwall_tan_bar_02 = new BaseImage(AssetPaths.AssetIconsParishWall, "tan_bar_02.png");

		// Token: 0x04002020 RID: 8224
		public static BaseImage parishwall_tan_bar_03 = new BaseImage(AssetPaths.AssetIconsParishWall, "tan_bar_03.png");

		// Token: 0x04002021 RID: 8225
		public static BaseImage parishwall_village_center_tab_down = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab_down.png");

		// Token: 0x04002022 RID: 8226
		public static BaseImage parishwall_village_center_tab_up = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab_up.png");

		// Token: 0x04002023 RID: 8227
		public static BaseImage parishwall_village_center_tab_outline_bottom_left = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_bottom_left.png");

		// Token: 0x04002024 RID: 8228
		public static BaseImage parishwall_village_center_tab_outline_bottom_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_bottom_middle.png");

		// Token: 0x04002025 RID: 8229
		public static BaseImage parishwall_village_center_tab_outline_bottom_right = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_bottom_right.png");

		// Token: 0x04002026 RID: 8230
		public static BaseImage parishwall_village_center_tab_outline_middle_left = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_middle_left.png");

		// Token: 0x04002027 RID: 8231
		public static BaseImage parishwall_village_center_tab_outline_middle_right = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_middle_right.png");

		// Token: 0x04002028 RID: 8232
		public static BaseImage parishwall_village_center_tab_outline_top_left = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_top_left.png");

		// Token: 0x04002029 RID: 8233
		public static BaseImage parishwall_village_center_tab_outline_top_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_top_middle.png");

		// Token: 0x0400202A RID: 8234
		public static BaseImage parishwall_village_center_tab_outline_top_right = new BaseImage(AssetPaths.AssetIconsParishWall, "village_center_tab-outline_top_right.png");

		// Token: 0x0400202B RID: 8235
		public static BaseImage parishwall_village_illlustration_01 = new BaseImage(AssetPaths.AssetIconsParishWall, "village_illlustration_01.png");

		// Token: 0x0400202C RID: 8236
		public static BaseImage parishwall_village_illlustration_02 = new BaseImage(AssetPaths.AssetIconsParishWall, "vote_illustration_2.png");

		// Token: 0x0400202D RID: 8237
		public static BaseImage parishwall_village_illlustration_03 = new BaseImage(AssetPaths.AssetIconsParishWall, "vote_illustration_3.png");

		// Token: 0x0400202E RID: 8238
		public static BaseImage parishwall_village_illlustration_04 = new BaseImage(AssetPaths.AssetIconsParishWall, "vote_illustration_4.png");

		// Token: 0x0400202F RID: 8239
		public static BaseImage parishwall_what_say_thou_box = new BaseImage(AssetPaths.AssetIconsParishWall, "what_say_thou_box.png");

		// Token: 0x04002030 RID: 8240
		public static BaseImage _24wide_thumb_bottom = new BaseImage(AssetPaths.AssetIconsParishWall, "_24wide_thumb_bottom.png");

		// Token: 0x04002031 RID: 8241
		public static BaseImage _24wide_thumb_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "_24wide_thumb_middle.png");

		// Token: 0x04002032 RID: 8242
		public static BaseImage _24wide_thumb_top = new BaseImage(AssetPaths.AssetIconsParishWall, "_24wide_thumb_top.png");

		// Token: 0x04002033 RID: 8243
		public static BaseImage shield_blank_256 = new BaseImage(AssetPaths.AssetIconsParishWall, "shield_blank_256.png");

		// Token: 0x04002034 RID: 8244
		public static BaseImage parishwall_solid_rounded_rectangle_tan_bottom_left = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_bottom-left.png");

		// Token: 0x04002035 RID: 8245
		public static BaseImage parishwall_solid_rounded_rectangle_tan_bottom_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_bottom-middle.png");

		// Token: 0x04002036 RID: 8246
		public static BaseImage parishwall_solid_rounded_rectangle_tan_bottom_right = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_bottom-right.png");

		// Token: 0x04002037 RID: 8247
		public static BaseImage parishwall_solid_rounded_rectangle_tan_middle_left = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_middle-left.png");

		// Token: 0x04002038 RID: 8248
		public static BaseImage parishwall_solid_rounded_rectangle_tan_middle_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_middle-middle.png");

		// Token: 0x04002039 RID: 8249
		public static BaseImage parishwall_solid_rounded_rectangle_tan_middle_right = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_middle-right.png");

		// Token: 0x0400203A RID: 8250
		public static BaseImage parishwall_solid_rounded_rectangle_tan_upper_left = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_upper-left.png");

		// Token: 0x0400203B RID: 8251
		public static BaseImage parishwall_solid_rounded_rectangle_tan_upper_middle = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_upper-middle.png");

		// Token: 0x0400203C RID: 8252
		public static BaseImage parishwall_solid_rounded_rectangle_tan_upper_right = new BaseImage(AssetPaths.AssetIconsParishWall, "solid_rounded_rectangle_tan_upper-right.png");

		// Token: 0x0400203D RID: 8253
		public static BaseImage parishwall_button_vote_checked_normal = new BaseImage(AssetPaths.AssetIconsParishWall, "button_vote_checked_normal.png");

		// Token: 0x0400203E RID: 8254
		public static BaseImage parishwall_button_vote_checked_over = new BaseImage(AssetPaths.AssetIconsParishWall, "button_vote_checked_over.png");

		// Token: 0x0400203F RID: 8255
		public static BaseImage house_flag_001_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_001_small.png");

		// Token: 0x04002040 RID: 8256
		public static BaseImage house_flag_002_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_002_small.png");

		// Token: 0x04002041 RID: 8257
		public static BaseImage house_flag_003_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_003_small.png");

		// Token: 0x04002042 RID: 8258
		public static BaseImage house_flag_004_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_004_small.png");

		// Token: 0x04002043 RID: 8259
		public static BaseImage house_flag_005_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_005_small.png");

		// Token: 0x04002044 RID: 8260
		public static BaseImage house_flag_006_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_006_small.png");

		// Token: 0x04002045 RID: 8261
		public static BaseImage house_flag_007_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_007_small.png");

		// Token: 0x04002046 RID: 8262
		public static BaseImage house_flag_008_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_008_small.png");

		// Token: 0x04002047 RID: 8263
		public static BaseImage house_flag_009_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_009_small.png");

		// Token: 0x04002048 RID: 8264
		public static BaseImage house_flag_010_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_010_small.png");

		// Token: 0x04002049 RID: 8265
		public static BaseImage house_flag_011_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_011_small.png");

		// Token: 0x0400204A RID: 8266
		public static BaseImage house_flag_012_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_012_small.png");

		// Token: 0x0400204B RID: 8267
		public static BaseImage house_flag_013_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_013_small.png");

		// Token: 0x0400204C RID: 8268
		public static BaseImage house_flag_014_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_014_small.png");

		// Token: 0x0400204D RID: 8269
		public static BaseImage house_flag_015_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_015_small.png");

		// Token: 0x0400204E RID: 8270
		public static BaseImage house_flag_016_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_016_small.png");

		// Token: 0x0400204F RID: 8271
		public static BaseImage house_flag_017_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_017_small.png");

		// Token: 0x04002050 RID: 8272
		public static BaseImage house_flag_018_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_018_small.png");

		// Token: 0x04002051 RID: 8273
		public static BaseImage house_flag_019_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_019_small.png");

		// Token: 0x04002052 RID: 8274
		public static BaseImage house_flag_020_small = new BaseImage(AssetPaths.AssetIconsParishWall, "house_flag_020_small.png");

		// Token: 0x04002053 RID: 8275
		public static BaseImage mail2_exclaimation = new BaseImage(AssetPaths.AssetIconsMail2, "exclamation.png");

		// Token: 0x04002054 RID: 8276
		public static BaseImage mail2_blue_scrollbar_bar_bottom = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bar_bottom.png");

		// Token: 0x04002055 RID: 8277
		public static BaseImage mail2_blue_scrollbar_bar_middle = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bar_middle.png");

		// Token: 0x04002056 RID: 8278
		public static BaseImage mail2_blue_scrollbar_bar_top = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bar_top.png");

		// Token: 0x04002057 RID: 8279
		public static BaseImage mail2_blue_scrollbar_bottomarrow_in = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bottomarrow_in.png");

		// Token: 0x04002058 RID: 8280
		public static BaseImage mail2_blue_scrollbar_bottomarrow_normal = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bottomarrow_normal.png");

		// Token: 0x04002059 RID: 8281
		public static BaseImage mail2_blue_scrollbar_bottomarrow_over = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_bottomarrow_over.png");

		// Token: 0x0400205A RID: 8282
		public static BaseImage mail2_blue_scrollbar_thumb_bottom = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_thumb_bottom.png");

		// Token: 0x0400205B RID: 8283
		public static BaseImage mail2_blue_scrollbar_thumb_mid = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_thumb_mid.png");

		// Token: 0x0400205C RID: 8284
		public static BaseImage mail2_blue_scrollbar_thumb_mid_lines = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_thumb_mid_lines.png");

		// Token: 0x0400205D RID: 8285
		public static BaseImage mail2_blue_scrollbar_thumb_top = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_thumb_top.png");

		// Token: 0x0400205E RID: 8286
		public static BaseImage mail2_blue_scrollbar_toparrow_in = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_toparrow_in.png");

		// Token: 0x0400205F RID: 8287
		public static BaseImage mail2_blue_scrollbar_toparrow_normal = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_toparrow_normal.png");

		// Token: 0x04002060 RID: 8288
		public static BaseImage mail2_blue_scrollbar_toparrow_over = new BaseImage(AssetPaths.AssetIconsMail2, "blue_scrollbar_toparrow_over.png");

		// Token: 0x04002061 RID: 8289
		public static BaseImage mail2_button_blue_141wide_normal = new BaseImage(AssetPaths.AssetIconsMail2, "button_blue_141wide_normal.png");

		// Token: 0x04002062 RID: 8290
		public static BaseImage mail2_button_blue_141wide_over = new BaseImage(AssetPaths.AssetIconsMail2, "button_blue_141wide_over.png");

		// Token: 0x04002063 RID: 8291
		public static BaseImage mail2_button_blue_141wide_pushed = new BaseImage(AssetPaths.AssetIconsMail2, "button_blue_141wide_pushed.png");

		// Token: 0x04002064 RID: 8292
		public static BaseImage mail2_button_thin_in = new BaseImage(AssetPaths.AssetIconsMail2, "button_thin_in.png");

		// Token: 0x04002065 RID: 8293
		public static BaseImage mail2_button_thin_normal = new BaseImage(AssetPaths.AssetIconsMail2, "button_thin_normal.png");

		// Token: 0x04002066 RID: 8294
		public static BaseImage mail2_button_thin_over = new BaseImage(AssetPaths.AssetIconsMail2, "button_thin_over.png");

		// Token: 0x04002067 RID: 8295
		public static BaseImage mail2_corner_gradient_bottom_right = new BaseImage(AssetPaths.AssetIconsMail2, "corner_gradient_bottom_right.png");

		// Token: 0x04002068 RID: 8296
		public static BaseImage mail2_corner_Gradient_upper_left = new BaseImage(AssetPaths.AssetIconsMail2, "corner_Gradient_upper_left.png");

		// Token: 0x04002069 RID: 8297
		public static BaseImage mail2_detach_attach_window_in = new BaseImage(AssetPaths.AssetIconsMail2, "detach_attach_window_in.png");

		// Token: 0x0400206A RID: 8298
		public static BaseImage mail2_detach_attach_window_normal = new BaseImage(AssetPaths.AssetIconsMail2, "detach_attach_window_normal.png");

		// Token: 0x0400206B RID: 8299
		public static BaseImage mail2_detach_attach_window_over = new BaseImage(AssetPaths.AssetIconsMail2, "detach_attach_window_over.png");

		// Token: 0x0400206C RID: 8300
		public static BaseImage mail2_detach_window_in = new BaseImage(AssetPaths.AssetIconsMail2, "detach_window_in.png");

		// Token: 0x0400206D RID: 8301
		public static BaseImage mail2_detach_window_normal = new BaseImage(AssetPaths.AssetIconsMail2, "detach_window_normal.png");

		// Token: 0x0400206E RID: 8302
		public static BaseImage mail2_detach_window_over = new BaseImage(AssetPaths.AssetIconsMail2, "detach_window_over.png");

		// Token: 0x0400206F RID: 8303
		public static BaseImage mail2_field_bar_mail_divider = new BaseImage(AssetPaths.AssetIconsMail2, "field_bar_mail_divider.png");

		// Token: 0x04002070 RID: 8304
		public static BaseImage mail2_field_bar_mail_left = new BaseImage(AssetPaths.AssetIconsMail2, "field_bar_mail_left.png");

		// Token: 0x04002071 RID: 8305
		public static BaseImage mail2_field_bar_mail_middle = new BaseImage(AssetPaths.AssetIconsMail2, "field_bar_mail_middle.png");

		// Token: 0x04002072 RID: 8306
		public static BaseImage mail2_field_bar_mail_right = new BaseImage(AssetPaths.AssetIconsMail2, "field_bar_mail_right.png");

		// Token: 0x04002073 RID: 8307
		public static BaseImage mail2_folder_icon_plus = new BaseImage(AssetPaths.AssetIconsMail2, "folder_icon_plus.png");

		// Token: 0x04002074 RID: 8308
		public static BaseImage mail2_folder_icon_64_open = new BaseImage(AssetPaths.AssetIconsMail2, "folder_icon_64_open.png");

		// Token: 0x04002075 RID: 8309
		public static BaseImage mail2_folder_icon_closed = new BaseImage(AssetPaths.AssetIconsMail2, "folder_icon_closed.png");

		// Token: 0x04002076 RID: 8310
		public static BaseImage mail2_folder_icon_delete = new BaseImage(AssetPaths.AssetIconsMail2, "folder_icon_delete.png");

		// Token: 0x04002077 RID: 8311
		public static BaseImage mail2_folder_icon_open = new BaseImage(AssetPaths.AssetIconsMail2, "folder_icon_open.png");

		// Token: 0x04002078 RID: 8312
		public static BaseImage mail2_item_bar_tan_darker = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_tan-darker.png");

		// Token: 0x04002079 RID: 8313
		public static BaseImage mail2_item_bar_tan_darker_over = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_tan-darker_over.png");

		// Token: 0x0400207A RID: 8314
		public static BaseImage mail2_item_bar_tan_lighter = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_tan-lighter.png");

		// Token: 0x0400207B RID: 8315
		public static BaseImage mail2_item_bar_tan_lighter_over = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_tan-lighter_over.png");

		// Token: 0x0400207C RID: 8316
		public static BaseImage mail2_item_bar_white = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_white.png");

		// Token: 0x0400207D RID: 8317
		public static BaseImage mail2_item_bar_white_over = new BaseImage(AssetPaths.AssetIconsMail2, "item_bar_white_over.png");

		// Token: 0x0400207E RID: 8318
		public static BaseImage mail2_mail_icon = new BaseImage(AssetPaths.AssetIconsMail2, "mail_icon.png");

		// Token: 0x0400207F RID: 8319
		public static BaseImage mail2_mail_inset_textline_left = new BaseImage(AssetPaths.AssetIconsMail2, "mail_inset-textline_left.png");

		// Token: 0x04002080 RID: 8320
		public static BaseImage mail2_mail_inset_textline_middle = new BaseImage(AssetPaths.AssetIconsMail2, "mail_inset-textline_middle.png");

		// Token: 0x04002081 RID: 8321
		public static BaseImage mail2_mail_inset_textline_right = new BaseImage(AssetPaths.AssetIconsMail2, "mail_inset-textline_right.png");

		// Token: 0x04002082 RID: 8322
		public static BaseImage mail2_mail_panel_lower_left = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_lower_left.png");

		// Token: 0x04002083 RID: 8323
		public static BaseImage mail2_mail_panel_lower_middle = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_lower_middle.png");

		// Token: 0x04002084 RID: 8324
		public static BaseImage mail2_mail_panel_lower_right = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_lower_right.png");

		// Token: 0x04002085 RID: 8325
		public static BaseImage mail2_mail_panel_middle_left = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_middle_left.png");

		// Token: 0x04002086 RID: 8326
		public static BaseImage mail2_mail_panel_middle_middle = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_middle_middle.png");

		// Token: 0x04002087 RID: 8327
		public static BaseImage mail2_mail_panel_middle_right = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_middle_right.png");

		// Token: 0x04002088 RID: 8328
		public static BaseImage mail2_mail_panel_upper_left = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_upper_left.png");

		// Token: 0x04002089 RID: 8329
		public static BaseImage mail2_mail_panel_upper_middle = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_upper_middle.png");

		// Token: 0x0400208A RID: 8330
		public static BaseImage mail2_mail_panel_upper_right = new BaseImage(AssetPaths.AssetIconsMail2, "mail_panel_upper_right.png");

		// Token: 0x0400208B RID: 8331
		public static BaseImage mail2_new_mail_body_bottom = new BaseImage(AssetPaths.AssetIconsMail2, "new_mail_body_bottom.png");

		// Token: 0x0400208C RID: 8332
		public static BaseImage mail2_new_mail_body_middle = new BaseImage(AssetPaths.AssetIconsMail2, "new_mail_body_middle.png");

		// Token: 0x0400208D RID: 8333
		public static BaseImage mail2_new_mail_body_top = new BaseImage(AssetPaths.AssetIconsMail2, "new_mail_body_top.png");

		// Token: 0x0400208E RID: 8334
		public static BaseImage mail2_new_mail_tab_panel = new BaseImage(AssetPaths.AssetIconsMail2, "new_mail_tab_panel.png");

		// Token: 0x0400208F RID: 8335
		public static BaseImage mail2_rounded_rectangle_tan_bottom_left = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_bottom-left.png");

		// Token: 0x04002090 RID: 8336
		public static BaseImage mail2_rounded_rectangle_tan_bottom_middle = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_bottom-middle.png");

		// Token: 0x04002091 RID: 8337
		public static BaseImage mail2_rounded_rectangle_tan_bottom_right = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_bottom-right.png");

		// Token: 0x04002092 RID: 8338
		public static BaseImage mail2_rounded_rectangle_tan_middle_left = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_middle-left.png");

		// Token: 0x04002093 RID: 8339
		public static BaseImage mail2_rounded_rectangle_tan_middle_middle = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_middle-middle.png");

		// Token: 0x04002094 RID: 8340
		public static BaseImage mail2_rounded_rectangle_tan_middle_right = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_middle-right.png");

		// Token: 0x04002095 RID: 8341
		public static BaseImage mail2_rounded_rectangle_tan_upper_left = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_upper-left.png");

		// Token: 0x04002096 RID: 8342
		public static BaseImage mail2_rounded_rectangle_tan_upper_middle = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_upper-middle.png");

		// Token: 0x04002097 RID: 8343
		public static BaseImage mail2_rounded_rectangle_tan_upper_right = new BaseImage(AssetPaths.AssetIconsMail2, "rounded_rectangle_tan_upper-right.png");

		// Token: 0x04002098 RID: 8344
		public static BaseImage mail2_scrollbar_bottom = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_bottom.png");

		// Token: 0x04002099 RID: 8345
		public static BaseImage mail2_scrollbar_bottomarrow_in = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_bottomarrow_in.png");

		// Token: 0x0400209A RID: 8346
		public static BaseImage mail2_scrollbar_bottomarrow_normal = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_bottomarrow_normal.png");

		// Token: 0x0400209B RID: 8347
		public static BaseImage mail2_scrollbar_bottomarrow_over = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_bottomarrow_over.png");

		// Token: 0x0400209C RID: 8348
		public static BaseImage mail2_scrollbar_middle = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_middle.png");

		// Token: 0x0400209D RID: 8349
		public static BaseImage mail2_scrollbar_thumb_bottom = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_thumb_bottom.png");

		// Token: 0x0400209E RID: 8350
		public static BaseImage mail2_scrollbar_thumb_middle = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_thumb_middle.png");

		// Token: 0x0400209F RID: 8351
		public static BaseImage mail2_scrollbar_thumb_top = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_thumb_top.png");

		// Token: 0x040020A0 RID: 8352
		public static BaseImage mail2_scrollbar_top = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_top.png");

		// Token: 0x040020A1 RID: 8353
		public static BaseImage mail2_scrollbar_toparrow_in = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_toparrow_in.png");

		// Token: 0x040020A2 RID: 8354
		public static BaseImage mail2_scrollbar_toparrow_normal = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_toparrow_normal.png");

		// Token: 0x040020A3 RID: 8355
		public static BaseImage mail2_scrollbar_toparrow_over = new BaseImage(AssetPaths.AssetIconsMail2, "scrollbar_toparrow_over.png");

		// Token: 0x040020A4 RID: 8356
		public static BaseImage mail2_subject_bar_tan = new BaseImage(AssetPaths.AssetIconsMail2, "subject_bar_tan.png");

		// Token: 0x040020A5 RID: 8357
		public static BaseImage mail2_textline_middle = new BaseImage(AssetPaths.AssetIconsMail2, "textline_middle.png");

		// Token: 0x040020A6 RID: 8358
		public static BaseImage mail2_titlebar_left = new BaseImage(AssetPaths.AssetIconsMail2, "titlebar_left.png");

		// Token: 0x040020A7 RID: 8359
		public static BaseImage mail2_titlebar_middle = new BaseImage(AssetPaths.AssetIconsMail2, "titlebar_middle.png");

		// Token: 0x040020A8 RID: 8360
		public static BaseImage mail2_titlebar_right = new BaseImage(AssetPaths.AssetIconsMail2, "titlebar_right.png");

		// Token: 0x040020A9 RID: 8361
		public static BaseImage mail2_users_favourites_normal = new BaseImage(AssetPaths.AssetIconsMail2, "users_favourites_normal.png");

		// Token: 0x040020AA RID: 8362
		public static BaseImage mail2_users_favourites_over = new BaseImage(AssetPaths.AssetIconsMail2, "users_favourites_over.png");

		// Token: 0x040020AB RID: 8363
		public static BaseImage mail2_users_favourites_selected = new BaseImage(AssetPaths.AssetIconsMail2, "users_favourites_selected.png");

		// Token: 0x040020AC RID: 8364
		public static BaseImage mail2_users_find_normal = new BaseImage(AssetPaths.AssetIconsMail2, "users_find_normal.png");

		// Token: 0x040020AD RID: 8365
		public static BaseImage mail2_users_find_over = new BaseImage(AssetPaths.AssetIconsMail2, "users_find_over.png");

		// Token: 0x040020AE RID: 8366
		public static BaseImage mail2_users_find_selected = new BaseImage(AssetPaths.AssetIconsMail2, "users_find_selected.png");

		// Token: 0x040020AF RID: 8367
		public static BaseImage mail2_users_groups_normal = new BaseImage(AssetPaths.AssetIconsMail2, "users_groups_normal.png");

		// Token: 0x040020B0 RID: 8368
		public static BaseImage mail2_users_groups_over = new BaseImage(AssetPaths.AssetIconsMail2, "users_groups_over.png");

		// Token: 0x040020B1 RID: 8369
		public static BaseImage mail2_users_groups_selected = new BaseImage(AssetPaths.AssetIconsMail2, "users_groups_selected.png");

		// Token: 0x040020B2 RID: 8370
		public static BaseImage mail2_users_recent_normal = new BaseImage(AssetPaths.AssetIconsMail2, "users_recent_normal.png");

		// Token: 0x040020B3 RID: 8371
		public static BaseImage mail2_users_recent_over = new BaseImage(AssetPaths.AssetIconsMail2, "users_recent_over.png");

		// Token: 0x040020B4 RID: 8372
		public static BaseImage mail2_users_recent_selected = new BaseImage(AssetPaths.AssetIconsMail2, "users_recent_selected.png");

		// Token: 0x040020B5 RID: 8373
		public static BaseImage mail2_large_button_normal = new BaseImage(AssetPaths.AssetIconsMail2, "blue_infobar_01.png");

		// Token: 0x040020B6 RID: 8374
		public static BaseImage mail2_large_button_over = new BaseImage(AssetPaths.AssetIconsMail2, "blue_infobar_01_over.png");

		// Token: 0x040020B7 RID: 8375
		public static BaseImage mail2_attach_player_normal = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_user_normal.png");

		// Token: 0x040020B8 RID: 8376
		public static BaseImage mail2_attach_player_over = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_user_over.png");

		// Token: 0x040020B9 RID: 8377
		public static BaseImage mail2_attach_player_selected = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_user_selected.png");

		// Token: 0x040020BA RID: 8378
		public static BaseImage mail2_attach_village_normal = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_village_normal.png");

		// Token: 0x040020BB RID: 8379
		public static BaseImage mail2_attach_village_over = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_village_over.png");

		// Token: 0x040020BC RID: 8380
		public static BaseImage mail2_attach_village_selected = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_village_selected.png");

		// Token: 0x040020BD RID: 8381
		public static BaseImage mail2_attach_parish_normal = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_region_normal.png");

		// Token: 0x040020BE RID: 8382
		public static BaseImage mail2_attach_parish_over = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_region_over.png");

		// Token: 0x040020BF RID: 8383
		public static BaseImage mail2_attach_parish_selected = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_region_selected.png");

		// Token: 0x040020C0 RID: 8384
		public static BaseImage mail2_attach_current_normal = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_attachment_normal.png");

		// Token: 0x040020C1 RID: 8385
		public static BaseImage mail2_attach_current_over = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_attachment_over.png");

		// Token: 0x040020C2 RID: 8386
		public static BaseImage mail2_attach_current_selected = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_attachment_selected.png");

		// Token: 0x040020C3 RID: 8387
		public static BaseImage mail2_attach_type_player = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_user_icon.png");

		// Token: 0x040020C4 RID: 8388
		public static BaseImage mail2_attach_type_village = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_village_icon.png");

		// Token: 0x040020C5 RID: 8389
		public static BaseImage mail2_attach_type_parish = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_region_icon.png");

		// Token: 0x040020C6 RID: 8390
		public static BaseImage mail2_attach_icon = new BaseImage(AssetPaths.AssetIconsMail2, "mail_hyperlinking_attachment_icon.png");

		// Token: 0x040020C7 RID: 8391
		public static BaseImage background_top = new BaseImage(AssetPaths.AssetIconsStats, "background_top.png");

		// Token: 0x040020C8 RID: 8392
		public static BaseImage catagory_icons_achiever_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_achiever_normal.png");

		// Token: 0x040020C9 RID: 8393
		public static BaseImage catagory_icons_achiever_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_achiever_over.png");

		// Token: 0x040020CA RID: 8394
		public static BaseImage catagory_icons_achiever_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_achiever_pushed.png");

		// Token: 0x040020CB RID: 8395
		public static BaseImage catagory_icons_aikiller_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_aikiller_normal.png");

		// Token: 0x040020CC RID: 8396
		public static BaseImage catagory_icons_aikiller_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_aikiller_over.png");

		// Token: 0x040020CD RID: 8397
		public static BaseImage catagory_icons_aikiller_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_aikiller_pushed.png");

		// Token: 0x040020CE RID: 8398
		public static BaseImage catagory_icons_banditslayer_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banditslayer_normal.png");

		// Token: 0x040020CF RID: 8399
		public static BaseImage catagory_icons_banditslayer_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banditslayer_over.png");

		// Token: 0x040020D0 RID: 8400
		public static BaseImage catagory_icons_banditslayer_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banditslayer_pushed.png");

		// Token: 0x040020D1 RID: 8401
		public static BaseImage catagory_icons_banquet_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banquet_normal.png");

		// Token: 0x040020D2 RID: 8402
		public static BaseImage catagory_icons_banquet_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banquet_over.png");

		// Token: 0x040020D3 RID: 8403
		public static BaseImage catagory_icons_banquet_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_banquet_pushed.png");

		// Token: 0x040020D4 RID: 8404
		public static BaseImage catagory_icons_blacksmith_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_blacksmith_normal.png");

		// Token: 0x040020D5 RID: 8405
		public static BaseImage catagory_icons_blacksmith_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_blacksmith_over.png");

		// Token: 0x040020D6 RID: 8406
		public static BaseImage catagory_icons_blacksmith_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_blacksmith_pushed.png");

		// Token: 0x040020D7 RID: 8407
		public static BaseImage catagory_icons_brewer_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_brewer_normal.png");

		// Token: 0x040020D8 RID: 8408
		public static BaseImage catagory_icons_brewer_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_brewer_over.png");

		// Token: 0x040020D9 RID: 8409
		public static BaseImage catagory_icons_brewer_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_brewer_pushed.png");

		// Token: 0x040020DA RID: 8410
		public static BaseImage catagory_icons_defender_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_defender_normal.png");

		// Token: 0x040020DB RID: 8411
		public static BaseImage catagory_icons_defender_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_defender_over.png");

		// Token: 0x040020DC RID: 8412
		public static BaseImage catagory_icons_defender_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_defender_pushed.png");

		// Token: 0x040020DD RID: 8413
		public static BaseImage catagory_icons_destroyer_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_destroyer_normal.png");

		// Token: 0x040020DE RID: 8414
		public static BaseImage catagory_icons_destroyer_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_destroyer_over.png");

		// Token: 0x040020DF RID: 8415
		public static BaseImage catagory_icons_destroyer_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_destroyer_pushed.png");

		// Token: 0x040020E0 RID: 8416
		public static BaseImage catagory_icons_donator_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_donator_normal.png");

		// Token: 0x040020E1 RID: 8417
		public static BaseImage catagory_icons_donator_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_donator_over.png");

		// Token: 0x040020E2 RID: 8418
		public static BaseImage catagory_icons_donator_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_donator_pushed.png");

		// Token: 0x040020E3 RID: 8419
		public static BaseImage catagory_icons_factions_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_factions_normal.png");

		// Token: 0x040020E4 RID: 8420
		public static BaseImage catagory_icons_factions_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_factions_over.png");

		// Token: 0x040020E5 RID: 8421
		public static BaseImage catagory_icons_factions_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_factions_pushed.png");

		// Token: 0x040020E6 RID: 8422
		public static BaseImage catagory_icons_farmer_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_farmer_normal.png");

		// Token: 0x040020E7 RID: 8423
		public static BaseImage catagory_icons_farmer_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_farmer_over.png");

		// Token: 0x040020E8 RID: 8424
		public static BaseImage catagory_icons_farmer_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_farmer_pushed.png");

		// Token: 0x040020E9 RID: 8425
		public static BaseImage catagory_icons_forger_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_forger_normal.png");

		// Token: 0x040020EA RID: 8426
		public static BaseImage catagory_icons_forger_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_forger_over.png");

		// Token: 0x040020EB RID: 8427
		public static BaseImage catagory_icons_forger_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_forger_pushed.png");

		// Token: 0x040020EC RID: 8428
		public static BaseImage catagory_icons_houses_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_houses_normal.png");

		// Token: 0x040020ED RID: 8429
		public static BaseImage catagory_icons_houses_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_houses_over.png");

		// Token: 0x040020EE RID: 8430
		public static BaseImage catagory_icons_houses_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_houses_pushed.png");

		// Token: 0x040020EF RID: 8431
		public static BaseImage catagory_icons_merchant_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_merchant_normal.png");

		// Token: 0x040020F0 RID: 8432
		public static BaseImage catagory_icons_merchant_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_merchant_over.png");

		// Token: 0x040020F1 RID: 8433
		public static BaseImage catagory_icons_merchant_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_merchant_pushed.png");

		// Token: 0x040020F2 RID: 8434
		public static BaseImage catagory_icons_parishes_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishes_normal.png");

		// Token: 0x040020F3 RID: 8435
		public static BaseImage catagory_icons_parishes_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishes_over.png");

		// Token: 0x040020F4 RID: 8436
		public static BaseImage catagory_icons_parishes_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishes_pushed.png");

		// Token: 0x040020F5 RID: 8437
		public static BaseImage catagory_icons_parishflags_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishflags_normal.png");

		// Token: 0x040020F6 RID: 8438
		public static BaseImage catagory_icons_parishflags_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishflags_over.png");

		// Token: 0x040020F7 RID: 8439
		public static BaseImage catagory_icons_parishflags_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_parishflags_pushed.png");

		// Token: 0x040020F8 RID: 8440
		public static BaseImage catagory_icons_pillager_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_pillager_normal.png");

		// Token: 0x040020F9 RID: 8441
		public static BaseImage catagory_icons_pillager_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_pillager_over.png");

		// Token: 0x040020FA RID: 8442
		public static BaseImage catagory_icons_pillager_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_pillager_pushed.png");

		// Token: 0x040020FB RID: 8443
		public static BaseImage catagory_icons_points_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_points_normal.png");

		// Token: 0x040020FC RID: 8444
		public static BaseImage catagory_icons_points_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_points_over.png");

		// Token: 0x040020FD RID: 8445
		public static BaseImage catagory_icons_points_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_points_pushed.png");

		// Token: 0x040020FE RID: 8446
		public static BaseImage catagory_icons_rank_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_rank_normal.png");

		// Token: 0x040020FF RID: 8447
		public static BaseImage catagory_icons_rank_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_rank_over.png");

		// Token: 0x04002100 RID: 8448
		public static BaseImage catagory_icons_rank_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_rank_pushed.png");

		// Token: 0x04002101 RID: 8449
		public static BaseImage catagory_icons_villages_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_villages_normal.png");

		// Token: 0x04002102 RID: 8450
		public static BaseImage catagory_icons_villages_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_villages_over.png");

		// Token: 0x04002103 RID: 8451
		public static BaseImage catagory_icons_villages_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_villages_pushed.png");

		// Token: 0x04002104 RID: 8452
		public static BaseImage catagory_icons_wolfbane_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_wolfbane_normal.png");

		// Token: 0x04002105 RID: 8453
		public static BaseImage catagory_icons_wolfbane_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_wolfbane_over.png");

		// Token: 0x04002106 RID: 8454
		public static BaseImage catagory_icons_wolfbane_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_wolfbane_pushed.png");

		// Token: 0x04002107 RID: 8455
		public static BaseImage catagory_icons_worker_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_worker_normal.png");

		// Token: 0x04002108 RID: 8456
		public static BaseImage catagory_icons_worker_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_worker_over.png");

		// Token: 0x04002109 RID: 8457
		public static BaseImage catagory_icons_worker_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_worker_pushed.png");

		// Token: 0x0400210A RID: 8458
		public static BaseImage catagory_icons_capture_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_capture_normal.png");

		// Token: 0x0400210B RID: 8459
		public static BaseImage catagory_icons_capture_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_capture_over.png");

		// Token: 0x0400210C RID: 8460
		public static BaseImage catagory_icons_capture_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_capture_pushed.png");

		// Token: 0x0400210D RID: 8461
		public static BaseImage catagory_icons_raze_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_raze_normal.png");

		// Token: 0x0400210E RID: 8462
		public static BaseImage catagory_icons_raze_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_raze_over.png");

		// Token: 0x0400210F RID: 8463
		public static BaseImage catagory_icons_raze_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_raze_pushed.png");

		// Token: 0x04002110 RID: 8464
		public static BaseImage catagory_icons_glory_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_glory_normal.png");

		// Token: 0x04002111 RID: 8465
		public static BaseImage catagory_icons_glory_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_glory_over.png");

		// Token: 0x04002112 RID: 8466
		public static BaseImage catagory_icons_glory_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_glory_pushed.png");

		// Token: 0x04002113 RID: 8467
		public static BaseImage catagory_icons_killstreak_normal = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_killstreak_normal.png");

		// Token: 0x04002114 RID: 8468
		public static BaseImage catagory_icons_killstreak_over = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_killstreak_over.png");

		// Token: 0x04002115 RID: 8469
		public static BaseImage catagory_icons_killstreak_pushed = new BaseImage(AssetPaths.AssetIconsStats, "catagory_icons_killstreak_pushed.png");

		// Token: 0x04002116 RID: 8470
		public static BaseImage house_flag_001 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_001.png");

		// Token: 0x04002117 RID: 8471
		public static BaseImage house_flag_002 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_002.png");

		// Token: 0x04002118 RID: 8472
		public static BaseImage house_flag_003 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_003.png");

		// Token: 0x04002119 RID: 8473
		public static BaseImage house_flag_004 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_004.png");

		// Token: 0x0400211A RID: 8474
		public static BaseImage house_flag_005 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_005.png");

		// Token: 0x0400211B RID: 8475
		public static BaseImage house_flag_006 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_006.png");

		// Token: 0x0400211C RID: 8476
		public static BaseImage house_flag_007 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_007.png");

		// Token: 0x0400211D RID: 8477
		public static BaseImage house_flag_008 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_008.png");

		// Token: 0x0400211E RID: 8478
		public static BaseImage house_flag_009 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_009.png");

		// Token: 0x0400211F RID: 8479
		public static BaseImage house_flag_010 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_010.png");

		// Token: 0x04002120 RID: 8480
		public static BaseImage house_flag_011 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_011.png");

		// Token: 0x04002121 RID: 8481
		public static BaseImage house_flag_012 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_012.png");

		// Token: 0x04002122 RID: 8482
		public static BaseImage house_flag_013 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_013.png");

		// Token: 0x04002123 RID: 8483
		public static BaseImage house_flag_014 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_014.png");

		// Token: 0x04002124 RID: 8484
		public static BaseImage house_flag_015 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_015.png");

		// Token: 0x04002125 RID: 8485
		public static BaseImage house_flag_016 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_016.png");

		// Token: 0x04002126 RID: 8486
		public static BaseImage house_flag_017 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_017.png");

		// Token: 0x04002127 RID: 8487
		public static BaseImage house_flag_018 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_018.png");

		// Token: 0x04002128 RID: 8488
		public static BaseImage house_flag_019 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_019.png");

		// Token: 0x04002129 RID: 8489
		public static BaseImage house_flag_020 = new BaseImage(AssetPaths.AssetIconsStats, "house_flag_020.png");

		// Token: 0x0400212A RID: 8490
		public static BaseImage int_statsscreen_iconbar_arrow_left_normal = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-left_normal.png");

		// Token: 0x0400212B RID: 8491
		public static BaseImage int_statsscreen_iconbar_arrow_left_over = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-left_over.png");

		// Token: 0x0400212C RID: 8492
		public static BaseImage int_statsscreen_iconbar_arrow_left_pressed = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-left_pressed.png");

		// Token: 0x0400212D RID: 8493
		public static BaseImage int_statsscreen_iconbar_arrow_right_normal = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-right_normal.png");

		// Token: 0x0400212E RID: 8494
		public static BaseImage int_statsscreen_iconbar_arrow_right_over = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-right_over.png");

		// Token: 0x0400212F RID: 8495
		public static BaseImage int_statsscreen_iconbar_arrow_right_pressed = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_arrow-right_pressed.png");

		// Token: 0x04002130 RID: 8496
		public static BaseImage int_statsscreen_iconbar_left = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_left.png");

		// Token: 0x04002131 RID: 8497
		public static BaseImage int_statsscreen_iconbar_middle = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_middle.png");

		// Token: 0x04002132 RID: 8498
		public static BaseImage int_statsscreen_iconbar_right = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_iconbar_right.png");

		// Token: 0x04002133 RID: 8499
		public static BaseImage int_statsscreen_listbar_darker = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_listbar_darker.png");

		// Token: 0x04002134 RID: 8500
		public static BaseImage int_statsscreen_listbar_lighter = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_listbar_lighter.png");

		// Token: 0x04002135 RID: 8501
		public static BaseImage int_statsscreen_maininset_bottom = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_maininset_bottom.png");

		// Token: 0x04002136 RID: 8502
		public static BaseImage int_statsscreen_maininset_middle = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_maininset_middle.png");

		// Token: 0x04002137 RID: 8503
		public static BaseImage int_statsscreen_maininset_top_top = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_maininset_top_top.png");

		// Token: 0x04002138 RID: 8504
		public static BaseImage int_statsscreen_maininset_top_middle = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_maininset_top_middle.png");

		// Token: 0x04002139 RID: 8505
		public static BaseImage int_statsscreen_maininset_top_bottom = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_maininset_top_bottom.png");

		// Token: 0x0400213A RID: 8506
		public static BaseImage int_statsscreen_search_button_normal = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_button_normal.png");

		// Token: 0x0400213B RID: 8507
		public static BaseImage int_statsscreen_search_button_over = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_button_over.png");

		// Token: 0x0400213C RID: 8508
		public static BaseImage int_statsscreen_search_button_pushed = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_button_pushed.png");

		// Token: 0x0400213D RID: 8509
		public static BaseImage int_statsscreen_search_clear_button_normal = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_clear_button_normal.png");

		// Token: 0x0400213E RID: 8510
		public static BaseImage int_statsscreen_search_clear_button_over = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_clear_button_over.png");

		// Token: 0x0400213F RID: 8511
		public static BaseImage int_statsscreen_search_clear_button_pushed = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_clear_button_pushed.png");

		// Token: 0x04002140 RID: 8512
		public static BaseImage int_statsscreen_search_inset = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_search_inset.png");

		// Token: 0x04002141 RID: 8513
		public static BaseImage int_statsscreen_secondinset_bar_darker = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_secondinset_bar-darker.png");

		// Token: 0x04002142 RID: 8514
		public static BaseImage int_statsscreen_secondinset_bar_lighter = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_secondinset_bar-lighter.png");

		// Token: 0x04002143 RID: 8515
		public static BaseImage int_statsscreen_secondinset_bottom = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_secondinset_bottom.png");

		// Token: 0x04002144 RID: 8516
		public static BaseImage int_statsscreen_secondinset_middle = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_secondinset_middle.png");

		// Token: 0x04002145 RID: 8517
		public static BaseImage int_statsscreen_secondinset_top = new BaseImage(AssetPaths.AssetIconsStats, "int_statsscreen_secondinset_top.png");

		// Token: 0x04002146 RID: 8518
		public static BaseImage page_bottom_normal = new BaseImage(AssetPaths.AssetIconsStats, "page_bottom_normal.png");

		// Token: 0x04002147 RID: 8519
		public static BaseImage page_bottom_over = new BaseImage(AssetPaths.AssetIconsStats, "page_bottom_over.png");

		// Token: 0x04002148 RID: 8520
		public static BaseImage page_bottom_pushed = new BaseImage(AssetPaths.AssetIconsStats, "page_bottom_pushed.png");

		// Token: 0x04002149 RID: 8521
		public static BaseImage page_down_normal = new BaseImage(AssetPaths.AssetIconsStats, "page_down_normal.png");

		// Token: 0x0400214A RID: 8522
		public static BaseImage page_down_over = new BaseImage(AssetPaths.AssetIconsStats, "page_down_over.png");

		// Token: 0x0400214B RID: 8523
		public static BaseImage page_down_pushed = new BaseImage(AssetPaths.AssetIconsStats, "page_down_pushed.png");

		// Token: 0x0400214C RID: 8524
		public static BaseImage page_top_norrmal = new BaseImage(AssetPaths.AssetIconsStats, "page_top_norrmal.png");

		// Token: 0x0400214D RID: 8525
		public static BaseImage page_top_over = new BaseImage(AssetPaths.AssetIconsStats, "page_top_over.png");

		// Token: 0x0400214E RID: 8526
		public static BaseImage page_top_pushed = new BaseImage(AssetPaths.AssetIconsStats, "page_top_pushed.png");

		// Token: 0x0400214F RID: 8527
		public static BaseImage page_up_normal = new BaseImage(AssetPaths.AssetIconsStats, "page_up_normal.png");

		// Token: 0x04002150 RID: 8528
		public static BaseImage page_up_over = new BaseImage(AssetPaths.AssetIconsStats, "page_up_over.png");

		// Token: 0x04002151 RID: 8529
		public static BaseImage page_up_pushed = new BaseImage(AssetPaths.AssetIconsStats, "page_up_pushed.png");

		// Token: 0x04002152 RID: 8530
		public static BaseImage arrow_up = new BaseImage(AssetPaths.AssetIconsStats, "arrow_up.png");

		// Token: 0x04002153 RID: 8531
		public static BaseImage arrow_down = new BaseImage(AssetPaths.AssetIconsStats, "arrow_down.png");

		// Token: 0x04002154 RID: 8532
		public static BaseImage button_blue_01_in = new BaseImage(AssetPaths.AssetIconsReports, "button_blue_01_in.png");

		// Token: 0x04002155 RID: 8533
		public static BaseImage button_blue_01_normal = new BaseImage(AssetPaths.AssetIconsReports, "button_blue_01_normal.png");

		// Token: 0x04002156 RID: 8534
		public static BaseImage button_blue_01_over = new BaseImage(AssetPaths.AssetIconsReports, "button_blue_01_over.png");

		// Token: 0x04002157 RID: 8535
		public static BaseImage reports_checkbox_empty = new BaseImage(AssetPaths.AssetIconsReports, "checkbox_empty.png");

		// Token: 0x04002158 RID: 8536
		public static BaseImage reports_checkbox_faded = new BaseImage(AssetPaths.AssetIconsReports, "checkbox_faded.png");

		// Token: 0x04002159 RID: 8537
		public static BaseImage reports_checkbox_checked = new BaseImage(AssetPaths.AssetIconsReports, "checkbox_checked.png");

		// Token: 0x0400215A RID: 8538
		public static BaseImage icon_arrow_down = new BaseImage(AssetPaths.AssetIconsReports, "icon_arrow_down.png");

		// Token: 0x0400215B RID: 8539
		public static BaseImage icon_bang = new BaseImage(AssetPaths.AssetIconsReports, "icon_bang.png");

		// Token: 0x0400215C RID: 8540
		public static BaseImage icon_capture = new BaseImage(AssetPaths.AssetIconsReports, "icon_capture.png");

		// Token: 0x0400215D RID: 8541
		public static BaseImage icon_capture_over = new BaseImage(AssetPaths.AssetIconsReports, "icon_capture_over.png");

		// Token: 0x0400215E RID: 8542
		public static BaseImage icon_filter = new BaseImage(AssetPaths.AssetIconsReports, "icon_filter.png");

		// Token: 0x0400215F RID: 8543
		public static BaseImage icon_folder = new BaseImage(AssetPaths.AssetIconsReports, "icon_folder.png");

		// Token: 0x04002160 RID: 8544
		public static BaseImage icon_filter_over = new BaseImage(AssetPaths.AssetIconsReports, "icon_filter_over.png");

		// Token: 0x04002161 RID: 8545
		public static BaseImage icon_filter_selected = new BaseImage(AssetPaths.AssetIconsReports, "icon_filter_selected_normal.png");

		// Token: 0x04002162 RID: 8546
		public static BaseImage icon_filter_selected_over = new BaseImage(AssetPaths.AssetIconsReports, "icon_filter_selected_over.png");

		// Token: 0x04002163 RID: 8547
		public static BaseImage icon_trash = new BaseImage(AssetPaths.AssetIconsReports, "icon_trash_normal.png");

		// Token: 0x04002164 RID: 8548
		public static BaseImage icon_trash_over = new BaseImage(AssetPaths.AssetIconsReports, "icon_trash_over.png");

		// Token: 0x04002165 RID: 8549
		public static BaseImage icon_folder_back = new BaseImage(AssetPaths.AssetIconsReports, "icon_folder_back.png");

		// Token: 0x04002166 RID: 8550
		public static BaseImage icon_scroll_closed = new BaseImage(AssetPaths.AssetIconsReports, "icon_scroll_closed.png");

		// Token: 0x04002167 RID: 8551
		public static BaseImage iconband = new BaseImage(AssetPaths.AssetIconsReports, "iconband.png");

		// Token: 0x04002168 RID: 8552
		public static BaseImage lineitem_strip_01_dark = new BaseImage(AssetPaths.AssetIconsReports, "lineitem_strip_01_dark.png");

		// Token: 0x04002169 RID: 8553
		public static BaseImage lineitem_strip_01_light = new BaseImage(AssetPaths.AssetIconsReports, "lineitem_strip_01_light.png");

		// Token: 0x0400216A RID: 8554
		public static BaseImage lineitem_strip_02_dark = new BaseImage(AssetPaths.AssetIconsReports, "lineitem_strip_02_dark.png");

		// Token: 0x0400216B RID: 8555
		public static BaseImage lineitem_strip_02_light = new BaseImage(AssetPaths.AssetIconsReports, "lineitem_strip_02_light.png");

		// Token: 0x0400216C RID: 8556
		public static BaseImage popup_background_01 = new BaseImage(AssetPaths.AssetIconsReports, "popup_background_01.png");

		// Token: 0x0400216D RID: 8557
		public static BaseImage[] char_but_achievement = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_but_achievement", 3);

		// Token: 0x0400216E RID: 8558
		public static BaseImage[] char_but_invite = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_but_invite", 2);

		// Token: 0x0400216F RID: 8559
		public static BaseImage[] char_but_mail = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_but_mail", 2);

		// Token: 0x04002170 RID: 8560
		public static BaseImage[] char_but_quest = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_but_quest", 3);

		// Token: 0x04002171 RID: 8561
		public static BaseImage[] char_position = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_position", 8);

		// Token: 0x04002172 RID: 8562
		public static BaseImage[] char_village_icons = BaseImage.createFromUV(AssetPaths.AssetIconsUser, "char_village_icons", 20);

		// Token: 0x04002173 RID: 8563
		public static BaseImage char_line_01 = new BaseImage(AssetPaths.AssetIconsUser, "char_line_01.png");

		// Token: 0x04002174 RID: 8564
		public static BaseImage char_line_02 = new BaseImage(AssetPaths.AssetIconsUser, "char_line_02.png");

		// Token: 0x04002175 RID: 8565
		public static BaseImage char_portraite_shadow = new BaseImage(AssetPaths.AssetIconsUser, "char_portraite_shadow.png");

		// Token: 0x04002176 RID: 8566
		public static BaseImage char_shieldcomp_back = new BaseImage(AssetPaths.AssetIconsUser, "char_shieldcomp_back.png");

		// Token: 0x04002177 RID: 8567
		public static BaseImage char_villagelist_inset = new BaseImage(AssetPaths.AssetIconsUser, "char_villagelist_inset.png");

		// Token: 0x04002178 RID: 8568
		public static BaseImage char_shadow_faction = new BaseImage(AssetPaths.AssetIconsUser, "shadow_faction.png");

		// Token: 0x04002179 RID: 8569
		public static BaseImage char_shadow_house = new BaseImage(AssetPaths.AssetIconsUser, "shadow_house.png");

		// Token: 0x0400217A RID: 8570
		public static BaseImage[] custom_player_marker = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker1.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker2.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker3.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker4.png")
		};

		// Token: 0x0400217B RID: 8571
		public static BaseImage[] custom_player_marker_selected = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker1_select.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker2_select.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker3_select.png"),
			new BaseImage(AssetPaths.AssetIconsUser, "playerMarker4_select.png")
		};

		// Token: 0x0400217C RID: 8572
		public static BaseImage[] tutorial_illustrations = BaseImage.createFromUV(AssetPaths.AssetIconsTutorial, "tutorial_illustration_array", 30);

		// Token: 0x0400217D RID: 8573
		public static BaseImage[] tutorial_arrow_yellow = BaseImage.createFromUV(AssetPaths.AssetIconsTutorial, "tutorial_arrow_3d_yellow", 2);

		// Token: 0x0400217E RID: 8574
		public static BaseImage[] tutorial_reward_anim = BaseImage.createFromUV(AssetPaths.AssetIconsTutorial, "reward_burst_x20", 20);

		// Token: 0x0400217F RID: 8575
		public static BaseImage tutorial_background = new BaseImage(AssetPaths.AssetIconsTutorial, "tutorial_background");

		// Token: 0x04002180 RID: 8576
		public static BaseImage tutorial_button_normal = new BaseImage(AssetPaths.AssetIconsTutorial, "tutorial_button_normal");

		// Token: 0x04002181 RID: 8577
		public static BaseImage tutorial_button_over = new BaseImage(AssetPaths.AssetIconsTutorial, "tutorial_button_over");

		// Token: 0x04002182 RID: 8578
		public static BaseImage minimize_Normal = new BaseImage(AssetPaths.AssetIconsTutorial, "minimize_Normal");

		// Token: 0x04002183 RID: 8579
		public static BaseImage minimize_Over = new BaseImage(AssetPaths.AssetIconsTutorial, "minimize_Over");

		// Token: 0x04002184 RID: 8580
		public static BaseImage tutorial_button_glow = new BaseImage(AssetPaths.AssetIconsTutorial, "tut___but_glow");

		// Token: 0x04002185 RID: 8581
		public static BaseImage tutorial_longarm1 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms1-1.png");

		// Token: 0x04002186 RID: 8582
		public static BaseImage tutorial_longarm2 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms2-1.png");

		// Token: 0x04002187 RID: 8583
		public static BaseImage tutorial_longarm3 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms3-1.png");

		// Token: 0x04002188 RID: 8584
		public static BaseImage tutorial_longarm4 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms4-1.png");

		// Token: 0x04002189 RID: 8585
		public static BaseImage tutorial_longarm5 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms5-1.png");

		// Token: 0x0400218A RID: 8586
		public static BaseImage tutorial_longarm6 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms6-1.png");

		// Token: 0x0400218B RID: 8587
		public static BaseImage tutorial_longarm7 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms7-1.png");

		// Token: 0x0400218C RID: 8588
		public static BaseImage tutorial_longarm8 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms8-1.png");

		// Token: 0x0400218D RID: 8589
		public static BaseImage tutorial_longarm9 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms9-1.png");

		// Token: 0x0400218E RID: 8590
		public static BaseImage tutorial_longarm10 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms10-1.png");

		// Token: 0x0400218F RID: 8591
		public static BaseImage tutorial_longarm11 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms11-1.png");

		// Token: 0x04002190 RID: 8592
		public static BaseImage tutorial_longarm12 = new BaseImage(AssetPaths.AssetIconsTutorial, "longarms12-1.png");

		// Token: 0x04002191 RID: 8593
		public static BaseImage glory_background = new BaseImage(AssetPaths.AssetIconsGlory, "background");

		// Token: 0x04002192 RID: 8594
		public static BaseImage glory_thin_pole = new BaseImage(AssetPaths.AssetIconsGlory, "ploe_thin");

		// Token: 0x04002193 RID: 8595
		public static BaseImage glory_thick_pole = new BaseImage(AssetPaths.AssetIconsGlory, "ploe_thick");

		// Token: 0x04002194 RID: 8596
		public static BaseImage glory_star_large = new BaseImage(AssetPaths.AssetIconsGlory, "star_01");

		// Token: 0x04002195 RID: 8597
		public static BaseImage glory_star_small = new BaseImage(AssetPaths.AssetIconsGlory, "star_02");

		// Token: 0x04002196 RID: 8598
		public static BaseImage FactionTabBar_1_Normal = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_1_Normal.png");

		// Token: 0x04002197 RID: 8599
		public static BaseImage FactionTabBar_1_Selected = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_1_Selected.png");

		// Token: 0x04002198 RID: 8600
		public static BaseImage FactionTabBar_2_Normal = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_2_Normal.png");

		// Token: 0x04002199 RID: 8601
		public static BaseImage FactionTabBar_2_Selected = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_2_Selected.png");

		// Token: 0x0400219A RID: 8602
		public static BaseImage FactionTabBar_3_Normal = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_3_Normal.png");

		// Token: 0x0400219B RID: 8603
		public static BaseImage FactionTabBar_3_Selected = new BaseImage(AssetPaths.AssetIconsGlory, "FactionTabBar_3_Selected.png");

		// Token: 0x0400219C RID: 8604
		public static BaseImage faction_pen = new BaseImage(AssetPaths.AssetIconsGlory, "rdit_icon");

		// Token: 0x0400219D RID: 8605
		public static BaseImage faction_background = new BaseImage(AssetPaths.AssetIconsGlory, "faction_right_panel_back.png");

		// Token: 0x0400219E RID: 8606
		public static BaseImage faction_background_bottom = new BaseImage(AssetPaths.AssetIconsGlory, "faction_right_panel_back_bottom.png");

		// Token: 0x0400219F RID: 8607
		public static BaseImage faction_button_background = new BaseImage(AssetPaths.AssetIconsGlory, "faction_button_selected.png");

		// Token: 0x040021A0 RID: 8608
		public static BaseImage faction_button_background1 = new BaseImage(AssetPaths.AssetIconsGlory, "faction_button_selected_row1.png");

		// Token: 0x040021A1 RID: 8609
		public static BaseImage faction_button_background2 = new BaseImage(AssetPaths.AssetIconsGlory, "faction_button_selected_row2.png");

		// Token: 0x040021A2 RID: 8610
		public static BaseImage faction_button_background3 = new BaseImage(AssetPaths.AssetIconsGlory, "faction_button_selected_row3.png");

		// Token: 0x040021A3 RID: 8611
		public static BaseImage trashcan_normal = new BaseImage(AssetPaths.AssetIconsGlory, "trashcan_25tall_semitrans.png");

		// Token: 0x040021A4 RID: 8612
		public static BaseImage trashcan_over = new BaseImage(AssetPaths.AssetIconsGlory, "trashcan_25tal_over.png");

		// Token: 0x040021A5 RID: 8613
		public static BaseImage trashcan_clicked = new BaseImage(AssetPaths.AssetIconsGlory, "trashcan_25tall.png");

		// Token: 0x040021A6 RID: 8614
		public static BaseImage house_circles_medium_selected_top = new BaseImage(AssetPaths.AssetIconsGlory, "house_circles_medium_selected_top.png");

		// Token: 0x040021A7 RID: 8615
		public static BaseImage faction_flag_outline_100 = new BaseImage(AssetPaths.AssetIconsGlory, "flag_outline_100.png");

		// Token: 0x040021A8 RID: 8616
		public static BaseImage faction_flag_outline_50 = new BaseImage(AssetPaths.AssetIconsGlory, "flag_outline_50.png");

		// Token: 0x040021A9 RID: 8617
		public static BaseImage faction_flag_outline_25 = new BaseImage(AssetPaths.AssetIconsGlory, "flag_outline_25.png");

		// Token: 0x040021AA RID: 8618
		public static BaseImage faction_inset = new BaseImage(AssetPaths.AssetIconsGlory, "color picker inset.png");

		// Token: 0x040021AB RID: 8619
		public static BaseImage arrow_button_left_normal = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_left_normal.png");

		// Token: 0x040021AC RID: 8620
		public static BaseImage arrow_button_left_over = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_left_over.png");

		// Token: 0x040021AD RID: 8621
		public static BaseImage arrow_button_left_pushed = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_left_pushed.png");

		// Token: 0x040021AE RID: 8622
		public static BaseImage arrow_button_right_normal = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_right_normal.png");

		// Token: 0x040021AF RID: 8623
		public static BaseImage arrow_button_right_over = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_right_over.png");

		// Token: 0x040021B0 RID: 8624
		public static BaseImage arrow_button_right_pushed = new BaseImage(AssetPaths.AssetIconsGlory, "arrow_button_right_pushed.png");

		// Token: 0x040021B1 RID: 8625
		public static BaseImage glory_frame = new BaseImage(AssetPaths.AssetIconsGlory, "glory frame.png");

		// Token: 0x040021B2 RID: 8626
		public static BaseImage faction_title_band = new BaseImage(AssetPaths.AssetIconsGlory, "title_band.png");

		// Token: 0x040021B3 RID: 8627
		public static BaseImage faction_tanback = new BaseImage(AssetPaths.AssetIconsGlory, "faction_tanback.png");

		// Token: 0x040021B4 RID: 8628
		public static BaseImage faction_bar_tan_1_lighter = new BaseImage(AssetPaths.AssetIconsGlory, "faction_bar_tan_1_lighter.png");

		// Token: 0x040021B5 RID: 8629
		public static BaseImage faction_bar_tan_1_heavier = new BaseImage(AssetPaths.AssetIconsGlory, "faction_bar_tan_1_heavier.png");

		// Token: 0x040021B6 RID: 8630
		public static BaseImage faction_bar_tan_2_lighter = new BaseImage(AssetPaths.AssetIconsGlory, "faction_bar_tan_2_lighter.png");

		// Token: 0x040021B7 RID: 8631
		public static BaseImage faction_bar_tan_2_heavier = new BaseImage(AssetPaths.AssetIconsGlory, "faction_bar_tan_2_heavier.png");

		// Token: 0x040021B8 RID: 8632
		public static BaseImage eow_left = new BaseImage(AssetPaths.AssetIconsGlory, "EoW_Screen-Background-Left.png");

		// Token: 0x040021B9 RID: 8633
		public static BaseImage eow_right = new BaseImage(AssetPaths.AssetIconsGlory, "EoW_Screen-Background-Right.png");

		// Token: 0x040021BA RID: 8634
		public static BaseImage eow_right_paper = new BaseImage(AssetPaths.AssetIconsGlory, "EoW_Screen-Background-Right_paper.png");

		// Token: 0x040021BB RID: 8635
		public static BaseImage[] eow_toggle = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "EoW_button-toggle-array", 6);

		// Token: 0x040021BC RID: 8636
		public static BaseImage[] eow_buttons = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "EoW_EndWorld-button_array_with-highlight", 27);

		// Token: 0x040021BD RID: 8637
		public static BaseImage[] factionFlags = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsGlory, "f_00.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_01.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_02.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_03.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_04.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_05.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_06.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_07.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_08.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_09.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_10.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_11.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_12.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_13.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_14.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_15.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_16.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_17.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_18.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_19.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_20.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_21.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_22.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_23.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_24.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_25.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_26.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_27.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_28.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_29.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_30.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_31.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_32.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_33.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_34.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_35.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_36.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_37.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_38.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_39.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_40.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_41.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_42.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_43.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_44.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_45.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_46.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_47.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_48.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_49.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_50.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_51.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_52.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_53.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_54.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_55.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_56.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_57.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_58.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_59.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_60.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_61.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_62.png"),
			new BaseImage(AssetPaths.AssetIconsGlory, "f_63.png")
		};

		// Token: 0x040021BE RID: 8638
		public static BaseImage[] glory_flags_largest = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "flags_array_largest", 20);

		// Token: 0x040021BF RID: 8639
		public static BaseImage[] glory_flags_large = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "flags_array_large", 20);

		// Token: 0x040021C0 RID: 8640
		public static BaseImage[] glory_flags_med = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "flags_array_med", 20);

		// Token: 0x040021C1 RID: 8641
		public static BaseImage[] glory_flags_small = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "flags_array_small", 20);

		// Token: 0x040021C2 RID: 8642
		public static BaseImage[] faction_leaders = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "leader_officer", 2);

		// Token: 0x040021C3 RID: 8643
		public static BaseImage[] faction_relationships = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "sword_rosetta", 3);

		// Token: 0x040021C4 RID: 8644
		public static BaseImage[] faction_buttons = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "faction_buttons", 24);

		// Token: 0x040021C5 RID: 8645
		public static BaseImage[] house_circles_medium = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "house_circles_medium", 40);

		// Token: 0x040021C6 RID: 8646
		public static BaseImage[] house_circles_large = BaseImage.createFromUV(AssetPaths.AssetIconsGlory, "house_circles_large", 20);

		// Token: 0x040021C7 RID: 8647
		public static BaseImage[] free_card_screen_cardback_array = BaseImage.createFromUV(AssetPaths.AssetIconsFreeCards, "free_card_screen_cardback_array", 14);

		// Token: 0x040021C8 RID: 8648
		public static BaseImage[] free_card_screen_wax_array = BaseImage.createFromUV(AssetPaths.AssetIconsFreeCards, "free_card_screen_wax_array", 10);

		// Token: 0x040021C9 RID: 8649
		public static BaseImage free_card_screen_card_fan = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_card_fan");

		// Token: 0x040021CA RID: 8650
		public static BaseImage free_card_screen_green_panel_bottom_left = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_bottom_left");

		// Token: 0x040021CB RID: 8651
		public static BaseImage free_card_screen_green_panel_bottom_mid = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_bottom_mid");

		// Token: 0x040021CC RID: 8652
		public static BaseImage free_card_screen_green_panel_bottom_right = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_bottom_right");

		// Token: 0x040021CD RID: 8653
		public static BaseImage free_card_screen_green_panel_mid_left = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_mid_left");

		// Token: 0x040021CE RID: 8654
		public static BaseImage free_card_screen_green_panel_mid_mid = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_mid_mid");

		// Token: 0x040021CF RID: 8655
		public static BaseImage free_card_screen_green_panel_mid_right = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_mid_right");

		// Token: 0x040021D0 RID: 8656
		public static BaseImage free_card_screen_green_panel_top_left = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_top_left");

		// Token: 0x040021D1 RID: 8657
		public static BaseImage free_card_screen_green_panel_top_mid = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_top_mid");

		// Token: 0x040021D2 RID: 8658
		public static BaseImage free_card_screen_green_panel_top_right = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_green_panel_top_right");

		// Token: 0x040021D3 RID: 8659
		public static BaseImage free_card_screen_progbar_fill = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_progbar_fill");

		// Token: 0x040021D4 RID: 8660
		public static BaseImage free_card_screen_progbar_left = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_progbar_left");

		// Token: 0x040021D5 RID: 8661
		public static BaseImage free_card_screen_progbar_mid = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_progbar_mid");

		// Token: 0x040021D6 RID: 8662
		public static BaseImage free_card_screen_progbar_right = new BaseImage(AssetPaths.AssetIconsFreeCards, "free_card_screen_progbar_right");

		// Token: 0x040021D7 RID: 8663
		public static BaseImage you_got_free_card_screen_cardback = new BaseImage(AssetPaths.AssetIconsFreeCards, "you_got_free_card_screen_cardback");

		// Token: 0x040021D8 RID: 8664
		public static BaseImage you_got_free_card_screen_parchment = new BaseImage(AssetPaths.AssetIconsFreeCards, "you_got_free_card_screen_parchment");

		// Token: 0x040021D9 RID: 8665
		public static BaseImage[] villageType_illustrations = BaseImage.createFromUV(AssetPaths.AssetIconsVillageType, "new_village_type_illustration_array", 20);

		// Token: 0x040021DA RID: 8666
		public static BaseImage[] villageType_types = BaseImage.createFromUV(AssetPaths.AssetIconsVillageType, "new_village_type_array", 11);

		// Token: 0x040021DB RID: 8667
		public static BaseImage[] villageType_helpButton = BaseImage.createFromUV(AssetPaths.AssetIconsVillageType, "new_village_button_help", 2);

		// Token: 0x040021DC RID: 8668
		public static BaseImage villageType_inset_top = new BaseImage(AssetPaths.AssetIconsVillageType, "new_village_inset_top");

		// Token: 0x040021DD RID: 8669
		public static BaseImage villageType_inset_mid = new BaseImage(AssetPaths.AssetIconsVillageType, "new_village_inset_middle");

		// Token: 0x040021DE RID: 8670
		public static BaseImage villageType_inset_bottom = new BaseImage(AssetPaths.AssetIconsVillageType, "new_village_inset_bottom");

		// Token: 0x040021DF RID: 8671
		public static BaseImage[] mrhp_button_more_info_solid = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "button_more_info_solid", 2);

		// Token: 0x040021E0 RID: 8672
		public static BaseImage[] mrhp_location_portrait = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "location_portrait", 51);

		// Token: 0x040021E1 RID: 8673
		public static BaseImage[] mrhp_world_icons_rhs_array = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "world_icons_rhs_array", 39);

		// Token: 0x040021E2 RID: 8674
		public static BaseImage[] mrhp_travelling_buttons = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "Travelling_buttons", 3);

		// Token: 0x040021E3 RID: 8675
		public static BaseImage[] mrhp_travelling_arrows = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "Travelling_arrows", 2);

		// Token: 0x040021E4 RID: 8676
		public static BaseImage[] mrhp_village_type_miniicons = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "village_type_miniicons", 30);

		// Token: 0x040021E5 RID: 8677
		public static BaseImage[] mrhp_button_150x25 = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "button_150x25", 3);

		// Token: 0x040021E6 RID: 8678
		public static BaseImage[] mrhp_world_filter_check = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "world_filter_check", 2);

		// Token: 0x040021E7 RID: 8679
		public static BaseImage[] mrhp_button_filter_off = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "button_filter_off", 12);

		// Token: 0x040021E8 RID: 8680
		public static BaseImage[] mrhp_button_filter_search = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "button_search", 3);

		// Token: 0x040021E9 RID: 8681
		public static BaseImage[] mrhp_button_filter_ai = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "world_icons_rhs_array_ai", 3);

		// Token: 0x040021EA RID: 8682
		public static BaseImage[] mrhp_button_envelope = BaseImage.createFromUV(AssetPaths.AssetIconsMapPanel, "button_envelope", 3);

		// Token: 0x040021EB RID: 8683
		public static BaseImage mrhp_avatar_frame = new BaseImage(AssetPaths.AssetIconsMapPanel, "avatar_frame");

		// Token: 0x040021EC RID: 8684
		public static BaseImage mrhp_button_filter_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_filter_over");

		// Token: 0x040021ED RID: 8685
		public static BaseImage mrhp_button_filter_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_filter_normal");

		// Token: 0x040021EE RID: 8686
		public static BaseImage mrhp_button_more_info = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_more_info");

		// Token: 0x040021EF RID: 8687
		public static BaseImage mrhp_button_more_info_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_more_info_over");

		// Token: 0x040021F0 RID: 8688
		public static BaseImage mrhp_world_panel_102 = new BaseImage(AssetPaths.AssetIconsMapPanel, "world_panel_102");

		// Token: 0x040021F1 RID: 8689
		public static BaseImage mrhp_world_panel_132 = new BaseImage(AssetPaths.AssetIconsMapPanel, "world_panel_132");

		// Token: 0x040021F2 RID: 8690
		public static BaseImage mrhp_world_panel_192 = new BaseImage(AssetPaths.AssetIconsMapPanel, "world_panel_192");

		// Token: 0x040021F3 RID: 8691
		public static BaseImage mrhp_location_portrait_glow_short = new BaseImage(AssetPaths.AssetIconsMapPanel, "location_portrait_glow_small");

		// Token: 0x040021F4 RID: 8692
		public static BaseImage mrhp_location_portrait_glow_long = new BaseImage(AssetPaths.AssetIconsMapPanel, "location_portrait_glow_long");

		// Token: 0x040021F5 RID: 8693
		public static BaseImage mrhp_button_check_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_check_normal");

		// Token: 0x040021F6 RID: 8694
		public static BaseImage mrhp_button_check_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_check_over");

		// Token: 0x040021F7 RID: 8695
		public static BaseImage mrhp_button_check_pushed = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_check_pushed");

		// Token: 0x040021F8 RID: 8696
		public static BaseImage mrhp_button_x_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_x_normal");

		// Token: 0x040021F9 RID: 8697
		public static BaseImage mrhp_button_x_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_x_over");

		// Token: 0x040021FA RID: 8698
		public static BaseImage mrhp_button_x_pushed = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_x_pushed");

		// Token: 0x040021FB RID: 8699
		public static BaseImage mrhp_button_80_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_80_normal");

		// Token: 0x040021FC RID: 8700
		public static BaseImage mrhp_button_80_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_80_over");

		// Token: 0x040021FD RID: 8701
		public static BaseImage mrhp_button_80_pushed = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_80_pushed");

		// Token: 0x040021FE RID: 8702
		public static BaseImage mrhp_reports = new BaseImage(AssetPaths.AssetIconsMapPanel, "int_world_icon_scroll");

		// Token: 0x040021FF RID: 8703
		public static BaseImage mrhp_avatar_frame_background = new BaseImage(AssetPaths.AssetIconsMapPanel, "avatar_frame_background.png");

		// Token: 0x04002200 RID: 8704
		public static BaseImage mrhp_shield_blank = new BaseImage(AssetPaths.AssetIconsMapPanel, "shield_blank.png");

		// Token: 0x04002201 RID: 8705
		public static BaseImage mrhp_world_icons_filter_selected = new BaseImage(AssetPaths.AssetIconsMapPanel, "world_icons_filter_selected.png");

		// Token: 0x04002202 RID: 8706
		public static BaseImage mrhp_button_filter_off_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_filter_off_normal.png");

		// Token: 0x04002203 RID: 8707
		public static BaseImage mrhp_button_filter_off_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_filter_off_over.png");

		// Token: 0x04002204 RID: 8708
		public static BaseImage mrhp_button_attack_normal = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_attack_normal.png");

		// Token: 0x04002205 RID: 8709
		public static BaseImage mrhp_button_attack_over = new BaseImage(AssetPaths.AssetIconsMapPanel, "button_attack_over.png");

		// Token: 0x04002206 RID: 8710
		public static BaseImage star_market_3 = new BaseImage(AssetPaths.AssetIconsMapPanel, "star_market_03.png");

		// Token: 0x04002207 RID: 8711
		public static BaseImage BlankCard = new BaseImage(AssetPaths.AssetIconsCards, "card_back_39x56.png");

		// Token: 0x04002208 RID: 8712
		public static BaseImage BlankCardShadow = new BaseImage(AssetPaths.AssetIconsCards, "card_back_39x56_plus_shadow.png");

		// Token: 0x04002209 RID: 8713
		public static BaseImage BlankCardShadow_Highlight = new BaseImage(AssetPaths.AssetIconsCards, "card_back_39x56_plus_shadow_bright.png");

		// Token: 0x0400220A RID: 8714
		public static BaseImage BlueCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_border_blue_39x56.png");

		// Token: 0x0400220B RID: 8715
		public static BaseImage GreenCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_border_green_39x56.png");

		// Token: 0x0400220C RID: 8716
		public static BaseImage PurpleCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_border_purple_39x56.png");

		// Token: 0x0400220D RID: 8717
		public static BaseImage RedCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_border_red_39x56.png");

		// Token: 0x0400220E RID: 8718
		public static BaseImage YellowCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_border_yellow_39x56.png");

		// Token: 0x0400220F RID: 8719
		public static BaseImage GreyCardOverlay = new BaseImage(AssetPaths.AssetIconsCards, "card_greyscale_39x56.png");

		// Token: 0x04002210 RID: 8720
		public static BaseImage BlueCardOverlayNobar = new BaseImage(AssetPaths.AssetIconsCards, "card_border_blue_39x56_nobar.png");

		// Token: 0x04002211 RID: 8721
		public static BaseImage GreenCardOverlayNobar = new BaseImage(AssetPaths.AssetIconsCards, "card_border_green_39x56_nobar.png");

		// Token: 0x04002212 RID: 8722
		public static BaseImage PurpleCardOverlayNobar = new BaseImage(AssetPaths.AssetIconsCards, "card_border_purple_39x56_nobar.png");

		// Token: 0x04002213 RID: 8723
		public static BaseImage RedCardOverlayNobar = new BaseImage(AssetPaths.AssetIconsCards, "card_border_red_39x56_nobar.png");

		// Token: 0x04002214 RID: 8724
		public static BaseImage YellowCardOverlayNobar = new BaseImage(AssetPaths.AssetIconsCards, "card_border_yellow_39x56_nobar.png");

		// Token: 0x04002215 RID: 8725
		public static BaseImage menubar_middle_gold = new BaseImage(AssetPaths.AssetIconsCards, "menubar_middle_gold.png");

		// Token: 0x04002216 RID: 8726
		public static BaseImage menubar_middle_over = new BaseImage(AssetPaths.AssetIconsCards, "menubar_middle_over.png");

		// Token: 0x04002217 RID: 8727
		public static BaseImage menubar_middle_offer = new BaseImage(AssetPaths.AssetIconsCards, "menubar_middle_offer.png");

		// Token: 0x04002218 RID: 8728
		public static BaseImage menubar_middle_gold_offer = new BaseImage(AssetPaths.AssetIconsCards, "menubar_middle_gold_offer.png");

		// Token: 0x04002219 RID: 8729
		public static BaseImage menubar_middle_gold_over = new BaseImage(AssetPaths.AssetIconsCards, "menubar_middle_gold_over.png");

		// Token: 0x0400221A RID: 8730
		public static BaseImage card_circles_card = new BaseImage(AssetPaths.AssetIconsCards, "card_circle_cards.png");

		// Token: 0x0400221B RID: 8731
		public static BaseImage[] cardbar_expand = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_open_up.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_open_over.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_open_down.png")
		};

		// Token: 0x0400221C RID: 8732
		public static BaseImage[] cardbar_collapse = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_close_up.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_close_over.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_close_down.png")
		};

		// Token: 0x0400221D RID: 8733
		public static BaseImage[] cardbar_left = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_left_up.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_left_over.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_left_down.png")
		};

		// Token: 0x0400221E RID: 8734
		public static BaseImage[] cardbar_right = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_right_up.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_right_over.png"),
			new BaseImage(AssetPaths.AssetIconsCards, "cardbar_right_down.png")
		};

		// Token: 0x0400221F RID: 8735
		public static BaseImage[] card_circles_timer = BaseImage.createFromUV(AssetPaths.AssetIconsCards, "card_circle_timer_array", 65);

		// Token: 0x04002220 RID: 8736
		public static BaseImage[] card_circles_icons = BaseImage.createFromUV(AssetPaths.AssetIconsCards, "card_circle_icons", 106);

		// Token: 0x04002221 RID: 8737
		public static BaseImage NoImageCardBig = new BaseImage(AssetPaths.AssetIconsBigCards, "_no_image_yet.jpg");

		// Token: 0x04002222 RID: 8738
		public static BaseImage CardGradeBronze = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_175xX242_coin_bronze.png");

		// Token: 0x04002223 RID: 8739
		public static BaseImage CardGradeSilver = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_175xX242_coin_platinum.png");

		// Token: 0x04002224 RID: 8740
		public static BaseImage CardGradeGold = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_175xX242_coin_gold.png");

		// Token: 0x04002225 RID: 8741
		public static BaseImage CardGradeDiamond = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_175xX242_coin_gem.png");

		// Token: 0x04002226 RID: 8742
		public static BaseImage CardGradeDiamond2 = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_175xX242_coin_gem.png");

		// Token: 0x04002227 RID: 8743
		public static BaseImage card_frame_overlay_diamond = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_frame_overlay_diamond");

		// Token: 0x04002228 RID: 8744
		public static BaseImage card_frame_overlay_gold = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_frame_overlay_gold");

		// Token: 0x04002229 RID: 8745
		public static BaseImage card_frame_overlay_sapphire = new BaseImage(AssetPaths.AssetIconsCardGrade, "card_frame_overlay_sapphire");

		// Token: 0x0400222A RID: 8746
		public static BaseImage[] card_diamond_anim = BaseImage.createFromUV(AssetPaths.AssetIconsCardGrade, "diamond_array_blueish", 64);

		// Token: 0x0400222B RID: 8747
		public static BaseImage[] card_diamond2_anim = BaseImage.createFromUV(AssetPaths.AssetIconsCardGrade, "diamond_70_x2_blue", 64);

		// Token: 0x0400222C RID: 8748
		public static BaseImage[] card_diamond3_anim = BaseImage.createFromUV(AssetPaths.AssetIconsCardGrade, "diamond_70_blue", 64);

		// Token: 0x0400222D RID: 8749
		public static BaseImage[] card_gold_anim = BaseImage.createFromUV(AssetPaths.AssetIconsCardGrade, "coin_55_gold", 64);

		// Token: 0x0400222E RID: 8750
		public static BaseImage[] card_sapphire_anim = BaseImage.createFromUV(AssetPaths.AssetIconsCardGrade, "sapphire", 64);

		// Token: 0x0400222F RID: 8751
		public static BaseImage BlueCardOverlayBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_blue.png");

		// Token: 0x04002230 RID: 8752
		public static BaseImage GreenCardOverlayBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_green.png");

		// Token: 0x04002231 RID: 8753
		public static BaseImage RedCardOverlayBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_red.png");

		// Token: 0x04002232 RID: 8754
		public static BaseImage YellowCardOverlayBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_yellow.png");

		// Token: 0x04002233 RID: 8755
		public static BaseImage PurpleCardOverlayBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_purple.png");

		// Token: 0x04002234 RID: 8756
		public static BaseImage BlueCardOverlayBigOver = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_blue_brigh.png");

		// Token: 0x04002235 RID: 8757
		public static BaseImage GreenCardOverlayBigOver = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_green_bright.png");

		// Token: 0x04002236 RID: 8758
		public static BaseImage RedCardOverlayBigOver = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_red_brigh.png");

		// Token: 0x04002237 RID: 8759
		public static BaseImage YellowCardOverlayBigOver = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_yellow_brigh.png");

		// Token: 0x04002238 RID: 8760
		public static BaseImage PurpleCardOverlayBigOver = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_purple_brigh.png");

		// Token: 0x04002239 RID: 8761
		public static BaseImage BlueCardOverlayEmpty = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_blue_empty.png");

		// Token: 0x0400223A RID: 8762
		public static BaseImage GreenCardOverlayEmpty = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_green_empty.png");

		// Token: 0x0400223B RID: 8763
		public static BaseImage RedCardOverlayEmpty = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_red_empty.png");

		// Token: 0x0400223C RID: 8764
		public static BaseImage YellowCardOverlayEmpty = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_yellow_empty.png");

		// Token: 0x0400223D RID: 8765
		public static BaseImage PurpleCardOverlayEmpty = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_purple_empty.png");

		// Token: 0x0400223E RID: 8766
		public static BaseImage CardBackBig = new BaseImage(AssetPaths.AssetIconsCardFrame, "card_175xX242_frame_empty.png");

		// Token: 0x0400223F RID: 8767
		public static BaseImage[] card_offer_pieces = BaseImage.createFromUV(AssetPaths.AssetIconsCardOffers, "card_ad_bitz", 4);

		// Token: 0x04002240 RID: 8768
		public static BaseImage card_offer_background = new BaseImage(AssetPaths.AssetIconsCardOffers, "card_pack_back");

		// Token: 0x04002241 RID: 8769
		public static BaseImage card_offer_background_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "buy_pack_button_over");

		// Token: 0x04002242 RID: 8770
		public static Dictionary<string, BaseImage> CardPackImages;

		// Token: 0x04002243 RID: 8771
		public static BaseImage[] CardSlotAnimFrames = new BaseImage[]
		{
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_apple_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_apple_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_castle_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_castle_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_castle_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_crown_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_crown_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_crown_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_hawk_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_hawk_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_hawk_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_jester_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_jester_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_jester_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_shield_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_shield_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_shield_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_wolf_blur_top.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_wolf_blur_middle.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_wolf_blur_bottom.png"),
			new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_apple_blur_top.png")
		};

		// Token: 0x04002244 RID: 8772
		public static BaseImage CardSlotFrame = new BaseImage(AssetPaths.AssetIconsCardSlots, "card-screen_slot_frame.png");

		// Token: 0x04002245 RID: 8773
		public static BaseImage[] CardFilters_All = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_all_%STATE%.png");

		// Token: 0x04002246 RID: 8774
		public static BaseImage[] CardFilters_Food = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_food_%STATE%.png");

		// Token: 0x04002247 RID: 8775
		public static BaseImage[] CardFilters_Resources = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_resources_%STATE%.png");

		// Token: 0x04002248 RID: 8776
		public static BaseImage[] CardFilters_Honour = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_honour_%STATE%.png");

		// Token: 0x04002249 RID: 8777
		public static BaseImage[] CardFilters_Weapons = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_weapons_%STATE%.png");

		// Token: 0x0400224A RID: 8778
		public static BaseImage[] CardFilters_Research = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_research_%STATE%.png");

		// Token: 0x0400224B RID: 8779
		public static BaseImage[] CardFilters_Industry = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_village_%STATE%.png");

		// Token: 0x0400224C RID: 8780
		public static BaseImage[] CardFilters_Castle = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_castle_%STATE%.png");

		// Token: 0x0400224D RID: 8781
		public static BaseImage[] CardFilters_Army = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_army_%STATE%.png");

		// Token: 0x0400224E RID: 8782
		public static BaseImage[] CardFilters_Scouting = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_scout_%STATE%.png");

		// Token: 0x0400224F RID: 8783
		public static BaseImage[] CardFilters_Trading = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_merchant_%STATE%.png");

		// Token: 0x04002250 RID: 8784
		public static BaseImage[] CardFilters_Religion = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_monk_%STATE%.png");

		// Token: 0x04002251 RID: 8785
		public static BaseImage[] CardFilters_Weapons2 = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_anvil_%STATE%.png");

		// Token: 0x04002252 RID: 8786
		public static BaseImage[] CardFilters_Bread = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_bread_%STATE%.png");

		// Token: 0x04002253 RID: 8787
		public static BaseImage[] CardFilters_Fish = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_fish_%STATE%.png");

		// Token: 0x04002254 RID: 8788
		public static BaseImage[] CardFilters_Apples = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_food_apples_%STATE%.png");

		// Token: 0x04002255 RID: 8789
		public static BaseImage[] CardFilters_Cheese = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_food_cheese_%STATE%.png");

		// Token: 0x04002256 RID: 8790
		public static BaseImage[] CardFilters_Meat = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_meat_%STATE%.png");

		// Token: 0x04002257 RID: 8791
		public static BaseImage[] CardFilters_Veg = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_veg_%STATE%.png");

		// Token: 0x04002258 RID: 8792
		public static BaseImage[] CardFilters_Specialist = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_facecrown_%STATE%.png");

		// Token: 0x04002259 RID: 8793
		public static BaseImage[] CardFilters_Parish = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_flag_%STATE%.png");

		// Token: 0x0400225A RID: 8794
		public static BaseImage[] CardFilters_Playable = BaseImage.createButton(AssetPaths.AssetIconsCardPanel, "card_type_buttons_chevron_%STATE%.png");

		// Token: 0x0400225B RID: 8795
		public static BaseImage LoginShieldPlaceholder = new BaseImage(AssetPaths.AssetIconsCardPanel, "profile_COA_placeholder.png");

		// Token: 0x0400225C RID: 8796
		public static BaseImage cardpanel_cashin_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "cash_in_normal.png");

		// Token: 0x0400225D RID: 8797
		public static BaseImage cardpanel_cashin_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "cash_in_over.png");

		// Token: 0x0400225E RID: 8798
		public static BaseImage cardpanel_cashin_in = new BaseImage(AssetPaths.AssetIconsCardPanel, "cash_in_in.png");

		// Token: 0x0400225F RID: 8799
		public static BaseImage cardpanel_manage_tabs_white_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "tabs_white_left.png");

		// Token: 0x04002260 RID: 8800
		public static BaseImage cardpanel_manage_tabs_white_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "tabs_white_right.png");

		// Token: 0x04002261 RID: 8801
		public static BaseImage cardpanel_manage_card_points_icon = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_point_icon.png");

		// Token: 0x04002262 RID: 8802
		public static BaseImage cardpanel_prem_timer_back_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_back_left.png");

		// Token: 0x04002263 RID: 8803
		public static BaseImage cardpanel_prem_timer_back_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_back_mid.png");

		// Token: 0x04002264 RID: 8804
		public static BaseImage cardpanel_prem_timer_back_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_back_right.png");

		// Token: 0x04002265 RID: 8805
		public static BaseImage cardpanel_prem_timer_fill_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_fill_left.png");

		// Token: 0x04002266 RID: 8806
		public static BaseImage cardpanel_prem_timer_fill_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_fill_mid.png");

		// Token: 0x04002267 RID: 8807
		public static BaseImage cardpanel_prem_timer_fill_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "timerbar_fill_right.png");

		// Token: 0x04002268 RID: 8808
		public static BaseImage cardpanel_premium_token = new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_144_134_normal.png");

		// Token: 0x04002269 RID: 8809
		public static BaseImage cardpanel_premium_token_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "premium_disk_144_134_over.png");

		// Token: 0x0400226A RID: 8810
		public static BaseImage cardpanel_pack_open_circle = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_pack_open_circle.png");

		// Token: 0x0400226B RID: 8811
		public static BaseImage card_screen_button_blank = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_screen_button_blank.png");

		// Token: 0x0400226C RID: 8812
		public static BaseImage card_screen_button_blank_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_screen_button_blank_over.png");

		// Token: 0x0400226D RID: 8813
		public static BaseImage sort_back = new BaseImage(AssetPaths.AssetIconsCardPanel, "sort_back.png");

		// Token: 0x0400226E RID: 8814
		public static BaseImage sort_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "sort_normal.png");

		// Token: 0x0400226F RID: 8815
		public static BaseImage sort_in = new BaseImage(AssetPaths.AssetIconsCardPanel, "sort_in.png");

		// Token: 0x04002270 RID: 8816
		public static BaseImage sort_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "sort_over.png");

		// Token: 0x04002271 RID: 8817
		public static BaseImage sort_selected = new BaseImage(AssetPaths.AssetIconsCardPanel, "sort_selected.png");

		// Token: 0x04002272 RID: 8818
		public static BaseImage cardpanel_symbol_apple = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_apple.png");

		// Token: 0x04002273 RID: 8819
		public static BaseImage cardpanel_symbol_crown = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_crown.png");

		// Token: 0x04002274 RID: 8820
		public static BaseImage cardpanel_symbol_hawk = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_hawk.png");

		// Token: 0x04002275 RID: 8821
		public static BaseImage cardpanel_symbol_jester = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_jester.png");

		// Token: 0x04002276 RID: 8822
		public static BaseImage cardpanel_symbol_shield = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_shield.png");

		// Token: 0x04002277 RID: 8823
		public static BaseImage cardpanel_symbol_tower = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_tower.png");

		// Token: 0x04002278 RID: 8824
		public static BaseImage cardpanel_symbol_wolf = new BaseImage(AssetPaths.AssetIconsCardPanel, "symbol_wolf.png");

		// Token: 0x04002279 RID: 8825
		public static BaseImage cardpanel_button_blue_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_blue_141wide_normal.png");

		// Token: 0x0400227A RID: 8826
		public static BaseImage cardpanel_button_blue_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_blue_141wide_over.png");

		// Token: 0x0400227B RID: 8827
		public static BaseImage cardpanel_button_blue_pressed = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_blue_141wide_pushed.png");

		// Token: 0x0400227C RID: 8828
		public static BaseImage cardpanel_button_close_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_close_normal.png");

		// Token: 0x0400227D RID: 8829
		public static BaseImage cardpanel_button_close_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_close_over.png");

		// Token: 0x0400227E RID: 8830
		public static BaseImage cardpanel_button_close_pressed = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_close_pressed.png");

		// Token: 0x0400227F RID: 8831
		public static BaseImage cardpanel_panel_back_bar_divider = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_bar_divider.png");

		// Token: 0x04002280 RID: 8832
		public static BaseImage cardpanel_panel_back_bottom_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_bottom_left.png");

		// Token: 0x04002281 RID: 8833
		public static BaseImage cardpanel_panel_back_bottom_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_bottom_mid.png");

		// Token: 0x04002282 RID: 8834
		public static BaseImage cardpanel_panel_back_bottom_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_bottom_right.png");

		// Token: 0x04002283 RID: 8835
		public static BaseImage cardpanel_panel_back_mid_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_mid_left.png");

		// Token: 0x04002284 RID: 8836
		public static BaseImage cardpanel_panel_back_mid_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_mid_mid.png");

		// Token: 0x04002285 RID: 8837
		public static BaseImage cardpanel_panel_back_mid_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_mid_right.png");

		// Token: 0x04002286 RID: 8838
		public static BaseImage cardpanel_panel_back_top_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_top_left.png");

		// Token: 0x04002287 RID: 8839
		public static BaseImage cardpanel_panel_back_top_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_top_mid.png");

		// Token: 0x04002288 RID: 8840
		public static BaseImage cardpanel_panel_back_top_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_back_top_right.png");

		// Token: 0x04002289 RID: 8841
		public static BaseImage cardpanel_panel_black_bottom_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_bottom_left.png");

		// Token: 0x0400228A RID: 8842
		public static BaseImage cardpanel_panel_black_bottom_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_bottom_mid.png");

		// Token: 0x0400228B RID: 8843
		public static BaseImage cardpanel_panel_black_bottom_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_bottom_right.png");

		// Token: 0x0400228C RID: 8844
		public static BaseImage cardpanel_panel_black_mid_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_left.png");

		// Token: 0x0400228D RID: 8845
		public static BaseImage cardpanel_panel_black_mid_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_mid.png");

		// Token: 0x0400228E RID: 8846
		public static BaseImage cardpanel_panel_black_mid_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_right.png");

		// Token: 0x0400228F RID: 8847
		public static BaseImage cardpanel_panel_black_top_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_left.png");

		// Token: 0x04002290 RID: 8848
		public static BaseImage cardpanel_panel_black_top_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_mid.png");

		// Token: 0x04002291 RID: 8849
		public static BaseImage cardpanel_panel_black_top_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_right.png");

		// Token: 0x04002292 RID: 8850
		public static BaseImage cardpanel_panel_grey_bottom_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_bottom_mid.png");

		// Token: 0x04002293 RID: 8851
		public static BaseImage cardpanel_panel_grey_bottom_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_bottom_right.png");

		// Token: 0x04002294 RID: 8852
		public static BaseImage cardpanel_panel_grey_mid_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_left.png");

		// Token: 0x04002295 RID: 8853
		public static BaseImage cardpanel_panel_grey_mid_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_mid.png");

		// Token: 0x04002296 RID: 8854
		public static BaseImage cardpanel_panel_grey_mid_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_mid_right.png");

		// Token: 0x04002297 RID: 8855
		public static BaseImage cardpanel_panel_grey_top_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_left.png");

		// Token: 0x04002298 RID: 8856
		public static BaseImage cardpanel_panel_grey_top_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_mid.png");

		// Token: 0x04002299 RID: 8857
		public static BaseImage cardpanel_panel_grey_top_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_black_top_right.png");

		// Token: 0x0400229A RID: 8858
		public static BaseImage cardpanel_grey_9slice_right_middle = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_right_middle.png");

		// Token: 0x0400229B RID: 8859
		public static BaseImage cardpanel_grey_9slice_right_bottom = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_right_bottom.png");

		// Token: 0x0400229C RID: 8860
		public static BaseImage cardpanel_grey_9slice_middle_top = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_middle_top.png");

		// Token: 0x0400229D RID: 8861
		public static BaseImage cardpanel_grey_9slice_middle_middle = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_middle_middle.png");

		// Token: 0x0400229E RID: 8862
		public static BaseImage cardpanel_grey_9slice_middle_bottom = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_middle_bottom.png");

		// Token: 0x0400229F RID: 8863
		public static BaseImage cardpanel_grey_9slice_left_top = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_left_top.png");

		// Token: 0x040022A0 RID: 8864
		public static BaseImage cardpanel_grey_9slice_left_middle = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_left_middle.png");

		// Token: 0x040022A1 RID: 8865
		public static BaseImage cardpanel_grey_9slice_left_bottom = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_left_bottom.png");

		// Token: 0x040022A2 RID: 8866
		public static BaseImage cardpanel_grey_9slice_right_top = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_right_top.png");

		// Token: 0x040022A3 RID: 8867
		public static BaseImage cardpanel_grey_9slice_gradation_bottom = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_gradation_bottom right.png");

		// Token: 0x040022A4 RID: 8868
		public static BaseImage cardpanel_grey_9slice_gradation_top_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "grey_9slice_gradation_top_left.png");

		// Token: 0x040022A5 RID: 8869
		public static BaseImage button_cards_all_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_cards_all_normal.png");

		// Token: 0x040022A6 RID: 8870
		public static BaseImage button_cards_all_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_cards_all_over.png");

		// Token: 0x040022A7 RID: 8871
		public static BaseImage button_cards_in_play_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_cards_in_play_normal.png");

		// Token: 0x040022A8 RID: 8872
		public static BaseImage button_cards_in_play_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "button_cards_in_play_over.png");

		// Token: 0x040022A9 RID: 8873
		public static BaseImage cardpanel_panel_gradient_bottom_right = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_gradient_bottom_right.png");

		// Token: 0x040022AA RID: 8874
		public static BaseImage cardpanel_panel_gradient_top_left = new BaseImage(AssetPaths.AssetIconsCardPanel, "panel_gradient_top_left.png");

		// Token: 0x040022AB RID: 8875
		public static BaseImage cardpanel_payment_button_crowns_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "payment_button_crowns_normal.png");

		// Token: 0x040022AC RID: 8876
		public static BaseImage cardpanel_payment_button_crowns_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "payment_button_crowns_over.png");

		// Token: 0x040022AD RID: 8877
		public static BaseImage cardpanel_payment_button_greywhite_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "payment_button_grey-white_normal");

		// Token: 0x040022AE RID: 8878
		public static BaseImage cardpanel_payment_button_greywhite_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "payment_button_grey-white_over");

		// Token: 0x040022AF RID: 8879
		public static BaseImage cardpanel_RH_button_back_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-back_normal");

		// Token: 0x040022B0 RID: 8880
		public static BaseImage cardpanel_RH_button_back_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-back_over");

		// Token: 0x040022B1 RID: 8881
		public static BaseImage cardpanel_scroll_thumb_botom = new BaseImage(AssetPaths.AssetIconsCardPanel, "scroll_thumb_botom.png");

		// Token: 0x040022B2 RID: 8882
		public static BaseImage cardpanel_scroll_thumb_mid = new BaseImage(AssetPaths.AssetIconsCardPanel, "scroll_thumb_mid.png");

		// Token: 0x040022B3 RID: 8883
		public static BaseImage cardpanel_scroll_thumb_top = new BaseImage(AssetPaths.AssetIconsCardPanel, "scroll_thumb_top.png");

		// Token: 0x040022B4 RID: 8884
		public static BaseImage SuperFan = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_fan_super_random.png");

		// Token: 0x040022B5 RID: 8885
		public static BaseImage UltimateFan = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_fan_ultimate_random.png");

		// Token: 0x040022B6 RID: 8886
		public static BaseImage card_type_buttons_recent_in = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_type_buttons_recent_in.png");

		// Token: 0x040022B7 RID: 8887
		public static BaseImage card_type_buttons_recent_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_type_buttons_recent_normal.png");

		// Token: 0x040022B8 RID: 8888
		public static BaseImage card_type_buttons_recent_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "card_type_buttons_recent_over.png");

		// Token: 0x040022B9 RID: 8889
		public static BaseImage cardpanel_RH_button_v2_buycrowns_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_buycrowns_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BA RID: 8890
		public static BaseImage cardpanel_RH_button_v2_buycrowns_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_buycrowns_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BB RID: 8891
		public static BaseImage cardpanel_RH_button_v2_choose_cards_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_choose_cards_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BC RID: 8892
		public static BaseImage cardpanel_RH_button_v2_choose_cards_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_choose_cards_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BD RID: 8893
		public static BaseImage cardpanel_RH_button_v2_getcards_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_getcards_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BE RID: 8894
		public static BaseImage cardpanel_RH_button_v2_getcards_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_getcards_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022BF RID: 8895
		public static BaseImage cardpanel_RH_button_v2_getpremium_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_getpremium_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C0 RID: 8896
		public static BaseImage cardpanel_RH_button_v2_getpremium_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_button-v2_getpremium_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C1 RID: 8897
		public static BaseImage cardpanel_RH_button_v2_friend_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_buttonX5_invite_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C2 RID: 8898
		public static BaseImage cardpanel_RH_button_v2_friend_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_buttonX5_invite_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C3 RID: 8899
		public static BaseImage cardpanel_RH_button_v2_offers_normal = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_buttonX5_offers_normal_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C4 RID: 8900
		public static BaseImage cardpanel_RH_button_v2_offers_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "RH_buttonX5_offers_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C5 RID: 8901
		public static BaseImage premiumAdvert30 = new BaseImage(AssetPaths.AssetIconsCardPanel, "ad_30premfor100crown_halfsize_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C6 RID: 8902
		public static BaseImage premiumAdvert7 = new BaseImage(AssetPaths.AssetIconsCardPanel, "ad_1premfor30crown_half_size_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C7 RID: 8903
		public static BaseImage premiumAdvert30_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "ad_30premfor100crown_halfsize_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C8 RID: 8904
		public static BaseImage premiumAdvert7_over = new BaseImage(AssetPaths.AssetIconsCardPanel, "ad_1premfor30crown_half_size_over_%LANG%.png", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022C9 RID: 8905
		public static BaseImage cardpanel_premium_ad = new BaseImage(AssetPaths.AssetIconsCardPanel, "ad_1premfor30crown_%LANG%.jpg", BaseImage.loadType.LOCALIZED);

		// Token: 0x040022CA RID: 8906
		public static BaseImage[] cardTypeButtons = BaseImage.createFromUV(AssetPaths.AssetIconsCardPanel, "card_type_buttons_array", 114);

		// Token: 0x040022CB RID: 8907
		public static BaseImage[] premiumIcons = BaseImage.createFromUV(AssetPaths.AssetIconsCardPanel, "premium_icons", 9);

		// Token: 0x040022CC RID: 8908
		public static BaseImage offer_bundle_1_normal = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_1_normal.png");

		// Token: 0x040022CD RID: 8909
		public static BaseImage offer_bundle_1_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_1_over.png");

		// Token: 0x040022CE RID: 8910
		public static BaseImage offer_bundle_2_normal = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_2_normal.png");

		// Token: 0x040022CF RID: 8911
		public static BaseImage offer_bundle_2_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_2_over.png");

		// Token: 0x040022D0 RID: 8912
		public static BaseImage offer_bundle_3_normal = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_3_normal.png");

		// Token: 0x040022D1 RID: 8913
		public static BaseImage offer_bundle_3_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_bundle_3_over.png");

		// Token: 0x040022D2 RID: 8914
		public static BaseImage offer_special_normal = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_special_normal.png");

		// Token: 0x040022D3 RID: 8915
		public static BaseImage offer_special_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_special_over.png");

		// Token: 0x040022D4 RID: 8916
		public static BaseImage offer_sale_normal = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_sale_normal.png");

		// Token: 0x040022D5 RID: 8917
		public static BaseImage offer_sale_over = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_sale_over.png");

		// Token: 0x040022D6 RID: 8918
		public static BaseImage offer_gold = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_gold.png");

		// Token: 0x040022D7 RID: 8919
		public static BaseImage offer_honour = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_honour.png");

		// Token: 0x040022D8 RID: 8920
		public static BaseImage offer_faith = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_faith.png");

		// Token: 0x040022D9 RID: 8921
		public static BaseImage offer_shield = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_shield.png");

		// Token: 0x040022DA RID: 8922
		public static BaseImage offer_wheel_spin = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin.png");

		// Token: 0x040022DB RID: 8923
		public static BaseImage offer_wheel_spin1 = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin-1.png");

		// Token: 0x040022DC RID: 8924
		public static BaseImage offer_wheel_spin2 = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin-2.png");

		// Token: 0x040022DD RID: 8925
		public static BaseImage offer_wheel_spin3 = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin-3.png");

		// Token: 0x040022DE RID: 8926
		public static BaseImage offer_wheel_spin4 = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin-4.png");

		// Token: 0x040022DF RID: 8927
		public static BaseImage offer_wheel_spin5 = new BaseImage(AssetPaths.AssetIconsCardOffers, "offer_wheel-spin-5.png");

		// Token: 0x040022E0 RID: 8928
		public static BaseImage avatar_arms01 = new BaseImage(AssetPaths.AssetIconsAvatar, "arms01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E1 RID: 8929
		public static BaseImage avatar_arms02 = new BaseImage(AssetPaths.AssetIconsAvatar, "arms02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E2 RID: 8930
		public static BaseImage avatar_arms03 = new BaseImage(AssetPaths.AssetIconsAvatar, "arms03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E3 RID: 8931
		public static BaseImage avatar_arms04 = new BaseImage(AssetPaths.AssetIconsAvatar, "arms04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E4 RID: 8932
		public static BaseImage avatar_face01_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face01_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E5 RID: 8933
		public static BaseImage avatar_face02_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face02_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E6 RID: 8934
		public static BaseImage avatar_face03_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face03_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E7 RID: 8935
		public static BaseImage avatar_face04_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face04_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E8 RID: 8936
		public static BaseImage avatar_face06_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face06_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022E9 RID: 8937
		public static BaseImage avatar_face07_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face07_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022EA RID: 8938
		public static BaseImage avatar_face05_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face05_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022EB RID: 8939
		public static BaseImage avatar_face06_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face06_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022EC RID: 8940
		public static BaseImage avatar_face08_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face---man-1.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022ED RID: 8941
		public static BaseImage avatar_face08_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face---woman-1.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022EE RID: 8942
		public static BaseImage avatar_face09_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face---man-2.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022EF RID: 8943
		public static BaseImage avatar_face09_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face---woman-2.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F0 RID: 8944
		public static BaseImage avatar_face10_male = new BaseImage(AssetPaths.AssetIconsAvatar, "face---man-3.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F1 RID: 8945
		public static BaseImage avatar_face10_female = new BaseImage(AssetPaths.AssetIconsAvatar, "face---woman-3.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F2 RID: 8946
		public static BaseImage avatar_feet01 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F3 RID: 8947
		public static BaseImage avatar_feet02 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F4 RID: 8948
		public static BaseImage avatar_feet03 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F5 RID: 8949
		public static BaseImage avatar_feet04 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F6 RID: 8950
		public static BaseImage avatar_feet05 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet---bare-hairy-feet.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F7 RID: 8951
		public static BaseImage avatar_feet06 = new BaseImage(AssetPaths.AssetIconsAvatar, "feet---high-leather-boots.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F8 RID: 8952
		public static BaseImage avatar_floor01 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022F9 RID: 8953
		public static BaseImage avatar_floor02 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FA RID: 8954
		public static BaseImage avatar_floor03 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FB RID: 8955
		public static BaseImage avatar_floor04 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FC RID: 8956
		public static BaseImage avatar_floor05 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor05.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FD RID: 8957
		public static BaseImage avatar_floor06 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor---fire.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FE RID: 8958
		public static BaseImage avatar_floor07 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor---puddle.png", BaseImage.loadType.SHRUNK);

		// Token: 0x040022FF RID: 8959
		public static BaseImage avatar_floor08 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor---snow.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002300 RID: 8960
		public static BaseImage avatar_floor09 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor---spikes.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002301 RID: 8961
		public static BaseImage avatar_floor10 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor--tiled.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002302 RID: 8962
		public static BaseImage avatar_floor11 = new BaseImage(AssetPaths.AssetIconsAvatar, "floor---wooden-boards.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002303 RID: 8963
		public static BaseImage avatar_hair01_helmhide = new BaseImage(AssetPaths.AssetIconsAvatar, "hair01_helmhide.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002304 RID: 8964
		public static BaseImage avatar_hair02 = new BaseImage(AssetPaths.AssetIconsAvatar, "hair02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002305 RID: 8965
		public static BaseImage avatar_hair03 = new BaseImage(AssetPaths.AssetIconsAvatar, "hair03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002306 RID: 8966
		public static BaseImage avatar_hair04 = new BaseImage(AssetPaths.AssetIconsAvatar, "hair04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002307 RID: 8967
		public static BaseImage avatar_hair05 = new BaseImage(AssetPaths.AssetIconsAvatar, "hair---female-frizzy.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002308 RID: 8968
		public static BaseImage avatar_hair06 = new BaseImage(AssetPaths.AssetIconsAvatar, "hair---male-balding.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002309 RID: 8969
		public static BaseImage avatar_hands01 = new BaseImage(AssetPaths.AssetIconsAvatar, "hands01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230A RID: 8970
		public static BaseImage avatar_hands02 = new BaseImage(AssetPaths.AssetIconsAvatar, "hands02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230B RID: 8971
		public static BaseImage avatar_hands03 = new BaseImage(AssetPaths.AssetIconsAvatar, "hands03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230C RID: 8972
		public static BaseImage avatar_hands04 = new BaseImage(AssetPaths.AssetIconsAvatar, "hands04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230D RID: 8973
		public static BaseImage avatar_head01_hairoff = new BaseImage(AssetPaths.AssetIconsAvatar, "head01_hairoff.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230E RID: 8974
		public static BaseImage avatar_head02_hairoff = new BaseImage(AssetPaths.AssetIconsAvatar, "head02_hairoff.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400230F RID: 8975
		public static BaseImage avatar_head03 = new BaseImage(AssetPaths.AssetIconsAvatar, "head03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002310 RID: 8976
		public static BaseImage avatar_head04 = new BaseImage(AssetPaths.AssetIconsAvatar, "head04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002311 RID: 8977
		public static BaseImage avatar_head05 = new BaseImage(AssetPaths.AssetIconsAvatar, "hat---skull.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002312 RID: 8978
		public static BaseImage avatar_head06 = new BaseImage(AssetPaths.AssetIconsAvatar, "hat---viking-hollywood.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002313 RID: 8979
		public static BaseImage avatar_head07 = new BaseImage(AssetPaths.AssetIconsAvatar, "head---helmet-basic.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002314 RID: 8980
		public static BaseImage avatar_head08 = new BaseImage(AssetPaths.AssetIconsAvatar, "head---helmet-russian.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002315 RID: 8981
		public static BaseImage avatar_head09 = new BaseImage(AssetPaths.AssetIconsAvatar, "helmet---arabic.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002316 RID: 8982
		public static BaseImage avatar_head10 = new BaseImage(AssetPaths.AssetIconsAvatar, "hat---jester.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002317 RID: 8983
		public static BaseImage avatar_head11 = new BaseImage(AssetPaths.AssetIconsAvatar, "hat---rabbit-ears.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002318 RID: 8984
		public static BaseImage avatar_head12 = new BaseImage(AssetPaths.AssetIconsAvatar, "hat---santa.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002319 RID: 8985
		public static BaseImage avatar_legs01_female = new BaseImage(AssetPaths.AssetIconsAvatar, "legs01_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231A RID: 8986
		public static BaseImage avatar_legs01_male = new BaseImage(AssetPaths.AssetIconsAvatar, "legs01_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231B RID: 8987
		public static BaseImage avatar_legs02 = new BaseImage(AssetPaths.AssetIconsAvatar, "legs02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231C RID: 8988
		public static BaseImage avatar_legs03 = new BaseImage(AssetPaths.AssetIconsAvatar, "legs03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231D RID: 8989
		public static BaseImage avatar_legs04 = new BaseImage(AssetPaths.AssetIconsAvatar, "legs04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231E RID: 8990
		public static BaseImage avatar_legs05 = new BaseImage(AssetPaths.AssetIconsAvatar, "legs05_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400231F RID: 8991
		public static BaseImage avatar_legs06 = new BaseImage(AssetPaths.AssetIconsAvatar, "legs---chain-mail-skirt.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002320 RID: 8992
		public static BaseImage avatar_legs07 = new BaseImage(AssetPaths.AssetIconsAvatar, "Legs---fine-silk-skirt.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002321 RID: 8993
		public static BaseImage avatar_shoulders01 = new BaseImage(AssetPaths.AssetIconsAvatar, "shoulders01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002322 RID: 8994
		public static BaseImage avatar_shoulders02 = new BaseImage(AssetPaths.AssetIconsAvatar, "shoulders02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002323 RID: 8995
		public static BaseImage avatar_shoulders03 = new BaseImage(AssetPaths.AssetIconsAvatar, "shoulders03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002324 RID: 8996
		public static BaseImage avatar_shoulders04_back = new BaseImage(AssetPaths.AssetIconsAvatar, "shoulders04_back.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002325 RID: 8997
		public static BaseImage avatar_shoulders04_front = new BaseImage(AssetPaths.AssetIconsAvatar, "shoulders04_front.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002326 RID: 8998
		public static BaseImage avatar_tabard01 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002327 RID: 8999
		public static BaseImage avatar_tabard02 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002328 RID: 9000
		public static BaseImage avatar_tabard03 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002329 RID: 9001
		public static BaseImage avatar_tabard04 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232A RID: 9002
		public static BaseImage avatar_tabard05 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard---arabic-swordsman.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232B RID: 9003
		public static BaseImage avatar_tabard06 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard---quilted-armour.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232C RID: 9004
		public static BaseImage avatar_tabard07 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard---ripped.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232D RID: 9005
		public static BaseImage avatar_tabard08 = new BaseImage(AssetPaths.AssetIconsAvatar, "tabard---studded.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232E RID: 9006
		public static BaseImage avatar_torso01_female_default = new BaseImage(AssetPaths.AssetIconsAvatar, "torso01_female_default.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400232F RID: 9007
		public static BaseImage avatar_torso01_male_default = new BaseImage(AssetPaths.AssetIconsAvatar, "torso01_male_default.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002330 RID: 9008
		public static BaseImage avatar_torso02_female = new BaseImage(AssetPaths.AssetIconsAvatar, "torso02_female.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002331 RID: 9009
		public static BaseImage avatar_torso02_male = new BaseImage(AssetPaths.AssetIconsAvatar, "torso02_male.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002332 RID: 9010
		public static BaseImage avatar_torso03 = new BaseImage(AssetPaths.AssetIconsAvatar, "torso03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002333 RID: 9011
		public static BaseImage avatar_torso04 = new BaseImage(AssetPaths.AssetIconsAvatar, "torso04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002334 RID: 9012
		public static BaseImage avatar_weapon_belt = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon_belt.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002335 RID: 9013
		public static BaseImage avatar_weapon01 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon01.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002336 RID: 9014
		public static BaseImage avatar_weapon02 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon02.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002337 RID: 9015
		public static BaseImage avatar_weapon03 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon03.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002338 RID: 9016
		public static BaseImage avatar_weapon04 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon04.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002339 RID: 9017
		public static BaseImage avatar_weapon05 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon---flail.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233A RID: 9018
		public static BaseImage avatar_weapon06 = new BaseImage(AssetPaths.AssetIconsAvatar, "weapon---scimitar.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233B RID: 9019
		public static BaseImage avatar_body01_default = new BaseImage(AssetPaths.AssetIconsAvatar, "body01_default.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233C RID: 9020
		public static BaseImage avatar_rat_face = new BaseImage(AssetPaths.AssetIconsAvatar, "rat1_face.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233D RID: 9021
		public static BaseImage avatar_rat_helm = new BaseImage(AssetPaths.AssetIconsAvatar, "rat_helm.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233E RID: 9022
		public static BaseImage avatar_snake_face = new BaseImage(AssetPaths.AssetIconsAvatar, "snake_face.png", BaseImage.loadType.SHRUNK);

		// Token: 0x0400233F RID: 9023
		public static BaseImage avatar_pig_face = new BaseImage(AssetPaths.AssetIconsAvatar, "pig_face.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002340 RID: 9024
		public static BaseImage avatar_wolf_face = new BaseImage(AssetPaths.AssetIconsAvatar, "wolf_face.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002341 RID: 9025
		public static BaseImage avatar_wolf_helm = new BaseImage(AssetPaths.AssetIconsAvatar, "wolf_helm.png", BaseImage.loadType.SHRUNK);

		// Token: 0x04002342 RID: 9026
		public static BaseImage avatar_randomise = new BaseImage(AssetPaths.AssetIconsAvatar, "randomise_wood2.png");

		// Token: 0x04002343 RID: 9027
		public static BaseImage avatar_parchment_base_layer = new BaseImage(AssetPaths.AssetIconsAvatar, "parchment_base_layer.png");

		// Token: 0x04002344 RID: 9028
		public static BaseImage avatar_parchment_top_multiply = new BaseImage(AssetPaths.AssetIconsAvatar, "parchment_top_multiply.png");

		// Token: 0x04002345 RID: 9029
		private int worldMapIconsTexID = -1;

		// Token: 0x04002346 RID: 9030
		private int effectLayerTexID = -1;

		// Token: 0x04002347 RID: 9031
		private int mapElementsTexID = -1;

		// Token: 0x04002348 RID: 9032
		private int worldMapTilesTexID = -1;

		// Token: 0x04002349 RID: 9033
		private int goods1TexID = -1;

		// Token: 0x0400234A RID: 9034
		private int townBuildindsTexID = -1;

		// Token: 0x0400234B RID: 9035
		private int goods2TexID = -1;

		// Token: 0x0400234C RID: 9036
		private int body_stonemasonTexID = -1;

		// Token: 0x0400234D RID: 9037
		private int stonemasonAnimTexID = -1;

		// Token: 0x0400234E RID: 9038
		private int body_troubadourTexID = -1;

		// Token: 0x0400234F RID: 9039
		private int body_theaterworkerTexID = -1;

		// Token: 0x04002350 RID: 9040
		private int villageOverlaysAnimTexID = -1;

		// Token: 0x04002351 RID: 9041
		private int woodcutterAnimTexID = -1;

		// Token: 0x04002352 RID: 9042
		private int farmerAnimTexID = -1;

		// Token: 0x04002353 RID: 9043
		private int farmer2AnimTexID = -1;

		// Token: 0x04002354 RID: 9044
		private int farmer3AnimTexID = -1;

		// Token: 0x04002355 RID: 9045
		private int bakerAnimTexID = -1;

		// Token: 0x04002356 RID: 9046
		private int metalWorkerAnimTexID = -1;

		// Token: 0x04002357 RID: 9047
		private int fletcherAnimTexID = -1;

		// Token: 0x04002358 RID: 9048
		private int pitchworkerAnimTexID = -1;

		// Token: 0x04002359 RID: 9049
		private int poleturnerAnimTexID = -1;

		// Token: 0x0400235A RID: 9050
		private int cowAnimTexID = -1;

		// Token: 0x0400235B RID: 9051
		private int blacksmithAnimTexID = -1;

		// Token: 0x0400235C RID: 9052
		private int armourerAnimTexID = -1;

		// Token: 0x0400235D RID: 9053
		private int sheepAnimTexID = -1;

		// Token: 0x0400235E RID: 9054
		private int chickenBrownAnimTexID = -1;

		// Token: 0x0400235F RID: 9055
		private int chickenWhiteAnimTexID = -1;

		// Token: 0x04002360 RID: 9056
		private int pigAnimTexID = -1;

		// Token: 0x04002361 RID: 9057
		private int traderAnimTexID = -1;

		// Token: 0x04002362 RID: 9058
		private int bld_17x17_1TexID = -1;

		// Token: 0x04002363 RID: 9059
		private int bld_7x7_1TexID = -1;

		// Token: 0x04002364 RID: 9060
		private int bld_9x9_1TexID = -1;

		// Token: 0x04002365 RID: 9061
		private int bld_11x11_1TexID = -1;

		// Token: 0x04002366 RID: 9062
		private int bld_13x13_1TexID = -1;

		// Token: 0x04002367 RID: 9063
		private int bld_13x13_2TexID = -1;

		// Token: 0x04002368 RID: 9064
		private int bld_4x4_1TexID = -1;

		// Token: 0x04002369 RID: 9065
		private int bld_5x5_1TexID = -1;

		// Token: 0x0400236A RID: 9066
		private int body_carpenterTexID = -1;

		// Token: 0x0400236B RID: 9067
		private int dockworkerAnimTexID = -1;

		// Token: 0x0400236C RID: 9068
		private int ironMinerAnimTexID = -1;

		// Token: 0x0400236D RID: 9069
		private int body_iron_mine_workTexID = -1;

		// Token: 0x0400236E RID: 9070
		private int body_hunterTexID = -1;

		// Token: 0x0400236F RID: 9071
		private int body_brewerTexID = -1;

		// Token: 0x04002370 RID: 9072
		private int body_tailorTexID = -1;

		// Token: 0x04002371 RID: 9073
		private int body_siegeworkerTexID = -1;

		// Token: 0x04002372 RID: 9074
		private int body_pitchworkerTexID = -1;

		// Token: 0x04002373 RID: 9075
		private int traderHorseAnimTexID = -1;

		// Token: 0x04002374 RID: 9076
		private int bld_8x8_1TexID = -1;

		// Token: 0x04002375 RID: 9077
		private int woodcutter_animsTexID = -1;

		// Token: 0x04002376 RID: 9078
		private int bld_6x6_1TexID = -1;

		// Token: 0x04002377 RID: 9079
		private int body_farmer_3TexID = -1;

		// Token: 0x04002378 RID: 9080
		private int body_metalworkerTexID = -1;

		// Token: 0x04002379 RID: 9081
		private int body_bakerTexID = -1;

		// Token: 0x0400237A RID: 9082
		private int body_poleturnerTexID = -1;

		// Token: 0x0400237B RID: 9083
		private int body_fletcherTexID = -1;

		// Token: 0x0400237C RID: 9084
		private int body_blacksmithTexID = -1;

		// Token: 0x0400237D RID: 9085
		private int body_armourerTexID = -1;

		// Token: 0x0400237E RID: 9086
		private int bld_Various_01TexID = -1;

		// Token: 0x0400237F RID: 9087
		private int body_jesterTexID = -1;

		// Token: 0x04002380 RID: 9088
		private int anim_dancing_bearTexID = -1;

		// Token: 0x04002381 RID: 9089
		private int anim_maypoleTexID = -1;

		// Token: 0x04002382 RID: 9090
		private int anim_rackTexID = -1;

		// Token: 0x04002383 RID: 9091
		private int anim_stakeTexID = -1;

		// Token: 0x04002384 RID: 9092
		private int anim_gibbetTexID = -1;

		// Token: 0x04002385 RID: 9093
		private int anim_stocksTexID = -1;

		// Token: 0x04002386 RID: 9094
		private int archerAnimTexID = -1;

		// Token: 0x04002387 RID: 9095
		private int archerRedAnimTexID = -1;

		// Token: 0x04002388 RID: 9096
		private int archerGreenAnimTexID = -1;

		// Token: 0x04002389 RID: 9097
		private int peasantAnimTexID = -1;

		// Token: 0x0400238A RID: 9098
		private int peasantRedAnimTexID = -1;

		// Token: 0x0400238B RID: 9099
		private int peasantGreenAnimTexID = -1;

		// Token: 0x0400238C RID: 9100
		private int pikemanAnimTexID = -1;

		// Token: 0x0400238D RID: 9101
		private int pikemanRedAnimTexID = -1;

		// Token: 0x0400238E RID: 9102
		private int pikemanGreenAnimTexID = -1;

		// Token: 0x0400238F RID: 9103
		private int swordsmanAnimTexID = -1;

		// Token: 0x04002390 RID: 9104
		private int swordsmanRedAnimTexID = -1;

		// Token: 0x04002391 RID: 9105
		private int swordsmanGreenAnimTexID = -1;

		// Token: 0x04002392 RID: 9106
		private int knightAnimTexID = -1;

		// Token: 0x04002393 RID: 9107
		private int knightTopAnimTexID = -1;

		// Token: 0x04002394 RID: 9108
		private int archerCarryAnimTexID = -1;

		// Token: 0x04002395 RID: 9109
		private int peasantCarryAnimTexID = -1;

		// Token: 0x04002396 RID: 9110
		private int pikemanCarryAnimTexID = -1;

		// Token: 0x04002397 RID: 9111
		private int swordsmanCarryAnimTexID = -1;

		// Token: 0x04002398 RID: 9112
		private int captainAnimTexID = -1;

		// Token: 0x04002399 RID: 9113
		private int captainAnimRedTexID = -1;

		// Token: 0x0400239A RID: 9114
		private int catapultAnimTexID = -1;

		// Token: 0x0400239B RID: 9115
		private int manOnFireTexID = -1;

		// Token: 0x0400239C RID: 9116
		private int peasant2AnimTexID = -1;

		// Token: 0x0400239D RID: 9117
		private int peasant2RedAnimTexID = -1;

		// Token: 0x0400239E RID: 9118
		private int peasant2GreenAnimTexID = -1;

		// Token: 0x0400239F RID: 9119
		private int wolfAnimTexID = -1;

		// Token: 0x040023A0 RID: 9120
		private int archer2AnimTexID = -1;

		// Token: 0x040023A1 RID: 9121
		private int archer2RedAnimTexID = -1;

		// Token: 0x040023A2 RID: 9122
		private int archer2GreenAnimTexID = -1;

		// Token: 0x040023A3 RID: 9123
		private int missileTexID = -1;

		// Token: 0x040023A4 RID: 9124
		private int missile2TexID = -1;

		// Token: 0x040023A5 RID: 9125
		private int animKillingPitsTexID = -1;

		// Token: 0x040023A6 RID: 9126
		private int fireTexID = -1;

		// Token: 0x040023A7 RID: 9127
		private int smoke1TexID = -1;

		// Token: 0x040023A8 RID: 9128
		private int oilPotAnimTexID = -1;

		// Token: 0x040023A9 RID: 9129
		private int hpsBarsTexID = -1;

		// Token: 0x040023AA RID: 9130
		private int castleBackgroundTexID = -1;

		// Token: 0x040023AB RID: 9131
		private int castleSpritesTexID = -1;

		// Token: 0x040023AC RID: 9132
		private int ballistaTexID = -1;

		// Token: 0x040023AD RID: 9133
		private int armyAnimsTexID = -1;

		// Token: 0x040023AE RID: 9134
		private int tutorialIconNormalID = -1;

		// Token: 0x040023AF RID: 9135
		private int tutorialIconOverID = -1;

		// Token: 0x040023B0 RID: 9136
		private int freeCardIconsID = -1;

		// Token: 0x040023B1 RID: 9137
		public bool worldMapLoaded;

		// Token: 0x040023B2 RID: 9138
		public static Image parishwall_button_vote_disabled = null;

		// Token: 0x040023B3 RID: 9139
		public static Image parishwall_button_vote_unchecked_normal = null;

		// Token: 0x040023B4 RID: 9140
		public static Image parishwall_button_vote_unchecked_over = null;

		// Token: 0x040023B5 RID: 9141
		public static Image tutorial_character_mockup = null;

		// Token: 0x040023B6 RID: 9142
		public static BaseImage banner_ad_friend = null;

		// Token: 0x040023B7 RID: 9143
		public static BaseImage banner_ad_friend_quest = null;

		// Token: 0x040023B8 RID: 9144
		public static int invite_ad_colour = 0;

		// Token: 0x040023B9 RID: 9145
		public static Image dummy = null;

		// Token: 0x040023BA RID: 9146
		public static byte[] parchementOverlay = null;

		// Token: 0x040023BB RID: 9147
		public int ImageSurroundTexID2 = -1;

		// Token: 0x040023BC RID: 9148
		public int ImageSurroundTexID3 = -1;

		// Token: 0x040023BD RID: 9149
		public int ImageSurroundShadowTexID = -1;

		// Token: 0x040023BE RID: 9150
		public int WikiHelpIconNormal = -1;

		// Token: 0x040023BF RID: 9151
		public int WikiHelpIconOver = -1;

		// Token: 0x040023C0 RID: 9152
		private SparseArray cardImagesBig = new SparseArray();

		// Token: 0x040023C1 RID: 9153
		public Image NoImageCard;

		// Token: 0x040023C2 RID: 9154
		private ResourceLoader cachedBigCardsLoader;
	}
}
