using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public AudioSource introMusic;
    public AudioSource gameMusic;

    private void Awake () {
        DontDestroyOnLoad (gameObject);
    }

    public void PlayIntroMusic () {
        gameMusic.Stop ();
        introMusic.loop = true;
        introMusic.Play ();
    }

    public void PlayGameMusic () {
        introMusic.Stop ();
        gameMusic.loop = true;
        gameMusic.Play ();
    }
}