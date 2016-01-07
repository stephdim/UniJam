using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float lifeLeft;
    float lifeMax;

    [SerializeField]
    Slider lifeSlider;

    Character scriptCharacter;
    public static event Action<int> OnDeath;
    float cooldown;
    // Use this for initialization
    void Start () {

        scriptCharacter = GetComponent<Character>();

        this.lifeMax = scriptCharacter.lifeMax;
        lifeLeft = lifeMax;
        cooldown = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        lifeSlider.value = lifeLeft / lifeMax;
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damage) {
        if (cooldown <= 0) {
            if (lifeLeft - damage <= 0) {
                if (OnDeath != null) {
                    OnDeath(scriptCharacter.id);
                }

                //player dead

            } else {
                lifeLeft = lifeLeft - damage;
            }
            cooldown = 0.5f;
        }
    }


}
