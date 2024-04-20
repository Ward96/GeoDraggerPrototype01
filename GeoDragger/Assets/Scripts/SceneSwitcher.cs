using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void US_Monuments()
    {
        SceneManager.LoadScene("US_Monuments");
        PlayerPrefs.SetString("HighScoreSwitcher", "USMonuments");//set a playerpref string so that the high score menu knows what high score file to use, will be needed in a later build
    }

    public void HighScoresScreen()
    {
        SceneManager.LoadScene("HighScores");
    }
}
