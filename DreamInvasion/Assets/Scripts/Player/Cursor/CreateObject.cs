using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour {

    
    int[] currentRand; // 0 : current, 1 : next
    GameObject[] currentGos;
  int current;
    DetectPlateform detectPlateform;
    GameObject pool;
    GameObject boss;
    public bool isOk;
    [SerializeField]
    float cooldown;
    float timer;
    bool canPut;
    Fire[] fire;
    Square[] square;
    Collider2D[] collider;

    void Start() {
        currentRand = new int[2];
        currentGos = new GameObject[2];
        collider = new Collider2D[2];
        fire = new Fire[2];
        square = new Square[2];
        pool = GameObject.FindGameObjectWithTag("Pool");
        boss = GameObject.FindGameObjectWithTag("Boss");
        //for (int i = 0; i < currentRand.Length; ++i) {
        //    currentRand[i] = Random.Range(1, 101);
        //}
        currentRand[0] = Random.Range(1, 101);
        Create();
        Create();
        detectPlateform = transform.parent.GetComponentInChildren<DetectPlateform>();
        isOk = true;
        timer = cooldown;
        canPut = true;
        current = 0;
}
	
void Update() {
    if (Input.GetButtonDown("Fire" + transform.parent.GetComponentInChildren<Stats>().id) && isOk && canPut) {
            PlaceObj();
            canPut = false;
        } else if (!canPut) {
            if (timer >= 0) {
                timer -= Time.deltaTime;
            } else {
                canPut = true;
                timer = cooldown;
            }
        }
	}

    void PlaceObj() {
        float y = -10;
        if (fire[(current + 1) % 2] != null) {
            fire[(current + 1) % 2].enabled = true;
        }
        for (int i = 0; i < detectPlateform.Plateforms.Count; ++i) {
            if (detectPlateform.Plateforms[i].transform.position.y <= transform.position.y && detectPlateform.Plateforms[i].transform.position.y > y) {
                y = detectPlateform.Plateforms[i].transform.position.y;
            }
        }
        if (y == -10) return;

        currentGos[(current+1)%2].transform.SetParent(null);
        if (square[(current + 1) % 2] != null) {
            square[(current + 1) % 2].yMin = y;
            square[(current + 1) % 2].enabled = true;
        }
        currentGos[current].transform.position = currentGos[(current + 1) % 2].transform.position;
        if (fire[(current + 1) % 2] != null) {
            currentGos[(current + 1) % 2].transform.position = new Vector2(transform.position.x, y);
        } else {
            currentGos[(current + 1) % 2].transform.position = transform.position;
        }
        currentGos[(current + 1) % 2].transform.SetParent(pool.transform);
        currentGos[(current + 1) % 2] = currentGos[current];
        Create();
    }

    void Create() {
        Vector3 pos;
        if (current == 0) {
            pos = new Vector2(.15f, .5f);
        } else {
            pos = new Vector2(1.93f, -.13f);
        }
        if (currentRand[0] <= 50) {
            GameObject go = Instantiate(Resources.Load("Prefabs/Square")) as GameObject;
            go.transform.SetParent(boss.transform);
            go.transform.localPosition = pos;
            go.transform.localScale = .5f * go.transform.localScale;
            currentGos[current] = go;
            square[current] = currentGos[current].GetComponent<Square>();
            square[current].enabled = false;
            collider[current] = currentGos[current].GetComponent<Collider2D>();
            collider[current].enabled = false;
        } else if (currentRand[0] <= 100) {
            GameObject go = Instantiate(Resources.Load("Prefabs/Spike")) as GameObject;
            currentGos[current] = go;
            go.transform.SetParent(boss.transform);
            go.transform.localPosition = pos;
            go.transform.localScale = .5f * go.transform.localScale;
            fire[current] = currentGos[current].GetComponent<Fire>();
            collider[current] = currentGos[current].GetComponent<Collider2D>();
            collider[current].enabled = false;
            fire[current].enabled = false;
        } else {
            Debug.Log(currentRand[0]);
        }
        currentRand[0] = currentRand[1];
        currentRand[1] = Random.Range(1, 101);
        current = (current + 1) % 2;

    }
}
