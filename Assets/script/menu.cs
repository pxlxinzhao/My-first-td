using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Play Game")) {
			Debug.Log("Play");
			Application.LoadLevel("main_scene");
		}
	}

	void Start(){

	}

	void Update(){

	}
}
