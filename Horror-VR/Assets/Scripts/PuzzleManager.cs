using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Games
{
    public class PuzzleManager : MonoBehaviour
    {
        public static bool Manne;
        public AudioSource ringing;
        public bool test;

        void Start()
        {
            Manne = false;
            test = false;
        }

        private void Update()
        {

            if (test == true)
            {
                //if (Manne == true)
                //{
                    ringing.Play();
                //}
            }
        }
    }
}
