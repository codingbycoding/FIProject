package es.upm.fi.services;

import Ice.Current;
//import Ice.Identity;
import es.upm.fi.data.OLUser;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.rmi.*;
import es.upm.fi.utils.ConvertorUtil;
import es.upm.fi.utils.NotificationUtil;
import es.upm.fi.utils.UTLogger;


public class NotificationRegisterServiceI extends _NotificationRegisterServiceDisp {
    @Override
    public void RegisterNotification(NotificationBasePrx notification, Current __current) {
        String name = __current.id.name;
        //Identity identity = notification.ice_getIdentity();

        UTLogger.info("RegisterNotification name:" + name);
        NotificationUtil.putNotification("Adam", notification);

        UTLogger.debug("__current.id.name:" + name);
        UTLogger.debug("__current.con.__toString():" + __current.con._toString());

//        String str[] = __current.con._toString().split("=");
//        String strConnID = str[1].trim();
//
//        UTLogger.debug("strConnID:" + strConnID);

        OLUser olUser = OLUserMgr.getInstance().getUserByConnID(ConvertorUtil.ConStr2Remote(__current.con._toString()));
        olUser.registerNotification(notification);

    }

    @Override
    public void RegisterNotifications(NotificationBasePrx[] notificationSeq, Current __current) {

    }
}
