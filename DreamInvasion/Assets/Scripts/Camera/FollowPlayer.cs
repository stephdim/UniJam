using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        Follow();
    }

    void Follow() {
        float diffX = player.transform.position.x - transform.position.x;
        Debug.Log(diffX);
        if (Mathf.Abs(diffX) > 6) {
            transform.position += player.GetComponent<MyPlatformer2DUserControl>().Speed * Vector3.right;
        }
    }
}
