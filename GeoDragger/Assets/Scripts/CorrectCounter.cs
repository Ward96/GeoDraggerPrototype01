using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CorrectCounter : MonoBehaviour
{
    public float correctPercentage = 100; //displays the current correct percentage, used for scoring
    public float correctFlat = 0; //displays flat number of correct placed objects
    public float totalObjects = 9; //set in inspector, the total objects to be dragged

    public float totalGuesses = 0; //redundant, but nice for readability
    public float totalCorrectGuesses = 0;
    public float percentage; //gets the percentage

    public TMP_Text accuracyDisplay;
    public TMP_Text correctDisplay;
    private TMP_Text timerText;//object to display the timer
    public TMP_Text scoreText;

    private bool percentDisplayBool = false; //used so that theres no "NaN" displayed on game start

    public float startingTime;//starting time of the match
    public float currentTimeRemaining;//the current time remaining
    public float currentScore; //the float for the current score


    


    // Start is called before the first frame update
    void Start()
    {
        accuracyDisplay = GameObject.Find("Accuracy").GetComponent<TMP_Text>();
        correctDisplay = GameObject.Find("CorrectNum").GetComponent<TMP_Text>();
        timerText = GameObject.Find("Timer").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();


        accuracyDisplay.text =  "100%";
        UpdateDisplay();

        currentTimeRemaining = startingTime;//set the current time to starting time at start
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
        TimeCountdown();
    }

    private void UpdateDisplay()
    {
        UpdateDisplayBool();
        if (percentDisplayBool){
            percentage = (((totalCorrectGuesses / totalGuesses) * 100));//calculate the percentage and update the text
            accuracyDisplay.text = percentage.ToString("F1") + "%";
        }


        correctDisplay.text = (correctFlat + "/" + totalObjects).ToString();        //updatw the correct% display

        TimeScoreMathManager();//calls timescoremathmanager to manage the score, based on time remaining
    }

    private void UpdateDisplayBool()
    {
        if (totalGuesses >=1)
        {
            percentDisplayBool = true;
        }
    }

    private void TimeCountdown()
    {
        if (currentTimeRemaining > 0) //if theres more than 0 seconds remaining, reduce time
        {
            currentTimeRemaining -= Time.deltaTime;
            DisplayTime();
        }
        else
        {
            currentTimeRemaining = 0;
        }
    }
    private void TimeScoreMathManager()
    {
        float timeRemainingPercentage = (currentTimeRemaining / startingTime);//gets the percentage of the remaining time, used with Lerp
        currentScore = Mathf.Lerp(0, 5000, timeRemainingPercentage);//use lerp to interpolate between the maximum and minumum possible score, based on the percentage of time remaining
        int intValue = Mathf.FloorToInt(currentScore); //round down to nearest integer to eliminate decimal
        scoreText.text = intValue.ToString();
    }



    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(currentTimeRemaining / 60);//gets the largest int smaller than or equal to time/60, so if 170 seconds, would return 2
        float seconds = Mathf.FloorToInt(currentTimeRemaining % 60);// gets the largest int smaller than or equal to time % 60, so if 170 seconds, would return 50

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //formats the minutes and seconds into a string
    }
}
