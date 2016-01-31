using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

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
        if (col.tag != "boss")
        {
            if (!hidden)
            {
                hidden = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "boss")
        {
            if (hidden)
            {
                hidden = false;
            }
        }
    }
}
