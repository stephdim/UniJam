using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

    GameObject player;
    [SerializeField]
    private float cooldown;
    private float timer;
    public float yMin = 0;
    float yMax;
    bool isFalling;
    bool isFallen;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = cooldown;
        yMax = 5;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 3) {
            isFalling = true;
        }
        if (isFalling && !isFallen) {
            Fall();
        }

        if (isFallen && timer > 0) {
            timer -= Time.deltaTime;
        } else if (timer <= 0) {
            Replacing();
        }
	}

    void Fall() {
        transform.Translate(10*Vector3.down * Time.deltaTime);
        if (transform.position.y <= yMin) {
            isFalling = false;
            isFallen = true;
        }
    }

    void Replacing() {
        if (transform.position.y < yMax) {
            Debug.Log("Replacing");
            transform.Translate(5*Vector3.up * Time.deltaTime);
        } else {
            isFallen = false;
            timer = cooldown;
        }
    }
}
