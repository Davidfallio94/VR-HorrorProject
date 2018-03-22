using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour {

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AcHands")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
