using UnityEngine;
using UnityEngine.UI;
using es.upm.fi.rmi;
using System;


// ServerListMgr manages the servers info received from Online Service
public class ServerListMgr : MonoBehaviour {
    public Button servEntryButtonFab;
    private GameClient gameClient;

    private RectTransform parentPanel;

    public Button restoreButtonFab;
    // Use this for initialization
    void Start () {
        gameClient = DataMaster.GameClient;

        parentPanel = GameObject.Find("ServerListPanel").GetComponent<RectTransform>(); 

        int index = 0;
        foreach(ServerEntry servEntry in gameClient.servInfo.serverInfoSeq)
        {
            Button bt = Instantiate<Button>(servEntryButtonFab, new Vector3(0, -60.0f-80.0f*index++, 0), Quaternion.identity);
            bt.GetComponentInChildren<Text>().text = servEntry.name + "  " + servEntry.servAddr;
            bt.transform.SetParent(parentPanel, false);

            ServEntryButton servEntryButton = bt.GetComponent<ServEntryButton>();
            string[]  strIPAndPort = servEntry.servAddr.Split(':');
            servEntryButton.setServIP(strIPAndPort[0]);
            servEntryButton.setServPort(Int32.Parse(strIPAndPort[1]));

            Debug.Log(servEntry.servAddr);
        }

        AvatarState avatarState = gameClient.avatarManager.GetAvatarState(gameClient.userName);
        gameClient.restoreServEntry = avatarState.serverEntry;

        Button btRestore = Instantiate<Button>(restoreButtonFab, new Vector3(0, -60.0f - 80.0f * index++, 0), Quaternion.identity);
        btRestore.transform.SetParent(parentPanel, false);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}