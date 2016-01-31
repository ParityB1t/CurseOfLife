using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class engine : MonoBehaviour {

    public GameObject player;

    public GameObject Canvas;
    public GameObject Inventory;


    public GameObject TextBoxManager;
    public GameObject OpeningDialogueTrigger;
    
    //environment
    public GameObject worldMap;
    public GameObject Walls;
        
    //heart
    public GameObject heart;

    // Bosses
    public GameObject sleepBoss;

	// Use this for initialization
	void Start () {

        #region environment

	   // Instantiate(worldMap);
	  //  Instantiate(Walls, new Vector3(0, 12), Walls.transform.rotation);

        #endregion

        GameObject playerInstance = Instantiate(player);
        transform.SetParent(playerInstance.transform);
        GameObject textBoxManagerInstance = Instantiate(TextBoxManager);
	    GameObject inventoryInstance = Instantiate(Inventory);
        GameObject heartInstance = Instantiate(heart);

        textBoxManagerInstance.GetComponent<TextBoxManager>().player = playerInstance.GetComponent<PlayerMovement>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().textBox = GameObject.FindGameObjectWithTag("textbox");
        textBoxManagerInstance.GetComponent<TextBoxManager>().theText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        textBoxManagerInstance.GetComponent<TextBoxManager>().InitTextBox();       

        transform.SetParent(playerInstance.transform);

        #region heart
        Heart heartComponent = heartInstance.GetComponent<Heart>();
        heartComponent.isNormalHeartRate = true;
        heartComponent.playerStealth = player.GetComponent<StealthGameMode>();
        #endregion

        #region inventory

        inventoryInstance.transform.SetParent(Canvas.transform);
	    inventoryInstance.transform.localScale = Vector3.one;
        inventoryInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100,inventoryInstance.transform.position.y);
       
        playerInstance.GetComponent<PlayerInteraction>().Inventory = inventoryInstance;  
        inventoryInstance.SetActive(false);

        #endregion

        #region Bosses

        GameObject sleepBossInstance = Instantiate(sleepBoss);
        sleepBossInstance.transform.position = new Vector3(0,14);
        SleepBossState sleepBossState = sleepBossInstance.GetComponent<SleepBossState>();
	    playerInstance.GetComponent<PlayerNodeState>().sleepBoss = sleepBossState;
	    playerInstance.GetComponent<StealthGameMode>().sleepBoss = sleepBossState;
	    #endregion
	}


    void Update () {
        	    
	}
}
