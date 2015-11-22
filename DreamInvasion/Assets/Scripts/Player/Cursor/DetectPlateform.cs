using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectPlateform : MonoBehaviour {

    public List<GameObject> Plateforms { get; private set; }

	void Start() {
        Plateforms = new List<GameObject>();
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Plateform")) {
            Plateforms.Add(other.transform.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Plateform")) {
            Plateforms.Remove(other.transform.gameObject);
        }
    }
}
