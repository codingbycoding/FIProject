package es.upm.fi.services;

import Ice.Current;

import es.upm.fi.data.OLDs;
import es.upm.fi.rmi.ServerEntry;
import es.upm.fi.rmi.ServerInfo;
import es.upm.fi.rmi._ServerServiceDisp;


import java.util.ArrayList;


public class ServerServiceI  extends _ServerServiceDisp {


    @Override
    public ServerInfo getServerInfo(Current __current) {

        ArrayList<ServerEntry> serverArray = OLDs.getDsInfo();

        ServerInfo servverInfo = new ServerInfo();

        if(serverArray.size() > 0) {
            servverInfo.serverInfoSeq = new ServerEntry[serverArray.size()];

            int i = 0;
            for (ServerEntry serverEntry : serverArray) {
                servverInfo.serverInfoSeq[i++] = serverEntry;

            }
        } else {
            servverInfo.serverInfoSeq = new ServerEntry[0];
        }

        return servverInfo;
    }
}
