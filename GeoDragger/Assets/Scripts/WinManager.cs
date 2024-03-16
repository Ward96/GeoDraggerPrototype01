using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    private GameObject GameUI; //get game UI object, need to disable on win
    private GameObject matchCompletedUI; //get gamecompletedUI object, need to enable on win

    private TMP_Text scoreDisplay;//object to display score
    private TMP_Text gradeDisplay;//object to display gfrade, based on score

    private CorrectCounter correctcounterScript; //instance of correctcounter, used to display the score on match complete

    private bool matchComplete; //tracks if the match is completed
    // Start is called before the first frame update
    void Start()
    {
        correctcounterScript = GameObject.Find("gameManager").GetComponent<CorrectCounter>();
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TMP_Text>();
        gradeDisplay = GameObject.Find("Grade").GetComponent<TMP_Text>();
        GameUI = GameObject.Find("GameView"); //initialize
        matchCompletedUI = GameObject.Find("WinMenu"); //initialize
        matchCompletedUI.SetActive(false); //set false on start
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfMatchComplete();
        DisplayMatchComplete();
    }

    private void CheckIfMatchComplete() //checks if all objects have been matched
    {
        if (correctcounterScript.correctFlat == correctcounterScript.totalObjects)
        {
            matchComplete = true;
        }
    }

    private void DisplayMatchComplete()
    {
        if (matchComplete) //if match is complete, start match complete stuff
        {
            matchCompletedUI.SetActive(true);
            GameUI.SetActive(false);
            ScoreDisplay();
        }
    }

    private void ScoreDisplay()
    {
        scoreDisplay.text = ("Score: " + correctcounterScript.percentDisplay.text);//display exact score percent
        if(correctcounterScript.percentage > 90) //ifs to determine grade
        {
            gradeDisplay.text = "Grade: A";
        }
        else if(correctcounterScript.percentage > 80)
        {
            gradeDisplay.text = "Grade: B";
        }
        else if (correctcounterScript.percentage > 70)
        {
            gradeDisplay.text = "Grade: C";
        }
        else if (correctcounterScript.percentage > 60)
        {
            gradeDisplay.text = "Grade: D";
        }
        else
        {
            gradeDisplay.text = "Grade: D";
        }
    }
}
