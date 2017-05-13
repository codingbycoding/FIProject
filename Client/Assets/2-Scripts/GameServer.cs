using es.upm.fi.rmi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// GameServer only exists on game server just like GameClient only exists on game client.
// 
public class GameServer : BaseNetworkGameManager {
    public GameObject[] avatarPrefabs;

    private GameUserManager gameUserManager;
    private AsyncOperation asyncSceneLoad;

    // Use to connect online service
    private string onlineIP;
    private int onlinePort;

    // Use to initiate dedicate server
    private string sceneName;
	private string sceneLabelName;
    private string servIP;
    private int servPort;

    public OnlineManager onlineManager;
    public AvatarManager avatarManager;
    public DsManager dsManager;
    public ChatManager chatManager;

    [SerializeField]
    private int maxPlayersNum = 20;

	public string SceneLabelName {
		get { return sceneLabelName; }
	}
    //private ItemsFab itemsFab;
    // Use this for initialization
    void Start() {
        DataMaster.GameServer = this;
        StartGame();

        StartCoroutine(ServerSpawnObjects());

        //itemsFab = GetComponent<ItemsFab>();
        //SpawnItems();

        PrintRegisteredServerMsg();
        gameUserManager = GameUserManager.GetGameUserManager();
    }

	void OnDestroy() {
		print("GameServer Script was destroyed");
		onlineManager.Logout ();
	}


    void PrintRegisteredServerMsg()
    {
        Debug.Log("Print all the delegates of NetworkServer:");
        string msgTypes = "";

        foreach (KeyValuePair<short, NetworkMessageDelegate> entry in NetworkServer.handlers)
        {
            msgTypes += entry.Key;

            msgTypes += ": ";
            msgTypes += MsgType.MsgTypeToString(entry.Key);
            msgTypes += "    ";
        }

        Debug.Log("entry.keys:" + msgTypes);
    }


    //void SpawnItems()
    //{
    //    Vector3 vec3 = new Vector3(20f, 0.4f, 35f);
    //    Quaternion rotation = Quaternion.Euler(new Vector3(-40f, 0, 0));
    //    for (int i = 0; i < itemsFab.fabItems.Length - 1; i++)
    //    {
    //        vec3.x += i;
    //        NetworkServer.Spawn(Instantiate(itemsFab.fabItems[i], vec3, rotation));
    //    }

    //}


    void ParseParameters()
    {
        onlineIP = Util.GetArg("-OnlineIP");
        onlinePort = Util.GetArg("-OnlinePort", 0);
        sceneName = Util.GetArg("-SceneName");
		sceneLabelName = Util.GetArg("-SceneLabelName");
        servIP = Util.GetArg("-IP");
        servPort = Util.GetArg("-Port", 0);

        if (null == onlineIP || 0 == onlinePort 
			|| null == sceneName || null == sceneLabelName || null == servIP || 0 == servPort)
        {
            Debug.LogError("ParseParameters Failed. Check the parameters!!!");
        }
    }

    // Update is called once per frame
    void Update() {

    }
    void InitOnline()
    {
        //GameServerConnectOnlineService("GameServer.UserName", "GameServer.Password");
        GameServerConnectOnlineService("DS", "DS");

        ServerEntry servEntry = new ServerEntry();
		servEntry.name = sceneLabelName;
        servEntry.servAddr = networkAddress + ":" + networkPort;
        
        dsManager = DsManager.GetDsManager();
        dsManager.RegisterDs(servEntry);

    }

    public void GameServerConnectOnlineService(string userName, string password)
    {
        onlineManager = OnlineManager.InitOnlineManager(onlineIP, onlinePort);
        onlineManager.DsLogin(userName, password);

        avatarManager = AvatarManager.GetAvatarManager();
    }

    void StartGame()
    {
        ParseParameters();

        SceneManager.LoadScene(sceneName);

        networkAddress = servIP;
        networkPort = servPort;
        StartServer();

        RegisterServerHandlers();        

        if (!NetworkServer.SpawnObjects())
        {
            Debug.LogError("NetworkServer.SpawnObjects Failed !!!");
        }

        Debug.Log(string.Format("Starting GameServer SceneName:{0} IP:{1} Port:{2} OnlineIP:{3} OnlinePort:{4}", 
            sceneName, servIP, servPort, onlineIP, onlinePort));

        InitOnline();
    }

