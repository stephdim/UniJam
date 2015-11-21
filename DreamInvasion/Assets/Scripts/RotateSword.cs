using UnityEngine;
using System.Collections;

public class RotateSword : MonoBehaviour {

    [SerializeField]
    float cooldown = 0.8f;
    float time;
    bool hit = false;

    [SerializeField]
    float speed = 1.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1")) {
            hit = true;
            time = Time.time;
            RotateDown();
            
            //GetComponentInParent<Animator>().enabled = true;
        }
        if(time + cooldown < Time.time && hit) {
            hit = false;
            RotateUp();
            //GetComponentInParent<Animator>().enabled = false;
        }        
	}

    public void RotateDown() {

        transform.Rotate(new Vector3(0, 0, -60));

    }

    public void RotateUp() {

        transform.Rotate(new Vector3(0, 0, 60));

    }
}
