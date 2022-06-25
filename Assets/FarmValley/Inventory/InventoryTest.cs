using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Inventory;
using FarmValley.Database;
using FarmValley.Player;

public class InventoryTest : MonoBehaviour {
    private PlayerInventory inventory;

    // Start is called before the first frame update
    void Start() {
        inventory = GetComponent<PlayerInventoryManager>().GetInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T)) {
            int completed = inventory.AddItem("testItem", 1);
            if(completed == -1)
                Debug.Log("Could not add item to inventory, inventory was full.");
        }
        if(Input.GetKeyDown(KeyCode.G)) {
            foreach(InventorySlot slot in inventory.GetSlots()) {
                if(slot.item == null) {
                    continue;
                }
                Debug.Log($"Slot: {slot.item.itemReference} Amount: {slot.amount}");
            }
        }
    }
}
