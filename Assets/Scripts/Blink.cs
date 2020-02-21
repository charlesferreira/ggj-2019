using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public Animator animator;

    void Start () {
        Invoke ("StartBlink", Random.Range (0.5f, 4f));
    }

    void StartBlink () {
        animator.SetTrigger ("Blink");
        Invoke ("StartBlink", Random.Range (0.5f, 4f));
    }
}