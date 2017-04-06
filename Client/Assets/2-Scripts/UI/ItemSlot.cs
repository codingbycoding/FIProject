﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

    // Use this for initialization
    private Item item;

    private bool isMouseCurrentOver = false;
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
    }

    public void ConnectItem(Item item)
    {
        this.item = item;
    }

    void OnGUI()
    {
        if (Event.current.button == 1 && isMouseCurrentOver)
        {
            Debug.Log("ItemSlot OnGUI button == 1 item_id:" + item.itemId);

            this.gameObject.transform.SetParent(null);
            this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            item.DropItem();
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
