using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    private GameObject GameUI; //get game UI object, need to disable on win
    private GameObject matchCompletedUI; //get gamecompletedUI object, need to enable on win

    private TMP_Text accuracyDisplay;//object to display score
    private TMP_Text scoreDisplay;//object to display gfrade, based on score

    private TMP_InputField playerNameField;//the tmp_inputfield for the name

    private CorrectCounter correctcounterScript; //instance of correctcounter, used to display the score on match complete
    private ScoreSaver scoreSaverScript;//instance of scoresaver script, used to save the score at game over

    private Button saveScoreButton;//button to save the players score to a file

    private bool matchComplete = false; //tracks if the match is completed
    private bool scoreCalculated = false;//tracks if the score has been calculated, so that it can only happen once
    private bool scoreStored = false;//tracks if the score has been stored, then disables the button
    public int calulatedIntValue;
    // Start is called before the first frame update
    void Start()
    {
        correctcounterScript = GameObject.Find("gameManager").GetComponent<CorrectCounter>();
        scoreSaverScript = GameObject.Find("gameManager").GetComponent<ScoreSaver>();
        accuracyDisplay = GameObject.Find("AccuracyDisplay").GetComponent<TMP_Text>();
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TMP_Text>();
        playerNameField = GameObject.Find("NameInput").GetComponent<TMP_InputField>();

        saveScoreButton = GameObject.Find("SaveScoreButton").GetComponent<Button>();
        
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
        if (correctcounterScript.currentTimeRemaining == 0)
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

            //if the pinputfield is empty, or if the score has already been stored, disable the button, else enable it
            if (playerNameField.text == "" || scoreStored)
            {
                saveScoreButton.interactable = false;
            }
            else
            {
                saveScoreButton.interactable = true;
            }
        }
    }

    private void ScoreDisplay()
    {
        accuracyDisplay.text = ("Accuracy: " + correctcounterScript.accuracyDisplay.text);//display exact score percent
        if (!scoreCalculated) //calculates the score
        {
            float calculatedScore = ((correctcounterScript.percentage /100f) * correctcounterScript.currentScore); //get the calculated score by multiplying the percentage correct by the score
            calulatedIntValue = Mathf.FloorToInt(calculatedScore); //round down to nearest integer to eliminate decimal
            scoreDisplay.text = ("Score: " + calulatedIntValue.ToString());//display exact calculated score
            //scoreSaverScript.AddNewScore(calulatedIntValue.ToString());//call the method used to store the score
            scoreCalculated = true;//now that we've calculated score, set the boolean to true, keeps score from updating once game over reached
        }
    }

    public void StoreTheScore()//called by a button
    {
        string temp = playerNameField.text;
        string temp2 = calulatedIntValue.ToString();
        scoreSaverScript.AddNewScore(temp2, temp);//call the method used to store the score, send it the name and the score
        scoreStored = true;
    }
}
