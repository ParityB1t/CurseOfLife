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
        const float lookTime = 4.5f;
        
        while (active)
        {
            yield return new WaitForSeconds(1.2f);
            float startTime = Time.time;

            GetComponent<SpriteRenderer>().sprite = awake;

            while (Time.time - startTime < lookTime)
            {
                yield return null;
            }
            
            GetComponent<SpriteRenderer>().sprite = sleep;
            looking = false;
        }
    }
}
