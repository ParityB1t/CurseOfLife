using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    private float speed = 0.1f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (canMove)
        {
            /*float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal < 0)
            {
                transform.position -= new Vector3(speed, 0, 0);
            }
            else
            {
                transform.position += new Vector3(speed, 0, 0);
            }

            if (vertical < 0)
            {
                transform.position -= new Vector3(speed, 0, 0);
            }
            else
            {
                transform.position += new Vector3(speed, 0, 0);
            }*/

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed, 0, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, speed, 0);
            }
        }
    }
}
