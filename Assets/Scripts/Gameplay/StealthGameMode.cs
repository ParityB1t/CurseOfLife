using UnityEngine;
using System.Collections;

public class StealthGameMode : MonoBehaviour
{

    public SleepBossState sleepBoss;
    public bool hidden;		
	
	void Update () {
	    if (sleepBoss.looking && !hidden)
	    {
            Debug.Log("lose");
	        //fade to black, restart
	    }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (!hidden)
        {
            hidden = true;
        }
            
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (hidden)
        {
            hidden = false;
        }
    }
}
