using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public bool Global;//togliere
    float Velocity;
    public float SpeedVelocity =50f;
    public float rotationTime = 0.25f;
    float currentSpeed;
    float Speed;
    public Animator movimentoPlayer;
    public int frame =20;
    public int counter = 0;
    public bool isShooting= false;
    public bool fermo=false;
    public bool slotFull = false;

    public bool InputMobile = false;
    public GameObject boxArma;
    public GameObject marco;
    public GameObject bastone;
    



    public FixedJoystick joystick;
    //public FixedTouchField touchField;
    void start()
    {
       
        movimentoPlayer = GetComponent<Animator>();
        movimentoPlayer.SetBool("isWalking", false);
        movimentoPlayer.SetBool("isShooting", false);
        movimentoPlayer.SetBool("isDeath", false);
        movimentoPlayer.SetBool("hasArmy", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector2 input;//= Vector2.zero;
        if (InputMobile) {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else {

            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }
        Vector2 InputDir = input.normalized;

        if (InputDir != Vector2.zero)
        {
            float rotatio = Mathf.Atan2(InputDir.x, InputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotatio, ref Velocity, rotationTime);
        }
        float targetSpeed = SpeedVelocity * InputDir.magnitude;
       
        if (targetSpeed != 0)
        {
            movimentoPlayer.SetBool("isWalking", true);
            movimentoPlayer.SetBool("isStopped", false);
            fermo = false;
            
        }
        else
        {
            movimentoPlayer.SetBool("isWalking", false);
            movimentoPlayer.SetBool("isStopped", true);
            fermo = true;
            
        }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref Speed, 0.1f);
     
        //if (Global)//toglier
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        if (slotFull)
        {
            movimentoPlayer.SetBool("hasArmy", true);
 
        }
        else {
            movimentoPlayer.SetBool("hasArmy", false);

        }



        if (marco.GetComponent<FixedTouchField>().Pressed)
        {
           movimentoPlayer.SetBool("isShooting", true);
           isShooting = true;
           counter=0;
       }
       else
       {
           counter++;
           if (counter == frame)
           {
               movimentoPlayer.SetBool("isShooting", false);
               isShooting = false;
           }
       }
        bastone.SetActive(!slotFull);
        

        //else
        // transform.Translate(transform.forward * (currentSpeed) * Time.deltaTime, Space.Self);//togliere
        //print(transform.forward);//togliere

    }
}