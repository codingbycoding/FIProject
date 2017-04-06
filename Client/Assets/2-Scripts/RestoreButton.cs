using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

        string[] strIPAndPort = gameClient.restoreServEntry.servAddr.Split(':');

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