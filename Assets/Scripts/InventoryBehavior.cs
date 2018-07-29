using UnityEngine;
using UnityEngine.UI;

public class InventoryBehavior : MonoBehaviour {
    public const int numItems = 10;
    public Item[] items = new Item[numItems];

    protected Image firstItemImage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AddItem(Item item) {
        for (int i = 0; i < numItems; i++) {
            if (items[i] == null) {
                items[i] = item;


                Transform itemSlotTransform = gameObject.transform.GetChild(i);
                Image itemImage = itemSlotTransform.GetChild(0).GetComponent<Image>();
                print("Sprites/" + item.itemKey);
                itemImage.sprite = Resources.Load<Sprite>("Sprites/" + item.itemKey);

                return true;
            }
        }

        return false;
    }
}
