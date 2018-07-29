using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    protected Image firstItemImage;

	// Use this for initialization
	void Start () {
        firstItemImage = this.gameObject.transform.Find("ItemSlot0").GetChild(0).GetComponent<Image>();
        firstItemImage.sprite = Resources.Load<Sprite>("Sprites/box");
        print(firstItemImage.sprite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
