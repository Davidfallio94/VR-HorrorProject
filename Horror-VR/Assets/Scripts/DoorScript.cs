using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Exiting
{
    public class DoorScript : MonoBehaviour
    {

        public static bool nail1;
        public static bool nail2;
        public static bool nail3;
        public static bool nail4;
        public static bool nail5;
        private bool DoorOpen;
        public AudioSource door;
        public AudioClip locked;
        public AudioClip open; 



        void Start()
        {
            nail1 = false;
            nail2 = false;
            nail3 = false;
            nail4 = false;
            nail5 = false;
            DoorOpen = false; 
        }

        private void Update()
        {
            if ( (nail1 == true) && (nail2 == true) && (nail3 == true) && (nail4 == true) && (nail5 == true))
            {
                DoorOpen = true; 
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.tag == "AcHands")
            {
                if (DoorOpen == false)
                {
                    door.clip = locked;
                    door.Play();
                }

                if (DoorOpen == true)
                {
                    door.clip = open;
                    door.Play();
                    SceneManager.LoadScene("EndScene");
                }

                Debug.Log("nail"+nail1 + nail2 +nail3+nail4+nail5);
            }
        }
    }
}
