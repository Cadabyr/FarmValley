using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Player {
    [System.Serializable]
    public class Inventory {
        [SerializeField]
        InventorySlot[] slots;
        public Inventory(int amountOfSlots) {
            slots = new InventorySlot[amountOfSlots];
        }

        /// <summary>
        /// Adds an item to the inventory if there is space
        /// </summary>
        /// <returns>If the item was succesfully added to the inventory</returns>
        public bool AddItem(string itemId, int amount) {
            //Try to find space for the item
            InventorySlot emptySlot = null;
            foreach(InventorySlot slot in slots) {
                //Check if slot is null
                if(slot.item == null) {
                    //Check if there is no current empty slot saved
                    if(emptySlot == null) {
                        emptySlot = slot;
                    }
                    continue;
                }

                //Check if the slot has the same item and can fit this amount
                if(slot.item.itemReference == itemId && slot.amount + amount <= 64) {
                    emptySlot = slot;
                }
            }

            //Return false if we couldn't find an empty inventory slot
            if(emptySlot == null)
                return false;

            //Add the item to the slot
            if(emptySlot.item == null)
                emptySlot.item = new Item(itemId);
            emptySlot.amount += amount;
            return true;
        }
    }
}