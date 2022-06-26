using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Inventory;
using System;

namespace FarmValley.Player {
    /// <summary>
    /// A graphical version of the Inventory class for the Player's UI
    /// </summary>
    public class PlayerInventory : Inventory.Inventory {
        private Transform inventorySlotHolder;

        public PlayerInventory(Transform slotHolder) : base(32) {
            this.inventorySlotHolder = slotHolder;
        }

        //Adds the graphical element to the UI
        public override int AddItem(string itemId, int amount) {
            //Add the item to the inventory
            int slot = AddInventoryItem(itemId, amount);
            //Update the UI to reflect the addition
            if(slot != -1) {
                UpdateSlot(slot);
            }

            return slot;
        }

        /// <summary>
        /// Updates all the UI slots in the inventory
        /// </summary>
        public void RefreshUI() {
            for(int i = 0; i < 32; i++) {
                UpdateSlot(i);
            }
        }

        /// <summary>
        /// Updates the slot UI
        /// </summary>
        /// <param name="slotIndex">The index of the slot that is being updates</param>
        private void UpdateSlot(int slotIndex) {
            Transform uiSlot = inventorySlotHolder.GetChild(slotIndex);
            Transform uiAmount = uiSlot.Find("Amount");
            Transform uiIcon = uiSlot.Find("ItemIcon");

            //The amount of items in the slot
            int amount = GetSlots()[slotIndex].amount;

            uiAmount.GetComponent<TMPro.TextMeshProUGUI>().text = amount == 0 ? "" : "" + amount;
            if(uiIcon == null)
                return;
            uiIcon.gameObject.GetComponent<CanvasGroup>().alpha = amount == 0 ? 0 : 1;
        }
    }
}