using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{

public class MannequinHand : MonoBehaviour {
    public GameObject collidedGameLeg;
    public MeshRenderer MeshMannequin;
    public GameObject theKey;
    public AudioSource ringing;


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
                    PuzzleManager.Manne = true;
                    ringing.Play();
                    ringing.loop = true;
                    Debug.Log("arm");
                }
            }
        }
    }
}
