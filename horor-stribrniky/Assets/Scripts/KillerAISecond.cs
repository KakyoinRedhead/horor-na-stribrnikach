using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class KillerAISecond : MonoBehaviour
{
    public NavMeshAgent killer;

    public Transform player;
    public Transform killeros;
    public Transform bod;
    public Camera playerCamera;

    public LayerMask whatGround, whatPlayer;

    public NavMeshPath path;

    public Vector3 walkingPoint;
    bool walkingPointSet;
    public float walkingPointRange;


    public float attackSpeed;
    bool attacking;

    public float sightRange, attackRange;
    public bool playerInSight, playerInAttack;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        killeros = GameObject.Find("KillerUhKAPSLE").transform;
        killer = GetComponent<NavMeshAgent>();
        playerCamera = Camera.main;
    }
    private void Start()
    {
    }
    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatPlayer);
        PlayerMovement playerScript = GameObject.Find("PlayerC").GetComponent<PlayerMovement>();
        bool canHunt = playerScript.moving;


        if (!playerInSight && !playerInAttack)
        {
            LookingForPlayer();
        }
        if (playerInSight && !playerInAttack && canHunt)
        {
            HuntingPlayer();
        }
        else {
            LookingForPlayer();
                }
        if (playerInSight && playerInAttack )
        {
            AttackingPlayer();
        }

    }


    private void LookingForPlayer()
    {
        if (!walkingPointSet)
        {
            SearchWalkPoint();
        }

        Vector3 walkingPointDistance = transform.position - walkingPoint;

        if (walkingPointDistance.magnitude < 1f || path == null || path.status != NavMeshPathStatus.PathComplete)
        {
            walkingPointSet = false;
        }

        killer.speed = 10f;
    }
    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkingPointRange, walkingPointRange);
        float randomZ = UnityEngine.Random.Range(-walkingPointRange, walkingPointRange);


        walkingPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        path = new NavMeshPath();


        if (Physics.Raycast(walkingPoint, -transform.up, 2f, whatGround) && killer.CalculatePath(walkingPoint, path))
        {
            killer.SetPath(path);
            walkingPointSet = true;
        }
    }

    private void HuntingPlayer()
    {
        var path = new NavMeshPath();
        var pos = new Vector3(player.position.x, transform.position.y, player.position.z);

        killer.CalculatePath(pos, path);

        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            this.path = path;

            walkingPointSet = false;
            walkingPoint = pos;

            killer.speed = 10f;
            killer.SetPath(path);
        }
        else
        {
            LookingForPlayer();
        }

    }

    private void AttackingPlayer()
    {
        killer.SetDestination(transform.position);

        transform.LookAt(player);


        if (!attacking)
        {
            attacking = true;
            Invoke(nameof(ResetAttack), attackSpeed);
        }
    }

    private void ResetAttack()
    {
        attacking = false;
    }
}
