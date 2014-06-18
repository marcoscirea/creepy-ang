using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

    ArrayList enemies = new ArrayList();

    float fieldOfViewRange= 60f;

	// Use this for initialization
	void Start () {
	    foreach (GameObject g in GameObject.FindGameObjectsWithTag("Creepy"))
        {
            enemies.Add(g);
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject g in enemies)
        {
            RaycastHit hit;
            Vector3 rayDirection = (g.transform.position - transform.position).normalized;

            Debug.Log(Vector3.Angle(rayDirection, transform.forward));
            if((Vector3.Angle(rayDirection, transform.forward)) < fieldOfViewRange){ // Detect if player is within the field of view
                if (Physics.Raycast (transform.position, rayDirection, out hit)) {
                    Debug.DrawRay(transform.position,rayDirection);
                    Debug.Log(hit.transform.name);
                    if (hit.transform.tag == "Creepy") {
                        //Debug.Log("Can see enemy");
                        g.GetComponent<Creepy>().Freeze();
                    }else{
                        //Debug.Log("Can not see enemy");
                        g.GetComponent<Creepy>().Resume();
                    }
                }else{
                    //Debug.Log("Can not see enemy");
                    g.GetComponent<Creepy>().Resume();
                }
            }else{
                //Debug.Log("Can not see enemy");
                g.GetComponent<Creepy>().Resume();
            }
        }
	}
}
