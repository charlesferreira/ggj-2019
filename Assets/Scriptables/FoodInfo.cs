using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "FoodInfo", menuName = "ScriptableObjects/FoodInfo", order = 0)]
public class FoodInfo : ScriptableObject {

    public List<Sprite> sprites;

    public float scale;

}