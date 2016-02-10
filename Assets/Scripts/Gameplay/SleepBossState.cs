using UnityEngine;
using System.Collections;

public class SleepBossState : MonoBehaviour
{
    private Coroutine wakeUpRoutine;
    [HideInInspector] public bool active;
    [HideInInspector] public bool looking = false;

    public Sprite sleep;
    public Sprite awake;

    private GameObject vision;

    void Start()
    {
        vision = transform.GetChild(0).gameObject;
        vision.SetActive(false);
    }
	

    public void ActivateStealthLevel()
    {        
        wakeUpRoutine = StartCoroutine(SleepWakeUpRoutine());
    }

    IEnumerator SleepWakeUpRoutine()
    {        
        while (active)
        {
            
            yield return new WaitForSeconds(1.2f);            

            GetComponent<SpriteRenderer>().sprite = awake;
            vision.SetActive(true);
            
            yield return new WaitForSeconds(4.5f);
            
            GetComponent<SpriteRenderer>().sprite = sleep;
            looking = false;
        }
    }
}
