using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour {

    
    int[] currentObjs; // 0 : current, 1 : next
    DetectPlateform detectPlateform;
    GameObject pool;
    public bool isOk;
    [SerializeField]
    float cooldown;
    float timer;
    void Start() {
        currentObjs = new int[2];
        pool = GameObject.FindGameObjectWithTag("Pool");
        for (int i = 0; i < currentObjs.Length; ++i) {
            currentObjs[i] = Random.Range(1, 101);
        }
        detectPlateform = transform.parent.GetComponentInChildren<DetectPlateform>();
        isOk = true;
        timer = cooldown;
	}
	
	void Update() {
	    if (Input.GetButtonDown("Fire" + transform.parent.GetComponentInChildren<Stats>().id) && isOk) {
            Create();
        }
	}

    void Create() {
        if (currentObjs[0] <= 25) {
            float y = -10;
            for (int i = 0; i < detectPlateform.Plateforms.Count; ++i) {
                if (detectPlateform.Plateforms[i].transform.position.y <= transform.position.y && detectPlateform.Plateforms[i].transform.position.y > y) {
                    y = detectPlateform.Plateforms[i].transform.position.y;
                }
            }
            if (y == -10) return;
            GameObject go = Instantiate(Resources.Load("Prefabs/Square"), transform.position, Quaternion.identity) as GameObject;
            go.transform.SetParent(pool.transform);
            go.GetComponent<Square>().yMin = y;
        } else if (currentObjs[0] <= 50) {
            float y = -10;
            for (int i = 0; i < detectPlateform.Plateforms.Count; ++i) {
                if (detectPlateform.Plateforms[i].transform.position.y <= transform.position.y && detectPlateform.Plateforms[i].transform.position.y > y) {
                    y = detectPlateform.Plateforms[i].transform.position.y;
                }
            }
            if (y == -10) return;
            GameObject go = Instantiate(Resources.Load("Prefabs/Spike"), new Vector2(transform.position.x, y), Quaternion.identity) as GameObject;
            go.transform.SetParent(pool.transform);
        } else {
            Debug.Log(currentObjs[0]);
        }
        currentObjs[0] = currentObjs[1];
        currentObjs[1] = Random.Range(1, 101);
    }
}
