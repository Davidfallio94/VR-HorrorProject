using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Games
{
    public class PuzzleManager : MonoBehaviour
    {
        public static bool Manne;
        public AudioSource ringing;

        void Start()
        {
            Manne = false;
        }

        private void Update()
        {
            if (Manne == true)
            {
                ringing.Play();
            }
        }
    }
}
