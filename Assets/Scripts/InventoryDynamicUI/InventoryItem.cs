using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipSlot { Helmet, Armor, Weapon, Offhand, NotEquppable };
public enum ItemType { Equipment, Medical, Energy, Food, Augmentation, Quest };

public class InventoryItem : MonoBehaviour
{
    public string DisplayName;
    [Multiline]
    public string Description;
    public Sprite Sprite;

    public EquipSlot Slot;
    public ItemType Type;

    //public List<StatChangeScript> StatChangeScripts = new List<StatChangeScript>();

    void Start () {
		
	}
    
	//void Update () {
		
	//}

    /// <summary>
    /// 
    /// </summary>
    public void Consume()
    {
        // TODO: Change Hero Stats
    }
}
