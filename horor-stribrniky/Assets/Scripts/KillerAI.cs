using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;
using Image = UnityEngine.UI.Image;

public class KillerAI : MonoBehaviour
{
    public NavMeshAgent killer;

    public Transform player;
    public Transform killeros;
    public Transform bod;
    public Camera playerCamera;

    public LayerMask whatGround, whatPlayer;

    //public AudioSource source;
    //public AudioClip clip;
    //public GameObject jumpscar;
    //public Image blackscreen;
    //public bool soundPlayed = false;

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
        killeros = GameObject.Find("Killer").transform;
        killer = GetComponent<NavMeshAgent>();
        playerCamera = Camera.main;
    }
    private void Start()
    {
        //blackscreen.enabled = false;
    }
    private void Update()
    {
        bool isPlayerLooking = IsPlayerLookingAtEnemy();
        bool batteryIsOff = GetBatteryStatus();
        bool batteryIsOn = GetBatteryStatus();
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatPlayer);


        if(!playerInSight && !playerInAttack)
        {
            LookingForPlayer();
        }
        if(playerInSight && !playerInAttack)
        {
            HuntingPlayer();
        }
        if(playerInSight && playerInAttack)
        {
            AttackingPlayer();
        }
        if (isPlayerLooking && !batteryIsOff)
        {
            killer.speed = 2f;
        }
        else
        {
            killer.speed = 8f;
        }
    }

    private bool IsPlayerLookingAtEnemy()
    {
        Vector3 toEnemy = transform.position - playerCamera.transform.position;
        float angle = Vector3.Angle(playerCamera.transform.forward, toEnemy);

        return angle < playerCamera.fieldOfView / 2f;
    }
    private bool GetBatteryStatus()
    {
        Battery batteryScript = GameObject.Find("BatteryO").GetComponent<Battery>();

        if (batteryScript != null)
        {
            return batteryScript.batteryIsOff;
        }

        return false; 
    }

    private void LookingForPlayer()
    {
        if (!walkingPointSet)
        {
            SearchWalkPoint();
        }

        /*if (walkingPointSet)
        {
            killer.SetDestination(walkingPoint);
        }*/

        Vector3 walkingPointDistance = transform.position - walkingPoint;

        if(walkingPointDistance.magnitude < 1f || path == null || path.status != NavMeshPathStatus.PathComplete)
        {
            walkingPointSet = false;
        }

        killer.speed = 4f;
    }
    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkingPointRange, walkingPointRange);
        float randomZ = UnityEngine.Random.Range(-walkingPointRange, walkingPointRange);


        walkingPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        path = new NavMeshPath();

        //bod.position = walkingPoint;


        if(Physics.Raycast(walkingPoint, -transform.up, 2f, whatGround) && killer.CalculatePath(walkingPoint, path))
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

            killer.speed = 5f;
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

        //die
        //Application.Quit();
        //JumpScara();

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


    //private void JumpScara()
    //{
    //    StartCoroutine(DelayedRespawn());

    //    if (soundPlayed) { }
    //    else
    //    {
    //        jumpscar.SetActive(true);
    //        source.PlayOneShot(clip);
    //        soundPlayed = true;
    //    }
    //}

    //IEnumerator DelayedRespawn()
    //{
    //    yield return new WaitForSeconds(clip.length / 2);
    //    blackscreen.enabled = true;
    //    source.Stop();
    //    jumpscar.SetActive(false);
    //    StartCoroutine(Respawn());
    //}
    //IEnumerator Respawn()
    //{
    //    yield return new WaitForSeconds(1);
    //    player.position = new Vector3(-11, 0.059f, -267.3f);
    //    blackscreen.enabled = false;
    //}
}
