using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWristMovement : MonoBehaviour {

    public float force;

    Vector3 target;
    Rigidbody2D rb;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate () {
        target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        target.z = transform.position.z;
        rb.AddForce ((target - transform.position) * force * Time.fixedDeltaTime);
    }
}