using UnityEngine;
using System.Collections;

public class ChangeMachineStateValueStomp : MonoBehaviour {

    private Animator m_Anim;

    // Use this for initialization
    void Start () {

        m_Anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            m_Anim.SetInteger("stompState",0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            m_Anim.SetInteger("stompState", -1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            m_Anim.SetInteger("stompState", 1);

        }

    }
}
