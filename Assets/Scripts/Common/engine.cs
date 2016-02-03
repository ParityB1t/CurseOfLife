using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class engine : MonoBehaviour {

    //engine
    private bool alreadyLoaded;

    //player
    public GameObject player;
    public GameObject playerInHouse;

    //UI
    public GameObject Canvas;
    public GameObject EventSystem;
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

        DontDestroyOnLoad(gameObject);

        #region UI

        GameObject canvas = Instantiate(Canvas);
        GameObject eventSys = Instantiate(EventSystem);

        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSys);

        #endregion

        BeginGame(canvas);
        
        /*GameObject playerInstance = Instantiate(player);
        playerInstance.transform.position = new Vector3(0,-2.8f);
        
        
	    GameObject inventoryInstance = Instantiate(Inventory);
        GameObject heartInstance = Instantiate(heart);
	            
        #region heart
        Heart heartComponent = heartInstance.GetComponent<Heart>();
        heartComponent.isNormalHeartRate = true;
        heartComponent.playerStealth = player.GetComponent<StealthGameMode>();
        #endregion
                

        #region inventory

        inventoryInstance.transform.SetParent(canvas.transform);
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
	    #endregion*/
	}

    void BeginGame(GameObject canvas)
    {
        
        GameObject playerInstance = Instantiate(playerInHouse);
        PlayerNodeState houseState = playerInstance.GetComponent<PlayerNodeState>();

        houseState.x = 0;
        houseState.y = 0;

        GameObject textBoxManagerInstance = Instantiate(TextBoxManager);
        TextBoxManager manager = textBoxManagerInstance.GetComponent<TextBoxManager>();
        manager.player = playerInstance.GetComponent<PlayerMovement>();
        manager.textBox = canvas.transform.GetChild(0).gameObject;
        manager.theText = manager.textBox.transform.GetChild(0).GetComponent<Text>();
        manager.InitTextBox();
        manager.EnableTextBox();

        manager.currentLine = 0;
        manager.endAtLine = 19;        

        DontDestroyOnLoad(playerInstance);
        DontDestroyOnLoad(textBoxManagerInstance);        

        SceneManager.LoadScene(1);
    }
    

    private void LoadWorld()
    {
        #region environment

        Instantiate(worldMap);
        Instantiate(Walls, new Vector3(0, 11), Walls.transform.rotation);

        if (!alreadyLoaded)
        {
            Instantiate(Initialitems);
            alreadyLoaded = true;
        }
            

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
