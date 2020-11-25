using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;
using InventoryIG;

public class Party : SingletonManager<Party> {

    public Inventory PartyInventory;

    public List<HeroInventory> HeroInventories = new List<HeroInventory>();
    public HeroInventory CurrentHeroInventory;

	private void Awake () {
        base.Awake();
	    DontDestroyOnLoad(gameObject);

        if (PartyInventory == null)
	        PartyInventory = gameObject.GetComponent<Inventory>();
	}

    private void Start() {
        if (CurrentHeroInventory == null) {
            if (HeroInventories.Count > 0)
                CurrentHeroInventory = HeroInventories[0];
            else {
                CurrentHeroInventory = FindObjectOfType<HeroInventory>();
            }
        }
    }

    private void Update () {
		
	}
}