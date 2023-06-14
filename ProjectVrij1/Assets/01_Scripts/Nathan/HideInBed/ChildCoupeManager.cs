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

    [Header("miscellaneous")]
    public bool IsDay;
    public SceneLoader sceneLoader;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerInputManager.InBed == true)
        {
            cameraManager.CameraBed.SetActive(true);
            drawerManager.Player.SetActive(false);
        }

        if(playerInputManager.InBed == false)
        {
            drawerManager.Player.SetActive(true);
            cameraManager.CameraBed.SetActive(false);
        }

        if(sceneLoader.LoadThirdScene == true)
        {
            SceneManager.LoadScene("");

        }
    }
}
