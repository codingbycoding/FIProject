package es.upm.fi.services;

import Ice.Current;

import es.upm.fi.data.OLUser;
import es.upm.fi.data.OLUserMgr;
import es.upm.fi.db.InventoryDB;
import es.upm.fi.entity.InventoryEntity;
import es.upm.fi.entity.InventoryItemId;

import es.upm.fi.rmi.RmiInventory;
import es.upm.fi.rmi.RmiItem;
import es.upm.fi.rmi._InventoryServiceDisp;
import es.upm.fi.utils.DataConvertor;
import es.upm.fi.utils.UTLogger;


import java.util.List;

/**
 * Created by Adam on 2/28/2017.s
 */
public class InventoryServiceI extends _InventoryServiceDisp {

    @Override
    public RmiInventory getInventory(Current __current) {
        OLUser user = OLUserMgr.getInstance().getUserByCurrent(__current);

        List<InventoryEntity> inventoryEntityList = InventoryDB.getInventory(user.getName());

        RmiItem items[] = new RmiItem[inventoryEntityList.size()];
        int i=0;
        for (InventoryEntity inventoryEntity : inventoryEntityList) {
            items[i++] = new RmiItem(inventoryEntity.getId().getItem_id(), inventoryEntity.getItem_count());
        }

        UTLogger.info("getInventory username: " + user.getName() + " itemSize: " + inventoryEntityList.size());

        return new RmiInventory(items);
    }

    @Override
    public void updateItem(RmiItem item, Current __current) {
        OLUser user = OLUserMgr.getInstance().getUserByCurrent(__current);

        InventoryEntity inventoryEntity = DataConvertor.toEntityData(user.getName(), item);

        UTLogger.info("updateItem username: " + user.getName() + " item_id: " + item.itemId);

        InventoryItemId inventoryItemId = new InventoryItemId();
        inventoryItemId.setAvatar_id(user.getName());
        inventoryItemId.setItem_id(item.itemId);

        InventoryDB.updateItem(inventoryEntity);
    }
}
