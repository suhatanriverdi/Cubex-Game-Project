//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Class For Camera Following
public class CameraFollow : MonoBehaviour
{
	// Will be Used for an object to be followed by current camera
    public Transform target;

	// To Smooth Camera Follow Movement
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

	// Update Camera Fixed Player Movements (Locked)
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
