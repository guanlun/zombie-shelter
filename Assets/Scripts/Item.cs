using UnityEngine;

public class Item : MonoBehaviour {
    public string itemKey;
    
    void Start() {
        itemKey = "item_" + this.gameObject.name.ToLower();
    }
}
