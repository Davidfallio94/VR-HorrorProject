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
        

        void Start()
        {
            //This gets the Animator, which should be attached to the GameObject you are intending to animate.
            m_Animator = gameObject.GetComponent<Animator>();
            // The GameObject cannot jump
            keypress = false;
        }

        void Update()
        {

            //If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
            if (keypress == false)
            {
                m_Animator.SetBool("keypress", false);
            }


            //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
            if (keypress == true)
            {
                m_Animator.SetBool("keypress", true);
                Debug.Log(keypress);
            }
        }
    }
}
