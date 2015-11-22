using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {

	void OnEnable() {
        GameManager.OnNewLevel += OnNewLevel;
    }

    private void OnNewLevel() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
