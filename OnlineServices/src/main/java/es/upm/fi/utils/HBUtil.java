package es.upm.fi.utils;

/**
 * Created by adam on 1/22/2017.
 * HBUtil is used as a Hibernate Util to manage Hibernate.
 */

import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

public class HBUtil {

    private static final SessionFactory sessionFactory = buildSessionFactory();

    private static SessionFactory buildSessionFactory() {
        try {
            return new Configuration().configure().buildSessionFactory();
        }
        catch (Throwable ex) {
            System.err.println("Initial SessionFactory creation failed." + ex);
            throw new ExceptionInInitializerError(ex);
        }
    }

    public static SessionFactory getSessionFactory() {
        return sessionFactory;
    }

    public static void shutdown() {
        // Close caches and connection pools
        getSessionFactory().close();
    }

}
