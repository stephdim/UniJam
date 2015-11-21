using UnityEngine;
using System.Collections;

public class LockRot : MonoBehaviour {

    bool test = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.parent.localScale.x < 0 && transform.localScale.x >0 ) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (transform.parent.localScale.x > 0 && transform.localScale.x < 0) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
