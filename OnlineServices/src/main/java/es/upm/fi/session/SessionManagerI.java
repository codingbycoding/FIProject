package es.upm.fi.session;

import Glacier2.CannotCreateSessionException;
import Glacier2.SessionControlPrx;
import Glacier2.SessionPrx;
import Glacier2._SessionManagerDisp;
import Ice.Current;
import Ice.Identity;
import es.upm.fi.data.OLSession;
import es.upm.fi.data.OLUser;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.utils.UTLogger;

/**
 * Created by adam on 1/25/2017.
 */
public class SessionManagerI extends _SessionManagerDisp {
    @Override
    public SessionPrx create(String userId, SessionControlPrx control, Current __current) throws CannotCreateSessionException {

        UTLogger.info("userId:" + userId);

        String avatar_id = userId;

        long sessionId = OLSession.createSession(userId);

        return Glacier2.SessionPrxHelper
                .uncheckedCast(__current.adapter.createProxy(new Identity(avatar_id + sessionId, CATEGORY)));

    }


    final private String CATEGORY = "USER-SESSION";
}
