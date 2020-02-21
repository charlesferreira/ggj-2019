using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Music {
    IntroMusic,
    GameMusic
}
public class StartMusic : MonoBehaviour {
    public Music music;

    private void Start () {

        var musicPlayerGO = GameObject.Find ("MusicPlayer");
        if (musicPlayerGO == null) {
            return;
        }

        var musicPlayer = musicPlayerGO.GetComponent<MusicPlayer> ();

        if (music == Music.GameMusic) {
            musicPlayer.PlayGameMusic ();
        } else {
            musicPlayer.PlayIntroMusic ();
        }
    }
}