using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotation : MonoBehaviour {

    public Transform food;
    public Transform leftJoint;
    public Transform rightJoint;

    Vector3 left { get { return leftJoint.position; } }
    Vector3 right { get { return rightJoint.position; } }

    private void LateUpdate () {
        food.position = (left + right) / 2f;
        food.right = (right - left).normalized;
    }
}