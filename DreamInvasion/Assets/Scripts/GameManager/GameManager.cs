using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour {

    GameObject[] players;
    GameObject[] levels;
    GameObject[] cursors;
    GameObject[] safezones;

    [SerializeField]
    int nbLevels;
    int currentlevel;
    int currentLoser;

	// Use this for initialization

    void OnEnable() {
        Health.OnDeath += OnDeath;
        EndLevel.OnLevelFinished += OnLevelFinished;
    }

    private void OnLevelFinished() {
        OnDeath(currentLoser);
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
            if (currentlevel == 0) currentLoser = -1;
            levels[currentlevel].SetActive(true);
        }
        SetPlayers();
        SetCamera();

        foreach (GameObject player in players) {
            player.GetComponent<Health>().lifeLeft = player.GetComponent<Character>().lifeMax;
        }

    }

    void Awake () {
        players = GameObject.FindGameObjectsWithTag("Player");
        cursors = GameObject.FindGameObjectsWithTag("Cursor");
        levels = new GameObject[nbLevels];
        safezones = new GameObject[levels.Length - 1];
        levels[0] = GameObject.Find("Level0");
        for (int i = 1; i < levels.Length; ++i) {
            levels[i] = GameObject.Find("Level"+i);
            safezones[i - 1] = levels[i].transform.FindChild("Safezone").gameObject;
            levels[i].SetActive(false);
        }
        
        currentlevel = 0;
        currentLoser = -1;
    }

    void Start() {
        for (int i = 0; i < players.Length; ++i) {
            players[i].GetComponent<Character>().id = i + 1;
            cursors[i].GetComponent<Stats>().id = i + 1;
            cursors[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
	    
	}

    void SetPlayers() {
        Debug.Log(currentLoser);
        if (currentLoser == -1) {
            for (int i = 0; i < players.Length; ++i) {
                players[i].SetActive(true);
                cursors[i].SetActive(false);
            }
        } else {
            for (int i = 0; i < players.Length; ++i) {
                if (i+1 == currentLoser) {
                    players[i].SetActive(false);
                    cursors[i].SetActive(true);
                } else {
                    players[i].SetActive(true);
                    players[i].transform.position = safezones[i - 1].transform.position;
                    cursors[i].SetActive(false);
                }
            }
        }
    }

    void SetCamera() {
        if (currentlevel != 0) {
            int winner = currentLoser == 1 ? 2 : 1;
            Camera.main.GetComponent<MyCameraFollow>().m_Player = players[winner-1].transform;
        }
    }
}
