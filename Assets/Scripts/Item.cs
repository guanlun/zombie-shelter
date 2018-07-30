using UnityEngine;

public class Item : MonoBehaviour {
    public string itemKey;
    
    void Start() {
        itemKey = this.gameObject.name.ToLower();
    }
}
