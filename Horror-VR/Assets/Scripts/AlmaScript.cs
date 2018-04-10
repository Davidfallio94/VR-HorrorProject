using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmaScript : MonoBehaviour
{

    public AudioSource almasound;
    public AudioClip Moan;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AcHands")
        {
            if (!almasound.isPlaying)
            {
                almasound.clip = Moan;
                almasound.Play();
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.tag == "AcHands")
    //    {
    //        if (!almasound.isPlaying)
    //        {
    //            almasound.clip = Moan;
    //            almasound.Play();
    //        }
    //    }
    //}
}
