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
	private bool isColliding;

	// Nathan heeft dit toegevoegd
	[SerializeField] private UIInput uiInput;
	public bool PlayAnimation;
	public bool DemonAnimationHasBeenPlayed;

	private void Awake()
	{
		auditman.PlayAudio(0);
		DemonAnimationHasBeenPlayed = false;
        thirdPersonController = playerObj.GetComponent<ThirdPersonController>();
		thirdPersonController.enabled = true;
		isColliding = false;
	}

	private void Update()
	{
		InputTrigger();
	}

	private void OnTriggerEnter(Collider other)
	{
		isColliding = true;
	}

	void InputTrigger()
	{
		// ik heb dit veranderd naar een bool zodat ik via de player het kan activeren
		if (PlayAnimation == true)
		{
			thirdPersonController.enabled = false;
			cinemachineVirtualCamera.Follow = null;
			lockAndSpam.EventDemon();
			auditman.PlayAudio(1);
			uiInput.DemonAnimationIsActive = true;

        }
	}

	public void EnableEverythingAgain()
	{
		CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		noise.m_FrequencyGain = 0.5f;

		thirdPersonController.enabled = true;
		cinemachineVirtualCamera.Follow = cameraPlacementPlayer.transform;
		isColliding = false;
        DemonAnimationHasBeenPlayed = true;
        uiInput.DemonAnimationIsActive = false;
    }
}