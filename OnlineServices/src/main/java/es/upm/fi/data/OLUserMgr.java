package es.upm.fi.data;

import Ice.Current;
import es.upm.fi.rmi.NotificationBasePrx;
import es.upm.fi.utils.ConvertorUtil;

import java.util.HashSet;
import java.util.HashMap;
/**
 * Created by Adam on 2/23/2017.
 * OLUserMgr used to hold all online users' data
 */

public class OLUserMgr {

    private HashMap<String, OLUser> olUserHashMap;
    private HashMap<String, String> olUserConnID2NameMap;
    private HashSet<String> olUserNames;

    private static OLUserMgr instance = null;

    private OLUserMgr() {
        olUserHashMap = new HashMap<>();
        olUserConnID2NameMap = new HashMap<>();
        olUserNames = new HashSet<>();
    }


    public static OLUserMgr getInstance() {
        if (instance == null) {
            instance = new OLUserMgr();
        }

        return instance;
    }

    public boolean addOrUpdateUser(OLUser olUser) {
        if(olUserHashMap.containsKey(olUser.getName())) {
            // TODO handle duplicate user name.
            // return false;
        }

        olUserHashMap.put(olUser.getName(), olUser);
        olUserConnID2NameMap.put(olUser.getConnID(), olUser.getName());
        olUserNames.add(olUser.getName());
        return true;
    }

    public void delUserByConnID(String connID) {
        String userName = olUserConnID2NameMap.get(connID);
        olUserHashMap.remove(userName);
        olUserNames.remove(userName);
    }

    public OLUser getUserByConnID(String connID) {
        return olUserHashMap.get(olUserConnID2NameMap.get(connID));
    }

    public OLUser getUserByName(String name) {
        return olUserHashMap.get(name);
    }

    public OLUser getUserByCurrent(Current __current) {
        String strRemote = ConvertorUtil.ConStr2Remote(__current.con._toString());
        return OLUserMgr.getInstance().getUserByConnID(strRemote);
    }

//    public ArrayList<String> getAllUser() {
//        return olUserNames;
//    }

    public String[] getAllUser() {
        String[] allUser = olUserNames.toArray(new String[olUserNames.size()]);
        return allUser;
    }
}
