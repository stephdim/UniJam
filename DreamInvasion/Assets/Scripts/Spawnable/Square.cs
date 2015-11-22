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
    Animator anim;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = cooldown;
        yMax = 5;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Approximately(transform.position.y, yMax)) {
            anim.SetBool("idle", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
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
        anim.SetBool("down", true);
        anim.SetBool("idle", false);
        anim.SetBool("up", false);
    }

    void Replacing() {
        if (transform.position.y < yMax) {
            anim.SetBool("down", false);
            anim.SetBool("up", true);
            anim.SetBool("idle", false);
            Debug.Log("Replacing");
            transform.Translate(5*Vector3.up * Time.deltaTime);
        } else {
            isFallen = false;
            timer = cooldown;
        }
    }
}
