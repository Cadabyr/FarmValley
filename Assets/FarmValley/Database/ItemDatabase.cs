using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Database;

namespace FarmValley.Inventory {
    public class ItemDatabase : MonoBehaviour {
        [SerializeField]
        private List<ItemData> itemData = new List<ItemData>();

        public List<ItemData> getItemData() {
            return itemData;
        }

        /// <summary>
        /// Get an item from the database from it's id
        /// </summary>
        /// <param name="itemId">The item's ID that you are searching for</param>
        /// <returns>The ItemData for the selected item ID, null if not found</returns>
        public ItemData getItemData(string itemId) {
            foreach(ItemData itemData in itemData) {
                if(itemData.itemId == itemId) {
                    return itemData;
                }
            }

            Debug.LogError($"<color=red>Attempted to get itemData for {itemId} but it could not be found.</color>");
            return null;
        }
    }
}