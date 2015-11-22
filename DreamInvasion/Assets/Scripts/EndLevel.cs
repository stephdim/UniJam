using UnityEngine;
using System.Collections;
using System;

public class EndLevel : MonoBehaviour {

    public static event Action OnLevelFinished;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (OnLevelFinished != null) {
                OnLevelFinished();
            }
        }
    }
}
