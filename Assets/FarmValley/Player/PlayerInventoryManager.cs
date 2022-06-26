using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmValley.Inventory;

namespace FarmValley.Player {
    public class PlayerInventoryManager : MonoBehaviour {
        [SerializeField] Transform slotsHolder;
        [SerializeField] GameObject slotPrefab;
        [SerializeField] PlayerInventory inventory;
        [SerializeField] CanvasGroup inventoryCanvas;
        [SerializeField] Transform dragObjectHolder;

        // Start is called before the first frame update
        void Awake() {
            Canvas canvas = inventoryCanvas.GetComponent<Canvas>();

            //Create the UI slots
            for(int i = 0; i < 32; i++) {
                //Setup slot
                GameObject uiSlot = Instantiate(slotPrefab, slotsHolder.transform);
                uiSlot.GetComponent<InventorySlotBehaviour>().Setup(this);
                uiSlot.name = $"{uiSlot.name} {i}";

                //Setup item in that slot
                InventoryItemBehaviour item = uiSlot.GetComponentInChildren<InventoryItemBehaviour>();
                item.SetupItem(canvas, dragObjectHolder);
                item.GetComponent<CanvasGroup>().alpha = 0;
            }

            dragObjectHolder.GetComponent<RectTransform>().SetAsLastSibling();
            inventory = new PlayerInventory(slotsHolder);
        }

        // Move this to a separate behaviour for properness
        void Update() {
            if(Input.GetKeyDown(KeyCode.Tab)) {
                ToggleCanvas(inventoryCanvas);
            }
        }

        void ToggleCanvas(CanvasGroup canvas) {
            canvas.alpha = canvas.alpha == 1 ? 0 : 1;
            canvas.interactable = !canvas.interactable;
            canvas.blocksRaycasts = !canvas.blocksRaycasts;
        }

        public PlayerInventory GetInventory() {
            return inventory;
        }
    }
}