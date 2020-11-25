using System;
using UnityEngine;
using System.Collections;

namespace InventoryIG
{
    [System.Serializable]
    public partial class ItemRarity : ScriptableObject
    {
        public uint ID;

        public new string name;
        public Color color = Color.white;

        [Tooltip("The item that is used when dropping something, leave null to use the object model itself.")]
        public GameObject dropObject;
    }
}