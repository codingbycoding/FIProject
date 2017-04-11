package es.upm.fi.session;

import Ice.Current;
//import Ice.Identity;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.rmi.NotificationBasePrx;
import es.upm.fi.rmi._UserSessionDisp;
import es.upm.fi.utils.NotificationUtil;
import es.upm.fi.utils.UTLogger;


/**
 * Created by adam on 1/25/2017.
 */
public class UserSessionI extends  _UserSessionDisp {
    @Override
    public void RegisterNotification(NotificationBasePrx notification, Current __current) {
        String name = __current.id.name;
        //Identity identity = notification.ice_getIdentity();
        //notification.toString();

        UTLogger.info("RegisterNotification name:" + name);
        NotificationUtil.putNotification("Adam", notification);

        UTLogger.debug("__current.id.name" + name);
    }

    @Override
    public void RegisterNotifications(NotificationBasePrx[] notificationSeq, Current __current) {

    }

    @Override
    public void destroy(Current __current) {
        UTLogger.info("session destroy " + __current.id.name);
        // TODO: destory session for Client and DS.
/*        if(isDS) {
            unRegisterDs();
        } else if(isClient) {

        }*/

        OLUserMgr.getInstance().delUserByConnID(__current.con._toString());
    }
}
