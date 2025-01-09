using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class playerMovement : MonoBehaviour
{

    public Rigidbody catBody;
    public Transform orientation;
    public Transform poppyOrientation;
    public float jumpPower = 2.0f;
    public float walkSpeed = 15.0f;
    public float runSpeed = 30.0f;
    public float dashSpeed = 60.0f;
    public float playerHeight;
    public LayerMask ground;
    public AnimationCurve animCurve;
    public float time;
    Vector3 moveDirection;
    Vector3 currentSpeed;
    public int totalSpeed;
    float rotation;
    float run;
    bool jumpOn;
    bool jumpOff;
    bool dash;
    bool dashCoolDown = true;
    bool groundCheck;
    bool sprintCheck;
    bool moveCheck;
    public Text textElement;
    public bool moveStop = true;

    void Start()
    {
        catBody = GetComponent<Rigidbody>();
        catBody.freezeRotation = true;
    }

    void Update()
    {
        currentSpeed = new Vector3(catBody.velocity.x, 0, catBody.velocity.z);
        totalSpeed = (int)currentSpeed.magnitude;
        groundCheck = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        textElement.text = currentSpeed.magnitude.ToString();
        MyInput();
        SurfaceAllignment();
    }

    void FixedUpdate()
    {
            PlayerMovement();
    }

    void MyInput()
    {
        jumpOn = Input.GetButton("Jump");
        rotation = Input.GetAxisRaw("Horizontal");
        run = Input.GetAxisRaw("Vertical");
        dash = Input.GetButton("Q");
        sprintCheck = Input.GetKey(KeyCode.LeftShift);
    }

    void PlayerMovement()
    {
        moveDirection = new Vector3(rotation, 0f, run);

        if (rotation != 0 || run != 0)
        {
            moveCheck = true;
        }
        else
        {
            moveCheck = false;
        }

        if (jumpOn && groundCheck)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.Impulse);
        }

        if (dash && dashCoolDown)
        { 
            catBody.velocity = catBody.velocity * 1.5f;
            dashCoolDown = false;
            StartCoroutine(dashCoolDownStart());
        }

        if (sprintCheck && moveCheck)
        {
            catBody.AddForce(poppyOrientation.forward * runSpeed, ForceMode.Force);
            Vector3 limitedRunVel = new Vector3(catBody.velocity.x, catBody.velocity.y, catBody.velocity.z);
            if (limitedRunVel.magnitude > runSpeed && dashCoolDown)
            {
                catBody.velocity = limitedRunVel.normalized * runSpeed;
            }
        }

        else if (moveCheck)
        {
            catBody.AddForce(poppyOrientation.forward * walkSpeed, ForceMode.Force);
            Vector3 limitedWalkVel = new Vector3(catBody.velocity.x, catBody.velocity.y, catBody.velocity.z);
            if(limitedWalkVel.magnitude > walkSpeed && dashCoolDown)
            {
                catBody.velocity = limitedWalkVel.normalized * walkSpeed;
            }
        }
    }

    public void SurfaceAllignment()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        Quaternion RotationRef = Quaternion.Euler(0, 0, 0);
        if(Physics.Raycast(ray, out info, ground))
        {
            RotationRef = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), animCurve.Evaluate(time));
            transform.rotation = Quaternion.Euler(RotationRef.eulerAngles.x, transform.eulerAngles.y, RotationRef.eulerAngles.z);
        }
        if(!groundCheck)
        {
            transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        }
    }

    public IEnumerator dashCoolDownStart()
    {
        yield return new WaitForSeconds(2f);
        dashCoolDown = true;
    }
}
