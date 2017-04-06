using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using es.upm.fi.rmi;


// DsManager only exists on Game Server. Each Game Server is a dedicated server, it needs to register to Online Service,
// Once it registered to Online Service, all the clients will be able to get the server info from Online Service
public class DsManager
{
    private static DsManager instance = null;

    private DsServicePrx dsPrx;

    public static DsManager GetDsManager()
    {
        if(null == instance)
        {
            instance = new DsManager(OnlineManager.GetOnlineManger());
        }

        return instance;
    }


    private DsManager(OnlineManager olManager)
    {
        dsPrx = DsServicePrxHelper.checkedCast(olManager.StringToProxy("PaseoOnline/PaseoDsService"));
    }

    public bool  RegisterDs(ServerEntry serverEntry)
    {
        dsPrx.registerDs(serverEntry);
        return false;
    }

}

