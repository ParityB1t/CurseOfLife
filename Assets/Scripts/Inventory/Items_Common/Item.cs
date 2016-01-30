using UnityEngine;

public class Item
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
}