    void RegisterServerHandlers()
    {
        NetworkServer.RegisterHandler(CustomMsgType.CS_Login, CS_Login);
        NetworkServer.RegisterHandler(CustomMsgType.CS_RestoreState, CS_RestoreState);
        //NetworkServer.RegisterHandler(CustomMsgType.CS_ClientSceneReady, CS_ClientSceneReady); 
    }


    IEnumerator ServerSpawnObjects()
    {
        Debug.Log("ServerSpawnObjects Spawning Objects.");
        yield return new WaitForSeconds(2f);

        bool ret = NetworkServer.SpawnObjects();
        Debug.Log("ServerSpawnObjects state:" + ret.ToString());
    }

    // called when a client connects 
    public override void OnServerConnect(NetworkConnection conn)
    {
        if(numPlayers >= maxPlayersNum)
        {
            conn.Disconnect();
            Debug.Log(string.Format("OnServerConnect conn.ToString():{0} numPlayers({1}) >= maxPlayersNum({2})", 
                conn.ToString(), numPlayers, maxPlayersNum));
        }

        Debug.Log(string.Format("OnServerConnect conn.ToString():{0}", conn.ToString()));
    }

    // called when a client disconnects
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        gameUserManager.RemoveGameUser(conn);
        NetworkServer.DestroyPlayersForConnection(conn);

