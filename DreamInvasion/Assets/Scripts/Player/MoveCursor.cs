using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        if (Mathf.Abs(dx) >= 0.1f) {
            transform.position += 0.5f * dx * Vector3.right;
        }
        if (Mathf.Abs(dy) >= 0.1f) {
            transform.position += 0.5f * dy * Vector3.up;
        }
	}
}
