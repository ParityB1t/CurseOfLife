using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class engine2 : MonoBehaviour
{

    public GameObject TextBoxManager;
    public GameObject player;    

	void Start () {

        GameObject playerInstance = Instantiate(player);

        GameObject textBoxManagerInstance = Instantiate(TextBoxManager);
	    TextBoxManager manager = textBoxManagerInstance.GetComponent<TextBoxManager>();
        manager.player = playerInstance.GetComponent<PlayerMovement>();
        manager.textBox = GameObject.FindGameObjectWithTag("textbox");
        manager.theText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        manager.isActive = true;
        manager.InitTextBox();

        
	    manager.currentLine = 0;
	    manager.endAtLine = 19;
	    manager.stopPlayerMovement = true;        

	}

}
