using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

    static GUIText gameOver;
    static GUIText escape;
    static GUIText cont;

	// Use this for initialization
	void Start () {
        gameOver = transform.FindChild("GameOver").guiText;
        escape = transform.FindChild("Escape").guiText;
        cont = transform.FindChild("Continue").guiText;
	}
	
    public void Dead(){
        gameOver.enabled = true;
        //Time.timeScale = 0;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Creepy"))
        {
            g.GetComponent<Creepy>().activated=false;
        }
    }

    public void Safe(){
        escape.enabled = true;
        //Time.timeScale = 0f;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Creepy"))
        {
            g.GetComponent<Creepy>().activated=false;
        }
    }

    public void Continue(){
        cont.enabled = true;
    }
}
