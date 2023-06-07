using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DrawerMechanic : MonoBehaviour
{
    [Header("Managers")]
    public ManagerDrawer managerDrawer;

    [Header("miscellaneous")]
    public float BoxActivationDistance = 2.0f;
    public float Speed = 6f;
    public float DistanceToWin;
    public int Counter;

    private BoxCollider boxCollider;
    private float InitialSpeed;
    
    //Positie
    private float backPivot;
    private float frontPivot;

    private float MinBoundry;
    private float MaxBoundry;

    private float PlayerBeginPosX;
    private float PlayerBeginPosZ;

    private float PlayerCurrentPosX;
    private float PlayerCurrentPosZ;

    private float PlayerNewPosX;
    private float PlayerNewPosZ;

    private Vector3 speedVector;
    private Vector3 BeginPos;
    private Vector3 boxSize;

    //private bool dayTime;

    void Start()
    {
        boxSize = GetComponent<Renderer>().bounds.size;
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.enabled = true;

        PlayerBeginPosX = transform.position.x;
        PlayerBeginPosZ = transform.position.z;
        InitialSpeed = Speed;

        backPivot = CalculatingBackPivot();
        frontPivot = CalculatingFrontPivot();
        MaxBoundry = CalculatingMaxBoundary();
        MinBoundry = CalculatingMinBoundary();
    }

    // Update is called once per frame
    void Update()
    {
            decidingBoxColliderState();
            calculateWhichAxis();

        if (managerDrawer.DayTime == true)
        {

            if(Speed == 0 && Counter < 3)
            {
                Speed = InitialSpeed;
            }

            if (boxSize.x > boxSize.z)
            {
                if (transform.position.x <= PlayerBeginPosX)
                {
                    Counter++;
                }
            }

            if (boxSize.x < boxSize.z)
            {
                if (transform.position.z <= PlayerBeginPosZ)
                {
                    Counter++;
                }
            }

        }

        if(managerDrawer.DayTime == false)
        {
            decidingBoxColliderState();
            calculateWhichAxis();

            if (boxSize.x > boxSize.z)
            {
                if(transform.position.x > PlayerBeginPosX)
                {
                    Speed = InitialSpeed * -1;
                }

                if (transform.position.x <= PlayerBeginPosX)
                {
                    Speed = 0;
                }
            }

            if (boxSize.x < boxSize.z)
            {
                if (transform.position.z > PlayerBeginPosX)
                {
                    Speed = InitialSpeed * -1;
                }

                if (transform.position.z <= PlayerBeginPosZ)
                {
                    Speed = 0;
                }
            }
        }
    }
    private void calculateWhichAxis()
    {
 

        if (boxSize.x > boxSize.z)
        {
            PlayerNewPosX = PlayerCurrentPosX + Speed * Time.deltaTime;
            PlayerCurrentPosX = PlayerNewPosX;

            transform.position = new Vector3(PlayerCurrentPosX, transform.position.y, transform.position.z);

            if (PlayerCurrentPosX >= MaxBoundry && Speed >= 0 || PlayerCurrentPosX <= MinBoundry && Speed <= 0)
            {
                Speed = Speed * -1;
            }
        }

        if (boxSize.x < boxSize.z)
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
    private float CalculatingFrontPivot()
    {
        float _frontkPos;
        if (boxSize.x > boxSize.z)
        {
            _frontkPos = transform.position.x + (boxSize.x / 2);

            return _frontkPos;
        }

        if (boxSize.x < boxSize.z)
        {
            _frontkPos = transform.position.z + (boxSize.z / 2);
            return _frontkPos;
        }
        else
        {
            _frontkPos = 0.0f;
            Debug.Log("CalculatingBackPivot: zijden zijn gelijk");
            return _frontkPos;
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

    private void decidingBoxColliderState()
    {
        bool _state;
        float _playerObjectDistance = Vector3.Distance(transform.position, managerDrawer.Player.transform.position);
        Debug.Log(_playerObjectDistance);

        if(_playerObjectDistance < BoxActivationDistance && Speed > 0 || _playerObjectDistance < BoxActivationDistance && Speed < 0)
        {
            _state = false;
        }
        else 
        {
            _state= true;
        }

        boxCollider.enabled = _state;
    }

    public bool CalculatingWin()
    {
        bool _Win;

        if(Speed == 0 && (transform.position.x + backPivot) < MaxBoundry && (transform.position.x + backPivot) > (MaxBoundry + DistanceToWin))
        {
            _Win = true;
        }
        else
        {
            _Win = false;
        }

        return _Win;
    }

}
