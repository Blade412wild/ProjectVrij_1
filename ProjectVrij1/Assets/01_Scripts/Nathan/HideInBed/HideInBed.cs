using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInBed : MonoBehaviour
{
    public ChildCoupeManager childCoupeManager;
    public RectTransform Blakets;

    public float maxPosY;
    public float Speed;
    public float SafDistance;
    public bool PlayerSafeSatus;

    private float minPosY;

    private float beginPosX;
    private float currentPosY;
    private float newPosY;

    private bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        beginPosX = Blakets.position.y;
        currentPosY = beginPosX;
        minPosY = Blakets.position.y; 


    }

    // Update is called once per frame
    void Update()
    {
        PlayerSafeSatus = IsPlayerSafe();
        movemend();

    }
    private void movemend()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("press button");
            goingUp = true;
            if (Speed < 0)
            {
                Speed = Speed * -1;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (currentPosY < maxPosY)
            {
                Debug.Log("hold butoon");
                newPosY = currentPosY + Speed * Time.deltaTime;
                currentPosY = newPosY;
                Blakets.transform.position = new Vector3(Blakets.position.x, currentPosY, Blakets.position.z);
            }


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("release Button");
            Speed = Speed * -1;
            goingUp = false;

        }

        if (currentPosY > beginPosX && goingUp == false)
        {
            Debug.Log("going down");
            newPosY = currentPosY + Speed * Time.deltaTime;
            currentPosY = newPosY;
            Blakets.transform.position = new Vector3(Blakets.position.x, currentPosY, Blakets.position.z);

        }
    }

    private bool IsPlayerSafe()
    {
        bool _condition;
        if (Blakets.transform.position.y > maxPosY - SafDistance)
        {
            _condition = true;
        }
        else
        {
            _condition = false;
        }

        return _condition;
    }
}
