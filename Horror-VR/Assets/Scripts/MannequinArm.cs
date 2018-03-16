using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games

{
    public class MannequinArm : MonoBehaviour
    {

        public GameObject collidedGameLeg;
        public MeshRenderer MeshMannequin;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "arm")
            {
                if (MannequinTorso.ManLeg == true)
                {
                    DestroyObject(collidedGameLeg);
                    MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    MannequinTorso.ManLeftArm = true;
                }
            }
        }
    }
}
