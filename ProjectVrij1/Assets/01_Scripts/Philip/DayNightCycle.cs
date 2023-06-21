using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject demon;
	[SerializeField] private Demon demonScript;
	[SerializeField] private GameObject lights;
	[SerializeField] private GameObject lightStand;
	public bool DayOrNight;

	private void Awake()
	{
		DayOrNight = true;
		demonScript.enabled = false;
		demon.SetActive(false);
		lights.SetActive(true);
		lightStand.SetActive(true);
	}

	private void Update()
	{
		//day
		if (DayOrNight)
		{
			anim.SetInteger("DNC", 1);
			demonScript.enabled = false;
			demon.SetActive(false);
			lights.SetActive(true);
			lightStand.SetActive(true);
		}
		//night
		if (!DayOrNight)
		{
			anim.SetInteger("DNC", 0);
			StartCoroutine(ShowDemon());
			lights.SetActive(false);
			lightStand.SetActive(false);
		}
	}

	public void SetDayOrNight(bool _index)
	{
		DayOrNight = _index;
	}

	IEnumerator ShowDemon()
	{
		yield return new WaitForSeconds(2);
		demonScript.enabled = true;
		demon.SetActive(true);
	}


}
