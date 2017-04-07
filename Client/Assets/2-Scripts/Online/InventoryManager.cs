﻿using es.upm.fi.rmi;

using UnityEngine;

public class InventoryManager
{
    private Inventory inventory = null;
    private RmiInventory rmiInventory = null;
    private InventoryServicePrx inventoryPrx = null;

    private static InventoryManager instance = null;

    private InventoryUI inventoryUI = null;
    ItemsFab itemsFab;

    public static InventoryManager GetInstance()
    {
        if (instance == null)
        {
            instance = new InventoryManager(OnlineManager.GetOnlineManger());
        }

        return instance;
    }


    private InventoryManager(OnlineManager olManager)
    {
        inventory = Inventory.GetInstance();
        itemsFab = GameObject.Find("Canvas").GetComponent<ItemsFab>();  
        inventoryPrx = InventoryServicePrxHelper.checkedCast(olManager.StringToProxy("PaseoOnline/PaseoInventoryService"));
    }

    public void SetInventoryUI(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item);

        inventoryUI.ShowNewItem(item);

        int item_count = 0;
        foreach(Item itemEach in inventory.GetItems())
        {
            if (item.itemId == itemEach.itemId)
                item_count++;
        }

        RmiItem rmiItem;
        rmiItem.itemId = item.itemId;
        rmiItem.itemNum = item_count;

        UpdateItem(rmiItem);
    }

    public void RemoveItem(Item item)
    {
        RmiItem rmiItem;
        rmiItem.itemId = item.itemId;
        rmiItem.itemNum = -1;   

        foreach (RmiItem rmiItemEach in rmiInventory.items)
        {
            if (item.itemId == rmiItemEach.itemId)
            {
                rmiItem = rmiItemEach;
                break;
            }                
        }

        rmiItem.itemNum--;
        if (rmiItem.itemNum >= 0)
        {
            inventory.RemoveItem(item);
            UpdateItem(rmiItem);
        }
        
    }

    public void GetInventory()
    {
        if(rmiInventory != null)
        {
            return;
        }

        rmiInventory = inventoryPrx.getInventory();
        foreach (RmiItem rmiItem in rmiInventory.items)
        {  
            for (int i=0; i<rmiItem.itemNum; i++) {
                GameObject gbItem = itemsFab.NewItem(rmiItem.itemId);
                Item item = gbItem.GetComponent<Item>();
                inventoryUI.ShowNewItem(item);
                inventory.AddItem(item);
            }
           
        }

    }

    public void UpdateItem(RmiItem rmiItem)
    {
        inventoryPrx.updateItem(rmiItem);
    }
}