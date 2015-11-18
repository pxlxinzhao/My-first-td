using UnityEngine;
using System.Collections;

public class GV : MonoBehaviour {
	
	public int wave = 1;
	public int monster_amount = 0;
	public int lives = 10;
	public float score = 0;
	public int HP = 9999;
	public Vector3 velocity;

	public static GV instance;
	
	//When the object awakens, we assign the static variable
	void Awake() 
	{
//		instance = this;
	}

	public static GV getInstance(){
		if (instance == null) {
			instance = GameObject.FindObjectOfType<GV>();
			Debug.Log (instance == null);
		} 
		return instance;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
