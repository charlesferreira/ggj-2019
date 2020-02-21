using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public float matchDuration;
    public Text timeText;
    float matchTime;
    bool finalCountdown;
    public Animator timeAnimator;
    public GameObject TimesUp;
    public AudioSource timesupSound;
    bool gameOver = false;

    private void Awake () {
        timesupSound = GetComponent<AudioSource> ();
    }
    private void Start () {
        matchTime = matchDuration;
    }

    void Update () {
        if (gameOver) {
            return;
        }
        matchTime -= Time.deltaTime;
        if (matchTime > 0) {
            if (!finalCountdown && matchTime <= 15) {
                ToFinalCountDown ();
            }
            timeText.text = (matchTime + 1).ToSeconds ();
        } else {
            timeText.text = 0f.ToSeconds ();
            TimesUp.SetActive (true);
            Invoke ("GameOver", 1.5f);
            gameOver = true;
        }
    }

    void ToFinalCountDown () {
        timesupSound.Play ();
        finalCountdown = true;
        timeAnimator.SetBool ("Final", true);
    }

    void GameOver () {
        SceneManager.LoadScene ("GameOver");
    }
}