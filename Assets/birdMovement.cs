using UnityEngine;
using System.Collections;

public class birdMovement : MonoBehaviour {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseWaitTime = 5f;                        // The amount of time to wait when the last sighting is reached.
    public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
    public Vector3[] patrolWayPoints = new Vector3[2]{new Vector3(-0.52f,19.46f), new Vector3(38.59f,19.4f)};                     // An array of transforms for the patrol route.


    private NavMeshAgent nav;                               // Reference to the nav mesh agent.
    private Transform player;                               // Reference to the player's transform.
    private float chaseTimer;                               // A timer for the chaseWaitTime.
    private float patrolTimer;                              // A timer for the patrolWaitTime.
    private int wayPointIndex; 

    private bool dead = false;
      
	// Use this for initialization
	void Start () {
        // Setting up the references.
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	/*void Update () {
        patrolling();
        this.transform.position = new Vector3(-0.1f, 19.12f);
	}*/

    IEnumerator patrolling()
    {
         while (!dead)
         {
             yield return StartCoroutine(goToNextPoint(patrolWayPoints[0]));
             yield return StartCoroutine(goToNextPoint(patrolWayPoints[1]));
         }
    }

    IEnumerator goToNextPoint(Vector3 nextPoint)
    {
        while (transform.position != nextPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, 1);
            yield return null;
        }
    }
}
