using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games

{


    public class MannequinForearm : MonoBehaviour
    {

        public GameObject collidedGameLeg;
        public MeshRenderer MeshMannequin;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "forearm")
            {
                if (MannequinTorso.ManLeftArm == true)
                {
                    DestroyObject(collidedGameLeg);
                    MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    MannequinTorso.ManRightArm = true;
                }
            }
        }
    }
}

