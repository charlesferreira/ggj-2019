using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour {
    public FoodSpawner foodSpawner;

    public void Spawn () {
        foodSpawner.Spawn ();
    }
}