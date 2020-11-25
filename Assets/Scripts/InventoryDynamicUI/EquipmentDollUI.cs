using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace InventoryIG {
    public class EquipmentDollUI : MonoBehaviour {
        public HeroInventory HeroInventory;

        public InventoryItemDisplay Helmet, Armor, Weapon, Offhand;

        public bool Debugging;

        private void Start() {
            // If UI is active already - 
            HeroInventory = HeroInventory.GetActive();
            if (HeroInventory != null)
                Construct(HeroInventory);

            InventoryItemDisplay.OnClick += HandleOnClick;
            HeroInventory.OnHeroEquipmentChanged += HandleOnHeroEquipmentChanged;
        }

        private void OnDestroy() {
            InventoryItemDisplay.OnClick -= HandleOnClick;
            HeroInventory.OnHeroEquipmentChanged -= HandleOnHeroEquipmentChanged;
        }

        public void Hide() {
            gameObject.SetActive(false);
        }


        private void HandleOnClick(InventoryItem item) {
            if (HeroInventory.IsEquipped(item)) {
                HeroInventory.Unequip(item);
                if (Debugging)
                    Debug.Log(
                        "Used InventoryItemDisplay on Equipment Screen. Hero Unequiping it, so removing it from UI");
                Party.I.PartyInventory.AddItem(item);
                return;
            }
            if (HeroInventory.ConsumeItem(item))
                Party.I.PartyInventory.RemoveItem(item);
            if (HeroInventory.Equip(item))
                Party.I.PartyInventory.RemoveItem(item);
        }

        private void HandleOnHeroEquipmentChanged(HeroInventory heroInventory) {
            if (HeroInventory == heroInventory)
                if (Debugging)
                    Debug.Log("Hero changed, Equipment Screen is updating");
            Construct(heroInventory);
        }

        public void Construct(HeroInventory heroInventory) {
            HeroInventory = heroInventory;
            gameObject.SetActive(true);

            if (Helmet != null) {
                Helmet.Construct(heroInventory.Helmet);
            }
            if (Armor != null) {
                Armor.Construct(heroInventory.Armor);
            }
            if (Weapon != null) {
                Weapon.Construct(heroInventory.Weapon);
            }
            if (Offhand != null) {
                Offhand.Construct(heroInventory.Offhand);
            }
        }
    }
}