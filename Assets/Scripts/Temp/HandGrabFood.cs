using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabFood : MonoBehaviour {

    [SerializeField] string button;
    [SerializeField] SpriteRenderer open;
    [SerializeField] SpriteRenderer closed;

    Rigidbody2D rb;
    Food food;
    Joint2D joint;

    bool buttonPressed { get { return Input.GetButtonDown (button); } }
    bool buttonReleased { get { return Input.GetButtonUp (button); } }

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void OnTriggerStay2D (Collider2D other) {
        food = other.GetComponent<Food> ();
    }

    private void OnTriggerExit2D (Collider2D other) {
        food = null;
    }

    private void Update () {
        if (buttonPressed)
            Grab (food);
        if (buttonReleased) {
            Release (food);
        }
    }

    void Grab (Food food) {
        if (food) {
            joint = food.AttachTo (this);
            SetHandSprite (closed);
        }
    }

    void Release (Food food) {
        SetHandSprite (open);
        if (joint) Destroy (joint);
        food = null;
    }

    void SetHandSprite (SpriteRenderer active) {
        open.enabled = open == active;
        closed.enabled = closed == active;
    }
}