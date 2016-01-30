using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotLogic : MonoBehaviour, IPointerEnterHandler//, IPointerExitHandler
{

    private Image itemImage;
    [HideInInspector] public int ItemSlotNumber;
    private InventoryLogic inventoryLogic;    
    private Item itemInSlot;
    

    void Awake()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }

	void Start ()
	{
	    UpdateSlot();
	}

    /*
     * Updates the data in the slot if a change has been made in inventory logic
     */
    public void UpdateSlot()
    {
        itemInSlot = inventoryLogic.PlayerItems[ItemSlotNumber];

        if (itemInSlot.ItemImage != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = itemInSlot.ItemImage;
        }
        else
        {
            itemImage.enabled = false;
        }
    }	

       
    public Item ReturnItemInSlot()
    {
        return itemInSlot;
    }

    public void setInventory(InventoryLogic logic, InventoryRenderer renderer)
    {
        inventoryLogic = logic;        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemInSlot.Name != null)
        {
            Debug.Log(itemInSlot.Name);
        }
    }
}
