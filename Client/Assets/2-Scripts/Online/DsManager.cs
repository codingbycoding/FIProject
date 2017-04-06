using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using es.upm.fi.rmi;


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

