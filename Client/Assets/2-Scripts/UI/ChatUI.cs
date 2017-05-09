using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using es.upm.fi.rmi;

// ChatUI process the online chat message at UI layer.
public class ChatUI : MonoBehaviour {
    private Text text = null;
	private GameObject chatWarning = null;
    private InputField inputField = null;
    private GameClient gameClient = null;

    private Dictionary<string, string> senderColorDic = null;
    private List<string> colorList = null;
    private HashSet<string> chattingUser = null;

	private string defaultColor = "orange";
	// Use this for initialization
	void Start () {
        text = GameObject.Find("ChatText").GetComponent<Text>();
        text.text = text.text + "\r\n";
		chatWarning = GameObject.Find("ChatWarningText");
		chatWarning.SetActive (false);
        inputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
        gameClient = DataMaster.GameClient;

        senderColorDic = new Dictionary<string, string>();
        colorList = new List<string>();
        colorList.Add("green");
        colorList.Add("yellow");
        colorList.Add("purple");
        colorList.Add("orange");

        chattingUser = new HashSet<string>();
    }
	
	// Update is called once per frame
	void Update () {

		if (gameClient != null && !NetworkServer.active)
        {
			ProcessReceivedMsg ();
			ProcessSendMsg ();
        }
    }

	void ProcessReceivedMsg() {
		Queue<Message> msgQue = gameClient.chatManager.GetMsgQueue();

		while (msgQue.Count > 0)
		{
			Message msg = msgQue.Dequeue();

			string color;

			if (senderColorDic.ContainsKey(msg.SenderId))
			{
				color = senderColorDic[msg.SenderId];
			}
			else
			{ 
				color = colorList[chattingUser.Count % colorList.Count];
				chattingUser.Add(msg.SenderId);
			}

			senderColorDic[msg.SenderId] = color;

			text.text = text.text +  "<color=" + color + ">[" + msg.SenderId + "] says: " + msg.Text + "</color>\r\n";
		}
	}

	void ProcessSendMsg() {


		if (!inputField.text.Equals("") && Input.GetKeyDown(KeyCode.Return))
		{                
			string symbolStr = inputField.text.Substring (0, 1);
			if(!symbolStr.Equals ("/") && !symbolStr.Equals ("@"))
			{
				chatWarning.SetActive (true);
				return;
			}

			chatWarning.SetActive (false);

			if (inputField.text.StartsWith ("/list")) {
				string[] userList = gameClient.chatManager.GetOnlineUserList ();

				string strUsers = "";
				foreach(string str in userList) {
					strUsers += str + " ";
				}

				text.text = text.text + "<color=" + defaultColor + ">Online Users: </color>";
				text.text = text.text + strUsers + "\r\n";
				Debug.Log (strUsers);
			} else if (symbolStr.Equals ("@")) {
				int indexEndOfName = inputField.text.IndexOf(' ');

				string strMsg = inputField.text.Substring(indexEndOfName + 1);
				string receiverName = inputField.text.Substring(1, indexEndOfName - 1);

				gameClient.chatManager.SendChatMessage(receiverName, strMsg);
			}

			inputField.text = "";
			inputField.ActivateInputField();
			inputField.Select();
		}
	}

}