using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using es.upm.fi.rmi;

// ChatUI process the online chat message at UI layer.
public class ChatUI : MonoBehaviour {
    private Text text = null;
    private InputField inputField = null;
    private GameClient gameClient = null;

    private Dictionary<string, string> senderColorDic = null;
    private List<string> colorList = null;
    private HashSet<string> chattingUser = null;
	// Use this for initialization
	void Start () {
        text = GameObject.Find("ChatText").GetComponent<Text>();
        text.text = text.text + "\r\n";

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

        if (gameClient != null && !Network.isServer)
        {
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


            if (!inputField.text.Equals("") && Input.GetKeyDown(KeyCode.Return))
            {
                int indexEndOfName = inputField.text.IndexOf(' ');

                string strMsg = inputField.text.Substring(indexEndOfName + 1);
                string receiverName = inputField.text.Substring(1, indexEndOfName - 1);

                gameClient.chatManager.SendChatMessage(receiverName, strMsg);
                inputField.text = "";
            }
        }
    }
}