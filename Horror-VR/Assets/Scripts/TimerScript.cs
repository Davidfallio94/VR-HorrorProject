using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    private float timeLeft;
    public GameObject Alma;
    private bool jumped;


	// Use this for initialization
	void Start () {
        timeLeft = 3.0f;
        jumped = false;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (jumped == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
        Alma.SetActive(true);
        timeLeft = 5.0f;
        jumped = true;



    }

}
