using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using es.upm.fi.rmi;

using UnityEngine;


// OnlineManager is the communication tunnel of Ice.
// The connection to Online Service establish from here.
public class OnlineManager
{
    private static OnlineManager instance = null;

    private Glacier2.RouterPrx router;
    private Glacier2.SessionPrx session = null;
    private Ice.Communicator iceCommunicator;

    Ice.ObjectAdapter callbackAdapter = null;
    ClientNotification clientNotification = null;
    public static OnlineManager GetOnlineManger()
    {
        return instance;
    }

    public static OnlineManager InitOnlineManager(string onlineIP, int onlinePort)
    {
        instance = new OnlineManager(onlineIP, onlinePort);
        return instance;
    }

    private OnlineManager(string onlineIP, int onlinePort)
    {
        List<string> propList = new List<string>();

        propList.Add("--Ice.Default.Router = Glacier2/router:tcp -h " + onlineIP + " -p " + onlinePort);

        propList.Add("--Ice.ProgramName=PaseoOnline");
        propList.Add("--Ice.RetryIntervals = -1");

        propList.Add("--Ice.ThreadPool.Client.Size=2");
        propList.Add("--Ice.ThreadPool.Client.ThreadIdleTime=0");
        propList.Add("--Ice.ThreadPool.Server.Size=2");

        propList.Add("--Ice.Trace.Locator = 2");
        propList.Add("--Ice.Trace.Network=2");
        propList.Add("--Ice.Trace.Protocol=2");
        propList.Add("--Ice.Trace.ThreadPool=2");

        string[] propArgs = new string[propList.Count()];
        for (int i = 0; i < propArgs.Count(); i++)
        {
            propArgs[i] = propList[i];
        }

        try
        {
            iceCommunicator = Ice.Util.initialize(ref propArgs);
            router = Glacier2.RouterPrxHelper.checkedCast(iceCommunicator.getDefaultRouter());

            /*
            int acmTimeout = router.getACMTimeout();
            if (acmTimeout > 0)
            {
                Ice.Connection conn = router.ice_getCachedConnection();
                conn.setACM(acmTimeout, Ice.ACMClose.CloseOff, Ice.ACMHeartbeat.HeartbeatAlways);
            }
            */

        }
        catch (Glacier2.PermissionDeniedException ex)
        {
            Debug.LogError("!!! permission denied:" + ex.reason);
        }
        catch (Glacier2.CannotCreateSessionException ex)
        {
            Debug.LogError("!!! cannot create session:" + ex.reason);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

    }


    public bool Login(string name, string password)
    {
        Debug.Log("Login to Online Service.");

        try
        {
            session = router.createSession(name, password);

            callbackAdapter = iceCommunicator.createObjectAdapterWithRouter("callbackAdapter", router);

            Ice.Identity id = new Ice.Identity("MessageNotification", router.getCategoryForClient());

            clientNotification = new ClientNotification(DataMaster.GameClient);
            NotificationBasePrx notificationBasePrx = NotificationBasePrxHelper.checkedCast(callbackAdapter.add(clientNotification, id));

            NotificationRegisterServicePrx notificationRegisterServicePrx = NotificationRegisterServicePrxHelper.checkedCast(iceCommunicator.stringToProxy("PaseoOnline/PaseoNotificationRegisterService"));
            notificationRegisterServicePrx.RegisterNotification(notificationBasePrx);
            callbackAdapter.activate();

            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return false;
    }

	static string GetMd5Hash(MD5 md5Hash, string input)
	{

		// Convert the input string to a byte array and compute the hash.
		byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

		// Create a new Stringbuilder to collect the bytes
		// and create a string.
		StringBuilder sBuilder = new StringBuilder();

		// Loop through each byte of the hashed data 
		// and format each one as a hexadecimal string.
		for (int i = 0; i < data.Length; i++)
		{
			sBuilder.Append(data[i].ToString("x2"));
		}

		// Return the hexadecimal string.
		return sBuilder.ToString();
	}

    public bool DsLogin(string dsName, string dsPassword)
    {
		using (MD5 md5Hash = MD5.Create ()) {
			string dsPasswordHash = GetMd5Hash (md5Hash, dsPassword);
		

			try {
				session = router.createSession (dsName, dsPasswordHash);
				return true;
			} catch (Exception e) {
				Debug.LogError (e);
			}
		}

        return false;
    }

    public ServerInfo GetServerInfo()
    {
        try
        {
            Ice.ObjectPrx serverObjPrx = iceCommunicator.stringToProxy("PaseoOnline/PaseoServerService");
            ServerServicePrx serverPrx = ServerServicePrxHelper.checkedCast(serverObjPrx);
            return serverPrx.getServerInfo();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return null;
    }

    public Ice.ObjectPrx StringToProxy(string strProxy)
    {
        return iceCommunicator.stringToProxy(strProxy);
    }

    public void Logout()
    {
        if(null != session)
			
        {
			try {
           	 session.destroy();
			} 
			catch(Exception e) 
			{
				Debug.LogError(e);
			}
        }        
    }

}

