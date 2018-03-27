using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Safe
{

    public class SafeScript : MonoBehaviour
    {

        public static bool num1;
        public static bool num2;
        public static bool num3;
        public static bool num4;
        public static bool num5;
        public static bool num6;
        public static bool num7;
        public static bool num8;
        public static bool num9;

        public static int inputs;
        public Animator OpenSafe;
        public Animator alma;

        public AudioClip doorOpen;
        public AudioClip denied;
        public AudioSource SafeDoor;
        public GameObject almarig;

        // Use this for initialization
        void Start()
        {
            num1 = false;
            num2 = false;
            num3 = false;
            num4 = false;
            num5 = false;
            num6 = false;
            num7 = false;
            num8 = false;
            num9 = false;
            inputs = 0;

        }

        // Update is called once per frame
        void Update()
        {
            if (inputs == 4)
            {
                if (num1 == true && num2 ==true && num3 == true && num9 == true)
                {
                    SafeDoor.clip = doorOpen;
                    OpenSafe.SetBool("open",true);
                    alma.SetBool("idle", true);
                    almarig.transform.localPosition = new Vector3(-8.257f, 0.006f, 2.819f);
                    SafeDoor.Play();
                    num1 = true;
                    num2 = true;
                    num3 = true;
                    num4 = true;
                    num5 = true;
                    num6 = true;
                    num7 = true;
                    num8 = true;
                    num9 = true;
                    inputs = 6;
                }
                else
                {
                    inputs = 0;
                    num1 = false;
                    num2 = false;
                    num3 = false;
                    num4 = false;
                    num5 = false;
                    num6 = false;
                    num7 = false;
                    num8 = false;
                    num9 = false;
                    SafeDoor.clip = denied;
                    SafeDoor.Play();
                }



            }
        }
    }
}
