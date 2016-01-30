using UnityEngine;
using System.Collections;

public class engine : MonoBehaviour {
    public GameObject player;
//    public GameObject bird;

	// Use this for initialization
	void Start () {
        player = Instantiate(player);
//      Instantiate(bird);
//        bird.AddComponent<birdMovement>()
        this.transform.SetParent(player.GetComponent<Transform>());

	}

    
	// Update is called once per frame
	void Update () {
	
	}
}
