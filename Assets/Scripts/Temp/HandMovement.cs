using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    public enum Side { Left, Right }

    public float maxForce;
    public float reverseIntensity;
    public Side side;
    public string axis;

    Rigidbody2D rb;

    float InputValue { get { return Input.GetAxis (axis); } }
    float SideSign { get { return side == Side.Left ? 1 : -1; } }

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        var multiplier = Mathf.Sign (InputValue) == SideSign ? 1 : reverseIntensity;
        var force = Vector2.right * InputValue * maxForce * multiplier;
        rb.AddForce (force);
    }
}