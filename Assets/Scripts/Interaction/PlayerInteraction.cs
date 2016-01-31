using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject Inventory;
    private bool canPickUp;
    private ItemData itemInRange;
    private int itemSelected;
    private bool enemyInRange;
    public InventoryLogic inventoryLogic;
    private GameObject enemy;

    public void InitInventory(GameObject InventoryObject)
    {
        Inventory = InventoryObject;
        inventoryLogic = Inventory.GetComponent<InventoryLogic>();
    }
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.I))
	    {            
	        Inventory.SetActive(!Inventory.activeSelf);
	    }

	    SelectItem();

	    if (Input.GetKeyDown(KeyCode.E) && canPickUp)
	    {
            Inventory.SetActive(true);            
	        inventoryLogic.AddItem(itemInRange.type);
            Destroy(itemInRange.gameObject);
	        canPickUp = false;
	    }

	    if (Input.GetKeyDown(KeyCode.F))
	    {
	        if (Inventory.activeSelf)
	        {
                Debug.Log("using item " + inventoryLogic.PlayerItems[itemSelected].Name);
	            inventoryLogic.PlayerItems[itemSelected].ActivateItem(enemyInRange, enemy);
	        }
	    }
	}

    private void SelectItem()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            itemSelected = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            itemSelected = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            itemSelected = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            itemSelected = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            itemSelected = 4;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!canPickUp)
        {
            if (col.tag == "Item")
            {             
                canPickUp = true;
                itemInRange = col.GetComponent<ItemData>();
            }
        }

        if (col.tag == "boss")
        {
            enemyInRange = true;
            enemy = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "item")
        {
            Debug.Log("can't pick up");
            canPickUp = false;
            itemInRange = null;
        }
        else if (col.tag == "boss")
        {
            enemyInRange = false;
            enemy = null;
        }
    }
}
