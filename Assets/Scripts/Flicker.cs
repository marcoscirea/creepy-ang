using UnityEngine;
using System;
using System.Collections;

public abstract class Flicker : MonoBehaviour
{
    float startingTime = 0;
    bool isStarted = false;
    bool hasBlinked = false;

    public float lenght = 2f;
    public bool infinite = false;
    public bool activated = false;

    void Awake(){
        doAwake();
    }

    public abstract void doAwake();

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
                    if (!infinite && (Time.time - startingTime) >= lenght) //Stop after 2 seconds
                    {
                        this.hasBlinked = true;
                        //renderer.enabled = true;
                        On();
                    } else //Blink
                    {
                        //renderer.enabled = false;
                        //transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
                        Off();
                        StartCoroutine(EnableRenderer());
                    }
                }
            }
        }
    }

    IEnumerator EnableRenderer() //Blink every time.
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.2f)); //Wait after each blink
        //this.renderer.enabled = true;
        //transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
        On();
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.2f)); //Wait after each blink
    }

    public abstract void Off();

    public abstract void On();

    public void Activate(){
        activated = true;
    }
    
    public void Reset(){
        activated = false;
        isStarted = false;
        hasBlinked = false;
        Off();
    }

}