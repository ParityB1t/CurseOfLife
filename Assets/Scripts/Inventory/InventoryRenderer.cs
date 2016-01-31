using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{        
    //bit redundant
    private int maxLoad = 5;
    private float gapBetweenSlots;

    public GameObject InventorySpace;    
    private InventoryLogic inventoryLogic;

    public List<Sprite> itemImages;

    void Awake()
    {
        inventoryLogic = GetComponent<InventoryLogic>();           
    }
	
	void Start ()
	{
        Debug.Log("generate database");
        inventoryLogic.SetUpDatabase(itemImages);
        gapBetweenSlots = InventorySpace.GetComponent<RectTransform>().rect.height*2.5f;
        RenderInventory();
	}

    /*
     * Render the inventory slots in correct positions
     */
    private void RenderInventory()
    {
        int itemSlotNumber = 0;
        float y = 0;

        for (int i = 0; i < maxLoad; i++)
        {            

            GameObject newInventorySpace = Instantiate(InventorySpace);
            SlotLogic slot = newInventorySpace.GetComponent<SlotLogic>();
            slot.setInventory(inventoryLogic,this);
            slot.ItemSlotNumber = itemSlotNumber;
            
            itemSlotNumber++;            
            
            newInventorySpace.transform.name = "slot " + i;
            newInventorySpace.transform.SetParent(this.transform);
            newInventorySpace.GetComponent<RectTransform>().localPosition = new Vector2(0, y);

            y -= gapBetweenSlots;
        }
    }


}
