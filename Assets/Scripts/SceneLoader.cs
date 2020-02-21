using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    void Update () {
        for (int i = 1; i <= 4; i++) {
            if (Input.GetButtonDown ("Grab" + i)) {
                SceneManager.LoadScene ("Game");
            }
        }
    }
}