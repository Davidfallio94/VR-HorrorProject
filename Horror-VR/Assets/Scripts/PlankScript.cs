using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exiting {

    public class PlankScript : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if ((DoorScript.nail1 == true) && (DoorScript.nail2 == true) && (DoorScript.nail3 == true))
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
