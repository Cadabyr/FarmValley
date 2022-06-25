using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Player;
using FarmValley.Database;

public class InventoryTest : MonoBehaviour {
    [SerializeField]
    Inventory testInventory;

    // Start is called before the first frame update
    void Start() {
        testInventory = new Inventory(32);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) {
            bool completed = testInventory.AddItem("testItem", 1);
            if(completed == false)
                Debug.Log("Could not add item to inventory, inventory was full.");
        }
    }
}
