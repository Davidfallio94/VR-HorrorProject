using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour {

    private bool Locked;
    public AudioSource Lock;
    public AudioClip Unlocked;
    public GameObject _Lock;
    public Animation open;

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
            Locked = false;
            Lock.clip = Unlocked;
            Lock.Play();
            _Lock.SetActive(true);
            Destroy(this, 5);
            open.Play();

        }
    }


}
