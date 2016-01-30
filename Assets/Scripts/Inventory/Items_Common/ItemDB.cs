using System.Collections.Generic;
using UnityEngine;

public class ItemDB {

    public List<Item> ItemDatabase = new List<Item>();    

    public ItemDB()
    {
        
    }

    public void GenerateDatabase(List<Sprite> itemImages)
    {
        ItemDatabase.Add(new Item("Holy Water", Item.ItemType.holyWater, "Poison to those unholy",itemImages[0]));
        ItemDatabase.Add(new Item("Talisman", Item.ItemType.lightningTalisman, "The incarnation of lightning",itemImages[1]));
        ItemDatabase.Add(new Item("A Mother's Picture 1", Item.ItemType.motherPicture, "A memory of the one you loved",itemImages[2]));
        ItemDatabase.Add(new Item("The Children Picture", Item.ItemType.childrenPicture, "A memory of those you adored",itemImages[3]));
        ItemDatabase.Add(new Item("A Mother's Picture 2", Item.ItemType.pregnantPicture, "A memory you never experienced",itemImages[4]));
    }

}
