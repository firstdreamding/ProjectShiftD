using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIScript : MonoBehaviour
{

    public NavMeshAgent agent;

    //Location of base and player.
    public Transform Base1;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer, whatIsBase;

    // Tracks attacks range and cooldowns.
    public float attackCoolDown;
    public bool attackTracker;
    public float attackRange;

    //track Range of player/base.
    public bool baseInRange, playerInRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        Base1 = GameObject.Find("Base").transform;


    }

    // Update is called once per frame
    void Update()
    {//
        //check
        checkRange();
        if(!playerInRange){
            Pathing();
        }else{
            agent.SetDestination(transform.position);
        }
    }
    private void Pathing(){
        agent.SetDestination(player.position);
    }

    private void checkRange(){
        baseInRange = Physics.CheckSphere(transform.position, attackRange, whatIsBase);
        playerInRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        Debug.Log(playerInRange);
    }


}
