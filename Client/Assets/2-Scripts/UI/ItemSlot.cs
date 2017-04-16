using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// When item iconized, the item will become as a item icon in player's inventory panel.
public class ItemSlot : MonoBehaviour {   

    private bool isMouseCurrentOver = false;
	private bool isDropping = false;
    private Item item;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (isMouseCurrentOver && Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("ItemSlot OnGUI button == 1 item_id:" + item.itemId);

        //    this.gameObject.transform.SetParent(null);
        //    this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        //    item.DropItem();
        //}

        //if (Event.current.button == 1 && isMouseCurrentOver)
        //{
        //    Debug.Log("ItemSlot OnGUI button == 1 item_id:" + item.itemId);

        //    this.gameObject.transform.SetParent(null);
        //    this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        //    item.DropItem();
        //}
    }

    public void ConnectItem(Item item)
    {
        this.item = item;
    }

    void OnGUI()
    {
		if (Event.current.button == 1 && isMouseCurrentOver && !isDropping)
        {
			isDropping = true;
            Debug.Log("ItemSlot OnGUI button == 1 item_id:" + item.itemId);

            this.gameObject.transform.SetParent(null);
            this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            item.DropItem();
            Destroy(this);
        }

    }


    public void MouseCurrentEnter()
    {
        isMouseCurrentOver = true;
    }

    public void MouseCurrentExit()
    {
        isMouseCurrentOver = false;
    }
}
