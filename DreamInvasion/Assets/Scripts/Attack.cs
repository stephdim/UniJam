using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    [SerializeField]
    int damage;
    [SerializeField]
    int attack_speed;
    [SerializeField]
    float speed;
    [SerializeField]
    float distance;

    [SerializeField]
    public Animator m_Anim;


    float timeOfLastAttack;
    [SerializeField]
    float cooldownBetweenAttacks = 0.1f;

    RotateOnKeyPressed scriptRotation;

    Vector3 origin;
    Character player;

    bool attacked;

    // Use this for initialization
    void Start () {
        scriptRotation = this.gameObject.GetComponentInParent<RotateOnKeyPressed>();
        attacked = false;
        origin = this.transform.position;
        player = GetComponentInParent<Character>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Fire" + player.id) && !attacked) {

            m_Anim.SetBool("attack", true);
            m_Anim.SetBool("move", false);
            m_Anim.SetBool("idle", false);
            m_Anim.SetBool("jump", false);

            this.GetComponent<BoxCollider2D>().enabled = true;

            scriptRotation.RotateDown();

            this.timeOfLastAttack = Time.time;
            attacked = true;
        }

        if(attacked && Time.time > timeOfLastAttack + cooldownBetweenAttacks) {

            m_Anim.SetBool("attack", false);
            m_Anim.SetBool("move", false);
            m_Anim.SetBool("idle", true);
            m_Anim.SetBool("jump", false);

            this.GetComponent<BoxCollider2D>().enabled = false;
            attacked = false;

            scriptRotation.RotateUp();
        }
	
	}


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            Debug.Log(transform.parent.parent.name);
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
