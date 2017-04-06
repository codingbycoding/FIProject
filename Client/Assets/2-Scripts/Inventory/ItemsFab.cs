﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemsFab : NetworkBehaviour {

    public GameObject[] fabItems;
    // Use this for initialization
 
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject NewItem(int i)
    {
        GameObject gb = Instantiate(fabItems[i]);
        gb.GetComponent<Item>().Iconize();
        return gb;
    }
    
}
