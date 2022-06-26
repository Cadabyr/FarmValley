using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Inventory {
    [System.Serializable]
    public class InventorySlot {
        /// <summary>
        /// The current item held by the inventory slot
        /// </summary>
        public Item item { get; set; }

        /// <summary>
        /// The current amount of the item held in this inventory slot
        /// </summary>
        [SerializeField]
        public int amount { get; set; }
    }
}