using UnityEngine;
using UnityEngine.UI;

public class InventoryBehavior : MonoBehaviour {
    public const int NUM_ITEMS = 10;
    public string[] storedItemKeys = new string[NUM_ITEMS];

	// Use this for initialization
	void Start () {
        VerticalLayoutGroup itemButtonContainer = gameObject.GetComponent<VerticalLayoutGroup>();
        Button itemSlotImageResource = Resources.Load<Button>("UI/ItemSlotButton");

        for (int i = 0; i < NUM_ITEMS; i++) {
            Button itemSlot = Instantiate(itemSlotImageResource) as Button;
            itemSlot.transform.SetParent(itemButtonContainer.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
    }

    public bool AddItem(string itemKey) {
        for (int i = 0; i < NUM_ITEMS; i++) {
            if (storedItemKeys[i] == null) {
                storedItemKeys[i] = itemKey;

                Transform itemSlotTransform = gameObject.transform.GetChild(i);
                Image itemImage = itemSlotTransform.GetChild(0).GetComponent<Image>();
                itemImage.sprite = Resources.Load<Sprite>("Sprites/" + itemKey);

                return true;
            }
        }

        return false;
    }
}
