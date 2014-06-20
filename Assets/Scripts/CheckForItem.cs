using UnityEngine;
using System.Collections;

public class CheckForItem : MonoBehaviour {

    public string necessaryItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Inventory>().Has(necessaryItem))
                Destroy(gameObject);
        }
    }
}
