﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using es.upm.fi.rmi;

// GameClient only exists on game client just like GameServer only exists on game server.
public class GameClient : BaseNetworkGameManager {

    private AsyncOperation asyncSceneLoad;
    private AvatarPanel avatarPanel;
    //private int avatarId;

    public ServerInfo servInfo { get; set; }
    public ServerEntry restoreServEntry { get; set; }
    public string userName { get; set; }
    public bool restoreFlag { get; set; }

    private string cookie;

	private string onlineIP;
//	private int onlinePort = 4060;

    public OnlineManager onlineManager;
    public AvatarManager avatarManager;
    public DsManager dsManager;
    public ChatManager chatManager;
	public InventoryManager inventoryManager;

	public string currentServerLabelName;

	private AssetBundle assetBundleScene;

	public Dictionary<string, string> serverLabelNameDict;
	public Dictionary<string, string> sceneNameDict;
	public Dictionary<string, ServerEntry> serverLabelName2AddrDict;
    // Use this for initialization
    void Start() {
        avatarPanel = GameObject.Find("AvatarPanel").GetComponent<AvatarPanel>();

        restoreFlag = false;
        DataMaster.GameClient = this;
        cookie = "defaultCookie";

		serverLabelNameDict = new Dictionary<string, string> ();
		serverLabelNameDict.Add ("City", "ServerScene_City");
		serverLabelNameDict.Add ("RoomInside", "ServerScene_RoomInside");
		serverLabelNameDict.Add ("GrassBridge", "ServerScene_GrassBridge");
		serverLabelNameDict.Add ("GrassHouse", "assetbundle_serverscene_grasshouse");

		sceneNameDict = new Dictionary<string, string> ();
		sceneNameDict.Add ("ServerScene_City", "City");
		sceneNameDict.Add ("ServerScene_RoomInside", "RoomInside");
		sceneNameDict.Add ("ServerScene_GrassBridge", "GrassBridge");
		sceneNameDict.Add ("assetbundle_serverscene_grasshouse", "GrassHouse");

		serverLabelName2AddrDict = new Dictionary<string, ServerEntry> ();
    }

	void OnDestroy() {
		print("GameClient Script was destroyed");
		//onlineManager.Logout ();
	}

    // Update is called once per frame
    void Update() {

    }

	public string OnlineIP {
		get { return onlineIP; }
	}

	public void ConnectGameServer(string serverIp, int serverPort, string cookie="", bool bClear=false)
    {		
		if (bClear) {
			ClearInventory();
		}

        this.cookie = cookie;
		ConnectGameServer (serverIp, serverPort);
    }

	//clear 
	private void ClearInventory() 
	{				
		Debug.Log("ClearInventory");
		inventoryManager.Delete();

	}

    private void ConnectGameServer(string serverIp, int serverPort)
    {
		networkAddress = serverIp;
		networkPort = serverPort;

		if(isNetworkActive)
		{
			StopClient();
		}

		StartClient();

		RegisterClientHandlers();

		PrintClientRegisteredMsg();
    }

    void RegisterClientHandlers()
    {
        client.RegisterHandler(CustomMsgType.SC_Login, SC_Login);
        client.RegisterHandler(CustomMsgType.SC_PlayerReady, SC_PlayerReady);
    }

    void PrintClientRegisteredMsg()
    {
        Debug.Log("Print all the delegates of NetworkClient:");
        string msgTypes = "";

        foreach (KeyValuePair<short, NetworkMessageDelegate> entry in client.handlers)
        {
            msgTypes += entry.Key;

            msgTypes += ": ";
            msgTypes += MsgType.MsgTypeToString(entry.Key);
            msgTypes += "    ";
        }

        Debug.Log("entry.keys:" + msgTypes);
    }

	public void ConnectOnlineService(string onlineIP, int onlinePort, string userName, string password, int avatarId = 0)
	{
        //this.avatarId = avatarId;
        this.userName = userName;
		this.onlineIP = onlineIP;

		onlineManager = OnlineManager.InitOnlineManager(onlineIP, onlinePort);

        if (!onlineManager.Login(userName, password))
        {
            Debug.LogError("Login Online Service Failed!!!");
            return;
        }

        chatManager = ChatManager.GetChatManager();
        avatarManager = AvatarManager.GetAvatarManager();

        servInfo = onlineManager.GetServerInfo();
        SceneManager.LoadScene("ServerList", LoadSceneMode.Single);
    }

    // called when connected to a server
    public override void OnClientConnect(NetworkConnection conn)
    {  
        CSLoginMessage csLoginMessage = new CSLoginMessage();
        csLoginMessage.userName = userName;
        csLoginMessage.avatarId = avatarPanel.AvatarCursor;
        csLoginMessage.cookie = cookie;
        
        if(restoreFlag == true)
        {
            csLoginMessage.restoreFlag = true;
            restoreFlag = false;
        }

        client.Send(CustomMsgType.CS_Login, csLoginMessage);

        Debug.Log(string.Format("OnClientConnect conn.ToString():{0} csLoginMessage.restoreFlag:{1}", conn.ToString(), csLoginMessage.restoreFlag));
    }

    
    // called when disconnected from a server
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        StopClient();
        SceneManager.LoadScene(0);

