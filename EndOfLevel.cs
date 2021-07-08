using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public GameObject canvasDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Update Score
        Score.SaveOutNewHighscore();
        
        Debug.Log("EndingTrigger?");
        Cursor.visible = true;
        Screen.lockCursor = false;
        MenuStartsPaused.PauseTheGame();
        StartEndMenuUp();
    }

    public void StartEndMenuUp()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvasDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
