using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item {
	// Use this for initialization
	void Start () {
        itemKey = "item_axe";
    }
	
    public override void ApplyOnItem(WorkableItem item) {
        TreeBehavior tree = item as TreeBehavior;

        if (tree) {
            Destroy(tree.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
