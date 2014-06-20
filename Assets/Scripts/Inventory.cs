using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Add(string item){
        inventory.Add(item);
    }

    public bool Has(string item){
        if (inventory.Contains(item))
        {
            return true;
        } else
        {
            return false;
        }
    }
}
