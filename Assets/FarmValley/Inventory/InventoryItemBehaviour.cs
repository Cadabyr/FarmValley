using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FarmValley.Inventory {
    public class InventoryItemBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
        [SerializeField] private RectTransform dragRect;
        private Canvas canvas;
        private Transform inventoryDragHolder;
        private CanvasGroup canvasGroup;
        private Transform inventorySlot;

        private Vector3 tempPosition;

        public void SetupItem(Canvas canvas, Transform inventoryDragHolder) {
            this.canvas = canvas;
            this.inventoryDragHolder = inventoryDragHolder;
        }

        private void Awake() {
            inventorySlot = transform.parent;
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Gets the slot that this item belongs to
        /// </summary>
        /// <returns>The slot's Transform</returns>
        public Transform GetSlotTransform() {
            return inventorySlot;
        }

        //This is used because OnEndDrag isn't called before OnDrop
        public void SendItemBackToSlot() {
            transform.SetParent(inventorySlot);
        }

        public void OnDrag(PointerEventData eventData) {
            //Make sure the item isn't "disabled"
            if(canvasGroup.alpha == 0)
                return;

            dragRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            //Make sure the item isn't "disabled"
            if(canvasGroup.alpha == 0)
                return;

            canvasGroup.alpha = .5f;
            canvasGroup.blocksRaycasts = false;

            tempPosition = dragRect.position;

            transform.SetParent(inventoryDragHolder);
        }

        public void OnEndDrag(PointerEventData eventData) {
            //Make sure the item isn't "disabled"
            if(canvasGroup.alpha != 0)
                canvasGroup.alpha = 1f;

            canvasGroup.blocksRaycasts = true;
            transform.SetParent(inventorySlot);

            dragRect.position = tempPosition;
        }
    }
}