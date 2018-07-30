using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    protected Camera cam;

    protected GameObject selectedCharacter;

    // Use this for initialization
    void Start() {
        cam = GetComponent<Camera>();
        selectedCharacter = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update() {
        transform.position = (selectedCharacter.transform.position + new Vector3(-3, 5, -3));

        bool leftMouseButtonUp = Input.GetMouseButtonUp(0);
        bool rightMouseButtonUp = Input.GetMouseButtonUp(1);

        if (leftMouseButtonUp || rightMouseButtonUp) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (leftMouseButtonUp) {
                    // TODO: left mouse button behavior here
                } else if (rightMouseButtonUp) {
                    handleCharacterInteraction(hit);
                }
            }
        }
    }

    protected void handleCharacterInteraction(RaycastHit hit) {
        GameObject rootObjHit = hit.transform.root.gameObject;
        Item pickableItem = rootObjHit.GetComponent<Item>();
        WorkableItem workableItem = rootObjHit.GetComponent<WorkableItem>();

        CharacterBehavior selectedCharacterBehavior = selectedCharacter.GetComponent<CharacterBehavior>();

        if (pickableItem) {
            selectedCharacterBehavior.GoPickUpItem(pickableItem);
        } else if (workableItem) {
            selectedCharacterBehavior.GoWorkOnItem(workableItem);
        } else if (rootObjHit.isStatic) {
            selectedCharacterBehavior.MoveTo(hit.point);
        }
    }
}
