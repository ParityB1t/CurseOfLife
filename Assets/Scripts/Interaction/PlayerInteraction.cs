using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject Inventory;

	void Start () {
	    
	}
	
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.I))
	    {            
	        Inventory.SetActive(!Inventory.activeSelf);
	    }	    
	}
}
