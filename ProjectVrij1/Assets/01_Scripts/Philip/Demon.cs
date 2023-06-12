using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Demon : MonoBehaviour
{
    private enum StateEnum { Idle, Patrol, Attack }
    [SerializeField] private StateEnum currentState;
	[SerializeField] private float ViewDistance = 5;
    [SerializeField] private float rayThreshold = 1.0f;
    [SerializeField] private float closeDistanceThreshold = 2.0f;
    [SerializeField] private string sceneToLoad = "GameOverScene";
    [SerializeField] private float CooldownTimer;
    [SerializeField] private float CooldownStartTime;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private Animator anim;

    [Header("NavMeshAgent")]
    [SerializeField] private NavMeshAgent NavMeshAgent;
    public PatrolPoints[] PatrolPoints;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private int patrolIndex = 0;

    [Header("Reference Object")]
    [SerializeField] private GameObject Player;
    //[SerializeField] private AdultToChildMode adultToChildMode;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();

        if (raycastOrigin == null)
        {
            // Create a new GameObject as the raycast origin if not assigned
            raycastOrigin = new GameObject("RaycastOrigin").transform;
            raycastOrigin.SetParent(transform);
            raycastOrigin.localPosition = Vector3.zero;
            raycastOrigin.localRotation = Quaternion.identity;
        }
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
        anim.SetInteger("Demon", 0);
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, ViewDistance, playerLayerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                currentState = StateEnum.Attack;
            }
        }

        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * ViewDistance, Color.red);

        CooldownTimer -= Time.deltaTime;
        if (CooldownTimer <= 0)
        {
            NavMeshAgent.SetDestination(PatrolPoints[patrolIndex].transform.position);
            currentState = StateEnum.Patrol;
        }
    }

    private void PatrolBehaviour()
    {
        anim.SetInteger("Demon", 1);
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

        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, ViewDistance, playerLayerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                currentState = StateEnum.Attack;
            }
        }

        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * ViewDistance, Color.red);
    }

    private void AttackBehaviour()
    {
        anim.SetInteger("Demon", 0);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer < closeDistanceThreshold)
        {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }

        Debug.Log(" attack ");
        NavMeshAgent.SetDestination(Player.transform.position);
        //NavMeshAgent.transform.rotation = Quaternion.LookRotation((Player.transform.position - transform.position).normalized);

        Vector3 directionToPlayer = Player.transform.position - transform.position;
        directionToPlayer.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        NavMeshAgent.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);


        if (distanceToPlayer > ViewDistance * 2)
        {
            currentState = StateEnum.Patrol;
        }
    }
}
