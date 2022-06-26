using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FarmValley.Inventory {
    [System.Serializable]
    public class Inventory {
        [SerializeField]
        InventorySlot[] slots;
        public Inventory(int amountOfSlots) {
            slots = new InventorySlot[amountOfSlots];

            for(int i = 0; i < slots.Length; i++) {
                slots[i] = new InventorySlot();
                //slots[i].amount = 0;
            }
        }

        /// <summary>
        /// Adds an item to the inventory if there is space
        /// </summary>
        /// <returns>The index of the inventory slot, -1 if it was not added</returns>
        public virtual int AddItem(string itemId, int amount) {
            return AddInventoryItem(itemId, amount);
        }

        
        private protected int AddInventoryItem(string itemId, int amount) {
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
                return -1;

            //Add the item to the slot
            if(emptySlot.item == null)
                emptySlot.item = new Item(itemId);
            emptySlot.amount += amount;
            return Array.IndexOf(slots, emptySlot);
        }

        public InventorySlot[] GetSlots() {
            return slots;
        }

        public void SwapItems(int index1, int index2) {
            (slots[index1], slots[index2]) = (slots[index2], slots[index1]);
        }
    }
}