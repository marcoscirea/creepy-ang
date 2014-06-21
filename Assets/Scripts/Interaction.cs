using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    public bool ended= false;
    float timerStart;
    float timerLenght = 4f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (ended)
        {
            
            if (Time.time > timerStart + timerLenght)
            {
                GameObject.Find("EndScreen").GetComponent<EndScreen>().Continue();

                if (Input.anyKey){
                    Application.LoadLevel("Level");
                }
            }
        }
	}

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Creepy"))
        {
            if (!collider.GetComponent<Creepy>().seen){
                Debug.Log("Dead");
                GetComponent<MouseLook>().enabled = false;
                GetComponent<CharacterMotor>().enabled = false;
                GameObject.Find("Flashlight").transform.localPosition = Vector3.zero;
                Camera.main.GetComponent<SmoothLookAt>().enabled = true;
                Camera.main.GetComponent<SmoothLookAt>().target = collider.transform.Find("creepy/hips/spine/spine-1/chest/chest-1/neck/head").transform;
                GameObject.Find("EndScreen").GetComponent<EndScreen>().Dead();
                timerStart = Time.time;
                ended = true;
            }
        }

        if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Escaped");
            GetComponent<MouseLook>().enabled = false;
            GetComponent<CharacterMotor>().enabled = false;
            Camera.main.GetComponent<SmoothLookAt>().enabled = true;
            Camera.main.GetComponent<SmoothLookAt>().target = GameObject.FindGameObjectWithTag("Exit").transform;
            GameObject.Find("EndScreen").GetComponent<EndScreen>().Safe();
            timerStart = Time.time;
            ended = true;
        }
    }

}
