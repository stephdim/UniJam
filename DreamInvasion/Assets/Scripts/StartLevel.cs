using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Collider") {
            other.transform.parent.GetComponentInChildren<CreateObject>().isOk = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Collider") {
            other.transform.parent.GetComponentInChildren<CreateObject>().isOk = true;
        }
    }
}
