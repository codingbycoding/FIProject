using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.SceneManagement;

using es.upm.fi.rmi;
using Ice;

public class ClientNotification : MessageNotificationDisp_
{
    private GameClient gameClient;

    public ClientNotification(GameClient networkController)
    {
        gameClient = networkController;
    }

    public override void OnAutoJoinedChannel(ChannelInfo info, Current current__)
    {
        throw new NotImplementedException();
    }

    public override void OnKeepAliveCheck(Current current__)
    {
        throw new NotImplementedException();
    }

    public override void OnReceiveInformation(SendInformationInfo info, Current current__)
    {
        throw new NotImplementedException();
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

    public override void OnReceiveNotice(NoticeInfo info, Current current__)
    {
        throw new NotImplementedException();
    }
}

