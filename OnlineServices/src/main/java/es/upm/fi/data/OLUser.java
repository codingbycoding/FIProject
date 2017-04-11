package es.upm.fi.data;

import es.upm.fi.rmi.NotificationBasePrx;

/**
 * Created by Adam on 2/27/2017.
 */
public class OLUser {
    private String name;

    public String getName() {
        return name;
    }

    public String getConnID() {
        return connID;
    }

    public NotificationBasePrx getNotificationBasePrx() {
        return notificationBasePrx;
    }

    private String connID;
    private NotificationBasePrx notificationBasePrx;

    public OLUser(String name, String connID) {
        this.name = name;
        this.connID = connID;
    }


    public void registerNotification(NotificationBasePrx notificationBasePrx) {
        this.notificationBasePrx = notificationBasePrx;
    }
}

