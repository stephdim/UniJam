using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {


    GameObject viseur;

	// Use this for initialization
	void Start () {
        viseur = transform.FindChild("viseur").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal2");
        float dy = Input.GetAxis("Vertical2");

        if (Mathf.Abs(dx) >= 0.1f) {
            transform.position += 0.5f * dx * Vector3.right;
        }
        if (Mathf.Abs(dy) >= 0.1f) {
            viseur.transform.position += 0.5f * dy * Vector3.up;
        }
	}
}
