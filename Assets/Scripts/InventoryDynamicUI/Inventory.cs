using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryIG {
    public class Inventory : MonoBehaviour {
        [SerializeField] private bool _displayed;

        public List<InventoryItem> Items = new List<InventoryItem>();

        public InventoryUI InventoryUIInstance;
        public GameObject InventoryUIContainer;
        public InventoryUI InventoryUIPrefab;


        public delegate void InventoryDelegate(Inventory item);

        public static event InventoryDelegate OnChanged;

        private void Start() {
            if (InventoryUIInstance != null)
                _displayed = InventoryUIInstance.gameObject.activeSelf;
            else
                _displayed = false;
        }

        public void SwitchDisplay() {
            if (InventoryUIContainer == null &&
                (InventoryUIContainer == null || InventoryUIPrefab == null)) return;

            if (!_displayed) {
                if (InventoryUIInstance != null) { }
                else {
                    InventoryUIInstance =
                        (InventoryUI)Instantiate(InventoryUIPrefab, InventoryUIContainer.transform);

                }
                InventoryUIInstance.Construct(this);
                _displayed = true;
            }
            else {
                Destroy(InventoryUIInstance.gameObject);
                //InventoryUIPrefab = null;
                _displayed = false;
            }
        }

        //[ContextMenu("ResetItems")]
        //public void ResetItems() {
        //    Debug.Log("Items are resetting");
        //}

        public void AddItem(InventoryItem item) {
            if (item == null) return;
            Items.Add(item);
            OnChanged?.Invoke(this);
        }

        public void RemoveItem(InventoryItem item) {
            if (item == null || !Items.Contains(item))
                return;

            Items.Remove(item);
            OnChanged?.Invoke(this);
        }
    }
}