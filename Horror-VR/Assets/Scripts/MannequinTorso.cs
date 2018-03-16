using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{

    public class MannequinTorso : MonoBehaviour
    {

        public GameObject collidedGameLeg;
        public MeshRenderer MeshMannequin;


        [SerializeField]
        public static bool ManTorso;
        public static bool ManLeftArm;
        public static bool ManLeg;
        public static bool ManRightArm;
        public static bool ManHand;



        // Use this for initialization
        void Start()
        {

            ManTorso = false;
            ManLeftArm = false;
            ManLeg = false;
            ManRightArm = false;
            ManHand = false;

        }


    private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "torso")
            {

                DestroyObject(collidedGameLeg);
                MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                ManTorso = true;
            }
        }
    }
}
