using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour
{

    public Vector3 originalPosition;
    GameObject objectToDrag;
    string objectTag; 
    GameObject dragObjective;
    float distance;

    CorrectCounter correctcounterScript; //instance of CreateCounter script, we will increment the # of correct object placements
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; //set the original position of the gameObject
        correctcounterScript = GameObject.Find("gameManager").GetComponent<CorrectCounter>();   //get the script CorrectCounter
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drag()
    {
        gameObject.transform.position = Input.mousePosition;
    }


    public void Drop()
    {
        checkMatch();
    }

    public void checkMatch()
    {
        objectToDrag = gameObject; //sets object to grab as the current game object
        objectTag = gameObject.tag; //get the tag of the current game object, this will "link" it with the dragObjective
        dragObjective = GameObject.FindWithTag(objectTag);

        distance = Vector3.Distance(dragObjective.transform.position, objectToDrag.transform.position);

        if (distance <= 50)
        {
            snap(objectToDrag, dragObjective);
            dragObjective.SetActive(false); //set the objkective location to false, just ot hide it, useful in cases like statue of liberty
            clearEventTriggers(objectToDrag);
            correctcounterScript.correctFlat += 1;
            correctcounterScript.totalCorrectGuesses += 1;
            correctcounterScript.totalGuesses += 1;
        }
        else
        {
            moveBack();
            correctcounterScript.totalGuesses += 1;
        }

    }

    public void moveBack()
    {
        transform.position = originalPosition;
    }

    public void snap(GameObject objectToDrag, GameObject dragObjective)
    {
        objectToDrag.transform.position = dragObjective.transform.position;
    }

    public void clearEventTriggers(GameObject objectToDrag) //this method clears event triggers so that once an object is correctly placed, it cannot be interacted with again
    {
        EventTrigger eventTrigger = objectToDrag.GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            eventTrigger.triggers.Clear();
        }
    }
}
