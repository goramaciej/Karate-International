using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Head collision 2d: " + collision.gameObject.name);
    }
}
