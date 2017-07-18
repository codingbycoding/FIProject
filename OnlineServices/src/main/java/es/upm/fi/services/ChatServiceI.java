package es.upm.fi.services;

import Ice.Current;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.rmi.*;
import es.upm.fi.utils.ConvertorUtil;
import es.upm.fi.utils.NotificationUtil;
import es.upm.fi.utils.UTLogger;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.data.OLUser;

public class ChatServiceI extends _ChatServiceDisp {

    @Override
    public void SendChatMessage(long sid, byte scopeId, long senderSid, String receiverName, String message, Current __current) throws PaseoException {

        UTLogger.info("SendChatMessage receiverName:" + receiverName);
        UTLogger.info("SendChatMessage _toString(): " + __current.con._toString());
        //__current.adapter.get

//        NotificationBasePrx notificationBasePrx = NotificationUtil.getNotification(receiverName);
//        if(null != notificationBasePrx) {
//            MessageNotificationPrx messageNotificationPrx = MessageNotificationPrxHelper.checkedCast(notificationBasePrx);
//            Message[] messages = new Message[1];
//            messages[0] = new Message();
//            messages[0].Text = message;
//            messages[0].SenderId = "senderName";
//
//            messageNotificationPrx.OnReceiveMessage(messages);
//        }

        OLUser olUserRecevier =  OLUserMgr.getInstance().getUserByName(receiverName);
        String strRemote = ConvertorUtil.ConStr2Remote(__current.con._toString());
        String senderName = OLUserMgr.getInstance().getUserByConnID(strRemote).getName();

        if(null != olUserRecevier) {
            NotificationBasePrx notificationBasePrx = olUserRecevier.getNotificationBasePrx();
            if (null != notificationBasePrx) {
                MessageNotificationPrx messageNotificationPrx = MessageNotificationPrxHelper.checkedCast(notificationBasePrx);
                Message[] messages = new Message[1];
                messages[0] = new Message();
                messages[0].Text = message;
                messages[0].SenderId = senderName;

                messageNotificationPrx.OnReceiveMessage(messages);
            }
        }
    }



    @Override
    public String[] GetOnlineUserList(Ice.Current __current)
            throws PaseoException {

        return OLUserMgr.getInstance().getAllUser();
    }
}
