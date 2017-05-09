using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using es.upm.fi.rmi;

// RestoreButton attachs to a button to restore player's last state(position, rotation...)
public class RestoreButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(delegate { Restore(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restore()
    {
        GameClient  gameClient = DataMaster.GameClient;
        gameClient.restoreFlag = true;

		if(!gameClient.serverLabelName2AddrDict.ContainsKey(gameClient.restoreServEntry.serverName)) {
			Debug.LogError("Server " + gameClient.restoreServEntry.serverName + " not exists or is not online");
			return;
		}

		ServerEntry serverEntry = gameClient.serverLabelName2AddrDict[gameClient.restoreServEntry.serverName];
		string[] strIPAndPort =  serverEntry.servAddr.Split(':');

        //string[] strIPAndPort = gameClient.restoreServEntry.servAddr.Split(':');

        int servPort = System.Int32.Parse(strIPAndPort[1]);
        string servIP = strIPAndPort[0];
        gameClient.ConnectGameServer(servIP, servPort);

        //Move to after client ready
        //GameObject gbPlayer = DataMaster.GamePlayer;
        //PlayerCommand playerCommand = gbPlayer.GetComponent<PlayerCommand>();
        //playerCommand.CmdRestoreState();


        //gameClient.ReqRestoreState();

        Debug.Log("Restore");
    }
}