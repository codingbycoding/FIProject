using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using es.upm.fi.rmi;

public class ChatManager
{
    private ChatServicePrx chatPrx;

    private static ChatManager instance = null;
    private Queue<Message> msgQue;

    public static ChatManager GetChatManager()
    {
        if(null == instance)
        {            
            instance = new ChatManager(OnlineManager.GetOnlineManger());
        }

        return instance;
    }

    private ChatManager(OnlineManager olManager)
    {      
        chatPrx = ChatServicePrxHelper.checkedCast(olManager.StringToProxy("PaseoOnline/PaseoChatService"));
        msgQue = new Queue<Message>();
    }

    public void SendChatMessage(string receiverName, string message)
    {
        chatPrx.SendChatMessage(0, 0, 1, receiverName, message);
    }

    public void OnReceiveMessage(Message msg)
    {
        msgQue.Enqueue(msg);
    }

    public Queue<Message> GetMsgQueue()
    {
        return msgQue;
    }
}

