using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    //Positie
    float PlayerBeginPosX;
    float PlayerBeginPosZ;

    float PlayerCurrentPosX;
    float PlayerCurrentPosZ;

    float PlayerNewPosX;
    float PlayerNewPosZ;

    public float speed = 6f;

    void Start()
    {
        PlayerBeginPosX = transform.position.x;
        PlayerBeginPosZ = transform.position.z;
        Debug.Log(PlayerBeginPosX);
        Debug.Log(PlayerBeginPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerNewPosX = PlayerCurrentPosX + speed * Time.deltaTime;
        PlayerCurrentPosX = PlayerNewPosX;

        transform.position = new Vector3(PlayerCurrentPosX , transform.position.y, transform.position.z);

        if (PlayerCurrentPosX >= 10 || PlayerCurrentPosX <= -10)
        {
            speed = speed * -1;
        }
    }

    
}
