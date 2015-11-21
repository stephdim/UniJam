using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    GameObject[] players;
	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; ++i) {
            players[i].GetComponent<MyPlatformer2DUserControl>().id = i + 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