        Debug.Log(string.Format("OnServerDisconnect conn.ToString():{0}", conn.ToString()));
    }

    // called when a client is ready
    public override void OnServerReady(NetworkConnection conn)
    {
        Debug.Log(string.Format("OnServerReady conn.ToString():{0}", conn.ToString()));
        //NetworkServer.SetClientReady(conn);
        //GameUser gameUser = gameUserManager.GetGameUser(conn);

    }

    //private void CS_ClientSceneReady(NetworkMessage netMsg)
    //{
    //    //CSLoginMessage csLoginMessage = netMsg.ReadMessage<CSLoginMessage>();
    //    Debug.Log(string.Format("CS_ClientSceneReady cnetMsg.conn.ToString():{0}", netMsg.conn.ToString()));
    //    //NetworkServer.SetClientReady(conn);
    //    GameUser gameUser = userDictionary[netMsg.conn];
    //    NetworkServer.AddPlayerForConnection(netMsg.conn, gameUser.Avatar, 0);
    //}

    // called when a new player is added for a client
    //public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //base.OnServerAddPlayer(conn, playerControllerId);
        //var player = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
        //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        //CSLoginMessage csLoginMessage = extraMessageReader.ReadMessage<CSLoginMessage>();
        //Debug.Log(string.Format("extraMessageReader csLoginMessage.userName:{0} csLoginMessage.avatarId:{1} csLoginMessage.cookie:{2}", 
        //    csLoginMessage.userName, csLoginMessage.avatarId, csLoginMessage.cookie));


        //// GameObject posObj = GameObject.FindWithTag(csLoginMessage.cookie);
        //GameObject posObj = GameObject.Find(csLoginMessage.cookie);
        //GameObject avatar = null;
        //if (null == posObj)
        //{
        //    avatar = Instantiate(avatarPrefabs[csLoginMessage.avatarId], GetStartPosition().position, GetStartPosition().rotation) as GameObject;
        //}
        //else
        //{
        //    avatar = Instantiate(avatarPrefabs[csLoginMessage.avatarId], posObj.transform.position, posObj.transform.rotation) as GameObject;
        //}


        //if(null == avatar)
        //{
        //    Debug.LogError("OnServerAddPlayer null == avatar");
        //}

        //Debug.Log(string.Format("OnServerAddPlayer conn.ToString():{0}  playerControllerId:{1}", conn.ToString(), playerControllerId));

        //GameUser gameUser = new GameUser(csLoginMessage.userName, avatar, conn);
        //gameUserManager.AddGameUser(gameUser);        

        //SCLoginMessage scLoginMessage = new SCLoginMessage();
        //scLoginMessage.loginState = LoginState.ACCEPT;        
        //scLoginMessage.sceneName = SceneManager.GetActiveScene().name;

        //NetworkServer.SendToClient(conn.connectionId, CustomMsgType.SC_Login, scLoginMessage);
        //NetworkServer.SetClientReady(conn);

        GameUser gameUser = gameUserManager.GetGameUser(conn);
        NetworkServer.AddPlayerForConnection(conn, gameUser.Avatar, playerControllerId);

        NetworkServer.SendToClient(conn.connectionId, CustomMsgType.SC_PlayerReady, new SCPlayerReady());
        Debug.Log(string.Format("OnServerAddPlayer conn.ToString():{0}  playerControllerId:{1}", conn.ToString(), playerControllerId));
        
    }

    // called when a player is removed for a client
    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {
        gameUserManager.RemoveGameUser(conn);
        base.OnServerRemovePlayer(conn, player);

        //PlayerController player;
        //if (conn.GetPlayer(playerControllerId, out player))
        //{
        //    if (player.NetworkIdentity != null && player.NetworkIdentity.gameObject != null)
        //        NetworkServer.Destroy(player.NetworkIdentity.gameObject);
        //}

        Debug.Log(string.Format("OnServerRemovePlayer conn.ToString():{0}", conn.ToString()));
    }

    // called when a network error occurs
    public override void OnServerError(NetworkConnection conn, int errorCode)
    {

        Debug.Log(string.Format("OnServerError errorCode:{0}", errorCode));
    }


    public void CS_RestoreState(NetworkMessage netMsg)
    {
        CSRestoreState csRestoreState = netMsg.ReadMessage<CSRestoreState>();
        GameUser gameUser = gameUserManager.GetGameUser(csRestoreState.userName);

        AvatarState avatarState = avatarManager.GetAvatarState(csRestoreState.userName);
        gameUser.Avatar.transform.position = DataUtils.ToUPosition(avatarState.position);
        gameUser.Avatar.transform.rotation = DataUtils.ToURotation(avatarState.rotation);

        Debug.Log("CS_RestoreState userName:" + gameUser.UserName);
        Debug.Log(string.Format("gameUser.Avatar.transform.position:({0},{1},{2})", 
            gameUser.Avatar.transform.position.x,
            gameUser.Avatar.transform.position.y,
            gameUser.Avatar.transform.position.z));
    }

    public void CS_Login(NetworkMessage netMsg)
    {
        CSLoginMessage csLoginMessage = netMsg.ReadMessage<CSLoginMessage>();

        SCLoginMessage scLoginMessage = new SCLoginMessage();
        if (gameUserManager.HasGameUser(csLoginMessage.userName))
        {
            scLoginMessage.loginState = LoginState.REJECT;
            NetworkServer.SendToClient(netMsg.conn.connectionId, CustomMsgType.SC_Login, scLoginMessage);
            return;
        } 

		GameObject objJumpPoints = GameObject.Find ("JumpPoints");
		Transform posTransform = null;
		if(null != objJumpPoints) {
			posTransform = objJumpPoints.transform.FindChild("JumpPoint" + csLoginMessage.cookie + "/pos");
		}

        GameObject avatar = null;

        if (csLoginMessage.restoreFlag)
        {
            AvatarState avatarState = avatarManager.GetAvatarState(csLoginMessage.userName);
            Vector3 position = DataUtils.ToUPosition(avatarState.position);
            Quaternion rotation = DataUtils.ToURotation(avatarState.rotation);

            avatar = Instantiate(avatarPrefabs[csLoginMessage.avatarId], position, rotation) as GameObject;

            Debug.Log("csLoginMessage.restoreFlag: " + csLoginMessage.restoreFlag);
            Debug.Log(string.Format("transform.position:({0}, {1}, {2}",
                    position.x,
                    position.y,
                    position.z));
        }
		else if (null != posTransform)
        {
			avatar = Instantiate(avatarPrefabs[csLoginMessage.avatarId], posTransform.position, posTransform.rotation) as GameObject;
        }
        else
        {
            avatar = Instantiate(avatarPrefabs[csLoginMessage.avatarId], GetStartPosition().position, GetStartPosition().rotation) as GameObject;
        }


        if (null == avatar)
        {
            Debug.LogError("OnServerAddPlayer null == avatar");
        }

        GamePlayer gamePlayer = avatar.GetComponent<GamePlayer>();
        
        GameUser gameUser = new GameUser(csLoginMessage.userName, avatar, netMsg.conn);
        gamePlayer.UserName = gameUser.UserName;
        gameUserManager.AddGameUser(gameUser);

        scLoginMessage.loginState = LoginState.ACCEPT;
        scLoginMessage.sceneName = SceneManager.GetActiveScene().name;
        NetworkServer.SendToClient(netMsg.conn.connectionId, CustomMsgType.SC_Login, scLoginMessage);

        Debug.Log(string.Format("CS_Login csLoginMessage.userName:{0}", csLoginMessage.userName));
    }
}