using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

    [SerializeField]
    Camera level1;
    [SerializeField]
    Camera level2;
    [SerializeField]
    Camera level3;
    [SerializeField]
    GameManager manager;
    AudioSource audioclip;
    public AudioClip theme;
    public AudioClip otherclip;
    int currentLevel = 0;
	// Use this for initialization
	void Start () {
        transform.position = level1.transform.position;
        audioclip = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
        if (!audioclip.isPlaying) {
            audioclip.Play();
        }
        if (manager.currentlevel != currentLevel) {
            if (manager.currentlevel == 0) {
                transform.position = level1.transform.position;
            } else if (manager.currentlevel == 1) {
                transform.position = level2.transform.position;
                if (currentLevel == 2) {
                    if (audioclip.isPlaying) {
                        audioclip.Stop();
                    }
                    audioclip.clip = theme;
                    audioclip.Play();
                }
            } else if (manager.currentlevel == 2) {
                transform.position = level3.transform.position;
                if (audioclip.isPlaying) {
                    audioclip.Stop();
                }
                audioclip.clip = otherclip;
                audioclip.Play();
            }
            currentLevel = manager.currentlevel;
        }
    }

    public void Restart() {
        audioclip.Stop();
        audioclip.clip = theme;
    }
}
