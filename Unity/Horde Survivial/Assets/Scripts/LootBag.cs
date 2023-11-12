using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject DroppedLoot;
    //public List<Loot> LootList = new List<Loot>();

   // Loot GetDroppedItem()
  // {
   //     int randomNumber = Random.Range(1, 100);
   ///     List<Loot> possibleItems = new List<Loot>();
    //    foreach (Loot item in LootList)
    //    {
      //      if(randomNumber <= item.dropChance)
    //        {
      //          possibleItems.Add(item);
    ///        }
   //     }

   //     if(possibleItems.Count > 0) 
   //     {
   //         Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
   //         return droppedItem;
        
  //      }
  ///      return null;
 //   }

 //   public void InstantiateLoot(Vector3 SpawnPosition)
 //   {
     //   Loot droppedItem = GetDroppedItem();
     //   if(droppedItem != null) 
     //   {
     //       GameObject lootGameObject = Instantiate(DroppedLoot, SpawnPosition, Quaternion.identity);
     //       lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
     //   }
  //  }
}
