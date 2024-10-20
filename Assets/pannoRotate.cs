using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pannoRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around its Y-axis at the specified speed
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}