using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour {
    public bool isSelected;
    NavMeshAgent agent;

    public InventoryBehavior inventoryBehavior;

    protected Item pickUpTarget;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        inventoryBehavior = GameObject.Find("InventoryDisplay").GetComponent<InventoryBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
		if (pickUpTarget) {
            TryPickUpTargetItem();
        }
	}

    void SetSelected() {
        this.isSelected = true;
    }

    public void MoveTo(Vector3 destination) {
        agent.SetDestination(destination);
    }

    public void GoPickUpItem(Item item) {
        pickUpTarget = item;

        agent.SetDestination(item.transform.position);

        TryPickUpTargetItem();
    }

    protected void TryPickUpTargetItem() {
        if (!pickUpTarget) {
            return;
        }

        if ((pickUpTarget.transform.position - transform.position).magnitude < 2) {
            if (inventoryBehavior.AddItem(pickUpTarget)) {
                Destroy(pickUpTarget.gameObject);
                pickUpTarget = null;
            }
        }
    }
}
