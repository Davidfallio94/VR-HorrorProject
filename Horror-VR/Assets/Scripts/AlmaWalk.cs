using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlmaWalk : MonoBehaviour
{

    public NavMeshAgent nav;
    private Transform player;
    public AudioSource almasound;
    public AudioClip Walk;
    public AudioClip Scream;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        almasound.clip = Scream;
        almasound.Play();
    }

    void FixedUpdate()
    {
        nav.SetDestination(player.position);
        NavMeshPath path = new NavMeshPath();
        nav.CalculatePath(player.position, path);
        nav.SetPath(path);

     
    }

    private void Update()
    {
        if (!almasound.isPlaying)
        {
            almasound.clip = Walk;
            almasound.loop = true;
            almasound.Play();
        }
    }


}
   
