using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	public int duration = 7;
	private int counter; 
	// Use this for initialization
	void Start () {
		counter = duration;
	}
	
	// Update is called once per frame
	void Update () {
		counter --;
		if (counter < 0) {
			GameObject.Destroy(gameObject);
		}
	}
}
