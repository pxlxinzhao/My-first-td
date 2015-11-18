using UnityEngine;
using System.Collections;

public class BigExplosion : MonoBehaviour {

	public int duration = 17;
	int counter;
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
