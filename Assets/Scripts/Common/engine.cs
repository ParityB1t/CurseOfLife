using UnityEngine;
using System.Collections;

public class engine : MonoBehaviour {

    public GameObject player;

    public GameObject Canvas;
    public GameObject Inventory;
    

	// Use this for initialization
	void Start () {

        GameObject playerInstance = Instantiate(player);
        transform.SetParent(playerInstance.transform);

	    GameObject inventoryInstance = Instantiate(Inventory);
        inventoryInstance.transform.SetParent(Canvas.transform);
	    inventoryInstance.transform.localScale = Vector3.one;
        inventoryInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100,inventoryInstance.transform.position.y);

	    playerInstance.GetComponent<PlayerInteraction>().Inventory = inventoryInstance;  
        inventoryInstance.SetActive(false);
	}

    	
	void Update () {
        	    
	}
}
