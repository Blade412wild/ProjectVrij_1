using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject cameraPlacementPlayer;
    [SerializeField] private GetLockedAndSpam lockAndSpam;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private AudioManager auditman;
    private ThirdPersonController thirdPersonController;
    public bool DemonAnimationIsPlaying;
 

    // Nathan heeft dit toegevoegd
    [SerializeField] private UIInput uiInput;
    public bool PlayAnimation;
    public bool AnimationHasBeenPlayed;

    private void Awake()
    {
        auditman.PlayAudio(0);
        DemonAnimationIsPlaying = false;
        thirdPersonController = playerObj.GetComponent<ThirdPersonController>();
        thirdPersonController.enabled = true;
    }

    private void Update()
    {
        InputTrigger();
    }

    void InputTrigger()
    {
        if (PlayAnimation == true && !DemonAnimationIsPlaying)
        {
            DemonAnimationIsPlaying = true;
            thirdPersonController.enabled = false;
            cinemachineVirtualCamera.Follow = null;
            lockAndSpam.EventDemon();
            auditman.PlayAudio(1);
        }
    }

    public void EnableEverythingAgain()
    {
        AnimationHasBeenPlayed = true;
        auditman.PlayAudio(0);
        CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_FrequencyGain = 0.5f;

        thirdPersonController.enabled = true;
        cinemachineVirtualCamera.Follow = cameraPlacementPlayer.transform;
        uiInput.DemonAnimationIsActive = false;
    }
}
