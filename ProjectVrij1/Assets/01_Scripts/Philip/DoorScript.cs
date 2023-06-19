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
    public bool DemonAnimationHasBeenPlayed;

    // Nathan heeft dit toegevoegd
    [SerializeField] private UIInput uiInput;
    public bool PlayAnimation;

    private void Awake()
    {
        auditman.PlayAudio(0);
        DemonAnimationHasBeenPlayed = false;
        thirdPersonController = playerObj.GetComponent<ThirdPersonController>();
        thirdPersonController.enabled = true;
    }

    private void Update()
    {
        InputTrigger();
    }

    void InputTrigger()
    {
        if (PlayAnimation == true && !DemonAnimationHasBeenPlayed)
        {
            DemonAnimationHasBeenPlayed = true;
            thirdPersonController.enabled = false;
            cinemachineVirtualCamera.Follow = null;
            lockAndSpam.EventDemon();
            auditman.PlayAudio(1);
        }
    }

    public void EnableEverythingAgain()
    {
        auditman.PlayAudio(0);
        CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_FrequencyGain = 0.5f;

        thirdPersonController.enabled = true;
        cinemachineVirtualCamera.Follow = cameraPlacementPlayer.transform;
        uiInput.DemonAnimationIsActive = false;
    }
}
