using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020000D7 RID: 215
	public class Avatar
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x0007A864 File Offset: 0x00078A64
		public static Bitmap CreateAvatar(AvatarData avatar, Color backgroundColour)
		{
			Bitmap bitmap = new Bitmap(154, 500);
			return Avatar.CreateAvatar(avatar, bitmap, backgroundColour);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0007A88C File Offset: 0x00078A8C
		public static Bitmap CreateAvatar(AvatarData avatar, int height)
		{
			Bitmap bitmap = new Bitmap(154, 500);
			Avatar.CreateAvatar(avatar, bitmap, global::ARGBColors.LightGoldenrodYellow, true);
			Bitmap bitmap2 = new Bitmap(154 * height / 500, height);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), new Rectangle(0, 0, 154, 500), GraphicsUnit.Pixel);
			graphics.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0007A90C File Offset: 0x00078B0C
		public static Bitmap CreateAvatar(AvatarData avatar, int height, Color backgroundColour, bool drawParchment)
		{
			Bitmap bitmap = new Bitmap(154, 500);
			Avatar.CreateAvatar(avatar, bitmap, backgroundColour, drawParchment);
			Bitmap bitmap2 = new Bitmap(154 * height / 500, height);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), new Rectangle(0, 0, 154, 500), GraphicsUnit.Pixel);
			graphics.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0007A988 File Offset: 0x00078B88
		public static Bitmap CreateExportAvatar(AvatarData avatar, Color backgroundColour, bool drawParchment)
		{
			Bitmap bitmap = new Bitmap(154, 500);
			Avatar.CreateAvatar(avatar, bitmap, backgroundColour, drawParchment);
			Bitmap bitmap2 = new Bitmap(90, 256);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(3, -11, 83, 272), new Rectangle(0, 0, 154, 500), GraphicsUnit.Pixel);
			graphics.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0000B438 File Offset: 0x00009638
		public static Bitmap CreateAvatar(AvatarData avatarData, Bitmap bitmap)
		{
			return Avatar.CreateAvatar(avatarData, bitmap, Color.FromArgb(105, 119, 129), true);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0000B450 File Offset: 0x00009650
		public static Bitmap CreateAvatar(AvatarData avatarData, Bitmap bitmap, Color backgroundColour)
		{
			return Avatar.CreateAvatar(avatarData, bitmap, backgroundColour, true);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0007A9F8 File Offset: 0x00078BF8
		public static void CreateExportAvatar(WorldMap.CachedUserInfo userInfo, string path)
		{
			Bitmap bitmap = Avatar.CreateExportAvatar(userInfo.avatarData, global::ARGBColors.Transparent, false);
			bitmap.Save(path, ImageFormat.Png);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0007AA24 File Offset: 0x00078C24
		public static AvatarData getRatAvatar()
		{
			return new AvatarData
			{
				male = true,
				floor = 4,
				body = 0,
				legs = 2,
				feet = 2,
				torso = 3,
				tabard = -1,
				arms = 2,
				hands = 2,
				shoulder = 1,
				face = 7,
				hair = -1,
				head = 12,
				weapon = 0,
				bodyColour = -2307931,
				legsColour = -4275256,
				feetColour = -4275256,
				torsoColour = -4275256,
				tabardColour = -9217456,
				armsColour = -2633011,
				handsColour = -4275256,
				shouldersColour = -4275256,
				hairColour = -6588326,
				headColour = -2633011,
				weaponColour = -10866131
			};
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0007AB14 File Offset: 0x00078D14
		public static AvatarData getSnakeAvatar()
		{
			return new AvatarData
			{
				male = true,
				floor = 1,
				body = 0,
				legs = 0,
				feet = 1,
				torso = 1,
				tabard = -1,
				arms = 1,
				hands = -1,
				shoulder = -1,
				face = 8,
				hair = 0,
				head = 2,
				weapon = -1,
				bodyColour = -2307931,
				legsColour = -14803426,
				feetColour = -10526881,
				torsoColour = -14803426,
				tabardColour = -9217456,
				armsColour = -14803426,
				handsColour = -14803426,
				shouldersColour = -2633011,
				hairColour = -13816536,
				headColour = -9217456,
				weaponColour = -14803426
			};
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0007AC04 File Offset: 0x00078E04
		public static AvatarData getPigAvatar()
		{
			return new AvatarData
			{
				male = true,
				floor = 0,
				body = 0,
				legs = 1,
				feet = 3,
				torso = 0,
				tabard = 7,
				arms = 2,
				hands = 0,
				shoulder = 0,
				face = 9,
				hair = -1,
				head = -1,
				weapon = 2,
				bodyColour = -2307931,
				legsColour = -12828346,
				feetColour = -7896461,
				torsoColour = -6259366,
				tabardColour = -10526881,
				armsColour = -6259366,
				handsColour = -2633011,
				shouldersColour = -3619906,
				hairColour = -10526881,
				headColour = -2633011,
				weaponColour = -10529476
			};
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0007ACF4 File Offset: 0x00078EF4
		public static AvatarData getWolfAvatar()
		{
			return new AvatarData
			{
				male = true,
				floor = 5,
				body = 0,
				legs = 2,
				feet = 3,
				torso = 3,
				tabard = -1,
				arms = 2,
				hands = 2,
				shoulder = 3,
				face = 10,
				hair = -1,
				head = 13,
				weapon = 3,
				bodyColour = -2307931,
				legsColour = -7896461,
				feetColour = -12172996,
				torsoColour = -7896461,
				tabardColour = -6259366,
				armsColour = -9217456,
				handsColour = -12172996,
				shouldersColour = -10529476,
				hairColour = -3618626,
				headColour = -7896461,
				weaponColour = -10866131
			};
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0007ADE8 File Offset: 0x00078FE8
		public static Bitmap CreateAvatar(AvatarData avatarData, Bitmap bitmap, Color backgroundColour, bool drawParchment)
		{
			if (GFXLibrary.avatar_parchment_base_layer != null)
			{
				Graphics graphics = Graphics.FromImage(bitmap);
				Rectangle rectangle = new Rectangle(0, 0, 154, 500);
				SolidBrush solidBrush = new SolidBrush(backgroundColour);
				graphics.FillRectangle(solidBrush, rectangle);
				solidBrush.Dispose();
				if (drawParchment)
				{
					graphics.DrawImage(GFXLibrary.avatar_parchment_base_layer, rectangle, rectangle, GraphicsUnit.Pixel);
				}
				Color color = global::ARGBColors.White;
				color = avatarData.ShouldersColour;
				ShrunkImage shrunkImage = Avatar.getRear(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = global::ARGBColors.White;
				shrunkImage = Avatar.getFloor(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.BodyColour;
				shrunkImage = Avatar.getBody(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				if (avatarData.legs != 4 && avatarData.legs != 5 && avatarData.legs != 6 && avatarData.feet != 4)
				{
					color = avatarData.LegsColour;
					shrunkImage = Avatar.getLegs(avatarData);
					if (shrunkImage != null)
					{
						graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
					}
					color = avatarData.FeetColour;
					shrunkImage = Avatar.getFeet(avatarData);
					if (shrunkImage != null)
					{
						graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
					}
				}
				else
				{
					color = avatarData.FeetColour;
					shrunkImage = Avatar.getFeet(avatarData);
					if (shrunkImage != null)
					{
						graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
					}
					color = avatarData.LegsColour;
					shrunkImage = Avatar.getLegs(avatarData);
					if (shrunkImage != null)
					{
						graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
					}
				}
				color = avatarData.TorsoColour;
				shrunkImage = Avatar.getTorso(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.TabardColour;
				shrunkImage = Avatar.getTabard(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.ArmsColour;
				shrunkImage = Avatar.getArms(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.HandsColour;
				shrunkImage = Avatar.getHands(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.ShouldersColour;
				shrunkImage = Avatar.getShoulders(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.HairColour;
				shrunkImage = Avatar.getFace(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.HairColour;
				shrunkImage = Avatar.getHair(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.HeadColour;
				shrunkImage = Avatar.getHead(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.WeaponColour;
				shrunkImage = Avatar.getWeapon(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				color = avatarData.WeaponColour;
				shrunkImage = Avatar.getBelt(avatarData);
				if (shrunkImage != null)
				{
					graphics.DrawImage(shrunkImage.image, shrunkImage.Dest, shrunkImage.Source.X, shrunkImage.Source.Y, shrunkImage.Source.Width, shrunkImage.Source.Height, GraphicsUnit.Pixel, Avatar.createColour(color));
				}
				int num = bitmap.Width * bitmap.Height * 4;
				byte[] array = new byte[num];
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
				IntPtr scan = bitmapData.Scan0;
				Marshal.Copy(scan, array, 0, num);
				byte[] parchementOverlay = GFXLibrary.parchementOverlay;
				for (int i = 0; i < parchementOverlay.Length; i += 4)
				{
					if (parchementOverlay[i] < 255)
					{
						array[i] = (byte)(array[i] * parchementOverlay[i] / byte.MaxValue);
					}
					if (parchementOverlay[i + 1] < 255)
					{
						array[i + 1] = (byte)(array[i + 1] * parchementOverlay[i + 1] / byte.MaxValue);
					}
					if (parchementOverlay[i + 2] < 255)
					{
						array[i + 2] = (byte)(array[i + 2] * parchementOverlay[i + 2] / byte.MaxValue);
					}
					byte b = parchementOverlay[i + 3];
				}
				Marshal.Copy(array, 0, scan, num);
				bitmap.UnlockBits(bitmapData);
				graphics.Dispose();
			}
			return bitmap;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0007B680 File Offset: 0x00079880
		private static ImageAttributes createColour(Color color)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix00 = (float)color.R / 255f;
			colorMatrix.Matrix11 = (float)color.G / 255f;
			colorMatrix.Matrix22 = (float)color.B / 255f;
			colorMatrix.Matrix44 = 1f;
			colorMatrix.Matrix33 = 1f;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			return imageAttributes;
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0007B6F4 File Offset: 0x000798F4
		public static ShrunkImage getRear(AvatarData data)
		{
			int shoulder = data.shoulder;
			if (shoulder != 3)
			{
				return null;
			}
			return GFXLibrary.avatar_shoulders04_back;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0007B718 File Offset: 0x00079918
		public static ShrunkImage getFloor(AvatarData data)
		{
			switch (data.floor)
			{
			case 1:
				return GFXLibrary.avatar_floor02;
			case 2:
				return GFXLibrary.avatar_floor03;
			case 3:
				return GFXLibrary.avatar_floor04;
			case 4:
				return GFXLibrary.avatar_floor05;
			case 5:
				return GFXLibrary.avatar_floor06;
			case 6:
				return GFXLibrary.avatar_floor07;
			case 7:
				return GFXLibrary.avatar_floor08;
			case 8:
				return GFXLibrary.avatar_floor09;
			case 9:
				return GFXLibrary.avatar_floor10;
			case 10:
				return GFXLibrary.avatar_floor11;
			default:
				return GFXLibrary.avatar_floor01;
			}
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0000B45B File Offset: 0x0000965B
		public static ShrunkImage getBody(AvatarData data)
		{
			int body = data.body;
			return GFXLibrary.avatar_body01_default;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0007B7D4 File Offset: 0x000799D4
		public static ShrunkImage getLegs(AvatarData data)
		{
			switch (data.legs)
			{
			case 1:
				return GFXLibrary.avatar_legs02;
			case 2:
				return GFXLibrary.avatar_legs03;
			case 3:
				return GFXLibrary.avatar_legs04;
			case 4:
				return GFXLibrary.avatar_legs05;
			case 5:
				return GFXLibrary.avatar_legs06;
			case 6:
				return GFXLibrary.avatar_legs07;
			default:
				if (data.male)
				{
					return GFXLibrary.avatar_legs01_male;
				}
				return GFXLibrary.avatar_legs01_female;
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0007B868 File Offset: 0x00079A68
		public static ShrunkImage getFeet(AvatarData data)
		{
			switch (data.feet)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_feet02;
			case 2:
				return GFXLibrary.avatar_feet03;
			case 3:
				return GFXLibrary.avatar_feet04;
			case 4:
				return GFXLibrary.avatar_feet05;
			case 5:
				return GFXLibrary.avatar_feet06;
			}
			return GFXLibrary.avatar_feet01;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0007B8E8 File Offset: 0x00079AE8
		public static ShrunkImage getTorso(AvatarData data)
		{
			switch (data.torso)
			{
			case 1:
				if (data.male)
				{
					return GFXLibrary.avatar_torso02_male;
				}
				return GFXLibrary.avatar_torso02_female;
			case 2:
				return GFXLibrary.avatar_torso03;
			case 3:
				return GFXLibrary.avatar_torso04;
			default:
				if (data.male)
				{
					return GFXLibrary.avatar_torso01_male_default;
				}
				return GFXLibrary.avatar_torso01_female_default;
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0007B964 File Offset: 0x00079B64
		public static ShrunkImage getTabard(AvatarData data)
		{
			switch (data.tabard)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_tabard02;
			case 2:
				return GFXLibrary.avatar_tabard03;
			case 3:
				return GFXLibrary.avatar_tabard04;
			case 4:
				return GFXLibrary.avatar_tabard05;
			case 5:
				return GFXLibrary.avatar_tabard06;
			case 6:
				return GFXLibrary.avatar_tabard07;
			case 7:
				return GFXLibrary.avatar_tabard08;
			}
			return GFXLibrary.avatar_tabard01;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0007BA00 File Offset: 0x00079C00
		public static ShrunkImage getArms(AvatarData data)
		{
			switch (data.arms)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_arms02;
			case 2:
				return GFXLibrary.avatar_arms03;
			case 3:
				return GFXLibrary.avatar_arms04;
			}
			return GFXLibrary.avatar_arms01;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0007BA60 File Offset: 0x00079C60
		public static ShrunkImage getHands(AvatarData data)
		{
			switch (data.hands)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_hands02;
			case 2:
				return GFXLibrary.avatar_hands03;
			case 3:
				return GFXLibrary.avatar_hands04;
			}
			return GFXLibrary.avatar_hands01;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0007BAC0 File Offset: 0x00079CC0
		public static ShrunkImage getShoulders(AvatarData data)
		{
			switch (data.shoulder)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_shoulders02;
			case 2:
				return GFXLibrary.avatar_shoulders03;
			case 3:
				return GFXLibrary.avatar_shoulders04_front;
			}
			return GFXLibrary.avatar_shoulders01;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0007BB20 File Offset: 0x00079D20
		public static ShrunkImage getFace(AvatarData data)
		{
			switch (data.face)
			{
			case 1:
				if (data.male)
				{
					return GFXLibrary.avatar_face02_male;
				}
				return GFXLibrary.avatar_face04_female;
			case 2:
				if (data.male)
				{
					return GFXLibrary.avatar_face06_male;
				}
				return GFXLibrary.avatar_face05_female;
			case 3:
				if (data.male)
				{
					return GFXLibrary.avatar_face07_male;
				}
				return GFXLibrary.avatar_face06_female;
			case 4:
				if (data.male)
				{
					return GFXLibrary.avatar_face08_male;
				}
				return GFXLibrary.avatar_face08_female;
			case 5:
				if (data.male)
				{
					return GFXLibrary.avatar_face09_male;
				}
				return GFXLibrary.avatar_face09_female;
			case 6:
				if (data.male)
				{
					return GFXLibrary.avatar_face10_male;
				}
				return GFXLibrary.avatar_face10_female;
			case 7:
				return GFXLibrary.avatar_rat_face;
			case 8:
				return GFXLibrary.avatar_snake_face;
			case 9:
				return GFXLibrary.avatar_pig_face;
			case 10:
				return GFXLibrary.avatar_wolf_face;
			default:
				if (data.male)
				{
					return GFXLibrary.avatar_face01_male;
				}
				return GFXLibrary.avatar_face03_female;
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0007BC64 File Offset: 0x00079E64
		public static ShrunkImage getHair(AvatarData data)
		{
			if ((data.head == 0 || data.head == 1) && data.hair == 0)
			{
				return null;
			}
			switch (data.hair)
			{
			case -1:
				return null;
			case 1:
				return GFXLibrary.avatar_hair02;
			case 2:
				return GFXLibrary.avatar_hair03;
			case 3:
				return GFXLibrary.avatar_hair04;
			case 4:
				return GFXLibrary.avatar_hair05;
			case 5:
				return GFXLibrary.avatar_hair06;
			}
			return GFXLibrary.avatar_hair01_helmhide;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0007BCFC File Offset: 0x00079EFC
		public static ShrunkImage getHead(AvatarData data)
		{
			switch (data.head)
			{
			case 0:
				return GFXLibrary.avatar_head01_hairoff;
			case 1:
				return GFXLibrary.avatar_head02_hairoff;
			case 2:
				return GFXLibrary.avatar_head03;
			case 3:
				return GFXLibrary.avatar_head04;
			case 4:
				return GFXLibrary.avatar_head05;
			case 5:
				return GFXLibrary.avatar_head06;
			case 6:
				return GFXLibrary.avatar_head07;
			case 7:
				return GFXLibrary.avatar_head08;
			case 8:
				return GFXLibrary.avatar_head09;
			case 9:
				return GFXLibrary.avatar_head10;
			case 10:
				return GFXLibrary.avatar_head11;
			case 11:
				return GFXLibrary.avatar_head12;
			case 12:
				return GFXLibrary.avatar_rat_helm;
			case 13:
				return GFXLibrary.avatar_wolf_helm;
			default:
				return null;
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0007BDEC File Offset: 0x00079FEC
		public static ShrunkImage getWeapon(AvatarData data)
		{
			switch (data.weapon)
			{
			case 0:
				return GFXLibrary.avatar_weapon01;
			case 1:
				return GFXLibrary.avatar_weapon02;
			case 2:
				return GFXLibrary.avatar_weapon03;
			case 3:
				return GFXLibrary.avatar_weapon04;
			case 4:
				return GFXLibrary.avatar_weapon05;
			case 5:
				return GFXLibrary.avatar_weapon06;
			default:
				return null;
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0000B46E File Offset: 0x0000966E
		public static ShrunkImage getBelt(AvatarData data)
		{
			if (data.weapon >= 0)
			{
				return GFXLibrary.avatar_weapon_belt;
			}
			return null;
		}
	}
}
