package es.upm.fi.utils;

import es.upm.fi.entity.InventoryEntity;
import es.upm.fi.entity.InventoryItemId;
import es.upm.fi.rmi.RmiItem;

/**
 * Created by Adam on 3/7/2017.
 */
public class DataConvertor {
    public static RmiItem toRmiData(InventoryEntity inventoryEntity) {
        return new RmiItem(inventoryEntity.getId().getItem_id(), inventoryEntity.getItem_count());
    }


    public static InventoryEntity toEntityData(String userName, RmiItem rmiItem) {
        InventoryEntity inventoryEntity = new InventoryEntity();

        InventoryItemId inventoryItemId = new InventoryItemId();
        inventoryItemId.setAvatar_id(userName);
        inventoryItemId.setItem_id(rmiItem.itemId);

        inventoryEntity.setId(inventoryItemId);
        inventoryEntity.setItem_count(rmiItem.itemNum);
        return inventoryEntity;
    }

}
