using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 5f;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        Invoke("LoadLevel", levelLoadDelay);
    }

    void Update() {

    }

    private void LoadLevel() {
        SceneManager.LoadScene(1);
    }
}
