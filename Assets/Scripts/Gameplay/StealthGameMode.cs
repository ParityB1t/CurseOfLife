using System.Collections;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StealthGameMode : MonoBehaviour
{

    public SleepBossState sleepBoss;
    public bool hidden = true;

    public Heart heart;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "vision")
        {

            StartCoroutine(DeathSequence());
        }
    }

    private IEnumerator DeathSequence()
    {
        heart.heartBeatSpeed = 0.1f;
        GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(1f);
        float alpha = 1f;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        while (alpha > 0)
        {
            sprite.color = new Color(1,1,1,alpha);
            alpha += -.01f;

            yield return null;
        }

        heart.heartBeatSpeed = 1f;
        engine.Instance.LoadHouse();
        SceneManager.LoadScene(1);
    }
}
