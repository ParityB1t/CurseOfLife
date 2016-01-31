using UnityEngine;
using System.Collections;

public class engine : MonoBehaviour {

    public GameObject player;

    public GameObject Canvas;
    public GameObject Inventory;

    //environment
    public GameObject worldMap;
    public GameObject Walls;
        


    // Bosses
    public GameObject sleepBoss;

	// Use this for initialization
	void Start () {

        #region environment

	    Instantiate(worldMap);
	    Instantiate(Walls, new Vector3(0, 12), Walls.transform.rotation);

        #endregion

        GameObject playerInstance = Instantiate(player);

        #region inventory

        GameObject inventoryInstance = Instantiate(Inventory);
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
