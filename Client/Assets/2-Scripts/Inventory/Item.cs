using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class Item : NetworkBehaviour {

    public string iconName;
    public GameObject fabItemIcon;
    public int itemId;
    public GameObject itemSlot = null;

    private bool isIconize;

    // Use this for initialization
    void Start () {
        isIconize = false;
    }

    public override void OnStartServer()
    {
        //NetworkServer.Spawn(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        PickItem();        
    }

    private void PickItem()
    {
        PlayerCommand playerCommand = DataMaster.GamePlayer.GetComponent<PlayerCommand>();
        playerCommand.CmdPickItem(netId);

        //Iconize();
        InventoryManager.GetInstance().AddItem(this);
    }

    public void DropItem()
    {
        GameObject gamePlayer = DataMaster.GamePlayer;
        Vector3 itemPosition = gamePlayer.transform.position;
        itemPosition.x += 1;

        PlayerCommand playerCommand = DataMaster.GamePlayer.GetComponent<PlayerCommand>();
        playerCommand.CmdDropItem(itemId, itemPosition);

        //Deiconize();
        InventoryManager.GetInstance().RemoveItem(this);
        Destroy(this);

        Debug.Log("DropItem itemId:" + itemId);
    }

    [ClientRpc]
    public void RpcIconize()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<Item>().enabled = false;

        this.transform.localPosition = Vector3.zero;

        if(null != itemSlot)
        {
            itemSlot.GetComponent<ItemSlot>().enabled = true;
        }
       
        isIconize = true;
    }

    public void Iconize()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<Item>().enabled = false;

        this.transform.localPosition = Vector3.zero;

        if (null != itemSlot)
        {
            itemSlot.GetComponent<ItemSlot>().enabled = true;
        }

        isIconize = true;
    }

    public void Deiconize()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<Item>().enabled = true;

        this.transform.SetParent(null);
        this.transform.localPosition = Vector3.zero;

        if (null != itemSlot)
        {
            itemSlot.GetComponent<ItemSlot>().enabled = false;
        }

        isIconize = false;
    }


    [ClientRpc]
    public void RpcDeiconize(Vector3 itemPosition)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<Item>().enabled = true;

        this.transform.SetParent(null);
        this.transform.position = itemPosition;

        if (null != itemSlot)
        {
            itemSlot.GetComponent<ItemSlot>().enabled = false;
        }

        isIconize = false;
    }

    public bool IconizeState()
    {
        return isIconize;
    }

    public void SetIconizeState(bool isIconize)
    {
        if(isIconize == true)
        {
            GetComponentInChildren<ItemSlot>().enabled = false;
        } else
        {
            GetComponentInChildren<ItemSlot>().enabled = true;
        }

        this.isIconize = isIconize;
    }     

    public void SetIconSlot(GameObject gb)
    {
        itemSlot = gb;
    }

    public GameObject IconSlot()
    {
        return itemSlot;
    }
}

