using es.upm.fi.rmi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


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

    public OnlineManager onlineManager;
    public AvatarManager avatarManager;
    public DsManager dsManager;
    public ChatManager chatManager;
    // Use this for initialization
    void Start() {
        avatarPanel = GameObject.Find("AvatarPanel").GetComponent<AvatarPanel>();

        restoreFlag = false;
        DataMaster.GameClient = this;
        cookie = "defaultCookie";
    }

    // Update is called once per frame
    void Update() {

    }

    public void ConnectGameServer(string serverIp, int serverPort, string cookie)
    {
        this.cookie = cookie;
        ConnectGameServer(serverIp, serverPort);
    }

    public void ConnectGameServer(string serverIp, int serverPort)
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


    public void ConnectOlineService(string userName, string password, int avatarId = 0)
    {
        //this.avatarId = avatarId;
        this.userName = userName;

        onlineManager = OnlineManager.InitOnlineManager("127.0.0.1", 4060);

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
            asyncSceneLoad = SceneManager.LoadSceneAsync(scLoginMessage.sceneName);
            StartCoroutine(CheckLoadState());
            
        } else if(LoginState.REJECT == scLoginMessage.loginState)
        {
            
        }

        Debug.Log(string.Format("SC_Login scLoginMessage:{0}", scLoginMessage.loginState));

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
        InventoryManager inventoryManager = InventoryManager.GetInstance();
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

}