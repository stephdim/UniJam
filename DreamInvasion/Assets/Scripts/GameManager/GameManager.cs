using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour {

    GameObject[] players;
    GameObject[] levels;
    GameObject[] cursors;
    GameObject[] bosses;
    GameObject[] safezones;

    [SerializeField]
    int nbLevels;
    public int currentlevel;
    int currentLoser;

    // Use this for initialization
    public static event Action OnNewLevel;


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
                return;
            }
            levels[currentlevel].SetActive(true);
        } else {
            currentlevel--;
            if (currentlevel == 0) currentLoser = -1;
            levels[currentlevel].SetActive(true);
        }
        SetPlayers();
        SetCamera();
        if (OnNewLevel != null) {
            OnNewLevel();
        }
        foreach (GameObject player in players) {
            player.GetComponent<Health>().lifeLeft = player.GetComponent<Character>().lifeMax;
        }

    }

    void Awake () {
        players = GameObject.FindGameObjectsWithTag("Player");
        bosses = GameObject.FindGameObjectsWithTag("Bosses");
        cursors = GameObject.FindGameObjectsWithTag("Cursor");
        levels = new GameObject[nbLevels];
        safezones = new GameObject[levels.Length - 1];
        levels[0] = GameObject.Find("Level0");
        for (int i = 0; i < bosses.Length; ++i) {
            bosses[i].SetActive(false);
        }
        for (int i = 1; i < nbLevels; ++i) {
            levels[i] = GameObject.Find("Level"+i);
            levels[i].SetActive(false);
        }
        for (int i = 1; i < nbLevels - 1; ++i) {
            safezones[i - 1] = levels[i].transform.FindChild("Safezone").gameObject;
        }

        currentlevel = 0;
        currentLoser = -1;
    }

    void Start() {
        for (int i = 0; i < players.Length; ++i) {

            Debug.Log(" players[i]");

            players[i].GetComponent<Character>().id = i + 1;

            cursors[i].GetComponent<Stats>().id = i + 1;
            cursors[i].SetActive(false);
            Debug.Log("id : "+(i + 1));
        }
    }
    // Update is called once per frame
    void Update () {
	    
	}

    void SetPlayers() {
        if (currentLoser == -1) {
            for (int i = 0; i < players.Length; ++i) {
                players[i].SetActive(true);
                cursors[i].SetActive(false);
            }
            players[0].transform.position = new Vector2(1.3f, -2.6f);
            players[1].transform.position = new Vector2(-1.3f, -2.6f);
        } else {
            if (currentlevel == nbLevels-1) {
                if (1 == currentLoser) {
                    players[1].transform.position = new Vector2(108.3f, 2.25f);
                } else {
                    players[0].transform.position = new Vector2(108.3f, 2.25f);
                }
                players[currentLoser - 1].transform.position = new Vector2(108.3f, 6.2f);
                players[currentLoser - 1].SetActive(true);
                return;
            }
            for (int i = 0; i < players.Length; ++i) {
                if (i+1 == currentLoser) {
                    players[i].SetActive(false);
                    cursors[i].SetActive(true);
                    cursors[i].transform.position = safezones[currentlevel - 1].transform.position + 2 * Vector3.up;
                } else {
                    players[i].SetActive(true);
                    players[i].transform.position = safezones[currentlevel-1].transform.position;
                    cursors[i].SetActive(false);
                }
            }
        }
    }

    void SetCamera() {
        if (currentlevel != 0 && currentlevel != nbLevels - 1) {
            int winner = currentLoser == 1 ? 2 : 1;
            Camera.main.GetComponent<MyCameraFollow>().m_Player = players[winner-1].transform;
        }
    }
}
