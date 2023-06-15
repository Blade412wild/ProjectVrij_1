using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public ElectricityManager electricityManager;
    public GameObject canvas;
    public VideoPlayer clip1;
    float clipDuration = 10.0f;

    private float speed = 1.0f;
    private float beginTime = 0.0f;
    private float currentTime;
    private float newTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = beginTime;
        //clipDuration = (float)clip1.length;
    }

    // Update is called once per frame
    void Update()
    {
        newTime = currentTime  + (speed *Time.deltaTime);
        currentTime = newTime;

        if(currentTime >= clipDuration)
        {
            clip1.Stop();
            canvas.SetActive(false);
        }

        if(electricityManager.FinishedMiniGame == true)
        {
            clip1.Play();
        }

        Debug.Log(currentTime);
    }
}
