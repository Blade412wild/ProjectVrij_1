using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInput : MonoBehaviour
{
    public GameObject F;
    public GameObject Spacebar;
    public GameObject SmashSpacebar;

    public bool DemonAnimationIsActive; 
    public bool demonAttackStateIsActive;
    public bool inBed;
    // Start is called before the first frame update
    void Start()
    {
        F.SetActive(false); 
        Spacebar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3.0f))
        {
            if (hit.transform.GetComponent<Item>() != null)
            {
                Debug.Log("have hit item");
            }
            else if (hit.transform.GetComponent<DrawerMechanic>() != null)
            {
                Debug.Log("Drawer");
                F.SetActive(true);

            }
            else if (hit.transform.GetComponent<bed>() != null)
            {
                Debug.Log("there is a bed");
                F.SetActive(true);

            }
            else if (hit.transform.GetComponent<DoorScript>() != null)
            {
                Debug.Log("door");
                F.SetActive(true);
            }
            else if (hit.transform.GetComponent<Lamp>() != null)
            {
                Debug.Log("door");
                F.SetActive(true);
            }


        }
        else
        {
            F.SetActive(false);
        }

        if(DemonAnimationIsActive == true)
        {
            SmashSpacebar.SetActive (true);
        }
        else if(demonAttackStateIsActive == true)
        {
            SmashSpacebar.SetActive(true);
        }
        else if (inBed == true)
        {
            Spacebar.SetActive(true);
        }
        else
        {
            SmashSpacebar.SetActive(false);
            Spacebar.SetActive(false);

        }
    }
}
