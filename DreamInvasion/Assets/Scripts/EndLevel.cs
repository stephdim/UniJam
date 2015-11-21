using UnityEngine;
using System.Collections;
using System;

public class EndLevel : MonoBehaviour {

    public static event Action OnLevelFinished;

    void OnTriggerEnter2D() {
        if (OnLevelFinished != null) {
            OnLevelFinished();
        }
    }
}
