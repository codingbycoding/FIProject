package es.upm.fi.db;


import es.upm.fi.entity.AvatarEntity;
import es.upm.fi.utils.HBUtil;
import es.upm.fi.utils.UTLogger;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;

/**
 * Created by Adam on 2/17/2017.
 */
public class AvatarDB {


    public static AvatarEntity getAvatar(String name) {
        SessionFactory sf = HBUtil.getSessionFactory();

        Session session = sf.openSession();
        Transaction tx = null;
        AvatarEntity avatarEntity = null;

        try {
            tx = session.beginTransaction();
            avatarEntity =
                    (AvatarEntity) session.get(AvatarEntity.class, name);
            tx.commit();

            //avatarEntity.getAvatar_state();
            UTLogger.info("getAvatar name:" + name );

        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return avatarEntity;
    }


    public static void persistAvatar( AvatarEntity avatarEntity) {
        SessionFactory sf = HBUtil.getSessionFactory();
        Session session = sf.openSession();
        Transaction tx = null;

        try {
            tx = session.beginTransaction();

            avatarEntity.getAvatar_state();
            session.saveOrUpdate(avatarEntity);
            tx.commit();
            UTLogger.info("persistAvatar name:" + avatarEntity.getName() );


        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }
    }
}
