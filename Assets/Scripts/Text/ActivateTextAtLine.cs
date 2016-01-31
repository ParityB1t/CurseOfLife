using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public bool requireButtonPress;
    private bool waitForPress;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();


	}
	
	// Update is called once per frame
	void Update () {
        if (waitForPress && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            theTextBox.reloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    //when the player enters the collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player(Clone)")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            theTextBox.reloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    //if the player leaves the area.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
