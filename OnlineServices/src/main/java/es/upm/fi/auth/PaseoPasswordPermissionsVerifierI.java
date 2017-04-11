package es.upm.fi.auth;

import Glacier2.PermissionDeniedException;
import Glacier2._PermissionsVerifierDisp;

import Ice.Current;
import Ice.StringHolder;

import es.upm.fi.data.OLUser;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.utils.ConvertorUtil;
import es.upm.fi.utils.UTLogger;

import org.apache.commons.codec.digest.DigestUtils;

@SuppressWarnings("serial")
public class PaseoPasswordPermissionsVerifierI extends _PermissionsVerifierDisp {
    @Override
    public boolean checkPermissions(String userId, String password, StringHolder reason, Current __current) throws PermissionDeniedException {
        boolean ret = false;
        UTLogger.info("checkPermissions userId:" + userId + " password:" + password);

        reason.value = new String(new byte[]{CHECK_SUCCESS});


        if (specifiedAccountVerify(userId, password)) {
            UTLogger.info("specifiedAccountVerify " + userId + " : " + password);
            ret = true;
            return ret;
        }


        OLUser olUser = new OLUser(userId, ConvertorUtil.ConStr2Remote(__current.con._toString()));
        OLUserMgr.getInstance().addOrUpdateUser(olUser);
        UTLogger.info("Add User _toString:" + __current.con._toString());
        //ret = AuthDB.checkAuth(userId, password);
        ret = true;
        return ret;
    }

    private boolean specifiedAccountVerify(String userId, String password) {

        if (userId.equals(defaultGuestAccount)
                && password.equals(DigestUtils.md5Hex(defaultGuestPassword)))
        {
            UTLogger.debug(
                    "TmPasswordPermissionsVerifierI.checkPermissions( "
                            + userId + ", " + password
                            + " ): Guest login succeeded. ");
            return true;
        }

        if (userId.equals(defaultDsaAccount)
                && password.equals(DigestUtils.md5Hex(defaultDsaPassword)))
        {
            UTLogger.debug(
                    "TmPasswordPermissionsVerifierI.checkPermissions( "
                            + userId + ", " + password
                            + " ): Dsa login succeeded. ");
            return true;
        }

        if (userId.equals(defaultDsAccount)
                && password.equals(DigestUtils.md5Hex(defaultDsPassword)))
        {
            UTLogger.debug(
                    "TmPasswordPermissionsVerifierI.checkPermissions( "
                            + userId + ", " + password
                            + " ): Ds login succeeded. ");
            return true;
        }

        return false;
    }

    private static final byte CHECK_SUCCESS = 0;
    private static final byte VERIFY_FAILED = 1;
    private static final byte UNKNOWN = 3;


    private static String		defaultGuestAccount = "Guest";
    private static String		defaultGuestPassword = "Guest";
    private static String		defaultDsaAccount = "DsAgent";
    private static String		defaultDsaPassword = "DsAgent";
    private static String		defaultDsAccount = "DS";
    private static String		defaultDsPassword = "DS";
}
