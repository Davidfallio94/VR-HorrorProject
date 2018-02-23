using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace control
{

    public class Keypress : MonoBehaviour
    {
        //Fetch the Animator
        Animator m_Animator;
        // Use this for deciding if the GameObject can jump or not
        public static bool keypress;
        public static bool keypressL;


        void Start()
        {
            //This gets the Animator, which should be attached to the GameObject you are intending to animate.
            m_Animator = gameObject.GetComponent<Animator>();
            // The GameObject cannot jump
            keypress = false;
            keypressL = false;
        }

        void Update()
        {

            
            {
                m_Animator.SetBool("keypress", false);
            }
           
            if (keypress == true)
            {
                m_Animator.SetBool("keypress", true);
                Debug.Log(keypress);
            }

            if (keypressL == false)
            {
                m_Animator.SetBool("keypressL", false);
            }

            {
                m_Animator.SetBool("keypressL", true);
                Debug.Log(keypress);
            }
        }
    }
}
