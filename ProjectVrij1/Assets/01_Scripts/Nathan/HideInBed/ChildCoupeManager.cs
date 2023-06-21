using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildCoupeManager : MonoBehaviour
{
    [Header("managers")]
    public ManagerDrawer drawerManager;
    public CameraManager cameraManager;
    public PlayerInputManager playerInputManager;
    public LevelBoundary levelBoundary;
    public DayNightCycle dayNightCycle;

    [Header("miscellaneous")]
    public SceneLoader sceneLoader;
    public bool CanvasActive;


    // Start is called before the first frame update
    void Start()
    {
        CanvasActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInputManager.InBed == true)
        {
            CanvasActive = true;
            cameraManager.CameraBed.SetActive(true);
            drawerManager.Player.SetActive(false);
            playerInputManager.uiInput.inBed = true;

        }

        if (playerInputManager.InBed == false)
        {
            CanvasActive = false;
            drawerManager.Player.SetActive(true);
            cameraManager.CameraBed.SetActive(false);
            playerInputManager.uiInput.inBed = false;
        }

        if(playerInputManager.Lamp == true && levelBoundary.OnTheDrawer == true)
        {
            SceneManager.LoadScene("ElectricityGame");
        }

        if(dayNightCycle.DayOrNight == true)
        {
            drawerManager.DayTime = true;
        }
        else if (dayNightCycle.DayOrNight == false)
        {
            drawerManager.DayTime = false;
        }


    }
}
