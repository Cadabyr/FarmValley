using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Database {
    [System.Serializable]
    public class ItemData {
        public string itemId;
        public string literalName { get; private set; }
    }
}