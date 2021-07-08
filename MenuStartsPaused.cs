using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStartsPaused : MonoBehaviour
{
    static bool _isPaused;

    public static bool isPaused() => _isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseTheGame();
    }

    public static void PauseTheGame()
    {
        _isPaused = true;
    }
    
    void UnPauseTheGame()
    {
        _isPaused = false;
        var canvasforMenus = GetComponentInChildren<Canvas>();
        canvasforMenus.enabled = false;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            UnPauseTheGame();
        }
    }

    // Update is called once per frame
}
