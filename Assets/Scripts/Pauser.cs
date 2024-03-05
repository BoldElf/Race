using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Pauser : MonoBehaviour
{
    public event UnityAction<bool> PauseStateChange;

    private bool isPaused;
    public bool IsPaused => isPaused;

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        UnPause();
    }

    public void ChangePauseState()
    {
        if(isPaused == true)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (isPaused == true) return;
        Time.timeScale = 0;
        isPaused = true;
        PauseStateChange?.Invoke(isPaused);
    }
    public void UnPause()
    {
        if (isPaused == false) return;
        Time.timeScale = 1;
        isPaused = false;
        PauseStateChange?.Invoke(isPaused);
    }
}
