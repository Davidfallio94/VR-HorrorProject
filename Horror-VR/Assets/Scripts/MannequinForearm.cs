using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinForearm : MonoBehaviour {

    public GameObject collidedGameLeg;
    public MeshRenderer MeshMannequin;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forearm")
        {

            DestroyObject(collidedGameLeg);
            MeshMannequin.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
}
