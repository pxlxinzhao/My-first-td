using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject Tower;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector3 tower_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			GameObject tower = Instantiate(Tower, tower_position, Quaternion.identity) as GameObject;
			Vector3 v = tower.transform.position;
			v.z = 0;
			tower.transform.position = v;
		}
	}
}
