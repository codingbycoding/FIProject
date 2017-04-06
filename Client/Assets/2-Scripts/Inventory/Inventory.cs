using System.Collections.Generic;

public class Inventory
{
    private List<Item> itemsList;

    private static Inventory instance = null;

    public static Inventory GetInstance()
    {
        if(null == instance)
        {
            instance = new Inventory();
        }

        return instance;
    }

    public Inventory()
    {
        itemsList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemsList.Remove(item);
    }

    public List<Item> GetItems()
    {
        return itemsList;
    }
}

