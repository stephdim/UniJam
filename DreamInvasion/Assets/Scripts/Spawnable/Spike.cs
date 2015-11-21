using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    [SerializeField]
    private float cooldown;
    private float timer;
    private bool isOut;
	// Use this for initialization
	void Start () {
        timer = cooldown;
        isOut = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer >= 0) {
            timer -= Time.deltaTime;
        } else {
            Move();
            timer = cooldown;
        }
	}

    void Move() {
        if (!isOut) {
            transform.position += Vector3.up;
            isOut = true;
        } else {
            transform.position -= Vector3.up;
            isOut = false;
        }
    }
}
