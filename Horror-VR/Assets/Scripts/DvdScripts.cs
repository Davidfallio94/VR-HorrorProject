using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvdScripts : MonoBehaviour
{

    private bool Locked;
    public GameObject TvPlane;
    public GameObject Dvd;
    public GameObject Crowbar;
    public Material rend;

    public Animator box;
    public GameObject screen;
    public GameObject particles;


    void Start()
    {
        rend.shader = Shader.Find("Shaders/TVStatic");
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Dvd")
        {

            Destroy(Dvd);
            rend.shader = Shader.Find("Standard");
            screen.transform.localPosition = new Vector3(-0.03f, 0f, 0f);
            TvPlane.SetActive(true);

            box.SetBool("open",true);
            Crowbar.SetActive(true);
            particles.SetActive(true);

        }
    }
}
