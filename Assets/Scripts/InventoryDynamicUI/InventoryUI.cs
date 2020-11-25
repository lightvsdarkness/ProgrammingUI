using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryIG {
    public class InventoryUI : MonoBehaviour {
    public InventoryItemDisplay ItemDisplayPrefab;

    public Transform TargetTransform;

    public Inventory Inventory;

    public bool Constructed;


    private void Start () {
        //if (!Constructed && ItemDisplayPrefab != null)
        //    Construct(ItemDisplayPrefab);
        //Constructed = true;
	    Inventory.OnChanged += HandleOnChanged;
	}

    private void OnDestroy() {
        Inventory.OnChanged -= HandleOnChanged;
    }


    private void HandleOnChanged(Inventory inventory) {
        if (Inventory == inventory)
            Construct(inventory);
    }


    public void Construct(Inventory inventory) {
        Inventory = inventory;
        List<InventoryItem> items = inventory.Items;

        Clear();

        foreach (var item in items)
        {
            InventoryItemDisplay display = Instantiate(ItemDisplayPrefab);
            display.transform.SetParent(TargetTransform, false);
            display.Construct(item);
        }
        Constructed = true;
    }

    private void Clear() {
        for (int i = 0; i < TargetTransform.childCount; i++)
        {
            Destroy(TargetTransform.GetChild(i).gameObject);
        }
    }
}
}