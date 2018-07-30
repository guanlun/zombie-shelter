using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour {
    public bool isSelected;
    NavMeshAgent agent;

    public InventoryBehavior inventoryBehavior;

    protected Item heldItem;

    protected Item pickUpTarget;
    protected WorkableItem workTarget;

    protected GameObject rightHand;

    Animator animator;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        inventoryBehavior = GameObject.Find("InventoryDisplay").GetComponent<InventoryBehavior>();
        inventoryBehavior.parentCharacterBehavior = this;

        animator = GetComponent<Animator>();

        rightHand = GameObject.Find("Bip01 R Hand");
    }
	
	// Update is called once per frame
	void Update () {
		if (pickUpTarget) {
            TryPickUpTargetItem();
        } else if (workTarget) {
            TryWorkOnItem();
        }
	}

    void SetSelected() {
        this.isSelected = true;
    }

    public void EquipItem(string itemKey) {
        GameObject itemObject = Instantiate(Resources.Load<GameObject>("Prefabs/" + itemKey));
        itemObject.transform.parent = rightHand.transform;
        itemObject.transform.localPosition = Vector3.zero;
        itemObject.transform.localRotation = Quaternion.identity;

        heldItem = itemObject.GetComponent<Item>();
    }

    public void MoveTo(Vector3 destination) {
        agent.SetDestination(destination);
    }

    public void GoPickUpItem(Item item) {
        pickUpTarget = item;

        agent.SetDestination(item.transform.position);

        TryPickUpTargetItem();
    }
    
    public void GoWorkOnItem(WorkableItem workableItem) {
        workTarget = workableItem;

        agent.SetDestination(workableItem.transform.position);

        TryWorkOnItem();
    }

    protected void TryPickUpTargetItem() {
        if (!pickUpTarget) {
            return;
        }

        if ((pickUpTarget.transform.position - transform.position).magnitude < 2) {
            if (inventoryBehavior.AddItem(pickUpTarget.itemKey)) {
                Destroy(pickUpTarget.gameObject);
                pickUpTarget = null;
            }
        }
    }

    protected void TryWorkOnItem() {
        if (!workTarget) {
            return;
        }

        if ((workTarget.transform.position - transform.position).magnitude < 5) {
            if (heldItem.ApplyOnItem(workTarget)) {
                Destroy(workTarget.gameObject);
                workTarget = null;
            }
        }
    }
}
