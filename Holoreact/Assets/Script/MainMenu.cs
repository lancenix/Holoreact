﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// this script is used to manage MainMenu scene
/// </summary>

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    public Button playButton, yesQuitButton;
    [SerializeField]
    public Canvas quitNotificationCanvas, mainMenuCanvas, studentDataCanvas;

    private int lvl;
    
    public bool isFirstPlay = true;
    
    GameObject highlightedButton, highlightedButton2;

    // Start is called before the first frame update
    void Start()
    {
        ToggleNotification(false, true, playButton);
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuNavigation();
    }

    private void MainMenuNavigation()
    {
        highlightedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("highlighted button " + highlightedButton.name);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //MainMenu Navigation
            switch (highlightedButton.name)
            {
                case "Play":
                    SceneManager.LoadScene("ChooseLevel");
                    break;
                case "Settings":
                    break;
                case "Credits":
                    break;
                case "Quit":
                    //Open Notification Canvas
                    ToggleNotification(true, false, yesQuitButton);
                    break;
            }
        }


        if (quitNotificationCanvas.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (highlightedButton.name)
                {
                    case "YesQuit":
                        print("Game Quits");
                        Application.Quit();
                        break;
                    case "NoQuit":
                        ToggleNotification(false, true, playButton);
                        break;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleNotification(false, true, playButton);
            }
        }
    }

    private void ToggleNotification(bool isNotifOn, bool isMainMenuOn, Button toHighlight)
    {
        quitNotificationCanvas.gameObject.SetActive(isNotifOn);
        mainMenuCanvas.gameObject.SetActive(isMainMenuOn);
        toHighlight.Select();
    }
}
