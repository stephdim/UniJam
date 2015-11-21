using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    GameObject[] players;
    GameObject[] levels;
    [SerializeField]
    int nbLevels;
    int currentlevel;
    int currentLoser;

	// Use this for initialization

    void OnEnable() {
        Health.OnDeath += OnDeath;
    }

    private void OnDeath(int id) {
        levels[currentlevel].SetActive(false);
        if (currentlevel == 0) {
            currentlevel = 1;
            levels[currentlevel].SetActive(true);
            currentLoser = id;
        } else if (id == currentLoser) {
            currentlevel++;
            if (currentlevel >= levels.Length) {
                currentlevel = 0;
                Time.timeScale = 0f;
                Debug.Log("Game Over");
            }
            levels[currentlevel].SetActive(true);
        } else {
            currentlevel--;
            levels[currentlevel].SetActive(true);
        }
    }

    void Awake () {
        players = GameObject.FindGameObjectsWithTag("Player");
        levels = new GameObject[nbLevels];
        levels[0] = GameObject.Find("Level0");
        for (int i = 1; i < levels.Length; ++i) {
            levels[i] = GameObject.Find("Level"+i);
            levels[i].SetActive(false);
        }
        for (int i = 0; i < players.Length; ++i) {
            players[i].GetComponent<Character>().id = i + 1;
            Debug.Log("id : " + (i + 1));
        }
        currentlevel = 0;
        currentLoser = -1;
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
