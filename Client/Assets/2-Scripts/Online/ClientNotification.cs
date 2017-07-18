using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.SceneManagement;

using es.upm.fi.rmi;
using Ice;


// ClientNotification is used to receive message from Online Service 
// All the messages that Online Service actively send to Client will be notifications
public class ClientNotification : MessageNotificationDisp_
{
    private GameClient gameClient;

    public ClientNotification(GameClient networkController)
    {
        gameClient = networkController;
    }


    public override void OnReceiveMessage(Message[] msgSeq, Current current__)
    {
        //_networkController._servInfos = new ServerInfo[msgSeq.Length];
        int i = 1;
        foreach (Message msg in msgSeq)
        {
            Debug.Log("message " + i++ + ":" + msg.Text);
            gameClient.chatManager.OnReceiveMessage(msg);
        }
    }
		
}

