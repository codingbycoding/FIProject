using es.upm.fi.rmi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


//PlayerCommand holds all the commands that player could invoke on the server
public class PlayerCommand : NetworkBehaviour {

    private ItemsFab itemsFab;
    // Use this for initialization

    public override void OnStartServer()
    {
        itemsFab = DataMaster.GameServer.GetComponent<ItemsFab>();
    }

    void Start () {        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    public void CmdSaveState()
    {
        GameServer gameServer = DataMaster.GameServer;

        AvatarState avatarState = new AvatarState();

        avatarState.position = DataUtils.ToRmiPosition(transform.position);
        avatarState.rotation = DataUtils.ToRmiRotation(transform.rotation);

        string servIPPort = gameServer.networkAddress;
        servIPPort += ":" + gameServer.networkPort;
		avatarState.serverEntry = new ServerEntry(gameServer.SceneLabelName, servIPPort, NetworkManager.networkSceneName);

        GamePlayer gamePlayer = GetComponent<GamePlayer>();
        gameServer.avatarManager.UpdateAvatar(gamePlayer.UserName, avatarState);
        
        Debug.Log("CmdSaveState from: " + gamePlayer.UserName);
        Debug.Log(string.Format("transform.position:({0}, {1}, {2}", 
            transform.position.x,
            transform.position.y,
            transform.position.z));
    }


    [Command]
    public void CmdRestoreState() {
        GameServer gameServer = DataMaster.GameServer;
        GamePlayer gamePlayer = GetComponent<GamePlayer>();

        AvatarState avatarState = gameServer.avatarManager.GetAvatarState(gamePlayer.UserName);
        transform.position = DataUtils.ToUPosition(avatarState.position);
        transform.rotation = DataUtils.ToURotation(avatarState.rotation);

        Debug.Log("CmdRestoreState from: " + gamePlayer.UserName);
        Debug.Log(string.Format("transform.position:({0}, {1}, {2}",
            transform.position.x,
            transform.position.y,
            transform.position.z));
    }

    [Command]
    public void CmdPickItem(NetworkInstanceId netId)
    {
        GameObject objItem = NetworkServer.FindLocalObject(netId);
        Item item = objItem.GetComponent<Item>();
		item.Iconize ();
        item.RpcIconize();
    }

    [Command]
    public void CmdDropItem(int itemId, Vector3 itemPosition)
    {
        GameObject gbItem = itemsFab.NewItem(itemId);
        gbItem.transform.position = itemPosition;
        NetworkServer.Spawn(gbItem);
        Debug.Log(string.Format("CmdDropItem position({0}, {1}, {2})", itemPosition.x, itemPosition.y, itemPosition.z));
    }
}