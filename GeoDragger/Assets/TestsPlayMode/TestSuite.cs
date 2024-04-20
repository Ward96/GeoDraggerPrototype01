using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestSuiteSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MonumentLocationLoads()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator MonumentLoads()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator ScoreCalculatesCorrectly()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator TimerCountsCorrectly()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator GamePausesCorrectly()
    {
        yield return null;
    }
    [UnityTest]
    public IEnumerator ScoreSavesCorrectly()
    {
        yield return null;
    }
}
