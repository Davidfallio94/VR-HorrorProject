using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Exiting
{
    public class NailScript : MonoBehaviour
    {

       // public GameObject Alma;
        //public GameObject AlmaNav;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Crowbar")
            {
                if (this.gameObject.tag == "nail1")
                {
                    DoorScript.nail1 = true;
                }

                if (this.gameObject.tag == "nail2")
                {
                    DoorScript.nail2 = true;
                }

                if (this.gameObject.tag == "nail3")
                {
                    DoorScript.nail3 = true;
                }

                if (this.gameObject.tag == "nail4")
                {
                    DoorScript.nail4 = true;
                }

                if (this.gameObject.tag == "nail5")
                {
                    DoorScript.nail5 = true;
                }

                //Destroy(Alma);
               // AlmaNav.SetActive(true);
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}

