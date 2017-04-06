using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] fabItemSlots;

    public GameObject fabInventoryPanel = null;
    private GameObject gbInventory = null;

    private int cntEachLine = 6;
    private int cntTotal = 13;
  
    private Vector3 slotStartVec = new Vector3(-128, 60, 0);
    private Vector3 inventoryPanelVec = new Vector3(54, -33, 0);

    private GameObject gbIconZone;
    // Use this for initialization
    void Start()
    {
        if(GameObject.Find("InventoryPanel"))
        {
            gbInventory = GameObject.Find("InventoryPanel");
        } else {
            gbInventory = Instantiate(fabInventoryPanel);
        }        

        gbInventory.transform.SetParent(GameObject.Find("Canvas").transform);
        gbInventory.GetComponent<RectTransform>().localPosition = inventoryPanelVec;

        //ShowItems();
        gbIconZone = GameObject.Find("IconZone");
        gbInventory.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gbInventory.SetActive(!gbInventory.activeSelf);
            if(gbInventory.activeSelf)
            {
                //TestItems();
                //ShowItems();
            }
        }
    }

    public void TestItems()
    {
        float xPos = slotStartVec.x;
        float yPos = slotStartVec.y;

        int i = 0;
        while (i < cntTotal)
        {
            GameObject itemSlot = Instantiate(fabItemSlots[i % fabItemSlots.Length]);
            
            itemSlot.transform.SetParent(gbIconZone.GetComponent<RectTransform>());
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += itemSlot.GetComponent<RectTransform>().rect.width;

            if (++i % cntEachLine == 0)
            {
                xPos = slotStartVec.x;
                yPos -= itemSlot.GetComponent<RectTransform>().rect.width;
            }

        }
    }


    public void ShowItems()
    {
        Inventory inventory = Inventory.GetInstance();

        int index = 0;
        foreach (Item it in inventory.GetItems())
        {
            if (null == it.itemSlot)
            {
                it.itemSlot = Instantiate(it.fabItemIcon);
            }
   
            int xn = index % cntEachLine;
            int yn = index / cntEachLine;

            float xPos = slotStartVec.x + xn * it.itemSlot.GetComponent<RectTransform>().rect.width;
            float yPos = slotStartVec.y - yn * it.itemSlot.GetComponent<RectTransform>().rect.width;

            it.itemSlot.transform.SetParent(gbIconZone.GetComponent<RectTransform>());
            it.itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);

            index++;
        }
    }

    public void ShowNewItem(Item item)
    {
        if(null == item.itemSlot)
        {
            item.itemSlot = Instantiate(item.fabItemIcon);
        }

        item.itemSlot.GetComponent<ItemSlot>().ConnectItem(item);

        int count = gbIconZone.GetComponent<RectTransform>().childCount;

        int xn = count % cntEachLine;
        int yn = count / cntEachLine;

        float xPos = slotStartVec.x  + xn * item.itemSlot.GetComponent<RectTransform>().rect.width;
        float yPos = slotStartVec.y  - yn * item.itemSlot.GetComponent<RectTransform>().rect.width;

        item.itemSlot.transform.SetParent(gbIconZone.GetComponent<RectTransform>());
        item.itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);        
    }

    public void RemoveItem(Item item)
    {
        item.DropItem();
    }


    private void DisplayInventoryPanel()
    {
        ShowItems();    

    }

    private void OnGUI()
    {
        if(gbInventory.activeInHierarchy)
        {
            DisplayInventoryPanel();
        }
       
        //TestItems();
        //GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }
    
}
