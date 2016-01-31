using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
    public float heartBeatSpeed;
    public bool isNormalHeartRate;
    public GameObject heart1;
    public GameObject heart2;
    public bool showHeart1;
    public bool showHeart2;
    public StealthGameMode playerStealth;

	// Use this for initialization
	void Start () {
        
        heartBeatSpeed = 1;
        heart1 = GameObject.Find("heart1");
        heart2 = GameObject.Find("heart2");
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void ShowHeart1()
    {
        heart1.SetActive(true);
        heart2.SetActive(false);
    }

    public void ShowHeart2()
    {
        heart2.SetActive(true);
        heart1.SetActive(false);
    }
}
