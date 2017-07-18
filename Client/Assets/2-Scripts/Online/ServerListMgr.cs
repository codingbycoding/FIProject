using UnityEngine;
using UnityEngine.UI;
using es.upm.fi.rmi;
using System;
using System.Collections;
using System.Collections.Generic;

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

		foreach(string serverLabelName in gameClient.serverLabelNameDict.Keys) {
			bool bMatched = false;

			Button bt = Instantiate<Button>(servEntryButtonFab, new Vector3(0, -60.0f-80.0f*index++, 0), Quaternion.identity);
			bt.transform.SetParent(parentPanel, false);
			bt.transform.Find ("AssetBundle").SetAsFirstSibling ();

			foreach(ServerEntry servEntry in gameClient.servInfo.serverInfoSeq)
			{						
				if(serverLabelName.Equals(servEntry.name)) {
					
					bt.transform.Find ("ServerName").GetComponent<Text> ().text = servEntry.name;// + "  " + servEntry.servAddr;

					ServEntryButton servEntryButton = bt.GetComponent<ServEntryButton>();
					string[]  strIPAndPort = servEntry.servAddr.Split(':');
					servEntryButton.setServIP(strIPAndPort[0]);
					servEntryButton.setServPort(Int32.Parse(strIPAndPort[1]));

					gameClient.serverLabelName2AddrDict[servEntry.name] = servEntry;
					Debug.Log(servEntry.name + "  " + servEntry.servAddr);

					bMatched = true;
					break;
				}
			}

			if(false == bMatched) {				
				bt.transform.Find("ServerName").GetComponent<Text>().text = serverLabelName;
				bt.transform.Find("ServerStatus").GetComponent<Text> ().text = "offline";
				bt.transform.Find("ServerStatus").GetComponent<Text> ().color = Color.red;
			}

			if(gameClient.serverLabelNameDict[serverLabelName].Length > 11 
				&& gameClient.serverLabelNameDict[serverLabelName].Substring (0, 11).Equals("assetbundle")) {
				bt.transform.Find ("AssetBundle").SetAsLastSibling ();
				AssetsBundleOp assetsBundleOp = bt.transform.Find ("AssetBundle").gameObject.GetComponent<AssetsBundleOp> ();
				assetsBundleOp.CheckCached(gameClient.serverLabelNameDict[serverLabelName], serverLabelName);
			}

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