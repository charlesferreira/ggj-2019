using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContactPoint : MonoBehaviour {

    Rigidbody2D rb;
    HandGrabFood hand;
    FixedJoint2D fixedJoint;

    public float breakForce;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void OnJointBreak2D (Joint2D brokenJoint) {
        Drop ();
    }

    public void AttachTo (HandGrabFood hand) {
        this.hand = hand;
        SetGravity (false);
        CreateFixedJoint ();
    }

    internal void Drop () {
        // if (hand != null)
        //     hand.OnFoodDrop ();
        SetGravity (true);
        Destroy (fixedJoint);
    }

    private void CreateFixedJoint () {
        fixedJoint = gameObject.AddComponent<FixedJoint2D> ();
        fixedJoint.connectedBody = hand.GetComponent<Rigidbody2D> ();
        fixedJoint.breakForce = breakForce;
    }

    private void SetGravity (bool active) {
        rb.gravityScale = active ? 1 : 0;
    }
}