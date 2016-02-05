using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerTransition2 : MonoBehaviour
{

    private string boundTag = "Bounds";
    private string top = "TopBound";
    private string bottom = "BottomBound";
    private string left = "LeftBound";
    private string right = "RightBound";

    private Vector3 sceneDimension = new Vector3(8, 6);

    private PlayerNodeState nodestate;

    private engine engine;

    void Start()
    {
        nodestate = GetComponent<PlayerNodeState>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == boundTag)
        {

            GetComponent<PlayerMovement>().enabled = false;
            
            if (col.gameObject.name == bottom)
            {
                if (nodestate.x == 1)
                {                    
                    SceneManager.LoadScene(2);                    
                    StartCoroutine(WaitTillGenerate());                    
                }                                
            }
            else if (col.gameObject.name == left)
            {
                if (nodestate.x > 0)
                {
                    nodestate.MoveLeft();
                    StartCoroutine(moveCamera(Vector3.left));
                }

            }
            else if (col.gameObject.name == right)
            {
                if (nodestate.x < nodestate.getMapSize())
                {
                    nodestate.MoveRight();
                    StartCoroutine(moveCamera(Vector3.right));
                }
            }            
        }
    }

    private IEnumerator WaitTillGenerate()
    {
        yield return new WaitForSeconds(0);
        Camera.main.transform.position = new Vector3(0, 0, -10);
        engine.LoadWorld();
        Destroy(gameObject);

    }


    IEnumerator moveCamera(Vector3 direction)
    {
            Vector3 moveCameraBy = Vector3.Scale(direction, sceneDimension);
            Vector3 movePlayerBy = Vector3.Scale(direction, GetComponent<PlayerMovement>().Speed()*sceneDimension*8f);

            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 finalPosition = cameraPosition + moveCameraBy;

            Vector3 playerPosition = transform.position;
            Vector3 finalPlayerPosition = transform.position + movePlayerBy;

            const float transitionTime = 1.3f;
            float startTime = Time.time;

            transform.position = transform.position + (direction*0.1f);

            while (Camera.main.transform.position != finalPosition)
            {
                Camera.main.transform.position = Vector3.Lerp(cameraPosition, finalPosition,
                    (Time.time - startTime)/transitionTime);
                transform.position = Vector3.Lerp(playerPosition, finalPlayerPosition,
                    (Time.time - startTime)/transitionTime);
                yield return null;
            }

            GetComponent<PlayerMovement>().enabled = true;
      }

    public void setEngine(engine engine)
    {
        this.engine = engine;
    } 
}
