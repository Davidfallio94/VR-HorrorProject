using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlmaWalk : MonoBehaviour
{

    public NavMeshAgent nav;
    private Transform player;



    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        nav.SetDestination(player.position);
        NavMeshPath path = new NavMeshPath();
        nav.CalculatePath(player.position, path);
        nav.SetPath(path);
    }
}
   
