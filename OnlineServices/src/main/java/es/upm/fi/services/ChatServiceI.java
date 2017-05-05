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
    public ChannelInfo JoinChannel(long sid, long channelId, Current __current) throws PaseoException {
        return null;
    }

    @Override
    public ChannelInfo[] GetAllChannel(long sid, Current __current) {
        return new ChannelInfo[0];
    }

    @Override
    public boolean SendNotice(long sid, NoticeInfo info, Current __current) {
        return false;
    }

    @Override
    public NoticeInfo[] GetAllNoticeByType(long sid, byte noticeType, Current __current) {
        return new NoticeInfo[0];
    }

    @Override
    public boolean DelNotice(long sid, int noticeId, byte noticeType, Current __current) {
        return false;
    }

    @Override
    public boolean SendInformation(long sid, InformationInfo info, Current __current) {
        return false;
    }

    @Override
    public InformationInfo[] GetAllInformation(long sid, Current __current) {
        return new InformationInfo[0];
    }

    @Override
    public boolean DelInformation(long sid, int informationId, Current __current) {
        return false;
    }

    @Override
    public CharacterProfile[] GetSameChannelIdlePlayers(long sid, Current __current) throws PaseoException {
        return new CharacterProfile[0];
    }

    @Override
    public String[] GetOnlineUserList(Ice.Current __current)
            throws PaseoException {

        return OLUserMgr.getInstance().getAllUser();
    }
}
