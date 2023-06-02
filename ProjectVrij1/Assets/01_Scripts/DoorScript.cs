using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private GameObject playerObj;
	[SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
	private ThirdPersonController thirdPersonController;
	private bool isColliding;

	private void Awake()
	{
		thirdPersonController = playerObj.GetComponent<ThirdPersonController>();
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
		if (Input.GetKeyDown(KeyCode.Space) && isColliding)
		{
			thirdPersonController.enabled = false;
			cinemachineVirtualCamera.enabled = false;
		}
	}
}