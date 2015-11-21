using UnityEngine;
using System.Collections;

public enum Classe {
    Tank,
    Guerrier,
    Voleur,
    BossTank,
    BossGuerrier,
    BossVoleur
}

public class Character : MonoBehaviour {

    [SerializeField]
    public float lifeMax;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float strenght;
    [SerializeField]
    public Classe classe;
    public int id;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
