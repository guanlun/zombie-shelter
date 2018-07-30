using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item {
	// Use this for initialization
	void Start () {
        itemKey = "item_axe";
    }
	
    public override bool ApplyOnItem(WorkableItem item) {
        TreeBehavior tree = item as TreeBehavior;

        if (tree) {
            tree.AfterWorked();
            
            return true;
        }

        return false;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
