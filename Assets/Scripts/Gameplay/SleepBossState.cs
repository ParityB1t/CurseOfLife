using UnityEngine;
using System.Collections;

public class SleepBossState : MonoBehaviour
{
    private Coroutine wakeUpRoutine;
    [HideInInspector] public bool active;
    [HideInInspector] public bool looking = false;

    public Sprite sleep;
    public Sprite awake;    
	

    public void ActivateStealthLevel()
    {
        wakeUpRoutine = StartCoroutine(SleepWakeUpRoutine());
    }

    IEnumerator SleepWakeUpRoutine()
    {
        while (active)
        {
            yield return new WaitForSeconds(1.2f);
            looking = true;
            GetComponent<SpriteRenderer>().sprite = awake;
            yield return new WaitForSeconds(4.5f);
            GetComponent<SpriteRenderer>().sprite = sleep;
            looking = false;
        }
    }
}
