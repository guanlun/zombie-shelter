using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour {
    public bool isSelected;
    NavMeshAgent agent;

    public InventoryBehavior inventoryBehavior;

    protected Item heldItem;
    protected Item pickUpTarget;

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
            if (inventoryBehavior.AddItem(pickUpTarget.itemKey)) {
                Destroy(pickUpTarget.gameObject);
                pickUpTarget = null;
            }
        }
    }

}
