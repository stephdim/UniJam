using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour {

    Vector2 posCurrent;
    Vector2 posNext;
    int nbObjs;
    public bool isOk;
    bool canPut;
    GameObject[] objs;
    DetectPlateform detectPlateform;
    GameObject pool;
    GameObject boss;
    [SerializeField]
    float cooldown;
    float timer;

    void Start() {
        posCurrent = new Vector2(.15f, .5f);
        posNext = new Vector2(1.93f, -.13f);
        nbObjs = 0;
        pool = GameObject.FindGameObjectWithTag("Pool");
        boss = GameObject.FindGameObjectWithTag("Boss");
        detectPlateform = transform.parent.GetComponentInChildren<DetectPlateform>();
        objs = new GameObject[2];
        isOk = true;
        canPut = true;
        timer = cooldown;
    }

    void Update() {
        if (nbObjs < 2) {
            Create();
            nbObjs++;
        }
        if (Input.GetButtonDown("Fire" + transform.parent.GetComponentInChildren<Stats>().id) && isOk && canPut) {
            SetPos();
            nbObjs--;
        } else if (!canPut) {
            if (timer >= 0) {
                timer -= Time.deltaTime;
            } else {
                canPut = true;
                timer = cooldown;
            }
        }
    }

        void Create() {
        int rand = Random.Range(1, 101);
        GameObject go = new GameObject();
        if (rand <= 35) {
            go = Instantiate(Resources.Load("Prefabs/Fire")) as GameObject;
        } else if (rand <= 60) {
            go = Instantiate(Resources.Load("Prefabs/Square")) as GameObject;
        } else if (rand <= 100) {
            go = Instantiate(Resources.Load("Prefabs/TonneauExplosif")) as GameObject;
        }

        go.transform.SetParent(boss.transform);
        go.transform.localScale = .5f * go.transform.localScale;
        if (nbObjs == 0) {
            go.transform.localPosition = posCurrent;
            objs[0] = go;
        } else {
            go.transform.localPosition = posNext;
            objs[1] = go;
        }
        for (int i = 0; i <= nbObjs; ++i) {
            Debug.Log("obj : " + objs[i]);
            objs[i].GetComponent<BoxCollider2D>().enabled = false;
            if (objs[i].GetComponent<Fire>() != null) {
                objs[i].GetComponent<Fire>().enabled = false;
            } else if (objs[i].GetComponent<Square>() != null) {
                objs[i].GetComponent<Square>().enabled = false;
            } else {
                objs[i].GetComponent<Rigidbody2D>().isKinematic = true;
                objs[i].GetComponent<StartBarrelExplosionAnimation>().enabled = false;
            }
        }
    }

    void SetPos() {
        objs[0].transform.SetParent(null);

        float y = -10;

        for (int i = 0; i < detectPlateform.Plateforms.Count; ++i) {
            if (detectPlateform.Plateforms[i].transform.position.y <= transform.position.y && detectPlateform.Plateforms[i].transform.position.y > y) {
                y = detectPlateform.Plateforms[i].transform.position.y;
            }
        }
        if (y == -10) return;

        if (objs[0].GetComponent<Fire>() != null) {
            objs[0].transform.position = new Vector2(transform.position.x, y + 0.33f);
            objs[0].GetComponent<BoxCollider2D>().enabled = true;
            objs[0].GetComponent<Fire>().enabled = true;
        } else if (objs[0].GetComponent<Square>() != null){
            objs[0].transform.position = transform.position;
            objs[0].GetComponent<BoxCollider2D>().enabled = true;
            objs[0].GetComponent<Square>().enabled = true;
            objs[0].GetComponent<Square>().yMin = y + 0.65f;
        } else {
            objs[0].transform.position = new Vector2(transform.position.x, y + 5f);
            objs[0].GetComponent<BoxCollider2D>().enabled = true;
            objs[0].GetComponent<Rigidbody2D>().isKinematic = false;
            objs[0].GetComponent<StartBarrelExplosionAnimation>().enabled = true;
        }
        objs[0].transform.SetParent(pool.transform);
        objs[0] = objs[1];
        objs[0].transform.localPosition = posCurrent;
        objs[1] = null;
    }
}
