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

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == boundTag)
        {

            GetComponent<PlayerMovement>().enabled = false;

            if (col.gameObject.name == top)
            {
                StartCoroutine(moveCamera(Vector3.up));
            }
            else if (col.gameObject.name == bottom)
            {
                StartCoroutine(moveCamera(Vector3.down));
            }
            else if (col.gameObject.name == left)
            {                
                StartCoroutine(moveCamera(Vector3.left));
            }
            else if (col.gameObject.name == right)
            {
                StartCoroutine(moveCamera(Vector3.right));
            }
        }
    }

    IEnumerator moveCamera(Vector3 direction)
    {
        Vector3 moveCameraBy = Vector3.Scale(direction,sceneDimension);
        Vector3 movePlayerBy = Vector3.Scale(direction,GetComponent<PlayerMovement>().Speed() * sceneDimension * 1.5f);

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
