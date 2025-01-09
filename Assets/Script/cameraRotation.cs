using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{

    public float rotationSpeed;
    public Transform orientation;

    void Start()
    {
        
    }

    void Update()
    {
        orientation.transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
    }
}
