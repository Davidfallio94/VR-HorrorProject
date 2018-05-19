using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour {

    public Button Play, Quit;

    void Start()
    {
        Button btn = Play.GetComponent<Button>();
        Button btn2 = Quit.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn.onClick.AddListener(PlayClick);
        btn2.onClick.AddListener(QuitClick);
    }

    void PlayClick()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Game");
    }

    void QuitClick()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

