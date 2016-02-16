using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    public GameObject picture;

    public void dropItem()
    {
        Instantiate(picture, transform.position, picture.transform.rotation);
    }
}
