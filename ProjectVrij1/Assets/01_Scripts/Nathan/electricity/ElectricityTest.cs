using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ElectricityTest : MonoBehaviour
{
    public float SpeedY = -4.0f;
    public float SpeedX = 1.0f;
    public  float BeginSpeed;
    public AudioSource electricitySound;


    public  bool BeginState;
    private Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        BeginState = true;
        BeginSpeed = SpeedY;
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ElectricityMovement();
    }
    private void ElectricityMovement()
    {
        if (BeginState)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BeginState = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && SpeedY < 0)
            {
                SpeedY = SpeedY * -1;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                playerPos = new Vector3(transform.position.x + SpeedX * Time.deltaTime, transform.position.y + SpeedY * Time.deltaTime, transform.position.z /*- SpeedX * Time.deltaTime*/);
                transform.position = playerPos;
            }
            else
            {
                playerPos = new Vector3(transform.position.x + SpeedX * Time.deltaTime, transform.position.y + SpeedY * Time.deltaTime, transform.position.z /*- SpeedX * Time.deltaTime*/);
                transform.position = playerPos;

            }

            if (Input.GetKeyUp(KeyCode.Space) && SpeedY > 0)
            {
                SpeedY = SpeedY * -1;
            }
        }
    }

}


