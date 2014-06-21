using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Creepy"))
        {
            if (collider.GetComponent<Creepy>().activated){
                Debug.Log("Dead");
                GetComponent<MouseLook>().enabled = false;
                Camera.main.GetComponent<SmoothLookAt>().enabled = true;
                Camera.main.GetComponent<SmoothLookAt>().target = collider.transform.Find("creepy/hips/spine/spine-1/chest/chest-1/neck/head").transform;
                GameObject.Find("EndScreen").GetComponent<EndScreen>().Dead();
            }
        }

        if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Escaped");
            GetComponent<MouseLook>().enabled = false;
            Camera.main.GetComponent<SmoothLookAt>().enabled = true;
            Camera.main.GetComponent<SmoothLookAt>().target = GameObject.FindGameObjectWithTag("Exit").transform;
            GameObject.Find("EndScreen").GetComponent<EndScreen>().Safe();
        }
    }
}
