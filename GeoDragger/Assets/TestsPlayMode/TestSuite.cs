using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestSuite
{

    [Test]
    public void TestSuiteSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    [UnityTest]
    public IEnumerator MonumentLocationLoads()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(.5f);//pass time .5 seconds

        GameObject theMonumentLocation = GameObject.Find("Monument1Location");//search for the monument location

        Assert.IsNotNull(theMonumentLocation); //assert that it exists in the game scene
    }

    [UnityTest]
    public IEnumerator MonumentLoads()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(.5f);//pass time .5 seconds

        GameObject theMonument = GameObject.Find("Monument1");//search for the monument

        Assert.IsNotNull(theMonument); //assert that it exists in the game scene
    }

    [UnityTest]
    public IEnumerator MonumentLocationsSnapCorrectly()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(1f);//pass time .5 seconds

        GameObject theMonumentLocation = GameObject.Find("Monument1Location");//search for the monument location
        GameObject theMonument = GameObject.Find("Monument1");//search for the monument

        theMonument.GetComponent<DragController>().snap(theMonumentLocation, theMonument);//call snap from the drag controller

        yield return new WaitForSeconds(1f);//pass time .5 seconds

        Assert.IsTrue(theMonumentLocation.transform.position == theMonument.transform.position); //assert that the locations are euqal after snapping
    }

    [UnityTest]
    public IEnumerator MonumentMovesBackCorrectly()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(1f);//pass time .5 seconds

        GameObject theMonumentLocation = GameObject.Find("Monument1Location");//search for the monument location
        GameObject theMonument = GameObject.Find("Monument1");//search for the monument

        Vector3 originalPosition = theMonument.transform.position;//get the original position of the monument

        theMonument.GetComponent<DragController>().snap(theMonumentLocation, theMonument);//call snap from the drag controller to move the objects
        theMonument.GetComponent<DragController>().moveBack();//call moveback to move the moment mack

        yield return new WaitForSeconds(1f);//pass time .5 seconds

        Assert.IsTrue(theMonument.transform.position == originalPosition) ; //assert that the locations are euqal after snapping
    }

    [UnityTest]
    public IEnumerator ScoreCalculatesCorrectly()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(.5f);//pass time .5 seconds

        GameObject theManager = GameObject.Find("gameManager");//search for the game manager that controls the score

        yield return new WaitForSeconds(10f);//pause ten seconds to let the score drop

        float theScore = theManager.GetComponent<CorrectCounter>().currentScore; //get the score in a float for readability

        Assert.IsTrue(theScore < 5000 && theScore > 4500);//check to see that the score is less than 5000, and more than 4500, indicating its dropping at the proper rate
    }

    [UnityTest]
    public IEnumerator TimerCountsCorrectly()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(1f);//pass time 1 seconds

        GameObject theManager = GameObject.Find("gameManager");//search for the game manager that controls the time

        yield return new WaitForSeconds(9f);//pause 8.5 seconds

        float theTime = theManager.GetComponent<CorrectCounter>().currentTimeRemaining; //get the time in a float for readability

        Assert.IsTrue(theTime >169 && theTime <171);//check to see that the time is within a second of ten seconds passing
    }

    [UnityTest]
    public IEnumerator GamePausesCorrectly()
    {
        SceneManager.LoadScene("US_Monuments");//load game scene
        yield return new WaitForSeconds(1f);//pass time 1 seconds

        GameObject thePauseButton = GameObject.Find("PauseButton");//search for the pause button
        thePauseButton.GetComponent<Button>().onClick.Invoke();//click the pause button

        yield return new WaitForSeconds(1f);//pass time 1 seconds
        GameObject thePauseUI = GameObject.Find("PauseMenu");//search for the pause menu

        Assert.IsTrue(thePauseUI);//assert that thepauseui is true, meaning the game has been paused

    }
    [UnityTest]
    public IEnumerator ScoreSavesCorrectly()
    {
        yield return null;
    }
}
