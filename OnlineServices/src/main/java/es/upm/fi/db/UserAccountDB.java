package es.upm.fi.db;

import es.upm.fi.rmi.AccountProfile;

import es.upm.fi.entity.UserAccountEntity;
import es.upm.fi.utils.HBUtil;
import es.upm.fi.entity.*;

import es.upm.fi.utils.UTLogger;
import org.hibernate.SessionFactory;
import org.hibernate.Session;
import org.hibernate.HibernateException;
import org.hibernate.Transaction;

import org.apache.commons.codec.digest.DigestUtils;

import java.util.UUID;
import java.util.Date;
import java.sql.Timestamp;

public class UserAccountDB {

    public static boolean createAccount(AccountProfile profile) {

        SessionFactory sf = HBUtil.getSessionFactory();
        Session session = sf.openSession();
        Transaction tx = null;
        boolean ret = false;

        //Name and email must be unique.
        if(nameOrEmailExists(profile)) {
            ret = false;
            UTLogger.error("Can't createAccount, because the name or email provided is already registered.");
            return ret;
        }

        try {

            tx = session.beginTransaction();
//            UserAccountEntity userAccountEntityDB =
//                    (UserAccountEntity) session.get(UserAccountEntity.class, profile.name);

            //Initialize user_account_tbl entry
            UserAccountEntity userAccountEntity = new UserAccountEntity();
            userAccountEntity.setName(profile.name);
            String uuid_avatar = UUID.randomUUID().toString();

            userAccountEntity.setAvatar_id(uuid_avatar);
            userAccountEntity.setEmail(profile.email);
            Date nowDate = new Date();
            Timestamp now = new Timestamp(nowDate.getTime());

            userAccountEntity.setCreate_timestamp(now);
            userAccountEntity.setActive_timestamp(now);
            userAccountEntity.setAvatar_level(1);
            userAccountEntity.setUser_flags(0);
            userAccountEntity.setUser_title("");
            session.save(userAccountEntity);

            //Initialize auth_tbl entry
            AuthEntity authEntity = new AuthEntity(profile.name);
            String md5Hex = DigestUtils.md5Hex(DigestUtils.md5Hex(profile.password) + ":" + uuid_avatar);
            authEntity.setAvatar_id(uuid_avatar);
            authEntity.setPassword_hash(md5Hex);
            authEntity.setPassword_salt(uuid_avatar.replaceAll("-", ""));
            authEntity.setAccount_type("");
            session.save(authEntity);

            //Initialize avatars_tbl entry
            AvatarEntity avatarEntity = new AvatarEntity();
            avatarEntity.setAvatar_id(uuid_avatar);
            avatarEntity.setName(profile.name);
            session.save(avatarEntity);

            tx.commit();
            UTLogger.info("createAccount succeed. name:" + profile.name + " email:" + profile.email + " password(plain):" + profile.password);
            ret = true;
        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return ret;
    }

    private static boolean nameOrEmailExists(AccountProfile profile) {
        boolean ret = true;

        SessionFactory sf = HBUtil.getSessionFactory();
        Session session = sf.openSession();
        Transaction tx = null;

        try {
            tx = session.beginTransaction();
            UserAccountEntity userAccountEntityDB_1 =
                    (UserAccountEntity) session.get(UserAccountEntity.class, profile.name);

            UserAccountEntity userAccountEntityDB_2 =
                    (UserAccountEntity) session.get(UserAccountEntity.class, profile.email);

            tx.commit();

            if(null == userAccountEntityDB_1 && null == userAccountEntityDB_2)  {
                ret = false;
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