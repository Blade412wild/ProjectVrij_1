using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public bool InBed;
    public bool SpacebarBed;
    public UIInput uiInput;
    // Start is called before the first frame update

    void Start()
    {
        InBed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (InBed == true)
                {
                    SpacebarBed = true;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (InBed == true)
            {
                InBed = false;
            }

            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                if (hit.transform.GetComponent<DrawerMechanic>() != null)
                {
                    var selection = hit.transform;
                    var selectionItem = selection.GetComponent<DrawerMechanic>();
                    selectionItem.Speed = 0;

                }

                if (hit.transform.GetComponent<bed>() != null)
                {
                    Debug.Log("there is a bed");
                    //if (InBed == true)
                    //{
                    //    InBed = false;
                    //}
                    if (InBed == false)
                    {
                        InBed = true;
                    }

                }
                if (hit.transform.GetComponent<DoorScript>())
                {
                    var selection = hit.transform;
                    Debug.Log(selection.ToString());
                    var selectionItem = selection.GetComponent<DoorScript>();
                    selectionItem.PlayAnimation = true;
                    uiInput.DemonAnimationIsActive = true;
                }



            }

            //if (InBed == true)
            //{
            //    InBed = false;
            //}

        }
    }
}
