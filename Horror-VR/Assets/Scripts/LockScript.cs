using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour {

    private bool Locked;
    public GameObject self;
    public AudioSource Lock;
    public AudioClip Unlocked;
    public GameObject _Lock;
    public Animation open;
    public Animator Her;
    public GameObject Writing;
    public GameObject Bible;

    void Start()
    {
        Locked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AcHands")
        {
            if (Locked == true )
            {
                Lock.Play();
            }
        }

        if (other.tag == "Key")
        {
            Bible.SetActive(true);
            Locked = false;
            Lock.clip = Unlocked;
            Lock.Play();
            _Lock.SetActive(true);
            open.Play();
            Her.SetBool("Point" , true);
            Writing.SetActive(true);
            Destroy(self);
        }
    }


}
