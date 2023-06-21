using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    [Header("miscellaneous")]
    [SerializeField] private GameObject uiSpaceBar;
    public GameObject ElectricityPrefab;
    public EndMarker endMarker;
    public  bool FinishedMiniGame;

    private Vector3 playerSpawnPos;
    private ElectricityTest ElectricityMoveScript; 
    private  ElectricityCollission collissionScript;
    

    private bool IsCollission;
    // Start is called before the first frame update
    void Start()
    {
        FinishedMiniGame = false;
        playerSpawnPos = ElectricityPrefab.transform.position;
        ElectricityMoveScript = ElectricityPrefab.GetComponent<ElectricityTest>();
        collissionScript = ElectricityPrefab.GetComponent<ElectricityCollission>();


    }

    // Update is called once per frame
    void Update()
    {
        IsCollission = checkFOrCollossion();

        if (IsCollission == true)
        {
            ElectricityMoveScript.BeginState = true;
            ElectricityMoveScript.SpeedY = ElectricityMoveScript.BeginSpeed;
            ElectricityPrefab.transform.position = playerSpawnPos;
            Debug.Log(ElectricityMoveScript.BeginState);
        }

        if (endMarker.DidWin == true)
        {
            FinishedMiniGame = true;
            uiSpaceBar.SetActive(false);
        }


    }

    bool checkFOrCollossion()
    {
        //Debug.Log(collissionScript.IsCollission);
        return collissionScript.IsCollission;
        
    }

}
