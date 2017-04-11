package es.upm.fi.utils;

import Ice.Identity;
import es.upm.fi.rmi.NotificationBasePrx;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by adam on 1/25/2017.
 * NotificationUtil use to store notification temporarily, will use other method to store this info like redis.
 */
@Deprecated
public class NotificationUtil {


    public static void putNotification(String name, NotificationBasePrx notificationBasePrx) {
        Identity identity = notificationBasePrx.ice_getIdentity();

//        ArrayList<Object> arrayListObj = new ArrayList<>();
//        arrayListObj.add(identity);
//        arrayListObj.add(notificationBasePrx);


        notifyMap.put(name, notificationBasePrx);
    }


    public static NotificationBasePrx getNotification(String name) {
        return notifyMap.get(name);
    }

    //private static HashMap<String, ArrayList<Object>> notifyMap = new HashMap<>();

    private static HashMap<String, NotificationBasePrx> notifyMap = new HashMap<>();

}
