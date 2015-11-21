using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    [SerializeField]
    int damage = 1;
    [SerializeField]
    int attack_speed = 1;
    [SerializeField]
    string enemy;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float distance = 1;

    float timeOfLastAttack;
    [SerializeField]
    float cooldownBetweenAttacks = 0.1f;

    RotateOnKeyPressed scriptRotation;

    Vector3 origin;


    bool attacked;

    // Use this for initialization
    void Start () {
        scriptRotation = this.gameObject.GetComponentInParent<RotateOnKeyPressed>();
        enemy = "Test_attack";
        attacked = false;
        origin = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.W) && !attacked) {
            
            this.GetComponent<BoxCollider2D>().enabled = true;

            scriptRotation.RotateDown();

            //parent.Rotate((new Vector3(0, 0, -60.0f)));

            //this.transform.Rotate((new Vector3(0,0,1)), 60.0f);

            //this.transform.Rotate(new Vector3(0, -90 * Time.deltaTime * speed, 0));

            //this.transform.Translate(new Vector3(Mathf.PingPong(Time.time,speed),0,0));

            //transform.position = origin + (transform.forward * (Mathf.PingPong(Time.time * distance * speed + (distance * speed / 2), distance * 2) - distance));

            // this.transform.Translate(new Vector3(speed * Time.deltaTime ,0 ,0 ));

            this.timeOfLastAttack = Time.time;
            attacked = true;
        }

        if(attacked && Time.time > timeOfLastAttack + cooldownBetweenAttacks) {

            this.GetComponent<BoxCollider2D>().enabled = false;
            attacked = false;

            scriptRotation.RotateUp();

            //scriptRotation.Rotate(new Vector3(0, 60.0f, 0), Space.World);

            //this.transform.Rotate(new Vector3(0, 90 * Time.deltaTime * speed, 0));
            //this.transform.Translate(new Vector3(Mathf.PingPong(Time.time, -speed), 0, 0));
            //this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
	
	}


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
