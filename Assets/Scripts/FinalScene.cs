using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour {
    public List<Sprite> sprites;
    public Animator presAnim;
    ScoreManager scoreManager;
    Image image;
    bool canBack;

    void Awake () {
        scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
        image = GetComponent<Image> ();
    }
    void Start () {
        var score1 = scoreManager.scores[0];
        var score2 = scoreManager.scores[1];
        if (score1 == 0 && score2 == 0) {
            image.sprite = sprites[0];
        } else if (score1 == score2) {
            image.sprite = sprites[1];
        } else if (score1 > score2) {
            image.sprite = sprites[2];
        } else {
            image.sprite = sprites[3];
        }
        Invoke ("AllowsBack", 3);
    }

    void Update () {
        for (int i = 1; i <= 4; i++) {
            if (Input.GetButtonDown ("Grab" + i)) {
                SceneManager.LoadScene ("Game");
            }
        }
    }

    void AllowsBack () {
        presAnim.SetTrigger ("Show");
        canBack = true;
    }
}