using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraBehavior : MonoBehaviour {
    Camera cam;

    private GameObject selectedCharacter;

    // Use this for initialization
    void Start() {
        cam = GetComponent<Camera>();
        selectedCharacter = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(transform.InverseTransformDirection(Vector3.forward));
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(transform.InverseTransformDirection(Vector3.left));
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(transform.InverseTransformDirection(Vector3.back));
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(transform.InverseTransformDirection(Vector3.right));
        }

        float scrollAmount = Input.GetAxis("Mouse ScrollWheel");

        if (scrollAmount > 0f) {
            transform.Translate(Vector3.forward);
        } else if (scrollAmount < 0f) {
            transform.Translate(Vector3.back);
        }

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

        CharacterBehavior selectedCharacterBehavior = selectedCharacter.GetComponent<CharacterBehavior>();

        if (pickableItem) {
            selectedCharacterBehavior.GoPickUpItem(pickableItem);
        } else if (rootObjHit.isStatic) {
            selectedCharacterBehavior.MoveTo(hit.point);
        }
    }
}
