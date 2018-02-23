using System.Collections;
using UnityEngine;

namespace control
{

    public class Skinburncontorl : MonoBehaviour
    {
        public static bool grabbed;
        public Renderer rend;


        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("SkinBurning");
            grabbed = false;

        }
        void Update()
        {

            if (grabbed = true)
            {
                //float fallaway = fallaway + 0.01;
              //  rend.material.SetFloat("_Threshold", fallaway);
            }
            else grabbed = false;
        }
    }
}