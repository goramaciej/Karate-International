using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField] private Transform LookAt;
    [SerializeField] private float boundX = 2.0f;
    [SerializeField] private float boundY = 1.5f;
    [SerializeField] private float boundZ = 1f;
    [SerializeField] private float distanceZ = -5f;
    [SerializeField] [Range(0, 1)] private float speed = 0.15f;

    private Vector3 desiredPosition;

    private void LateUpdate() {
        Vector3 delta = Vector3.zero;

        float dx = LookAt.position.x - transform.position.x;

        if (dx > boundX || dx < -boundX) {
            if (transform.position.x < LookAt.position.x) {
                delta.x = dx - boundX;
            } else {
                delta.x = dx + boundX;
            }
        }

        float dy = LookAt.position.y - transform.position.y;

        if (dy > boundY || dy < -boundY) {
            if (transform.position.y < LookAt.position.y) {
                delta.y = dy - boundY;
            } else {
                delta.y = dy + boundY;
            }
        }

        float dz = LookAt.position.z - transform.position.z;

        if (dz > boundZ || dz < -boundZ) {
            if (transform.position.z < LookAt.position.z) {
                delta.z = dz - boundZ + distanceZ;
            } else {
                delta.z = dz + boundZ + distanceZ;
            }
        }


        desiredPosition = transform.position + delta;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
    }
}
