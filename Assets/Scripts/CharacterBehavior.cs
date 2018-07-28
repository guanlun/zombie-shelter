using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour {
    public bool isSelected;
    NavMeshAgent agent;

    public Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = new Inventory();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetSelected() {
        this.isSelected = true;
    }

    void MoveTo(Vector3 destination) {
        agent.SetDestination(destination);
    }

    void PickUpItem(Item item) {
        print("picking up item");

        this.inventory.AddItem(item);
    }
}
