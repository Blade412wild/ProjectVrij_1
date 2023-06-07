using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDrawer : MonoBehaviour
{
    [Header("drawers")]
    public GameObject Drawer1;
    public GameObject Drawer2;
    public GameObject Drawer3;
    public GameObject Drawer4;


    [Header("Slide")]
    public GameObject Slide1;
    public GameObject Slide2;
    public GameObject Slide3;
    public GameObject Slide4;
    public GameObject Slide5;

    [Header("miscellaneous")]
    public GameObject Player;
    public int MinCounter; 
    public bool DayTime;
   

    private DrawerMechanic Drawer1Mechanic;
    private DrawerMechanic Drawer2Mechanic;
    private DrawerMechanic Drawer3Mechanic;
    private DrawerMechanic Drawer4Mechanic;


    // Start is called before the first frame update
    void Start()
    {
        Drawer1Mechanic = Drawer1.GetComponent<DrawerMechanic>();
        Drawer2Mechanic = Drawer2.GetComponent<DrawerMechanic>();
        Drawer3Mechanic = Drawer3.GetComponent<DrawerMechanic>();
        Drawer4Mechanic = Drawer4.GetComponent<DrawerMechanic>();

    }

    // Update is called once per frame
    void Update()
    {
        if (DayTime == true)
        {
            if (Drawer1Mechanic.Speed == 0 && Drawer1Mechanic.Counter > MinCounter)
            {
                Slide1.SetActive(true);
            }
            if (Drawer2Mechanic.Speed == 0 && Drawer1Mechanic.Counter > MinCounter)
            {
                Slide2.SetActive(true);
            }
            if (Drawer3Mechanic.Speed == 0 && Drawer1Mechanic.Counter > MinCounter)
            {
                Slide3.SetActive(true);
            }
            if (Drawer4Mechanic.Speed == 0 && Drawer1Mechanic.Counter > MinCounter)
            {
                Slide4.SetActive(true);
                Slide5.SetActive(true);
            }
        }

        if(DayTime == false)
        {
            Drawer1Mechanic.Counter = 0;
            Drawer2Mechanic.Counter = 0;
            Drawer3Mechanic.Counter = 0;
            Drawer4Mechanic.Counter = 0;
        }


    }
    
}