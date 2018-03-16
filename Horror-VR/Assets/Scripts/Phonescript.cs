using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public class Phonescript : MonoBehaviour
    {
        public AudioSource pickup;
        public GameObject phone;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "AcHands")
            {
              
               
            }
        }



    }
}

