using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 5f;

    void Start() {
        Invoke("LoadLevel", levelLoadDelay);
    }

    void Update() {

    }

    private void LoadLevel() {
        SceneManager.LoadScene(1);
    }
}
