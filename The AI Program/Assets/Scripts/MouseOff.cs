using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame

	public void quitGame(){
		if (Input.GetKey ("escape")) {
                 Application.Quit();
                }
	}
	void Update()
	{

		quitGame();
	}

}
