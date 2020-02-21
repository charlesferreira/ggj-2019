using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;

    public int[] scores = new int[] { 0, 0 };

    void Awake () {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    public void AddScore (int player, int score, FoodInfo info) {
        scores[player] += score;
    }

    public void Restart () {
        for (int i = 0; i < scores.Length; i++) {
            scores[i] = 0;
        }
    }
}