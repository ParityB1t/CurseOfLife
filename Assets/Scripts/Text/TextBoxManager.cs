using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text theText;

    public bool stopPlayerMovement;
    public bool isActive;

    public int currentLine;
    public int endAtLine;

    public PlayerMovement player;
    public TextAsset textFile;
    public string[] textLines;

	// Use this for initialization
	public void InitTextBox() {
        if (textFile != null)
        {
            //split the text in the text file by line.
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

    }
	
	// Update is called once per frame
	void Update () {



        if (isActive) //
        {
            theText.text = textLines[currentLine];

            //use return or space bar to go through the text.
            if (Input.GetKeyDown(KeyCode.Return) | Input.GetKeyDown(KeyCode.Space))
            {
                currentLine += 1;
            }

            if (currentLine > endAtLine)
            {
                //will hide the textbox once the dialogue is finished.
                DisableTextBox();
            }
        }
        
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        player.canMove = true;
    }

    public void reloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
