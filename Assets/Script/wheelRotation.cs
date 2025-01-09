using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotation : MonoBehaviour
{
    public playerMovement speed;
    public GameObject obj;
    float speedNow;

    void Start()
    {
        speed = obj.GetComponent<playerMovement>();
    }

    void Update()
    {
        transform.Rotate(0f, 0f, (float)speed.totalSpeed, Space.Self);
    }
}
