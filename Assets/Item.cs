using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Player {
    [System.Serializable]
    public class Item {
        /// <summary>
        /// The name of the item in the Item database
        /// </summary>
        public string itemReference { get; private set; }

        public Item(string itemReference) {
            this.itemReference = itemReference;
        }
    }
}