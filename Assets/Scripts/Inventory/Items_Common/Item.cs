using UnityEngine;

public class Item : MonoBehaviour
{
    
    public string Name;    
    public ItemType itemType;
    public string ItemDescription;
    public Sprite ItemImage;    

    public enum ItemType
    {
        holyWater = 0,
        lightningTalisman = 1,
        motherPicture = 2,
        childrenPicture = 3,
        pregnantPicture = 4
    }

   public Item(string name, ItemType itemType, string description, Sprite image)
	{
	   this.Name = name;
	   this.itemType = itemType;
       this.ItemDescription = description;
       this.ItemImage = image;
	}

	public Item()
	{

	}

    public void ActivateItem(bool enemyInRange, GameObject enemy)
    {
        Debug.Log("item type = " + itemType);
        if (itemType == ItemType.holyWater)
        {
            if (enemy != null && enemy.name == "SleepBoss")
            {
                Debug.Log("killed sleepy");
                Destroy(enemy);
                //Play Animation for sleep boss death                
            }

        }
    }
}