using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : WorkableItem {
	// Use this for initialization
	void Start () {
        objectKey = "destructable_tree";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void AfterWorked() {
        GameObject logPrefab = Resources.Load<GameObject>("Prefabs/item_log");

        for (int i = 0; i < Random.Range(2, 4); i++) {
            GameObject log = Instantiate(logPrefab);
            log.transform.position = transform.position + Vector3.up * 2;
            log.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        }
    }
}
