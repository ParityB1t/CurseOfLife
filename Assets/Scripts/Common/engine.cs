using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class engine : MonoBehaviour {

    public GameObject player;

    public GameObject Canvas;
    public GameObject Inventory;

    public GameObject TextBoxManager;    

    
    //environment
    public GameObject worldMap;
    public GameObject Walls;
    public GameObject Initialitems;
        
    //heart
    public GameObject heart;

    // Bosses
    public GameObject sleepBoss;

	// Use this for initialization
	void Start () {

        #region environment


	    Instantiate(worldMap);
	    Instantiate(Walls, new Vector3(0, 11), Walls.transform.rotation);
	    Instantiate(Initialitems);

        #endregion

        GameObject playerInstance = Instantiate(player);
        playerInstance.transform.position = new Vector3(0,-2.8f);
        
        GameObject textBoxManagerInstance = Instantiate(TextBoxManager);
	    GameObject inventoryInstance = Instantiate(Inventory);
        GameObject heartInstance = Instantiate(heart);
	    
        textBoxManagerInstance.GetComponent<TextBoxManager>().player = playerInstance.GetComponent<PlayerMovement>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().textBox = GameObject.FindGameObjectWithTag("textbox");
        textBoxManagerInstance.GetComponent<TextBoxManager>().theText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().InitTextBox();               

        #region heart
        Heart heartComponent = heartInstance.GetComponent<Heart>();
        heartComponent.isNormalHeartRate = true;
        heartComponent.playerStealth = player.GetComponent<StealthGameMode>();
        #endregion

        #region inventory

        inventoryInstance.transform.SetParent(Canvas.transform);
	    inventoryInstance.transform.localScale = Vector3.one;
        inventoryInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100,inventoryInstance.transform.position.y);
       
        playerInstance.GetComponent<PlayerInteraction>().InitInventory(inventoryInstance);
        
        StartCoroutine(WaitTillGenerateDatabase(inventoryInstance.GetComponent<InventoryLogic>()));

        #endregion

        #region Bosses

        GameObject sleepBossInstance = Instantiate(sleepBoss);
	    sleepBossInstance.name = "SleepBoss";
        sleepBossInstance.transform.position = new Vector3(0,13);
        SleepBossState sleepBossState = sleepBossInstance.GetComponent<SleepBossState>();
	    playerInstance.GetComponent<PlayerNodeState>().sleepBoss = sleepBossState;
	    playerInstance.GetComponent<StealthGameMode>().sleepBoss = sleepBossState;
	    #endregion
	}

    IEnumerator WaitTillGenerateDatabase(InventoryLogic inventory)
    {
        while (inventory.itemDB.ItemDatabase.Count < 5)
        {
            yield return null;
        }

        inventory.gameObject.SetActive(false);
    }
    
}
