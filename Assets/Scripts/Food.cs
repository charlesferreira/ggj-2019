using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public FoodInfo info;
    public ParticleSystem crumbs;
    public ScoreManager scoreManager;
    public float totalEatDuration;
    public float oneHandedDropY;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    float currentEatTime;
    float eatingStepTime;
    int currentSpriteIndex;
    public int player;
    public int foodScore;
    bool eating;
    public bool IsReadyToEat { get; private set; }
    public FoodSpawner foodSpawner;

    private void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        boxCollider = GetComponent<BoxCollider2D> ();
    }
    void Start () {
        eatingStepTime = totalEatDuration / (float) info.sprites.Count;
        Invoke ("EnableToEat", 2);
    }

    void EnableToEat () {
        IsReadyToEat = true;
    }

    internal Joint2D AttachTo (HandGrabFood handGrabFood) {
        var joint = gameObject.AddComponent<DistanceJoint2D> ();
        joint.connectedBody = handGrabFood.GetComponent<Rigidbody2D> ();
        var anchor = handGrabFood.transform.position - transform.position;
        joint.anchor = transform.InverseTransformVector (anchor);
        print (joint.anchor);
        joint.autoConfigureDistance = false;
        joint.distance = 0.005f;
        return joint;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Mouth")) {
            eating = true;
            crumbs.Play ();
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Mouth")) {
            eating = false;
            crumbs.Stop ();
        }
    }

    void Update () {
        if (eating) {
            currentEatTime += Time.deltaTime;
            if (currentEatTime >= eatingStepTime) {
                currentEatTime -= eatingStepTime;
                NextSprite ();
            }
        }

        if (transform.position.y > oneHandedDropY) {
            var joints = GetComponents<DistanceJoint2D> ();
            if (joints.Length == 1) {
                Destroy (joints[0]);
            }
        }
    }

    void NextSprite () {
        currentSpriteIndex += 1;
        if (currentSpriteIndex == 2) {
            var foodPending = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner> ();
            foodPending.AddPending (player);
            GameObject.Find ("Grandma").GetComponent<Animator> ().SetTrigger ("Throw");
        }
        if (currentSpriteIndex >= info.sprites.Count) {
            scoreManager.AddScore (player, foodScore, info);
            GameObject.Find ("Scores").GetComponent<Scores> ().AddScore (player, foodScore, info);
            Destroy (gameObject);
        } else {
            spriteRenderer.sprite = info.sprites[currentSpriteIndex];
        }
    }

    void OnDestroy () {
        foodSpawner.RemoveActiveFood (transform);
        Destroy (transform.root.gameObject);
    }
}