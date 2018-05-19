using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarScript : MonoBehaviour
{

    public GameObject Alma;
    public GameObject AlmaPissed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AcHands")
        {
            Destroy(Alma);
            AlmaPissed.SetActive(true);
        }

    }
}
