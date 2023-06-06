using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    //Positie
    public float Speed = 6f;
    private float MinBoundry;
    private float MaxBoundry;
    private BoxCollider boxCollider;

    private float backPivot;


    float PlayerBeginPosX;
    float PlayerBeginPosZ;

    float PlayerCurrentPosX;
    float PlayerCurrentPosZ;

    float PlayerNewPosX;
    float PlayerNewPosZ;

    private Vector3 speedVector;
    private Vector3 boxSize;

    void Start()
    {
        boxSize = GetComponent<Renderer>().bounds.size;
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.enabled = false;

        PlayerBeginPosX = transform.position.x;
        PlayerBeginPosZ = transform.position.z;

        backPivot = CalculatingBackPivot();
        MaxBoundry = CalculatingMaxBoundary();
        MinBoundry = CalculatingMinBoundary();
    }

    // Update is called once per frame
    void Update()
    {
        calculateWhichAxis();
    }
    private void calculateWhichAxis()
    {
        if(Speed == 0)
        {
            boxCollider.enabled = true;
        }

        if (boxSize.x > boxSize.z)
        {
            PlayerNewPosX = PlayerCurrentPosX + Speed * Time.deltaTime;
            PlayerCurrentPosX = PlayerNewPosX;

            transform.position = new Vector3(PlayerCurrentPosX, transform.position.y, transform.position.z);

            if (PlayerCurrentPosX >= MaxBoundry  && Speed >= 0|| PlayerCurrentPosX <= MinBoundry && Speed <= 0)
            {
                Speed = Speed * -1;
            }
        }
        
        if(boxSize.x < boxSize.z)
        {
            PlayerNewPosZ = PlayerCurrentPosZ + Speed * Time.deltaTime;
            PlayerCurrentPosZ = PlayerNewPosZ;

            transform.position = new Vector3(transform.position.x, transform.position.y, PlayerCurrentPosZ);

            if (PlayerCurrentPosZ >= MaxBoundry && Speed >= 0 || PlayerCurrentPosZ <= MinBoundry && Speed <= 0)
            {
                Speed = Speed * -1;
            }
        }

        
    }

    private float CalculatingBackPivot()
    {
        float _backPos;
        if (boxSize.x > boxSize.z)
        {
            _backPos = transform.position.x - (boxSize.x / 2);

            return _backPos;
        }

        if (boxSize.x < boxSize.z)
        {
            _backPos = transform.position.z - (boxSize.z / 2);
            return _backPos;
        }
        else
        {
            _backPos = 0.0f;
            Debug.Log("CalculatingBackPivot: zijden zijn gelijk");
            return _backPos;
        }
    }
    private float CalculatingMinBoundary()
    {
        float MinBoundry;
        if (boxSize.x > boxSize.z)
        {
            MinBoundry = transform.position.x;
            return MinBoundry;
        }

        if (boxSize.x < boxSize.z)
        {
            MinBoundry = transform.position.z;

            return MinBoundry;
        }
        else
        {
            MinBoundry = backPivot;
            Debug.Log("MinBoundary: zijden zijn gelijk");
            return MinBoundry;
        }

        return 0.0f;
    }
    private float CalculatingMaxBoundary()
    {
        float MaxBoundry;

        if (boxSize.x > boxSize.z)
        {
            MaxBoundry = transform.position.x + boxSize.x;
            return MaxBoundry;
        }

        if (boxSize.x < boxSize.z)
        {
            MaxBoundry = transform.position.z + boxSize.z;

            return MaxBoundry;
        }
        else
        {
            MaxBoundry = 0.0f;
            Debug.Log("MaxBoundary: zijden zijn gelijk");
            return MaxBoundry;
        }
    }


}
