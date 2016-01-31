using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class engine : MonoBehaviour {

    public GameObject player;

    public GameObject Canvas;
    public GameObject Inventory;
    public GameObject TextBoxManager;
    public GameObject OpeningDialogueTrigger;

	// Use this for initialization
	void Start () {

        GameObject playerInstance = Instantiate(player);
        transform.SetParent(playerInstance.transform);
        GameObject textBoxManagerInstance = Instantiate(TextBoxManager);
	    GameObject inventoryInstance = Instantiate(Inventory);

        textBoxManagerInstance.GetComponent<TextBoxManager>().player = playerInstance.GetComponent<PlayerMovement>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().textBox = GameObject.FindGameObjectWithTag("textbox");
        textBoxManagerInstance.GetComponent<TextBoxManager>().theText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().InitTextBox();       

        inventoryInstance.transform.SetParent(Canvas.transform);
	    inventoryInstance.transform.localScale = Vector3.one;
        inventoryInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100,inventoryInstance.transform.position.y);

	    playerInstance.GetComponent<PlayerInteraction>().Inventory = inventoryInstance;  
        inventoryInstance.SetActive(false);
	}

    	
	void Update () {
        	    
	}
}
