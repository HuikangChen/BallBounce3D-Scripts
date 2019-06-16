﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameLevel;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameLevel);
    }
}
