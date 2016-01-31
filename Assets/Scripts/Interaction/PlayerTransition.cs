using UnityEngine;
using System.Collections;

public class PlayerTransition : MonoBehaviour
{
    private string boundTag = "Bounds";
    private string top = "TopBound";
    private string bottom = "BottomBound";
    private string left = "LeftBound";
    private string right = "RightBound";

    private Vector3 sceneDimension = new Vector3(8,6);

    private PlayerNodeState nodestate;

    void Start()
    {
        nodestate = GetComponent<PlayerNodeState>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == boundTag)
        {

            GetComponent<PlayerMovement>().enabled = false;

            if (col.gameObject.name == top)
            {
                if (nodestate.Y() > 0)
                {
                    nodestate.MoveUp();
                    StartCoroutine(moveCamera(Vector3.up));
                }
                
            }
            else if (col.gameObject.name == bottom)
            {
                if (nodestate.Y() < nodestate.getMapSize())
                {
                    nodestate.MoveDown();
                    StartCoroutine(moveCamera(Vector3.down));
                }
                
            }
            else if (col.gameObject.name == left)
            {
                if (nodestate.X() > 0)
                {
                    nodestate.MoveLeft();
                    StartCoroutine(moveCamera(Vector3.left));
                }
                
            }
            else if (col.gameObject.name == right)
            {
                if (nodestate.X() < nodestate.getMapSize())
                {
                    nodestate.MoveRight();
                    StartCoroutine(moveCamera(Vector3.right));
                }
                
            }

            if (nodestate.isAtSleepBoss())
            {
                nodestate.sleepBoss.active = true;
                nodestate.sleepBoss.ActivateStealthLevel();
                GetComponent<StealthGameMode>().enabled = true;
            }
            else
            {
                nodestate.sleepBoss.active = false;
                GetComponent<StealthGameMode>().enabled = false;
            }
        }
    }

    IEnumerator moveCamera(Vector3 direction)
    {
        Vector3 moveCameraBy = Vector3.Scale(direction,sceneDimension);
        Vector3 movePlayerBy = Vector3.Scale(direction,GetComponent<PlayerMovement>().Speed() * sceneDimension * 3f);

        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 finalPosition = cameraPosition + moveCameraBy;

        Vector3 playerPosition = transform.position;
        Vector3 finalPlayerPosition = transform.position + movePlayerBy;

        const float transitionTime = 1.3f;
        float startTime = Time.time;

        transform.position = transform.position + (direction * 0.1f);

        while (Camera.main.transform.position != finalPosition)
        {
            Camera.main.transform.position = Vector3.Lerp(cameraPosition,finalPosition,(Time.time - startTime)/transitionTime);
            transform.position = Vector3.Lerp(playerPosition, finalPlayerPosition, (Time.time - startTime)/transitionTime);
            yield return null;
        }

        GetComponent<PlayerMovement>().enabled = true;
    }
}
