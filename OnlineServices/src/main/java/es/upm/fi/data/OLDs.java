package es.upm.fi.data;


import es.upm.fi.rmi.*;
import es.upm.fi.utils.UTLogger;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by Adam on 2/15/2017.
 * Dedicated Server's data is not necessary to persistent to database.
 * All the active DS info will be handled in this class.
 */
public class OLDs {

    private static HashMap _dsMap = new HashMap<String, ServerEntry>();


    public static void updateDsInfo(ServerEntry serverEntry) {
        UTLogger.info("updateDsInfo " + serverEntry.servAddr );
        _dsMap.put(serverEntry.servAddr, serverEntry);

    }


    public  static ArrayList getDsInfo() {
        return new ArrayList<ServerEntry>(_dsMap.values());
    }

}
