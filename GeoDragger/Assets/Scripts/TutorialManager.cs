using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private GameObject MainMenuUI;
    private GameObject TutorialUI;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI = GameObject.Find("MainMenu"); //initialize
        TutorialUI = GameObject.Find("Tutorial");//initialize
        TutorialUI.SetActive(false); //set false on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTutorial()
    {
        MainMenuUI.SetActive(false);
        TutorialUI.SetActive(true);
    }
    public void CloseTutorial()
    {
        MainMenuUI.SetActive(true);
        TutorialUI.SetActive(false);
    }
}
