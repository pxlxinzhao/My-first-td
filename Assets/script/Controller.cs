using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject score_text;
	public GameObject wave_text;
	public GameObject monster_text;

	public static Controller instance;

	public static Controller getInstance(){
		if (instance == null) {
			instance = GameObject.FindObjectOfType<Controller>();
			Debug.Log (instance == null);
		} 
		return instance;
	}
	// Use this for initialization
	void Start () {
//		Debug.Log (score_text.GetComponent<Text>().text);

	}
	
	// Update is called once per frame
	void Update () {
		GV.getInstance().score += Time.deltaTime;
		score_text.GetComponent<Text>().text = Mathf.Floor(GV.getInstance().score * 100).ToString();
	}

	public void gameover(){
		Debug.Log ("Game over!!");
	}

	public void nextWave(){
		wave_text.GetComponent<Text> ().text = (++GV.getInstance ().wave).ToString();
	}

	public void addMonster(){
		monster_text.GetComponent<Text>().text= (++GV.getInstance ().monster_amount).ToString();
	}

	public void killMonster(){
		if (GV.getInstance ().monster_amount > 0) {
			monster_text.GetComponent<Text>().text= (--GV.getInstance ().monster_amount).ToString();
		}
	}
}
