using UnityEngine;
using System.Collections;

public class CreepyTrigger : MonoBehaviour {

    public GameObject[] toActivate;

	void OnTriggerEnter(){
        foreach (GameObject g in toActivate)
        {
            g.GetComponent<Creepy>().activated=true;
        }
        Destroy(gameObject);
    }
}
