using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{

    public Transform orientation;
    public Transform cubeOrientation;
    float rotation;
    float run;
    Vector3 direction;
    public static float turnSmoothTime;
    float turnSmoothVelocity;

    void Start()
    {
        
    }

    void MyInput()
    {
        run = Input.GetAxisRaw("Vertical");
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void Update()
    {
        MyInput();
        direction = new Vector3(run, 0f, -rotation).normalized;
        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(orientation.eulerAngles.y, targetAngle - 45f, ref turnSmoothVelocity, turnSmoothTime);
            float yRotation = angle - transform.eulerAngles.y;
            orientation.transform.Rotate(0f, yRotation, 0f, Space.Self);
        }
    }
}
