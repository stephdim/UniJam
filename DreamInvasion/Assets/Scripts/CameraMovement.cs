//using UnityEngine;
//using System.Collections;
//using UnityStandardAssets._2D;

//public class CameraMovement : MonoBehaviour {

//    GameObject player;
//	// Use this for initialization
//	void Start () {
//        player = GameObject.FindGameObjectWithTag("Player");
//	}
	
//	// Update is called once per frame
//	void Update () {
//        FollowPlayer();
//	}

//    void FollowPlayer() {
//        float diffX = player.transform.position.x - transform.position.x;
//        if (Mathf.Abs(diffX) > 6) {
//            //transform.position += player.GetComponent<PlatformerCharacter2D>().*Vector3.right * Mathf.Sign(diffX);
//        }
//    }
//}
