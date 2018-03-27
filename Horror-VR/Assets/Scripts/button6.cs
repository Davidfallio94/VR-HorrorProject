using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Safe
{

    public class button6 : MonoBehaviour
    {

        public AudioSource door;
        public AudioClip beep;
        public Material rend;


        private void Start()
        {
            rend.shader = Shader.Find("Custom/OutlineShader");

        }


        // Update is called once per frame
        void Update()
        {
            if (SafeScript.num6 == false)
            {
                rend.SetColor("_OutlineColor", Color.red);
            }

            if (SafeScript.num6 == true)
            {
                rend.SetColor("_OutlineColor", Color.green);
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if ((SafeScript.num6 == false) && (other.tag == "finger"))
            {
                door.clip = beep;
                door.Play();
                SafeScript.num6 = true;
                SafeScript.inputs += 1;
            }

        }
    }
}

