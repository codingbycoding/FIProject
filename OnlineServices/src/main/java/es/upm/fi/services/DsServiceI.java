package es.upm.fi.services;

import Ice.Current;

import es.upm.fi.data.OLDs;
import es.upm.fi.rmi.ServerEntry;
import es.upm.fi.rmi._DsServiceDisp;

import es.upm.fi.utils.*;


public class DsServiceI extends  _DsServiceDisp {

    @Override
    public void registerDs(ServerEntry serverEntry, Current __current) {
        UTLogger.info("registerDS serverEntry:" + serverEntry.servAddr);
        OLDs.updateDsInfo(serverEntry);
    }

    public void unRegisterDs(ServerEntry serverEntry, Current __current) {
        UTLogger.info("registerDS serverInfo:" + serverEntry.servAddr);
        OLDs.updateDsInfo(serverEntry);
    }


}
