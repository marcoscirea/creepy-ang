using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

    Vector3 startingPosition;
    Vector3 target;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
        target = startingPosition + (Vector3.up * Random.Range(-0.2f, 0.2f));
        Debug.Log(target);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Distance(transform.position, target));
        if (Vector3.Distance(transform.position, target) > 0.01f)
        {
            float speed = Vector3.Distance(transform.position, target);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        } else
        {
            target = startingPosition + (Vector3.up * Random.Range(-0.2f, 0.2f));
        }
	}
}
