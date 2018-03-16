using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Games

{
    public class MannequinScript : MonoBehaviour
    {


        public GameObject collidedGameLeg;
        public MeshRenderer MeshMannequin;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "leg")
            {
                if (MannequinTorso.ManTorso == true)
                {
                    DestroyObject(collidedGameLeg);
                    MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    MannequinTorso.ManLeg = true;
                }
            }
        }
    }
}
