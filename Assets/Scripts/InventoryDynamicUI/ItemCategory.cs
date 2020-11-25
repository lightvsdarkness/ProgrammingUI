using UnityEngine;
using System;
using System.Collections.Generic;

namespace InventoryIG {

    [System.Serializable]
    public partial class ItemCategory : ScriptableObject
    {
        public uint ID;

        public new string CategoryName;
        public Sprite Icon;
    }
}