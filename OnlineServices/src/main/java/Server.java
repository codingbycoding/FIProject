import Ice.ObjectAdapter;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.services.*;
import es.upm.fi.auth.*;
import es.upm.fi.session.SessionManagerI;
import es.upm.fi.session.UserSessionI;
import es.upm.fi.utils.*;

public class Server extends Ice.Application
{

    @Override
    public int
    run(String[] args)
    {
        Ice.ObjectAdapter adapter = communicator().createObjectAdapter("PaseoAdapter");
        createServices(adapter);
        adapter.activate();
        UTLogger.info("adapter activated...");

        communicator().waitForShutdown();
        return 0;
    }

    private void initDataMgr() {
        //OLUserMgr olUserMgr = OLUserMgr.getInstance();

    }

    private void createServices(ObjectAdapter adapter) {

        AccountServiceI accountServiceI = new AccountServiceI();
        adapter.add(accountServiceI, communicator().stringToIdentity("PaseoOnline/PaseoAccountService"));

        PaseoPasswordPermissionsVerifierI verifier = new PaseoPasswordPermissionsVerifierI();
        adapter.add(verifier,
                communicator().stringToIdentity("PermissionsVerifier/PaseoPasswordPermissionsVerifier"));

        SessionManagerI sessionManagerI = new SessionManagerI();
        adapter.add(sessionManagerI,
                communicator().stringToIdentity("UserSessionManagement/PaseoUserSessionManager"));

        ChatServiceI chatServiceI = new ChatServiceI();
        adapter.add(chatServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoChatService"));

        ServerServiceI serverServiceI = new ServerServiceI();
        adapter.add(serverServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoServerService"));

        AvatarServiceI avatarServiceI = new AvatarServiceI();
        adapter.add(avatarServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoAvatarService"));

        InventoryServiceI inventoryServiceI = new InventoryServiceI();
        adapter.add(inventoryServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoInventoryService"));

        DsServiceI dsServiceI = new DsServiceI();
        adapter.add(dsServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoDsService"));

        NotificationRegisterServiceI notificationRegisterServiceI = new NotificationRegisterServiceI();
        adapter.add(notificationRegisterServiceI,
                communicator().stringToIdentity("PaseoOnline/PaseoNotificationRegisterService"));

        UserSessionI userSessionI = new UserSessionI();
        adapter.add(userSessionI,
                communicator().stringToIdentity("PaseoOnline/PaseoUserSession"));
    }

    static public void
    main(String[] args)
    {
        Server app = new Server();
        int status = app.main("Server", args);
        System.exit(status);
    }
}
