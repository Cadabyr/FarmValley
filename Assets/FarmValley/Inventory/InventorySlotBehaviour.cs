using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace FarmValley.Inventory {
    public class InventorySlotBehaviour : MonoBehaviour, IDropHandler {
        Player.PlayerInventoryManager manager;

        public void Setup(Player.PlayerInventoryManager manager) {
            this.manager = manager;
        }

        public void OnDrop(PointerEventData eventData) {
            //Get the dropped item's slot
            GameObject droppedObject = eventData.pointerDrag;

            //Prevent the player from moving slots that are already empty
            if(droppedObject.GetComponent<CanvasGroup>().alpha == 0)
                return;

            InventoryItemBehaviour droppedItem = droppedObject.GetComponent<InventoryItemBehaviour>();

            int index1 = transform.GetSiblingIndex();
            int index2 = droppedItem.GetSlotTransform().GetSiblingIndex();

            if(index1 == index2)
                return;

            //Make sure the item is in it's parent slot before trying to refresh the UI
            droppedItem.SendItemBackToSlot();
            //Swap the items in the Inventory
            manager.GetInventory().SwapItems(index1, index2);
            //Refresh the player's UI to match the swapped items
            manager.GetInventory().RefreshUI();
        }
    }
}