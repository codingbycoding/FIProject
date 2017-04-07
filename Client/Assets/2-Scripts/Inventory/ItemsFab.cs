using UnityEngine;


public class ItemsFab : MonoBehaviour {

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
