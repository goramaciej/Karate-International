using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("wall collission");
    }
}