        Debug.Log(string.Format("OnClientDisconnect conn.ToString():{0}", conn.ToString()));
    }

    // called when a network error occurs
    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        StopClient();
        SceneManager.LoadScene(0);
        Debug.Log(string.Format("OnClientError conn.ToString():{0} errorCode:{1}", conn.ToString(), errorCode));
    }


    // called when told to be not-ready by a server
    public override void OnClientNotReady(NetworkConnection conn)
    {
        Debug.Log(string.Format("OnClientNotReady conn.ToString():{0}", conn.ToString()));
    }


    void SC_Login(NetworkMessage netMsg)
    {
        SCLoginMessage scLoginMessage = netMsg.ReadMessage<SCLoginMessage>();

        if(LoginState.ACCEPT == scLoginMessage.loginState)
        {
			if (scLoginMessage.sceneName.Substring (0, 11).Equals ("assetbundle")) {

				StartCoroutine(LoadAssetBundleScene(scLoginMessage.sceneName));

			} else {
				asyncSceneLoad = SceneManager.LoadSceneAsync(scLoginMessage.sceneName);
				currentServerLabelName = sceneNameDict[scLoginMessage.sceneName];

				StartCoroutine(CheckLoadState());
			}           
            
        } else if(LoginState.REJECT == scLoginMessage.loginState)
        {
            
        }

        Debug.Log(string.Format("SC_Login scLoginMessage:{0}", scLoginMessage.loginState));

    }



	IEnumerator LoadAssetBundleScene(string sceneName)
	{
		string bundleURL = "http://" + onlineIP + ":8080/FIProject_AssetBundles/scenes/" + sceneName;
		Debug.Log("LoadAssetBundleScene Scene:" + bundleURL);


		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		if (null != assetBundleScene)
		{
			assetBundleScene.Unload(true);
		}

		// Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
		using (WWW www = WWW.LoadFromCacheOrDownload(bundleURL, 0))
		{
			while (!www.isDone)
			{				
				yield return null;
			}
				
			//yield return www;


//			if (!string.IsNullOrEmpty(www.error))
//				throw new Exception("WWW download had an error:" + www.error);


			assetBundleScene = www.assetBundle;

		} 

		asyncSceneLoad = SceneManager.LoadSceneAsync(sceneName);
		currentServerLabelName = sceneNameDict[sceneName];
		StartCoroutine(CheckLoadState());
	}




    void SC_PlayerReady(NetworkMessage netMsg)
    {
        //if (restoreFlag == true)
        //{
        //    GameObject gbPlayer = DataMaster.GamePlayer;
        //    PlayerCommand playerCommand = gbPlayer.GetComponent<PlayerCommand>();
        //    playerCommand.CmdRestoreState();
        //    restoreFlag = false;
        //}

        ReqRestoreState();
    }

    private IEnumerator CheckLoadState()
    {
        yield return new WaitForSeconds(0.15f);

        if (asyncSceneLoad.isDone)
        {
            Debug.Log("AsyncSceneLod is done");           


            //CSLoginMessage csLoginMessage = new CSLoginMessage();
            //csLoginMessage.userName = userName;
            //csLoginMessage.avatarId = avatarPanel.AvatarCursor;
            //csLoginMessage.cookie = cookie;

            ClientScene.Ready(client.connection);
            ClientScene.AddPlayer(0);
            //ClientScene.AddPlayer(client.connection, 0, csLoginMessage);        

            //CSClientSceneReady csClientSceneReady = new CSClientSceneReady();
            //client.Send(CustomMsgType.CS_ClientSceneReady, csClientSceneReady);
            GetInventory();

            cookie = "";
        }
        else
        {
            StartCoroutine(CheckLoadState());
        }
    }


    private void GetInventory()
    {
        InventoryUI inventoryUI = GameObject.Find("Canvas").GetComponent<InventoryUI>();
		inventoryManager = InventoryManager.GetInstance();
        inventoryManager.SetInventoryUI(inventoryUI);
        inventoryManager.GetInventory();
    }

    public void ReqRestoreState()
    {
        if (restoreFlag == true)
        {
            CSRestoreState csRestoreState = new CSRestoreState();
            csRestoreState.userName = userName;

            client.Send(CustomMsgType.CS_RestoreState, csRestoreState);
            restoreFlag = false;

            Debug.Log("RequestRestoreState userName:" + userName);
        }

    }

	public void Logout() {

		ClearInventory();
		onlineManager.Logout();
	}

}