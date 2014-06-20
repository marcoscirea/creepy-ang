using UnityEngine;
using System;
using System.Collections;

public class Flicker : MonoBehaviour
{
    float startingTime = 0;
    bool isStarted = false;
    bool hasBlinked = false;
    Vector3 startingPosition;

    bool activated = false;

    void Awake(){
        renderer.enabled = false;
        startingPosition = transform.position;
    }
    
    void Update()
    {
        if (activated)
        {
            if (!hasBlinked) //Check if the blinking occured already
            {
                if (!isStarted) //Check if the start time is set
                {
                    //Set start time
                    startingTime = Time.time;
                    isStarted = true;
                } else
                {
                    if ((Time.time - startingTime) >= 2) //Stop after 2 seconds
                    {
                        this.hasBlinked = true;
                        renderer.enabled = true;
                    } else //Blink
                    {
                        renderer.enabled = false;
                        transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
                        StartCoroutine(EnableRenderer());
                    }
                }
            }
        }
    }

    IEnumerator EnableRenderer() //Blink every time.
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.2f)); //Wait after each blink
        this.renderer.enabled = true;
        transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.2f)); //Wait after each blink
    }

    void OnTriggerEnter(){
        activated = true;
    }

    void OnTriggerExit(){
        activated = false;
        isStarted = false;
        hasBlinked = false;
        renderer.enabled = false;
    }
}