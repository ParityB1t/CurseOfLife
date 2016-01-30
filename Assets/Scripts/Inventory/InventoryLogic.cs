using System.Collections.Generic;
using UnityEngine;

public class InventoryLogic : MonoBehaviour
{
    private const int inventorySize = 5;
    [HideInInspector] public Item[] PlayerItems = new Item[inventorySize];
    private ItemDB itemDB;

#region monobehaviour

    /// <summary>
    /// Init functions. Creates database (where it lies)
    /// Init empty items
    /// </summary>
    void Awake () {
	    itemDB = new ItemDB();        
	}

    void Start()
    {
        for (int i = 0; i < PlayerItems.Length; i++)
        {
            PlayerItems[i] = new Item();
        }        
    }

#endregion

    /// <summary>
    /// Set up the actualy database with images from list
    /// </summary>
    /// <param name="itemImages"></param>
    public void SetUpDatabase(List<Sprite> itemImages)
    {
        itemDB.GenerateDatabase(itemImages);
    }


    /*
     * Add a non-empty item which is in database
     */
    public bool AddItem(Item.ItemType item)
    {
        bool canPlaced = true;
        
        for (int i = 0; i < itemDB.ItemDatabase.Count; i++)
        {
            if (itemDB.ItemDatabase[i].itemType == item)
            {                
                Item itemToAdd = itemDB.ItemDatabase[i];                
                canPlaced = FindEmptySlotToPlace(itemToAdd);
                break;
            }
        }
                
        return canPlaced;
    }

    private bool FindEmptySlotToPlace(Item item)
    {        
        bool placed = false;
        int count = 0;
        
        while (!placed && count < inventorySize)
        {                        
            if (PlayerItems[count].Name == null)
            {                
                PlayerItems[count] = item;                
                transform.GetChild(count).GetComponent<SlotLogic>().UpdateSlot();
                placed = true;
            }
            else
            {
                count++;
            }
        }

        return placed;        
    }
   
    /*
     * Should only be used if item does exist in inventory
     */
    public int IndexOf(Item Item)
    {
        int index = -1;

        for (int i = 0; i < PlayerItems.Length; i++)
        {
            if (PlayerItems[i] == Item)
                index = i;
        }

        return index;
    }
}
