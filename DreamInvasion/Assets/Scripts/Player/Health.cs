using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour {

    public float lifeLeft;
    float lifeMax;

    Character scriptCharacter;
    public static event Action<int> OnDeath;

    // Use this for initialization
    void Start () {

        scriptCharacter = GetComponent<Character>();

        this.lifeMax = scriptCharacter.lifeMax;
        lifeLeft = lifeMax;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(float damage) {

        if(lifeLeft-damage <= 0) {
            if (OnDeath != null) {
                OnDeath(scriptCharacter.id);
            }

            //player dead

        } else {
            lifeLeft = lifeLeft - damage;
        }
    }


}
