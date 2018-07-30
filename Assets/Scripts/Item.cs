using UnityEngine;

public class Item : MonoBehaviour {
    public string itemKey;

    public virtual bool ApplyOnItem(WorkableItem item) {
        return false;
    }
}
