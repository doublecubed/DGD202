using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToTheMenu();
        }
    }

    public void GoToTheMenu()
    {
        SceneManager.LoadScene(0);
    }
}
