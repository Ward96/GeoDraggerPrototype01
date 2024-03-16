using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private GameObject GameUI; //get game UI object
    private GameObject PauseUI;//get pauseUi object
    // Start is called before the first frame update
    void Start()
    {
        GameUI = GameObject.Find("GameView"); //initialize
        PauseUI = GameObject.Find("PauseMenu");//initializa
        PauseUI.SetActive(false); //set pause to false on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame() //pause game function, sets gameUI to false, and pause to true
    {
        GameUI.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void ResumeGame()//resume game sets gameUI true and pause to false
    {
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
    }
    public void RestartGame() //gets acrive scene and loads it, to restart the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
