package es.upm.fi.db;

import es.upm.fi.entity.AvatarEntity;
import es.upm.fi.entity.InventoryEntity;
import es.upm.fi.entity.InventoryItemId;
import es.upm.fi.utils.HBUtil;
import es.upm.fi.utils.UTLogger;
import org.hibernate.*;
import org.hibernate.criterion.Criterion;
import org.hibernate.criterion.LogicalExpression;
import org.hibernate.criterion.Restrictions;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Created by Adam on 2/24/2017.
 * InventoryDB use to operate user's inventory.
 */


public class InventoryDB
{

    public static List<InventoryEntity> getInventory(String name) {
        SessionFactory sf = HBUtil.getSessionFactory();
        Session session = sf.openSession();
        Transaction tx = null;

        List<InventoryEntity> inventoryEntities = new ArrayList<>();

        try {
            tx = session.beginTransaction();

            Criteria cr = session.createCriteria(InventoryEntity.class);
            cr.add(Restrictions.eq("id.avatar_id", name));
            List results = cr.list();

            for (Iterator iterator =
                 results.iterator(); iterator.hasNext();){
                InventoryEntity inventoryEntity = (InventoryEntity) iterator.next();
                System.out.print("item_id: " + inventoryEntity.getId().getItem_id());
                inventoryEntities.add(inventoryEntity);
            }

            tx.commit();

            UTLogger.info("getInventory name:" + name );
        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return inventoryEntities;
    }


    public static void updateItem(InventoryEntity inventoryEntity) {
        SessionFactory sf = HBUtil.getSessionFactory();
        Session session = sf.openSession();
        Transaction tx = null;

        try {
            tx = session.beginTransaction();
            session.saveOrUpdate(inventoryEntity);

            tx.commit();

            UTLogger.info("updateItem name:" + inventoryEntity.getId().getAvatar_id() + " item_id:" + inventoryEntity.getId().getItem_id());
        } catch (HibernateException e) {
            if (tx != null) tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

    }
}
