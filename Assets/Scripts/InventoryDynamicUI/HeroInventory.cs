using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryIG {
    public interface ICharacterInventory {
        bool Equip(InventoryItem item);
    }

    public class HeroInventory : MonoBehaviour, ICharacterInventory {
        public static HeroInventory CurrentActive;
        [SerializeField] private bool _displayed;

        public EquipmentDollUI EquipmentDollUIInstance;
        public GameObject EquipmentDollUIContainer;
        public EquipmentDollUI EquipmentDollUIPrefab;

        public InventoryItem Helmet, Armor, Weapon, Offhand;

        public delegate void HeroDelegate(HeroInventory heroInventory);

        public static event HeroDelegate OnHeroEquipmentChanged;

        private void Start() {
            if (EquipmentDollUIInstance != null)
                _displayed = EquipmentDollUIInstance.gameObject.activeSelf;
            else
                _displayed = false;
        }


        public void SwitchDisplay() {
            if (EquipmentDollUIInstance == null &&
                (EquipmentDollUIContainer == null || EquipmentDollUIPrefab == null)) return;

            if (!_displayed) {
                if (EquipmentDollUIInstance != null) { }
                else  {
                    EquipmentDollUIInstance =
                        (EquipmentDollUI)Instantiate(EquipmentDollUIPrefab, EquipmentDollUIContainer.transform);
                }
                EquipmentDollUIInstance.Construct(this);
                CurrentActive = this;
                _displayed = true;
            }
            else {
                EquipmentDollUIInstance.Hide();
                //CurrentActive = null;
                _displayed = false;
            }
        }

        public static HeroInventory GetActive() {
            return CurrentActive;
        }

        public bool IsEquipped(InventoryItem item) {
            if (Helmet == item || Armor == item || Weapon == item || Offhand == item)
                return true;
            return false;
        }

        public bool Equip(InventoryItem item) {
            if (item == null) return false;
            if (item.Type != ItemType.Equipment) return false;
            switch (item.Slot) {
                default:
                    Debug.Log("Hero Doesn't know how to equip on slot " + item.Slot);
                    return false;

                case EquipSlot.Helmet:
                    Party.I.PartyInventory.AddItem(Helmet);
                    Helmet = item;
                    break;
                case EquipSlot.Armor:
                    Party.I.PartyInventory.AddItem(Armor);
                    Armor = item;
                    break;
                case EquipSlot.Weapon:
                    Party.I.PartyInventory.AddItem(Weapon);
                    Weapon = item;
                    break;
                case EquipSlot.Offhand:
                    Party.I.PartyInventory.AddItem(Offhand);
                    Offhand = item;
                    break;
            }

            if (OnHeroEquipmentChanged != null) {
                Debug.Log(name + " equipment change, listen up!");
                OnHeroEquipmentChanged.Invoke(this);
            }
            else
                Debug.Log(name + " equipment change, nobody cared");

            return true;
        }

        public void Unequip(InventoryItem item) {
            if (Helmet == item)
                Helmet = null;
            if (Armor == item)
                Armor = null;
            if (Weapon == item)
                Weapon = null;
            if (Offhand == item)
                Offhand = null;

            if (OnHeroEquipmentChanged != null) {
                Debug.Log(name + " equipment unequpped, listen up!");
                OnHeroEquipmentChanged.Invoke(this);
            }
            else
                Debug.Log(name + " equipment unequpped, nobody cared");
        }

        public bool ConsumeItem(InventoryItem item) {
            if (item.Type == ItemType.Medical || item.Type == ItemType.Energy || item.Type == ItemType.Food ||
                item.Type == ItemType.Augmentation) {
                item.Consume();
                return true;
            }
            Debug.Log("Item is not consumable");
            return false;
        }
    }
}