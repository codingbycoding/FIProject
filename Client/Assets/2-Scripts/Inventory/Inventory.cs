using System.Collections.Generic;
using UnityEngine;
using es.upm.fi.rmi;

public class Inventory
{
    private List<Item> itemsList;
	private List<RmiItem> rmiItemList;

    private static Inventory instance = null;

    public static Inventory GetInstance()
    {
        if(null == instance)
        {
            instance = new Inventory();
        }

        return instance;
    }

	public void Clear() 
	{
		itemsList.Clear();
		rmiItemList.Clear();
	}

    public Inventory()
    {
        itemsList = new List<Item>();
		rmiItemList = new List<RmiItem>();
    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
		RmiItem rmiItem;
		rmiItem.itemId = item.itemId;
		bool bFound = false;
		for(int i=0; i<rmiItemList.Count; i++) {
			if (item.itemId == rmiItemList[i].itemId)
			{
				rmiItem.itemNum = rmiItemList[i].itemNum+1;
				rmiItemList[i] = rmiItem;
				bFound = true;
				break;
			}              
		}

		if (!bFound) {		
			rmiItem.itemNum = 1;
			rmiItemList.Add(rmiItem);
		}
    }

    public void RemoveItem(Item item)
    {
        itemsList.Remove(item);
		RmiItem rmiItem;
		rmiItem.itemId = item.itemId;

		for(int i=0; i<rmiItemList.Count; i++) {
			if (item.itemId == rmiItemList[i].itemId)
			{
				rmiItem.itemNum = rmiItemList[i].itemNum-1;
				rmiItemList[i] = rmiItem;
				break;
			}              
		}
    }

    public List<Item> GetItems()
    {
        return itemsList;
    }

	public RmiItem GetRmiItem(int item_id)
	{
		
		foreach (RmiItem rmiItemEach in rmiItemList)
		{
			if (item_id == rmiItemEach.itemId)
			{				
				return rmiItemEach;
			}                
		}

		RmiItem rmiItem;
		rmiItem.itemId = item_id;
		rmiItem.itemNum = 0;
		return rmiItem;
	}
}

