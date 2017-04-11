package es.upm.fi.db;

import es.upm.fi.entity.AuthEntity;
import es.upm.fi.utils.HBUtil;

import org.hibernate.SessionFactory;
import org.hibernate.Session;
import org.hibernate.HibernateException;
import org.hibernate.Transaction;

import org.apache.commons.codec.digest.DigestUtils;

import es.upm.fi.utils.UTLogger;

/**
 * Created by adam on 1/23/2017.
 */
public class AuthDB {

    public static boolean checkAuth(String name, String password) {
        SessionFactory sf = HBUtil.getSessionFactory();

        Session session = sf.openSession();
        Transaction tx = null;
        boolean ret = false;

        try {
            tx = session.beginTransaction();
            AuthEntity authEntityDB =
                    (AuthEntity) session.get(AuthEntity.class, name);
            tx.commit();

            String md5Hex = DigestUtils.md5Hex(DigestUtils.md5Hex(password) + ":" + authEntityDB.getPassword_salt());

            if( authEntityDB.getPassword_hash().equals(md5Hex)) {
                UTLogger.info("checkAuth Succeed name:" + name + " password:" + password);
                ret = true;
            } else {
                UTLogger.error("checkAuth Failed name:" + name + " password:" + password);
            }

        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return ret;
    }

}
