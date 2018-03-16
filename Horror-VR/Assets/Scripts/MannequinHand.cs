using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{

public class MannequinHand : MonoBehaviour {
    public GameObject collidedGameLeg;
    public MeshRenderer MeshMannequin;
    public GameObject theKey;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "hand")
            {

                if (MannequinTorso.ManTorso == true)
                {
                    DestroyObject(collidedGameLeg);
                    MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    MannequinTorso.ManLeg = true;
                    theKey.SetActive(true);
                    Games.PuzzleManager.Manne = true;
                }


            }
        }
    }
}
