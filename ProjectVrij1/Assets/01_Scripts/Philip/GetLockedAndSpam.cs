using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLockedAndSpam : MonoBehaviour
{
	private bool isSpammable = false;
	private int spamAmount;
	[SerializeField] private float spamTotal;
	[SerializeField] private Animator animController;
	[SerializeField] DoorScript doorScript;

	private void Awake()
	{
		animController.enabled = false;
	}

	private void Update()
	{
		if (isSpammable)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				spamAmount++;
			}
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
	}
}
