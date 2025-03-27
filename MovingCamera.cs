using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    private Vector3 cameraDistance;
    public Transform target;
    public float smoothTime;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        cameraDistance = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + cameraDistance;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }

}
