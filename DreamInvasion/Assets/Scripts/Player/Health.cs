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

    // Use this for initialization
    void Start () {

        scriptCharacter = GetComponent<Character>();

        this.lifeMax = scriptCharacter.lifeMax;
        lifeLeft = lifeMax;

        lifeSlider.value = lifeLeft / lifeMax;

    }
	
	// Update is called once per frame
	void Update () {

        lifeSlider.value = lifeLeft / lifeMax;
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
