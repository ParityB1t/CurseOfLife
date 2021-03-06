﻿using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
    public float heartBeatSpeed;
    public bool isNormalHeartRate;
    public GameObject heart1;
    public GameObject heart2;
    public bool showHeart1;
    public bool showHeart2;    
    public bool dead;

	// Use this for initialization
	void Start ()
	{

	    heart1 = transform.GetChild(0).gameObject;
        heart2 = transform.GetChild(1).gameObject; 
        if (isNormalHeartRate)
        {
            //decreasing the heart beat speed variable increases the speed that the heart beats.
            heartBeatSpeed = 1;
            StartCoroutine(HeartBeat());
        }
    }
	
	// Update is called once per frame
	IEnumerator HeartBeat() {
        while (!dead)
        {
            yield return new WaitForSeconds(heartBeatSpeed * 1.5f);
            ShowHeart1();
            yield return new WaitForSeconds(heartBeatSpeed * 0.3f);
            ShowHeart2();            
        }
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
