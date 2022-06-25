using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Inventory;

namespace FarmValley.Player {
    /// <summary>
    /// A graphical version of the Inventory class
    /// </summary>
    public class PlayerInventory : Inventory.Inventory {
        private Transform inventorySlotHolder;

        public PlayerInventory(Transform slotHolder) : base(32) {
            this.inventorySlotHolder = slotHolder;
        }

        //Adds the graphical element to the UI
        public override int AddItem(string itemId, int amount) {
            int slot = AddInventoryItem(itemId, amount);
            if(slot != -1) {
                Transform uiSlot = inventorySlotHolder.GetChild(slot);
                Transform uiAmount = uiSlot.Find("Amount");
                Transform uiIcon = uiSlot.Find("ItemIcon");

                uiAmount.GetComponent<TMPro.TextMeshProUGUI>().text = "" + GetSlots()[slot].amount;
                uiIcon.gameObject.SetActive(true);
            }

            return slot;
        }
    }
}