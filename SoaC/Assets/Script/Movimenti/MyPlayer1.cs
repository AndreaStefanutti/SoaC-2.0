using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer1 : MonoBehaviour
{
    public bool Global;//togliere
    float Velocity;
    public float SpeedVelocity = 50f;
    public float rotationTime = 0.25f;
    float currentSpeed;
    float Speed;

    public bool InputMobile = false;


    public FixedJoystick joystick;
    //public FixedTouchField touchField;


    // Update is called once per frame
    void Update()
    {
        Vector2 input;//= Vector2.zero;
        if (InputMobile)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {

            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }
        Vector2 InputDir = input.normalized;

        if (InputDir != Vector2.zero)
        {
            float rotatio = Mathf.Atan2(InputDir.x, InputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotatio, ref Velocity, rotationTime);
        }
        float targetSpeed = SpeedVelocity * InputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref Speed, 0.1f);

        //if (Global)//toglier
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        //else
        // transform.Translate(transform.forward * (currentSpeed) * Time.deltaTime, Space.Self);//togliere
        //print(transform.forward);//togliere

    }
}