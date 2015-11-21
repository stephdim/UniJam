using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour {


    Dictionary<ObjectType, Queue<Spawnable>> availableObj;
    int[] currentObjs; // 0 : current, 1 : next

    void Start() {
        currentObjs = new int[2];
        for (int i = 0; i < currentObjs.Length; ++i) {
            currentObjs[i] = Random.Range(1, 101);
        }
	}
	
	void Update() {
	    if (Input.GetButtonDown("Fire1")) {
            Create();
        }
	}

    void Create() {
        if (currentObjs[0] <= 25) {
            GameObject go = Instantiate(Resources.Load("Prefabs/Square"), transform.position, Quaternion.identity) as GameObject;
        } else {
            Debug.Log(currentObjs[0]);
        }
        currentObjs[0] = currentObjs[1];
        currentObjs[1] = Random.Range(1, 101);
    }
}
