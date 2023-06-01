using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Demon : MonoBehaviour
{
	[SerializeField] private enum StateEnum { Idle, Patrol, Attack }
	[SerializeField] private StateEnum currentState;
	[SerializeField] private float ViewDistance = 5;
	[SerializeField] private float CooldownTimer;
	[SerializeField] private float CooldownStartTime;

	[Header("NavMeshAgent")]
	[SerializeField] private NavMeshAgent NavMeshAgent;
	public PatrolPoints[] PatrolPoints;
	[SerializeField] private int patrolIndex = 0;

	[Header("Reference Object")]
	[SerializeField] private GameObject Player;

	private void Awake()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
	}

	private void Start()
	{
		if (PatrolPoints.Length != 0)
		{
			NavMeshAgent.SetDestination(PatrolPoints[patrolIndex].transform.position);
		}
	}

	private void Update()
	{
		CheckState();
	}

	private void CheckState()
	{
		switch (currentState)
		{
			case StateEnum.Idle: IdleBehaviour(); break;
			case StateEnum.Patrol: PatrolBehaviour(); break;
			case StateEnum.Attack: AttackBehaviour(); break;
		}
	}

	private void IdleBehaviour()
	{
		if (Vector3.Distance(transform.position, Player.transform.position) < ViewDistance)
		{
			currentState = StateEnum.Attack;
		}

		CooldownTimer = CooldownStartTime;
		CooldownTimer -= 1000 * Time.deltaTime;
		if (CooldownTimer <= 0)
		{
			NavMeshAgent.SetDestination(PatrolPoints[patrolIndex].transform.position);
			currentState = StateEnum.Patrol;
		}
	}

	private void PatrolBehaviour()
	{
		if (NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
		{
			patrolIndex++;
			if (patrolIndex < PatrolPoints.Length)
			{
				currentState = StateEnum.Idle;
			}

			if (patrolIndex >= PatrolPoints.Length)
			{
				patrolIndex = -1;
			}
		}

		if (Vector3.Distance(transform.position, Player.transform.position) < ViewDistance)
		{
			currentState = StateEnum.Attack;
		}
	}

	private void AttackBehaviour()
	{
		Debug.Log(" attack ");
		NavMeshAgent.SetDestination(Player.transform.position);
		NavMeshAgent.transform.rotation = Quaternion.LookRotation((Player.transform.position - transform.position).normalized);

		if (Vector3.Distance(transform.position, Player.transform.position) > ViewDistance * 2)
		{
			currentState = StateEnum.Patrol;
		}
	}	
}
