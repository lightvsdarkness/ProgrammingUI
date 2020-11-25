using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemResponder : MonoBehaviour {


	// Use this for initialization
	void Start ()
	{
	    InventoryItemDisplay.OnClick += HandleOnClick;
	}

    void OnDestroy()
    {
        InventoryItemDisplay.OnClick -= HandleOnClick;
    }
    private void HandleOnClick(InventoryItem item)
    {
        //Debug.Log("Reacted on using"+item.DisplayName);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
