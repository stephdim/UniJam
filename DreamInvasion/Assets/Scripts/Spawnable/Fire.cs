using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {


    Animator anim;
    [SerializeField]
    float damage;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.CompareTag("Player")) {
            Debug.Log("hit" + "Player");

            other.gameObject.GetComponent<Health>().TakeDamage(this.damage);
        }
    }
}
