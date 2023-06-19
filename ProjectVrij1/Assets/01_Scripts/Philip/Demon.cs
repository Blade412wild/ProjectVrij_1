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
    [SerializeField] private float closeDistanceThreshold = 2.0f;
    [SerializeField] private string sceneToLoad = "GameOverScene";
    [SerializeField] private float CooldownTimer;
    [SerializeField] private float CooldownStartTime;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private Animator anim;
    [SerializeField] private HideInBed hidinBed;

    [Header("NavMeshAgent")]
    [SerializeField] private NavMeshAgent NavMeshAgent;
    public PatrolPoints[] PatrolPoints;
    [SerializeField] private int patrolIndex = 0;

    [Header("Reference Object")]
    [SerializeField] private GameObject Player;
    //[SerializeField] private AdultToChildMode adultToChildMode;

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
        anim.SetInteger("Demon", 0);
        if (Vector2.Distance(transform.position, Player.transform.position) <= ViewDistance && hidinBed.PlayerSafeSatus == false)
        {
            currentState = StateEnum.Attack;
        }

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

        if (Vector2.Distance(transform.position, Player.transform.position) <= ViewDistance && hidinBed.PlayerSafeSatus == false)
        {
            currentState = StateEnum.Attack;
        }
    }

    private void AttackBehaviour()
    {
        if (hidinBed.PlayerSafeSatus == true)
		{
            currentState = StateEnum.Patrol;
		}

        anim.SetInteger("Demon", 1);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer < closeDistanceThreshold)
        {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }

        NavMeshAgent.SetDestination(Player.transform.position);

        Vector3 directionToPlayer = Player.transform.position - transform.position;
        directionToPlayer.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        NavMeshAgent.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

        if (distanceToPlayer > ViewDistance)
        {
            currentState = StateEnum.Patrol;
        }
    }
}
