﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().Add(name);
            Destroy(gameObject);
        }
    }
}
