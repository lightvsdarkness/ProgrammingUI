using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryIG {
    public class InventoryButtonUI : MonoBehaviour {

        public Inventory Inventory;
        public HeroInventory Equipment;


        public void Start() {
            if (Inventory == null)
                GetComponent<Inventory>();

        }

        public void DisplayInventoryAndEquipment() {
            DisplayInventory();
            DisplayEquipment();
        }

        public void DisplayInventory() {
            if (Inventory != null)
                Inventory.SwitchDisplay();
        }

        public void DisplayEquipment() {
            if (Equipment != null)
                Equipment.SwitchDisplay();
        }
        public void DisplayCurrentHeroInventory() {
            if (Party.I.CurrentHeroInventory != null)
                Party.I.CurrentHeroInventory.SwitchDisplay();
        }
    }
}