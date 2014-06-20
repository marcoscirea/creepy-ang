using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    public float dither_min = 2f;
    public float dither_max = 5f;
    float dither_start;
    public float dither_speed = 0.5f;
    bool dither_grow = true;

    public float cutoff_min = 0.2f;
    public float cutoff_max = 0.7f;
    float cutoff_start;
    public float cutoff_speed = 0.5f;
    bool cutoff_grow = true;

	// Use this for initialization
	void Start () {
        dither_start = Time.time;
        cutoff_start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (renderer.material.GetFloat("_DitherSize") == dither_max || renderer.material.GetFloat("_DitherSize") == dither_min)
        {
            dither_start = Time.time - 0.01f;
            dither_grow = !dither_grow;
        }
        if (dither_grow)
            renderer.material.SetFloat("_DitherSize", Mathf.Lerp(dither_min, dither_max, (Time.time - dither_start) * dither_speed));
        else
            renderer.material.SetFloat("_DitherSize", Mathf.Lerp(dither_max, dither_min, (Time.time - dither_start) * dither_speed));
	    
        if (renderer.material.GetFloat("_Cutoff") == cutoff_max || renderer.material.GetFloat("_Cutoff") == cutoff_min)
        {
            cutoff_start = Time.time - 0.01f;
            cutoff_grow = !cutoff_grow;
        }
        if (cutoff_grow)
            renderer.material.SetFloat("_Cutoff", Mathf.Lerp(cutoff_min, cutoff_max, (Time.time - cutoff_start) * cutoff_speed));
        else
            renderer.material.SetFloat("_Cutoff", Mathf.Lerp(cutoff_max, cutoff_min, (Time.time - cutoff_start) * cutoff_speed));

    }
}
