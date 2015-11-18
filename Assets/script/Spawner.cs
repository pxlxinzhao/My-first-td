using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Monster;
	public GameObject monster_amount_text;
	public Vector3 velocity;
	public float base_interval;
	public float waveCooldown;
	public float difficulty;
	public int amount;

	float time = 0;
	float generationTime = 0;
	float interval;
	bool canSpawn = true;
	int toCreate;
	// Use this for initialization
	void Start () {
//		createWave ();
		if (difficulty < 1) {
			Debug.LogError("Difficulty has to be greater than 1!!");
		}
		generationTime = time;
		interval = base_interval;
		toCreate = amount;
		base_interval = base_interval / velocity.x;
	}

	void Update () {
		time += Time.deltaTime;
		createWave ();
		if (time > generationTime + waveCooldown && GV.getInstance ().monster_amount <= 0) {
			Debug.Log("new Wave");
			amount = Mathf.FloorToInt(amount*difficulty);
			velocity.x *= difficulty;
			GV.getInstance().HP = Mathf.FloorToInt(GV.getInstance().HP*difficulty);
			toCreate = amount;
			generationTime = time;
			Controller.getInstance().nextWave();
			//base_interval = base_interval / velocity.x;
			base_interval = base_interval / difficulty;
			Debug.Log(base_interval);
		}
	}

	void createWave(){

		if ( canSpawn && time > generationTime && toCreate > 0) {
			generationTime += base_interval; 
			toCreate--;
			createMonster();
		}
	}


	void createMonster(){
		GameObject monster = Instantiate(Monster,
                         new Vector3(transform.position.x, transform.position.y, transform.position.z),
                         Quaternion.identity) as GameObject;
		monster.GetComponent<Monster> ().speed = velocity.x; 
		GV.getInstance().score++;
//		Debug.Log (string.Format("spawned new ememy has speed: {0}", monster.GetComponent<Monster> ().speed));
		Controller.getInstance().addMonster ();

	}
}
