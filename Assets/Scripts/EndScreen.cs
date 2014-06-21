using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

    static GUIText gameOver;
    static GUIText escape;

	// Use this for initialization
	void Start () {
        gameOver = transform.FindChild("GameOver").guiText;
        escape = transform.FindChild("Escape").guiText;
	}
	
    public void Dead(){
        gameOver.enabled = true;
        Time.timeScale = 0;
    }

    public void Safe(){
        escape.enabled = true;
        Time.timeScale = 0.1f;
    }
}
