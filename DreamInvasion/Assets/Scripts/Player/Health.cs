using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float lifeLeft;
    float lifeMax;

    Character scriptCharacter;

    // Use this for initialization
    void Start () {

        scriptCharacter = GetComponent<Character>();

        this.lifeMax = scriptCharacter.lifeMax;
        lifeLeft = lifeMax;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDamage(float damage) {

        if(lifeLeft-damage <= 0) {
            lifeLeft = 0;

            //player dead

        } else {
            lifeLeft = lifeLeft - damage;
        }
    }


}
