using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using CommonTypes;
using CustomSinks;
using DXGraphics;
using ServerInterface;

namespace Kingdoms
{
	// Token: 0x020002B7 RID: 695
	public class RemoteServices
	{
		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x0001D83A File Offset: 0x0001BA3A
		public static RemoteServices Instance
		{
			get
			{
				return RemoteServices.instance;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06001F0C RID: 7948 RVA: 0x0001D841 File Offset: 0x0001BA41
		public bool InResultsProcessing
		{
			get
			{
				return this.inResultsProcessing;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x0001D849 File Offset: 0x0001BA49
		// (set) Token: 0x06001F0E RID: 7950 RVA: 0x0001D851 File Offset: 0x0001BA51
		public bool ChatActive
		{
			get
			{
				return this.chatActive;
			}
			set
			{
				this.chatActive = value;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06001F0F RID: 7951 RVA: 0x0001D85A File Offset: 0x0001BA5A
		// (set) Token: 0x06001F10 RID: 7952 RVA: 0x0001D862 File Offset: 0x0001BA62
		public int ProfileWorldID
		{
			get
			{
				return this.profileWorldID;
			}
			set
			{
				this.profileWorldID = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06001F11 RID: 7953 RVA: 0x0001D86B File Offset: 0x0001BA6B
		// (set) Token: 0x06001F12 RID: 7954 RVA: 0x0001D873 File Offset: 0x0001BA73
		public Guid UserGuid
		{
			get
			{
				return this.userGuid;
			}
			set
			{
				this.userGuid = value;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06001F13 RID: 7955 RVA: 0x0001D87C File Offset: 0x0001BA7C
		// (set) Token: 0x06001F14 RID: 7956 RVA: 0x0001D884 File Offset: 0x0001BA84
		public Guid SessionGuid
		{
			get
			{
				return this.sessionGuid;
			}
			set
			{
				this.sessionGuid = value;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x0001D88D File Offset: 0x0001BA8D
		// (set) Token: 0x06001F16 RID: 7958 RVA: 0x0001D895 File Offset: 0x0001BA95
		public string WebToken
		{
			get
			{
				return this.webToken;
			}
			set
			{
				this.webToken = value;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06001F17 RID: 7959 RVA: 0x001DEFA8 File Offset: 0x001DD1A8
		public string UserGuidProfileSite
		{
			get
			{
				return this.UserGuid.ToString().Replace("-", "");
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06001F18 RID: 7960 RVA: 0x001DEFD8 File Offset: 0x001DD1D8
		public string SessionGuidProfileSite
		{
			get
			{
				return this.SessionGuid.ToString().Replace("-", "");
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06001F19 RID: 7961 RVA: 0x0001D89E File Offset: 0x0001BA9E
		// (set) Token: 0x06001F1A RID: 7962 RVA: 0x0001D8A6 File Offset: 0x0001BAA6
		public int UserID
		{
			get
			{
				return this.userID;
			}
			set
			{
				this.userID = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06001F1B RID: 7963 RVA: 0x0001D8AF File Offset: 0x0001BAAF
		// (set) Token: 0x06001F1C RID: 7964 RVA: 0x0001D8B7 File Offset: 0x0001BAB7
		public int SessionID
		{
			get
			{
				return this.sessionID;
			}
			set
			{
				this.sessionID = value;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06001F1D RID: 7965 RVA: 0x0001D8C0 File Offset: 0x0001BAC0
		// (set) Token: 0x06001F1E RID: 7966 RVA: 0x0001D8C8 File Offset: 0x0001BAC8
		public int UserFactionID
		{
			get
			{
				return this.userFactionID;
			}
			set
			{
				this.userFactionID = value;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06001F1F RID: 7967 RVA: 0x0001D8D1 File Offset: 0x0001BAD1
		// (set) Token: 0x06001F20 RID: 7968 RVA: 0x0001D8D9 File Offset: 0x0001BAD9
		public string UserName
		{
			get
			{
				return this.username;
			}
			set
			{
				this.username = value;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06001F21 RID: 7969 RVA: 0x0001D8E2 File Offset: 0x0001BAE2
		// (set) Token: 0x06001F22 RID: 7970 RVA: 0x0001D8EA File Offset: 0x0001BAEA
		public string RealName
		{
			get
			{
				return this.realname;
			}
			set
			{
				this.realname = value;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06001F23 RID: 7971 RVA: 0x0001D8F3 File Offset: 0x0001BAF3
		// (set) Token: 0x06001F24 RID: 7972 RVA: 0x0001D8FB File Offset: 0x0001BAFB
		public Guid WorldGUID
		{
			get
			{
				return this.worldGUID;
			}
			set
			{
				this.worldGUID = value;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06001F25 RID: 7973 RVA: 0x0001D904 File Offset: 0x0001BB04
		// (set) Token: 0x06001F26 RID: 7974 RVA: 0x0001D90C File Offset: 0x0001BB0C
		public bool Admin
		{
			get
			{
				return this.admin;
			}
			set
			{
				this.admin = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06001F27 RID: 7975 RVA: 0x0001D915 File Offset: 0x0001BB15
		// (set) Token: 0x06001F28 RID: 7976 RVA: 0x0001D91D File Offset: 0x0001BB1D
		public bool MapEditor
		{
			get
			{
				return this.mapEditor;
			}
			set
			{
				this.mapEditor = value;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06001F29 RID: 7977 RVA: 0x0001D926 File Offset: 0x0001BB26
		// (set) Token: 0x06001F2A RID: 7978 RVA: 0x0001D92E File Offset: 0x0001BB2E
		public bool Moderator
		{
			get
			{
				return this.moderator;
			}
			set
			{
				this.moderator = value;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06001F2B RID: 7979 RVA: 0x001DF008 File Offset: 0x001DD208
		// (set) Token: 0x06001F2C RID: 7980 RVA: 0x0001D937 File Offset: 0x0001BB37
		public bool ShowAdminMessage
		{
			get
			{
				bool result = this.showAdminMessage;
				this.showAdminMessage = false;
				return result;
			}
			set
			{
				this.showAdminMessage = value;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001DF024 File Offset: 0x001DD224
		// (set) Token: 0x06001F2E RID: 7982 RVA: 0x0001D940 File Offset: 0x0001BB40
		public bool Show2ndAgeMessage
		{
			get
			{
				bool result = this.show2ndAgeMessage;
				this.show2ndAgeMessage = false;
				return result;
			}
			set
			{
				this.show2ndAgeMessage = value;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001DF040 File Offset: 0x001DD240
		// (set) Token: 0x06001F30 RID: 7984 RVA: 0x0001D949 File Offset: 0x0001BB49
		public bool Show3rdAgeMessage
		{
			get
			{
				bool result = this.show3rdAgeMessage;
				this.show3rdAgeMessage = false;
				return result;
			}
			set
			{
				this.show3rdAgeMessage = value;
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06001F31 RID: 7985 RVA: 0x001DF05C File Offset: 0x001DD25C
		// (set) Token: 0x06001F32 RID: 7986 RVA: 0x0001D952 File Offset: 0x0001BB52
		public bool Show4thAgeMessage
		{
			get
			{
				bool result = this.show4thAgeMessage;
				this.show4thAgeMessage = false;
				return result;
			}
			set
			{
				this.show4thAgeMessage = value;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06001F33 RID: 7987 RVA: 0x001DF078 File Offset: 0x001DD278
		// (set) Token: 0x06001F34 RID: 7988 RVA: 0x0001D95B File Offset: 0x0001BB5B
		public bool Show5thAgeMessage
		{
			get
			{
				bool result = this.show5thAgeMessage;
				this.show5thAgeMessage = false;
				return result;
			}
			set
			{
				this.show5thAgeMessage = value;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06001F35 RID: 7989 RVA: 0x001DF094 File Offset: 0x001DD294
		// (set) Token: 0x06001F36 RID: 7990 RVA: 0x0001D964 File Offset: 0x0001BB64
		public bool Show6thAgeMessage
		{
			get
			{
				bool result = this.show6thAgeMessage;
				this.show6thAgeMessage = false;
				return result;
			}
			set
			{
				this.show6thAgeMessage = value;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06001F37 RID: 7991 RVA: 0x001DF0B0 File Offset: 0x001DD2B0
		// (set) Token: 0x06001F38 RID: 7992 RVA: 0x0001D96D File Offset: 0x0001BB6D
		public bool Show7thAgeMessage
		{
			get
			{
				bool result = this.show7thAgeMessage;
				this.show7thAgeMessage = false;
				return result;
			}
			set
			{
				this.show7thAgeMessage = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06001F39 RID: 7993 RVA: 0x0001D976 File Offset: 0x0001BB76
		// (set) Token: 0x06001F3A RID: 7994 RVA: 0x0001D97E File Offset: 0x0001BB7E
		public ReportFilterList ReportFilters
		{
			get
			{
				return this.reportFilters;
			}
			set
			{
				this.reportFilters = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06001F3B RID: 7995 RVA: 0x0001D987 File Offset: 0x0001BB87
		// (set) Token: 0x06001F3C RID: 7996 RVA: 0x0001D98F File Offset: 0x0001BB8F
		public bool RequiresVerification
		{
			get
			{
				return this.requiresVerification;
			}
			set
			{
				this.requiresVerification = value;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06001F3D RID: 7997 RVA: 0x0001D998 File Offset: 0x0001BB98
		// (set) Token: 0x06001F3E RID: 7998 RVA: 0x0001D9A0 File Offset: 0x0001BBA0
		public LoginLeadersInfo LoginLeaderInfo
		{
			get
			{
				return this.loginLeaderInfo;
			}
			set
			{
				this.loginLeaderInfo = value;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06001F3F RID: 7999 RVA: 0x0001D9A9 File Offset: 0x0001BBA9
		// (set) Token: 0x06001F40 RID: 8000 RVA: 0x0001D9B1 File Offset: 0x0001BBB1
		public bool BoxUser
		{
			get
			{
				return this.boxUser;
			}
			set
			{
				this.boxUser = value;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x0001D9BA File Offset: 0x0001BBBA
		// (set) Token: 0x06001F42 RID: 8002 RVA: 0x0001D9C2 File Offset: 0x0001BBC2
		public bool MobileWorld
		{
			get
			{
				return this.mobileWorld;
			}
			set
			{
				this.mobileWorld = value;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06001F43 RID: 8003 RVA: 0x0001D9CB File Offset: 0x0001BBCB
		// (set) Token: 0x06001F44 RID: 8004 RVA: 0x0001D9D3 File Offset: 0x0001BBD3
		public AvatarData UserAvatar
		{
			get
			{
				return this.userAvatar;
			}
			set
			{
				this.userAvatar = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06001F45 RID: 8005 RVA: 0x0001D9DC File Offset: 0x0001BBDC
		// (set) Token: 0x06001F46 RID: 8006 RVA: 0x0001D9E4 File Offset: 0x0001BBE4
		public GameOptionsData UserOptions
		{
			get
			{
				return this.userOptions;
			}
			set
			{
				this.userOptions = value;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06001F47 RID: 8007 RVA: 0x0001D9ED File Offset: 0x0001BBED
		// (set) Token: 0x06001F48 RID: 8008 RVA: 0x0001D9F5 File Offset: 0x0001BBF5
		public List<int> UserAchievements
		{
			get
			{
				return this.achievements;
			}
			set
			{
				this.achievements = value;
			}
		}

		// Token: 0x06001F49 RID: 8009 RVA: 0x001DF0CC File Offset: 0x001DD2CC
		private RemoteServices()
		{
		}

		// Token: 0x06001F4A RID: 8010 RVA: 0x0001D9FE File Offset: 0x0001BBFE
		private bool UnityEndOfTheWorldHandler(Common_ReturnData returnData)
		{
			if (returnData == null)
			{
				return false;
			}
			if (!returnData.Success && returnData.m_errorCode == ErrorCodes.ErrorCode.LOCK_OUT)
			{
				GameEngine.Instance.World.WorldEnded = true;
				return true;
			}
			return false;
		}

		// Token: 0x06001F4B RID: 8011 RVA: 0x0001DA2D File Offset: 0x0001BC2D
		public void set_CreateNewUser_UserCallBack(RemoteServices.CreateNewUser_UserCallBack callback)
		{
			this.createNewUser_UserCallBack = callback;
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x001DF174 File Offset: 0x001DD374
		public void createNewUser(string username, string password, string realname, string emailaddress)
		{
			if (this.CreateNewUser_Callback == null)
			{
				this.CreateNewUser_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateNewUser);
			}
			RemoteServices.RemoteAsyncDelegate_CreateNewUser remoteAsyncDelegate_CreateNewUser = new RemoteServices.RemoteAsyncDelegate_CreateNewUser(this.service.CreateNewUser);
			this.registerRPCcall(remoteAsyncDelegate_CreateNewUser.BeginInvoke(username, password, realname, emailaddress, BuildVersion.VersionNumber, "", this.CreateNewUser_Callback, null), typeof(CreateNewUser_ReturnType));
		}

		// Token: 0x06001F4D RID: 8013 RVA: 0x001DF1DC File Offset: 0x001DD3DC
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateNewUser(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateNewUser remoteAsyncDelegate_CreateNewUser = (RemoteServices.RemoteAsyncDelegate_CreateNewUser)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateNewUser.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateNewUser_ReturnType returnData = new CreateNewUser_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F4E RID: 8014 RVA: 0x0001DA36 File Offset: 0x0001BC36
		public void set_LoginUser_UserCallBack(RemoteServices.LoginUser_UserCallBack callback)
		{
			this.loginUser_UserCallBack = callback;
		}

		// Token: 0x06001F4F RID: 8015 RVA: 0x001DF22C File Offset: 0x001DD42C
		public void LoginUser(string username, string password, string verificationString)
		{
			bool needVillageData = true;
			if (VillageMap.villageBuildingData != null)
			{
				needVillageData = false;
			}
			if (this.LoginUser_Callback == null)
			{
				this.LoginUser_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LoginUser);
			}
			RemoteServices.RemoteAsyncDelegate_LoginUser remoteAsyncDelegate_LoginUser = new RemoteServices.RemoteAsyncDelegate_LoginUser(this.service.LoginUser);
			this.registerRPCcall(remoteAsyncDelegate_LoginUser.BeginInvoke(username, password, BuildVersion.VersionNumber, verificationString, needVillageData, this.LoginUser_Callback, null), typeof(LoginUser_ReturnType));
		}

		// Token: 0x06001F50 RID: 8016 RVA: 0x001DF298 File Offset: 0x001DD498
		[OneWay]
		public void OurRemoteAsyncCallBack_LoginUser(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LoginUser remoteAsyncDelegate_LoginUser = (RemoteServices.RemoteAsyncDelegate_LoginUser)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LoginUser.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LoginUser_ReturnType returnData = new LoginUser_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F51 RID: 8017 RVA: 0x0001DA3F File Offset: 0x0001BC3F
		public void set_LoginUserGuid_UserCallBack(RemoteServices.LoginUserGuid_UserCallBack callback)
		{
			this.loginUserGuid_UserCallBack = callback;
		}

		// Token: 0x06001F52 RID: 8018 RVA: 0x001DF2E8 File Offset: 0x001DD4E8
		public void LoginUserGuid(string username, Guid userGuid, Guid sessionGuid)
		{
			bool needVillageData = true;
			if (VillageMap.villageBuildingData != null)
			{
				needVillageData = false;
			}
			if (this.LoginUserGuid_Callback == null)
			{
				this.LoginUserGuid_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LoginUserGuid);
			}
			RemoteServices.RemoteAsyncDelegate_LoginUserGuid remoteAsyncDelegate_LoginUserGuid = new RemoteServices.RemoteAsyncDelegate_LoginUserGuid(this.service.LoginUserGuid);
			this.registerRPCcall(remoteAsyncDelegate_LoginUserGuid.BeginInvoke(username, userGuid.ToString(), sessionGuid.ToString(), needVillageData, BuildVersion.VersionNumber, this.LoginUserGuid_Callback, null), typeof(LoginUserGuid_ReturnType));
		}

		// Token: 0x06001F53 RID: 8019 RVA: 0x001DF36C File Offset: 0x001DD56C
		[OneWay]
		public void OurRemoteAsyncCallBack_LoginUserGuid(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LoginUserGuid remoteAsyncDelegate_LoginUserGuid = (RemoteServices.RemoteAsyncDelegate_LoginUserGuid)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LoginUserGuid.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LoginUserGuid_ReturnType returnData = new LoginUserGuid_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F54 RID: 8020 RVA: 0x0001DA48 File Offset: 0x0001BC48
		public void set_ResendVerificationEmail_UserCallBack(RemoteServices.ResendVerificationEmail_UserCallBack callback)
		{
			this.resendVerificationEmail_UserCallBack = callback;
		}

		// Token: 0x06001F55 RID: 8021 RVA: 0x001DF3BC File Offset: 0x001DD5BC
		public void ResendVerificationEmail(string username, string password)
		{
			if (this.ResendVerificationEmail_Callback == null)
			{
				this.ResendVerificationEmail_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ResendVerificationEmail);
			}
			RemoteServices.RemoteAsyncDelegate_ResendVerificationEmail remoteAsyncDelegate_ResendVerificationEmail = new RemoteServices.RemoteAsyncDelegate_ResendVerificationEmail(this.service.ResendVerificationEmail);
			this.registerRPCcall(remoteAsyncDelegate_ResendVerificationEmail.BeginInvoke(username, password, this.ResendVerificationEmail_Callback, null), typeof(ResendVerificationEmail_ReturnType));
		}

		// Token: 0x06001F56 RID: 8022 RVA: 0x001DF418 File Offset: 0x001DD618
		[OneWay]
		public void OurRemoteAsyncCallBack_ResendVerificationEmail(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ResendVerificationEmail remoteAsyncDelegate_ResendVerificationEmail = (RemoteServices.RemoteAsyncDelegate_ResendVerificationEmail)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ResendVerificationEmail.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ResendVerificationEmail_ReturnType returnData = new ResendVerificationEmail_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F57 RID: 8023 RVA: 0x0001DA51 File Offset: 0x0001BC51
		public void set_GetAllVillageOwnerFactions_UserCallBack(RemoteServices.GetAllVillageOwnerFactions_UserCallBack callback)
		{
			this.getAllVillageOwnerFactions_UserCallBack = callback;
		}

		// Token: 0x06001F58 RID: 8024 RVA: 0x001DF468 File Offset: 0x001DD668
		public void GetAllVillageOwnerFactions()
		{
			if (this.GetAllVillageOwnerFactions_Callback == null)
			{
				this.GetAllVillageOwnerFactions_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetAllVillageOwnerFactions);
			}
			RemoteServices.RemoteAsyncDelegate_GetAllVillageOwnerFactions remoteAsyncDelegate_GetAllVillageOwnerFactions = new RemoteServices.RemoteAsyncDelegate_GetAllVillageOwnerFactions(this.service.GetAllVillageOwnerFactions);
			this.GetAllVillageOwnerFactions_ValidDownload = false;
			this.GetAllVillageOwnerFactions_Index++;
			this.registerRPCcall(remoteAsyncDelegate_GetAllVillageOwnerFactions.BeginInvoke(this.UserID, this.SessionID, this.GetAllVillageOwnerFactions_Index, this.GetAllVillageOwnerFactions_Callback, null), typeof(GetAllVillageOwnerFactions_ReturnType));
		}

		// Token: 0x06001F59 RID: 8025 RVA: 0x001DF4E8 File Offset: 0x001DD6E8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetAllVillageOwnerFactions(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetAllVillageOwnerFactions remoteAsyncDelegate_GetAllVillageOwnerFactions = (RemoteServices.RemoteAsyncDelegate_GetAllVillageOwnerFactions)((AsyncResult)ar).AsyncDelegate;
			try
			{
				GetAllVillageOwnerFactions_ReturnType getAllVillageOwnerFactions_ReturnType = remoteAsyncDelegate_GetAllVillageOwnerFactions.EndInvoke(ar);
				if (getAllVillageOwnerFactions_ReturnType.sendIndex == this.GetAllVillageOwnerFactions_Index)
				{
					this.GetAllVillageOwnerFactions_ValidDownload = true;
					this.storeRPCresult(ar, getAllVillageOwnerFactions_ReturnType);
				}
				else
				{
					this.removeRPCresult(ar);
				}
			}
			catch (Exception e)
			{
				GetAllVillageOwnerFactions_ReturnType returnData = new GetAllVillageOwnerFactions_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F5A RID: 8026 RVA: 0x0001DA5A File Offset: 0x0001BC5A
		public void set_GetVillageFactionChanges_UserCallBack(RemoteServices.GetVillageFactionChanges_UserCallBack callback)
		{
			this.getVillageFactionChanges_UserCallBack = callback;
		}

		// Token: 0x06001F5B RID: 8027 RVA: 0x001DF558 File Offset: 0x001DD758
		public void GetVillageFactionChanges(long startChangePos, long factionsChangePos)
		{
			if (startChangePos < -1L)
			{
				startChangePos = -1L;
			}
			if (factionsChangePos < -1L)
			{
				factionsChangePos = -1L;
			}
			if (this.GetVillageFactionChanges_Callback == null)
			{
				this.GetVillageFactionChanges_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageFactionChanges);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageFactionChanges remoteAsyncDelegate_GetVillageFactionChanges = new RemoteServices.RemoteAsyncDelegate_GetVillageFactionChanges(this.service.GetVillageFactionChanges);
			this.GetVillageFactionChanges_ValidDownload = false;
			this.GetVillageFactionChanges_Index++;
			this.registerRPCcall(remoteAsyncDelegate_GetVillageFactionChanges.BeginInvoke(this.UserID, this.SessionID, startChangePos, factionsChangePos, this.GetVillageFactionChanges_Index, this.GetVillageFactionChanges_Callback, null), typeof(GetVillageFactionChanges_ReturnType));
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x001DF5EC File Offset: 0x001DD7EC
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageFactionChanges(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageFactionChanges remoteAsyncDelegate_GetVillageFactionChanges = (RemoteServices.RemoteAsyncDelegate_GetVillageFactionChanges)((AsyncResult)ar).AsyncDelegate;
			try
			{
				GetVillageFactionChanges_ReturnType getVillageFactionChanges_ReturnType = remoteAsyncDelegate_GetVillageFactionChanges.EndInvoke(ar);
				if (getVillageFactionChanges_ReturnType.sendIndex == this.GetVillageFactionChanges_Index)
				{
					this.GetVillageFactionChanges_ValidDownload = true;
					this.storeRPCresult(ar, getVillageFactionChanges_ReturnType);
				}
				else
				{
					this.removeRPCresult(ar);
				}
			}
			catch (Exception e)
			{
				GetVillageFactionChanges_ReturnType returnData = new GetVillageFactionChanges_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x0001DA63 File Offset: 0x0001BC63
		public void set_GetVillageNames_UserCallBack(RemoteServices.GetVillageNames_UserCallBack callback)
		{
			this.getVillageNames_UserCallBack = callback;
		}

		// Token: 0x06001F5E RID: 8030 RVA: 0x001DF65C File Offset: 0x001DD85C
		public void GetVillageNames(long changePos)
		{
			if (this.GetVillageNames_Callback == null)
			{
				this.GetVillageNames_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageNames);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageNames remoteAsyncDelegate_GetVillageNames = new RemoteServices.RemoteAsyncDelegate_GetVillageNames(this.service.GetVillageNames);
			this.GetVillageNames_ValidDownload = false;
			this.GetVillageNames_Index++;
			this.registerRPCcall(remoteAsyncDelegate_GetVillageNames.BeginInvoke(this.UserID, this.SessionID, changePos, this.GetVillageNames_Index, this.GetVillageNames_Callback, null), typeof(GetVillageNames_ReturnType));
		}

		// Token: 0x06001F5F RID: 8031 RVA: 0x001DF6DC File Offset: 0x001DD8DC
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageNames(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageNames remoteAsyncDelegate_GetVillageNames = (RemoteServices.RemoteAsyncDelegate_GetVillageNames)((AsyncResult)ar).AsyncDelegate;
			try
			{
				GetVillageNames_ReturnType getVillageNames_ReturnType = remoteAsyncDelegate_GetVillageNames.EndInvoke(ar);
				if (getVillageNames_ReturnType.sendIndex == this.GetVillageNames_Index)
				{
					this.GetVillageNames_ValidDownload = true;
					this.storeRPCresult(ar, getVillageNames_ReturnType);
				}
				else
				{
					this.removeRPCresult(ar);
				}
			}
			catch (Exception e)
			{
				GetVillageNames_ReturnType returnData = new GetVillageNames_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F60 RID: 8032 RVA: 0x0001DA6C File Offset: 0x0001BC6C
		public void set_GetAreaFactionChanges_UserCallBack(RemoteServices.GetAreaFactionChanges_UserCallBack callback)
		{
			this.getAreaFactionChanges_UserCallBack = callback;
		}

		// Token: 0x06001F61 RID: 8033 RVA: 0x001DF74C File Offset: 0x001DD94C
		public void GetAreaFactionChanges(long regionStartPos, long countyStartPos, long provinceStartPos, long countryStartPos, long parishFlagsPos, long countyFlagsPos, long provinceFlagsPos, long countryFlagsPos)
		{
			if (regionStartPos < -1L)
			{
				regionStartPos = -1L;
			}
			if (countyStartPos < -1L)
			{
				countyStartPos = -1L;
			}
			if (provinceStartPos < -1L)
			{
				provinceStartPos = -1L;
			}
			if (countryStartPos < -1L)
			{
				countryStartPos = -1L;
			}
			if (this.GetAreaFactionChanges_Callback == null)
			{
				this.GetAreaFactionChanges_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetAreaFactionChanges);
			}
			RemoteServices.RemoteAsyncDelegate_GetAreaFactionChanges remoteAsyncDelegate_GetAreaFactionChanges = new RemoteServices.RemoteAsyncDelegate_GetAreaFactionChanges(this.service.GetAreaFactionChanges);
			this.registerRPCcall(remoteAsyncDelegate_GetAreaFactionChanges.BeginInvoke(this.UserID, this.SessionID, regionStartPos, countyStartPos, provinceStartPos, countryStartPos, parishFlagsPos, countyFlagsPos, provinceFlagsPos, countryFlagsPos, this.GetAreaFactionChanges_Callback, null), typeof(GetAreaFactionChanges_ReturnType));
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x001DF7E4 File Offset: 0x001DD9E4
		[OneWay]
		public void OurRemoteAsyncCallBack_GetAreaFactionChanges(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetAreaFactionChanges remoteAsyncDelegate_GetAreaFactionChanges = (RemoteServices.RemoteAsyncDelegate_GetAreaFactionChanges)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetAreaFactionChanges.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetAreaFactionChanges_ReturnType returnData = new GetAreaFactionChanges_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F63 RID: 8035 RVA: 0x0001DA75 File Offset: 0x0001BC75
		public void set_GetUserVillages_UserCallBack(RemoteServices.GetUserVillages_UserCallBack callback)
		{
			this.getUserVillages_UserCallBack = callback;
		}

		// Token: 0x06001F64 RID: 8036 RVA: 0x001DF834 File Offset: 0x001DDA34
		public void GetUserVillages()
		{
			if (this.GetUserVillages_Callback == null)
			{
				this.GetUserVillages_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserVillages);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserVillages remoteAsyncDelegate_GetUserVillages = new RemoteServices.RemoteAsyncDelegate_GetUserVillages(this.service.GetUserVillages);
			this.registerRPCcall(remoteAsyncDelegate_GetUserVillages.BeginInvoke(this.UserID, this.SessionID, this.GetUserVillages_Callback, null), typeof(GetUserVillages_ReturnType));
		}

		// Token: 0x06001F65 RID: 8037 RVA: 0x001DF898 File Offset: 0x001DDA98
		[OneWay]
		public void OurRemoteAsyncCallBack_GetUserVillages(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetUserVillages remoteAsyncDelegate_GetUserVillages = (RemoteServices.RemoteAsyncDelegate_GetUserVillages)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetUserVillages.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetUserVillages_ReturnType returnData = new GetUserVillages_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F66 RID: 8038 RVA: 0x0001DA7E File Offset: 0x0001BC7E
		public void set_GetOtherUserVillageIDList_UserCallBack(RemoteServices.GetOtherUserVillageIDList_UserCallBack callback)
		{
			this.getOtherUserVillageIDList_UserCallBack = callback;
		}

		// Token: 0x06001F67 RID: 8039 RVA: 0x001DF8E8 File Offset: 0x001DDAE8
		public void GetOtherUserVillageIDList(string targetUser)
		{
			if (this.GetOtherUserVillageIDList_Callback == null)
			{
				this.GetOtherUserVillageIDList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetOtherUserVillageIDList);
			}
			RemoteServices.RemoteAsyncDelegate_GetOtherUserVillageIDList remoteAsyncDelegate_GetOtherUserVillageIDList = new RemoteServices.RemoteAsyncDelegate_GetOtherUserVillageIDList(this.service.GetOtherUserVillageIDList);
			this.registerRPCcall(remoteAsyncDelegate_GetOtherUserVillageIDList.BeginInvoke(this.UserID, targetUser, this.SessionID, this.GetOtherUserVillageIDList_Callback, null), typeof(GetOtherUserVillageIDList_ReturnType));
		}

		// Token: 0x06001F68 RID: 8040 RVA: 0x001DF94C File Offset: 0x001DDB4C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetOtherUserVillageIDList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetOtherUserVillageIDList remoteAsyncDelegate_GetOtherUserVillageIDList = (RemoteServices.RemoteAsyncDelegate_GetOtherUserVillageIDList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetOtherUserVillageIDList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetOtherUserVillageIDList_ReturnType returnData = new GetOtherUserVillageIDList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x0001DA87 File Offset: 0x0001BC87
		public void set_BuyVillage_UserCallBack(RemoteServices.BuyVillage_UserCallBack callback)
		{
			this.buyVillage_UserCallBack = callback;
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x001DF99C File Offset: 0x001DDB9C
		public void BuyVillage(int fromVillageID, int villageID, int mapType, long startChangePos, bool peaceTime)
		{
			if (this.BuyVillage_Callback == null)
			{
				this.BuyVillage_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_BuyVillage);
			}
			RemoteServices.RemoteAsyncDelegate_BuyVillage remoteAsyncDelegate_BuyVillage = new RemoteServices.RemoteAsyncDelegate_BuyVillage(this.service.BuyVillage);
			this.registerRPCcall(remoteAsyncDelegate_BuyVillage.BeginInvoke(this.UserID, this.SessionID, fromVillageID, villageID, mapType, startChangePos, peaceTime, this.BuyVillage_Callback, null), typeof(BuyVillage_ReturnType));
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x001DFA08 File Offset: 0x001DDC08
		[OneWay]
		public void OurRemoteAsyncCallBack_BuyVillage(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_BuyVillage remoteAsyncDelegate_BuyVillage = (RemoteServices.RemoteAsyncDelegate_BuyVillage)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_BuyVillage.EndInvoke(ar));
			}
			catch (Exception e)
			{
				BuyVillage_ReturnType returnData = new BuyVillage_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x0001DA90 File Offset: 0x0001BC90
		public void set_ConvertVillage_UserCallBack(RemoteServices.ConvertVillage_UserCallBack callback)
		{
			this.convertVillage_UserCallBack = callback;
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x001DFA58 File Offset: 0x001DDC58
		public void ConvertVillage(int villageID, int mapType)
		{
			if (this.ConvertVillage_Callback == null)
			{
				this.ConvertVillage_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ConvertVillage);
			}
			RemoteServices.RemoteAsyncDelegate_ConvertVillage remoteAsyncDelegate_ConvertVillage = new RemoteServices.RemoteAsyncDelegate_ConvertVillage(this.service.ConvertVillage);
			this.registerRPCcall(remoteAsyncDelegate_ConvertVillage.BeginInvoke(this.UserID, this.SessionID, villageID, mapType, this.ConvertVillage_Callback, null), typeof(ConvertVillage_ReturnType));
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x001DFAC0 File Offset: 0x001DDCC0
		[OneWay]
		public void OurRemoteAsyncCallBack_ConvertVillage(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ConvertVillage remoteAsyncDelegate_ConvertVillage = (RemoteServices.RemoteAsyncDelegate_ConvertVillage)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ConvertVillage.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ConvertVillage_ReturnType returnData = new ConvertVillage_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x0001DA99 File Offset: 0x0001BC99
		public void set_FullTick_UserCallBack(RemoteServices.FullTick_UserCallBack callback)
		{
			this.fullTick_UserCallBack = callback;
		}

		// Token: 0x06001F70 RID: 8048 RVA: 0x001DFB10 File Offset: 0x001DDD10
		public void FullTick(long startChangePos, long regionStartPos, long countyStartPos, long provinceStartPos, long countryStartPos, bool registerSession, long villageNamePos, long factionsChangePos, DateTime lastTraderTime, DateTime lastPeopleTime, long parishFlagsPos, long countyFlagsPos, long provinceFlagsPos, long countryFlagsPos, long highestArmyID, int mode, bool fullMode)
		{
			if (this.FullTick_Callback == null)
			{
				this.FullTick_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FullTick);
			}
			RemoteServices.RemoteAsyncDelegate_FullTick remoteAsyncDelegate_FullTick = new RemoteServices.RemoteAsyncDelegate_FullTick(this.service.FullTick);
			this.registerRPCcall(remoteAsyncDelegate_FullTick.BeginInvoke(this.UserID, this.SessionID, startChangePos, regionStartPos, countyStartPos, provinceStartPos, countryStartPos, registerSession, villageNamePos, factionsChangePos, lastTraderTime, lastPeopleTime, parishFlagsPos, countyFlagsPos, provinceFlagsPos, countryFlagsPos, highestArmyID, mode, fullMode, this.FullTick_Callback, null), typeof(FullTick_ReturnType));
		}

		// Token: 0x06001F71 RID: 8049 RVA: 0x001DFB94 File Offset: 0x001DDD94
		[OneWay]
		public void OurRemoteAsyncCallBack_FullTick(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FullTick remoteAsyncDelegate_FullTick = (RemoteServices.RemoteAsyncDelegate_FullTick)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FullTick.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FullTick_ReturnType returnData = new FullTick_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F72 RID: 8050 RVA: 0x0001DAA2 File Offset: 0x0001BCA2
		public void set_LeaderBoard_UserCallBack(RemoteServices.LeaderBoard_UserCallBack callback)
		{
			this.leaderBoard_UserCallBack = callback;
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x001DFBE4 File Offset: 0x001DDDE4
		public void LeaderBoard(int mode)
		{
			if (this.LeaderBoard_Callback == null)
			{
				this.LeaderBoard_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LeaderBoard);
			}
			RemoteServices.RemoteAsyncDelegate_LeaderBoard remoteAsyncDelegate_LeaderBoard = new RemoteServices.RemoteAsyncDelegate_LeaderBoard(this.service.LeaderBoard);
			this.registerRPCcall(remoteAsyncDelegate_LeaderBoard.BeginInvoke(this.UserID, this.SessionID, mode, -1, -1, DateTime.MinValue, this.LeaderBoard_Callback, null), typeof(LeaderBoard_ReturnType));
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x001DFC50 File Offset: 0x001DDE50
		public void LeaderBoard(int mode, int minValue, int maxValue, DateTime lastUpdate)
		{
			if (this.LeaderBoard_Callback == null)
			{
				this.LeaderBoard_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LeaderBoard);
			}
			RemoteServices.RemoteAsyncDelegate_LeaderBoard remoteAsyncDelegate_LeaderBoard = new RemoteServices.RemoteAsyncDelegate_LeaderBoard(this.service.LeaderBoard);
			this.registerRPCcall(remoteAsyncDelegate_LeaderBoard.BeginInvoke(this.UserID, this.SessionID, mode, minValue, maxValue, lastUpdate, this.LeaderBoard_Callback, null), typeof(LeaderBoard_ReturnType));
		}

		// Token: 0x06001F75 RID: 8053 RVA: 0x001DFCB8 File Offset: 0x001DDEB8
		[OneWay]
		public void OurRemoteAsyncCallBack_LeaderBoard(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LeaderBoard remoteAsyncDelegate_LeaderBoard = (RemoteServices.RemoteAsyncDelegate_LeaderBoard)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LeaderBoard.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LeaderBoard_ReturnType returnData = new LeaderBoard_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F76 RID: 8054 RVA: 0x0001DAAB File Offset: 0x0001BCAB
		public void set_LeaderBoardSearch_UserCallBack(RemoteServices.LeaderBoardSearch_UserCallBack callback)
		{
			this.leaderBoardSearch_UserCallBack = callback;
		}

		// Token: 0x06001F77 RID: 8055 RVA: 0x001DFD08 File Offset: 0x001DDF08
		public void LeaderBoardSearch(int mode, string searchString, DateTime lastUpdate)
		{
			if (this.LeaderBoardSearch_Callback == null)
			{
				this.LeaderBoardSearch_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LeaderBoardSearch);
			}
			RemoteServices.RemoteAsyncDelegate_LeaderBoardSearch remoteAsyncDelegate_LeaderBoardSearch = new RemoteServices.RemoteAsyncDelegate_LeaderBoardSearch(this.service.LeaderBoardSearch);
			this.registerRPCcall(remoteAsyncDelegate_LeaderBoardSearch.BeginInvoke(this.UserID, this.SessionID, mode, searchString, lastUpdate, this.LeaderBoardSearch_Callback, null), typeof(LeaderBoardSearch_ReturnType));
		}

		// Token: 0x06001F78 RID: 8056 RVA: 0x001DFD70 File Offset: 0x001DDF70
		[OneWay]
		public void OurRemoteAsyncCallBack_LeaderBoardSearch(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LeaderBoardSearch remoteAsyncDelegate_LeaderBoardSearch = (RemoteServices.RemoteAsyncDelegate_LeaderBoardSearch)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LeaderBoardSearch.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LeaderBoardSearch_ReturnType returnData = new LeaderBoardSearch_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F79 RID: 8057 RVA: 0x0001DAB4 File Offset: 0x0001BCB4
		public void set_LogOut_UserCallBack(RemoteServices.LogOut_UserCallBack callback)
		{
			this.logOut_UserCallBack = callback;
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x001DFDC0 File Offset: 0x001DDFC0
		public void LogOut(bool manual, bool autoScout, bool autoTrade, bool autoAttack, bool autoAttackWolf, bool autoAttackBandit, bool autoAttackAI, int resourceType, int percent, bool autoRecruit, bool autoRecruitPeasant, bool autoRecruitArchers, bool autoRecruitPikemen, bool autoRecruitSwordsmen, bool autoRecruitCatapults, int autoRecruitPeasant_Cap, int autoRecruitArchers_Cap, int autoRecruitPikemen_Cap, int autoRecruitSwordsmen_Cap, int autoRecruitCatapults_Cap)
		{
			if (this.service != null)
			{
				if (this.LogOut_Callback == null)
				{
					this.LogOut_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LogOut);
				}
				RemoteServices.RemoteAsyncDelegate_LogOut remoteAsyncDelegate_LogOut = new RemoteServices.RemoteAsyncDelegate_LogOut(this.service.LogOut);
				this.registerRPCcall(remoteAsyncDelegate_LogOut.BeginInvoke(this.UserID, this.SessionID, manual, autoScout, autoTrade, autoAttack, autoAttackWolf, autoAttackBandit, autoAttackAI, resourceType, percent, autoRecruit, autoRecruitPeasant, autoRecruitArchers, autoRecruitPikemen, autoRecruitSwordsmen, autoRecruitCatapults, autoRecruitPeasant_Cap, autoRecruitArchers_Cap, autoRecruitPikemen_Cap, autoRecruitSwordsmen_Cap, autoRecruitCatapults_Cap, this.LogOut_Callback, null), typeof(LogOut_ReturnType));
			}
		}

		// Token: 0x06001F7B RID: 8059 RVA: 0x001DFE50 File Offset: 0x001DE050
		[OneWay]
		public void OurRemoteAsyncCallBack_LogOut(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LogOut remoteAsyncDelegate_LogOut = (RemoteServices.RemoteAsyncDelegate_LogOut)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LogOut.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LogOut_ReturnType returnData = new LogOut_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x0001DABD File Offset: 0x0001BCBD
		public void set_GetLoginHistory_UserCallBack(RemoteServices.GetLoginHistory_UserCallBack callback)
		{
			this.getLoginHistory_UserCallBack = callback;
		}

		// Token: 0x06001F7D RID: 8061 RVA: 0x001DFEA0 File Offset: 0x001DE0A0
		public void GetLoginHistory()
		{
			if (this.GetLoginHistory_Callback == null)
			{
				this.GetLoginHistory_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetLoginHistory);
			}
			RemoteServices.RemoteAsyncDelegate_GetLoginHistory remoteAsyncDelegate_GetLoginHistory = new RemoteServices.RemoteAsyncDelegate_GetLoginHistory(this.service.GetLoginHistory);
			this.registerRPCcall(remoteAsyncDelegate_GetLoginHistory.BeginInvoke(this.UserID, this.SessionID, this.GetLoginHistory_Callback, null), typeof(GetLoginHistory_ReturnType));
		}

		// Token: 0x06001F7E RID: 8062 RVA: 0x001DFF04 File Offset: 0x001DE104
		[OneWay]
		public void OurRemoteAsyncCallBack_GetLoginHistory(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetLoginHistory remoteAsyncDelegate_GetLoginHistory = (RemoteServices.RemoteAsyncDelegate_GetLoginHistory)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetLoginHistory.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetLoginHistory_ReturnType returnData = new GetLoginHistory_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F7F RID: 8063 RVA: 0x0001DAC6 File Offset: 0x0001BCC6
		public void set_UserInfo_UserCallBack(RemoteServices.UserInfo_UserCallBack callback)
		{
			this.userInfo_UserCallBack = callback;
		}

		// Token: 0x06001F80 RID: 8064 RVA: 0x001DFF54 File Offset: 0x001DE154
		public void UserInfo(int requestedUser)
		{
			if (this.UserInfo_Callback == null)
			{
				this.UserInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UserInfo);
			}
			RemoteServices.RemoteAsyncDelegate_UserInfo remoteAsyncDelegate_UserInfo = new RemoteServices.RemoteAsyncDelegate_UserInfo(this.service.UserInfo);
			this.registerRPCcall(remoteAsyncDelegate_UserInfo.BeginInvoke(this.UserID, this.SessionID, requestedUser, this.UserInfo_Callback, null), typeof(UserInfo_ReturnType));
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x001DFFB8 File Offset: 0x001DE1B8
		[OneWay]
		public void OurRemoteAsyncCallBack_UserInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UserInfo remoteAsyncDelegate_UserInfo = (RemoteServices.RemoteAsyncDelegate_UserInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UserInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UserInfo_ReturnType returnData = new UserInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F82 RID: 8066 RVA: 0x0001DACF File Offset: 0x0001BCCF
		public void set_GetArmyData_UserCallBack(RemoteServices.GetArmyData_UserCallBack callback)
		{
			this.getArmyData_UserCallBack = callback;
		}

		// Token: 0x06001F83 RID: 8067 RVA: 0x001E0008 File Offset: 0x001DE208
		public void GetArmyData(long highestSeen)
		{
			if (this.GetArmyData_Callback == null)
			{
				this.GetArmyData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetArmyData);
			}
			RemoteServices.RemoteAsyncDelegate_GetArmyData remoteAsyncDelegate_GetArmyData = new RemoteServices.RemoteAsyncDelegate_GetArmyData(this.service.GetArmyData);
			this.registerRPCcall(remoteAsyncDelegate_GetArmyData.BeginInvoke(this.UserID, this.SessionID, highestSeen, this.GetArmyData_Callback, null), typeof(GetArmyData_ReturnType));
		}

		// Token: 0x06001F84 RID: 8068 RVA: 0x001E006C File Offset: 0x001DE26C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetArmyData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetArmyData remoteAsyncDelegate_GetArmyData = (RemoteServices.RemoteAsyncDelegate_GetArmyData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetArmyData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetArmyData_ReturnType returnData = new GetArmyData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F85 RID: 8069 RVA: 0x0001DAD8 File Offset: 0x0001BCD8
		public void set_ArmyAttack_UserCallBack(RemoteServices.ArmyAttack_UserCallBack callback)
		{
			this.armyAttack_UserCallBack = callback;
		}

		// Token: 0x06001F86 RID: 8070 RVA: 0x001E00BC File Offset: 0x001DE2BC
		public void ArmyAttack(int armyID, int targetVillage, int attackType)
		{
			if (this.ArmyAttack_Callback == null)
			{
				this.ArmyAttack_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ArmyAttack);
			}
			RemoteServices.RemoteAsyncDelegate_ArmyAttack remoteAsyncDelegate_ArmyAttack = new RemoteServices.RemoteAsyncDelegate_ArmyAttack(this.service.ArmyAttack);
			this.registerRPCcall(remoteAsyncDelegate_ArmyAttack.BeginInvoke(this.UserID, this.SessionID, armyID, targetVillage, attackType, this.ArmyAttack_Callback, null), typeof(ArmyAttack_ReturnType));
		}

		// Token: 0x06001F87 RID: 8071 RVA: 0x001E0124 File Offset: 0x001DE324
		[OneWay]
		public void OurRemoteAsyncCallBack_ArmyAttack(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ArmyAttack remoteAsyncDelegate_ArmyAttack = (RemoteServices.RemoteAsyncDelegate_ArmyAttack)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ArmyAttack.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ArmyAttack_ReturnType returnData = new ArmyAttack_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F88 RID: 8072 RVA: 0x0001DAE1 File Offset: 0x0001BCE1
		public void set_RetrieveAttackResult_UserCallBack(RemoteServices.RetrieveAttackResult_UserCallBack callback)
		{
			this.retrieveAttackResult_UserCallBack = callback;
		}

		// Token: 0x06001F89 RID: 8073 RVA: 0x001E0174 File Offset: 0x001DE374
		public void RetrieveAttackResult(long armyID, long startChangePos)
		{
			if (this.RetrieveAttackResult_Callback == null)
			{
				this.RetrieveAttackResult_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveAttackResult);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveAttackResult remoteAsyncDelegate_RetrieveAttackResult = new RemoteServices.RemoteAsyncDelegate_RetrieveAttackResult(this.service.RetrieveAttackResult);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveAttackResult.BeginInvoke(this.UserID, this.SessionID, armyID, startChangePos, this.RetrieveAttackResult_Callback, null), typeof(RetrieveAttackResult_ReturnType));
		}

		// Token: 0x06001F8A RID: 8074 RVA: 0x001E01DC File Offset: 0x001DE3DC
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveAttackResult(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveAttackResult remoteAsyncDelegate_RetrieveAttackResult = (RemoteServices.RemoteAsyncDelegate_RetrieveAttackResult)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveAttackResult.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveAttackResult_ReturnType returnData = new RetrieveAttackResult_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F8B RID: 8075 RVA: 0x0001DAEA File Offset: 0x0001BCEA
		public void set_SetAdminMessage_UserCallBack(RemoteServices.SetAdminMessage_UserCallBack callback)
		{
			this.setAdminMessage_UserCallBack = callback;
		}

		// Token: 0x06001F8C RID: 8076 RVA: 0x001E022C File Offset: 0x001DE42C
		public void SetAdminMessage(string message, int type)
		{
			if (this.SetAdminMessage_Callback == null)
			{
				this.SetAdminMessage_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SetAdminMessage);
			}
			RemoteServices.RemoteAsyncDelegate_SetAdminMessage remoteAsyncDelegate_SetAdminMessage = new RemoteServices.RemoteAsyncDelegate_SetAdminMessage(this.service.SetAdminMessage);
			this.registerRPCcall(remoteAsyncDelegate_SetAdminMessage.BeginInvoke(this.UserID, this.SessionID, message, type, this.SetAdminMessage_Callback, null), typeof(SetAdminMessage_ReturnType));
		}

		// Token: 0x06001F8D RID: 8077 RVA: 0x001E0294 File Offset: 0x001DE494
		[OneWay]
		public void OurRemoteAsyncCallBack_SetAdminMessage(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SetAdminMessage remoteAsyncDelegate_SetAdminMessage = (RemoteServices.RemoteAsyncDelegate_SetAdminMessage)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SetAdminMessage.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SetAdminMessage_ReturnType returnData = new SetAdminMessage_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F8E RID: 8078 RVA: 0x0001DAF3 File Offset: 0x0001BCF3
		public void set_CompleteVillageCastle_UserCallBack(RemoteServices.CompleteVillageCastle_UserCallBack callback)
		{
			this.completeVillageCastle_UserCallBack = callback;
		}

		// Token: 0x06001F8F RID: 8079 RVA: 0x001E02E4 File Offset: 0x001DE4E4
		public void CompleteVillageCastle(int villageID, int mode)
		{
			if (this.CompleteVillageCastle_Callback == null)
			{
				this.CompleteVillageCastle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CompleteVillageCastle);
			}
			RemoteServices.RemoteAsyncDelegate_CompleteVillageCastle remoteAsyncDelegate_CompleteVillageCastle = new RemoteServices.RemoteAsyncDelegate_CompleteVillageCastle(this.service.CompleteVillageCastle);
			this.registerRPCcall(remoteAsyncDelegate_CompleteVillageCastle.BeginInvoke(this.UserID, this.SessionID, villageID, mode, this.CompleteVillageCastle_Callback, null), typeof(CompleteVillageCastle_ReturnType));
		}

		// Token: 0x06001F90 RID: 8080 RVA: 0x001E034C File Offset: 0x001DE54C
		[OneWay]
		public void OurRemoteAsyncCallBack_CompleteVillageCastle(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CompleteVillageCastle remoteAsyncDelegate_CompleteVillageCastle = (RemoteServices.RemoteAsyncDelegate_CompleteVillageCastle)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CompleteVillageCastle.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CompleteVillageCastle_ReturnType returnData = new CompleteVillageCastle_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F91 RID: 8081 RVA: 0x0001DAFC File Offset: 0x0001BCFC
		public void set_RetrieveStats_UserCallBack(RemoteServices.RetrieveStats_UserCallBack callback)
		{
			this.retrieveStats_UserCallBack = callback;
		}

		// Token: 0x06001F92 RID: 8082 RVA: 0x001E039C File Offset: 0x001DE59C
		public void RetrieveStats()
		{
			if (this.RetrieveStats_Callback == null)
			{
				this.RetrieveStats_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveStats);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveStats remoteAsyncDelegate_RetrieveStats = new RemoteServices.RemoteAsyncDelegate_RetrieveStats(this.service.RetrieveStats);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveStats.BeginInvoke(this.UserID, this.SessionID, this.RetrieveStats_Callback, null), typeof(RetrieveStats_ReturnType));
		}

		// Token: 0x06001F93 RID: 8083 RVA: 0x001E0400 File Offset: 0x001DE600
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveStats(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveStats remoteAsyncDelegate_RetrieveStats = (RemoteServices.RemoteAsyncDelegate_RetrieveStats)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveStats.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveStats_ReturnType returnData = new RetrieveStats_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F94 RID: 8084 RVA: 0x0001DB05 File Offset: 0x0001BD05
		public void set_RetrieveStats2_UserCallBack(RemoteServices.RetrieveStats2_UserCallBack callback)
		{
			this.retrieveStats2_UserCallBack = callback;
		}

		// Token: 0x06001F95 RID: 8085 RVA: 0x001E0450 File Offset: 0x001DE650
		public void RetrieveStats2()
		{
			if (this.RetrieveStats2_Callback == null)
			{
				this.RetrieveStats2_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveStats2);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveStats2 remoteAsyncDelegate_RetrieveStats = new RemoteServices.RemoteAsyncDelegate_RetrieveStats2(this.service.RetrieveStats2);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveStats.BeginInvoke(this.UserID, this.SessionID, this.RetrieveStats2_Callback, null), typeof(RetrieveStats2_ReturnType));
		}

		// Token: 0x06001F96 RID: 8086 RVA: 0x001E04B4 File Offset: 0x001DE6B4
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveStats2(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveStats2 remoteAsyncDelegate_RetrieveStats = (RemoteServices.RemoteAsyncDelegate_RetrieveStats2)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveStats.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveStats2_ReturnType returnData = new RetrieveStats2_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F97 RID: 8087 RVA: 0x0001DB0E File Offset: 0x0001BD0E
		public void set_GetAdminStats_UserCallBack(RemoteServices.GetAdminStats_UserCallBack callback)
		{
			this.getAdminStats_UserCallBack = callback;
		}

		// Token: 0x06001F98 RID: 8088 RVA: 0x001E0504 File Offset: 0x001DE704
		public void GetAdminStats()
		{
			if (this.GetAdminStats_Callback == null)
			{
				this.GetAdminStats_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetAdminStats);
			}
			RemoteServices.RemoteAsyncDelegate_GetAdminStats remoteAsyncDelegate_GetAdminStats = new RemoteServices.RemoteAsyncDelegate_GetAdminStats(this.service.GetAdminStats);
			this.registerRPCcall(remoteAsyncDelegate_GetAdminStats.BeginInvoke(this.UserID, this.SessionID, this.GetAdminStats_Callback, null), typeof(GetAdminStats_ReturnType));
		}

		// Token: 0x06001F99 RID: 8089 RVA: 0x001E0568 File Offset: 0x001DE768
		[OneWay]
		public void OurRemoteAsyncCallBack_GetAdminStats(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetAdminStats remoteAsyncDelegate_GetAdminStats = (RemoteServices.RemoteAsyncDelegate_GetAdminStats)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetAdminStats.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetAdminStats_ReturnType returnData = new GetAdminStats_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F9A RID: 8090 RVA: 0x0001DB17 File Offset: 0x0001BD17
		public void set_GetReportsList_UserCallBack(RemoteServices.GetReportsList_UserCallBack callback)
		{
			this.getReportsList_UserCallBack = callback;
		}

		// Token: 0x06001F9B RID: 8091 RVA: 0x001E05B8 File Offset: 0x001DE7B8
		public void GetReportsList(int readFilter, long clientHighest)
		{
			if (this.GetReportsList_Callback == null)
			{
				this.GetReportsList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetReportsList);
			}
			RemoteServices.RemoteAsyncDelegate_GetReportsList remoteAsyncDelegate_GetReportsList = new RemoteServices.RemoteAsyncDelegate_GetReportsList(this.service.GetReportsList);
			this.registerRPCcall(remoteAsyncDelegate_GetReportsList.BeginInvoke(this.UserID, this.SessionID, readFilter, null, -1L, clientHighest, this.GetReportsList_Callback, null), typeof(GetReportsList_ReturnType));
		}

		// Token: 0x06001F9C RID: 8092 RVA: 0x001E0620 File Offset: 0x001DE820
		public void GetReportsList(int readFilter, int[] typeFilters, long folderID)
		{
			if (this.GetReportsList_Callback == null)
			{
				this.GetReportsList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetReportsList);
			}
			RemoteServices.RemoteAsyncDelegate_GetReportsList remoteAsyncDelegate_GetReportsList = new RemoteServices.RemoteAsyncDelegate_GetReportsList(this.service.GetReportsList);
			this.registerRPCcall(remoteAsyncDelegate_GetReportsList.BeginInvoke(this.UserID, this.SessionID, readFilter, typeFilters, folderID, -1L, this.GetReportsList_Callback, null), typeof(GetReportsList_ReturnType));
		}

		// Token: 0x06001F9D RID: 8093 RVA: 0x001E0688 File Offset: 0x001DE888
		[OneWay]
		public void OurRemoteAsyncCallBack_GetReportsList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetReportsList remoteAsyncDelegate_GetReportsList = (RemoteServices.RemoteAsyncDelegate_GetReportsList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetReportsList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetReportsList_ReturnType returnData = new GetReportsList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001F9E RID: 8094 RVA: 0x0001DB20 File Offset: 0x0001BD20
		public void set_GetReport_UserCallBack(RemoteServices.GetReport_UserCallBack callback)
		{
			this.getReport_UserCallBack = callback;
		}

		// Token: 0x06001F9F RID: 8095 RVA: 0x001E06D8 File Offset: 0x001DE8D8
		public void GetReport(long reportID)
		{
			if (this.GetReport_Callback == null)
			{
				this.GetReport_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetReport);
			}
			RemoteServices.RemoteAsyncDelegate_GetReport remoteAsyncDelegate_GetReport = new RemoteServices.RemoteAsyncDelegate_GetReport(this.service.GetReport);
			this.registerRPCcall(remoteAsyncDelegate_GetReport.BeginInvoke(this.UserID, this.SessionID, reportID, this.GetReport_Callback, null), typeof(GetReport_ReturnType));
		}

		// Token: 0x06001FA0 RID: 8096 RVA: 0x001E073C File Offset: 0x001DE93C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetReport(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetReport remoteAsyncDelegate_GetReport = (RemoteServices.RemoteAsyncDelegate_GetReport)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetReport.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetReport_ReturnType returnData = new GetReport_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FA1 RID: 8097 RVA: 0x0001DB29 File Offset: 0x0001BD29
		public void set_ForwardReport_UserCallBack(RemoteServices.ForwardReport_UserCallBack callback)
		{
			this.forwardReport_UserCallBack = callback;
		}

		// Token: 0x06001FA2 RID: 8098 RVA: 0x001E078C File Offset: 0x001DE98C
		public void ForwardReport(long reportID, string[] recipients)
		{
			if (this.ForwardReport_Callback == null)
			{
				this.ForwardReport_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ForwardReport);
			}
			RemoteServices.RemoteAsyncDelegate_ForwardReport remoteAsyncDelegate_ForwardReport = new RemoteServices.RemoteAsyncDelegate_ForwardReport(this.service.ForwardReport);
			this.registerRPCcall(remoteAsyncDelegate_ForwardReport.BeginInvoke(this.UserID, this.SessionID, reportID, recipients, this.ForwardReport_Callback, null), typeof(ForwardReport_ReturnType));
		}

		// Token: 0x06001FA3 RID: 8099 RVA: 0x001E07F4 File Offset: 0x001DE9F4
		[OneWay]
		public void OurRemoteAsyncCallBack_ForwardReport(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ForwardReport remoteAsyncDelegate_ForwardReport = (RemoteServices.RemoteAsyncDelegate_ForwardReport)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ForwardReport.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ForwardReport_ReturnType returnData = new ForwardReport_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FA4 RID: 8100 RVA: 0x0001DB32 File Offset: 0x0001BD32
		public void set_ViewBattle_UserCallBack(RemoteServices.ViewBattle_UserCallBack callback)
		{
			this.viewBattle_UserCallBack = callback;
		}

		// Token: 0x06001FA5 RID: 8101 RVA: 0x001E0844 File Offset: 0x001DEA44
		public void ViewBattle(long reportID)
		{
			if (this.ViewBattle_Callback == null)
			{
				this.ViewBattle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ViewBattle);
			}
			RemoteServices.RemoteAsyncDelegate_ViewBattle remoteAsyncDelegate_ViewBattle = new RemoteServices.RemoteAsyncDelegate_ViewBattle(this.service.ViewBattle);
			this.registerRPCcall(remoteAsyncDelegate_ViewBattle.BeginInvoke(this.UserID, this.SessionID, reportID, this.ViewBattle_Callback, null), typeof(ViewBattle_ReturnType));
		}

		// Token: 0x06001FA6 RID: 8102 RVA: 0x001E08A8 File Offset: 0x001DEAA8
		[OneWay]
		public void OurRemoteAsyncCallBack_ViewBattle(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ViewBattle remoteAsyncDelegate_ViewBattle = (RemoteServices.RemoteAsyncDelegate_ViewBattle)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ViewBattle.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ViewBattle_ReturnType returnData = new ViewBattle_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FA7 RID: 8103 RVA: 0x0001DB3B File Offset: 0x0001BD3B
		public void set_ViewCastle_UserCallBack(RemoteServices.ViewCastle_UserCallBack callback)
		{
			this.viewCastle_UserCallBack = callback;
		}

		// Token: 0x06001FA8 RID: 8104 RVA: 0x001E08F8 File Offset: 0x001DEAF8
		public void ViewCastle_Report(long reportID)
		{
			if (this.ViewCastle_Callback == null)
			{
				this.ViewCastle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ViewCastle);
			}
			RemoteServices.RemoteAsyncDelegate_ViewCastle remoteAsyncDelegate_ViewCastle = new RemoteServices.RemoteAsyncDelegate_ViewCastle(this.service.ViewCastle);
			this.registerRPCcall(remoteAsyncDelegate_ViewCastle.BeginInvoke(this.UserID, this.SessionID, -1, reportID, this.ViewCastle_Callback, null), typeof(ViewCastle_ReturnType));
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x001E0960 File Offset: 0x001DEB60
		public void ViewCastle_Village(int villageID)
		{
			if (this.ViewCastle_Callback == null)
			{
				this.ViewCastle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ViewCastle);
			}
			RemoteServices.RemoteAsyncDelegate_ViewCastle remoteAsyncDelegate_ViewCastle = new RemoteServices.RemoteAsyncDelegate_ViewCastle(this.service.ViewCastle);
			this.registerRPCcall(remoteAsyncDelegate_ViewCastle.BeginInvoke(this.UserID, this.SessionID, villageID, -1L, this.ViewCastle_Callback, null), typeof(ViewCastle_ReturnType));
		}

		// Token: 0x06001FAA RID: 8106 RVA: 0x001E09C8 File Offset: 0x001DEBC8
		[OneWay]
		public void OurRemoteAsyncCallBack_ViewCastle(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ViewCastle remoteAsyncDelegate_ViewCastle = (RemoteServices.RemoteAsyncDelegate_ViewCastle)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ViewCastle.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ViewCastle_ReturnType returnData = new ViewCastle_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FAB RID: 8107 RVA: 0x0001DB44 File Offset: 0x0001BD44
		public void set_DeleteOrMoveReports_UserCallBack(RemoteServices.DeleteReports_UserCallBack callback)
		{
			this.deleteReports_UserCallBack = callback;
		}

		// Token: 0x06001FAC RID: 8108 RVA: 0x001E0A18 File Offset: 0x001DEC18
		public void DeleteReports(long[] reportsToDelete)
		{
			if (this.DeleteReports_Callback == null)
			{
				this.DeleteReports_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteReports);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteReports remoteAsyncDelegate_DeleteReports = new RemoteServices.RemoteAsyncDelegate_DeleteReports(this.service.DeleteOrMoveReports);
			this.registerRPCcall(remoteAsyncDelegate_DeleteReports.BeginInvoke(this.UserID, this.SessionID, 0, reportsToDelete, -1L, this.DeleteReports_Callback, null), typeof(DeleteReports_ReturnType));
		}

		// Token: 0x06001FAD RID: 8109 RVA: 0x001E0A80 File Offset: 0x001DEC80
		public void MoveReports(long[] reportsToDelete, long folderID)
		{
			if (this.DeleteReports_Callback == null)
			{
				this.DeleteReports_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteReports);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteReports remoteAsyncDelegate_DeleteReports = new RemoteServices.RemoteAsyncDelegate_DeleteReports(this.service.DeleteOrMoveReports);
			this.registerRPCcall(remoteAsyncDelegate_DeleteReports.BeginInvoke(this.UserID, this.SessionID, 1, reportsToDelete, folderID, this.DeleteReports_Callback, null), typeof(DeleteReports_ReturnType));
		}

		// Token: 0x06001FAE RID: 8110 RVA: 0x001E0AE8 File Offset: 0x001DECE8
		public void MarkReportsRead(long[] reportsToMark)
		{
			if (this.DeleteReports_Callback == null)
			{
				this.DeleteReports_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteReports);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteReports remoteAsyncDelegate_DeleteReports = new RemoteServices.RemoteAsyncDelegate_DeleteReports(this.service.DeleteOrMoveReports);
			this.registerRPCcall(remoteAsyncDelegate_DeleteReports.BeginInvoke(this.UserID, this.SessionID, 2, reportsToMark, -1L, this.DeleteReports_Callback, null), typeof(DeleteReports_ReturnType));
		}

		// Token: 0x06001FAF RID: 8111 RVA: 0x001E0B50 File Offset: 0x001DED50
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteReports(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteReports remoteAsyncDelegate_DeleteReports = (RemoteServices.RemoteAsyncDelegate_DeleteReports)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteReports.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteReports_ReturnType returnData = new DeleteReports_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FB0 RID: 8112 RVA: 0x0001DB4D File Offset: 0x0001BD4D
		public void set_UpdateReportFilters_UserCallBack(RemoteServices.UpdateReportFilters_UserCallBack callback)
		{
			this.updateReportFilters_UserCallBack = callback;
		}

		// Token: 0x06001FB1 RID: 8113 RVA: 0x001E0BA0 File Offset: 0x001DEDA0
		public void UpdateReportFilters(ReportFilterList filters)
		{
			if (this.UpdateReportFilters_Callback == null)
			{
				this.UpdateReportFilters_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateReportFilters);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateReportFilters remoteAsyncDelegate_UpdateReportFilters = new RemoteServices.RemoteAsyncDelegate_UpdateReportFilters(this.service.UpdateReportFilters);
			this.registerRPCcall(remoteAsyncDelegate_UpdateReportFilters.BeginInvoke(this.UserID, this.SessionID, filters, this.UpdateReportFilters_Callback, null), typeof(UpdateReportFilters_ReturnType));
		}

		// Token: 0x06001FB2 RID: 8114 RVA: 0x001E0C04 File Offset: 0x001DEE04
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateReportFilters(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateReportFilters remoteAsyncDelegate_UpdateReportFilters = (RemoteServices.RemoteAsyncDelegate_UpdateReportFilters)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateReportFilters.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateReportFilters_ReturnType returnData = new UpdateReportFilters_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FB3 RID: 8115 RVA: 0x0001DB56 File Offset: 0x0001BD56
		public void set_UpdateUserOptions_UserCallBack(RemoteServices.UpdateUserOptions_UserCallBack callback)
		{
			this.updateUserOptions_UserCallBack = callback;
		}

		// Token: 0x06001FB4 RID: 8116 RVA: 0x001E0C54 File Offset: 0x001DEE54
		public void UpdateUserOptions(GameOptionsData options)
		{
			if (this.UpdateUserOptions_Callback == null)
			{
				this.UpdateUserOptions_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateUserOptions);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateUserOptions remoteAsyncDelegate_UpdateUserOptions = new RemoteServices.RemoteAsyncDelegate_UpdateUserOptions(this.service.UpdateUserOptions);
			this.registerRPCcall(remoteAsyncDelegate_UpdateUserOptions.BeginInvoke(this.UserID, this.SessionID, options, this.UpdateUserOptions_Callback, null), typeof(UpdateUserOptions_ReturnType));
		}

		// Token: 0x06001FB5 RID: 8117 RVA: 0x001E0CB8 File Offset: 0x001DEEB8
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateUserOptions(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateUserOptions remoteAsyncDelegate_UpdateUserOptions = (RemoteServices.RemoteAsyncDelegate_UpdateUserOptions)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateUserOptions.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateUserOptions_ReturnType returnData = new UpdateUserOptions_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FB6 RID: 8118 RVA: 0x0001DB5F File Offset: 0x0001BD5F
		public void set_ManageReportFolders_UserCallBack(RemoteServices.ManageReportFolders_UserCallBack callback)
		{
			this.manageReportFolders_UserCallBack = callback;
		}

		// Token: 0x06001FB7 RID: 8119 RVA: 0x001E0D08 File Offset: 0x001DEF08
		public void getReportFolders()
		{
			if (this.ManageReportFolders_Callback == null)
			{
				this.ManageReportFolders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ManageReportFolders);
			}
			RemoteServices.RemoteAsyncDelegate_ManageReportFolders remoteAsyncDelegate_ManageReportFolders = new RemoteServices.RemoteAsyncDelegate_ManageReportFolders(this.service.ManageReportFolders);
			this.registerRPCcall(remoteAsyncDelegate_ManageReportFolders.BeginInvoke(this.UserID, this.SessionID, 0, 0L, "", this.ManageReportFolders_Callback, null), typeof(ManageReportFolders_ReturnType));
		}

		// Token: 0x06001FB8 RID: 8120 RVA: 0x001E0D74 File Offset: 0x001DEF74
		public void addReportFolder(string folderName)
		{
			if (this.ManageReportFolders_Callback == null)
			{
				this.ManageReportFolders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ManageReportFolders);
			}
			RemoteServices.RemoteAsyncDelegate_ManageReportFolders remoteAsyncDelegate_ManageReportFolders = new RemoteServices.RemoteAsyncDelegate_ManageReportFolders(this.service.ManageReportFolders);
			this.registerRPCcall(remoteAsyncDelegate_ManageReportFolders.BeginInvoke(this.UserID, this.SessionID, 1, 0L, folderName, this.ManageReportFolders_Callback, null), typeof(ManageReportFolders_ReturnType));
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x001E0DDC File Offset: 0x001DEFDC
		public void deleteReportFolder(long folderID, int mode)
		{
			if (this.ManageReportFolders_Callback == null)
			{
				this.ManageReportFolders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ManageReportFolders);
			}
			RemoteServices.RemoteAsyncDelegate_ManageReportFolders remoteAsyncDelegate_ManageReportFolders = new RemoteServices.RemoteAsyncDelegate_ManageReportFolders(this.service.ManageReportFolders);
			this.registerRPCcall(remoteAsyncDelegate_ManageReportFolders.BeginInvoke(this.UserID, this.SessionID, mode, folderID, "", this.ManageReportFolders_Callback, null), typeof(ManageReportFolders_ReturnType));
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x001E0E48 File Offset: 0x001DF048
		[OneWay]
		public void OurRemoteAsyncCallBack_ManageReportFolders(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ManageReportFolders remoteAsyncDelegate_ManageReportFolders = (RemoteServices.RemoteAsyncDelegate_ManageReportFolders)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ManageReportFolders.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ManageReportFolders_ReturnType returnData = new ManageReportFolders_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FBB RID: 8123 RVA: 0x0001DB68 File Offset: 0x0001BD68
		public void set_GetMailThreadList_UserCallBack(RemoteServices.GetMailThreadList_UserCallBack callback)
		{
			this.getMailThreadList_UserCallBack = callback;
		}

		// Token: 0x06001FBC RID: 8124 RVA: 0x001E0E98 File Offset: 0x001DF098
		public void GetMailThreadList(bool initialRequest, int mode, DateTime lastRetrieved)
		{
			if (this.GetMailThreadList_Callback == null)
			{
				this.GetMailThreadList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetMailThreadList);
			}
			RemoteServices.RemoteAsyncDelegate_GetMailThreadList remoteAsyncDelegate_GetMailThreadList = new RemoteServices.RemoteAsyncDelegate_GetMailThreadList(this.service.GetMailThreadList);
			this.registerRPCcall(remoteAsyncDelegate_GetMailThreadList.BeginInvoke(this.UserID, this.SessionID, initialRequest, mode, lastRetrieved, this.GetMailThreadList_Callback, null), typeof(GetMailThreadList_ReturnType));
		}

		// Token: 0x06001FBD RID: 8125 RVA: 0x001E0F00 File Offset: 0x001DF100
		[OneWay]
		public void OurRemoteAsyncCallBack_GetMailThreadList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetMailThreadList remoteAsyncDelegate_GetMailThreadList = (RemoteServices.RemoteAsyncDelegate_GetMailThreadList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetMailThreadList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetMailThreadList_ReturnType returnData = new GetMailThreadList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FBE RID: 8126 RVA: 0x0001DB71 File Offset: 0x0001BD71
		public void set_GetMailThread_UserCallBack(RemoteServices.GetMailThread_UserCallBack callback)
		{
			this.getMailThread_UserCallBack = callback;
		}

		// Token: 0x06001FBF RID: 8127 RVA: 0x001E0F50 File Offset: 0x001DF150
		public void GetMailThread(long threadID, int localCount, long highestSegmentID)
		{
			if (this.GetMailThread_Callback == null)
			{
				this.GetMailThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetMailThread);
			}
			RemoteServices.RemoteAsyncDelegate_GetMailThread remoteAsyncDelegate_GetMailThread = new RemoteServices.RemoteAsyncDelegate_GetMailThread(this.service.GetMailThread);
			this.registerRPCcall(remoteAsyncDelegate_GetMailThread.BeginInvoke(this.UserID, this.SessionID, threadID, localCount, highestSegmentID, this.GetMailThread_Callback, null), typeof(GetMailThread_ReturnType));
		}

		// Token: 0x06001FC0 RID: 8128 RVA: 0x001E0FB8 File Offset: 0x001DF1B8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetMailThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetMailThread remoteAsyncDelegate_GetMailThread = (RemoteServices.RemoteAsyncDelegate_GetMailThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetMailThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetMailThread_ReturnType returnData = new GetMailThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FC1 RID: 8129 RVA: 0x0001DB7A File Offset: 0x0001BD7A
		public void set_GetMailFolders_UserCallBack(RemoteServices.GetMailFolders_UserCallBack callback)
		{
			this.getMailFolders_UserCallBack = callback;
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x001E1008 File Offset: 0x001DF208
		public void GetMailFolders()
		{
			if (this.GetMailFolders_Callback == null)
			{
				this.GetMailFolders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetMailFolders);
			}
			RemoteServices.RemoteAsyncDelegate_GetMailFolders remoteAsyncDelegate_GetMailFolders = new RemoteServices.RemoteAsyncDelegate_GetMailFolders(this.service.GetMailFolders);
			this.registerRPCcall(remoteAsyncDelegate_GetMailFolders.BeginInvoke(this.UserID, this.SessionID, this.GetMailFolders_Callback, null), typeof(GetMailFolders_ReturnType));
		}

		// Token: 0x06001FC3 RID: 8131 RVA: 0x001E106C File Offset: 0x001DF26C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetMailFolders(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetMailFolders remoteAsyncDelegate_GetMailFolders = (RemoteServices.RemoteAsyncDelegate_GetMailFolders)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetMailFolders.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetMailFolders_ReturnType returnData = new GetMailFolders_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x0001DB83 File Offset: 0x0001BD83
		public void set_CreateMailFolder_UserCallBack(RemoteServices.CreateMailFolder_UserCallBack callback)
		{
			this.createMailFolder_UserCallBack = callback;
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x001E10BC File Offset: 0x001DF2BC
		public void CreateMailFolder(string folderName)
		{
			if (this.CreateMailFolder_Callback == null)
			{
				this.CreateMailFolder_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateMailFolder);
			}
			RemoteServices.RemoteAsyncDelegate_CreateMailFolder remoteAsyncDelegate_CreateMailFolder = new RemoteServices.RemoteAsyncDelegate_CreateMailFolder(this.service.CreateMailFolder);
			this.registerRPCcall(remoteAsyncDelegate_CreateMailFolder.BeginInvoke(this.UserID, this.SessionID, folderName, this.CreateMailFolder_Callback, null), typeof(CreateMailFolder_ReturnType));
		}

		// Token: 0x06001FC6 RID: 8134 RVA: 0x001E1120 File Offset: 0x001DF320
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateMailFolder(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateMailFolder remoteAsyncDelegate_CreateMailFolder = (RemoteServices.RemoteAsyncDelegate_CreateMailFolder)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateMailFolder.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateMailFolder_ReturnType returnData = new CreateMailFolder_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x0001DB8C File Offset: 0x0001BD8C
		public void set_MoveToMailFolder_UserCallBack(RemoteServices.MoveToMailFolder_UserCallBack callback)
		{
			this.moveToMailFolder_UserCallBack = callback;
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x001E1170 File Offset: 0x001DF370
		public void MoveToMailFolder(long threadID, long folderID)
		{
			if (this.MoveToMailFolder_Callback == null)
			{
				this.MoveToMailFolder_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MoveToMailFolder);
			}
			RemoteServices.RemoteAsyncDelegate_MoveToMailFolder remoteAsyncDelegate_MoveToMailFolder = new RemoteServices.RemoteAsyncDelegate_MoveToMailFolder(this.service.MoveToMailFolder);
			this.registerRPCcall(remoteAsyncDelegate_MoveToMailFolder.BeginInvoke(this.UserID, this.SessionID, threadID, folderID, this.MoveToMailFolder_Callback, null), typeof(MoveToMailFolder_ReturnType));
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x001E11D8 File Offset: 0x001DF3D8
		[OneWay]
		public void OurRemoteAsyncCallBack_MoveToMailFolder(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MoveToMailFolder remoteAsyncDelegate_MoveToMailFolder = (RemoteServices.RemoteAsyncDelegate_MoveToMailFolder)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MoveToMailFolder.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MoveToMailFolder_ReturnType returnData = new MoveToMailFolder_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FCA RID: 8138 RVA: 0x0001DB95 File Offset: 0x0001BD95
		public void set_RemoveMailFolder_UserCallBack(RemoteServices.RemoveMailFolder_UserCallBack callback)
		{
			this.removeMailFolder_UserCallBack = callback;
		}

		// Token: 0x06001FCB RID: 8139 RVA: 0x001E1228 File Offset: 0x001DF428
		public void RemoveMailFolder(long folderID)
		{
			if (this.RemoveMailFolder_Callback == null)
			{
				this.RemoveMailFolder_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RemoveMailFolder);
			}
			RemoteServices.RemoteAsyncDelegate_RemoveMailFolder remoteAsyncDelegate_RemoveMailFolder = new RemoteServices.RemoteAsyncDelegate_RemoveMailFolder(this.service.RemoveMailFolder);
			this.registerRPCcall(remoteAsyncDelegate_RemoveMailFolder.BeginInvoke(this.UserID, this.SessionID, folderID, this.RemoveMailFolder_Callback, null), typeof(RemoveMailFolder_ReturnType));
		}

		// Token: 0x06001FCC RID: 8140 RVA: 0x001E128C File Offset: 0x001DF48C
		[OneWay]
		public void OurRemoteAsyncCallBack_RemoveMailFolder(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RemoveMailFolder remoteAsyncDelegate_RemoveMailFolder = (RemoteServices.RemoteAsyncDelegate_RemoveMailFolder)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RemoveMailFolder.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RemoveMailFolder_ReturnType returnData = new RemoveMailFolder_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FCD RID: 8141 RVA: 0x0001DB9E File Offset: 0x0001BD9E
		public void set_ReportMail_UserCallBack(RemoteServices.ReportMail_UserCallBack callback)
		{
			this.reportMail_UserCallBack = callback;
		}

		// Token: 0x06001FCE RID: 8142 RVA: 0x001E12DC File Offset: 0x001DF4DC
		public void ReportMail(long mailID, long threadID, string reason, string summary)
		{
			if (this.ReportMail_Callback == null)
			{
				this.ReportMail_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ReportMail);
			}
			RemoteServices.RemoteAsyncDelegate_ReportMail remoteAsyncDelegate_ReportMail = new RemoteServices.RemoteAsyncDelegate_ReportMail(this.service.ReportMail);
			this.registerRPCcall(remoteAsyncDelegate_ReportMail.BeginInvoke(this.UserID, this.SessionID, mailID, threadID, reason, summary, this.ReportMail_Callback, null), typeof(ReportMail_ReturnType));
		}

		// Token: 0x06001FCF RID: 8143 RVA: 0x001E1344 File Offset: 0x001DF544
		[OneWay]
		public void OurRemoteAsyncCallBack_ReportMail(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ReportMail remoteAsyncDelegate_ReportMail = (RemoteServices.RemoteAsyncDelegate_ReportMail)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ReportMail.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ReportMail_ReturnType returnData = new ReportMail_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FD0 RID: 8144 RVA: 0x0001DBA7 File Offset: 0x0001BDA7
		public void set_FlagMailRead_UserCallBack(RemoteServices.FlagMailRead_UserCallBack callback)
		{
			this.flagMailRead_UserCallBack = callback;
		}

		// Token: 0x06001FD1 RID: 8145 RVA: 0x001E1394 File Offset: 0x001DF594
		public void FlagMailRead(long mailID)
		{
			if (this.FlagMailRead_Callback == null)
			{
				this.FlagMailRead_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FlagMailRead);
			}
			RemoteServices.RemoteAsyncDelegate_FlagMailRead remoteAsyncDelegate_FlagMailRead = new RemoteServices.RemoteAsyncDelegate_FlagMailRead(this.service.FlagMailRead);
			this.registerRPCcall(remoteAsyncDelegate_FlagMailRead.BeginInvoke(this.UserID, this.SessionID, mailID, -1L, true, this.FlagMailRead_Callback, null), typeof(FlagMailRead_ReturnType));
		}

		// Token: 0x06001FD2 RID: 8146 RVA: 0x001E13FC File Offset: 0x001DF5FC
		public void FlagThreadRead(long threadID)
		{
			if (this.FlagMailRead_Callback == null)
			{
				this.FlagMailRead_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FlagMailRead);
			}
			RemoteServices.RemoteAsyncDelegate_FlagMailRead remoteAsyncDelegate_FlagMailRead = new RemoteServices.RemoteAsyncDelegate_FlagMailRead(this.service.FlagMailRead);
			this.registerRPCcall(remoteAsyncDelegate_FlagMailRead.BeginInvoke(this.UserID, this.SessionID, -1L, threadID, true, this.FlagMailRead_Callback, null), typeof(FlagMailRead_ReturnType));
		}

		// Token: 0x06001FD3 RID: 8147 RVA: 0x001E1464 File Offset: 0x001DF664
		public void FlagThreadUnread(long threadID)
		{
			if (this.FlagMailRead_Callback == null)
			{
				this.FlagMailRead_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FlagMailRead);
			}
			RemoteServices.RemoteAsyncDelegate_FlagMailRead remoteAsyncDelegate_FlagMailRead = new RemoteServices.RemoteAsyncDelegate_FlagMailRead(this.service.FlagMailRead);
			this.registerRPCcall(remoteAsyncDelegate_FlagMailRead.BeginInvoke(this.UserID, this.SessionID, -1L, threadID, false, this.FlagMailRead_Callback, null), typeof(FlagMailRead_ReturnType));
		}

		// Token: 0x06001FD4 RID: 8148 RVA: 0x001E14CC File Offset: 0x001DF6CC
		[OneWay]
		public void OurRemoteAsyncCallBack_FlagMailRead(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FlagMailRead remoteAsyncDelegate_FlagMailRead = (RemoteServices.RemoteAsyncDelegate_FlagMailRead)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FlagMailRead.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FlagMailRead_ReturnType returnData = new FlagMailRead_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x0001DBB0 File Offset: 0x0001BDB0
		public void set_SendMail_UserCallBack(RemoteServices.SendMail_UserCallBack callback)
		{
			this.sendMail_UserCallBack = callback;
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x001E151C File Offset: 0x001DF71C
		public void SendMail(string subject, string body, string[] recipients, long threadID, bool forwardThread)
		{
			if (this.SendMail_Callback == null)
			{
				this.SendMail_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendMail);
			}
			RemoteServices.RemoteAsyncDelegate_SendMail remoteAsyncDelegate_SendMail = new RemoteServices.RemoteAsyncDelegate_SendMail(this.service.SendMail);
			this.registerRPCcall(remoteAsyncDelegate_SendMail.BeginInvoke(this.UserID, this.SessionID, subject, body, recipients, threadID, forwardThread, this.SendMail_Callback, null), typeof(SendMail_ReturnType));
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x001E1588 File Offset: 0x001DF788
		[OneWay]
		public void OurRemoteAsyncCallBack_SendMail(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendMail remoteAsyncDelegate_SendMail = (RemoteServices.RemoteAsyncDelegate_SendMail)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendMail.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendMail_ReturnType returnData = new SendMail_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x0001DBB9 File Offset: 0x0001BDB9
		public void set_SendSpecialMail_UserCallBack(RemoteServices.SendSpecialMail_UserCallBack callback)
		{
			this.sendSpecialMail_UserCallBack = callback;
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x001E15D8 File Offset: 0x001DF7D8
		public void SendSpecialMail(int mailType, int area, string subject, string body)
		{
			if (this.SendSpecialMail_Callback == null)
			{
				this.SendSpecialMail_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendSpecialMail);
			}
			RemoteServices.RemoteAsyncDelegate_SendSpecialMail remoteAsyncDelegate_SendSpecialMail = new RemoteServices.RemoteAsyncDelegate_SendSpecialMail(this.service.SendSpecialMail);
			this.registerRPCcall(remoteAsyncDelegate_SendSpecialMail.BeginInvoke(this.UserID, this.SessionID, mailType, area, subject, body, this.SendSpecialMail_Callback, null), typeof(SendSpecialMail_ReturnType));
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x001E1640 File Offset: 0x001DF840
		[OneWay]
		public void OurRemoteAsyncCallBack_SendSpecialMail(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendSpecialMail remoteAsyncDelegate_SendSpecialMail = (RemoteServices.RemoteAsyncDelegate_SendSpecialMail)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendSpecialMail.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendSpecialMail_ReturnType returnData = new SendSpecialMail_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x0001DBC2 File Offset: 0x0001BDC2
		public void set_DeleteMailThread_UserCallBack(RemoteServices.DeleteMailThread_UserCallBack callback)
		{
			this.deleteMailThread_UserCallBack = callback;
		}

		// Token: 0x06001FDC RID: 8156 RVA: 0x001E1690 File Offset: 0x001DF890
		public void DeleteMailThread(long threadID)
		{
			if (this.DeleteMailThread_Callback == null)
			{
				this.DeleteMailThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteMailThread);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteMailThread remoteAsyncDelegate_DeleteMailThread = new RemoteServices.RemoteAsyncDelegate_DeleteMailThread(this.service.DeleteMailThread);
			this.registerRPCcall(remoteAsyncDelegate_DeleteMailThread.BeginInvoke(this.UserID, this.SessionID, threadID, this.DeleteMailThread_Callback, null), typeof(DeleteMailThread_ReturnType));
		}

		// Token: 0x06001FDD RID: 8157 RVA: 0x001E16F4 File Offset: 0x001DF8F4
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteMailThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteMailThread remoteAsyncDelegate_DeleteMailThread = (RemoteServices.RemoteAsyncDelegate_DeleteMailThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteMailThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteMailThread_ReturnType returnData = new DeleteMailThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FDE RID: 8158 RVA: 0x0001DBCB File Offset: 0x0001BDCB
		public void set_GetMailRecipientsHistory_UserCallBack(RemoteServices.GetMailRecipientsHistory_UserCallBack callback)
		{
			this.getMailRecipientsHistory_UserCallBack = callback;
		}

		// Token: 0x06001FDF RID: 8159 RVA: 0x001E1744 File Offset: 0x001DF944
		public void GetMailRecipientsHistory()
		{
			if (this.GetMailRecipientsHistory_Callback == null)
			{
				this.GetMailRecipientsHistory_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetMailRecipientsHistory);
			}
			RemoteServices.RemoteAsyncDelegate_GetMailRecipientsHistory remoteAsyncDelegate_GetMailRecipientsHistory = new RemoteServices.RemoteAsyncDelegate_GetMailRecipientsHistory(this.service.GetMailRecipientsHistory);
			this.registerRPCcall(remoteAsyncDelegate_GetMailRecipientsHistory.BeginInvoke(this.UserID, this.SessionID, this.GetMailRecipientsHistory_Callback, null), typeof(GetMailRecipientsHistory_ReturnType));
		}

		// Token: 0x06001FE0 RID: 8160 RVA: 0x001E17A8 File Offset: 0x001DF9A8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetMailRecipientsHistory(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetMailRecipientsHistory remoteAsyncDelegate_GetMailRecipientsHistory = (RemoteServices.RemoteAsyncDelegate_GetMailRecipientsHistory)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetMailRecipientsHistory.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetMailRecipientsHistory_ReturnType returnData = new GetMailRecipientsHistory_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FE1 RID: 8161 RVA: 0x0001DBD4 File Offset: 0x0001BDD4
		public void set_GetMailUserSearch_UserCallBack(RemoteServices.GetMailUserSearch_UserCallBack callback)
		{
			this.getMailUserSearch_UserCallBack = callback;
		}

		// Token: 0x06001FE2 RID: 8162 RVA: 0x001E17F8 File Offset: 0x001DF9F8
		public void GetMailUserSearch(string filter)
		{
			if (this.GetMailUserSearch_Callback == null)
			{
				this.GetMailUserSearch_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetMailUserSearch);
			}
			RemoteServices.RemoteAsyncDelegate_GetMailUserSearch remoteAsyncDelegate_GetMailUserSearch = new RemoteServices.RemoteAsyncDelegate_GetMailUserSearch(this.service.GetMailUserSearch);
			this.registerRPCcall(remoteAsyncDelegate_GetMailUserSearch.BeginInvoke(this.UserID, this.SessionID, filter, this.GetMailUserSearch_Callback, null), typeof(GetMailUserSearch_ReturnType));
		}

		// Token: 0x06001FE3 RID: 8163 RVA: 0x001E185C File Offset: 0x001DFA5C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetMailUserSearch(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetMailUserSearch remoteAsyncDelegate_GetMailUserSearch = (RemoteServices.RemoteAsyncDelegate_GetMailUserSearch)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetMailUserSearch.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetMailUserSearch_ReturnType returnData = new GetMailUserSearch_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FE4 RID: 8164 RVA: 0x0001DBDD File Offset: 0x0001BDDD
		public void set_AddUserToFavourites_UserCallBack(RemoteServices.AddUserToFavourites_UserCallBack callback)
		{
			this.addUserToFavourites_UserCallBack = callback;
		}

		// Token: 0x06001FE5 RID: 8165 RVA: 0x001E18AC File Offset: 0x001DFAAC
		public void AddUserToFavourites(string userName)
		{
			if (this.AddUserToFavourites_Callback == null)
			{
				this.AddUserToFavourites_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AddUserToFavourites);
			}
			RemoteServices.RemoteAsyncDelegate_AddUserToFavourites remoteAsyncDelegate_AddUserToFavourites = new RemoteServices.RemoteAsyncDelegate_AddUserToFavourites(this.service.AddUserToFavourites);
			this.registerRPCcall(remoteAsyncDelegate_AddUserToFavourites.BeginInvoke(this.UserID, this.SessionID, userName, false, this.AddUserToFavourites_Callback, null), typeof(AddUserToFavourites_ReturnType));
		}

		// Token: 0x06001FE6 RID: 8166 RVA: 0x001E1914 File Offset: 0x001DFB14
		public void RemoveUserFromFavourites(string userName)
		{
			if (this.AddUserToFavourites_Callback == null)
			{
				this.AddUserToFavourites_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AddUserToFavourites);
			}
			RemoteServices.RemoteAsyncDelegate_AddUserToFavourites remoteAsyncDelegate_AddUserToFavourites = new RemoteServices.RemoteAsyncDelegate_AddUserToFavourites(this.service.AddUserToFavourites);
			this.registerRPCcall(remoteAsyncDelegate_AddUserToFavourites.BeginInvoke(this.UserID, this.SessionID, userName, true, this.AddUserToFavourites_Callback, null), typeof(AddUserToFavourites_ReturnType));
		}

		// Token: 0x06001FE7 RID: 8167 RVA: 0x001E197C File Offset: 0x001DFB7C
		[OneWay]
		public void OurRemoteAsyncCallBack_AddUserToFavourites(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_AddUserToFavourites remoteAsyncDelegate_AddUserToFavourites = (RemoteServices.RemoteAsyncDelegate_AddUserToFavourites)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_AddUserToFavourites.EndInvoke(ar));
			}
			catch (Exception e)
			{
				AddUserToFavourites_ReturnType returnData = new AddUserToFavourites_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FE8 RID: 8168 RVA: 0x0001DBE6 File Offset: 0x0001BDE6
		public void set_GetHistoricalData_UserCallBack(RemoteServices.GetHistoricalData_UserCallBack callback)
		{
			this.getHistoricalData_UserCallBack = callback;
		}

		// Token: 0x06001FE9 RID: 8169 RVA: 0x001E19CC File Offset: 0x001DFBCC
		public void GetHistoricalData()
		{
			if (this.GetHistoricalData_Callback == null)
			{
				this.GetHistoricalData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetHistoricalData);
			}
			RemoteServices.RemoteAsyncDelegate_GetHistoricalData remoteAsyncDelegate_GetHistoricalData = new RemoteServices.RemoteAsyncDelegate_GetHistoricalData(this.service.GetHistoricalData);
			this.registerRPCcall(remoteAsyncDelegate_GetHistoricalData.BeginInvoke(this.UserID, this.SessionID, this.GetHistoricalData_Callback, null), typeof(GetHistoricalData_ReturnType));
		}

		// Token: 0x06001FEA RID: 8170 RVA: 0x001E1A30 File Offset: 0x001DFC30
		[OneWay]
		public void OurRemoteAsyncCallBack_GetHistoricalData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetHistoricalData remoteAsyncDelegate_GetHistoricalData = (RemoteServices.RemoteAsyncDelegate_GetHistoricalData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetHistoricalData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetHistoricalData_ReturnType returnData = new GetHistoricalData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FEB RID: 8171 RVA: 0x0001DBEF File Offset: 0x0001BDEF
		public void set_GetResourceLevel_UserCallBack(RemoteServices.GetResourceLevel_UserCallBack callback)
		{
			this.getResourceLevel_UserCallBack = callback;
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x001E1A80 File Offset: 0x001DFC80
		public void GetResourceLevel(int villageID, int buildingType)
		{
			if (this.GetResourceLevel_Callback == null)
			{
				this.GetResourceLevel_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetResourceLevel);
			}
			RemoteServices.RemoteAsyncDelegate_GetResourceLevel remoteAsyncDelegate_GetResourceLevel = new RemoteServices.RemoteAsyncDelegate_GetResourceLevel(this.service.GetResourceLevel);
			this.registerRPCcall(remoteAsyncDelegate_GetResourceLevel.BeginInvoke(this.UserID, this.SessionID, villageID, buildingType, this.GetResourceLevel_Callback, null), typeof(GetResourceLevel_ReturnType));
		}

		// Token: 0x06001FED RID: 8173 RVA: 0x001E1AE8 File Offset: 0x001DFCE8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetResourceLevel(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetResourceLevel remoteAsyncDelegate_GetResourceLevel = (RemoteServices.RemoteAsyncDelegate_GetResourceLevel)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetResourceLevel.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetResourceLevel_ReturnType returnData = new GetResourceLevel_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FEE RID: 8174 RVA: 0x0001DBF8 File Offset: 0x0001BDF8
		public void set_GetVillageBuildingsList_UserCallBack(RemoteServices.GetVillageBuildingsList_UserCallBack callback)
		{
			this.getVillageBuildingsList_UserCallBack = callback;
		}

		// Token: 0x06001FEF RID: 8175 RVA: 0x001E1B38 File Offset: 0x001DFD38
		public void GetVillageBuildingsList(int villageID, bool fullUpdate, bool needParishPeople)
		{
			if (this.GetVillageBuildingsList_Callback == null)
			{
				this.GetVillageBuildingsList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageBuildingsList);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageBuildingsList remoteAsyncDelegate_GetVillageBuildingsList = new RemoteServices.RemoteAsyncDelegate_GetVillageBuildingsList(this.service.GetVillageBuildingsList);
			this.registerRPCcall(remoteAsyncDelegate_GetVillageBuildingsList.BeginInvoke(this.UserID, this.SessionID, villageID, fullUpdate, false, needParishPeople, this.GetVillageBuildingsList_Callback, null), typeof(GetVillageBuildingsList_ReturnType));
		}

		// Token: 0x06001FF0 RID: 8176 RVA: 0x001E1BA0 File Offset: 0x001DFDA0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageBuildingsList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageBuildingsList remoteAsyncDelegate_GetVillageBuildingsList = (RemoteServices.RemoteAsyncDelegate_GetVillageBuildingsList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetVillageBuildingsList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetVillageBuildingsList_ReturnType returnData = new GetVillageBuildingsList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FF1 RID: 8177 RVA: 0x0001DC01 File Offset: 0x0001BE01
		public void set_PlaceVillageBuilding_UserCallBack(RemoteServices.PlaceVillageBuilding_UserCallBack callback)
		{
			this.placeVillageBuilding_UserCallBack = callback;
		}

		// Token: 0x06001FF2 RID: 8178 RVA: 0x001E1BF0 File Offset: 0x001DFDF0
		public void PlaceVillageBuilding(int villageID, int buildingType, Point buildingLocation)
		{
			if (this.PlaceVillageBuilding_Callback == null)
			{
				this.PlaceVillageBuilding_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_PlaceVillageBuilding);
			}
			RemoteServices.RemoteAsyncDelegate_PlaceVillageBuilding remoteAsyncDelegate_PlaceVillageBuilding = new RemoteServices.RemoteAsyncDelegate_PlaceVillageBuilding(this.service.PlaceVillageBuilding);
			this.registerRPCcall(remoteAsyncDelegate_PlaceVillageBuilding.BeginInvoke(this.UserID, this.SessionID, villageID, buildingType, buildingLocation, this.PlaceVillageBuilding_Callback, null), typeof(PlaceVillageBuilding_ReturnType));
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x001E1C58 File Offset: 0x001DFE58
		[OneWay]
		public void OurRemoteAsyncCallBack_PlaceVillageBuilding(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_PlaceVillageBuilding remoteAsyncDelegate_PlaceVillageBuilding = (RemoteServices.RemoteAsyncDelegate_PlaceVillageBuilding)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_PlaceVillageBuilding.EndInvoke(ar));
			}
			catch (Exception e)
			{
				PlaceVillageBuilding_ReturnType returnData = new PlaceVillageBuilding_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x0001DC0A File Offset: 0x0001BE0A
		public void set_DeleteVillageBuilding_UserCallBack(RemoteServices.DeleteVillageBuilding_UserCallBack callback)
		{
			this.deleteVillageBuilding_UserCallBack = callback;
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x001E1CA8 File Offset: 0x001DFEA8
		public void DeleteVillageBuilding(int villageID, long buildingID)
		{
			if (this.DeleteVillageBuilding_Callback == null)
			{
				this.DeleteVillageBuilding_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteVillageBuilding);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteVillageBuilding remoteAsyncDelegate_DeleteVillageBuilding = new RemoteServices.RemoteAsyncDelegate_DeleteVillageBuilding(this.service.DeleteVillageBuilding);
			this.registerRPCcall(remoteAsyncDelegate_DeleteVillageBuilding.BeginInvoke(this.UserID, this.SessionID, villageID, buildingID, this.DeleteVillageBuilding_Callback, null), typeof(DeleteVillageBuilding_ReturnType));
		}

		// Token: 0x06001FF6 RID: 8182 RVA: 0x001E1D10 File Offset: 0x001DFF10
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteVillageBuilding(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteVillageBuilding remoteAsyncDelegate_DeleteVillageBuilding = (RemoteServices.RemoteAsyncDelegate_DeleteVillageBuilding)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteVillageBuilding.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteVillageBuilding_ReturnType returnData = new DeleteVillageBuilding_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FF7 RID: 8183 RVA: 0x0001DC13 File Offset: 0x0001BE13
		public void set_CancelDeleteVillageBuilding_UserCallBack(RemoteServices.CancelDeleteVillageBuilding_UserCallBack callback)
		{
			this.cancelDeleteVillageBuilding_UserCallBack = callback;
		}

		// Token: 0x06001FF8 RID: 8184 RVA: 0x001E1D60 File Offset: 0x001DFF60
		public void CancelDeleteVillageBuilding(int villageID, long buildingID)
		{
			if (this.CancelDeleteVillageBuilding_Callback == null)
			{
				this.CancelDeleteVillageBuilding_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CancelDeleteVillageBuilding);
			}
			RemoteServices.RemoteAsyncDelegate_CancelDeleteVillageBuilding remoteAsyncDelegate_CancelDeleteVillageBuilding = new RemoteServices.RemoteAsyncDelegate_CancelDeleteVillageBuilding(this.service.CancelDeleteVillageBuilding);
			this.registerRPCcall(remoteAsyncDelegate_CancelDeleteVillageBuilding.BeginInvoke(this.UserID, this.SessionID, villageID, buildingID, this.CancelDeleteVillageBuilding_Callback, null), typeof(CancelDeleteVillageBuilding_ReturnType));
		}

		// Token: 0x06001FF9 RID: 8185 RVA: 0x001E1DC8 File Offset: 0x001DFFC8
		[OneWay]
		public void OurRemoteAsyncCallBack_CancelDeleteVillageBuilding(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CancelDeleteVillageBuilding remoteAsyncDelegate_CancelDeleteVillageBuilding = (RemoteServices.RemoteAsyncDelegate_CancelDeleteVillageBuilding)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CancelDeleteVillageBuilding.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CancelDeleteVillageBuilding_ReturnType returnData = new CancelDeleteVillageBuilding_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FFA RID: 8186 RVA: 0x0001DC1C File Offset: 0x0001BE1C
		public void set_MoveVillageBuilding_UserCallBack(RemoteServices.MoveVillageBuilding_UserCallBack callback)
		{
			this.moveVillageBuilding_UserCallBack = callback;
		}

		// Token: 0x06001FFB RID: 8187 RVA: 0x001E1E18 File Offset: 0x001E0018
		public void MoveVillageBuilding(int villageID, long buildingID, Point buildingLocation)
		{
			if (this.MoveVillageBuilding_Callback == null)
			{
				this.MoveVillageBuilding_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MoveVillageBuilding);
			}
			RemoteServices.RemoteAsyncDelegate_MoveVillageBuilding remoteAsyncDelegate_MoveVillageBuilding = new RemoteServices.RemoteAsyncDelegate_MoveVillageBuilding(this.service.MoveVillageBuilding);
			this.registerRPCcall(remoteAsyncDelegate_MoveVillageBuilding.BeginInvoke(this.UserID, this.SessionID, villageID, buildingID, buildingLocation, this.MoveVillageBuilding_Callback, null), typeof(MoveVillageBuilding_ReturnType));
		}

		// Token: 0x06001FFC RID: 8188 RVA: 0x001E1E80 File Offset: 0x001E0080
		[OneWay]
		public void OurRemoteAsyncCallBack_MoveVillageBuilding(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MoveVillageBuilding remoteAsyncDelegate_MoveVillageBuilding = (RemoteServices.RemoteAsyncDelegate_MoveVillageBuilding)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MoveVillageBuilding.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MoveVillageBuilding_ReturnType returnData = new MoveVillageBuilding_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06001FFD RID: 8189 RVA: 0x0001DC25 File Offset: 0x0001BE25
		public void set_VillageBuildingCompleteDataRetrieval_UserCallBack(RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack callback)
		{
			this.villageBuildingCompleteDataRetrieval_UserCallBack = callback;
		}

		// Token: 0x06001FFE RID: 8190 RVA: 0x001E1ED0 File Offset: 0x001E00D0
		public void VillageBuildingCompleteDataRetrieval(int villageID, long buildingID)
		{
			if (this.VillageBuildingCompleteDataRetrieval_Callback == null)
			{
				this.VillageBuildingCompleteDataRetrieval_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingCompleteDataRetrieval);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval = new RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval(this.service.VillageBuildingCompleteDataRetrieval);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval.BeginInvoke(this.UserID, this.SessionID, villageID, buildingID, 0, this.VillageBuildingCompleteDataRetrieval_Callback, null), typeof(VillageBuildingCompleteDataRetrieval_ReturnType));
		}

		// Token: 0x06001FFF RID: 8191 RVA: 0x001E1F38 File Offset: 0x001E0138
		public void VillageBuildingDeleteDataRetrieval(int villageID, long buildingID)
		{
			if (this.VillageBuildingCompleteDataRetrieval_Callback == null)
			{
				this.VillageBuildingCompleteDataRetrieval_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingCompleteDataRetrieval);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval = new RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval(this.service.VillageBuildingCompleteDataRetrieval);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval.BeginInvoke(this.UserID, this.SessionID, villageID, buildingID, 1, this.VillageBuildingCompleteDataRetrieval_Callback, null), typeof(VillageBuildingCompleteDataRetrieval_ReturnType));
		}

		// Token: 0x06002000 RID: 8192 RVA: 0x001E1FA0 File Offset: 0x001E01A0
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageBuildingCompleteDataRetrieval(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval = (RemoteServices.RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageBuildingCompleteDataRetrieval.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageBuildingCompleteDataRetrieval_ReturnType returnData = new VillageBuildingCompleteDataRetrieval_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002001 RID: 8193 RVA: 0x0001DC2E File Offset: 0x0001BE2E
		public void set_VillageBuildingSetActive_UserCallBack(RemoteServices.VillageBuildingSetActive_UserCallBack callback)
		{
			this.villageBuildingSetActive_UserCallBack = callback;
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x001E1FF0 File Offset: 0x001E01F0
		public void VillageBuildingSetActive(int villageID, long buildingID, bool state)
		{
			if (this.VillageBuildingSetActive_Callback == null)
			{
				this.VillageBuildingSetActive_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingSetActive);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive remoteAsyncDelegate_VillageBuildingSetActive = new RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive(this.service.VillageBuildingSetActive);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingSetActive.BeginInvoke(this.UserID, this.SessionID, buildingID, villageID, -1, state, this.VillageBuildingSetActive_Callback, null), typeof(VillageBuildingSetActive_ReturnType));
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x001E2058 File Offset: 0x001E0258
		public void VillageBuildingTypeSetActive(int villageID, int buildingType, bool state)
		{
			if (this.VillageBuildingSetActive_Callback == null)
			{
				this.VillageBuildingSetActive_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingSetActive);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive remoteAsyncDelegate_VillageBuildingSetActive = new RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive(this.service.VillageBuildingSetActive);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingSetActive.BeginInvoke(this.UserID, this.SessionID, -1L, villageID, buildingType, state, this.VillageBuildingSetActive_Callback, null), typeof(VillageBuildingSetActive_ReturnType));
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x001E20C0 File Offset: 0x001E02C0
		public void VillageAllBuildingsSetActive(int villageID, bool state)
		{
			if (this.VillageBuildingSetActive_Callback == null)
			{
				this.VillageBuildingSetActive_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingSetActive);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive remoteAsyncDelegate_VillageBuildingSetActive = new RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive(this.service.VillageBuildingSetActive);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingSetActive.BeginInvoke(this.UserID, this.SessionID, -1L, villageID, -1, state, this.VillageBuildingSetActive_Callback, null), typeof(VillageBuildingSetActive_ReturnType));
		}

		// Token: 0x06002005 RID: 8197 RVA: 0x001E2128 File Offset: 0x001E0328
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageBuildingSetActive(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive remoteAsyncDelegate_VillageBuildingSetActive = (RemoteServices.RemoteAsyncDelegate_VillageBuildingSetActive)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageBuildingSetActive.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageBuildingSetActive_ReturnType returnData = new VillageBuildingSetActive_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002006 RID: 8198 RVA: 0x0001DC37 File Offset: 0x0001BE37
		public void set_VillageBuildingChangeRates_UserCallBack(RemoteServices.VillageBuildingChangeRates_UserCallBack callback)
		{
			this.villageBuildingChangeRates_UserCallBack = callback;
		}

		// Token: 0x06002007 RID: 8199 RVA: 0x001E2178 File Offset: 0x001E0378
		public void VillageBuildingChangeRates(int villageID, int taxLevel, int rationsLevel, int aleRationsLevel, int capitalTaxRate)
		{
			if (this.VillageBuildingChangeRates_Callback == null)
			{
				this.VillageBuildingChangeRates_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageBuildingChangeRates);
			}
			RemoteServices.RemoteAsyncDelegate_VillageBuildingChangeRates remoteAsyncDelegate_VillageBuildingChangeRates = new RemoteServices.RemoteAsyncDelegate_VillageBuildingChangeRates(this.service.VillageBuildingChangeRates);
			this.registerRPCcall(remoteAsyncDelegate_VillageBuildingChangeRates.BeginInvoke(this.UserID, this.SessionID, villageID, taxLevel, rationsLevel, aleRationsLevel, capitalTaxRate, this.VillageBuildingChangeRates_Callback, null), typeof(VillageBuildingChangeRates_ReturnType));
		}

		// Token: 0x06002008 RID: 8200 RVA: 0x001E21E4 File Offset: 0x001E03E4
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageBuildingChangeRates(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageBuildingChangeRates remoteAsyncDelegate_VillageBuildingChangeRates = (RemoteServices.RemoteAsyncDelegate_VillageBuildingChangeRates)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageBuildingChangeRates.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageBuildingChangeRates_ReturnType returnData = new VillageBuildingChangeRates_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002009 RID: 8201 RVA: 0x0001DC40 File Offset: 0x0001BE40
		public void set_VillageRename_UserCallBack(RemoteServices.VillageRename_UserCallBack callback)
		{
			this.villageRename_UserCallBack = callback;
		}

		// Token: 0x0600200A RID: 8202 RVA: 0x001E2234 File Offset: 0x001E0434
		public void VillageRename(int villageID, string villageName)
		{
			if (this.VillageRename_Callback == null)
			{
				this.VillageRename_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageRename);
			}
			RemoteServices.RemoteAsyncDelegate_VillageRename remoteAsyncDelegate_VillageRename = new RemoteServices.RemoteAsyncDelegate_VillageRename(this.service.VillageRename);
			this.registerRPCcall(remoteAsyncDelegate_VillageRename.BeginInvoke(this.UserID, this.SessionID, villageID, villageName, false, false, this.VillageRename_Callback, null), typeof(VillageRename_ReturnType));
		}

		// Token: 0x0600200B RID: 8203 RVA: 0x001E229C File Offset: 0x001E049C
		public void VillageResetName(int villageID)
		{
			if (this.VillageRename_Callback == null)
			{
				this.VillageRename_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageRename);
			}
			RemoteServices.RemoteAsyncDelegate_VillageRename remoteAsyncDelegate_VillageRename = new RemoteServices.RemoteAsyncDelegate_VillageRename(this.service.VillageRename);
			this.registerRPCcall(remoteAsyncDelegate_VillageRename.BeginInvoke(this.UserID, this.SessionID, villageID, "DoReset", false, true, this.VillageRename_Callback, null), typeof(VillageRename_ReturnType));
		}

		// Token: 0x0600200C RID: 8204 RVA: 0x001E2308 File Offset: 0x001E0508
		public void VillageAbandon(int villageID)
		{
			if (this.VillageRename_Callback == null)
			{
				this.VillageRename_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageRename);
			}
			RemoteServices.RemoteAsyncDelegate_VillageRename remoteAsyncDelegate_VillageRename = new RemoteServices.RemoteAsyncDelegate_VillageRename(this.service.VillageRename);
			this.registerRPCcall(remoteAsyncDelegate_VillageRename.BeginInvoke(this.UserID, this.SessionID, villageID, "DoAbandon", true, false, this.VillageRename_Callback, null), typeof(VillageRename_ReturnType));
		}

		// Token: 0x0600200D RID: 8205 RVA: 0x001E2374 File Offset: 0x001E0574
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageRename(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageRename remoteAsyncDelegate_VillageRename = (RemoteServices.RemoteAsyncDelegate_VillageRename)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageRename.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageRename_ReturnType returnData = new VillageRename_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600200E RID: 8206 RVA: 0x0001DC49 File Offset: 0x0001BE49
		public void set_VillageProduceWeapons_UserCallBack(RemoteServices.VillageProduceWeapons_UserCallBack callback)
		{
			this.villageProduceWeapons_UserCallBack = callback;
		}

		// Token: 0x0600200F RID: 8207 RVA: 0x001E23C4 File Offset: 0x001E05C4
		public void VillageProduceWeapons(int villageID, int weaponType, int amount)
		{
			if (this.VillageProduceWeapons_Callback == null)
			{
				this.VillageProduceWeapons_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageProduceWeapons);
			}
			RemoteServices.RemoteAsyncDelegate_VillageProduceWeapons remoteAsyncDelegate_VillageProduceWeapons = new RemoteServices.RemoteAsyncDelegate_VillageProduceWeapons(this.service.VillageProduceWeapons);
			this.registerRPCcall(remoteAsyncDelegate_VillageProduceWeapons.BeginInvoke(this.UserID, this.SessionID, villageID, weaponType, amount, this.VillageProduceWeapons_Callback, null), typeof(VillageProduceWeapons_ReturnType));
		}

		// Token: 0x06002010 RID: 8208 RVA: 0x001E242C File Offset: 0x001E062C
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageProduceWeapons(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageProduceWeapons remoteAsyncDelegate_VillageProduceWeapons = (RemoteServices.RemoteAsyncDelegate_VillageProduceWeapons)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageProduceWeapons.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageProduceWeapons_ReturnType returnData = new VillageProduceWeapons_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002011 RID: 8209 RVA: 0x0001DC52 File Offset: 0x0001BE52
		public void set_VillageHoldBanquet_UserCallBack(RemoteServices.VillageHoldBanquet_UserCallBack callback)
		{
			this.villageHoldBanquet_UserCallBack = callback;
		}

		// Token: 0x06002012 RID: 8210 RVA: 0x001E247C File Offset: 0x001E067C
		public void VillageHoldBanquet(int villageID, int venison, int furniture, int metalwork, int clothing, int wine, int salt, int spice, int silk)
		{
			if (this.VillageHoldBanquet_Callback == null)
			{
				this.VillageHoldBanquet_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VillageHoldBanquet);
			}
			RemoteServices.RemoteAsyncDelegate_VillageHoldBanquet remoteAsyncDelegate_VillageHoldBanquet = new RemoteServices.RemoteAsyncDelegate_VillageHoldBanquet(this.service.VillageHoldBanquet);
			this.registerRPCcall(remoteAsyncDelegate_VillageHoldBanquet.BeginInvoke(this.UserID, this.SessionID, villageID, venison, wine, salt, spice, silk, clothing, furniture, metalwork, this.VillageHoldBanquet_Callback, null), typeof(VillageHoldBanquet_ReturnType));
		}

		// Token: 0x06002013 RID: 8211 RVA: 0x001E24F0 File Offset: 0x001E06F0
		[OneWay]
		public void OurRemoteAsyncCallBack_VillageHoldBanquet(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VillageHoldBanquet remoteAsyncDelegate_VillageHoldBanquet = (RemoteServices.RemoteAsyncDelegate_VillageHoldBanquet)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VillageHoldBanquet.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VillageHoldBanquet_ReturnType returnData = new VillageHoldBanquet_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002014 RID: 8212 RVA: 0x0001DC5B File Offset: 0x0001BE5B
		public void set_GetCastle_UserCallBack(RemoteServices.GetCastle_UserCallBack callback)
		{
			this.getCastle_UserCallBack = callback;
		}

		// Token: 0x06002015 RID: 8213 RVA: 0x001E2540 File Offset: 0x001E0740
		public void GetCastle(int villageID)
		{
			if (this.GetCastle_Callback == null)
			{
				this.GetCastle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCastle);
			}
			RemoteServices.RemoteAsyncDelegate_GetCastle remoteAsyncDelegate_GetCastle = new RemoteServices.RemoteAsyncDelegate_GetCastle(this.service.GetCastle);
			this.registerRPCcall(remoteAsyncDelegate_GetCastle.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetCastle_Callback, null), typeof(GetCastle_ReturnType));
		}

		// Token: 0x06002016 RID: 8214 RVA: 0x001E25A4 File Offset: 0x001E07A4
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCastle(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCastle remoteAsyncDelegate_GetCastle = (RemoteServices.RemoteAsyncDelegate_GetCastle)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCastle.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCastle_ReturnType returnData = new GetCastle_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002017 RID: 8215 RVA: 0x0001DC64 File Offset: 0x0001BE64
		public void set_AddCastleElement_UserCallBack(RemoteServices.AddCastleElement_UserCallBack callback)
		{
			this.addCastleElement_UserCallBack = callback;
		}

		// Token: 0x06002018 RID: 8216 RVA: 0x001E25F4 File Offset: 0x001E07F4
		public void AddCastleElement(int villageID, int elementType, int x, int y, long clientElementNumber)
		{
			this.AddCastleElement(villageID, elementType, x, y, clientElementNumber, false, false, null, null, null);
		}

		// Token: 0x06002019 RID: 8217 RVA: 0x001E2614 File Offset: 0x001E0814
		public void AddCastleElement(int villageID, int elementType, int x, int y, long clientElementNumber, bool reinforcement)
		{
			this.AddCastleElement(villageID, elementType, x, y, clientElementNumber, reinforcement, false, null, null, null);
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x001E2634 File Offset: 0x001E0834
		public void AddCastleElementList(int villageID, byte[,] elementList)
		{
			this.AddCastleElement(villageID, 0, 0, 0, -1L, false, false, elementList, null, null);
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x001E2654 File Offset: 0x001E0854
		public void AddCastleElementList(int villageID, byte[,] elementList, long[] troopsToDelete, MoveElementData[] troopsToMove)
		{
			this.AddCastleElement(villageID, 0, 0, 0, -1L, false, false, elementList, troopsToDelete, troopsToMove);
		}

		// Token: 0x0600201C RID: 8220 RVA: 0x001E2674 File Offset: 0x001E0874
		public void AddCastleElement(int villageID, int elementType, int x, int y, long clientElementNumber, bool reinforcement, bool vassalReinforcement, byte[,] elementList, long[] troopsToDelete, MoveElementData[] troopsToMove)
		{
			if (this.AddCastleElement_Callback == null)
			{
				this.AddCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AddCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_AddCastleElement remoteAsyncDelegate_AddCastleElement = new RemoteServices.RemoteAsyncDelegate_AddCastleElement(this.service.AddCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_AddCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, elementType, x, y, clientElementNumber, -1, -1, reinforcement, vassalReinforcement, elementList, troopsToDelete, troopsToMove, this.AddCastleElement_Callback, null), typeof(AddCastleElement_ReturnType));
		}

		// Token: 0x0600201D RID: 8221 RVA: 0x001E26EC File Offset: 0x001E08EC
		public void AddCastleWallElement(int villageID, int elementType, int x, int y, long clientElementNumber, int wallX, int wallY)
		{
			if (this.AddCastleElement_Callback == null)
			{
				this.AddCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AddCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_AddCastleElement remoteAsyncDelegate_AddCastleElement = new RemoteServices.RemoteAsyncDelegate_AddCastleElement(this.service.AddCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_AddCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, elementType, x, y, clientElementNumber, wallX, wallY, false, false, null, null, null, this.AddCastleElement_Callback, null), typeof(AddCastleElement_ReturnType));
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x001E2760 File Offset: 0x001E0960
		[OneWay]
		public void OurRemoteAsyncCallBack_AddCastleElement(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_AddCastleElement remoteAsyncDelegate_AddCastleElement = (RemoteServices.RemoteAsyncDelegate_AddCastleElement)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_AddCastleElement.EndInvoke(ar));
			}
			catch (Exception e)
			{
				AddCastleElement_ReturnType returnData = new AddCastleElement_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600201F RID: 8223 RVA: 0x0001DC6D File Offset: 0x0001BE6D
		public void set_DeleteCastleElement_UserCallBack(RemoteServices.DeleteCastleElement_UserCallBack callback)
		{
			this.deleteCastleElement_UserCallBack = callback;
		}

		// Token: 0x06002020 RID: 8224 RVA: 0x001E27B0 File Offset: 0x001E09B0
		public void DeleteCastleElement(int villageID, long elementID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, elementID, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002021 RID: 8225 RVA: 0x001E2818 File Offset: 0x001E0A18
		public void DeleteCastleElement(int villageID, List<long> elementList)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -1L, elementList, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x001E2880 File Offset: 0x001E0A80
		public void DeleteConstructingCastleElements(int villageID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -1L, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002023 RID: 8227 RVA: 0x001E28E8 File Offset: 0x001E0AE8
		public void DeleteAllCastleElements(int villageID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -51L, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x001E2950 File Offset: 0x001E0B50
		public void DeleteAllCastlePitsElements(int villageID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -61L, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x001E29B8 File Offset: 0x001E0BB8
		public void DeleteAllCastleMoatElements(int villageID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -71L, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x001E2A20 File Offset: 0x001E0C20
		public void DeleteAllCastleOilPotsElements(int villageID)
		{
			if (this.DeleteCastleElement_Callback == null)
			{
				this.DeleteCastleElement_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteCastleElement);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = new RemoteServices.RemoteAsyncDelegate_DeleteCastleElement(this.service.DeleteCastleElement);
			this.registerRPCcall(remoteAsyncDelegate_DeleteCastleElement.BeginInvoke(this.UserID, this.SessionID, villageID, -81L, null, this.DeleteCastleElement_Callback, null), typeof(DeleteCastleElement_ReturnType));
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x001E2A88 File Offset: 0x001E0C88
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteCastleElement(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteCastleElement remoteAsyncDelegate_DeleteCastleElement = (RemoteServices.RemoteAsyncDelegate_DeleteCastleElement)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteCastleElement.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteCastleElement_ReturnType returnData = new DeleteCastleElement_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x0001DC76 File Offset: 0x0001BE76
		public void set_ChangeCastleElementAggressiveDefender_UserCallBack(RemoteServices.ChangeCastleElementAggressiveDefender_UserCallBack callback)
		{
			this.changeCastleElementAggressiveDefender_UserCallBack = callback;
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x001E2AD8 File Offset: 0x001E0CD8
		public void ChangeCastleElementAggressiveDefender(int villageID, long[] elementID, bool state)
		{
			if (this.ChangeCastleElementAggressiveDefender_Callback == null)
			{
				this.ChangeCastleElementAggressiveDefender_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ChangeCastleElementAggressiveDefender);
			}
			RemoteServices.RemoteAsyncDelegate_ChangeCastleElementAggressiveDefender remoteAsyncDelegate_ChangeCastleElementAggressiveDefender = new RemoteServices.RemoteAsyncDelegate_ChangeCastleElementAggressiveDefender(this.service.ChangeCastleElementAggressiveDefender);
			this.registerRPCcall(remoteAsyncDelegate_ChangeCastleElementAggressiveDefender.BeginInvoke(this.UserID, this.SessionID, villageID, elementID, state, this.ChangeCastleElementAggressiveDefender_Callback, null), typeof(ChangeCastleElementAggressiveDefender_ReturnType));
		}

		// Token: 0x0600202A RID: 8234 RVA: 0x001E2B40 File Offset: 0x001E0D40
		[OneWay]
		public void OurRemoteAsyncCallBack_ChangeCastleElementAggressiveDefender(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ChangeCastleElementAggressiveDefender remoteAsyncDelegate_ChangeCastleElementAggressiveDefender = (RemoteServices.RemoteAsyncDelegate_ChangeCastleElementAggressiveDefender)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ChangeCastleElementAggressiveDefender.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ChangeCastleElementAggressiveDefender_ReturnType returnData = new ChangeCastleElementAggressiveDefender_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600202B RID: 8235 RVA: 0x0001DC7F File Offset: 0x0001BE7F
		public void set_AutoRepairCastle_UserCallBack(RemoteServices.AutoRepairCastle_UserCallBack callback)
		{
			this.autoRepairCastle_UserCallBack = callback;
		}

		// Token: 0x0600202C RID: 8236 RVA: 0x001E2B90 File Offset: 0x001E0D90
		public void AutoRepairCastle(int villageID)
		{
			if (this.AutoRepairCastle_Callback == null)
			{
				this.AutoRepairCastle_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AutoRepairCastle);
			}
			RemoteServices.RemoteAsyncDelegate_AutoRepairCastle remoteAsyncDelegate_AutoRepairCastle = new RemoteServices.RemoteAsyncDelegate_AutoRepairCastle(this.service.AutoRepairCastle);
			this.registerRPCcall(remoteAsyncDelegate_AutoRepairCastle.BeginInvoke(this.UserID, this.SessionID, villageID, this.AutoRepairCastle_Callback, null), typeof(AutoRepairCastle_ReturnType));
		}

		// Token: 0x0600202D RID: 8237 RVA: 0x001E2BF4 File Offset: 0x001E0DF4
		[OneWay]
		public void OurRemoteAsyncCallBack_AutoRepairCastle(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_AutoRepairCastle remoteAsyncDelegate_AutoRepairCastle = (RemoteServices.RemoteAsyncDelegate_AutoRepairCastle)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_AutoRepairCastle.EndInvoke(ar));
			}
			catch (Exception e)
			{
				AutoRepairCastle_ReturnType returnData = new AutoRepairCastle_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x0001DC88 File Offset: 0x0001BE88
		public void set_MemorizeCastleTroops_UserCallBack(RemoteServices.MemorizeCastleTroops_UserCallBack callback)
		{
			this.memorizeCastleTroops_UserCallBack = callback;
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x001E2C44 File Offset: 0x001E0E44
		public void MemorizeCastleTroops(int villageID)
		{
			if (this.MemorizeCastleTroops_Callback == null)
			{
				this.MemorizeCastleTroops_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MemorizeCastleTroops);
			}
			RemoteServices.RemoteAsyncDelegate_MemorizeCastleTroops remoteAsyncDelegate_MemorizeCastleTroops = new RemoteServices.RemoteAsyncDelegate_MemorizeCastleTroops(this.service.MemorizeCastleTroops);
			this.registerRPCcall(remoteAsyncDelegate_MemorizeCastleTroops.BeginInvoke(this.UserID, this.SessionID, villageID, this.MemorizeCastleTroops_Callback, null), typeof(MemorizeCastleTroops_ReturnType));
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x001E2CA8 File Offset: 0x001E0EA8
		[OneWay]
		public void OurRemoteAsyncCallBack_MemorizeCastleTroops(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MemorizeCastleTroops remoteAsyncDelegate_MemorizeCastleTroops = (RemoteServices.RemoteAsyncDelegate_MemorizeCastleTroops)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MemorizeCastleTroops.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MemorizeCastleTroops_ReturnType returnData = new MemorizeCastleTroops_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x0001DC91 File Offset: 0x0001BE91
		public void set_RestoreCastleTroops_UserCallBack(RemoteServices.RestoreCastleTroops_UserCallBack callback)
		{
			this.restoreCastleTroops_UserCallBack = callback;
		}

		// Token: 0x06002032 RID: 8242 RVA: 0x001E2CF8 File Offset: 0x001E0EF8
		public void RestoreCastleTroops(int villageID)
		{
			if (this.RestoreCastleTroops_Callback == null)
			{
				this.RestoreCastleTroops_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RestoreCastleTroops);
			}
			RemoteServices.RemoteAsyncDelegate_RestoreCastleTroops remoteAsyncDelegate_RestoreCastleTroops = new RemoteServices.RemoteAsyncDelegate_RestoreCastleTroops(this.service.RestoreCastleTroops);
			this.registerRPCcall(remoteAsyncDelegate_RestoreCastleTroops.BeginInvoke(this.UserID, this.SessionID, villageID, this.RestoreCastleTroops_Callback, null), typeof(RestoreCastleTroops_ReturnType));
		}

		// Token: 0x06002033 RID: 8243 RVA: 0x001E2D5C File Offset: 0x001E0F5C
		[OneWay]
		public void OurRemoteAsyncCallBack_RestoreCastleTroops(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RestoreCastleTroops remoteAsyncDelegate_RestoreCastleTroops = (RemoteServices.RemoteAsyncDelegate_RestoreCastleTroops)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RestoreCastleTroops.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RestoreCastleTroops_ReturnType returnData = new RestoreCastleTroops_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002034 RID: 8244 RVA: 0x0001DC9A File Offset: 0x0001BE9A
		public void set_CheatAddTroops_UserCallBack(RemoteServices.CheatAddTroops_UserCallBack callback)
		{
			this.cheatAddTroops_UserCallBack = callback;
		}

		// Token: 0x06002035 RID: 8245 RVA: 0x001E2DAC File Offset: 0x001E0FAC
		public void CheatAddTroops(int villageID, int troopsType, int numTroops)
		{
			if (this.CheatAddTroops_Callback == null)
			{
				this.CheatAddTroops_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CheatAddTroops);
			}
			RemoteServices.RemoteAsyncDelegate_CheatAddTroops remoteAsyncDelegate_CheatAddTroops = new RemoteServices.RemoteAsyncDelegate_CheatAddTroops(this.service.CheatAddTroops);
			this.registerRPCcall(remoteAsyncDelegate_CheatAddTroops.BeginInvoke(this.UserID, this.SessionID, villageID, troopsType, numTroops, this.CheatAddTroops_Callback, null), typeof(CheatAddTroops_ReturnType));
		}

		// Token: 0x06002036 RID: 8246 RVA: 0x001E2E14 File Offset: 0x001E1014
		[OneWay]
		public void OurRemoteAsyncCallBack_CheatAddTroops(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CheatAddTroops remoteAsyncDelegate_CheatAddTroops = (RemoteServices.RemoteAsyncDelegate_CheatAddTroops)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CheatAddTroops.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CheatAddTroops_ReturnType returnData = new CheatAddTroops_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002037 RID: 8247 RVA: 0x0001DCA3 File Offset: 0x0001BEA3
		public void set_LaunchCastleAttack_UserCallBack(RemoteServices.LaunchCastleAttack_UserCallBack callback)
		{
			this.launchCastleAttack_UserCallBack = callback;
		}

		// Token: 0x06002038 RID: 8248 RVA: 0x001E2E64 File Offset: 0x001E1064
		public void LaunchCastleAttack(int parentOfAttackingVillageID, int sourceVillageID, int targetVillageID, byte[] troopMap, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackType, int pillagePercent, int CaptainsCommand, int numCaptains)
		{
			if (this.LaunchCastleAttack_Callback == null)
			{
				this.LaunchCastleAttack_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LaunchCastleAttack);
			}
			RemoteServices.RemoteAsyncDelegate_LaunchCastleAttack remoteAsyncDelegate_LaunchCastleAttack = new RemoteServices.RemoteAsyncDelegate_LaunchCastleAttack(this.service.LaunchCastleAttack);
			this.registerRPCcall(remoteAsyncDelegate_LaunchCastleAttack.BeginInvoke(this.UserID, this.SessionID, parentOfAttackingVillageID, targetVillageID, sourceVillageID, troopMap, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, attackType, pillagePercent, CaptainsCommand, numCaptains, this.LaunchCastleAttack_Callback, null), typeof(LaunchCastleAttack_ReturnType));
		}

		// Token: 0x06002039 RID: 8249 RVA: 0x001E2EE0 File Offset: 0x001E10E0
		[OneWay]
		public void OurRemoteAsyncCallBack_LaunchCastleAttack(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LaunchCastleAttack remoteAsyncDelegate_LaunchCastleAttack = (RemoteServices.RemoteAsyncDelegate_LaunchCastleAttack)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LaunchCastleAttack.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LaunchCastleAttack_ReturnType returnData = new LaunchCastleAttack_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600203A RID: 8250 RVA: 0x0001DCAC File Offset: 0x0001BEAC
		public void set_SendScouts_UserCallBack(RemoteServices.SendScouts_UserCallBack callback)
		{
			this.sendScouts_UserCallBack = callback;
		}

		// Token: 0x0600203B RID: 8251 RVA: 0x001E2F30 File Offset: 0x001E1130
		public void SendScouts(int sourceVillageID, int targetVillageID, int numScouts)
		{
			if (this.SendScouts_Callback == null)
			{
				this.SendScouts_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendScouts);
			}
			RemoteServices.RemoteAsyncDelegate_SendScouts remoteAsyncDelegate_SendScouts = new RemoteServices.RemoteAsyncDelegate_SendScouts(this.service.SendScouts);
			this.registerRPCcall(remoteAsyncDelegate_SendScouts.BeginInvoke(this.UserID, this.SessionID, targetVillageID, sourceVillageID, numScouts, this.SendScouts_Callback, null), typeof(SendScouts_ReturnType));
		}

		// Token: 0x0600203C RID: 8252 RVA: 0x001E2F98 File Offset: 0x001E1198
		[OneWay]
		public void OurRemoteAsyncCallBack_SendScouts(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendScouts remoteAsyncDelegate_SendScouts = (RemoteServices.RemoteAsyncDelegate_SendScouts)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendScouts.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendScouts_ReturnType returnData = new SendScouts_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600203D RID: 8253 RVA: 0x0001DCB5 File Offset: 0x0001BEB5
		public void set_CancelCastleAttack_UserCallBack(RemoteServices.CancelCastleAttack_UserCallBack callback)
		{
			this.cancelCastleAttack_UserCallBack = callback;
		}

		// Token: 0x0600203E RID: 8254 RVA: 0x001E2FE8 File Offset: 0x001E11E8
		public void CancelCastleAttack(long armyID)
		{
			if (this.CancelCastleAttack_Callback == null)
			{
				this.CancelCastleAttack_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CancelCastleAttack);
			}
			RemoteServices.RemoteAsyncDelegate_CancelCastleAttack remoteAsyncDelegate_CancelCastleAttack = new RemoteServices.RemoteAsyncDelegate_CancelCastleAttack(this.service.CancelCastleAttack);
			this.registerRPCcall(remoteAsyncDelegate_CancelCastleAttack.BeginInvoke(this.UserID, this.SessionID, armyID, this.CancelCastleAttack_Callback, null), typeof(CancelCastleAttack_ReturnType));
		}

		// Token: 0x0600203F RID: 8255 RVA: 0x001E304C File Offset: 0x001E124C
		[OneWay]
		public void OurRemoteAsyncCallBack_CancelCastleAttack(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CancelCastleAttack remoteAsyncDelegate_CancelCastleAttack = (RemoteServices.RemoteAsyncDelegate_CancelCastleAttack)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CancelCastleAttack.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CancelCastleAttack_ReturnType returnData = new CancelCastleAttack_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002040 RID: 8256 RVA: 0x0001DCBE File Offset: 0x0001BEBE
		public void set_SendReinforcements_UserCallBack(RemoteServices.SendReinforcements_UserCallBack callback)
		{
			this.sendReinforcements_UserCallBack = callback;
		}

		// Token: 0x06002041 RID: 8257 RVA: 0x001E309C File Offset: 0x001E129C
		public void SendReinforcements(int sourceVillageID, int targetVillageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults)
		{
			if (this.SendReinforcements_Callback == null)
			{
				this.SendReinforcements_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendReinforcements);
			}
			RemoteServices.RemoteAsyncDelegate_SendReinforcements remoteAsyncDelegate_SendReinforcements = new RemoteServices.RemoteAsyncDelegate_SendReinforcements(this.service.SendReinforcements);
			this.registerRPCcall(remoteAsyncDelegate_SendReinforcements.BeginInvoke(this.UserID, this.SessionID, sourceVillageID, targetVillageID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, this.SendReinforcements_Callback, null), typeof(SendReinforcements_ReturnType));
		}

		// Token: 0x06002042 RID: 8258 RVA: 0x001E310C File Offset: 0x001E130C
		[OneWay]
		public void OurRemoteAsyncCallBack_SendReinforcements(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendReinforcements remoteAsyncDelegate_SendReinforcements = (RemoteServices.RemoteAsyncDelegate_SendReinforcements)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendReinforcements.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendReinforcements_ReturnType returnData = new SendReinforcements_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002043 RID: 8259 RVA: 0x0001DCC7 File Offset: 0x0001BEC7
		public void set_ReturnReinforcements_UserCallBack(RemoteServices.ReturnReinforcements_UserCallBack callback)
		{
			this.returnReinforcements_UserCallBack = callback;
		}

		// Token: 0x06002044 RID: 8260 RVA: 0x001E315C File Offset: 0x001E135C
		public void ReturnReinforcements(long reinforcementID)
		{
			if (this.ReturnReinforcements_Callback == null)
			{
				this.ReturnReinforcements_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ReturnReinforcements);
			}
			RemoteServices.RemoteAsyncDelegate_ReturnReinforcements remoteAsyncDelegate_ReturnReinforcements = new RemoteServices.RemoteAsyncDelegate_ReturnReinforcements(this.service.ReturnReinforcements);
			this.registerRPCcall(remoteAsyncDelegate_ReturnReinforcements.BeginInvoke(this.UserID, this.SessionID, reinforcementID, -1, -1, -1, -1, -1, this.ReturnReinforcements_Callback, null), typeof(ReturnReinforcements_ReturnType));
		}

		// Token: 0x06002045 RID: 8261 RVA: 0x001E31C8 File Offset: 0x001E13C8
		public void ReturnReinforcements(long reinforcementID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults)
		{
			if (this.ReturnReinforcements_Callback == null)
			{
				this.ReturnReinforcements_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ReturnReinforcements);
			}
			RemoteServices.RemoteAsyncDelegate_ReturnReinforcements remoteAsyncDelegate_ReturnReinforcements = new RemoteServices.RemoteAsyncDelegate_ReturnReinforcements(this.service.ReturnReinforcements);
			this.registerRPCcall(remoteAsyncDelegate_ReturnReinforcements.BeginInvoke(this.UserID, this.SessionID, reinforcementID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, this.ReturnReinforcements_Callback, null), typeof(ReturnReinforcements_ReturnType));
		}

		// Token: 0x06002046 RID: 8262 RVA: 0x001E3234 File Offset: 0x001E1434
		[OneWay]
		public void OurRemoteAsyncCallBack_ReturnReinforcements(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ReturnReinforcements remoteAsyncDelegate_ReturnReinforcements = (RemoteServices.RemoteAsyncDelegate_ReturnReinforcements)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ReturnReinforcements.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ReturnReinforcements_ReturnType returnData = new ReturnReinforcements_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002047 RID: 8263 RVA: 0x0001DCD0 File Offset: 0x0001BED0
		public void set_SendMarketResources_UserCallBack(RemoteServices.SendMarketResources_UserCallBack callback)
		{
			this.sendMarketResources_UserCallBack = callback;
		}

		// Token: 0x06002048 RID: 8264 RVA: 0x001E3284 File Offset: 0x001E1484
		public void SendMarketResources(int homeVillageID, int targetVillage, int resource, int amount)
		{
			if (this.SendMarketResources_Callback == null)
			{
				this.SendMarketResources_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendMarketResources);
			}
			RemoteServices.RemoteAsyncDelegate_SendMarketResources remoteAsyncDelegate_SendMarketResources = new RemoteServices.RemoteAsyncDelegate_SendMarketResources(this.service.SendMarketResources);
			this.registerRPCcall(remoteAsyncDelegate_SendMarketResources.BeginInvoke(this.UserID, this.SessionID, homeVillageID, targetVillage, resource, amount, this.SendMarketResources_Callback, null), typeof(SendMarketResources_ReturnType));
		}

		// Token: 0x06002049 RID: 8265 RVA: 0x001E32EC File Offset: 0x001E14EC
		[OneWay]
		public void OurRemoteAsyncCallBack_SendMarketResources(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendMarketResources remoteAsyncDelegate_SendMarketResources = (RemoteServices.RemoteAsyncDelegate_SendMarketResources)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendMarketResources.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendMarketResources_ReturnType returnData = new SendMarketResources_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600204A RID: 8266 RVA: 0x0001DCD9 File Offset: 0x0001BED9
		public void set_GetUserTraders_UserCallBack(RemoteServices.GetUserTraders_UserCallBack callback)
		{
			this.getUserTraders_UserCallBack = callback;
		}

		// Token: 0x0600204B RID: 8267 RVA: 0x001E333C File Offset: 0x001E153C
		public void GetUserTraders()
		{
			if (this.GetUserTraders_Callback == null)
			{
				this.GetUserTraders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserTraders);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserTraders remoteAsyncDelegate_GetUserTraders = new RemoteServices.RemoteAsyncDelegate_GetUserTraders(this.service.GetUserTraders);
			this.registerRPCcall(remoteAsyncDelegate_GetUserTraders.BeginInvoke(this.UserID, this.SessionID, -1, this.GetUserTraders_Callback, null), typeof(GetUserTraders_ReturnType));
		}

		// Token: 0x0600204C RID: 8268 RVA: 0x001E33A0 File Offset: 0x001E15A0
		public void GetUserTraders(int villageID)
		{
			if (this.GetUserTraders_Callback == null)
			{
				this.GetUserTraders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserTraders);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserTraders remoteAsyncDelegate_GetUserTraders = new RemoteServices.RemoteAsyncDelegate_GetUserTraders(this.service.GetUserTraders);
			this.registerRPCcall(remoteAsyncDelegate_GetUserTraders.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetUserTraders_Callback, null), typeof(GetUserTraders_ReturnType));
		}

		// Token: 0x0600204D RID: 8269 RVA: 0x001E3404 File Offset: 0x001E1604
		[OneWay]
		public void OurRemoteAsyncCallBack_GetUserTraders(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetUserTraders remoteAsyncDelegate_GetUserTraders = (RemoteServices.RemoteAsyncDelegate_GetUserTraders)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetUserTraders.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetUserTraders_ReturnType returnData = new GetUserTraders_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600204E RID: 8270 RVA: 0x0001DCE2 File Offset: 0x0001BEE2
		public void set_GetActiveTraders_UserCallBack(RemoteServices.GetActiveTraders_UserCallBack callback)
		{
			this.getActiveTraders_UserCallBack = callback;
		}

		// Token: 0x0600204F RID: 8271 RVA: 0x001E3454 File Offset: 0x001E1654
		public void GetActiveTraders(DateTime lastTime)
		{
			if (this.GetActiveTraders_Callback == null)
			{
				this.GetActiveTraders_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetActiveTraders);
			}
			RemoteServices.RemoteAsyncDelegate_GetActiveTraders remoteAsyncDelegate_GetActiveTraders = new RemoteServices.RemoteAsyncDelegate_GetActiveTraders(this.service.GetActiveTraders);
			this.registerRPCcall(remoteAsyncDelegate_GetActiveTraders.BeginInvoke(this.UserID, this.SessionID, lastTime, this.GetActiveTraders_Callback, null), typeof(GetActiveTraders_ReturnType));
		}

		// Token: 0x06002050 RID: 8272 RVA: 0x001E34B8 File Offset: 0x001E16B8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetActiveTraders(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetActiveTraders remoteAsyncDelegate_GetActiveTraders = (RemoteServices.RemoteAsyncDelegate_GetActiveTraders)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetActiveTraders.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetActiveTraders_ReturnType returnData = new GetActiveTraders_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x0001DCEB File Offset: 0x0001BEEB
		public void set_GetStockExchangeData_UserCallBack(RemoteServices.GetStockExchangeData_UserCallBack callback)
		{
			this.getStockExchangeData_UserCallBack = callback;
		}

		// Token: 0x06002052 RID: 8274 RVA: 0x001E3508 File Offset: 0x001E1708
		public void GetStockExchangeData(int villageID, bool stockExchange)
		{
			if (this.GetStockExchangeData_Callback == null)
			{
				this.GetStockExchangeData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetStockExchangeData);
			}
			RemoteServices.RemoteAsyncDelegate_GetStockExchangeData remoteAsyncDelegate_GetStockExchangeData = new RemoteServices.RemoteAsyncDelegate_GetStockExchangeData(this.service.GetStockExchangeData);
			this.registerRPCcall(remoteAsyncDelegate_GetStockExchangeData.BeginInvoke(this.UserID, this.SessionID, villageID, stockExchange, null, this.GetStockExchangeData_Callback, null), typeof(GetStockExchangeData_ReturnType));
		}

		// Token: 0x06002053 RID: 8275 RVA: 0x001E3570 File Offset: 0x001E1770
		public void GetStockExchangePremiumData(int villageID, int[] closeVillages)
		{
			if (this.GetStockExchangeData_Callback == null)
			{
				this.GetStockExchangeData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetStockExchangeData);
			}
			RemoteServices.RemoteAsyncDelegate_GetStockExchangeData remoteAsyncDelegate_GetStockExchangeData = new RemoteServices.RemoteAsyncDelegate_GetStockExchangeData(this.service.GetStockExchangeData);
			this.registerRPCcall(remoteAsyncDelegate_GetStockExchangeData.BeginInvoke(this.UserID, this.SessionID, villageID, true, closeVillages, this.GetStockExchangeData_Callback, null), typeof(GetStockExchangeData_ReturnType));
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x001E35D8 File Offset: 0x001E17D8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetStockExchangeData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetStockExchangeData remoteAsyncDelegate_GetStockExchangeData = (RemoteServices.RemoteAsyncDelegate_GetStockExchangeData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetStockExchangeData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetStockExchangeData_ReturnType returnData = new GetStockExchangeData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002055 RID: 8277 RVA: 0x0001DCF4 File Offset: 0x0001BEF4
		public void set_StockExchangeTrade_UserCallBack(RemoteServices.StockExchangeTrade_UserCallBack callback)
		{
			this.stockExchangeTrade_UserCallBack = callback;
		}

		// Token: 0x06002056 RID: 8278 RVA: 0x001E3628 File Offset: 0x001E1828
		public void StockExchangeTrade(int villageID, int targetExchange, int resource, int amount, bool buy)
		{
			if (this.StockExchangeTrade_Callback == null)
			{
				this.StockExchangeTrade_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_StockExchangeTrade);
			}
			RemoteServices.RemoteAsyncDelegate_StockExchangeTrade remoteAsyncDelegate_StockExchangeTrade = new RemoteServices.RemoteAsyncDelegate_StockExchangeTrade(this.service.StockExchangeTrade);
			this.registerRPCcall(remoteAsyncDelegate_StockExchangeTrade.BeginInvoke(this.UserID, this.SessionID, villageID, targetExchange, resource, amount, buy, this.StockExchangeTrade_Callback, null), typeof(StockExchangeTrade_ReturnType));
		}

		// Token: 0x06002057 RID: 8279 RVA: 0x001E3694 File Offset: 0x001E1894
		[OneWay]
		public void OurRemoteAsyncCallBack_StockExchangeTrade(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_StockExchangeTrade remoteAsyncDelegate_StockExchangeTrade = (RemoteServices.RemoteAsyncDelegate_StockExchangeTrade)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_StockExchangeTrade.EndInvoke(ar));
			}
			catch (Exception e)
			{
				StockExchangeTrade_ReturnType returnData = new StockExchangeTrade_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002058 RID: 8280 RVA: 0x0001DCFD File Offset: 0x0001BEFD
		public void set_UpdateVillageFavourites_UserCallBack(RemoteServices.UpdateVillageFavourites_UserCallBack callback)
		{
			this.updateVillageFavourites_UserCallBack = callback;
		}

		// Token: 0x06002059 RID: 8281 RVA: 0x001E36E4 File Offset: 0x001E18E4
		public void UpdateVillageFavourites(int mode, int villageID)
		{
			if (this.UpdateVillageFavourites_Callback == null)
			{
				this.UpdateVillageFavourites_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateVillageFavourites);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateVillageFavourites remoteAsyncDelegate_UpdateVillageFavourites = new RemoteServices.RemoteAsyncDelegate_UpdateVillageFavourites(this.service.UpdateVillageFavourites);
			this.registerRPCcall(remoteAsyncDelegate_UpdateVillageFavourites.BeginInvoke(this.UserID, this.SessionID, mode, villageID, this.UpdateVillageFavourites_Callback, null), typeof(UpdateVillageFavourites_ReturnType));
		}

		// Token: 0x0600205A RID: 8282 RVA: 0x001E374C File Offset: 0x001E194C
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateVillageFavourites(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateVillageFavourites remoteAsyncDelegate_UpdateVillageFavourites = (RemoteServices.RemoteAsyncDelegate_UpdateVillageFavourites)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateVillageFavourites.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateVillageFavourites_ReturnType returnData = new UpdateVillageFavourites_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600205B RID: 8283 RVA: 0x0001DD06 File Offset: 0x0001BF06
		public void set_MakeTroop_UserCallBack(RemoteServices.MakeTroop_UserCallBack callback)
		{
			this.makeTroop_UserCallBack = callback;
		}

		// Token: 0x0600205C RID: 8284 RVA: 0x001E379C File Offset: 0x001E199C
		public void MakeTroop(int villageID, int troopType, int amount)
		{
			if (this.MakeTroop_Callback == null)
			{
				this.MakeTroop_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakeTroop);
			}
			RemoteServices.RemoteAsyncDelegate_MakeTroop remoteAsyncDelegate_MakeTroop = new RemoteServices.RemoteAsyncDelegate_MakeTroop(this.service.MakeTroop);
			this.registerRPCcall(remoteAsyncDelegate_MakeTroop.BeginInvoke(this.UserID, this.SessionID, villageID, troopType, amount, this.MakeTroop_Callback, null), typeof(MakeTroop_ReturnType));
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x001E3804 File Offset: 0x001E1A04
		[OneWay]
		public void OurRemoteAsyncCallBack_MakeTroop(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakeTroop remoteAsyncDelegate_MakeTroop = (RemoteServices.RemoteAsyncDelegate_MakeTroop)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakeTroop.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakeTroop_ReturnType returnData = new MakeTroop_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600205E RID: 8286 RVA: 0x0001DD0F File Offset: 0x0001BF0F
		public void set_UpgradeRank_UserCallBack(RemoteServices.UpgradeRank_UserCallBack callback)
		{
			this.upgradeRank_UserCallBack = callback;
		}

		// Token: 0x0600205F RID: 8287 RVA: 0x001E3854 File Offset: 0x001E1A54
		public void UpgradeRank(int rank, int rankSubLevel)
		{
			if (this.UpgradeRank_Callback == null)
			{
				this.UpgradeRank_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpgradeRank);
			}
			RemoteServices.RemoteAsyncDelegate_UpgradeRank remoteAsyncDelegate_UpgradeRank = new RemoteServices.RemoteAsyncDelegate_UpgradeRank(this.service.UpgradeRank);
			this.registerRPCcall(remoteAsyncDelegate_UpgradeRank.BeginInvoke(this.UserID, this.SessionID, rank, rankSubLevel, this.UpgradeRank_Callback, null), typeof(UpgradeRank_ReturnType));
		}

		// Token: 0x06002060 RID: 8288 RVA: 0x001E38BC File Offset: 0x001E1ABC
		[OneWay]
		public void OurRemoteAsyncCallBack_UpgradeRank(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpgradeRank remoteAsyncDelegate_UpgradeRank = (RemoteServices.RemoteAsyncDelegate_UpgradeRank)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpgradeRank.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpgradeRank_ReturnType returnData = new UpgradeRank_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002061 RID: 8289 RVA: 0x0001DD18 File Offset: 0x0001BF18
		public void set_PreAttackSetup_UserCallBack(RemoteServices.PreAttackSetup_UserCallBack callback)
		{
			this.preAttackSetup_UserCallBack = callback;
		}

		// Token: 0x06002062 RID: 8290 RVA: 0x001E390C File Offset: 0x001E1B0C
		public void PreAttackSetup(int parentAttackingVillage, int attackingVillage, int targetVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackType, int pillagePercent, int captainsCommand)
		{
			if (this.PreAttackSetup_Callback == null)
			{
				this.PreAttackSetup_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_PreAttackSetup);
			}
			RemoteServices.RemoteAsyncDelegate_PreAttackSetup remoteAsyncDelegate_PreAttackSetup = new RemoteServices.RemoteAsyncDelegate_PreAttackSetup(this.service.PreAttackSetup);
			this.registerRPCcall(remoteAsyncDelegate_PreAttackSetup.BeginInvoke(this.UserID, this.SessionID, parentAttackingVillage, attackingVillage, targetVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, attackType, pillagePercent, captainsCommand, this.PreAttackSetup_Callback, null), typeof(PreAttackSetup_ReturnType));
		}

		// Token: 0x06002063 RID: 8291 RVA: 0x001E3984 File Offset: 0x001E1B84
		[OneWay]
		public void OurRemoteAsyncCallBack_PreAttackSetup(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_PreAttackSetup remoteAsyncDelegate_PreAttackSetup = (RemoteServices.RemoteAsyncDelegate_PreAttackSetup)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_PreAttackSetup.EndInvoke(ar));
			}
			catch (Exception e)
			{
				PreAttackSetup_ReturnType returnData = new PreAttackSetup_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002064 RID: 8292 RVA: 0x0001DD21 File Offset: 0x0001BF21
		public void set_GetBattleHonourRating_UserCallBack(RemoteServices.GetBattleHonourRating_UserCallBack callback)
		{
			this.getBattleHonourRating_UserCallBack = callback;
		}

		// Token: 0x06002065 RID: 8293 RVA: 0x001E39D4 File Offset: 0x001E1BD4
		public void GetBattleHonourRating(int attackedVillage)
		{
			if (this.GetBattleHonourRating_Callback == null)
			{
				this.GetBattleHonourRating_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetBattleHonourRating);
			}
			RemoteServices.RemoteAsyncDelegate_GetBattleHonourRating remoteAsyncDelegate_GetBattleHonourRating = new RemoteServices.RemoteAsyncDelegate_GetBattleHonourRating(this.service.GetBattleHonourRating);
			this.registerRPCcall(remoteAsyncDelegate_GetBattleHonourRating.BeginInvoke(this.UserID, this.SessionID, attackedVillage, this.GetBattleHonourRating_Callback, null), typeof(GetBattleHonourRating_ReturnType));
		}

		// Token: 0x06002066 RID: 8294 RVA: 0x001E3A38 File Offset: 0x001E1C38
		[OneWay]
		public void OurRemoteAsyncCallBack_GetBattleHonourRating(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetBattleHonourRating remoteAsyncDelegate_GetBattleHonourRating = (RemoteServices.RemoteAsyncDelegate_GetBattleHonourRating)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetBattleHonourRating.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetBattleHonourRating_ReturnType returnData = new GetBattleHonourRating_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002067 RID: 8295 RVA: 0x0001DD2A File Offset: 0x0001BF2A
		public void set_RetrieveArmyFromGarrison_UserCallBack(RemoteServices.RetrieveArmyFromGarrison_UserCallBack callback)
		{
			this.retrieveArmyFromGarrison_UserCallBack = callback;
		}

		// Token: 0x06002068 RID: 8296 RVA: 0x001E3A88 File Offset: 0x001E1C88
		public void RetrieveArmyFromGarrison(int villageID)
		{
			if (this.RetrieveArmyFromGarrison_Callback == null)
			{
				this.RetrieveArmyFromGarrison_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveArmyFromGarrison);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveArmyFromGarrison remoteAsyncDelegate_RetrieveArmyFromGarrison = new RemoteServices.RemoteAsyncDelegate_RetrieveArmyFromGarrison(this.service.RetrieveArmyFromGarrison);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveArmyFromGarrison.BeginInvoke(this.UserID, this.SessionID, villageID, this.RetrieveArmyFromGarrison_Callback, null), typeof(RetrieveArmyFromGarrison_ReturnType));
		}

		// Token: 0x06002069 RID: 8297 RVA: 0x001E3AEC File Offset: 0x001E1CEC
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveArmyFromGarrison(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveArmyFromGarrison remoteAsyncDelegate_RetrieveArmyFromGarrison = (RemoteServices.RemoteAsyncDelegate_RetrieveArmyFromGarrison)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveArmyFromGarrison.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveArmyFromGarrison_ReturnType returnData = new RetrieveArmyFromGarrison_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x0001DD33 File Offset: 0x0001BF33
		public void set_RetrieveVillageUserInfo_UserCallBack(RemoteServices.RetrieveVillageUserInfo_UserCallBack callback)
		{
			this.retrieveVillageUserInfo_UserCallBack = callback;
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x001E3B3C File Offset: 0x001E1D3C
		public void RetrieveVillageUserInfo(int villageID, int targetUserID, bool extended)
		{
			if (this.RetrieveVillageUserInfo_Callback == null)
			{
				this.RetrieveVillageUserInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveVillageUserInfo);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveVillageUserInfo remoteAsyncDelegate_RetrieveVillageUserInfo = new RemoteServices.RemoteAsyncDelegate_RetrieveVillageUserInfo(this.service.RetrieveVillageUserInfo);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveVillageUserInfo.BeginInvoke(this.UserID, this.SessionID, villageID, targetUserID, extended, this.RetrieveVillageUserInfo_Callback, null), typeof(RetrieveVillageUserInfo_ReturnType));
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x001E3BA4 File Offset: 0x001E1DA4
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveVillageUserInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveVillageUserInfo remoteAsyncDelegate_RetrieveVillageUserInfo = (RemoteServices.RemoteAsyncDelegate_RetrieveVillageUserInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveVillageUserInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveVillageUserInfo_ReturnType returnData = new RetrieveVillageUserInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600206D RID: 8301 RVA: 0x0001DD3C File Offset: 0x0001BF3C
		public void set_SpecialVillageInfo_UserCallBack(RemoteServices.SpecialVillageInfo_UserCallBack callback)
		{
			this.specialVillageInfo_UserCallBack = callback;
		}

		// Token: 0x0600206E RID: 8302 RVA: 0x001E3BF4 File Offset: 0x001E1DF4
		public void SpecialVillageInfo(int villageID)
		{
			if (this.SpecialVillageInfo_Callback == null)
			{
				this.SpecialVillageInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpecialVillageInfo);
			}
			RemoteServices.RemoteAsyncDelegate_SpecialVillageInfo remoteAsyncDelegate_SpecialVillageInfo = new RemoteServices.RemoteAsyncDelegate_SpecialVillageInfo(this.service.SpecialVillageInfo);
			this.registerRPCcall(remoteAsyncDelegate_SpecialVillageInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.SpecialVillageInfo_Callback, null), typeof(SpecialVillageInfo_ReturnType));
		}

		// Token: 0x0600206F RID: 8303 RVA: 0x001E3C58 File Offset: 0x001E1E58
		[OneWay]
		public void OurRemoteAsyncCallBack_SpecialVillageInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpecialVillageInfo remoteAsyncDelegate_SpecialVillageInfo = (RemoteServices.RemoteAsyncDelegate_SpecialVillageInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpecialVillageInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpecialVillageInfo_ReturnType returnData = new SpecialVillageInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002070 RID: 8304 RVA: 0x0001DD45 File Offset: 0x0001BF45
		public void set_GetVillageRankTaxTree_UserCallBack(RemoteServices.GetVillageRankTaxTree_UserCallBack callback)
		{
			this.getVillageRankTaxTree_UserCallBack = callback;
		}

		// Token: 0x06002071 RID: 8305 RVA: 0x001E3CA8 File Offset: 0x001E1EA8
		public void GetVillageRankTaxTree()
		{
			if (this.GetVillageRankTaxTree_Callback == null)
			{
				this.GetVillageRankTaxTree_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageRankTaxTree);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageRankTaxTree remoteAsyncDelegate_GetVillageRankTaxTree = new RemoteServices.RemoteAsyncDelegate_GetVillageRankTaxTree(this.service.GetVillageRankTaxTree);
			this.registerRPCcall(remoteAsyncDelegate_GetVillageRankTaxTree.BeginInvoke(this.UserID, this.SessionID, this.GetVillageRankTaxTree_Callback, null), typeof(GetVillageRankTaxTree_ReturnType));
		}

		// Token: 0x06002072 RID: 8306 RVA: 0x001E3D0C File Offset: 0x001E1F0C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageRankTaxTree(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageRankTaxTree remoteAsyncDelegate_GetVillageRankTaxTree = (RemoteServices.RemoteAsyncDelegate_GetVillageRankTaxTree)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetVillageRankTaxTree.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetVillageRankTaxTree_ReturnType returnData = new GetVillageRankTaxTree_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002073 RID: 8307 RVA: 0x0001DD4E File Offset: 0x0001BF4E
		public void set_GetResearchData_UserCallBack(RemoteServices.GetResearchData_UserCallBack callback)
		{
			this.getResearchData_UserCallBack = callback;
		}

		// Token: 0x06002074 RID: 8308 RVA: 0x001E3D5C File Offset: 0x001E1F5C
		public void GetResearchData()
		{
			if (this.GetResearchData_Callback == null)
			{
				this.GetResearchData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetResearchData);
			}
			RemoteServices.RemoteAsyncDelegate_GetResearchData remoteAsyncDelegate_GetResearchData = new RemoteServices.RemoteAsyncDelegate_GetResearchData(this.service.GetResearchData);
			this.registerRPCcall(remoteAsyncDelegate_GetResearchData.BeginInvoke(this.UserID, this.SessionID, this.GetResearchData_Callback, null), typeof(GetResearchData_ReturnType));
		}

		// Token: 0x06002075 RID: 8309 RVA: 0x001E3DC0 File Offset: 0x001E1FC0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetResearchData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetResearchData remoteAsyncDelegate_GetResearchData = (RemoteServices.RemoteAsyncDelegate_GetResearchData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetResearchData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetResearchData_ReturnType returnData = new GetResearchData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002076 RID: 8310 RVA: 0x0001DD57 File Offset: 0x0001BF57
		public void set_DoResearch_UserCallBack(RemoteServices.DoResearch_UserCallBack callback)
		{
			this.doResearch_UserCallBack = callback;
		}

		// Token: 0x06002077 RID: 8311 RVA: 0x001E3E10 File Offset: 0x001E2010
		public void DoResearch(int researchType)
		{
			if (this.DoResearch_Callback == null)
			{
				this.DoResearch_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DoResearch);
			}
			RemoteServices.RemoteAsyncDelegate_DoResearch remoteAsyncDelegate_DoResearch = new RemoteServices.RemoteAsyncDelegate_DoResearch(this.service.DoResearch);
			this.registerRPCcall(remoteAsyncDelegate_DoResearch.BeginInvoke(this.UserID, this.SessionID, researchType, -1, this.DoResearch_Callback, null), typeof(DoResearch_ReturnType));
		}

		// Token: 0x06002078 RID: 8312 RVA: 0x001E3E78 File Offset: 0x001E2078
		public void CancelQueuedResearch(int researchType, int queuePos)
		{
			if (this.DoResearch_Callback == null)
			{
				this.DoResearch_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DoResearch);
			}
			RemoteServices.RemoteAsyncDelegate_DoResearch remoteAsyncDelegate_DoResearch = new RemoteServices.RemoteAsyncDelegate_DoResearch(this.service.DoResearch);
			this.registerRPCcall(remoteAsyncDelegate_DoResearch.BeginInvoke(this.UserID, this.SessionID, researchType, queuePos, this.DoResearch_Callback, null), typeof(DoResearch_ReturnType));
		}

		// Token: 0x06002079 RID: 8313 RVA: 0x001E3EE0 File Offset: 0x001E20E0
		[OneWay]
		public void OurRemoteAsyncCallBack_DoResearch(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DoResearch remoteAsyncDelegate_DoResearch = (RemoteServices.RemoteAsyncDelegate_DoResearch)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DoResearch.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DoResearch_ReturnType returnData = new DoResearch_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600207A RID: 8314 RVA: 0x0001DD60 File Offset: 0x0001BF60
		public void set_BuyResearchPoint_UserCallBack(RemoteServices.BuyResearchPoint_UserCallBack callback)
		{
			this.buyResearchPoint_UserCallBack = callback;
		}

		// Token: 0x0600207B RID: 8315 RVA: 0x001E3F30 File Offset: 0x001E2130
		public void BuyResearchPoint()
		{
			if (this.BuyResearchPoint_Callback == null)
			{
				this.BuyResearchPoint_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_BuyResearchPoint);
			}
			RemoteServices.RemoteAsyncDelegate_BuyResearchPoint remoteAsyncDelegate_BuyResearchPoint = new RemoteServices.RemoteAsyncDelegate_BuyResearchPoint(this.service.BuyResearchPoint);
			this.registerRPCcall(remoteAsyncDelegate_BuyResearchPoint.BeginInvoke(this.UserID, this.SessionID, this.BuyResearchPoint_Callback, null), typeof(BuyResearchPoint_ReturnType));
		}

		// Token: 0x0600207C RID: 8316 RVA: 0x001E3F94 File Offset: 0x001E2194
		[OneWay]
		public void OurRemoteAsyncCallBack_BuyResearchPoint(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_BuyResearchPoint remoteAsyncDelegate_BuyResearchPoint = (RemoteServices.RemoteAsyncDelegate_BuyResearchPoint)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_BuyResearchPoint.EndInvoke(ar));
			}
			catch (Exception e)
			{
				BuyResearchPoint_ReturnType returnData = new BuyResearchPoint_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600207D RID: 8317 RVA: 0x0001DD69 File Offset: 0x0001BF69
		public void set_VassalInfo_UserCallBack(RemoteServices.VassalInfo_UserCallBack callback)
		{
			this.vassalInfo_UserCallBack = callback;
		}

		// Token: 0x0600207E RID: 8318 RVA: 0x001E3FE4 File Offset: 0x001E21E4
		public void VassalInfo(int villageID)
		{
			if (this.VassalInfo_Callback == null)
			{
				this.VassalInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VassalInfo);
			}
			RemoteServices.RemoteAsyncDelegate_VassalInfo remoteAsyncDelegate_VassalInfo = new RemoteServices.RemoteAsyncDelegate_VassalInfo(this.service.VassalInfo);
			this.registerRPCcall(remoteAsyncDelegate_VassalInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.VassalInfo_Callback, null), typeof(VassalInfo_ReturnType));
		}

		// Token: 0x0600207F RID: 8319 RVA: 0x001E4048 File Offset: 0x001E2248
		[OneWay]
		public void OurRemoteAsyncCallBack_VassalInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VassalInfo remoteAsyncDelegate_VassalInfo = (RemoteServices.RemoteAsyncDelegate_VassalInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VassalInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VassalInfo_ReturnType returnData = new VassalInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002080 RID: 8320 RVA: 0x0001DD72 File Offset: 0x0001BF72
		public void set_VassalSendResources_UserCallBack(RemoteServices.VassalSendResources_UserCallBack callback)
		{
			this.vassalSendResources_UserCallBack = callback;
		}

		// Token: 0x06002081 RID: 8321 RVA: 0x001E4098 File Offset: 0x001E2298
		public void VassalSendResources(int villageID, int targetVillage, int type, int amount)
		{
			if (this.VassalSendResources_Callback == null)
			{
				this.VassalSendResources_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VassalSendResources);
			}
			RemoteServices.RemoteAsyncDelegate_VassalSendResources remoteAsyncDelegate_VassalSendResources = new RemoteServices.RemoteAsyncDelegate_VassalSendResources(this.service.VassalSendResources);
			this.registerRPCcall(remoteAsyncDelegate_VassalSendResources.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillage, type, amount, this.VassalSendResources_Callback, null), typeof(VassalSendResources_ReturnType));
		}

		// Token: 0x06002082 RID: 8322 RVA: 0x001E4100 File Offset: 0x001E2300
		[OneWay]
		public void OurRemoteAsyncCallBack_VassalSendResources(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VassalSendResources remoteAsyncDelegate_VassalSendResources = (RemoteServices.RemoteAsyncDelegate_VassalSendResources)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VassalSendResources.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VassalSendResources_ReturnType returnData = new VassalSendResources_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002083 RID: 8323 RVA: 0x0001DD7B File Offset: 0x0001BF7B
		public void set_UpdateSelectedTitheType_UserCallBack(RemoteServices.UpdateSelectedTitheType_UserCallBack callback)
		{
			this.updateSelectedTitheType_UserCallBack = callback;
		}

		// Token: 0x06002084 RID: 8324 RVA: 0x001E4150 File Offset: 0x001E2350
		public void UpdateSelectedTitheType(int villageID, int type)
		{
			if (this.UpdateSelectedTitheType_Callback == null)
			{
				this.UpdateSelectedTitheType_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateSelectedTitheType);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateSelectedTitheType remoteAsyncDelegate_UpdateSelectedTitheType = new RemoteServices.RemoteAsyncDelegate_UpdateSelectedTitheType(this.service.UpdateSelectedTitheType);
			this.registerRPCcall(remoteAsyncDelegate_UpdateSelectedTitheType.BeginInvoke(this.UserID, this.SessionID, villageID, type, this.UpdateSelectedTitheType_Callback, null), typeof(UpdateSelectedTitheType_ReturnType));
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x001E41B8 File Offset: 0x001E23B8
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateSelectedTitheType(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateSelectedTitheType remoteAsyncDelegate_UpdateSelectedTitheType = (RemoteServices.RemoteAsyncDelegate_UpdateSelectedTitheType)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateSelectedTitheType.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateSelectedTitheType_ReturnType returnData = new UpdateSelectedTitheType_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002086 RID: 8326 RVA: 0x0001DD84 File Offset: 0x0001BF84
		public void set_BreakVassalage_UserCallBack(RemoteServices.BreakVassalage_UserCallBack callback)
		{
			this.breakVassalage_UserCallBack = callback;
		}

		// Token: 0x06002087 RID: 8327 RVA: 0x001E4208 File Offset: 0x001E2408
		public void BreakVassalage(int villageID, int targetVillage)
		{
			if (this.BreakVassalage_Callback == null)
			{
				this.BreakVassalage_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_BreakVassalage);
			}
			RemoteServices.RemoteAsyncDelegate_BreakVassalage remoteAsyncDelegate_BreakVassalage = new RemoteServices.RemoteAsyncDelegate_BreakVassalage(this.service.BreakVassalage);
			this.registerRPCcall(remoteAsyncDelegate_BreakVassalage.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillage, this.BreakVassalage_Callback, null), typeof(BreakVassalage_ReturnType));
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x001E4270 File Offset: 0x001E2470
		[OneWay]
		public void OurRemoteAsyncCallBack_BreakVassalage(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_BreakVassalage remoteAsyncDelegate_BreakVassalage = (RemoteServices.RemoteAsyncDelegate_BreakVassalage)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_BreakVassalage.EndInvoke(ar));
			}
			catch (Exception e)
			{
				BreakVassalage_ReturnType returnData = new BreakVassalage_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002089 RID: 8329 RVA: 0x0001DD8D File Offset: 0x0001BF8D
		public void set_BreakLiegeLord_UserCallBack(RemoteServices.BreakLiegeLord_UserCallBack callback)
		{
			this.breakLiegeLord_UserCallBack = callback;
		}

		// Token: 0x0600208A RID: 8330 RVA: 0x001E42C0 File Offset: 0x001E24C0
		public void BreakLiegeLord(int villageID, int targetVillage)
		{
			if (this.BreakLiegeLord_Callback == null)
			{
				this.BreakLiegeLord_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_BreakLiegeLord);
			}
			RemoteServices.RemoteAsyncDelegate_BreakLiegeLord remoteAsyncDelegate_BreakLiegeLord = new RemoteServices.RemoteAsyncDelegate_BreakLiegeLord(this.service.BreakLiegeLord);
			this.registerRPCcall(remoteAsyncDelegate_BreakLiegeLord.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillage, this.BreakLiegeLord_Callback, null), typeof(BreakLiegeLord_ReturnType));
		}

		// Token: 0x0600208B RID: 8331 RVA: 0x001E4328 File Offset: 0x001E2528
		[OneWay]
		public void OurRemoteAsyncCallBack_BreakLiegeLord(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_BreakLiegeLord remoteAsyncDelegate_BreakLiegeLord = (RemoteServices.RemoteAsyncDelegate_BreakLiegeLord)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_BreakLiegeLord.EndInvoke(ar));
			}
			catch (Exception e)
			{
				BreakLiegeLord_ReturnType returnData = new BreakLiegeLord_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600208C RID: 8332 RVA: 0x0001DD96 File Offset: 0x0001BF96
		public void set_GetPreVassalInfo_UserCallBack(RemoteServices.GetPreVassalInfo_UserCallBack callback)
		{
			this.getPreVassalInfo_UserCallBack = callback;
		}

		// Token: 0x0600208D RID: 8333 RVA: 0x001E4378 File Offset: 0x001E2578
		public void GetPreVassalInfo(int villageID, int targetVillage)
		{
			if (this.GetPreVassalInfo_Callback == null)
			{
				this.GetPreVassalInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetPreVassalInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetPreVassalInfo remoteAsyncDelegate_GetPreVassalInfo = new RemoteServices.RemoteAsyncDelegate_GetPreVassalInfo(this.service.GetPreVassalInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetPreVassalInfo.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillage, this.GetPreVassalInfo_Callback, null), typeof(GetPreVassalInfo_ReturnType));
		}

		// Token: 0x0600208E RID: 8334 RVA: 0x001E43E0 File Offset: 0x001E25E0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetPreVassalInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetPreVassalInfo remoteAsyncDelegate_GetPreVassalInfo = (RemoteServices.RemoteAsyncDelegate_GetPreVassalInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetPreVassalInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetPreVassalInfo_ReturnType returnData = new GetPreVassalInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600208F RID: 8335 RVA: 0x0001DD9F File Offset: 0x0001BF9F
		public void set_SendVassalRequest_UserCallBack(RemoteServices.SendVassalRequest_UserCallBack callback)
		{
			this.sendVassalRequest_UserCallBack = callback;
		}

		// Token: 0x06002090 RID: 8336 RVA: 0x001E4430 File Offset: 0x001E2630
		public void SendVassalRequest(int villageID, int targetVillage)
		{
			if (this.SendVassalRequest_Callback == null)
			{
				this.SendVassalRequest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendVassalRequest);
			}
			RemoteServices.RemoteAsyncDelegate_SendVassalRequest remoteAsyncDelegate_SendVassalRequest = new RemoteServices.RemoteAsyncDelegate_SendVassalRequest(this.service.SendVassalRequest);
			this.registerRPCcall(remoteAsyncDelegate_SendVassalRequest.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillage, this.SendVassalRequest_Callback, null), typeof(SendVassalRequest_ReturnType));
		}

		// Token: 0x06002091 RID: 8337 RVA: 0x001E4498 File Offset: 0x001E2698
		[OneWay]
		public void OurRemoteAsyncCallBack_SendVassalRequest(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendVassalRequest remoteAsyncDelegate_SendVassalRequest = (RemoteServices.RemoteAsyncDelegate_SendVassalRequest)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendVassalRequest.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendVassalRequest_ReturnType returnData = new SendVassalRequest_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002092 RID: 8338 RVA: 0x0001DDA8 File Offset: 0x0001BFA8
		public void set_HandleVassalRequest_UserCallBack(RemoteServices.HandleVassalRequest_UserCallBack callback)
		{
			this.handleVassalRequest_UserCallBack = callback;
		}

		// Token: 0x06002093 RID: 8339 RVA: 0x001E44E8 File Offset: 0x001E26E8
		public void AcceptVassalRequest(int requesterVillageID, int vassalVillageID)
		{
			if (this.HandleVassalRequest_Callback == null)
			{
				this.HandleVassalRequest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_HandleVassalRequest);
			}
			RemoteServices.RemoteAsyncDelegate_HandleVassalRequest remoteAsyncDelegate_HandleVassalRequest = new RemoteServices.RemoteAsyncDelegate_HandleVassalRequest(this.service.HandleVassalRequest);
			this.registerRPCcall(remoteAsyncDelegate_HandleVassalRequest.BeginInvoke(this.UserID, this.SessionID, 1, requesterVillageID, vassalVillageID, this.HandleVassalRequest_Callback, null), typeof(HandleVassalRequest_ReturnType));
		}

		// Token: 0x06002094 RID: 8340 RVA: 0x001E4550 File Offset: 0x001E2750
		public void DeclineVassalRequest(int requesterVillageID, int vassalVillageID)
		{
			if (this.HandleVassalRequest_Callback == null)
			{
				this.HandleVassalRequest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_HandleVassalRequest);
			}
			RemoteServices.RemoteAsyncDelegate_HandleVassalRequest remoteAsyncDelegate_HandleVassalRequest = new RemoteServices.RemoteAsyncDelegate_HandleVassalRequest(this.service.HandleVassalRequest);
			this.registerRPCcall(remoteAsyncDelegate_HandleVassalRequest.BeginInvoke(this.UserID, this.SessionID, 2, requesterVillageID, vassalVillageID, this.HandleVassalRequest_Callback, null), typeof(HandleVassalRequest_ReturnType));
		}

		// Token: 0x06002095 RID: 8341 RVA: 0x001E45B8 File Offset: 0x001E27B8
		public void CancelVassalRequest(int requesterVillageID, int vassalVillageID)
		{
			if (this.HandleVassalRequest_Callback == null)
			{
				this.HandleVassalRequest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_HandleVassalRequest);
			}
			RemoteServices.RemoteAsyncDelegate_HandleVassalRequest remoteAsyncDelegate_HandleVassalRequest = new RemoteServices.RemoteAsyncDelegate_HandleVassalRequest(this.service.HandleVassalRequest);
			this.registerRPCcall(remoteAsyncDelegate_HandleVassalRequest.BeginInvoke(this.UserID, this.SessionID, 3, requesterVillageID, vassalVillageID, this.HandleVassalRequest_Callback, null), typeof(HandleVassalRequest_ReturnType));
		}

		// Token: 0x06002096 RID: 8342 RVA: 0x001E4620 File Offset: 0x001E2820
		[OneWay]
		public void OurRemoteAsyncCallBack_HandleVassalRequest(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_HandleVassalRequest remoteAsyncDelegate_HandleVassalRequest = (RemoteServices.RemoteAsyncDelegate_HandleVassalRequest)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_HandleVassalRequest.EndInvoke(ar));
			}
			catch (Exception e)
			{
				HandleVassalRequest_ReturnType returnData = new HandleVassalRequest_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x0001DDB1 File Offset: 0x0001BFB1
		public void set_GetVassalArmyInfo_UserCallBack(RemoteServices.GetVassalArmyInfo_UserCallBack callback)
		{
			this.getVassalArmyInfo_UserCallBack = callback;
		}

		// Token: 0x06002098 RID: 8344 RVA: 0x001E4670 File Offset: 0x001E2870
		public void GetVassalArmyInfo(int vassalVillageID, int mode, int attackedVillage)
		{
			if (this.GetVassalArmyInfo_Callback == null)
			{
				this.GetVassalArmyInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVassalArmyInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetVassalArmyInfo remoteAsyncDelegate_GetVassalArmyInfo = new RemoteServices.RemoteAsyncDelegate_GetVassalArmyInfo(this.service.GetVassalArmyInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetVassalArmyInfo.BeginInvoke(this.UserID, this.SessionID, vassalVillageID, mode, attackedVillage, this.GetVassalArmyInfo_Callback, null), typeof(GetVassalArmyInfo_ReturnType));
		}

		// Token: 0x06002099 RID: 8345 RVA: 0x001E46D8 File Offset: 0x001E28D8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVassalArmyInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVassalArmyInfo remoteAsyncDelegate_GetVassalArmyInfo = (RemoteServices.RemoteAsyncDelegate_GetVassalArmyInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetVassalArmyInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetVassalArmyInfo_ReturnType returnData = new GetVassalArmyInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600209A RID: 8346 RVA: 0x0001DDBA File Offset: 0x0001BFBA
		public void set_SendTroopsToVassal_UserCallBack(RemoteServices.SendTroopsToVassal_UserCallBack callback)
		{
			this.sendTroopsToVassal_UserCallBack = callback;
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x001E4728 File Offset: 0x001E2928
		public void SendTroopsToVassal(int liegeLordVillageID, int vassalVillageID, int peasants, int archers, int pikemen, int swordsmen, int catapults)
		{
			if (this.SendTroopsToVassal_Callback == null)
			{
				this.SendTroopsToVassal_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendTroopsToVassal);
			}
			RemoteServices.RemoteAsyncDelegate_SendTroopsToVassal remoteAsyncDelegate_SendTroopsToVassal = new RemoteServices.RemoteAsyncDelegate_SendTroopsToVassal(this.service.SendTroopsToVassal);
			this.registerRPCcall(remoteAsyncDelegate_SendTroopsToVassal.BeginInvoke(this.UserID, this.SessionID, liegeLordVillageID, vassalVillageID, peasants, archers, pikemen, swordsmen, catapults, this.SendTroopsToVassal_Callback, null), typeof(SendTroopsToVassal_ReturnType));
		}

		// Token: 0x0600209C RID: 8348 RVA: 0x001E4798 File Offset: 0x001E2998
		[OneWay]
		public void OurRemoteAsyncCallBack_SendTroopsToVassal(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendTroopsToVassal remoteAsyncDelegate_SendTroopsToVassal = (RemoteServices.RemoteAsyncDelegate_SendTroopsToVassal)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendTroopsToVassal.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendTroopsToVassal_ReturnType returnData = new SendTroopsToVassal_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x0001DDC3 File Offset: 0x0001BFC3
		public void set_RetrieveTroopsFromVassal_UserCallBack(RemoteServices.RetrieveTroopsFromVassal_UserCallBack callback)
		{
			this.retrieveTroopsFromVassal_UserCallBack = callback;
		}

		// Token: 0x0600209E RID: 8350 RVA: 0x001E47E8 File Offset: 0x001E29E8
		public void RetrieveTroopsFromVassal(int liegeLordVillageID, int vassalVillageID)
		{
			if (this.RetrieveTroopsFromVassal_Callback == null)
			{
				this.RetrieveTroopsFromVassal_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrieveTroopsFromVassal);
			}
			RemoteServices.RemoteAsyncDelegate_RetrieveTroopsFromVassal remoteAsyncDelegate_RetrieveTroopsFromVassal = new RemoteServices.RemoteAsyncDelegate_RetrieveTroopsFromVassal(this.service.RetrieveTroopsFromVassal);
			this.registerRPCcall(remoteAsyncDelegate_RetrieveTroopsFromVassal.BeginInvoke(this.UserID, this.SessionID, liegeLordVillageID, vassalVillageID, this.RetrieveTroopsFromVassal_Callback, null), typeof(RetrieveTroopsFromVassal_ReturnType));
		}

		// Token: 0x0600209F RID: 8351 RVA: 0x001E4850 File Offset: 0x001E2A50
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrieveTroopsFromVassal(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrieveTroopsFromVassal remoteAsyncDelegate_RetrieveTroopsFromVassal = (RemoteServices.RemoteAsyncDelegate_RetrieveTroopsFromVassal)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrieveTroopsFromVassal.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrieveTroopsFromVassal_ReturnType returnData = new RetrieveTroopsFromVassal_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020A0 RID: 8352 RVA: 0x0001DDCC File Offset: 0x0001BFCC
		public void set_UpdateVillageResourcesInfo_UserCallBack(RemoteServices.UpdateVillageResourcesInfo_UserCallBack callback)
		{
			this.updateVillageResourcesInfo_UserCallBack = callback;
		}

		// Token: 0x060020A1 RID: 8353 RVA: 0x001E48A0 File Offset: 0x001E2AA0
		public void UpdateVillageResourcesInfo(int villageID)
		{
			if (this.UpdateVillageResourcesInfo_Callback == null)
			{
				this.UpdateVillageResourcesInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateVillageResourcesInfo);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateVillageResourcesInfo remoteAsyncDelegate_UpdateVillageResourcesInfo = new RemoteServices.RemoteAsyncDelegate_UpdateVillageResourcesInfo(this.service.UpdateVillageResourcesInfo);
			this.registerRPCcall(remoteAsyncDelegate_UpdateVillageResourcesInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.UpdateVillageResourcesInfo_Callback, null), typeof(UpdateVillageResourcesInfo_ReturnType));
		}

		// Token: 0x060020A2 RID: 8354 RVA: 0x001E4904 File Offset: 0x001E2B04
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateVillageResourcesInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateVillageResourcesInfo remoteAsyncDelegate_UpdateVillageResourcesInfo = (RemoteServices.RemoteAsyncDelegate_UpdateVillageResourcesInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateVillageResourcesInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateVillageResourcesInfo_ReturnType returnData = new UpdateVillageResourcesInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020A3 RID: 8355 RVA: 0x0001DDD5 File Offset: 0x0001BFD5
		public void set_SetHighestArmySeen_UserCallBack(RemoteServices.SetHighestArmySeen_UserCallBack callback)
		{
			this.setHighestArmySeen_UserCallBack = callback;
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x001E4954 File Offset: 0x001E2B54
		public void SetHighestArmySeen(long highestArmyIDSeen)
		{
			if (this.SetHighestArmySeen_Callback == null)
			{
				this.SetHighestArmySeen_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SetHighestArmySeen);
			}
			RemoteServices.RemoteAsyncDelegate_SetHighestArmySeen remoteAsyncDelegate_SetHighestArmySeen = new RemoteServices.RemoteAsyncDelegate_SetHighestArmySeen(this.service.SetHighestArmySeen);
			this.registerRPCcall(remoteAsyncDelegate_SetHighestArmySeen.BeginInvoke(this.UserID, this.SessionID, highestArmyIDSeen, this.SetHighestArmySeen_Callback, null), typeof(SetHighestArmySeen_ReturnType));
		}

		// Token: 0x060020A5 RID: 8357 RVA: 0x001E49B8 File Offset: 0x001E2BB8
		[OneWay]
		public void OurRemoteAsyncCallBack_SetHighestArmySeen(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SetHighestArmySeen remoteAsyncDelegate_SetHighestArmySeen = (RemoteServices.RemoteAsyncDelegate_SetHighestArmySeen)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SetHighestArmySeen.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SetHighestArmySeen_ReturnType returnData = new SetHighestArmySeen_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x0001DDDE File Offset: 0x0001BFDE
		public void set_GetForumList_UserCallBack(RemoteServices.GetForumList_UserCallBack callback)
		{
			this.getForumList_UserCallBack = callback;
		}

		// Token: 0x060020A7 RID: 8359 RVA: 0x001E4A08 File Offset: 0x001E2C08
		public void GetForumList(int areaID, int areaType)
		{
			if (this.GetForumList_Callback == null)
			{
				this.GetForumList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetForumList);
			}
			RemoteServices.RemoteAsyncDelegate_GetForumList remoteAsyncDelegate_GetForumList = new RemoteServices.RemoteAsyncDelegate_GetForumList(this.service.GetForumList);
			this.registerRPCcall(remoteAsyncDelegate_GetForumList.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, this.GetForumList_Callback, null), typeof(GetForumList_ReturnType));
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x001E4A70 File Offset: 0x001E2C70
		[OneWay]
		public void OurRemoteAsyncCallBack_GetForumList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetForumList remoteAsyncDelegate_GetForumList = (RemoteServices.RemoteAsyncDelegate_GetForumList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetForumList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetForumList_ReturnType returnData = new GetForumList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x0001DDE7 File Offset: 0x0001BFE7
		public void set_GetForumThreadList_UserCallBack(RemoteServices.GetForumThreadList_UserCallBack callback)
		{
			this.getForumThreadList_UserCallBack = callback;
		}

		// Token: 0x060020AA RID: 8362 RVA: 0x001E4AC0 File Offset: 0x001E2CC0
		public void GetForumThreadList(long forumID, DateTime lastGet, bool forceGet)
		{
			if (this.GetForumThreadList_Callback == null)
			{
				this.GetForumThreadList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetForumThreadList);
			}
			RemoteServices.RemoteAsyncDelegate_GetForumThreadList remoteAsyncDelegate_GetForumThreadList = new RemoteServices.RemoteAsyncDelegate_GetForumThreadList(this.service.GetForumThreadList);
			this.registerRPCcall(remoteAsyncDelegate_GetForumThreadList.BeginInvoke(this.UserID, this.SessionID, forumID, lastGet, forceGet, this.GetForumThreadList_Callback, null), typeof(GetForumThreadList_ReturnType));
		}

		// Token: 0x060020AB RID: 8363 RVA: 0x001E4B28 File Offset: 0x001E2D28
		[OneWay]
		public void OurRemoteAsyncCallBack_GetForumThreadList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetForumThreadList remoteAsyncDelegate_GetForumThreadList = (RemoteServices.RemoteAsyncDelegate_GetForumThreadList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetForumThreadList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetForumThreadList_ReturnType returnData = new GetForumThreadList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x0001DDF0 File Offset: 0x0001BFF0
		public void set_GetForumThread_UserCallBack(RemoteServices.GetForumThread_UserCallBack callback)
		{
			this.getForumThread_UserCallBack = callback;
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x001E4B78 File Offset: 0x001E2D78
		public void GetForumThread(long forumID, long threadID, DateTime lastGet, bool forceGet)
		{
			if (this.GetForumThread_Callback == null)
			{
				this.GetForumThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetForumThread);
			}
			RemoteServices.RemoteAsyncDelegate_GetForumThread remoteAsyncDelegate_GetForumThread = new RemoteServices.RemoteAsyncDelegate_GetForumThread(this.service.GetForumThread);
			this.registerRPCcall(remoteAsyncDelegate_GetForumThread.BeginInvoke(this.UserID, this.SessionID, forumID, threadID, lastGet, forceGet, this.GetForumThread_Callback, null), typeof(GetForumThread_ReturnType));
		}

		// Token: 0x060020AE RID: 8366 RVA: 0x001E4BE0 File Offset: 0x001E2DE0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetForumThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetForumThread remoteAsyncDelegate_GetForumThread = (RemoteServices.RemoteAsyncDelegate_GetForumThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetForumThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetForumThread_ReturnType returnData = new GetForumThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x0001DDF9 File Offset: 0x0001BFF9
		public void set_NewForumThread_UserCallBack(RemoteServices.NewForumThread_UserCallBack callback)
		{
			this.newForumThread_UserCallBack = callback;
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x001E4C30 File Offset: 0x001E2E30
		public void NewForumThread(long forumID, string headingText, string bodyText)
		{
			if (this.NewForumThread_Callback == null)
			{
				this.NewForumThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_NewForumThread);
			}
			RemoteServices.RemoteAsyncDelegate_NewForumThread remoteAsyncDelegate_NewForumThread = new RemoteServices.RemoteAsyncDelegate_NewForumThread(this.service.NewForumThread);
			this.registerRPCcall(remoteAsyncDelegate_NewForumThread.BeginInvoke(this.UserID, this.SessionID, forumID, headingText, bodyText, this.NewForumThread_Callback, null), typeof(NewForumThread_ReturnType));
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x001E4C98 File Offset: 0x001E2E98
		[OneWay]
		public void OurRemoteAsyncCallBack_NewForumThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_NewForumThread remoteAsyncDelegate_NewForumThread = (RemoteServices.RemoteAsyncDelegate_NewForumThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_NewForumThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				NewForumThread_ReturnType returnData = new NewForumThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x0001DE02 File Offset: 0x0001C002
		public void set_PostToForumThread_UserCallBack(RemoteServices.PostToForumThread_UserCallBack callback)
		{
			this.postToForumThread_UserCallBack = callback;
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x001E4CE8 File Offset: 0x001E2EE8
		public void PostToForumThread(long threadID, long forumID, string text)
		{
			if (this.PostToForumThread_Callback == null)
			{
				this.PostToForumThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_PostToForumThread);
			}
			RemoteServices.RemoteAsyncDelegate_PostToForumThread remoteAsyncDelegate_PostToForumThread = new RemoteServices.RemoteAsyncDelegate_PostToForumThread(this.service.PostToForumThread);
			this.registerRPCcall(remoteAsyncDelegate_PostToForumThread.BeginInvoke(this.UserID, this.SessionID, threadID, forumID, text, this.PostToForumThread_Callback, null), typeof(PostToForumThread_ReturnType));
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x001E4D50 File Offset: 0x001E2F50
		[OneWay]
		public void OurRemoteAsyncCallBack_PostToForumThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_PostToForumThread remoteAsyncDelegate_PostToForumThread = (RemoteServices.RemoteAsyncDelegate_PostToForumThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_PostToForumThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				PostToForumThread_ReturnType returnData = new PostToForumThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x0001DE0B File Offset: 0x0001C00B
		public void set_GiveForumAccess_UserCallBack(RemoteServices.GiveForumAccess_UserCallBack callback)
		{
			this.giveForumAccess_UserCallBack = callback;
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x001E4DA0 File Offset: 0x001E2FA0
		public void GiveForumAccess(long forumID, int[] users)
		{
			if (this.GiveForumAccess_Callback == null)
			{
				this.GiveForumAccess_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GiveForumAccess);
			}
			RemoteServices.RemoteAsyncDelegate_GiveForumAccess remoteAsyncDelegate_GiveForumAccess = new RemoteServices.RemoteAsyncDelegate_GiveForumAccess(this.service.GiveForumAccess);
			this.registerRPCcall(remoteAsyncDelegate_GiveForumAccess.BeginInvoke(this.UserID, this.SessionID, forumID, users, this.GiveForumAccess_Callback, null), typeof(GiveForumAccess_ReturnType));
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x001E4E08 File Offset: 0x001E3008
		[OneWay]
		public void OurRemoteAsyncCallBack_GiveForumAccess(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GiveForumAccess remoteAsyncDelegate_GiveForumAccess = (RemoteServices.RemoteAsyncDelegate_GiveForumAccess)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GiveForumAccess.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GiveForumAccess_ReturnType returnData = new GiveForumAccess_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020B8 RID: 8376 RVA: 0x0001DE14 File Offset: 0x0001C014
		public void set_CreateForum_UserCallBack(RemoteServices.CreateForum_UserCallBack callback)
		{
			this.createForum_UserCallBack = callback;
		}

		// Token: 0x060020B9 RID: 8377 RVA: 0x001E4E58 File Offset: 0x001E3058
		public void CreateForum(int areaID, int areaType, string name)
		{
			if (this.CreateForum_Callback == null)
			{
				this.CreateForum_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateForum);
			}
			RemoteServices.RemoteAsyncDelegate_CreateForum remoteAsyncDelegate_CreateForum = new RemoteServices.RemoteAsyncDelegate_CreateForum(this.service.CreateForum);
			this.registerRPCcall(remoteAsyncDelegate_CreateForum.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, name, this.CreateForum_Callback, null), typeof(CreateForum_ReturnType));
		}

		// Token: 0x060020BA RID: 8378 RVA: 0x001E4EC0 File Offset: 0x001E30C0
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateForum(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateForum remoteAsyncDelegate_CreateForum = (RemoteServices.RemoteAsyncDelegate_CreateForum)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateForum.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateForum_ReturnType returnData = new CreateForum_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020BB RID: 8379 RVA: 0x0001DE1D File Offset: 0x0001C01D
		public void set_DeleteForum_UserCallBack(RemoteServices.DeleteForum_UserCallBack callback)
		{
			this.deleteForum_UserCallBack = callback;
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x001E4F10 File Offset: 0x001E3110
		public void DeleteForum(int areaID, int areaType, long forumID)
		{
			if (this.DeleteForum_Callback == null)
			{
				this.DeleteForum_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteForum);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteForum remoteAsyncDelegate_DeleteForum = new RemoteServices.RemoteAsyncDelegate_DeleteForum(this.service.DeleteForum);
			this.registerRPCcall(remoteAsyncDelegate_DeleteForum.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, forumID, this.DeleteForum_Callback, null), typeof(DeleteForum_ReturnType));
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x001E4F78 File Offset: 0x001E3178
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteForum(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteForum remoteAsyncDelegate_DeleteForum = (RemoteServices.RemoteAsyncDelegate_DeleteForum)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteForum.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteForum_ReturnType returnData = new DeleteForum_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020BE RID: 8382 RVA: 0x0001DE26 File Offset: 0x0001C026
		public void set_DeleteForumThread_UserCallBack(RemoteServices.DeleteForumThread_UserCallBack callback)
		{
			this.deleteForumThread_UserCallBack = callback;
		}

		// Token: 0x060020BF RID: 8383 RVA: 0x001E4FC8 File Offset: 0x001E31C8
		public void DeleteForumThread(int areaID, int areaType, string name, long forumID, long forumThreadID)
		{
			if (this.DeleteForumThread_Callback == null)
			{
				this.DeleteForumThread_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteForumThread);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteForumThread remoteAsyncDelegate_DeleteForumThread = new RemoteServices.RemoteAsyncDelegate_DeleteForumThread(this.service.DeleteForumThread);
			this.registerRPCcall(remoteAsyncDelegate_DeleteForumThread.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, name, forumID, forumThreadID, this.DeleteForumThread_Callback, null), typeof(DeleteForumThread_ReturnType));
		}

		// Token: 0x060020C0 RID: 8384 RVA: 0x001E5034 File Offset: 0x001E3234
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteForumThread(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteForumThread remoteAsyncDelegate_DeleteForumThread = (RemoteServices.RemoteAsyncDelegate_DeleteForumThread)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteForumThread.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteForumThread_ReturnType returnData = new DeleteForumThread_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x0001DE2F File Offset: 0x0001C02F
		public void set_DeleteForumPost_UserCallBack(RemoteServices.DeleteForumPost_UserCallBack callback)
		{
			this.deleteForumPost_UserCallBack = callback;
		}

		// Token: 0x060020C2 RID: 8386 RVA: 0x001E5084 File Offset: 0x001E3284
		public void DeleteForumPost(int areaID, int areaType, string name, long forumID, long forumThreadID, long forumPostID)
		{
			if (this.DeleteForumPost_Callback == null)
			{
				this.DeleteForumPost_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DeleteForumPost);
			}
			RemoteServices.RemoteAsyncDelegate_DeleteForumPost remoteAsyncDelegate_DeleteForumPost = new RemoteServices.RemoteAsyncDelegate_DeleteForumPost(this.service.DeleteForumPost);
			this.registerRPCcall(remoteAsyncDelegate_DeleteForumPost.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, name, forumID, forumThreadID, forumPostID, this.DeleteForumPost_Callback, null), typeof(DeleteForumPost_ReturnType));
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x001E50F0 File Offset: 0x001E32F0
		[OneWay]
		public void OurRemoteAsyncCallBack_DeleteForumPost(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DeleteForumPost remoteAsyncDelegate_DeleteForumPost = (RemoteServices.RemoteAsyncDelegate_DeleteForumPost)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DeleteForumPost.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DeleteForumPost_ReturnType returnData = new DeleteForumPost_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020C4 RID: 8388 RVA: 0x0001DE38 File Offset: 0x0001C038
		public void set_GetCurrentElectionInfo_UserCallBack(RemoteServices.GetCurrentElectionInfo_UserCallBack callback)
		{
			this.getCurrentElectionInfo_UserCallBack = callback;
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x001E5140 File Offset: 0x001E3340
		public void GetCurrentElectionInfo(int areaID, int areaType)
		{
			if (this.GetCurrentElectionInfo_Callback == null)
			{
				this.GetCurrentElectionInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCurrentElectionInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetCurrentElectionInfo remoteAsyncDelegate_GetCurrentElectionInfo = new RemoteServices.RemoteAsyncDelegate_GetCurrentElectionInfo(this.service.GetCurrentElectionInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetCurrentElectionInfo.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, this.GetCurrentElectionInfo_Callback, null), typeof(GetCurrentElectionInfo_ReturnType));
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x001E51A8 File Offset: 0x001E33A8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCurrentElectionInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCurrentElectionInfo remoteAsyncDelegate_GetCurrentElectionInfo = (RemoteServices.RemoteAsyncDelegate_GetCurrentElectionInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCurrentElectionInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCurrentElectionInfo_ReturnType returnData = new GetCurrentElectionInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x0001DE41 File Offset: 0x0001C041
		public void set_StandInElection_UserCallBack(RemoteServices.StandInElection_UserCallBack callback)
		{
			this.standInElection_UserCallBack = callback;
		}

		// Token: 0x060020C8 RID: 8392 RVA: 0x001E51F8 File Offset: 0x001E33F8
		public void StandInElection(int areaID, int areaType, bool state)
		{
			if (this.StandInElection_Callback == null)
			{
				this.StandInElection_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_StandInElection);
			}
			RemoteServices.RemoteAsyncDelegate_StandInElection remoteAsyncDelegate_StandInElection = new RemoteServices.RemoteAsyncDelegate_StandInElection(this.service.StandInElection);
			this.registerRPCcall(remoteAsyncDelegate_StandInElection.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, state, this.StandInElection_Callback, null), typeof(StandInElection_ReturnType));
		}

		// Token: 0x060020C9 RID: 8393 RVA: 0x001E5260 File Offset: 0x001E3460
		[OneWay]
		public void OurRemoteAsyncCallBack_StandInElection(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_StandInElection remoteAsyncDelegate_StandInElection = (RemoteServices.RemoteAsyncDelegate_StandInElection)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_StandInElection.EndInvoke(ar));
			}
			catch (Exception e)
			{
				StandInElection_ReturnType returnData = new StandInElection_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020CA RID: 8394 RVA: 0x0001DE4A File Offset: 0x0001C04A
		public void set_VoteInElection_UserCallBack(RemoteServices.VoteInElection_UserCallBack callback)
		{
			this.voteInElection_UserCallBack = callback;
		}

		// Token: 0x060020CB RID: 8395 RVA: 0x001E52B0 File Offset: 0x001E34B0
		public void VoteInElection(int areaID, int areaType, int candidate)
		{
			if (this.VoteInElection_Callback == null)
			{
				this.VoteInElection_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_VoteInElection);
			}
			RemoteServices.RemoteAsyncDelegate_VoteInElection remoteAsyncDelegate_VoteInElection = new RemoteServices.RemoteAsyncDelegate_VoteInElection(this.service.VoteInElection);
			this.registerRPCcall(remoteAsyncDelegate_VoteInElection.BeginInvoke(this.UserID, this.SessionID, areaID, areaType, candidate, this.VoteInElection_Callback, null), typeof(VoteInElection_ReturnType));
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x001E5318 File Offset: 0x001E3518
		[OneWay]
		public void OurRemoteAsyncCallBack_VoteInElection(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_VoteInElection remoteAsyncDelegate_VoteInElection = (RemoteServices.RemoteAsyncDelegate_VoteInElection)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_VoteInElection.EndInvoke(ar));
			}
			catch (Exception e)
			{
				VoteInElection_ReturnType returnData = new VoteInElection_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x0001DE53 File Offset: 0x0001C053
		public void set_UploadAvatar_UserCallBack(RemoteServices.UploadAvatar_UserCallBack callback)
		{
			this.uploadAvatar_UserCallBack = callback;
		}

		// Token: 0x060020CE RID: 8398 RVA: 0x001E5368 File Offset: 0x001E3568
		public void UploadAvatar(AvatarData avatarData)
		{
			if (this.UploadAvatar_Callback == null)
			{
				this.UploadAvatar_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UploadAvatar);
			}
			RemoteServices.RemoteAsyncDelegate_UploadAvatar remoteAsyncDelegate_UploadAvatar = new RemoteServices.RemoteAsyncDelegate_UploadAvatar(this.service.UploadAvatar);
			this.registerRPCcall(remoteAsyncDelegate_UploadAvatar.BeginInvoke(this.UserID, this.SessionID, avatarData, this.UploadAvatar_Callback, null), typeof(UploadAvatar_ReturnType));
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x001E53CC File Offset: 0x001E35CC
		[OneWay]
		public void OurRemoteAsyncCallBack_UploadAvatar(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UploadAvatar remoteAsyncDelegate_UploadAvatar = (RemoteServices.RemoteAsyncDelegate_UploadAvatar)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UploadAvatar.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UploadAvatar_ReturnType returnData = new UploadAvatar_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020D0 RID: 8400 RVA: 0x0001DE5C File Offset: 0x0001C05C
		public void set_MakePeople_UserCallBack(RemoteServices.MakePeople_UserCallBack callback)
		{
			this.makePeople_UserCallBack = callback;
		}

		// Token: 0x060020D1 RID: 8401 RVA: 0x001E541C File Offset: 0x001E361C
		public void MakePeople(int villageID, int personType)
		{
			if (this.MakePeople_Callback == null)
			{
				this.MakePeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakePeople);
			}
			RemoteServices.RemoteAsyncDelegate_MakePeople remoteAsyncDelegate_MakePeople = new RemoteServices.RemoteAsyncDelegate_MakePeople(this.service.MakePeople);
			this.registerRPCcall(remoteAsyncDelegate_MakePeople.BeginInvoke(this.UserID, this.SessionID, villageID, personType, this.MakePeople_Callback, null), typeof(MakePeople_ReturnType));
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x001E5484 File Offset: 0x001E3684
		[OneWay]
		public void OurRemoteAsyncCallBack_MakePeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakePeople remoteAsyncDelegate_MakePeople = (RemoteServices.RemoteAsyncDelegate_MakePeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakePeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakePeople_ReturnType returnData = new MakePeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x0001DE65 File Offset: 0x0001C065
		public void set_GetUserPeople_UserCallBack(RemoteServices.GetUserPeople_UserCallBack callback)
		{
			this.getUserPeople_UserCallBack = callback;
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x001E54D4 File Offset: 0x001E36D4
		public void GetUserPeople()
		{
			if (this.GetUserPeople_Callback == null)
			{
				this.GetUserPeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserPeople);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserPeople remoteAsyncDelegate_GetUserPeople = new RemoteServices.RemoteAsyncDelegate_GetUserPeople(this.service.GetUserPeople);
			this.registerRPCcall(remoteAsyncDelegate_GetUserPeople.BeginInvoke(this.UserID, this.SessionID, this.GetUserPeople_Callback, null), typeof(GetUserPeople_ReturnType));
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x001E5538 File Offset: 0x001E3738
		[OneWay]
		public void OurRemoteAsyncCallBack_GetUserPeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetUserPeople remoteAsyncDelegate_GetUserPeople = (RemoteServices.RemoteAsyncDelegate_GetUserPeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetUserPeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetUserPeople_ReturnType returnData = new GetUserPeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020D6 RID: 8406 RVA: 0x0001DE6E File Offset: 0x0001C06E
		public void set_GetUserIDFromName_UserCallBack(RemoteServices.GetUserIDFromName_UserCallBack callback)
		{
			this.getUserIDFromName_UserCallBack = callback;
		}

		// Token: 0x060020D7 RID: 8407 RVA: 0x001E5588 File Offset: 0x001E3788
		public void GetUserIDFromName(string targetUser)
		{
			if (this.GetUserIDFromName_Callback == null)
			{
				this.GetUserIDFromName_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserIDFromName);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserIDFromName remoteAsyncDelegate_GetUserIDFromName = new RemoteServices.RemoteAsyncDelegate_GetUserIDFromName(this.service.GetUserIDFromName);
			this.registerRPCcall(remoteAsyncDelegate_GetUserIDFromName.BeginInvoke(this.UserID, this.SessionID, targetUser, this.GetUserIDFromName_Callback, null), typeof(GetUserIDFromName_ReturnType));
		}

		// Token: 0x060020D8 RID: 8408 RVA: 0x001E55EC File Offset: 0x001E37EC
		[OneWay]
		public void OurRemoteAsyncCallBack_GetUserIDFromName(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetUserIDFromName remoteAsyncDelegate_GetUserIDFromName = (RemoteServices.RemoteAsyncDelegate_GetUserIDFromName)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetUserIDFromName.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetUserIDFromName_ReturnType returnData = new GetUserIDFromName_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020D9 RID: 8409 RVA: 0x0001DE77 File Offset: 0x0001C077
		public void set_GetActivePeople_UserCallBack(RemoteServices.GetActivePeople_UserCallBack callback)
		{
			this.getActivePeople_UserCallBack = callback;
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x001E563C File Offset: 0x001E383C
		public void GetActivePeople(DateTime lastTime)
		{
			if (this.GetActivePeople_Callback == null)
			{
				this.GetActivePeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetActivePeople);
			}
			RemoteServices.RemoteAsyncDelegate_GetActivePeople remoteAsyncDelegate_GetActivePeople = new RemoteServices.RemoteAsyncDelegate_GetActivePeople(this.service.GetActivePeople);
			this.registerRPCcall(remoteAsyncDelegate_GetActivePeople.BeginInvoke(this.UserID, this.SessionID, lastTime, this.GetActivePeople_Callback, null), typeof(GetActivePeople_ReturnType));
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x001E56A0 File Offset: 0x001E38A0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetActivePeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetActivePeople remoteAsyncDelegate_GetActivePeople = (RemoteServices.RemoteAsyncDelegate_GetActivePeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetActivePeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetActivePeople_ReturnType returnData = new GetActivePeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x0001DE80 File Offset: 0x0001C080
		public void set_SendPeople_UserCallBack(RemoteServices.SendPeople_UserCallBack callback)
		{
			this.sendPeople_UserCallBack = callback;
		}

		// Token: 0x060020DD RID: 8413 RVA: 0x001E56F0 File Offset: 0x001E38F0
		public void SendPeople(int homeVillage, int targetVillage, int personType, int number, int command, int data)
		{
			if (this.SendPeople_Callback == null)
			{
				this.SendPeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendPeople);
			}
			RemoteServices.RemoteAsyncDelegate_SendPeople remoteAsyncDelegate_SendPeople = new RemoteServices.RemoteAsyncDelegate_SendPeople(this.service.SendPeople);
			this.registerRPCcall(remoteAsyncDelegate_SendPeople.BeginInvoke(this.UserID, this.SessionID, homeVillage, targetVillage, personType, number, command, data, this.SendPeople_Callback, null), typeof(SendPeople_ReturnType));
		}

		// Token: 0x060020DE RID: 8414 RVA: 0x001E575C File Offset: 0x001E395C
		[OneWay]
		public void OurRemoteAsyncCallBack_SendPeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendPeople remoteAsyncDelegate_SendPeople = (RemoteServices.RemoteAsyncDelegate_SendPeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendPeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendPeople_ReturnType returnData = new SendPeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020DF RID: 8415 RVA: 0x0001DE89 File Offset: 0x0001C089
		public void set_RetrievePeople_UserCallBack(RemoteServices.RetrievePeople_UserCallBack callback)
		{
			this.retrievePeople_UserCallBack = callback;
		}

		// Token: 0x060020E0 RID: 8416 RVA: 0x001E57AC File Offset: 0x001E39AC
		public void RetrievePeople(List<long> people, int villageID, int personType)
		{
			if (this.RetrievePeople_Callback == null)
			{
				this.RetrievePeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_RetrievePeople);
			}
			RemoteServices.RemoteAsyncDelegate_RetrievePeople remoteAsyncDelegate_RetrievePeople = new RemoteServices.RemoteAsyncDelegate_RetrievePeople(this.service.RetrievePeople);
			this.registerRPCcall(remoteAsyncDelegate_RetrievePeople.BeginInvoke(this.UserID, this.SessionID, villageID, people, personType, this.RetrievePeople_Callback, null), typeof(RetrievePeople_ReturnType));
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x001E5814 File Offset: 0x001E3A14
		[OneWay]
		public void OurRemoteAsyncCallBack_RetrievePeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_RetrievePeople remoteAsyncDelegate_RetrievePeople = (RemoteServices.RemoteAsyncDelegate_RetrievePeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_RetrievePeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				RetrievePeople_ReturnType returnData = new RetrievePeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020E2 RID: 8418 RVA: 0x0001DE92 File Offset: 0x0001C092
		public void set_SpyCommand_UserCallBack(RemoteServices.SpyCommand_UserCallBack callback)
		{
			this.spyCommand_UserCallBack = callback;
		}

		// Token: 0x060020E3 RID: 8419 RVA: 0x001E5864 File Offset: 0x001E3A64
		public void SpyCommand(int villageID, int command)
		{
			if (this.SpyCommand_Callback == null)
			{
				this.SpyCommand_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpyCommand);
			}
			RemoteServices.RemoteAsyncDelegate_SpyCommand remoteAsyncDelegate_SpyCommand = new RemoteServices.RemoteAsyncDelegate_SpyCommand(this.service.SpyCommand);
			this.registerRPCcall(remoteAsyncDelegate_SpyCommand.BeginInvoke(this.UserID, this.SessionID, villageID, command, this.SpyCommand_Callback, null), typeof(SpyCommand_ReturnType));
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x001E58CC File Offset: 0x001E3ACC
		[OneWay]
		public void OurRemoteAsyncCallBack_SpyCommand(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpyCommand remoteAsyncDelegate_SpyCommand = (RemoteServices.RemoteAsyncDelegate_SpyCommand)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpyCommand.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpyCommand_ReturnType returnData = new SpyCommand_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x0001DE9B File Offset: 0x0001C09B
		public void set_SpyGetVillageResourceInfo_UserCallBack(RemoteServices.SpyGetVillageResourceInfo_UserCallBack callback)
		{
			this.spyGetVillageResourceInfo_UserCallBack = callback;
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x001E591C File Offset: 0x001E3B1C
		public void SpyGetVillageResourceInfo(int villageID)
		{
			if (this.SpyGetVillageResourceInfo_Callback == null)
			{
				this.SpyGetVillageResourceInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpyGetVillageResourceInfo);
			}
			RemoteServices.RemoteAsyncDelegate_SpyGetVillageResourceInfo remoteAsyncDelegate_SpyGetVillageResourceInfo = new RemoteServices.RemoteAsyncDelegate_SpyGetVillageResourceInfo(this.service.SpyGetVillageResourceInfo);
			this.registerRPCcall(remoteAsyncDelegate_SpyGetVillageResourceInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.SpyGetVillageResourceInfo_Callback, null), typeof(SpyGetVillageResourceInfo_ReturnType));
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x001E5980 File Offset: 0x001E3B80
		[OneWay]
		public void OurRemoteAsyncCallBack_SpyGetVillageResourceInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpyGetVillageResourceInfo remoteAsyncDelegate_SpyGetVillageResourceInfo = (RemoteServices.RemoteAsyncDelegate_SpyGetVillageResourceInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpyGetVillageResourceInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpyGetVillageResourceInfo_ReturnType returnData = new SpyGetVillageResourceInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x0001DEA4 File Offset: 0x0001C0A4
		public void set_SpyGetArmyInfo_UserCallBack(RemoteServices.SpyGetArmyInfo_UserCallBack callback)
		{
			this.spyGetArmyInfo_UserCallBack = callback;
		}

		// Token: 0x060020E9 RID: 8425 RVA: 0x001E59D0 File Offset: 0x001E3BD0
		public void SpyGetArmyInfo(int villageID)
		{
			if (this.SpyGetArmyInfo_Callback == null)
			{
				this.SpyGetArmyInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpyGetArmyInfo);
			}
			RemoteServices.RemoteAsyncDelegate_SpyGetArmyInfo remoteAsyncDelegate_SpyGetArmyInfo = new RemoteServices.RemoteAsyncDelegate_SpyGetArmyInfo(this.service.SpyGetArmyInfo);
			this.registerRPCcall(remoteAsyncDelegate_SpyGetArmyInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.SpyGetArmyInfo_Callback, null), typeof(SpyGetArmyInfo_ReturnType));
		}

		// Token: 0x060020EA RID: 8426 RVA: 0x001E5A34 File Offset: 0x001E3C34
		[OneWay]
		public void OurRemoteAsyncCallBack_SpyGetArmyInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpyGetArmyInfo remoteAsyncDelegate_SpyGetArmyInfo = (RemoteServices.RemoteAsyncDelegate_SpyGetArmyInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpyGetArmyInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpyGetArmyInfo_ReturnType returnData = new SpyGetArmyInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020EB RID: 8427 RVA: 0x0001DEAD File Offset: 0x0001C0AD
		public void set_SpyGetResearchInfo_UserCallBack(RemoteServices.SpyGetResearchInfo_UserCallBack callback)
		{
			this.spyGetResearchInfo_UserCallBack = callback;
		}

		// Token: 0x060020EC RID: 8428 RVA: 0x001E5A84 File Offset: 0x001E3C84
		public void SpyGetResearchInfo(int villageID)
		{
			if (this.SpyGetResearchInfo_Callback == null)
			{
				this.SpyGetResearchInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpyGetResearchInfo);
			}
			RemoteServices.RemoteAsyncDelegate_SpyGetResearchInfo remoteAsyncDelegate_SpyGetResearchInfo = new RemoteServices.RemoteAsyncDelegate_SpyGetResearchInfo(this.service.SpyGetResearchInfo);
			this.registerRPCcall(remoteAsyncDelegate_SpyGetResearchInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.SpyGetResearchInfo_Callback, null), typeof(SpyGetResearchInfo_ReturnType));
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x001E5AE8 File Offset: 0x001E3CE8
		[OneWay]
		public void OurRemoteAsyncCallBack_SpyGetResearchInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpyGetResearchInfo remoteAsyncDelegate_SpyGetResearchInfo = (RemoteServices.RemoteAsyncDelegate_SpyGetResearchInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpyGetResearchInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpyGetResearchInfo_ReturnType returnData = new SpyGetResearchInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020EE RID: 8430 RVA: 0x0001DEB6 File Offset: 0x0001C0B6
		public void set_CreateFaction_UserCallBack(RemoteServices.CreateFaction_UserCallBack callback)
		{
			this.createFaction_UserCallBack = callback;
		}

		// Token: 0x060020EF RID: 8431 RVA: 0x001E5B38 File Offset: 0x001E3D38
		public void CreateFaction(string factionName, string factionNameabrv, string factionMotto, int flagdata)
		{
			if (this.CreateFaction_Callback == null)
			{
				this.CreateFaction_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateFaction);
			}
			RemoteServices.RemoteAsyncDelegate_CreateFaction remoteAsyncDelegate_CreateFaction = new RemoteServices.RemoteAsyncDelegate_CreateFaction(this.service.CreateFaction);
			this.registerRPCcall(remoteAsyncDelegate_CreateFaction.BeginInvoke(this.UserID, this.SessionID, factionName, factionNameabrv, factionMotto, flagdata, this.CreateFaction_Callback, null), typeof(CreateFaction_ReturnType));
		}

		// Token: 0x060020F0 RID: 8432 RVA: 0x001E5BA0 File Offset: 0x001E3DA0
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateFaction(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateFaction remoteAsyncDelegate_CreateFaction = (RemoteServices.RemoteAsyncDelegate_CreateFaction)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateFaction.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateFaction_ReturnType returnData = new CreateFaction_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020F1 RID: 8433 RVA: 0x0001DEBF File Offset: 0x0001C0BF
		public void set_DisbandFaction_UserCallBack(RemoteServices.DisbandFaction_UserCallBack callback)
		{
			this.disbandFaction_UserCallBack = callback;
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x001E5BF0 File Offset: 0x001E3DF0
		public void DisbandFaction()
		{
			if (this.DisbandFaction_Callback == null)
			{
				this.DisbandFaction_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DisbandFaction);
			}
			RemoteServices.RemoteAsyncDelegate_DisbandFaction remoteAsyncDelegate_DisbandFaction = new RemoteServices.RemoteAsyncDelegate_DisbandFaction(this.service.DisbandFaction);
			this.registerRPCcall(remoteAsyncDelegate_DisbandFaction.BeginInvoke(this.UserID, this.SessionID, this.UserFactionID, this.DisbandFaction_Callback, null), typeof(DisbandFaction_ReturnType));
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x001E5C5C File Offset: 0x001E3E5C
		[OneWay]
		public void OurRemoteAsyncCallBack_DisbandFaction(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DisbandFaction remoteAsyncDelegate_DisbandFaction = (RemoteServices.RemoteAsyncDelegate_DisbandFaction)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DisbandFaction.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DisbandFaction_ReturnType returnData = new DisbandFaction_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x0001DEC8 File Offset: 0x0001C0C8
		public void set_FactionSendInvite_UserCallBack(RemoteServices.FactionSendInvite_UserCallBack callback)
		{
			this.factionSendInvite_UserCallBack = callback;
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x001E5CAC File Offset: 0x001E3EAC
		public void FactionSendInvite(string targetUser)
		{
			if (this.FactionSendInvite_Callback == null)
			{
				this.FactionSendInvite_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionSendInvite);
			}
			RemoteServices.RemoteAsyncDelegate_FactionSendInvite remoteAsyncDelegate_FactionSendInvite = new RemoteServices.RemoteAsyncDelegate_FactionSendInvite(this.service.FactionSendInvite);
			this.registerRPCcall(remoteAsyncDelegate_FactionSendInvite.BeginInvoke(this.UserID, this.SessionID, targetUser, this.FactionSendInvite_Callback, null), typeof(FactionSendInvite_ReturnType));
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x001E5D10 File Offset: 0x001E3F10
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionSendInvite(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionSendInvite remoteAsyncDelegate_FactionSendInvite = (RemoteServices.RemoteAsyncDelegate_FactionSendInvite)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionSendInvite.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionSendInvite_ReturnType returnData = new FactionSendInvite_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x0001DED1 File Offset: 0x0001C0D1
		public void set_FactionWithdrawInvite_UserCallBack(RemoteServices.FactionWithdrawInvite_UserCallBack callback)
		{
			this.factionWithdrawInvite_UserCallBack = callback;
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x001E5D60 File Offset: 0x001E3F60
		public void FactionWithdrawInvite(int targetUserID)
		{
			if (this.FactionWithdrawInvite_Callback == null)
			{
				this.FactionWithdrawInvite_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionWithdrawInvite);
			}
			RemoteServices.RemoteAsyncDelegate_FactionWithdrawInvite remoteAsyncDelegate_FactionWithdrawInvite = new RemoteServices.RemoteAsyncDelegate_FactionWithdrawInvite(this.service.FactionWithdrawInvite);
			this.registerRPCcall(remoteAsyncDelegate_FactionWithdrawInvite.BeginInvoke(this.UserID, this.SessionID, targetUserID, this.FactionWithdrawInvite_Callback, null), typeof(FactionWithdrawInvite_ReturnType));
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x001E5DC4 File Offset: 0x001E3FC4
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionWithdrawInvite(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionWithdrawInvite remoteAsyncDelegate_FactionWithdrawInvite = (RemoteServices.RemoteAsyncDelegate_FactionWithdrawInvite)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionWithdrawInvite.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionWithdrawInvite_ReturnType returnData = new FactionWithdrawInvite_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x0001DEDA File Offset: 0x0001C0DA
		public void set_FactionReplyToInvite_UserCallBack(RemoteServices.FactionReplyToInvite_UserCallBack callback)
		{
			this.factionReplyToInvite_UserCallBack = callback;
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x001E5E14 File Offset: 0x001E4014
		public void FactionReplyToInvite(int factionID, bool accept)
		{
			if (this.FactionReplyToInvite_Callback == null)
			{
				this.FactionReplyToInvite_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionReplyToInvite);
			}
			RemoteServices.RemoteAsyncDelegate_FactionReplyToInvite remoteAsyncDelegate_FactionReplyToInvite = new RemoteServices.RemoteAsyncDelegate_FactionReplyToInvite(this.service.FactionReplyToInvite);
			this.registerRPCcall(remoteAsyncDelegate_FactionReplyToInvite.BeginInvoke(this.UserID, this.SessionID, factionID, accept, this.FactionReplyToInvite_Callback, null), typeof(FactionReplyToInvite_ReturnType));
		}

		// Token: 0x060020FC RID: 8444 RVA: 0x001E5E7C File Offset: 0x001E407C
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionReplyToInvite(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionReplyToInvite remoteAsyncDelegate_FactionReplyToInvite = (RemoteServices.RemoteAsyncDelegate_FactionReplyToInvite)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionReplyToInvite.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionReplyToInvite_ReturnType returnData = new FactionReplyToInvite_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060020FD RID: 8445 RVA: 0x0001DEE3 File Offset: 0x0001C0E3
		public void set_FactionChangeMemberStatus_UserCallBack(RemoteServices.FactionChangeMemberStatus_UserCallBack callback)
		{
			this.factionChangeMemberStatus_UserCallBack = callback;
		}

		// Token: 0x060020FE RID: 8446 RVA: 0x001E5ECC File Offset: 0x001E40CC
		public void FactionChangeMemberStatus(int memberUserID, int targetRank)
		{
			if (this.FactionChangeMemberStatus_Callback == null)
			{
				this.FactionChangeMemberStatus_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionChangeMemberStatus);
			}
			RemoteServices.RemoteAsyncDelegate_FactionChangeMemberStatus remoteAsyncDelegate_FactionChangeMemberStatus = new RemoteServices.RemoteAsyncDelegate_FactionChangeMemberStatus(this.service.FactionChangeMemberStatus);
			this.registerRPCcall(remoteAsyncDelegate_FactionChangeMemberStatus.BeginInvoke(this.UserID, this.SessionID, memberUserID, targetRank, this.FactionChangeMemberStatus_Callback, null), typeof(FactionChangeMemberStatus_ReturnType));
		}

		// Token: 0x060020FF RID: 8447 RVA: 0x001E5F34 File Offset: 0x001E4134
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionChangeMemberStatus(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionChangeMemberStatus remoteAsyncDelegate_FactionChangeMemberStatus = (RemoteServices.RemoteAsyncDelegate_FactionChangeMemberStatus)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionChangeMemberStatus.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionChangeMemberStatus_ReturnType returnData = new FactionChangeMemberStatus_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002100 RID: 8448 RVA: 0x0001DEEC File Offset: 0x0001C0EC
		public void set_FactionLeave_UserCallBack(RemoteServices.FactionLeave_UserCallBack callback)
		{
			this.factionLeave_UserCallBack = callback;
		}

		// Token: 0x06002101 RID: 8449 RVA: 0x001E5F84 File Offset: 0x001E4184
		public void FactionLeave()
		{
			if (this.FactionLeave_Callback == null)
			{
				this.FactionLeave_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionLeave);
			}
			RemoteServices.RemoteAsyncDelegate_FactionLeave remoteAsyncDelegate_FactionLeave = new RemoteServices.RemoteAsyncDelegate_FactionLeave(this.service.FactionLeave);
			this.registerRPCcall(remoteAsyncDelegate_FactionLeave.BeginInvoke(this.UserID, this.SessionID, this.FactionLeave_Callback, null), typeof(FactionLeave_ReturnType));
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x001E5FE8 File Offset: 0x001E41E8
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionLeave(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionLeave remoteAsyncDelegate_FactionLeave = (RemoteServices.RemoteAsyncDelegate_FactionLeave)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionLeave.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionLeave_ReturnType returnData = new FactionLeave_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x0001DEF5 File Offset: 0x0001C0F5
		public void set_GetFactionData_UserCallBack(RemoteServices.GetFactionData_UserCallBack callback)
		{
			this.getFactionData_UserCallBack = callback;
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x001E6038 File Offset: 0x001E4238
		public void GetFactionData(int factionID, long factionChangesPos)
		{
			if (this.GetFactionData_Callback == null)
			{
				this.GetFactionData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetFactionData);
			}
			RemoteServices.RemoteAsyncDelegate_GetFactionData remoteAsyncDelegate_GetFactionData = new RemoteServices.RemoteAsyncDelegate_GetFactionData(this.service.GetFactionData);
			this.registerRPCcall(remoteAsyncDelegate_GetFactionData.BeginInvoke(this.UserID, this.SessionID, factionID, factionChangesPos, this.GetFactionData_Callback, null), typeof(GetFactionData_ReturnType));
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x001E60A0 File Offset: 0x001E42A0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetFactionData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetFactionData remoteAsyncDelegate_GetFactionData = (RemoteServices.RemoteAsyncDelegate_GetFactionData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetFactionData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetFactionData_ReturnType returnData = new GetFactionData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002106 RID: 8454 RVA: 0x0001DEFE File Offset: 0x0001C0FE
		public void set_CreateUserRelationship_UserCallBack(RemoteServices.CreateUserRelationship_UserCallBack callback)
		{
			this.createUserRelationship_UserCallBack = callback;
		}

		// Token: 0x06002107 RID: 8455 RVA: 0x001E60F0 File Offset: 0x001E42F0
		public void CreateUserRelationship(int targetUserID, int relationship)
		{
			if (this.CreateUserRelationship_Callback == null)
			{
				this.CreateUserRelationship_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateUserRelationship);
			}
			RemoteServices.RemoteAsyncDelegate_CreateUserRelationship remoteAsyncDelegate_CreateUserRelationship = new RemoteServices.RemoteAsyncDelegate_CreateUserRelationship(this.service.CreateUserRelationship);
			this.registerRPCcall(remoteAsyncDelegate_CreateUserRelationship.BeginInvoke(this.UserID, this.SessionID, targetUserID, relationship, this.CreateUserRelationship_Callback, null), typeof(CreateUserRelationship_ReturnType));
		}

		// Token: 0x06002108 RID: 8456 RVA: 0x001E6158 File Offset: 0x001E4358
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateUserRelationship(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateUserRelationship remoteAsyncDelegate_CreateUserRelationship = (RemoteServices.RemoteAsyncDelegate_CreateUserRelationship)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateUserRelationship.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateUserRelationship_ReturnType returnData = new CreateUserRelationship_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002109 RID: 8457 RVA: 0x0001DF07 File Offset: 0x0001C107
		public void set_SetUserMarker_UserCallBack(RemoteServices.SetUserMarker_UserCallBack callback)
		{
			this.setUserMarker_UserCallBack = callback;
		}

		// Token: 0x0600210A RID: 8458 RVA: 0x001E61A8 File Offset: 0x001E43A8
		public void SetUserMarker(int targetUserID, int markerType)
		{
			if (this.SetUserMarker_Callback == null)
			{
				this.SetUserMarker_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SetUserMarker);
			}
			RemoteServices.RemoteAsyncDelegate_SetUserMarker remoteAsyncDelegate_SetUserMarker = new RemoteServices.RemoteAsyncDelegate_SetUserMarker(this.service.SetUserMarker);
			this.registerRPCcall(remoteAsyncDelegate_SetUserMarker.BeginInvoke(this.UserID, this.SessionID, targetUserID, markerType, this.SetUserMarker_Callback, null), typeof(SetUserMarker_ReturnType));
		}

		// Token: 0x0600210B RID: 8459 RVA: 0x001E6210 File Offset: 0x001E4410
		[OneWay]
		public void OurRemoteAsyncCallBack_SetUserMarker(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SetUserMarker remoteAsyncDelegate_SetUserMarker = (RemoteServices.RemoteAsyncDelegate_SetUserMarker)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SetUserMarker.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SetUserMarker_ReturnType returnData = new SetUserMarker_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600210C RID: 8460 RVA: 0x0001DF10 File Offset: 0x0001C110
		public void set_CreateFactionRelationship_UserCallBack(RemoteServices.CreateFactionRelationship_UserCallBack callback)
		{
			this.createFactionRelationship_UserCallBack = callback;
		}

		// Token: 0x0600210D RID: 8461 RVA: 0x001E6260 File Offset: 0x001E4460
		public void CreateFactionRelationship(int targetFactionID, int relationship)
		{
			if (this.CreateFactionRelationship_Callback == null)
			{
				this.CreateFactionRelationship_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateFactionRelationship);
			}
			RemoteServices.RemoteAsyncDelegate_CreateFactionRelationship remoteAsyncDelegate_CreateFactionRelationship = new RemoteServices.RemoteAsyncDelegate_CreateFactionRelationship(this.service.CreateFactionRelationship);
			this.registerRPCcall(remoteAsyncDelegate_CreateFactionRelationship.BeginInvoke(this.UserID, this.SessionID, targetFactionID, relationship, this.CreateFactionRelationship_Callback, null), typeof(CreateFactionRelationship_ReturnType));
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x001E62C8 File Offset: 0x001E44C8
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateFactionRelationship(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateFactionRelationship remoteAsyncDelegate_CreateFactionRelationship = (RemoteServices.RemoteAsyncDelegate_CreateFactionRelationship)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateFactionRelationship.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateFactionRelationship_ReturnType returnData = new CreateFactionRelationship_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600210F RID: 8463 RVA: 0x0001DF19 File Offset: 0x0001C119
		public void set_CreateHouseRelationship_UserCallBack(RemoteServices.CreateHouseRelationship_UserCallBack callback)
		{
			this.createHouseRelationship_UserCallBack = callback;
		}

		// Token: 0x06002110 RID: 8464 RVA: 0x001E6318 File Offset: 0x001E4518
		public void CreateHouseRelationship(int targetHouseID, int relationship)
		{
			if (this.CreateHouseRelationship_Callback == null)
			{
				this.CreateHouseRelationship_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CreateHouseRelationship);
			}
			RemoteServices.RemoteAsyncDelegate_CreateHouseRelationship remoteAsyncDelegate_CreateHouseRelationship = new RemoteServices.RemoteAsyncDelegate_CreateHouseRelationship(this.service.CreateHouseRelationship);
			this.registerRPCcall(remoteAsyncDelegate_CreateHouseRelationship.BeginInvoke(this.UserID, this.SessionID, targetHouseID, relationship, this.CreateHouseRelationship_Callback, null), typeof(CreateHouseRelationship_ReturnType));
		}

		// Token: 0x06002111 RID: 8465 RVA: 0x001E6380 File Offset: 0x001E4580
		[OneWay]
		public void OurRemoteAsyncCallBack_CreateHouseRelationship(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CreateHouseRelationship remoteAsyncDelegate_CreateHouseRelationship = (RemoteServices.RemoteAsyncDelegate_CreateHouseRelationship)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CreateHouseRelationship.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CreateHouseRelationship_ReturnType returnData = new CreateHouseRelationship_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002112 RID: 8466 RVA: 0x0001DF22 File Offset: 0x0001C122
		public void set_GetHouseGloryPoints_UserCallBack(RemoteServices.GetHouseGloryPoints_UserCallBack callback)
		{
			this.getHouseGloryPoints_UserCallBack = callback;
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x001E63D0 File Offset: 0x001E45D0
		public void GetHouseGloryPoints()
		{
			if (this.GetHouseGloryPoints_Callback == null)
			{
				this.GetHouseGloryPoints_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetHouseGloryPoints);
			}
			RemoteServices.RemoteAsyncDelegate_GetHouseGloryPoints remoteAsyncDelegate_GetHouseGloryPoints = new RemoteServices.RemoteAsyncDelegate_GetHouseGloryPoints(this.service.GetHouseGloryPoints);
			this.registerRPCcall(remoteAsyncDelegate_GetHouseGloryPoints.BeginInvoke(this.UserID, this.SessionID, this.GetHouseGloryPoints_Callback, null), typeof(GetHouseGloryPoints_ReturnType));
		}

		// Token: 0x06002114 RID: 8468 RVA: 0x001E6434 File Offset: 0x001E4634
		[OneWay]
		public void OurRemoteAsyncCallBack_GetHouseGloryPoints(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetHouseGloryPoints remoteAsyncDelegate_GetHouseGloryPoints = (RemoteServices.RemoteAsyncDelegate_GetHouseGloryPoints)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetHouseGloryPoints.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetHouseGloryPoints_ReturnType returnData = new GetHouseGloryPoints_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002115 RID: 8469 RVA: 0x0001DF2B File Offset: 0x0001C12B
		public void set_ChangeFactionMotto_UserCallBack(RemoteServices.ChangeFactionMotto_UserCallBack callback)
		{
			this.changeFactionMotto_UserCallBack = callback;
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x001E6484 File Offset: 0x001E4684
		public void ChangeFactionMotto(string factionName, string factionNameAbrv, string motto, int flagData)
		{
			if (this.ChangeFactionMotto_Callback == null)
			{
				this.ChangeFactionMotto_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ChangeFactionMotto);
			}
			RemoteServices.RemoteAsyncDelegate_ChangeFactionMotto remoteAsyncDelegate_ChangeFactionMotto = new RemoteServices.RemoteAsyncDelegate_ChangeFactionMotto(this.service.ChangeFactionMotto);
			this.registerRPCcall(remoteAsyncDelegate_ChangeFactionMotto.BeginInvoke(this.UserID, this.SessionID, factionName, factionNameAbrv, motto, flagData, this.ChangeFactionMotto_Callback, null), typeof(ChangeFactionMotto_ReturnType));
		}

		// Token: 0x06002117 RID: 8471 RVA: 0x001E64EC File Offset: 0x001E46EC
		[OneWay]
		public void OurRemoteAsyncCallBack_ChangeFactionMotto(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ChangeFactionMotto remoteAsyncDelegate_ChangeFactionMotto = (RemoteServices.RemoteAsyncDelegate_ChangeFactionMotto)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ChangeFactionMotto.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ChangeFactionMotto_ReturnType returnData = new ChangeFactionMotto_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x0001DF34 File Offset: 0x0001C134
		public void set_FactionLeadershipVote_UserCallBack(RemoteServices.FactionLeadershipVote_UserCallBack callback)
		{
			this.factionLeadershipVote_UserCallBack = callback;
		}

		// Token: 0x06002119 RID: 8473 RVA: 0x001E653C File Offset: 0x001E473C
		public void FactionLeadershipVote(int factionID, int votedID)
		{
			if (this.FactionLeadershipVote_Callback == null)
			{
				this.FactionLeadershipVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionLeadershipVote);
			}
			RemoteServices.RemoteAsyncDelegate_FactionLeadershipVote remoteAsyncDelegate_FactionLeadershipVote = new RemoteServices.RemoteAsyncDelegate_FactionLeadershipVote(this.service.FactionLeadershipVote);
			this.registerRPCcall(remoteAsyncDelegate_FactionLeadershipVote.BeginInvoke(this.UserID, this.SessionID, factionID, votedID, this.FactionLeadershipVote_Callback, null), typeof(FactionLeadershipVote_ReturnType));
		}

		// Token: 0x0600211A RID: 8474 RVA: 0x001E65A4 File Offset: 0x001E47A4
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionLeadershipVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionLeadershipVote remoteAsyncDelegate_FactionLeadershipVote = (RemoteServices.RemoteAsyncDelegate_FactionLeadershipVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionLeadershipVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionLeadershipVote_ReturnType returnData = new FactionLeadershipVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600211B RID: 8475 RVA: 0x0001DF3D File Offset: 0x0001C13D
		public void set_GetViewFactionData_UserCallBack(RemoteServices.GetViewFactionData_UserCallBack callback)
		{
			this.getViewFactionData_UserCallBack = callback;
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x001E65F4 File Offset: 0x001E47F4
		public void GetViewFactionData(int factionID)
		{
			if (this.GetViewFactionData_Callback == null)
			{
				this.GetViewFactionData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetViewFactionData);
			}
			RemoteServices.RemoteAsyncDelegate_GetViewFactionData remoteAsyncDelegate_GetViewFactionData = new RemoteServices.RemoteAsyncDelegate_GetViewFactionData(this.service.GetViewFactionData);
			this.registerRPCcall(remoteAsyncDelegate_GetViewFactionData.BeginInvoke(this.UserID, this.SessionID, factionID, this.GetViewFactionData_Callback, null), typeof(GetViewFactionData_ReturnType));
		}

		// Token: 0x0600211D RID: 8477 RVA: 0x001E6658 File Offset: 0x001E4858
		[OneWay]
		public void OurRemoteAsyncCallBack_GetViewFactionData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetViewFactionData remoteAsyncDelegate_GetViewFactionData = (RemoteServices.RemoteAsyncDelegate_GetViewFactionData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetViewFactionData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetViewFactionData_ReturnType returnData = new GetViewFactionData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600211E RID: 8478 RVA: 0x0001DF46 File Offset: 0x0001C146
		public void set_GetViewHouseData_UserCallBack(RemoteServices.GetViewHouseData_UserCallBack callback)
		{
			this.getViewHouseData_UserCallBack = callback;
		}

		// Token: 0x0600211F RID: 8479 RVA: 0x001E66A8 File Offset: 0x001E48A8
		public void GetViewHouseData(int houseID)
		{
			if (this.GetViewHouseData_Callback == null)
			{
				this.GetViewHouseData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetViewHouseData);
			}
			RemoteServices.RemoteAsyncDelegate_GetViewHouseData remoteAsyncDelegate_GetViewHouseData = new RemoteServices.RemoteAsyncDelegate_GetViewHouseData(this.service.GetViewHouseData);
			this.registerRPCcall(remoteAsyncDelegate_GetViewHouseData.BeginInvoke(this.UserID, this.SessionID, houseID, this.GetViewHouseData_Callback, null), typeof(GetViewHouseData_ReturnType));
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x001E670C File Offset: 0x001E490C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetViewHouseData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetViewHouseData remoteAsyncDelegate_GetViewHouseData = (RemoteServices.RemoteAsyncDelegate_GetViewHouseData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetViewHouseData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetViewHouseData_ReturnType returnData = new GetViewHouseData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0001DF4F File Offset: 0x0001C14F
		public void set_SelfJoinHouse_UserCallBack(RemoteServices.SelfJoinHouse_UserCallBack callback)
		{
			this.selfJoinHouse_UserCallBack = callback;
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x001E675C File Offset: 0x001E495C
		public void SelfJoinHouse(int factionID, int houseID, long factionsChangePos)
		{
			if (this.SelfJoinHouse_Callback == null)
			{
				this.SelfJoinHouse_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SelfJoinHouse);
			}
			RemoteServices.RemoteAsyncDelegate_SelfJoinHouse remoteAsyncDelegate_SelfJoinHouse = new RemoteServices.RemoteAsyncDelegate_SelfJoinHouse(this.service.SelfJoinHouse);
			this.registerRPCcall(remoteAsyncDelegate_SelfJoinHouse.BeginInvoke(this.UserID, this.SessionID, factionID, houseID, factionsChangePos, this.SelfJoinHouse_Callback, null), typeof(SelfJoinHouse_ReturnType));
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x001E67C4 File Offset: 0x001E49C4
		[OneWay]
		public void OurRemoteAsyncCallBack_SelfJoinHouse(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SelfJoinHouse remoteAsyncDelegate_SelfJoinHouse = (RemoteServices.RemoteAsyncDelegate_SelfJoinHouse)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SelfJoinHouse.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SelfJoinHouse_ReturnType returnData = new SelfJoinHouse_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002124 RID: 8484 RVA: 0x0001DF58 File Offset: 0x0001C158
		public void set_HouseVote_UserCallBack(RemoteServices.HouseVote_UserCallBack callback)
		{
			this.houseVote_UserCallBack = callback;
		}

		// Token: 0x06002125 RID: 8485 RVA: 0x001E6814 File Offset: 0x001E4A14
		public void HouseVote(int targetFaction, bool application, bool vote, long factionsChangePos)
		{
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			if (yourFaction != null)
			{
				if (this.HouseVote_Callback == null)
				{
					this.HouseVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_HouseVote);
				}
				RemoteServices.RemoteAsyncDelegate_HouseVote remoteAsyncDelegate_HouseVote = new RemoteServices.RemoteAsyncDelegate_HouseVote(this.service.HouseVote);
				this.registerRPCcall(remoteAsyncDelegate_HouseVote.BeginInvoke(this.UserID, this.SessionID, yourFaction.factionID, yourFaction.houseID, targetFaction, application, vote, factionsChangePos, this.HouseVote_Callback, null), typeof(HouseVote_ReturnType));
			}
		}

		// Token: 0x06002126 RID: 8486 RVA: 0x001E689C File Offset: 0x001E4A9C
		[OneWay]
		public void OurRemoteAsyncCallBack_HouseVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_HouseVote remoteAsyncDelegate_HouseVote = (RemoteServices.RemoteAsyncDelegate_HouseVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_HouseVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				HouseVote_ReturnType returnData = new HouseVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002127 RID: 8487 RVA: 0x0001DF61 File Offset: 0x0001C161
		public void set_HouseVoteHouseLeader_UserCallBack(RemoteServices.HouseVoteHouseLeader_UserCallBack callback)
		{
			this.houseVoteHouseLeader_UserCallBack = callback;
		}

		// Token: 0x06002128 RID: 8488 RVA: 0x001E68EC File Offset: 0x001E4AEC
		public void HouseVoteHouseLeader(int factionID, int houseID, int votedFactionID, long factionsChangePos)
		{
			if (this.HouseVoteHouseLeader_Callback == null)
			{
				this.HouseVoteHouseLeader_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_HouseVoteHouseLeader);
			}
			RemoteServices.RemoteAsyncDelegate_HouseVoteHouseLeader remoteAsyncDelegate_HouseVoteHouseLeader = new RemoteServices.RemoteAsyncDelegate_HouseVoteHouseLeader(this.service.HouseVoteHouseLeader);
			this.registerRPCcall(remoteAsyncDelegate_HouseVoteHouseLeader.BeginInvoke(this.UserID, this.SessionID, factionID, houseID, votedFactionID, factionsChangePos, this.HouseVoteHouseLeader_Callback, null), typeof(HouseVoteHouseLeader_ReturnType));
		}

		// Token: 0x06002129 RID: 8489 RVA: 0x001E6954 File Offset: 0x001E4B54
		[OneWay]
		public void OurRemoteAsyncCallBack_HouseVoteHouseLeader(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_HouseVoteHouseLeader remoteAsyncDelegate_HouseVoteHouseLeader = (RemoteServices.RemoteAsyncDelegate_HouseVoteHouseLeader)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_HouseVoteHouseLeader.EndInvoke(ar));
			}
			catch (Exception e)
			{
				HouseVoteHouseLeader_ReturnType returnData = new HouseVoteHouseLeader_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600212A RID: 8490 RVA: 0x0001DF6A File Offset: 0x0001C16A
		public void set_TouchHouseVisitDate_UserCallBack(RemoteServices.TouchHouseVisitDate_UserCallBack callback)
		{
			this.touchHouseVisitDate_UserCallBack = callback;
		}

		// Token: 0x0600212B RID: 8491 RVA: 0x001E69A4 File Offset: 0x001E4BA4
		public void TouchHouseVisitDate(int factionID)
		{
			if (this.TouchHouseVisitDate_Callback == null)
			{
				this.TouchHouseVisitDate_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_TouchHouseVisitDate);
			}
			RemoteServices.RemoteAsyncDelegate_TouchHouseVisitDate remoteAsyncDelegate_TouchHouseVisitDate = new RemoteServices.RemoteAsyncDelegate_TouchHouseVisitDate(this.service.TouchHouseVisitDate);
			this.registerRPCcall(remoteAsyncDelegate_TouchHouseVisitDate.BeginInvoke(this.UserID, this.SessionID, factionID, this.TouchHouseVisitDate_Callback, null), typeof(TouchHouseVisitDate_ReturnType));
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x001E6A08 File Offset: 0x001E4C08
		[OneWay]
		public void OurRemoteAsyncCallBack_TouchHouseVisitDate(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_TouchHouseVisitDate remoteAsyncDelegate_TouchHouseVisitDate = (RemoteServices.RemoteAsyncDelegate_TouchHouseVisitDate)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_TouchHouseVisitDate.EndInvoke(ar));
			}
			catch (Exception e)
			{
				TouchHouseVisitDate_ReturnType returnData = new TouchHouseVisitDate_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600212D RID: 8493 RVA: 0x0001DF73 File Offset: 0x0001C173
		public void set_LeaveHouse_UserCallBack(RemoteServices.LeaveHouse_UserCallBack callback)
		{
			this.leaveHouse_UserCallBack = callback;
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x001E6A58 File Offset: 0x001E4C58
		public void LeaveHouse(int factionID, int houseID, long factionsChangePos)
		{
			if (this.LeaveHouse_Callback == null)
			{
				this.LeaveHouse_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_LeaveHouse);
			}
			RemoteServices.RemoteAsyncDelegate_LeaveHouse remoteAsyncDelegate_LeaveHouse = new RemoteServices.RemoteAsyncDelegate_LeaveHouse(this.service.LeaveHouse);
			this.registerRPCcall(remoteAsyncDelegate_LeaveHouse.BeginInvoke(this.UserID, this.SessionID, factionID, houseID, factionsChangePos, this.LeaveHouse_Callback, null), typeof(LeaveHouse_ReturnType));
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x001E6AC0 File Offset: 0x001E4CC0
		[OneWay]
		public void OurRemoteAsyncCallBack_LeaveHouse(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_LeaveHouse remoteAsyncDelegate_LeaveHouse = (RemoteServices.RemoteAsyncDelegate_LeaveHouse)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_LeaveHouse.EndInvoke(ar));
			}
			catch (Exception e)
			{
				LeaveHouse_ReturnType returnData = new LeaveHouse_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002130 RID: 8496 RVA: 0x0001DF7C File Offset: 0x0001C17C
		public void set_FactionApplication_UserCallBack(RemoteServices.FactionApplication_UserCallBack callback)
		{
			this.factionApplication_UserCallBack = callback;
		}

		// Token: 0x06002131 RID: 8497 RVA: 0x001E6B10 File Offset: 0x001E4D10
		public void FactionApplication(int factionID)
		{
			if (this.FactionApplication_Callback == null)
			{
				this.FactionApplication_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplication);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplication remoteAsyncDelegate_FactionApplication = new RemoteServices.RemoteAsyncDelegate_FactionApplication(this.service.FactionApplication);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplication.BeginInvoke(this.UserID, this.SessionID, factionID, false, this.FactionApplication_Callback, null), typeof(FactionApplication_ReturnType));
		}

		// Token: 0x06002132 RID: 8498 RVA: 0x001E6B78 File Offset: 0x001E4D78
		public void FactionApplicationCancel(int factionID)
		{
			if (this.FactionApplication_Callback == null)
			{
				this.FactionApplication_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplication);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplication remoteAsyncDelegate_FactionApplication = new RemoteServices.RemoteAsyncDelegate_FactionApplication(this.service.FactionApplication);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplication.BeginInvoke(this.UserID, this.SessionID, factionID, true, this.FactionApplication_Callback, null), typeof(FactionApplication_ReturnType));
		}

		// Token: 0x06002133 RID: 8499 RVA: 0x001E6BE0 File Offset: 0x001E4DE0
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionApplication(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionApplication remoteAsyncDelegate_FactionApplication = (RemoteServices.RemoteAsyncDelegate_FactionApplication)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionApplication.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionApplication_ReturnType returnData = new FactionApplication_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002134 RID: 8500 RVA: 0x0001DF85 File Offset: 0x0001C185
		public void set_FactionApplicationProcessing_UserCallBack(RemoteServices.FactionApplicationProcessing_UserCallBack callback)
		{
			this.factionApplicationProcessing_UserCallBack = callback;
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x001E6C30 File Offset: 0x001E4E30
		public void FactionApplicationAccept(int userID)
		{
			if (this.FactionApplicationProcessing_Callback == null)
			{
				this.FactionApplicationProcessing_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplicationProcessing);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing remoteAsyncDelegate_FactionApplicationProcessing = new RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing(this.service.FactionApplicationProcessing);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplicationProcessing.BeginInvoke(this.UserID, this.SessionID, userID, true, false, false, this.FactionApplicationProcessing_Callback, null), typeof(FactionApplicationProcessing_ReturnType));
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x001E6C98 File Offset: 0x001E4E98
		public void FactionApplicationReject(int userID)
		{
			if (this.FactionApplicationProcessing_Callback == null)
			{
				this.FactionApplicationProcessing_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplicationProcessing);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing remoteAsyncDelegate_FactionApplicationProcessing = new RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing(this.service.FactionApplicationProcessing);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplicationProcessing.BeginInvoke(this.UserID, this.SessionID, userID, false, true, false, this.FactionApplicationProcessing_Callback, null), typeof(FactionApplicationProcessing_ReturnType));
		}

		// Token: 0x06002137 RID: 8503 RVA: 0x001E6D00 File Offset: 0x001E4F00
		public void FactionApplicationSetMode(bool accepting)
		{
			if (this.FactionApplicationProcessing_Callback == null)
			{
				this.FactionApplicationProcessing_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplicationProcessing);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing remoteAsyncDelegate_FactionApplicationProcessing = new RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing(this.service.FactionApplicationProcessing);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplicationProcessing.BeginInvoke(this.UserID, this.SessionID, -1, false, false, accepting, this.FactionApplicationProcessing_Callback, null), typeof(FactionApplicationProcessing_ReturnType));
		}

		// Token: 0x06002138 RID: 8504 RVA: 0x001E6D68 File Offset: 0x001E4F68
		public void FactionApplicationGoHeretic()
		{
			if (this.FactionApplicationProcessing_Callback == null)
			{
				this.FactionApplicationProcessing_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FactionApplicationProcessing);
			}
			RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing remoteAsyncDelegate_FactionApplicationProcessing = new RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing(this.service.FactionApplicationProcessing);
			this.registerRPCcall(remoteAsyncDelegate_FactionApplicationProcessing.BeginInvoke(this.UserID, this.SessionID, 4, true, true, true, this.FactionApplicationProcessing_Callback, null), typeof(FactionApplicationProcessing_ReturnType));
		}

		// Token: 0x06002139 RID: 8505 RVA: 0x001E6DD0 File Offset: 0x001E4FD0
		[OneWay]
		public void OurRemoteAsyncCallBack_FactionApplicationProcessing(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing remoteAsyncDelegate_FactionApplicationProcessing = (RemoteServices.RemoteAsyncDelegate_FactionApplicationProcessing)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FactionApplicationProcessing.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FactionApplicationProcessing_ReturnType returnData = new FactionApplicationProcessing_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600213A RID: 8506 RVA: 0x0001DF8E File Offset: 0x0001C18E
		public void set_GetParishMembersList_UserCallBack(RemoteServices.GetParishMembersList_UserCallBack callback)
		{
			this.getParishMembersList_UserCallBack = callback;
		}

		// Token: 0x0600213B RID: 8507 RVA: 0x001E6E20 File Offset: 0x001E5020
		public void GetParishMembersList(int villageID)
		{
			if (this.GetParishMembersList_Callback == null)
			{
				this.GetParishMembersList_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetParishMembersList);
			}
			RemoteServices.RemoteAsyncDelegate_GetParishMembersList remoteAsyncDelegate_GetParishMembersList = new RemoteServices.RemoteAsyncDelegate_GetParishMembersList(this.service.GetParishMembersList);
			this.registerRPCcall(remoteAsyncDelegate_GetParishMembersList.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetParishMembersList_Callback, null), typeof(GetParishMembersList_ReturnType));
		}

		// Token: 0x0600213C RID: 8508 RVA: 0x001E6E84 File Offset: 0x001E5084
		[OneWay]
		public void OurRemoteAsyncCallBack_GetParishMembersList(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetParishMembersList remoteAsyncDelegate_GetParishMembersList = (RemoteServices.RemoteAsyncDelegate_GetParishMembersList)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetParishMembersList.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetParishMembersList_ReturnType returnData = new GetParishMembersList_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600213D RID: 8509 RVA: 0x0001DF97 File Offset: 0x0001C197
		public void set_GetParishFrontPageInfo_UserCallBack(RemoteServices.GetParishFrontPageInfo_UserCallBack callback)
		{
			this.getParishFrontPageInfo_UserCallBack = callback;
		}

		// Token: 0x0600213E RID: 8510 RVA: 0x001E6ED4 File Offset: 0x001E50D4
		public void GetParishFrontPageInfo(int villageID, DateTime lastTime)
		{
			if (this.GetParishFrontPageInfo_Callback == null)
			{
				this.GetParishFrontPageInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetParishFrontPageInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetParishFrontPageInfo remoteAsyncDelegate_GetParishFrontPageInfo = new RemoteServices.RemoteAsyncDelegate_GetParishFrontPageInfo(this.service.GetParishFrontPageInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetParishFrontPageInfo.BeginInvoke(this.UserID, this.SessionID, villageID, lastTime, this.GetParishFrontPageInfo_Callback, null), typeof(GetParishFrontPageInfo_ReturnType));
		}

		// Token: 0x0600213F RID: 8511 RVA: 0x001E6F3C File Offset: 0x001E513C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetParishFrontPageInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetParishFrontPageInfo remoteAsyncDelegate_GetParishFrontPageInfo = (RemoteServices.RemoteAsyncDelegate_GetParishFrontPageInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetParishFrontPageInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetParishFrontPageInfo_ReturnType returnData = new GetParishFrontPageInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
		public void set_ParishWallDetailInfo_UserCallBack(RemoteServices.ParishWallDetailInfo_UserCallBack callback)
		{
			this.parishWallDetailInfo_UserCallBack = callback;
		}

		// Token: 0x06002141 RID: 8513 RVA: 0x001E6F8C File Offset: 0x001E518C
		public void ParishWallDetailInfo(int parishCapitalID, long wallInfoID)
		{
			if (this.ParishWallDetailInfo_Callback == null)
			{
				this.ParishWallDetailInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ParishWallDetailInfo);
			}
			RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo remoteAsyncDelegate_ParishWallDetailInfo = new RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo(this.service.ParishWallDetailInfo);
			this.registerRPCcall(remoteAsyncDelegate_ParishWallDetailInfo.BeginInvoke(this.UserID, this.SessionID, parishCapitalID, wallInfoID, -1, -1, this.ParishWallDetailInfo_Callback, null), typeof(ParishWallDetailInfo_ReturnType));
		}

		// Token: 0x06002142 RID: 8514 RVA: 0x001E6FF4 File Offset: 0x001E51F4
		public void ParishWallDetailInfo(int parishCapitalID, int targetUserId, int wallType)
		{
			if (this.ParishWallDetailInfo_Callback == null)
			{
				this.ParishWallDetailInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_ParishWallDetailInfo);
			}
			RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo remoteAsyncDelegate_ParishWallDetailInfo = new RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo(this.service.ParishWallDetailInfo);
			this.registerRPCcall(remoteAsyncDelegate_ParishWallDetailInfo.BeginInvoke(this.UserID, this.SessionID, parishCapitalID, -1L, targetUserId, wallType, this.ParishWallDetailInfo_Callback, null), typeof(ParishWallDetailInfo_ReturnType));
		}

		// Token: 0x06002143 RID: 8515 RVA: 0x001E705C File Offset: 0x001E525C
		[OneWay]
		public void OurRemoteAsyncCallBack_ParishWallDetailInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo remoteAsyncDelegate_ParishWallDetailInfo = (RemoteServices.RemoteAsyncDelegate_ParishWallDetailInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_ParishWallDetailInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				ParishWallDetailInfo_ReturnType returnData = new ParishWallDetailInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002144 RID: 8516 RVA: 0x0001DFA9 File Offset: 0x0001C1A9
		public void set_StandDownAsParishDespot_UserCallBack(RemoteServices.StandDownAsParishDespot_UserCallBack callback)
		{
			this.standDownAsParishDespot_UserCallBack = callback;
		}

		// Token: 0x06002145 RID: 8517 RVA: 0x001E70AC File Offset: 0x001E52AC
		public void StandDownAsParishDespot(int villageID)
		{
			if (this.StandDownAsParishDespot_Callback == null)
			{
				this.StandDownAsParishDespot_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_StandDownAsParishDespot);
			}
			RemoteServices.RemoteAsyncDelegate_StandDownAsParishDespot remoteAsyncDelegate_StandDownAsParishDespot = new RemoteServices.RemoteAsyncDelegate_StandDownAsParishDespot(this.service.StandDownAsParishDespot);
			this.registerRPCcall(remoteAsyncDelegate_StandDownAsParishDespot.BeginInvoke(this.UserID, this.SessionID, villageID, this.StandDownAsParishDespot_Callback, null), typeof(StandDownAsParishDespot_ReturnType));
		}

		// Token: 0x06002146 RID: 8518 RVA: 0x001E7110 File Offset: 0x001E5310
		[OneWay]
		public void OurRemoteAsyncCallBack_StandDownAsParishDespot(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_StandDownAsParishDespot remoteAsyncDelegate_StandDownAsParishDespot = (RemoteServices.RemoteAsyncDelegate_StandDownAsParishDespot)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_StandDownAsParishDespot.EndInvoke(ar));
			}
			catch (Exception e)
			{
				StandDownAsParishDespot_ReturnType returnData = new StandDownAsParishDespot_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002147 RID: 8519 RVA: 0x0001DFB2 File Offset: 0x0001C1B2
		public void set_MakeParishVote_UserCallBack(RemoteServices.MakeParishVote_UserCallBack callback)
		{
			this.makeParishVote_UserCallBack = callback;
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x001E7160 File Offset: 0x001E5360
		public void MakeParishVote(int villageID, int votedUserID)
		{
			if (this.MakeParishVote_Callback == null)
			{
				this.MakeParishVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakeParishVote);
			}
			RemoteServices.RemoteAsyncDelegate_MakeParishVote remoteAsyncDelegate_MakeParishVote = new RemoteServices.RemoteAsyncDelegate_MakeParishVote(this.service.MakeParishVote);
			this.registerRPCcall(remoteAsyncDelegate_MakeParishVote.BeginInvoke(this.UserID, this.SessionID, villageID, votedUserID, this.MakeParishVote_Callback, null), typeof(MakeParishVote_ReturnType));
		}

		// Token: 0x06002149 RID: 8521 RVA: 0x001E71C8 File Offset: 0x001E53C8
		[OneWay]
		public void OurRemoteAsyncCallBack_MakeParishVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakeParishVote remoteAsyncDelegate_MakeParishVote = (RemoteServices.RemoteAsyncDelegate_MakeParishVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakeParishVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakeParishVote_ReturnType returnData = new MakeParishVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x0001DFBB File Offset: 0x0001C1BB
		public void set_SendTroopsToCapital_UserCallBack(RemoteServices.SendTroopsToCapital_UserCallBack callback)
		{
			this.sendTroopsToCapital_UserCallBack = callback;
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x001E7218 File Offset: 0x001E5418
		public void SendTroopsToCapital(int sourceVillageID, int targetVillageID, int peasants, int archers, int pikemen, int swordsmen, int catapults)
		{
			if (this.SendTroopsToCapital_Callback == null)
			{
				this.SendTroopsToCapital_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendTroopsToCapital);
			}
			RemoteServices.RemoteAsyncDelegate_SendTroopsToCapital remoteAsyncDelegate_SendTroopsToCapital = new RemoteServices.RemoteAsyncDelegate_SendTroopsToCapital(this.service.SendTroopsToCapital);
			this.registerRPCcall(remoteAsyncDelegate_SendTroopsToCapital.BeginInvoke(this.UserID, this.SessionID, sourceVillageID, targetVillageID, peasants, archers, pikemen, swordsmen, catapults, this.SendTroopsToCapital_Callback, null), typeof(SendTroopsToCapital_ReturnType));
		}

		// Token: 0x0600214C RID: 8524 RVA: 0x001E7288 File Offset: 0x001E5488
		[OneWay]
		public void OurRemoteAsyncCallBack_SendTroopsToCapital(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendTroopsToCapital remoteAsyncDelegate_SendTroopsToCapital = (RemoteServices.RemoteAsyncDelegate_SendTroopsToCapital)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendTroopsToCapital.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendTroopsToCapital_ReturnType returnData = new SendTroopsToCapital_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600214D RID: 8525 RVA: 0x0001DFC4 File Offset: 0x0001C1C4
		public void set_GetCapitalBarracksSpace_UserCallBack(RemoteServices.GetCapitalBarracksSpace_UserCallBack callback)
		{
			this.getCapitalBarracksSpace_UserCallBack = callback;
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x001E72D8 File Offset: 0x001E54D8
		public void GetCapitalBarracksSpace(int sourceVillageID, int targetVillageID)
		{
			if (this.GetCapitalBarracksSpace_Callback == null)
			{
				this.GetCapitalBarracksSpace_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCapitalBarracksSpace);
			}
			RemoteServices.RemoteAsyncDelegate_GetCapitalBarracksSpace remoteAsyncDelegate_GetCapitalBarracksSpace = new RemoteServices.RemoteAsyncDelegate_GetCapitalBarracksSpace(this.service.GetCapitalBarracksSpace);
			this.registerRPCcall(remoteAsyncDelegate_GetCapitalBarracksSpace.BeginInvoke(this.UserID, this.SessionID, sourceVillageID, targetVillageID, this.GetCapitalBarracksSpace_Callback, null), typeof(GetCapitalBarracksSpace_ReturnType));
		}

		// Token: 0x0600214F RID: 8527 RVA: 0x001E7340 File Offset: 0x001E5540
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCapitalBarracksSpace(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCapitalBarracksSpace remoteAsyncDelegate_GetCapitalBarracksSpace = (RemoteServices.RemoteAsyncDelegate_GetCapitalBarracksSpace)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCapitalBarracksSpace.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCapitalBarracksSpace_ReturnType returnData = new GetCapitalBarracksSpace_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x0001DFCD File Offset: 0x0001C1CD
		public void set_GetCountyElectionInfo_UserCallBack(RemoteServices.GetCountyElectionInfo_UserCallBack callback)
		{
			this.getCountyElectionInfo_UserCallBack = callback;
		}

		// Token: 0x06002151 RID: 8529 RVA: 0x001E7390 File Offset: 0x001E5590
		public void GetCountyElectionInfo(int villageID)
		{
			if (this.GetCountyElectionInfo_Callback == null)
			{
				this.GetCountyElectionInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCountyElectionInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetCountyElectionInfo remoteAsyncDelegate_GetCountyElectionInfo = new RemoteServices.RemoteAsyncDelegate_GetCountyElectionInfo(this.service.GetCountyElectionInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetCountyElectionInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetCountyElectionInfo_Callback, null), typeof(GetCountyElectionInfo_ReturnType));
		}

		// Token: 0x06002152 RID: 8530 RVA: 0x001E73F4 File Offset: 0x001E55F4
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCountyElectionInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCountyElectionInfo remoteAsyncDelegate_GetCountyElectionInfo = (RemoteServices.RemoteAsyncDelegate_GetCountyElectionInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCountyElectionInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCountyElectionInfo_ReturnType returnData = new GetCountyElectionInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002153 RID: 8531 RVA: 0x0001DFD6 File Offset: 0x0001C1D6
		public void set_GetCountyFrontPageInfo_UserCallBack(RemoteServices.GetCountyFrontPageInfo_UserCallBack callback)
		{
			this.getCountyFrontPageInfo_UserCallBack = callback;
		}

		// Token: 0x06002154 RID: 8532 RVA: 0x001E7444 File Offset: 0x001E5644
		public void GetCountyFrontPageInfo(int villageID)
		{
			if (this.GetCountyFrontPageInfo_Callback == null)
			{
				this.GetCountyFrontPageInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCountyFrontPageInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetCountyFrontPageInfo remoteAsyncDelegate_GetCountyFrontPageInfo = new RemoteServices.RemoteAsyncDelegate_GetCountyFrontPageInfo(this.service.GetCountyFrontPageInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetCountyFrontPageInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetCountyFrontPageInfo_Callback, null), typeof(GetCountyFrontPageInfo_ReturnType));
		}

		// Token: 0x06002155 RID: 8533 RVA: 0x001E74A8 File Offset: 0x001E56A8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCountyFrontPageInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCountyFrontPageInfo remoteAsyncDelegate_GetCountyFrontPageInfo = (RemoteServices.RemoteAsyncDelegate_GetCountyFrontPageInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCountyFrontPageInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCountyFrontPageInfo_ReturnType returnData = new GetCountyFrontPageInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x0001DFDF File Offset: 0x0001C1DF
		public void set_MakeCountyVote_UserCallBack(RemoteServices.MakeCountyVote_UserCallBack callback)
		{
			this.makeCountyVote_UserCallBack = callback;
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x001E74F8 File Offset: 0x001E56F8
		public void MakeCountyVote(int villageID, int votedParishID)
		{
			if (this.MakeCountyVote_Callback == null)
			{
				this.MakeCountyVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakeCountyVote);
			}
			RemoteServices.RemoteAsyncDelegate_MakeCountyVote remoteAsyncDelegate_MakeCountyVote = new RemoteServices.RemoteAsyncDelegate_MakeCountyVote(this.service.MakeCountyVote);
			this.registerRPCcall(remoteAsyncDelegate_MakeCountyVote.BeginInvoke(this.UserID, this.SessionID, villageID, votedParishID, this.MakeCountyVote_Callback, null), typeof(MakeCountyVote_ReturnType));
		}

		// Token: 0x06002158 RID: 8536 RVA: 0x001E7560 File Offset: 0x001E5760
		[OneWay]
		public void OurRemoteAsyncCallBack_MakeCountyVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakeCountyVote remoteAsyncDelegate_MakeCountyVote = (RemoteServices.RemoteAsyncDelegate_MakeCountyVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakeCountyVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakeCountyVote_ReturnType returnData = new MakeCountyVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x0001DFE8 File Offset: 0x0001C1E8
		public void set_GetProvinceElectionInfo_UserCallBack(RemoteServices.GetProvinceElectionInfo_UserCallBack callback)
		{
			this.getProvinceElectionInfo_UserCallBack = callback;
		}

		// Token: 0x0600215A RID: 8538 RVA: 0x001E75B0 File Offset: 0x001E57B0
		public void GetProvinceElectionInfo(int villageID)
		{
			if (this.GetProvinceElectionInfo_Callback == null)
			{
				this.GetProvinceElectionInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetProvinceElectionInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetProvinceElectionInfo remoteAsyncDelegate_GetProvinceElectionInfo = new RemoteServices.RemoteAsyncDelegate_GetProvinceElectionInfo(this.service.GetProvinceElectionInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetProvinceElectionInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetProvinceElectionInfo_Callback, null), typeof(GetProvinceElectionInfo_ReturnType));
		}

		// Token: 0x0600215B RID: 8539 RVA: 0x001E7614 File Offset: 0x001E5814
		[OneWay]
		public void OurRemoteAsyncCallBack_GetProvinceElectionInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetProvinceElectionInfo remoteAsyncDelegate_GetProvinceElectionInfo = (RemoteServices.RemoteAsyncDelegate_GetProvinceElectionInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetProvinceElectionInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetProvinceElectionInfo_ReturnType returnData = new GetProvinceElectionInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600215C RID: 8540 RVA: 0x0001DFF1 File Offset: 0x0001C1F1
		public void set_GetProvinceFrontPageInfo_UserCallBack(RemoteServices.GetProvinceFrontPageInfo_UserCallBack callback)
		{
			this.getProvinceFrontPageInfo_UserCallBack = callback;
		}

		// Token: 0x0600215D RID: 8541 RVA: 0x001E7664 File Offset: 0x001E5864
		public void GetProvinceFrontPageInfo(int villageID)
		{
			if (this.GetProvinceFrontPageInfo_Callback == null)
			{
				this.GetProvinceFrontPageInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetProvinceFrontPageInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetProvinceFrontPageInfo remoteAsyncDelegate_GetProvinceFrontPageInfo = new RemoteServices.RemoteAsyncDelegate_GetProvinceFrontPageInfo(this.service.GetProvinceFrontPageInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetProvinceFrontPageInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetProvinceFrontPageInfo_Callback, null), typeof(GetProvinceFrontPageInfo_ReturnType));
		}

		// Token: 0x0600215E RID: 8542 RVA: 0x001E76C8 File Offset: 0x001E58C8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetProvinceFrontPageInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetProvinceFrontPageInfo remoteAsyncDelegate_GetProvinceFrontPageInfo = (RemoteServices.RemoteAsyncDelegate_GetProvinceFrontPageInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetProvinceFrontPageInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetProvinceFrontPageInfo_ReturnType returnData = new GetProvinceFrontPageInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600215F RID: 8543 RVA: 0x0001DFFA File Offset: 0x0001C1FA
		public void set_MakeProvinceVote_UserCallBack(RemoteServices.MakeProvinceVote_UserCallBack callback)
		{
			this.makeProvinceVote_UserCallBack = callback;
		}

		// Token: 0x06002160 RID: 8544 RVA: 0x001E7718 File Offset: 0x001E5918
		public void MakeProvinceVote(int villageID, int votedParishID)
		{
			if (this.MakeProvinceVote_Callback == null)
			{
				this.MakeProvinceVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakeProvinceVote);
			}
			RemoteServices.RemoteAsyncDelegate_MakeProvinceVote remoteAsyncDelegate_MakeProvinceVote = new RemoteServices.RemoteAsyncDelegate_MakeProvinceVote(this.service.MakeProvinceVote);
			this.registerRPCcall(remoteAsyncDelegate_MakeProvinceVote.BeginInvoke(this.UserID, this.SessionID, villageID, votedParishID, this.MakeProvinceVote_Callback, null), typeof(MakeProvinceVote_ReturnType));
		}

		// Token: 0x06002161 RID: 8545 RVA: 0x001E7780 File Offset: 0x001E5980
		[OneWay]
		public void OurRemoteAsyncCallBack_MakeProvinceVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakeProvinceVote remoteAsyncDelegate_MakeProvinceVote = (RemoteServices.RemoteAsyncDelegate_MakeProvinceVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakeProvinceVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakeProvinceVote_ReturnType returnData = new MakeProvinceVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002162 RID: 8546 RVA: 0x0001E003 File Offset: 0x0001C203
		public void set_GetCountryElectionInfo_UserCallBack(RemoteServices.GetCountryElectionInfo_UserCallBack callback)
		{
			this.getCountryElectionInfo_UserCallBack = callback;
		}

		// Token: 0x06002163 RID: 8547 RVA: 0x001E77D0 File Offset: 0x001E59D0
		public void GetCountryElectionInfo(int villageID)
		{
			if (this.GetCountryElectionInfo_Callback == null)
			{
				this.GetCountryElectionInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCountryElectionInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetCountryElectionInfo remoteAsyncDelegate_GetCountryElectionInfo = new RemoteServices.RemoteAsyncDelegate_GetCountryElectionInfo(this.service.GetCountryElectionInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetCountryElectionInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetCountryElectionInfo_Callback, null), typeof(GetCountryElectionInfo_ReturnType));
		}

		// Token: 0x06002164 RID: 8548 RVA: 0x001E7834 File Offset: 0x001E5A34
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCountryElectionInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCountryElectionInfo remoteAsyncDelegate_GetCountryElectionInfo = (RemoteServices.RemoteAsyncDelegate_GetCountryElectionInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCountryElectionInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCountryElectionInfo_ReturnType returnData = new GetCountryElectionInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002165 RID: 8549 RVA: 0x0001E00C File Offset: 0x0001C20C
		public void set_GetCountryFrontPageInfo_UserCallBack(RemoteServices.GetCountryFrontPageInfo_UserCallBack callback)
		{
			this.getCountryFrontPageInfo_UserCallBack = callback;
		}

		// Token: 0x06002166 RID: 8550 RVA: 0x001E7884 File Offset: 0x001E5A84
		public void GetCountryFrontPageInfo(int villageID)
		{
			if (this.GetCountryFrontPageInfo_Callback == null)
			{
				this.GetCountryFrontPageInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetCountryFrontPageInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetCountryFrontPageInfo remoteAsyncDelegate_GetCountryFrontPageInfo = new RemoteServices.RemoteAsyncDelegate_GetCountryFrontPageInfo(this.service.GetCountryFrontPageInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetCountryFrontPageInfo.BeginInvoke(this.UserID, this.SessionID, villageID, this.GetCountryFrontPageInfo_Callback, null), typeof(GetCountryFrontPageInfo_ReturnType));
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x001E78E8 File Offset: 0x001E5AE8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetCountryFrontPageInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetCountryFrontPageInfo remoteAsyncDelegate_GetCountryFrontPageInfo = (RemoteServices.RemoteAsyncDelegate_GetCountryFrontPageInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetCountryFrontPageInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetCountryFrontPageInfo_ReturnType returnData = new GetCountryFrontPageInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002168 RID: 8552 RVA: 0x0001E015 File Offset: 0x0001C215
		public void set_MakeCountryVote_UserCallBack(RemoteServices.MakeCountryVote_UserCallBack callback)
		{
			this.makeCountryVote_UserCallBack = callback;
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x001E7938 File Offset: 0x001E5B38
		public void MakeCountryVote(int villageID, int votedParishID)
		{
			if (this.MakeCountryVote_Callback == null)
			{
				this.MakeCountryVote_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_MakeCountryVote);
			}
			RemoteServices.RemoteAsyncDelegate_MakeCountryVote remoteAsyncDelegate_MakeCountryVote = new RemoteServices.RemoteAsyncDelegate_MakeCountryVote(this.service.MakeCountryVote);
			this.registerRPCcall(remoteAsyncDelegate_MakeCountryVote.BeginInvoke(this.UserID, this.SessionID, villageID, votedParishID, this.MakeCountryVote_Callback, null), typeof(MakeCountryVote_ReturnType));
		}

		// Token: 0x0600216A RID: 8554 RVA: 0x001E79A0 File Offset: 0x001E5BA0
		[OneWay]
		public void OurRemoteAsyncCallBack_MakeCountryVote(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_MakeCountryVote remoteAsyncDelegate_MakeCountryVote = (RemoteServices.RemoteAsyncDelegate_MakeCountryVote)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_MakeCountryVote.EndInvoke(ar));
			}
			catch (Exception e)
			{
				MakeCountryVote_ReturnType returnData = new MakeCountryVote_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600216B RID: 8555 RVA: 0x0001E01E File Offset: 0x0001C21E
		public void set_GetIngameMessage_UserCallBack(RemoteServices.GetIngameMessage_UserCallBack callback)
		{
			this.getIngameMessage_UserCallBack = callback;
		}

		// Token: 0x0600216C RID: 8556 RVA: 0x001E79F0 File Offset: 0x001E5BF0
		public void GetIngameMessage()
		{
			if (this.GetIngameMessage_Callback == null)
			{
				this.GetIngameMessage_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetIngameMessage);
			}
			RemoteServices.RemoteAsyncDelegate_GetIngameMessage remoteAsyncDelegate_GetIngameMessage = new RemoteServices.RemoteAsyncDelegate_GetIngameMessage(this.service.GetIngameMessage);
			this.registerRPCcall(remoteAsyncDelegate_GetIngameMessage.BeginInvoke(this.UserID, this.SessionID, this.GetIngameMessage_Callback, null), typeof(GetIngameMessage_ReturnType));
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x001E7A54 File Offset: 0x001E5C54
		[OneWay]
		public void OurRemoteAsyncCallBack_GetIngameMessage(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetIngameMessage remoteAsyncDelegate_GetIngameMessage = (RemoteServices.RemoteAsyncDelegate_GetIngameMessage)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetIngameMessage.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetIngameMessage_ReturnType returnData = new GetIngameMessage_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x0001E027 File Offset: 0x0001C227
		public void set_CancelInterdiction_UserCallBack(RemoteServices.CancelInterdiction_UserCallBack callback)
		{
			this.cancelInterdiction_UserCallBack = callback;
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x001E7AA4 File Offset: 0x001E5CA4
		public void CancelInterdiction(int villageID)
		{
			if (this.CancelInterdiction_Callback == null)
			{
				this.CancelInterdiction_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CancelInterdiction);
			}
			RemoteServices.RemoteAsyncDelegate_CancelInterdiction remoteAsyncDelegate_CancelInterdiction = new RemoteServices.RemoteAsyncDelegate_CancelInterdiction(this.service.CancelInterdiction);
			this.registerRPCcall(remoteAsyncDelegate_CancelInterdiction.BeginInvoke(this.UserID, this.SessionID, villageID, this.CancelInterdiction_Callback, null), typeof(CancelInterdiction_ReturnType));
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x001E7B08 File Offset: 0x001E5D08
		[OneWay]
		public void OurRemoteAsyncCallBack_CancelInterdiction(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CancelInterdiction remoteAsyncDelegate_CancelInterdiction = (RemoteServices.RemoteAsyncDelegate_CancelInterdiction)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CancelInterdiction.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CancelInterdiction_ReturnType returnData = new CancelInterdiction_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002171 RID: 8561 RVA: 0x0001E030 File Offset: 0x0001C230
		public void set_GetExcommunicationStatus_UserCallBack(RemoteServices.GetExcommunicationStatus_UserCallBack callback)
		{
			this.getExcommunicationStatus_UserCallBack = callback;
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x001E7B58 File Offset: 0x001E5D58
		public void GetExcommunicationStatus(int villageID, int targetVillageID)
		{
			if (this.GetExcommunicationStatus_Callback == null)
			{
				this.GetExcommunicationStatus_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetExcommunicationStatus);
			}
			RemoteServices.RemoteAsyncDelegate_GetExcommunicationStatus remoteAsyncDelegate_GetExcommunicationStatus = new RemoteServices.RemoteAsyncDelegate_GetExcommunicationStatus(this.service.GetExcommunicationStatus);
			this.registerRPCcall(remoteAsyncDelegate_GetExcommunicationStatus.BeginInvoke(this.UserID, this.SessionID, villageID, targetVillageID, this.GetExcommunicationStatus_Callback, null), typeof(GetExcommunicationStatus_ReturnType));
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x001E7BC0 File Offset: 0x001E5DC0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetExcommunicationStatus(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetExcommunicationStatus remoteAsyncDelegate_GetExcommunicationStatus = (RemoteServices.RemoteAsyncDelegate_GetExcommunicationStatus)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetExcommunicationStatus.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetExcommunicationStatus_ReturnType returnData = new GetExcommunicationStatus_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x0001E039 File Offset: 0x0001C239
		public void set_DisbandTroops_UserCallBack(RemoteServices.DisbandTroops_UserCallBack callback)
		{
			this.disbandTroops_UserCallBack = callback;
		}

		// Token: 0x06002175 RID: 8565 RVA: 0x001E7C10 File Offset: 0x001E5E10
		public void DisbandTroops(int villageID, int troopType, int amount)
		{
			if (this.DisbandTroops_Callback == null)
			{
				this.DisbandTroops_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DisbandTroops);
			}
			RemoteServices.RemoteAsyncDelegate_DisbandTroops remoteAsyncDelegate_DisbandTroops = new RemoteServices.RemoteAsyncDelegate_DisbandTroops(this.service.DisbandTroops);
			this.registerRPCcall(remoteAsyncDelegate_DisbandTroops.BeginInvoke(this.UserID, this.SessionID, villageID, troopType, amount, this.DisbandTroops_Callback, null), typeof(DisbandTroops_ReturnType));
		}

		// Token: 0x06002176 RID: 8566 RVA: 0x001E7C78 File Offset: 0x001E5E78
		[OneWay]
		public void OurRemoteAsyncCallBack_DisbandTroops(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DisbandTroops remoteAsyncDelegate_DisbandTroops = (RemoteServices.RemoteAsyncDelegate_DisbandTroops)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DisbandTroops.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DisbandTroops_ReturnType returnData = new DisbandTroops_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002177 RID: 8567 RVA: 0x0001E042 File Offset: 0x0001C242
		public void set_DisbandPeople_UserCallBack(RemoteServices.DisbandPeople_UserCallBack callback)
		{
			this.disbandPeople_UserCallBack = callback;
		}

		// Token: 0x06002178 RID: 8568 RVA: 0x001E7CC8 File Offset: 0x001E5EC8
		public void DisbandPeople(int villageID, int troopType, int amount)
		{
			if (this.DisbandPeople_Callback == null)
			{
				this.DisbandPeople_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DisbandPeople);
			}
			RemoteServices.RemoteAsyncDelegate_DisbandPeople remoteAsyncDelegate_DisbandPeople = new RemoteServices.RemoteAsyncDelegate_DisbandPeople(this.service.DisbandPeople);
			this.registerRPCcall(remoteAsyncDelegate_DisbandPeople.BeginInvoke(this.UserID, this.SessionID, villageID, troopType, amount, this.DisbandPeople_Callback, null), typeof(DisbandPeople_ReturnType));
		}

		// Token: 0x06002179 RID: 8569 RVA: 0x001E7D30 File Offset: 0x001E5F30
		[OneWay]
		public void OurRemoteAsyncCallBack_DisbandPeople(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DisbandPeople remoteAsyncDelegate_DisbandPeople = (RemoteServices.RemoteAsyncDelegate_DisbandPeople)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DisbandPeople.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DisbandPeople_ReturnType returnData = new DisbandPeople_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600217A RID: 8570 RVA: 0x0001E04B File Offset: 0x0001C24B
		public void set_GetVillageInfoForDonateCapitalGoods_UserCallBack(RemoteServices.GetVillageInfoForDonateCapitalGoods_UserCallBack callback)
		{
			this.getVillageInfoForDonateCapitalGoods_UserCallBack = callback;
		}

		// Token: 0x0600217B RID: 8571 RVA: 0x001E7D80 File Offset: 0x001E5F80
		public void GetVillageInfoForDonateCapitalGoods(int parishCapitalID, int targetBuildingType)
		{
			if (this.GetVillageInfoForDonateCapitalGoods_Callback == null)
			{
				this.GetVillageInfoForDonateCapitalGoods_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageInfoForDonateCapitalGoods);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods remoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods = new RemoteServices.RemoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods(this.service.GetVillageInfoForDonateCapitalGoods);
			this.registerRPCcall(remoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods.BeginInvoke(this.UserID, this.SessionID, parishCapitalID, targetBuildingType, this.GetVillageInfoForDonateCapitalGoods_Callback, null), typeof(GetVillageInfoForDonateCapitalGoods_ReturnType));
		}

		// Token: 0x0600217C RID: 8572 RVA: 0x001E7DE8 File Offset: 0x001E5FE8
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageInfoForDonateCapitalGoods(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods remoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods = (RemoteServices.RemoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetVillageInfoForDonateCapitalGoods_ReturnType returnData = new GetVillageInfoForDonateCapitalGoods_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600217D RID: 8573 RVA: 0x0001E054 File Offset: 0x0001C254
		public void set_DonateCapitalGoods_UserCallBack(RemoteServices.DonateCapitalGoods_UserCallBack callback)
		{
			this.donateCapitalGoods_UserCallBack = callback;
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x001E7E38 File Offset: 0x001E6038
		public void DonateCapitalGoods(int targetVillageID, int sourceVillageID, int resourceType, int amount, int buildingType, long targetBuildingID)
		{
			if (this.DonateCapitalGoods_Callback == null)
			{
				this.DonateCapitalGoods_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_DonateCapitalGoods);
			}
			RemoteServices.RemoteAsyncDelegate_DonateCapitalGoods remoteAsyncDelegate_DonateCapitalGoods = new RemoteServices.RemoteAsyncDelegate_DonateCapitalGoods(this.service.DonateCapitalGoods);
			this.registerRPCcall(remoteAsyncDelegate_DonateCapitalGoods.BeginInvoke(this.UserID, this.SessionID, targetVillageID, sourceVillageID, resourceType, amount, buildingType, targetBuildingID, this.DonateCapitalGoods_Callback, null), typeof(DonateCapitalGoods_ReturnType));
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x001E7EA4 File Offset: 0x001E60A4
		[OneWay]
		public void OurRemoteAsyncCallBack_DonateCapitalGoods(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_DonateCapitalGoods remoteAsyncDelegate_DonateCapitalGoods = (RemoteServices.RemoteAsyncDelegate_DonateCapitalGoods)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_DonateCapitalGoods.EndInvoke(ar));
			}
			catch (Exception e)
			{
				DonateCapitalGoods_ReturnType returnData = new DonateCapitalGoods_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002180 RID: 8576 RVA: 0x0001E05D File Offset: 0x0001C25D
		public void set_GetVillageStartLocations_UserCallBack(RemoteServices.GetVillageStartLocations_UserCallBack callback)
		{
			this.getVillageStartLocations_UserCallBack = callback;
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x001E7EF4 File Offset: 0x001E60F4
		public void GetVillageStartLocations()
		{
			if (this.GetVillageStartLocations_Callback == null)
			{
				this.GetVillageStartLocations_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetVillageStartLocations);
			}
			RemoteServices.RemoteAsyncDelegate_GetVillageStartLocations remoteAsyncDelegate_GetVillageStartLocations = new RemoteServices.RemoteAsyncDelegate_GetVillageStartLocations(this.service.GetVillageStartLocations);
			this.registerRPCcall(remoteAsyncDelegate_GetVillageStartLocations.BeginInvoke(this.UserID, this.SessionID, this.GetVillageStartLocations_Callback, null), typeof(GetVillageStartLocations_ReturnType));
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x001E7F58 File Offset: 0x001E6158
		[OneWay]
		public void OurRemoteAsyncCallBack_GetVillageStartLocations(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetVillageStartLocations remoteAsyncDelegate_GetVillageStartLocations = (RemoteServices.RemoteAsyncDelegate_GetVillageStartLocations)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetVillageStartLocations.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetVillageStartLocations_ReturnType returnData = new GetVillageStartLocations_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002183 RID: 8579 RVA: 0x0001E066 File Offset: 0x0001C266
		public void set_SetStartingCounty_UserCallBack(RemoteServices.SetStartingCounty_UserCallBack callback)
		{
			this.setStartingCounty_UserCallBack = callback;
		}

		// Token: 0x06002184 RID: 8580 RVA: 0x001E7FA8 File Offset: 0x001E61A8
		public void SetStartingCounty(int countyID)
		{
			if (this.SetStartingCounty_Callback == null)
			{
				this.SetStartingCounty_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SetStartingCounty);
			}
			RemoteServices.RemoteAsyncDelegate_SetStartingCounty remoteAsyncDelegate_SetStartingCounty = new RemoteServices.RemoteAsyncDelegate_SetStartingCounty(this.service.SetStartingCounty);
			this.registerRPCcall(remoteAsyncDelegate_SetStartingCounty.BeginInvoke(this.UserID, this.SessionID, countyID, this.SetStartingCounty_Callback, null), typeof(SetStartingCounty_ReturnType));
		}

		// Token: 0x06002185 RID: 8581 RVA: 0x001E800C File Offset: 0x001E620C
		[OneWay]
		public void OurRemoteAsyncCallBack_SetStartingCounty(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SetStartingCounty remoteAsyncDelegate_SetStartingCounty = (RemoteServices.RemoteAsyncDelegate_SetStartingCounty)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SetStartingCounty.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SetStartingCounty_ReturnType returnData = new SetStartingCounty_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002186 RID: 8582 RVA: 0x0001E06F File Offset: 0x0001C26F
		public void set_CancelCard_UserCallBack(RemoteServices.CancelCard_UserCallBack callback)
		{
			this.cancelCard_UserCallBack = callback;
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x001E805C File Offset: 0x001E625C
		public void CancelCard(int card)
		{
			if (this.CancelCard_Callback == null)
			{
				this.CancelCard_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CancelCard);
			}
			RemoteServices.RemoteAsyncDelegate_CancelCard remoteAsyncDelegate_CancelCard = new RemoteServices.RemoteAsyncDelegate_CancelCard(this.service.CancelCard);
			this.registerRPCcall(remoteAsyncDelegate_CancelCard.BeginInvoke(this.UserID, this.SessionID, card, this.CancelCard_Callback, null), typeof(CancelCard_ReturnType));
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x001E80C0 File Offset: 0x001E62C0
		[OneWay]
		public void OurRemoteAsyncCallBack_CancelCard(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CancelCard remoteAsyncDelegate_CancelCard = (RemoteServices.RemoteAsyncDelegate_CancelCard)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CancelCard.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CancelCard_ReturnType returnData = new CancelCard_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002189 RID: 8585 RVA: 0x0001E078 File Offset: 0x0001C278
		public void set_UpdateCurrentCards_UserCallBack(RemoteServices.UpdateCurrentCards_UserCallBack callback)
		{
			this.updateCurrentCards_UserCallBack = callback;
		}

		// Token: 0x0600218A RID: 8586 RVA: 0x001E8110 File Offset: 0x001E6310
		public void UpdateCurrentCards()
		{
			if (this.UpdateCurrentCards_Callback == null)
			{
				this.UpdateCurrentCards_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateCurrentCards);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateCurrentCards remoteAsyncDelegate_UpdateCurrentCards = new RemoteServices.RemoteAsyncDelegate_UpdateCurrentCards(this.service.UpdateCurrentCards);
			this.registerRPCcall(remoteAsyncDelegate_UpdateCurrentCards.BeginInvoke(this.UserID, this.SessionID, this.UpdateCurrentCards_Callback, null), typeof(UpdateCurrentCards_ReturnType));
		}

		// Token: 0x0600218B RID: 8587 RVA: 0x001E8174 File Offset: 0x001E6374
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateCurrentCards(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateCurrentCards remoteAsyncDelegate_UpdateCurrentCards = (RemoteServices.RemoteAsyncDelegate_UpdateCurrentCards)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateCurrentCards.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateCurrentCards_ReturnType returnData = new UpdateCurrentCards_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600218C RID: 8588 RVA: 0x0001E081 File Offset: 0x0001C281
		public void set_TutorialCommand_UserCallBack(RemoteServices.TutorialCommand_UserCallBack callback)
		{
			this.tutorialCommand_UserCallBack = callback;
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x001E81C4 File Offset: 0x001E63C4
		public void TutorialCommand(int command)
		{
			if (this.TutorialCommand_Callback == null)
			{
				this.TutorialCommand_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_TutorialCommand);
			}
			RemoteServices.RemoteAsyncDelegate_TutorialCommand remoteAsyncDelegate_TutorialCommand = new RemoteServices.RemoteAsyncDelegate_TutorialCommand(this.service.TutorialCommand);
			this.registerRPCcall(remoteAsyncDelegate_TutorialCommand.BeginInvoke(this.UserID, this.SessionID, command, this.TutorialCommand_Callback, null), typeof(TutorialCommand_ReturnType));
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x001E8228 File Offset: 0x001E6428
		[OneWay]
		public void OurRemoteAsyncCallBack_TutorialCommand(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_TutorialCommand remoteAsyncDelegate_TutorialCommand = (RemoteServices.RemoteAsyncDelegate_TutorialCommand)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_TutorialCommand.EndInvoke(ar));
			}
			catch (Exception e)
			{
				TutorialCommand_ReturnType returnData = new TutorialCommand_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x0001E08A File Offset: 0x0001C28A
		public void set_GetQuestStatus_UserCallBack(RemoteServices.GetQuestStatus_UserCallBack callback)
		{
			this.getQuestStatus_UserCallBack = callback;
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x001E8278 File Offset: 0x001E6478
		public void GetQuestStatus()
		{
			if (this.GetQuestStatus_Callback == null)
			{
				this.GetQuestStatus_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetQuestStatus);
			}
			RemoteServices.RemoteAsyncDelegate_GetQuestStatus remoteAsyncDelegate_GetQuestStatus = new RemoteServices.RemoteAsyncDelegate_GetQuestStatus(this.service.GetQuestStatus);
			this.registerRPCcall(remoteAsyncDelegate_GetQuestStatus.BeginInvoke(this.UserID, this.SessionID, this.GetQuestStatus_Callback, null), typeof(GetQuestStatus_ReturnType));
		}

		// Token: 0x06002191 RID: 8593 RVA: 0x001E82DC File Offset: 0x001E64DC
		[OneWay]
		public void OurRemoteAsyncCallBack_GetQuestStatus(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetQuestStatus remoteAsyncDelegate_GetQuestStatus = (RemoteServices.RemoteAsyncDelegate_GetQuestStatus)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetQuestStatus.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetQuestStatus_ReturnType returnData = new GetQuestStatus_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002192 RID: 8594 RVA: 0x0001E093 File Offset: 0x0001C293
		public void set_CompleteQuest_UserCallBack(RemoteServices.CompleteQuest_UserCallBack callback)
		{
			this.completeQuest_UserCallBack = callback;
		}

		// Token: 0x06002193 RID: 8595 RVA: 0x001E832C File Offset: 0x001E652C
		public void CompleteQuest(int quest)
		{
			if (this.CompleteQuest_Callback == null)
			{
				this.CompleteQuest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CompleteQuest);
			}
			RemoteServices.RemoteAsyncDelegate_CompleteQuest remoteAsyncDelegate_CompleteQuest = new RemoteServices.RemoteAsyncDelegate_CompleteQuest(this.service.CompleteQuest);
			this.registerRPCcall(remoteAsyncDelegate_CompleteQuest.BeginInvoke(this.UserID, this.SessionID, quest, this.CompleteQuest_Callback, null), typeof(CompleteQuest_ReturnType));
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x001E8390 File Offset: 0x001E6590
		[OneWay]
		public void OurRemoteAsyncCallBack_CompleteQuest(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CompleteQuest remoteAsyncDelegate_CompleteQuest = (RemoteServices.RemoteAsyncDelegate_CompleteQuest)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CompleteQuest.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CompleteQuest_ReturnType returnData = new CompleteQuest_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x0001E09C File Offset: 0x0001C29C
		public void set_FlagQuestObjectiveComplete_UserCallBack(RemoteServices.FlagQuestObjectiveComplete_UserCallBack callback)
		{
			this.flagQuestObjectiveComplete_UserCallBack = callback;
		}

		// Token: 0x06002196 RID: 8598 RVA: 0x001E83E0 File Offset: 0x001E65E0
		public void FlagQuestObjectiveComplete(int objective)
		{
			if (this.FlagQuestObjectiveComplete_Callback == null)
			{
				this.FlagQuestObjectiveComplete_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_FlagQuestObjectiveComplete);
			}
			RemoteServices.RemoteAsyncDelegate_FlagQuestObjectiveComplete remoteAsyncDelegate_FlagQuestObjectiveComplete = new RemoteServices.RemoteAsyncDelegate_FlagQuestObjectiveComplete(this.service.FlagQuestObjectiveComplete);
			this.registerRPCcall(remoteAsyncDelegate_FlagQuestObjectiveComplete.BeginInvoke(this.UserID, this.SessionID, objective, this.FlagQuestObjectiveComplete_Callback, null), typeof(FlagQuestObjectiveComplete_ReturnType));
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x001E8444 File Offset: 0x001E6644
		[OneWay]
		public void OurRemoteAsyncCallBack_FlagQuestObjectiveComplete(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_FlagQuestObjectiveComplete remoteAsyncDelegate_FlagQuestObjectiveComplete = (RemoteServices.RemoteAsyncDelegate_FlagQuestObjectiveComplete)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_FlagQuestObjectiveComplete.EndInvoke(ar));
			}
			catch (Exception e)
			{
				FlagQuestObjectiveComplete_ReturnType returnData = new FlagQuestObjectiveComplete_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x06002198 RID: 8600 RVA: 0x0001E0A5 File Offset: 0x0001C2A5
		public void set_CheckQuestObjectiveComplete_UserCallBack(RemoteServices.CheckQuestObjectiveComplete_UserCallBack callback)
		{
			this.checkQuestObjectiveComplete_UserCallBack = callback;
		}

		// Token: 0x06002199 RID: 8601 RVA: 0x001E8494 File Offset: 0x001E6694
		public void CheckQuestObjectiveComplete(int quest)
		{
			if (this.CheckQuestObjectiveComplete_Callback == null)
			{
				this.CheckQuestObjectiveComplete_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CheckQuestObjectiveComplete);
			}
			RemoteServices.RemoteAsyncDelegate_CheckQuestObjectiveComplete remoteAsyncDelegate_CheckQuestObjectiveComplete = new RemoteServices.RemoteAsyncDelegate_CheckQuestObjectiveComplete(this.service.CheckQuestObjectiveComplete);
			this.registerRPCcall(remoteAsyncDelegate_CheckQuestObjectiveComplete.BeginInvoke(this.UserID, this.SessionID, quest, this.CheckQuestObjectiveComplete_Callback, null), typeof(CheckQuestObjectiveComplete_ReturnType));
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001E84F8 File Offset: 0x001E66F8
		[OneWay]
		public void OurRemoteAsyncCallBack_CheckQuestObjectiveComplete(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CheckQuestObjectiveComplete remoteAsyncDelegate_CheckQuestObjectiveComplete = (RemoteServices.RemoteAsyncDelegate_CheckQuestObjectiveComplete)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CheckQuestObjectiveComplete.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CheckQuestObjectiveComplete_ReturnType returnData = new CheckQuestObjectiveComplete_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600219B RID: 8603 RVA: 0x0001E0AE File Offset: 0x0001C2AE
		public void set_UpdateDiplomacyStatus_UserCallBack(RemoteServices.UpdateDiplomacyStatus_UserCallBack callback)
		{
			this.updateDiplomacyStatus_UserCallBack = callback;
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x001E8548 File Offset: 0x001E6748
		public void UpdateDiplomacyStatus(bool state)
		{
			if (this.UpdateDiplomacyStatus_Callback == null)
			{
				this.UpdateDiplomacyStatus_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_UpdateDiplomacyStatus);
			}
			RemoteServices.RemoteAsyncDelegate_UpdateDiplomacyStatus remoteAsyncDelegate_UpdateDiplomacyStatus = new RemoteServices.RemoteAsyncDelegate_UpdateDiplomacyStatus(this.service.UpdateDiplomacyStatus);
			this.registerRPCcall(remoteAsyncDelegate_UpdateDiplomacyStatus.BeginInvoke(this.UserID, this.SessionID, state, this.UpdateDiplomacyStatus_Callback, null), typeof(UpdateDiplomacyStatus_ReturnType));
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x001E85AC File Offset: 0x001E67AC
		[OneWay]
		public void OurRemoteAsyncCallBack_UpdateDiplomacyStatus(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_UpdateDiplomacyStatus remoteAsyncDelegate_UpdateDiplomacyStatus = (RemoteServices.RemoteAsyncDelegate_UpdateDiplomacyStatus)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_UpdateDiplomacyStatus.EndInvoke(ar));
			}
			catch (Exception e)
			{
				UpdateDiplomacyStatus_ReturnType returnData = new UpdateDiplomacyStatus_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x0001E0B7 File Offset: 0x0001C2B7
		public void set_SendCommands_UserCallBack(RemoteServices.SendCommands_UserCallBack callback)
		{
			this.sendCommands_UserCallBack = callback;
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x001E85FC File Offset: 0x001E67FC
		public void SendCommands(int targetUserID, int command, int duration, string reason)
		{
			if (this.SendCommands_Callback == null)
			{
				this.SendCommands_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SendCommands);
			}
			RemoteServices.RemoteAsyncDelegate_SendCommands remoteAsyncDelegate_SendCommands = new RemoteServices.RemoteAsyncDelegate_SendCommands(this.service.SendCommands);
			this.registerRPCcall(remoteAsyncDelegate_SendCommands.BeginInvoke(this.UserID, this.SessionID, targetUserID, command, duration, reason, this.SendCommands_Callback, null), typeof(SendCommands_ReturnType));
		}

		// Token: 0x060021A0 RID: 8608 RVA: 0x001E8664 File Offset: 0x001E6864
		[OneWay]
		public void OurRemoteAsyncCallBack_SendCommands(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SendCommands remoteAsyncDelegate_SendCommands = (RemoteServices.RemoteAsyncDelegate_SendCommands)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SendCommands.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SendCommands_ReturnType returnData = new SendCommands_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021A1 RID: 8609 RVA: 0x0001E0C0 File Offset: 0x0001C2C0
		public void set_InitialiseFreeCards_UserCallBack(RemoteServices.InitialiseFreeCards_UserCallBack callback)
		{
			this.initialiseFreeCards_UserCallBack = callback;
		}

		// Token: 0x060021A2 RID: 8610 RVA: 0x001E86B4 File Offset: 0x001E68B4
		public void InitialiseFreeCards()
		{
			if (this.InitialiseFreeCards_Callback == null)
			{
				this.InitialiseFreeCards_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_InitialiseFreeCards);
			}
			RemoteServices.RemoteAsyncDelegate_InitialiseFreeCards remoteAsyncDelegate_InitialiseFreeCards = new RemoteServices.RemoteAsyncDelegate_InitialiseFreeCards(this.service.InitialiseFreeCards);
			this.registerRPCcall(remoteAsyncDelegate_InitialiseFreeCards.BeginInvoke(this.UserID, this.SessionID, this.InitialiseFreeCards_Callback, null), typeof(InitialiseFreeCards_ReturnType));
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x001E8718 File Offset: 0x001E6918
		[OneWay]
		public void OurRemoteAsyncCallBack_InitialiseFreeCards(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_InitialiseFreeCards remoteAsyncDelegate_InitialiseFreeCards = (RemoteServices.RemoteAsyncDelegate_InitialiseFreeCards)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_InitialiseFreeCards.EndInvoke(ar));
			}
			catch (Exception e)
			{
				InitialiseFreeCards_ReturnType returnData = new InitialiseFreeCards_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x0001E0C9 File Offset: 0x0001C2C9
		public void set_TestAchievements_UserCallBack(RemoteServices.TestAchievements_UserCallBack callback)
		{
			this.testAchievements_UserCallBack = callback;
		}

		// Token: 0x060021A5 RID: 8613 RVA: 0x001E8768 File Offset: 0x001E6968
		public void TestAchievements(List<int> achievementsToTest, List<AchievementData> achievementData)
		{
			if (this.TestAchievements_Callback == null)
			{
				this.TestAchievements_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_TestAchievements);
			}
			RemoteServices.RemoteAsyncDelegate_TestAchievements remoteAsyncDelegate_TestAchievements = new RemoteServices.RemoteAsyncDelegate_TestAchievements(this.service.TestAchievements);
			this.registerRPCcall(remoteAsyncDelegate_TestAchievements.BeginInvoke(this.UserID, this.SessionID, achievementsToTest, achievementData, this.TestAchievements_Callback, null), typeof(TestAchievements_ReturnType));
		}

		// Token: 0x060021A6 RID: 8614 RVA: 0x001E87D0 File Offset: 0x001E69D0
		[OneWay]
		public void OurRemoteAsyncCallBack_TestAchievements(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_TestAchievements remoteAsyncDelegate_TestAchievements = (RemoteServices.RemoteAsyncDelegate_TestAchievements)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_TestAchievements.EndInvoke(ar));
			}
			catch (Exception e)
			{
				TestAchievements_ReturnType returnData = new TestAchievements_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021A7 RID: 8615 RVA: 0x0001E0D2 File Offset: 0x0001C2D2
		public void set_AchievementProgress_UserCallBack(RemoteServices.AchievementProgress_UserCallBack callback)
		{
			this.achievementProgress_UserCallBack = callback;
		}

		// Token: 0x060021A8 RID: 8616 RVA: 0x001E8820 File Offset: 0x001E6A20
		public void AchievementProgress()
		{
			if (this.AchievementProgress_Callback == null)
			{
				this.AchievementProgress_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_AchievementProgress);
			}
			RemoteServices.RemoteAsyncDelegate_AchievementProgress remoteAsyncDelegate_AchievementProgress = new RemoteServices.RemoteAsyncDelegate_AchievementProgress(this.service.AchievementProgress);
			this.registerRPCcall(remoteAsyncDelegate_AchievementProgress.BeginInvoke(this.UserID, this.SessionID, this.AchievementProgress_Callback, null), typeof(AchievementProgress_ReturnType));
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x001E8884 File Offset: 0x001E6A84
		[OneWay]
		public void OurRemoteAsyncCallBack_AchievementProgress(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_AchievementProgress remoteAsyncDelegate_AchievementProgress = (RemoteServices.RemoteAsyncDelegate_AchievementProgress)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_AchievementProgress.EndInvoke(ar));
			}
			catch (Exception e)
			{
				AchievementProgress_ReturnType returnData = new AchievementProgress_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021AA RID: 8618 RVA: 0x0001E0DB File Offset: 0x0001C2DB
		public void set_GetQuestData_UserCallBack(RemoteServices.GetQuestData_UserCallBack callback)
		{
			this.getQuestData_UserCallBack = callback;
		}

		// Token: 0x060021AB RID: 8619 RVA: 0x001E88D4 File Offset: 0x001E6AD4
		public void GetQuestData(bool full)
		{
			if (this.GetQuestData_Callback == null)
			{
				this.GetQuestData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetQuestData);
			}
			RemoteServices.RemoteAsyncDelegate_GetQuestData remoteAsyncDelegate_GetQuestData = new RemoteServices.RemoteAsyncDelegate_GetQuestData(this.service.GetQuestData);
			this.registerRPCcall(remoteAsyncDelegate_GetQuestData.BeginInvoke(this.UserID, this.SessionID, full, this.GetQuestData_Callback, null), typeof(GetQuestData_ReturnType));
		}

		// Token: 0x060021AC RID: 8620 RVA: 0x001E8938 File Offset: 0x001E6B38
		[OneWay]
		public void OurRemoteAsyncCallBack_GetQuestData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetQuestData remoteAsyncDelegate_GetQuestData = (RemoteServices.RemoteAsyncDelegate_GetQuestData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetQuestData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetQuestData_ReturnType returnData = new GetQuestData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021AD RID: 8621 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
		public void set_StartNewQuest_UserCallBack(RemoteServices.StartNewQuest_UserCallBack callback)
		{
			this.startNewQuest_UserCallBack = callback;
		}

		// Token: 0x060021AE RID: 8622 RVA: 0x001E8988 File Offset: 0x001E6B88
		public void StartNewQuest(int questID)
		{
			if (this.StartNewQuest_Callback == null)
			{
				this.StartNewQuest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_StartNewQuest);
			}
			RemoteServices.RemoteAsyncDelegate_StartNewQuest remoteAsyncDelegate_StartNewQuest = new RemoteServices.RemoteAsyncDelegate_StartNewQuest(this.service.StartNewQuest);
			this.registerRPCcall(remoteAsyncDelegate_StartNewQuest.BeginInvoke(this.UserID, this.SessionID, questID, this.StartNewQuest_Callback, null), typeof(StartNewQuest_ReturnType));
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x001E89EC File Offset: 0x001E6BEC
		[OneWay]
		public void OurRemoteAsyncCallBack_StartNewQuest(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_StartNewQuest remoteAsyncDelegate_StartNewQuest = (RemoteServices.RemoteAsyncDelegate_StartNewQuest)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_StartNewQuest.EndInvoke(ar));
			}
			catch (Exception e)
			{
				StartNewQuest_ReturnType returnData = new StartNewQuest_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x0001E0ED File Offset: 0x0001C2ED
		public void set_CompleteAbandonNewQuest_UserCallBack(RemoteServices.CompleteAbandonNewQuest_UserCallBack callback)
		{
			this.completeAbandonNewQuest_UserCallBack = callback;
		}

		// Token: 0x060021B1 RID: 8625 RVA: 0x001E8A3C File Offset: 0x001E6C3C
		public void CompleteNewQuest(int questID, bool glory, int villageID)
		{
			if (this.CompleteAbandonNewQuest_Callback == null)
			{
				this.CompleteAbandonNewQuest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CompleteAbandonNewQuest);
			}
			RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest remoteAsyncDelegate_CompleteAbandonNewQuest = new RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest(this.service.CompleteAbandonNewQuest);
			this.registerRPCcall(remoteAsyncDelegate_CompleteAbandonNewQuest.BeginInvoke(this.UserID, this.SessionID, questID, false, glory, villageID, this.CompleteAbandonNewQuest_Callback, null), typeof(CompleteAbandonNewQuest_ReturnType));
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001E8AA4 File Offset: 0x001E6CA4
		public void AbandonNewQuest(int questID)
		{
			if (this.CompleteAbandonNewQuest_Callback == null)
			{
				this.CompleteAbandonNewQuest_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_CompleteAbandonNewQuest);
			}
			RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest remoteAsyncDelegate_CompleteAbandonNewQuest = new RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest(this.service.CompleteAbandonNewQuest);
			this.registerRPCcall(remoteAsyncDelegate_CompleteAbandonNewQuest.BeginInvoke(this.UserID, this.SessionID, questID, true, false, -1, this.CompleteAbandonNewQuest_Callback, null), typeof(CompleteAbandonNewQuest_ReturnType));
		}

		// Token: 0x060021B3 RID: 8627 RVA: 0x001E8B0C File Offset: 0x001E6D0C
		[OneWay]
		public void OurRemoteAsyncCallBack_CompleteAbandonNewQuest(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest remoteAsyncDelegate_CompleteAbandonNewQuest = (RemoteServices.RemoteAsyncDelegate_CompleteAbandonNewQuest)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_CompleteAbandonNewQuest.EndInvoke(ar));
			}
			catch (Exception e)
			{
				CompleteAbandonNewQuest_ReturnType returnData = new CompleteAbandonNewQuest_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x0001E0F6 File Offset: 0x0001C2F6
		public void set_SpinTheWheel_UserCallBack(RemoteServices.SpinTheWheel_UserCallBack callback)
		{
			this.spinTheWheel_UserCallBack = callback;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001E8B5C File Offset: 0x001E6D5C
		public void SpinTheRoyalWheel(int villageID, int wheelType)
		{
			if (this.SpinTheWheel_Callback == null)
			{
				this.SpinTheWheel_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SpinTheWheel);
			}
			RemoteServices.RemoteAsyncDelegate_SpinTheWheel remoteAsyncDelegate_SpinTheWheel = new RemoteServices.RemoteAsyncDelegate_SpinTheWheel(this.service.SpinTheWheel);
			this.registerRPCcall(remoteAsyncDelegate_SpinTheWheel.BeginInvoke(this.UserID, this.SessionID, villageID, wheelType, this.SpinTheWheel_Callback, null), typeof(SpinTheWheel_ReturnType));
		}

		// Token: 0x060021B6 RID: 8630 RVA: 0x001E8BC4 File Offset: 0x001E6DC4
		[OneWay]
		public void OurRemoteAsyncCallBack_SpinTheWheel(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SpinTheWheel remoteAsyncDelegate_SpinTheWheel = (RemoteServices.RemoteAsyncDelegate_SpinTheWheel)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SpinTheWheel.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SpinTheWheel_ReturnType returnData = new SpinTheWheel_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021B7 RID: 8631 RVA: 0x0001E0FF File Offset: 0x0001C2FF
		public void set_SetVacationMode_UserCallBack(RemoteServices.SetVacationMode_UserCallBack callback)
		{
			this.setVacationMode_UserCallBack = callback;
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x001E8C14 File Offset: 0x001E6E14
		public void SetVacationMode(int numDays)
		{
			if (this.SetVacationMode_Callback == null)
			{
				this.SetVacationMode_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_SetVacationMode);
			}
			RemoteServices.RemoteAsyncDelegate_SetVacationMode remoteAsyncDelegate_SetVacationMode = new RemoteServices.RemoteAsyncDelegate_SetVacationMode(this.service.SetVacationMode);
			this.registerRPCcall(remoteAsyncDelegate_SetVacationMode.BeginInvoke(this.UserID, this.SessionID, numDays, this.SetVacationMode_Callback, null), typeof(SetVacationMode_ReturnType));
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001E8C78 File Offset: 0x001E6E78
		[OneWay]
		public void OurRemoteAsyncCallBack_SetVacationMode(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_SetVacationMode remoteAsyncDelegate_SetVacationMode = (RemoteServices.RemoteAsyncDelegate_SetVacationMode)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_SetVacationMode.EndInvoke(ar));
			}
			catch (Exception e)
			{
				SetVacationMode_ReturnType returnData = new SetVacationMode_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021BA RID: 8634 RVA: 0x0001E108 File Offset: 0x0001C308
		public void set_PremiumOverview_UserCallBack(RemoteServices.PremiumOverview_UserCallBack callback)
		{
			this.premiumOverview_UserCallBack = callback;
		}

		// Token: 0x060021BB RID: 8635 RVA: 0x001E8CC8 File Offset: 0x001E6EC8
		public void PremiumOverview()
		{
			if (this.PremiumOverview_Callback == null)
			{
				this.PremiumOverview_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_PremiumOverview);
			}
			RemoteServices.RemoteAsyncDelegate_PremiumOverview remoteAsyncDelegate_PremiumOverview = new RemoteServices.RemoteAsyncDelegate_PremiumOverview(this.service.PremiumOverview);
			this.registerRPCcall(remoteAsyncDelegate_PremiumOverview.BeginInvoke(this.UserID, this.SessionID, this.PremiumOverview_Callback, null), typeof(PremiumOverview_ReturnType));
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x001E8D2C File Offset: 0x001E6F2C
		[OneWay]
		public void OurRemoteAsyncCallBack_PremiumOverview(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_PremiumOverview remoteAsyncDelegate_PremiumOverview = (RemoteServices.RemoteAsyncDelegate_PremiumOverview)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_PremiumOverview.EndInvoke(ar));
			}
			catch (Exception e)
			{
				PremiumOverview_ReturnType returnData = new PremiumOverview_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x0001E111 File Offset: 0x0001C311
		public void set_GetLastAttacker_UserCallBack(RemoteServices.GetLastAttacker_UserCallBack callback)
		{
			this.getLastAttacker_UserCallBack = callback;
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x001E8D7C File Offset: 0x001E6F7C
		public void GetLastAttacker()
		{
			if (this.GetLastAttacker_Callback == null)
			{
				this.GetLastAttacker_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetLastAttacker);
			}
			RemoteServices.RemoteAsyncDelegate_GetLastAttacker remoteAsyncDelegate_GetLastAttacker = new RemoteServices.RemoteAsyncDelegate_GetLastAttacker(this.service.GetLastAttacker);
			this.registerRPCcall(remoteAsyncDelegate_GetLastAttacker.BeginInvoke(this.UserID, this.SessionID, this.GetLastAttacker_Callback, null), typeof(GetLastAttacker_ReturnType));
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001E8DE0 File Offset: 0x001E6FE0
		[OneWay]
		public void OurRemoteAsyncCallBack_GetLastAttacker(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetLastAttacker remoteAsyncDelegate_GetLastAttacker = (RemoteServices.RemoteAsyncDelegate_GetLastAttacker)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetLastAttacker.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetLastAttacker_ReturnType returnData = new GetLastAttacker_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x0001E11A File Offset: 0x0001C31A
		public void set_PreValidateCardToBePlayed_UserCallBack(RemoteServices.PreValidateCardToBePlayed_UserCallBack callback)
		{
			this.preValidateCardToBePlayed_UserCallBack = callback;
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x001E8E30 File Offset: 0x001E7030
		public void PreValidateCardToBePlayed(int card, int data)
		{
			if (this.PreValidateCardToBePlayed_Callback == null)
			{
				this.PreValidateCardToBePlayed_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_PreValidateCardToBePlayed);
			}
			RemoteServices.RemoteAsyncDelegate_PreValidateCardToBePlayed remoteAsyncDelegate_PreValidateCardToBePlayed = new RemoteServices.RemoteAsyncDelegate_PreValidateCardToBePlayed(this.service.PreValidateCardToBePlayed);
			this.registerRPCcall(remoteAsyncDelegate_PreValidateCardToBePlayed.BeginInvoke(this.UserID, this.SessionID, card, data, this.PreValidateCardToBePlayed_Callback, null), typeof(PreValidateCardToBePlayed_ReturnType));
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x001E8E98 File Offset: 0x001E7098
		[OneWay]
		public void OurRemoteAsyncCallBack_PreValidateCardToBePlayed(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_PreValidateCardToBePlayed remoteAsyncDelegate_PreValidateCardToBePlayed = (RemoteServices.RemoteAsyncDelegate_PreValidateCardToBePlayed)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_PreValidateCardToBePlayed.EndInvoke(ar));
			}
			catch (Exception e)
			{
				PreValidateCardToBePlayed_ReturnType returnData = new PreValidateCardToBePlayed_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x0001E123 File Offset: 0x0001C323
		public void set_GetInvasionInfo_UserCallBack(RemoteServices.GetInvasionInfo_UserCallBack callback)
		{
			this.getInvasionInfo_UserCallBack = callback;
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x001E8EE8 File Offset: 0x001E70E8
		public void GetInvasionInfo()
		{
			if (this.GetInvasionInfo_Callback == null)
			{
				this.GetInvasionInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetInvasionInfo);
			}
			RemoteServices.RemoteAsyncDelegate_GetInvasionInfo remoteAsyncDelegate_GetInvasionInfo = new RemoteServices.RemoteAsyncDelegate_GetInvasionInfo(this.service.GetInvasionInfo);
			this.registerRPCcall(remoteAsyncDelegate_GetInvasionInfo.BeginInvoke(this.UserID, this.SessionID, this.GetInvasionInfo_Callback, null), typeof(GetInvasionInfo_ReturnType));
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x001E8F4C File Offset: 0x001E714C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetInvasionInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetInvasionInfo remoteAsyncDelegate_GetInvasionInfo = (RemoteServices.RemoteAsyncDelegate_GetInvasionInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetInvasionInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetInvasionInfo_ReturnType returnData = new GetInvasionInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x0001E12C File Offset: 0x0001C32C
		public void set_WorldInfo_UserCallBack(RemoteServices.WorldInfo_UserCallBack callback)
		{
			this.worldInfo_UserCallBack = callback;
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x001E8F9C File Offset: 0x001E719C
		public void WorldInfo()
		{
			if (this.WorldInfo_Callback == null)
			{
				this.WorldInfo_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_WorldInfo);
			}
			RemoteServices.RemoteAsyncDelegate_WorldInfo remoteAsyncDelegate_WorldInfo = new RemoteServices.RemoteAsyncDelegate_WorldInfo(this.service.WorldInfo);
			this.registerRPCcall(remoteAsyncDelegate_WorldInfo.BeginInvoke(this.WorldInfo_Callback, null), typeof(WorldInfo_ReturnType));
		}

		// Token: 0x060021C8 RID: 8648 RVA: 0x001E8FF4 File Offset: 0x001E71F4
		[OneWay]
		public void OurRemoteAsyncCallBack_WorldInfo(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_WorldInfo remoteAsyncDelegate_WorldInfo = (RemoteServices.RemoteAsyncDelegate_WorldInfo)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_WorldInfo.EndInvoke(ar));
			}
			catch (Exception e)
			{
				WorldInfo_ReturnType returnData = new WorldInfo_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x0001E135 File Offset: 0x0001C335
		public void set_EndWorld_UserCallBack(RemoteServices.EndWorld_UserCallBack callback)
		{
			this.endWorld_UserCallBack = callback;
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001E9044 File Offset: 0x001E7244
		public void EndWorld()
		{
			if (this.EndWorld_Callback == null)
			{
				this.EndWorld_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_EndWorld);
			}
			RemoteServices.RemoteAsyncDelegate_EndWorld remoteAsyncDelegate_EndWorld = new RemoteServices.RemoteAsyncDelegate_EndWorld(this.service.EndWorld);
			this.registerRPCcall(remoteAsyncDelegate_EndWorld.BeginInvoke(this.UserID, this.SessionID, this.EndWorld_Callback, null), typeof(EndWorld_ReturnType));
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001E90A8 File Offset: 0x001E72A8
		[OneWay]
		public void OurRemoteAsyncCallBack_EndWorld(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_EndWorld remoteAsyncDelegate_EndWorld = (RemoteServices.RemoteAsyncDelegate_EndWorld)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_EndWorld.EndInvoke(ar));
			}
			catch (Exception e)
			{
				EndWorld_ReturnType returnData = new EndWorld_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x0001E13E File Offset: 0x0001C33E
		public void set_EndOfTheWorldStats_UserCallBack(RemoteServices.EndOfTheWorldStats_UserCallBack callback)
		{
			this.endOfTheWorldStats_UserCallBack = callback;
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001E90F8 File Offset: 0x001E72F8
		public void EndOfTheWorldStats()
		{
			if (this.EndOfTheWorldStats_Callback == null)
			{
				this.EndOfTheWorldStats_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_EndOfTheWorldStats);
			}
			RemoteServices.RemoteAsyncDelegate_EndOfTheWorldStats remoteAsyncDelegate_EndOfTheWorldStats = new RemoteServices.RemoteAsyncDelegate_EndOfTheWorldStats(this.service.EndOfTheWorldStats);
			this.registerRPCcall(remoteAsyncDelegate_EndOfTheWorldStats.BeginInvoke(this.UserID, this.SessionID, this.EndOfTheWorldStats_Callback, null), typeof(EndOfTheWorldStats_ReturnType));
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x001E915C File Offset: 0x001E735C
		[OneWay]
		public void OurRemoteAsyncCallBack_EndOfTheWorldStats(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_EndOfTheWorldStats remoteAsyncDelegate_EndOfTheWorldStats = (RemoteServices.RemoteAsyncDelegate_EndOfTheWorldStats)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_EndOfTheWorldStats.EndInvoke(ar));
			}
			catch (Exception e)
			{
				EndOfTheWorldStats_ReturnType returnData = new EndOfTheWorldStats_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x0001E147 File Offset: 0x0001C347
		public void set_GetKillStreakData_UserCallBack(RemoteServices.GetKillStreakData_UserCallBack callback)
		{
			this.getKillStreakData_UserCallBack = callback;
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x001E91AC File Offset: 0x001E73AC
		public void GetKillStreakData()
		{
			if (this.GetKillStreakData_Callback == null)
			{
				this.GetKillStreakData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetKillStreakData);
			}
			RemoteServices.RemoteAsyncDelegate_GetKillStreakData remoteAsyncDelegate_GetKillStreakData = new RemoteServices.RemoteAsyncDelegate_GetKillStreakData(this.service.GetKillStreakData);
			this.registerRPCcall(remoteAsyncDelegate_GetKillStreakData.BeginInvoke(this.UserID, this.SessionID, this.GetKillStreakData_Callback, null), typeof(GetKillStreakData_ReturnType));
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001E9210 File Offset: 0x001E7410
		[OneWay]
		public void OurRemoteAsyncCallBack_GetKillStreakData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetKillStreakData remoteAsyncDelegate_GetKillStreakData = (RemoteServices.RemoteAsyncDelegate_GetKillStreakData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetKillStreakData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetKillStreakData_ReturnType returnData = new GetKillStreakData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x0001E150 File Offset: 0x0001C350
		public void set_GetUserContestData_UserCallBack(RemoteServices.GetUserContestData_UserCallBack callback)
		{
			this.getUserContestData_UserCallBack = callback;
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x001E9260 File Offset: 0x001E7460
		public void GetUserContestData(int contestID)
		{
			if (this.GetUserContestData_Callback == null)
			{
				this.GetUserContestData_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetUserContestData);
			}
			RemoteServices.RemoteAsyncDelegate_GetUserContestData remoteAsyncDelegate_GetUserContestData = new RemoteServices.RemoteAsyncDelegate_GetUserContestData(this.service.GetUserContestData);
			this.registerRPCcall(remoteAsyncDelegate_GetUserContestData.BeginInvoke(this.UserID, this.SessionID, contestID, this.GetUserContestData_Callback, null), typeof(GetUserContestData_ReturnType));
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x001E92C4 File Offset: 0x001E74C4
		[OneWay]
		public void OurRemoteAsyncCallBack_GetUserContestData(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetUserContestData remoteAsyncDelegate_GetUserContestData = (RemoteServices.RemoteAsyncDelegate_GetUserContestData)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetUserContestData.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetUserContestData_ReturnType returnData = new GetUserContestData_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x0001E159 File Offset: 0x0001C359
		public void set_GetContestDataRange_UserCallBack(RemoteServices.GetContestDataRange_UserCallBack callback)
		{
			this.getContestDataRange_UserCallBack = callback;
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x001E9314 File Offset: 0x001E7514
		public void GetContestDataRange(int contestID, int topIndex, int numEntries, int rankBand)
		{
			if (this.GetContestDataRange_Callback == null)
			{
				this.GetContestDataRange_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetContestDataRange);
			}
			RemoteServices.RemoteAsyncDelegate_GetContestDataRange remoteAsyncDelegate_GetContestDataRange = new RemoteServices.RemoteAsyncDelegate_GetContestDataRange(this.service.GetContestDataRange);
			this.registerRPCcall(remoteAsyncDelegate_GetContestDataRange.BeginInvoke(this.UserID, this.SessionID, contestID, topIndex, numEntries, rankBand, this.GetContestDataRange_Callback, null), typeof(GetContestDataRange_ReturnType));
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x001E937C File Offset: 0x001E757C
		[OneWay]
		public void OurRemoteAsyncCallBack_GetContestDataRange(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetContestDataRange remoteAsyncDelegate_GetContestDataRange = (RemoteServices.RemoteAsyncDelegate_GetContestDataRange)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetContestDataRange.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetContestDataRange_ReturnType returnData = new GetContestDataRange_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x0001E162 File Offset: 0x0001C362
		public void set_GetContestHistoryIDs_UserCallBack(RemoteServices.GetContestHistoryIDs_UserCallBack callback)
		{
			this.getContestHistoryIDs_UserCallBack = callback;
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001E93CC File Offset: 0x001E75CC
		public void GetContestHistoryIDs()
		{
			if (this.GetContestHistoryIDs_Callback == null)
			{
				this.GetContestHistoryIDs_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_GetContestHistoryIDs);
			}
			RemoteServices.RemoteAsyncDelegate_GetContestHistoryIDs remoteAsyncDelegate_GetContestHistoryIDs = new RemoteServices.RemoteAsyncDelegate_GetContestHistoryIDs(this.service.GetContestHistoryIDs);
			this.registerRPCcall(remoteAsyncDelegate_GetContestHistoryIDs.BeginInvoke(this.UserID, this.SessionID, this.GetContestHistoryIDs_Callback, null), typeof(GetContestHistoryIDs_ReturnType));
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x001E9430 File Offset: 0x001E7630
		[OneWay]
		public void OurRemoteAsyncCallBack_GetContestHistoryIDs(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_GetContestHistoryIDs remoteAsyncDelegate_GetContestHistoryIDs = (RemoteServices.RemoteAsyncDelegate_GetContestHistoryIDs)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_GetContestHistoryIDs.EndInvoke(ar));
			}
			catch (Exception e)
			{
				GetContestHistoryIDs_ReturnType returnData = new GetContestHistoryIDs_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x0001E16B File Offset: 0x0001C36B
		public void set_Chat_Login_UserCallBack(RemoteServices.Chat_Login_UserCallBack callback)
		{
			this.chat_Login_UserCallBack = callback;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001E9480 File Offset: 0x001E7680
		public void Chat_Login()
		{
			if (this.ChatActive)
			{
				if (this.Chat_Login_Callback == null)
				{
					this.Chat_Login_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_Login);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_Login remoteAsyncDelegate_Chat_Login = new RemoteServices.RemoteAsyncDelegate_Chat_Login(this.service.Chat_Login);
				this.registerRPCcall(remoteAsyncDelegate_Chat_Login.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, this.Chat_Login_Callback, null), typeof(Chat_Login_ReturnType));
			}
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001E94F4 File Offset: 0x001E76F4
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_Login(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_Login remoteAsyncDelegate_Chat_Login = (RemoteServices.RemoteAsyncDelegate_Chat_Login)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_Login.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_Login_ReturnType returnData = new Chat_Login_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x0001E174 File Offset: 0x0001C374
		public void set_Chat_Logout_UserCallBack(RemoteServices.Chat_Logout_UserCallBack callback)
		{
			this.chat_Logout_UserCallBack = callback;
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x001E9544 File Offset: 0x001E7744
		public void Chat_Logout()
		{
			if (this.ChatActive && this.SessionID != 0)
			{
				if (this.Chat_Logout_Callback == null)
				{
					this.Chat_Logout_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_Logout);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_Logout remoteAsyncDelegate_Chat_Logout = new RemoteServices.RemoteAsyncDelegate_Chat_Logout(this.service.Chat_Logout);
				this.registerRPCcall(remoteAsyncDelegate_Chat_Logout.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, this.Chat_Logout_Callback, null), typeof(Chat_Logout_ReturnType));
			}
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001E95C0 File Offset: 0x001E77C0
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_Logout(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_Logout remoteAsyncDelegate_Chat_Logout = (RemoteServices.RemoteAsyncDelegate_Chat_Logout)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_Logout.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_Logout_ReturnType returnData = new Chat_Logout_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x0001E17D File Offset: 0x0001C37D
		public void set_Chat_SetReceivingState_UserCallBack(RemoteServices.Chat_SetReceivingState_UserCallBack callback)
		{
			this.chat_SetReceivingState_UserCallBack = callback;
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001E9610 File Offset: 0x001E7810
		public void Chat_StartReceiving()
		{
			if (this.ChatActive)
			{
				if (this.Chat_SetReceivingState_Callback == null)
				{
					this.Chat_SetReceivingState_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_SetReceivingState);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState remoteAsyncDelegate_Chat_SetReceivingState = new RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState(this.service.Chat_SetReceivingState);
				this.registerRPCcall(remoteAsyncDelegate_Chat_SetReceivingState.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, true, this.Chat_SetReceivingState_Callback, null), typeof(Chat_SetReceivingState_ReturnType));
			}
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001E9684 File Offset: 0x001E7884
		public void Chat_StopReceiving()
		{
			if (this.ChatActive)
			{
				if (this.Chat_SetReceivingState_Callback == null)
				{
					this.Chat_SetReceivingState_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_SetReceivingState);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState remoteAsyncDelegate_Chat_SetReceivingState = new RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState(this.service.Chat_SetReceivingState);
				this.registerRPCcall(remoteAsyncDelegate_Chat_SetReceivingState.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, false, this.Chat_SetReceivingState_Callback, null), typeof(Chat_SetReceivingState_ReturnType));
			}
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x001E96F8 File Offset: 0x001E78F8
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_SetReceivingState(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState remoteAsyncDelegate_Chat_SetReceivingState = (RemoteServices.RemoteAsyncDelegate_Chat_SetReceivingState)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_SetReceivingState.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_SetReceivingState_ReturnType returnData = new Chat_SetReceivingState_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x0001E186 File Offset: 0x0001C386
		public void set_Chat_SendText_UserCallBack(RemoteServices.Chat_SendText_UserCallBack callback)
		{
			this.chat_SendText_UserCallBack = callback;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001E9748 File Offset: 0x001E7948
		public void Chat_SendText(string text, int roomType, int roomID)
		{
			if (this.ChatActive)
			{
				if (this.Chat_SendText_Callback == null)
				{
					this.Chat_SendText_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_SendText);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_SendText remoteAsyncDelegate_Chat_SendText = new RemoteServices.RemoteAsyncDelegate_Chat_SendText(this.service.Chat_SendText);
				this.registerRPCcall(remoteAsyncDelegate_Chat_SendText.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, roomType, roomID, text, RemoteServices.Instance.UserOptions.profanityFilter, this.Chat_SendText_Callback, null), typeof(Chat_SendText_ReturnType));
			}
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001E97D0 File Offset: 0x001E79D0
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_SendText(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_SendText remoteAsyncDelegate_Chat_SendText = (RemoteServices.RemoteAsyncDelegate_Chat_SendText)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_SendText.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_SendText_ReturnType returnData = new Chat_SendText_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x0001E18F File Offset: 0x0001C38F
		public void set_Chat_ReceiveText_UserCallBack(RemoteServices.Chat_ReceiveText_UserCallBack callback)
		{
			this.chat_ReceiveText_UserCallBack = callback;
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001E9820 File Offset: 0x001E7A20
		public void Chat_GetText(List<Chat_RoomID> roomsToRegister, bool changeRooms)
		{
			if (this.ChatActive)
			{
				if (this.Chat_ReceiveText_Callback == null)
				{
					this.Chat_ReceiveText_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_ReceiveText);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_ReceiveText remoteAsyncDelegate_Chat_ReceiveText = new RemoteServices.RemoteAsyncDelegate_Chat_ReceiveText(this.service.Chat_ReceiveText);
				this.registerRPCcall(remoteAsyncDelegate_Chat_ReceiveText.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, roomsToRegister, changeRooms, RemoteServices.Instance.UserOptions.profanityFilter, this.Chat_ReceiveText_Callback, null), typeof(Chat_ReceiveText_ReturnType));
			}
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001E98A4 File Offset: 0x001E7AA4
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_ReceiveText(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_ReceiveText remoteAsyncDelegate_Chat_ReceiveText = (RemoteServices.RemoteAsyncDelegate_Chat_ReceiveText)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_ReceiveText.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_ReceiveText_ReturnType returnData = new Chat_ReceiveText_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x0001E198 File Offset: 0x0001C398
		public void set_Chat_SendParishText_UserCallBack(RemoteServices.Chat_SendParishText_UserCallBack callback)
		{
			this.chat_SendParishText_UserCallBack = callback;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001E98F4 File Offset: 0x001E7AF4
		public void Chat_SendParishText(string text, int parishID, int subForumID, DateTime lastTime)
		{
			if (this.ChatActive)
			{
				if (this.Chat_SendParishText_Callback == null)
				{
					this.Chat_SendParishText_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_SendParishText);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_SendParishText remoteAsyncDelegate_Chat_SendParishText = new RemoteServices.RemoteAsyncDelegate_Chat_SendParishText(this.service.Chat_SendParishText);
				this.registerRPCcall(remoteAsyncDelegate_Chat_SendParishText.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, parishID, subForumID, text, lastTime, RemoteServices.Instance.UserOptions.profanityFilter, this.Chat_SendParishText_Callback, null), typeof(Chat_SendParishText_ReturnType));
			}
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001E997C File Offset: 0x001E7B7C
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_SendParishText(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_SendParishText remoteAsyncDelegate_Chat_SendParishText = (RemoteServices.RemoteAsyncDelegate_Chat_SendParishText)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_SendParishText.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_SendParishText_ReturnType returnData = new Chat_SendParishText_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x0001E1A1 File Offset: 0x0001C3A1
		public void set_Chat_ReceiveParishText_UserCallBack(RemoteServices.Chat_ReceiveParishText_UserCallBack callback)
		{
			this.chat_ReceiveParishText_UserCallBack = callback;
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001E99CC File Offset: 0x001E7BCC
		public void Chat_ReceiveParishText(int parishID, DateTime lastTime)
		{
			if (this.ChatActive)
			{
				if (this.Chat_ReceiveParishText_Callback == null)
				{
					this.Chat_ReceiveParishText_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_ReceiveParishText);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_ReceiveParishText remoteAsyncDelegate_Chat_ReceiveParishText = new RemoteServices.RemoteAsyncDelegate_Chat_ReceiveParishText(this.service.Chat_ReceiveParishText);
				this.registerRPCcall(remoteAsyncDelegate_Chat_ReceiveParishText.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, parishID, lastTime, RemoteServices.Instance.UserOptions.profanityFilter, this.Chat_ReceiveParishText_Callback, null), typeof(Chat_ReceiveParishText_ReturnType));
			}
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001E9A50 File Offset: 0x001E7C50
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_ReceiveParishText(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_ReceiveParishText remoteAsyncDelegate_Chat_ReceiveParishText = (RemoteServices.RemoteAsyncDelegate_Chat_ReceiveParishText)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_ReceiveParishText.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_ReceiveParishText_ReturnType returnData = new Chat_ReceiveParishText_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x0001E1AA File Offset: 0x0001C3AA
		public void set_Chat_BackFillParishText_UserCallBack(RemoteServices.Chat_BackFillParishText_UserCallBack callback)
		{
			this.chat_BackFillParishText_UserCallBack = callback;
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001E9AA0 File Offset: 0x001E7CA0
		public void Chat_BackFillParishText(int parishID, int pageID, long oldestKnownID, DateTime lastTime)
		{
			if (this.ChatActive)
			{
				if (this.Chat_BackFillParishText_Callback == null)
				{
					this.Chat_BackFillParishText_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_BackFillParishText);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_BackFillParishText remoteAsyncDelegate_Chat_BackFillParishText = new RemoteServices.RemoteAsyncDelegate_Chat_BackFillParishText(this.service.Chat_BackFillParishText);
				this.registerRPCcall(remoteAsyncDelegate_Chat_BackFillParishText.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, parishID, pageID, oldestKnownID, lastTime, RemoteServices.Instance.UserOptions.profanityFilter, this.Chat_BackFillParishText_Callback, null), typeof(Chat_BackFillParishText_ReturnType));
			}
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001E9B28 File Offset: 0x001E7D28
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_BackFillParishText(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_BackFillParishText remoteAsyncDelegate_Chat_BackFillParishText = (RemoteServices.RemoteAsyncDelegate_Chat_BackFillParishText)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_BackFillParishText.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_BackFillParishText_ReturnType returnData = new Chat_BackFillParishText_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x0001E1B3 File Offset: 0x0001C3B3
		public void set_Chat_MarkParishTextRead_UserCallBack(RemoteServices.Chat_MarkParishTextRead_UserCallBack callback)
		{
			this.chat_MarkParishTextRead_UserCallBack = callback;
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001E9B78 File Offset: 0x001E7D78
		public void Chat_MarkParishTextRead(int parishID, int pageID, long readID)
		{
			if (this.ChatActive)
			{
				if (this.Chat_MarkParishTextRead_Callback == null)
				{
					this.Chat_MarkParishTextRead_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_MarkParishTextRead);
				}
				RemoteServices.RemoteAsyncDelegate_Chat_MarkParishTextRead remoteAsyncDelegate_Chat_MarkParishTextRead = new RemoteServices.RemoteAsyncDelegate_Chat_MarkParishTextRead(this.service.Chat_MarkParishTextRead);
				this.registerRPCcall(remoteAsyncDelegate_Chat_MarkParishTextRead.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, parishID, pageID, readID, this.Chat_MarkParishTextRead_Callback, null), typeof(Chat_MarkParishTextRead_ReturnType));
			}
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001E9BF0 File Offset: 0x001E7DF0
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_MarkParishTextRead(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_MarkParishTextRead remoteAsyncDelegate_Chat_MarkParishTextRead = (RemoteServices.RemoteAsyncDelegate_Chat_MarkParishTextRead)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_MarkParishTextRead.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_MarkParishTextRead_ReturnType returnData = new Chat_MarkParishTextRead_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x0001E1BC File Offset: 0x0001C3BC
		public void set_Chat_Admin_Command_UserCallBack(RemoteServices.Chat_Admin_Command_UserCallBack callback)
		{
			this.chat_Admin_Command_UserCallBack = callback;
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001E9C40 File Offset: 0x001E7E40
		public void Chat_Admin_Command(int command, int targetUserID)
		{
			if (this.Chat_Admin_Command_Callback == null)
			{
				this.Chat_Admin_Command_Callback = new AsyncCallback(this.OurRemoteAsyncCallBack_Chat_Admin_Command);
			}
			RemoteServices.RemoteAsyncDelegate_Chat_Admin_Command remoteAsyncDelegate_Chat_Admin_Command = new RemoteServices.RemoteAsyncDelegate_Chat_Admin_Command(this.service.Chat_Admin_Command);
			this.registerRPCcall(remoteAsyncDelegate_Chat_Admin_Command.BeginInvoke(RemoteServices.Instance.UserID, RemoteServices.Instance.SessionID, command, targetUserID, this.Chat_Admin_Command_Callback, null), typeof(Chat_Admin_Command_ReturnType));
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001E9CB0 File Offset: 0x001E7EB0
		[OneWay]
		public void OurRemoteAsyncCallBack_Chat_Admin_Command(IAsyncResult ar)
		{
			RemoteServices.RemoteAsyncDelegate_Chat_Admin_Command remoteAsyncDelegate_Chat_Admin_Command = (RemoteServices.RemoteAsyncDelegate_Chat_Admin_Command)((AsyncResult)ar).AsyncDelegate;
			try
			{
				this.storeRPCresult(ar, remoteAsyncDelegate_Chat_Admin_Command.EndInvoke(ar));
			}
			catch (Exception e)
			{
				Chat_Admin_Command_ReturnType returnData = new Chat_Admin_Command_ReturnType();
				this.manageRemoteExpection(ar, returnData, e);
			}
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x0001E1C5 File Offset: 0x0001C3C5
		public void set_CommonData_UserCallBack(RemoteServices.CommonData_UserCallBack callback)
		{
			this.commonData_UserCallBack = callback;
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001E9D00 File Offset: 0x001E7F00
		public void processData()
		{
			if (this.connectionErrored)
			{
				bool flag = true;
				foreach (RemoteServices.CallBackEntryClass callBackEntryClass in this.resultList)
				{
					if (callBackEntryClass.state == 1 && callBackEntryClass.classType != typeof(FullTick_ReturnType) && callBackEntryClass.classType != typeof(GetArmyData_ReturnType))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					GameEngine.Instance.sessionExpired(11);
				}
				else
				{
					GameEngine.Instance.sessionExpired(1);
				}
				this.connectionErrored = false;
			}
			this.inResultsProcessing = true;
			bool flag2 = false;
			try
			{
				foreach (RemoteServices.CallBackEntryClass callBackEntryClass2 in this.resultList)
				{
					if (callBackEntryClass2.state == 1)
					{
						double num = DXTimer.GetCurrentMilliseconds() - callBackEntryClass2.timer;
						if (num > 30000.0)
						{
							if (callBackEntryClass2.classType == typeof(CreateNewUser_ReturnType))
							{
								callBackEntryClass2.state = 0;
								callBackEntryClass2.data = null;
								if (this.createNewUser_UserCallBack != null)
								{
									CreateNewUser_ReturnType createNewUser_ReturnType = new CreateNewUser_ReturnType();
									createNewUser_ReturnType.SetAsFailed();
									createNewUser_ReturnType.m_errorCode = ErrorCodes.ErrorCode.CONNECTION_TIMED_OUT;
									this.createNewUser_UserCallBack(createNewUser_ReturnType);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LoginUser_ReturnType))
							{
								callBackEntryClass2.state = 0;
								callBackEntryClass2.data = null;
								if (this.loginUser_UserCallBack != null)
								{
									LoginUser_ReturnType loginUser_ReturnType = new LoginUser_ReturnType();
									loginUser_ReturnType.SetAsFailed();
									loginUser_ReturnType.m_errorCode = ErrorCodes.ErrorCode.CONNECTION_TIMED_OUT;
									this.loginUser_UserCallBack(loginUser_ReturnType);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LoginUserGuid_ReturnType))
							{
								callBackEntryClass2.state = 0;
								callBackEntryClass2.data = null;
								if (this.loginUserGuid_UserCallBack != null)
								{
									LoginUserGuid_ReturnType loginUserGuid_ReturnType = new LoginUserGuid_ReturnType();
									loginUserGuid_ReturnType.SetAsFailed();
									loginUserGuid_ReturnType.m_errorCode = ErrorCodes.ErrorCode.CONNECTION_TIMED_OUT;
									this.loginUserGuid_UserCallBack(loginUserGuid_ReturnType);
								}
							}
						}
						if (this.packetTimeOut(num, callBackEntryClass2) && callBackEntryClass2.classType != typeof(RetrieveStats_ReturnType) && callBackEntryClass2.classType != typeof(RetrieveStats2_ReturnType) && !InterfaceMgr.Instance.isConnectionErrorWindow())
						{
							int num2 = this.RTTTimeOuts;
							this.RTTTimeOuts = num2 + 1;
							callBackEntryClass2.state = 0;
							callBackEntryClass2.data = null;
							this.addPacket(callBackEntryClass2.classType, -1);
							num2 = this.consecutiveTimeOuts;
							this.consecutiveTimeOuts = num2 + 1;
							if (this.consecutiveTimeOuts >= 10)
							{
								if (this.sessionID != 0)
								{
									this.sessionID = 0;
									GameEngine.Instance.sessionExpired(2);
									flag2 = true;
									break;
								}
								break;
							}
						}
					}
					if (callBackEntryClass2.state == 2)
					{
						callBackEntryClass2.state = 0;
						this.consecutiveTimeOuts = 0;
						if (!callBackEntryClass2.data.Success && callBackEntryClass2.data.m_errorCode == ErrorCodes.ErrorCode.CONNECTION_SESSION_ENDED)
						{
							if (this.sessionID != 0)
							{
								this.sessionID = 0;
								GameEngine.Instance.sessionExpired(0);
								flag2 = true;
							}
							callBackEntryClass2.data = null;
							break;
						}
						if (callBackEntryClass2.classType != typeof(CreateNewUser_ReturnType) && callBackEntryClass2.classType != typeof(LoginUser_ReturnType) && callBackEntryClass2.classType != typeof(LogOut_ReturnType) && callBackEntryClass2.classType != typeof(LoginUserGuid_ReturnType) && !callBackEntryClass2.data.Success && callBackEntryClass2.data.m_errorCode == ErrorCodes.ErrorCode.CONNECTION_NO_SERVER)
						{
							callBackEntryClass2.data = null;
							break;
						}
						if (InterfaceMgr.Instance.isConnectionErrorWindow())
						{
							InterfaceMgr.Instance.closeConnectionErrorWindow();
						}
						if (!callBackEntryClass2.data.Success && callBackEntryClass2.data.m_errorCode == ErrorCodes.ErrorCode.COMMUNICATION_BAN)
						{
							if (callBackEntryClass2.classType == typeof(SendMail_ReturnType) || callBackEntryClass2.classType == typeof(SendSpecialMail_ReturnType))
							{
								MyMessageBox.Show(SK.Text("ChatScreenManager_Ban_Message_mail", "Your mail posting privileges have been suspended for violations of the game rules or code of conduct.") + Environment.NewLine + URLs.IPSharingPage, SK.Text("GENERIC_Mail Banned", "Mail Posting Privileges Ban"));
							}
							else if (callBackEntryClass2.classType == typeof(NewForumThread_ReturnType) || callBackEntryClass2.classType == typeof(PostToForumThread_ReturnType))
							{
								MyMessageBox.Show(SK.Text("ChatScreenManager_Ban_Message_forum", "Your forum posting privileges have been suspended for violations of the game rules or code of conduct.") + Environment.NewLine + URLs.IPSharingPage, SK.Text("GENERIC_Forum Banned", "Forum Posting Privileges Ban"));
							}
							else
							{
								MyMessageBox.Show(SK.Text("ChatScreenManager_Ban_Message", "You have been banned from using this function, contact support if you wish to discuss this.") + Environment.NewLine + "https://support.strongholdkingdoms.com", SK.Text("GENERIC_Banned", "Banned"));
							}
							callBackEntryClass2.data = null;
						}
						else
						{
							if (this.commonData_UserCallBack != null && callBackEntryClass2.classType != typeof(WorldInfo_ReturnType))
							{
								Common_ReturnData data = callBackEntryClass2.data;
								if (data.Success)
								{
									this.commonData_UserCallBack(data);
								}
							}
							Common_ReturnData data2 = callBackEntryClass2.data;
							if (!data2.Success)
							{
								if (data2.m_errorCode == ErrorCodes.ErrorCode.ACTION_NOT_IMPLEMENTED)
								{
									MyMessageBox.Show("This Function is not Implement Yet.", "Error");
								}
								else
								{
									if (data2.m_errorCode == ErrorCodes.ErrorCode.LOCK_OUT)
									{
										GameEngine.Instance.World.WorldEnded = true;
										continue;
									}
									callBackEntryClass2.state = 0;
									ErrorCodes.ErrorCode errorCode = data2.m_errorCode;
									if (errorCode - ErrorCodes.ErrorCode.SHARED_TRADING <= 5)
									{
										string errorString = ErrorCodes.getErrorString(data2.m_errorCode);
										SharedIPErrorPopup.showSharedIPPopup(errorString);
										foreach (RemoteServices.CallBackEntryClass callBackEntryClass3 in this.resultList)
										{
											callBackEntryClass3.timer = DXTimer.GetCurrentMilliseconds();
										}
									}
								}
							}
							if (callBackEntryClass2.classType == typeof(CreateNewUser_ReturnType))
							{
								CreateNewUser_ReturnType returnData = (CreateNewUser_ReturnType)callBackEntryClass2.data;
								if (this.createNewUser_UserCallBack != null)
								{
									this.createNewUser_UserCallBack(returnData);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LoginUser_ReturnType))
							{
								LoginUser_ReturnType returnData2 = (LoginUser_ReturnType)callBackEntryClass2.data;
								if (this.loginUser_UserCallBack != null)
								{
									this.loginUser_UserCallBack(returnData2);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LoginUserGuid_ReturnType))
							{
								LoginUserGuid_ReturnType returnData3 = (LoginUserGuid_ReturnType)callBackEntryClass2.data;
								if (this.loginUserGuid_UserCallBack != null)
								{
									this.loginUserGuid_UserCallBack(returnData3);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ResendVerificationEmail_ReturnType))
							{
								ResendVerificationEmail_ReturnType returnData4 = (ResendVerificationEmail_ReturnType)callBackEntryClass2.data;
								if (this.resendVerificationEmail_UserCallBack != null)
								{
									this.resendVerificationEmail_UserCallBack(returnData4);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveVillageUserInfo_ReturnType))
							{
								RetrieveVillageUserInfo_ReturnType returnData5 = (RetrieveVillageUserInfo_ReturnType)callBackEntryClass2.data;
								if (this.retrieveVillageUserInfo_UserCallBack != null)
								{
									this.retrieveVillageUserInfo_UserCallBack(returnData5);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SpecialVillageInfo_ReturnType))
							{
								SpecialVillageInfo_ReturnType returnData6 = (SpecialVillageInfo_ReturnType)callBackEntryClass2.data;
								if (this.specialVillageInfo_UserCallBack != null)
								{
									this.specialVillageInfo_UserCallBack(returnData6);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetAllVillageOwnerFactions_ReturnType))
							{
								GetAllVillageOwnerFactions_ReturnType returnData7 = (GetAllVillageOwnerFactions_ReturnType)callBackEntryClass2.data;
								if (this.getAllVillageOwnerFactions_UserCallBack != null)
								{
									this.getAllVillageOwnerFactions_UserCallBack(returnData7);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageNames_ReturnType))
							{
								GetVillageNames_ReturnType returnData8 = (GetVillageNames_ReturnType)callBackEntryClass2.data;
								if (this.getVillageNames_UserCallBack != null)
								{
									this.getVillageNames_UserCallBack(returnData8);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageFactionChanges_ReturnType))
							{
								GetVillageFactionChanges_ReturnType returnData9 = (GetVillageFactionChanges_ReturnType)callBackEntryClass2.data;
								if (this.getVillageFactionChanges_UserCallBack != null)
								{
									this.getVillageFactionChanges_UserCallBack(returnData9);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetAreaFactionChanges_ReturnType))
							{
								GetAreaFactionChanges_ReturnType returnData10 = (GetAreaFactionChanges_ReturnType)callBackEntryClass2.data;
								if (this.getAreaFactionChanges_UserCallBack != null)
								{
									this.getAreaFactionChanges_UserCallBack(returnData10);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetUserVillages_ReturnType))
							{
								GetUserVillages_ReturnType returnData11 = (GetUserVillages_ReturnType)callBackEntryClass2.data;
								if (this.getUserVillages_UserCallBack != null)
								{
									this.getUserVillages_UserCallBack(returnData11);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetOtherUserVillageIDList_ReturnType))
							{
								GetOtherUserVillageIDList_ReturnType returnData12 = (GetOtherUserVillageIDList_ReturnType)callBackEntryClass2.data;
								if (this.getOtherUserVillageIDList_UserCallBack != null)
								{
									this.getOtherUserVillageIDList_UserCallBack(returnData12);
								}
							}
							else if (callBackEntryClass2.classType == typeof(BuyVillage_ReturnType))
							{
								BuyVillage_ReturnType returnData13 = (BuyVillage_ReturnType)callBackEntryClass2.data;
								if (this.buyVillage_UserCallBack != null)
								{
									this.buyVillage_UserCallBack(returnData13);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ConvertVillage_ReturnType))
							{
								ConvertVillage_ReturnType returnData14 = (ConvertVillage_ReturnType)callBackEntryClass2.data;
								if (this.convertVillage_UserCallBack != null)
								{
									this.convertVillage_UserCallBack(returnData14);
								}
							}
							else if (callBackEntryClass2.classType == typeof(FullTick_ReturnType))
							{
								FullTick_ReturnType returnData15 = (FullTick_ReturnType)callBackEntryClass2.data;
								if (this.fullTick_UserCallBack != null)
								{
									this.fullTick_UserCallBack(returnData15);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LeaderBoard_ReturnType))
							{
								LeaderBoard_ReturnType returnData16 = (LeaderBoard_ReturnType)callBackEntryClass2.data;
								if (this.leaderBoard_UserCallBack != null)
								{
									this.leaderBoard_UserCallBack(returnData16);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LeaderBoardSearch_ReturnType))
							{
								LeaderBoardSearch_ReturnType returnData17 = (LeaderBoardSearch_ReturnType)callBackEntryClass2.data;
								if (this.leaderBoardSearch_UserCallBack != null)
								{
									this.leaderBoardSearch_UserCallBack(returnData17);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LogOut_ReturnType))
							{
								LogOut_ReturnType returnData18 = (LogOut_ReturnType)callBackEntryClass2.data;
								if (this.logOut_UserCallBack != null)
								{
									this.logOut_UserCallBack(returnData18);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UserInfo_ReturnType))
							{
								UserInfo_ReturnType returnData19 = (UserInfo_ReturnType)callBackEntryClass2.data;
								if (this.userInfo_UserCallBack != null)
								{
									this.userInfo_UserCallBack(returnData19);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetArmyData_ReturnType))
							{
								GetArmyData_ReturnType returnData20 = (GetArmyData_ReturnType)callBackEntryClass2.data;
								if (this.getArmyData_UserCallBack != null)
								{
									this.getArmyData_UserCallBack(returnData20);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ArmyAttack_ReturnType))
							{
								ArmyAttack_ReturnType returnData21 = (ArmyAttack_ReturnType)callBackEntryClass2.data;
								if (this.armyAttack_UserCallBack != null)
								{
									this.armyAttack_UserCallBack(returnData21);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveAttackResult_ReturnType))
							{
								RetrieveAttackResult_ReturnType returnData22 = (RetrieveAttackResult_ReturnType)callBackEntryClass2.data;
								if (this.retrieveAttackResult_UserCallBack != null)
								{
									this.retrieveAttackResult_UserCallBack(returnData22);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SetAdminMessage_ReturnType))
							{
								SetAdminMessage_ReturnType returnData23 = (SetAdminMessage_ReturnType)callBackEntryClass2.data;
								if (this.setAdminMessage_UserCallBack != null)
								{
									this.setAdminMessage_UserCallBack(returnData23);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CompleteVillageCastle_ReturnType))
							{
								CompleteVillageCastle_ReturnType returnData24 = (CompleteVillageCastle_ReturnType)callBackEntryClass2.data;
								if (this.completeVillageCastle_UserCallBack != null)
								{
									this.completeVillageCastle_UserCallBack(returnData24);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveStats_ReturnType))
							{
								RetrieveStats_ReturnType returnData25 = (RetrieveStats_ReturnType)callBackEntryClass2.data;
								if (this.retrieveStats_UserCallBack != null)
								{
									this.retrieveStats_UserCallBack(returnData25);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveStats2_ReturnType))
							{
								RetrieveStats2_ReturnType returnData26 = (RetrieveStats2_ReturnType)callBackEntryClass2.data;
								if (this.retrieveStats2_UserCallBack != null)
								{
									this.retrieveStats2_UserCallBack(returnData26);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetAdminStats_ReturnType))
							{
								GetAdminStats_ReturnType returnData27 = (GetAdminStats_ReturnType)callBackEntryClass2.data;
								if (this.getAdminStats_UserCallBack != null)
								{
									this.getAdminStats_UserCallBack(returnData27);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetReportsList_ReturnType))
							{
								GetReportsList_ReturnType returnData28 = (GetReportsList_ReturnType)callBackEntryClass2.data;
								if (this.getReportsList_UserCallBack != null)
								{
									this.getReportsList_UserCallBack(returnData28);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetReport_ReturnType))
							{
								GetReport_ReturnType returnData29 = (GetReport_ReturnType)callBackEntryClass2.data;
								if (this.getReport_UserCallBack != null)
								{
									this.getReport_UserCallBack(returnData29);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ForwardReport_ReturnType))
							{
								ForwardReport_ReturnType returnData30 = (ForwardReport_ReturnType)callBackEntryClass2.data;
								if (this.forwardReport_UserCallBack != null)
								{
									this.forwardReport_UserCallBack(returnData30);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ViewBattle_ReturnType))
							{
								ViewBattle_ReturnType returnData31 = (ViewBattle_ReturnType)callBackEntryClass2.data;
								if (this.viewBattle_UserCallBack != null)
								{
									this.viewBattle_UserCallBack(returnData31);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ViewCastle_ReturnType))
							{
								ViewCastle_ReturnType returnData32 = (ViewCastle_ReturnType)callBackEntryClass2.data;
								if (this.viewCastle_UserCallBack != null)
								{
									this.viewCastle_UserCallBack(returnData32);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DeleteReports_ReturnType))
							{
								DeleteReports_ReturnType returnData33 = (DeleteReports_ReturnType)callBackEntryClass2.data;
								if (this.deleteReports_UserCallBack != null)
								{
									this.deleteReports_UserCallBack(returnData33);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateReportFilters_ReturnType))
							{
								UpdateReportFilters_ReturnType returnData34 = (UpdateReportFilters_ReturnType)callBackEntryClass2.data;
								if (this.updateReportFilters_UserCallBack != null)
								{
									this.updateReportFilters_UserCallBack(returnData34);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateUserOptions_ReturnType))
							{
								UpdateUserOptions_ReturnType returnData35 = (UpdateUserOptions_ReturnType)callBackEntryClass2.data;
								if (this.updateUserOptions_UserCallBack != null)
								{
									this.updateUserOptions_UserCallBack(returnData35);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ManageReportFolders_ReturnType))
							{
								ManageReportFolders_ReturnType returnData36 = (ManageReportFolders_ReturnType)callBackEntryClass2.data;
								if (this.manageReportFolders_UserCallBack != null)
								{
									this.manageReportFolders_UserCallBack(returnData36);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetHistoricalData_ReturnType))
							{
								GetHistoricalData_ReturnType returnData37 = (GetHistoricalData_ReturnType)callBackEntryClass2.data;
								if (this.getHistoricalData_UserCallBack != null)
								{
									this.getHistoricalData_UserCallBack(returnData37);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetMailThreadList_ReturnType))
							{
								GetMailThreadList_ReturnType returnData38 = (GetMailThreadList_ReturnType)callBackEntryClass2.data;
								if (this.getMailThreadList_UserCallBack != null)
								{
									this.getMailThreadList_UserCallBack(returnData38);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetMailThread_ReturnType))
							{
								GetMailThread_ReturnType returnData39 = (GetMailThread_ReturnType)callBackEntryClass2.data;
								if (this.getMailThread_UserCallBack != null)
								{
									this.getMailThread_UserCallBack(returnData39);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetMailFolders_ReturnType))
							{
								GetMailFolders_ReturnType returnData40 = (GetMailFolders_ReturnType)callBackEntryClass2.data;
								if (this.getMailFolders_UserCallBack != null)
								{
									this.getMailFolders_UserCallBack(returnData40);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CreateMailFolder_ReturnType))
							{
								CreateMailFolder_ReturnType returnData41 = (CreateMailFolder_ReturnType)callBackEntryClass2.data;
								if (this.createMailFolder_UserCallBack != null)
								{
									this.createMailFolder_UserCallBack(returnData41);
								}
							}
							else if (callBackEntryClass2.classType == typeof(MoveToMailFolder_ReturnType))
							{
								MoveToMailFolder_ReturnType returnData42 = (MoveToMailFolder_ReturnType)callBackEntryClass2.data;
								if (this.moveToMailFolder_UserCallBack != null)
								{
									this.moveToMailFolder_UserCallBack(returnData42);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RemoveMailFolder_ReturnType))
							{
								RemoveMailFolder_ReturnType returnData43 = (RemoveMailFolder_ReturnType)callBackEntryClass2.data;
								if (this.removeMailFolder_UserCallBack != null)
								{
									this.removeMailFolder_UserCallBack(returnData43);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ReportMail_ReturnType))
							{
								ReportMail_ReturnType returnData44 = (ReportMail_ReturnType)callBackEntryClass2.data;
								if (this.reportMail_UserCallBack != null)
								{
									this.reportMail_UserCallBack(returnData44);
								}
							}
							else if (callBackEntryClass2.classType == typeof(FlagMailRead_ReturnType))
							{
								FlagMailRead_ReturnType returnData45 = (FlagMailRead_ReturnType)callBackEntryClass2.data;
								if (this.flagMailRead_UserCallBack != null)
								{
									this.flagMailRead_UserCallBack(returnData45);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendMail_ReturnType))
							{
								SendMail_ReturnType returnData46 = (SendMail_ReturnType)callBackEntryClass2.data;
								if (this.sendMail_UserCallBack != null)
								{
									this.sendMail_UserCallBack(returnData46);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendSpecialMail_ReturnType))
							{
								SendSpecialMail_ReturnType returnData47 = (SendSpecialMail_ReturnType)callBackEntryClass2.data;
								if (this.sendSpecialMail_UserCallBack != null)
								{
									this.sendSpecialMail_UserCallBack(returnData47);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DeleteMailThread_ReturnType))
							{
								DeleteMailThread_ReturnType returnData48 = (DeleteMailThread_ReturnType)callBackEntryClass2.data;
								if (this.deleteMailThread_UserCallBack != null)
								{
									this.deleteMailThread_UserCallBack(returnData48);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetMailRecipientsHistory_ReturnType))
							{
								GetMailRecipientsHistory_ReturnType returnData49 = (GetMailRecipientsHistory_ReturnType)callBackEntryClass2.data;
								if (this.getMailRecipientsHistory_UserCallBack != null)
								{
									this.getMailRecipientsHistory_UserCallBack(returnData49);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetMailUserSearch_ReturnType))
							{
								GetMailUserSearch_ReturnType returnData50 = (GetMailUserSearch_ReturnType)callBackEntryClass2.data;
								if (this.getMailUserSearch_UserCallBack != null)
								{
									this.getMailUserSearch_UserCallBack(returnData50);
								}
							}
							else if (callBackEntryClass2.classType == typeof(AddUserToFavourites_ReturnType))
							{
								AddUserToFavourites_ReturnType returnData51 = (AddUserToFavourites_ReturnType)callBackEntryClass2.data;
								if (this.addUserToFavourites_UserCallBack != null)
								{
									this.addUserToFavourites_UserCallBack(returnData51);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetResourceLevel_ReturnType))
							{
								GetResourceLevel_ReturnType returnData52 = (GetResourceLevel_ReturnType)callBackEntryClass2.data;
								if (this.getResourceLevel_UserCallBack != null)
								{
									this.getResourceLevel_UserCallBack(returnData52);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageBuildingsList_ReturnType))
							{
								GetVillageBuildingsList_ReturnType returnData53 = (GetVillageBuildingsList_ReturnType)callBackEntryClass2.data;
								if (this.getVillageBuildingsList_UserCallBack != null)
								{
									this.getVillageBuildingsList_UserCallBack(returnData53);
								}
							}
							else if (callBackEntryClass2.classType == typeof(PlaceVillageBuilding_ReturnType))
							{
								PlaceVillageBuilding_ReturnType returnData54 = (PlaceVillageBuilding_ReturnType)callBackEntryClass2.data;
								if (this.placeVillageBuilding_UserCallBack != null)
								{
									this.placeVillageBuilding_UserCallBack(returnData54);
								}
							}
							else if (callBackEntryClass2.classType == typeof(MoveVillageBuilding_ReturnType))
							{
								MoveVillageBuilding_ReturnType returnData55 = (MoveVillageBuilding_ReturnType)callBackEntryClass2.data;
								if (this.moveVillageBuilding_UserCallBack != null)
								{
									this.moveVillageBuilding_UserCallBack(returnData55);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DeleteVillageBuilding_ReturnType))
							{
								DeleteVillageBuilding_ReturnType returnData56 = (DeleteVillageBuilding_ReturnType)callBackEntryClass2.data;
								if (this.deleteVillageBuilding_UserCallBack != null)
								{
									this.deleteVillageBuilding_UserCallBack(returnData56);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CancelDeleteVillageBuilding_ReturnType))
							{
								CancelDeleteVillageBuilding_ReturnType returnData57 = (CancelDeleteVillageBuilding_ReturnType)callBackEntryClass2.data;
								if (this.cancelDeleteVillageBuilding_UserCallBack != null)
								{
									this.cancelDeleteVillageBuilding_UserCallBack(returnData57);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageBuildingCompleteDataRetrieval_ReturnType))
							{
								VillageBuildingCompleteDataRetrieval_ReturnType returnData58 = (VillageBuildingCompleteDataRetrieval_ReturnType)callBackEntryClass2.data;
								if (this.villageBuildingCompleteDataRetrieval_UserCallBack != null)
								{
									this.villageBuildingCompleteDataRetrieval_UserCallBack(returnData58);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageBuildingSetActive_ReturnType))
							{
								VillageBuildingSetActive_ReturnType returnData59 = (VillageBuildingSetActive_ReturnType)callBackEntryClass2.data;
								if (this.villageBuildingSetActive_UserCallBack != null)
								{
									this.villageBuildingSetActive_UserCallBack(returnData59);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageBuildingChangeRates_ReturnType))
							{
								VillageBuildingChangeRates_ReturnType returnData60 = (VillageBuildingChangeRates_ReturnType)callBackEntryClass2.data;
								if (this.villageBuildingChangeRates_UserCallBack != null)
								{
									this.villageBuildingChangeRates_UserCallBack(returnData60);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageRename_ReturnType))
							{
								VillageRename_ReturnType returnData61 = (VillageRename_ReturnType)callBackEntryClass2.data;
								if (this.villageRename_UserCallBack != null)
								{
									this.villageRename_UserCallBack(returnData61);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageProduceWeapons_ReturnType))
							{
								VillageProduceWeapons_ReturnType returnData62 = (VillageProduceWeapons_ReturnType)callBackEntryClass2.data;
								if (this.villageProduceWeapons_UserCallBack != null)
								{
									this.villageProduceWeapons_UserCallBack(returnData62);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VillageHoldBanquet_ReturnType))
							{
								VillageHoldBanquet_ReturnType returnData63 = (VillageHoldBanquet_ReturnType)callBackEntryClass2.data;
								if (this.villageHoldBanquet_UserCallBack != null)
								{
									this.villageHoldBanquet_UserCallBack(returnData63);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetCastle_ReturnType))
							{
								GetCastle_ReturnType returnData64 = (GetCastle_ReturnType)callBackEntryClass2.data;
								if (this.getCastle_UserCallBack != null)
								{
									this.getCastle_UserCallBack(returnData64);
								}
							}
							else if (callBackEntryClass2.classType == typeof(AddCastleElement_ReturnType))
							{
								AddCastleElement_ReturnType returnData65 = (AddCastleElement_ReturnType)callBackEntryClass2.data;
								if (this.addCastleElement_UserCallBack != null)
								{
									this.addCastleElement_UserCallBack(returnData65);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DeleteCastleElement_ReturnType))
							{
								DeleteCastleElement_ReturnType returnData66 = (DeleteCastleElement_ReturnType)callBackEntryClass2.data;
								if (this.deleteCastleElement_UserCallBack != null)
								{
									this.deleteCastleElement_UserCallBack(returnData66);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CheatAddTroops_ReturnType))
							{
								CheatAddTroops_ReturnType returnData67 = (CheatAddTroops_ReturnType)callBackEntryClass2.data;
								if (this.cheatAddTroops_UserCallBack != null)
								{
									this.cheatAddTroops_UserCallBack(returnData67);
								}
							}
							else if (callBackEntryClass2.classType == typeof(AutoRepairCastle_ReturnType))
							{
								AutoRepairCastle_ReturnType returnData68 = (AutoRepairCastle_ReturnType)callBackEntryClass2.data;
								if (this.autoRepairCastle_UserCallBack != null)
								{
									this.autoRepairCastle_UserCallBack(returnData68);
								}
							}
							else if (callBackEntryClass2.classType == typeof(MemorizeCastleTroops_ReturnType))
							{
								MemorizeCastleTroops_ReturnType returnData69 = (MemorizeCastleTroops_ReturnType)callBackEntryClass2.data;
								if (this.memorizeCastleTroops_UserCallBack != null)
								{
									this.memorizeCastleTroops_UserCallBack(returnData69);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RestoreCastleTroops_ReturnType))
							{
								RestoreCastleTroops_ReturnType returnData70 = (RestoreCastleTroops_ReturnType)callBackEntryClass2.data;
								if (this.restoreCastleTroops_UserCallBack != null)
								{
									this.restoreCastleTroops_UserCallBack(returnData70);
								}
							}
							else if (callBackEntryClass2.classType == typeof(LaunchCastleAttack_ReturnType))
							{
								LaunchCastleAttack_ReturnType returnData71 = (LaunchCastleAttack_ReturnType)callBackEntryClass2.data;
								if (this.launchCastleAttack_UserCallBack != null)
								{
									this.launchCastleAttack_UserCallBack(returnData71);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ChangeCastleElementAggressiveDefender_ReturnType))
							{
								ChangeCastleElementAggressiveDefender_ReturnType returnData72 = (ChangeCastleElementAggressiveDefender_ReturnType)callBackEntryClass2.data;
								if (this.changeCastleElementAggressiveDefender_UserCallBack != null)
								{
									this.changeCastleElementAggressiveDefender_UserCallBack(returnData72);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendMarketResources_ReturnType))
							{
								SendMarketResources_ReturnType returnData73 = (SendMarketResources_ReturnType)callBackEntryClass2.data;
								if (this.sendMarketResources_UserCallBack != null)
								{
									this.sendMarketResources_UserCallBack(returnData73);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetUserTraders_ReturnType))
							{
								GetUserTraders_ReturnType returnData74 = (GetUserTraders_ReturnType)callBackEntryClass2.data;
								if (this.getUserTraders_UserCallBack != null)
								{
									this.getUserTraders_UserCallBack(returnData74);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetActiveTraders_ReturnType))
							{
								GetActiveTraders_ReturnType returnData75 = (GetActiveTraders_ReturnType)callBackEntryClass2.data;
								if (this.getActiveTraders_UserCallBack != null)
								{
									this.getActiveTraders_UserCallBack(returnData75);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetStockExchangeData_ReturnType))
							{
								GetStockExchangeData_ReturnType returnData76 = (GetStockExchangeData_ReturnType)callBackEntryClass2.data;
								if (this.getStockExchangeData_UserCallBack != null)
								{
									this.getStockExchangeData_UserCallBack(returnData76);
								}
							}
							else if (callBackEntryClass2.classType == typeof(StockExchangeTrade_ReturnType))
							{
								StockExchangeTrade_ReturnType returnData77 = (StockExchangeTrade_ReturnType)callBackEntryClass2.data;
								if (this.stockExchangeTrade_UserCallBack != null)
								{
									this.stockExchangeTrade_UserCallBack(returnData77);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateVillageFavourites_ReturnType))
							{
								UpdateVillageFavourites_ReturnType returnData78 = (UpdateVillageFavourites_ReturnType)callBackEntryClass2.data;
								if (this.updateVillageFavourites_UserCallBack != null)
								{
									this.updateVillageFavourites_UserCallBack(returnData78);
								}
							}
							else if (callBackEntryClass2.classType == typeof(MakeTroop_ReturnType))
							{
								MakeTroop_ReturnType returnData79 = (MakeTroop_ReturnType)callBackEntryClass2.data;
								if (this.makeTroop_UserCallBack != null)
								{
									this.makeTroop_UserCallBack(returnData79);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DisbandTroops_ReturnType))
							{
								DisbandTroops_ReturnType returnData80 = (DisbandTroops_ReturnType)callBackEntryClass2.data;
								if (this.disbandTroops_UserCallBack != null)
								{
									this.disbandTroops_UserCallBack(returnData80);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DisbandPeople_ReturnType))
							{
								DisbandPeople_ReturnType returnData81 = (DisbandPeople_ReturnType)callBackEntryClass2.data;
								if (this.disbandPeople_UserCallBack != null)
								{
									this.disbandPeople_UserCallBack(returnData81);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageInfoForDonateCapitalGoods_ReturnType))
							{
								GetVillageInfoForDonateCapitalGoods_ReturnType returnData82 = (GetVillageInfoForDonateCapitalGoods_ReturnType)callBackEntryClass2.data;
								if (this.getVillageInfoForDonateCapitalGoods_UserCallBack != null)
								{
									this.getVillageInfoForDonateCapitalGoods_UserCallBack(returnData82);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DonateCapitalGoods_ReturnType))
							{
								DonateCapitalGoods_ReturnType returnData83 = (DonateCapitalGoods_ReturnType)callBackEntryClass2.data;
								if (this.donateCapitalGoods_UserCallBack != null)
								{
									this.donateCapitalGoods_UserCallBack(returnData83);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageStartLocations_ReturnType))
							{
								GetVillageStartLocations_ReturnType returnData84 = (GetVillageStartLocations_ReturnType)callBackEntryClass2.data;
								if (this.getVillageStartLocations_UserCallBack != null)
								{
									this.getVillageStartLocations_UserCallBack(returnData84);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SetStartingCounty_ReturnType))
							{
								SetStartingCounty_ReturnType returnData85 = (SetStartingCounty_ReturnType)callBackEntryClass2.data;
								if (this.setStartingCounty_UserCallBack != null)
								{
									this.setStartingCounty_UserCallBack(returnData85);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateCurrentCards_ReturnType))
							{
								UpdateCurrentCards_ReturnType returnData86 = (UpdateCurrentCards_ReturnType)callBackEntryClass2.data;
								if (this.updateCurrentCards_UserCallBack != null)
								{
									this.updateCurrentCards_UserCallBack(returnData86);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CancelCard_ReturnType))
							{
								CancelCard_ReturnType returnData87 = (CancelCard_ReturnType)callBackEntryClass2.data;
								if (this.cancelCard_UserCallBack != null)
								{
									this.cancelCard_UserCallBack(returnData87);
								}
							}
							else if (callBackEntryClass2.classType == typeof(TutorialCommand_ReturnType))
							{
								TutorialCommand_ReturnType returnData88 = (TutorialCommand_ReturnType)callBackEntryClass2.data;
								if (this.tutorialCommand_UserCallBack != null)
								{
									this.tutorialCommand_UserCallBack(returnData88);
								}
							}
							else if (callBackEntryClass2.classType == typeof(FlagQuestObjectiveComplete_ReturnType))
							{
								FlagQuestObjectiveComplete_ReturnType returnData89 = (FlagQuestObjectiveComplete_ReturnType)callBackEntryClass2.data;
								if (this.flagQuestObjectiveComplete_UserCallBack != null)
								{
									this.flagQuestObjectiveComplete_UserCallBack(returnData89);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CheckQuestObjectiveComplete_ReturnType))
							{
								CheckQuestObjectiveComplete_ReturnType returnData90 = (CheckQuestObjectiveComplete_ReturnType)callBackEntryClass2.data;
								if (this.checkQuestObjectiveComplete_UserCallBack != null)
								{
									this.checkQuestObjectiveComplete_UserCallBack(returnData90);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateDiplomacyStatus_ReturnType))
							{
								UpdateDiplomacyStatus_ReturnType returnData91 = (UpdateDiplomacyStatus_ReturnType)callBackEntryClass2.data;
								if (this.updateDiplomacyStatus_UserCallBack != null)
								{
									this.updateDiplomacyStatus_UserCallBack(returnData91);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendCommands_ReturnType))
							{
								SendCommands_ReturnType returnData92 = (SendCommands_ReturnType)callBackEntryClass2.data;
								if (this.sendCommands_UserCallBack != null)
								{
									this.sendCommands_UserCallBack(returnData92);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetQuestStatus_ReturnType))
							{
								GetQuestStatus_ReturnType returnData93 = (GetQuestStatus_ReturnType)callBackEntryClass2.data;
								if (this.getQuestStatus_UserCallBack != null)
								{
									this.getQuestStatus_UserCallBack(returnData93);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CompleteQuest_ReturnType))
							{
								CompleteQuest_ReturnType returnData94 = (CompleteQuest_ReturnType)callBackEntryClass2.data;
								if (this.completeQuest_UserCallBack != null)
								{
									this.completeQuest_UserCallBack(returnData94);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpgradeRank_ReturnType))
							{
								UpgradeRank_ReturnType returnData95 = (UpgradeRank_ReturnType)callBackEntryClass2.data;
								if (this.upgradeRank_UserCallBack != null)
								{
									this.upgradeRank_UserCallBack(returnData95);
								}
							}
							else if (callBackEntryClass2.classType == typeof(PreAttackSetup_ReturnType))
							{
								PreAttackSetup_ReturnType returnData96 = (PreAttackSetup_ReturnType)callBackEntryClass2.data;
								if (this.preAttackSetup_UserCallBack != null)
								{
									this.preAttackSetup_UserCallBack(returnData96);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetBattleHonourRating_ReturnType))
							{
								GetBattleHonourRating_ReturnType returnData97 = (GetBattleHonourRating_ReturnType)callBackEntryClass2.data;
								if (this.getBattleHonourRating_UserCallBack != null)
								{
									this.getBattleHonourRating_UserCallBack(returnData97);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveArmyFromGarrison_ReturnType))
							{
								RetrieveArmyFromGarrison_ReturnType returnData98 = (RetrieveArmyFromGarrison_ReturnType)callBackEntryClass2.data;
								if (this.retrieveArmyFromGarrison_UserCallBack != null)
								{
									this.retrieveArmyFromGarrison_UserCallBack(returnData98);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVillageRankTaxTree_ReturnType))
							{
								GetVillageRankTaxTree_ReturnType returnData99 = (GetVillageRankTaxTree_ReturnType)callBackEntryClass2.data;
								if (this.getVillageRankTaxTree_UserCallBack != null)
								{
									this.getVillageRankTaxTree_UserCallBack(returnData99);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetResearchData_ReturnType))
							{
								GetResearchData_ReturnType returnData100 = (GetResearchData_ReturnType)callBackEntryClass2.data;
								if (this.getResearchData_UserCallBack != null)
								{
									this.getResearchData_UserCallBack(returnData100);
								}
							}
							else if (callBackEntryClass2.classType == typeof(DoResearch_ReturnType))
							{
								DoResearch_ReturnType returnData101 = (DoResearch_ReturnType)callBackEntryClass2.data;
								if (this.doResearch_UserCallBack != null)
								{
									this.doResearch_UserCallBack(returnData101);
								}
							}
							else if (callBackEntryClass2.classType == typeof(BuyResearchPoint_ReturnType))
							{
								BuyResearchPoint_ReturnType returnData102 = (BuyResearchPoint_ReturnType)callBackEntryClass2.data;
								if (this.buyResearchPoint_UserCallBack != null)
								{
									this.buyResearchPoint_UserCallBack(returnData102);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendReinforcements_ReturnType))
							{
								SendReinforcements_ReturnType returnData103 = (SendReinforcements_ReturnType)callBackEntryClass2.data;
								if (this.sendReinforcements_UserCallBack != null)
								{
									this.sendReinforcements_UserCallBack(returnData103);
								}
							}
							else if (callBackEntryClass2.classType == typeof(ReturnReinforcements_ReturnType))
							{
								ReturnReinforcements_ReturnType returnData104 = (ReturnReinforcements_ReturnType)callBackEntryClass2.data;
								if (this.returnReinforcements_UserCallBack != null)
								{
									this.returnReinforcements_UserCallBack(returnData104);
								}
							}
							else if (callBackEntryClass2.classType == typeof(CancelCastleAttack_ReturnType))
							{
								CancelCastleAttack_ReturnType returnData105 = (CancelCastleAttack_ReturnType)callBackEntryClass2.data;
								if (this.cancelCastleAttack_UserCallBack != null)
								{
									this.cancelCastleAttack_UserCallBack(returnData105);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VassalInfo_ReturnType))
							{
								VassalInfo_ReturnType returnData106 = (VassalInfo_ReturnType)callBackEntryClass2.data;
								if (this.vassalInfo_UserCallBack != null)
								{
									this.vassalInfo_UserCallBack(returnData106);
								}
							}
							else if (callBackEntryClass2.classType == typeof(HandleVassalRequest_ReturnType))
							{
								HandleVassalRequest_ReturnType returnData107 = (HandleVassalRequest_ReturnType)callBackEntryClass2.data;
								if (this.handleVassalRequest_UserCallBack != null)
								{
									this.handleVassalRequest_UserCallBack(returnData107);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetVassalArmyInfo_ReturnType))
							{
								GetVassalArmyInfo_ReturnType returnData108 = (GetVassalArmyInfo_ReturnType)callBackEntryClass2.data;
								if (this.getVassalArmyInfo_UserCallBack != null)
								{
									this.getVassalArmyInfo_UserCallBack(returnData108);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendTroopsToVassal_ReturnType))
							{
								SendTroopsToVassal_ReturnType returnData109 = (SendTroopsToVassal_ReturnType)callBackEntryClass2.data;
								if (this.sendTroopsToVassal_UserCallBack != null)
								{
									this.sendTroopsToVassal_UserCallBack(returnData109);
								}
							}
							else if (callBackEntryClass2.classType == typeof(RetrieveTroopsFromVassal_ReturnType))
							{
								RetrieveTroopsFromVassal_ReturnType returnData110 = (RetrieveTroopsFromVassal_ReturnType)callBackEntryClass2.data;
								if (this.retrieveTroopsFromVassal_UserCallBack != null)
								{
									this.retrieveTroopsFromVassal_UserCallBack(returnData110);
								}
							}
							else if (callBackEntryClass2.classType == typeof(VassalSendResources_ReturnType))
							{
								VassalSendResources_ReturnType returnData111 = (VassalSendResources_ReturnType)callBackEntryClass2.data;
								if (this.vassalSendResources_UserCallBack != null)
								{
									this.vassalSendResources_UserCallBack(returnData111);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateSelectedTitheType_ReturnType))
							{
								UpdateSelectedTitheType_ReturnType returnData112 = (UpdateSelectedTitheType_ReturnType)callBackEntryClass2.data;
								if (this.updateSelectedTitheType_UserCallBack != null)
								{
									this.updateSelectedTitheType_UserCallBack(returnData112);
								}
							}
							else if (callBackEntryClass2.classType == typeof(BreakVassalage_ReturnType))
							{
								BreakVassalage_ReturnType returnData113 = (BreakVassalage_ReturnType)callBackEntryClass2.data;
								if (this.breakVassalage_UserCallBack != null)
								{
									this.breakVassalage_UserCallBack(returnData113);
								}
							}
							else if (callBackEntryClass2.classType == typeof(SendVassalRequest_ReturnType))
							{
								SendVassalRequest_ReturnType returnData114 = (SendVassalRequest_ReturnType)callBackEntryClass2.data;
								if (this.sendVassalRequest_UserCallBack != null)
								{
									this.sendVassalRequest_UserCallBack(returnData114);
								}
							}
							else if (callBackEntryClass2.classType == typeof(GetPreVassalInfo_ReturnType))
							{
								GetPreVassalInfo_ReturnType returnData115 = (GetPreVassalInfo_ReturnType)callBackEntryClass2.data;
								if (this.getPreVassalInfo_UserCallBack != null)
								{
									this.getPreVassalInfo_UserCallBack(returnData115);
								}
							}
							else if (callBackEntryClass2.classType == typeof(BreakLiegeLord_ReturnType))
							{
								BreakLiegeLord_ReturnType returnData116 = (BreakLiegeLord_ReturnType)callBackEntryClass2.data;
								if (this.breakLiegeLord_UserCallBack != null)
								{
									this.breakLiegeLord_UserCallBack(returnData116);
								}
							}
							else if (callBackEntryClass2.classType == typeof(UpdateVillageResourcesInfo_ReturnType))
							{
								UpdateVillageResourcesInfo_ReturnType returnData117 = (UpdateVillageResourcesInfo_ReturnType)callBackEntryClass2.data;
								if (this.updateVillageResourcesInfo_UserCallBack != null)
								{
									this.updateVillageResourcesInfo_UserCallBack(returnData117);
								}
							}
							else
							{
								if (callBackEntryClass2.classType == typeof(SendScouts_ReturnType))
								{
									SendScouts_ReturnType returnData118 = (SendScouts_ReturnType)callBackEntryClass2.data;
									if (this.sendScouts_UserCallBack == null)
									{
										goto IL_399F;
									}
									try
									{
										this.sendScouts_UserCallBack(returnData118);
										goto IL_399F;
									}
									catch (Exception)
									{
										goto IL_399F;
									}
								}
								if (callBackEntryClass2.classType == typeof(SetHighestArmySeen_ReturnType))
								{
									SetHighestArmySeen_ReturnType returnData119 = (SetHighestArmySeen_ReturnType)callBackEntryClass2.data;
									if (this.setHighestArmySeen_UserCallBack != null)
									{
										this.setHighestArmySeen_UserCallBack(returnData119);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetForumList_ReturnType))
								{
									GetForumList_ReturnType returnData120 = (GetForumList_ReturnType)callBackEntryClass2.data;
									if (this.getForumList_UserCallBack != null)
									{
										this.getForumList_UserCallBack(returnData120);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetForumThreadList_ReturnType))
								{
									GetForumThreadList_ReturnType returnData121 = (GetForumThreadList_ReturnType)callBackEntryClass2.data;
									if (this.getForumThreadList_UserCallBack != null)
									{
										this.getForumThreadList_UserCallBack(returnData121);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetForumThread_ReturnType))
								{
									GetForumThread_ReturnType returnData122 = (GetForumThread_ReturnType)callBackEntryClass2.data;
									if (this.getForumThread_UserCallBack != null)
									{
										this.getForumThread_UserCallBack(returnData122);
									}
								}
								else if (callBackEntryClass2.classType == typeof(NewForumThread_ReturnType))
								{
									NewForumThread_ReturnType returnData123 = (NewForumThread_ReturnType)callBackEntryClass2.data;
									if (this.newForumThread_UserCallBack != null)
									{
										this.newForumThread_UserCallBack(returnData123);
									}
								}
								else if (callBackEntryClass2.classType == typeof(PostToForumThread_ReturnType))
								{
									PostToForumThread_ReturnType returnData124 = (PostToForumThread_ReturnType)callBackEntryClass2.data;
									if (this.postToForumThread_UserCallBack != null)
									{
										this.postToForumThread_UserCallBack(returnData124);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GiveForumAccess_ReturnType))
								{
									GiveForumAccess_ReturnType returnData125 = (GiveForumAccess_ReturnType)callBackEntryClass2.data;
									if (this.giveForumAccess_UserCallBack != null)
									{
										this.giveForumAccess_UserCallBack(returnData125);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CreateForum_ReturnType))
								{
									CreateForum_ReturnType returnData126 = (CreateForum_ReturnType)callBackEntryClass2.data;
									if (this.createForum_UserCallBack != null)
									{
										this.createForum_UserCallBack(returnData126);
									}
								}
								else if (callBackEntryClass2.classType == typeof(DeleteForum_ReturnType))
								{
									DeleteForum_ReturnType returnData127 = (DeleteForum_ReturnType)callBackEntryClass2.data;
									if (this.deleteForum_UserCallBack != null)
									{
										this.deleteForum_UserCallBack(returnData127);
									}
								}
								else if (callBackEntryClass2.classType == typeof(DeleteForumThread_ReturnType))
								{
									DeleteForumThread_ReturnType returnData128 = (DeleteForumThread_ReturnType)callBackEntryClass2.data;
									if (this.deleteForumThread_UserCallBack != null)
									{
										this.deleteForumThread_UserCallBack(returnData128);
									}
								}
								else if (callBackEntryClass2.classType == typeof(DeleteForumPost_ReturnType))
								{
									DeleteForumPost_ReturnType returnData129 = (DeleteForumPost_ReturnType)callBackEntryClass2.data;
									if (this.deleteForumPost_UserCallBack != null)
									{
										this.deleteForumPost_UserCallBack(returnData129);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCurrentElectionInfo_ReturnType))
								{
									GetCurrentElectionInfo_ReturnType returnData130 = (GetCurrentElectionInfo_ReturnType)callBackEntryClass2.data;
									if (this.getCurrentElectionInfo_UserCallBack != null)
									{
										this.getCurrentElectionInfo_UserCallBack(returnData130);
									}
								}
								else if (callBackEntryClass2.classType == typeof(StandInElection_ReturnType))
								{
									StandInElection_ReturnType returnData131 = (StandInElection_ReturnType)callBackEntryClass2.data;
									if (this.standInElection_UserCallBack != null)
									{
										this.standInElection_UserCallBack(returnData131);
									}
								}
								else if (callBackEntryClass2.classType == typeof(VoteInElection_ReturnType))
								{
									VoteInElection_ReturnType returnData132 = (VoteInElection_ReturnType)callBackEntryClass2.data;
									if (this.voteInElection_UserCallBack != null)
									{
										this.voteInElection_UserCallBack(returnData132);
									}
								}
								else if (callBackEntryClass2.classType == typeof(UploadAvatar_ReturnType))
								{
									UploadAvatar_ReturnType returnData133 = (UploadAvatar_ReturnType)callBackEntryClass2.data;
									if (this.uploadAvatar_UserCallBack != null)
									{
										this.uploadAvatar_UserCallBack(returnData133);
									}
								}
								else if (callBackEntryClass2.classType == typeof(MakePeople_ReturnType))
								{
									MakePeople_ReturnType returnData134 = (MakePeople_ReturnType)callBackEntryClass2.data;
									if (this.makePeople_UserCallBack != null)
									{
										this.makePeople_UserCallBack(returnData134);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetUserPeople_ReturnType))
								{
									GetUserPeople_ReturnType returnData135 = (GetUserPeople_ReturnType)callBackEntryClass2.data;
									if (this.getUserPeople_UserCallBack != null)
									{
										this.getUserPeople_UserCallBack(returnData135);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetUserIDFromName_ReturnType))
								{
									GetUserIDFromName_ReturnType returnData136 = (GetUserIDFromName_ReturnType)callBackEntryClass2.data;
									if (this.getUserIDFromName_UserCallBack != null)
									{
										this.getUserIDFromName_UserCallBack(returnData136);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetActivePeople_ReturnType))
								{
									GetActivePeople_ReturnType returnData137 = (GetActivePeople_ReturnType)callBackEntryClass2.data;
									if (this.getActivePeople_UserCallBack != null)
									{
										this.getActivePeople_UserCallBack(returnData137);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SendPeople_ReturnType))
								{
									SendPeople_ReturnType returnData138 = (SendPeople_ReturnType)callBackEntryClass2.data;
									if (this.sendPeople_UserCallBack != null)
									{
										this.sendPeople_UserCallBack(returnData138);
									}
								}
								else if (callBackEntryClass2.classType == typeof(RetrievePeople_ReturnType))
								{
									RetrievePeople_ReturnType returnData139 = (RetrievePeople_ReturnType)callBackEntryClass2.data;
									if (this.retrievePeople_UserCallBack != null)
									{
										this.retrievePeople_UserCallBack(returnData139);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SpyCommand_ReturnType))
								{
									SpyCommand_ReturnType returnData140 = (SpyCommand_ReturnType)callBackEntryClass2.data;
									if (this.spyCommand_UserCallBack != null)
									{
										this.spyCommand_UserCallBack(returnData140);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SpyGetVillageResourceInfo_ReturnType))
								{
									SpyGetVillageResourceInfo_ReturnType returnData141 = (SpyGetVillageResourceInfo_ReturnType)callBackEntryClass2.data;
									if (this.spyGetVillageResourceInfo_UserCallBack != null)
									{
										this.spyGetVillageResourceInfo_UserCallBack(returnData141);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SpyGetArmyInfo_ReturnType))
								{
									SpyGetArmyInfo_ReturnType returnData142 = (SpyGetArmyInfo_ReturnType)callBackEntryClass2.data;
									if (this.spyGetArmyInfo_UserCallBack != null)
									{
										this.spyGetArmyInfo_UserCallBack(returnData142);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SpyGetResearchInfo_ReturnType))
								{
									SpyGetResearchInfo_ReturnType returnData143 = (SpyGetResearchInfo_ReturnType)callBackEntryClass2.data;
									if (this.spyGetResearchInfo_UserCallBack != null)
									{
										this.spyGetResearchInfo_UserCallBack(returnData143);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetLoginHistory_ReturnType))
								{
									GetLoginHistory_ReturnType returnData144 = (GetLoginHistory_ReturnType)callBackEntryClass2.data;
									if (this.getLoginHistory_UserCallBack != null)
									{
										this.getLoginHistory_UserCallBack(returnData144);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CreateFaction_ReturnType))
								{
									CreateFaction_ReturnType returnData145 = (CreateFaction_ReturnType)callBackEntryClass2.data;
									if (this.createFaction_UserCallBack != null)
									{
										this.createFaction_UserCallBack(returnData145);
									}
								}
								else if (callBackEntryClass2.classType == typeof(DisbandFaction_ReturnType))
								{
									DisbandFaction_ReturnType returnData146 = (DisbandFaction_ReturnType)callBackEntryClass2.data;
									if (this.disbandFaction_UserCallBack != null)
									{
										this.disbandFaction_UserCallBack(returnData146);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionSendInvite_ReturnType))
								{
									FactionSendInvite_ReturnType returnData147 = (FactionSendInvite_ReturnType)callBackEntryClass2.data;
									if (this.factionSendInvite_UserCallBack != null)
									{
										this.factionSendInvite_UserCallBack(returnData147);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionWithdrawInvite_ReturnType))
								{
									FactionWithdrawInvite_ReturnType returnData148 = (FactionWithdrawInvite_ReturnType)callBackEntryClass2.data;
									if (this.factionWithdrawInvite_UserCallBack != null)
									{
										this.factionWithdrawInvite_UserCallBack(returnData148);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionReplyToInvite_ReturnType))
								{
									FactionReplyToInvite_ReturnType returnData149 = (FactionReplyToInvite_ReturnType)callBackEntryClass2.data;
									if (this.factionReplyToInvite_UserCallBack != null)
									{
										this.factionReplyToInvite_UserCallBack(returnData149);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionChangeMemberStatus_ReturnType))
								{
									FactionChangeMemberStatus_ReturnType returnData150 = (FactionChangeMemberStatus_ReturnType)callBackEntryClass2.data;
									if (this.factionChangeMemberStatus_UserCallBack != null)
									{
										this.factionChangeMemberStatus_UserCallBack(returnData150);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionLeave_ReturnType))
								{
									FactionLeave_ReturnType returnData151 = (FactionLeave_ReturnType)callBackEntryClass2.data;
									if (this.factionLeave_UserCallBack != null)
									{
										this.factionLeave_UserCallBack(returnData151);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionApplication_ReturnType))
								{
									FactionApplication_ReturnType returnData152 = (FactionApplication_ReturnType)callBackEntryClass2.data;
									if (this.factionApplication_UserCallBack != null)
									{
										this.factionApplication_UserCallBack(returnData152);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionApplicationProcessing_ReturnType))
								{
									FactionApplicationProcessing_ReturnType returnData153 = (FactionApplicationProcessing_ReturnType)callBackEntryClass2.data;
									if (this.factionApplicationProcessing_UserCallBack != null)
									{
										this.factionApplicationProcessing_UserCallBack(returnData153);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetFactionData_ReturnType))
								{
									GetFactionData_ReturnType returnData154 = (GetFactionData_ReturnType)callBackEntryClass2.data;
									if (this.getFactionData_UserCallBack != null)
									{
										this.getFactionData_UserCallBack(returnData154);
									}
								}
								else if (callBackEntryClass2.classType == typeof(FactionLeadershipVote_ReturnType))
								{
									FactionLeadershipVote_ReturnType returnData155 = (FactionLeadershipVote_ReturnType)callBackEntryClass2.data;
									if (this.factionLeadershipVote_UserCallBack != null)
									{
										this.factionLeadershipVote_UserCallBack(returnData155);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CreateUserRelationship_ReturnType))
								{
									CreateUserRelationship_ReturnType returnData156 = (CreateUserRelationship_ReturnType)callBackEntryClass2.data;
									if (this.createUserRelationship_UserCallBack != null)
									{
										this.createUserRelationship_UserCallBack(returnData156);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CreateFactionRelationship_ReturnType))
								{
									CreateFactionRelationship_ReturnType returnData157 = (CreateFactionRelationship_ReturnType)callBackEntryClass2.data;
									if (this.createFactionRelationship_UserCallBack != null)
									{
										this.createFactionRelationship_UserCallBack(returnData157);
									}
								}
								else if (callBackEntryClass2.classType == typeof(ChangeFactionMotto_ReturnType))
								{
									ChangeFactionMotto_ReturnType returnData158 = (ChangeFactionMotto_ReturnType)callBackEntryClass2.data;
									if (this.changeFactionMotto_UserCallBack != null)
									{
										this.changeFactionMotto_UserCallBack(returnData158);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CreateHouseRelationship_ReturnType))
								{
									CreateHouseRelationship_ReturnType returnData159 = (CreateHouseRelationship_ReturnType)callBackEntryClass2.data;
									if (this.createHouseRelationship_UserCallBack != null)
									{
										this.createHouseRelationship_UserCallBack(returnData159);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetHouseGloryPoints_ReturnType))
								{
									GetHouseGloryPoints_ReturnType returnData160 = (GetHouseGloryPoints_ReturnType)callBackEntryClass2.data;
									if (this.getHouseGloryPoints_UserCallBack != null)
									{
										this.getHouseGloryPoints_UserCallBack(returnData160);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetViewFactionData_ReturnType))
								{
									GetViewFactionData_ReturnType returnData161 = (GetViewFactionData_ReturnType)callBackEntryClass2.data;
									if (this.getViewFactionData_UserCallBack != null)
									{
										this.getViewFactionData_UserCallBack(returnData161);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetViewHouseData_ReturnType))
								{
									GetViewHouseData_ReturnType returnData162 = (GetViewHouseData_ReturnType)callBackEntryClass2.data;
									if (this.getViewHouseData_UserCallBack != null)
									{
										this.getViewHouseData_UserCallBack(returnData162);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SelfJoinHouse_ReturnType))
								{
									SelfJoinHouse_ReturnType returnData163 = (SelfJoinHouse_ReturnType)callBackEntryClass2.data;
									if (this.selfJoinHouse_UserCallBack != null)
									{
										this.selfJoinHouse_UserCallBack(returnData163);
									}
								}
								else if (callBackEntryClass2.classType == typeof(HouseVote_ReturnType))
								{
									HouseVote_ReturnType returnData164 = (HouseVote_ReturnType)callBackEntryClass2.data;
									if (this.houseVote_UserCallBack != null)
									{
										this.houseVote_UserCallBack(returnData164);
									}
								}
								else if (callBackEntryClass2.classType == typeof(HouseVoteHouseLeader_ReturnType))
								{
									HouseVoteHouseLeader_ReturnType returnData165 = (HouseVoteHouseLeader_ReturnType)callBackEntryClass2.data;
									if (this.houseVoteHouseLeader_UserCallBack != null)
									{
										this.houseVoteHouseLeader_UserCallBack(returnData165);
									}
								}
								else if (callBackEntryClass2.classType == typeof(TouchHouseVisitDate_ReturnType))
								{
									TouchHouseVisitDate_ReturnType returnData166 = (TouchHouseVisitDate_ReturnType)callBackEntryClass2.data;
									if (this.touchHouseVisitDate_UserCallBack != null)
									{
										this.touchHouseVisitDate_UserCallBack(returnData166);
									}
								}
								else if (callBackEntryClass2.classType == typeof(LeaveHouse_ReturnType))
								{
									LeaveHouse_ReturnType returnData167 = (LeaveHouse_ReturnType)callBackEntryClass2.data;
									if (this.leaveHouse_UserCallBack != null)
									{
										this.leaveHouse_UserCallBack(returnData167);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetParishMembersList_ReturnType))
								{
									GetParishMembersList_ReturnType returnData168 = (GetParishMembersList_ReturnType)callBackEntryClass2.data;
									if (this.getParishMembersList_UserCallBack != null)
									{
										this.getParishMembersList_UserCallBack(returnData168);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetParishFrontPageInfo_ReturnType))
								{
									GetParishFrontPageInfo_ReturnType returnData169 = (GetParishFrontPageInfo_ReturnType)callBackEntryClass2.data;
									if (this.getParishFrontPageInfo_UserCallBack != null)
									{
										this.getParishFrontPageInfo_UserCallBack(returnData169);
									}
								}
								else if (callBackEntryClass2.classType == typeof(ParishWallDetailInfo_ReturnType))
								{
									ParishWallDetailInfo_ReturnType returnData170 = (ParishWallDetailInfo_ReturnType)callBackEntryClass2.data;
									if (this.parishWallDetailInfo_UserCallBack != null)
									{
										this.parishWallDetailInfo_UserCallBack(returnData170);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCountyElectionInfo_ReturnType))
								{
									GetCountyElectionInfo_ReturnType returnData171 = (GetCountyElectionInfo_ReturnType)callBackEntryClass2.data;
									if (this.getCountyElectionInfo_UserCallBack != null)
									{
										this.getCountyElectionInfo_UserCallBack(returnData171);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCountyFrontPageInfo_ReturnType))
								{
									GetCountyFrontPageInfo_ReturnType returnData172 = (GetCountyFrontPageInfo_ReturnType)callBackEntryClass2.data;
									if (this.getCountyFrontPageInfo_UserCallBack != null)
									{
										this.getCountyFrontPageInfo_UserCallBack(returnData172);
									}
								}
								else if (callBackEntryClass2.classType == typeof(StandDownAsParishDespot_ReturnType))
								{
									StandDownAsParishDespot_ReturnType returnData173 = (StandDownAsParishDespot_ReturnType)callBackEntryClass2.data;
									if (this.standDownAsParishDespot_UserCallBack != null)
									{
										this.standDownAsParishDespot_UserCallBack(returnData173);
									}
								}
								else if (callBackEntryClass2.classType == typeof(MakeParishVote_ReturnType))
								{
									MakeParishVote_ReturnType returnData174 = (MakeParishVote_ReturnType)callBackEntryClass2.data;
									if (this.makeParishVote_UserCallBack != null)
									{
										this.makeParishVote_UserCallBack(returnData174);
									}
								}
								else if (callBackEntryClass2.classType == typeof(MakeCountyVote_ReturnType))
								{
									MakeCountyVote_ReturnType returnData175 = (MakeCountyVote_ReturnType)callBackEntryClass2.data;
									if (this.makeCountyVote_UserCallBack != null)
									{
										this.makeCountyVote_UserCallBack(returnData175);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCountryElectionInfo_ReturnType))
								{
									GetCountryElectionInfo_ReturnType returnData176 = (GetCountryElectionInfo_ReturnType)callBackEntryClass2.data;
									if (this.getCountryElectionInfo_UserCallBack != null)
									{
										this.getCountryElectionInfo_UserCallBack(returnData176);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCountryFrontPageInfo_ReturnType))
								{
									GetCountryFrontPageInfo_ReturnType returnData177 = (GetCountryFrontPageInfo_ReturnType)callBackEntryClass2.data;
									if (this.getCountryFrontPageInfo_UserCallBack != null)
									{
										this.getCountryFrontPageInfo_UserCallBack(returnData177);
									}
								}
								else if (callBackEntryClass2.classType == typeof(MakeCountryVote_ReturnType))
								{
									MakeCountryVote_ReturnType returnData178 = (MakeCountryVote_ReturnType)callBackEntryClass2.data;
									if (this.makeCountryVote_UserCallBack != null)
									{
										this.makeCountryVote_UserCallBack(returnData178);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetProvinceElectionInfo_ReturnType))
								{
									GetProvinceElectionInfo_ReturnType returnData179 = (GetProvinceElectionInfo_ReturnType)callBackEntryClass2.data;
									if (this.getProvinceElectionInfo_UserCallBack != null)
									{
										this.getProvinceElectionInfo_UserCallBack(returnData179);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetProvinceFrontPageInfo_ReturnType))
								{
									GetProvinceFrontPageInfo_ReturnType returnData180 = (GetProvinceFrontPageInfo_ReturnType)callBackEntryClass2.data;
									if (this.getProvinceFrontPageInfo_UserCallBack != null)
									{
										this.getProvinceFrontPageInfo_UserCallBack(returnData180);
									}
								}
								else if (callBackEntryClass2.classType == typeof(MakeProvinceVote_ReturnType))
								{
									MakeProvinceVote_ReturnType returnData181 = (MakeProvinceVote_ReturnType)callBackEntryClass2.data;
									if (this.makeProvinceVote_UserCallBack != null)
									{
										this.makeProvinceVote_UserCallBack(returnData181);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SendTroopsToCapital_ReturnType))
								{
									SendTroopsToCapital_ReturnType returnData182 = (SendTroopsToCapital_ReturnType)callBackEntryClass2.data;
									if (this.sendTroopsToCapital_UserCallBack != null)
									{
										this.sendTroopsToCapital_UserCallBack(returnData182);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetCapitalBarracksSpace_ReturnType))
								{
									GetCapitalBarracksSpace_ReturnType returnData183 = (GetCapitalBarracksSpace_ReturnType)callBackEntryClass2.data;
									if (this.getCapitalBarracksSpace_UserCallBack != null)
									{
										this.getCapitalBarracksSpace_UserCallBack(returnData183);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetIngameMessage_ReturnType))
								{
									GetIngameMessage_ReturnType returnData184 = (GetIngameMessage_ReturnType)callBackEntryClass2.data;
									if (this.getIngameMessage_UserCallBack != null)
									{
										this.getIngameMessage_UserCallBack(returnData184);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CancelInterdiction_ReturnType))
								{
									CancelInterdiction_ReturnType returnData185 = (CancelInterdiction_ReturnType)callBackEntryClass2.data;
									if (this.cancelInterdiction_UserCallBack != null)
									{
										this.cancelInterdiction_UserCallBack(returnData185);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetExcommunicationStatus_ReturnType))
								{
									GetExcommunicationStatus_ReturnType returnData186 = (GetExcommunicationStatus_ReturnType)callBackEntryClass2.data;
									if (this.getExcommunicationStatus_UserCallBack != null)
									{
										this.getExcommunicationStatus_UserCallBack(returnData186);
									}
								}
								else if (callBackEntryClass2.classType == typeof(InitialiseFreeCards_ReturnType))
								{
									InitialiseFreeCards_ReturnType returnData187 = (InitialiseFreeCards_ReturnType)callBackEntryClass2.data;
									if (this.initialiseFreeCards_UserCallBack != null)
									{
										this.initialiseFreeCards_UserCallBack(returnData187);
									}
								}
								else if (callBackEntryClass2.classType == typeof(TestAchievements_ReturnType))
								{
									TestAchievements_ReturnType returnData188 = (TestAchievements_ReturnType)callBackEntryClass2.data;
									if (this.testAchievements_UserCallBack != null)
									{
										this.testAchievements_UserCallBack(returnData188);
									}
								}
								else if (callBackEntryClass2.classType == typeof(AchievementProgress_ReturnType))
								{
									AchievementProgress_ReturnType returnData189 = (AchievementProgress_ReturnType)callBackEntryClass2.data;
									if (this.achievementProgress_UserCallBack != null)
									{
										this.achievementProgress_UserCallBack(returnData189);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetQuestData_ReturnType))
								{
									GetQuestData_ReturnType returnData190 = (GetQuestData_ReturnType)callBackEntryClass2.data;
									if (this.getQuestData_UserCallBack != null)
									{
										this.getQuestData_UserCallBack(returnData190);
									}
								}
								else if (callBackEntryClass2.classType == typeof(StartNewQuest_ReturnType))
								{
									StartNewQuest_ReturnType returnData191 = (StartNewQuest_ReturnType)callBackEntryClass2.data;
									if (this.startNewQuest_UserCallBack != null)
									{
										this.startNewQuest_UserCallBack(returnData191);
									}
								}
								else if (callBackEntryClass2.classType == typeof(CompleteAbandonNewQuest_ReturnType))
								{
									CompleteAbandonNewQuest_ReturnType returnData192 = (CompleteAbandonNewQuest_ReturnType)callBackEntryClass2.data;
									if (this.completeAbandonNewQuest_UserCallBack != null)
									{
										this.completeAbandonNewQuest_UserCallBack(returnData192);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SpinTheWheel_ReturnType))
								{
									SpinTheWheel_ReturnType returnData193 = (SpinTheWheel_ReturnType)callBackEntryClass2.data;
									if (this.spinTheWheel_UserCallBack != null)
									{
										this.spinTheWheel_UserCallBack(returnData193);
									}
								}
								else if (callBackEntryClass2.classType == typeof(SetVacationMode_ReturnType))
								{
									SetVacationMode_ReturnType returnData194 = (SetVacationMode_ReturnType)callBackEntryClass2.data;
									if (this.setVacationMode_UserCallBack != null)
									{
										this.setVacationMode_UserCallBack(returnData194);
									}
								}
								else if (callBackEntryClass2.classType == typeof(PremiumOverview_ReturnType))
								{
									PremiumOverview_ReturnType returnData195 = (PremiumOverview_ReturnType)callBackEntryClass2.data;
									if (this.premiumOverview_UserCallBack != null)
									{
										this.premiumOverview_UserCallBack(returnData195);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetLastAttacker_ReturnType))
								{
									GetLastAttacker_ReturnType returnData196 = (GetLastAttacker_ReturnType)callBackEntryClass2.data;
									if (this.getLastAttacker_UserCallBack != null)
									{
										this.getLastAttacker_UserCallBack(returnData196);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetInvasionInfo_ReturnType))
								{
									GetInvasionInfo_ReturnType returnData197 = (GetInvasionInfo_ReturnType)callBackEntryClass2.data;
									if (this.getInvasionInfo_UserCallBack != null)
									{
										this.getInvasionInfo_UserCallBack(returnData197);
									}
								}
								else if (callBackEntryClass2.classType == typeof(PreValidateCardToBePlayed_ReturnType))
								{
									PreValidateCardToBePlayed_ReturnType returnData198 = (PreValidateCardToBePlayed_ReturnType)callBackEntryClass2.data;
									if (this.preValidateCardToBePlayed_UserCallBack != null)
									{
										this.preValidateCardToBePlayed_UserCallBack(returnData198);
									}
								}
								else if (callBackEntryClass2.classType == typeof(WorldInfo_ReturnType))
								{
									WorldInfo_ReturnType returnData199 = (WorldInfo_ReturnType)callBackEntryClass2.data;
									if (this.worldInfo_UserCallBack != null)
									{
										this.worldInfo_UserCallBack(returnData199);
									}
								}
								else if (callBackEntryClass2.classType == typeof(EndOfTheWorldStats_ReturnType))
								{
									EndOfTheWorldStats_ReturnType returnData200 = (EndOfTheWorldStats_ReturnType)callBackEntryClass2.data;
									if (this.endOfTheWorldStats_UserCallBack != null)
									{
										this.endOfTheWorldStats_UserCallBack(returnData200);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetKillStreakData_ReturnType))
								{
									GetKillStreakData_ReturnType returnData201 = (GetKillStreakData_ReturnType)callBackEntryClass2.data;
									if (this.getKillStreakData_UserCallBack != null)
									{
										this.getKillStreakData_UserCallBack(returnData201);
									}
								}
								else if (callBackEntryClass2.classType == typeof(EndWorld_ReturnType))
								{
									EndWorld_ReturnType returnData202 = (EndWorld_ReturnType)callBackEntryClass2.data;
									if (this.endWorld_UserCallBack != null)
									{
										this.endWorld_UserCallBack(returnData202);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_Login_ReturnType))
								{
									Chat_Login_ReturnType returnData203 = (Chat_Login_ReturnType)callBackEntryClass2.data;
									if (this.chat_Login_UserCallBack != null)
									{
										this.chat_Login_UserCallBack(returnData203);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_Logout_ReturnType))
								{
									Chat_Logout_ReturnType returnData204 = (Chat_Logout_ReturnType)callBackEntryClass2.data;
									if (this.chat_Logout_UserCallBack != null)
									{
										this.chat_Logout_UserCallBack(returnData204);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_SetReceivingState_ReturnType))
								{
									Chat_SetReceivingState_ReturnType returnData205 = (Chat_SetReceivingState_ReturnType)callBackEntryClass2.data;
									if (this.chat_SetReceivingState_UserCallBack != null)
									{
										this.chat_SetReceivingState_UserCallBack(returnData205);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_SendText_ReturnType))
								{
									Chat_SendText_ReturnType returnData206 = (Chat_SendText_ReturnType)callBackEntryClass2.data;
									if (this.chat_SendText_UserCallBack != null)
									{
										this.chat_SendText_UserCallBack(returnData206);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_ReceiveText_ReturnType))
								{
									Chat_ReceiveText_ReturnType returnData207 = (Chat_ReceiveText_ReturnType)callBackEntryClass2.data;
									if (this.chat_ReceiveText_UserCallBack != null)
									{
										this.chat_ReceiveText_UserCallBack(returnData207);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_SendParishText_ReturnType))
								{
									Chat_SendParishText_ReturnType returnData208 = (Chat_SendParishText_ReturnType)callBackEntryClass2.data;
									if (this.chat_SendParishText_UserCallBack != null)
									{
										this.chat_SendParishText_UserCallBack(returnData208);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_ReceiveParishText_ReturnType))
								{
									Chat_ReceiveParishText_ReturnType returnData209 = (Chat_ReceiveParishText_ReturnType)callBackEntryClass2.data;
									if (this.chat_ReceiveParishText_UserCallBack != null)
									{
										this.chat_ReceiveParishText_UserCallBack(returnData209);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_BackFillParishText_ReturnType))
								{
									Chat_BackFillParishText_ReturnType returnData210 = (Chat_BackFillParishText_ReturnType)callBackEntryClass2.data;
									if (this.chat_BackFillParishText_UserCallBack != null)
									{
										this.chat_BackFillParishText_UserCallBack(returnData210);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_MarkParishTextRead_ReturnType))
								{
									Chat_MarkParishTextRead_ReturnType returnData211 = (Chat_MarkParishTextRead_ReturnType)callBackEntryClass2.data;
									if (this.chat_MarkParishTextRead_UserCallBack != null)
									{
										this.chat_MarkParishTextRead_UserCallBack(returnData211);
									}
								}
								else if (callBackEntryClass2.classType == typeof(Chat_Admin_Command_ReturnType))
								{
									Chat_Admin_Command_ReturnType returnData212 = (Chat_Admin_Command_ReturnType)callBackEntryClass2.data;
									if (this.chat_Admin_Command_UserCallBack != null)
									{
										this.chat_Admin_Command_UserCallBack(returnData212);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetContestDataRange_ReturnType))
								{
									GetContestDataRange_ReturnType returnData213 = (GetContestDataRange_ReturnType)callBackEntryClass2.data;
									if (this.getContestDataRange_UserCallBack != null)
									{
										this.getContestDataRange_UserCallBack(returnData213);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetUserContestData_ReturnType))
								{
									GetUserContestData_ReturnType returnData214 = (GetUserContestData_ReturnType)callBackEntryClass2.data;
									if (this.getUserContestData_UserCallBack != null)
									{
										this.getUserContestData_UserCallBack(returnData214);
									}
								}
								else if (callBackEntryClass2.classType == typeof(GetContestHistoryIDs_ReturnType))
								{
									GetContestHistoryIDs_ReturnType returnData215 = (GetContestHistoryIDs_ReturnType)callBackEntryClass2.data;
									if (this.getContestHistoryIDs_UserCallBack != null)
									{
										this.getContestHistoryIDs_UserCallBack(returnData215);
									}
								}
							}
							IL_399F:
							callBackEntryClass2.data = null;
						}
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
			if (flag2)
			{
				this.resultList.Clear();
			}
			this.inResultsProcessing = false;
			if (this.queuedResultList.Count > 0)
			{
				bool flag3 = false;
				bool flag4 = true;
				foreach (object obj in this.queuedResultList)
				{
					RemoteServices.CallBackEntryClass callBackEntryClass4 = (RemoteServices.CallBackEntryClass)obj;
					int count = this.resultList.Count;
					if (flag4)
					{
						int num2;
						for (int i = 0; i < count; i = num2 + 1)
						{
							if (this.resultList[i].state == 0)
							{
								this.resultList[i] = callBackEntryClass4;
								flag3 = true;
								break;
							}
							num2 = i;
						}
					}
					if (!flag3)
					{
						flag4 = false;
						this.resultList.Add(callBackEntryClass4);
					}
					flag3 = false;
				}
				this.queuedResultList.Clear();
			}
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001ED844 File Offset: 0x001EBA44
		private bool packetTimeOut(double timeTaken, RemoteServices.CallBackEntryClass cbe)
		{
			double num = 180000.0;
			if (cbe.classType == typeof(GetVillageNames_ReturnType) || cbe.classType == typeof(GetVillageFactionChanges_ReturnType) || cbe.classType == typeof(FullTick_ReturnType) || cbe.classType == typeof(GetAllVillageOwnerFactions_ReturnType))
			{
				num = 600000.0;
			}
			return timeTaken > num;
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001ED8B4 File Offset: 0x001EBAB4
		public bool queueEmpty()
		{
			int count = this.resultList.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.resultList[i].state != 0)
				{
					return false;
				}
			}
			return this.queuedResultList.Count <= 0;
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x0001E1CE File Offset: 0x0001C3CE
		public void clearQueues()
		{
			this.resultList.Clear();
			this.queuedResultList.Clear();
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001ED900 File Offset: 0x001EBB00
		public void initChannel()
		{
			if (this.channel == null)
			{
				ServicePointManager.Expect100Continue = false;
				ServicePointManager.MaxServicePointIdleTime = 1;
				ListDictionary properties = new ListDictionary();
				BinaryClientFormatterSinkProvider binaryClientFormatterSinkProvider = new BinaryClientFormatterSinkProvider();
				ListDictionary listDictionary = new ListDictionary();
				ListDictionary providerData = new ListDictionary();
				listDictionary.Add("customSinkType", "CompressedSink.CompressedClientSink, CustomSinks");
				binaryClientFormatterSinkProvider.Next = new CustomClientSinkProvider(listDictionary, providerData);
				this.channel = new HttpChannel(properties, binaryClientFormatterSinkProvider, null);
				ChannelServices.RegisterChannel(this.channel, false);
			}
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001ED970 File Offset: 0x001EBB70
		public void init(string remotePath)
		{
			this.connectionErrored = false;
			this.clearQueues();
			this.initChannel();
			this.service = (IService)Activator.GetObject(typeof(IService), remotePath);
			IDictionary channelSinkProperties = ChannelServices.GetChannelSinkProperties(this.service);
			channelSinkProperties["credentials"] = CredentialCache.DefaultCredentials;
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.MaxServicePointIdleTime = 1;
			this.chatActive = true;
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001ED9DC File Offset: 0x001EBBDC
		public void registerRPCcall(IAsyncResult RemAr, Type classType)
		{
			object obj = RemoteServices.syncLock;
			lock (obj)
			{
				if (this.SessionID == 0)
				{
					this.RTTAverageTime += 1.0;
				}
				RemoteServices.CallBackEntryClass callBackEntryClass = new RemoteServices.CallBackEntryClass();
				callBackEntryClass.ar = RemAr;
				callBackEntryClass.classType = classType;
				callBackEntryClass.data = null;
				callBackEntryClass.timer = DXTimer.GetCurrentMilliseconds();
				if (!this.inResultsProcessing)
				{
					int count = this.resultList.Count;
					bool flag = false;
					for (int i = 0; i < count; i++)
					{
						if (this.resultList[i].state == 0)
						{
							this.resultList[i] = callBackEntryClass;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.resultList.Add(callBackEntryClass);
					}
				}
				else
				{
					this.queuedResultList.Add(callBackEntryClass);
				}
			}
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EDABC File Offset: 0x001EBCBC
		public void addPacket(Type classType, int time)
		{
			RemoteServices.RTT_Log_data rtt_Log_data = new RemoteServices.RTT_Log_data();
			rtt_Log_data.packetType = classType;
			rtt_Log_data.time = time;
			this.rtt_logging.Add(rtt_Log_data);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x0001E1E6 File Offset: 0x0001C3E6
		public List<RemoteServices.RTT_Log_data> getDetailedLogging()
		{
			return this.rtt_logging;
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EDAEC File Offset: 0x001EBCEC
		public void removeRPCresult(IAsyncResult ar)
		{
			foreach (RemoteServices.CallBackEntryClass callBackEntryClass in this.resultList)
			{
				if (callBackEntryClass.state == 1 && callBackEntryClass.ar == ar)
				{
					callBackEntryClass.state = 0;
					return;
				}
			}
			foreach (object obj in this.queuedResultList)
			{
				RemoteServices.CallBackEntryClass callBackEntryClass2 = (RemoteServices.CallBackEntryClass)obj;
				if (callBackEntryClass2.state == 1 && callBackEntryClass2.ar == ar)
				{
					callBackEntryClass2.state = 0;
					break;
				}
			}
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EDBB4 File Offset: 0x001EBDB4
		public void storeRPCresult(IAsyncResult ar, Common_ReturnData resultData)
		{
			foreach (RemoteServices.CallBackEntryClass callBackEntryClass in this.resultList)
			{
				if (callBackEntryClass.state == 1 && callBackEntryClass.ar == ar)
				{
					callBackEntryClass.data = resultData;
					callBackEntryClass.state = 2;
					callBackEntryClass.timer = DXTimer.GetCurrentMilliseconds() - callBackEntryClass.timer;
					this.lastLatency = (int)callBackEntryClass.timer;
					if (this.RTTAverageCount == 0)
					{
						this.RTTAverageCount = 1;
						this.RTTAverageTime = callBackEntryClass.timer;
					}
					else
					{
						double num = this.RTTAverageTime * (double)this.RTTAverageCount;
						num += callBackEntryClass.timer;
						this.RTTAverageCount++;
						this.RTTAverageTime = num / (double)this.RTTAverageCount;
					}
					this.addPacket(callBackEntryClass.classType, (int)callBackEntryClass.timer);
					if (callBackEntryClass.timer < 1000.0)
					{
						if (this.RTTAverageShortCount == 0)
						{
							this.RTTAverageShortCount = 1;
							this.RTTAverageShortTime = callBackEntryClass.timer;
							break;
						}
						double num2 = this.RTTAverageShortTime * (double)this.RTTAverageShortCount;
						num2 += callBackEntryClass.timer;
						this.RTTAverageShortCount++;
						this.RTTAverageShortTime = num2 / (double)this.RTTAverageShortCount;
						break;
					}
					else
					{
						if (this.RTTAverageLongCount == 0)
						{
							this.RTTAverageLongCount = 1;
							this.RTTAverageLongTime = callBackEntryClass.timer;
							break;
						}
						double num3 = this.RTTAverageLongTime * (double)this.RTTAverageLongCount;
						num3 += callBackEntryClass.timer;
						this.RTTAverageLongCount++;
						this.RTTAverageLongTime = num3 / (double)this.RTTAverageLongCount;
						break;
					}
				}
			}
			foreach (object obj in this.queuedResultList)
			{
				RemoteServices.CallBackEntryClass callBackEntryClass2 = (RemoteServices.CallBackEntryClass)obj;
				if (callBackEntryClass2.state == 1 && callBackEntryClass2.ar == ar)
				{
					callBackEntryClass2.data = resultData;
					callBackEntryClass2.state = 2;
					callBackEntryClass2.timer = DXTimer.GetCurrentMilliseconds() - callBackEntryClass2.timer;
					if (this.RTTAverageCount == 0)
					{
						this.RTTAverageCount = 1;
						this.RTTAverageTime = callBackEntryClass2.timer;
					}
					else
					{
						double num4 = this.RTTAverageTime * (double)this.RTTAverageCount;
						num4 += callBackEntryClass2.timer;
						this.RTTAverageCount++;
						this.RTTAverageTime = num4 / (double)this.RTTAverageCount;
					}
					this.addPacket(callBackEntryClass2.classType, (int)callBackEntryClass2.timer);
					if (callBackEntryClass2.timer < 1000.0)
					{
						if (this.RTTAverageShortCount == 0)
						{
							this.RTTAverageShortCount = 1;
							this.RTTAverageShortTime = callBackEntryClass2.timer;
							break;
						}
						double num5 = this.RTTAverageShortTime * (double)this.RTTAverageShortCount;
						num5 += callBackEntryClass2.timer;
						this.RTTAverageShortCount++;
						this.RTTAverageShortTime = num5 / (double)this.RTTAverageShortCount;
						break;
					}
					else
					{
						if (this.RTTAverageLongCount == 0)
						{
							this.RTTAverageLongCount = 1;
							this.RTTAverageLongTime = callBackEntryClass2.timer;
							break;
						}
						double num6 = this.RTTAverageLongTime * (double)this.RTTAverageLongCount;
						num6 += callBackEntryClass2.timer;
						this.RTTAverageLongTime += 1.0;
						this.RTTAverageLongTime = num6 / (double)this.RTTAverageLongCount;
						break;
					}
				}
			}
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001EDF58 File Offset: 0x001EC158
		private void manageRemoteExpection(IAsyncResult ar, Common_ReturnData returnData, Exception e)
		{
			if (e.GetType() == typeof(WebException))
			{
				GameEngine.Instance.connectionErrorString = e.Message + "\n" + e.ToString();
				returnData.m_errorCode = ErrorCodes.ErrorCode.CONNECTION_NO_SERVER;
				returnData.SetAsFailed();
				this.storeRPCresult(ar, returnData);
				this.connectionErrored = true;
			}
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x0001E1EE File Offset: 0x0001C3EE
		private bool isDataNotNull(object data)
		{
			return data != null;
		}

		// Token: 0x04002FF0 RID: 12272
		private static readonly RemoteServices instance = new RemoteServices();

		// Token: 0x04002FF1 RID: 12273
		private IService service;

		// Token: 0x04002FF2 RID: 12274
		private List<RemoteServices.CallBackEntryClass> resultList = new List<RemoteServices.CallBackEntryClass>();

		// Token: 0x04002FF3 RID: 12275
		private ArrayList queuedResultList = new ArrayList();

		// Token: 0x04002FF4 RID: 12276
		private bool inResultsProcessing;

		// Token: 0x04002FF5 RID: 12277
		private bool chatActive;

		// Token: 0x04002FF6 RID: 12278
		private int userID = -1;

		// Token: 0x04002FF7 RID: 12279
		private int sessionID;

		// Token: 0x04002FF8 RID: 12280
		private string username = "";

		// Token: 0x04002FF9 RID: 12281
		private string realname = "";

		// Token: 0x04002FFA RID: 12282
		private int userFactionID;

		// Token: 0x04002FFB RID: 12283
		private Guid worldGUID = Guid.Empty;

		// Token: 0x04002FFC RID: 12284
		private int profileWorldID = -1;

		// Token: 0x04002FFD RID: 12285
		private bool admin;

		// Token: 0x04002FFE RID: 12286
		private bool mapEditor;

		// Token: 0x04002FFF RID: 12287
		private bool moderator;

		// Token: 0x04003000 RID: 12288
		private bool showAdminMessage;

		// Token: 0x04003001 RID: 12289
		private bool show2ndAgeMessage;

		// Token: 0x04003002 RID: 12290
		private bool show3rdAgeMessage;

		// Token: 0x04003003 RID: 12291
		private bool show4thAgeMessage;

		// Token: 0x04003004 RID: 12292
		private bool show5thAgeMessage;

		// Token: 0x04003005 RID: 12293
		private bool show6thAgeMessage;

		// Token: 0x04003006 RID: 12294
		private bool show7thAgeMessage;

		// Token: 0x04003007 RID: 12295
		private bool boxUser;

		// Token: 0x04003008 RID: 12296
		private bool mobileWorld;

		// Token: 0x04003009 RID: 12297
		private ReportFilterList reportFilters;

		// Token: 0x0400300A RID: 12298
		private bool requiresVerification;

		// Token: 0x0400300B RID: 12299
		private LoginLeadersInfo loginLeaderInfo;

		// Token: 0x0400300C RID: 12300
		private AvatarData userAvatar = new AvatarData();

		// Token: 0x0400300D RID: 12301
		private List<int> achievements = new List<int>();

		// Token: 0x0400300E RID: 12302
		private GameOptionsData userOptions = new GameOptionsData();

		// Token: 0x0400300F RID: 12303
		private Guid userGuid = Guid.Empty;

		// Token: 0x04003010 RID: 12304
		private Guid sessionGuid = Guid.Empty;

		// Token: 0x04003011 RID: 12305
		private string webToken = "";

		// Token: 0x04003012 RID: 12306
		private AsyncCallback CreateNewUser_Callback;

		// Token: 0x04003013 RID: 12307
		private RemoteServices.CreateNewUser_UserCallBack createNewUser_UserCallBack;

		// Token: 0x04003014 RID: 12308
		private AsyncCallback LoginUser_Callback;

		// Token: 0x04003015 RID: 12309
		private RemoteServices.LoginUser_UserCallBack loginUser_UserCallBack;

		// Token: 0x04003016 RID: 12310
		private AsyncCallback LoginUserGuid_Callback;

		// Token: 0x04003017 RID: 12311
		private RemoteServices.LoginUserGuid_UserCallBack loginUserGuid_UserCallBack;

		// Token: 0x04003018 RID: 12312
		private AsyncCallback ResendVerificationEmail_Callback;

		// Token: 0x04003019 RID: 12313
		private RemoteServices.ResendVerificationEmail_UserCallBack resendVerificationEmail_UserCallBack;

		// Token: 0x0400301A RID: 12314
		private AsyncCallback GetAllVillageOwnerFactions_Callback;

		// Token: 0x0400301B RID: 12315
		private RemoteServices.GetAllVillageOwnerFactions_UserCallBack getAllVillageOwnerFactions_UserCallBack;

		// Token: 0x0400301C RID: 12316
		private int GetAllVillageOwnerFactions_Index;

		// Token: 0x0400301D RID: 12317
		public bool GetAllVillageOwnerFactions_ValidDownload;

		// Token: 0x0400301E RID: 12318
		private AsyncCallback GetVillageFactionChanges_Callback;

		// Token: 0x0400301F RID: 12319
		private RemoteServices.GetVillageFactionChanges_UserCallBack getVillageFactionChanges_UserCallBack;

		// Token: 0x04003020 RID: 12320
		private int GetVillageFactionChanges_Index;

		// Token: 0x04003021 RID: 12321
		public bool GetVillageFactionChanges_ValidDownload;

		// Token: 0x04003022 RID: 12322
		private AsyncCallback GetVillageNames_Callback;

		// Token: 0x04003023 RID: 12323
		private RemoteServices.GetVillageNames_UserCallBack getVillageNames_UserCallBack;

		// Token: 0x04003024 RID: 12324
		private int GetVillageNames_Index;

		// Token: 0x04003025 RID: 12325
		public bool GetVillageNames_ValidDownload;

		// Token: 0x04003026 RID: 12326
		private AsyncCallback GetAreaFactionChanges_Callback;

		// Token: 0x04003027 RID: 12327
		private RemoteServices.GetAreaFactionChanges_UserCallBack getAreaFactionChanges_UserCallBack;

		// Token: 0x04003028 RID: 12328
		private AsyncCallback GetUserVillages_Callback;

		// Token: 0x04003029 RID: 12329
		private RemoteServices.GetUserVillages_UserCallBack getUserVillages_UserCallBack;

		// Token: 0x0400302A RID: 12330
		private AsyncCallback GetOtherUserVillageIDList_Callback;

		// Token: 0x0400302B RID: 12331
		private RemoteServices.GetOtherUserVillageIDList_UserCallBack getOtherUserVillageIDList_UserCallBack;

		// Token: 0x0400302C RID: 12332
		private AsyncCallback BuyVillage_Callback;

		// Token: 0x0400302D RID: 12333
		private RemoteServices.BuyVillage_UserCallBack buyVillage_UserCallBack;

		// Token: 0x0400302E RID: 12334
		private AsyncCallback ConvertVillage_Callback;

		// Token: 0x0400302F RID: 12335
		private RemoteServices.ConvertVillage_UserCallBack convertVillage_UserCallBack;

		// Token: 0x04003030 RID: 12336
		private AsyncCallback FullTick_Callback;

		// Token: 0x04003031 RID: 12337
		private RemoteServices.FullTick_UserCallBack fullTick_UserCallBack;

		// Token: 0x04003032 RID: 12338
		private AsyncCallback LeaderBoard_Callback;

		// Token: 0x04003033 RID: 12339
		private RemoteServices.LeaderBoard_UserCallBack leaderBoard_UserCallBack;

		// Token: 0x04003034 RID: 12340
		private AsyncCallback LeaderBoardSearch_Callback;

		// Token: 0x04003035 RID: 12341
		private RemoteServices.LeaderBoardSearch_UserCallBack leaderBoardSearch_UserCallBack;

		// Token: 0x04003036 RID: 12342
		private AsyncCallback LogOut_Callback;

		// Token: 0x04003037 RID: 12343
		private RemoteServices.LogOut_UserCallBack logOut_UserCallBack;

		// Token: 0x04003038 RID: 12344
		private AsyncCallback GetLoginHistory_Callback;

		// Token: 0x04003039 RID: 12345
		private RemoteServices.GetLoginHistory_UserCallBack getLoginHistory_UserCallBack;

		// Token: 0x0400303A RID: 12346
		private AsyncCallback UserInfo_Callback;

		// Token: 0x0400303B RID: 12347
		private RemoteServices.UserInfo_UserCallBack userInfo_UserCallBack;

		// Token: 0x0400303C RID: 12348
		private AsyncCallback GetArmyData_Callback;

		// Token: 0x0400303D RID: 12349
		private RemoteServices.GetArmyData_UserCallBack getArmyData_UserCallBack;

		// Token: 0x0400303E RID: 12350
		private AsyncCallback ArmyAttack_Callback;

		// Token: 0x0400303F RID: 12351
		private RemoteServices.ArmyAttack_UserCallBack armyAttack_UserCallBack;

		// Token: 0x04003040 RID: 12352
		private AsyncCallback RetrieveAttackResult_Callback;

		// Token: 0x04003041 RID: 12353
		private RemoteServices.RetrieveAttackResult_UserCallBack retrieveAttackResult_UserCallBack;

		// Token: 0x04003042 RID: 12354
		private AsyncCallback SetAdminMessage_Callback;

		// Token: 0x04003043 RID: 12355
		private RemoteServices.SetAdminMessage_UserCallBack setAdminMessage_UserCallBack;

		// Token: 0x04003044 RID: 12356
		private AsyncCallback CompleteVillageCastle_Callback;

		// Token: 0x04003045 RID: 12357
		private RemoteServices.CompleteVillageCastle_UserCallBack completeVillageCastle_UserCallBack;

		// Token: 0x04003046 RID: 12358
		private AsyncCallback RetrieveStats_Callback;

		// Token: 0x04003047 RID: 12359
		private RemoteServices.RetrieveStats_UserCallBack retrieveStats_UserCallBack;

		// Token: 0x04003048 RID: 12360
		private AsyncCallback RetrieveStats2_Callback;

		// Token: 0x04003049 RID: 12361
		private RemoteServices.RetrieveStats2_UserCallBack retrieveStats2_UserCallBack;

		// Token: 0x0400304A RID: 12362
		private AsyncCallback GetAdminStats_Callback;

		// Token: 0x0400304B RID: 12363
		private RemoteServices.GetAdminStats_UserCallBack getAdminStats_UserCallBack;

		// Token: 0x0400304C RID: 12364
		private AsyncCallback GetReportsList_Callback;

		// Token: 0x0400304D RID: 12365
		private RemoteServices.GetReportsList_UserCallBack getReportsList_UserCallBack;

		// Token: 0x0400304E RID: 12366
		private AsyncCallback GetReport_Callback;

		// Token: 0x0400304F RID: 12367
		private RemoteServices.GetReport_UserCallBack getReport_UserCallBack;

		// Token: 0x04003050 RID: 12368
		private AsyncCallback ForwardReport_Callback;

		// Token: 0x04003051 RID: 12369
		private RemoteServices.ForwardReport_UserCallBack forwardReport_UserCallBack;

		// Token: 0x04003052 RID: 12370
		private AsyncCallback ViewBattle_Callback;

		// Token: 0x04003053 RID: 12371
		private RemoteServices.ViewBattle_UserCallBack viewBattle_UserCallBack;

		// Token: 0x04003054 RID: 12372
		private AsyncCallback ViewCastle_Callback;

		// Token: 0x04003055 RID: 12373
		private RemoteServices.ViewCastle_UserCallBack viewCastle_UserCallBack;

		// Token: 0x04003056 RID: 12374
		private AsyncCallback DeleteReports_Callback;

		// Token: 0x04003057 RID: 12375
		private RemoteServices.DeleteReports_UserCallBack deleteReports_UserCallBack;

		// Token: 0x04003058 RID: 12376
		private AsyncCallback UpdateReportFilters_Callback;

		// Token: 0x04003059 RID: 12377
		private RemoteServices.UpdateReportFilters_UserCallBack updateReportFilters_UserCallBack;

		// Token: 0x0400305A RID: 12378
		private AsyncCallback UpdateUserOptions_Callback;

		// Token: 0x0400305B RID: 12379
		private RemoteServices.UpdateUserOptions_UserCallBack updateUserOptions_UserCallBack;

		// Token: 0x0400305C RID: 12380
		private AsyncCallback ManageReportFolders_Callback;

		// Token: 0x0400305D RID: 12381
		private RemoteServices.ManageReportFolders_UserCallBack manageReportFolders_UserCallBack;

		// Token: 0x0400305E RID: 12382
		private AsyncCallback GetMailThreadList_Callback;

		// Token: 0x0400305F RID: 12383
		private RemoteServices.GetMailThreadList_UserCallBack getMailThreadList_UserCallBack;

		// Token: 0x04003060 RID: 12384
		private AsyncCallback GetMailThread_Callback;

		// Token: 0x04003061 RID: 12385
		private RemoteServices.GetMailThread_UserCallBack getMailThread_UserCallBack;

		// Token: 0x04003062 RID: 12386
		private AsyncCallback GetMailFolders_Callback;

		// Token: 0x04003063 RID: 12387
		private RemoteServices.GetMailFolders_UserCallBack getMailFolders_UserCallBack;

		// Token: 0x04003064 RID: 12388
		private AsyncCallback CreateMailFolder_Callback;

		// Token: 0x04003065 RID: 12389
		private RemoteServices.CreateMailFolder_UserCallBack createMailFolder_UserCallBack;

		// Token: 0x04003066 RID: 12390
		private AsyncCallback MoveToMailFolder_Callback;

		// Token: 0x04003067 RID: 12391
		private RemoteServices.MoveToMailFolder_UserCallBack moveToMailFolder_UserCallBack;

		// Token: 0x04003068 RID: 12392
		private AsyncCallback RemoveMailFolder_Callback;

		// Token: 0x04003069 RID: 12393
		private RemoteServices.RemoveMailFolder_UserCallBack removeMailFolder_UserCallBack;

		// Token: 0x0400306A RID: 12394
		private AsyncCallback ReportMail_Callback;

		// Token: 0x0400306B RID: 12395
		private RemoteServices.ReportMail_UserCallBack reportMail_UserCallBack;

		// Token: 0x0400306C RID: 12396
		private AsyncCallback FlagMailRead_Callback;

		// Token: 0x0400306D RID: 12397
		private RemoteServices.FlagMailRead_UserCallBack flagMailRead_UserCallBack;

		// Token: 0x0400306E RID: 12398
		private AsyncCallback SendMail_Callback;

		// Token: 0x0400306F RID: 12399
		private RemoteServices.SendMail_UserCallBack sendMail_UserCallBack;

		// Token: 0x04003070 RID: 12400
		private AsyncCallback SendSpecialMail_Callback;

		// Token: 0x04003071 RID: 12401
		private RemoteServices.SendSpecialMail_UserCallBack sendSpecialMail_UserCallBack;

		// Token: 0x04003072 RID: 12402
		private AsyncCallback DeleteMailThread_Callback;

		// Token: 0x04003073 RID: 12403
		private RemoteServices.DeleteMailThread_UserCallBack deleteMailThread_UserCallBack;

		// Token: 0x04003074 RID: 12404
		private AsyncCallback GetMailRecipientsHistory_Callback;

		// Token: 0x04003075 RID: 12405
		private RemoteServices.GetMailRecipientsHistory_UserCallBack getMailRecipientsHistory_UserCallBack;

		// Token: 0x04003076 RID: 12406
		private AsyncCallback GetMailUserSearch_Callback;

		// Token: 0x04003077 RID: 12407
		private RemoteServices.GetMailUserSearch_UserCallBack getMailUserSearch_UserCallBack;

		// Token: 0x04003078 RID: 12408
		private AsyncCallback AddUserToFavourites_Callback;

		// Token: 0x04003079 RID: 12409
		private RemoteServices.AddUserToFavourites_UserCallBack addUserToFavourites_UserCallBack;

		// Token: 0x0400307A RID: 12410
		private AsyncCallback GetHistoricalData_Callback;

		// Token: 0x0400307B RID: 12411
		private RemoteServices.GetHistoricalData_UserCallBack getHistoricalData_UserCallBack;

		// Token: 0x0400307C RID: 12412
		private AsyncCallback GetResourceLevel_Callback;

		// Token: 0x0400307D RID: 12413
		private RemoteServices.GetResourceLevel_UserCallBack getResourceLevel_UserCallBack;

		// Token: 0x0400307E RID: 12414
		private AsyncCallback GetVillageBuildingsList_Callback;

		// Token: 0x0400307F RID: 12415
		private RemoteServices.GetVillageBuildingsList_UserCallBack getVillageBuildingsList_UserCallBack;

		// Token: 0x04003080 RID: 12416
		private AsyncCallback PlaceVillageBuilding_Callback;

		// Token: 0x04003081 RID: 12417
		private RemoteServices.PlaceVillageBuilding_UserCallBack placeVillageBuilding_UserCallBack;

		// Token: 0x04003082 RID: 12418
		private AsyncCallback DeleteVillageBuilding_Callback;

		// Token: 0x04003083 RID: 12419
		private RemoteServices.DeleteVillageBuilding_UserCallBack deleteVillageBuilding_UserCallBack;

		// Token: 0x04003084 RID: 12420
		private AsyncCallback CancelDeleteVillageBuilding_Callback;

		// Token: 0x04003085 RID: 12421
		private RemoteServices.CancelDeleteVillageBuilding_UserCallBack cancelDeleteVillageBuilding_UserCallBack;

		// Token: 0x04003086 RID: 12422
		private AsyncCallback MoveVillageBuilding_Callback;

		// Token: 0x04003087 RID: 12423
		private RemoteServices.MoveVillageBuilding_UserCallBack moveVillageBuilding_UserCallBack;

		// Token: 0x04003088 RID: 12424
		private AsyncCallback VillageBuildingCompleteDataRetrieval_Callback;

		// Token: 0x04003089 RID: 12425
		private RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack villageBuildingCompleteDataRetrieval_UserCallBack;

		// Token: 0x0400308A RID: 12426
		private AsyncCallback VillageBuildingSetActive_Callback;

		// Token: 0x0400308B RID: 12427
		private RemoteServices.VillageBuildingSetActive_UserCallBack villageBuildingSetActive_UserCallBack;

		// Token: 0x0400308C RID: 12428
		private AsyncCallback VillageBuildingChangeRates_Callback;

		// Token: 0x0400308D RID: 12429
		private RemoteServices.VillageBuildingChangeRates_UserCallBack villageBuildingChangeRates_UserCallBack;

		// Token: 0x0400308E RID: 12430
		private AsyncCallback VillageRename_Callback;

		// Token: 0x0400308F RID: 12431
		private RemoteServices.VillageRename_UserCallBack villageRename_UserCallBack;

		// Token: 0x04003090 RID: 12432
		private AsyncCallback VillageProduceWeapons_Callback;

		// Token: 0x04003091 RID: 12433
		private RemoteServices.VillageProduceWeapons_UserCallBack villageProduceWeapons_UserCallBack;

		// Token: 0x04003092 RID: 12434
		private AsyncCallback VillageHoldBanquet_Callback;

		// Token: 0x04003093 RID: 12435
		private RemoteServices.VillageHoldBanquet_UserCallBack villageHoldBanquet_UserCallBack;

		// Token: 0x04003094 RID: 12436
		private AsyncCallback GetCastle_Callback;

		// Token: 0x04003095 RID: 12437
		private RemoteServices.GetCastle_UserCallBack getCastle_UserCallBack;

		// Token: 0x04003096 RID: 12438
		private AsyncCallback AddCastleElement_Callback;

		// Token: 0x04003097 RID: 12439
		private RemoteServices.AddCastleElement_UserCallBack addCastleElement_UserCallBack;

		// Token: 0x04003098 RID: 12440
		private AsyncCallback DeleteCastleElement_Callback;

		// Token: 0x04003099 RID: 12441
		private RemoteServices.DeleteCastleElement_UserCallBack deleteCastleElement_UserCallBack;

		// Token: 0x0400309A RID: 12442
		private AsyncCallback ChangeCastleElementAggressiveDefender_Callback;

		// Token: 0x0400309B RID: 12443
		private RemoteServices.ChangeCastleElementAggressiveDefender_UserCallBack changeCastleElementAggressiveDefender_UserCallBack;

		// Token: 0x0400309C RID: 12444
		private AsyncCallback AutoRepairCastle_Callback;

		// Token: 0x0400309D RID: 12445
		private RemoteServices.AutoRepairCastle_UserCallBack autoRepairCastle_UserCallBack;

		// Token: 0x0400309E RID: 12446
		private AsyncCallback MemorizeCastleTroops_Callback;

		// Token: 0x0400309F RID: 12447
		private RemoteServices.MemorizeCastleTroops_UserCallBack memorizeCastleTroops_UserCallBack;

		// Token: 0x040030A0 RID: 12448
		private AsyncCallback RestoreCastleTroops_Callback;

		// Token: 0x040030A1 RID: 12449
		private RemoteServices.RestoreCastleTroops_UserCallBack restoreCastleTroops_UserCallBack;

		// Token: 0x040030A2 RID: 12450
		private AsyncCallback CheatAddTroops_Callback;

		// Token: 0x040030A3 RID: 12451
		private RemoteServices.CheatAddTroops_UserCallBack cheatAddTroops_UserCallBack;

		// Token: 0x040030A4 RID: 12452
		private AsyncCallback LaunchCastleAttack_Callback;

		// Token: 0x040030A5 RID: 12453
		private RemoteServices.LaunchCastleAttack_UserCallBack launchCastleAttack_UserCallBack;

		// Token: 0x040030A6 RID: 12454
		private AsyncCallback SendScouts_Callback;

		// Token: 0x040030A7 RID: 12455
		private RemoteServices.SendScouts_UserCallBack sendScouts_UserCallBack;

		// Token: 0x040030A8 RID: 12456
		private AsyncCallback CancelCastleAttack_Callback;

		// Token: 0x040030A9 RID: 12457
		private RemoteServices.CancelCastleAttack_UserCallBack cancelCastleAttack_UserCallBack;

		// Token: 0x040030AA RID: 12458
		private AsyncCallback SendReinforcements_Callback;

		// Token: 0x040030AB RID: 12459
		private RemoteServices.SendReinforcements_UserCallBack sendReinforcements_UserCallBack;

		// Token: 0x040030AC RID: 12460
		private AsyncCallback ReturnReinforcements_Callback;

		// Token: 0x040030AD RID: 12461
		private RemoteServices.ReturnReinforcements_UserCallBack returnReinforcements_UserCallBack;

		// Token: 0x040030AE RID: 12462
		private AsyncCallback SendMarketResources_Callback;

		// Token: 0x040030AF RID: 12463
		private RemoteServices.SendMarketResources_UserCallBack sendMarketResources_UserCallBack;

		// Token: 0x040030B0 RID: 12464
		private AsyncCallback GetUserTraders_Callback;

		// Token: 0x040030B1 RID: 12465
		private RemoteServices.GetUserTraders_UserCallBack getUserTraders_UserCallBack;

		// Token: 0x040030B2 RID: 12466
		private AsyncCallback GetActiveTraders_Callback;

		// Token: 0x040030B3 RID: 12467
		private RemoteServices.GetActiveTraders_UserCallBack getActiveTraders_UserCallBack;

		// Token: 0x040030B4 RID: 12468
		private AsyncCallback GetStockExchangeData_Callback;

		// Token: 0x040030B5 RID: 12469
		private RemoteServices.GetStockExchangeData_UserCallBack getStockExchangeData_UserCallBack;

		// Token: 0x040030B6 RID: 12470
		private AsyncCallback StockExchangeTrade_Callback;

		// Token: 0x040030B7 RID: 12471
		private RemoteServices.StockExchangeTrade_UserCallBack stockExchangeTrade_UserCallBack;

		// Token: 0x040030B8 RID: 12472
		private AsyncCallback UpdateVillageFavourites_Callback;

		// Token: 0x040030B9 RID: 12473
		private RemoteServices.UpdateVillageFavourites_UserCallBack updateVillageFavourites_UserCallBack;

		// Token: 0x040030BA RID: 12474
		private AsyncCallback MakeTroop_Callback;

		// Token: 0x040030BB RID: 12475
		private RemoteServices.MakeTroop_UserCallBack makeTroop_UserCallBack;

		// Token: 0x040030BC RID: 12476
		private AsyncCallback UpgradeRank_Callback;

		// Token: 0x040030BD RID: 12477
		private RemoteServices.UpgradeRank_UserCallBack upgradeRank_UserCallBack;

		// Token: 0x040030BE RID: 12478
		private AsyncCallback PreAttackSetup_Callback;

		// Token: 0x040030BF RID: 12479
		private RemoteServices.PreAttackSetup_UserCallBack preAttackSetup_UserCallBack;

		// Token: 0x040030C0 RID: 12480
		private AsyncCallback GetBattleHonourRating_Callback;

		// Token: 0x040030C1 RID: 12481
		private RemoteServices.GetBattleHonourRating_UserCallBack getBattleHonourRating_UserCallBack;

		// Token: 0x040030C2 RID: 12482
		private AsyncCallback RetrieveArmyFromGarrison_Callback;

		// Token: 0x040030C3 RID: 12483
		private RemoteServices.RetrieveArmyFromGarrison_UserCallBack retrieveArmyFromGarrison_UserCallBack;

		// Token: 0x040030C4 RID: 12484
		private AsyncCallback RetrieveVillageUserInfo_Callback;

		// Token: 0x040030C5 RID: 12485
		private RemoteServices.RetrieveVillageUserInfo_UserCallBack retrieveVillageUserInfo_UserCallBack;

		// Token: 0x040030C6 RID: 12486
		private AsyncCallback SpecialVillageInfo_Callback;

		// Token: 0x040030C7 RID: 12487
		private RemoteServices.SpecialVillageInfo_UserCallBack specialVillageInfo_UserCallBack;

		// Token: 0x040030C8 RID: 12488
		private AsyncCallback GetVillageRankTaxTree_Callback;

		// Token: 0x040030C9 RID: 12489
		private RemoteServices.GetVillageRankTaxTree_UserCallBack getVillageRankTaxTree_UserCallBack;

		// Token: 0x040030CA RID: 12490
		private AsyncCallback GetResearchData_Callback;

		// Token: 0x040030CB RID: 12491
		private RemoteServices.GetResearchData_UserCallBack getResearchData_UserCallBack;

		// Token: 0x040030CC RID: 12492
		private AsyncCallback DoResearch_Callback;

		// Token: 0x040030CD RID: 12493
		private RemoteServices.DoResearch_UserCallBack doResearch_UserCallBack;

		// Token: 0x040030CE RID: 12494
		private AsyncCallback BuyResearchPoint_Callback;

		// Token: 0x040030CF RID: 12495
		private RemoteServices.BuyResearchPoint_UserCallBack buyResearchPoint_UserCallBack;

		// Token: 0x040030D0 RID: 12496
		private AsyncCallback VassalInfo_Callback;

		// Token: 0x040030D1 RID: 12497
		private RemoteServices.VassalInfo_UserCallBack vassalInfo_UserCallBack;

		// Token: 0x040030D2 RID: 12498
		private AsyncCallback VassalSendResources_Callback;

		// Token: 0x040030D3 RID: 12499
		private RemoteServices.VassalSendResources_UserCallBack vassalSendResources_UserCallBack;

		// Token: 0x040030D4 RID: 12500
		private AsyncCallback UpdateSelectedTitheType_Callback;

		// Token: 0x040030D5 RID: 12501
		private RemoteServices.UpdateSelectedTitheType_UserCallBack updateSelectedTitheType_UserCallBack;

		// Token: 0x040030D6 RID: 12502
		private AsyncCallback BreakVassalage_Callback;

		// Token: 0x040030D7 RID: 12503
		private RemoteServices.BreakVassalage_UserCallBack breakVassalage_UserCallBack;

		// Token: 0x040030D8 RID: 12504
		private AsyncCallback BreakLiegeLord_Callback;

		// Token: 0x040030D9 RID: 12505
		private RemoteServices.BreakLiegeLord_UserCallBack breakLiegeLord_UserCallBack;

		// Token: 0x040030DA RID: 12506
		private AsyncCallback GetPreVassalInfo_Callback;

		// Token: 0x040030DB RID: 12507
		private RemoteServices.GetPreVassalInfo_UserCallBack getPreVassalInfo_UserCallBack;

		// Token: 0x040030DC RID: 12508
		private AsyncCallback SendVassalRequest_Callback;

		// Token: 0x040030DD RID: 12509
		private RemoteServices.SendVassalRequest_UserCallBack sendVassalRequest_UserCallBack;

		// Token: 0x040030DE RID: 12510
		private AsyncCallback HandleVassalRequest_Callback;

		// Token: 0x040030DF RID: 12511
		private RemoteServices.HandleVassalRequest_UserCallBack handleVassalRequest_UserCallBack;

		// Token: 0x040030E0 RID: 12512
		private AsyncCallback GetVassalArmyInfo_Callback;

		// Token: 0x040030E1 RID: 12513
		private RemoteServices.GetVassalArmyInfo_UserCallBack getVassalArmyInfo_UserCallBack;

		// Token: 0x040030E2 RID: 12514
		private AsyncCallback SendTroopsToVassal_Callback;

		// Token: 0x040030E3 RID: 12515
		private RemoteServices.SendTroopsToVassal_UserCallBack sendTroopsToVassal_UserCallBack;

		// Token: 0x040030E4 RID: 12516
		private AsyncCallback RetrieveTroopsFromVassal_Callback;

		// Token: 0x040030E5 RID: 12517
		private RemoteServices.RetrieveTroopsFromVassal_UserCallBack retrieveTroopsFromVassal_UserCallBack;

		// Token: 0x040030E6 RID: 12518
		private AsyncCallback UpdateVillageResourcesInfo_Callback;

		// Token: 0x040030E7 RID: 12519
		private RemoteServices.UpdateVillageResourcesInfo_UserCallBack updateVillageResourcesInfo_UserCallBack;

		// Token: 0x040030E8 RID: 12520
		private AsyncCallback SetHighestArmySeen_Callback;

		// Token: 0x040030E9 RID: 12521
		private RemoteServices.SetHighestArmySeen_UserCallBack setHighestArmySeen_UserCallBack;

		// Token: 0x040030EA RID: 12522
		private AsyncCallback GetForumList_Callback;

		// Token: 0x040030EB RID: 12523
		private RemoteServices.GetForumList_UserCallBack getForumList_UserCallBack;

		// Token: 0x040030EC RID: 12524
		private AsyncCallback GetForumThreadList_Callback;

		// Token: 0x040030ED RID: 12525
		private RemoteServices.GetForumThreadList_UserCallBack getForumThreadList_UserCallBack;

		// Token: 0x040030EE RID: 12526
		private AsyncCallback GetForumThread_Callback;

		// Token: 0x040030EF RID: 12527
		private RemoteServices.GetForumThread_UserCallBack getForumThread_UserCallBack;

		// Token: 0x040030F0 RID: 12528
		private AsyncCallback NewForumThread_Callback;

		// Token: 0x040030F1 RID: 12529
		private RemoteServices.NewForumThread_UserCallBack newForumThread_UserCallBack;

		// Token: 0x040030F2 RID: 12530
		private AsyncCallback PostToForumThread_Callback;

		// Token: 0x040030F3 RID: 12531
		private RemoteServices.PostToForumThread_UserCallBack postToForumThread_UserCallBack;

		// Token: 0x040030F4 RID: 12532
		private AsyncCallback GiveForumAccess_Callback;

		// Token: 0x040030F5 RID: 12533
		private RemoteServices.GiveForumAccess_UserCallBack giveForumAccess_UserCallBack;

		// Token: 0x040030F6 RID: 12534
		private AsyncCallback CreateForum_Callback;

		// Token: 0x040030F7 RID: 12535
		private RemoteServices.CreateForum_UserCallBack createForum_UserCallBack;

		// Token: 0x040030F8 RID: 12536
		private AsyncCallback DeleteForum_Callback;

		// Token: 0x040030F9 RID: 12537
		private RemoteServices.DeleteForum_UserCallBack deleteForum_UserCallBack;

		// Token: 0x040030FA RID: 12538
		private AsyncCallback DeleteForumThread_Callback;

		// Token: 0x040030FB RID: 12539
		private RemoteServices.DeleteForumThread_UserCallBack deleteForumThread_UserCallBack;

		// Token: 0x040030FC RID: 12540
		private AsyncCallback DeleteForumPost_Callback;

		// Token: 0x040030FD RID: 12541
		private RemoteServices.DeleteForumPost_UserCallBack deleteForumPost_UserCallBack;

		// Token: 0x040030FE RID: 12542
		private AsyncCallback GetCurrentElectionInfo_Callback;

		// Token: 0x040030FF RID: 12543
		private RemoteServices.GetCurrentElectionInfo_UserCallBack getCurrentElectionInfo_UserCallBack;

		// Token: 0x04003100 RID: 12544
		private AsyncCallback StandInElection_Callback;

		// Token: 0x04003101 RID: 12545
		private RemoteServices.StandInElection_UserCallBack standInElection_UserCallBack;

		// Token: 0x04003102 RID: 12546
		private AsyncCallback VoteInElection_Callback;

		// Token: 0x04003103 RID: 12547
		private RemoteServices.VoteInElection_UserCallBack voteInElection_UserCallBack;

		// Token: 0x04003104 RID: 12548
		private AsyncCallback UploadAvatar_Callback;

		// Token: 0x04003105 RID: 12549
		private RemoteServices.UploadAvatar_UserCallBack uploadAvatar_UserCallBack;

		// Token: 0x04003106 RID: 12550
		private AsyncCallback MakePeople_Callback;

		// Token: 0x04003107 RID: 12551
		private RemoteServices.MakePeople_UserCallBack makePeople_UserCallBack;

		// Token: 0x04003108 RID: 12552
		private AsyncCallback GetUserPeople_Callback;

		// Token: 0x04003109 RID: 12553
		private RemoteServices.GetUserPeople_UserCallBack getUserPeople_UserCallBack;

		// Token: 0x0400310A RID: 12554
		private AsyncCallback GetUserIDFromName_Callback;

		// Token: 0x0400310B RID: 12555
		private RemoteServices.GetUserIDFromName_UserCallBack getUserIDFromName_UserCallBack;

		// Token: 0x0400310C RID: 12556
		private AsyncCallback GetActivePeople_Callback;

		// Token: 0x0400310D RID: 12557
		private RemoteServices.GetActivePeople_UserCallBack getActivePeople_UserCallBack;

		// Token: 0x0400310E RID: 12558
		private AsyncCallback SendPeople_Callback;

		// Token: 0x0400310F RID: 12559
		private RemoteServices.SendPeople_UserCallBack sendPeople_UserCallBack;

		// Token: 0x04003110 RID: 12560
		private AsyncCallback RetrievePeople_Callback;

		// Token: 0x04003111 RID: 12561
		private RemoteServices.RetrievePeople_UserCallBack retrievePeople_UserCallBack;

		// Token: 0x04003112 RID: 12562
		private AsyncCallback SpyCommand_Callback;

		// Token: 0x04003113 RID: 12563
		private RemoteServices.SpyCommand_UserCallBack spyCommand_UserCallBack;

		// Token: 0x04003114 RID: 12564
		private AsyncCallback SpyGetVillageResourceInfo_Callback;

		// Token: 0x04003115 RID: 12565
		private RemoteServices.SpyGetVillageResourceInfo_UserCallBack spyGetVillageResourceInfo_UserCallBack;

		// Token: 0x04003116 RID: 12566
		private AsyncCallback SpyGetArmyInfo_Callback;

		// Token: 0x04003117 RID: 12567
		private RemoteServices.SpyGetArmyInfo_UserCallBack spyGetArmyInfo_UserCallBack;

		// Token: 0x04003118 RID: 12568
		private AsyncCallback SpyGetResearchInfo_Callback;

		// Token: 0x04003119 RID: 12569
		private RemoteServices.SpyGetResearchInfo_UserCallBack spyGetResearchInfo_UserCallBack;

		// Token: 0x0400311A RID: 12570
		private AsyncCallback CreateFaction_Callback;

		// Token: 0x0400311B RID: 12571
		private RemoteServices.CreateFaction_UserCallBack createFaction_UserCallBack;

		// Token: 0x0400311C RID: 12572
		private AsyncCallback DisbandFaction_Callback;

		// Token: 0x0400311D RID: 12573
		private RemoteServices.DisbandFaction_UserCallBack disbandFaction_UserCallBack;

		// Token: 0x0400311E RID: 12574
		private AsyncCallback FactionSendInvite_Callback;

		// Token: 0x0400311F RID: 12575
		private RemoteServices.FactionSendInvite_UserCallBack factionSendInvite_UserCallBack;

		// Token: 0x04003120 RID: 12576
		private AsyncCallback FactionWithdrawInvite_Callback;

		// Token: 0x04003121 RID: 12577
		private RemoteServices.FactionWithdrawInvite_UserCallBack factionWithdrawInvite_UserCallBack;

		// Token: 0x04003122 RID: 12578
		private AsyncCallback FactionReplyToInvite_Callback;

		// Token: 0x04003123 RID: 12579
		private RemoteServices.FactionReplyToInvite_UserCallBack factionReplyToInvite_UserCallBack;

		// Token: 0x04003124 RID: 12580
		private AsyncCallback FactionChangeMemberStatus_Callback;

		// Token: 0x04003125 RID: 12581
		private RemoteServices.FactionChangeMemberStatus_UserCallBack factionChangeMemberStatus_UserCallBack;

		// Token: 0x04003126 RID: 12582
		private AsyncCallback FactionLeave_Callback;

		// Token: 0x04003127 RID: 12583
		private RemoteServices.FactionLeave_UserCallBack factionLeave_UserCallBack;

		// Token: 0x04003128 RID: 12584
		private AsyncCallback GetFactionData_Callback;

		// Token: 0x04003129 RID: 12585
		private RemoteServices.GetFactionData_UserCallBack getFactionData_UserCallBack;

		// Token: 0x0400312A RID: 12586
		private AsyncCallback CreateUserRelationship_Callback;

		// Token: 0x0400312B RID: 12587
		private RemoteServices.CreateUserRelationship_UserCallBack createUserRelationship_UserCallBack;

		// Token: 0x0400312C RID: 12588
		private AsyncCallback SetUserMarker_Callback;

		// Token: 0x0400312D RID: 12589
		private RemoteServices.SetUserMarker_UserCallBack setUserMarker_UserCallBack;

		// Token: 0x0400312E RID: 12590
		private AsyncCallback CreateFactionRelationship_Callback;

		// Token: 0x0400312F RID: 12591
		private RemoteServices.CreateFactionRelationship_UserCallBack createFactionRelationship_UserCallBack;

		// Token: 0x04003130 RID: 12592
		private AsyncCallback CreateHouseRelationship_Callback;

		// Token: 0x04003131 RID: 12593
		private RemoteServices.CreateHouseRelationship_UserCallBack createHouseRelationship_UserCallBack;

		// Token: 0x04003132 RID: 12594
		private AsyncCallback GetHouseGloryPoints_Callback;

		// Token: 0x04003133 RID: 12595
		private RemoteServices.GetHouseGloryPoints_UserCallBack getHouseGloryPoints_UserCallBack;

		// Token: 0x04003134 RID: 12596
		private AsyncCallback ChangeFactionMotto_Callback;

		// Token: 0x04003135 RID: 12597
		private RemoteServices.ChangeFactionMotto_UserCallBack changeFactionMotto_UserCallBack;

		// Token: 0x04003136 RID: 12598
		private AsyncCallback FactionLeadershipVote_Callback;

		// Token: 0x04003137 RID: 12599
		private RemoteServices.FactionLeadershipVote_UserCallBack factionLeadershipVote_UserCallBack;

		// Token: 0x04003138 RID: 12600
		private AsyncCallback GetViewFactionData_Callback;

		// Token: 0x04003139 RID: 12601
		private RemoteServices.GetViewFactionData_UserCallBack getViewFactionData_UserCallBack;

		// Token: 0x0400313A RID: 12602
		private AsyncCallback GetViewHouseData_Callback;

		// Token: 0x0400313B RID: 12603
		private RemoteServices.GetViewHouseData_UserCallBack getViewHouseData_UserCallBack;

		// Token: 0x0400313C RID: 12604
		private AsyncCallback SelfJoinHouse_Callback;

		// Token: 0x0400313D RID: 12605
		private RemoteServices.SelfJoinHouse_UserCallBack selfJoinHouse_UserCallBack;

		// Token: 0x0400313E RID: 12606
		private AsyncCallback HouseVote_Callback;

		// Token: 0x0400313F RID: 12607
		private RemoteServices.HouseVote_UserCallBack houseVote_UserCallBack;

		// Token: 0x04003140 RID: 12608
		private AsyncCallback HouseVoteHouseLeader_Callback;

		// Token: 0x04003141 RID: 12609
		private RemoteServices.HouseVoteHouseLeader_UserCallBack houseVoteHouseLeader_UserCallBack;

		// Token: 0x04003142 RID: 12610
		private AsyncCallback TouchHouseVisitDate_Callback;

		// Token: 0x04003143 RID: 12611
		private RemoteServices.TouchHouseVisitDate_UserCallBack touchHouseVisitDate_UserCallBack;

		// Token: 0x04003144 RID: 12612
		private AsyncCallback LeaveHouse_Callback;

		// Token: 0x04003145 RID: 12613
		private RemoteServices.LeaveHouse_UserCallBack leaveHouse_UserCallBack;

		// Token: 0x04003146 RID: 12614
		private AsyncCallback FactionApplication_Callback;

		// Token: 0x04003147 RID: 12615
		private RemoteServices.FactionApplication_UserCallBack factionApplication_UserCallBack;

		// Token: 0x04003148 RID: 12616
		private AsyncCallback FactionApplicationProcessing_Callback;

		// Token: 0x04003149 RID: 12617
		private RemoteServices.FactionApplicationProcessing_UserCallBack factionApplicationProcessing_UserCallBack;

		// Token: 0x0400314A RID: 12618
		private AsyncCallback GetParishMembersList_Callback;

		// Token: 0x0400314B RID: 12619
		private RemoteServices.GetParishMembersList_UserCallBack getParishMembersList_UserCallBack;

		// Token: 0x0400314C RID: 12620
		private AsyncCallback GetParishFrontPageInfo_Callback;

		// Token: 0x0400314D RID: 12621
		private RemoteServices.GetParishFrontPageInfo_UserCallBack getParishFrontPageInfo_UserCallBack;

		// Token: 0x0400314E RID: 12622
		private AsyncCallback ParishWallDetailInfo_Callback;

		// Token: 0x0400314F RID: 12623
		private RemoteServices.ParishWallDetailInfo_UserCallBack parishWallDetailInfo_UserCallBack;

		// Token: 0x04003150 RID: 12624
		private AsyncCallback StandDownAsParishDespot_Callback;

		// Token: 0x04003151 RID: 12625
		private RemoteServices.StandDownAsParishDespot_UserCallBack standDownAsParishDespot_UserCallBack;

		// Token: 0x04003152 RID: 12626
		private AsyncCallback MakeParishVote_Callback;

		// Token: 0x04003153 RID: 12627
		private RemoteServices.MakeParishVote_UserCallBack makeParishVote_UserCallBack;

		// Token: 0x04003154 RID: 12628
		private AsyncCallback SendTroopsToCapital_Callback;

		// Token: 0x04003155 RID: 12629
		private RemoteServices.SendTroopsToCapital_UserCallBack sendTroopsToCapital_UserCallBack;

		// Token: 0x04003156 RID: 12630
		private AsyncCallback GetCapitalBarracksSpace_Callback;

		// Token: 0x04003157 RID: 12631
		private RemoteServices.GetCapitalBarracksSpace_UserCallBack getCapitalBarracksSpace_UserCallBack;

		// Token: 0x04003158 RID: 12632
		private AsyncCallback GetCountyElectionInfo_Callback;

		// Token: 0x04003159 RID: 12633
		private RemoteServices.GetCountyElectionInfo_UserCallBack getCountyElectionInfo_UserCallBack;

		// Token: 0x0400315A RID: 12634
		private AsyncCallback GetCountyFrontPageInfo_Callback;

		// Token: 0x0400315B RID: 12635
		private RemoteServices.GetCountyFrontPageInfo_UserCallBack getCountyFrontPageInfo_UserCallBack;

		// Token: 0x0400315C RID: 12636
		private AsyncCallback MakeCountyVote_Callback;

		// Token: 0x0400315D RID: 12637
		private RemoteServices.MakeCountyVote_UserCallBack makeCountyVote_UserCallBack;

		// Token: 0x0400315E RID: 12638
		private AsyncCallback GetProvinceElectionInfo_Callback;

		// Token: 0x0400315F RID: 12639
		private RemoteServices.GetProvinceElectionInfo_UserCallBack getProvinceElectionInfo_UserCallBack;

		// Token: 0x04003160 RID: 12640
		private AsyncCallback GetProvinceFrontPageInfo_Callback;

		// Token: 0x04003161 RID: 12641
		private RemoteServices.GetProvinceFrontPageInfo_UserCallBack getProvinceFrontPageInfo_UserCallBack;

		// Token: 0x04003162 RID: 12642
		private AsyncCallback MakeProvinceVote_Callback;

		// Token: 0x04003163 RID: 12643
		private RemoteServices.MakeProvinceVote_UserCallBack makeProvinceVote_UserCallBack;

		// Token: 0x04003164 RID: 12644
		private AsyncCallback GetCountryElectionInfo_Callback;

		// Token: 0x04003165 RID: 12645
		private RemoteServices.GetCountryElectionInfo_UserCallBack getCountryElectionInfo_UserCallBack;

		// Token: 0x04003166 RID: 12646
		private AsyncCallback GetCountryFrontPageInfo_Callback;

		// Token: 0x04003167 RID: 12647
		private RemoteServices.GetCountryFrontPageInfo_UserCallBack getCountryFrontPageInfo_UserCallBack;

		// Token: 0x04003168 RID: 12648
		private AsyncCallback MakeCountryVote_Callback;

		// Token: 0x04003169 RID: 12649
		private RemoteServices.MakeCountryVote_UserCallBack makeCountryVote_UserCallBack;

		// Token: 0x0400316A RID: 12650
		private AsyncCallback GetIngameMessage_Callback;

		// Token: 0x0400316B RID: 12651
		private RemoteServices.GetIngameMessage_UserCallBack getIngameMessage_UserCallBack;

		// Token: 0x0400316C RID: 12652
		private AsyncCallback CancelInterdiction_Callback;

		// Token: 0x0400316D RID: 12653
		private RemoteServices.CancelInterdiction_UserCallBack cancelInterdiction_UserCallBack;

		// Token: 0x0400316E RID: 12654
		private AsyncCallback GetExcommunicationStatus_Callback;

		// Token: 0x0400316F RID: 12655
		private RemoteServices.GetExcommunicationStatus_UserCallBack getExcommunicationStatus_UserCallBack;

		// Token: 0x04003170 RID: 12656
		private AsyncCallback DisbandTroops_Callback;

		// Token: 0x04003171 RID: 12657
		private RemoteServices.DisbandTroops_UserCallBack disbandTroops_UserCallBack;

		// Token: 0x04003172 RID: 12658
		private AsyncCallback DisbandPeople_Callback;

		// Token: 0x04003173 RID: 12659
		private RemoteServices.DisbandPeople_UserCallBack disbandPeople_UserCallBack;

		// Token: 0x04003174 RID: 12660
		private AsyncCallback GetVillageInfoForDonateCapitalGoods_Callback;

		// Token: 0x04003175 RID: 12661
		private RemoteServices.GetVillageInfoForDonateCapitalGoods_UserCallBack getVillageInfoForDonateCapitalGoods_UserCallBack;

		// Token: 0x04003176 RID: 12662
		private AsyncCallback DonateCapitalGoods_Callback;

		// Token: 0x04003177 RID: 12663
		private RemoteServices.DonateCapitalGoods_UserCallBack donateCapitalGoods_UserCallBack;

		// Token: 0x04003178 RID: 12664
		private AsyncCallback GetVillageStartLocations_Callback;

		// Token: 0x04003179 RID: 12665
		private RemoteServices.GetVillageStartLocations_UserCallBack getVillageStartLocations_UserCallBack;

		// Token: 0x0400317A RID: 12666
		private AsyncCallback SetStartingCounty_Callback;

		// Token: 0x0400317B RID: 12667
		private RemoteServices.SetStartingCounty_UserCallBack setStartingCounty_UserCallBack;

		// Token: 0x0400317C RID: 12668
		private AsyncCallback CancelCard_Callback;

		// Token: 0x0400317D RID: 12669
		private RemoteServices.CancelCard_UserCallBack cancelCard_UserCallBack;

		// Token: 0x0400317E RID: 12670
		private AsyncCallback UpdateCurrentCards_Callback;

		// Token: 0x0400317F RID: 12671
		private RemoteServices.UpdateCurrentCards_UserCallBack updateCurrentCards_UserCallBack;

		// Token: 0x04003180 RID: 12672
		private AsyncCallback TutorialCommand_Callback;

		// Token: 0x04003181 RID: 12673
		private RemoteServices.TutorialCommand_UserCallBack tutorialCommand_UserCallBack;

		// Token: 0x04003182 RID: 12674
		private AsyncCallback GetQuestStatus_Callback;

		// Token: 0x04003183 RID: 12675
		private RemoteServices.GetQuestStatus_UserCallBack getQuestStatus_UserCallBack;

		// Token: 0x04003184 RID: 12676
		private AsyncCallback CompleteQuest_Callback;

		// Token: 0x04003185 RID: 12677
		private RemoteServices.CompleteQuest_UserCallBack completeQuest_UserCallBack;

		// Token: 0x04003186 RID: 12678
		private AsyncCallback FlagQuestObjectiveComplete_Callback;

		// Token: 0x04003187 RID: 12679
		private RemoteServices.FlagQuestObjectiveComplete_UserCallBack flagQuestObjectiveComplete_UserCallBack;

		// Token: 0x04003188 RID: 12680
		private AsyncCallback CheckQuestObjectiveComplete_Callback;

		// Token: 0x04003189 RID: 12681
		private RemoteServices.CheckQuestObjectiveComplete_UserCallBack checkQuestObjectiveComplete_UserCallBack;

		// Token: 0x0400318A RID: 12682
		private AsyncCallback UpdateDiplomacyStatus_Callback;

		// Token: 0x0400318B RID: 12683
		private RemoteServices.UpdateDiplomacyStatus_UserCallBack updateDiplomacyStatus_UserCallBack;

		// Token: 0x0400318C RID: 12684
		private AsyncCallback SendCommands_Callback;

		// Token: 0x0400318D RID: 12685
		private RemoteServices.SendCommands_UserCallBack sendCommands_UserCallBack;

		// Token: 0x0400318E RID: 12686
		private AsyncCallback InitialiseFreeCards_Callback;

		// Token: 0x0400318F RID: 12687
		private RemoteServices.InitialiseFreeCards_UserCallBack initialiseFreeCards_UserCallBack;

		// Token: 0x04003190 RID: 12688
		private AsyncCallback TestAchievements_Callback;

		// Token: 0x04003191 RID: 12689
		private RemoteServices.TestAchievements_UserCallBack testAchievements_UserCallBack;

		// Token: 0x04003192 RID: 12690
		private AsyncCallback AchievementProgress_Callback;

		// Token: 0x04003193 RID: 12691
		private RemoteServices.AchievementProgress_UserCallBack achievementProgress_UserCallBack;

		// Token: 0x04003194 RID: 12692
		private AsyncCallback GetQuestData_Callback;

		// Token: 0x04003195 RID: 12693
		private RemoteServices.GetQuestData_UserCallBack getQuestData_UserCallBack;

		// Token: 0x04003196 RID: 12694
		private AsyncCallback StartNewQuest_Callback;

		// Token: 0x04003197 RID: 12695
		private RemoteServices.StartNewQuest_UserCallBack startNewQuest_UserCallBack;

		// Token: 0x04003198 RID: 12696
		private AsyncCallback CompleteAbandonNewQuest_Callback;

		// Token: 0x04003199 RID: 12697
		private RemoteServices.CompleteAbandonNewQuest_UserCallBack completeAbandonNewQuest_UserCallBack;

		// Token: 0x0400319A RID: 12698
		private AsyncCallback SpinTheWheel_Callback;

		// Token: 0x0400319B RID: 12699
		private RemoteServices.SpinTheWheel_UserCallBack spinTheWheel_UserCallBack;

		// Token: 0x0400319C RID: 12700
		private AsyncCallback SetVacationMode_Callback;

		// Token: 0x0400319D RID: 12701
		private RemoteServices.SetVacationMode_UserCallBack setVacationMode_UserCallBack;

		// Token: 0x0400319E RID: 12702
		private AsyncCallback PremiumOverview_Callback;

		// Token: 0x0400319F RID: 12703
		private RemoteServices.PremiumOverview_UserCallBack premiumOverview_UserCallBack;

		// Token: 0x040031A0 RID: 12704
		private AsyncCallback GetLastAttacker_Callback;

		// Token: 0x040031A1 RID: 12705
		private RemoteServices.GetLastAttacker_UserCallBack getLastAttacker_UserCallBack;

		// Token: 0x040031A2 RID: 12706
		private AsyncCallback PreValidateCardToBePlayed_Callback;

		// Token: 0x040031A3 RID: 12707
		private RemoteServices.PreValidateCardToBePlayed_UserCallBack preValidateCardToBePlayed_UserCallBack;

		// Token: 0x040031A4 RID: 12708
		private AsyncCallback GetInvasionInfo_Callback;

		// Token: 0x040031A5 RID: 12709
		private RemoteServices.GetInvasionInfo_UserCallBack getInvasionInfo_UserCallBack;

		// Token: 0x040031A6 RID: 12710
		private AsyncCallback WorldInfo_Callback;

		// Token: 0x040031A7 RID: 12711
		private RemoteServices.WorldInfo_UserCallBack worldInfo_UserCallBack;

		// Token: 0x040031A8 RID: 12712
		private AsyncCallback EndWorld_Callback;

		// Token: 0x040031A9 RID: 12713
		private RemoteServices.EndWorld_UserCallBack endWorld_UserCallBack;

		// Token: 0x040031AA RID: 12714
		private AsyncCallback EndOfTheWorldStats_Callback;

		// Token: 0x040031AB RID: 12715
		private RemoteServices.EndOfTheWorldStats_UserCallBack endOfTheWorldStats_UserCallBack;

		// Token: 0x040031AC RID: 12716
		private AsyncCallback GetKillStreakData_Callback;

		// Token: 0x040031AD RID: 12717
		private RemoteServices.GetKillStreakData_UserCallBack getKillStreakData_UserCallBack;

		// Token: 0x040031AE RID: 12718
		private AsyncCallback GetUserContestData_Callback;

		// Token: 0x040031AF RID: 12719
		private RemoteServices.GetUserContestData_UserCallBack getUserContestData_UserCallBack;

		// Token: 0x040031B0 RID: 12720
		private AsyncCallback GetContestDataRange_Callback;

		// Token: 0x040031B1 RID: 12721
		private RemoteServices.GetContestDataRange_UserCallBack getContestDataRange_UserCallBack;

		// Token: 0x040031B2 RID: 12722
		private AsyncCallback GetContestHistoryIDs_Callback;

		// Token: 0x040031B3 RID: 12723
		private RemoteServices.GetContestHistoryIDs_UserCallBack getContestHistoryIDs_UserCallBack;

		// Token: 0x040031B4 RID: 12724
		private AsyncCallback Chat_Login_Callback;

		// Token: 0x040031B5 RID: 12725
		private RemoteServices.Chat_Login_UserCallBack chat_Login_UserCallBack;

		// Token: 0x040031B6 RID: 12726
		private AsyncCallback Chat_Logout_Callback;

		// Token: 0x040031B7 RID: 12727
		private RemoteServices.Chat_Logout_UserCallBack chat_Logout_UserCallBack;

		// Token: 0x040031B8 RID: 12728
		private AsyncCallback Chat_SetReceivingState_Callback;

		// Token: 0x040031B9 RID: 12729
		private RemoteServices.Chat_SetReceivingState_UserCallBack chat_SetReceivingState_UserCallBack;

		// Token: 0x040031BA RID: 12730
		private AsyncCallback Chat_SendText_Callback;

		// Token: 0x040031BB RID: 12731
		private RemoteServices.Chat_SendText_UserCallBack chat_SendText_UserCallBack;

		// Token: 0x040031BC RID: 12732
		private AsyncCallback Chat_ReceiveText_Callback;

		// Token: 0x040031BD RID: 12733
		private RemoteServices.Chat_ReceiveText_UserCallBack chat_ReceiveText_UserCallBack;

		// Token: 0x040031BE RID: 12734
		private AsyncCallback Chat_SendParishText_Callback;

		// Token: 0x040031BF RID: 12735
		private RemoteServices.Chat_SendParishText_UserCallBack chat_SendParishText_UserCallBack;

		// Token: 0x040031C0 RID: 12736
		private AsyncCallback Chat_ReceiveParishText_Callback;

		// Token: 0x040031C1 RID: 12737
		private RemoteServices.Chat_ReceiveParishText_UserCallBack chat_ReceiveParishText_UserCallBack;

		// Token: 0x040031C2 RID: 12738
		private AsyncCallback Chat_BackFillParishText_Callback;

		// Token: 0x040031C3 RID: 12739
		private RemoteServices.Chat_BackFillParishText_UserCallBack chat_BackFillParishText_UserCallBack;

		// Token: 0x040031C4 RID: 12740
		private AsyncCallback Chat_MarkParishTextRead_Callback;

		// Token: 0x040031C5 RID: 12741
		private RemoteServices.Chat_MarkParishTextRead_UserCallBack chat_MarkParishTextRead_UserCallBack;

		// Token: 0x040031C6 RID: 12742
		private AsyncCallback Chat_Admin_Command_Callback;

		// Token: 0x040031C7 RID: 12743
		private RemoteServices.Chat_Admin_Command_UserCallBack chat_Admin_Command_UserCallBack;

		// Token: 0x040031C8 RID: 12744
		private RemoteServices.CommonData_UserCallBack commonData_UserCallBack;

		// Token: 0x040031C9 RID: 12745
		private bool connectionErrored;

		// Token: 0x040031CA RID: 12746
		private int consecutiveTimeOuts;

		// Token: 0x040031CB RID: 12747
		private HttpChannel channel;

		// Token: 0x040031CC RID: 12748
		private static object syncLock = new object();

		// Token: 0x040031CD RID: 12749
		public double RTTAverageTime;

		// Token: 0x040031CE RID: 12750
		public int RTTAverageCount;

		// Token: 0x040031CF RID: 12751
		public double RTTAverageShortTime;

		// Token: 0x040031D0 RID: 12752
		public int RTTAverageShortCount;

		// Token: 0x040031D1 RID: 12753
		public double RTTAverageLongTime;

		// Token: 0x040031D2 RID: 12754
		public int RTTAverageLongCount;

		// Token: 0x040031D3 RID: 12755
		public int RTTTimeOuts;

		// Token: 0x040031D4 RID: 12756
		public List<RemoteServices.RTT_Log_data> rtt_logging = new List<RemoteServices.RTT_Log_data>();

		// Token: 0x040031D5 RID: 12757
		public int lastLatency;

		// Token: 0x020002B8 RID: 696
		private class CallBackEntryClass
		{
			// Token: 0x040031D6 RID: 12758
			public IAsyncResult ar;

			// Token: 0x040031D7 RID: 12759
			public Type classType;

			// Token: 0x040031D8 RID: 12760
			public Common_ReturnData data;

			// Token: 0x040031D9 RID: 12761
			public int state = 1;

			// Token: 0x040031DA RID: 12762
			public double timer;
		}

		// Token: 0x020002B9 RID: 697
		// (Invoke) Token: 0x0600220B RID: 8715
		public delegate CreateNewUser_ReturnType RemoteAsyncDelegate_CreateNewUser(string username, string password, string realname, string emailaddress, int versionNo, string securityString);

		// Token: 0x020002BA RID: 698
		// (Invoke) Token: 0x0600220F RID: 8719
		public delegate void CreateNewUser_UserCallBack(CreateNewUser_ReturnType returnData);

		// Token: 0x020002BB RID: 699
		// (Invoke) Token: 0x06002213 RID: 8723
		public delegate LoginUser_ReturnType RemoteAsyncDelegate_LoginUser(string username, string password, int versionNo, string verificationString, bool needVillageData);

		// Token: 0x020002BC RID: 700
		// (Invoke) Token: 0x06002217 RID: 8727
		public delegate void LoginUser_UserCallBack(LoginUser_ReturnType returnData);

		// Token: 0x020002BD RID: 701
		// (Invoke) Token: 0x0600221B RID: 8731
		public delegate LoginUserGuid_ReturnType RemoteAsyncDelegate_LoginUserGuid(string userName, string userGuid, string sessionGuid, bool needVillageData, int versionID);

		// Token: 0x020002BE RID: 702
		// (Invoke) Token: 0x0600221F RID: 8735
		public delegate void LoginUserGuid_UserCallBack(LoginUserGuid_ReturnType returnData);

		// Token: 0x020002BF RID: 703
		// (Invoke) Token: 0x06002223 RID: 8739
		public delegate ResendVerificationEmail_ReturnType RemoteAsyncDelegate_ResendVerificationEmail(string username, string password);

		// Token: 0x020002C0 RID: 704
		// (Invoke) Token: 0x06002227 RID: 8743
		public delegate void ResendVerificationEmail_UserCallBack(ResendVerificationEmail_ReturnType returnData);

		// Token: 0x020002C1 RID: 705
		// (Invoke) Token: 0x0600222B RID: 8747
		public delegate GetAllVillageOwnerFactions_ReturnType RemoteAsyncDelegate_GetAllVillageOwnerFactions(int userID, int sessionID, int sendIndex);

		// Token: 0x020002C2 RID: 706
		// (Invoke) Token: 0x0600222F RID: 8751
		public delegate void GetAllVillageOwnerFactions_UserCallBack(GetAllVillageOwnerFactions_ReturnType returnData);

		// Token: 0x020002C3 RID: 707
		// (Invoke) Token: 0x06002233 RID: 8755
		public delegate GetVillageFactionChanges_ReturnType RemoteAsyncDelegate_GetVillageFactionChanges(int userID, int sessionID, long startChangePos, long factionsChangePos, int sendIndex);

		// Token: 0x020002C4 RID: 708
		// (Invoke) Token: 0x06002237 RID: 8759
		public delegate void GetVillageFactionChanges_UserCallBack(GetVillageFactionChanges_ReturnType returnData);

		// Token: 0x020002C5 RID: 709
		// (Invoke) Token: 0x0600223B RID: 8763
		public delegate GetVillageNames_ReturnType RemoteAsyncDelegate_GetVillageNames(int userID, int sessionID, long currentPos, int sendIndex);

		// Token: 0x020002C6 RID: 710
		// (Invoke) Token: 0x0600223F RID: 8767
		public delegate void GetVillageNames_UserCallBack(GetVillageNames_ReturnType returnData);

		// Token: 0x020002C7 RID: 711
		// (Invoke) Token: 0x06002243 RID: 8771
		public delegate GetAreaFactionChanges_ReturnType RemoteAsyncDelegate_GetAreaFactionChanges(int userID, int sessionID, long regionStartPos, long countyStartPos, long provinceStartPos, long countryStartPos, long parishFlagsPos, long countyFlagsPos, long provinceFlagsPos, long countryFlagsPos);

		// Token: 0x020002C8 RID: 712
		// (Invoke) Token: 0x06002247 RID: 8775
		public delegate void GetAreaFactionChanges_UserCallBack(GetAreaFactionChanges_ReturnType returnData);

		// Token: 0x020002C9 RID: 713
		// (Invoke) Token: 0x0600224B RID: 8779
		public delegate GetUserVillages_ReturnType RemoteAsyncDelegate_GetUserVillages(int userID, int sessionID);

		// Token: 0x020002CA RID: 714
		// (Invoke) Token: 0x0600224F RID: 8783
		public delegate void GetUserVillages_UserCallBack(GetUserVillages_ReturnType returnData);

		// Token: 0x020002CB RID: 715
		// (Invoke) Token: 0x06002253 RID: 8787
		public delegate GetOtherUserVillageIDList_ReturnType RemoteAsyncDelegate_GetOtherUserVillageIDList(int userID, string userName, int sessionID);

		// Token: 0x020002CC RID: 716
		// (Invoke) Token: 0x06002257 RID: 8791
		public delegate void GetOtherUserVillageIDList_UserCallBack(GetOtherUserVillageIDList_ReturnType returnData);

		// Token: 0x020002CD RID: 717
		// (Invoke) Token: 0x0600225B RID: 8795
		public delegate BuyVillage_ReturnType RemoteAsyncDelegate_BuyVillage(int userID, int sessionID, int fromVillageID, int villageID, int mapType, long startChangePos, bool peaceTime);

		// Token: 0x020002CE RID: 718
		// (Invoke) Token: 0x0600225F RID: 8799
		public delegate void BuyVillage_UserCallBack(BuyVillage_ReturnType returnData);

		// Token: 0x020002CF RID: 719
		// (Invoke) Token: 0x06002263 RID: 8803
		public delegate ConvertVillage_ReturnType RemoteAsyncDelegate_ConvertVillage(int userID, int sessionID, int villageID, int mapType);

		// Token: 0x020002D0 RID: 720
		// (Invoke) Token: 0x06002267 RID: 8807
		public delegate void ConvertVillage_UserCallBack(ConvertVillage_ReturnType returnData);

		// Token: 0x020002D1 RID: 721
		// (Invoke) Token: 0x0600226B RID: 8811
		public delegate FullTick_ReturnType RemoteAsyncDelegate_FullTick(int userID, int sessionID, long startChangePos, long regionStartPos, long countyStartPos, long provinceStartPos, long countryStartPos, bool registerSession, long villageNamePos, long factionsChangePos, DateTime lastTraderTime, DateTime lastPeopleTime, long parishFlagsPos, long countyFlagsPos, long provinceFlagsPos, long countryFlagsPos, long highestArmyID, int mode, bool fullMode);

		// Token: 0x020002D2 RID: 722
		// (Invoke) Token: 0x0600226F RID: 8815
		public delegate void FullTick_UserCallBack(FullTick_ReturnType returnData);

		// Token: 0x020002D3 RID: 723
		// (Invoke) Token: 0x06002273 RID: 8819
		public delegate LeaderBoard_ReturnType RemoteAsyncDelegate_LeaderBoard(int userID, int sessionID, int mode, int minValue, int maxValue, DateTime lastUpdate);

		// Token: 0x020002D4 RID: 724
		// (Invoke) Token: 0x06002277 RID: 8823
		public delegate void LeaderBoard_UserCallBack(LeaderBoard_ReturnType returnData);

		// Token: 0x020002D5 RID: 725
		// (Invoke) Token: 0x0600227B RID: 8827
		public delegate LeaderBoardSearch_ReturnType RemoteAsyncDelegate_LeaderBoardSearch(int userID, int sessionID, int category, string searchString, DateTime lastUpdate);

		// Token: 0x020002D6 RID: 726
		// (Invoke) Token: 0x0600227F RID: 8831
		public delegate void LeaderBoardSearch_UserCallBack(LeaderBoardSearch_ReturnType returnData);

		// Token: 0x020002D7 RID: 727
		// (Invoke) Token: 0x06002283 RID: 8835
		public delegate LogOut_ReturnType RemoteAsyncDelegate_LogOut(int userID, int sessionID, bool manual, bool autoScout, bool autoTrade, bool autoAttack, bool autoAttackWolf, bool autoAttackBandit, bool autoAttackAI, int resourceType, int percent, bool autoRecruit, bool autoRecruitPeasant, bool autoRecruitArchers, bool autoRecruitPikemen, bool autoRecruitSwordsmen, bool autoRecruitCatapults, int autoRecruitPeasant_Cap, int autoRecruitArchers_Cap, int autoRecruitPikemen_Cap, int autoRecruitSwordsmen_Cap, int autoRecruitCatapults_Cap);

		// Token: 0x020002D8 RID: 728
		// (Invoke) Token: 0x06002287 RID: 8839
		public delegate void LogOut_UserCallBack(LogOut_ReturnType returnData);

		// Token: 0x020002D9 RID: 729
		// (Invoke) Token: 0x0600228B RID: 8843
		public delegate GetLoginHistory_ReturnType RemoteAsyncDelegate_GetLoginHistory(int userID, int sessionID);

		// Token: 0x020002DA RID: 730
		// (Invoke) Token: 0x0600228F RID: 8847
		public delegate void GetLoginHistory_UserCallBack(GetLoginHistory_ReturnType returnData);

		// Token: 0x020002DB RID: 731
		// (Invoke) Token: 0x06002293 RID: 8851
		public delegate UserInfo_ReturnType RemoteAsyncDelegate_UserInfo(int userID, int sessionID, int requestUserID);

		// Token: 0x020002DC RID: 732
		// (Invoke) Token: 0x06002297 RID: 8855
		public delegate void UserInfo_UserCallBack(UserInfo_ReturnType returnData);

		// Token: 0x020002DD RID: 733
		// (Invoke) Token: 0x0600229B RID: 8859
		public delegate GetArmyData_ReturnType RemoteAsyncDelegate_GetArmyData(int userID, int sessionID, long highestSeendID);

		// Token: 0x020002DE RID: 734
		// (Invoke) Token: 0x0600229F RID: 8863
		public delegate void GetArmyData_UserCallBack(GetArmyData_ReturnType returnData);

		// Token: 0x020002DF RID: 735
		// (Invoke) Token: 0x060022A3 RID: 8867
		public delegate ArmyAttack_ReturnType RemoteAsyncDelegate_ArmyAttack(int userID, int sessionID, int armyID, int targetVillage, int attackType);

		// Token: 0x020002E0 RID: 736
		// (Invoke) Token: 0x060022A7 RID: 8871
		public delegate void ArmyAttack_UserCallBack(ArmyAttack_ReturnType returnData);

		// Token: 0x020002E1 RID: 737
		// (Invoke) Token: 0x060022AB RID: 8875
		public delegate RetrieveAttackResult_ReturnType RemoteAsyncDelegate_RetrieveAttackResult(int userID, int sessionID, long armyID, long startChangePos);

		// Token: 0x020002E2 RID: 738
		// (Invoke) Token: 0x060022AF RID: 8879
		public delegate void RetrieveAttackResult_UserCallBack(RetrieveAttackResult_ReturnType returnData);

		// Token: 0x020002E3 RID: 739
		// (Invoke) Token: 0x060022B3 RID: 8883
		public delegate SetAdminMessage_ReturnType RemoteAsyncDelegate_SetAdminMessage(int userID, int sessionID, string message, int type);

		// Token: 0x020002E4 RID: 740
		// (Invoke) Token: 0x060022B7 RID: 8887
		public delegate void SetAdminMessage_UserCallBack(SetAdminMessage_ReturnType returnData);

		// Token: 0x020002E5 RID: 741
		// (Invoke) Token: 0x060022BB RID: 8891
		public delegate CompleteVillageCastle_ReturnType RemoteAsyncDelegate_CompleteVillageCastle(int userID, int sessionID, int villageID, int mode);

		// Token: 0x020002E6 RID: 742
		// (Invoke) Token: 0x060022BF RID: 8895
		public delegate void CompleteVillageCastle_UserCallBack(CompleteVillageCastle_ReturnType returnData);

		// Token: 0x020002E7 RID: 743
		// (Invoke) Token: 0x060022C3 RID: 8899
		public delegate RetrieveStats_ReturnType RemoteAsyncDelegate_RetrieveStats(int userID, int sessionID);

		// Token: 0x020002E8 RID: 744
		// (Invoke) Token: 0x060022C7 RID: 8903
		public delegate void RetrieveStats_UserCallBack(RetrieveStats_ReturnType returnData);

		// Token: 0x020002E9 RID: 745
		// (Invoke) Token: 0x060022CB RID: 8907
		public delegate RetrieveStats2_ReturnType RemoteAsyncDelegate_RetrieveStats2(int userID, int sessionID);

		// Token: 0x020002EA RID: 746
		// (Invoke) Token: 0x060022CF RID: 8911
		public delegate void RetrieveStats2_UserCallBack(RetrieveStats2_ReturnType returnData);

		// Token: 0x020002EB RID: 747
		// (Invoke) Token: 0x060022D3 RID: 8915
		public delegate GetAdminStats_ReturnType RemoteAsyncDelegate_GetAdminStats(int userID, int sessionID);

		// Token: 0x020002EC RID: 748
		// (Invoke) Token: 0x060022D7 RID: 8919
		public delegate void GetAdminStats_UserCallBack(GetAdminStats_ReturnType returnData);

		// Token: 0x020002ED RID: 749
		// (Invoke) Token: 0x060022DB RID: 8923
		public delegate GetReportsList_ReturnType RemoteAsyncDelegate_GetReportsList(int userID, int sessionID, int readFilter, int[] typeFilters, long folderID, long clientHighest);

		// Token: 0x020002EE RID: 750
		// (Invoke) Token: 0x060022DF RID: 8927
		public delegate void GetReportsList_UserCallBack(GetReportsList_ReturnType returnData);

		// Token: 0x020002EF RID: 751
		// (Invoke) Token: 0x060022E3 RID: 8931
		public delegate GetReport_ReturnType RemoteAsyncDelegate_GetReport(int userID, int sessionID, long reportID);

		// Token: 0x020002F0 RID: 752
		// (Invoke) Token: 0x060022E7 RID: 8935
		public delegate void GetReport_UserCallBack(GetReport_ReturnType returnData);

		// Token: 0x020002F1 RID: 753
		// (Invoke) Token: 0x060022EB RID: 8939
		public delegate ForwardReport_ReturnType RemoteAsyncDelegate_ForwardReport(int userID, int sessionID, long reportID, string[] recipients);

		// Token: 0x020002F2 RID: 754
		// (Invoke) Token: 0x060022EF RID: 8943
		public delegate void ForwardReport_UserCallBack(ForwardReport_ReturnType returnData);

		// Token: 0x020002F3 RID: 755
		// (Invoke) Token: 0x060022F3 RID: 8947
		public delegate ViewBattle_ReturnType RemoteAsyncDelegate_ViewBattle(int userID, int sessionID, long reportID);

		// Token: 0x020002F4 RID: 756
		// (Invoke) Token: 0x060022F7 RID: 8951
		public delegate void ViewBattle_UserCallBack(ViewBattle_ReturnType returnData);

		// Token: 0x020002F5 RID: 757
		// (Invoke) Token: 0x060022FB RID: 8955
		public delegate ViewCastle_ReturnType RemoteAsyncDelegate_ViewCastle(int userID, int sessionID, int villageID, long reportID);

		// Token: 0x020002F6 RID: 758
		// (Invoke) Token: 0x060022FF RID: 8959
		public delegate void ViewCastle_UserCallBack(ViewCastle_ReturnType returnData);

		// Token: 0x020002F7 RID: 759
		// (Invoke) Token: 0x06002303 RID: 8963
		public delegate DeleteReports_ReturnType RemoteAsyncDelegate_DeleteReports(int userID, int sessionID, int mode, long[] reportsToDelete, long folderID);

		// Token: 0x020002F8 RID: 760
		// (Invoke) Token: 0x06002307 RID: 8967
		public delegate void DeleteReports_UserCallBack(DeleteReports_ReturnType returnData);

		// Token: 0x020002F9 RID: 761
		// (Invoke) Token: 0x0600230B RID: 8971
		public delegate UpdateReportFilters_ReturnType RemoteAsyncDelegate_UpdateReportFilters(int userID, int sessionID, ReportFilterList filters);

		// Token: 0x020002FA RID: 762
		// (Invoke) Token: 0x0600230F RID: 8975
		public delegate void UpdateReportFilters_UserCallBack(UpdateReportFilters_ReturnType returnData);

		// Token: 0x020002FB RID: 763
		// (Invoke) Token: 0x06002313 RID: 8979
		public delegate UpdateUserOptions_ReturnType RemoteAsyncDelegate_UpdateUserOptions(int userID, int sessionID, GameOptionsData options);

		// Token: 0x020002FC RID: 764
		// (Invoke) Token: 0x06002317 RID: 8983
		public delegate void UpdateUserOptions_UserCallBack(UpdateUserOptions_ReturnType returnData);

		// Token: 0x020002FD RID: 765
		// (Invoke) Token: 0x0600231B RID: 8987
		public delegate ManageReportFolders_ReturnType RemoteAsyncDelegate_ManageReportFolders(int userID, int sessionID, int mode, long folderID, string groupNames);

		// Token: 0x020002FE RID: 766
		// (Invoke) Token: 0x0600231F RID: 8991
		public delegate void ManageReportFolders_UserCallBack(ManageReportFolders_ReturnType returnData);

		// Token: 0x020002FF RID: 767
		// (Invoke) Token: 0x06002323 RID: 8995
		public delegate GetMailThreadList_ReturnType RemoteAsyncDelegate_GetMailThreadList(int userID, int sessionID, bool initialRequest, int retrieveMode, DateTime lastRetrieved);

		// Token: 0x02000300 RID: 768
		// (Invoke) Token: 0x06002327 RID: 8999
		public delegate void GetMailThreadList_UserCallBack(GetMailThreadList_ReturnType returnData);

		// Token: 0x02000301 RID: 769
		// (Invoke) Token: 0x0600232B RID: 9003
		public delegate GetMailThread_ReturnType RemoteAsyncDelegate_GetMailThread(int userID, int sessionID, long threadID, int localCount, long highestSegmentID);

		// Token: 0x02000302 RID: 770
		// (Invoke) Token: 0x0600232F RID: 9007
		public delegate void GetMailThread_UserCallBack(GetMailThread_ReturnType returnData);

		// Token: 0x02000303 RID: 771
		// (Invoke) Token: 0x06002333 RID: 9011
		public delegate GetMailFolders_ReturnType RemoteAsyncDelegate_GetMailFolders(int userID, int sessionID);

		// Token: 0x02000304 RID: 772
		// (Invoke) Token: 0x06002337 RID: 9015
		public delegate void GetMailFolders_UserCallBack(GetMailFolders_ReturnType returnData);

		// Token: 0x02000305 RID: 773
		// (Invoke) Token: 0x0600233B RID: 9019
		public delegate CreateMailFolder_ReturnType RemoteAsyncDelegate_CreateMailFolder(int userID, int sessionID, string folderName);

		// Token: 0x02000306 RID: 774
		// (Invoke) Token: 0x0600233F RID: 9023
		public delegate void CreateMailFolder_UserCallBack(CreateMailFolder_ReturnType returnData);

		// Token: 0x02000307 RID: 775
		// (Invoke) Token: 0x06002343 RID: 9027
		public delegate MoveToMailFolder_ReturnType RemoteAsyncDelegate_MoveToMailFolder(int userID, int sessionID, long threadID, long folderID);

		// Token: 0x02000308 RID: 776
		// (Invoke) Token: 0x06002347 RID: 9031
		public delegate void MoveToMailFolder_UserCallBack(MoveToMailFolder_ReturnType returnData);

		// Token: 0x02000309 RID: 777
		// (Invoke) Token: 0x0600234B RID: 9035
		public delegate RemoveMailFolder_ReturnType RemoteAsyncDelegate_RemoveMailFolder(int userID, int sessionID, long folderID);

		// Token: 0x0200030A RID: 778
		// (Invoke) Token: 0x0600234F RID: 9039
		public delegate void RemoveMailFolder_UserCallBack(RemoveMailFolder_ReturnType returnData);

		// Token: 0x0200030B RID: 779
		// (Invoke) Token: 0x06002353 RID: 9043
		public delegate ReportMail_ReturnType RemoteAsyncDelegate_ReportMail(int userID, int sessionID, long mailID, long threadID, string reason, string summary);

		// Token: 0x0200030C RID: 780
		// (Invoke) Token: 0x06002357 RID: 9047
		public delegate void ReportMail_UserCallBack(ReportMail_ReturnType returnData);

		// Token: 0x0200030D RID: 781
		// (Invoke) Token: 0x0600235B RID: 9051
		public delegate FlagMailRead_ReturnType RemoteAsyncDelegate_FlagMailRead(int userID, int sessionID, long mailID, long threadID, bool asRead);

		// Token: 0x0200030E RID: 782
		// (Invoke) Token: 0x0600235F RID: 9055
		public delegate void FlagMailRead_UserCallBack(FlagMailRead_ReturnType returnData);

		// Token: 0x0200030F RID: 783
		// (Invoke) Token: 0x06002363 RID: 9059
		public delegate SendMail_ReturnType RemoteAsyncDelegate_SendMail(int userID, int sessionID, string subject, string body, string[] recipients, long threadID, bool forwardThread);

		// Token: 0x02000310 RID: 784
		// (Invoke) Token: 0x06002367 RID: 9063
		public delegate void SendMail_UserCallBack(SendMail_ReturnType returnData);

		// Token: 0x02000311 RID: 785
		// (Invoke) Token: 0x0600236B RID: 9067
		public delegate SendSpecialMail_ReturnType RemoteAsyncDelegate_SendSpecialMail(int userID, int sessionID, int mailType, int area, string subject, string body);

		// Token: 0x02000312 RID: 786
		// (Invoke) Token: 0x0600236F RID: 9071
		public delegate void SendSpecialMail_UserCallBack(SendSpecialMail_ReturnType returnData);

		// Token: 0x02000313 RID: 787
		// (Invoke) Token: 0x06002373 RID: 9075
		public delegate DeleteMailThread_ReturnType RemoteAsyncDelegate_DeleteMailThread(int userID, int sessionID, long threadID);

		// Token: 0x02000314 RID: 788
		// (Invoke) Token: 0x06002377 RID: 9079
		public delegate void DeleteMailThread_UserCallBack(DeleteMailThread_ReturnType returnData);

		// Token: 0x02000315 RID: 789
		// (Invoke) Token: 0x0600237B RID: 9083
		public delegate GetMailRecipientsHistory_ReturnType RemoteAsyncDelegate_GetMailRecipientsHistory(int userID, int sessionID);

		// Token: 0x02000316 RID: 790
		// (Invoke) Token: 0x0600237F RID: 9087
		public delegate void GetMailRecipientsHistory_UserCallBack(GetMailRecipientsHistory_ReturnType returnData);

		// Token: 0x02000317 RID: 791
		// (Invoke) Token: 0x06002383 RID: 9091
		public delegate GetMailUserSearch_ReturnType RemoteAsyncDelegate_GetMailUserSearch(int userID, int sessionID, string filter);

		// Token: 0x02000318 RID: 792
		// (Invoke) Token: 0x06002387 RID: 9095
		public delegate void GetMailUserSearch_UserCallBack(GetMailUserSearch_ReturnType returnData);

		// Token: 0x02000319 RID: 793
		// (Invoke) Token: 0x0600238B RID: 9099
		public delegate AddUserToFavourites_ReturnType RemoteAsyncDelegate_AddUserToFavourites(int userID, int sessionID, string userName, bool doRemove);

		// Token: 0x0200031A RID: 794
		// (Invoke) Token: 0x0600238F RID: 9103
		public delegate void AddUserToFavourites_UserCallBack(AddUserToFavourites_ReturnType returnData);

		// Token: 0x0200031B RID: 795
		// (Invoke) Token: 0x06002393 RID: 9107
		public delegate GetHistoricalData_ReturnType RemoteAsyncDelegate_GetHistoricalData(int userID, int sessionID);

		// Token: 0x0200031C RID: 796
		// (Invoke) Token: 0x06002397 RID: 9111
		public delegate void GetHistoricalData_UserCallBack(GetHistoricalData_ReturnType returnData);

		// Token: 0x0200031D RID: 797
		// (Invoke) Token: 0x0600239B RID: 9115
		public delegate GetResourceLevel_ReturnType RemoteAsyncDelegate_GetResourceLevel(int userID, int sessionID, int villageID, int buildingType);

		// Token: 0x0200031E RID: 798
		// (Invoke) Token: 0x0600239F RID: 9119
		public delegate void GetResourceLevel_UserCallBack(GetResourceLevel_ReturnType returnData);

		// Token: 0x0200031F RID: 799
		// (Invoke) Token: 0x060023A3 RID: 9123
		public delegate GetVillageBuildingsList_ReturnType RemoteAsyncDelegate_GetVillageBuildingsList(int userID, int sessionID, int villageID, bool fullUpdate, bool viewOnly, bool needParishPeople);

		// Token: 0x02000320 RID: 800
		// (Invoke) Token: 0x060023A7 RID: 9127
		public delegate void GetVillageBuildingsList_UserCallBack(GetVillageBuildingsList_ReturnType returnData);

		// Token: 0x02000321 RID: 801
		// (Invoke) Token: 0x060023AB RID: 9131
		public delegate PlaceVillageBuilding_ReturnType RemoteAsyncDelegate_PlaceVillageBuilding(int userID, int sessionID, int villageID, int buildingType, Point buildingLocation);

		// Token: 0x02000322 RID: 802
		// (Invoke) Token: 0x060023AF RID: 9135
		public delegate void PlaceVillageBuilding_UserCallBack(PlaceVillageBuilding_ReturnType returnData);

		// Token: 0x02000323 RID: 803
		// (Invoke) Token: 0x060023B3 RID: 9139
		public delegate DeleteVillageBuilding_ReturnType RemoteAsyncDelegate_DeleteVillageBuilding(int userID, int sessionID, int villageID, long buildingID);

		// Token: 0x02000324 RID: 804
		// (Invoke) Token: 0x060023B7 RID: 9143
		public delegate void DeleteVillageBuilding_UserCallBack(DeleteVillageBuilding_ReturnType returnData);

		// Token: 0x02000325 RID: 805
		// (Invoke) Token: 0x060023BB RID: 9147
		public delegate CancelDeleteVillageBuilding_ReturnType RemoteAsyncDelegate_CancelDeleteVillageBuilding(int userID, int sessionID, int villageID, long buildingID);

		// Token: 0x02000326 RID: 806
		// (Invoke) Token: 0x060023BF RID: 9151
		public delegate void CancelDeleteVillageBuilding_UserCallBack(CancelDeleteVillageBuilding_ReturnType returnData);

		// Token: 0x02000327 RID: 807
		// (Invoke) Token: 0x060023C3 RID: 9155
		public delegate MoveVillageBuilding_ReturnType RemoteAsyncDelegate_MoveVillageBuilding(int userID, int sessionID, int villageID, long buildingID, Point buildingLocation);

		// Token: 0x02000328 RID: 808
		// (Invoke) Token: 0x060023C7 RID: 9159
		public delegate void MoveVillageBuilding_UserCallBack(MoveVillageBuilding_ReturnType returnData);

		// Token: 0x02000329 RID: 809
		// (Invoke) Token: 0x060023CB RID: 9163
		public delegate VillageBuildingCompleteDataRetrieval_ReturnType RemoteAsyncDelegate_VillageBuildingCompleteDataRetrieval(int userID, int sessionID, int villageID, long buildingID, int mode);

		// Token: 0x0200032A RID: 810
		// (Invoke) Token: 0x060023CF RID: 9167
		public delegate void VillageBuildingCompleteDataRetrieval_UserCallBack(VillageBuildingCompleteDataRetrieval_ReturnType returnData);

		// Token: 0x0200032B RID: 811
		// (Invoke) Token: 0x060023D3 RID: 9171
		public delegate VillageBuildingSetActive_ReturnType RemoteAsyncDelegate_VillageBuildingSetActive(int userID, int sessionID, long buildingID, int villageID, int buildingType, bool state);

		// Token: 0x0200032C RID: 812
		// (Invoke) Token: 0x060023D7 RID: 9175
		public delegate void VillageBuildingSetActive_UserCallBack(VillageBuildingSetActive_ReturnType returnData);

		// Token: 0x0200032D RID: 813
		// (Invoke) Token: 0x060023DB RID: 9179
		public delegate VillageBuildingChangeRates_ReturnType RemoteAsyncDelegate_VillageBuildingChangeRates(int userID, int sessionID, int villageID, int taxLevel, int rationsLevel, int aleRationsLevel, int capitalTaxRate);

		// Token: 0x0200032E RID: 814
		// (Invoke) Token: 0x060023DF RID: 9183
		public delegate void VillageBuildingChangeRates_UserCallBack(VillageBuildingChangeRates_ReturnType returnData);

		// Token: 0x0200032F RID: 815
		// (Invoke) Token: 0x060023E3 RID: 9187
		public delegate VillageRename_ReturnType RemoteAsyncDelegate_VillageRename(int userID, int sessionID, int villageID, string villageName, bool abandon, bool modReset);

		// Token: 0x02000330 RID: 816
		// (Invoke) Token: 0x060023E7 RID: 9191
		public delegate void VillageRename_UserCallBack(VillageRename_ReturnType returnData);

		// Token: 0x02000331 RID: 817
		// (Invoke) Token: 0x060023EB RID: 9195
		public delegate VillageProduceWeapons_ReturnType RemoteAsyncDelegate_VillageProduceWeapons(int userID, int sessionID, int villageID, int weaponType, int amount);

		// Token: 0x02000332 RID: 818
		// (Invoke) Token: 0x060023EF RID: 9199
		public delegate void VillageProduceWeapons_UserCallBack(VillageProduceWeapons_ReturnType returnData);

		// Token: 0x02000333 RID: 819
		// (Invoke) Token: 0x060023F3 RID: 9203
		public delegate VillageHoldBanquet_ReturnType RemoteAsyncDelegate_VillageHoldBanquet(int userID, int sessionID, int villageID, int venison, int wine, int salt, int spice, int silk, int clothing, int furniture, int metalwork);

		// Token: 0x02000334 RID: 820
		// (Invoke) Token: 0x060023F7 RID: 9207
		public delegate void VillageHoldBanquet_UserCallBack(VillageHoldBanquet_ReturnType returnData);

		// Token: 0x02000335 RID: 821
		// (Invoke) Token: 0x060023FB RID: 9211
		public delegate GetCastle_ReturnType RemoteAsyncDelegate_GetCastle(int userID, int sessionID, int villageID);

		// Token: 0x02000336 RID: 822
		// (Invoke) Token: 0x060023FF RID: 9215
		public delegate void GetCastle_UserCallBack(GetCastle_ReturnType returnData);

		// Token: 0x02000337 RID: 823
		// (Invoke) Token: 0x06002403 RID: 9219
		public delegate AddCastleElement_ReturnType RemoteAsyncDelegate_AddCastleElement(int userID, int sessionID, int villageID, int elementType, int xPos, int yPos, long clientElementNumber, int wallEndX, int wallEndY, bool reinforcement, bool vassalReinforcement, byte[,] elementList, long[] troopsToDelete, MoveElementData[] troopsToMove);

		// Token: 0x02000338 RID: 824
		// (Invoke) Token: 0x06002407 RID: 9223
		public delegate void AddCastleElement_UserCallBack(AddCastleElement_ReturnType returnData);

		// Token: 0x02000339 RID: 825
		// (Invoke) Token: 0x0600240B RID: 9227
		public delegate DeleteCastleElement_ReturnType RemoteAsyncDelegate_DeleteCastleElement(int userID, int sessionID, int villageID, long elementNumber, List<long> elementList);

		// Token: 0x0200033A RID: 826
		// (Invoke) Token: 0x0600240F RID: 9231
		public delegate void DeleteCastleElement_UserCallBack(DeleteCastleElement_ReturnType returnData);

		// Token: 0x0200033B RID: 827
		// (Invoke) Token: 0x06002413 RID: 9235
		public delegate ChangeCastleElementAggressiveDefender_ReturnType RemoteAsyncDelegate_ChangeCastleElementAggressiveDefender(int userID, int sessionID, int villageID, long[] elementID, bool state);

		// Token: 0x0200033C RID: 828
		// (Invoke) Token: 0x06002417 RID: 9239
		public delegate void ChangeCastleElementAggressiveDefender_UserCallBack(ChangeCastleElementAggressiveDefender_ReturnType returnData);

		// Token: 0x0200033D RID: 829
		// (Invoke) Token: 0x0600241B RID: 9243
		public delegate AutoRepairCastle_ReturnType RemoteAsyncDelegate_AutoRepairCastle(int userID, int sessionID, int villageID);

		// Token: 0x0200033E RID: 830
		// (Invoke) Token: 0x0600241F RID: 9247
		public delegate void AutoRepairCastle_UserCallBack(AutoRepairCastle_ReturnType returnData);

		// Token: 0x0200033F RID: 831
		// (Invoke) Token: 0x06002423 RID: 9251
		public delegate MemorizeCastleTroops_ReturnType RemoteAsyncDelegate_MemorizeCastleTroops(int userID, int sessionID, int villageID);

		// Token: 0x02000340 RID: 832
		// (Invoke) Token: 0x06002427 RID: 9255
		public delegate void MemorizeCastleTroops_UserCallBack(MemorizeCastleTroops_ReturnType returnData);

		// Token: 0x02000341 RID: 833
		// (Invoke) Token: 0x0600242B RID: 9259
		public delegate RestoreCastleTroops_ReturnType RemoteAsyncDelegate_RestoreCastleTroops(int userID, int sessionID, int villageID);

		// Token: 0x02000342 RID: 834
		// (Invoke) Token: 0x0600242F RID: 9263
		public delegate void RestoreCastleTroops_UserCallBack(RestoreCastleTroops_ReturnType returnData);

		// Token: 0x02000343 RID: 835
		// (Invoke) Token: 0x06002433 RID: 9267
		public delegate CheatAddTroops_ReturnType RemoteAsyncDelegate_CheatAddTroops(int userID, int sessionID, int villageID, int troopType, int numToMake);

		// Token: 0x02000344 RID: 836
		// (Invoke) Token: 0x06002437 RID: 9271
		public delegate void CheatAddTroops_UserCallBack(CheatAddTroops_ReturnType returnData);

		// Token: 0x02000345 RID: 837
		// (Invoke) Token: 0x0600243B RID: 9275
		public delegate LaunchCastleAttack_ReturnType RemoteAsyncDelegate_LaunchCastleAttack(int userID, int sessionID, int parentOfAttackingVillageID, int targetVillageID, int sourceVillageID, byte[] attackersMap, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackType, int pillagePercent, int CaptainsCommand, int numCaptains);

		// Token: 0x02000346 RID: 838
		// (Invoke) Token: 0x0600243F RID: 9279
		public delegate void LaunchCastleAttack_UserCallBack(LaunchCastleAttack_ReturnType returnData);

		// Token: 0x02000347 RID: 839
		// (Invoke) Token: 0x06002443 RID: 9283
		public delegate SendScouts_ReturnType RemoteAsyncDelegate_SendScouts(int userID, int sessionID, int targetVillageID, int sourceVillageID, int numScouts);

		// Token: 0x02000348 RID: 840
		// (Invoke) Token: 0x06002447 RID: 9287
		public delegate void SendScouts_UserCallBack(SendScouts_ReturnType returnData);

		// Token: 0x02000349 RID: 841
		// (Invoke) Token: 0x0600244B RID: 9291
		public delegate CancelCastleAttack_ReturnType RemoteAsyncDelegate_CancelCastleAttack(int userID, int sessionID, long armyID);

		// Token: 0x0200034A RID: 842
		// (Invoke) Token: 0x0600244F RID: 9295
		public delegate void CancelCastleAttack_UserCallBack(CancelCastleAttack_ReturnType returnData);

		// Token: 0x0200034B RID: 843
		// (Invoke) Token: 0x06002453 RID: 9299
		public delegate SendReinforcements_ReturnType RemoteAsyncDelegate_SendReinforcements(int userID, int sessionID, int homeVillageID, int supportedVillageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults);

		// Token: 0x0200034C RID: 844
		// (Invoke) Token: 0x06002457 RID: 9303
		public delegate void SendReinforcements_UserCallBack(SendReinforcements_ReturnType returnData);

		// Token: 0x0200034D RID: 845
		// (Invoke) Token: 0x0600245B RID: 9307
		public delegate ReturnReinforcements_ReturnType RemoteAsyncDelegate_ReturnReinforcements(int userID, int sessionID, long reinforcementID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults);

		// Token: 0x0200034E RID: 846
		// (Invoke) Token: 0x0600245F RID: 9311
		public delegate void ReturnReinforcements_UserCallBack(ReturnReinforcements_ReturnType returnData);

		// Token: 0x0200034F RID: 847
		// (Invoke) Token: 0x06002463 RID: 9315
		public delegate SendMarketResources_ReturnType RemoteAsyncDelegate_SendMarketResources(int userID, int sessionID, int homeVillageID, int targetVillage, int resource, int amount);

		// Token: 0x02000350 RID: 848
		// (Invoke) Token: 0x06002467 RID: 9319
		public delegate void SendMarketResources_UserCallBack(SendMarketResources_ReturnType returnData);

		// Token: 0x02000351 RID: 849
		// (Invoke) Token: 0x0600246B RID: 9323
		public delegate GetUserTraders_ReturnType RemoteAsyncDelegate_GetUserTraders(int userID, int sessionID, int villageID);

		// Token: 0x02000352 RID: 850
		// (Invoke) Token: 0x0600246F RID: 9327
		public delegate void GetUserTraders_UserCallBack(GetUserTraders_ReturnType returnData);

		// Token: 0x02000353 RID: 851
		// (Invoke) Token: 0x06002473 RID: 9331
		public delegate GetActiveTraders_ReturnType RemoteAsyncDelegate_GetActiveTraders(int userID, int sessionID, DateTime lastTime);

		// Token: 0x02000354 RID: 852
		// (Invoke) Token: 0x06002477 RID: 9335
		public delegate void GetActiveTraders_UserCallBack(GetActiveTraders_ReturnType returnData);

		// Token: 0x02000355 RID: 853
		// (Invoke) Token: 0x0600247B RID: 9339
		public delegate GetStockExchangeData_ReturnType RemoteAsyncDelegate_GetStockExchangeData(int userID, int sessionID, int villageID, bool stockExchange, int[] closeVillages);

		// Token: 0x02000356 RID: 854
		// (Invoke) Token: 0x0600247F RID: 9343
		public delegate void GetStockExchangeData_UserCallBack(GetStockExchangeData_ReturnType returnData);

		// Token: 0x02000357 RID: 855
		// (Invoke) Token: 0x06002483 RID: 9347
		public delegate StockExchangeTrade_ReturnType RemoteAsyncDelegate_StockExchangeTrade(int userID, int sessionID, int villageID, int targetExchange, int resource, int amount, bool buy);

		// Token: 0x02000358 RID: 856
		// (Invoke) Token: 0x06002487 RID: 9351
		public delegate void StockExchangeTrade_UserCallBack(StockExchangeTrade_ReturnType returnData);

		// Token: 0x02000359 RID: 857
		// (Invoke) Token: 0x0600248B RID: 9355
		public delegate UpdateVillageFavourites_ReturnType RemoteAsyncDelegate_UpdateVillageFavourites(int userID, int sessionID, int mode, int villageID);

		// Token: 0x0200035A RID: 858
		// (Invoke) Token: 0x0600248F RID: 9359
		public delegate void UpdateVillageFavourites_UserCallBack(UpdateVillageFavourites_ReturnType returnData);

		// Token: 0x0200035B RID: 859
		// (Invoke) Token: 0x06002493 RID: 9363
		public delegate MakeTroop_ReturnType RemoteAsyncDelegate_MakeTroop(int userID, int sessionID, int villageID, int troopType, int amount);

		// Token: 0x0200035C RID: 860
		// (Invoke) Token: 0x06002497 RID: 9367
		public delegate void MakeTroop_UserCallBack(MakeTroop_ReturnType returnData);

		// Token: 0x0200035D RID: 861
		// (Invoke) Token: 0x0600249B RID: 9371
		public delegate UpgradeRank_ReturnType RemoteAsyncDelegate_UpgradeRank(int userID, int sessionID, int curRank, int curRankSubLevel);

		// Token: 0x0200035E RID: 862
		// (Invoke) Token: 0x0600249F RID: 9375
		public delegate void UpgradeRank_UserCallBack(UpgradeRank_ReturnType returnData);

		// Token: 0x0200035F RID: 863
		// (Invoke) Token: 0x060024A3 RID: 9379
		public delegate PreAttackSetup_ReturnType RemoteAsyncDelegate_PreAttackSetup(int userID, int sessionID, int parentAttackingVillage, int attackingVillage, int targetVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackType, int pillagePercent, int captainsCommand);

		// Token: 0x02000360 RID: 864
		// (Invoke) Token: 0x060024A7 RID: 9383
		public delegate void PreAttackSetup_UserCallBack(PreAttackSetup_ReturnType returnData);

		// Token: 0x02000361 RID: 865
		// (Invoke) Token: 0x060024AB RID: 9387
		public delegate GetBattleHonourRating_ReturnType RemoteAsyncDelegate_GetBattleHonourRating(int userID, int sessionID, int attackedVillage);

		// Token: 0x02000362 RID: 866
		// (Invoke) Token: 0x060024AF RID: 9391
		public delegate void GetBattleHonourRating_UserCallBack(GetBattleHonourRating_ReturnType returnData);

		// Token: 0x02000363 RID: 867
		// (Invoke) Token: 0x060024B3 RID: 9395
		public delegate RetrieveArmyFromGarrison_ReturnType RemoteAsyncDelegate_RetrieveArmyFromGarrison(int userID, int sessionID, int villageID);

		// Token: 0x02000364 RID: 868
		// (Invoke) Token: 0x060024B7 RID: 9399
		public delegate void RetrieveArmyFromGarrison_UserCallBack(RetrieveArmyFromGarrison_ReturnType returnData);

		// Token: 0x02000365 RID: 869
		// (Invoke) Token: 0x060024BB RID: 9403
		public delegate RetrieveVillageUserInfo_ReturnType RemoteAsyncDelegate_RetrieveVillageUserInfo(int userID, int sessionID, int villageID, int targetUserID, bool extended);

		// Token: 0x02000366 RID: 870
		// (Invoke) Token: 0x060024BF RID: 9407
		public delegate void RetrieveVillageUserInfo_UserCallBack(RetrieveVillageUserInfo_ReturnType returnData);

		// Token: 0x02000367 RID: 871
		// (Invoke) Token: 0x060024C3 RID: 9411
		public delegate SpecialVillageInfo_ReturnType RemoteAsyncDelegate_SpecialVillageInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000368 RID: 872
		// (Invoke) Token: 0x060024C7 RID: 9415
		public delegate void SpecialVillageInfo_UserCallBack(SpecialVillageInfo_ReturnType returnData);

		// Token: 0x02000369 RID: 873
		// (Invoke) Token: 0x060024CB RID: 9419
		public delegate GetVillageRankTaxTree_ReturnType RemoteAsyncDelegate_GetVillageRankTaxTree(int userID, int sessionID);

		// Token: 0x0200036A RID: 874
		// (Invoke) Token: 0x060024CF RID: 9423
		public delegate void GetVillageRankTaxTree_UserCallBack(GetVillageRankTaxTree_ReturnType returnData);

		// Token: 0x0200036B RID: 875
		// (Invoke) Token: 0x060024D3 RID: 9427
		public delegate GetResearchData_ReturnType RemoteAsyncDelegate_GetResearchData(int userID, int sessionID);

		// Token: 0x0200036C RID: 876
		// (Invoke) Token: 0x060024D7 RID: 9431
		public delegate void GetResearchData_UserCallBack(GetResearchData_ReturnType returnData);

		// Token: 0x0200036D RID: 877
		// (Invoke) Token: 0x060024DB RID: 9435
		public delegate DoResearch_ReturnType RemoteAsyncDelegate_DoResearch(int userID, int sessionID, int researchType, int queuePos);

		// Token: 0x0200036E RID: 878
		// (Invoke) Token: 0x060024DF RID: 9439
		public delegate void DoResearch_UserCallBack(DoResearch_ReturnType returnData);

		// Token: 0x0200036F RID: 879
		// (Invoke) Token: 0x060024E3 RID: 9443
		public delegate BuyResearchPoint_ReturnType RemoteAsyncDelegate_BuyResearchPoint(int userID, int sessionID);

		// Token: 0x02000370 RID: 880
		// (Invoke) Token: 0x060024E7 RID: 9447
		public delegate void BuyResearchPoint_UserCallBack(BuyResearchPoint_ReturnType returnData);

		// Token: 0x02000371 RID: 881
		// (Invoke) Token: 0x060024EB RID: 9451
		public delegate VassalInfo_ReturnType RemoteAsyncDelegate_VassalInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000372 RID: 882
		// (Invoke) Token: 0x060024EF RID: 9455
		public delegate void VassalInfo_UserCallBack(VassalInfo_ReturnType returnData);

		// Token: 0x02000373 RID: 883
		// (Invoke) Token: 0x060024F3 RID: 9459
		public delegate VassalSendResources_ReturnType RemoteAsyncDelegate_VassalSendResources(int userID, int sessionID, int liegeLordVillageID, int vassalVillageID, int resourceType, int amount);

		// Token: 0x02000374 RID: 884
		// (Invoke) Token: 0x060024F7 RID: 9463
		public delegate void VassalSendResources_UserCallBack(VassalSendResources_ReturnType returnData);

		// Token: 0x02000375 RID: 885
		// (Invoke) Token: 0x060024FB RID: 9467
		public delegate UpdateSelectedTitheType_ReturnType RemoteAsyncDelegate_UpdateSelectedTitheType(int userID, int sessionID, int villageID, int titheType);

		// Token: 0x02000376 RID: 886
		// (Invoke) Token: 0x060024FF RID: 9471
		public delegate void UpdateSelectedTitheType_UserCallBack(UpdateSelectedTitheType_ReturnType returnData);

		// Token: 0x02000377 RID: 887
		// (Invoke) Token: 0x06002503 RID: 9475
		public delegate BreakVassalage_ReturnType RemoteAsyncDelegate_BreakVassalage(int userID, int sessionID, int villageID, int targetVillage);

		// Token: 0x02000378 RID: 888
		// (Invoke) Token: 0x06002507 RID: 9479
		public delegate void BreakVassalage_UserCallBack(BreakVassalage_ReturnType returnData);

		// Token: 0x02000379 RID: 889
		// (Invoke) Token: 0x0600250B RID: 9483
		public delegate BreakLiegeLord_ReturnType RemoteAsyncDelegate_BreakLiegeLord(int userID, int sessionID, int villageID, int targetVillage);

		// Token: 0x0200037A RID: 890
		// (Invoke) Token: 0x0600250F RID: 9487
		public delegate void BreakLiegeLord_UserCallBack(BreakLiegeLord_ReturnType returnData);

		// Token: 0x0200037B RID: 891
		// (Invoke) Token: 0x06002513 RID: 9491
		public delegate GetPreVassalInfo_ReturnType RemoteAsyncDelegate_GetPreVassalInfo(int userID, int sessionID, int yourVillageID, int targetVillageID);

		// Token: 0x0200037C RID: 892
		// (Invoke) Token: 0x06002517 RID: 9495
		public delegate void GetPreVassalInfo_UserCallBack(GetPreVassalInfo_ReturnType returnData);

		// Token: 0x0200037D RID: 893
		// (Invoke) Token: 0x0600251B RID: 9499
		public delegate SendVassalRequest_ReturnType RemoteAsyncDelegate_SendVassalRequest(int userID, int sessionID, int yourVillageID, int targetVillageID);

		// Token: 0x0200037E RID: 894
		// (Invoke) Token: 0x0600251F RID: 9503
		public delegate void SendVassalRequest_UserCallBack(SendVassalRequest_ReturnType returnData);

		// Token: 0x0200037F RID: 895
		// (Invoke) Token: 0x06002523 RID: 9507
		public delegate HandleVassalRequest_ReturnType RemoteAsyncDelegate_HandleVassalRequest(int userID, int sessionID, int command, int liegeLordVillageID, int vassalVillageID);

		// Token: 0x02000380 RID: 896
		// (Invoke) Token: 0x06002527 RID: 9511
		public delegate void HandleVassalRequest_UserCallBack(HandleVassalRequest_ReturnType returnData);

		// Token: 0x02000381 RID: 897
		// (Invoke) Token: 0x0600252B RID: 9515
		public delegate GetVassalArmyInfo_ReturnType RemoteAsyncDelegate_GetVassalArmyInfo(int userID, int sessionID, int vassalVillageID, int mode, int attackedVillage);

		// Token: 0x02000382 RID: 898
		// (Invoke) Token: 0x0600252F RID: 9519
		public delegate void GetVassalArmyInfo_UserCallBack(GetVassalArmyInfo_ReturnType returnData);

		// Token: 0x02000383 RID: 899
		// (Invoke) Token: 0x06002533 RID: 9523
		public delegate SendTroopsToVassal_ReturnType RemoteAsyncDelegate_SendTroopsToVassal(int userID, int sessionID, int liegeLordVillageID, int vassalVillageID, int peasants, int archers, int pikemen, int swordsmen, int catapults);

		// Token: 0x02000384 RID: 900
		// (Invoke) Token: 0x06002537 RID: 9527
		public delegate void SendTroopsToVassal_UserCallBack(SendTroopsToVassal_ReturnType returnData);

		// Token: 0x02000385 RID: 901
		// (Invoke) Token: 0x0600253B RID: 9531
		public delegate RetrieveTroopsFromVassal_ReturnType RemoteAsyncDelegate_RetrieveTroopsFromVassal(int userID, int sessionID, int liegeLordVillageID, int vassalVillageID);

		// Token: 0x02000386 RID: 902
		// (Invoke) Token: 0x0600253F RID: 9535
		public delegate void RetrieveTroopsFromVassal_UserCallBack(RetrieveTroopsFromVassal_ReturnType returnData);

		// Token: 0x02000387 RID: 903
		// (Invoke) Token: 0x06002543 RID: 9539
		public delegate UpdateVillageResourcesInfo_ReturnType RemoteAsyncDelegate_UpdateVillageResourcesInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000388 RID: 904
		// (Invoke) Token: 0x06002547 RID: 9543
		public delegate void UpdateVillageResourcesInfo_UserCallBack(UpdateVillageResourcesInfo_ReturnType returnData);

		// Token: 0x02000389 RID: 905
		// (Invoke) Token: 0x0600254B RID: 9547
		public delegate SetHighestArmySeen_ReturnType RemoteAsyncDelegate_SetHighestArmySeen(int userID, int sessionID, long highestArmyIDSeen);

		// Token: 0x0200038A RID: 906
		// (Invoke) Token: 0x0600254F RID: 9551
		public delegate void SetHighestArmySeen_UserCallBack(SetHighestArmySeen_ReturnType returnData);

		// Token: 0x0200038B RID: 907
		// (Invoke) Token: 0x06002553 RID: 9555
		public delegate GetForumList_ReturnType RemoteAsyncDelegate_GetForumList(int userID, int sessionID, int areaID, int areaType);

		// Token: 0x0200038C RID: 908
		// (Invoke) Token: 0x06002557 RID: 9559
		public delegate void GetForumList_UserCallBack(GetForumList_ReturnType returnData);

		// Token: 0x0200038D RID: 909
		// (Invoke) Token: 0x0600255B RID: 9563
		public delegate GetForumThreadList_ReturnType RemoteAsyncDelegate_GetForumThreadList(int userID, int sessionID, long forumID, DateTime lastGet, bool forceGet);

		// Token: 0x0200038E RID: 910
		// (Invoke) Token: 0x0600255F RID: 9567
		public delegate void GetForumThreadList_UserCallBack(GetForumThreadList_ReturnType returnData);

		// Token: 0x0200038F RID: 911
		// (Invoke) Token: 0x06002563 RID: 9571
		public delegate GetForumThread_ReturnType RemoteAsyncDelegate_GetForumThread(int userID, int sessionID, long forumID, long threadID, DateTime lastGet, bool forceGet);

		// Token: 0x02000390 RID: 912
		// (Invoke) Token: 0x06002567 RID: 9575
		public delegate void GetForumThread_UserCallBack(GetForumThread_ReturnType returnData);

		// Token: 0x02000391 RID: 913
		// (Invoke) Token: 0x0600256B RID: 9579
		public delegate NewForumThread_ReturnType RemoteAsyncDelegate_NewForumThread(int userID, int sessionID, long forumID, string headingText, string bodyText);

		// Token: 0x02000392 RID: 914
		// (Invoke) Token: 0x0600256F RID: 9583
		public delegate void NewForumThread_UserCallBack(NewForumThread_ReturnType returnData);

		// Token: 0x02000393 RID: 915
		// (Invoke) Token: 0x06002573 RID: 9587
		public delegate PostToForumThread_ReturnType RemoteAsyncDelegate_PostToForumThread(int userID, int sessionID, long threadID, long forumID, string text);

		// Token: 0x02000394 RID: 916
		// (Invoke) Token: 0x06002577 RID: 9591
		public delegate void PostToForumThread_UserCallBack(PostToForumThread_ReturnType returnData);

		// Token: 0x02000395 RID: 917
		// (Invoke) Token: 0x0600257B RID: 9595
		public delegate GiveForumAccess_ReturnType RemoteAsyncDelegate_GiveForumAccess(int userID, int sessionID, long forumID, int[] users);

		// Token: 0x02000396 RID: 918
		// (Invoke) Token: 0x0600257F RID: 9599
		public delegate void GiveForumAccess_UserCallBack(GiveForumAccess_ReturnType returnData);

		// Token: 0x02000397 RID: 919
		// (Invoke) Token: 0x06002583 RID: 9603
		public delegate CreateForum_ReturnType RemoteAsyncDelegate_CreateForum(int userID, int sessionID, int areaID, int areaType, string name);

		// Token: 0x02000398 RID: 920
		// (Invoke) Token: 0x06002587 RID: 9607
		public delegate void CreateForum_UserCallBack(CreateForum_ReturnType returnData);

		// Token: 0x02000399 RID: 921
		// (Invoke) Token: 0x0600258B RID: 9611
		public delegate DeleteForum_ReturnType RemoteAsyncDelegate_DeleteForum(int userID, int sessionID, int areaID, int areaType, long forumID);

		// Token: 0x0200039A RID: 922
		// (Invoke) Token: 0x0600258F RID: 9615
		public delegate void DeleteForum_UserCallBack(DeleteForum_ReturnType returnData);

		// Token: 0x0200039B RID: 923
		// (Invoke) Token: 0x06002593 RID: 9619
		public delegate DeleteForumThread_ReturnType RemoteAsyncDelegate_DeleteForumThread(int userID, int sessionID, int areaID, int areaType, string forumTitle, long forumID, long forumThreadID);

		// Token: 0x0200039C RID: 924
		// (Invoke) Token: 0x06002597 RID: 9623
		public delegate void DeleteForumThread_UserCallBack(DeleteForumThread_ReturnType returnData);

		// Token: 0x0200039D RID: 925
		// (Invoke) Token: 0x0600259B RID: 9627
		public delegate DeleteForumPost_ReturnType RemoteAsyncDelegate_DeleteForumPost(int userID, int sessionID, int areaID, int areaType, string forumTitle, long forumID, long forumThreadID, long forumPostID);

		// Token: 0x0200039E RID: 926
		// (Invoke) Token: 0x0600259F RID: 9631
		public delegate void DeleteForumPost_UserCallBack(DeleteForumPost_ReturnType returnData);

		// Token: 0x0200039F RID: 927
		// (Invoke) Token: 0x060025A3 RID: 9635
		public delegate GetCurrentElectionInfo_ReturnType RemoteAsyncDelegate_GetCurrentElectionInfo(int userID, int sessionID, int areaID, int areaType);

		// Token: 0x020003A0 RID: 928
		// (Invoke) Token: 0x060025A7 RID: 9639
		public delegate void GetCurrentElectionInfo_UserCallBack(GetCurrentElectionInfo_ReturnType returnData);

		// Token: 0x020003A1 RID: 929
		// (Invoke) Token: 0x060025AB RID: 9643
		public delegate StandInElection_ReturnType RemoteAsyncDelegate_StandInElection(int userID, int sessionID, int areaID, int areaType, bool state);

		// Token: 0x020003A2 RID: 930
		// (Invoke) Token: 0x060025AF RID: 9647
		public delegate void StandInElection_UserCallBack(StandInElection_ReturnType returnData);

		// Token: 0x020003A3 RID: 931
		// (Invoke) Token: 0x060025B3 RID: 9651
		public delegate VoteInElection_ReturnType RemoteAsyncDelegate_VoteInElection(int userID, int sessionID, int areaID, int areaType, int candidate);

		// Token: 0x020003A4 RID: 932
		// (Invoke) Token: 0x060025B7 RID: 9655
		public delegate void VoteInElection_UserCallBack(VoteInElection_ReturnType returnData);

		// Token: 0x020003A5 RID: 933
		// (Invoke) Token: 0x060025BB RID: 9659
		public delegate UploadAvatar_ReturnType RemoteAsyncDelegate_UploadAvatar(int userID, int sessionID, AvatarData avatarData);

		// Token: 0x020003A6 RID: 934
		// (Invoke) Token: 0x060025BF RID: 9663
		public delegate void UploadAvatar_UserCallBack(UploadAvatar_ReturnType returnData);

		// Token: 0x020003A7 RID: 935
		// (Invoke) Token: 0x060025C3 RID: 9667
		public delegate MakePeople_ReturnType RemoteAsyncDelegate_MakePeople(int userID, int sessionID, int villageIDF, int personType);

		// Token: 0x020003A8 RID: 936
		// (Invoke) Token: 0x060025C7 RID: 9671
		public delegate void MakePeople_UserCallBack(MakePeople_ReturnType returnData);

		// Token: 0x020003A9 RID: 937
		// (Invoke) Token: 0x060025CB RID: 9675
		public delegate GetUserPeople_ReturnType RemoteAsyncDelegate_GetUserPeople(int userID, int sessionID);

		// Token: 0x020003AA RID: 938
		// (Invoke) Token: 0x060025CF RID: 9679
		public delegate void GetUserPeople_UserCallBack(GetUserPeople_ReturnType returnData);

		// Token: 0x020003AB RID: 939
		// (Invoke) Token: 0x060025D3 RID: 9683
		public delegate GetUserIDFromName_ReturnType RemoteAsyncDelegate_GetUserIDFromName(int userID, int sessionID, string targetUser);

		// Token: 0x020003AC RID: 940
		// (Invoke) Token: 0x060025D7 RID: 9687
		public delegate void GetUserIDFromName_UserCallBack(GetUserIDFromName_ReturnType returnData);

		// Token: 0x020003AD RID: 941
		// (Invoke) Token: 0x060025DB RID: 9691
		public delegate GetActivePeople_ReturnType RemoteAsyncDelegate_GetActivePeople(int userID, int sessionID, DateTime lastTime);

		// Token: 0x020003AE RID: 942
		// (Invoke) Token: 0x060025DF RID: 9695
		public delegate void GetActivePeople_UserCallBack(GetActivePeople_ReturnType returnData);

		// Token: 0x020003AF RID: 943
		// (Invoke) Token: 0x060025E3 RID: 9699
		public delegate SendPeople_ReturnType RemoteAsyncDelegate_SendPeople(int userID, int sessionID, int homeVillageID, int targetVillage, int personType, int number, int command, int data);

		// Token: 0x020003B0 RID: 944
		// (Invoke) Token: 0x060025E7 RID: 9703
		public delegate void SendPeople_UserCallBack(SendPeople_ReturnType returnData);

		// Token: 0x020003B1 RID: 945
		// (Invoke) Token: 0x060025EB RID: 9707
		public delegate RetrievePeople_ReturnType RemoteAsyncDelegate_RetrievePeople(int userID, int sessionID, int villageID, List<long> people, int personType);

		// Token: 0x020003B2 RID: 946
		// (Invoke) Token: 0x060025EF RID: 9711
		public delegate void RetrievePeople_UserCallBack(RetrievePeople_ReturnType returnData);

		// Token: 0x020003B3 RID: 947
		// (Invoke) Token: 0x060025F3 RID: 9715
		public delegate SpyCommand_ReturnType RemoteAsyncDelegate_SpyCommand(int userID, int sessionID, int villageID, int command);

		// Token: 0x020003B4 RID: 948
		// (Invoke) Token: 0x060025F7 RID: 9719
		public delegate void SpyCommand_UserCallBack(SpyCommand_ReturnType returnData);

		// Token: 0x020003B5 RID: 949
		// (Invoke) Token: 0x060025FB RID: 9723
		public delegate SpyGetVillageResourceInfo_ReturnType RemoteAsyncDelegate_SpyGetVillageResourceInfo(int userID, int sessionID, int villageID);

		// Token: 0x020003B6 RID: 950
		// (Invoke) Token: 0x060025FF RID: 9727
		public delegate void SpyGetVillageResourceInfo_UserCallBack(SpyGetVillageResourceInfo_ReturnType returnData);

		// Token: 0x020003B7 RID: 951
		// (Invoke) Token: 0x06002603 RID: 9731
		public delegate SpyGetArmyInfo_ReturnType RemoteAsyncDelegate_SpyGetArmyInfo(int userID, int sessionID, int villageID);

		// Token: 0x020003B8 RID: 952
		// (Invoke) Token: 0x06002607 RID: 9735
		public delegate void SpyGetArmyInfo_UserCallBack(SpyGetArmyInfo_ReturnType returnData);

		// Token: 0x020003B9 RID: 953
		// (Invoke) Token: 0x0600260B RID: 9739
		public delegate SpyGetResearchInfo_ReturnType RemoteAsyncDelegate_SpyGetResearchInfo(int userID, int sessionID, int villageID);

		// Token: 0x020003BA RID: 954
		// (Invoke) Token: 0x0600260F RID: 9743
		public delegate void SpyGetResearchInfo_UserCallBack(SpyGetResearchInfo_ReturnType returnData);

		// Token: 0x020003BB RID: 955
		// (Invoke) Token: 0x06002613 RID: 9747
		public delegate CreateFaction_ReturnType RemoteAsyncDelegate_CreateFaction(int userID, int sessionID, string factionName, string factionNameabrv, string factionMotto, int flagdata);

		// Token: 0x020003BC RID: 956
		// (Invoke) Token: 0x06002617 RID: 9751
		public delegate void CreateFaction_UserCallBack(CreateFaction_ReturnType returnData);

		// Token: 0x020003BD RID: 957
		// (Invoke) Token: 0x0600261B RID: 9755
		public delegate DisbandFaction_ReturnType RemoteAsyncDelegate_DisbandFaction(int userID, int sessionID, int factionID);

		// Token: 0x020003BE RID: 958
		// (Invoke) Token: 0x0600261F RID: 9759
		public delegate void DisbandFaction_UserCallBack(DisbandFaction_ReturnType returnData);

		// Token: 0x020003BF RID: 959
		// (Invoke) Token: 0x06002623 RID: 9763
		public delegate FactionSendInvite_ReturnType RemoteAsyncDelegate_FactionSendInvite(int userID, int sessionID, string targetUser);

		// Token: 0x020003C0 RID: 960
		// (Invoke) Token: 0x06002627 RID: 9767
		public delegate void FactionSendInvite_UserCallBack(FactionSendInvite_ReturnType returnData);

		// Token: 0x020003C1 RID: 961
		// (Invoke) Token: 0x0600262B RID: 9771
		public delegate FactionWithdrawInvite_ReturnType RemoteAsyncDelegate_FactionWithdrawInvite(int userID, int sessionID, int targetUserID);

		// Token: 0x020003C2 RID: 962
		// (Invoke) Token: 0x0600262F RID: 9775
		public delegate void FactionWithdrawInvite_UserCallBack(FactionWithdrawInvite_ReturnType returnData);

		// Token: 0x020003C3 RID: 963
		// (Invoke) Token: 0x06002633 RID: 9779
		public delegate FactionReplyToInvite_ReturnType RemoteAsyncDelegate_FactionReplyToInvite(int userID, int sessionID, int factionID, bool accept);

		// Token: 0x020003C4 RID: 964
		// (Invoke) Token: 0x06002637 RID: 9783
		public delegate void FactionReplyToInvite_UserCallBack(FactionReplyToInvite_ReturnType returnData);

		// Token: 0x020003C5 RID: 965
		// (Invoke) Token: 0x0600263B RID: 9787
		public delegate FactionChangeMemberStatus_ReturnType RemoteAsyncDelegate_FactionChangeMemberStatus(int userID, int sessionID, int memberUserID, int targetRank);

		// Token: 0x020003C6 RID: 966
		// (Invoke) Token: 0x0600263F RID: 9791
		public delegate void FactionChangeMemberStatus_UserCallBack(FactionChangeMemberStatus_ReturnType returnData);

		// Token: 0x020003C7 RID: 967
		// (Invoke) Token: 0x06002643 RID: 9795
		public delegate FactionLeave_ReturnType RemoteAsyncDelegate_FactionLeave(int userID, int sessionID);

		// Token: 0x020003C8 RID: 968
		// (Invoke) Token: 0x06002647 RID: 9799
		public delegate void FactionLeave_UserCallBack(FactionLeave_ReturnType returnData);

		// Token: 0x020003C9 RID: 969
		// (Invoke) Token: 0x0600264B RID: 9803
		public delegate GetFactionData_ReturnType RemoteAsyncDelegate_GetFactionData(int userID, int sessionID, int factionID, long factionChangesPos);

		// Token: 0x020003CA RID: 970
		// (Invoke) Token: 0x0600264F RID: 9807
		public delegate void GetFactionData_UserCallBack(GetFactionData_ReturnType returnData);

		// Token: 0x020003CB RID: 971
		// (Invoke) Token: 0x06002653 RID: 9811
		public delegate CreateUserRelationship_ReturnType RemoteAsyncDelegate_CreateUserRelationship(int userID, int sessionID, int targetUserID, int relationship);

		// Token: 0x020003CC RID: 972
		// (Invoke) Token: 0x06002657 RID: 9815
		public delegate void CreateUserRelationship_UserCallBack(CreateUserRelationship_ReturnType returnData);

		// Token: 0x020003CD RID: 973
		// (Invoke) Token: 0x0600265B RID: 9819
		public delegate SetUserMarker_ReturnType RemoteAsyncDelegate_SetUserMarker(int userID, int sessionID, int targetUserID, int markerType);

		// Token: 0x020003CE RID: 974
		// (Invoke) Token: 0x0600265F RID: 9823
		public delegate void SetUserMarker_UserCallBack(SetUserMarker_ReturnType returnData);

		// Token: 0x020003CF RID: 975
		// (Invoke) Token: 0x06002663 RID: 9827
		public delegate CreateFactionRelationship_ReturnType RemoteAsyncDelegate_CreateFactionRelationship(int userID, int sessionID, int targetFactionID, int relationship);

		// Token: 0x020003D0 RID: 976
		// (Invoke) Token: 0x06002667 RID: 9831
		public delegate void CreateFactionRelationship_UserCallBack(CreateFactionRelationship_ReturnType returnData);

		// Token: 0x020003D1 RID: 977
		// (Invoke) Token: 0x0600266B RID: 9835
		public delegate CreateHouseRelationship_ReturnType RemoteAsyncDelegate_CreateHouseRelationship(int userID, int sessionID, int targetHouseID, int relationship);

		// Token: 0x020003D2 RID: 978
		// (Invoke) Token: 0x0600266F RID: 9839
		public delegate void CreateHouseRelationship_UserCallBack(CreateHouseRelationship_ReturnType returnData);

		// Token: 0x020003D3 RID: 979
		// (Invoke) Token: 0x06002673 RID: 9843
		public delegate GetHouseGloryPoints_ReturnType RemoteAsyncDelegate_GetHouseGloryPoints(int userID, int sessionID);

		// Token: 0x020003D4 RID: 980
		// (Invoke) Token: 0x06002677 RID: 9847
		public delegate void GetHouseGloryPoints_UserCallBack(GetHouseGloryPoints_ReturnType returnData);

		// Token: 0x020003D5 RID: 981
		// (Invoke) Token: 0x0600267B RID: 9851
		public delegate ChangeFactionMotto_ReturnType RemoteAsyncDelegate_ChangeFactionMotto(int userID, int sessionID, string factionName, string factionNameAbrv, string motto, int flagData);

		// Token: 0x020003D6 RID: 982
		// (Invoke) Token: 0x0600267F RID: 9855
		public delegate void ChangeFactionMotto_UserCallBack(ChangeFactionMotto_ReturnType returnData);

		// Token: 0x020003D7 RID: 983
		// (Invoke) Token: 0x06002683 RID: 9859
		public delegate FactionLeadershipVote_ReturnType RemoteAsyncDelegate_FactionLeadershipVote(int userID, int sessionID, int factionID, int votedID);

		// Token: 0x020003D8 RID: 984
		// (Invoke) Token: 0x06002687 RID: 9863
		public delegate void FactionLeadershipVote_UserCallBack(FactionLeadershipVote_ReturnType returnData);

		// Token: 0x020003D9 RID: 985
		// (Invoke) Token: 0x0600268B RID: 9867
		public delegate GetViewFactionData_ReturnType RemoteAsyncDelegate_GetViewFactionData(int userID, int sessionID, int factionID);

		// Token: 0x020003DA RID: 986
		// (Invoke) Token: 0x0600268F RID: 9871
		public delegate void GetViewFactionData_UserCallBack(GetViewFactionData_ReturnType returnData);

		// Token: 0x020003DB RID: 987
		// (Invoke) Token: 0x06002693 RID: 9875
		public delegate GetViewHouseData_ReturnType RemoteAsyncDelegate_GetViewHouseData(int userID, int sessionID, int houseID);

		// Token: 0x020003DC RID: 988
		// (Invoke) Token: 0x06002697 RID: 9879
		public delegate void GetViewHouseData_UserCallBack(GetViewHouseData_ReturnType returnData);

		// Token: 0x020003DD RID: 989
		// (Invoke) Token: 0x0600269B RID: 9883
		public delegate SelfJoinHouse_ReturnType RemoteAsyncDelegate_SelfJoinHouse(int userID, int sessionID, int factionID, int houseID, long factionsChangePos);

		// Token: 0x020003DE RID: 990
		// (Invoke) Token: 0x0600269F RID: 9887
		public delegate void SelfJoinHouse_UserCallBack(SelfJoinHouse_ReturnType returnData);

		// Token: 0x020003DF RID: 991
		// (Invoke) Token: 0x060026A3 RID: 9891
		public delegate HouseVote_ReturnType RemoteAsyncDelegate_HouseVote(int userID, int sessionID, int factionID, int houseID, int targetFaction, bool application, bool vote, long factionsChangePos);

		// Token: 0x020003E0 RID: 992
		// (Invoke) Token: 0x060026A7 RID: 9895
		public delegate void HouseVote_UserCallBack(HouseVote_ReturnType returnData);

		// Token: 0x020003E1 RID: 993
		// (Invoke) Token: 0x060026AB RID: 9899
		public delegate HouseVoteHouseLeader_ReturnType RemoteAsyncDelegate_HouseVoteHouseLeader(int userID, int sessionID, int factionID, int houseID, int leaderVote, long factionsChangePos);

		// Token: 0x020003E2 RID: 994
		// (Invoke) Token: 0x060026AF RID: 9903
		public delegate void HouseVoteHouseLeader_UserCallBack(HouseVoteHouseLeader_ReturnType returnData);

		// Token: 0x020003E3 RID: 995
		// (Invoke) Token: 0x060026B3 RID: 9907
		public delegate TouchHouseVisitDate_ReturnType RemoteAsyncDelegate_TouchHouseVisitDate(int userID, int sessionID, int factionID);

		// Token: 0x020003E4 RID: 996
		// (Invoke) Token: 0x060026B7 RID: 9911
		public delegate void TouchHouseVisitDate_UserCallBack(TouchHouseVisitDate_ReturnType returnData);

		// Token: 0x020003E5 RID: 997
		// (Invoke) Token: 0x060026BB RID: 9915
		public delegate LeaveHouse_ReturnType RemoteAsyncDelegate_LeaveHouse(int userID, int sessionID, int factionID, int houseID, long factionsChangePos);

		// Token: 0x020003E6 RID: 998
		// (Invoke) Token: 0x060026BF RID: 9919
		public delegate void LeaveHouse_UserCallBack(LeaveHouse_ReturnType returnData);

		// Token: 0x020003E7 RID: 999
		// (Invoke) Token: 0x060026C3 RID: 9923
		public delegate FactionApplication_ReturnType RemoteAsyncDelegate_FactionApplication(int userID, int sessionID, int factionID, bool cancel);

		// Token: 0x020003E8 RID: 1000
		// (Invoke) Token: 0x060026C7 RID: 9927
		public delegate void FactionApplication_UserCallBack(FactionApplication_ReturnType returnData);

		// Token: 0x020003E9 RID: 1001
		// (Invoke) Token: 0x060026CB RID: 9931
		public delegate FactionApplicationProcessing_ReturnType RemoteAsyncDelegate_FactionApplicationProcessing(int userID, int sessionID, int otherUserID, bool accept, bool reject, bool setMode);

		// Token: 0x020003EA RID: 1002
		// (Invoke) Token: 0x060026CF RID: 9935
		public delegate void FactionApplicationProcessing_UserCallBack(FactionApplicationProcessing_ReturnType returnData);

		// Token: 0x020003EB RID: 1003
		// (Invoke) Token: 0x060026D3 RID: 9939
		public delegate GetParishMembersList_ReturnType RemoteAsyncDelegate_GetParishMembersList(int userID, int sessionID, int villageID);

		// Token: 0x020003EC RID: 1004
		// (Invoke) Token: 0x060026D7 RID: 9943
		public delegate void GetParishMembersList_UserCallBack(GetParishMembersList_ReturnType returnData);

		// Token: 0x020003ED RID: 1005
		// (Invoke) Token: 0x060026DB RID: 9947
		public delegate GetParishFrontPageInfo_ReturnType RemoteAsyncDelegate_GetParishFrontPageInfo(int userID, int sessionID, int villageID, DateTime lastTime);

		// Token: 0x020003EE RID: 1006
		// (Invoke) Token: 0x060026DF RID: 9951
		public delegate void GetParishFrontPageInfo_UserCallBack(GetParishFrontPageInfo_ReturnType returnData);

		// Token: 0x020003EF RID: 1007
		// (Invoke) Token: 0x060026E3 RID: 9955
		public delegate ParishWallDetailInfo_ReturnType RemoteAsyncDelegate_ParishWallDetailInfo(int userID, int sessionID, int parishCapitalID, long wallInfoID, int targetUserId, int type);

		// Token: 0x020003F0 RID: 1008
		// (Invoke) Token: 0x060026E7 RID: 9959
		public delegate void ParishWallDetailInfo_UserCallBack(ParishWallDetailInfo_ReturnType returnData);

		// Token: 0x020003F1 RID: 1009
		// (Invoke) Token: 0x060026EB RID: 9963
		public delegate StandDownAsParishDespot_ReturnType RemoteAsyncDelegate_StandDownAsParishDespot(int userID, int sessionID, int villageID);

		// Token: 0x020003F2 RID: 1010
		// (Invoke) Token: 0x060026EF RID: 9967
		public delegate void StandDownAsParishDespot_UserCallBack(StandDownAsParishDespot_ReturnType returnData);

		// Token: 0x020003F3 RID: 1011
		// (Invoke) Token: 0x060026F3 RID: 9971
		public delegate MakeParishVote_ReturnType RemoteAsyncDelegate_MakeParishVote(int userID, int sessionID, int villageID, int votedUserID);

		// Token: 0x020003F4 RID: 1012
		// (Invoke) Token: 0x060026F7 RID: 9975
		public delegate void MakeParishVote_UserCallBack(MakeParishVote_ReturnType returnData);

		// Token: 0x020003F5 RID: 1013
		// (Invoke) Token: 0x060026FB RID: 9979
		public delegate SendTroopsToCapital_ReturnType RemoteAsyncDelegate_SendTroopsToCapital(int userID, int sessionID, int sourceVillageID, int targetVillageID, int peasants, int archers, int pikemen, int swordsmen, int catapults);

		// Token: 0x020003F6 RID: 1014
		// (Invoke) Token: 0x060026FF RID: 9983
		public delegate void SendTroopsToCapital_UserCallBack(SendTroopsToCapital_ReturnType returnData);

		// Token: 0x020003F7 RID: 1015
		// (Invoke) Token: 0x06002703 RID: 9987
		public delegate GetCapitalBarracksSpace_ReturnType RemoteAsyncDelegate_GetCapitalBarracksSpace(int userID, int sessionID, int sourceVillageID, int targetVillageID);

		// Token: 0x020003F8 RID: 1016
		// (Invoke) Token: 0x06002707 RID: 9991
		public delegate void GetCapitalBarracksSpace_UserCallBack(GetCapitalBarracksSpace_ReturnType returnData);

		// Token: 0x020003F9 RID: 1017
		// (Invoke) Token: 0x0600270B RID: 9995
		public delegate GetCountyElectionInfo_ReturnType RemoteAsyncDelegate_GetCountyElectionInfo(int userID, int sessionID, int villageID);

		// Token: 0x020003FA RID: 1018
		// (Invoke) Token: 0x0600270F RID: 9999
		public delegate void GetCountyElectionInfo_UserCallBack(GetCountyElectionInfo_ReturnType returnData);

		// Token: 0x020003FB RID: 1019
		// (Invoke) Token: 0x06002713 RID: 10003
		public delegate GetCountyFrontPageInfo_ReturnType RemoteAsyncDelegate_GetCountyFrontPageInfo(int userID, int sessionID, int villageID);

		// Token: 0x020003FC RID: 1020
		// (Invoke) Token: 0x06002717 RID: 10007
		public delegate void GetCountyFrontPageInfo_UserCallBack(GetCountyFrontPageInfo_ReturnType returnData);

		// Token: 0x020003FD RID: 1021
		// (Invoke) Token: 0x0600271B RID: 10011
		public delegate MakeCountyVote_ReturnType RemoteAsyncDelegate_MakeCountyVote(int userID, int sessionID, int villageID, int votedUserID);

		// Token: 0x020003FE RID: 1022
		// (Invoke) Token: 0x0600271F RID: 10015
		public delegate void MakeCountyVote_UserCallBack(MakeCountyVote_ReturnType returnData);

		// Token: 0x020003FF RID: 1023
		// (Invoke) Token: 0x06002723 RID: 10019
		public delegate GetProvinceElectionInfo_ReturnType RemoteAsyncDelegate_GetProvinceElectionInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000400 RID: 1024
		// (Invoke) Token: 0x06002727 RID: 10023
		public delegate void GetProvinceElectionInfo_UserCallBack(GetProvinceElectionInfo_ReturnType returnData);

		// Token: 0x02000401 RID: 1025
		// (Invoke) Token: 0x0600272B RID: 10027
		public delegate GetProvinceFrontPageInfo_ReturnType RemoteAsyncDelegate_GetProvinceFrontPageInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000402 RID: 1026
		// (Invoke) Token: 0x0600272F RID: 10031
		public delegate void GetProvinceFrontPageInfo_UserCallBack(GetProvinceFrontPageInfo_ReturnType returnData);

		// Token: 0x02000403 RID: 1027
		// (Invoke) Token: 0x06002733 RID: 10035
		public delegate MakeProvinceVote_ReturnType RemoteAsyncDelegate_MakeProvinceVote(int userID, int sessionID, int villageID, int votedUserID);

		// Token: 0x02000404 RID: 1028
		// (Invoke) Token: 0x06002737 RID: 10039
		public delegate void MakeProvinceVote_UserCallBack(MakeProvinceVote_ReturnType returnData);

		// Token: 0x02000405 RID: 1029
		// (Invoke) Token: 0x0600273B RID: 10043
		public delegate GetCountryElectionInfo_ReturnType RemoteAsyncDelegate_GetCountryElectionInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000406 RID: 1030
		// (Invoke) Token: 0x0600273F RID: 10047
		public delegate void GetCountryElectionInfo_UserCallBack(GetCountryElectionInfo_ReturnType returnData);

		// Token: 0x02000407 RID: 1031
		// (Invoke) Token: 0x06002743 RID: 10051
		public delegate GetCountryFrontPageInfo_ReturnType RemoteAsyncDelegate_GetCountryFrontPageInfo(int userID, int sessionID, int villageID);

		// Token: 0x02000408 RID: 1032
		// (Invoke) Token: 0x06002747 RID: 10055
		public delegate void GetCountryFrontPageInfo_UserCallBack(GetCountryFrontPageInfo_ReturnType returnData);

		// Token: 0x02000409 RID: 1033
		// (Invoke) Token: 0x0600274B RID: 10059
		public delegate MakeCountryVote_ReturnType RemoteAsyncDelegate_MakeCountryVote(int userID, int sessionID, int villageID, int votedUserID);

		// Token: 0x0200040A RID: 1034
		// (Invoke) Token: 0x0600274F RID: 10063
		public delegate void MakeCountryVote_UserCallBack(MakeCountryVote_ReturnType returnData);

		// Token: 0x0200040B RID: 1035
		// (Invoke) Token: 0x06002753 RID: 10067
		public delegate GetIngameMessage_ReturnType RemoteAsyncDelegate_GetIngameMessage(int userID, int sessionID);

		// Token: 0x0200040C RID: 1036
		// (Invoke) Token: 0x06002757 RID: 10071
		public delegate void GetIngameMessage_UserCallBack(GetIngameMessage_ReturnType returnData);

		// Token: 0x0200040D RID: 1037
		// (Invoke) Token: 0x0600275B RID: 10075
		public delegate CancelInterdiction_ReturnType RemoteAsyncDelegate_CancelInterdiction(int userID, int sessionID, int villageID);

		// Token: 0x0200040E RID: 1038
		// (Invoke) Token: 0x0600275F RID: 10079
		public delegate void CancelInterdiction_UserCallBack(CancelInterdiction_ReturnType returnData);

		// Token: 0x0200040F RID: 1039
		// (Invoke) Token: 0x06002763 RID: 10083
		public delegate GetExcommunicationStatus_ReturnType RemoteAsyncDelegate_GetExcommunicationStatus(int userID, int sessionID, int villageID, int targetVillageID);

		// Token: 0x02000410 RID: 1040
		// (Invoke) Token: 0x06002767 RID: 10087
		public delegate void GetExcommunicationStatus_UserCallBack(GetExcommunicationStatus_ReturnType returnData);

		// Token: 0x02000411 RID: 1041
		// (Invoke) Token: 0x0600276B RID: 10091
		public delegate DisbandTroops_ReturnType RemoteAsyncDelegate_DisbandTroops(int userID, int sessionID, int villageID, int troopType, int amount);

		// Token: 0x02000412 RID: 1042
		// (Invoke) Token: 0x0600276F RID: 10095
		public delegate void DisbandTroops_UserCallBack(DisbandTroops_ReturnType returnData);

		// Token: 0x02000413 RID: 1043
		// (Invoke) Token: 0x06002773 RID: 10099
		public delegate DisbandPeople_ReturnType RemoteAsyncDelegate_DisbandPeople(int userID, int sessionID, int villageID, int troopType, int amount);

		// Token: 0x02000414 RID: 1044
		// (Invoke) Token: 0x06002777 RID: 10103
		public delegate void DisbandPeople_UserCallBack(DisbandPeople_ReturnType returnData);

		// Token: 0x02000415 RID: 1045
		// (Invoke) Token: 0x0600277B RID: 10107
		public delegate GetVillageInfoForDonateCapitalGoods_ReturnType RemoteAsyncDelegate_GetVillageInfoForDonateCapitalGoods(int userID, int sessionID, int parishCapitalID, int targetBuildingType);

		// Token: 0x02000416 RID: 1046
		// (Invoke) Token: 0x0600277F RID: 10111
		public delegate void GetVillageInfoForDonateCapitalGoods_UserCallBack(GetVillageInfoForDonateCapitalGoods_ReturnType returnData);

		// Token: 0x02000417 RID: 1047
		// (Invoke) Token: 0x06002783 RID: 10115
		public delegate DonateCapitalGoods_ReturnType RemoteAsyncDelegate_DonateCapitalGoods(int userID, int sessionID, int targetVillageID, int sourceVillageID, int resourceType, int amount, int buildingType, long targetBuildingID);

		// Token: 0x02000418 RID: 1048
		// (Invoke) Token: 0x06002787 RID: 10119
		public delegate void DonateCapitalGoods_UserCallBack(DonateCapitalGoods_ReturnType returnData);

		// Token: 0x02000419 RID: 1049
		// (Invoke) Token: 0x0600278B RID: 10123
		public delegate GetVillageStartLocations_ReturnType RemoteAsyncDelegate_GetVillageStartLocations(int userID, int sessionID);

		// Token: 0x0200041A RID: 1050
		// (Invoke) Token: 0x0600278F RID: 10127
		public delegate void GetVillageStartLocations_UserCallBack(GetVillageStartLocations_ReturnType returnData);

		// Token: 0x0200041B RID: 1051
		// (Invoke) Token: 0x06002793 RID: 10131
		public delegate SetStartingCounty_ReturnType RemoteAsyncDelegate_SetStartingCounty(int userID, int sessionID, int countyID);

		// Token: 0x0200041C RID: 1052
		// (Invoke) Token: 0x06002797 RID: 10135
		public delegate void SetStartingCounty_UserCallBack(SetStartingCounty_ReturnType returnData);

		// Token: 0x0200041D RID: 1053
		// (Invoke) Token: 0x0600279B RID: 10139
		public delegate CancelCard_ReturnType RemoteAsyncDelegate_CancelCard(int userID, int sessionID, int card);

		// Token: 0x0200041E RID: 1054
		// (Invoke) Token: 0x0600279F RID: 10143
		public delegate void CancelCard_UserCallBack(CancelCard_ReturnType returnData);

		// Token: 0x0200041F RID: 1055
		// (Invoke) Token: 0x060027A3 RID: 10147
		public delegate UpdateCurrentCards_ReturnType RemoteAsyncDelegate_UpdateCurrentCards(int userID, int sessionID);

		// Token: 0x02000420 RID: 1056
		// (Invoke) Token: 0x060027A7 RID: 10151
		public delegate void UpdateCurrentCards_UserCallBack(UpdateCurrentCards_ReturnType returnData);

		// Token: 0x02000421 RID: 1057
		// (Invoke) Token: 0x060027AB RID: 10155
		public delegate TutorialCommand_ReturnType RemoteAsyncDelegate_TutorialCommand(int userID, int sessionID, int tutorialAction);

		// Token: 0x02000422 RID: 1058
		// (Invoke) Token: 0x060027AF RID: 10159
		public delegate void TutorialCommand_UserCallBack(TutorialCommand_ReturnType returnData);

		// Token: 0x02000423 RID: 1059
		// (Invoke) Token: 0x060027B3 RID: 10163
		public delegate GetQuestStatus_ReturnType RemoteAsyncDelegate_GetQuestStatus(int userID, int sessionID);

		// Token: 0x02000424 RID: 1060
		// (Invoke) Token: 0x060027B7 RID: 10167
		public delegate void GetQuestStatus_UserCallBack(GetQuestStatus_ReturnType returnData);

		// Token: 0x02000425 RID: 1061
		// (Invoke) Token: 0x060027BB RID: 10171
		public delegate CompleteQuest_ReturnType RemoteAsyncDelegate_CompleteQuest(int userID, int sessionID, int quest);

		// Token: 0x02000426 RID: 1062
		// (Invoke) Token: 0x060027BF RID: 10175
		public delegate void CompleteQuest_UserCallBack(CompleteQuest_ReturnType returnData);

		// Token: 0x02000427 RID: 1063
		// (Invoke) Token: 0x060027C3 RID: 10179
		public delegate FlagQuestObjectiveComplete_ReturnType RemoteAsyncDelegate_FlagQuestObjectiveComplete(int userID, int sessionID, int objective);

		// Token: 0x02000428 RID: 1064
		// (Invoke) Token: 0x060027C7 RID: 10183
		public delegate void FlagQuestObjectiveComplete_UserCallBack(FlagQuestObjectiveComplete_ReturnType returnData);

		// Token: 0x02000429 RID: 1065
		// (Invoke) Token: 0x060027CB RID: 10187
		public delegate CheckQuestObjectiveComplete_ReturnType RemoteAsyncDelegate_CheckQuestObjectiveComplete(int userID, int sessionID, int quest);

		// Token: 0x0200042A RID: 1066
		// (Invoke) Token: 0x060027CF RID: 10191
		public delegate void CheckQuestObjectiveComplete_UserCallBack(CheckQuestObjectiveComplete_ReturnType returnData);

		// Token: 0x0200042B RID: 1067
		// (Invoke) Token: 0x060027D3 RID: 10195
		public delegate UpdateDiplomacyStatus_ReturnType RemoteAsyncDelegate_UpdateDiplomacyStatus(int userID, int sessionID, bool state);

		// Token: 0x0200042C RID: 1068
		// (Invoke) Token: 0x060027D7 RID: 10199
		public delegate void UpdateDiplomacyStatus_UserCallBack(UpdateDiplomacyStatus_ReturnType returnData);

		// Token: 0x0200042D RID: 1069
		// (Invoke) Token: 0x060027DB RID: 10203
		public delegate SendCommands_ReturnType RemoteAsyncDelegate_SendCommands(int userID, int sessionID, int targetUserID, int command, int duration, string reason);

		// Token: 0x0200042E RID: 1070
		// (Invoke) Token: 0x060027DF RID: 10207
		public delegate void SendCommands_UserCallBack(SendCommands_ReturnType returnData);

		// Token: 0x0200042F RID: 1071
		// (Invoke) Token: 0x060027E3 RID: 10211
		public delegate InitialiseFreeCards_ReturnType RemoteAsyncDelegate_InitialiseFreeCards(int userID, int sessionID);

		// Token: 0x02000430 RID: 1072
		// (Invoke) Token: 0x060027E7 RID: 10215
		public delegate void InitialiseFreeCards_UserCallBack(InitialiseFreeCards_ReturnType returnData);

		// Token: 0x02000431 RID: 1073
		// (Invoke) Token: 0x060027EB RID: 10219
		public delegate TestAchievements_ReturnType RemoteAsyncDelegate_TestAchievements(int userID, int sessionID, List<int> achievementsToTest, List<AchievementData> achievementData);

		// Token: 0x02000432 RID: 1074
		// (Invoke) Token: 0x060027EF RID: 10223
		public delegate void TestAchievements_UserCallBack(TestAchievements_ReturnType returnData);

		// Token: 0x02000433 RID: 1075
		// (Invoke) Token: 0x060027F3 RID: 10227
		public delegate AchievementProgress_ReturnType RemoteAsyncDelegate_AchievementProgress(int userID, int sessionID);

		// Token: 0x02000434 RID: 1076
		// (Invoke) Token: 0x060027F7 RID: 10231
		public delegate void AchievementProgress_UserCallBack(AchievementProgress_ReturnType returnData);

		// Token: 0x02000435 RID: 1077
		// (Invoke) Token: 0x060027FB RID: 10235
		public delegate GetQuestData_ReturnType RemoteAsyncDelegate_GetQuestData(int userID, int sessionID, bool full);

		// Token: 0x02000436 RID: 1078
		// (Invoke) Token: 0x060027FF RID: 10239
		public delegate void GetQuestData_UserCallBack(GetQuestData_ReturnType returnData);

		// Token: 0x02000437 RID: 1079
		// (Invoke) Token: 0x06002803 RID: 10243
		public delegate StartNewQuest_ReturnType RemoteAsyncDelegate_StartNewQuest(int userID, int sessionID, int questID);

		// Token: 0x02000438 RID: 1080
		// (Invoke) Token: 0x06002807 RID: 10247
		public delegate void StartNewQuest_UserCallBack(StartNewQuest_ReturnType returnData);

		// Token: 0x02000439 RID: 1081
		// (Invoke) Token: 0x0600280B RID: 10251
		public delegate CompleteAbandonNewQuest_ReturnType RemoteAsyncDelegate_CompleteAbandonNewQuest(int userID, int sessionID, int questID, bool abandon, bool glory, int villageID);

		// Token: 0x0200043A RID: 1082
		// (Invoke) Token: 0x0600280F RID: 10255
		public delegate void CompleteAbandonNewQuest_UserCallBack(CompleteAbandonNewQuest_ReturnType returnData);

		// Token: 0x0200043B RID: 1083
		// (Invoke) Token: 0x06002813 RID: 10259
		public delegate SpinTheWheel_ReturnType RemoteAsyncDelegate_SpinTheWheel(int userID, int sessionID, int villageID, int wheelType);

		// Token: 0x0200043C RID: 1084
		// (Invoke) Token: 0x06002817 RID: 10263
		public delegate void SpinTheWheel_UserCallBack(SpinTheWheel_ReturnType returnData);

		// Token: 0x0200043D RID: 1085
		// (Invoke) Token: 0x0600281B RID: 10267
		public delegate SetVacationMode_ReturnType RemoteAsyncDelegate_SetVacationMode(int userID, int sessionID, int numDays);

		// Token: 0x0200043E RID: 1086
		// (Invoke) Token: 0x0600281F RID: 10271
		public delegate void SetVacationMode_UserCallBack(SetVacationMode_ReturnType returnData);

		// Token: 0x0200043F RID: 1087
		// (Invoke) Token: 0x06002823 RID: 10275
		public delegate PremiumOverview_ReturnType RemoteAsyncDelegate_PremiumOverview(int userID, int sessionID);

		// Token: 0x02000440 RID: 1088
		// (Invoke) Token: 0x06002827 RID: 10279
		public delegate void PremiumOverview_UserCallBack(PremiumOverview_ReturnType returnData);

		// Token: 0x02000441 RID: 1089
		// (Invoke) Token: 0x0600282B RID: 10283
		public delegate GetLastAttacker_ReturnType RemoteAsyncDelegate_GetLastAttacker(int userID, int sessionID);

		// Token: 0x02000442 RID: 1090
		// (Invoke) Token: 0x0600282F RID: 10287
		public delegate void GetLastAttacker_UserCallBack(GetLastAttacker_ReturnType returnData);

		// Token: 0x02000443 RID: 1091
		// (Invoke) Token: 0x06002833 RID: 10291
		public delegate PreValidateCardToBePlayed_ReturnType RemoteAsyncDelegate_PreValidateCardToBePlayed(int userID, int sessionID, int card, int data);

		// Token: 0x02000444 RID: 1092
		// (Invoke) Token: 0x06002837 RID: 10295
		public delegate void PreValidateCardToBePlayed_UserCallBack(PreValidateCardToBePlayed_ReturnType returnData);

		// Token: 0x02000445 RID: 1093
		// (Invoke) Token: 0x0600283B RID: 10299
		public delegate GetInvasionInfo_ReturnType RemoteAsyncDelegate_GetInvasionInfo(int userID, int sessionID);

		// Token: 0x02000446 RID: 1094
		// (Invoke) Token: 0x0600283F RID: 10303
		public delegate void GetInvasionInfo_UserCallBack(GetInvasionInfo_ReturnType returnData);

		// Token: 0x02000447 RID: 1095
		// (Invoke) Token: 0x06002843 RID: 10307
		public delegate WorldInfo_ReturnType RemoteAsyncDelegate_WorldInfo();

		// Token: 0x02000448 RID: 1096
		// (Invoke) Token: 0x06002847 RID: 10311
		public delegate void WorldInfo_UserCallBack(WorldInfo_ReturnType returnData);

		// Token: 0x02000449 RID: 1097
		// (Invoke) Token: 0x0600284B RID: 10315
		public delegate EndWorld_ReturnType RemoteAsyncDelegate_EndWorld(int userID, int sessionsID);

		// Token: 0x0200044A RID: 1098
		// (Invoke) Token: 0x0600284F RID: 10319
		public delegate void EndWorld_UserCallBack(EndWorld_ReturnType returnData);

		// Token: 0x0200044B RID: 1099
		// (Invoke) Token: 0x06002853 RID: 10323
		public delegate EndOfTheWorldStats_ReturnType RemoteAsyncDelegate_EndOfTheWorldStats(int userID, int sessionsID);

		// Token: 0x0200044C RID: 1100
		// (Invoke) Token: 0x06002857 RID: 10327
		public delegate void EndOfTheWorldStats_UserCallBack(EndOfTheWorldStats_ReturnType returnData);

		// Token: 0x0200044D RID: 1101
		// (Invoke) Token: 0x0600285B RID: 10331
		public delegate GetKillStreakData_ReturnType RemoteAsyncDelegate_GetKillStreakData(int userID, int sessionsID);

		// Token: 0x0200044E RID: 1102
		// (Invoke) Token: 0x0600285F RID: 10335
		public delegate void GetKillStreakData_UserCallBack(GetKillStreakData_ReturnType returnData);

		// Token: 0x0200044F RID: 1103
		// (Invoke) Token: 0x06002863 RID: 10339
		public delegate GetUserContestData_ReturnType RemoteAsyncDelegate_GetUserContestData(int userID, int sessionID, int contestID);

		// Token: 0x02000450 RID: 1104
		// (Invoke) Token: 0x06002867 RID: 10343
		public delegate void GetUserContestData_UserCallBack(GetUserContestData_ReturnType returnData);

		// Token: 0x02000451 RID: 1105
		// (Invoke) Token: 0x0600286B RID: 10347
		public delegate GetContestDataRange_ReturnType RemoteAsyncDelegate_GetContestDataRange(int userID, int sessionID, int contestID, int topIndex, int numEntries, int rankBand);

		// Token: 0x02000452 RID: 1106
		// (Invoke) Token: 0x0600286F RID: 10351
		public delegate void GetContestDataRange_UserCallBack(GetContestDataRange_ReturnType returnData);

		// Token: 0x02000453 RID: 1107
		// (Invoke) Token: 0x06002873 RID: 10355
		public delegate GetContestHistoryIDs_ReturnType RemoteAsyncDelegate_GetContestHistoryIDs(int userID, int sessionID);

		// Token: 0x02000454 RID: 1108
		// (Invoke) Token: 0x06002877 RID: 10359
		public delegate void GetContestHistoryIDs_UserCallBack(GetContestHistoryIDs_ReturnType returnData);

		// Token: 0x02000455 RID: 1109
		// (Invoke) Token: 0x0600287B RID: 10363
		public delegate Chat_Login_ReturnType RemoteAsyncDelegate_Chat_Login(int userID, int sessionID);

		// Token: 0x02000456 RID: 1110
		// (Invoke) Token: 0x0600287F RID: 10367
		public delegate void Chat_Login_UserCallBack(Chat_Login_ReturnType returnData);

		// Token: 0x02000457 RID: 1111
		// (Invoke) Token: 0x06002883 RID: 10371
		public delegate Chat_Logout_ReturnType RemoteAsyncDelegate_Chat_Logout(int userID, int sessionID);

		// Token: 0x02000458 RID: 1112
		// (Invoke) Token: 0x06002887 RID: 10375
		public delegate void Chat_Logout_UserCallBack(Chat_Logout_ReturnType returnData);

		// Token: 0x02000459 RID: 1113
		// (Invoke) Token: 0x0600288B RID: 10379
		public delegate Chat_SetReceivingState_ReturnType RemoteAsyncDelegate_Chat_SetReceivingState(int userID, int sessionID, bool state);

		// Token: 0x0200045A RID: 1114
		// (Invoke) Token: 0x0600288F RID: 10383
		public delegate void Chat_SetReceivingState_UserCallBack(Chat_SetReceivingState_ReturnType returnData);

		// Token: 0x0200045B RID: 1115
		// (Invoke) Token: 0x06002893 RID: 10387
		public delegate Chat_SendText_ReturnType RemoteAsyncDelegate_Chat_SendText(int userID, int sessionID, int roomType, int roomID, string text, bool filter);

		// Token: 0x0200045C RID: 1116
		// (Invoke) Token: 0x06002897 RID: 10391
		public delegate void Chat_SendText_UserCallBack(Chat_SendText_ReturnType returnData);

		// Token: 0x0200045D RID: 1117
		// (Invoke) Token: 0x0600289B RID: 10395
		public delegate Chat_ReceiveText_ReturnType RemoteAsyncDelegate_Chat_ReceiveText(int userID, int sessionID, List<Chat_RoomID> roomsToRegister, bool changeRooms, bool filter);

		// Token: 0x0200045E RID: 1118
		// (Invoke) Token: 0x0600289F RID: 10399
		public delegate void Chat_ReceiveText_UserCallBack(Chat_ReceiveText_ReturnType returnData);

		// Token: 0x0200045F RID: 1119
		// (Invoke) Token: 0x060028A3 RID: 10403
		public delegate Chat_SendParishText_ReturnType RemoteAsyncDelegate_Chat_SendParishText(int userID, int sessionID, int parishID, int subForumID, string text, DateTime lastTime, bool filter);

		// Token: 0x02000460 RID: 1120
		// (Invoke) Token: 0x060028A7 RID: 10407
		public delegate void Chat_SendParishText_UserCallBack(Chat_SendParishText_ReturnType returnData);

		// Token: 0x02000461 RID: 1121
		// (Invoke) Token: 0x060028AB RID: 10411
		public delegate Chat_ReceiveParishText_ReturnType RemoteAsyncDelegate_Chat_ReceiveParishText(int userID, int sessionID, int parishID, DateTime lastTime, bool filter);

		// Token: 0x02000462 RID: 1122
		// (Invoke) Token: 0x060028AF RID: 10415
		public delegate void Chat_ReceiveParishText_UserCallBack(Chat_ReceiveParishText_ReturnType returnData);

		// Token: 0x02000463 RID: 1123
		// (Invoke) Token: 0x060028B3 RID: 10419
		public delegate Chat_BackFillParishText_ReturnType RemoteAsyncDelegate_Chat_BackFillParishText(int userID, int sessionID, int parishID, int subPage, long oldestIDDownloaded, DateTime oldestTime, bool filter);

		// Token: 0x02000464 RID: 1124
		// (Invoke) Token: 0x060028B7 RID: 10423
		public delegate void Chat_BackFillParishText_UserCallBack(Chat_BackFillParishText_ReturnType returnData);

		// Token: 0x02000465 RID: 1125
		// (Invoke) Token: 0x060028BB RID: 10427
		public delegate Chat_MarkParishTextRead_ReturnType RemoteAsyncDelegate_Chat_MarkParishTextRead(int userID, int sessionID, int parishID, int pageID, long readID);

		// Token: 0x02000466 RID: 1126
		// (Invoke) Token: 0x060028BF RID: 10431
		public delegate void Chat_MarkParishTextRead_UserCallBack(Chat_MarkParishTextRead_ReturnType returnData);

		// Token: 0x02000467 RID: 1127
		// (Invoke) Token: 0x060028C3 RID: 10435
		public delegate Chat_Admin_Command_ReturnType RemoteAsyncDelegate_Chat_Admin_Command(int userID, int sessionID, int command, int targetUserID);

		// Token: 0x02000468 RID: 1128
		// (Invoke) Token: 0x060028C7 RID: 10439
		public delegate void Chat_Admin_Command_UserCallBack(Chat_Admin_Command_ReturnType returnData);

		// Token: 0x02000469 RID: 1129
		// (Invoke) Token: 0x060028CB RID: 10443
		public delegate void CommonData_UserCallBack(Common_ReturnData returnData);

		// Token: 0x0200046A RID: 1130
		public class RTT_Log_data
		{
			// Token: 0x040031DB RID: 12763
			public Type packetType;

			// Token: 0x040031DC RID: 12764
			public int time;
		}
	}
}
