using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    int score;
    public GameObject scoreItemModel;
    public FoodInfo info;

    public void AddScore (FoodInfo info) {
        score++;
        var item = Instantiate (scoreItemModel, Vector3.zero, Quaternion.identity, transform).GetComponent<ScoreItem> ();
        item.spriteItem.sprite = info.sprites[0];
        var offset = 1.46f;
        item.transform.localPosition = Vector3.zero;
        item.transform.localPosition += new Vector3 (0, offset * score - offset * 0.5f, 0);
        transform.localPosition += Vector3.down * offset;
    }

    // void Update () {
    //     if (Input.GetKeyDown (KeyCode.P)) {
    //         AddScore (info);
    //     }
    // }
}