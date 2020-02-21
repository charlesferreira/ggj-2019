using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {
    FoodSpawner foodSpawner;
    public Transform eyeL;
    public Transform eyeR;
    float maxDistance = 0.1f;

    private void Start () {
        foodSpawner = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner> ();
    }

    private void Update () {
        Vector3 nearestPosition = new Vector3 ();
        if (foodSpawner.GetNearestFood (transform.position, out nearestPosition)) {
            var directionL = nearestPosition - eyeL.position;
            var directionR = nearestPosition - eyeR.position;
            directionL = directionL.normalized;
            directionR = directionR.normalized;
            eyeL.localPosition = directionL * maxDistance;
            eyeR.localPosition = directionR * maxDistance;
        } else {
            transform.localPosition = Vector3.zero;
        }
    }
}