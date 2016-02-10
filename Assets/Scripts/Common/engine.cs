using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
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
    private GameObject canvas;
    public GameObject EventSystem;

    //inventory
    private GameObject inventoryInstance;
    public GameObject Inventory;

    public GameObject TextBoxManager;    

    
    //environment
    public GameObject worldMap;
    public GameObject Walls;
    public GameObject Initialitems;
            

    //heart
    public GameObject heart;
    private GameObject heartInstance;

    // Bosses
    public GameObject sleepBoss;
    private bool defeatedSleep;    

    public static engine Instance;
    
	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);

	    Instance = this;

        #region UI

        canvas = Instantiate(Canvas);
        GameObject eventSys = Instantiate(EventSystem);

        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSys);

        #endregion

        BeginGame(canvas);
        
        
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
    

    public void LoadWorld()
    {        

        Instantiate(worldMap);
        Instantiate(Walls, new Vector3(0, 11), Walls.transform.rotation);

        GameObject playerInstance = Instantiate(player);
        playerInstance.transform.position = new Vector3(0, -2f);
        playerInstance.GetComponent<PlayerNodeState>().x = 2;
        playerInstance.GetComponent<PlayerNodeState>().y = 2;                



        if (!alreadyLoaded)
        {

            GameObject items = Instantiate(Initialitems);
            DontDestroyOnLoad(items);

            inventoryInstance = Instantiate(Inventory);

            #region inventory

            inventoryInstance.transform.SetParent(canvas.transform);
            inventoryInstance.transform.localScale = Vector3.one;
            inventoryInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100, inventoryInstance.transform.position.y);

            playerInstance.GetComponent<PlayerInteraction>().InitInventory(inventoryInstance);

            StartCoroutine(WaitTillGenerateDatabase(inventoryInstance.GetComponent<InventoryLogic>()));

            alreadyLoaded = true;
            
            DontDestroyOnLoad(inventoryInstance);

            #endregion
        }

        #region heart

        heartInstance = Instantiate(heart);
        heartInstance.transform.SetParent(canvas.transform);
        heartInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(70, -70);
        Heart heartComponent = heartInstance.GetComponent<Heart>();
        heartComponent.isNormalHeartRate = true;
        heartComponent.playerStealth = player.GetComponent<StealthGameMode>();
        
        #endregion

        #region Bosses

        if (!defeatedSleep)
        {
            GameObject sleepBossInstance = Instantiate(sleepBoss);
            sleepBossInstance.name = "SleepBoss";
            sleepBossInstance.transform.position = new Vector3(0, 13);
            SleepBossState sleepBossState = sleepBossInstance.GetComponent<SleepBossState>();
            playerInstance.GetComponent<PlayerNodeState>().sleepBoss = sleepBossState;
            playerInstance.GetComponent<StealthGameMode>().sleepBoss = sleepBossState;            
        }

        #endregion                  
    }

    public void LoadHouse()
    {
        GameObject playerInstance = Instantiate(playerInHouse);        
        playerInstance.transform.position = new Vector3(8.3f,-1.3f);
        playerInstance.GetComponent<SpriteRenderer>().sprite = playerInstance.GetComponent<PlayerMovement>().back;
        PlayerNodeState houseState = playerInstance.GetComponent<PlayerNodeState>();

        houseState.x = 1;
        houseState.y = 0;

        transform.position = new Vector3(8,0,-10);        

        DontDestroyOnLoad(playerInstance);
    }

    IEnumerator WaitTillGenerateDatabase(InventoryLogic inventory)
    {
        while (inventory.itemDB.ItemDatabase.Count < 5)
        {
            yield return null;
        }

        inventory.gameObject.SetActive(false);
    }

    public void defeatSleep()
    {
        defeatedSleep = true;
    }
    
}
