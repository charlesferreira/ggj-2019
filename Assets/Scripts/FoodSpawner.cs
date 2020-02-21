using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    ScoreManager scoreManager;
    public List<GameObject> foods;
    public List<Transform> spawnPoints;
    public List<int> pendings;
    public List<float> timers = new List<float> ();
    public List<Transform> activeFoods = new List<Transform> ();

    private void Awake () {
        scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
    }
    private void Start () {
        pendings.Add (0);
        pendings.Add (1);
        timers.Add (0f);
        timers.Add (0f);
    }

    private void Update () {
        for (int i = 0; i < timers.Count; i++) {
            timers[i] += Time.deltaTime;
            if (timers[i] > 10) {
                AddPending (i);
                Spawn ();
            }
        }
    }

    public void AddPending (int player) {
        pendings.Add (player);
    }

    public void Spawn () {
        foreach (var i in pendings) {
            SpawnFood (spawnPoints[i].position);
            timers[i] = 0;
        }
        pendings.Clear ();
    }

    void SpawnFood (Vector3 position) {
        var model = foods[Random.Range (0, foods.Count)];
        var food = Instantiate (model, position, Quaternion.identity).GetComponentInChildren<Food> ();
        food.foodSpawner = this;
        activeFoods.Add (food.gameObject.transform);
        food.scoreManager = scoreManager;
    }

    public void RemoveActiveFood (Transform transform) {
        activeFoods.Remove (transform);
    }

    public bool GetNearestFood (Vector3 position, out Vector3 nearestPosition) {

        var minDistance = float.MaxValue;

        nearestPosition = Vector3.zero;

        foreach (var food in activeFoods) {
            var sqrDistance = (food.position - position).sqrMagnitude;
            if (sqrDistance < minDistance) {
                nearestPosition = food.position;
                minDistance = sqrDistance;
            }
        }

        return (nearestPosition != Vector3.zero);
    }
}