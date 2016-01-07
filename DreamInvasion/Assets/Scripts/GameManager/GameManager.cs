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
    public static event Action OnGameOver;


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
                Time.timeScale = 0.0f;
                if (OnGameOver != null) {
                    //levels = new GameObject[nbLevels];
                    OnGameOver();
                }
                return;
            }
            levels[currentlevel].SetActive(true);
        } else {
            if (currentlevel == levels.Length - 1) {
                bosses[currentLoser - 1].SetActive(false);
            }
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
        players = new GameObject[2];
        bosses = new GameObject[2];
        players[0] = GameObject.Find("BlueWarrior");
        players[1] = GameObject.Find("RedWarrior");
        bosses[0] = GameObject.Find("BlueBoss");
        bosses[1] = GameObject.Find("RedBoss");
        cursors = GameObject.FindGameObjectsWithTag("Cursor");
        levels = new GameObject[nbLevels];
        safezones = new GameObject[levels.Length - 1];
        levels[0] = GameObject.Find("Level0");
        
        for (int i = 1; i < nbLevels; ++i) {
            levels[i] = GameObject.Find("Level" + i);
        }
        for (int i = 1; i < nbLevels - 1; ++i) {
            safezones[i - 1] = levels[i].transform.FindChild("Safezone").gameObject;
        }
    }

    void Start() {
        for (int i = 0; i < players.Length; ++i) {
            players[i].GetComponent<Character>().id = i + 1;
            bosses[i].GetComponent<Character>().id = i + 1;
            cursors[i].GetComponent<Stats>().id = i + 1;
            cursors[i].SetActive(false);
        }
        for (int i = 0; i < bosses.Length; ++i) {
            bosses[i].SetActive(false);
            players[i].SetActive(true);
        }
        for (int i = 1; i < nbLevels; ++i) {
            levels[i].SetActive(false);
        }
        levels[0].SetActive(true);
        players[0].transform.position = new Vector2(-1.3f, -2.6f);
        players[1].transform.position = new Vector2(1.3f, -2.6f);
        currentlevel = 0;
        currentLoser = -1;
        Time.timeScale = 1f;
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
            players[0].transform.position = new Vector2(-1.3f, -2.6f);
            players[1].transform.position = new Vector2(1.3f, -2.6f);
        } else {
            if (currentlevel == nbLevels-1) {
                if (1 == currentLoser) {
                    players[1].transform.position = new Vector2(108.3f, 2.25f);
                } else {
                    players[0].transform.position = new Vector2(108.3f, 2.25f);
                }
                bosses[currentLoser - 1].transform.position = new Vector2(108.3f, 6.2f);
                bosses[currentLoser - 1].SetActive(true);
                cursors[currentLoser - 1].SetActive(false);
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

    public void Restart() {
        Start();
        foreach (var boss in bosses) {
            boss.GetComponent<Health>().lifeLeft = boss.GetComponent<Character>().lifeMax;
        }
    }
}
