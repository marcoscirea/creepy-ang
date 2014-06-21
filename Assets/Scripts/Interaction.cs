using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    bool ended= false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (ended)
        {
            if (Input.anyKey){
                Application.LoadLevel("Level");
            }
        }
	}

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Creepy"))
        {
            if (collider.GetComponent<Creepy>().activated){
                Debug.Log("Dead");
                GetComponent<MouseLook>().enabled = false;
                GameObject.Find("Flashlight").transform.localPosition = Vector3.zero;
                Camera.main.GetComponent<SmoothLookAt>().enabled = true;
                Camera.main.GetComponent<SmoothLookAt>().target = collider.transform.Find("creepy/hips/spine/spine-1/chest/chest-1/neck/head").transform;
                GameObject.Find("EndScreen").GetComponent<EndScreen>().Dead();
                Timer();
                GameObject.Find("EndScreen").GetComponent<EndScreen>().Continue();
                ended = true;
            }
        }

        if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Escaped");
            GetComponent<MouseLook>().enabled = false;
            Camera.main.GetComponent<SmoothLookAt>().enabled = true;
            Camera.main.GetComponent<SmoothLookAt>().target = GameObject.FindGameObjectWithTag("Exit").transform;
            GameObject.Find("EndScreen").GetComponent<EndScreen>().Safe();
            Timer();
            GameObject.Find("EndScreen").GetComponent<EndScreen>().Continue();
            ended = true;
        }
    }

    IEnumerator Timer() //Blink every time.
    {
        yield return new WaitForSeconds(2);
    }
}
