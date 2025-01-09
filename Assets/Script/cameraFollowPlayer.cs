using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{

    public Transform playerPosition;
    public Transform cameraPosition;
    Vector3 cameraDistance;

    void Start()
    {
        cameraDistance = playerPosition.position - cameraPosition.position;
    }

    void Update()
    {   
        cameraPosition.position = playerPosition.position - cameraDistance;
    }
}
