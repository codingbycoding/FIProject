using UnityEngine;
using System.Collections;

public class ServEntryButton : MonoBehaviour {
    private GameClient gameClient;
    private string servIP;
    private int servPort;
    

    // Use this for initialization
    void Start () {
        gameClient = GameObject.Find("GameClient").GetComponent<GameClient>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void setServIP(string inServIP)
    {
        servIP = inServIP;
    }

    public void setServPort(int inPort)
    {
        servPort = inPort;
    }
    public void Connect()
    {
        Debug.Log("Connecting to server:" + servIP + ":" + servPort);
       gameClient.ConnectGameServer(servIP, servPort); 
    }
}
