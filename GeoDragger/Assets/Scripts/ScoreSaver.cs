using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSaver : MonoBehaviour
{
    public InputField NewScore;//DELETE
    public TMP_InputField NewName;//the tmp_inputfield for the name
    public int num_scores = 5;//the max number of scores
    public string fileName;//the name of the file, to be set in inspector for different levels
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewScore(string importedScore, string importedName)
    {
        string path = "Assets/" + fileName + ".txt";//the file path to store the file, 
        string line; //the line of text that gets read from the file
        string[] fields; //fields at [0] will be name, at [1] will be score
        int scores_written = 0; //counter fot the number of scores written
        string newName = "don't forget to input";
        string newScore = "999";
        bool newScoreWritten = false;
        string[] writeNames = new string[5];
        string[] writeScores = new string[5];

        newName = importedName;//set name to the imported name
        newScore = importedScore;//set score to the imported score
        //print(importedName);
        //print(importedScore);

        StreamReader reader = new StreamReader(path); //initialize streamreader to read from file
        while (!reader.EndOfStream)//lloop until the end of the file has been reached
        {
            line = reader.ReadLine();//read one lne from the file
            fields = line.Split(',');//splits the line by the comma, will set the name to fields[0] and the score to fields[1]
            if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
            {
                //check if we need to write new higher score first
                if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))//fields at 1 is the stored score, so compare newscore to stored score in "fields[1]"
                {
                    writeNames[scores_written] = newName;//since newscore is higher than the stored score, write it and name to the corresponding arrays
                    writeScores[scores_written] = newScore;
                    newScoreWritten = true; //set newscorewritten to true, since we've written a score
                    scores_written += 1; //increment scoreswritten
                }

            }
            if (scores_written < num_scores) // we have not written enough lines yet, if score is not higher, then we keep the current score and name set in the current line
            {
                writeNames[scores_written] = fields[0];
                writeScores[scores_written] = fields[1];
                scores_written += 1;
            }
        }
        reader.Close();

        // now we have parallel arrays with names and scores to write
        StreamWriter writer = new StreamWriter(path); //initialize streamwriter to write to file

        for (int x = 0; x < scores_written; x++)//for loop to loop until number of scores written
        {
            writer.WriteLine(writeNames[x] + ',' + writeScores[x]);//write a line using the data stored in the two arrays, seperate them by comma so they can be split later
        }
        writer.Close(); //close the streamwriter


        //are either of these needed?
        //AssetDatabase.ImportAsset(path); //import the asset at the path
        //TextAsset asset = (TextAsset)Resources.Load("scores"); //load the text asst "scores"

    }
}
