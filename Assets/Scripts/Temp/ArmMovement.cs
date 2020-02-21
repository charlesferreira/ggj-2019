using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour {

    public float force;
    public float reverseMultiplier;
    public string axis;

    Rigidbody2D rb;

    float input { get { return Input.GetAxisRaw (axis); } }

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        var multiplier = Mathf.Sign (input) == 1 ? 1 : reverseMultiplier;
        rb.AddForce (Vector2.up * input * force * multiplier);
    }
}