using UnityEngine;
using System.Collections;

public class StartBarrelExplosionAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.X)) {
            GetComponent<Animator>().enabled = true;
        }
	}
}
