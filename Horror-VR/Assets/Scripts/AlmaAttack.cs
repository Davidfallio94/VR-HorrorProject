using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlmaAttack : MonoBehaviour {

    public Animator Alma;
    public NavMeshAgent nav;
    public AudioSource almaSound;
    public AudioClip attack;
    public AudioClip walk;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Attack");
            nav.speed = 0.0f;
            Alma.SetBool("Attack", true);
            almaSound.volume = 0 ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("StopAttack");
            nav.speed = 0.5f;
            Alma.SetBool("Attack", false);
            almaSound.volume = 1;
        }
    }
}
