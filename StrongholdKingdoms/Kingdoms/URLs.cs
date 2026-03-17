using System;

namespace Kingdoms
{
	// Token: 0x020004AE RID: 1198
	public class URLs
	{
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06002BD5 RID: 11221 RVA: 0x000202F0 File Offset: 0x0001E4F0
		public static string AccountMainPage
		{
			get
			{
				return URLs.WebProtocol + "://" + URLs.ProfileServerAddressWeb + "/kingdoms/account.php";
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06002BD6 RID: 11222 RVA: 0x0002030B File Offset: 0x0001E50B
		public static string AccountOffersPage
		{
			get
			{
				return URLs.WebProtocol + "://" + URLs.ProfileServerAddressWeb + URLs.ProfileNewOffersPath;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06002BD7 RID: 11223 RVA: 0x00020326 File Offset: 0x0001E526
		public static string ForgottenPasswordLink
		{
			get
			{
				return URLs.WebProtocol + "://" + URLs.ProfileServerAddressWeb + "/kingdoms/forgotten.php";
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06002BD8 RID: 11224 RVA: 0x00020341 File Offset: 0x0001E541
		public static string shieldDesignerURL
		{
			get
			{
				return URLs.WebProtocol + "://" + URLs.ProfileServerAddressWeb + "/shield/shield.html";
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06002BD9 RID: 11225 RVA: 0x0002035C File Offset: 0x0001E55C
		public static string ServerNewsFeed
		{
			get
			{
				return string.Concat(new string[]
				{
					URLs.WebProtocol,
					"://",
					URLs.ProfileServerAddressCMS,
					"/servernews.php?lang=",
					Program.mySettings.LanguageIdent
				});
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06002BDA RID: 11226 RVA: 0x0022B418 File Offset: 0x00229618
		public static string NewsMainPage
		{
			get
			{
				if (!Program.bigpointPartnerInstall)
				{
					return string.Concat(new string[]
					{
						URLs.WebProtocol,
						"://",
						URLs.ProfileServerAddressCMS,
						"/clientnews.php?lang=",
						Program.mySettings.LanguageIdent
					});
				}
				return string.Concat(new string[]
				{
					URLs.WebProtocol,
					"://",
					URLs.ProfileServerAddressCMS,
					"/clientnews.php?lang=",
					Program.mySettings.LanguageIdent,
					"&noads=1"
				});
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06002BDB RID: 11227 RVA: 0x0022B4A8 File Offset: 0x002296A8
		public static string NewsMainPageBrowserVersion
		{
			get
			{
				if (!Program.bigpointPartnerInstall)
				{
					return string.Concat(new string[]
					{
						URLs.WebProtocol,
						"://",
						URLs.ProfileServerAddressCMS,
						"/frontpagenews.php?lang=",
						Program.mySettings.LanguageIdent
					});
				}
				return string.Concat(new string[]
				{
					URLs.WebProtocol,
					"://",
					URLs.ProfileServerAddressCMS,
					"/frontpagenews.php?lang=",
					Program.mySettings.LanguageIdent,
					"&noads=1"
				});
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06002BDC RID: 11228 RVA: 0x00020396 File Offset: 0x0001E596
		public static string GameRPC
		{
			get
			{
				return "http://" + URLs.GameRPCAddress + ":80/KingdomsRPC/Kingdoms.rem";
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06002BDD RID: 11229 RVA: 0x000203AC File Offset: 0x0001E5AC
		public static string ChatRPC
		{
			get
			{
				return "http://" + URLs.ChatRPCAddress + ":80/KingdomsChatRPC/KingdomsChat.rem";
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06002BDE RID: 11230 RVA: 0x000203C2 File Offset: 0x0001E5C2
		public static string FireflyHomepage
		{
			get
			{
				return URLs.WebProtocol + "://www.fireflyworlds.com";
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06002BDF RID: 11231 RVA: 0x000203D3 File Offset: 0x0001E5D3
		public static string ForumHomepage
		{
			get
			{
				return "https://forum.strongholdkingdoms.com";
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06002BE0 RID: 11232 RVA: 0x0022B538 File Offset: 0x00229738
		public static string Supportpage
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num <= 1194886160U)
					{
						if (num != 1162757945U)
						{
							if (num != 1176137065U)
							{
								if (num == 1194886160U)
								{
									if (languageIdent == "it")
									{
										return "https://support.strongholdkingdoms.com/?it";
									}
								}
							}
							else if (languageIdent == "es")
							{
								return "https://support.strongholdkingdoms.com/?es";
							}
						}
						else if (languageIdent == "pl")
						{
							return "https://support.strongholdkingdoms.com/?pl";
						}
					}
					else if (num <= 1213488160U)
					{
						if (num != 1195724803U)
						{
							if (num == 1213488160U)
							{
								if (languageIdent == "ru")
								{
									return "https://support.strongholdkingdoms.com/?ru";
								}
							}
						}
						else if (languageIdent == "tr")
						{
							return "https://support.strongholdkingdoms.com/?tr";
						}
					}
					else if (num != 1461901041U)
					{
						if (num == 1545391778U)
						{
							if (languageIdent == "de")
							{
								return "https://support.strongholdkingdoms.com/?de";
							}
						}
					}
					else if (languageIdent == "fr")
					{
						return "https://support.strongholdkingdoms.com/?fr";
					}
				}
				return "https://support.strongholdkingdoms.com/?en";
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06002BE1 RID: 11233 RVA: 0x0022B654 File Offset: 0x00229854
		public static string WikiPage
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num > 1195724803U)
					{
						if (num <= 1328268469U)
						{
							if (num != 1213488160U)
							{
								if (num != 1328268469U)
								{
									goto IL_15B;
								}
								if (!(languageIdent == "br"))
								{
									goto IL_15B;
								}
							}
							else
							{
								if (!(languageIdent == "ru"))
								{
									goto IL_15B;
								}
								return "https://strongholdkingdoms-ru.gamepedia.com";
							}
						}
						else if (num != 1461901041U)
						{
							if (num != 1545391778U)
							{
								if (num != 1565420801U)
								{
									goto IL_15B;
								}
								if (!(languageIdent == "pt"))
								{
									goto IL_15B;
								}
							}
							else
							{
								if (!(languageIdent == "de"))
								{
									goto IL_15B;
								}
								return "https://strongholdkingdoms-de.gamepedia.com";
							}
						}
						else
						{
							if (!(languageIdent == "fr"))
							{
								goto IL_15B;
							}
							return "https://strongholdkingdoms-fr.gamepedia.com";
						}
						return "https://strongholdkingdoms-pt.gamepedia.com";
					}
					if (num <= 1176137065U)
					{
						if (num != 1162757945U)
						{
							if (num == 1176137065U)
							{
								if (languageIdent == "es")
								{
									return "https://strongholdkingdoms-es.gamepedia.com";
								}
							}
						}
						else if (languageIdent == "pl")
						{
							return "https://strongholdkingdoms-pl.gamepedia.com/";
						}
					}
					else if (num != 1194886160U)
					{
						if (num == 1195724803U)
						{
							if (languageIdent == "tr")
							{
								return "https://strongholdkingdoms-tr.gamepedia.com";
							}
						}
					}
					else if (languageIdent == "it")
					{
						return "https://strongholdkingdoms-it.gamepedia.com";
					}
				}
				IL_15B:
				return "https://strongholdkingdoms.gamepedia.com";
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06002BE2 RID: 11234 RVA: 0x0022B7C4 File Offset: 0x002299C4
		public static string IPSharingPage
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num > 1195724803U)
					{
						if (num <= 1328268469U)
						{
							if (num != 1213488160U)
							{
								if (num != 1241987482U)
								{
									if (num != 1328268469U)
									{
										goto IL_280;
									}
									if (!(languageIdent == "br"))
									{
										goto IL_280;
									}
								}
								else
								{
									if (!(languageIdent == "zhhk"))
									{
										goto IL_280;
									}
									return "https://www.strongholdkingdoms.com/GameRules.tc.html";
								}
							}
							else
							{
								if (!(languageIdent == "ru"))
								{
									goto IL_280;
								}
								return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.ru.html";
							}
						}
						else if (num <= 1545391778U)
						{
							if (num != 1461901041U)
							{
								if (num != 1545391778U)
								{
									goto IL_280;
								}
								if (!(languageIdent == "de"))
								{
									goto IL_280;
								}
								return URLs.WebProtocol + "://www.strongholdkingdoms.com/spielregeln.html";
							}
							else
							{
								if (!(languageIdent == "fr"))
								{
									goto IL_280;
								}
								return URLs.WebProtocol + "://www.strongholdkingdoms.com/ReglesduJeu.html";
							}
						}
						else if (num != 1564435063U)
						{
							if (num != 1565420801U)
							{
								goto IL_280;
							}
							if (!(languageIdent == "pt"))
							{
								goto IL_280;
							}
						}
						else
						{
							if (!(languageIdent == "jp"))
							{
								goto IL_280;
							}
							return "https://www.strongholdkingdoms.com/GameRules.jp.html";
						}
						return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.pt.html";
					}
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
										return "https://www.strongholdkingdoms.com/GameRules.sc.html";
									}
								}
							}
							else if (languageIdent == "pl")
							{
								return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.pl.html";
							}
						}
						else if (languageIdent == "ko")
						{
							return "https://www.strongholdkingdoms.com/GameRules.ko.html";
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
									return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.tr.html";
								}
							}
						}
						else if (languageIdent == "it")
						{
							return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.it.html";
						}
					}
					else if (languageIdent == "es")
					{
						return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.es.html";
					}
				}
				IL_280:
				return URLs.WebProtocol + "://www.strongholdkingdoms.com/GameRules.html";
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06002BE3 RID: 11235 RVA: 0x0022BA60 File Offset: 0x00229C60
		public static string TermsAndConditions
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num > 1195724803U)
					{
						if (num <= 1328268469U)
						{
							if (num != 1213488160U)
							{
								if (num != 1241987482U)
								{
									if (num != 1328268469U)
									{
										goto IL_212;
									}
									if (!(languageIdent == "br"))
									{
										goto IL_212;
									}
								}
								else
								{
									if (!(languageIdent == "zhhk"))
									{
										goto IL_212;
									}
									return "https://fireflyworlds.com/terms-of-use-tc/";
								}
							}
							else
							{
								if (!(languageIdent == "ru"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/terms-of-use-ru/";
							}
						}
						else if (num <= 1545391778U)
						{
							if (num != 1461901041U)
							{
								if (num != 1545391778U)
								{
									goto IL_212;
								}
								if (!(languageIdent == "de"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/terms-of-use-de/";
							}
							else
							{
								if (!(languageIdent == "fr"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/terms-of-use-fr/";
							}
						}
						else if (num != 1564435063U)
						{
							if (num != 1565420801U)
							{
								goto IL_212;
							}
							if (!(languageIdent == "pt"))
							{
								goto IL_212;
							}
						}
						else
						{
							if (!(languageIdent == "jp"))
							{
								goto IL_212;
							}
							return "https://fireflyworlds.com/terms-of-use-jp/";
						}
						return "https://fireflyworlds.com/terms-of-use-pt/";
					}
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
										return "https://fireflyworlds.com/terms-of-use-sc/";
									}
								}
							}
							else if (languageIdent == "pl")
							{
								return "https://fireflyworlds.com/terms-of-use-pl/";
							}
						}
						else if (languageIdent == "ko")
						{
							return "https://fireflyworlds.com/terms-of-use-ko/";
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
									return "https://fireflyworlds.com/terms-of-use-tr/";
								}
							}
						}
						else if (languageIdent == "it")
						{
							return "https://fireflyworlds.com/terms-of-use-it/";
						}
					}
					else if (languageIdent == "es")
					{
						return "https://fireflyworlds.com/terms-of-use-es/";
					}
				}
				IL_212:
				return "https://fireflyworlds.com/terms-of-use-en/";
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06002BE4 RID: 11236 RVA: 0x0022BC84 File Offset: 0x00229E84
		public static string PrivacyPolicy
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num > 1195724803U)
					{
						if (num <= 1328268469U)
						{
							if (num != 1213488160U)
							{
								if (num != 1241987482U)
								{
									if (num != 1328268469U)
									{
										goto IL_212;
									}
									if (!(languageIdent == "br"))
									{
										goto IL_212;
									}
								}
								else
								{
									if (!(languageIdent == "zhhk"))
									{
										goto IL_212;
									}
									return "https://fireflyworlds.com/privacy-policy-tc/";
								}
							}
							else
							{
								if (!(languageIdent == "ru"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/privacy-policy-ru/";
							}
						}
						else if (num <= 1545391778U)
						{
							if (num != 1461901041U)
							{
								if (num != 1545391778U)
								{
									goto IL_212;
								}
								if (!(languageIdent == "de"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/privacy-policy-de/";
							}
							else
							{
								if (!(languageIdent == "fr"))
								{
									goto IL_212;
								}
								return "https://fireflyworlds.com/privacy-policy-fr/";
							}
						}
						else if (num != 1564435063U)
						{
							if (num != 1565420801U)
							{
								goto IL_212;
							}
							if (!(languageIdent == "pt"))
							{
								goto IL_212;
							}
						}
						else
						{
							if (!(languageIdent == "jp"))
							{
								goto IL_212;
							}
							return "https://fireflyworlds.com/privacy-policy-jp/";
						}
						return "https://fireflyworlds.com/privacy-policy-pt/";
					}
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
										return "https://fireflyworlds.com/privacy-policy-sc/";
									}
								}
							}
							else if (languageIdent == "pl")
							{
								return "https://fireflyworlds.com/privacy-policy-pl/";
							}
						}
						else if (languageIdent == "ko")
						{
							return "https://fireflyworlds.com/privacy-policy-ko/";
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
									return "https://fireflyworlds.com/privacy-policy-tr/";
								}
							}
						}
						else if (languageIdent == "it")
						{
							return "https://fireflyworlds.com/privacy-policy-it/";
						}
					}
					else if (languageIdent == "es")
					{
						return "https://fireflyworlds.com/privacy-policy-es/";
					}
				}
				IL_212:
				return "https://fireflyworlds.com/privacy-policy/";
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06002BE5 RID: 11237 RVA: 0x000203DA File Offset: 0x0001E5DA
		public static string TwitterURL
		{
			get
			{
				return "https://twitter.com/playstronghold";
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06002BE6 RID: 11238 RVA: 0x0022BEA8 File Offset: 0x0022A0A8
		public static string FacebookURL
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					if (languageIdent == "de")
					{
						return URLs.WebProtocol + "://www.facebook.com/strongholdkingdoms";
					}
					if (languageIdent == "fr")
					{
						return URLs.WebProtocol + "://www.facebook.com/strongholdkingdoms";
					}
					if (languageIdent == "ru")
					{
						return URLs.WebProtocol + "://www.facebook.com/StrongholdKingdoms";
					}
					if (languageIdent == "es")
					{
						return URLs.WebProtocol + "://www.facebook.com/strongholdkingdoms";
					}
				}
				return URLs.WebProtocol + "://www.facebook.com/strongholdkingdoms";
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06002BE7 RID: 11239 RVA: 0x0022BF48 File Offset: 0x0022A148
		public static string YoutubeURL
		{
			get
			{
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					if (languageIdent == "de")
					{
						return URLs.WebProtocol + "://www.youtube.com/user/fireflyworlds?ob=0";
					}
					if (languageIdent == "fr")
					{
						return URLs.WebProtocol + "://www.youtube.com/user/fireflyworlds?ob=0";
					}
					if (languageIdent == "ru")
					{
						return URLs.WebProtocol + "://www.youtube.com/user/fireflyworlds?ob=0";
					}
				}
				return URLs.WebProtocol + "://www.youtube.com/user/fireflyworlds?ob=0";
			}
		}

		// Token: 0x0400369B RID: 13979
		public static string GameRPCAddress = "";

		// Token: 0x0400369C RID: 13980
		public static string ChatRPCAddress = "";

		// Token: 0x0400369D RID: 13981
		public static string ProfileProtocol = "http";

		// Token: 0x0400369E RID: 13982
		public static string WebProtocol = "https";

		// Token: 0x0400369F RID: 13983
		public static string ProfilePath = "/services/auth.php";

		// Token: 0x040036A0 RID: 13984
		public static string ProfileCardPath = "/services/cardserver.php";

		// Token: 0x040036A1 RID: 13985
		public static string ProfileBPPath = "/services/bpEndpoint.php";

		// Token: 0x040036A2 RID: 13986
		public static string ProfilePresetsPath = "/services/auth.php";

		// Token: 0x040036A3 RID: 13987
		public static string ProfileServerAddressCMS = "news.strongholdkingdoms.com";

		// Token: 0x040036A4 RID: 13988
		public static string ProfileNewOffersPath = "/kingdoms/viewRedeemedOffers.php";

		// Token: 0x040036A5 RID: 13989
		public static string ProfileServerPort = "80";

		// Token: 0x040036A6 RID: 13990
		public static string ProfileServerAddressCards = "cardsxml.prd.external.fireflyops.com";

		// Token: 0x040036A7 RID: 13991
		public static string ProfileServerAddressBigpoint = "cardsxml.prd.external.fireflyops.com";

		// Token: 0x040036A8 RID: 13992
		public static string ProfileServerAddressWeb = "login.strongholdkingdoms.com";

		// Token: 0x040036A9 RID: 13993
		public static string ProfileServerAddressLogin = "login.strongholdkingdoms.com";

		// Token: 0x040036AA RID: 13994
		public static string ProfileServerAddressPresets = "login.strongholdkingdoms.com";

		// Token: 0x040036AB RID: 13995
		public static string ProfilePaymentURL = URLs.WebProtocol + "://login.strongholdkingdoms.com/pay.php";

		// Token: 0x040036AC RID: 13996
		public static string AccountInfoURL = URLs.WebProtocol + "://login.strongholdkingdoms.com/kingdoms/account.php";

		// Token: 0x040036AD RID: 13997
		public static string InviteAFriendURL = URLs.WebProtocol + "://login.strongholdkingdoms.com/invitefriend";
	}
}
