using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 0.04f;
    public bool canMove = true;

    public Sprite front;
    public Sprite back;
    public Sprite Left;
    public Sprite right;

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
                GetComponent<SpriteRenderer>().sprite = right;
                transform.position -= new Vector3(speed, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<SpriteRenderer>().sprite = Left;
                transform.position += new Vector3(speed, 0, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<SpriteRenderer>().sprite = back;
                transform.position += new Vector3(0, speed, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<SpriteRenderer>().sprite = front;
                transform.position -= new Vector3(0, speed, 0);
            }
        }
    }

    public float Speed()
    {
        return speed;
    }
}
