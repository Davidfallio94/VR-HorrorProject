using System.Collections;
using UnityEngine;

namespace control
{

    public class Skinburncontrol : MonoBehaviour
    {
        public static bool grabbed;
        public Material rend;
        private bool burn;
        float fallaway = 0;


        void Start()
        {
            //rend = GetComponent<Material>();
            rend.shader = Shader.Find("Custom/SkinBurning");
            Debug.Log(rend.shader);
            grabbed = false;
            rend.SetFloat("_Threshold", 0);
            burn = false;
        }
        void Update()
        {
            if (burn == true)
            {
               
                    fallaway = fallaway + 0.0007f;
                    rend.SetFloat("_Threshold", fallaway);
                    Debug.Log("blazing");
               
               
            }

           
            
                if (burn == false && fallaway > 0.0f)
                {
                    fallaway = fallaway - 0.001f;
                    rend.SetFloat("_Threshold", fallaway);
                Debug.Log("begone");
                }

                if (fallaway < 0)
            {
                fallaway = 0;
                rend.SetFloat("_Threshold", fallaway);
            }
                
            }


        private void OnTriggerEnter(Collider other)
        {
           
                if (other.tag == "burn")
                {
                    burn = true;
                    Debug.Log("burn baby burn");
                }
            
        }

        private void OnTriggerExit(Collider other)
        {
           
                if (other.tag == "burn")
                {
                    grabbed = false;
                    burn = false;
                    Debug.Log("extinguished");
                }
            
        }

    }
}
