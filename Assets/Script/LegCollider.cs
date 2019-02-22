using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("has collision");
    }
}
