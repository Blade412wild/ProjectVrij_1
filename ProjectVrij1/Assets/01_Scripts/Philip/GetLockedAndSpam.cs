using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLockedAndSpam : MonoBehaviour
{
	private bool isSpammable = false;
	private int spamAmount;
	[SerializeField] private float spamTotal;
	[SerializeField] private GameObject DemonObj;
	[SerializeField] private Animator animController;
	[SerializeField] private Animator animControllerDemon;
	[SerializeField] private Animator animControllerModel;
	[SerializeField] DoorScript doorScript;

	private void Awake()
	{
		animController.enabled = false;
		DemonObj.SetActive(false);
	}

	private void Update()
	{
		if (isSpammable)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				spamAmount++;
			}

			DemonObj.SetActive(true);
			animControllerModel.SetInteger("Demon", 1);
			animControllerDemon.SetBool("Demon", true);

		}	

		if (spamAmount >= spamTotal)
		{
			doorScript.EnableEverythingAgain();
			animController.SetBool("Demon", false);
			animController.enabled = false;
			isSpammable = false;
		}

		AnimatorStateInfo stateInfo = animController.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName("turnaround") && stateInfo.normalizedTime >= 1.0f)
		{
			SceneManager.LoadScene("Death");
		}
	}

	public void EventDemon()
	{
		animController.enabled = true;
		isSpammable = true;
		animController.SetBool("Demon", true);
		animControllerDemon.SetBool("Demon", true);
	}
}
