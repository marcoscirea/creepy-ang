using UnityEngine;
using System.Collections;

public class TextFlicker : Flicker {
    
    Vector3 startingPosition;

    public override void doAwake(){
        renderer.enabled = false;
        startingPosition = transform.position;
    }

	public override void On(){
        renderer.enabled = true;
        transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
    }

    public override void Off(){
        renderer.enabled = false;
        transform.position = startingPosition + (UnityEngine.Random.insideUnitSphere * 0.1F);
    }

    void OnTriggerEnter(){
        Activate();
    }
    
    void OnTriggerExit(){
        Reset();
    }
}
