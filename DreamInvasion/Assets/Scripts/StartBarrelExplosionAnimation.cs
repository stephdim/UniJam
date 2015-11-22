using UnityEngine;
using System.Collections;

public class StartBarrelExplosionAnimation : MonoBehaviour {
    
    float timer = 0.5f;
    bool isDestroyed;
    GameObject player;
    Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
        isDestroyed = false;
    }

    void Update() {
        if (isDestroyed) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                if (player != null) {
                    player.GetComponent<Health>().TakeDamage(1);
                }
                Destroy(gameObject);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col) {
        anim.enabled = true;
        isDestroyed = true;
        if (col.gameObject.CompareTag("Player")) {
            player = col.gameObject;
        }
    }
}
