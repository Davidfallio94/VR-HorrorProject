using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using control;

namespace Games
{
    public class Phonescript : MonoBehaviour
    {
        public AudioSource pickup;
        public GameObject phone;
        public AudioClip answer;
        private bool played;
        public GameObject blood;

        private void Start()
        {
            played = false;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "AcHands")
            {
                if (Keypress.keypress == true || Keypress.keypressL == true)
                {
                    if (played == false)
                    {
                        pickup.Stop();
                        pickup.clip = answer;
                        pickup.loop = false;
                        pickup.Play();
                        played = true;
                        blood.SetActive(true);
                    }
                }
            }
        }
    }
}

