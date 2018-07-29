using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraBehavior : MonoBehaviour {
    Camera cam;

    private GameObject selectedCharacter;

    // Use this for initialization
    void Start() {
        this.cam = GetComponent<Camera>();
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
                Transform objectHit = hit.transform;
                GameObject rootObjHit = objectHit.root.gameObject;

                if (leftMouseButtonUp) {
                    if (rootObjHit.name.IndexOf("Character") != -1) {
                        this.selectedCharacter = rootObjHit;
                    }
                } else if (rightMouseButtonUp) {
                    Item pickableItem = rootObjHit.GetComponent<Item>();

                    if (pickableItem) {
                        this.selectedCharacter.SendMessage("PickUpItem", pickableItem);
                    } else if (rootObjHit.isStatic) {
                        this.selectedCharacter.SendMessage("MoveTo", hit.point);
                    }
                }
            }
        }
    }

}
