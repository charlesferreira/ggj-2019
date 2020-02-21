using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {

    public ScoreDisplay[] scoreDisplay;
    public Dog[] animals;

    public void AddScore (int player, int score, FoodInfo info) {
        scoreDisplay[player].AddScore (info);
        if (Random.Range (0, 3) == 0) {
            animals[player].Show ();
        }
    }
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}