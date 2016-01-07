using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    GameObject gameOverCam;

	void Awake () {
        canvas.SetActive(false);
        gameOverCam.SetActive(false);
    }

    void OnEnable() {
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnGameOver() {
        canvas.SetActive(true);
        gameOverCam.SetActive(true);
    }

    public void Restart () {
        //Application.LoadLevel(Application.loadedLevel);
        canvas.SetActive(false);
        gameOverCam.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().Restart();
        GameObject.Find("Audio Source").GetComponent<Audio>().Restart();
    }

    public void Exit() {
        Application.Quit();
    }
}
