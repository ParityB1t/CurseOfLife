using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StealthGameMode : MonoBehaviour
{

    public SleepBossState sleepBoss;
    public bool hidden = true;
	
	void Update () {
	    if (sleepBoss.looking && !hidden)
	    {
            hidden = true;
            engine.Instance.LoadHouse();
            SceneManager.LoadScene(1);            
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
