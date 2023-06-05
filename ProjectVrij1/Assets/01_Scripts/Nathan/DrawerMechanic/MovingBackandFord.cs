using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

public class MovingBackandFord : MonoBehaviour
{
    public float Speed = 0.05f;

    public Transform startMarker;
    public Transform endMarker;
    public bool MoveForward;


    private Vector3 startPos;
    private Vector3 endPos;

    private float drawerdept;
    private string axis;
    private Vector3 speedVector;
    private Vector3 currentPos;
    private Vector3 newPos;

    private float Xas;
    private float Zas;


    private bool XAxis;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        //currentPos = transform.position;
        //newPos = currentPos + speedVector;
        //currentPos = newPos;
        //transform.position = new Vector3(currentPos.x, currentPos.y, currentPos.z) * Time.deltaTime;


        //if (XAxis == true)
        //{
        //    transform.position = new Vector3(_currentPos.x, _currentPos.y, _currentPos.z) * Time.deltaTime;
        //}

        //if (XAxis == false)
        //{
        //    transform.position = new Vector3(_currentPos.x, _currentPos.y, _currentPos.z) * Time.deltaTime;
        //}
        if(MoveForward == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endMarker.position, Speed);
            if(transform.position == endMarker.position)
            {
                MoveForward = false;
            }
        }

        if (MoveForward == false)
        {
            transform.position = new Vector3(0, 0, 0);
            //Debug.Log("test");

            //transform.position = Vector3.MoveTowards(transform.position, startMarker.position, Speed);
            //if (transform.position == startMarker.position)
            //{
            //    MoveForward = true;
            //}
        }



        transform.position = Vector3.MoveTowards(transform.position, endMarker.position, Speed);
    }

    private void calculateWhichAxis()
    {
        Vector3 _boxSize = GetComponent<Renderer>().bounds.size;

        if(_boxSize.x > _boxSize.z)
        {
            speedVector = new Vector3(Speed, 0, 0);
            //XAxis = true;
        }
        else
        {
            speedVector = new Vector3(0, 0, Speed);
           // XAxis = false;
        }
    }

    private void calculateThePositions()
    {
        Vector3 _boxSize = GetComponent<Renderer>().bounds.size;

        if (_boxSize.x > _boxSize.z)
        {
            float xpos = _boxSize.x / 2;

        }
        else
        {
        }

    }


}
