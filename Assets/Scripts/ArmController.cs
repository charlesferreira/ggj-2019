using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

    [SerializeField] Rigidbody2D hand;
    [SerializeField] Vector2 maxDistance;
    [SerializeField] float force;
    [SerializeField] string xAxis;
    [SerializeField] string yAxis;

    float Horizontal { get { return Input.GetAxis (xAxis); } }
    float Vertical { get { return Input.GetAxis (yAxis); } }
    Vector2 ForceDirection { get { return Vector2.right * Horizontal + Vector2.up * Vertical; } }

    private void Update () {
        hand.AddForce (ForceDirection * force * Time.deltaTime);
    }
}