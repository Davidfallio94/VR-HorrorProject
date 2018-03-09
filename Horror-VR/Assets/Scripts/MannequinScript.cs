using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinScript : MonoBehaviour {


   public GameObject collidedGameLeg;
   public MeshRenderer MeshMannequin;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leg")
        {
           
            DestroyObject(collidedGameLeg);
            MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
}
