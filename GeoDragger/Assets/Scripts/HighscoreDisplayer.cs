using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class HighscoreDisplayer : MonoBehaviour
{
    public TMP_Text HighScores;
    public int num_scores = 5;

    void Start()
    {
        LevelScoresToDisplay();//call the levelscorestodisplay on start so we know what levels we're displayinh, does nothing as of now, but will when there are multiple levels
        ShowTopScores("nothing");
    }
    public void ShowTopScores(string fileName)
    {
        string path = "Assets/" + "USMonuments" + ".txt";//the file path to store the file, 
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;

        HighScores.text = ""; // clear the scores box

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores.text += fields[0] + " : " + fields[1] + "\n";
            scores_read += 1;
        }

    }

    public void LevelScoresToDisplay() //not needed now, but will be needed when there are multiple levels, internal logic may change
    {
        string savedPlayerPrefString = PlayerPrefs.GetString("HighScoreSwitcher");//gets the string for high score switcher to determine which levels scores to display
        if (savedPlayerPrefString == "USMonuments")
        {
            ShowTopScores("USMonuments");
        }
    }
}
