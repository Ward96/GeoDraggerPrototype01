using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectCounter : MonoBehaviour
{
    public float correctPercentage = 100; //displays the current correct percentage, used for scoring
    public float correctFlat = 0; //displays flat number of correct placed objects
    public float totalObjects = 9; //set in inspector, the total objects to be dragged

    public float totalGuesses = 0; //redundant, but nice for readability
    public float totalCorrectGuesses = 0;
    public float percentage; //gets the percentage

    public TMP_Text percentDisplay;
    public TMP_Text scoreDisplay;

    private bool percentDisplayBool = false; //used so that theres no "NaN" displayed on game start


    


    // Start is called before the first frame update
    void Start()
    {
        percentDisplay = GameObject.Find("Percent").GetComponent<TMP_Text>();
        scoreDisplay = GameObject.Find("CorrectNum").GetComponent<TMP_Text>();


        percentDisplay.text =  "100%";
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        UpdateDisplayBool();
        if (percentDisplayBool){
            percentage = (((totalCorrectGuesses / totalGuesses) * 100));//calculate the percentage and update the text
            percentDisplay.text = percentage.ToString("F1") + "%";
        }


        scoreDisplay.text = (correctFlat + "/" + totalObjects).ToString();        //updatw the score display
    }

    private void UpdateDisplayBool()
    {
        if (totalGuesses >=1)
        {
            percentDisplayBool = true;
        }
    }
}
