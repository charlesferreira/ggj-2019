using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour {

    public int player;
    public Animator anim;
    bool eating;
    AudioSource eatingSound;

    private void Awake () {
        eatingSound = GetComponent<AudioSource> ();
        eatingSound.loop = true;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Food") {
            var food = other.GetComponent<Food> ();
            if (food.IsReadyToEat) {
                food.player = player;
                eating = true;
                anim.SetBool ("Chewing", true);
                eatingSound.pitch = Random.Range (0.5f, 1.2f);
                eatingSound.Play ();
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Food") {
            eating = false;
            Invoke ("CheckChewing", 0.5f);
        }
    }

    private void CheckChewing () {
        if (!eating) {
            anim.SetBool ("Chewing", false);
            eatingSound.Stop ();
        }
    }
}