using UnityEngine;
using System.Collections;

public class RotateOnKeyPressed : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void RotateDown() {

        transform.Rotate(new Vector3(0, 0, -60));

    }

    public void RotateUp() {

        transform.Rotate(new Vector3(0, 0, 60));

    }
}
