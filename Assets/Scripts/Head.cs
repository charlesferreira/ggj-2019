using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    public Animator animator;
    public float startDelayAnimation;

    void Start () {
        Invoke ("StartAnimation", startDelayAnimation);
    }

    void StartAnimation () {
        animator.SetTrigger ("Head");
    }
}