using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    Animator animator;

    AudioSource audioSource;
    void Awake () {
        animator = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource> ();
    }

    public void Show () {
        animator.SetTrigger ("Show");
        audioSource.Play ();
    }
}